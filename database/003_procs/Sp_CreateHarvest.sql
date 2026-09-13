CREATE OR ALTER PROCEDURE agritrack.Sp_CreateHarvest
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @CropCycleId UNIQUEIDENTIFIER,
    @HarvestDate DATE,
    @YieldQuantity DECIMAL(10,2) = NULL,
    @YieldUnit NVARCHAR(20) = NULL,
    @SaleIncome DECIMAL(10,2) = NULL,
    @Notes NVARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Harvests (Id, UserId, CropCycleId, HarvestDate, YieldQuantity, YieldUnit, SaleIncome, Notes)
    VALUES (@Id, @UserId, @CropCycleId, @HarvestDate, @YieldQuantity, @YieldUnit, @SaleIncome, @Notes);

    SELECT Id, UserId, CropCycleId, HarvestDate, YieldQuantity, YieldUnit, SaleIncome, Notes, CreatedAt, UpdatedAt
    FROM agritrack.Harvests
    WHERE Id = @Id;
END
GO
