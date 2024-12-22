using System;
using System.Collections.Generic;

namespace Task_Mang_Api.Models;

public partial class DepartmentMaster
{
    public int DepId { get; set; }

    public string? DepName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; } = new List<EmployeeMaster>();
}
