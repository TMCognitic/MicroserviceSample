namespace Tools.Cqs.Queries;

public interface IQueryResult<T>
{
    /// <summary>
    /// Génère un réultat valide avec les données
    /// </summary>
    /// <param name="result">Données à encapsuler</param>
    /// <returns></returns>
    static IQueryResult<T> Success(T result)
    {
        return new QueryResult<T>(true, result);
    }

    /// <summary>
    /// Retourne un résultat en erreur
    /// </summary>
    /// <param name="errorMessage">Message d'erreur</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    static IQueryResult<T> Failure(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage, nameof(errorMessage));
        if(errorMessage.Trim() is "")
            throw new ArgumentException("En cas d'échec, veuillez indiquer la raison");

        return new QueryResult<T>(false, default, errorMessage);
    }

    bool IsSuccess { get; }
    bool IsFailure { get; }
    string? ErrorMessage { get; }
    T? Value { get; }
}
