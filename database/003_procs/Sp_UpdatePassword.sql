CREATE OR ALTER PROCEDURE agritrack.Sp_UpdatePassword
    @Id UNIQUEIDENTIFIER,
    @PasswordHash NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE agritrack.Users
    SET PasswordHash = @PasswordHash,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @Id;
END
GO
