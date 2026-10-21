using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseImmortal(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardSwiftImmortality"))
            return "immortal-not-selected";
        if (owner.Dead || owner.Definition.Combat == null)
            return "immortal-owner-unavailable";
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId))
            return "invalid-immortal-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        // Recovered SwiftImmortalityTime is eight seconds. The player cannot
        // supply a duration or make another player immortal through this call.
        var effect = new WarCardEffectRequest("CardSwiftImmortality",
            Vector3.Zero, 8, 0, "IMMORTAL");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "immortal-unavailable";
        return "immortal-active";
    }
}
