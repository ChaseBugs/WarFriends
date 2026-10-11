using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Owns card-soldier EnemyPoints separately from ordinary shield-linked
/// Rusher slots. A point remains occupied until its soldier dies or leaves it.
/// </summary>
internal sealed class CardEnemyPointOccupancy
{
    private readonly CardUnitInitialPointCatalog catalog;
    private readonly RecoveredBattleMap map;
    private readonly Dictionary<int, ulong> occupants = [];
    private readonly Dictionary<ulong, CardUnitInitialPoint> assigned = [];

    internal CardEnemyPointOccupancy(CardUnitInitialPointCatalog catalog,
        RecoveredBattleMap map)
    {
        this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        this.map = map ?? throw new ArgumentNullException(nameof(map));
    }

    internal CardUnitInitialPoint? Find(ulong entityKey) =>
        assigned.GetValueOrDefault(entityKey);

    internal ulong? Occupant(int pointFileId) =>
        occupants.TryGetValue(pointFileId, out ulong entityKey) ? entityKey : null;

    internal CardUnitInitialPoint? TryAssign(ulong entityKey, string sourceCardId,
        int fraction, Vector3 position)
    {
        if (entityKey == 0 || fraction is not (1 or 2) ||
            (int)(entityKey >> 32) != fraction || !PlayerHitbox.Finite(position))
            throw new InvalidDataException("Card soldier has no valid point identity.");
        if (assigned.TryGetValue(entityKey, out CardUnitInitialPoint? existing))
        {
            if (existing.Fraction != fraction ||
                !AcceptsPoint(sourceCardId, existing.ComponentType))
                throw new InvalidDataException("Card soldier changed its reserved point identity.");
            return existing;
        }

        CardUnitInitialPoint? point = catalog.Select(map, sourceCardId, fraction,
            position, pointFileId => !occupants.ContainsKey(pointFileId));
        if (point == null)
            return null;
        if (!occupants.TryAdd(point.ComponentFileId, entityKey))
            throw new InvalidDataException("Card enemy point was occupied during assignment.");
        assigned.Add(entityKey, point);
        return point;
    }

    internal bool Release(ulong entityKey)
    {
        if (!assigned.TryGetValue(entityKey, out CardUnitInitialPoint? point))
            return false;
        if (!occupants.TryGetValue(point.ComponentFileId, out ulong occupant) ||
            occupant != entityKey || !occupants.Remove(point.ComponentFileId) ||
            !assigned.Remove(entityKey))
            throw new InvalidDataException("Card enemy point lost its soldier owner.");
        return true;
    }

    private static bool AcceptsPoint(string sourceCardId, string pointType)
    {
        if (sourceCardId == "ELITESWAT")
            return pointType == "EnemyPointSwat";
        if (sourceCardId == "ELITEPARA")
            return pointType is "EnemyPointCorner" or "EnemyPointHiding";
        return false;
    }
}
