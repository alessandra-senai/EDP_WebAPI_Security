using EDP_WebAPI_Security.Models;

namespace EDP_WebAPI_Security.Services
{
    public interface ITokenService
    {
         string GenerateToken(Employee employee);
    }
}
