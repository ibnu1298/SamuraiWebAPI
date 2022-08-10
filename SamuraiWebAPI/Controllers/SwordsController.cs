using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Helpers;
using SamuraiWebAPI.Data;
using SamuraiWebAPI.Data.DAL;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.Element;
using SamuraiWebAPI.Dtos.Sword;
using SamuraiWebAPI.Models;
using SamuraiWebAPI.Response;

namespace SamuraiWebAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController : ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SwordsController(ISword swordDAL, IMapper mapper, DataContext context)
        {
            _swordDAL = swordDAL;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]//Read
        public async Task<IEnumerable<SwordDTO>> Get()
        {
            var results = await _swordDAL.GetAll();
            var swordDTO = _mapper.Map<IEnumerable<SwordDTO>>(results);
            return swordDTO;
        }
        [HttpGet("Pagination/{page}")]//Read
        public async Task<IEnumerable<ReadSwordTypeDTO>> GetPage(int page)
        {
            var results = await _swordDAL.PaginationSword();
            var swordType = _mapper.Map<IEnumerable<ReadSwordTypeDTO>>(results);
            var record = 10;
            var finalSwords = swordType.Skip((page - 1) * record).Take(record).ToList();
            return finalSwords;
        }
        //[HttpGet("Pagnation2/{page}")]
        //public async Task<ActionResult<List<Sword>>> GetPage2(int page)
        //{
        //    if (_context.Swords == null)
        //        return NotFound();
        //    var pageResults = 5f;
        //    var pageCount = Math.Ceiling(_context.Swords.Count() / pageResults);
        //    var swords = await _context.Swords
        //        .Skip((page-1) * (int)pageResults)
        //        .Take((int)pageResults)
        //        .ToListAsync();

        //    var response = new SwordResponse
        //    {
        //        Swords = swords,
        //        CurrentPage = page,
        //        Pages = (int)pageCount
        //    };

        //    return Ok(response);
        //}

        [HttpGet("{id}")]//Read
        public async Task<SwordDTO> Get(int id)
        {
            var results = await _swordDAL.GetById(id);
            var swordDTO = _mapper.Map<SwordDTO>(results);
            return swordDTO;
        }
        [HttpPost]//Insert
        public async Task<ActionResult> Post(CreateSwordSamuraiDTO swordCreateDTO)
        {
            try
            {
                var newSword = new Sword
                {
                    Name = swordCreateDTO.Name,
                    Weight = swordCreateDTO.Weight,
                    SamuraiId = swordCreateDTO.SamuraiId
                };
                var result = await _swordDAL.Insert(newSword);
                var swordReadDTO = new SwordDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Weight = result.Weight
                };
                return CreatedAtAction("Get", new { id = result.Id }, swordReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddWithType")]
        public async Task<ActionResult> AddType(CreateSwordTypeDTO createSwordTypeDTO)
        //Dalam Membuat createDTO, pastikan semua kolom tabel yang ada pada Sword harus dimasukan kecuali Id dari Sword
        {
            try
            {
                var newSword = _mapper.Map<Sword>(createSwordTypeDTO);
                var result = await _swordDAL.Insert(newSword);
                var typeSwordDTO = _mapper.Map<ReadSwordTypeDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, typeSwordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]//Update
        public async Task<ActionResult<List<SwordDTO>>> updateSword(SwordDTO swordDTO)
        {
            var sword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == swordDTO.Id);
            if (sword == null)
                return BadRequest($"Sword dengan Id = {swordDTO.Id} Tidak ditemukan");
            sword.Name = swordDTO.Name;
            sword.Weight = swordDTO.Weight;
            await _context.SaveChangesAsync();
            return Ok(swordDTO);
        }

        [HttpDelete("{id}")] //Delete
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _swordDAL.Delete(id);
                return Ok($"Data samurai dengan id {id} Berhasil di delete");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("ByName/{name}")]
        public async Task<IEnumerable<SwordDTO>> GetByName(string name)
        {

            var results = await _swordDAL.GetByName(name);
            var swordDtos = _mapper.Map<IEnumerable<SwordDTO>>(results); ;

            return swordDtos;
        }

        [HttpGet("Element")]
        public async Task<IEnumerable<SwordElementDTO>> GetSwordElement()
        {
            List<SwordElementDTO> swordElementDtos = new List<SwordElementDTO>();
            var results = await _swordDAL.GetSwordWithElements();
            foreach (var result in results)
            {
                List<ReadDTO> elementDtos = new List<ReadDTO>();
                foreach (var element in result.Elements)
                {
                    elementDtos.Add(new ReadDTO
                    {
                        Id = element.Id,
                        Name = element.Name
                    });
                }

                swordElementDtos.Add(new SwordElementDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Weight = result.Weight,
                    Elements = elementDtos
                });
            }
            return swordElementDtos;
        }
        [HttpPost("AddSwordToElement")]// Mendaftarkan existing Sword ke Element dan sebaliknya
        public async Task<ActionResult> AddSwordToElement(AddSwordToElementDTO addSE)
        {
            var element = _context.Elements.FirstOrDefault(e => e.Id == addSE.ElementsId);
            var sword = _context.Swords.FirstOrDefault(s => s.Id == addSE.SwordsId);
            if (element == null || sword == null) throw new("Data dengan Id tersebut tidak ditemukan\n\n\n");
            element.Swords.Add(sword);
            _context.SaveChangesAsync();
            return Ok($"Data Berhasil Ditambahkan");
        }
        [HttpDelete("DeleteElements/{Id}")]
        public async Task<ActionResult> DeleteElementFromSword(int Id)
        {
            try
            {
                await _swordDAL.DeleteElement(Id);
                return Ok($"Berhasil Menghapus Element pada Sword dengan Id = {Id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
