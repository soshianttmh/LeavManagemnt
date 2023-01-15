using LeavManagemnt_.NET6.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavManagemnt_.NET6.Configurations.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                UserId = "851a6c4e-2b56-4b80-86b0-f94605206223"
            }, new IdentityUserRole<string>
            {
                RoleId = "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                UserId = "341f3a6d-19b7-49a7-9ecf-890757774d7a"
            });
        }
    }
}
