namespace War.Backend.Application;

/// <summary>A use-case value or a named failure, without an HTTP context or response writer.</summary>
public sealed class ApplicationResult<T> where T : class
{
    private ApplicationResult(T? value, ApplicationFailure? failure)
    {
        Value = value;
        Failure = failure;
    }

    public T? Value { get; }

    public ApplicationFailure? Failure { get; }

    public static ApplicationResult<T> Success(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new ApplicationResult<T>(value, null);
    }

    public static ApplicationResult<T> Reject(ApplicationFailureKind kind, string code, string message)
    {
        return FromFailure(new ApplicationFailure(kind, code, message));
    }

    public static ApplicationResult<T> FromFailure(ApplicationFailure failure)
    {
        ArgumentNullException.ThrowIfNull(failure);
        return new ApplicationResult<T>(null, failure);
    }
}
