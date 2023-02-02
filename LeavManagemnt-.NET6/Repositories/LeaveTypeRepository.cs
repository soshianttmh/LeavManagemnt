using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeavManagemnt_.NET6.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)    
        {
        }
    }
}
