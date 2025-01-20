using Application.ServiceInterfaces;
using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserInsertDto dto)
        {
            var result = await _userService.Register(dto);

            if (result)
            {
                return Ok("registered");
            }
            else
            {
                return BadRequest("user is already registered");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDto dto)
        {
            string token = await _userService.Login(dto);
            if (token == "")
            {
                return NotFound("not found");
            }
            else
            {
                //   HttpContext.Response.Cookies.Append("testttcoookie", token);
                return Ok(token);
                // return Ok("login");
            }
        }

        [Authorize]
        [HttpGet("TestAuthorize")]
        public async Task<IActionResult> TestAuthorize()
        {
            return Ok("hihi");
        }


        [Authorize]
        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            //  HttpContext.Response.Cookies.Delete("testttcoookie");
            return Ok();
        }
    }
}
