using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermissionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupPermission",
                table: "User",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupPermission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermission", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupPermission",
                table: "User",
                column: "GroupPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_User_GroupPermission_IdGroupPermission",
                table: "User",
                column: "GroupPermission",
                principalTable: "GroupPermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_GroupPermission_IdGroupPermission",
                table: "User");

            migrationBuilder.DropTable(
                name: "GroupPermission");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupPermission",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupPermission",
                table: "User");
        }
    }
}
