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

    internal CardUnitInitialPoint? TryAssignSniper(ulong entityKey,
        int fraction, Vector3 soldierPosition, Vector3 opponentPosition)
    {
        if (entityKey == 0 || fraction is not (1 or 2) ||
            (int)(entityKey >> 32) != fraction ||
            !PlayerHitbox.Finite(soldierPosition) ||
            !PlayerHitbox.Finite(opponentPosition))
            throw new InvalidDataException("Card Sniper has no valid point identity.");
        if (assigned.TryGetValue(entityKey, out var existing))
        {
            if (existing.Fraction != fraction ||
                !AcceptsPoint("ELITESNIPER", existing.ComponentType))
                throw new InvalidDataException("Card Sniper changed its reserved point.");
            return existing;
        }

        CardUnitInitialPoint? point = catalog.SelectSniper(map, fraction,
            soldierPosition, opponentPosition,
            pointFileId => !occupants.ContainsKey(pointFileId));
        if (point == null)
            return null;
        occupants.Add(point.ComponentFileId, entityKey);
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

    internal IReadOnlyList<CardUnitInitialPoint> NextFreePoints(
        ulong entityKey, string sourceCardId, int fraction)
    {
        if (!assigned.TryGetValue(entityKey, out var current) ||
            current.Fraction != fraction ||
            !AcceptsPoint(sourceCardId, current.ComponentType))
            throw new InvalidDataException("Card soldier has no current point to leave.");
        return catalog.NextFreePoints(map, sourceCardId, fraction,
            current.ComponentFileId,
            pointFileId => !occupants.ContainsKey(pointFileId));
    }

    internal IReadOnlyList<CardUnitInitialPoint> NextSniperPoints(
        ulong entityKey, int fraction, Vector3 opponentPosition)
    {
        if (!assigned.TryGetValue(entityKey, out var current) ||
            current.Fraction != fraction ||
            !AcceptsPoint("ELITESNIPER", current.ComponentType))
            throw new InvalidDataException("Card Sniper has no point to leave.");
        return catalog.NextSniperPoints(map, fraction,
            current.ComponentFileId, opponentPosition,
            pointFileId => !occupants.ContainsKey(pointFileId));
    }

    internal void Transfer(ulong entityKey, string sourceCardId,
        CardUnitInitialPoint next, Vector3? opponentPosition = null)
    {
        ArgumentNullException.ThrowIfNull(next);
        if (sourceCardId is not ("ELITEPARA" or "ELITESNIPER"))
            throw new InvalidDataException("Card soldier cannot transfer this point type.");
        if (!assigned.TryGetValue(entityKey, out var current) ||
            current.ComponentFileId == next.ComponentFileId ||
            current.Fraction != next.Fraction ||
            !AcceptsPoint(sourceCardId, current.ComponentType) ||
            !AcceptsPoint(sourceCardId, next.ComponentType) ||
            !occupants.TryGetValue(current.ComponentFileId, out ulong owner) ||
            owner != entityKey || occupants.ContainsKey(next.ComponentFileId))
            throw new InvalidDataException("Card point transfer lost its source reservation.");

        IReadOnlyList<CardUnitInitialPoint> eligible = sourceCardId == "ELITEPARA"
            ? catalog.NextFreePoints(map, sourceCardId, current.Fraction,
                current.ComponentFileId, _ => true)
            : catalog.NextSniperPoints(map, current.Fraction,
                current.ComponentFileId, opponentPosition ??
                    throw new InvalidDataException("Sniper transfer lost its opponent pose."),
                _ => true);
        if (!eligible.Any(point => point.ComponentFileId == next.ComponentFileId))
            throw new InvalidDataException("Card point transfer is not source-eligible.");

        // The match loop is single-threaded. Check both identities before
        // changing either map, then move the reservation as one operation.
        occupants.Remove(current.ComponentFileId);
        occupants.Add(next.ComponentFileId, entityKey);
        assigned[entityKey] = next;
    }

    private static bool AcceptsPoint(string sourceCardId, string pointType)
    {
        if (sourceCardId == "ELITESWAT")
            return pointType == "EnemyPointSwat";
        if (sourceCardId is "ELITEPARA" or "BIGROCKET" or "GREATGRENADIER")
            return pointType is "EnemyPointCorner" or "EnemyPointHiding";
        if (sourceCardId == "ELITESNIPER")
            return pointType is "EnemyPointCorner" or "EnemyPointHiding";
        return false;
    }
}
