using LeavManagemnt_.NET6.Models;

namespace LeavManagemnt_.NET6.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task SetLeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
