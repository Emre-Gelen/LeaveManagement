using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models
{
    public class LeaveRequestCreateViewModel : IValidatableObject
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        public SelectList? LeaveTypes { get; set; }
        [Display(Name = "Request Comment")]
        public string RequestComment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The start date must be before end date.", new[] { nameof(StartDate), nameof(EndDate)});
            }
        }
    }
}
