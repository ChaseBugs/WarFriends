using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using War.Backend.Legacy;
using War.Backend.Legacy.Diagnostics;
using War.Persistence;

namespace War.Battle.Tests.Legacy.Diagnostics;

internal static class LegacyDiagnosticEndpointTests
{
    private const string CallerId = "11111111111111111111111111111111";
    private const string UntrustedText = "diagnostic-token-sentinel\r\n한😀";

    internal static async Task<int> RunAsync()
    {
        CheckPayloadOmission();
        CheckUtf8ByteUnits();
        await CheckCallbackResponsesAsync();
        return 3;
    }

    private static void CheckPayloadOmission()
    {
        var logger = new CapturingLogger();
        var endpoint = new LegacyDiagnosticEndpoint(logger);
        var player = new LegacyPlayerDocument { Id = CallerId };
        LegacyRequest request = Request(new Dictionary<string, string>
        {
            ["ReportedPlayerId"] = UntrustedText, ["ReportType"] = UntrustedText,
            ["Logs"] = UntrustedText, ["DbAction"] = UntrustedText, ["ExceptionMessage"] = UntrustedText,
            ["showedOffers"] = UntrustedText, ["ArenaId"] = UntrustedText,
            ["Token"] = UntrustedText, ["Password"] = UntrustedText, ["PostParameters"] = UntrustedText
        });

        endpoint.ReportCheater(request, player);
        endpoint.ReceiveLog(request, player);
        endpoint.ReceiveError(request, player);
        endpoint.ReceiveOfferShown(request, player);
        endpoint.ReceiveArenaShown(request, player);

        Require(logger.Messages.Count == 5, "A diagnostic receipt was not observable.");
        Require(logger.Messages.All(message => message.Contains(CallerId, StringComparison.Ordinal)),
            "Diagnostic logs lost their validated caller identity.");
        Require(logger.Messages.All(message => !message.Contains(UntrustedText, StringComparison.Ordinal) &&
                !message.Contains('\r') && !message.Contains('\n')),
            "A client diagnostic payload reached rendered operational logs.");
        Require(logger.Properties.All(properties => properties.Values.All(value =>
                value is not string text || !text.Contains(UntrustedText, StringComparison.Ordinal))),
            "A client diagnostic payload remained in structured log properties.");
    }

    private static void CheckUtf8ByteUnits()
    {
        var logger = new CapturingLogger();
        var endpoint = new LegacyDiagnosticEndpoint(logger);
        var player = new LegacyPlayerDocument { Id = CallerId };
        // A: one byte; 한: three bytes; the supplementary emoji: four bytes but two UTF-16 code units.
        endpoint.ReceiveLog(Request(new Dictionary<string, string> { ["Logs"] = "A한😀" }), player);
        endpoint.ReceiveLog(Request(new Dictionary<string, string>()), player);

        Require(logger.Properties[0].TryGetValue("Utf8Bytes", out object? byteCount) && byteCount is 8,
            "The diagnostic log length did not count UTF-8 bytes.");
        Require(logger.Properties[1].TryGetValue("Utf8Bytes", out byteCount) && byteCount is 0,
            "An omitted log payload did not report zero bytes.");
        Require(logger.Messages.All(message => message.Contains("UTF-8 bytes", StringComparison.Ordinal)),
            "Diagnostic length units are ambiguous.");
    }

    private static async Task CheckCallbackResponsesAsync()
    {
        var endpoint = new LegacyDiagnosticEndpoint(new CapturingLogger());
        var player = new LegacyPlayerDocument { Id = CallerId };
        LegacyRequest request = Request(new Dictionary<string, string> { ["ReportedPlayerId"] = UntrustedText });
        JsonObject report = await ReadAsync(endpoint.ReportCheater(request, player));
        Require(report["PlayerID"]!.GetValue<string>() == UntrustedText,
            "Log redaction changed the Client's exact mandatory PlayerID echo.");

        LegacyRequest empty = Request(new Dictionary<string, string>());
        report = await ReadAsync(endpoint.ReportCheater(empty, player));
        Require(report.ContainsKey("PlayerID") && report["PlayerID"] == null,
            "A missing report target lost the mandatory null PlayerID key.");
        JsonObject firstLog = await ReadAsync(endpoint.ReceiveLog(empty, player));
        JsonObject secondLog = await ReadAsync(endpoint.ReceiveLog(empty, player));
        string logId = firstLog["LogId"]!.GetValue<string>();
        Require(Guid.TryParseExact(logId, "N", out _) && secondLog["LogId"]!.GetValue<string>() != logId,
            "The log callback lost its generated receipt identity.");

        await ReadAsync(endpoint.ReceiveError(empty, player));
        await ReadAsync(endpoint.ReceiveOfferShown(empty, player));
        await ReadAsync(endpoint.ReceiveArenaShown(empty, player));
    }

    private static LegacyRequest Request(IReadOnlyDictionary<string, string> fields)
    {
        var form = fields.ToDictionary(pair => pair.Key, pair => new StringValues(pair.Value));
        string action = ((int)DatabaseAction.SendLog).ToString(System.Globalization.CultureInfo.InvariantCulture);
        form.Add("requestId", action);
        var context = new DefaultHttpContext();
        context.Request.ContentType = "application/x-www-form-urlencoded";
        context.Request.Form = new FormCollection(form);
        if (!LegacyRequest.TryParse(context.Request, out LegacyRequest? request))
        {
            throw new InvalidOperationException("Diagnostic fixture could not parse its request.");
        }
        return request;
    }

    private static async Task<JsonObject> ReadAsync(IResult result)
    {
        var context = new DefaultHttpContext();
        await using var output = new MemoryStream();
        context.Response.Body = output;
        await result.ExecuteAsync(context);
        output.Position = 0;
        var payload = (JsonObject)(await JsonNode.ParseAsync(output))!;
        Require(context.Response.StatusCode == 200 && context.Response.Headers.CacheControl == "no-store" &&
                context.Response.ContentType == "application/json" &&
                payload["Result"]!.GetValue<int>() == (int)DatabaseResult.Success,
            "A diagnostic acknowledgement changed its HTTP or Client success contract.");
        return payload;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class CapturingLogger : ILogger<LegacyDiagnosticEndpoint>
    {
        public List<string> Messages { get; } = [];
        public List<Dictionary<string, object?>> Properties { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            Messages.Add(formatter(state, exception));
            Properties.Add(((IEnumerable<KeyValuePair<string, object?>>)state!).ToDictionary(pair => pair.Key,
                pair => pair.Value));
        }
    }
}
