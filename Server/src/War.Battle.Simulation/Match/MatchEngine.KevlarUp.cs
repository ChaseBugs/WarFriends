using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseKevlarUp(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardKevlarUp"))
            return "kevlar-up-not-selected";
        if (owner.Dead || owner.Definition.Combat == null)
            return "kevlar-up-owner-unavailable";
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId))
            return "invalid-kevlar-up-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        float maximum;
        try { maximum = PlayerKevlar.CardMaximum(owner.MaximumHealth); }
        catch (InvalidDataException) { return "kevlar-up-owner-unavailable"; }

        // CardKevlarUp calls PlayerController.SetUpKevlar, which refills a
        // separate DestroyableObject to 20% of the current player maximum.
        var effect = new WarCardEffectRequest("CardKevlarUp",
            Vector3.Zero, 0, 1, "KEVLARUP");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "kevlar-up-unavailable";

        owner.KevlarMaximum = maximum;
        owner.KevlarHealth = maximum;
        owner.DamageRevision++;
        stateRevision++;
        return "kevlar-up-applied";
    }
}
