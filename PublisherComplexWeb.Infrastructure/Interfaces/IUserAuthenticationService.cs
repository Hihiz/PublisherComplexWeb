using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Infrastructure.Models;

namespace PublisherComplexWeb.Infrastructure.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<IBaseStatus> LoginAsync(LoginModel model);
        Task<IBaseStatus> RegisterAsync(RegistrationModel model);
        Task LogoutAsync();
    }
}
