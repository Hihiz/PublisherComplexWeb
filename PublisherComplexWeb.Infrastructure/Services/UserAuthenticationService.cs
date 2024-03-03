using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PublisherComplexWeb.Application.Dto.User;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Enums;
using PublisherComplexWeb.Infrastructure.Data;
using PublisherComplexWeb.Infrastructure.Identity;
using PublisherComplexWeb.Infrastructure.Interfaces;
using PublisherComplexWeb.Infrastructure.Models;
using System.Security.Claims;

namespace PublisherComplexWeb.Infrastructure.Services
{
    public class UserAuthenticationService : IUserAuthenticationService, IUserAuthService<UserDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public UserAuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IConfiguration configuration) =>
            (_userManager, _signInManager, _db, _configuration) = (userManager, signInManager, db, configuration);

        public async Task<List<UserDto>> GetAuthUsers()
        {
            List<ApplicationUser> users = await _db.Users.ToListAsync();

            List<UserDto> usersDto = users.Select(u => new UserDto()
            {
                Id = u.Id,
                Fio = $"{u.FirstName} {u.LastName}",
                Email = u.Email
            }).ToList();

            return usersDto;
        }

        public async Task<IBaseStatus> RegisterAsync(RegistrationModel model)
        {
            ApplicationUser userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
            {
                return new StatusResponse
                {
                    StatusCode = (int)ErrorCode.AlreadyExists,
                    Message = "Пользователь уже существует"
                };
            }

            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new StatusResponse
                {
                    StatusCode = (int)ErrorCode.BadRequest,
                    Message = "Не удалось создать пользователя"
                };
            }

            ApplicationUser findUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (findUser == null)
            {
                return new StatusResponse
                {
                    StatusCode = (int)ErrorCode.BadRequest,
                    Message = $"Пользователь {model.FirstName} {model.LastName} не найден"
                };
            }

            await _userManager.AddToRoleAsync(findUser, "Member");

            return new StatusResponse
            {
                StatusCode = (int)ErrorCode.OK,
                Message = ErrorCode.OK.ToString()
            };
        }

        public async Task<IBaseStatus> LoginAsync(LoginModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new StatusResponse
                {
                    StatusCode = (int)ErrorCode.BadRequest,
                    Message = "Неверное имя пользователя"
                };
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new StatusResponse
                {
                    StatusCode = (int)ErrorCode.BadRequest,
                    Message = "Неверный пароль"
                };
            }

            List<long> roleId = await _db.UserRoles.Where(u => u.UserId == user.Id).Select(u => u.RoleId).ToListAsync();
            List<IdentityRole<long>> roles = _db.Roles.Where(x => roleId.Contains(x.Id)).ToList();

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (!signInResult.Succeeded)
            {
                return new StatusResponse
                {
                    StatusCode = (int)ErrorCode.BadRequest,
                    Message = ErrorCode.BadRequest.ToString()
                };
            }

            // Список ролей пользователя
            //IList<string> userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                      //new Claim(ClaimTypes.Role, string.Join(" ", roles.Select(x => x.Name)))
                };

            foreach (var userRole in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole.Name!));
            }

            string accessToken = _configuration.GenerateAccessToken(authClaims);
            user.RefreshToken = TokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddSeconds(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            await _db.SaveChangesAsync();

            return new StatusAuthResponse
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = roles.Select(r => r.Name).ToList(),
                AccessToken = accessToken,
                RefreshToken = user.RefreshToken,
                StatusCode = (int)ErrorCode.OK,
                Message = ErrorCode.OK.ToString()
            };
        }

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();
    }
}
