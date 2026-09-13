CREATE OR ALTER PROCEDURE agritrack.Sp_GetPnlByCropCycle
    @CropCycleId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Total expense = manually-entered Expenses + any Cost logged alongside an Activity.
    DECLARE @TotalExpense DECIMAL(12,2) =
        ISNULL((SELECT SUM(Amount) FROM agritrack.Expenses WHERE CropCycleId = @CropCycleId AND UserId = @UserId), 0) +
        ISNULL((SELECT SUM(Cost) FROM agritrack.Activities WHERE CropCycleId = @CropCycleId AND UserId = @UserId AND Cost IS NOT NULL), 0);

    DECLARE @TotalIncome DECIMAL(12,2) = ISNULL((
        SELECT SUM(SaleIncome) FROM agritrack.Harvests WHERE CropCycleId = @CropCycleId AND UserId = @UserId
    ), 0);

    SELECT @TotalIncome AS TotalIncome, @TotalExpense AS TotalExpense, (@TotalIncome - @TotalExpense) AS Profit;
END
GO
