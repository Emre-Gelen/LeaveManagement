using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "8a358d19-3fda-461d-9eec-08e94e145506",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null,"Emre123."),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "8a298d19-1fba-461d-9ffc-98e94e146716",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    UserName = "user@user.com",
                    NormalizedUserName = "USER@USER.COM",
                    FirstName = "User",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "Emre123."),
                    EmailConfirmed = true
                }
            );
        }
    }
}
