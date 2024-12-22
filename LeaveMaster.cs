using System;
using System.Collections.Generic;

namespace Task_Mang_Api.Models;

public partial class LeaveMaster
{
    public int LeaveId { get; set; }

    public int? LeaveTypeId { get; set; }

    public int? EmpId { get; set; }

    public decimal? TotalLeave { get; set; }

    public decimal? TotalleaveHours { get; set; }

    public DateTime? LeaveMonth { get; set; }

    public virtual EmployeeMaster? Emp { get; set; }

    public virtual LeaveType? LeaveType { get; set; }
}
