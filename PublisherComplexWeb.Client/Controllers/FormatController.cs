using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Controllers
{
    public class FormatController : Controller
    {
        private readonly RequestAuthUser _requestAuthUser;
        private readonly ContextSession _contextSession;
        private readonly IApiDataHandler _apiDataHandler;

        public FormatController(RequestAuthUser requestAuthUser, ContextSession contextSession, IApiDataHandler apiDataHandler) => (_requestAuthUser, _contextSession, _apiDataHandler)
            = (requestAuthUser, contextSession, apiDataHandler);

        public async Task<IActionResult> GetFormats()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            List<Format> formats = new List<Format>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/format"))
                {
                    formats = await _apiDataHandler.ExtractApiDataList<Format>(response);
                }
            }

            return View(formats);
        }

        public async Task<IActionResult> GetFormatDetail(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            Format format = new Format();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/format/{id}"))
                {
                    format = await _apiDataHandler.ExtractApiData<Format>(response);
                }
            }

            return View(format);
        }

        public async Task<IActionResult> CreateFormat()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFormat(Format format)
        {
            Format formatCreate = new Format();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/format", format))
                {
                    formatCreate = await _apiDataHandler.ExtractApiData<Format>(response);
                }
            }

            return RedirectToAction("GetFormats", "Format");
        }

        public async Task<IActionResult> UpdateFormat(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            Format formatDetail = new Format();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/format/{id}"))
                {
                    formatDetail = await _apiDataHandler.ExtractApiData<Format>(response);
                }
            }

            return View(formatDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFormat(Format format)
        {
            Format formatUpdate = new Format();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7101/api/format/{format.Id}", format))
                {
                    formatUpdate = await _apiDataHandler.ExtractApiData<Format>(response);
                }
            }

            return RedirectToAction("GetFormats", "Format");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFormat(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7101/api/format/{id}");
            }

            return RedirectToAction("GetFormats", "Format");
        }
    }
}
