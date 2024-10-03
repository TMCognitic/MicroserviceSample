using MicroServ.Web.Models.Entities;
using MicroServ.Web.Models.Queries;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace MicroServ.Web.Models.Repositories
{
    public interface ITodoRepository : 
        IQueryHandler<GetAllTodoQuery, IEnumerable<Todo>>
    {
    }
}
