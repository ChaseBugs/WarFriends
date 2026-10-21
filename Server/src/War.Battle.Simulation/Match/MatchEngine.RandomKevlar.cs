using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseRandomKevlar(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardRandomKevlar"))
            return "random-kevlar-not-selected";
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId))
            return "invalid-random-kevlar-request";
        if (cardReservations == null ||
            (armyCatalog == null && activeArmyEntities.Count > 0))
            return "random-kevlar-authority-unavailable";

        var eligible = activeArmyEntities.Values
            .Where(row => row.OwnerFraction == owner.Definition.Fraction && row.Health > 0)
            .Where(row => armyCatalog!.Families.Any(family =>
                family.UnitId == row.UnitId && family.IsSoldier))
            .ToList();
        int targetCount = Math.Min(3, eligible.Count);
        if (stateRevision > ulong.MaxValue - 1 - (ulong)targetCount ||
            armyEntityRevision > ulong.MaxValue - (ulong)targetCount ||
            events.Count >= MaximumRetainedEvents)
            return "event-backpressure";
        if (eligible.Any(row => !HasValidRandomKevlarTarget(row)))
            return "random-kevlar-authority-unavailable";

        var selected = SelectRandomKevlarTargets(eligible, armyChoice);

        var effect = new WarCardEffectRequest("CardRandomKevlar",
            Vector3.Zero, 0, 1, "RANDOMKEVLAR");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "random-kevlar-unavailable";
        foreach (var soldier in selected)
            RefillSoldierKevlar(soldier);
        return selected.Count == 0 ? "random-kevlar-no-target" : "random-kevlar-applied";
    }

    internal static IReadOnlyList<BattleArmyEntityState> SelectRandomKevlarTargets(
        IReadOnlyList<BattleArmyEntityState> eligible, Func<int, int> chooseIndex)
    {
        ArgumentNullException.ThrowIfNull(eligible);
        ArgumentNullException.ThrowIfNull(chooseIndex);

        // The Client retries duplicate Random.Range indexes. Drawing from
        // the remaining candidates has the same unique-target distribution
        // and guarantees termination with a deterministic host random source.
        var remaining = eligible.ToList();
        var selected = new List<BattleArmyEntityState>();
        int targetCount = Math.Min(3, remaining.Count);
        while (selected.Count < targetCount)
        {
            int index = chooseIndex(remaining.Count);
            if (index < 0 || index >= remaining.Count)
                throw new InvalidDataException("Army random source returned an invalid index.");
            selected.Add(remaining[index]);
            remaining.RemoveAt(index);
        }
        return selected;
    }

    private bool HasValidRandomKevlarTarget(BattleArmyEntityState soldier)
    {
        float maximum = soldier.MaxHealth * 0.2f;
        if (!float.IsFinite(maximum) || maximum <= 0 || maximum > 10_000_000)
            return false;
        if (soldier.SourceCardId.Length > 0)
        {
            var cardUnit = cardUnitCombat?.Find(soldier.EntityKey);
            return cardUnit != null && cardUnit.Health == soldier.Health &&
                cardUnit.Kevlar == soldier.Kevlar &&
                cardUnit.MaxKevlar == soldier.MaxKevlar;
        }
        return armyVitality.TryGetValue(soldier.EntityKey, out var vitality) &&
            vitality.Current == soldier.Health &&
            vitality.Maximum == soldier.MaxHealth &&
            vitality.Kevlar == soldier.Kevlar &&
            vitality.KevlarMaximum == soldier.MaxKevlar;
    }

    private void RefillSoldierKevlar(BattleArmyEntityState soldier)
    {
        float maximum = soldier.MaxHealth * 0.2f;
        if (soldier.SourceCardId.Length > 0)
        {
            var cardUnit = cardUnitCombat!.RefillKevlar(soldier.EntityKey, maximum) ??
                throw new InvalidDataException("Selected card soldier disappeared.");
            soldier.MaxKevlar = cardUnit.MaxKevlar;
            soldier.Kevlar = cardUnit.Kevlar;
        }
        else
        {
            var vitality = armyVitality[soldier.EntityKey];
            vitality.KevlarMaximum = maximum;
            vitality.Kevlar = maximum;
            soldier.MaxKevlar = maximum;
            soldier.Kevlar = maximum;
        }
        armyEntityRevision++;
        stateRevision++;
    }
}
