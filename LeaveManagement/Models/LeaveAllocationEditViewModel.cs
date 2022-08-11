﻿namespace LeaveManagement.Models
{
    public class LeaveAllocationEditViewModel : LeaveAllocationViewModel
    {
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public EmployeeListViewModel? EmployeeListViewModel { get; set; }
    }
}
