IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'Farms')
BEGIN
    CREATE TABLE agritrack.Farms
    (
        Id              UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_Farms PRIMARY KEY,
        UserId          UNIQUEIDENTIFIER NOT NULL,
        Name            NVARCHAR(200)    NOT NULL,
        TotalAreaAcres  DECIMAL(10,2)    NULL,
        CreatedAt       DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Farms_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt       DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Farms_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_Farms_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id)
    );
    CREATE INDEX IX_agritrack_Farms_UserId ON agritrack.Farms (UserId);
END
GO
