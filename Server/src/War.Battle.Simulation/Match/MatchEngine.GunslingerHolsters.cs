namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly HashSet<ulong> _gunslingerHolstered = [];
    private readonly Dictionary<ulong, ulong> _gunslingerHolsterDueTicks = [];

    private void AdvanceGunslingerHolsters()
    {
        foreach (var (entityKey, due) in _gunslingerHolsterDueTicks.OrderBy(row => row.Key).ToArray())
        {
            if (tick < due)
            {
                continue;
            }

            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.UnitId != "ID_UNIT-GUNSLINGER" || entity.SourceCardId.Length != 0)
            {
                throw new InvalidDataException("Gunslinger holster callback lost its live normal-unit owner.");
            }

            _gunslingerHolstered.Add(entityKey);
            _gunslingerHolsterDueTicks.Remove(entityKey);
        }
    }
}
