using System.Data.Common;
using MicroServ.Api.Models.Entities;
using MicroServ.Api.Models.Queries;
using MicroServ.Api.Models.Repositories;
using BStorm.Tools.Database;
using BStorm.Tools.CommandQuerySeparation.Queries;
using MicroServ.Api.Models.Mappers;

namespace MicroServ.Api.Models.Services;

public class ITodoService(DbConnection _dbConnection) : ITodoRepository
{
    public IQueryResult<IEnumerable<Todo>> Execute(GetAllTodoQuery query)
    {
        try
        {
            _dbConnection.Open();
            IEnumerable<Todo> items = _dbConnection.ExecuteReader("Select Id, Title FROM Todo;", dr => dr.ToTodo()).ToList();
            return IQueryResult<IEnumerable<Todo>>.Success(items);
        }
        catch (Exception ex)
        {
            return IQueryResult<IEnumerable<Todo>>.Failure(ex.Message, ex);
        }
    }
}