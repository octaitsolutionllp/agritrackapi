IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'CropStageHistory')
BEGIN
    CREATE TABLE agritrack.CropStageHistory
    (
        Id           UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_CropStageHistory PRIMARY KEY,
        CropCycleId  UNIQUEIDENTIFIER NOT NULL,
        Stage        NVARCHAR(30)     NOT NULL,
        StartedAt    DATE             NOT NULL,
        CreatedAt    DATETIME2        NOT NULL CONSTRAINT DF_agritrack_CropStageHistory_CreatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_CropStageHistory_CropCycles FOREIGN KEY (CropCycleId) REFERENCES agritrack.CropCycles (Id)
    );
    CREATE INDEX IX_agritrack_CropStageHistory_CropCycleId ON agritrack.CropStageHistory (CropCycleId);
END
GO
