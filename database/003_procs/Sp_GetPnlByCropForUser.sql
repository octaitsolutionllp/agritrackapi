CREATE OR ALTER PROCEDURE agritrack.Sp_GetPnlByCropForUser
    @UserId UNIQUEIDENTIFIER,
    @FarmId UNIQUEIDENTIFIER = NULL,
    @FieldId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cc.Id AS CropCycleId,
        ct.Name AS CropTypeName,
        cc.CycleLabel,
        cc.SownDate,
        (ISNULL(exp.TotalExpense, 0) + ISNULL(act.TotalActivityCost, 0)) AS TotalExpense,
        ISNULL(inc.TotalIncome, 0) AS TotalIncome,
        (ISNULL(inc.TotalIncome, 0) - (ISNULL(exp.TotalExpense, 0) + ISNULL(act.TotalActivityCost, 0))) AS Profit
    FROM agritrack.CropCycles cc
    JOIN agritrack.CropTypes ct ON ct.Id = cc.CropTypeId
    JOIN agritrack.Fields f ON f.Id = cc.FieldId
    OUTER APPLY (
        SELECT SUM(Amount) AS TotalExpense FROM agritrack.Expenses e WHERE e.CropCycleId = cc.Id
    ) exp
    OUTER APPLY (
        -- Cost logged alongside an Activity counts toward expenses too — see Sp_GetPnlByCropCycle.
        SELECT SUM(Cost) AS TotalActivityCost FROM agritrack.Activities a WHERE a.CropCycleId = cc.Id AND a.Cost IS NOT NULL
    ) act
    OUTER APPLY (
        SELECT SUM(SaleIncome) AS TotalIncome FROM agritrack.Harvests h WHERE h.CropCycleId = cc.Id
    ) inc
    WHERE cc.UserId = @UserId AND (@FarmId IS NULL OR f.FarmId = @FarmId) AND (@FieldId IS NULL OR f.Id = @FieldId)
    ORDER BY cc.CreatedAt DESC;
END
GO
