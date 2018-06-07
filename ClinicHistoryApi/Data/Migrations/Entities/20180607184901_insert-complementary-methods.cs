using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
	public partial class insertcomplementarymethods : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sql = @"insert into entities.ComplementaryMethod ([name] ) values('Biopsia hepática') 
						insert into entities.ComplementaryMethod ([name] ) values('Endoscopía Digestiva Alta')
						insert into entities.ComplementaryMethod ([name] ) values('Colonoscopía')
						insert into entities.ComplementaryMethod ([name] ) values('TEGD')
						insert into entities.ComplementaryMethod ([name] ) values('Videodeglución')
						insert into entities.ComplementaryMethod ([name] ) values('Colon por enema simple')
						insert into entities.ComplementaryMethod ([name] ) values('Colon Por enema doble contrate')
						insert into entities.ComplementaryMethod ([name] ) values('Tránsito Intestinal')
						insert into entities.ComplementaryMethod ([name] ) values('Test del Sudor')
						insert into entities.ComplementaryMethod ([name] ) values('PPD')
						insert into entities.ComplementaryMethod ([name] ) values('Test del aliento')
						insert into entities.ComplementaryMethod ([name] ) values('Cápsula endoscópica')
						insert into entities.ComplementaryMethod ([name] ) values('Colangiopancreatografía retrógrada endoscópica')
						insert into entities.ComplementaryMethod ([name] ) values('Ecografías hepatobiliar y gastrointestinal')
						insert into entities.ComplementaryMethod ([name] ) values('Ecografía Doppler Abdominal')
						insert into entities.ComplementaryMethod ([name] ) values('Tomografía axial computarizada de abdomen')
						insert into entities.ComplementaryMethod ([name] ) values('Resonancia Magnética Abdominal')
						insert into entities.ComplementaryMethod ([name] ) values('Centellografía Abdominal con TC 99')
						insert into entities.ComplementaryMethod ([name] ) values('Centellografía Gastroesofágica y Pulmonar')
						insert into entities.ComplementaryMethod ([name] ) values('Angiografía')
						insert into entities.ComplementaryMethod ([name] ) values('Colangiopancreatoresonancia')
						insert into entities.ComplementaryMethod ([name] ) values('Colangiografía')
						insert into entities.ComplementaryMethod ([name] ) values('Manometría ano-rectal')
						insert into entities.ComplementaryMethod ([name] ) values('Marcadores Colónicos')
						insert into entities.ComplementaryMethod ([name] ) values('Manometría esofágica')
						insert into entities.ComplementaryMethod ([name] ) values('PHmetría esofágica')
						insert into entities.ComplementaryMethod ([name] ) values('Impedanciometría esofágica')
						insert into entities.ComplementaryMethod ([name] ) values('Ecocardiograma')
						insert into entities.ComplementaryMethod ([name] ) values('Fondo de Ojo')
						insert into entities.ComplementaryMethod ([name] ) values('Examen con Lámpara de Hendidura')
						insert into entities.ComplementaryMethod ([name] ) values('Broncoscopía')
						insert into entities.ComplementaryMethod ([name] ) values('Rx tórax')
						insert into entities.ComplementaryMethod ([name] ) values('Rx abdomen')
						insert into entities.ComplementaryMethod ([name] ) values('Rx columna')
						insert into entities.ComplementaryMethod ([name] ) values('Rx miembros')
						insert into entities.ComplementaryMethod ([name] ) values('Rx muñeca izquierda (edad ósea)')";
			migrationBuilder.Sql(sql);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("delete from entities.ComplementaryMethod");
		}
	}
}
