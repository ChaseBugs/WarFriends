using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float MaxHealthCardMultiplier = 1.1f;

    private string UseMaxHealth(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardHealthierMyself"))
            return "max-health-not-selected";
        if (owner.Dead || owner.Definition.Combat == null)
            return "max-health-owner-unavailable";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-max-health-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        // MainScene overrides CardHealthierMyself's C# default (1.15) with 1.1.
        // The recovered card increases maxHealth, then heals the exact increase.
        float oldMaximum = owner.MaximumHealth;
        float newMaximum = oldMaximum * MaxHealthCardMultiplier;
        float newHealth = Math.Min(owner.Health + (newMaximum - oldMaximum),
            newMaximum);
        if (!float.IsFinite(newMaximum) || newMaximum > 100_000_000 ||
            !float.IsFinite(newHealth) || owner.Health <= 0 ||
            owner.Health > oldMaximum)
            return "max-health-limit";

        var effect = new WarCardEffectRequest("CardHealthierMyself",
            Vector3.Zero, 0, 1, "MAXHEALTHINC");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "max-health-unavailable";

        owner.MaximumHealth = newMaximum;
        owner.Health = newHealth;
        owner.DamageRevision++;
        stateRevision++;
        return "max-health-increased";
    }
}
