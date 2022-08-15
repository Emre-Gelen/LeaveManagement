using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Models
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Number Of Days")]
        public int NumberOfDays => (EndDate - StartDate).Days;
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Request Comment")]
        public string RequestComment { get; set; }

        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeViewModel LeaveType { get; set; }
        public EmployeeListViewModel RequestedEmployee { get; set; }

    }
}
