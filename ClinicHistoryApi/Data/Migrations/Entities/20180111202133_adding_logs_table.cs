using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    public class _20180111202133_adding_logs_table : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(
				@"IF NOT EXISTS(SELECT * FROM sys.schemas WHERE name = 'Entities')
                BEGIN
                    EXEC('CREATE SCHEMA Entities')
                END                

                CREATE TABLE [Entities].[ClinicHistoryLogs] (
                    [Id] int IDENTITY(1, 1) NOT NULL,
                    [Message] nvarchar(max) NULL,
                    [MessageTemplate] nvarchar(max) NULL,
                    [Level] nvarchar(128) NULL,
                    [TimeStamp] datetimeoffset(7) NOT NULL, --use datetime for SQL Server pre - 2008
                    [Exception] nvarchar(max) NULL,
                    [Properties] xml NULL,
                    [LogEvent] nvarchar(max) NULL
                CONSTRAINT[PK_Logs]
                    PRIMARY KEY CLUSTERED([Id] ASC)
                        WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
                            ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                    ON[PRIMARY]
                ) ON[PRIMARY];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"DROP TABLE [Entities].[ClinicHistoryLogs]");
		}
	}
}
