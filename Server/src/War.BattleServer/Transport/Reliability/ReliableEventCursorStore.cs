using System.Text.Json;

namespace War.BattleServer;

/// <summary>Persists reliable-event cursors with an atomic replace, so restart cannot widen replay authority.</summary>
public sealed class ReliableEventCursorStore
{
    private sealed record CursorDocument(ulong NextEventId, ulong Acknowledged);
    private readonly string path;

    public ReliableEventCursorStore(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Cursor path is required.", nameof(path));
        this.path = Path.GetFullPath(path);
    }

    public bool Exists => File.Exists(path);

    public void Save(ReliableEventWindow window)
    {
        if (window is null) throw new ArgumentNullException(nameof(window));
        var snapshot = window.Snapshot;
        var json = JsonSerializer.Serialize(new CursorDocument(snapshot.Next, snapshot.Acknowledged));
        var directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
        var temporary = path + ".tmp";
        File.WriteAllText(temporary, json);
        File.Move(temporary, path, true);
    }

    public ReliableEventWindow Load(int capacity = 64)
    {
        var window = new ReliableEventWindow(capacity);
        if (!File.Exists(path)) return window;
        CursorDocument? document;
        try { document = JsonSerializer.Deserialize<CursorDocument>(File.ReadAllText(path)); }
        catch (Exception ex) when (ex is JsonException or IOException or UnauthorizedAccessException)
        { throw new InvalidDataException("Reliable event cursor is unreadable.", ex); }
        if (document is null) throw new InvalidDataException("Reliable event cursor is empty.");
        window.Restore(document.NextEventId, document.Acknowledged);
        return window;
    }
}
