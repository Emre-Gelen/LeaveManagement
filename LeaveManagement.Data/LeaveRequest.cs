using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime DateRequested { get; set; }
        public string RequestComment { get; set; }

        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }


        #region Relations
        public int LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public string RequestingEmployeeId { get; set; }
        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestedEmployee { get; set; }
        #endregion
    }
}
