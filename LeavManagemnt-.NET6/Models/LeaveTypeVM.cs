using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeavManagemnt_.NET6.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [DisplayName("Leave Type Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name="Default Number Of Days")]
        [Required]
        [Range(1,25,ErrorMessage ="Please Enter Valid Number")]
        public int DefaultDays { get; set; }    
    }
}
