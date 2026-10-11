using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseBulletSponge(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardBulletSponge"))
            return "bullet-sponge-not-selected";
        if (owner.Dead || owner.Definition.Combat == null)
            return "bullet-sponge-owner-unavailable";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-bullet-sponge-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        // CardBulletSponge sets chanceToNoDamage to 0.05 for 60 seconds.
        // The packet carries neither a chance nor a victim assertion.
        var effect = new WarCardEffectRequest("CardBulletSponge",
            Vector3.Zero, 60, 0, "BULLETHARMLESS");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "bullet-sponge-unavailable";
        return "bullet-sponge-active";
    }

    private PlayerCombatManifest CombatFor(Player player)
    {
        PlayerCombatManifest combat = player.CurrentCombat ??
            throw new InvalidDataException("Player combat authority is missing.");
        if (cardEffects.HasActiveCard(player.Definition.PlayerId, "CardBulletSponge"))
            combat = combat with { NoDamageChance = 0.05f };
        if (cardEffects.HasActiveCard(player.Definition.PlayerId,
                "CardSwiftImmortality"))
            combat = combat with { Immortal = true };
        return combat;
    }
}
