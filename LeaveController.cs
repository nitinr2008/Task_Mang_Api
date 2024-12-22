using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Mang_Api.Models;

namespace Task_Mang_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly TaskManagementContext _db;
        public LeaveController(TaskManagementContext db) 
        { 
         _db= db;
        }

        [Route("GetAllDep")]
        [HttpGet]
        public IActionResult GetAllDep()
        {
            var data = _db.DepartmentMasters.Where(x=>x.IsActive==true).Select(x=> new { 
            x.DepId,
            x.DepName
            }).ToList();
            if(data.Count>0)
            { 
            return Ok(data);
            }
            return BadRequest();
        }

        [Route("GetLeaveType")]
        [HttpGet]
        public IActionResult GetLeaveType()
        {
            var data = _db.LeaveTypes.Select(x=> new LeaveTypeViewModel()
            {
                LeaveTypeId=x.LeaveTypeId,
                LeaveName=x.LeaveName,
                IsActive=x.IsActive,
}).ToList();
            if(data.Count() > 0)
            {
                return Ok(data);
            }
            return NotFound();
           
        }


    }
}
