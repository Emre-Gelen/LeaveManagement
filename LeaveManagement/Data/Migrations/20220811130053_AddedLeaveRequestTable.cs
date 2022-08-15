using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestiongEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
                column: "ConcurrencyStamp",
                value: "3706f27e-f249-4ed4-bf18-5a2861ca1b20");

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
    }
}
