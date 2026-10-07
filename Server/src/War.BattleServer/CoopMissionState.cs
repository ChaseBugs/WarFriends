namespace War.BattleServer;

/// <summary>Server-owned admission, wave, and failure state for one co-op mission.</summary>
public sealed class CoopMissionState
{
    private const int MaximumEvents = 4096;

    private readonly int totalWaves;
    private readonly HashSet<string> completedEvents = [];
    private readonly HashSet<string> participants = [];
    private readonly HashSet<string> ready = [];

    public int Wave { get; private set; } = 1;
    public int TotalWaves => totalWaves;
    public bool Started { get; private set; }
    public bool Failed { get; private set; }
    public bool Completed => !Failed && Wave > totalWaves;
    public ulong DeadlineTick { get; }
    public IReadOnlyCollection<string> Participants => participants.ToArray();

    public CoopMissionState(int totalWaves, ulong deadlineTick = 0)
    {
        if (totalWaves is < 1 or > 1000)
            throw new InvalidDataException("Invalid co-op wave count.");
        if (deadlineTick > 10_000_000)
            throw new InvalidDataException("Invalid co-op mission deadline.");

        this.totalWaves = totalWaves;
        DeadlineTick = deadlineTick;
    }

    public bool Admit(string playerId)
    {
        if (!IsCanonicalId(playerId) || Started || Failed || participants.Count >= 2)
            return false;

        return participants.Add(playerId);
    }

    public bool MarkReady(string playerId)
    {
        if (!participants.Contains(playerId) || Started || Failed)
            return false;

        ready.Add(playerId);
        if (participants.Count == 2 && ready.Count == 2)
            Started = true;
        return true;
    }

    public bool AdvanceWave(string eventId, bool success)
    {
        // A Client cannot create wave progress before both players are ready.
        // Canonical event IDs make a differently cased retry invalid.
        if (!Started || Failed || Completed || !IsCanonicalId(eventId) ||
            completedEvents.Count >= MaximumEvents || !completedEvents.Add(eventId))
            return false;

        if (!success)
        {
            Failed = true;
            return true;
        }

        Wave = checked(Wave + 1);
        return true;
    }

    public bool AdvanceClock(ulong tick)
    {
        if (!Started || Failed || Completed || DeadlineTick == 0 || tick < DeadlineTick)
            return false;

        Failed = true;
        return true;
    }

    public bool Leave(string playerId)
    {
        if (!participants.Remove(playerId))
            return false;

        ready.Remove(playerId);
        if (Started && !Completed)
            Failed = true;
        return true;
    }

    public void Validate()
    {
        if (Wave < 1 || Wave > totalWaves + 1 ||
            participants.Count > 2 || ready.Count > participants.Count ||
            participants.Any(id => !IsCanonicalId(id)) ||
            ready.Any(id => !participants.Contains(id)) ||
            completedEvents.Count > MaximumEvents ||
            completedEvents.Any(id => !IsCanonicalId(id)) ||
            (!Started && (Failed || Completed)) ||
            (Started && !Failed && !Completed &&
             (participants.Count != 2 || ready.Count != 2)))
            throw new InvalidDataException("Invalid co-op mission state.");
    }

    private static bool IsCanonicalId(string? value)
    {
        return Guid.TryParseExact(value, "N", out Guid parsed) &&
            value == parsed.ToString("N");
    }
}
