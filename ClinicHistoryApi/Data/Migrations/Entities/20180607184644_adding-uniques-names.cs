using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public partial class addinguniquesnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "entities",
                table: "Laboratory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "entities",
                table: "ComplementaryMethod",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_Name",
                schema: "entities",
                table: "Laboratory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplementaryMethod_Name",
                schema: "entities",
                table: "ComplementaryMethod",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Laboratory_Name",
                schema: "entities",
                table: "Laboratory");

            migrationBuilder.DropIndex(
                name: "IX_ComplementaryMethod_Name",
                schema: "entities",
                table: "ComplementaryMethod");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "entities",
                table: "Laboratory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "entities",
                table: "ComplementaryMethod",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
