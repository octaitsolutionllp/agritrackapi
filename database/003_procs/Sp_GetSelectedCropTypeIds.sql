CREATE OR ALTER PROCEDURE agritrack.Sp_GetSelectedCropTypeIds
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CropTypeId FROM agritrack.UserCropTypes WHERE UserId = @UserId;
END
GO
