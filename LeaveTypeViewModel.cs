namespace Task_Mang_Api.Models
{
    public class LeaveTypeViewModel
    {
        public int LeaveTypeId { get; set; }

        public string? LeaveName { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<LeaveMaster> LeaveMasters { get; set; }

    }
}
