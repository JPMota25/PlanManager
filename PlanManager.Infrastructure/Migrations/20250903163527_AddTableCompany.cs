using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Plan",
                table: "License");

            migrationBuilder.DropIndex(
                name: "IX_License_Plan",
                table: "License");

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "License");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Sign",
                type: "nvarchar(44)",
                maxLength: 44,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(44)",
                oldMaxLength: 44,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "Sign",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sign_Plan",
                table: "Sign",
                column: "Plan");

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Plan",
                table: "Sign",
                column: "Plan",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Plan",
                table: "Sign");

            migrationBuilder.DropIndex(
                name: "IX_Sign_Plan",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Sign");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Sign",
                type: "nvarchar(44)",
                maxLength: 44,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(44)",
                oldMaxLength: 44);

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "License",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_License_Plan",
                table: "License",
                column: "Plan");

            migrationBuilder.AddForeignKey(
                name: "FK_License_Plan",
                table: "License",
                column: "Plan",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
