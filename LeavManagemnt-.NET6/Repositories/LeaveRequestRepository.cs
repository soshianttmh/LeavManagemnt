using AutoMapper;
using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace LeavManagemnt_.NET6.Repositories
{
    public class LeaveRequestRepository :  GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        ApplicationDbContext context;
        IMapper mapper;
        IHttpContextAccessor httpContextAccessor;
        ILeaveAllocationRepository leaveAllocationRepository;
        UserManager<Employee> usermanager;
        ILeaveTypeRepository leaveTypeRepository;
        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employee> usermanager,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.usermanager = usermanager;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var leaveRequest = mapper.Map<LeaveRequest>(model);
            var leaveType = await leaveTypeRepository.GetAsync(model.LeaveTypeId);
            if (leaveType == null)
            {
                return false;
            }
            int daysRequested = (int)(leaveRequest.EndTime - leaveRequest.StartTime).TotalDays;
            if (leaveType.DefaultDays < daysRequested)
            {
                return false;
            }
            var user = await usermanager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;
            await AddAsync(leaveRequest);
            return true;
        }

        public async Task<List<LeaveAllocationVM>> GetMyLeaveAllocationsVM(string employeeId)
        {
            var model = await context.LeaveAllocations
                .Include(q => q.leaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ToListAsync();
            var leaveAllocationVM = mapper.Map<List<LeaveAllocationVM>>(model);
            return leaveAllocationVM;
        }

        public async Task<List<LeaveRequest>> GetMyLeaveRequests(string employeeId)
        {
            return await context.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId).ToListAsync();
        }


        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            // First Way
            //var leaveAllocations = await GetMyLeaveAllocationsVM(user.Id);
            // Seccond Way
            var user = await usermanager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var leaveAllocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;

            var leaveRequests = await GetMyLeaveRequests(user.Id);
            var leaveDetails = new EmployeeLeaveRequestViewVM(leaveAllocations, mapper.Map<List<LeaveRequestVM>>(leaveRequests));
            return leaveDetails;    
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveDetails()
        {
            var leaveRequests = await context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var adminRequestsView = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests),
            };
            foreach (var leaveRequest in adminRequestsView.LeaveRequests)
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await usermanager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }
            return adminRequestsView;
        }

        public async Task<LeaveRequestVM?> GetLeaveRequest(int id)
        {
            var leaveRequest = await context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            if (leaveRequest == null)
            {
                return null;
            }
            var employee = await usermanager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            var model = mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = mapper.Map<EmployeeListVM>(employee);
            return model;
        }

        public async Task ChangeApprovalStatus(int id, bool approved)
        {
            var request = await GetAsync(id);
            request.Approved = approved;
            if (approved)
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(request.LeaveTypeId, request.RequestingEmployeeId);
                int daysRequested = (int)(request.EndTime - request.StartTime).TotalDays;
                allocation.NumberOfDays -= daysRequested;
                await leaveAllocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(request);
        }

        public async Task CancleRequest(int id)
        {
            var request = await GetAsync(id);
            request.Canceled = true;
            await UpdateAsync(request);
        }

        public async Task<List<LeaveAllocationVM>> GetLeaveTypeSelection()
        {
            var employee = await usermanager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var leaveAllocations = (await leaveAllocationRepository.GetEmployeeAllocations(employee.Id)).LeaveAllocations;
            foreach (var leave in leaveAllocations)
            {
                leave.Name = leave.LeaveType?.Name;
            }
            return mapper.Map<List<LeaveAllocationVM>>(leaveAllocations);
        }
    }
}
