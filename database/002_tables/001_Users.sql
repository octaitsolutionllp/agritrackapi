IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'Users')
BEGIN
    CREATE TABLE agritrack.Users
    (
        Id                  UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_Users PRIMARY KEY,
        Name                NVARCHAR(200)    NOT NULL,
        EmailOrPhone        NVARCHAR(200)    NOT NULL,
        PasswordHash        NVARCHAR(500)    NOT NULL,
        PreferredLanguage   NVARCHAR(5)      NOT NULL CONSTRAINT DF_agritrack_Users_PreferredLanguage DEFAULT ('en'),
        CreatedAt           DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Users_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt           DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Users_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT UQ_agritrack_Users_EmailOrPhone UNIQUE (EmailOrPhone)
    );
END
GO
