namespace Tools.Cqs.Queries;

internal class QueryResult<T> : ResultBase, IQueryResult<T>
{
    private readonly T? _value;

    public QueryResult(bool isSuccess, T? value, string? errorMessage = null)
        : base(isSuccess, errorMessage)
    {
        _value = value;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public T? Value 
    { 
        get
        {
            if (IsFailure)
                throw new InvalidOperationException("Il n'y a pas de résultat lorsque la requête a échouée.");

            return _value;
        }
    }
}
