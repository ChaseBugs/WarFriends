using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using War.Backend.Hosting;
using War.Backend.Hosting.Configuration;
using War.Backend.Legacy;
using War.Backend.Legacy.Dispatch;
using War.Battle.Tests.Startup;
using War.Persistence;
using Google.Protobuf;
using War.Client;
using War.Protocol;

namespace War.Battle.Tests.Legacy.Dispatch;

internal static class LegacyActionRegistryTests
{
    internal static async Task<int> RunAsync()
    {
        using WebApplication app = CreateApplication();
        LegacyActionRegistry registry = app.Services.GetRequiredService<LegacyActionRegistry>();
        CheckInventory(registry);
        CheckClientEnum();
        CheckExtractionContract(registry);
        CheckInvalidRegistrations(registry);
        CheckRoutes(app);
        await CheckHttpAdapterAsync(app);
        await CheckProtobufAdapterAsync(app);
        await CheckAnonymousDispatchAsync(registry);
        await CheckInvalidSessionAsync(registry);
        await CheckAuthenticatedDispatchAsync(registry);
        await CheckDamagedSessionAsync(registry);
        await CheckDailyRewardAvailabilityAsync(registry);
        await CheckAssignmentAvailabilityAsync(registry);
        return 13;
    }

    private static async Task CheckDailyRewardAvailabilityAsync(LegacyActionRegistry registry)
    {
        Require(registry.Get(DatabaseAction.CheckDailyReward).Disposition == LegacyActionDisposition.Authenticated,
            "Daily calendar reads must authenticate.");
        Require(registry.Get(DatabaseAction.ClaimDailyReward).Disposition == LegacyActionDisposition.Authenticated,
            "Daily calendar claims must authenticate.");
        await Task.CompletedTask;
    }

    private static async Task CheckAssignmentAvailabilityAsync(LegacyActionRegistry registry)
    {
        var player = new LegacyPlayerDocument();
        var authentication = new ObservedAuthentication { Player = player };
        LegacyRequestDispatcher dispatcher = CreateDispatcher(registry, authentication);
        IResult result = await dispatcher.DispatchAsync(Request(DatabaseAction.GetNewAssignments), CancellationToken.None);
        (string body, _) = await ReadAsync(result);
        JsonObject response = JsonNode.Parse(body)!.AsObject();
        JsonObject data = JsonNode.Parse(response["AssignmentData"]!.GetValue<string>())!.AsObject();
        Require(authentication.Calls == 1 && response["Result"]!.GetValue<int>() == 1,
            "Assignment availability must remain authenticated without forcing global maintenance.");
        Require(data["assignments"]!.AsArray().Count == 0 && player.Serialized.Count == 0,
            "Unavailable assignments must neither issue tasks nor publish progression.");
        const string existing = "{\"assignments\":[],\"rewardCounter\":7}";
        player.Serialized["AssignmentData"] = existing;
        result = await dispatcher.DispatchAsync(Request(DatabaseAction.GetNewAssignments), CancellationToken.None);
        (body, _) = await ReadAsync(result);
        Require(JsonNode.Parse(body)!["AssignmentData"]!.GetValue<string>() == existing &&
            player.Serialized["AssignmentData"] == existing,
            "A read-only availability check must not reset existing assignment progress.");
        Require(registry.Get(DatabaseAction.ClaimAssignment).Disposition != LegacyActionDisposition.Authenticated,
            "Availability must not enable direct reward claims.");
    }

    private static WebApplication CreateApplication()
    {
        var settings = BackendStartupPolicyTests.CreateSettings();
        settings["Mongo:Uri"] = "mongodb://127.0.0.1:1/?serverSelectionTimeoutMS=100";
        BackendDeploymentOptions deployment = BackendDeploymentOptions.FromConfiguration(settings);
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddBackendServices(deployment);
        WebApplication app = builder.Build();
        app.MapLegacy();
        return app;
    }

    private static void CheckInventory(LegacyActionRegistry registry)
    {
        LegacyActionRegistration[] entries = registry.Actions.Values.ToArray();
        Require(entries.Length == 175, "The reviewed legacy wire inventory changed.");
        Require(entries.Count(entry => entry.Disposition == LegacyActionDisposition.Anonymous) == 4,
            "The anonymous boundary changed.");
        Require(entries.Count(entry => entry.Disposition == LegacyActionDisposition.Authenticated) == 64,
            "An implemented direct action disappeared or opened without review.");
        Require(entries.Count(entry => entry.Disposition == LegacyActionDisposition.BufferedOnly) == 25,
            "The buffer-only inventory changed.");
        Require(entries.Count(entry => entry.Disposition == LegacyActionDisposition.Closed) == 82,
            "A closed action changed disposition without review.");
        Require(registry.Get(DatabaseAction.GameEnded).Disposition == LegacyActionDisposition.Authenticated,
            "Legacy GameEnded must require authentication before checking accepted host outcome authority.");
        Require(registry.Get(DatabaseAction.UpdateRegionPings).Feature == LegacyActionFeature.Battle,
            "Offline region compatibility belongs to the battle feature.");
    }

    private static void CheckClientEnum()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.Combine(Directory.GetParent(server)!.FullName,
            "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseAction.cs");
        string source = File.ReadAllText(path);
        Dictionary<string, int> client = Regex.Matches(source, @"\b(\w+)\s*=\s*(\d+)")
            .ToDictionary(match => match.Groups[1].Value, match => int.Parse(match.Groups[2].Value));
        DatabaseAction[] actions = Enum.GetValues<DatabaseAction>();
        Require(client.Count == actions.Length && actions.All(action =>
                client.TryGetValue(action.ToString(), out int value) && value == (int)action),
            "The server action identities differ from the recovered 1.4.0 Client.");
    }

    private static void CheckInvalidRegistrations(LegacyActionRegistry registry)
    {
        LegacyActionRegistration[] entries = registry.Actions.Values.ToArray();
        foreach (LegacyActionRegistration missing in entries)
        {
            Refuses(entries.Where(entry => entry != missing));
        }
        Refuses([.. entries, entries[0]]);
        Refuses([.. entries, LegacyActionRegistration.Closed((DatabaseAction)999999)]);
        Refuses(Replace(entries, LegacyActionRegistration.Closed(DatabaseAction.GetConfigurations)));
        Refuses(Replace(entries, LegacyActionRegistration.Anonymous(DatabaseAction.GameEnded,
            LegacyActionFeature.Battle, (_, _) => Task.FromResult(LegacyResponse.Ok()))));
        Refuses(Replace(entries, LegacyActionRegistration.Authenticated(DatabaseAction.BuyWeapon,
            LegacyActionFeature.Inventory, (_, _, _) => Task.FromResult(LegacyResponse.Ok()))));
        Refuses(Replace(entries, LegacyActionRegistration.Buffered(DatabaseAction.BuyWeapon,
            LegacyActionFeature.Unavailable)));
        Refuses(Replace(entries, LegacyActionRegistration.Buffered(DatabaseAction.BuyWeapon,
            (LegacyActionFeature)999999)));
    }

    private static void CheckExtractionContract(LegacyActionRegistry registry)
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        using JsonDocument evidence = JsonDocument.Parse(
            File.ReadAllText(Path.Combine(server, "docs/legacy-direct-extraction.json")));
        HashSet<string> originalDirect = evidence.RootElement.GetProperty("directActions").EnumerateArray()
            .Select(action => action.GetString()!).ToHashSet(StringComparer.Ordinal);
        // Preserve the extraction baseline; action 62 was subsequently implemented over host authority.
        originalDirect.Add(nameof(DatabaseAction.GameEnded));
        originalDirect.Add(nameof(DatabaseAction.CheckDailyReward));
        originalDirect.Add(nameof(DatabaseAction.ClaimDailyReward));
        originalDirect.Add(nameof(DatabaseAction.GetNewAssignments));
        IEnumerable<string> direct = registry.Actions.Values
            .Where(entry => entry.Disposition == LegacyActionDisposition.Authenticated)
            .Select(entry => entry.Action.ToString());
        Require(originalDirect.SetEquals(direct), "The extraction changed the original authenticated action set.");

        JsonElement[] blocked = evidence.RootElement.GetProperty("blockedDirectActions").EnumerateArray().ToArray();
        int distinctIds = blocked.Select(row => row.GetProperty("id").GetInt32()).Distinct().Count();
        Require(blocked.Length == 111 && distinctIds == 111,
            "The reviewed HTTP closure fixture is incomplete or duplicated.");
        foreach (JsonElement row in blocked)
        {
            var action = (DatabaseAction)row.GetProperty("id").GetInt32();
            LegacyActionRegistration entry = registry.Get(action);
            if (action == DatabaseAction.GameEnded || action == DatabaseAction.CheckDailyReward || action == DatabaseAction.ClaimDailyReward || action == DatabaseAction.GetNewAssignments)
            {
                Require(entry.Disposition == LegacyActionDisposition.Authenticated,
                    "Host-backed settlement must keep its authenticated boundary.");
                continue;
            }
            Require(action.ToString() == row.GetProperty("name").GetString() &&
                    entry.Disposition is LegacyActionDisposition.BufferedOnly or LegacyActionDisposition.Closed,
                "The reviewed direct-channel closure changed.");
        }

        DatabaseAction[] profile = [DatabaseAction.UpdateDeviceToken, DatabaseAction.SetPlayerStatus,
            DatabaseAction.ChangePlayerName, DatabaseAction.ChangeLanguage, DatabaseAction.UpdateSettings,
            DatabaseAction.GetPlayerInfo, DatabaseAction.UpdateArmyPower, DatabaseAction.ChangePlayerCountry];
        Require(profile.All(action => registry.Get(action).Feature == LegacyActionFeature.Player),
            "A recovered player-profile action lost its Player feature owner.");
    }

    private static void CheckRoutes(WebApplication app)
    {
        RouteEndpoint[] routes = ((IEndpointRouteBuilder)app).DataSources.SelectMany(source => source.Endpoints)
            .OfType<RouteEndpoint>().ToArray();
        string[] methods = routes.SelectMany(route => route.Metadata.GetRequiredMetadata<HttpMethodMetadata>()
            .HttpMethods.Select(method => method + " " + route.RoutePattern.RawText)).Order().ToArray();
        string[] expected = ["GET /check.php", "POST /check.php", "POST /index_09_25_2015.php"];
        Require(methods.SequenceEqual(expected), "The legacy route paths or verbs changed.");
        Require(routes.All(route => route.Metadata.GetMetadata<EnableRateLimitingAttribute>()?.PolicyName == "api"),
            "A legacy route lost its API rate-limit policy.");
    }

    private static async Task CheckAnonymousDispatchAsync(LegacyActionRegistry registry)
    {
        var authentication = new ObservedAuthentication();
        LegacyRequestDispatcher dispatcher = CreateDispatcher(registry, authentication);
        IResult result = await dispatcher.DispatchAsync(Request(DatabaseAction.GetConfigurations), default);
        (string body, string? contentType) = await ReadAsync(result);
        Require(body.StartsWith("success;", StringComparison.Ordinal) && body.Split(';').Length == 3 &&
                contentType == "text/plain" && authentication.Calls == 0,
            "Action 157 lost its raw semicolon response or now requires a session.");

        LegacyActionRegistry observed = ReplaceHandlers(registry);
        dispatcher = CreateDispatcher(observed, authentication);
        foreach (LegacyActionRegistration entry in observed.Actions.Values
                     .Where(entry => entry.Disposition == LegacyActionDisposition.Anonymous))
        {
            int code = await ResultCodeAsync(await dispatcher.DispatchAsync(Request(entry.Action), default));
            Require(code == (int)DatabaseResult.Success && authentication.Calls == 0,
                "An account/configuration action crossed the session boundary.");
        }
    }

    private static async Task CheckHttpAdapterAsync(WebApplication app)
    {
        string sheet = app.Services.GetRequiredService<BackendDeploymentOptions>().Legacy.Starter.SheetConfiguration;
        (string body, string? type) = await ReadRouteAsync(app, LegacyEndpoints.ActionPath, "157");
        Require(body == $"success;{sheet};{{}}" && type == "text/plain",
            "The actual HTTP delegate discarded or serialized the raw configuration IResult.");

        (body, type) = await ReadRouteAsync(app, LegacyEndpoints.ActionPath, "unknown");
        Require(type == "application/json" &&
                JsonNode.Parse(body)!["Result"]!.GetValue<int>() == (int)DatabaseResult.JsonFailure,
            "The actual HTTP delegate discarded the malformed-request failure result.");

        (body, type) = await ReadRouteAsync(app, LegacyEndpoints.CheckPath, null);
        Require(body == "ok" && type == "text/plain", "The reachability HTTP delegate lost its exact body.");
    }

    private static async Task CheckProtobufAdapterAsync(WebApplication app)
    {
        byte[] request = BackendActionCodec.Encode(new Dictionary<string, string> { ["requestId"] = "157" });
        string response = await ReadProtobufRouteAsync(app, LegacyEndpoints.ActionPath, request);
        Require(response.StartsWith("success;", StringComparison.Ordinal),
            "Protobuf must preserve the recovered configuration callback payload.");
        response = await ReadProtobufRouteAsync(app, LegacyEndpoints.CheckPath, []);
        Require(response == "ok", "Protobuf probe must preserve the local connectivity acknowledgement.");

        var duplicate = new ClientActionRequest { FormatVersion = 1 };
        duplicate.Fields.Add(new ClientActionField { Name = "requestId", Value = "157" });
        duplicate.Fields.Add(new ClientActionField { Name = "RequestId", Value = "118" });
        response = await ReadProtobufRouteAsync(app, LegacyEndpoints.ActionPath, duplicate.ToByteArray());
        Require(JsonNode.Parse(response)!["Result"]!.GetValue<int>() == (int)DatabaseResult.JsonFailure,
            "Case-ambiguous protobuf fields must not select an action.");
        response = await ReadProtobufRouteAsync(app, LegacyEndpoints.ActionPath, [0xff]);
        Require(JsonNode.Parse(response)!["Result"]!.GetValue<int>() == (int)DatabaseResult.JsonFailure,
            "Malformed protobuf must return a framed failure without invoking an action.");
    }

    private static async Task<string> ReadProtobufRouteAsync(WebApplication app, string path, byte[] bytes)
    {
        RouteEndpoint route = ((IEndpointRouteBuilder)app).DataSources.SelectMany(source => source.Endpoints)
            .OfType<RouteEndpoint>().Single(endpoint => endpoint.RoutePattern.RawText == path);
        var context = new DefaultHttpContext { RequestServices = app.Services };
        context.Request.Method = "POST";
        context.Request.Path = path;
        context.Request.ContentType = BackendActionCodec.ContentType;
        context.Request.Body = new MemoryStream(bytes);
        await using var output = new MemoryStream();
        context.Response.Body = output;
        await route.RequestDelegate!(context);
        Require(context.Response.ContentType == BackendActionCodec.ContentType,
            "The protobuf request must receive a protobuf response.");
        return BackendActionCodec.Decode(output.ToArray());
    }

    private static async Task<(string Body, string? ContentType)> ReadRouteAsync(
        WebApplication app, string path, string? requestId)
    {
        RouteEndpoint route = ((IEndpointRouteBuilder)app).DataSources.SelectMany(source => source.Endpoints)
            .OfType<RouteEndpoint>().Single(endpoint => endpoint.RoutePattern.RawText == path);
        var context = new DefaultHttpContext { RequestServices = app.Services };
        context.Request.Method = "POST";
        context.Request.Path = path;
        context.Request.ContentType = "application/x-www-form-urlencoded";
        var fields = new Dictionary<string, StringValues>();
        if (requestId != null)
        {
            fields.Add("requestId", requestId);
        }
        context.Request.Form = new FormCollection(fields);
        await using var output = new MemoryStream();
        context.Response.Body = output;
        await route.RequestDelegate!(context);
        return (Encoding.UTF8.GetString(output.ToArray()), context.Response.ContentType);
    }

    private static async Task CheckInvalidSessionAsync(LegacyActionRegistry registry)
    {
        var authentication = new ObservedAuthentication();
        LegacyRequestDispatcher dispatcher = CreateDispatcher(registry, authentication);
        foreach (LegacyActionRegistration entry in registry.Actions.Values
                     .Where(entry => entry.Disposition != LegacyActionDisposition.Anonymous))
        {
            int code = await ResultCodeAsync(await dispatcher.DispatchAsync(Request(entry.Action), default));
            Require(code == (int)DatabaseResult.InvalidToken,
                $"Action {entry.Action} executed before successful session authentication.");
        }
        Require(authentication.Calls == 171, "A non-anonymous action skipped session lookup.");
    }

    private static async Task CheckAuthenticatedDispatchAsync(LegacyActionRegistry registry)
    {
        var authentication = new ObservedAuthentication { Player = new LegacyPlayerDocument() };
        LegacyRequestDispatcher dispatcher = CreateDispatcher(ReplaceHandlers(registry), authentication);
        using var cancellation = new CancellationTokenSource();
        foreach (LegacyActionRegistration entry in registry.Actions.Values
                     .Where(entry => entry.Disposition != LegacyActionDisposition.Anonymous))
        {
            int code = await ResultCodeAsync(await dispatcher.DispatchAsync(Request(entry.Action), cancellation.Token));
            DatabaseResult expected = entry.Disposition == LegacyActionDisposition.Authenticated
                ? DatabaseResult.Success : DatabaseResult.ServerMaintenance;
            Require(code == (int)expected, $"Action {entry.Action} used the wrong direct-channel disposition.");
            Require(authentication.LastToken == cancellation.Token, "Session lookup lost request cancellation.");
        }
    }

    private static async Task CheckDamagedSessionAsync(LegacyActionRegistry registry)
    {
        var authentication = new ObservedAuthentication { Failure = new InvalidDataException("damaged state") };
        LegacyRequestDispatcher dispatcher = CreateDispatcher(registry, authentication);
        int code = await ResultCodeAsync(await dispatcher.DispatchAsync(Request(DatabaseAction.Test), default));
        Require(code == (int)DatabaseResult.ServerMaintenance, "Damaged stored session authority was accepted.");

        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        authentication.Failure = null;
        try
        {
            await dispatcher.DispatchAsync(Request(DatabaseAction.Test), cancellation.Token);
        }
        catch (OperationCanceledException error) when (error.CancellationToken == cancellation.Token)
        {
            return;
        }
        throw new InvalidOperationException("Session lookup swallowed request cancellation.");
    }

    private static LegacyActionRegistry ReplaceHandlers(LegacyActionRegistry registry)
    {
        return new LegacyActionRegistry(registry.Actions.Values.Select(entry => entry.Disposition switch
        {
            LegacyActionDisposition.Anonymous => LegacyActionRegistration.Anonymous(entry.Action, entry.Feature,
                (_, _) => Task.FromResult(LegacyResponse.Json(DatabaseResult.Success))),
            LegacyActionDisposition.Authenticated => LegacyActionRegistration.Authenticated(entry.Action, entry.Feature,
                (_, _, _) => Task.FromResult(LegacyResponse.Json(DatabaseResult.Success))),
            _ => entry
        }));
    }

    private static IEnumerable<LegacyActionRegistration> Replace(IEnumerable<LegacyActionRegistration> entries,
        LegacyActionRegistration replacement)
    {
        return entries.Select(entry => entry.Action == replacement.Action ? replacement : entry);
    }

    private static LegacyRequestDispatcher CreateDispatcher(
        LegacyActionRegistry registry, ILegacySessionAuthentication authentication)
    {
        return new(registry, authentication, NullLogger<LegacyRequestDispatcher>.Instance);
    }

    private static LegacyRequest Request(DatabaseAction action)
    {
        var context = new DefaultHttpContext();
        context.Request.ContentType = "application/x-www-form-urlencoded";
        context.Request.Form = new FormCollection(new Dictionary<string, StringValues>
        {
            ["requestId"] = ((int)action).ToString(System.Globalization.CultureInfo.InvariantCulture)
        });
        Require(LegacyRequest.TryParse(context.Request, out LegacyRequest? request), "Fixture request did not parse.");
        return request!;
    }

    private static async Task<int> ResultCodeAsync(IResult result)
    {
        (string body, _) = await ReadAsync(result);
        return JsonNode.Parse(body)!["Result"]!.GetValue<int>();
    }

    private static async Task<(string Body, string? ContentType)> ReadAsync(IResult result)
    {
        var context = new DefaultHttpContext();
        await using var output = new MemoryStream();
        context.Response.Body = output;
        await result.ExecuteAsync(context);
        Require(context.Response.StatusCode == 200 && context.Response.Headers.CacheControl == "no-store",
            "A protocol response changed its HTTP/cache contract.");
        return (Encoding.UTF8.GetString(output.ToArray()), context.Response.ContentType);
    }

    private static void Refuses(IEnumerable<LegacyActionRegistration> entries)
    {
        try
        {
            _ = new LegacyActionRegistry(entries);
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new InvalidOperationException("An invalid legacy action graph was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class ObservedAuthentication : ILegacySessionAuthentication
    {
        public LegacyPlayerDocument? Player { get; init; }
        public Exception? Failure { get; set; }
        public int Calls { get; private set; }
        public CancellationToken LastToken { get; private set; }

        public Task<LegacyPlayerDocument?> AuthenticateAsync(LegacyRequest request, CancellationToken cancellationToken)
        {
            Calls++;
            LastToken = cancellationToken;
            cancellationToken.ThrowIfCancellationRequested();
            if (Failure != null)
            {
                throw Failure;
            }
            return Task.FromResult(Player);
        }
    }
}
