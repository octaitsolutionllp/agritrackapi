using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Reports.GetReminders;

public sealed class GetRemindersHandler
{
    private readonly IStoredProcRepository _repository;

    public GetRemindersHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemindersResponse> HandleAsync(Guid userId)
    {
        var rows = await _repository.QueryAsync<ReminderRow>(StoredProcedures.GetDueReminders, new { UserId = userId });
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        var todayList = rows.Where(r => r.DueDate <= today).ToList();
        var upcomingList = rows.Where(r => r.DueDate > today).ToList();

        return new RemindersResponse(todayList, upcomingList);
    }
}
