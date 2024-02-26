using MicroServ.Web.Models.Entities;
using MicroServ.Web.Models.Queries;
using Tools.Cqs.Queries;

namespace MicroServ.Web.Models.Repositories
{
    public interface ITodoRepository : 
        IQueryHandler<GetAllTodoQuery, IEnumerable<Todo>>
    {
    }
}
