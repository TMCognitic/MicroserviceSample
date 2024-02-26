using MicroServ.Api.Models.Entities;
using MicroServ.Api.Models.Queries;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace MicroServ.Api.Models.Repositories;

public interface ITodoRepository :
    IQueryHandler<GetAllTodoQuery, IEnumerable<Todo>>
{    
}