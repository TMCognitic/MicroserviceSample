namespace Tools.Cqs;

internal abstract class ResultBase
{
    internal ResultBase(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; init; }
    public bool IsFailure { get => !IsSuccess; }
    public string? ErrorMessage { get; init; }
}
