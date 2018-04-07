echo You are about to apply migrations and update your configured database. Are you sure?
pause

cd CLinicHistoryApi

echo APPLYING CONFIGURATIONDBCONTEXT MIGRATIONS
dotnet ef database update -c ConfigurationDbContext
echo DONE

echo APPLYING PERSISTEDGRANTDBCONTEXT MIGRATIONS
dotnet ef database update -c PersistedGrantDbContext
echo DONE

echo APPLYING USERSDBCONTEXT MIGRATIONS
dotnet ef database update -c UsersDbContext
echo DONE

echo APPLYING ENTITIESDBCONTEX MIGRATIONS
dotnet ef database update -c EntitiesDbContext
echo DONE

pause
