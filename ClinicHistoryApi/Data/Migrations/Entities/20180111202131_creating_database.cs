using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public partial class creating_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "entities");

            migrationBuilder.CreateTable(
                name: "Diagnostic",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialSecurity",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialSecurity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosticId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EpidemiologicalBackground = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyBackground = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    PathologicalBackground = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysiologicalBackground = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrerinatologicalBackground = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Diagnostic_DiagnosticId",
                        column: x => x.DiagnosticId,
                        principalSchema: "entities",
                        principalTable: "Diagnostic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_SocialSecurity_SocialSecurityId",
                        column: x => x.SocialSecurityId,
                        principalSchema: "entities",
                        principalTable: "SocialSecurity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DiagnosticId",
                schema: "entities",
                table: "Patient",
                column: "DiagnosticId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_IdentificationNumber",
                schema: "entities",
                table: "Patient",
                column: "IdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_LastName",
                schema: "entities",
                table: "Patient",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Name",
                schema: "entities",
                table: "Patient",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_SocialSecurityId",
                schema: "entities",
                table: "Patient",
                column: "SocialSecurityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient",
                schema: "entities");

            migrationBuilder.DropTable(
                name: "Diagnostic",
                schema: "entities");

            migrationBuilder.DropTable(
                name: "SocialSecurity",
                schema: "entities");
        }
    }
}
