using War.Backend.Legacy.Dispatch;

namespace War.Backend.Legacy;

/// <summary>The recovered 1.4.0 form-POST channel; feature execution belongs to the action graph.</summary>
public static class LegacyEndpoints
{
    public const string CheckPath = "/check.php";
    public const string ActionPath = "/index_09_25_2015.php";

    public static bool IsLegacyPath(PathString path)
    {
        return path.Equals(CheckPath, StringComparison.OrdinalIgnoreCase)
            || path.Equals(ActionPath, StringComparison.OrdinalIgnoreCase);
    }

    public static void MapLegacy(this WebApplication app)
    {
        // Resolve now so duplicate/missing/incorrectly anonymous registrations fail before traffic.
        _ = app.Services.GetRequiredService<LegacyRequestDispatcher>();
        app.MapMethods(CheckPath, ["GET", "POST"], LegacyResponse.Ok).RequireRateLimiting("api");
        app.MapPost(ActionPath, DispatchAsync).RequireRateLimiting("api");
    }

    private static Task<IResult> DispatchAsync(HttpContext context, LegacyRequestDispatcher dispatcher)
    {
        if (!LegacyRequest.TryParse(context.Request, out LegacyRequest? request))
        {
            return Task.FromResult(LegacyResponse.Failure(DatabaseResult.JsonFailure));
        }

        return dispatcher.DispatchAsync(request, context.RequestAborted);
    }
}
