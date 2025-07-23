using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTabbleLogActivityFKUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogActivity_User",
                table: "LogActivity");

            migrationBuilder.DropIndex(
                name: "IX_LogActivity_User",
                table: "LogActivity");

            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "LogActivity",
                type: "nvarchar(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogActivity_FromUserId",
                table: "LogActivity",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActivity_User_FromUserId",
                table: "LogActivity",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogActivity_User_FromUserId",
                table: "LogActivity");

            migrationBuilder.DropIndex(
                name: "IX_LogActivity_FromUserId",
                table: "LogActivity");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "LogActivity");

            migrationBuilder.CreateIndex(
                name: "IX_LogActivity_User",
                table: "LogActivity",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActivity_User",
                table: "LogActivity",
                column: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
