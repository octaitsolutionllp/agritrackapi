CREATE OR ALTER PROCEDURE agritrack.Sp_GetExpensesByCropCycle
    @CropCycleId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, UserId, CropCycleId, Category, Amount, ExpenseDate, Notes, CreatedAt, UpdatedAt
    FROM agritrack.Expenses
    WHERE CropCycleId = @CropCycleId AND UserId = @UserId
    ORDER BY ExpenseDate DESC, CreatedAt DESC;
END
GO
