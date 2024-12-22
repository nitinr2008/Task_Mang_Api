using System;
using System.Collections.Generic;

namespace Task_Mang_Api.Models;

public partial class EmployeeMaster
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? EmpPass { get; set; }

    public int? DepId { get; set; }

    public bool? IsActive { get; set; }
    public virtual DepartmentMaster? Dep { get; set; }

    public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();

    public virtual ICollection<LeaveMaster> LeaveMasters { get; set; } = new List<LeaveMaster>();
}
