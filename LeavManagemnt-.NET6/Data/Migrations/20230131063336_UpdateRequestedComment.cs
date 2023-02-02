using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeavManagemnt_.NET6.Data.Migrations
{
    public partial class UpdateRequestedComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComment",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3c1b4d-6ae1-263a-8c55-36f336280266",
                column: "ConcurrencyStamp",
                value: "9022f6f3-e7e1-4963-aea5-2d52837dc9d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f3c3b4d-4ae1-463a-8a55-36f336280266",
                column: "ConcurrencyStamp",
                value: "d5a03668-093c-4eaf-8997-2f7b8eacbb9f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341f3a6d-19b7-49a7-9ecf-890757774d7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8f43735-127f-4e19-abaa-596271a8c70b", "AQAAAAEAACcQAAAAEAqdpuAMqvPItQ9GjjSeKwqYUmaziR9VTuraiIKyHaBBFXe1XoRIj6PFoCCERHxajw==", "338fb8cd-e22d-426c-b343-e47799a9b72d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "851a6c4e-2b56-4b80-86b0-f94605206223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc59089c-b4af-42e3-9e6b-bcf38507a26c", "AQAAAAEAACcQAAAAEGN3POSMU4vdX2OMFburBJBo+BFQZowxBGfecPtI9cOBszTTr3o+p9ekxgC3+/ywXw==", "d0de7ff6-9ebd-45a9-8807-229f3229b79c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComment",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
