using Newtonsoft.Json;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Services
{
    public class TokenService : ITokenService
    {
        public async Task<TokenModel> RefreshToken(TokenModel token)
        {
            TokenModel newToken = new TokenModel();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/account/refresh", token))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    newToken = JsonConvert.DeserializeObject<TokenModel>(apiResponse);
                }
            }

            return newToken;
        }
    }
}
