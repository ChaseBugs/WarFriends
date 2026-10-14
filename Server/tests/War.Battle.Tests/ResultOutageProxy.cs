using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Text.Json;

/// <summary>Injects observed delivery failures before restoring signed forwarding.</summary>
internal sealed class ResultOutageProxy : IAsyncDisposable
{
    private readonly WebApplication app;
    private readonly HttpClient http = new();
    private readonly TaskCompletionSource failureObserved =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private int available;
    private int responseDropped;
    private readonly ConcurrentQueue<string> responseCodes = new();
    internal Uri Endpoint { get; }
    internal string[] ResponseCodes => responseCodes.ToArray();

    private ResultOutageProxy(WebApplication app, Uri endpoint, Uri backend,
        bool disconnect, bool loseAcknowledgement)
    {
        this.app = app;
        Endpoint = endpoint;
        app.MapPost("/result", async context =>
        {
            if (Volatile.Read(ref available) == 0)
            {
                if (disconnect) context.Abort();
                else context.Response.StatusCode = 503;
                failureObserved.TrySetResult();
                return;
            }
            using var body = new MemoryStream();
            await context.Request.Body.CopyToAsync(body, context.RequestAborted);
            using var request = new HttpRequestMessage(HttpMethod.Post, backend)
            {
                Content = new ByteArrayContent(body.ToArray())
            };
            request.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            foreach (string header in new[] { "X-War-Control-Time", "X-War-Control-Mac" })
                request.Headers.Add(header, context.Request.Headers[header].ToString());
            using var response = await http.SendAsync(request, context.RequestAborted);
            byte[] responseBody = await response.Content.ReadAsByteArrayAsync(context.RequestAborted);
            if (response.IsSuccessStatusCode)
            {
                using var json = JsonDocument.Parse(responseBody);
                responseCodes.Enqueue(json.RootElement.GetProperty("code").GetString()!);
                if (loseAcknowledgement && Interlocked.CompareExchange(ref responseDropped, 1, 0) == 0)
                {
                    // Backend has committed the result, but the Worker sees
                    // a broken connection instead of the successful response.
                    context.Abort();
                    return;
                }
            }
            context.Response.StatusCode = (int)response.StatusCode;
            context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
            await context.Response.Body.WriteAsync(responseBody, context.RequestAborted);
        });
    }

    internal static async Task<ResultOutageProxy> Start(Uri backend,
        bool disconnect = false, bool loseAcknowledgement = false)
    {
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        int port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        var builder = WebApplication.CreateSlimBuilder();
        builder.WebHost.UseUrls($"http://127.0.0.1:{port}");
        var app = builder.Build();
        var proxy = new ResultOutageProxy(app, new Uri($"http://127.0.0.1:{port}/result"), backend,
            disconnect, loseAcknowledgement);
        await app.StartAsync();
        return proxy;
    }

    internal Task WaitForFailedDelivery(CancellationToken cancellationToken) =>
        failureObserved.Task.WaitAsync(cancellationToken);

    internal void Restore() => Volatile.Write(ref available, 1);

    public async ValueTask DisposeAsync()
    {
        await app.StopAsync();
        await app.DisposeAsync();
        http.Dispose();
    }
}
