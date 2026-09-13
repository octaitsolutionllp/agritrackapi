CREATE OR ALTER PROCEDURE agritrack.Sp_CreateFarm
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @TotalAreaAcres DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Farms (Id, UserId, Name, TotalAreaAcres)
    VALUES (@Id, @UserId, @Name, @TotalAreaAcres);

    SELECT Id, UserId, Name, TotalAreaAcres, CreatedAt, UpdatedAt
    FROM agritrack.Farms
    WHERE Id = @Id;
END
GO
