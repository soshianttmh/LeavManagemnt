using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeavManagemnt_.NET6.Data.Migrations
{
    public partial class SetEmployeeIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                column: "ConcurrencyStamp",
                value: "1f5e050f-8975-4a42-adf1-b4ee1b12063a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                column: "ConcurrencyStamp",
                value: "1189c956-9563-45f3-b3da-45662813bd06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341f3a6d-19b7-49a7-9ecf-890757774d7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b45f6d3b-ec0b-44b9-9023-0d1442476f8a", "AQAAAAEAACcQAAAAEJ8WoRXaIQVOXGip4q/NtRgAGQd3n0KMvnQFh3A8unUixPgudWPT+f/yBiI7dqZMFg==", "ce004a19-c331-45dd-adf5-a1a579deba09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "851a6c4e-2b56-4b80-86b0-f94605206223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "323356a3-f94b-46f8-88de-2b995f026767", "AQAAAAEAACcQAAAAEODNFo5/HgEVF24OrETLELA4YUYK2wQ2zcMg4zNa99WZ/2xRBApsUcwTY3vJPCtpmg==", "af7e3510-8e3a-4e27-92ef-35f39b9ee54a" });
        }
    }
}
