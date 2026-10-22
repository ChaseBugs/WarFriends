using System.Text.Json.Nodes;
using System.Text.Json;
using War.Backend.Legacy.DogTags;
using War.Backend.Legacy.Time;
using War.Persistence;
using War.Persistence.Legacy.Progression;

namespace War.Backend.Legacy.Progression;

/// <summary>Applies pending buffers before projecting committed state with one validated boot clock.</summary>
public sealed class LegacyPlayerDataEndpoint
{
    private readonly LegacyBufferProcessor _buffers;
    private readonly Func<LegacyPlayerDocument, int, JsonObject> _project;
    private readonly ILogger<LegacyPlayerDataEndpoint> _logger;
    private readonly TimeProvider _clock;
    private readonly OfflineBotSyncService? _offlineBots;

    public LegacyPlayerDataEndpoint(
        LegacyBufferProcessor buffers,
        Func<LegacyPlayerDocument, int, JsonObject> project,
        ILogger<LegacyPlayerDataEndpoint> logger,
        TimeProvider? clock = null,
        OfflineBotSyncService? offlineBots = null)
    {
        _buffers = buffers;
        _project = project;
        _logger = logger;
        _clock = clock ?? TimeProvider.System;
        _offlineBots = offlineBots;
    }

    /// <summary>Projects the post-buffer account and preserves the recovered mandatory boot fields.</summary>
    public async Task<IResult> ReadAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        IReadOnlyList<ParsedBuffer> pending;
        try
        {
            pending = LegacyBufferParser.ParseBuffers(request.Field("Buffers"));
        }
        catch (JsonException)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }

        try
        {
            OfflineBotJournal? journal = null;
            if (request.HasField("OfflineBotJournal"))
            {
                if (_offlineBots == null)
                    throw new InvalidDataException("Offline progress import requires recovered content.");
                journal = OfflineBotJournal.Parse(request.SingleField("OfflineBotJournal")
                    ?? throw new InvalidDataException("Ambiguous offline journal."));
                player = await _offlineBots.MergeAsync(player, journal, cancellationToken);
            }
            foreach (ParsedBuffer buffer in pending)
            {
                AppliedLegacyBuffer applied = await _buffers.ApplyAsync(player, buffer, cancellationToken);
                player = applied.Player;
            }

            int now = LegacyClientTime.Read(_clock.GetUtcNow().ToUnixTimeSeconds());
            var body = new JsonObject
            {
                ["Time"] = now,
                ["PlayerData"] = _project(player, now),
                ["Skill"] = player.Skill,
                ["MedalsBalance"] = player.MedalsBalance,
                ["PlacementMatchesRequired"] = player.PlacementMatchesRequired
            };
            if (_offlineBots != null) body["OfflineBotPolicy"] = _offlineBots.DescribePolicy();
            if (journal != null)
            {
                body["OfflineBotAck"] = new JsonObject
                {
                    ["Stream"] = journal.Stream,
                    ["Sequence"] = player.OfflineBotStreams[journal.Stream]
                };
            }
            if (player.LeagueId.Length > 0)
            {
                body["LeagueId"] = player.LeagueId;
            }

            if (player.BeginnersLeague > 0)
            {
                body["BeginnersLeague"] = player.BeginnersLeague;
            }

            return LegacyResponse.Json(DatabaseResult.Success, body);
        }
        catch (Exception exception) when (exception is InvalidDataException or JsonException or OverflowException)
        {
            _logger.LogError(exception, "Refused invalid legacy boot authority.");
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
    }
}
