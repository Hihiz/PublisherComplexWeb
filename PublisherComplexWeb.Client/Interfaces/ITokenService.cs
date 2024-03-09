using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Interfaces
{
    public interface ITokenService
    {
        Task<TokenModel> RefreshToken(TokenModel token);
    }
}
