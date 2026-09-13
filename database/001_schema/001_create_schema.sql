-- AgriTrack: create the agritrack schema (all AgriTrack objects live here, never in dbo)
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'agritrack')
BEGIN
    EXEC('CREATE SCHEMA agritrack');
END
GO
