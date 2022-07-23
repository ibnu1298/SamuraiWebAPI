using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Helpers;
using SamuraiWebAPI.Data.DAL;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly IElement _elementDAL;
        private readonly IMapper _mapper;

        public ElementsController(IElement elementDAL, IMapper mapper)
        {
            _elementDAL = elementDAL;
            _mapper = mapper;
        }

        [HttpGet]//Read
        public async Task<IEnumerable<ReadDTO>> Get()
        {
            var results = await _elementDAL.GetAll();
            var elemnentDTO = _mapper.Map<IEnumerable<ReadDTO>>(results);
            return elemnentDTO;
        }
        [HttpGet("{id}")]//Read
        public async Task<ReadDTO> Get(int id)
        {
            var results = await _elementDAL.GetById(id);
            var elemnentDTO = _mapper.Map<ReadDTO>(results);
            return elemnentDTO;
        }
        [HttpPost]//Insert
        public async Task<ActionResult> Post(CreateDTO createElementDTO)
        {
            try
            {
                var newElement = new Element
                {
                    Name = createElementDTO.Name
                };
                var result = await _elementDAL.Insert(newElement);
                var elementReadDTO = new ReadDTO
                {
                    Id = result.Id,
                    Name = result.Name
                };
                return CreatedAtAction("Get", new { id = result.Id }, elementReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]//Update
        public async Task<ActionResult> Put(ReadDTO elementDTO)
        {
            try
            {
                var updateElement = new Element
                {
                    Id = elementDTO.Id,
                    Name = elementDTO.Name
                };
                var result = await _elementDAL.Update(updateElement);
                return Ok(elementDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")] //Delete
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _elementDAL.Delete(id);
                return Ok($"Data Element dengan id {id} Berhasil di delete");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("ByName/{name}")]
        public async Task<IEnumerable<ReadDTO>> GetByName(string name)
        {

            var results = await _elementDAL.GetByName(name);
            var elementDtos = _mapper.Map<IEnumerable<ReadDTO>>(results); ;

            return elementDtos;
        }
    }
}
