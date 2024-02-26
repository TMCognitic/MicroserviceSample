using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Tools.Connections;

public static class DbConnectionExtensions
{
    public static int ExecuteNonQuery(this DbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
    {
        EnsureValidConnection(dbConnection);
        using DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters);
        
        return dbCommand.ExecuteNonQuery();
    }

    public static IEnumerable<TResult> ExecuteReader<TResult>(this DbConnection dbConnection, string query, Func<DbDataReader, TResult> mapper, bool isStoredProcedure = false, object? parameters = null)
    {
        EnsureValidConnection(dbConnection);
        ArgumentNullException.ThrowIfNull(mapper);

        using DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters);
        using DbDataReader dbDataReader = dbCommand.ExecuteReader();

        while(dbDataReader.Read())
            yield return mapper(dbDataReader);
    }

    public static object? ExecuteScalar(this DbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
    {
        EnsureValidConnection(dbConnection);
        using DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters);
        
        object? result = dbCommand.ExecuteScalar();
        return result is DBNull ? null : result;
    }

    private static DbCommand CreateCommand(DbConnection dbConnection, string query, bool isStoredProcedure, object? parameters)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(query);

        DbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;

        if(isStoredProcedure)
            dbCommand.CommandType = CommandType.StoredProcedure;

        Type? type = parameters?.GetType();

        if (type is not null)
        {
            foreach(PropertyInfo propertyInfo in type.GetProperties().Where(p => p.CanRead))
            {
                DbParameter dbParameter = dbCommand.CreateParameter();
                dbParameter.ParameterName = propertyInfo.Name;
                dbParameter.Value = propertyInfo.GetValue(parameters, null) ?? DBNull.Value;
                dbCommand.Parameters.Add(dbParameter);
            }
        }

        return dbCommand;
    }

    private static void EnsureValidConnection(DbConnection dbConnection)
    {
        ArgumentNullException.ThrowIfNull(dbConnection);
        if(dbConnection.State != ConnectionState.Open)
            throw new InvalidOperationException();
    }
}
