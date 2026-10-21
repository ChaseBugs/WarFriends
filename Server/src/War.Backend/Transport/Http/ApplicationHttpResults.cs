using Google.Protobuf;
using War.Backend.Application;
using static War.Backend.HttpProtocol;

namespace War.Backend.Transport.Http;

public static class ApplicationHttpResults
{
    public static IResult ToHttp<T>(this ApplicationResult<T> result) where T : class, IMessage
    {
        if (result.Value != null)
        {
            return Proto(result.Value);
        }

        ApplicationFailure failure = result.Failure!;
        int status = failure.Kind switch
        {
            ApplicationFailureKind.InvalidRequest => StatusCodes.Status400BadRequest,
            ApplicationFailureKind.Unauthorized => StatusCodes.Status401Unauthorized,
            ApplicationFailureKind.Missing => StatusCodes.Status404NotFound,
            ApplicationFailureKind.Conflict => StatusCodes.Status409Conflict,
            ApplicationFailureKind.Unavailable => StatusCodes.Status503ServiceUnavailable,
            _ => throw new InvalidOperationException("Unknown application failure.")
        };
        return Error(status, failure.Code, failure.Message);
    }

    public static IResult AuthenticationRequired()
    {
        return Error(StatusCodes.Status401Unauthorized, "unauthorized", "Authentication required.");
    }
}
