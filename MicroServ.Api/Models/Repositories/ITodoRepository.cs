using MicroServ.Api.Models.Entities;
using MicroServ.Api.Models.Queries;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace MicroServ.Api.Models.Repositories;

public interface ITodoRepository :
    IQueryHandler<GetAllTodoQuery, IEnumerable<Todo>>
{    
}