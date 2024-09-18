using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApi.DTOs;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterUserAsync(registerDto);

            if (result == "User already exists!")
            {
                return Conflict(new { message = result });
            }
            
            return Ok(new {message = result});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.LoginUserAsync(loginDto);

            if (token == "Invalid email or password!")
            {
                return Unauthorized(new { message = token });
            }

            return Ok(new { token });
        }
    }
}