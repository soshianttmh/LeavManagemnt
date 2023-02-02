namespace LeavManagemnt_.NET6.Models
{
    public class EmployeeLeaveRequestViewVM
    {
        public EmployeeLeaveRequestViewVM(List<LeaveAllocationVM> leaveAllocationsVM, List<LeaveRequestVM> leaveRequests)
        {
            LeaveAllocationsVM = leaveAllocationsVM;
            LeaveRequests = leaveRequests;
        }
    
        public List<LeaveAllocationVM> LeaveAllocationsVM { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
