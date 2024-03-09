using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Controllers
{
    public class MaterialController : Controller
    {
        private readonly RequestAuthUser _requestAuthUser;
        private readonly ContextSession _contextSession;
        private readonly IApiDataHandler _apiDataHandler;

        public MaterialController(RequestAuthUser requestAuthUser, ContextSession contextSession, IApiDataHandler apiDataHandler) => (_requestAuthUser, _contextSession, _apiDataHandler)
            = (requestAuthUser, contextSession, apiDataHandler);

        public async Task<IActionResult> GetMaterials()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            List<Material> materials = new List<Material>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/material"))
                {
                    materials = await _apiDataHandler.ExtractApiDataList<Material>(response);
                }
            }

            return View(materials);
        }

        public async Task<IActionResult> GetMaterialDetail(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            Material material = new Material();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/material/{id}"))
                {
                    material = await _apiDataHandler.ExtractApiData<Material>(response);
                }
            }

            return View(material);
        }

        public async Task<IActionResult> CreateMaterial()
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);


            await _apiDataHandler.HandleApiDataList<Material>("https://localhost:7101/api/device", "DeviceList", "Id", "Title", ViewData);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial(Material material)
        {
            Material materialCreate = new Material();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/material", material))
                {
                    materialCreate = await _apiDataHandler.ExtractApiData<Material>(response);
                }
            }

            return RedirectToAction("GetMaterials", "Material");
        }

        public async Task<IActionResult> UpdateMaterial(int id)
        {
            _contextSession.SetViewDataCurrentAuthUser(ViewData, HttpContext.Session);

            Material materialDetail = new Material();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/material/{id}"))
                {
                    materialDetail = await _apiDataHandler.ExtractApiData<Material>(response);
                }
            }

            await _apiDataHandler.HandleApiDataList<Device>($"https://localhost:7101/api/device", "DeviceList", "Id", "Title", ViewData);

            return View(materialDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMaterial(Material material)
        {
            Material materialUpdate = new Material();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");

                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7101/api/material/{material.Id}", material))
                {
                    materialUpdate = await _apiDataHandler.ExtractApiData<Material>(response);
                }
            }

            return RedirectToAction("GetMaterials", "Material");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_contextSession.GetAccessToken(HttpContext.Session)}");
                using HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7101/api/material/{id}");

            }

            return RedirectToAction("GetMaterials", "Material");
        }
    }
}
