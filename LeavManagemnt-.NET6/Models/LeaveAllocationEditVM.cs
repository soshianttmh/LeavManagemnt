namespace LeavManagemnt_.NET6.Models
{
    public class LeaveAllocationEditVM : LeaveAllocationVM
    {
        public string employeeId { get; set; }
        public int leaveTypeId { get; set; }
        public EmployeeListVM? Employee { get; set; }
    }
}
