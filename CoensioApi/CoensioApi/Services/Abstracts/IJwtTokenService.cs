using CoensioApi.Data.Dtos;
using System.Security.Claims;

namespace CoensioApi.Services.Abstracts
{
    public interface IJwtTokenService
    {
        dtoToken CreateAccessToken(ClaimsIdentity identity);
    
    }
}
