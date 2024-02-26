namespace Tools.Cqs.Queries;

public interface IQueryHandler<TQuery, T>
    where TQuery : class, IQueryDefinition<T>
{
    IQueryResult<T> Execute(TQuery query);
}
