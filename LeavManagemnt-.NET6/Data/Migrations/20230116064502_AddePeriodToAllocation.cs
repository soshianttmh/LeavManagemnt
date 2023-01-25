using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeavManagemnt_.NET6.Data.Migrations
{
    public partial class AddePeriodToAllocation : Migration
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
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "1f5e050f-8975-4a42-adf1-b4ee1b12063a", "User" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "cd5d36de-c87b-4750-bfcf-b6e381cbbf4c", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                column: "ConcurrencyStamp",
                value: "39461df3-fb86-4704-883e-70b5250ec294");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341f3a6d-19b7-49a7-9ecf-890757774d7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37827635-fb22-4ce2-9a26-2f9f65a3a700", "AQAAAAEAACcQAAAAEHiM6vaojW8gAwKI/oREDb5a9cG8AKVlBEwynWbBFlD3KGywVV+Yqkz9ePNAjKOY2Q==", "cf570be7-f01e-4f14-945d-805a0ce3ebeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "851a6c4e-2b56-4b80-86b0-f94605206223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2834feaa-71ca-4556-8c4e-df938b7a057b", "AQAAAAEAACcQAAAAEMLb0P/ebJ97jPZI+uFpJVZu6BYAriyHOIfxe6X/c+GojH0dEmWLrIpADBIuuslmIg==", "1b9e685b-35dc-4cb9-8ff1-f34c06b3567d" });
        }
    }
}
