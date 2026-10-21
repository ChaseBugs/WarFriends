using System.Net;

namespace War.BattleServer;

public enum SenderAdmission
{
    Allowed,
    RateLimited,
    CapacityReached
}

/// <summary>Keeps the UDP rate table bounded while allowing old endpoints to leave.</summary>
public sealed class SenderEndpointRegistry
{
    private sealed class Entry
    {
        public SenderRateWindow Rate { get; } = new();
        public ulong LastSeenTick { get; set; }
        public bool KnownMatchEndpoint { get; set; }
    }

    private readonly Dictionary<IPEndPoint, Entry> entries = [];
    private readonly int capacity;
    private readonly ulong idleTicks;
    private ulong? lastSweepTick;

    public SenderEndpointRegistry(int capacity = 4096, ulong idleTicks = 900)
    {
        if (capacity < 1 || idleTicks < 1)
            throw new InvalidDataException("Invalid sender endpoint limits.");
        this.capacity = capacity;
        this.idleTicks = idleTicks;
    }

    public int Count => entries.Count;

    public void SetKnownMatchEndpoints(IEnumerable<IPEndPoint> endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        var known = endpoints.ToHashSet();
        foreach ((IPEndPoint endpoint, Entry entry) in entries)
            entry.KnownMatchEndpoint = known.Contains(endpoint);
    }

    public SenderAdmission Admit(IPEndPoint endpoint, ulong tick,
        bool knownMatchEndpoint = false)
    {
        ArgumentNullException.ThrowIfNull(endpoint);

        if (!entries.TryGetValue(endpoint, out Entry? entry))
        {
            if (entries.Count == capacity)
                RemoveIdleEntries(tick);
            if (entries.Count == capacity)
            {
                if (!knownMatchEndpoint)
                    return SenderAdmission.CapacityReached;

                // A burst of unowned source endpoints must not lock a known
                // match participant out of the bounded rate table. Every
                // admitted endpoint still gets a fresh per-sender rate window.
                IPEndPoint oldest = entries
                    .OrderBy(pair => pair.Value.KnownMatchEndpoint)
                    .ThenBy(pair => pair.Value.LastSeenTick)
                    .First().Key;
                entries.Remove(oldest);
            }

            entry = new Entry();
            entries.Add(endpoint, entry);
        }

        if (tick < entry.LastSeenTick)
            throw new InvalidDataException("Sender tick moved backwards.");
        entry.LastSeenTick = tick;
        if (knownMatchEndpoint)
            entry.KnownMatchEndpoint = true;
        return entry.Rate.Allow(tick)
            ? SenderAdmission.Allowed
            : SenderAdmission.RateLimited;
    }

    private void RemoveIdleEntries(ulong tick)
    {
        // Many new endpoints may arrive during one simulation tick. Scan the
        // bounded table once, then reject the rest at constant cost.
        if (lastSweepTick == tick)
            return;
        lastSweepTick = tick;
        foreach (IPEndPoint endpoint in entries
            .Where(pair => tick >= pair.Value.LastSeenTick &&
                tick - pair.Value.LastSeenTick >= idleTicks)
            .Select(pair => pair.Key).ToArray())
            entries.Remove(endpoint);
    }
}
