CREATE OR ALTER PROCEDURE agritrack.Sp_DeleteHarvest
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM agritrack.Harvests
    WHERE Id = @Id AND UserId = @UserId;
END
GO
