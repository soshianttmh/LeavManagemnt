using LeavManagemnt_.NET6.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavManagemnt_.NET6.Configurations.Entities
{
    internal class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                Name = Roles.Adminastrator,
                NormalizedName = Roles.Adminastrator.ToUpper(),
            },
            new IdentityRole
            {
                Id = "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                Name = Roles.User,
                NormalizedName = Roles.User.ToUpper(),
            });
        }
    }
}