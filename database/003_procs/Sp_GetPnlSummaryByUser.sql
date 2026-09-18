CREATE OR ALTER PROCEDURE agritrack.Sp_GetPnlSummaryByUser
    @UserId UNIQUEIDENTIFIER,
    @FarmId UNIQUEIDENTIFIER = NULL,
    @FieldId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Total expense = manually-entered Expenses + any Cost logged alongside an Activity.
    DECLARE @TotalExpense DECIMAL(12,2) =
        ISNULL((
            SELECT SUM(e.Amount)
            FROM agritrack.Expenses e
            JOIN agritrack.CropCycles cc ON cc.Id = e.CropCycleId
            JOIN agritrack.Fields f ON f.Id = cc.FieldId
            WHERE e.UserId = @UserId AND (@FarmId IS NULL OR f.FarmId = @FarmId) AND (@FieldId IS NULL OR f.Id = @FieldId)
        ), 0) +
        ISNULL((
            SELECT SUM(a.Cost)
            FROM agritrack.Activities a
            JOIN agritrack.CropCycles cc ON cc.Id = a.CropCycleId
            JOIN agritrack.Fields f ON f.Id = cc.FieldId
            WHERE a.UserId = @UserId AND a.Cost IS NOT NULL AND (@FarmId IS NULL OR f.FarmId = @FarmId) AND (@FieldId IS NULL OR f.Id = @FieldId)
        ), 0);

    DECLARE @TotalIncome DECIMAL(12,2) = ISNULL((
        SELECT SUM(h.SaleIncome)
        FROM agritrack.Harvests h
        JOIN agritrack.CropCycles cc ON cc.Id = h.CropCycleId
        JOIN agritrack.Fields f ON f.Id = cc.FieldId
        WHERE h.UserId = @UserId AND (@FarmId IS NULL OR f.FarmId = @FarmId) AND (@FieldId IS NULL OR f.Id = @FieldId)
    ), 0);

    SELECT @TotalIncome AS TotalIncome, @TotalExpense AS TotalExpense, (@TotalIncome - @TotalExpense) AS Profit;
END
GO
