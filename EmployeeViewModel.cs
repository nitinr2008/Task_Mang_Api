namespace Task_Mang_Api.Models.View_Model
{
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }

        public string? EmpName { get; set; }

        public string? EmpPass { get; set; }

        public int? DepId { get; set; }

        public bool? IsActive { get; set; }
        public DepartmentMaster? Dep { get; set; }

        public string? DepName { get; set; }


    }
}
