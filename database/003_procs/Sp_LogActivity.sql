CREATE OR ALTER PROCEDURE agritrack.Sp_LogActivity
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @CropCycleId UNIQUEIDENTIFIER,
    @ActivityType NVARCHAR(30),
    @ActivityDate DATE,
    @Cost DECIMAL(10,2) = NULL,
    @Notes NVARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Activities (Id, UserId, CropCycleId, ActivityType, ActivityDate, Cost, Notes)
    VALUES (@Id, @UserId, @CropCycleId, @ActivityType, @ActivityDate, @Cost, @Notes);

    SELECT Id, UserId, CropCycleId, ActivityType, ActivityDate, Cost, Notes, CreatedAt, UpdatedAt
    FROM agritrack.Activities
    WHERE Id = @Id;
END
GO
