using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class PropertyNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestiongEmployeeId",
                table: "LeaveRequests",
                newName: "RequestingEmployeeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestingEmployeeId",
                table: "LeaveRequests",
                newName: "RequestiongEmployeeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "bdad9277-c0e6-43d5-8c9e-b6f8dcedd69b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                column: "ConcurrencyStamp",
                value: "6001614d-0b2e-4e0e-9d20-9d10ff29c7d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "289770ec-e2a8-4761-9f77-4f993894c97e", "AQAAAAEAACcQAAAAEE5nkFM73WWcx+nyNJdcaOx+d6nODhJy2PnAIBMTcp81FXgo9H6wjOUY3KwjvFEnvQ==", "7c5af03c-24ed-4afe-ac77-08f99c7ea7c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec920f30-36df-46fc-8042-81aaaf519b64", "AQAAAAEAACcQAAAAELQZqSQmxoVwsLUdk8GsOvDFbaLpkVABZksLrXKLiNyDen1ZyJ5dHPuxP77aTAAIGQ==", "b927b7c9-ef43-4648-8bac-4e73f8c61422" });
        }
    }
}
