using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class EmployeeListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Date Joined")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yy}")]
        public DateTime DateJoined { get; set; }
    }
}
