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

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }

            return Ok(await _authService.RegisterAsync(registration));
        }
    }
}
