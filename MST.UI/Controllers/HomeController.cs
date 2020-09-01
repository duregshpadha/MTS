using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MST.UI.Models;
using MST.UI.Models.Responce;
using MTS.Constants.WebsiteMessagesConstants;
using Newtonsoft.Json;

namespace MST.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        private readonly IConfiguration _config;


        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MedicineViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                string baseUrl = _config["APISettings:BaseUrl"] + "AddMedicine";
                HttpResponseMessage response = await client.PostAsync(baseUrl, stringContent);
                string result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<dynamic>(result);
                if (!response.IsSuccessStatusCode)
                {
                    ErrorMessage = res.message;
                }
                else
                {
                    SuccessMessage = res.message;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Medicine(string id)
        {
            using (var client = new HttpClient())
            {
                string baseUrl = _config["APISettings:BaseUrl"] + "medicine?id=" + id;
                HttpResponseMessage response = await client.GetAsync(baseUrl);
                string result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<dynamic>(result);
                if (!response.IsSuccessStatusCode)
                {
                    ErrorMessage = res.message;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    string Result = await response.Content.ReadAsStringAsync();
                    MedicineResponce medecine = JsonConvert.DeserializeObject<MedicineResponce>(Result);
                    return View(medecine.data);
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> Medicine(MedicineViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var client = new HttpClient())
            {
                string baseUrl = _config["APISettings:BaseUrl"] + "UpdateMedicine?id=" + model.Id + "&notes=" + model.Notes;
                HttpResponseMessage response = await client.GetAsync(baseUrl);
                string result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<dynamic>(result);
                if (!response.IsSuccessStatusCode)
                {
                    ErrorMessage = res.message;
                }
                else
                {
                    SuccessMessage = res.message;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMedicine(string id)
        {
            using (var client = new HttpClient())
            {
                string baseUrl = _config["APISettings:BaseUrl"] + "DeleteMedicine?id=" + id;
                HttpResponseMessage response = await client.GetAsync(baseUrl);
                string result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<dynamic>(result);
                string message = res.message;
                return Json(data: message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
