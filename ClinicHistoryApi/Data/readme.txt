ADD INITIAL MIGRATION

dotnet ef migrations add [migration-name] -c EntitiesDbContext -o Data/Migrations/Entities

UPDATE DATABASE USING MIGRATIONS
dotnet ef database update -c EntitiesDbContext