namespace War.BattleServer;

public sealed class CoverOccupancyRegistry
{
    private readonly int capacity;
    private readonly Dictionary<int, string> owners = new();
    public CoverOccupancyRegistry(int capacity = 64)
    {
        if (capacity is < 1 or > 512) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }
    public int Count => owners.Count;
    public IReadOnlyList<(int CoverIndex,string PlayerId)> Snapshot() => owners
        .OrderBy(x=>x.Key).Select(x=>(x.Key,x.Value)).ToArray();
    public bool TryClaim(int coverIndex, string playerId)
    {
        if (coverIndex < 0 || coverIndex >= capacity || !Guid.TryParseExact(playerId, "N", out var parsed)) return false;
        var canonical=parsed.ToString("N");
        if (owners.TryGetValue(coverIndex, out var owner)) return owner == canonical;
        owners.Add(coverIndex, canonical); return true;
    }
    public bool Release(int coverIndex, string playerId)
    {
        return Guid.TryParseExact(playerId, "N", out var parsed) && owners.TryGetValue(coverIndex, out var owner) &&
            owner == parsed.ToString("N") && owners.Remove(coverIndex);
    }
    public int ReleasePlayer(string playerId)
    {
        if (!Guid.TryParseExact(playerId, "N", out var parsed)) return 0;
        var slots = owners.Where(x => x.Value == parsed.ToString("N")).Select(x => x.Key).ToArray();
        foreach (var slot in slots) owners.Remove(slot);
        return slots.Length;
    }
}
