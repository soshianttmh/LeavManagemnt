using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;

namespace LeavManagemnt_.NET6.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }
        [Display(Name ="Number Of Days")]
        [Required]
        [Range(0,50, ErrorMessage = "Invalid Number Entered!!")]
        public int NumberOfDays { get; set; }
        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }

        public string? Name { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }
    }
}