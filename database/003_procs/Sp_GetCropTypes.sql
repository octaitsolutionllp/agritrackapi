CREATE OR ALTER PROCEDURE agritrack.Sp_GetCropTypes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson, CreatedAt, UpdatedAt
    FROM agritrack.CropTypes
    ORDER BY Name;
END
GO
