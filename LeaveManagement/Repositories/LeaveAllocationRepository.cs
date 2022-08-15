using AutoMapper;
using LeaveManagement.Constants;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {

        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public LeaveAllocationRepository(ApplicationDbContext dbContext,
                                         UserManager<Employee> userManager,
                                         ILeaveTypeRepository leaveTypeRepository,
                                         IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeID, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations.AnyAsync(allocation => allocation.LeaveTypeId == leaveTypeId
                                                                         && allocation.EmployeeId == employeeID
                                                                         && allocation.Period == period);
        }

        public async Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(allocation => allocation.EmployeeId == employeeId).ToListAsync();
            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationViewModel>(employee);
            employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationViewModel>>(allocations);

            return employeeAllocationModel;
        }
        public async Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id)
        {
            var allocation = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(allocation => allocation.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var leaveAllocationViewModel = _mapper.Map<LeaveAllocationEditViewModel>(allocation);
            leaveAllocationViewModel.EmployeeListViewModel = _mapper.Map<EmployeeListViewModel>(employee);

            return leaveAllocationViewModel;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);

            var allocations = new List<LeaveAllocation>();
            foreach (var employee in employees)
            {
                if (!(await AllocationExists(employee.Id, leaveTypeId, period)))
                {
                    var allocation = new LeaveAllocation()
                    {
                        EmployeeId = employee.Id,
                        LeaveTypeId = leaveTypeId,
                        Period = period,
                        NumberOfDays = leaveType.DefaultDays
                    };
                    allocations.Add(allocation);
                }
            }
            await AddRangeAsync(allocations);
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            return true;
        }
        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _entity.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
