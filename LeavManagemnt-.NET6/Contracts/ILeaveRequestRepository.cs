using LeavManagemnt_.NET6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeavManagemnt_.NET6.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest> 
    {
        public Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);
        public Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
        public Task<List<LeaveAllocationVM>> GetMyLeaveAllocationsVM(string employeeId);
        public Task<List<LeaveRequest>> GetMyLeaveRequests(string employeeId);
        public Task <AdminLeaveRequestViewVM> GetAdminLeaveDetails();
        public Task<LeaveRequestVM?> GetLeaveRequest(int id);
        public Task ChangeApprovalStatus(int id, bool approved);
        public Task CancleRequest(int id);
        public Task<List<LeaveAllocationVM>> GetLeaveTypeSelection();
    }
}
