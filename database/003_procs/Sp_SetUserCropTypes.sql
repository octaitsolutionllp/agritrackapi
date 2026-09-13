-- Replaces the user's selected crop types with the given set (a JSON array of GUID strings,
-- e.g. '["...","..."]' — an empty array '[]' is valid and means "show all crop types").
-- Always marks the onboarding step complete, whether they picked some crops or explicitly none.
CREATE OR ALTER PROCEDURE agritrack.Sp_SetUserCropTypes
    @UserId UNIQUEIDENTIFIER,
    @CropTypeIdsJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DELETE FROM agritrack.UserCropTypes WHERE UserId = @UserId;

    INSERT INTO agritrack.UserCropTypes (UserId, CropTypeId)
    SELECT @UserId, CAST(value AS UNIQUEIDENTIFIER)
    FROM OPENJSON(@CropTypeIdsJson);

    UPDATE agritrack.Users SET HasCompletedCropSelection = 1, UpdatedAt = SYSUTCDATETIME() WHERE Id = @UserId;

    COMMIT TRANSACTION;

    EXEC agritrack.Sp_GetSelectedCropTypeIds @UserId = @UserId;
END
GO
