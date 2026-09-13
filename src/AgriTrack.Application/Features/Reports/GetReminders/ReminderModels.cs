namespace AgriTrack.Application.Features.Reports.GetReminders;

public sealed record ReminderRow(Guid CropCycleId, string FieldName, string CropTypeName, string CurrentStage, string ReminderType, DateOnly DueDate);

public sealed record RemindersResponse(IReadOnlyList<ReminderRow> Today, IReadOnlyList<ReminderRow> Upcoming);
