namespace Tools.Cqs.Commands;

public interface ICommandResult
{
    static ICommandResult Success()
    {
        return new CommandResult(true);
    }

    static ICommandResult Failure(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage, nameof(errorMessage));
        if(errorMessage.Trim() is "")
            throw new ArgumentException("En cas d'échec, veuillez indiquer la raison");

        return new CommandResult(false, errorMessage);
    }

    bool IsSuccess { get; }
    bool IsFailure { get; }
    string? ErrorMessage { get; }
}
