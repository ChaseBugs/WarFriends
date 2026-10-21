namespace War.Backend.Legacy.State;

/// <summary>Maps refused authority to legacy maintenance without acknowledging a mutation.</summary>
public sealed class LegacyAuthorityFailureMiddleware(
    RequestDelegate next, ILogger<LegacyAuthorityFailureMiddleware> logger)
{
    /// <summary>Keeps durable authority failures out of both success callbacks and input-error receipts.</summary>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception) when ((exception is InvalidDataException or FormatException) &&
            LegacyEndpoints.IsLegacyPath(context.Request.Path) && !context.Response.HasStarted)
        {
            logger.LogError(exception, "Refused invalid stored legacy authority.");
            context.Response.Clear();
            await LegacyResponse.Failure(DatabaseResult.ServerMaintenance).ExecuteAsync(context);
        }
    }
}
