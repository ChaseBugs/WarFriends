using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using War.BattleServer;
using War.BattleServer.Hosting;
using War.BattleServer.Transport.Control;
using War.Battle.Tests.Startup;

namespace War.Battle.Tests.Http;

internal static class WorkerHttpBoundaryTests
{
    internal static int Run()
    {
        CheckRoutes();
        CheckRequestShapes();
        return 2;
    }

    private static void CheckRoutes()
    {
        BattleHostStartupOptions startup =
            BattleHostStartupOptions.FromConfiguration(BackendStartupPolicyTests.CreateSettings());
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddBattleHostServices(startup);
        using WebApplication app = builder.Build();
        app.MapBattleControlEndpoints();
        string[] actual = ((IEndpointRouteBuilder)app).DataSources.SelectMany(source => source.Endpoints)
            .OfType<RouteEndpoint>().SelectMany(endpoint => endpoint.Metadata
                .GetRequiredMetadata<HttpMethodMetadata>().HttpMethods
                .Select(method => method + " " + endpoint.RoutePattern.RawText)).ToArray();
        string[] expected =
        [
            "GET /health/live", "GET /health/ready", "GET /health/metrics",
            "POST /internal/matches", "POST /internal/matches/reconnect", "POST /internal/matches/cancel",
            "POST /internal/results/poll", "POST /internal/results/find", "POST /internal/results/ack"
        ];
        Require(actual.Length == expected.Length && actual.Order(StringComparer.Ordinal)
            .SequenceEqual(expected.Order(StringComparer.Ordinal)),
            "Worker route graph changed or duplicated a route.");
    }

    private static void CheckRequestShapes()
    {
        byte[] reconnectBody = JsonSerializer.SerializeToUtf8Bytes(new
        {
            matchId = "fixture", playerId = new string('a', 32), requestId = new string('b', 32)
        });
        ReconnectControlRequest reconnect = WorkerMatchRequests.ReadReconnect(reconnectBody);
        Require(reconnect.MatchId == "fixture" && reconnect.RequestId == new string('b', 32),
            "Reconnect identities changed while crossing the adapter.");
        CancelControlRequest cancellation = WorkerMatchRequests.ReadCancellation(
            "{\"matchId\":\"fixture\"}"u8.ToArray());
        Require(cancellation.ManifestHash == null, "Unscoped cancellation invented a manifest proof.");
        foreach (byte[] body in new[] { "{}"u8.ToArray(), "[]"u8.ToArray(),
            "{\"matchId\":\"fixture\",\"extra\":1}"u8.ToArray() })
        {
            Reject(() => WorkerMatchRequests.ReadReconnect(body));
            Reject(() => WorkerMatchRequests.ReadCancellation(body));
            Reject(() => WorkerResultRequests.ReadAcknowledgement(body));
            Reject(() => WorkerResultRequests.ReadLookup(body));
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("Malformed Worker control shape survived parsing.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
