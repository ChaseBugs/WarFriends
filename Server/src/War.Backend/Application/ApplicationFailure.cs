namespace War.Backend.Application;

public sealed record ApplicationFailure(ApplicationFailureKind Kind, string Code, string Message);
