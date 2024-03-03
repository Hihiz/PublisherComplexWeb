using Microsoft.AspNetCore.Http;
using PublisherComplexWeb.Application.Interfaces;
using System.Security.Claims;

namespace PublisherComplexWeb.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessot) => _httpContextAccessor = httpContextAccessot;

        public long UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                return string.IsNullOrEmpty(userId) ? 0 : Convert.ToInt16(userId);
            }
        }
    }
}
