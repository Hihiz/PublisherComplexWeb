using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Controllers
{
    public class TypeWorkController : Controller
    {
        private readonly RequestAuthUser _requestAuthUser;
        private readonly ContextSession _contextSession;
        private readonly IApiDataHandler _apiDataHandler;

        public TypeWorkController(RequestAuthUser requestAuthUser, ContextSession contextSession, IApiDataHandler apiDataHandler) => (_requestAuthUser, _contextSession, _apiDataHandler)
            = (requestAuthUser, contextSession, apiDataHandler);

        public async Task<IActionResult> GetTypeWorks()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            List<TypeWork> typeWorks = new List<TypeWork>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/typeWork"))
                {
                    typeWorks = await _apiDataHandler.ExtractApiDataList<TypeWork>(response);
                }
            }

            return View(typeWorks);
        }

        public async Task<IActionResult> GetTypeWorkDetail(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            TypeWork typeWork = new TypeWork();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/typeWork/{id}"))
                {
                    typeWork = await _apiDataHandler.ExtractApiData<TypeWork>(response);
                }
            }

            return View(typeWork);
        }

        public async Task<IActionResult> CreateTypeWork()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeWork(TypeWork typeWork)
        {
            TypeWork typeWorkCreate = new TypeWork();

            using (HttpClient httpClient = new HttpClient())
            {             
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/typeWork", typeWork))
                {                  
                    typeWorkCreate = await _apiDataHandler.ExtractApiData<TypeWork>(response);
                }
            }

            return RedirectToAction("GetTypeWorks", "TypeWork");
        }

        public async Task<IActionResult> UpdateTypeWork(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            TypeWork typeWorkDetail = new TypeWork();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/typeWork/{id}"))
                {
                    typeWorkDetail = await _apiDataHandler.ExtractApiData<TypeWork>(response);
                }
            }

            return View(typeWorkDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTypeWork(TypeWork typeWork)
        {
            TypeWork typeWorkUpdate = new TypeWork();

            using (HttpClient httpClient = new HttpClient())
            {              
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7101/api/typeWork/{typeWork.Id}", typeWork))
                {                  
                    typeWorkUpdate = await _apiDataHandler.ExtractApiData<TypeWork>(response);
                }
            }

            return RedirectToAction("GetTypeWorks", "TypeWork");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTypeWork(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {             
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7101/api/typeWork/{id}");                
            }

            return RedirectToAction("GetTypeWorks", "TypeWork");
        }
    }
}
