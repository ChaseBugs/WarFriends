using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// A measured Unity 2018 Play Mode frame. Position and rotation are local to
/// the enemy root; this is observation, not an authoritative world shot.
/// </summary>
internal sealed record CoopQueuedMuzzleSample(
    float FireClipSeconds, Vector3 LocalPosition, Quaternion LocalRotation);

internal sealed class CoopAssaulterQueueCatalog
{
    private const string VerifiedRevision =
        "565ac462191f1ec86d5ce2ba7451cf1971977c62009589ef7dcf4ff280746714";
    private const string WeaponSha256 =
        "a55f77d5fc32e948951805b01e13c9193cf852171ec842a2caa6ad3338239de2";

    private static readonly (string Start, string Fire, float Fade,
        int FirstQueuedFrame)[] SourceScenarios =
    [
        ("stand_up_begin", "rifle_shot_loop", 0.05f, 7),
        ("player_look_right3", "player_fire_right3", 0.02f, 15),
        ("player_look_left3", "player_fire_left3", 0.02f, 15)
    ];

    private readonly IReadOnlyDictionary<string, CoopQueuedMuzzleSample?[]>
        samples;

    private CoopAssaulterQueueCatalog(
        Dictionary<string, CoopQueuedMuzzleSample?[]> samples)
    {
        this.samples = samples;
    }

    internal static CoopAssaulterQueueCatalog Load(string path,
        EnemyPoseCatalog enemyPoses)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length is < 50_000 or > 200_000 ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) !=
                VerifiedRevision)
            throw new InvalidDataException(
                "Co-op Assaulter queue observation changed.");

        using JsonDocument document = JsonDocument.Parse(bytes,
            new JsonDocumentOptions { MaxDepth = 12 });
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("unity").GetString() != "2018.3.0f2" ||
            root.GetProperty("enemySha256").GetString() !=
                enemyPoses.SourceSha256 ||
            root.GetProperty("weaponSha256").GetString() != WeaponSha256 ||
            root.GetProperty("captureRate").GetInt32() != 30)
            throw new InvalidDataException(
                "Co-op Assaulter queue source binding changed.");

        JsonElement scenarios = root.GetProperty("scenarios");
        if (scenarios.GetArrayLength() != SourceScenarios.Length)
            throw new InvalidDataException(
                "Co-op Assaulter queue scenarios are incomplete.");
        var accepted = new Dictionary<string, CoopQueuedMuzzleSample?[]>(
            StringComparer.Ordinal);
        for (int scenarioIndex = 0;
             scenarioIndex < SourceScenarios.Length; scenarioIndex++)
        {
            var source = SourceScenarios[scenarioIndex];
            JsonElement scenario = scenarios[scenarioIndex];
            if (scenario.GetProperty("startClip").GetString() != source.Start ||
                scenario.GetProperty("fireClip").GetString() != source.Fire ||
                scenario.GetProperty("fadeSeconds").GetSingle() != source.Fade)
                throw new InvalidDataException(
                    "Co-op Assaulter queue clip mapping changed.");
            enemyPoses.Clip(source.Start);
            enemyPoses.Clip(source.Fire);

            JsonElement frames = scenario.GetProperty("frames");
            if (frames.GetArrayLength() != 40)
                throw new InvalidDataException(
                    "Co-op Assaulter queue frame window changed.");
            var observed = new CoopQueuedMuzzleSample?[40];
            int firstQueuedFrame = -1;
            for (int frameIndex = 0; frameIndex < observed.Length; frameIndex++)
            {
                JsonElement frame = frames[frameIndex];
                float seconds = frame.GetProperty("seconds").GetSingle();
                if (!float.IsFinite(seconds) ||
                    Math.Abs(seconds - frameIndex / 30f) > 0.00001f)
                    throw new InvalidDataException(
                        "Co-op Assaulter queue frame clock changed.");

                JsonElement states = frame.GetProperty("states");
                foreach (JsonElement state in states.EnumerateArray())
                {
                    if (state.GetProperty("name").GetString() !=
                            source.Fire + " - Queued Clone" ||
                        !state.GetProperty("enabled").GetBoolean())
                        continue;
                    if (observed[frameIndex] != null)
                        throw new InvalidDataException(
                            "Co-op Assaulter queue has duplicate firing states.");
                    float clipSeconds = state.GetProperty("time").GetSingle();
                    float weight = state.GetProperty("weight").GetSingle();
                    if (!float.IsFinite(clipSeconds) ||
                        Math.Abs(clipSeconds -
                            (frameIndex - source.FirstQueuedFrame) / 30f) >
                            0.00001f ||
                        !float.IsFinite(weight) ||
                        Math.Abs(weight - 1f) > 0.0001f)
                        throw new InvalidDataException(
                            "Co-op Assaulter queued firing clock changed.");
                    firstQueuedFrame = firstQueuedFrame < 0
                        ? frameIndex : firstQueuedFrame;
                    observed[frameIndex] = new CoopQueuedMuzzleSample(
                        clipSeconds,
                        ReadPosition(frame.GetProperty("position")),
                        ReadRotation(frame.GetProperty("rotation")));
                }
            }
            if (firstQueuedFrame != source.FirstQueuedFrame)
                throw new InvalidDataException(
                    "Co-op Assaulter firing clip started on a different frame.");
            accepted.Add(source.Start, observed);
        }
        return new CoopAssaulterQueueCatalog(accepted);
    }

    internal CoopQueuedMuzzleSample? Sample(string startClip,
        string fireClip, ulong elapsedTicks)
    {
        if (!samples.TryGetValue(startClip,
                out CoopQueuedMuzzleSample?[]? frames) ||
            !SourceScenarios.Any(source => source.Start == startClip &&
                source.Fire == fireClip))
            throw new InvalidDataException(
                "Unknown co-op Assaulter firing sequence.");
        if (elapsedTicks >= (ulong)frames.Length)
            return null;
        return frames[(int)elapsedTicks];
    }

    private static Vector3 ReadPosition(JsonElement values)
    {
        if (values.GetArrayLength() != 3)
            throw new InvalidDataException("Invalid observed muzzle position.");
        var position = new Vector3(values[0].GetSingle(),
            values[1].GetSingle(), values[2].GetSingle());
        if (!PlayerHitbox.Finite(position) || position.Length() > 5)
            throw new InvalidDataException("Observed muzzle left the source rig.");
        return position;
    }

    private static Quaternion ReadRotation(JsonElement values)
    {
        if (values.GetArrayLength() != 4)
            throw new InvalidDataException("Invalid observed muzzle rotation.");
        var rotation = new Quaternion(values[0].GetSingle(),
            values[1].GetSingle(), values[2].GetSingle(),
            values[3].GetSingle());
        if (!float.IsFinite(rotation.LengthSquared()) ||
            Math.Abs(rotation.LengthSquared() - 1) > 0.001f)
            throw new InvalidDataException(
                "Observed muzzle rotation is not a unit quaternion.");
        return Quaternion.Normalize(rotation);
    }
}
