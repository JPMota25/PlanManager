using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompanyWasUniqueInTableCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Company",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Company",
                table: "Customer",
                column: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Company",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Company",
                table: "Customer",
                column: "Company",
                unique: true);
        }
    }
}
