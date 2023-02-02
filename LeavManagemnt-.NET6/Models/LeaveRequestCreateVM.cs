using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeavManagemnt_.NET6.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Required]
        [Display(Name ="Start Date")]
        public DateTime? StartTime { get; set; }
        [Required]
        [Display(Name ="End Date")]
        public DateTime? EndTime { get; set; }
        [Display(Name ="Select Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }
        public SelectList? LeaveTypes { get; set; }

        [Display(Name ="Comment")]
        [MaxLength(255, ErrorMessage ="Comments are too Long!!")]    
        public string? RequestComment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartTime > EndTime)
            {
                // yield return does not break the method after return.
                yield return new ValidationResult("The Start Date Must Be Befor End Date!!", new[] { nameof(StartTime),nameof(EndTime)});
            }
            
        }
    }
}
