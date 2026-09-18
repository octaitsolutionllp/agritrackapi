CREATE OR ALTER PROCEDURE agritrack.Sp_CreateUser
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @EmailOrPhone NVARCHAR(200),
    @PasswordHash NVARCHAR(500),
    @PreferredLanguage NVARCHAR(5),
    @CreatedByUserId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Users (Id, Name, EmailOrPhone, PasswordHash, PreferredLanguage, CreatedByUserId)
    VALUES (@Id, @Name, @EmailOrPhone, @PasswordHash, @PreferredLanguage, @CreatedByUserId);

    SELECT Id, Name, EmailOrPhone, PreferredLanguage, HasCompletedCropSelection, Role, CreatedByUserId, CreatedAt, UpdatedAt
    FROM agritrack.Users
    WHERE Id = @Id;
END
GO
