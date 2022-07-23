using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Helpers;
using SamuraiWebAPI.Data.DAL;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.TypeSword;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSwordsController : ControllerBase
    {
        private readonly ITypeSword _typeSword;
        private readonly IMapper _mapper;

        public TypeSwordsController(ITypeSword typeSword, IMapper mapper)
        {
            _typeSword = typeSword;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReadDTO>> Get()
        {
            var results = await _typeSword.GetAll();
            var typeSwordDTO = _mapper.Map<IEnumerable<ReadDTO>>(results);
            return typeSwordDTO;
        }
        [HttpGet("{id}")]
        public async Task<ReadDTO> Get(int id)
        {
            var results = await _typeSword.GetById(id);
            var typeSwordDTO = _mapper.Map<ReadDTO>(results);
            return typeSwordDTO;
        }
        [HttpPost]
        public async Task<ActionResult> Post(createTypeSwordDTO createTypeDTO)
        {
            try
            {
                var newType = _mapper.Map<TypeSword>(createTypeDTO);
                var result = await _typeSword.Insert(newType);
                var typeSwordDTO = _mapper.Map<TypeSwordDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, typeSwordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(TypeSwordDTO typeSwordDTO)
        {
            try
            {
                var updateType= new TypeSword
                {
                    Id = typeSwordDTO.Id,
                    Name = typeSwordDTO.Name,
                    SwordId = typeSwordDTO.SwordId
                };
                var result = await _typeSword.Update(updateType);
                return Ok(typeSwordDTO);

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
                await _typeSword.Delete(id);
                return Ok($"Type Sword dengan id {id} Berhasil di delete");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("ByName/{name}")] // Auto Mapper
        public async Task<IEnumerable<ReadDTO>> GetByName(string name)
        {

            var results = await _typeSword.GetByName(name);
            var typeSwordDTO = _mapper.Map<IEnumerable<ReadDTO>>(results); ;

            return typeSwordDTO;
        }

    }
}
