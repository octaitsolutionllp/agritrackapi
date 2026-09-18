-- Admin-only listing of every user, with the creating admin's name (if any) joined in so the
-- UI doesn't need a second round trip per row.
CREATE OR ALTER PROCEDURE agritrack.Sp_GetAllUsers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.Id, u.Name, u.EmailOrPhone, u.PreferredLanguage, u.HasCompletedCropSelection,
        u.Role, u.CreatedByUserId, creator.Name AS CreatedByName,
        u.CreatedAt, u.UpdatedAt
    FROM agritrack.Users u
    LEFT JOIN agritrack.Users creator ON creator.Id = u.CreatedByUserId
    ORDER BY u.CreatedAt DESC;
END
GO
