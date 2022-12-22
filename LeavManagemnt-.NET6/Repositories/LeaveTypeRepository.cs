using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;

namespace LeavManagemnt_.NET6.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)    
        {
        }
    }
}
