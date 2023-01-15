using LeavManagemnt_.NET6.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavManagemnt_.NET6.Configurations.Entities
{
    internal class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();    
            builder.HasData(
            new Employee
            {
                Id = "851a6c4e-2b56-4b80-86b0-f94605206223",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Admin",    
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
            },
            new Employee
            {
                Id = "341f3a6d-19b7-49a7-9ecf-890757774d7a",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
                
            });
        }
    }
}
