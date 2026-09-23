using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Bounded durable payload log for reliable client events.</summary>
public sealed class ReliableEventPayloadStore
{
    private sealed record EventDocument(ulong Sequence, string Kind, ulong EntityId, float X, float Y, float Z);
    private readonly string path;
    private readonly int capacity;
    private readonly List<ClientBattleEvent> events = [];

    public ReliableEventPayloadStore(string path, int capacity = 4096)
    {
        if (string.IsNullOrWhiteSpace(path) || capacity is < 1 or > 65_536)
            throw new ArgumentException("Invalid event log configuration.");
        this.path = Path.GetFullPath(path); this.capacity = capacity;
        LoadExisting();
    }

    public IReadOnlyList<ClientBattleEvent> ReplayAfter(ulong sequence, int maxEvents = 256)
    {
        if (maxEvents is < 1 or > 4096) throw new InvalidDataException("Invalid event replay bound.");
        if (!CanReplayAfter(sequence)) throw new InvalidDataException("Event cursor has expired; full snapshot required.");
        return events.Where(x => x.Sequence > sequence).Take(maxEvents).ToArray();
    }

    public ulong FirstRetainedSequence => events.Count == 0 ? 0 : events[0].Sequence;
    public ulong LastRetainedSequence => events.Count == 0 ? 0 : events[^1].Sequence;
    public bool CanReplayAfter(ulong sequence) => events.Count == 0 || sequence + 1 >= FirstRetainedSequence;

    public void Append(ClientBattleEvent value)
    {
        ClientBattleEventValidator.Validate(value);
        if (events.Count > 0 && value.Sequence <= events[^1].Sequence)
            throw new InvalidDataException("Event sequence is not monotonic.");
        events.Add(value);
        while (events.Count > capacity) events.RemoveAt(0);
        Persist();
    }

    private void LoadExisting()
    {
        if (!File.Exists(path)) return;
        EventDocument[]? rows;
        try { rows = JsonSerializer.Deserialize<EventDocument[]>(File.ReadAllText(path)); }
        catch (Exception ex) when (ex is JsonException or IOException or UnauthorizedAccessException)
        { throw new InvalidDataException("Reliable event payload log is unreadable.", ex); }
        if (rows is null || rows.Length > capacity) throw new InvalidDataException("Invalid reliable event payload log.");
        ulong previous = 0;
        foreach (var row in rows)
        {
            if (row is null) throw new InvalidDataException("Invalid reliable event payload row.");
            var value = new ClientBattleEvent(row.Sequence, row.Kind, row.EntityId, new Vector3(row.X, row.Y, row.Z));
            ClientBattleEventValidator.Validate(value);
            if (previous != 0 && value.Sequence <= previous) throw new InvalidDataException("Event payload sequence is not monotonic.");
            previous = value.Sequence; events.Add(value);
        }
    }

    private void Persist()
    {
        var rows = events.Select(x => new EventDocument(x.Sequence, x.Kind, x.EntityId,
            x.Position.X, x.Position.Y, x.Position.Z)).ToArray();
        var directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
        var temporary = path + ".tmp";
        File.WriteAllText(temporary, JsonSerializer.Serialize(rows));
        File.Move(temporary, path, true);
    }
}
