using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Models;
using SampleWebAPI.Services;
using SamuraiWebAPI.Dtos.User;
using SamuraiWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Resgistration(CreateUserDTO userDTO)
        {
            try
            {
                var newUser = _mapper.Map<User>(userDTO);
                var response = await _userService.Registration(newUser);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(AuthenticateRequest model)
        {
            var response = _userService.Login(model);
            if (response == null)
                return BadRequest(new { message = "UserName Or Password Is Incorrect" });
            return Ok(response);
        }

    }
}