CREATE OR ALTER PROCEDURE agritrack.Sp_CreateUser
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @EmailOrPhone NVARCHAR(200),
    @PasswordHash NVARCHAR(500),
    @PreferredLanguage NVARCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO agritrack.Users (Id, Name, EmailOrPhone, PasswordHash, PreferredLanguage)
    VALUES (@Id, @Name, @EmailOrPhone, @PasswordHash, @PreferredLanguage);

    SELECT Id, Name, EmailOrPhone, PreferredLanguage, HasCompletedCropSelection, CreatedAt
    FROM agritrack.Users
    WHERE Id = @Id;
END
GO
