CREATE OR ALTER PROCEDURE agritrack.Sp_DeleteActivity
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM agritrack.Activities
    WHERE Id = @Id AND UserId = @UserId;
END
GO
