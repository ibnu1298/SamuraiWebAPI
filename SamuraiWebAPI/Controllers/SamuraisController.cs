using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Helpers;
using SamuraiWebAPI.Data;
using SamuraiWebAPI.Data.DAL;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.Samurai;
using SamuraiWebAPI.Dtos.Sword;
using SamuraiWebAPI.Dtos.TypeSword;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samuraiDAL;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SamuraisController(ISamurai samuraiDAL, IMapper mapper, DataContext context)
        {
            _samuraiDAL = samuraiDAL;
            _mapper = mapper;
            _context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ReadDTO>> Get()
        {
            var results = await _samuraiDAL.GetAll();
            var samuraiDTO = _mapper.Map<IEnumerable<ReadDTO>>(results);
            return samuraiDTO;
        }
        [HttpGet("{id}")]
        public async Task<ReadDTO> Get(int id)
        {
            var results = await _samuraiDAL.GetById(id);
            var samuraiDTO = _mapper.Map<ReadDTO>(results);
            return samuraiDTO;
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samuraiDAL.Insert(newSamurai);
                var samuraiDTO = _mapper.Map<ReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, samuraiDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(ReadDTO samuraiDTO)
        {
            try
            {
                var updateSamurai = new Samurai
                {
                    Id = samuraiDTO.Id,
                    Name = samuraiDTO.Name
                };
                var result = await _samuraiDAL.Update(updateSamurai);
                return Ok(samuraiDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samuraiDAL.Delete(id);
                return Ok($"Data samurai dengan id {id} Berhasil di delete");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("ByName/{name}")]
        public async Task<IEnumerable<ReadDTO>> GetByName(string name)
        {

            var results = await _samuraiDAL.GetByName(name);
            var samuraiDtos = _mapper.Map<IEnumerable<ReadDTO>>(results); ;

            return samuraiDtos;
        }
        [HttpGet("Battle")]
        public async Task<IEnumerable<SamuraiBattleDTO>> GetSamuraiWithBattles()
        {
            var results = await _samuraiDAL.GetSamuraiWithBattles();
            var samuraiBattleDtos = _mapper.Map<IEnumerable<SamuraiBattleDTO>>(results);
            return samuraiBattleDtos;
        }

        [HttpGet("SamuraiSTE")]
        public async Task<IEnumerable<SamuraiSwordElementDTO>> GetSamuraiPack()
        {
            var results = await _samuraiDAL.GetSamuraiWithSE();
            var samuraiDTO = _mapper.Map<IEnumerable<SamuraiSwordElementDTO>>(results);
            return samuraiDTO;
        }

        [HttpPost("AddWithSword")]
        public async Task<ActionResult> AddSamuraiWithSwords(CreateSamuraiSword samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samuraiDAL.Insert(newSamurai);
                var samuraiDTO = _mapper.Map<ReadSamuraiSword>(result);

                return CreatedAtAction("Get", new { id = result.Id }, samuraiDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
