-- Permanently deletes a user and every row they own, in FK-safe child-first order, in one
-- transaction (all-or-nothing). Irreversible — the API layer must confirm intent before calling this.
CREATE OR ALTER PROCEDURE agritrack.Sp_DeleteUserAccount
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DELETE csh
    FROM agritrack.CropStageHistory csh
    JOIN agritrack.CropCycles cc ON cc.Id = csh.CropCycleId
    WHERE cc.UserId = @UserId;

    DELETE FROM agritrack.Activities WHERE UserId = @UserId;
    DELETE FROM agritrack.Expenses WHERE UserId = @UserId;
    DELETE FROM agritrack.Harvests WHERE UserId = @UserId;
    DELETE FROM agritrack.CropCycles WHERE UserId = @UserId;
    DELETE FROM agritrack.Fields WHERE UserId = @UserId;
    DELETE FROM agritrack.Farms WHERE UserId = @UserId;
    DELETE FROM agritrack.UserCropTypes WHERE UserId = @UserId;
    DELETE FROM agritrack.Users WHERE Id = @UserId;

    COMMIT TRANSACTION;
END
GO
