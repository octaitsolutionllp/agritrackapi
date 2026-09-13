CREATE OR ALTER PROCEDURE agritrack.Sp_GetFarmsByUser
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, UserId, Name, TotalAreaAcres, CreatedAt, UpdatedAt
    FROM agritrack.Farms
    WHERE UserId = @UserId
    ORDER BY CreatedAt;
END
GO
