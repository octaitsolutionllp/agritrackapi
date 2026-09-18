-- Admin support: a Role ('User' | 'Admin') gates the new admin endpoints, and CreatedByUserId
-- tracks which admin created a given account (NULL for public self-registration via
-- /api/auth/register) so an admin can see "users I created".
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.Users') AND name = 'Role')
BEGIN
    ALTER TABLE agritrack.Users ADD Role NVARCHAR(20) NOT NULL CONSTRAINT DF_agritrack_Users_Role DEFAULT ('User');
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.Users') AND name = 'CreatedByUserId')
BEGIN
    ALTER TABLE agritrack.Users ADD CreatedByUserId UNIQUEIDENTIFIER NULL
        CONSTRAINT FK_agritrack_Users_CreatedByUserId REFERENCES agritrack.Users(Id);
END
GO
