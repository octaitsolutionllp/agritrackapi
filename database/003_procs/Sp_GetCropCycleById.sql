CREATE OR ALTER PROCEDURE agritrack.Sp_GetCropCycleById
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cc.Id, cc.UserId, cc.FieldId, f.Name AS FieldName, cc.CropTypeId, ct.Name AS CropTypeName,
        cc.SeedVariety, cc.SownDate, cc.ExpectedHarvestDate, cc.CurrentStage, cc.StageStartedAt, cc.Status,
        cc.CreatedAt, cc.UpdatedAt,
        cc.CycleLabel, cc.ParentCropCycleId, cc.RootCropCycleId,
        ct.StageDurationDaysJson, ct.WaterIntervalDaysJson, ct.PesticideIntervalDaysJson
    FROM agritrack.CropCycles cc
    JOIN agritrack.Fields f ON f.Id = cc.FieldId
    JOIN agritrack.CropTypes ct ON ct.Id = cc.CropTypeId
    WHERE cc.Id = @Id AND cc.UserId = @UserId;
END
GO
