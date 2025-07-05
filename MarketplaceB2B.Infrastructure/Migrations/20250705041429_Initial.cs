using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketplaceB2B.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eabde0f-0f19-4719-b423-c68f267ec590");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c72d052c-4285-4efb-a84e-35211d76a86d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "999cabc0-db26-4527-8ea0-dbb927b77394", null, "User", "USER" },
                    { "e0fd2b8d-1e96-49d4-9f24-f33698febc9d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "999cabc0-db26-4527-8ea0-dbb927b77394");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0fd2b8d-1e96-49d4-9f24-f33698febc9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6eabde0f-0f19-4719-b423-c68f267ec590", null, "User", "USER" },
                    { "c72d052c-4285-4efb-a84e-35211d76a86d", null, "Admin", "ADMIN" }
                });
        }
    }
}
