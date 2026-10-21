using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;

namespace War.BattleServer;

internal static class AirGeometryInventory
{
    internal const string LegacyDeploymentRevision =
        "6373ad1809e2a3091f3a3f9b285d7e607653e2f6abc4822ed1c4eb9522fec9ec";
    private const string ReviewedGeometryRevision =
        "9e2fe3908e5b58be0bc0b54e92c7c6778420e07ed6d2932a2e312b5868a7c273";

    internal static byte[] Read(string path, string expectedRevision, string deploymentRevision)
    {
        ValidateRevision(expectedRevision);
        ValidateRevision(deploymentRevision);
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > 500000)
        {
            throw new InvalidDataException("Air geometry inventory exceeds its size bound.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != expectedRevision)
        {
            throw new InvalidDataException("Air geometry inventory revision differs from the manifest.");
        }

        JsonNode root = JsonNode.Parse(bytes) ?? throw new InvalidDataException("Missing air geometry inventory.");
        if (root["deploymentSource"] is not JsonObject deployment ||
            deployment["sha256"]?.GetValue<string>() != deploymentRevision)
        {
            throw new InvalidDataException("Air geometry does not bind the admitted deployment revision.");
        }

        // Only deployment provenance may change. Every geometry, prefab and mesh field stays reviewed.
        deployment.Remove("sha256");
        byte[] geometry = Encoding.UTF8.GetBytes(root.ToJsonString());
        if (Convert.ToHexStringLower(SHA256.HashData(geometry)) != ReviewedGeometryRevision)
        {
            throw new InvalidDataException("Air geometry changed beyond reviewed deployment provenance.");
        }

        return bytes;
    }

    private static void ValidateRevision(string revision)
    {
        if (revision is not { Length: 64 } || !revision.All(char.IsAsciiHexDigitLower))
        {
            throw new InvalidDataException("Invalid expected air geometry revision.");
        }
    }
}
