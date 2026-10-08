using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// Body and head colliders measured while Unity blends a corner soldier's
/// cover-back animation into idle. These are diagnostic pose observations.
/// </summary>
internal sealed class CoopCornerQueuePoseCatalog
{
    private const string VerifiedRevision =
        "2b5701f1973edcf465295ea55e84cfe8aa4783b8641b9a670b48d95ad59d42c3";
    private static readonly string[] CoverClips =
        ["player_right_coverBack3", "player_left_coverBack3"];
    private readonly Dictionary<string, PlayerHitbox[][]> frames;
    private readonly Dictionary<string, float> idleSecondsAtLastFrame;
    private readonly EnemyPoseCatalog enemyPoses;

    private CoopCornerQueuePoseCatalog(
        Dictionary<string, PlayerHitbox[][]> frames,
        Dictionary<string, float> idleSecondsAtLastFrame,
        EnemyPoseCatalog enemyPoses)
    {
        this.frames = frames;
        this.idleSecondsAtLastFrame = idleSecondsAtLastFrame;
        this.enemyPoses = enemyPoses;
    }

    internal static CoopCornerQueuePoseCatalog Load(string path,
        EnemyPoseCatalog enemyPoses)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length is < 50_000 or > 200_000 ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) !=
                VerifiedRevision)
            throw new InvalidDataException(
                "Co-op corner queue observation changed.");
        try
        {
            using JsonDocument document = JsonDocument.Parse(bytes,
                new JsonDocumentOptions { MaxDepth = 12 });
            JsonElement root = document.RootElement;
            if (root.GetProperty("version").GetInt32() != 1 ||
                root.GetProperty("client").GetString() != "1.4.0" ||
                root.GetProperty("unity").GetString() != "2018.3.0f2" ||
                root.GetProperty("prefab").GetString() !=
                    "Assets/GameObject/enemy.prefab" ||
                root.GetProperty("prefabSha256").GetString() !=
                    enemyPoses.SourceSha256 ||
                root.GetProperty("captureRate").GetInt32() !=
                    MatchManifest.TickRate)
                throw new InvalidDataException(
                    "Co-op corner queue source identity changed.");

            JsonElement scenarios = root.GetProperty("scenarios");
            if (scenarios.GetArrayLength() != CoverClips.Length)
                throw new InvalidDataException(
                    "Co-op corner queue lost a cover side.");
            var accepted = new Dictionary<string, PlayerHitbox[][]>(
                StringComparer.Ordinal);
            var idleTimes = new Dictionary<string, float>(
                StringComparer.Ordinal);
            for (int side = 0; side < CoverClips.Length; side++)
            {
                string coverClip = CoverClips[side];
                JsonElement scenario = scenarios[side];
                if (scenario.GetProperty("coverClip").GetString() !=
                        coverClip ||
                    scenario.GetProperty("idleClip").GetString() !=
                        "idle_1")
                    throw new InvalidDataException(
                        "Co-op corner queue clip identity changed.");
                JsonElement samples = scenario.GetProperty("samples");
                if (samples.GetArrayLength() != 31)
                    throw new InvalidDataException(
                        "Co-op corner queue lost fixed frames.");
                var localFrames = new PlayerHitbox[31][];
                IReadOnlyList<PlayerHitbox> sourceParts = enemyPoses
                    .Clip(coverClip).Frames[0].Parts;
                float previousIdleWeight = 0;
                for (int tick = 0; tick < localFrames.Length; tick++)
                {
                    JsonElement sample = samples[tick];
                    float expectedSeconds = tick /
                        (float)MatchManifest.TickRate;
                    if (MathF.Abs(sample.GetProperty("seconds")
                            .GetSingle() - expectedSeconds) > 0.00001f)
                        throw new InvalidDataException(
                            "Co-op corner queue changed its clock.");
                    float idleWeight = ReadIdleWeight(sample);
                    if (idleWeight + 0.00001f < previousIdleWeight)
                        throw new InvalidDataException(
                            "Co-op corner queue reversed its blend.");
                    previousIdleWeight = idleWeight;
                    JsonElement parts = sample.GetProperty("parts");
                    if (parts.GetArrayLength() != sourceParts.Count)
                        throw new InvalidDataException(
                            "Co-op corner queue lost collider parts.");
                    localFrames[tick] = new PlayerHitbox[sourceParts.Count];
                    for (int index = 0; index < sourceParts.Count; index++)
                    {
                        JsonElement part = parts[index];
                        PlayerHitbox sourcePart = sourceParts[index];
                        if (part.GetProperty("path").GetString() !=
                            sourcePart.SourcePath)
                            throw new InvalidDataException(
                                "Co-op corner queue collider path changed.");
                        Vector3 center = ReadVector(part.GetProperty(
                            "center"));
                        Quaternion rotation = ReadRotation(part.GetProperty(
                            "rotation"));
                        localFrames[tick][index] = new PlayerHitbox(
                            sourcePart.SourcePath, sourcePart.Kind,
                            sourcePart.Weight, center, sourcePart.Size,
                            rotation, sourcePart.Radius, sourcePart.Axis,
                            sourcePart.HalfSegment);
                    }
                }
                if (previousIdleWeight != 1)
                    throw new InvalidDataException(
                        "Co-op corner queue never reached idle.");
                JsonElement finalStates = samples[30].GetProperty("states");
                if (finalStates.GetArrayLength() != 1 ||
                    finalStates[0].GetProperty("name").GetString() !=
                        "idle_1 - Queued Clone")
                    throw new InvalidDataException(
                        "Co-op corner queue has no pure idle handoff.");
                float idleSeconds = finalStates[0].GetProperty("time")
                    .GetSingle();
                if (!float.IsFinite(idleSeconds) ||
                    idleSeconds is < 0 or > 1)
                    throw new InvalidDataException(
                        "Co-op corner queue idle clock is invalid.");
                accepted.Add(coverClip, localFrames);
                idleTimes.Add(coverClip, idleSeconds);
            }
            return new CoopCornerQueuePoseCatalog(accepted, idleTimes,
                enemyPoses);
        }
        catch (Exception error) when (error is JsonException or
            KeyNotFoundException or FormatException or IndexOutOfRangeException)
        {
            throw new InvalidDataException(
                "Malformed co-op corner queue observation.", error);
        }
    }

    internal IReadOnlyList<PlayerHitbox> Place(string coverClip, int tick,
        Vector3 rootPosition, Quaternion rootRotation, string prefix = "")
    {
        if (!frames.TryGetValue(coverClip,
                out PlayerHitbox[][]? samples) ||
            tick < 0 || tick > 1_000_000 ||
            !PlayerHitbox.Finite(rootPosition) ||
            !float.IsFinite(rootRotation.LengthSquared()) ||
            MathF.Abs(rootRotation.LengthSquared() - 1) > 0.0002f ||
            prefix.Length > 128 || prefix.Any(char.IsControl))
            throw new InvalidDataException(
                "Invalid co-op corner queue placement.");
        if (tick >= samples.Length)
        {
            // The last Unity queue frame is pure idle and matches the
            // recovered looping idle clip at this exact animation time.
            float idleSeconds = idleSecondsAtLastFrame[coverClip] +
                (tick - 30) / (float)MatchManifest.TickRate;
            return enemyPoses.Place("idle_1", rootPosition, rootRotation,
                idleSeconds, prefix);
        }
        Quaternion facing = Quaternion.Normalize(rootRotation);
        return samples[tick].Select(part => new PlayerHitbox(
            prefix + part.SourcePath, part.Kind, part.Weight,
            rootPosition + Vector3.Transform(part.Center, facing),
            part.Size, Quaternion.Normalize(facing * part.Rotation),
            part.Radius, part.Axis, part.HalfSegment)).ToArray();
    }

    private static float ReadIdleWeight(JsonElement sample)
    {
        float total = 0;
        float idle = 0;
        foreach (JsonElement state in sample.GetProperty("states")
            .EnumerateArray())
        {
            string? name = state.GetProperty("name").GetString();
            if (name != "idle_1 - Queued Clone" &&
                !CoverClips.Contains(name))
                throw new InvalidDataException(
                    "Co-op corner queue contains an unexpected clip.");
            float weight = state.GetProperty("weight").GetSingle();
            if (!float.IsFinite(weight) || weight is < 0 or > 1)
                throw new InvalidDataException(
                    "Co-op corner queue has an invalid clip weight.");
            total += weight;
            if (name == "idle_1 - Queued Clone")
                idle = weight;
        }
        if (MathF.Abs(total - 1) > 0.0001f)
            throw new InvalidDataException(
                "Co-op corner queue weights do not conserve pose.");
        return idle;
    }

    private static Vector3 ReadVector(JsonElement values)
    {
        if (values.GetArrayLength() != 3)
            throw new InvalidDataException("Invalid queue collider center.");
        return new Vector3(values[0].GetSingle(), values[1].GetSingle(),
            values[2].GetSingle());
    }

    private static Quaternion ReadRotation(JsonElement values)
    {
        if (values.GetArrayLength() != 4)
            throw new InvalidDataException("Invalid queue collider rotation.");
        return new Quaternion(values[0].GetSingle(), values[1].GetSingle(),
            values[2].GetSingle(), values[3].GetSingle());
    }
}
