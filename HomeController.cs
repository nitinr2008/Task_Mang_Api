using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using Task_Mang_Api.Models;
using TaskmanagementWebApp.Models;

namespace TaskmanagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
         {
            List<LeaveTypeViewModel> lst = new List<LeaveTypeViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5050");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/Leave/GetLeaveType").Result;
                client.Dispose();
                if (response.IsSuccessStatusCode)
                {
                    string stgdata = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<List<LeaveTypeViewModel>>(stgdata);
                    return View(lst);
                }
                else
                {
                    TempData["error"] = $"{response.ReasonPhrase}";
                }
            }
            return View();
        }

       
        public JsonResult GetAllType()
        {
            List<LeaveTypeViewModel> lst = new List<LeaveTypeViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5050");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/Leave/GetLeaveType").Result;
                client.Dispose();
                if (response.IsSuccessStatusCode)
                {
                    string stgdata = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<List<LeaveTypeViewModel>>(stgdata);

                }
                else
                {
                    TempData["error"] = $"{response.ReasonPhrase}";
                }
            }

            return Json(new {data=lst,recordFilter=lst.Count(),recordLength=lst.Count()});
        }

       public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocati on.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
