CREATE OR ALTER PROCEDURE agritrack.Sp_SetUserRole
    @UserId UNIQUEIDENTIFIER,
    @Role NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE agritrack.Users
    SET Role = @Role,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @UserId;

    SELECT Id, Name, EmailOrPhone, PreferredLanguage, HasCompletedCropSelection, Role, CreatedByUserId, CreatedAt, UpdatedAt
    FROM agritrack.Users
    WHERE Id = @UserId;
END
GO
