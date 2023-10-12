using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class IdentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7547f5a-4df5-4b49-8973-f3c8d04a0da0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5369c01-0e4a-4da2-b25c-7d8d1390b573");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c1ad9ea-9af0-45e1-9354-4d5ef0ad2265", "dd8b052f-aa77-460f-aecb-4c0f53afd6bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9baf56c8-69e5-420b-849d-2010c570c79e", "4cdb1081-2e45-40f6-8433-34074d9f45b9", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c1ad9ea-9af0-45e1-9354-4d5ef0ad2265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9baf56c8-69e5-420b-849d-2010c570c79e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7547f5a-4df5-4b49-8973-f3c8d04a0da0", "2c3055b5-9ac6-45a4-a5ea-241330886270", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5369c01-0e4a-4da2-b25c-7d8d1390b573", "d5e3f913-7aa3-4499-8ae6-65a3fab2d597", "Admin", "ADMIN" });
        }
    }
}
