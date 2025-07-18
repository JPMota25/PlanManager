using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePlanPermissionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanPermissionRelation_PlanPermission_PlanPermissionId1",
                table: "PlanPermissionRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPermissionRelation_Plan_PlanId1",
                table: "PlanPermissionRelation");

            migrationBuilder.DropIndex(
                name: "IX_PlanPermissionRelation_PlanId",
                table: "PlanPermissionRelation");

            migrationBuilder.DropIndex(
                name: "IX_PlanPermissionRelation_PlanPermissionId",
                table: "PlanPermissionRelation");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "PlanPermissionRelation");

            migrationBuilder.DropColumn(
                name: "PlanPermissionId",
                table: "PlanPermissionRelation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanId",
                table: "PlanPermissionRelation",
                type: "nvarchar(11)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanPermissionId",
                table: "PlanPermissionRelation",
                type: "nvarchar(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_PlanId",
                table: "PlanPermissionRelation",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_PlanPermissionId",
                table: "PlanPermissionRelation",
                column: "PlanPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPermissionRelation_PlanPermission_PlanPermissionId1",
                table: "PlanPermissionRelation",
                column: "PlanPermissionId",
                principalTable: "PlanPermission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPermissionRelation_Plan_PlanId1",
                table: "PlanPermissionRelation",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }
    }
}
