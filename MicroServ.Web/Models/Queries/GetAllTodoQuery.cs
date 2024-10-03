using MicroServ.Web.Models.Entities;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace MicroServ.Web.Models.Queries
{
    public class GetAllTodoQuery : IQueryDefinition<IEnumerable<Todo>>
    {
    }
}
