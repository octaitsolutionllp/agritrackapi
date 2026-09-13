CREATE OR ALTER PROCEDURE agritrack.Sp_CreateCropCycle
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @FieldId UNIQUEIDENTIFIER,
    @CropTypeId UNIQUEIDENTIFIER,
    @SeedVariety NVARCHAR(200) = NULL,
    @SownDate DATE,
    @ExpectedHarvestDate DATE = NULL,
    @CycleLabel NVARCHAR(50) = NULL,
    @ParentCropCycleId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Ratoon/multi-cycle support: a child cycle inherits its parent's root; a fresh planting is its own root.
    DECLARE @RootCropCycleId UNIQUEIDENTIFIER;
    IF @ParentCropCycleId IS NOT NULL
        SELECT @RootCropCycleId = RootCropCycleId FROM agritrack.CropCycles WHERE Id = @ParentCropCycleId AND UserId = @UserId;

    IF @RootCropCycleId IS NULL
        SET @RootCropCycleId = @Id;

    -- Every cycle starts at LandPreparation (मशागत — tilling/preparing the field), the universal
    -- pre-sowing step, before the farmer advances it to Sowing on the actual sowing date.
    INSERT INTO agritrack.CropCycles
        (Id, UserId, FieldId, CropTypeId, SeedVariety, SownDate, ExpectedHarvestDate, CurrentStage, StageStartedAt, Status, CycleLabel, ParentCropCycleId, RootCropCycleId)
    VALUES
        (@Id, @UserId, @FieldId, @CropTypeId, @SeedVariety, @SownDate, @ExpectedHarvestDate, 'LandPreparation', @SownDate, 'Active', @CycleLabel, @ParentCropCycleId, @RootCropCycleId);

    INSERT INTO agritrack.CropStageHistory (Id, CropCycleId, Stage, StartedAt)
    VALUES (NEWID(), @Id, 'LandPreparation', @SownDate);

    EXEC agritrack.Sp_GetCropCycleById @Id = @Id, @UserId = @UserId;
END
GO
