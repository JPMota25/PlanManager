using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingReferenceINCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_IdCompany",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Person",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdCompany",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "Person",
                table: "Customer",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Person",
                table: "Customer",
                column: "Person",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Company_IdCompany",
                table: "Customer",
                column: "Company",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Person",
                table: "Customer",
                column: "Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_IdCompany",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Person",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Person",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Person",
                table: "Customer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Person",
                table: "Customer",
                column: "Company",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
