using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Task_Mang_Api.Models;
using Task_Mang_Api.Models.View_Model;
using TaskmanagementWebApp.Models;

namespace TaskmanagementWebApp.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult Index()
        {
           List<EmployeeViewModel> emp = new List<EmployeeViewModel>();
            using(HttpClient htclient=new HttpClient())
            {
                htclient.BaseAddress = new Uri("http://localhost:5050");
                htclient.DefaultRequestHeaders.Accept.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = htclient.GetAsync("/Employee/GetEmpData").Result;
                htclient.Dispose();
                if(res.IsSuccessStatusCode)
                {

                    string empdata=res.Content.ReadAsStringAsync().Result;
                    emp = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(empdata);
                    if (emp != null)
                    {
                        return View(emp);
                    }
                    else
                    {
                        TempData["error"] = $"{res.ReasonPhrase}";
                    }
                }
                
            }

            return View();
        }

        
        public IActionResult CreateEmployee()
       {
            EmpViewModel emp = new EmpViewModel();
            List<DepartmentMaster> dep = new List<DepartmentMaster>();
            using(HttpClient htclient=new HttpClient())
            {
                htclient.BaseAddress = new Uri("http://localhost:5050");
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = htclient.GetAsync("/Leave/GetAllDep").Result;
                htclient.Dispose();
                if (response.IsSuccessStatusCode)
                {
                    string stgdata = response.Content.ReadAsStringAsync().Result;
                    dep = JsonConvert.DeserializeObject<List<DepartmentMaster>>(stgdata);
                    TempData["depmast"] = new SelectList(dep, "DepId", "DepName");

                }
                else
                {
                    TempData["error"] = $"{response.ReasonPhrase}";
                }
            }

            return View(emp);
        }

       public IActionResult Edit(int id)
       {
            return View();
       }

        [HttpPost]
        public IActionResult Edit(EmployeeMaster e)
        {
            return View();
        }



        [HttpPost]
        public IActionResult SaveEmployee(EmpViewModel e)
        {
            using (HttpClient htclient=new HttpClient())
            {
                htclient.BaseAddress = new Uri("http://localhost:5050");
                var data = JsonConvert.SerializeObject(e);
                var contdata = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage reponse = htclient.PostAsync("/Employee/AddNewEmp",contdata).Result;
                TempData["Success"] = reponse.Content.ReadAsStringAsync().Result;

            }
                return View("CreateEmployee",e);
        }


    }
}
