CREATE OR ALTER PROCEDURE agritrack.Sp_GetUsersCreatedByAdmin
    @AdminUserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.Id, u.Name, u.EmailOrPhone, u.PreferredLanguage, u.HasCompletedCropSelection,
        u.Role, u.CreatedByUserId, u.CreatedAt, u.UpdatedAt
    FROM agritrack.Users u
    WHERE u.CreatedByUserId = @AdminUserId
    ORDER BY u.CreatedAt DESC;
END
GO
