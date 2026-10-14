using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed record QueuedBonusCardReceipt(string OwnerId, string SourceCardId);
    private readonly Dictionary<string, QueuedBonusCardReceipt> queuedBonusCardReceipts =
        new(StringComparer.Ordinal);

    private string QueueBonusCard(Player owner, string requestId, string sourceCardId)
    {
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-bonus-card-request";
        if (pvpBonusPlanner == null || cardReservations == null)
            return "bonus-card-authority-unavailable";

        int sourceIndex;
        try { sourceIndex = pvpBonusPlanner.SourceIndexForQueuedCard(sourceCardId); }
        catch (InvalidDataException) { return "invalid-bonus-card-source"; }

        if (queuedBonusCardReceipts.TryGetValue(requestId, out var previous))
            return previous.OwnerId == owner.Definition.PlayerId &&
                   previous.SourceCardId == sourceCardId
                ? "bonus-card-queued" : "bonus-card-request-conflict";
        if (!owner.CardsSelected ||
            !owner.SelectedCards.Contains(sourceCardId, StringComparer.Ordinal))
            return "bonus-card-not-selected";
        if (!cardReservations.HasInventory(owner.Definition.PlayerId, sourceCardId))
            return "bonus-card-authority-unavailable";
        if (events.Count >= MaximumRetainedEvents ||
            stateRevision == ulong.MaxValue || queuedBonusCardReceipts.Count >= 4096)
            return "event-backpressure";

        // CardIncreaseBonusChance queues the IndexOf(forBonus) result. The
        // Client cannot choose that index: MainScene's prefab reference and
        // the reviewed bonus catalog resolve it on the host.
        var effect = new WarCardEffectRequest("CardIncreaseBonusChance",
            Vector3.Zero, 0f, 0, sourceCardId);
        bool queued;
        try
        {
            queued = pvpBonusPlanner.TryEnqueueCardBonus(requestId,
                owner.Definition.PlayerId, sourceIndex, () =>
                    TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect));
        }
        catch (InvalidOperationException) { return "bonus-queue-full"; }
        catch (InvalidDataException) { return "bonus-card-unavailable"; }
        if (!queued) return "bonus-card-unavailable";

        queuedBonusCardReceipts.Add(requestId,
            new(owner.Definition.PlayerId, sourceCardId));
        return "bonus-card-queued";
    }
}
