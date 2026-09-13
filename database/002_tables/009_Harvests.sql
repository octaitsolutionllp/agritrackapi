IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'Harvests')
BEGIN
    CREATE TABLE agritrack.Harvests
    (
        Id             UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_Harvests PRIMARY KEY,
        UserId         UNIQUEIDENTIFIER NOT NULL,
        CropCycleId    UNIQUEIDENTIFIER NOT NULL,
        HarvestDate    DATE             NOT NULL,
        YieldQuantity  DECIMAL(10,2)    NULL,
        YieldUnit      NVARCHAR(20)     NULL,
        SaleIncome     DECIMAL(10,2)    NULL,
        Notes          NVARCHAR(1000)   NULL,
        CreatedAt      DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Harvests_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt      DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Harvests_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_Harvests_CropCycles FOREIGN KEY (CropCycleId) REFERENCES agritrack.CropCycles (Id),
        CONSTRAINT FK_agritrack_Harvests_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id)
    );
    CREATE INDEX IX_agritrack_Harvests_CropCycleId ON agritrack.Harvests (CropCycleId);
END
GO
