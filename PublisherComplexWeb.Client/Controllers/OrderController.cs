using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;
using PublisherComplexWeb.Client.Models.ViewModels;

namespace PublisherComplexWeb.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly RequestAuthUser _requestAuthUser;
        private readonly ContextSession _contextSession;
        private readonly IApiDataHandler _apiDataHandler;
        private readonly ITokenService _tokenService;

        public OrderController(RequestAuthUser requestAuthUser, ContextSession contextSession, IApiDataHandler apiDataHandler, ITokenService tokenService) =>
            (_requestAuthUser, _contextSession, _apiDataHandler, _tokenService)
            = (requestAuthUser, contextSession, apiDataHandler, tokenService);

        public async Task<IActionResult> GetOrders()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            OrderListViewModel orders = new OrderListViewModel();

            using (HttpClient httpClient = new HttpClient())
            {              
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/order"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    orders = JsonConvert.DeserializeObject<OrderListViewModel>(apiResponse);
                }
            }

            return View(orders);
        }

        public async Task<IActionResult> GetOrderDetail(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            OrderDetailViewModel order = new OrderDetailViewModel();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/order/{id}"))
                {
                    order.Data = await _apiDataHandler.ExtractApiData<Order>(response);
                }

                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/work/{id}"))
                {
                    order.Work = await _apiDataHandler.ExtractApiDataList<Work>(response);
                }
            }

            return View(order);
        }

        public async Task<IActionResult> GetOpenOrders()
        {
            List<Order> openOrders = [];

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/orderOpen"))
                {
                    openOrders = await _apiDataHandler.ExtractApiDataList<Order>(response);
                }
            }

            return View(openOrders);
        }

        public async Task<IActionResult> GetCloseOrders()
        {
            List<Order> closeOrders = [];

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/orderClose"))
                {
                    closeOrders = await _apiDataHandler.ExtractApiDataList<Order>(response);
                }
            }

            return View(closeOrders);
        }

        public async Task<IActionResult> CreateOrder()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            List<User> users = new List<User>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/account/authUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            Order orderCreate = new Order();

            using (HttpClient httpClient = new HttpClient())
            {                
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/order", order))
                {                  
                    orderCreate = await _apiDataHandler.ExtractApiData<Order>(response);
                }
            }

            return RedirectToAction("GetOrders", "Order");
        }

        public async Task<IActionResult> UpdateOrder(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            OrderViewModel order = new OrderViewModel();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/order/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    order = JsonConvert.DeserializeObject<OrderViewModel>(apiResponse);
                }

                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/account/authUsers"))
                {
                    List<User> users = new List<User>();

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    users = JsonConvert.DeserializeObject<List<User>>(apiResponse);                   
                }

                return View(order);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderViewModel order)
        {
            using (HttpClient httpClient = new HttpClient())
            {                
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7101/api/order/{order.Data.Id}", order.Data))
                {                    
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetOrders", "Order");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {               
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7101/api/order/{id}");

            }

            return RedirectToAction("GetOrders", "Order");
        }
    }
}
