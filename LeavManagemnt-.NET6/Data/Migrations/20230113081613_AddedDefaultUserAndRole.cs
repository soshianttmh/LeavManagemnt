using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeavManagemnt_.NET6.Data.Migrations
{
    public partial class AddedDefaultUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e3c1b4d-6ae1-263a-8c55-36f336280266", "cd5d36de-c87b-4750-bfcf-b6e381cbbf4c", "user", "USER" },
                    { "0f3c3b4d-4ae1-463a-8a55-36f336280266", "39461df3-fb86-4704-883e-70b5250ec294", "Adminastrator", "ADMINASTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "341f3a6d-19b7-49a7-9ecf-890757774d7a", 0, "37827635-fb22-4ce2-9a26-2f9f65a3a700", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEHiM6vaojW8gAwKI/oREDb5a9cG8AKVlBEwynWbBFlD3KGywVV+Yqkz9ePNAjKOY2Q==", null, false, "cf570be7-f01e-4f14-945d-805a0ce3ebeb", null, false, "admin@localhost.com" },
                    { "851a6c4e-2b56-4b80-86b0-f94605206223", 0, "2834feaa-71ca-4556-8c4e-df938b7a057b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEMLb0P/ebJ97jPZI+uFpJVZu6BYAriyHOIfxe6X/c+GojH0dEmWLrIpADBIuuslmIg==", null, false, "1b9e685b-35dc-4cb9-8ff1-f34c06b3567d", null, false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e3c1b4d-6ae1-263a-8c55-36f336280266", "341f3a6d-19b7-49a7-9ecf-890757774d7a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0f3c3b4d-4ae1-463a-8a55-36f336280266", "851a6c4e-2b56-4b80-86b0-f94605206223" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e3c1b4d-6ae1-263a-8c55-36f336280266", "341f3a6d-19b7-49a7-9ecf-890757774d7a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f3c3b4d-4ae1-463a-8a55-36f336280266", "851a6c4e-2b56-4b80-86b0-f94605206223" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f3c3b4d-4ae1-463a-8a55-36f336280266");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341f3a6d-19b7-49a7-9ecf-890757774d7a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "851a6c4e-2b56-4b80-86b0-f94605206223");
        }
    }
}
