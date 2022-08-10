using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class UpdatedUserNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "8968fbce-10ca-4cee-bd3d-83c594c0acde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                column: "ConcurrencyStamp",
                value: "0ffae013-ba35-4f29-91e0-8de47e41035a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "efe2d161-da2c-4a66-b428-9d22fe95ec7e", true, "USER@USER.COM", "AQAAAAEAACcQAAAAEFbQyFiA3Lgxm6sy9od9MswWsGdJ40izlDcRW8fql5w2Xd+YDZB87peJ0T8nQgNHtA==", "c9120846-a809-41ec-8cb4-a670759e71a1", "user@user.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7bc61023-a550-4bcc-8a04-a4b14d1b2134", true, "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELOwA5K2ldtDvxRzckAUy6ZOSudmUZS06juLQbWT2zhmewltrW8g9gSOKHT73XPECw==", "a0b51a23-0eef-46bd-b331-acd77516d6d0", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "423e8b7e-d27e-4270-a161-04d34ae275c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                column: "ConcurrencyStamp",
                value: "bba2f64c-fa76-47b0-aebb-74365516bc84");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "279db068-20f1-456b-8aac-d68c06bd9c79", false, null, "AQAAAAEAACcQAAAAEOpcYhILsrYesyF6W3bN/h73LKvCDqKvg+6RFD8R/CLkW4t82sAV2vcL0dgvtthIKQ==", "531dcfe7-daaf-47cc-bad2-83fb4da9a294", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "070168f0-7e10-4428-9e76-886c57ed30ca", false, null, "AQAAAAEAACcQAAAAEHMg9JMu64gNDPhbjN9Xyf/ICMkEQPfmc6r5XAeRBzlBS/DpDPs7vVYtFJxAiO9Lig==", "6e5e8965-8476-4b0b-b464-5b8295f4a876", null });
        }
    }
}
