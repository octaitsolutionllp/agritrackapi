CREATE OR ALTER PROCEDURE agritrack.Sp_GetActivitiesByCropCycle
    @CropCycleId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, UserId, CropCycleId, ActivityType, ActivityDate, Cost, Notes, CreatedAt, UpdatedAt
    FROM agritrack.Activities
    WHERE CropCycleId = @CropCycleId AND UserId = @UserId
    ORDER BY ActivityDate DESC, CreatedAt DESC;
END
GO
