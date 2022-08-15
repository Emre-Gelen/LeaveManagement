using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class UpdateChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096190dd-5f33-413a-883e-7276986fc080",
                column: "ConcurrencyStamp",
                value: "7606b916-68ec-4fd7-984f-5a95ff050ea9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c08c40-78f4-4fcb-8a1c-3f811e2b8df2",
                column: "ConcurrencyStamp",
                value: "e7d20d4b-19ca-4492-834c-5ba322c460aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a298d19-1fba-461d-9ffc-98e94e146716",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0698624e-aa28-4c18-a13c-7a3b567abe7c", "AQAAAAEAACcQAAAAEGBomAYabs5ivrVtAg2RMNNXdQiDV5gyq5XQb+K7d9VGTIqbi0/tKjqLRk/87HYVDQ==", "ca1f99f8-0272-4c22-ba94-10486896f656" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a358d19-3fda-461d-9eec-08e94e145506",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de68fd3c-6094-49ef-9930-2f4a9179e423", "AQAAAAEAACcQAAAAEPJMoTd2IAKcrUshKmEDjyL1Xk94fBC05OKyvyyg8pyxNRHhaS0L1YTJHWU1rzJCFQ==", "c8a10d1c-b8c6-4b9b-aa1e-367fe64ccdc7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
