using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {

        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public LeaveAllocationRepository(ApplicationDbContext dbContext,
                                         UserManager<Employee> userManager,
                                         ILeaveTypeRepository leaveTypeRepository,
                                         IMapper mapper,
                                         AutoMapper.IConfigurationProvider configurationProvider,
                                         IEmailSender emailSender) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
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
                .Where(allocation => allocation.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationViewModel>(_configurationProvider)
                .ToListAsync();
            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationViewModel>(employee);
            employeeAllocationModel.LeaveAllocations = allocations;

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
            var employeesWithAllocations = new List<Employee>();
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
                    employeesWithAllocations.Add(employee);
                }
            }
            await AddRangeAsync(allocations);

            foreach (var employee in employeesWithAllocations)
            {
                await _emailSender.SendEmailAsync(employee.Email,
                                                  $"Leave Allocation Posted for {period}",
                                                  $"Your {leaveType.Name} leave has been posted for the period of {period}. You have been given {leaveType.DefaultDays}");
            }
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
