using AutoMapper;
using LeavManagemnt_.NET6.Constants;
using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeavManagemnt_.NET6.Controllers
{
    [Authorize(Roles = Roles.Adminastrator)]
    public class EmployeeController : Controller
    {
        public UserManager<Employee> _userManager;
        public readonly IMapper _mapper;
        public readonly ILeaveAllocationRepository _leaveAllocationRepo;
        public readonly ILeaveTypeRepository _leaveTypeRepo;
        public EmployeeController(UserManager<Employee> userManager,IMapper mapper, ILeaveAllocationRepository leaveAllocationRepo, ILeaveTypeRepository leaveTypeRepo)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepo = leaveAllocationRepo;
            _leaveTypeRepo = leaveTypeRepo; 
        }
        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            IEnumerable<EmployeeListVM> model = _mapper.Map<IEnumerable<EmployeeListVM>>(employees);   
            return View(model);
        }

        // GET: EmployeeController/ViewAllocations
        public async Task<ActionResult> ViewAllocations(string id)
        {
            var model = await _leaveAllocationRepo.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET
        public async Task<IActionResult> EditAllocation(int allocationId)
        {
            //var leaveAllocation = await _leaveAllocationRepo.GetAsync(allocationId);
            //Employee employee = await _userManager.FindByIdAsync(leaveAllocation.EmployeeId);  
            //if (leaveAllocation == null || employee == null)
            //{
            //    return NotFound();
            //}
            //var model = _mapper.Map<LeaveAllocationEditVM>(leaveAllocation);
            //model.Employee = _mapper.Map<EmployeeListVM>(employee);

            var leaveAllocation = await _leaveAllocationRepo.GetEmployeeAllocation(allocationId);
            if (leaveAllocation == null)
            {
                return NotFound();
            }
            
            return View(leaveAllocation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _leaveAllocationRepo.UpdateEmployeeAllocation(model))
                    {
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.employeeId });
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Something went Wrong. Please try later!!");
            }
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(model.employeeId));
            model.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveTypeRepo.GetAsync(model.leaveTypeId));
            return View(model);
        }
    }
}
