IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'CropTypes')
BEGIN
    CREATE TABLE agritrack.CropTypes
    (
        Id                          UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_CropTypes PRIMARY KEY,
        Name                        NVARCHAR(100)    NOT NULL,
        -- JSON: { "Sowing":0, "Germination":7, "Vegetative":30, "Flowering":20, "Fruiting":25 } (days spent in each stage)
        StageDurationDaysJson       NVARCHAR(MAX)    NOT NULL,
        -- JSON: { "Sowing":3, "Germination":2, "Vegetative":3, "Flowering":2, "Fruiting":3 } (watering interval per stage, in days)
        WaterIntervalDaysJson       NVARCHAR(MAX)    NOT NULL,
        -- JSON: { "Vegetative":14, "Flowering":10, "Fruiting":14 } (pesticide interval per stage, in days; stages not listed = no scheduled pesticide reminder)
        PesticideIntervalDaysJson   NVARCHAR(MAX)    NOT NULL,
        CreatedAt                   DATETIME2        NOT NULL CONSTRAINT DF_agritrack_CropTypes_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt                   DATETIME2        NOT NULL CONSTRAINT DF_agritrack_CropTypes_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT UQ_agritrack_CropTypes_Name UNIQUE (Name)
    );
END
GO
