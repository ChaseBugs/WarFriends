namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, MortarIndicatorRuntime> _mortarIndicators = [];

    /// <summary>Copies visible warnings, including a dead shooter's still-running world warning.</summary>
    internal IReadOnlyList<MortarIndicatorObservation> MortarIndicators()
    {
        var observations = new List<MortarIndicatorObservation>();
        foreach (var entry in _mortarIndicators.OrderBy(entry => entry.Key))
        {
            MortarIndicatorObservation? observation = entry.Value.Observe();
            if (observation != null)
            {
                observations.Add(observation);
            }
        }
        return observations.ToArray();
    }

    internal int MortarIndicatorHistoryCount => _mortarIndicators.Count;

    private void BeginMortarIndicator(MortarMissileLaunch launch)
    {
        if (!activeArmyEntities.TryGetValue(launch.SoldierEntityKey, out var actor) ||
            actor.UnitId != "ID_UNIT-MORTAR" || actor.SourceCardId.Length != 0)
        {
            throw new InvalidDataException("Mortar warning requires its live ordinary source weapon.");
        }
        if (!_mortarIndicators.TryGetValue(actor.EntityKey, out MortarIndicatorRuntime? indicator))
        {
            indicator = new MortarIndicatorRuntime(actor.EntityKey, actor.OwnerPlayerId,
                actor.OwnerFraction, launch.LaunchTick);
            _mortarIndicators.Add(actor.EntityKey, indicator);
        }
        indicator.BeginLaunch(launch);
    }

    private void AdvanceMortarIndicators()
    {
        foreach (var (entityKey, indicator) in _mortarIndicators.ToArray())
        {
            indicator.Advance(tick);
            // OnInstancied hides a pooled indicator. A dead weapon needs no hidden reuse history.
            // Visible world warnings remain independent of both the missile and the soldier roster.
            if (!indicator.IsVisible && !activeArmyEntities.ContainsKey(entityKey))
            {
                _mortarIndicators.Remove(entityKey);
            }
        }
    }
}
