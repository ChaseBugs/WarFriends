using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging.Abstractions;
using War.Backend.Hosting;
using War.Backend.Hosting.Configuration;
using War.Backend.Transport.Http;
using War.Battle.Tests.Startup;

namespace War.Battle.Tests.Http;

internal static class BackendHttpBoundaryTests
{
    private const int BodyLimit = 2048;
    private const long Now = 100;
    private const string Domain = "war/result/accept/v1/";

    internal static async Task<int> RunAsync()
    {
        await CheckStreamingLimitAsync();
        await CheckDeclaredLimitAsync();
        CheckMacAndClock();
        CheckRouteInventory();
        await CheckOversizeConnectionPolicyAsync();
        return 5;
    }

    private static async Task CheckStreamingLimitAsync()
    {
        await using var stream = new ObservedStream(new byte[BodyLimit * 4]);
        var context = new DefaultHttpContext();
        context.Request.Body = stream;
        try
        {
            await BoundedHttpBody.ReadAsync(context, BodyLimit);
            throw new InvalidOperationException("An unknown-length body exceeded its budget.");
        }
        catch (BadHttpRequestException failure) when (failure.StatusCode == StatusCodes.Status413PayloadTooLarge)
        {
            Require(stream.BytesRead == BodyLimit + 1, "The body reader consumed more than one excess byte.");
        }

        context.Request.Body = new MemoryStream(new byte[BodyLimit]);
        byte[] atLimit = await BoundedHttpBody.ReadAsync(context, BodyLimit);
        Require(atLimit.Length == BodyLimit, "The exact body boundary was refused.");
    }

    private static async Task CheckDeclaredLimitAsync()
    {
        await using var stream = new ObservedStream(new byte[BodyLimit + 1]);
        var context = new DefaultHttpContext();
        context.Request.Body = stream;
        context.Request.ContentLength = BodyLimit + 1;
        try
        {
            await BoundedHttpBody.ReadAsync(context, BodyLimit);
            throw new InvalidOperationException("An oversized declared body was accepted.");
        }
        catch (BadHttpRequestException failure) when (failure.StatusCode == StatusCodes.Status413PayloadTooLarge)
        {
            Require(stream.BytesRead == 0, "Declared oversize consumed input before refusal.");
        }
    }

    private static void CheckMacAndClock()
    {
        BackendBattleOptions options =
            BackendBattleOptions.FromConfiguration(BackendStartupPolicyTests.CreateSettings());
        var authentication = new BattleControlAuthenticator(options, new FixedTime());
        byte[] key = options.Keys.ControlKey!;
        byte[] body = Encoding.UTF8.GetBytes("{}");
        foreach (long timestamp in new[] { Now - 30, Now, Now + 30 })
        {
            DefaultHttpContext context = SignedContext(key, body, timestamp.ToString());
            Require(authentication.IsAuthorized(context, body, Domain), "A supported signature clock was rejected.");
            Require(!authentication.IsAuthorized(context, body, "wrong-domain/"), "MAC domains were interchangeable.");
            Require(!authentication.IsAuthorized(context, [1], Domain), "MAC ignored payload bytes.");
        }
        foreach (string timestamp in new[] { "69", "131", "-1", "NaN", "", " 100", "253402300800" })
        {
            Require(!authentication.IsAuthorized(SignedContext(key, body, timestamp), body, Domain),
                "Invalid or expired signature time was accepted.");
        }
        DefaultHttpContext malformed = SignedContext(key, body, Now.ToString());
        malformed.Request.Headers["X-War-Control-Mac"] = new string('z', 64);
        Require(!authentication.IsAuthorized(malformed, body, Domain), "Malformed MAC encoding was accepted.");
    }

    private static DefaultHttpContext SignedContext(byte[] key, byte[] body, string timestamp)
    {
        var context = new DefaultHttpContext();
        byte[] prefix = Encoding.UTF8.GetBytes(Domain + timestamp + "\n");
        byte[] signed = prefix.Concat(body).ToArray();
        context.Request.Headers["X-War-Control-Time"] = timestamp;
        context.Request.Headers["X-War-Control-Mac"] = Convert.ToHexString(HMACSHA256.HashData(key, signed));
        return context;
    }

    private static void CheckRouteInventory()
    {
        BackendDeploymentOptions options =
            BackendDeploymentOptions.FromConfiguration(BackendStartupPolicyTests.CreateSettings());
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddBackendServices(options);
        using WebApplication app = builder.Build();
        app.MapModernBackendEndpoints();
        RouteEndpoint[] endpoints = ((IEndpointRouteBuilder)app).DataSources
            .SelectMany(source => source.Endpoints).OfType<RouteEndpoint>().ToArray();
        string[] expected =
        [
            "GET /health/live", "GET /health/ready", "POST /v1/accounts/register", "POST /v1/accounts/login",
            "GET /v1/player", "POST /v1/network/connect", "POST /v1/battle/grant", "POST /v1/battle/reconnect",
            "POST /v1/battle/queue/attempt", "POST /v1/battle/queue/join", "POST /v1/battle/queue/cancel",
            "POST /v1/battle/rematch/read", "POST /v1/battle/rematch/accept", "POST /v1/battle/rematch/cancel",
            "POST /v1/battle/rematch/allocate", "POST /v1/battle/rematch/cancel-allocation",
            "POST /internal/battle/matches/provision", "POST /internal/battle/results/accept",
            "POST /internal/battle/allocations/read"
        ];
        string[] actual = endpoints.SelectMany(endpoint => endpoint.Metadata.GetRequiredMetadata<HttpMethodMetadata>()
            .HttpMethods.Select(method => method + " " + endpoint.RoutePattern.RawText)).ToArray();
        Require(actual.Length == expected.Length && actual.Order(StringComparer.Ordinal)
            .SequenceEqual(expected.Order(StringComparer.Ordinal)),
            "A modern route disappeared, changed method or was mapped more than once.");
        foreach (RouteEndpoint endpoint in endpoints)
        {
            string path = endpoint.RoutePattern.RawText!;
            string? expectedPolicy = path.StartsWith("/v1/accounts/", StringComparison.Ordinal) ? "auth" :
                path.StartsWith("/v1/", StringComparison.Ordinal) ? "api" : null;
            Require(endpoint.Metadata.GetMetadata<EnableRateLimitingAttribute>()?.PolicyName == expectedPolicy,
                "A feature move changed its route rate-limit policy.");
        }
    }

    private static async Task CheckOversizeConnectionPolicyAsync()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = "Development"
        });
        using WebApplication app = builder.Build();
        BackendDeploymentOptions options =
            BackendDeploymentOptions.FromConfiguration(BackendStartupPolicyTests.CreateSettings());
        var middleware = new BackendRequestMiddleware(_ =>
            throw new BadHttpRequestException("Body too large.", StatusCodes.Status413PayloadTooLarge),
            app.Environment, options, NullLogger<BackendRequestMiddleware>.Instance);
        foreach (string protocol in new[] { "HTTP/1.1", "HTTP/2" })
        {
            var context = new DefaultHttpContext();
            context.Request.Protocol = protocol;
            context.Response.Body = new MemoryStream();
            await middleware.InvokeAsync(context);
            Require(context.Response.StatusCode == StatusCodes.Status413PayloadTooLarge &&
                (context.Response.Headers.Connection == "close") == (protocol == "HTTP/1.1"),
                "Oversized response did not preserve the protocol-specific connection policy.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class FixedTime : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return DateTimeOffset.FromUnixTimeSeconds(Now);
        }
    }

    private sealed class ObservedStream : MemoryStream
    {
        public ObservedStream(byte[] bytes) : base(bytes)
        {
        }

        public int BytesRead { get; private set; }

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer,
            CancellationToken cancellationToken = default)
        {
            int read = await base.ReadAsync(buffer, cancellationToken);
            BytesRead += read;
            return read;
        }
    }
}
