namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>
    /// Projects the mechanical army roots already owned by this match into
    /// the Client's GameShootableEntity type order. This is a read-only input
    /// for the pending Sabotage card; it does not spend a card or deal damage.
    /// </summary>
    internal IReadOnlyList<SabotageTargetPolicy.Candidate>
        SabotageMechanicalCandidates()
    {
        var registrationOrders = new Dictionary<string, int>(StringComparer.Ordinal);
        var candidates = new List<SabotageTargetPolicy.Candidate>();

        // Each of these recovered mechanical prefabs has one enabled,
        // visible main GameShootableEntity on its root. A source HeavyTurret
        // is a distinct class from Turret and must not enter this list.
        foreach (var army in activeArmyEntities.Values
            .OrderBy(entity => entity.SpawnTick)
            .ThenBy(entity => entity.EntityKey))
        {
            string? sourceType = SabotageTargetPolicy.SourceTypeForArmyUnit(
                army.UnitId);
            if (sourceType == null)
                continue;

            int registrationOrder = registrationOrders.GetValueOrDefault(sourceType);
            registrationOrders[sourceType] = checked(registrationOrder + 1);
            candidates.Add(new SabotageTargetPolicy.Candidate(
                sourceType, army.EntityKey, 0, registrationOrder,
                army.OwnerFraction, true, army.Health > 0f, true, true,
                army.SpawnTick, army.MaxHealth));
        }

        return candidates;
    }
}
