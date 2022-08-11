using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class AddedPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "ba127487-d276-4165-bbd7-bcc880e21e1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "3706f27e-f249-4ed4-bf18-5a2861ca1b20", "ADMİNİSTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345768de-7e21-46b5-92e6-90572da52f8c", "AQAAAAEAACcQAAAAEA8YPu4ZuhDUBgztSDw/0XabCElY/9tgVRM5MpT1HoB7em/KCyRK5dtzhC0tXdIFIQ==", "10a6f389-7e91-41a1-8030-8da86f85bc60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abfbd817-aed5-43e6-89c0-38abbe69f1ae", "AQAAAAEAACcQAAAAECyL95ojzUY+wdLsepZTsYVHnc26XghU/rs7V5qT6z8CNf5LKdRTNw5jMO8V3WL6gQ==", "5b6b878a-b252-4320-aeae-9270443045b0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "0ffae013-ba35-4f29-91e0-8de47e41035a", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe2d161-da2c-4a66-b428-9d22fe95ec7e", "AQAAAAEAACcQAAAAEFbQyFiA3Lgxm6sy9od9MswWsGdJ40izlDcRW8fql5w2Xd+YDZB87peJ0T8nQgNHtA==", "c9120846-a809-41ec-8cb4-a670759e71a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bc61023-a550-4bcc-8a04-a4b14d1b2134", "AQAAAAEAACcQAAAAELOwA5K2ldtDvxRzckAUy6ZOSudmUZS06juLQbWT2zhmewltrW8g9gSOKHT73XPECw==", "a0b51a23-0eef-46bd-b331-acd77516d6d0" });
        }
    }
}
