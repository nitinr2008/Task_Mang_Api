using System;
using System.Collections.Generic;

namespace Task_Mang_Api.Models;

public partial class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string? LeaveName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<LeaveMaster> LeaveMasters { get; set; } = new List<LeaveMaster>();
}
