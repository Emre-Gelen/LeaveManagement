using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "8a358d19-3fda-461d-9eec-08e94e145506",
                    RoleId = "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2"
                },
                new IdentityUserRole<string>
                {
                    UserId = "8a298d19-1fba-461d-9ffc-98e94e146716",
                    RoleId = "096190dd-5f33-413a-883e-7276986fc080"
                }
            );
        }
    }
}
