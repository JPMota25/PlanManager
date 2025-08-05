using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnFromUserIdFromLogActivity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
