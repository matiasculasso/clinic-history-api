using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public partial class adding_complements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "entities",
                table: "Patient",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "entities",
                table: "Patient",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolPerformance",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhysicalExam",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhysicalActivity",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evolution",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DefecatoryHabit",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alimentation",
                schema: "entities",
                table: "Consultation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Complement",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsultationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplementaryMethod",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplementaryMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratory",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplementaryMethodInstance",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplementId = table.Column<int>(type: "int", nullable: true),
                    ComplementaryMethodId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplementaryMethodInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplementaryMethodInstance_Complement_ComplementId",
                        column: x => x.ComplementId,
                        principalSchema: "entities",
                        principalTable: "Complement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryInstance",
                schema: "entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplementId = table.Column<int>(type: "int", nullable: true),
                    LaboratoryId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryInstance_Complement_ComplementId",
                        column: x => x.ComplementId,
                        principalSchema: "entities",
                        principalTable: "Complement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_PatientId",
                schema: "entities",
                table: "Consultation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Complement_ConsultationId",
                schema: "entities",
                table: "Complement",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplementaryMethodInstance_ComplementId",
                schema: "entities",
                table: "ComplementaryMethodInstance",
                column: "ComplementId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplementaryMethodInstance_ComplementaryMethodId",
                schema: "entities",
                table: "ComplementaryMethodInstance",
                column: "ComplementaryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryInstance_ComplementId",
                schema: "entities",
                table: "LaboratoryInstance",
                column: "ComplementId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryInstance_LaboratoryId",
                schema: "entities",
                table: "LaboratoryInstance",
                column: "LaboratoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplementaryMethod",
                schema: "entities");

            migrationBuilder.DropTable(
                name: "ComplementaryMethodInstance",
                schema: "entities");

            migrationBuilder.DropTable(
                name: "Laboratory",
                schema: "entities");

            migrationBuilder.DropTable(
                name: "LaboratoryInstance",
                schema: "entities");

            migrationBuilder.DropTable(
                name: "Complement",
                schema: "entities");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_PatientId",
                schema: "entities",
                table: "Consultation");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "entities",
                table: "Patient",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "entities",
                table: "Patient",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolPerformance",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhysicalExam",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhysicalActivity",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evolution",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DefecatoryHabit",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alimentation",
                schema: "entities",
                table: "Consultation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
