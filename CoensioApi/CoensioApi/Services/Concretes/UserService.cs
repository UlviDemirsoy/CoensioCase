using CoensioApi.Services.Abstracts;
using System.Security.Claims;

namespace CoensioApi.Services.Concretes
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserEmail()
        {
            var result = string.Empty;
            if (_httpContextAccessor != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            }
            return result;
        }
    }
}
