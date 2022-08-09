using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Default Number Of Days")]
        [Required]
        [Range(1, 20,ErrorMessage = "Please enter a valid value!")]
        public int DefaultDays { get; set; }
    }
}
