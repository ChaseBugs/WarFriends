using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Requires source proof before Mortar shares the straight missile blast implementation.</summary>
internal sealed class MortarWeaponSource
{
    private const string Revision = "276367ca14d775a0df411cb2cb1ed0b39f9585e9fcc7096fa7a4c2da4285270f";
    private const int MaximumArtifactBytes = 16384;

    internal float CadenceSeconds { get; }

    private MortarWeaponSource(float cadenceSeconds)
    {
        CadenceSeconds = cadenceSeconds;
    }

    internal static MortarWeaponSource Load(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        if (stream.Length is < 100 or > MaximumArtifactBytes)
        {
            throw new InvalidDataException("Mortar weapon source exceeds its bounded artifact size.");
        }
        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        if (stream.ReadByte() != -1 || Convert.ToHexStringLower(SHA256.HashData(bytes)) != Revision)
        {
            throw new InvalidDataException("Mortar weapon source revision changed.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        JsonElement policy = root.GetProperty("policy");
        if (root.GetProperty("version").GetInt32() != 1 || root.GetProperty("weaponFileId").GetInt32() != 11496012 ||
            root.GetProperty("setupFileId").GetInt32() != 11469566 ||
            policy.GetProperty("cadenceSeconds").GetSingle() != 2f ||
            policy.GetProperty("deadRadius").GetSingle() != 0.8f ||
            policy.GetProperty("hurtRadius").GetSingle() != 1.2f ||
            policy.GetProperty("criticalProbability").GetSingle() != 0f ||
            policy.GetProperty("curvedTrajectory").GetBoolean() || policy.GetProperty("friendKill").GetBoolean() ||
            policy.GetProperty("missileType").GetInt32() != 2 ||
            policy.GetProperty("shootOffset").EnumerateArray().Any(value => value.GetSingle() != 0f))
        {
            throw new InvalidDataException("Mortar no longer matches the reviewed straight missile policy.");
        }

        return new MortarWeaponSource(policy.GetProperty("cadenceSeconds").GetSingle());
    }
}
