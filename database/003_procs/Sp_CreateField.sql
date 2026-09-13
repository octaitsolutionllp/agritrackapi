CREATE OR ALTER PROCEDURE agritrack.Sp_CreateField
    @Id UNIQUEIDENTIFIER,
    @FarmId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @AreaAcres DECIMAL(10,2) = NULL,
    @SoilType NVARCHAR(100) = NULL,
    @Location NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Fields (Id, FarmId, UserId, Name, AreaAcres, SoilType, Location)
    VALUES (@Id, @FarmId, @UserId, @Name, @AreaAcres, @SoilType, @Location);

    SELECT Id, FarmId, UserId, Name, AreaAcres, SoilType, Location, CreatedAt, UpdatedAt
    FROM agritrack.Fields
    WHERE Id = @Id;
END
GO
