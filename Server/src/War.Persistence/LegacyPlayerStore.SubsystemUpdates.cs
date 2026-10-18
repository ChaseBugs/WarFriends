using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    /// <summary>Replaces related subsystem blobs atomically while their exact read snapshot still matches.</summary>
    public async Task<bool> TryReplaceSubsystemsAsync(LegacyPlayerDocument snapshot,
        IReadOnlyDictionary<string, string> replacements, CancellationToken cancellationToken)
    {
        if (snapshot == null || snapshot.Serialized == null || string.IsNullOrWhiteSpace(snapshot.Id) ||
            replacements == null || replacements.Count == 0 || replacements.Count > SerializedKeys.Count ||
            replacements.Any(row => !SerializedKeys.Contains(row.Key) || string.IsNullOrWhiteSpace(row.Value)))
        {
            throw new InvalidDataException("Invalid conditional subsystem replacement.");
        }

        var filters = Builders<LegacyPlayerDocument>.Filter;
        var filter = filters.Eq(player => player.Id, snapshot.Id) &
            filters.Gte(player => player.Revision, 0) & filters.Lt(player => player.Revision, long.MaxValue);
        var updates = new List<UpdateDefinition<LegacyPlayerDocument>>();
        foreach (var replacement in replacements)
        {
            string path = "Serialized." + replacement.Key;
            if (snapshot.Serialized.TryGetValue(replacement.Key, out string? previous))
            {
                filter &= filters.Exists(path) & filters.Eq(path, previous);
            }
            else
            {
                filter &= filters.Exists(path, false);
            }

            updates.Add(Builders<LegacyPlayerDocument>.Update.Set(path, replacement.Value));
        }

        updates.Add(Builders<LegacyPlayerDocument>.Update.Inc(player => player.Revision, 1));
        UpdateResult result = await players.UpdateOneAsync(filter,
            Builders<LegacyPlayerDocument>.Update.Combine(updates), cancellationToken: cancellationToken);
        return result.ModifiedCount == 1;
    }
}
