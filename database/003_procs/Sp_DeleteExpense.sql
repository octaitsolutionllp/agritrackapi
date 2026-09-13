CREATE OR ALTER PROCEDURE agritrack.Sp_DeleteExpense
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM agritrack.Expenses
    WHERE Id = @Id AND UserId = @UserId;
END
GO
