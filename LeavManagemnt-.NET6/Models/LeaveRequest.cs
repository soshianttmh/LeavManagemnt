using System.ComponentModel.DataAnnotations.Schema;

namespace LeavManagemnt_.NET6.Models
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComment { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
        public string RequestingEmployeeId { get; set; }
    }
}
