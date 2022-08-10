using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Helpers;
using SamuraiWebAPI.Data;
using SamuraiWebAPI.Data.DAL;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.Demon;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DemonsController : ControllerBase
    {
        private readonly IDemon _demonDAL;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DemonsController( IDemon demonDAL, IMapper mapper, DataContext context)
        {
            _demonDAL = demonDAL;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ReadDemonDTO>> Get()
        {
            var results = await _demonDAL.GetAll();
            var demon = _mapper.Map<IEnumerable<ReadDemonDTO>>(results);
            return demon;
        }
        [HttpGet("{id}")]
        public async Task<ReadDemonDTO> Get(int id)
        {
            var results = await _demonDAL.GetById(id);
            var sword = _mapper.Map<ReadDemonDTO>(results);
            return sword;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateDemonDTO demonCreateDTO)
        {
            try
            {
                var newDemon = _mapper.Map<Demon>(demonCreateDTO);
                var result = await _demonDAL.Insert(newDemon);
                var demon = _mapper.Map<ReadDemonDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, demon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<ReadDemonDTO>>> updateDemon(ReadDemonDTO demonDTO)
        {
            var demon = await _context.Demons.FirstOrDefaultAsync(d => d.Id == demonDTO.Id);
            if (demon == null)
                return BadRequest($"Demon dengan Id = {demonDTO.Id} Tidak ditemukan");
            demon.Name = demonDTO.Name;
            demon.Level = demonDTO.Level;
            await _context.SaveChangesAsync();
            return Ok(demonDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _demonDAL.Delete(id);
                return Ok($"Data Demon dengan id {id} Berhasil di delete");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("ByName/{name}")]
        public async Task<IEnumerable<ReadDemonDTO>> GetByName(string name)
        {

            var results = await _demonDAL.GetByName(name);
            var demon = _mapper.Map<IEnumerable<ReadDemonDTO>>(results); ;

            return demon;
        }
        [HttpGet("Element")]
        public async Task<IEnumerable<DemonWithElementsDTO>> GetDemonElement()
        {
            List<DemonWithElementsDTO> demonElementDtos = new List<DemonWithElementsDTO>();
            var results = await _demonDAL.GetDemonWithElement();
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

                demonElementDtos.Add(new DemonWithElementsDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Level = result.Level,
                    Elements = elementDtos
                });
            }
            return demonElementDtos;
        }
    }
}
