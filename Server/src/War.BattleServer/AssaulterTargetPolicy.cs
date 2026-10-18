namespace War.BattleServer;

/// <summary>Selects an entity using SoldierBehaviourAssaulter's source priority and registry ordering.</summary>
internal static class AssaulterTargetPolicy
{
    private const int MaximumCandidates = 1000;
    private const int MaximumIdentityLength = 100;
    private const int RusherUnitType = 3;
    private static readonly int[] FallbackUnitTypes = [1, 3, 2, 0];

    internal static DroneTargetCandidate? Select(int fraction, IReadOnlyList<DroneTargetCandidate> registry,
        Func<int, int> choose)
    {
        ArgumentNullException.ThrowIfNull(choose);
        ValidateRegistry(fraction, registry);
        DroneTargetCandidate[] opponents = registry.Where(candidate =>
            candidate.Fraction != fraction && candidate.Alive && candidate.Visible).ToArray();
        DroneTargetCandidate[] decoys = opponents.Where(candidate => candidate.IsDecoy).ToArray();
        if (decoys.Length > 0)
        {
            return Choose(decoys, choose);
        }

        DroneTargetCandidate[] rushers = opponents.Where(candidate => candidate.UnitType == RusherUnitType).ToArray();
        if (rushers.Length > 0)
        {
            return Choose(rushers, choose);
        }

        // GetOpponents(anyUnit) concatenates all four groups before one draw.
        // It does not choose the first group that happens to contain an opponent.
        DroneTargetCandidate[] fallback = FallbackUnitTypes.SelectMany(unitType =>
            opponents.Where(candidate => candidate.UnitType == unitType)).ToArray();
        return fallback.Length == 0 ? null : Choose(fallback, choose);
    }

    private static DroneTargetCandidate Choose(IReadOnlyList<DroneTargetCandidate> candidates, Func<int, int> choose)
    {
        int index = choose(candidates.Count);
        if (index < 0 || index >= candidates.Count)
        {
            throw new InvalidDataException("Assaulter target draw left its source candidate range.");
        }

        return candidates[index];
    }

    private static void ValidateRegistry(int fraction, IReadOnlyList<DroneTargetCandidate> registry)
    {
        ArgumentNullException.ThrowIfNull(registry);
        if (fraction is not (1 or 2) || registry.Count > MaximumCandidates)
        {
            throw new InvalidDataException("Assaulter requires a playing fraction and bounded source registry.");
        }

        var identities = new HashSet<string>(StringComparer.Ordinal);
        foreach (DroneTargetCandidate candidate in registry)
        {
            if (candidate == null || string.IsNullOrEmpty(candidate.Id) ||
                candidate.Id.Length > MaximumIdentityLength ||
                candidate.Id.Any(char.IsControl) || !identities.Add(candidate.Id) ||
                candidate.Fraction is not (1 or 2) || candidate.UnitType is < 0 or > 3 ||
                !PlayerHitbox.Finite(candidate.Position))
            {
                throw new InvalidDataException("Assaulter opponent registry contains invalid source authority.");
            }
        }
    }
}
