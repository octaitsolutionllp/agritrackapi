CREATE OR ALTER PROCEDURE agritrack.Sp_UpdateUserProfile
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @EmailOrPhone NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE agritrack.Users
    SET Name = @Name,
        EmailOrPhone = @EmailOrPhone,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @Id;

    SELECT Id, Name, EmailOrPhone, PreferredLanguage, HasCompletedCropSelection, Role, CreatedByUserId, CreatedAt, UpdatedAt
    FROM agritrack.Users
    WHERE Id = @Id;
END
GO
