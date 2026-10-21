using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Source-observed initial pool space; it does not assert that later scene parents never move.</summary>
internal sealed class HelicopterCrewPoolFrame
{
    private const string ReferenceDigest = "34433001337ce0aaa8f504c97ccec6acdd6344abcd06b6524221b7879a1fd96a";

    private HelicopterCrewPoolFrame()
    {
    }

    internal Quaternion ParentRotation => Quaternion.Identity;
    internal Quaternion SpawnResetRotation => Quaternion.Identity;

    internal static HelicopterCrewPoolFrame Load(string path)
    {
        string text = File.ReadAllText(path).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) != ReferenceDigest)
        {
            throw new InvalidDataException("Recovered helicopter pool frame differs from its reviewed scene capture.");
        }
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement observation = document.RootElement.GetProperty("observation");
        JsonElement container = observation.GetProperty("container");
        JsonElement reused = observation.GetProperty("reused");
        if (observation.GetProperty("poolName").GetString() != "NetworkPool" ||
            ReadVector(container.GetProperty("position")) != Vector3.Zero ||
            ReadVector(container.GetProperty("scale")) != Vector3.One ||
            ReadRotation(container.GetProperty("rotation")) != Quaternion.Identity ||
            ReadRotation(reused.GetProperty("rotation")) != Quaternion.Identity ||
            ReadRotation(reused.GetProperty("localRotation")) != Quaternion.Identity)
        {
            throw new InvalidDataException("The source initial crew pool space " +
                "no longer supports world-local identity.");
        }
        return new HelicopterCrewPoolFrame();
    }

    private static Vector3 ReadVector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static Quaternion ReadRotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }
}
