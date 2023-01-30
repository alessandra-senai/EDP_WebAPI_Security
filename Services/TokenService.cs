using EDP_WebAPI_Security.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EDP_WebAPI_Security.Services
{
    public class TokenService
    {
        public static string GenerateToken(Employee employee)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("jHt8byq8Sj4PQkz5y6vEt5GfgRKxqkH8wfxaxYG4bQCd24ac4nD6rTmjz3fgqPc2gKJL5L");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", employee.Id.ToString()),
                    new Claim(ClaimTypes.Name, employee.Name),
                    new Claim(ClaimTypes.Role, employee.Profile.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
