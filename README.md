# AgriTrack API

.NET 10 Web API backend for AgriTrack — an app that helps individual farmers track crop/seed growth stages, log expenses per crop, see profit & loss, and get smart watering/pesticide reminders.

Companion repo: [agritrackui](https://github.com/octaitsolutionllp/agritrackui) (React Native / Expo app).

See [CLAUDE.md](CLAUDE.md) for the full architecture reference (schema, stored-procedure conventions, auth model, etc.) — read it before making changes.

## Stack

- .NET 10, Minimal APIs, Clean Vertical Slice Architecture (no MediatR, no Controllers)
- Dapper + SQL Server stored procedures only — no Entity Framework, no inline SQL
- All primary/foreign keys are GUIDs
- JWT Bearer auth, per-user data isolation (no tenant/role concept)

## Local setup

1. Create a local SQL Server database named `agritrack`.
2. Run the scripts under `database/` in order: `001_schema/`, `002_tables/`, `003_procs/`, `004_seed/`.
   ```
   sqlcmd -S <your-instance> -U sa -P <your-password> -d agritrack -C -i path\to\script.sql
   ```
3. Copy `src/AgriTrack.Api/appsettings.Development.json.example` to `appsettings.Development.json` and fill in your own connection string.
4. Run the API:
   ```
   dotnet run --project src/AgriTrack.Api
   ```
   Default: `http://localhost:5012`.

## Repo layout

```
AgriTrack.slnx
src/
  AgriTrack.Api/             host: Program.cs, appsettings*.json
  AgriTrack.Domain/          Entities/ (plain POCOs, GUID keys)
  AgriTrack.Application/     Features/<Area>/<UseCase>/, Common/, EndpointMapping.cs
  AgriTrack.Infrastructure/  DbConnectionFactory, DapperStoredProcRepository, StoredProcedures.cs
database/
  001_schema/    CREATE SCHEMA agritrack
  002_tables/    one file per table
  003_procs/     one file per stored procedure
  004_seed/      crop type seed data
```
