CREATE OR ALTER PROCEDURE agritrack.Sp_GetUserByEmailOrPhone
    @EmailOrPhone NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, EmailOrPhone, PasswordHash, PreferredLanguage, HasCompletedCropSelection, Role, CreatedByUserId, CreatedAt, UpdatedAt
    FROM agritrack.Users
    WHERE EmailOrPhone = @EmailOrPhone;
END
GO
