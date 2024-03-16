# Academy Calendar API
This is the Academy Calendar API built with ASP.NET Core.

## Developer utilities
This section shows some useful información for the developers.

### Entity Framework
- Create first migration: dotnet ef migrations add InitialCreate -o Data/Migrations
- Add migration: dotnet ef migrations add <migration-name>
- Update database: dotnet ef database update
- Update to previous version: dotnet ef database update <previous-migration-name>
- Remove migration: dotnet ef migrations remove
- Remove database: dotnet ef database drop

