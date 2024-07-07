using CoensioApi.Data;
using CoensioApi.Data.Dtos;
using CoensioApi.Services.Abstracts;
using CoensioApi.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoensioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ICacheService _cacheService;
        private ApiDbContext _dbContext;
        private readonly IJwtTokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public AuthController(IConfiguration config, ICacheService cacheService, ApiDbContext dbContext, IJwtTokenService tokenService, IUserService userService, ILogger<Exception> logger)
        {
            _config = config;
            _cacheService = cacheService;
            _dbContext = dbContext;
            _tokenService = tokenService;
            _userService = userService;
            _logger = logger;
        }


        [HttpPost("Login"), AllowAnonymous]
        public IActionResult Login([FromBody] dtoLoginRequest loginRequest)
        {
            try
            {
                var isAdmin = _dbContext.Admins.SingleOrDefault(x => x.Email == loginRequest.Email);

                var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, loginRequest.Email),
                });

                if (isAdmin != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                }
                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                }

                var token = _tokenService.CreateAccessToken(identity);
                var isSet = _cacheService.SetData(loginRequest.Email, token.AccessToken);

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Logout"), Authorize(Roles = "admin, user")]
        public IActionResult Logout()
        {
            try
            {
                var userEmail = _userService.GetCurrentUserEmail();

                var userToken = _cacheService.GetData<string>(userEmail);
                if (userToken != null)
                {
                    _cacheService.RemoveData(userEmail);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
