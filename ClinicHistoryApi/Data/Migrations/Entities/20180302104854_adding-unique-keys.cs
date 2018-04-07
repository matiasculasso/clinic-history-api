using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public partial class addinguniquekeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SocialSecurity_Name",
                schema: "entities",
                table: "SocialSecurity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostic_Name",
                schema: "entities",
                table: "Diagnostic",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SocialSecurity_Name",
                schema: "entities",
                table: "SocialSecurity");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostic_Name",
                schema: "entities",
                table: "Diagnostic");
        }
    }
}
