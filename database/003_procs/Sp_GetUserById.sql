CREATE OR ALTER PROCEDURE agritrack.Sp_GetUserById
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Includes PasswordHash: only ever consumed server-side (e.g. to verify the current
    -- password before a change) — handlers must not put it on a response DTO.
    SELECT Id, Name, EmailOrPhone, PasswordHash, PreferredLanguage, HasCompletedCropSelection, CreatedAt, UpdatedAt
    FROM agritrack.Users
    WHERE Id = @Id;
END
GO
