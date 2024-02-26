namespace Tools.Cqs.Commands;

public interface ICommandHandler<TCommand>
    where TCommand : ICommandDefinition
{
    ICommandResult Execute(TCommand command);
}
