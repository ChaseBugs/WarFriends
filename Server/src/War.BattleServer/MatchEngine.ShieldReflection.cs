using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseShieldReflection(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardShiedlsRefection"))
            return "shield-reflection-not-selected";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-shield-reflection-request";
        if (cardReservations == null || shields == null)
            return "shield-reflection-authority-unavailable";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        // CardShiedlsRefection.UseCard marks every allied cover Shield as
        // immortal for the recovered 15-second CardConstants duration.
        var effect = new WarCardEffectRequest("CardShiedlsRefection",
            Vector3.Zero, 15, 0, "REFLECTION");
        return TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect)
            ? "shield-reflection-active" : "shield-reflection-unavailable";
    }

    private bool ShieldReflectionActive(int fraction)
    {
        Player? owner = players.SingleOrDefault(player =>
            player.Definition.Fraction == fraction);
        return owner != null && cardEffects.HasActiveCard(owner.Definition.PlayerId,
            "CardShiedlsRefection");
    }
}
