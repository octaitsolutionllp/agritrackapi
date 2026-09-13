CREATE OR ALTER PROCEDURE agritrack.Sp_UpdateUserLanguage
    @Id UNIQUEIDENTIFIER,
    @PreferredLanguage NVARCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE agritrack.Users
    SET PreferredLanguage = @PreferredLanguage,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @Id;

    SELECT Id, Name, EmailOrPhone, PreferredLanguage, CreatedAt, UpdatedAt
    FROM agritrack.Users
    WHERE Id = @Id;
END
GO
