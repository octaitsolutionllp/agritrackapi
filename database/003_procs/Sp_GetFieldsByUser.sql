CREATE OR ALTER PROCEDURE agritrack.Sp_GetFieldsByUser
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, FarmId, UserId, Name, AreaAcres, SoilType, Location, CreatedAt, UpdatedAt
    FROM agritrack.Fields
    WHERE UserId = @UserId
    ORDER BY CreatedAt;
END
GO
