using System;
using System.Collections.Generic;

namespace Task_Mang_Api.Models;

public partial class TaskMaster
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public DateTime? TaskStartDate { get; set; }

    public DateTime? TaskEndDate { get; set; }

    public bool? Isactive { get; set; }
}
