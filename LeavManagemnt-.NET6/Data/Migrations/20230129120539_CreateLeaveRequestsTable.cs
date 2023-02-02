using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeavManagemnt_.NET6.Data.Migrations
{
    public partial class CreateLeaveRequestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                column: "ConcurrencyStamp",
                value: "e55d1de1-1ef3-49e3-9e3c-85e7d635688c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                column: "ConcurrencyStamp",
                value: "2ec95a69-6501-41a8-8a2e-485402a87bb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341f3a6d-19b7-49a7-9ecf-890757774d7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37c8637b-86c5-4db0-a881-ee245fcfb51e", "AQAAAAEAACcQAAAAEHiiCPR6bRQnI7EByH5GdUm+1zemU2sr29IoDpbl0NgQ5JPEM1cm6dO+18r/rA/fHQ==", "72e18c21-c1f6-4ac5-8944-48e443f5eeb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "851a6c4e-2b56-4b80-86b0-f94605206223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2591ee7-8dc8-4792-b6fc-b50d56e9bb39", "AQAAAAEAACcQAAAAEDikMeRKmK4TS/S6v9OlX2Ym2NQvhOKVuORd9V+IjSDnl6rgBv92JxXmxchTPCI5Fg==", "df6094ed-bab9-4dd3-9e9f-b5d9496265eb" });

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
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                column: "ConcurrencyStamp",
                value: "f323b3dd-55c1-44cb-a0ca-a932f4784518");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                column: "ConcurrencyStamp",
                value: "f98dbf4d-617d-428f-9ba2-8d5770802398");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341f3a6d-19b7-49a7-9ecf-890757774d7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db45c626-1377-4b98-9282-6ad0325965a9", "AQAAAAEAACcQAAAAEE+KDZh8SAygUXQimBBuWLJj3bk3/aEqpVBor1ASqXWqSG5PTlKfbu3j294pf2M7hw==", "e177d0ce-6e93-44ca-9cb9-a7ea17707406" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "851a6c4e-2b56-4b80-86b0-f94605206223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4007c917-483a-4768-bba1-11c38ec7862e", "AQAAAAEAACcQAAAAEAXhAH+DYIiGvv9CeC7X0FBUxpTTIPVlxHlXpXpR03x8ZSyLUypntRJ/irbc3dK5HA==", "80b4f67c-4b52-4d2b-ab2d-d260fe920312" });
        }
    }
}
