using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Client.Interfaces;
using PublisherComplexWeb.Client.Models;

namespace PublisherComplexWeb.Client.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IApiDataHandler _apiDataHandler;

        public DeviceController(IApiDataHandler apiDataHandler) => _apiDataHandler = apiDataHandler;

        public async Task<IActionResult> GetDevices()
        {
            List<Device> devices = new List<Device>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7101/api/device"))
                {
                    devices = await _apiDataHandler.ExtractApiDataList<Device>(response);
                }
            }

            return View(devices);
        }

        public async Task<IActionResult> GetDeviceDetail(int id)
        {
            Device device = new Device();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/deivce/{id}"))
                {
                    device = await _apiDataHandler.ExtractApiData<Device>(response);
                }
            }

            return View(device);
        }

        public async Task<IActionResult> CreateDevice()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice(Device device)
        {
            Device deviceCreate = new Device();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7101/api/device", device))
                {
                    if (!response.IsSuccessStatusCode)
                    {

                    }

                    deviceCreate = await _apiDataHandler.ExtractApiData<Device>(response);
                }
            }

            return RedirectToAction("GetDevice", "Device");
        }

        public async Task<IActionResult> UpdateDevice(int id)
        {
            Device deviceDetail = new Device();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7101/api/device/{id}"))
                {
                    deviceDetail = await _apiDataHandler.ExtractApiData<Device>(response);
                }
            }

            return View(deviceDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDevice(Device device)
        {
            Device deviceUpdate = new Device();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7101/api/device/{device.Id}", device))
                {
                    deviceUpdate = await _apiDataHandler.ExtractApiData<Device>(response);
                }
            }

            return RedirectToAction("GetDevices", "Device");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7101/api/device/{id}");
            }

            return RedirectToAction("GetDevices", "Device");
        }
    }
}
