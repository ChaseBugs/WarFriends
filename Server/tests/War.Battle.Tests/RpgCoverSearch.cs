using War.BattleServer;

/// <summary>Remembers attempted firing covers for one crate while preserving source cover ordering.</summary>
internal sealed class RpgCoverSearch
{
    private readonly RecoveredBattleMap _map;
    private readonly HashSet<int> _attemptedCovers = new();
    private string _boxId = "";

    internal RpgCoverSearch(RecoveredBattleMap map)
    {
        _map = map;
    }

    internal CoverNode SelectNext(string boxId, int fraction, float targetZ)
    {
        if (_boxId != boxId)
        {
            _boxId = boxId;
            _attemptedCovers.Clear();
        }

        CoverNode selected = _map.Covers.Where(row => row.Fraction == fraction &&
                !_attemptedCovers.Contains(row.SourceIndex))
            .OrderBy(row => MathF.Abs(row.Position.Z - targetZ)).ThenBy(row => row.SourceIndex).FirstOrDefault()
            ?? throw new InvalidOperationException("No untried friendly RPG cover remains for this box.");
        _attemptedCovers.Add(selected.SourceIndex);
        return selected;
    }
}
