-- Computes due Water / Pesticide reminders per active crop cycle for a user.
-- DueDate = (last matching activity date, or the date the current stage started if none logged yet)
--           + interval-for-current-stage from agritrack.CropTypes' Water/PesticideIntervalDaysJson.
-- A crop type with no interval entry for the cycle's current stage simply produces no row for that type/stage
-- (e.g. no pesticide reminder during "Sowing" if PesticideIntervalDaysJson has no "Sowing" key).
CREATE OR ALTER PROCEDURE agritrack.Sp_GetDueReminders
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cc.Id AS CropCycleId, f.Name AS FieldName, ct.Name AS CropTypeName, cc.CurrentStage,
        'Water' AS ReminderType,
        DATEADD(DAY, CAST(wj.[value] AS INT), ISNULL(lastWater.LastDate, cc.StageStartedAt)) AS DueDate
    FROM agritrack.CropCycles cc
    JOIN agritrack.Fields f ON f.Id = cc.FieldId
    JOIN agritrack.CropTypes ct ON ct.Id = cc.CropTypeId
    CROSS APPLY OPENJSON(ct.WaterIntervalDaysJson) wj
    OUTER APPLY (
        SELECT MAX(ActivityDate) AS LastDate FROM agritrack.Activities a
        WHERE a.CropCycleId = cc.Id AND a.ActivityType = 'Water'
    ) lastWater
    WHERE cc.UserId = @UserId AND cc.Status = 'Active' AND wj.[key] COLLATE DATABASE_DEFAULT = cc.CurrentStage

    UNION ALL

    SELECT
        cc.Id, f.Name, ct.Name, cc.CurrentStage,
        'Pesticide',
        DATEADD(DAY, CAST(pj.[value] AS INT), ISNULL(lastPest.LastDate, cc.StageStartedAt))
    FROM agritrack.CropCycles cc
    JOIN agritrack.Fields f ON f.Id = cc.FieldId
    JOIN agritrack.CropTypes ct ON ct.Id = cc.CropTypeId
    CROSS APPLY OPENJSON(ct.PesticideIntervalDaysJson) pj
    OUTER APPLY (
        SELECT MAX(ActivityDate) AS LastDate FROM agritrack.Activities a
        WHERE a.CropCycleId = cc.Id AND a.ActivityType = 'Pesticide'
    ) lastPest
    WHERE cc.UserId = @UserId AND cc.Status = 'Active' AND pj.[key] COLLATE DATABASE_DEFAULT = cc.CurrentStage

    ORDER BY DueDate;
END
GO
