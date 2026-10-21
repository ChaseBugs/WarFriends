using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseBackstab(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardBackstab"))
            return "backstab-not-selected";
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId))
            return "invalid-backstab-request";
        if (cardReservations == null ||
            (armyCatalog == null && activeArmyEntities.Count > 0))
            return "backstab-authority-unavailable";
        if (events.Count >= MaximumRetainedEvents || stateRevision == ulong.MaxValue)
            return "event-backpressure";

        // EnemyController.canBeFreezed excludes vehicles, helicopters, and
        // machine-gun points. The source card still spends with no soldier.
        var targets = activeArmyEntities.Values
            .Where(row => row.OwnerFraction != owner.Definition.Fraction && row.Health > 0)
            .Where(row => armyCatalog!.Families.Any(family =>
                family.UnitId == row.UnitId && family.IsSoldier))
            .ToArray();
        if (targets.Any(row => !float.IsFinite(row.MaxHealth) ||
            row.MaxHealth <= 0 || row.MaxHealth > 10_000_000))
            return "backstab-authority-unavailable";

        var effect = new WarCardEffectRequest("CardBackstab", Vector3.Zero, 0, 1, "BACKSTAB");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "backstab-unavailable";
        if (targets.Length == 0)
            return "backstab-no-target";

        // CardBackstab uses float Random.Range(0, count - 1), followed by
        // Math.Round (midpoint-to-even), rather than integer Random.Range.
        double draw = NextArmyFloat() * (targets.Length - 1);
        int selectedIndex = (int)Math.Round(draw, MidpointRounding.ToEven);
        var target = targets[selectedIndex];
        ApplyArmyHostDamage(target.EntityKey, target.MaxHealth);
        return "backstab-applied";
    }
}
