namespace War.BattleServer;

/// <summary>Preserves the source next-point order, exclusion and empty-list no-draw behavior.</summary>
internal static class GunslingerPointSelection
{
    internal static GunslingerPoint? SelectNext(IReadOnlyList<GunslingerPoint> points, GunslingerPoint current,
        Func<int, bool> isOccupied, Func<int, int> choose)
    {
        ArgumentNullException.ThrowIfNull(points);
        ArgumentNullException.ThrowIfNull(current);
        ArgumentNullException.ThrowIfNull(isOccupied);
        ArgumentNullException.ThrowIfNull(choose);
        var candidates = new List<GunslingerPoint>();
        foreach (GunslingerPoint point in points.OrderBy(point => point.Order))
        {
            if (point.Fraction == current.Fraction && point.ComponentFileId != current.ComponentFileId &&
                !isOccupied(point.ComponentFileId))
            {
                candidates.Add(point);
            }
        }

        if (candidates.Count == 0)
        {
            return null;
        }

        int index = choose(candidates.Count);
        if (index < 0 || index >= candidates.Count)
        {
            throw new InvalidDataException("Gunslinger point-change draw left the source collection.");
        }

        return candidates[index];
    }
}
