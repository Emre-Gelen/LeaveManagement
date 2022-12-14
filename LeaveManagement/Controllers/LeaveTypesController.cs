using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Data;
using AutoMapper;
using LeaveManagement.Common.Models;
using LeaveManagement.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Common.Constants;

namespace LeaveManagement.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _repository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveTypesController(ILeaveTypeRepository repository, ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _repository = repository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = _mapper.Map<List<LeaveTypeViewModel>>(await _repository.GetAllAsync());
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _repository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<LeaveTypeViewModel>(leaveType));
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DefaultDays")] LeaveTypeViewModel leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(_mapper.Map<LeaveType>(leaveTypeVM));
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _repository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<LeaveTypeViewModel>(leaveType));
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DefaultDays")] LeaveTypeViewModel leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            var leaveType = await _repository.GetAsync(id);
            if (leaveType == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _mapper.Map(leaveTypeVM, leaveType);
                    await _repository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _repository.Exists(leaveTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await _leaveAllocationRepository.LeaveAllocation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
