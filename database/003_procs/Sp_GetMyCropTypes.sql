-- Crop types for the "Start Crop Cycle" picker: only the ones the user has selected, or every
-- crop type if they haven't made a selection yet (HasCompletedCropSelection can still be 0/1 —
-- what matters here is whether any rows exist, e.g. after an explicit "select none, show all").
CREATE OR ALTER PROCEDURE agritrack.Sp_GetMyCropTypes
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM agritrack.UserCropTypes WHERE UserId = @UserId)
    BEGIN
        SELECT ct.Id, ct.Name, ct.StageDurationDaysJson, ct.WaterIntervalDaysJson, ct.PesticideIntervalDaysJson, ct.CreatedAt, ct.UpdatedAt
        FROM agritrack.CropTypes ct
        JOIN agritrack.UserCropTypes uct ON uct.CropTypeId = ct.Id
        WHERE uct.UserId = @UserId
        ORDER BY ct.Name;
    END
    ELSE
    BEGIN
        SELECT Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson, CreatedAt, UpdatedAt
        FROM agritrack.CropTypes
        ORDER BY Name;
    END
END
GO
