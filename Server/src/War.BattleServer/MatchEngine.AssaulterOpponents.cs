namespace War.BattleServer;

internal enum AssaulterOpponentKind
{
    Entity,
    PlayerFallback,
    Unavailable
}

internal sealed record AssaulterOpponentSelection(AssaulterOpponentKind Kind, DroneTargetCandidate? Candidate);

public sealed partial class MatchEngine
{
    /// <summary>Selects a source opponent without treating missing entity provenance as player fallback.</summary>
    internal AssaulterOpponentSelection SelectAssaulterOpponent(ulong entityKey)
    {
        return SelectStationarySoldierOpponent(entityKey, "ID_UNIT-ASSAULT");
    }

    private AssaulterOpponentSelection SelectStationarySoldierOpponent(ulong entityKey, string expectedUnitId)
    {
        if (!activeArmyEntities.TryGetValue(entityKey, out var soldier) ||
            soldier.UnitId != expectedUnitId || soldier.SourceCardId.Length != 0)
        {
            throw new InvalidDataException("Stationary soldier target selection lost its normal source entity.");
        }

        IReadOnlyList<DroneTargetCandidate> registry = DroneTargetSnapshot();
        // A Decoy precedes every unit family, including a currently unresolved Mech.
        bool hasDecoy = registry.Any(candidate => candidate.Fraction != soldier.OwnerFraction &&
            candidate.Alive && candidate.Visible && candidate.IsDecoy);
        bool hasUnregisteredOpponent = activeArmyEntities.Values.Any(candidate =>
            candidate.OwnerFraction != soldier.OwnerFraction && !droneArmyTargets.ContainsKey(candidate.EntityKey));
        if (!hasDecoy && hasUnregisteredOpponent)
        {
            return new AssaulterOpponentSelection(AssaulterOpponentKind.Unavailable, null);
        }

        DroneTargetCandidate? selected = AssaulterTargetPolicy.Select(soldier.OwnerFraction, registry, armyChoice);
        return selected == null
            ? new AssaulterOpponentSelection(AssaulterOpponentKind.PlayerFallback, null)
            : new AssaulterOpponentSelection(AssaulterOpponentKind.Entity, selected);
    }
}
