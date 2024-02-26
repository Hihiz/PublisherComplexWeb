using PublisherComplexWeb.Application.Interfaces;

namespace PublisherComplexWeb.Infrastructure.Models
{
    public class StatusAuthResponse : IBaseStatus
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
