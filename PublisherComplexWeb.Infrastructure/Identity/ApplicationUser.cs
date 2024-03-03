using Microsoft.AspNetCore.Identity;

namespace PublisherComplexWeb.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime RegisteredIn { get; set; } = DateTime.UtcNow;

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
