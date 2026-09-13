-- Ratoon/multi-cycle cropping support (e.g. sugarcane's Lagwad -> Khodva 1 -> Khodva 2):
-- CycleLabel is a free-text label the farmer sets per cycle ("Lagwad", "Khodva 1", ...).
-- ParentCropCycleId points at the immediate previous cycle this one regrew/restarted from.
-- RootCropCycleId is denormalized to the ultimate ancestor's Id (or itself, if it IS the root) —
-- this turns "get the whole lineage" into a single indexed equality lookup instead of a recursive walk.
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.CropCycles') AND name = 'CycleLabel')
BEGIN
    ALTER TABLE agritrack.CropCycles ADD CycleLabel NVARCHAR(50) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.CropCycles') AND name = 'ParentCropCycleId')
BEGIN
    ALTER TABLE agritrack.CropCycles ADD ParentCropCycleId UNIQUEIDENTIFIER NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.CropCycles') AND name = 'RootCropCycleId')
BEGIN
    ALTER TABLE agritrack.CropCycles ADD RootCropCycleId UNIQUEIDENTIFIER NULL;
END
GO

-- Backfill existing rows: every pre-existing cycle is its own root (no lineage yet).
UPDATE agritrack.CropCycles SET RootCropCycleId = Id WHERE RootCropCycleId IS NULL;
GO

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.CropCycles') AND name = 'RootCropCycleId' AND is_nullable = 1)
BEGIN
    ALTER TABLE agritrack.CropCycles ALTER COLUMN RootCropCycleId UNIQUEIDENTIFIER NOT NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_agritrack_CropCycles_Parent')
BEGIN
    ALTER TABLE agritrack.CropCycles
        ADD CONSTRAINT FK_agritrack_CropCycles_Parent FOREIGN KEY (ParentCropCycleId) REFERENCES agritrack.CropCycles (Id);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_agritrack_CropCycles_RootCropCycleId')
BEGIN
    CREATE INDEX IX_agritrack_CropCycles_RootCropCycleId ON agritrack.CropCycles (RootCropCycleId);
END
GO
