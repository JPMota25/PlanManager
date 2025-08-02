using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterProjectArchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ProlongationInDays",
                table: "License",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpireDate",
                table: "License",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

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

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "LogActivity",
                newName: "FromUserIdVo");

            migrationBuilder.RenameIndex(
                name: "IX_LogActivity_FromUserId",
                table: "LogActivity",
                newName: "IX_LogActivity_FromUserIdVo");

            migrationBuilder.AlterColumn<int>(
                name: "ProlongationInDays",
                table: "License",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpireDate",
                table: "License",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActivity_User_FromUserIdVo",
                table: "LogActivity",
                column: "FromUserIdVo",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
