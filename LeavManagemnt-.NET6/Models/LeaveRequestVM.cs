using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LeavManagemnt_.NET6.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public LeaveTypeVM LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComment { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }

        public string? RequestingEmployeeId { get; set; }
        public EmployeeListVM Employee { get; set; }
    }
}
