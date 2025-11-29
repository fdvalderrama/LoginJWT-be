using LoginJWT_be.Models;
using LoginJWT_be.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginJWT_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly JwtService _jwtService;

        private readonly Context _context;

        public AuthController(JwtService jwtService, Context context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if(string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Completa todos los campos");
            }

            var query = await _context.Users
                .Where(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password)
                .Select(u => new {u.Id, u.Name, u.Role}).FirstOrDefaultAsync();

            if (query == null)
            {
                return Unauthorized("Campos incorrectos");
            }
                
            var userDto = new UserDto { Id = query.Id, Name = query.Name, Role = query.Role };

            var token = _jwtService.GenerateToken(userDto);

            return Ok(token);
        }
    }
}
