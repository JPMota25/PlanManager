using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePlanPermissionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IdCompany = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Person_PersonId",
                        column: x => x.IdCompany,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanPermission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    IdCompany = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPermission_Company",
                        column: x => x.IdCompany,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanPermissionRelation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PlanPermission = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PlanId = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    PlanPermissionId = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPermissionRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPermissionRelation_PlanPermission_PlanPermissionId",
                        column: x => x.PlanPermission,
                        principalTable: "PlanPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPermissionRelation_PlanPermission_PlanPermissionId1",
                        column: x => x.PlanPermissionId,
                        principalTable: "PlanPermission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanPermissionRelation_Plan_PlanId",
                        column: x => x.Plan,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPermissionRelation_Plan_PlanId1",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_IdCompany",
                table: "Plan",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Name",
                table: "Plan",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermission_Code",
                table: "PlanPermission",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermission_IdCompany",
                table: "PlanPermission",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_Plan",
                table: "PlanPermissionRelation",
                column: "Plan");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_PlanId",
                table: "PlanPermissionRelation",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_PlanPermission",
                table: "PlanPermissionRelation",
                column: "PlanPermission");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissionRelation_PlanPermissionId",
                table: "PlanPermissionRelation",
                column: "PlanPermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanPermissionRelation");

            migrationBuilder.DropTable(
                name: "PlanPermission");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
