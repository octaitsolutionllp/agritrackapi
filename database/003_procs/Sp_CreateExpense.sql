CREATE OR ALTER PROCEDURE agritrack.Sp_CreateExpense
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @CropCycleId UNIQUEIDENTIFIER,
    @Category NVARCHAR(30),
    @Amount DECIMAL(10,2),
    @ExpenseDate DATE,
    @Notes NVARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Expenses (Id, UserId, CropCycleId, Category, Amount, ExpenseDate, Notes)
    VALUES (@Id, @UserId, @CropCycleId, @Category, @Amount, @ExpenseDate, @Notes);

    SELECT Id, UserId, CropCycleId, Category, Amount, ExpenseDate, Notes, CreatedAt, UpdatedAt
    FROM agritrack.Expenses
    WHERE Id = @Id;
END
GO
