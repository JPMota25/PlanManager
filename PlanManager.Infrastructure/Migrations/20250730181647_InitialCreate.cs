using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PhoneNumberWithDigit = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Neighboorhood = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HasHouseNumber = table.Column<bool>(type: "bit", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IdPerson = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person",
                        column: x => x.IdPerson,
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
                        name: "FK_PlanPermissionRelation_Plan_PlanId",
                        column: x => x.Plan,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "LogActivity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    User = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ObjectId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogActivity_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id");
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
                name: "IX_LogActivity_FromUserId",
                table: "LogActivity",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Document",
                table: "Person",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_EmailAddress",
                table: "Person",
                column: "EmailAddress",
                unique: true);

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
                name: "IX_PlanPermissionRelation_PlanPermission",
                table: "PlanPermissionRelation",
                column: "PlanPermission");

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

            migrationBuilder.CreateIndex(
                name: "IX_User_IdPerson",
                table: "User",
                column: "IdPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
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
                name: "LogActivity");

            migrationBuilder.DropTable(
                name: "PlanPermissionRelation");

            migrationBuilder.DropTable(
                name: "Sign");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PlanPermission");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
