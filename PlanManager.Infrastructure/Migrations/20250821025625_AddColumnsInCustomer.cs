using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsInCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Sign",
                type: "nvarchar(44)",
                maxLength: 44,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tokens",
                table: "License",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Customer",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecretToken",
                table: "Customer",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Tokens",
                table: "License");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SecretToken",
                table: "Customer");
        }
    }
}
