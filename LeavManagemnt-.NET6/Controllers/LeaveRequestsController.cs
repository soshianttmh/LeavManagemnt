using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;
using AutoMapper;
using LeavManagemnt_.NET6.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeavManagemnt_.NET6.Constants;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace LeavManagemnt_.NET6.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepository)
        {
            _context = context;
            _leaveRequestRepository = leaveRequestRepository;
        }

        [Authorize(Roles = Roles.Adminastrator)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var leaveRequests = await _leaveRequestRepository.GetAdminLeaveDetails();
            return View(leaveRequests);
        }

        //GET : RequestDetails
        public async Task<IActionResult> RequestDetails(int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequest(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return View(leaveRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await _leaveRequestRepository.ChangeApprovalStatus(id, approved);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MyLeaves 
        public async Task<IActionResult> MyLeaves()
        {
            var model = await _leaveRequestRepository.GetMyLeaveDetails();
            return View(model);
        }

        // GET: LeaveRequests/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id");
            //ViewBag.LeaveShit = new SelectList(_context.LeaveTypes,"Id","Name");
            var model = await _leaveRequestRepository.GetLeaveTypeSelection();
            var leaveTypes = new SelectList(model, "Id", "Name");
            var requestCreateVM = new LeaveRequestCreateVM
            {
                LeaveTypes = leaveTypes,
            };
            return View(requestCreateVM);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM leaveRequestVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _leaveRequestRepository.CreateLeaveRequest(leaveRequestVM)) { 
                        return RedirectToAction(nameof(MyLeaves));
                    }
                    else
                    {
                        ModelState.AddModelError("StartTime", "The gap between start and end date could not be greater than DefaultDays!!");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Something went Wrong. Please try later!!");
            }
            var model = await _leaveRequestRepository.GetLeaveTypeSelection();
            var leaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name");
            leaveRequestVM.LeaveTypes = leaveTypes;
            return View(leaveTypes);
        }


        // Post : Cancle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancle(int id)
        {
            try
            {
                await _leaveRequestRepository.CancleRequest(id);
            }
            catch (Exception ex)
            {
                TempData["CancleError"] = "The LeaveRequest Not Found !!";
            }
            return RedirectToAction(nameof(MyLeaves));
        }
    }
}
