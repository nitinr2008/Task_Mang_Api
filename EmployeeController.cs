using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Mang_Api.Models;
using Task_Mang_Api.Models.View_Model;

namespace Task_Mang_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TaskManagementContext _db;
     public EmployeeController(TaskManagementContext db) {

            _db = db;
        
        }

        
        [Route("DataById")]
        [HttpGet]
        public IActionResult GetEmpDataId(int id)
        {
            var data=_db.EmployeeMasters.Find(id);
            if(data!=null)
            { 
            return Ok(data);
            }
            return BadRequest();
        }

        [Route("GetEmpData")]
        [HttpGet]
        public IActionResult GetEmpData()
        {

            var lst = (from e in _db.EmployeeMasters
                        join d in _db.DepartmentMasters
                        on e.DepId equals d.DepId
                        select new
                        {
                            EmpId = e.EmpId,
                            EmpName = e.EmpName,
                            EmpPass = e.EmpPass,
                            DepName = d.DepName

                        }).ToList(); 

//            var lst = _db.EmployeeMasters.Include(static x=>x.Dep.DepName).Select(x => new EmployeeViewModel()
//            {
//                EmpId = x.EmpId,
//                EmpName = x.EmpName,
//                EmpPass = x.EmpPass,
//                DepId = x.DepId
//}).ToList();
            if(lst.Count>0)
            { 
              return Ok(lst);
            }
            return BadRequest();
        }


        [Route("UpdateEmployee")]
        [HttpPut]
        public IActionResult EditEmp([FromBody] EmployeeMaster emp)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();

            }
            EmployeeMaster data = _db.EmployeeMasters.Where(x => x.EmpId == emp.EmpId).FirstOrDefault();
            if(data==null)
            {
                EmployeeMaster e = new EmployeeMaster()
                {
                    EmpName = data.EmpName,
                    EmpPass = data.EmpPass,
                    DepId = data.DepId,
                    IsActive = data.IsActive


                };
                _db.EmployeeMasters.Update(e);
                _db.SaveChanges();
                
            }
            return Ok();

        }

        
        [Route("AddNewEmp")]
        [HttpPost]
        public IActionResult AddNewEmp([FromBody] EmployeeMaster emp)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var data = new EmployeeMaster()
                {

                    EmpName = emp.EmpName,
                    EmpPass = emp.EmpPass,
                    DepId = emp.DepId,
                    IsActive = emp.IsActive
                };
                _db.EmployeeMasters.Add(data);
                _db.SaveChanges();
                return Ok();
            }


        }



    }
}
