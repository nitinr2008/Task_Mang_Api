using Task_Mang_Api.Models;

namespace TaskmanagementWebApp.Models
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }

        public string? EmpName { get; set; }

        public string? EmpPass { get; set; }

        public int? DepId { get; set; }

        public bool? IsActive { get; set; }
        
        public string DepName { get; set; }       

        public string City {set;get;}
    }



}
