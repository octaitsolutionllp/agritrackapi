using System.Data;
using Dapper;

namespace AgriTrack.Infrastructure;

/// <summary>
/// Dapper 2.1.66 does not auto-map System.DateOnly against SQL Server's DATE type — without this,
/// DateOnly parameters throw "cannot be used as a parameter value" and DateOnly result columns fail
/// to materialize into records. Register once at startup via DapperTypeHandlers.Register().
/// </summary>
public sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.DbType = DbType.Date;
        parameter.Value = value.ToDateTime(TimeOnly.MinValue);
    }

    public override DateOnly Parse(object value) => DateOnly.FromDateTime((DateTime)value);
}

public sealed class NullableDateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly?>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly? value)
    {
        parameter.DbType = DbType.Date;
        parameter.Value = value is null ? DBNull.Value : value.Value.ToDateTime(TimeOnly.MinValue);
    }

    public override DateOnly? Parse(object value) => value is null or DBNull ? null : DateOnly.FromDateTime((DateTime)value);
}

public static class DapperTypeHandlers
{
    public static void Register()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        SqlMapper.AddTypeHandler(new NullableDateOnlyTypeHandler());
    }
}
