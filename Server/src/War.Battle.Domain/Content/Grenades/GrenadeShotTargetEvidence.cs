using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;

namespace War.BattleServer;

internal static class GrenadeShotTargetEvidence
{
    private const int MinimumBytes = 50_000;
    private const int MaximumBytes = 500_000;
    private const string ReviewedSamplesRevision =
        "f5bf2dfa047cb48cd91d2bc712c7c9cad166d60e66440411e11b5eee0d6d9b55";

    internal static byte[] Read(string path, string sceneRevision)
    {
        if (sceneRevision is not { Length: 64 } || !sceneRevision.All(char.IsAsciiHexDigitLower))
        {
            throw new InvalidDataException("Invalid grenade target scene revision.");
        }

        using var stream = File.OpenRead(path);
        if (stream.Length is < MinimumBytes or > MaximumBytes)
        {
            throw new InvalidDataException("Grenade target evidence exceeds its size bounds.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        JsonNode source = JsonNode.Parse(bytes) ?? throw new InvalidDataException("Missing grenade target evidence.");
        if (source["sha256"]?.GetValue<string>() != sceneRevision)
        {
            throw new InvalidDataException("Grenade targets do not bind the admitted scene.");
        }

        // Native recapture may refresh scene provenance, never targets, clips or sampled positions.
        source.AsObject().Remove("sha256");
        byte[] samples = Encoding.UTF8.GetBytes(source.ToJsonString());
        if (Convert.ToHexStringLower(SHA256.HashData(samples)) != ReviewedSamplesRevision)
        {
            throw new InvalidDataException("Grenade target samples differ from reviewed evidence.");
        }

        return bytes;
    }
}
