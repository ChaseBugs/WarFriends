using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

/// <summary>Forwards signed control bytes and drops one observed successful registration response.</summary>
internal sealed class RegistrationReplyLossProxy : IAsyncDisposable
{
    private readonly WebApplication _app;
    private readonly HttpClient _http = new();
    private readonly Uri _worker;
    private readonly object _gate = new();
    private readonly List<Evidence> _replays = [];
    private bool _isArmed;
    private Evidence? _dropped;

    internal Uri Endpoint { get; }

    private RegistrationReplyLossProxy(WebApplication app, Uri endpoint, Uri worker)
    {
        _app = app;
        _worker = worker;
        Endpoint = endpoint;
        app.MapPost("/internal/matches", ForwardAsync);
        app.MapPost("/internal/matches/{**suffix}", ForwardAsync);
        app.MapPost("/internal/results/find", ForwardAsync);
    }

    internal static async Task<RegistrationReplyLossProxy> StartAsync(Uri worker, int[] excludedPorts)
    {
        int port;
        do
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
        } while (excludedPorts.Contains(port));
        var builder = WebApplication.CreateSlimBuilder();
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls($"http://127.0.0.1:{port}");
        var app = builder.Build();
        var proxy = new RegistrationReplyLossProxy(app,
            new Uri($"http://127.0.0.1:{port}/internal/matches"), worker);
        await app.StartAsync();
        return proxy;
    }

    internal void Arm()
    {
        lock (_gate)
        {
            if (_isArmed || _dropped != null)
            {
                throw new InvalidDataException("Registration loss fixture can be armed only once.");
            }
            _isArmed = true;
        }
    }

    internal Evidence Dropped
    {
        get
        {
            lock (_gate)
            {
                return _dropped ?? throw new InvalidDataException("No successful registration reply was dropped.");
            }
        }
    }

    internal Evidence[] Replays
    {
        get
        {
            lock (_gate)
            {
                return _replays.ToArray();
            }
        }
    }

    private async Task ForwardAsync(HttpContext context)
    {
        using var body = new MemoryStream();
        await context.Request.Body.CopyToAsync(body, context.RequestAborted);
        byte[] bytes = body.ToArray();
        using var request = new HttpRequestMessage(HttpMethod.Post, new Uri(_worker, context.Request.Path.Value))
        {
            Content = new ByteArrayContent(bytes),
        };
        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        foreach (string header in new[] { "X-War-Control-Time", "X-War-Control-Mac" })
        {
            request.Headers.Add(header, context.Request.Headers[header].ToString());
        }
        try
        {
            using var response = await _http.SendAsync(request, context.RequestAborted);
            byte[] responseBody = await response.Content.ReadAsByteArrayAsync(context.RequestAborted);
            if (context.Request.Path == "/internal/matches" && response.IsSuccessStatusCode &&
                CaptureOrDrop(bytes, responseBody))
            {
                // The Worker has issued real capabilities; the Backend receives no successful acknowledgement.
                context.Abort();
                return;
            }
            context.Response.StatusCode = (int)response.StatusCode;
            context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
            await context.Response.Body.WriteAsync(responseBody, context.RequestAborted);
        }
        catch (HttpRequestException)
        {
            // An intentionally stopped owned Worker is an actual unavailable upstream, not a registration response.
            context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
        }
    }

    private bool CaptureOrDrop(byte[] request, byte[] response)
    {
        lock (_gate)
        {
            if (!_isArmed && _dropped == null)
            {
                return false;
            }
            Evidence observed = Capture(request, response);
            if (_isArmed)
            {
                _isArmed = false;
                _dropped = observed;
                return true;
            }
            if (observed.MatchId == _dropped?.MatchId)
            {
                _replays.Add(observed);
            }
            return false;
        }
    }

    private static Evidence Capture(byte[] request, byte[] response)
    {
        using var source = JsonDocument.Parse(request);
        using var received = JsonDocument.Parse(response);
        JsonElement root = received.RootElement;
        string matchId = root.GetProperty("matchId").GetString()
            ?? throw new InvalidDataException("Registration response lacks its match identity.");
        if (source.RootElement.GetProperty("MatchId").GetString() != matchId)
        {
            throw new InvalidDataException("Observed registration request and response differ.");
        }
        return new Evidence
        {
            MatchId = matchId,
            Code = root.GetProperty("code").GetString() ?? "",
            ManifestHash = root.GetProperty("manifestHash").GetString() ?? "",
            RequestHash = Hash(request),
            GrantsHash = Hash(Encoding.UTF8.GetBytes(root.GetProperty("grants").GetRawText())),
            Capabilities = root.GetProperty("grants").EnumerateArray().Select(grant => new Capability(
                grant.GetProperty("playerId").GetString() ?? "", grant.GetProperty("sessionId").GetUInt64(),
                Hash(Encoding.UTF8.GetBytes(grant.GetProperty("ticket").GetString() ?? "")),
                Hash(Convert.FromBase64String(grant.GetProperty("sessionKey").GetString() ?? "")))).ToArray(),
        };
    }

    internal static string Hash(byte[] bytes)
    {
        return Convert.ToHexStringLower(SHA256.HashData(bytes));
    }

    /// <summary>Stops only this fixture's loopback listener and forwarding client.</summary>
    public async ValueTask DisposeAsync()
    {
        await _app.StopAsync();
        await _app.DisposeAsync();
        _http.Dispose();
    }

    internal sealed class Evidence
    {
        internal required string MatchId { get; init; }
        internal required string Code { get; init; }
        internal required string ManifestHash { get; init; }
        internal required string RequestHash { get; init; }
        internal required string GrantsHash { get; init; }
        internal required Capability[] Capabilities { get; init; }
    }

    internal sealed record Capability(string PlayerId, ulong SessionId, string TicketHash, string KeyHash);
}
