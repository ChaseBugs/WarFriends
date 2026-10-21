namespace War.BattleServer;

/// <summary>Immutable, server-provisioned buddy-card ownership used by prebattle selection.</summary>
public sealed class BattleBuddySelectionState
{
    private readonly IReadOnlyDictionary<string, IReadOnlySet<string>> owned;
    private readonly Dictionary<string, IReadOnlyList<string>> selected = new(StringComparer.Ordinal);

    public BattleBuddySelectionState(IEnumerable<(string PlayerId, IEnumerable<string> BuddyIds)> provisioned)
    {
        ArgumentNullException.ThrowIfNull(provisioned);
        var map = new Dictionary<string, IReadOnlySet<string>>(StringComparer.Ordinal);
        foreach (var (playerId, ids) in provisioned)
        {
            if (string.IsNullOrWhiteSpace(playerId) || map.ContainsKey(playerId))
                throw new InvalidDataException("Duplicate or empty buddy ownership player.");
            var set = new HashSet<string>(StringComparer.Ordinal);
            foreach (var id in ids ?? throw new InvalidDataException("Missing buddy ownership."))
            {
                if (string.IsNullOrWhiteSpace(id) || id.Length > 128 || id.Any(char.IsControl) || !set.Add(id))
                    throw new InvalidDataException("Invalid buddy-card identity.");
            }
            map[playerId] = set;
        }
        owned = map;
    }

    public IReadOnlyList<string> Submit(string playerId, IEnumerable<string> ids)
    {
        if (!owned.TryGetValue(playerId, out var allowed)) throw new InvalidDataException("Buddy ownership is not provisioned.");
        var list = (ids ?? throw new InvalidDataException("Missing buddy selection.")).ToArray();
        if (list.Length > 32 || list.Any(id => string.IsNullOrWhiteSpace(id) || !allowed.Contains(id)) ||
            list.Distinct(StringComparer.Ordinal).Count() != list.Length)
            throw new InvalidDataException("Buddy selection is not owned or is malformed.");
        if (selected.TryGetValue(playerId, out var prior))
        {
            if (!prior.SequenceEqual(list, StringComparer.Ordinal)) throw new InvalidDataException("Buddy selection request conflict.");
            return prior;
        }
        var frozen = Array.AsReadOnly(list);
        selected[playerId] = frozen;
        return frozen;
    }
}
