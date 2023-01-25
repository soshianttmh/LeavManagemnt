using LeavManagemnt_.NET6.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeavManagemnt_.NET6.Models
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType leaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public string EmployeeId { get; set; }

        public int Period { get; set; }
    }
}
