﻿using LeavManagemnt_.NET6.Configurations.Entities;
using LeavManagemnt_.NET6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeavManagemnt_.NET6.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // call when the database is ganerate
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }   
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; } 
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeavManagemnt_.NET6.Models.LeaveRequestVM> LeaveRequestVM { get; set; }
    }
}