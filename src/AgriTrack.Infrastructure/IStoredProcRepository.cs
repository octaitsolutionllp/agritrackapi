namespace AgriTrack.Infrastructure;

/// <summary>
/// Every data access call in AgriTrack goes through this — no EF, no inline SQL,
/// always a stored procedure under the agritrack schema (see StoredProcedures.cs for names).
/// </summary>
public interface IStoredProcRepository
{
    Task<IEnumerable<T>> QueryAsync<T>(string storedProcedure, object? parameters = null);
    Task<T?> QuerySingleOrDefaultAsync<T>(string storedProcedure, object? parameters = null);
    Task ExecuteAsync(string storedProcedure, object? parameters = null);
}
