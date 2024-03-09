using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly ContextSession _contextSession;

        public AccountController(ContextSession contextSession)
        {
            _contextSession = contextSession;
        }

        public async Task<IActionResult> Register()
        {          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel register)
        {
            StatusAuthResponse status = new StatusAuthResponse();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/account/register", register))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    status = JsonConvert.DeserializeObject<StatusAuthResponse>(apiResponse);

                    if (status.StatusCode == 400)
                    {
                        TempData["statusMessage"] = status.Message;

                        return View();
                    }
                }
            }

            return await Login(new LoginModel
            {
                Email = register.Email,
                Password = register.Password
            });
        }

        public async Task<IActionResult> Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            StatusAuthResponse statusResponse = new StatusAuthResponse();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/account/login", login))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    statusResponse = JsonConvert.DeserializeObject<StatusAuthResponse>(apiResponse);

                    if (statusResponse.StatusCode == 400)
                    {
                        TempData["statusMessage"] = statusResponse.Message;

                        return View();
                    }

                    _contextSession.SetStringContext(HttpContext.Session, statusResponse);

                    return RedirectToAction("GetOrders", "Order");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {         
            HttpContext.Session.Clear();
            return RedirectToAction("GetOrders", "Order");
        }
    }
}
