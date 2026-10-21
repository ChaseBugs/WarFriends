using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using War.Backend.Legacy;
using War.Persistence;
using War.Persistence.Battles.Settlement;

namespace War.Backend.Features.Battle.Settlement;

/// <summary>Adapts action 62 while keeping all submitted outcome/reward fields outside authority.</summary>
public sealed class BattleSettlementService
{
    private readonly BattleResultStore _results;
    private readonly TimeProvider _clock;

    public BattleSettlementService(BattleResultStore results, TimeProvider clock)
    {
        _results = results;
        _clock = clock;
    }

    public async Task<IResult> ExecuteAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        string? matchId = request.SingleField("BattleId");
        if (!Regex.IsMatch(matchId ?? "", "\\Am[0-9a-f]{32}\\z"))
        {
            return LegacyResponse.Failure(DatabaseResult.GameDidntExist);
        }

        DateTime now = _clock.GetUtcNow().UtcDateTime;
        try
        {
            var operation = new BattleSettlementRequest(matchId!, player.Id, player.SessionHash, now);
            string? response = await _results.SettleAsync(operation,
                context => BattleSettlementCalculator.Calculate(context, now), cancellationToken);
            if (response == null)
            {
                // The Worker outbox can arrive after the Client callback. The recovered parser offers retry for this code.
                return LegacyResponse.Failure(DatabaseResult.ThroughputExceededException);
            }
            return LegacyResponse.Json(DatabaseResult.Success, JsonNode.Parse(response)!.AsObject());
        }
        catch (Exception error) when (error is InvalidDataException or JsonException or OverflowException)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
    }
}
