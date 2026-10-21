using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Complete stored ordinary-card identity set, distinct from the host's implemented effect map.</summary>
public static class OrdinaryCardIdentityCatalog
{
    private const string VerifiedRevision = "6d65e9de3e33729c2cebe3b54ff40e8ea8ebb1a0df1222eb86b591d17ed25408";
    private static readonly IReadOnlyList<string> Identities = Load();

    /// <summary>Includes inactive rows because the Client keeps zero quantities for unavailable cards.</summary>
    public static IReadOnlyList<string> All => Identities;

    private static IReadOnlyList<string> Load()
    {
        using Stream stream = typeof(OrdinaryCardIdentityCatalog).Assembly.GetManifestResourceStream(
            "War.BattleServer.OrdinaryCardIdentities")
            ?? throw new InvalidDataException("Missing ordinary card identity evidence.");
        using var buffer = new MemoryStream();
        stream.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != VerifiedRevision)
        {
            throw new InvalidDataException("Unverified ordinary card identity evidence.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement cards = document.RootElement.GetProperty("cards");
        string[] identities = cards.EnumerateArray().Select(card => card.GetProperty("id").GetString()!).ToArray();
        if (identities.Length != 67 || identities.Distinct(StringComparer.Ordinal).Count() != identities.Length ||
            cards.EnumerateArray().Count(card => card.GetProperty("implemented").GetBoolean()) != 57)
        {
            throw new InvalidDataException("Incomplete ordinary card definition identity set.");
        }

        return Array.AsReadOnly(identities);
    }
}
