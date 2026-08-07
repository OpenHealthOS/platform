namespace OpenHealthOS.SharedKernel.Results;

public sealed class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    private Result(bool success)
    {
        IsSuccess = success;
    }

    public static Result Success() => new(true);

    public static Result Failure() => new(false);
}