CREATE OR ALTER PROCEDURE agritrack.Sp_GetHarvestsByCropCycle
    @CropCycleId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, UserId, CropCycleId, HarvestDate, YieldQuantity, YieldUnit, SaleIncome, Notes, CreatedAt, UpdatedAt
    FROM agritrack.Harvests
    WHERE CropCycleId = @CropCycleId AND UserId = @UserId
    ORDER BY HarvestDate DESC, CreatedAt DESC;
END
GO
