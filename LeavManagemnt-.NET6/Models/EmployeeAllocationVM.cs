namespace LeavManagemnt_.NET6.Models
{
    public class EmployeeAllocationVM : EmployeeListVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
