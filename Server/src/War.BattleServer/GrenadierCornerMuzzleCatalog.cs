using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Native pistol muzzle samples taken immediately before five source corner shots on each side.</summary>
internal sealed class GrenadierCornerMuzzleCatalog
{
    internal const int FirstShotDelayTicks = 22;
    private const int RoundIntervalTicks = 11;
    private const int MaximumRounds = 5;
    private const string ArtifactRevision = "40c8b684f6685f8b0618998e1bf367f6593a493113ed83b0ffc4c517b917d2b7";
    private static readonly Lazy<GrenadierCornerMuzzleCatalog> CachedInstance = new(ReadEmbedded);
    private readonly Dictionary<bool, Vector3[]> _samples = new();

    internal static GrenadierCornerMuzzleCatalog Instance => CachedInstance.Value;

    private GrenadierCornerMuzzleCatalog(JsonElement root)
    {
        if (root.GetProperty("unity").GetString() != "2018.3.0f2" ||
            root.GetProperty("captureRate").GetInt32() != MatchManifest.TickRate ||
            root.GetProperty("timeScale").GetSingle() != 1f)
        {
            throw new InvalidDataException("Grenadier native muzzle observation clock changed.");
        }

        foreach (JsonElement scenario in root.GetProperty("scenarios").EnumerateArray())
        {
            ReadScenario(scenario);
        }

        if (_samples.Count != 2)
        {
            throw new InvalidDataException("Grenadier native muzzles require both corner sides.");
        }
    }

    internal Vector3 Place(CardUnitInitialPoint corner, Vector3 position, Vector3 target, int roundIndex)
    {
        if (corner.ComponentType != "EnemyPointCorner" || corner.CornerRightSide is not bool rightSide ||
            corner.CornerDirection is not Vector3 direction || !PlayerHitbox.Finite(position) ||
            !PlayerHitbox.Finite(target) || roundIndex is < 0 or >= MaximumRounds ||
            !CornerShotPolicy.CanExpose(direction, rightSide, position, target))
        {
            throw new InvalidDataException("Grenadier pistol has no observed corner firing pose.");
        }

        // EnemyController.PrepareToShoot completes its turn facing away from the target.
        // These native samples already include the pistol attachment and callback-phase animation.
        Vector3 away = position - target;
        float yaw = MathF.Atan2(away.X, away.Z);
        return position + Vector3.Transform(_samples[rightSide][roundIndex],
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw));
    }

    private void ReadScenario(JsonElement scenario)
    {
        string side = scenario.GetProperty("side").GetString() ?? "";
        JsonElement rounds = scenario.GetProperty("rounds");
        if (side is not ("left" or "right") ||
            scenario.GetProperty("firstReadyTick").GetInt32() != FirstShotDelayTicks ||
            rounds.GetArrayLength() != MaximumRounds)
        {
            throw new InvalidDataException("Grenadier native volley observation is incomplete.");
        }

        var samples = new Vector3[MaximumRounds];
        for (int index = 0; index < samples.Length; index++)
        {
            JsonElement round = rounds[index];
            JsonElement point = round.GetProperty("pose").GetProperty("position");
            samples[index] = new Vector3(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle());
            if (round.GetProperty("tick").GetInt32() != FirstShotDelayTicks + index * RoundIntervalTicks ||
                !PlayerHitbox.Finite(samples[index]))
            {
                throw new InvalidDataException("Grenadier native round sequence changed.");
            }
        }

        _samples.Add(side == "right", samples);
    }

    private static GrenadierCornerMuzzleCatalog ReadEmbedded()
    {
        using Stream source = typeof(GrenadierCornerMuzzleCatalog).Assembly
            .GetManifestResourceStream("War.BattleServer.GrenadierCornerMuzzles") ??
            throw new InvalidDataException("Grenadier native muzzle evidence is absent.");
        using var buffer = new MemoryStream();
        source.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ArtifactRevision)
        {
            throw new InvalidDataException("Grenadier native muzzle revision mismatch.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        return new GrenadierCornerMuzzleCatalog(document.RootElement);
    }
}
