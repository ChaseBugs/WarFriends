using Google.Protobuf;
using War.Backend.Hosting.Configuration;
using War.Backend.Legacy;
using static War.Backend.HttpProtocol;

namespace War.Backend.Transport.Http;

/// <summary>Preserves the API failure envelope and the explicit recovered-client HTTP exception.</summary>
public sealed class BackendRequestMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _environment;
    private readonly bool _allowLegacyHttp;
    private readonly ILogger<BackendRequestMiddleware> _logger;

    public BackendRequestMiddleware(RequestDelegate next, IHostEnvironment environment,
        BackendDeploymentOptions deployment, ILogger<BackendRequestMiddleware> logger)
    {
        _next = next;
        _environment = environment;
        _allowLegacyHttp = deployment.Legacy.AllowInsecureHttp;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await ExecuteAsync(context);
        }
        catch (InvalidProtocolBufferException)
        {
            await Error(400, "invalid_protobuf", "Invalid protobuf body.").ExecuteAsync(context);
        }
        catch (BadHttpRequestException error)
        {
            if (error.StatusCode == StatusCodes.Status413PayloadTooLarge &&
                context.Request.Protocol.StartsWith("HTTP/1.", StringComparison.Ordinal))
            {
                // Kestrel may reject draining an unread oversized body after this response.
                // Advertise closure before headers are sent so a following request cannot reuse it.
                context.Response.Headers.Connection = "close";
            }
            await Error(error.StatusCode, "invalid_request", "Request rejected.").ExecuteAsync(context);
        }
        catch (Exception error) when (error is not OperationCanceledException)
        {
            _logger.LogError("Request failed: {ErrorType}", error.GetType().Name);
            await Error(503, "unavailable", "Service unavailable.").ExecuteAsync(context);
        }
    }

    private async Task ExecuteAsync(HttpContext context)
    {
        bool exempt = context.Request.Path.StartsWithSegments("/health") ||
            (_allowLegacyHttp && LegacyEndpoints.IsLegacyPath(context.Request.Path));
        if (!_environment.IsDevelopment() && !context.Request.IsHttps && !exempt)
        {
            await Error(400, "https_required", "HTTPS is required.").ExecuteAsync(context);
            return;
        }
        await _next(context);
    }
}
