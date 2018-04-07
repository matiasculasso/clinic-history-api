using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public partial class adding_consultations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "entities",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "entities",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Consultation",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alimentation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplementaryMethodRequested = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefecatoryHabit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PhysicalActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalExam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPerformance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultation",
                schema: "entities");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "entities",
                table: "Patient",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "entities",
                table: "Patient",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
