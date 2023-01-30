using EDP_WebAPI_Security.Context;
using EDP_WebAPI_Security.Dtos;
using EDP_WebAPI_Security.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDP_WebAPI_Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly RhContext _context;

        public AuthenticationController(RhContext context)
        {
            _context = context;
        }

        [HttpPost("/autenticar")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] EmployeeDto dto)
        {
            var user = await _context.Employee.Include(x => x.Profile).FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);
            if (user == null)
            {
                return BadRequest(new { Message = "Funcionário e/ou senha inválidos." });
            }
            var token = TokenService.GenerateToken(user);
            var result = new
            {
                token,
                User = new
                {
                    user.Id,
                    user.Name,
                    user.Email
                }
            };
            user.Password = "";
            return Ok(new { result });
        }


    }
}
