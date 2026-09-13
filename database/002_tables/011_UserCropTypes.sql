-- Which crop types a user has told the app they grow — the "Start Crop Cycle" picker shows only
-- these (falling back to every crop type if the user hasn't selected any yet).
IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'UserCropTypes')
BEGIN
    CREATE TABLE agritrack.UserCropTypes
    (
        UserId      UNIQUEIDENTIFIER NOT NULL,
        CropTypeId  UNIQUEIDENTIFIER NOT NULL,
        CreatedAt   DATETIME2        NOT NULL CONSTRAINT DF_agritrack_UserCropTypes_CreatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_agritrack_UserCropTypes PRIMARY KEY (UserId, CropTypeId),
        CONSTRAINT FK_agritrack_UserCropTypes_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id),
        CONSTRAINT FK_agritrack_UserCropTypes_CropTypes FOREIGN KEY (CropTypeId) REFERENCES agritrack.CropTypes (Id)
    );
END
GO

-- Tracks whether the user has been through (or explicitly skipped) the crop-selection onboarding
-- step, independent of whether they ended up selecting zero crops (which just means "show all").
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('agritrack.Users') AND name = 'HasCompletedCropSelection')
BEGIN
    ALTER TABLE agritrack.Users ADD HasCompletedCropSelection BIT NOT NULL CONSTRAINT DF_agritrack_Users_HasCompletedCropSelection DEFAULT (0);
END
GO
