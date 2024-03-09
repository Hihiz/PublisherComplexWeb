using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.User;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Infrastructure.Interfaces;
using PublisherComplexWeb.Infrastructure.Models;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAuthenticationService _authService;
        private readonly IUserAuthService<UserDto> _userService;

        public AccountController(IUserAuthenticationService authService, IUserAuthService<UserDto> userService) => (_authService, _userService) = (authService, userService);

        [HttpGet("authUsers")]
        public async Task<ActionResult> GetAllUser() => Ok(await _userService.GetAuthUsers());

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }

            return Ok(await _authService.RegisterAsync(registration));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Authenticate(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }

            return Ok(await _authService.LoginAsync(loginModel));
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> RefreshToken(TokenModel token) => Ok(await _authService.RefreshToken(token));

        [HttpPost("revoke/{username}")]
        public async Task<ActionResult> Revoke(string username) => Ok(await _authService.RevokeUser(username));

        [HttpPost("revokeAll")]
        public async Task<ActionResult> RevokeAll() => Ok(await _authService.RevokeAll());

        [HttpPost("logout")]
        public async Task Logout() => await _authService.LogoutAsync();      
    }
}
