using LeaveManagement.Data;
using LeaveManagement.Models;

namespace LeaveManagement.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeID, int leaveTypeId, int period);
        Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId);
        Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel model);
    }
}
