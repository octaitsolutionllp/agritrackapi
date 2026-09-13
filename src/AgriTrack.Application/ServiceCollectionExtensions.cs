using AgriTrack.Application.Common;
using AgriTrack.Application.Features.Activities.LogActivity;
using AgriTrack.Application.Features.Activities.ListActivities;
using AgriTrack.Application.Features.Activities.DeleteActivity;
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
using AgriTrack.Application.Features.Reports.GetPnlByCropCycle;
using AgriTrack.Application.Features.Reports.GetPnlSummary;
using AgriTrack.Application.Features.Reports.GetReminders;
using Microsoft.Extensions.DependencyInjection;

namespace AgriTrack.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAgriTrackApplication(this IServiceCollection services)
    {
        services.AddScoped<JwtTokenGenerator>();

        services.AddScoped<RegisterHandler>();
        services.AddScoped<LoginHandler>();

        services.AddScoped<CreateFarmHandler>();
        services.AddScoped<ListFarmsHandler>();

        services.AddScoped<CreateFieldHandler>();

        services.AddScoped<ListCropTypesHandler>();
        services.AddScoped<ListMyCropTypesHandler>();

        services.AddScoped<CreateCropCycleHandler>();
        services.AddScoped<ListCropCyclesHandler>();
        services.AddScoped<GetCropCycleHandler>();
        services.AddScoped<AdvanceStageHandler>();
        services.AddScoped<GetLineageHandler>();

        services.AddScoped<LogActivityHandler>();
        services.AddScoped<ListActivitiesHandler>();
        services.AddScoped<DeleteActivityHandler>();

        services.AddScoped<CreateExpenseHandler>();
        services.AddScoped<ListExpensesHandler>();
        services.AddScoped<DeleteExpenseHandler>();

        services.AddScoped<CreateHarvestHandler>();
        services.AddScoped<ListHarvestsHandler>();
        services.AddScoped<DeleteHarvestHandler>();

        services.AddScoped<GetPnlByCropCycleHandler>();
        services.AddScoped<GetPnlSummaryHandler>();
        services.AddScoped<GetRemindersHandler>();

        services.AddScoped<UpdateLanguageHandler>();
        services.AddScoped<ChangePasswordHandler>();
        services.AddScoped<DeleteAccountHandler>();
        services.AddScoped<GetSelectedCropTypesHandler>();
        services.AddScoped<SetCropTypesHandler>();

        return services;
    }
}
