namespace AgriTrack.Infrastructure;

/// <summary>Schema-qualified stored procedure names — keeps call sites free of magic strings.</summary>
public static class StoredProcedures
{
    public const string CreateUser = "agritrack.Sp_CreateUser";
    public const string GetUserByEmailOrPhone = "agritrack.Sp_GetUserByEmailOrPhone";
    public const string GetUserById = "agritrack.Sp_GetUserById";
    public const string UpdateUserLanguage = "agritrack.Sp_UpdateUserLanguage";
    public const string UpdatePassword = "agritrack.Sp_UpdatePassword";
    public const string DeleteUserAccount = "agritrack.Sp_DeleteUserAccount";

    public const string CreateFarm = "agritrack.Sp_CreateFarm";
    public const string GetFarmsByUser = "agritrack.Sp_GetFarmsByUser";

    public const string CreateField = "agritrack.Sp_CreateField";
    public const string GetFieldsByUser = "agritrack.Sp_GetFieldsByUser";

    public const string GetCropTypes = "agritrack.Sp_GetCropTypes";
    public const string GetMyCropTypes = "agritrack.Sp_GetMyCropTypes";
    public const string GetSelectedCropTypeIds = "agritrack.Sp_GetSelectedCropTypeIds";
    public const string SetUserCropTypes = "agritrack.Sp_SetUserCropTypes";

    public const string CreateCropCycle = "agritrack.Sp_CreateCropCycle";
    public const string GetCropCyclesByUser = "agritrack.Sp_GetCropCyclesByUser";
    public const string GetCropCycleById = "agritrack.Sp_GetCropCycleById";
    public const string AdvanceCropCycleStage = "agritrack.Sp_AdvanceCropCycleStage";
    public const string GetCycleLineage = "agritrack.Sp_GetCycleLineage";

    public const string LogActivity = "agritrack.Sp_LogActivity";
    public const string GetActivitiesByCropCycle = "agritrack.Sp_GetActivitiesByCropCycle";
    public const string DeleteActivity = "agritrack.Sp_DeleteActivity";

    public const string CreateExpense = "agritrack.Sp_CreateExpense";
    public const string GetExpensesByCropCycle = "agritrack.Sp_GetExpensesByCropCycle";
    public const string DeleteExpense = "agritrack.Sp_DeleteExpense";

    public const string CreateHarvest = "agritrack.Sp_CreateHarvest";
    public const string GetHarvestsByCropCycle = "agritrack.Sp_GetHarvestsByCropCycle";
    public const string DeleteHarvest = "agritrack.Sp_DeleteHarvest";

    public const string GetPnlByCropCycle = "agritrack.Sp_GetPnlByCropCycle";
    public const string GetExpenseCategoryBreakdown = "agritrack.Sp_GetExpenseCategoryBreakdown";
    public const string GetPnlSummaryByUser = "agritrack.Sp_GetPnlSummaryByUser";
    public const string GetPnlByCropForUser = "agritrack.Sp_GetPnlByCropForUser";

    public const string GetDueReminders = "agritrack.Sp_GetDueReminders";
}
