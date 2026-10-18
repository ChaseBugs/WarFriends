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
        if (!activeArmyEntities.TryGetValue(entityKey, out var assaulter) ||
            assaulter.UnitId != "ID_UNIT-ASSAULT" || assaulter.SourceCardId.Length != 0)
        {
            throw new InvalidDataException("Assaulter target selection lost its normal source entity.");
        }

        IReadOnlyList<DroneTargetCandidate> registry = DroneTargetSnapshot();
        // A Decoy precedes every unit family, including a currently unresolved Mech.
        bool hasDecoy = registry.Any(candidate => candidate.Fraction != assaulter.OwnerFraction &&
            candidate.Alive && candidate.Visible && candidate.IsDecoy);
        bool hasUnregisteredOpponent = activeArmyEntities.Values.Any(candidate =>
            candidate.OwnerFraction != assaulter.OwnerFraction && !droneArmyTargets.ContainsKey(candidate.EntityKey));
        if (!hasDecoy && hasUnregisteredOpponent)
        {
            return new AssaulterOpponentSelection(AssaulterOpponentKind.Unavailable, null);
        }

        DroneTargetCandidate? selected = AssaulterTargetPolicy.Select(assaulter.OwnerFraction, registry, armyChoice);
        return selected == null
            ? new AssaulterOpponentSelection(AssaulterOpponentKind.PlayerFallback, null)
            : new AssaulterOpponentSelection(AssaulterOpponentKind.Entity, selected);
    }
}
