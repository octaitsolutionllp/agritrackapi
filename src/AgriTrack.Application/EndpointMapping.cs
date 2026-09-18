using AgriTrack.Application.Features.Activities.LogActivity;
using AgriTrack.Application.Features.Activities.ListActivities;
using AgriTrack.Application.Features.Activities.DeleteActivity;
using AgriTrack.Application.Features.Admin.CreateUser;
using AgriTrack.Application.Features.Admin.GetUserData;
using AgriTrack.Application.Features.Admin.ListUsers;
using AgriTrack.Application.Features.Admin.ListUsersCreatedByMe;
using AgriTrack.Application.Features.Admin.ResetPassword;
using AgriTrack.Application.Features.Admin.SetRole;
using AgriTrack.Application.Features.Auth.Login;
using AgriTrack.Application.Features.Auth.Register;
using AgriTrack.Application.Features.CropCycles.AdvanceStage;
using AgriTrack.Application.Features.CropCycles.CreateCropCycle;
using AgriTrack.Application.Features.CropCycles.GetCropCycle;
using AgriTrack.Application.Features.CropCycles.GetLineage;
using AgriTrack.Application.Features.CropCycles.ListCropCycles;
using AgriTrack.Application.Features.CropTypes.ListCropTypes;
using AgriTrack.Application.Features.CropTypes.ListMyCropTypes;
using AgriTrack.Application.Features.Expenses.CreateExpense;
using AgriTrack.Application.Features.Expenses.ListExpenses;
using AgriTrack.Application.Features.Expenses.DeleteExpense;
using AgriTrack.Application.Features.Farms.CreateFarm;
using AgriTrack.Application.Features.Farms.ListFarms;
using AgriTrack.Application.Features.Fields.CreateField;
using AgriTrack.Application.Features.Harvests.CreateHarvest;
using AgriTrack.Application.Features.Harvests.ListHarvests;
using AgriTrack.Application.Features.Harvests.DeleteHarvest;
using AgriTrack.Application.Features.Profile.ChangePassword;
using AgriTrack.Application.Features.Profile.CropSelection;
using AgriTrack.Application.Features.Profile.DeleteAccount;
using AgriTrack.Application.Features.Profile.UpdateLanguage;
using AgriTrack.Application.Features.Profile.UpdateProfile;
using AgriTrack.Application.Features.Reports.GetPnlByCropCycle;
using AgriTrack.Application.Features.Reports.GetPnlSummary;
using AgriTrack.Application.Features.Reports.GetReminders;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application;

/// <summary>Single place Program.cs calls to wire up every feature's own endpoint — no controllers, no central routing file per feature.</summary>
public static class EndpointMapping
{
    public static void MapAgriTrackEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapRegisterEndpoint();
        app.MapLoginEndpoint();

        app.MapCreateFarmEndpoint();
        app.MapListFarmsEndpoint();

        app.MapCreateFieldEndpoint();

        app.MapListCropTypesEndpoint();
        app.MapListMyCropTypesEndpoint();

        app.MapCreateCropCycleEndpoint();
        app.MapListCropCyclesEndpoint();
        app.MapGetCropCycleEndpoint();
        app.MapAdvanceStageEndpoint();
        app.MapGetLineageEndpoint();

        app.MapLogActivityEndpoint();
        app.MapListActivitiesEndpoint();
        app.MapDeleteActivityEndpoint();

        app.MapCreateExpenseEndpoint();
        app.MapListExpensesEndpoint();
        app.MapDeleteExpenseEndpoint();

        app.MapCreateHarvestEndpoint();
        app.MapListHarvestsEndpoint();
        app.MapDeleteHarvestEndpoint();

        app.MapGetPnlByCropCycleEndpoint();
        app.MapGetPnlSummaryEndpoint();
        app.MapGetRemindersEndpoint();

        app.MapUpdateLanguageEndpoint();
        app.MapUpdateProfileEndpoint();
        app.MapChangePasswordEndpoint();
        app.MapDeleteAccountEndpoint();
        app.MapGetSelectedCropTypesEndpoint();
        app.MapSetCropTypesEndpoint();

        app.MapListUsersEndpoint();
        app.MapListUsersCreatedByMeEndpoint();
        app.MapGetUserDataEndpoint();
        app.MapAdminCreateUserEndpoint();
        app.MapAdminResetPasswordEndpoint();
        app.MapSetRoleEndpoint();
    }
}
