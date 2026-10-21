using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace War.BattleServer;

internal static class CoopTriangulationEvidence
{
    private const int MinimumBytes = 1_000;
    private const int MaximumBytes = 8_192;
    private const string ReviewedGeometryRevision =
        "69b91cfef943552366f1e3e415b12d13359e3463c4ce58b6ba9fa0c892b08cd1";

    internal static byte[] Read(string path)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < MinimumBytes or > MaximumBytes)
        {
            throw new InvalidDataException("Co-op triangulation manifest exceeds its size bounds.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        try
        {
            JsonNode source = JsonNode.Parse(bytes) ?? throw new InvalidDataException("Missing triangulation evidence.");
            // The caller binds this dependency to the admitted navigation catalog; geometry stays reviewed.
            source.AsObject().Remove("navigationSourceSha256");
            byte[] geometry = Encoding.UTF8.GetBytes(source.ToJsonString());
            if (Convert.ToHexStringLower(SHA256.HashData(geometry)) != ReviewedGeometryRevision)
            {
                throw new InvalidDataException("Co-op triangulation geometry differs from reviewed source.");
            }
        }
        catch (JsonException error)
        {
            throw new InvalidDataException("Malformed co-op triangulation evidence.", error);
        }

        return bytes;
    }
}
