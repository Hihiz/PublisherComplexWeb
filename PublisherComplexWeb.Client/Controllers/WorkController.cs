using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Controllers
{
    public class WorkController : Controller
    {       
        private readonly ContextSession _contextSession;
        private readonly IApiDataHandler _apiDataHandler;

        public WorkController(ContextSession contextSession, IApiDataHandler apiDataHandler) => (_contextSession, _apiDataHandler)
            =  (contextSession, apiDataHandler);

        public async Task<IActionResult> GetWorks()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            List<Work> works = new List<Work>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/work"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(apiResponse);
                    JToken data = json["data"];

                    works = data.ToObject<List<Work>>();
                }
            }

            return View(works);
        }

        public async Task<IActionResult> GetWorkDetail(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            Work work = new Work();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/work/workDetail/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(apiResponse);
                    JToken data = json["data"];

                    work = data.ToObject<Work>();
                }
            }

            return View(work);
        }

        public async Task<IActionResult> GetWorksOrder(int orderId)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            List<Work> worksOrder = new List<Work>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/work/{orderId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(apiResponse);
                    JToken data = json["data"];

                    worksOrder = data.ToObject<List<Work>>();
                }
            }

            return View(worksOrder);
        }

        public async Task<IActionResult> CreateWork()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            await _apiDataHandler.HandleApiDataList<TypeWork>("https://localhost:7101/api/typeWork", "TypeWorkList", "Id", "Title", ViewData);
            await _apiDataHandler.HandleApiDataList<Material>("https://localhost:7101/api/material", "MaterialList", "Id", "Title", ViewData);
            await _apiDataHandler.HandleApiDataList<Format>("https://localhost:7101/api/format", "FormatList", "Id", "Title", ViewData);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWork(Work work)
        {
            Work workCreate = new Work();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/work", work))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                  
                    JObject json = JObject.Parse(apiResponse);
                    JToken data = json["data"];

                    workCreate = data.ToObject<Work>();
                }
            }

            return RedirectToAction("GetWorks", "Work");
        }

        public async Task<IActionResult> UpdateWork(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            Work workDetail = new Work();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/work/workDetail/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(apiResponse);
                    JToken data = json["data"];

                    workDetail = data.ToObject<Work>();
                }

                await _apiDataHandler.HandleApiDataList<TypeWork>("https://localhost:7101/api/typeWork", "TypeWorkList", "Id", "Title", ViewData);
                await _apiDataHandler.HandleApiDataList<Material>("https://localhost:7101/api/material", "MaterialList", "Id", "Title", ViewData);
                await _apiDataHandler.HandleApiDataList<Format>("https://localhost:7101/api/format", "FormatList", "Id", "Title", ViewData);
            }

            return View(workDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWork(Work work)
        {
            Work workUpdate = new Work();

            using (HttpClient httpClient = new HttpClient())
            {               
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7101/api/work/{work.Id}", work))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(apiResponse);
                    JToken data = json["data"];

                    workUpdate = data.ToObject<Work>();
                }
            }

            return RedirectToAction("GetWorks", "Work");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWork(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {                
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7101/api/work/{id}");            
            }

            return RedirectToAction("GetWorks", "Work");
        }
    }
}
