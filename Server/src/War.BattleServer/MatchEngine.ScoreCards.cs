using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed record ScoreCardReceipt(string OwnerId, string SourceCardId, string Result);
    private readonly Dictionary<string, ScoreCardReceipt> scoreCardReceipts =
        new(StringComparer.Ordinal);

    private string UseScoreMultiplier(Player owner, string requestId, string sourceCardId)
    {
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-score-card-request";

        string cardClassId = sourceCardId switch
        {
            PvpScoreMultiplierState.StreakBoost => "CardScorestreakBooster",
            PvpScoreMultiplierState.CrateBlocker => "CardScoreStreakKiller",
            _ => ""
        };
        if (cardClassId.Length == 0)
            return "invalid-score-card-source";

        if (scoreCardReceipts.TryGetValue(requestId, out var previous))
            return previous.OwnerId == owner.Definition.PlayerId &&
                   previous.SourceCardId == sourceCardId
                ? previous.Result : "score-card-request-conflict";
        if (!HasSelectedCard(owner, cardClassId))
            return "score-card-not-selected";
        if (cardReservations == null || pvpBonusProgress == null ||
            players.Single(player => player != owner).Admitted != true)
            return "score-card-authority-unavailable";
        if (!pvpBonusProgress.CanUseScoreCard(owner.Definition.PlayerId, sourceCardId))
            return "score-card-already-active";
        if (events.Count >= MaximumRetainedEvents ||
            stateRevision == ulong.MaxValue || scoreCardReceipts.Count >= 4096)
            return "event-backpressure";

        // The recovered Cards assign 1.25 to their owner or zero to the
        // opponent for 60 seconds. The packet supplies neither value nor
        // target; inventory and selection come from the signed allocation.
        var effect = new WarCardEffectRequest(cardClassId, Vector3.Zero,
            PvpScoreMultiplierState.DurationSeconds, 0);
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "score-card-unavailable";

        pvpBonusProgress.ApplyConfirmedScoreCard(owner.Definition.PlayerId, sourceCardId);
        const string result = "score-card-active";
        scoreCardReceipts.Add(requestId, new(owner.Definition.PlayerId, sourceCardId, result));
        return result;
    }
}
