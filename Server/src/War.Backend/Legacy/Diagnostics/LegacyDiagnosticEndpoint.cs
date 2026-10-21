using System.Text;
using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy.Diagnostics;

/// <summary>Receives diagnostics without granting gameplay, offer, provider or Arena authority.</summary>
public sealed class LegacyDiagnosticEndpoint
{
    private readonly ILogger<LegacyDiagnosticEndpoint> _logger;

    public LegacyDiagnosticEndpoint(ILogger<LegacyDiagnosticEndpoint> logger)
    {
        _logger = logger;
    }

    public IResult ReportCheater(LegacyRequest request, LegacyPlayerDocument player)
    {
        _logger.LogWarning(
            "Legacy cheater report from player {PlayerId}: target {TargetUtf8Bytes}, type {TypeUtf8Bytes} UTF-8 bytes.",
            player.Id, ByteCount(request, "ReportedPlayerId"), ByteCount(request, "ReportType"));
        // OnReportCheater indexes PlayerID with this exact capitalization, even for a missing target.
        return LegacyResponse.Json(DatabaseResult.Success,
            new JsonObject { ["PlayerID"] = request.Field("ReportedPlayerId") });
    }

    public IResult ReceiveLog(LegacyRequest request, LegacyPlayerDocument player)
    {
        _logger.LogInformation("Legacy client log received from player {PlayerId} ({Utf8Bytes} UTF-8 bytes).",
            player.Id, ByteCount(request, "Logs"));
        // OnSendLog needs LogId to stop retries. Client log bodies are never persisted here.
        return LegacyResponse.Json(DatabaseResult.Success,
            new JsonObject { ["LogId"] = Guid.NewGuid().ToString("N") });
    }

    public IResult ReceiveCrashReport(LegacyPlayerDocument player)
    {
        _logger.LogInformation("Legacy crash report received from player {PlayerId}.", player.Id);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    public IResult ReceiveError(LegacyRequest request, LegacyPlayerDocument player)
    {
        // OnWebRequestError sends this only for non-localhost endpoints; there is no response parser case.
        // DbAction can include a URL and the exception can include request details. Do not log either text.
        _logger.LogWarning(
            "Legacy client error from player {PlayerId}: action {ActionUtf8Bytes}, error {ErrorUtf8Bytes} UTF-8 bytes.",
            player.Id, ByteCount(request, "DbAction"), ByteCount(request, "ExceptionMessage"));
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    public IResult ReceiveAnalytics(LegacyPlayerDocument player)
    {
        // PlayerAnalytics.GetUpdates is an unverified delta, not the complete PlayerAnalyticsData blob.
        // Acknowledgement must not merge that payload into durable analytics authority.
        _logger.LogInformation("Legacy analytics update received from player {PlayerId}.", player.Id);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    public IResult ReceiveFuseConfiguration(LegacyPlayerDocument player)
    {
        // The Client only logs the response. Retired Fuse configuration is not gameplay state.
        _logger.LogInformation("Legacy Fuse configuration received from player {PlayerId}.", player.Id);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    public IResult ReceiveOfferShown(LegacyRequest request, LegacyPlayerDocument player)
    {
        // ShowedSavedOnServer reads no response fields. Actual offer purchase remains closed.
        _logger.LogInformation("Legacy offer-shown list from player {PlayerId} ({Utf8Bytes} UTF-8 bytes).",
            player.Id, ByteCount(request, "showedOffers"));
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    public IResult ReceiveArenaShown(LegacyRequest request, LegacyPlayerDocument player)
    {
        // WarArenaShownRequest changes only local presentation. This does not enter or settle an Arena.
        _logger.LogInformation("Legacy Arena-shown receipt from player {PlayerId} ({Utf8Bytes} UTF-8 bytes).",
            player.Id, ByteCount(request, "ArenaId"));
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    public static IResult Test()
    {
        // OnTest indexes the Test field unconditionally and logs its value.
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Test"] = true });
    }

    private static int ByteCount(LegacyRequest request, string field)
    {
        // This is the decoded field's UTF-8 size, not its URL-encoded HTTP wire size.
        return Encoding.UTF8.GetByteCount(request.Field(field) ?? "");
    }
}
