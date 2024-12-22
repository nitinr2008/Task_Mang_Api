using System;
using System.Collections.Generic;

namespace Task_Mang_Api.Models;

public partial class LeaveBalance
{
    public int LeaveBalanceId { get; set; }

    public int? EmpId { get; set; }

    public decimal? LeaveBalenceday { get; set; }

    public decimal? LeaveBalanceHour { get; set; }

    public int? LeaveBalancetype01 { get; set; }

    public int? LeaveBalancetype02 { get; set; }

    public int? LeaveBalancetype03 { get; set; }

    public virtual EmployeeMaster? Emp { get; set; }
}
