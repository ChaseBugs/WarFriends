using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using BestHTTP;
using Google.Protobuf;
using War.Protocol;

// Runs real BestHTTP requests in the disposable Editor project, without a game account or database.
public static class UnityBestHttpBackendAudit
{
    public static void Run()
    {
        // In edit-mode batches, pre-create the component to avoid BestHTTP's play-mode
        // DontDestroyOnLoad path. Requests and callback pumping still use the real library.
        var updater = new UnityEngine.GameObject("HTTP Update Delegator");
        updater.AddComponent<HTTPUpdateDelegator>();
        var reservation = new TcpListener(IPAddress.Loopback, 0);
        reservation.Start();
        int port = ((IPEndPoint)reservation.LocalEndpoint).Port;
        reservation.Stop();
        var endpoint = new Uri("http://127.0.0.1:" + port + "/");
        using (var listener = new HttpListener())
        {
            listener.Prefixes.Add(endpoint.AbsoluteUri);
            listener.Start();
            using (var client = SelfHostedBackendClientFactory.Create(endpoint, true))
            {
                Task server = Task.Run(() =>
                {
                    HttpListenerContext context = listener.GetContext();
                    Require(context.Request.HttpMethod == "POST", "Register method changed.");
                    Require(context.Request.ContentType == "application/x-protobuf", "Protobuf content type missing.");
                    var request = RegisterRequest.Parser.ParseFrom(context.Request.InputStream);
                    Require(request.Username == "transport-audit", "Protobuf request body changed.");
                    Reply(context, 200, new AccountSession { AccessToken = "audit-token" }.ToByteArray());
                    context = listener.GetContext();
                    Require(context.Request.HttpMethod == "GET", "Player method changed.");
                    Require(context.Request.Headers["Authorization"] == "Bearer audit-token", "Bearer header changed.");
                    Reply(context, 200, new PlayerProfile { PlayerId = "audit-player" }.ToByteArray());
                    context = listener.GetContext();
                    Reply(context, 401, new ErrorResponse { Code = "audit-denied" }.ToByteArray());
                    context = listener.GetContext();
                    Reply(context, 200, new byte[65537]);
                });
                var registration = client.RegisterAsync(new RegisterRequest { Username = "transport-audit" }, CancellationToken.None);
                Pump(registration);
                Require(registration.GetAwaiter().GetResult().AccessToken == "audit-token", "Session response changed.");
                var player = client.PlayerAsync("audit-token", CancellationToken.None);
                Pump(player);
                Require(player.GetAwaiter().GetResult().PlayerId == "audit-player", "Player response changed.");
                var denied = client.PlayerAsync("audit-token", CancellationToken.None);
                Pump(denied);
                Require(denied.IsFaulted && denied.Exception.ToString().Contains("audit-denied"), "Error status/body lost.");
                var oversized = client.PlayerAsync("audit-token", CancellationToken.None);
                Pump(oversized);
                Require(oversized.IsFaulted, "Oversized response accepted.");
                Pump(server);
                server.GetAwaiter().GetResult();
                using (var cancellation = new CancellationTokenSource())
                {
                    var pending = client.PlayerAsync("audit-token", cancellation.Token);
                    Task<HttpListenerContext> received = listener.GetContextAsync();
                    Pump(received);
                    cancellation.Cancel();
                    Pump(pending);
                    Require(pending.IsCanceled, "In-flight cancellation was lost.");
                    received.Result.Response.Abort();
                    var canceled = client.PlayerAsync("audit-token", cancellation.Token);
                    Pump(canceled);
                    Require(canceled.IsCanceled, "Pre-canceled request was sent.");
                }
            }
        }
    }

    private static void Reply(HttpListenerContext context, int status, byte[] bytes)
    {
        context.Response.StatusCode = status;
        context.Response.ContentType = "application/x-protobuf";
        context.Response.ContentLength64 = bytes.Length;
        context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        context.Response.Close();
    }

    private static void Pump(Task task)
    {
        DateTime deadline = DateTime.UtcNow.AddSeconds(20);
        while (!task.IsCompleted)
        {
            if (DateTime.UtcNow >= deadline) throw new TimeoutException("BestHTTP audit timed out.");
            HTTPManager.OnUpdate();
            Thread.Sleep(10);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
}
