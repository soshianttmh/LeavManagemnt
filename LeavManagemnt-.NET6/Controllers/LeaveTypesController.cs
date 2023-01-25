using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;
using System.ComponentModel;
using AutoMapper;
using LeavManagemnt_.NET6.Repositories;
using LeavManagemnt_.NET6.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeavManagemnt_.NET6.Constants;

namespace LeavManagemnt_.NET6.Controllers
{
    [Authorize(Roles = Roles.Adminastrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository; 
        private IMapper mapper;    
        private readonly ILeaveAllocationRepository _leaveAllocationRepository; 

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository,IMapper _mapper,ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            mapper = _mapper;   
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var result = mapper.Map<List<LeaveTypeVM>>( await _leaveTypeRepository.GetAllAsync());   
            return View(result);
        }
        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);
            
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
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
        // just fields that set into bind can send with form and receive with controller : 
        // public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id,CreatedDate,ModifiedDate")] LeaveType leaveType)
        // when we use ViewModel we dont need to use bind 
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM) 
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                await _leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                    await _leaveTypeRepository.UpdateAsync(leaveType);    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _leaveTypeRepository.ExistsAsync(id))
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
            //if (_context.LeaveTypes == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            //}
            await _leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Allocate(int id)
        {
            await _leaveAllocationRepository.SetLeaveAllocation(id);
            return RedirectToAction(nameof(Index));  
        }
    }
}
