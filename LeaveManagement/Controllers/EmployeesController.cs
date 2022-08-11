using AutoMapper;
using LeaveManagement.Constants;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _repository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        // GET: EmployeesController
        public EmployeesController(UserManager<Employee> userManager,
                                   IMapper mapper,
                                   ILeaveAllocationRepository repository,
                                   ILeaveTypeRepository leaveTypeRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _repository = repository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            return View(_mapper.Map<List<EmployeeListViewModel>>(employees));
        }

        // GET: EmployeesController/ViewAllocations/5
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await _repository.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/EditAllocation/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var leaveAllocationViewModel = await _repository.GetEmployeeAllocation(id);
            if (leaveAllocationViewModel == null)
            {
                return NotFound();
            }
            return View(leaveAllocationViewModel);
        }

        // POST: EmployeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocationAsync(int id, LeaveAllocationEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(await _repository.UpdateEmployeeAllocation(model))
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId});
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error has occured. Please try again later.");
            }
            model.EmployeeListViewModel = _mapper.Map<EmployeeListViewModel>(await _userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeViewModel>(await _leaveTypeRepository.GetAsync(model.LeaveTypeId));
            return View(model);
        }
    }
}
