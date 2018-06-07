﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public partial class insertlaboratories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var sql = @"INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Hb')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Hcto')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('G.Blancos')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Plaquetas')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Sodio')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Potasio')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Cloro')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Calcio')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Fósforo')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Magnesio')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Gases')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Creatinina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Urea')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Glucemia')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('GOT')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('GPT')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('GGT')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('FAL')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('5N')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Bilirrubina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Amonio')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ácidos Biliares')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('APP') 
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('KPTT')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Factores de Coagulación')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Colesterol total')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('HDL')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('LDL')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Triglicéridos')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Amilasa')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Lipasa')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Proteinas totales')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Albúmina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Globulinas')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('IgE')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('IgA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('IgM')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('IgG')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ac. Antitransglutaminasa IgA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ac. Antitransglutaminasa IgG')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ac. Antigliadina Deaminada IgA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ac. Antigliadina Deaminada IgG')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ac. Antiendomisio IgA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ac. Antiendomisio IgG')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('HLA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('TSH')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('T4 libre')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('TPO')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('ATG')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('ANA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('ASMA')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Tiopurina metiltransferasa')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Clearence de A1ATfecal')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('A1 antitripsina fecal')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Calprotectina Fecal')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Elastasa fecal')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Quimiotripsina fecal')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Esteatrocrito')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Van de Kammer')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('SOMF inmunológico')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('PMN')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('pH ')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Addler')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ag.rotavirus fecal')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Coprocultivo')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Coproparasitologico seriado')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Sustancias Reductoras en orina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Urocultivo')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Orina completa')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Estudios Metabólicos')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Estudios Genéticos')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Gen AYRE')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Estudios Genéticos Enfermedad Celíaca')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Estudios Genéticos Poliposis ')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Estudios Genéticos FQ')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Cariotipo')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Anca P')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Anca C')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Cupruria')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Cupremia')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Alfa1antitripsina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Alfafetoproteína')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ceruloplasmina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('%Saturación transferrina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Transferrina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Ferritina')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('Hierro')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('AntiHBc')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('AntiHBs')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('HBsAg')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('ASGP')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('SLA/LP')
						INSERT INTO [entities].[Laboratory] ([Name]) VALUES ('AntiLKM')";
			migrationBuilder.Sql(sql);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("delete from entities.Laboratory");
		}
    }
}
