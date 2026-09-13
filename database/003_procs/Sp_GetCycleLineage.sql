-- Every cycle sharing the same RootCropCycleId as the given cycle (its whole planting -> ratoon
-- history), each with its own P&L, ordered oldest first. @CropCycleId can be any cycle in the
-- lineage (root or a later Khodva) — the proc resolves the shared root itself.
CREATE OR ALTER PROCEDURE agritrack.Sp_GetCycleLineage
    @CropCycleId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RootCropCycleId UNIQUEIDENTIFIER;
    SELECT @RootCropCycleId = RootCropCycleId FROM agritrack.CropCycles WHERE Id = @CropCycleId AND UserId = @UserId;

    SELECT
        cc.Id, cc.ParentCropCycleId, cc.RootCropCycleId, cc.CycleLabel,
        cc.SownDate, cc.ExpectedHarvestDate, cc.CurrentStage, cc.Status,
        ct.Name AS CropTypeName, f.Name AS FieldName,
        ISNULL(exp.TotalExpense, 0) AS TotalExpense,
        ISNULL(inc.TotalIncome, 0) AS TotalIncome,
        (ISNULL(inc.TotalIncome, 0) - ISNULL(exp.TotalExpense, 0)) AS Profit
    FROM agritrack.CropCycles cc
    JOIN agritrack.CropTypes ct ON ct.Id = cc.CropTypeId
    JOIN agritrack.Fields f ON f.Id = cc.FieldId
    OUTER APPLY (
        SELECT SUM(Amount) AS TotalExpense FROM agritrack.Expenses e WHERE e.CropCycleId = cc.Id
    ) exp
    OUTER APPLY (
        SELECT SUM(SaleIncome) AS TotalIncome FROM agritrack.Harvests h WHERE h.CropCycleId = cc.Id
    ) inc
    WHERE cc.UserId = @UserId AND cc.RootCropCycleId = @RootCropCycleId
    ORDER BY cc.SownDate ASC;
END
GO
