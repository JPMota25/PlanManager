using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Person_PersonId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPermission_Company",
                table: "PlanPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Company",
                table: "Sign");

            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Customer",
                table: "Sign");

            migrationBuilder.RenameColumn(
                name: "IdCompany",
                table: "PlanPermission",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPermission_IdCompany",
                table: "PlanPermission",
                newName: "IX_PlanPermission_Company");

            migrationBuilder.RenameColumn(
                name: "IdCompany",
                table: "Plan",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_IdCompany",
                table: "Plan",
                newName: "IX_Plan_Company");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "PlanPermissionRelation",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_Company",
                table: "PlanPermissionRelation",
                column: "Company",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Company_IdCompany",
                table: "Plan",
                column: "Company",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPermission_Company",
                table: "PlanPermission",
                column: "Company",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPermissionRelation_Company_IdCompany",
                table: "PlanPermissionRelation",
                column: "Company",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Company_IdCompany",
                table: "Sign",
                column: "Company",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Customer",
                table: "Sign",
                column: "Customer",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Company_IdCompany",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPermission_Company",
                table: "PlanPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPermissionRelation_Company_IdCompany",
                table: "PlanPermissionRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Company_IdCompany",
                table: "Sign");

            migrationBuilder.DropForeignKey(
                name: "FK_Sign_Customer",
                table: "Sign");

            migrationBuilder.DropIndex(
                name: "IX_PlanPermissionRelation_Company",
                table: "PlanPermissionRelation");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "PlanPermissionRelation");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "PlanPermission",
                newName: "IdCompany");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPermission_Company",
                table: "PlanPermission",
                newName: "IX_PlanPermission_IdCompany");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Plan",
                newName: "IdCompany");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_Company",
                table: "Plan",
                newName: "IX_Plan_IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Person_PersonId",
                table: "Plan",
                column: "IdCompany",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPermission_Company",
                table: "PlanPermission",
                column: "IdCompany",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Company",
                table: "Sign",
                column: "Company",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sign_Customer",
                table: "Sign",
                column: "Customer",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
