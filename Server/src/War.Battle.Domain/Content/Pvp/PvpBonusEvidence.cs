using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;

namespace War.BattleServer;

internal static class PvpBonusEvidence
{
    private const int MaximumBytes = 100_000;
    private const string ReviewedRulesRevision =
        "19fe945ba37a305a07fca7f5d3b429a44c140f6e7cd24c02d76c9b35c1d06603";

    internal static byte[] Read(string path, string sceneRevision, string contentRevision)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > MaximumBytes)
        {
            throw new InvalidDataException("PvP bonus evidence exceeds its size bound.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        JsonNode source = JsonNode.Parse(bytes) ?? throw new InvalidDataException("Missing PvP bonus evidence.");
        ValidateRevision(source, "sceneSha256", sceneRevision);
        ValidateRevision(source, "battleContentSha256", contentRevision);
        NormalizeFloat(source["rules"]!, "warbucksScalingBase", 1.033f);
        NormalizeFloat(source["rules"]!, "lowAmmoThreshold", 0.1f);
        byte[] rules = Encoding.UTF8.GetBytes(source.ToJsonString());
        if (Convert.ToHexStringLower(SHA256.HashData(rules)) != ReviewedRulesRevision)
        {
            throw new InvalidDataException("PvP bonus rules differ from reviewed source.");
        }

        return bytes;
    }

    private static void ValidateRevision(JsonNode source, string field, string revision)
    {
        if (revision is not { Length: 64 } || !revision.All(char.IsAsciiHexDigitLower) ||
            source[field]?.GetValue<string>() != revision)
        {
            throw new InvalidDataException("PvP bonus evidence has different source provenance.");
        }

        source.AsObject().Remove(field);
    }

    private static void NormalizeFloat(JsonNode rules, string field, float expected)
    {
        // The recovered C# fields are binary32. New extraction preserves their exact stored bits.
        if (rules[field]?.GetValue<float>() != expected)
        {
            throw new InvalidDataException("PvP bonus float rule changed its recovered value.");
        }

        rules[field] = JsonValue.Create(expected);
    }
}
