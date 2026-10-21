namespace War.Backend.Application;

public enum ApplicationFailureKind
{
    InvalidRequest,
    Unauthorized,
    Missing,
    Conflict,
    Unavailable
}
