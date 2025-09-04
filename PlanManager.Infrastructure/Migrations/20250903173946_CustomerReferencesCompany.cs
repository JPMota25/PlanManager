using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerReferencesCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person",
                table: "Customer",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Person",
                table: "Customer",
                newName: "IX_Customer_Company");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Company",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Company_Company",
                table: "Company",
                newName: "IX_Company_Person");

            migrationBuilder.AddColumn<string>(
                name: "IdCompany",
                table: "Customer",
                type: "nvarchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdCompany",
                table: "Customer",
                column: "IdCompany",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Company_IdCompany",
                table: "Customer",
                column: "IdCompany",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_IdCompany",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdCompany",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Customer",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Company",
                table: "Customer",
                newName: "IX_Customer_Person");

            migrationBuilder.RenameColumn(
                name: "Person",
                table: "Company",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Company_Person",
                table: "Company",
                newName: "IX_Company_Company");
        }
    }
}
