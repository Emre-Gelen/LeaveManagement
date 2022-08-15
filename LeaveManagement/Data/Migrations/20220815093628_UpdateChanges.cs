using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class UpdateChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestingEmployeeId",
                table: "LeaveRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "746baa09-7cf1-4cb9-bec2-60702dd2ae4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                column: "ConcurrencyStamp",
                value: "10ef2dec-53a8-4f13-a6f0-b3d85296c1e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7b65950-5562-45d5-a625-13b31690d5c9", "AQAAAAEAACcQAAAAEGcxrkqYPH8tb4NQbV1jdYii0A0kczpFN9eeR6I2vis17BIdthavlzJd0s2ieASHbw==", "6eab2f1b-1f47-48a7-b6c0-fee56cc32109" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0036c1f2-13ed-4f8c-b913-c6df2cad9f09", "AQAAAAEAACcQAAAAEOJP6BY/ZBlC1rEhgCw7boSGiWdg5dCGeKsX80WGe1qMKtNycJInvx/Yp+dRoxifTw==", "1c76d6d9-b029-4b15-ad53-16371503deb5" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_RequestingEmployeeId",
                table: "LeaveRequests",
                column: "RequestingEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_RequestingEmployeeId",
                table: "LeaveRequests",
                column: "RequestingEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_RequestingEmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_RequestingEmployeeId",
                table: "LeaveRequests");

            migrationBuilder.AlterColumn<string>(
                name: "RequestingEmployeeId",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "c3f6094a-ab6e-43f9-a88e-e4fa64b49d44");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                column: "ConcurrencyStamp",
                value: "e22a6ba2-a8c2-42b8-a3da-d9b376f15253");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b60e350-2234-4172-82a9-c37044ab8499", "AQAAAAEAACcQAAAAEJTFaXSbbmBdveCN8W2EkKBJKjgh05fKLnXBM8Ou4/kH7R0LvarYpj1xSB311F0E/Q==", "d1358191-e1f1-42f3-a927-b860169669bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cb92610-e80d-4865-9486-e7b46a261cc3", "AQAAAAEAACcQAAAAEForgqfUEI7IjJg7hgIuyHtv/+1QLBdmsHkstJ+58oM8Q3zcdkFyrOmHm0vhvPjogg==", "b7fb1366-4f39-484d-8257-ea329cf0a84e" });
        }
    }
}
