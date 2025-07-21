using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableSignAndLicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Person = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Person",
                        column: x => x.Person,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sign",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    InitialTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sign_Company",
                        column: x => x.Company,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sign_Customer",
                        column: x => x.Customer,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Sign = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProlongationInDays = table.Column<int>(type: "int", nullable: true),
                    LastDaySynced = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_Plan",
                        column: x => x.Plan,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Sign",
                        column: x => x.Sign,
                        principalTable: "Sign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Person",
                table: "Customer",
                column: "Person",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_License_Plan",
                table: "License",
                column: "Plan");

            migrationBuilder.CreateIndex(
                name: "IX_License_Sign",
                table: "License",
                column: "Sign");

            migrationBuilder.CreateIndex(
                name: "IX_Sign_Company",
                table: "Sign",
                column: "Company",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sign_Customer",
                table: "Sign",
                column: "Customer",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Sign");
        }
    }
}
