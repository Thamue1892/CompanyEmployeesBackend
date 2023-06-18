using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "979acd8f-e81e-4b2e-9cf3-6cee8985de4a", "d4e51ea2-7e22-4f0d-a161-bed6ba70f360", "Manager", "MANAGER" },
                    { "adeb8f26-ed53-4c5a-bf8c-b1fdac51e8b9", "e6666590-1a78-48ab-9251-aac3824e55f3", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "979acd8f-e81e-4b2e-9cf3-6cee8985de4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adeb8f26-ed53-4c5a-bf8c-b1fdac51e8b9");
        }
    }
}
