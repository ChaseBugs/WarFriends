using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Sockets;

/// <summary>Returns a real HTTP 503 until the test restores result delivery.</summary>
internal sealed class ResultOutageProxy : IAsyncDisposable
{
    private readonly WebApplication app;
    private readonly HttpClient http = new();
    private readonly TaskCompletionSource failureObserved =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private int available;
    internal Uri Endpoint { get; }

    private ResultOutageProxy(WebApplication app, Uri endpoint, Uri backend)
    {
        this.app = app;
        Endpoint = endpoint;
        app.MapPost("/result", async context =>
        {
            if (Volatile.Read(ref available) == 0)
            {
                context.Response.StatusCode = 503;
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
            context.Response.StatusCode = (int)response.StatusCode;
            context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
            await response.Content.CopyToAsync(context.Response.Body, context.RequestAborted);
        });
    }

    internal static async Task<ResultOutageProxy> Start(Uri backend)
    {
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        int port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        var builder = WebApplication.CreateSlimBuilder();
        builder.WebHost.UseUrls($"http://127.0.0.1:{port}");
        var app = builder.Build();
        var proxy = new ResultOutageProxy(app, new Uri($"http://127.0.0.1:{port}/result"), backend);
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
