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
        if (coverIndex < 0 || coverIndex >= capacity || !War.Shared.CanonicalGuid.IsCanonical(playerId))
        {
            return false;
        }
        if (owners.TryGetValue(coverIndex, out var owner))
        {
            return owner == playerId;
        }
        owners.Add(coverIndex, playerId);
        return true;
    }
    public bool Release(int coverIndex, string playerId)
    {
        return War.Shared.CanonicalGuid.IsCanonical(playerId) && owners.TryGetValue(coverIndex, out var owner) &&
            owner == playerId && owners.Remove(coverIndex);
    }
    public int ReleasePlayer(string playerId)
    {
        if (!War.Shared.CanonicalGuid.IsCanonical(playerId))
        {
            return 0;
        }
        var slots = owners.Where(x => x.Value == playerId).Select(x => x.Key).ToArray();
        foreach (var slot in slots) owners.Remove(slot);
        return slots.Length;
    }
}
