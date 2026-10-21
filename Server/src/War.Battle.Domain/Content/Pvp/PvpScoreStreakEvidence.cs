using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;

namespace War.BattleServer;

internal static class PvpScoreStreakEvidence
{
    private const int MaximumBytes = 8_192;
    private const string LegacyRulesRevision =
        "8b51fa69b82a380edd55ecc91fc3fced9951a0da2612ff6c6a6d3abbcbb36852";
    private const string CurrentRulesRevision =
        "d693cb337c8e6321204aefa184b805fb73a9704821aa15aab6766ba2429cfc88";

    internal static byte[] Read(string path, string sceneRevision, string contentRevision)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > MaximumBytes)
        {
            throw new InvalidDataException("Score-streak evidence exceeds its size bound.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        JsonNode source = JsonNode.Parse(bytes) ?? throw new InvalidDataException("Missing score-streak evidence.");
        ValidateRevision(source, "sceneSha256", sceneRevision);
        ValidateRevision(source, "battleContentSha256", contentRevision);
        string revision = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(source.ToJsonString())));

        // Keep each reviewed code-source tuple intact; host presentation changes do not redefine the policy.
        if (revision != LegacyRulesRevision && revision != CurrentRulesRevision)
        {
            throw new InvalidDataException("Score-streak rules or code provenance differ from reviewed source.");
        }

        return bytes;
    }

    private static void ValidateRevision(JsonNode source, string field, string revision)
    {
        if (revision is not { Length: 64 } || !revision.All(char.IsAsciiHexDigitLower) ||
            source[field]?.GetValue<string>() != revision)
        {
            throw new InvalidDataException("Score-streak evidence has different source provenance.");
        }

        source.AsObject().Remove(field);
    }
}
