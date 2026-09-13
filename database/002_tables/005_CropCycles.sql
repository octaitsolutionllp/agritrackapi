IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'CropCycles')
BEGIN
    CREATE TABLE agritrack.CropCycles
    (
        Id                      UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_CropCycles PRIMARY KEY,
        UserId                  UNIQUEIDENTIFIER NOT NULL,
        FieldId                 UNIQUEIDENTIFIER NOT NULL,
        CropTypeId              UNIQUEIDENTIFIER NOT NULL,
        SeedVariety             NVARCHAR(200)    NULL,
        SownDate                DATE             NOT NULL,
        ExpectedHarvestDate     DATE             NULL,
        CurrentStage            NVARCHAR(30)     NOT NULL CONSTRAINT DF_agritrack_CropCycles_CurrentStage DEFAULT ('LandPreparation'),
        StageStartedAt          DATE             NOT NULL,
        Status                  NVARCHAR(20)     NOT NULL CONSTRAINT DF_agritrack_CropCycles_Status DEFAULT ('Active'),
        CreatedAt               DATETIME2        NOT NULL CONSTRAINT DF_agritrack_CropCycles_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt               DATETIME2        NOT NULL CONSTRAINT DF_agritrack_CropCycles_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_CropCycles_Fields FOREIGN KEY (FieldId) REFERENCES agritrack.Fields (Id),
        CONSTRAINT FK_agritrack_CropCycles_CropTypes FOREIGN KEY (CropTypeId) REFERENCES agritrack.CropTypes (Id),
        CONSTRAINT FK_agritrack_CropCycles_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id)
    );
    CREATE INDEX IX_agritrack_CropCycles_UserId ON agritrack.CropCycles (UserId);
    CREATE INDEX IX_agritrack_CropCycles_FieldId ON agritrack.CropCycles (FieldId);
END
GO
