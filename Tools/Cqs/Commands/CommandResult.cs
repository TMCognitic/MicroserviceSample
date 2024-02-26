namespace Tools.Cqs.Commands;

internal class CommandResult : ResultBase, ICommandResult
{
    internal CommandResult(bool isSuccess, string? errorMessage = null)
        : base(isSuccess, errorMessage)
    {
    }
}
