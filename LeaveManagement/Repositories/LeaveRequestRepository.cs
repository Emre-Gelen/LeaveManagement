  using AutoMapper;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _allocationRepository;
        public LeaveRequestRepository(ApplicationDbContext dbContext,
                                      IMapper mapper,
                                      IHttpContextAccessor accessor,
                                      UserManager<Employee> userManager,
                                      ILeaveAllocationRepository allocationRepository) : base(dbContext)
        {
            _mapper = mapper;
            _accessor = accessor;
            _userManager = userManager;
            _allocationRepository = allocationRepository;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;

            await UpdateAsync(leaveRequest);
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                var allocation = await _allocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                await _allocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(leaveRequest);
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(_accessor?.HttpContext?.User);

            var leaveAllocation = await _allocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);
            int daysRequested = (model.EndDate - model.StartDate).Value.Days;

            if (leaveAllocation == null || daysRequested > leaveAllocation.NumberOfDays)
                return false;

            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            return true;
        }

        public async Task<AdminRequestViewModel> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _entity.Include(q => q.LeaveType)
                                             .Include(q => q.RequestedEmployee).ToListAsync();
            var model = new AdminRequestViewModel
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(request => request.Approved == true),
                PendingRequests = leaveRequests.Count(request => request.Approved is null),
                RejectedRequests = leaveRequests.Count(request => request.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests)
            };
            return model;
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _entity.Where(request => request.RequestingEmployeeId == employeeId).ToListAsync();
        }

        public async Task<LeaveRequestViewModel?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _entity.Include(q => q.LeaveType)
                                            .Include(q => q.RequestedEmployee)
                                            .FirstOrDefaultAsync(leaveRequest => leaveRequest.Id == id);
            return _mapper.Map<LeaveRequestViewModel>(leaveRequest);
        }

        public async Task<EmployeeLeaveRequestViewModel> GetLeaveRequestsByUser()
        {
            var user = await _userManager.GetUserAsync(_accessor?.HttpContext?.User);
            var allocations = (await _allocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestViewModel>>(await _entity.Include(q => q.LeaveType).Where(request => request.RequestingEmployeeId == user.Id).ToListAsync());

            var model = new EmployeeLeaveRequestViewModel
            {
                LeaveAllocations = allocations,
                LeaveRequests = requests
            };

            return model;
        }
    }
}
