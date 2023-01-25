using AutoMapper;
using LeavManagemnt_.NET6.Constants;
using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeavManagemnt_.NET6.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        UserManager<Employee> _userManager;
        ILeaveTypeRepository _leaveTypeRepository;  
        ApplicationDbContext _context;
        IMapper _mapper;
        public LeaveAllocationRepository(ApplicationDbContext context,
            UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int preiod)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == preiod);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(q => q.leaveType)
                .Where(q => q.EmployeeId == employeeId)
                // step1:  we can do this shit rather than mapping
                //.Select(q => new LeaveAllocationVM { Period = q.Period })
                .ToListAsync();
            var employee = await _userManager.FindByIdAsync(employeeId);
            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);
            // step2: we can do this shit rather than mapping
            //employeeAllocationModel.LeaveAllocations = allocations;

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await _context.LeaveAllocations
            .Include(q => q.leaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
            if (allocation == null)
            {
                return null;
            }
            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);
            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = _mapper.Map<EmployeeListVM>(employee);
            //model.employeeId = employee.Id;
            //model.leaveTypeId = allocation.LeaveTypeId; 
            return model;
        }

        public async Task SetLeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            int preiod = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId); 
            List<LeaveAllocation> leaveAllocationList = new List<LeaveAllocation>();    
            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, preiod))
                    continue;
                leaveAllocationList.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = preiod,
                    NumberOfDays = leaveType.DefaultDays
                });
            }
            await AddRangeAsync(leaveAllocationList);
        }
        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
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
    }
}
