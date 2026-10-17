using System.Security.Cryptography;
using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using War.Protocol;

/// <summary>Serves a preallocated real Worker grant through a bounded local test-only queue contract.</summary>
internal sealed class LiveMatchmakingTestHost : IAsyncDisposable
{
    private const int AccessTokenBytes = 32;
    private readonly WebApplication _application;
    private readonly MatchConnectionGrant _grant;
    private int _joinRequests;
    private int _grantRequests;
    private int _cancelRequests;

    private LiveMatchmakingTestHost(WebApplication application, MatchConnectionGrant grant)
    {
        _application = application;
        _grant = grant.Clone();
        AccessToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(AccessTokenBytes));
    }

    internal string AccessToken { get; }

    internal string Endpoint => _application.Urls.Single().TrimEnd('/') + "/";

    internal static async Task<LiveMatchmakingTestHost> StartAsync(MatchConnectionGrant grant)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        var host = new LiveMatchmakingTestHost(builder.Build(), grant);
        host._application.MapPost("/v1/battle/queue/join", (Delegate)host.JoinAsync);
        host._application.MapPost("/v1/battle/grant", (Delegate)host.GrantAsync);
        host._application.MapPost("/v1/battle/queue/cancel", (Delegate)host.CancelAsync);
        try
        {
            await host._application.StartAsync();
            return host;
        }
        catch
        {
            await host.DisposeAsync();
            throw;
        }
    }

    internal void VerifySuccessfulAdmission()
    {
        if (_joinRequests != 1 || _grantRequests != 1 || _cancelRequests != 0)
        {
            throw new Exception("Normal queue admission must join and fetch once without canceling its allocation.");
        }
    }

    /// <summary>Stops only the ephemeral allocator facade owned by this live test.</summary>
    public async ValueTask DisposeAsync()
    {
        await _application.DisposeAsync();
    }

    private async Task<IResult> JoinAsync(HttpContext context)
    {
        byte[]? body = await ReadAuthorizedAsync(context);
        if (body == null || body.Length != 0)
        {
            return Results.BadRequest();
        }

        Interlocked.Increment(ref _joinRequests);
        var reply = new MatchQueueReply { Code = "paired", MatchId = _grant.MatchId };
        reply.PlayerIds.Add(_grant.PlayerViews.Select(view => view.PlayerId));
        return Proto(reply);
    }

    private async Task<IResult> GrantAsync(HttpContext context)
    {
        byte[]? body = await ReadAuthorizedAsync(context);
        if (body == null || MatchGrantRequest.Parser.ParseFrom(body).MatchId != _grant.MatchId)
        {
            return Results.BadRequest();
        }

        Interlocked.Increment(ref _grantRequests);
        return Proto(_grant);
    }

    private async Task<IResult> CancelAsync(HttpContext context)
    {
        byte[]? body = await ReadAuthorizedAsync(context);
        if (body == null || body.Length != 0)
        {
            return Results.BadRequest();
        }

        Interlocked.Increment(ref _cancelRequests);
        return Proto(new MatchQueueReply { Code = "already-paired" });
    }

    private async Task<byte[]?> ReadAuthorizedAsync(HttpContext context)
    {
        const int MaximumRequestBytes = 256;
        if (context.Request.Headers.Authorization != "Bearer " + AccessToken ||
            context.Request.ContentLength is null or > MaximumRequestBytes)
        {
            return null;
        }

        using var body = new MemoryStream();
        await context.Request.Body.CopyToAsync(body, context.RequestAborted);
        return body.Length <= MaximumRequestBytes ? body.ToArray() : null;
    }

    private static IResult Proto(IMessage message)
    {
        return Results.Bytes(message.ToByteArray(), "application/x-protobuf");
    }
}
