using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "096190dd-5f33-413a-883e-7276986fc080", "423e8b7e-d27e-4270-a161-04d34ae275c0", "User", "USER" },
                    { "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2", "bba2f64c-fa76-47b0-aebb-74365516bc84", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8a298d19-1fba-461d-9ffc-98e94e146716", 0, "279db068-20f1-456b-8aac-d68c06bd9c79", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@user.com", false, "User", "User", false, null, "USER@USER.COM", null, "AQAAAAEAACcQAAAAEOpcYhILsrYesyF6W3bN/h73LKvCDqKvg+6RFD8R/CLkW4t82sAV2vcL0dgvtthIKQ==", null, false, "531dcfe7-daaf-47cc-bad2-83fb4da9a294", null, false, null },
                    { "8a358d19-3fda-461d-9eec-08e94e145506", 0, "070168f0-7e10-4428-9e76-886c57ed30ca", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEHMg9JMu64gNDPhbjN9Xyf/ICMkEQPfmc6r5XAeRBzlBS/DpDPs7vVYtFJxAiO9Lig==", null, false, "6e5e8965-8476-4b0b-b464-5b8295f4a876", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "096190dd-5f33-413a-883e-7276986fc080", "8a298d19-1fba-461d-9ffc-98e94e146716" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2", "8a358d19-3fda-461d-9eec-08e94e145506" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "096190dd-5f33-413a-883e-7276986fc080", "8a298d19-1fba-461d-9ffc-98e94e146716" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2", "8a358d19-3fda-461d-9eec-08e94e145506" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506");
        }
    }
}
