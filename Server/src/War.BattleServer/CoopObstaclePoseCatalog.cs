using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record CoopObstaclePoseClock(ulong ElapsedTick,
    IReadOnlyList<ulong> EmittedRoundTicks, ulong? CrawlReturnTick = null);

/// <summary>Selects diagnostic obstacle poses; sampled colliders are not complete hit authority.</summary>
internal sealed class CoopObstaclePoseCatalog
{
    private const string ReviewedSha256 = "7a4cc573e5f56587e5424231be13774f5afcd30716c6e2f14843f395af4fb9bb";
    private const string CrawlClip = "stand_up_crawl";
    private const string BeginClip = "stand_up_begin";
    private const string FireClip = "rifle_shot_loop";
    private const int MaximumObservationBytes = 200000;
    private const int MaximumVolleyRounds = 14;
    private const ulong BlendFrameTick = 1;
    private const float RootRotationTolerance = 0.0002f;
    private const int MaximumPrefixLength = 128;
    private readonly EnemyPoseCatalog _clips;
    private readonly IReadOnlyList<PlayerHitbox> _blendFrame;
    private readonly ulong _firstQueuedFireTick;

    private CoopObstaclePoseCatalog(EnemyPoseCatalog clips, IReadOnlyList<PlayerHitbox> blendFrame,
        ulong firstQueuedFireTick)
    {
        _clips = clips;
        _blendFrame = blendFrame;
        _firstQueuedFireTick = firstQueuedFireTick;
    }

    internal static CoopObstaclePoseCatalog Load(string path, EnemyPoseCatalog clips)
    {
        if (new FileInfo(path).Length > MaximumObservationBytes)
        {
            throw new InvalidDataException("Obstacle pose observation is too large.");
        }
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
        {
            throw new InvalidDataException("Obstacle controller observation differs from reviewed source.");
        }
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 3 ||
            root.GetProperty("prefabSha256").GetString() != clips.SourceSha256 ||
            root.GetProperty("captureRate").GetInt32() != MatchManifest.TickRate)
        {
            throw new InvalidDataException("Obstacle observation does not bind the source rig and clock.");
        }
        JsonElement samples = root.GetProperty("samples");
        ulong firstFire = (ulong)samples.EnumerateArray().First(frame =>
            frame.GetProperty("states").EnumerateArray().Any(state =>
                state.GetProperty("name").GetString() == FireClip + " - Queued Clone"))
            .GetProperty("tick").GetInt32();
        return new CoopObstaclePoseCatalog(clips, ReadBlendFrame(samples[(int)BlendFrameTick], clips), firstFire);
    }

    internal IReadOnlyList<PlayerHitbox> Place(CoopObstaclePoseClock clock, Vector3 rootPosition,
        Quaternion rootRotation, string prefix = "")
    {
        ulong fireOrigin = ValidateClock(clock);
        ValidatePlacement(rootPosition, rootRotation, prefix);
        rootRotation = Quaternion.Normalize(rootRotation);
        if (clock.ElapsedTick == BlendFrameTick)
        {
            return PlaceBlendFrame(rootPosition, rootRotation, prefix);
        }
        if (clock.ElapsedTick == 0)
        {
            return _clips.Place(CrawlClip, rootPosition, rootRotation, _clips.Clip(CrawlClip).Length, prefix);
        }
        if (clock.CrawlReturnTick.HasValue && clock.ElapsedTick >= clock.CrawlReturnTick.Value)
        {
            float seconds = (clock.ElapsedTick - clock.CrawlReturnTick.Value) / (float)MatchManifest.TickRate;
            return _clips.Place(CrawlClip, rootPosition, rootRotation, seconds, prefix);
        }
        if (clock.ElapsedTick < _firstQueuedFireTick)
        {
            float seconds = clock.ElapsedTick / (float)MatchManifest.TickRate;
            return _clips.Place(BeginClip, rootPosition, rootRotation, seconds, prefix);
        }
        float fireSeconds = (clock.ElapsedTick - fireOrigin) / (float)MatchManifest.TickRate;
        return _clips.Place(FireClip, rootPosition, rootRotation, fireSeconds, prefix);
    }

    internal CoopQueuedMuzzleSample? FiringMuzzle(CoopObstaclePoseClock clock, CoopEnemyMuzzleCatalog muzzles)
    {
        ArgumentNullException.ThrowIfNull(muzzles);
        ulong fireOrigin = ValidateClock(clock);
        if (clock.ElapsedTick < _firstQueuedFireTick ||
            (clock.CrawlReturnTick.HasValue && clock.ElapsedTick >= clock.CrawlReturnTick.Value))
        {
            return null;
        }

        // OnShot resets the loop after this frame's transform sample; only earlier rounds change its pose.
        float seconds = (clock.ElapsedTick - fireOrigin) / (float)MatchManifest.TickRate;
        CoopMuzzlePose pose = muzzles.Place(FireClip, Vector3.Zero, Quaternion.Identity, seconds);
        return new CoopQueuedMuzzleSample(seconds, pose.Position, pose.Rotation);
    }

    private ulong ValidateClock(CoopObstaclePoseClock clock)
    {
        ArgumentNullException.ThrowIfNull(clock);
        ArgumentNullException.ThrowIfNull(clock.EmittedRoundTicks);
        if (clock.EmittedRoundTicks.Count > MaximumVolleyRounds)
        {
            throw new InvalidDataException("Obstacle volley exceeds the recovered round cap.");
        }
        ulong prior = 0;
        ulong fireOrigin = _firstQueuedFireTick;
        foreach (ulong roundTick in clock.EmittedRoundTicks)
        {
            if (roundTick <= prior || roundTick < _firstQueuedFireTick || roundTick > clock.ElapsedTick)
            {
                throw new InvalidDataException("Obstacle rounds must be ordered emitted source ticks.");
            }
            // The capture callback resets Animation time after its current transform sample.
            if (roundTick < clock.ElapsedTick)
            {
                fireOrigin = roundTick;
            }
            prior = roundTick;
        }
        if (clock.CrawlReturnTick.HasValue &&
            (clock.CrawlReturnTick.Value <= prior || clock.CrawlReturnTick.Value < _firstQueuedFireTick))
        {
            throw new InvalidDataException("Obstacle crawl return cannot precede its emitted rounds.");
        }
        return fireOrigin;
    }

    private static IReadOnlyList<PlayerHitbox> ReadBlendFrame(JsonElement frame, EnemyPoseCatalog clips)
    {
        IReadOnlyList<PlayerHitbox> shapes = clips.Clip(CrawlClip).Frames[0].Parts;
        JsonElement parts = frame.GetProperty("parts");
        if (parts.GetArrayLength() != shapes.Count)
        {
            throw new InvalidDataException("Obstacle blend frame has an incomplete collider set.");
        }
        var accepted = new List<PlayerHitbox>(shapes.Count);
        for (int index = 0; index < shapes.Count; index++)
        {
            PlayerHitbox shape = shapes[index];
            JsonElement part = parts[index];
            string kind = shape.Kind == PlayerHitboxKind.Box ? "box" : "sphere";
            if (part.GetProperty("path").GetString() != shape.SourcePath ||
                part.GetProperty("kind").GetString() != kind)
            {
                throw new InvalidDataException("Obstacle blend collider identity differs from the recovered rig.");
            }
            float[] center = Values(part.GetProperty("center"));
            float[] rotation = Values(part.GetProperty("rotation"));
            float[] size = Values(part.GetProperty("size"));
            accepted.Add(new PlayerHitbox(shape.SourcePath, shape.Kind, shape.Weight,
                new Vector3(center[0], center[1], center[2]), new Vector3(size[0], size[1], size[2]),
                new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]),
                part.GetProperty("radius").GetSingle(), Vector3.Zero, 0,
                part.GetProperty("enabled").GetBoolean(), part.GetProperty("active").GetBoolean()));
        }
        return Array.AsReadOnly(accepted.ToArray());
    }

    private IReadOnlyList<PlayerHitbox> PlaceBlendFrame(Vector3 position, Quaternion rotation, string prefix)
    {
        return _blendFrame.Select(shape => new PlayerHitbox(prefix + shape.SourcePath, shape.Kind, shape.Weight,
            position + Vector3.Transform(shape.Center, rotation), shape.Size,
            Quaternion.Normalize(rotation * shape.Rotation), shape.Radius, Vector3.Zero, 0,
            shape.Enabled, shape.Active)).ToArray();
    }

    private static void ValidatePlacement(Vector3 position, Quaternion rotation, string prefix)
    {
        ArgumentNullException.ThrowIfNull(prefix);
        if (!PlayerHitbox.Finite(position) || !float.IsFinite(rotation.LengthSquared()) ||
            Math.Abs(rotation.LengthSquared() - 1f) > RootRotationTolerance ||
            prefix.Length > MaximumPrefixLength || prefix.Any(char.IsControl))
        {
            throw new InvalidDataException("Invalid diagnostic obstacle pose root.");
        }
    }

    private static float[] Values(JsonElement value)
    {
        return value.EnumerateArray().Select(item => item.GetSingle()).ToArray();
    }
}
