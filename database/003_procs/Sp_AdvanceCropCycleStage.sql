CREATE OR ALTER PROCEDURE agritrack.Sp_AdvanceCropCycleStage
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @StartedAt DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentStage NVARCHAR(30);
    SELECT @CurrentStage = CurrentStage FROM agritrack.CropCycles WHERE Id = @Id AND UserId = @UserId;

    IF @CurrentStage IS NULL
    BEGIN
        RETURN;
    END

    DECLARE @NextStage NVARCHAR(30) = CASE @CurrentStage
        WHEN 'LandPreparation' THEN 'Sowing'
        WHEN 'Sowing'          THEN 'Germination'
        WHEN 'Germination'     THEN 'Vegetative'
        WHEN 'Vegetative'      THEN 'Flowering'
        WHEN 'Flowering'       THEN 'Fruiting'
        WHEN 'Fruiting'        THEN 'Harvested'
        ELSE @CurrentStage
    END;

    UPDATE agritrack.CropCycles
    SET CurrentStage = @NextStage,
        StageStartedAt = @StartedAt,
        Status = CASE WHEN @NextStage = 'Harvested' THEN 'Completed' ELSE Status END,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @Id AND UserId = @UserId;

    INSERT INTO agritrack.CropStageHistory (Id, CropCycleId, Stage, StartedAt)
    VALUES (NEWID(), @Id, @NextStage, @StartedAt);

    EXEC agritrack.Sp_GetCropCycleById @Id = @Id, @UserId = @UserId;
END
GO
