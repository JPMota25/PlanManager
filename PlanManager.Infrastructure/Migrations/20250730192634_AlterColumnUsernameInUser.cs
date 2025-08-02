using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnUsernameInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogActivity_User_FromUserId",
                table: "LogActivity");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "LogActivity",
                newName: "FromUserIdVo");

            migrationBuilder.RenameIndex(
                name: "IX_LogActivity_FromUserId",
                table: "LogActivity",
                newName: "IX_LogActivity_FromUserIdVo");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActivity_User_FromUserIdVo",
                table: "LogActivity",
                column: "FromUserIdVo",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogActivity_User_FromUserIdVo",
                table: "LogActivity");

            migrationBuilder.RenameColumn(
                name: "FromUserIdVo",
                table: "LogActivity",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LogActivity_FromUserIdVo",
                table: "LogActivity",
                newName: "IX_LogActivity_FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActivity_User_FromUserId",
                table: "LogActivity",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
