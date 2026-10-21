namespace War.BattleServer;

internal sealed partial class CardEnemyPointOccupancy
{
    internal IReadOnlyList<CardUnitInitialPoint> NextAssaulterPoints(ulong entityKey)
    {
        if (!assigned.TryGetValue(entityKey, out var current) ||
            current.ComponentType != "EnemyPointCorner" ||
            occupants.GetValueOrDefault(current.ComponentFileId) != entityKey)
        {
            throw new InvalidDataException("Assaulter point change lost its current reservation.");
        }

        return catalog.NextAssaulterPoints(map, current.Fraction, current.ComponentFileId,
            pointId => !occupants.ContainsKey(pointId));
    }

    internal void TransferAssaulter(ulong entityKey, CardUnitInitialPoint next)
    {
        ArgumentNullException.ThrowIfNull(next);
        if (!NextAssaulterPoints(entityKey).Contains(next))
        {
            throw new InvalidDataException("Assaulter point transfer is not source-eligible.");
        }

        CardUnitInitialPoint current = assigned[entityKey];
        // All identities are validated before this single-threaded reservation transfer.
        occupants.Remove(current.ComponentFileId);
        occupants.Add(next.ComponentFileId, entityKey);
        assigned[entityKey] = next;
    }
}
