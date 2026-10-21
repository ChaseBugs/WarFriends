using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace War.BattleServer;

internal static class PvpSkillShotEvidence
{
    private const int MaximumBytes = 32_768;
    private const string ReviewedRulesRevision =
        "7f4edd436ef7fac25a69a4f47281f87c410443bc916dfb39ec80b6b09a96e670";

    internal static byte[] Read(string path, string sceneRevision, string contentRevision)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > MaximumBytes)
        {
            throw new InvalidDataException("Skill-shot evidence exceeds its size bound.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        JsonNode source = Parse(bytes);
        ValidateRevision(source, "sceneSha256", sceneRevision);
        ValidateRevision(source, "battleContentSha256", contentRevision);
        string revision = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(source.ToJsonString())));

        // Source code, score rows and ordering remain reviewed when scene provenance advances.
        if (revision != ReviewedRulesRevision)
        {
            throw new InvalidDataException("Skill-shot rules or code provenance differ from reviewed source.");
        }

        return bytes;
    }

    private static JsonNode Parse(byte[] bytes)
    {
        try
        {
            return JsonNode.Parse(bytes) ?? throw new InvalidDataException("Missing skill-shot evidence.");
        }
        catch (JsonException error)
        {
            throw new InvalidDataException("Malformed skill-shot evidence.", error);
        }
    }

    private static void ValidateRevision(JsonNode source, string field, string revision)
    {
        if (revision is not { Length: 64 } || !revision.All(char.IsAsciiHexDigitLower) ||
            source[field]?.GetValue<string>() != revision)
        {
            throw new InvalidDataException("Skill-shot evidence has different source provenance.");
        }

        source.AsObject().Remove(field);
    }
}
