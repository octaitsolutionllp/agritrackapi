IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'Activities')
BEGIN
    CREATE TABLE agritrack.Activities
    (
        Id            UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_Activities PRIMARY KEY,
        UserId        UNIQUEIDENTIFIER NOT NULL,
        CropCycleId   UNIQUEIDENTIFIER NOT NULL,
        ActivityType  NVARCHAR(30)     NOT NULL, -- Water | Pesticide | Fertilizer | Weeding | EarthingUp | Sieving | Other
        ActivityDate  DATE             NOT NULL,
        Cost          DECIMAL(10,2)    NULL,
        Notes         NVARCHAR(1000)   NULL,
        CreatedAt     DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Activities_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt     DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Activities_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_Activities_CropCycles FOREIGN KEY (CropCycleId) REFERENCES agritrack.CropCycles (Id),
        CONSTRAINT FK_agritrack_Activities_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id)
    );
    CREATE INDEX IX_agritrack_Activities_CropCycleId ON agritrack.Activities (CropCycleId, ActivityType, ActivityDate);
    CREATE INDEX IX_agritrack_Activities_UserId ON agritrack.Activities (UserId);
END
GO
