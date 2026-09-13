IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'Fields')
BEGIN
    CREATE TABLE agritrack.Fields
    (
        Id          UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_Fields PRIMARY KEY,
        FarmId      UNIQUEIDENTIFIER NOT NULL,
        UserId      UNIQUEIDENTIFIER NOT NULL,
        Name        NVARCHAR(200)    NOT NULL,
        AreaAcres   DECIMAL(10,2)    NULL,
        SoilType    NVARCHAR(100)    NULL,
        Location    NVARCHAR(300)    NULL,
        CreatedAt   DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Fields_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt   DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Fields_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_Fields_Farms FOREIGN KEY (FarmId) REFERENCES agritrack.Farms (Id),
        CONSTRAINT FK_agritrack_Fields_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id)
    );
    CREATE INDEX IX_agritrack_Fields_FarmId ON agritrack.Fields (FarmId);
    CREATE INDEX IX_agritrack_Fields_UserId ON agritrack.Fields (UserId);
END
GO
