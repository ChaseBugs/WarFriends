using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

// Source clip samples at 30Hz, with local-rig blending and explicit procedural
// overrides. Clip selection, blend weights and clocks remain host-owned inputs.
public sealed partial class PlayerPoseCatalog
{
    private sealed record Clip(float Length, PlayerCollisionModel[] Frames, Dictionary<string, RifleMuzzlePose[]> Muzzles, AimBone[][] Bones);
    private readonly Dictionary<string, Clip> clips;
    public string SourceHash { get; }
    public string Revision { get; }
    public int FrameCount => clips.Values.Sum(c => c.Frames.Length);
    public IReadOnlyList<string> ClipNames { get; }
    private static readonly string[] Expected = ["T_pose", "idle", "run", "player_look_left3", "player_fire_left3", "player_left_coverBack3",
        "player_look_right3", "player_fire_right3", "player_right_coverBack3", "rifle_shot_loop",
        "player_look_left_qbz", "player_fire_left_qbz", "player_left_coverBack_qbz",
        "player_look_right_qbz", "player_fire_right_qbz", "player_right_coverBack_qbz",
        "player_look_left_qbz2", "player_fire_left_qbz2", "player_left_coverBack_qbz2",
        "player_look_right_qbz2", "player_fire_right_qbz2", "player_right_coverBack_qbz2",
        "player_look_left_shotgun", "player_fire_left_shotgun", "player_left_coverBack_shotgun",
        "player_look_right_shotgun", "player_fire_right_shotgun", "player_right_coverBack_shotgun",
        "player_look_left_pistol", "player_fire_left_pistol", "player_left_coverBack_pistol",
        "player_look_right_pistol", "player_fire_right_pistol", "player_right_coverBack_pistol",
        "qbz_run", "qbz2_run", "shotgunner_run", "pistol_run", "shootAdditive",
        "player_look_left_minigun", "player_fire_left_minigun", "player_left_coverBack_minigun",
        "player_look_right_minigun", "player_fire_right_minigun", "player_right_coverBack_minigun",
        "minigun_run", "minigun_idle",
        "player_look_left_sniper", "player_fire_left_sniper", "player_left_coverBack_sniper",
        "player_look_right_sniper", "player_fire_right_sniper", "player_right_coverBack_sniper",
        "sniper_run", "sniper_idle",
        "bazooka_uncover_left", "bazooka_shoot_left", "bazooka_uncover_right", "bazooka_shoot_right",
        "bazooka_run", "bazooka_idle"];
    private static readonly string[] ExpectedRifles = new[] { "AK47", "AK47Elite", "AKS47U", "Famas", "FamasElite", "G36", "G36Elite", "M16", "QBZ95", "QBZ95Elite", "SteyrAUG" }
        .Select(x=>"Google2u.AssaultRifle_"+x).ToArray();
    private PlayerPoseCatalog(string hash, string revision, Dictionary<string, Clip> clips)
    { SourceHash = hash; Revision = revision; this.clips = clips; ClipNames = Array.AsReadOnly(Expected.ToArray()); }
    public float Duration(string name) => Get(name).Length;
    private Clip Get(string name) => clips.TryGetValue(name, out var clip) ? clip : throw new ArgumentException("Unsupported source pose clip.", nameof(name));

    // Explicit playback policy supplied by the server's animation state machine.
    // Hold last source sample within a tick; do not interpolate world colliders
    // and falsely claim to reproduce Unity's bone hierarchy interpolation.
    public PlayerCollisionModel Sample(string name, double seconds, bool loop)
    {
        var clip = Get(name);
        return clip.Frames[Frame(clip,seconds,loop)];
    }
    public RifleMuzzlePose SampleMuzzle(string name, string rifleId, double seconds, bool loop)
    {
        var clip=Get(name);
        if (!clip.Muzzles.TryGetValue(rifleId,out var samples)) throw new InvalidDataException("Unsupported pose rifle.");
        return samples[Frame(clip,seconds,loop)];
    }
    public PlayerAimPose SampleAimed(string name,double seconds,bool loop,Quaternion bodyLocal,Quaternion? upperLocal)
    {
        static void Valid(Quaternion q) { if (!float.IsFinite(q.LengthSquared()) || Math.Abs(q.LengthSquared()-1)>.0001f) throw new InvalidDataException("Invalid aim rotation."); }
        Valid(bodyLocal); if (upperLocal.HasValue) Valid(upperLocal.Value);
        var clip=Get(name); int index=Frame(clip,seconds,loop); var source=clip.Frames[index]; var bones=clip.Bones[index];
        (Vector3 P,Quaternion Q) Transform(string path,Vector3 p,Quaternion q)
        {
            // Apply child override in the sampled world, then move the full body.
            // This is equivalent to Unity updating the parent before the child.
            if (upperLocal.HasValue) (p,q)=bones[1].Apply(path,p,q,upperLocal.Value);
            return bones[0].Apply(path,p,q,bodyLocal);
        }
        var parts=source.Parts.Select(p=>
        {
            var t=Transform(p.SourcePath,p.Center,p.Rotation);
            var delta=t.Q*Quaternion.Inverse(p.Rotation);
            return new PlayerHitbox(p.SourcePath,p.Kind,p.Weight,t.P,p.Size,t.Q,p.Radius,
                p.Kind == PlayerHitboxKind.Capsule ? Vector3.Transform(p.Axis,delta) : Vector3.Zero,p.HalfSegment,p.Enabled,p.Active);
        }).ToArray();
        var collision=PlayerCollisionModel.InitializedFrame(source.SourceHash,source.SourcePath,source.RootPosition,source.RootRotation,parts);
        var muzzles=clip.Muzzles.ToDictionary(k=>k.Key,k=>
        {
            var m=k.Value[index]; var t=Transform(m.SourcePath,m.Position,m.Rotation);
            return m with { Position=t.P, Rotation=t.Q };
        },StringComparer.Ordinal);
        return new(collision,muzzles);
    }
    private static int Frame(Clip clip,double seconds,bool loop)
    {
        if (!double.IsFinite(seconds) || seconds is < 0 or > 86400) throw new ArgumentOutOfRangeException(nameof(seconds));
        if (loop) seconds %= clip.Length;
        if (seconds >= clip.Length) return clip.Frames.Length-1;
        return Math.Min(clip.Frames.Length-1, (int)Math.Floor(seconds*30));
    }

    public static PlayerPoseCatalog Load(string path, string expectedMainSceneHash, RifleBindingCatalog? bindings = null)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > 96*1024*1024) throw new InvalidDataException("Pose artifact exceeds bound.");
        string revision = Convert.ToHexStringLower(System.Security.Cryptography.SHA256.HashData(stream));
        stream.Position = 0;
        using var json = JsonDocument.Parse(stream, new JsonDocumentOptions { MaxDepth = 24 });
        var root = json.RootElement;
        string hash = root.GetProperty("sha256").GetString() ?? "";
        if (!Regex.IsMatch(hash, @"\A[0-9a-f]{64}\z") || hash != expectedMainSceneHash ||
            root.GetProperty("client").GetString() != "1.4.0" || root.GetProperty("source").GetString() != "Assets/Scenes/MainScene.unity" ||
            root.GetProperty("pose").GetString() != "initialized-single-clip-samples" || root.GetProperty("sampleRate").GetInt32() != 30 ||
            root.GetProperty("playerPath").GetString() != "MainSceneRootNew/Player") throw new InvalidDataException("Invalid pose provenance.");
        string playerPath = root.GetProperty("playerPath").GetString()!;
        var position = V(root.GetProperty("position")); var rotation = Q(root.GetProperty("rotation"));
        if (bindings != null && bindings.SceneRevision != hash) throw new InvalidDataException("Muzzle binding scene mismatch.");
        var rows = root.GetProperty("clips");
        if (rows.GetArrayLength() != Expected.Length) throw new InvalidDataException("Incomplete clip set.");
        var result = new Dictionary<string, Clip>(StringComparer.Ordinal);
        int index = 0;
        string[]? partNames = null;
        float[]? partWeights = null;
        string[]? muzzleIds = null;
        string[]? muzzlePaths = null;
        string[]? bonePaths = null;
        foreach (var row in rows.EnumerateArray())
        {
            string name = row.GetProperty("name").GetString() ?? "";
            string clipSource = row.GetProperty("source").GetString() ?? "";
            string sourceName = name == "idle" ? "idle_1" : name == "run" ? "run_0" : name;
            if (name != Expected[index++] || row.GetProperty("sourceName").GetString() != sourceName || !clipSource.StartsWith("Assets/", StringComparison.Ordinal) || clipSource.Contains("..", StringComparison.Ordinal) ||
                !Regex.IsMatch(row.GetProperty("guid").GetString() ?? "", @"\A[0-9a-f]{32}\z") || row.GetProperty("fileId").GetInt64() <= 0 ||
                !Regex.IsMatch(row.GetProperty("sha256").GetString() ?? "", @"\A[0-9a-f]{64}\z")) throw new InvalidDataException("Invalid clip identity.");
            float length = row.GetProperty("length").GetSingle();
            if (!float.IsFinite(length) || length is <= 0 or > 60) throw new InvalidDataException("Invalid clip duration.");
            var frames = row.GetProperty("frames");
            int expected = (int)MathF.Ceiling(length*30)+1;
            if (frames.GetArrayLength() != expected) throw new InvalidDataException("Truncated pose samples.");
            var snapshots = new PlayerCollisionModel[expected]; int frameIndex = 0;
            var muzzleFrames = new Dictionary<string,RifleMuzzlePose[]>(StringComparer.Ordinal);
            var boneFrames = new AimBone[expected][];
            foreach (var frame in frames.EnumerateArray())
            {
                float time = frame.GetProperty("seconds").GetSingle();
                if (!float.IsFinite(time) || Math.Abs(time-Math.Min(frameIndex/30f,length))>0.000001f) throw new InvalidDataException("Invalid sample ordering.");
                var boneRows=frame.GetProperty("aimBones").EnumerateArray().ToArray();
                if (boneRows.Length!=2) throw new InvalidDataException("Incomplete aim bones.");
                var bones=boneRows.Select(b=>
                {
                    var scale=V(b.GetProperty("parentScale"));
                    if (scale.X<=0 || Math.Abs(scale.X-scale.Y)>.00001f || Math.Abs(scale.X-scale.Z)>.00001f)
                        throw new InvalidDataException("Nonuniform aim parent scale requires affine rig support.");
                    return new AimBone(b.GetProperty("path").GetString()??"",V(b.GetProperty("position")),Q(b.GetProperty("rotation")),Q(b.GetProperty("parentRotation")));
                }).ToArray();
                if (!bones[0].Path.StartsWith(playerPath+"/",StringComparison.Ordinal) || !bones[1].Path.StartsWith(bones[0].Path+"/",StringComparison.Ordinal) || bones.Any(b=>b.Path.Length>1200))
                    throw new InvalidDataException("Invalid aim bone hierarchy.");
                bonePaths ??= bones.Select(b=>b.Path).ToArray();
                if (!bonePaths.SequenceEqual(bones.Select(b=>b.Path))) throw new InvalidDataException("Aim bones changed across frames.");
                boneFrames[frameIndex]=bones;
                var parts = frame.GetProperty("parts");
                if (parts.GetArrayLength()!=2) throw new InvalidDataException("Incomplete pose body parts.");
                var shapes = parts.EnumerateArray().Select(p => new PlayerHitbox(p.GetProperty("path").GetString() ?? "",
                    p.GetProperty("type").GetString() switch { "BoxCollider" => PlayerHitboxKind.Box, "SphereCollider" => PlayerHitboxKind.Sphere, _ => throw new InvalidDataException("Unsupported pose primitive.") },
                    p.GetProperty("weight").GetSingle(), V(p.GetProperty("center")), V(p.GetProperty("size")), Q(p.GetProperty("rotation")),
                    p.GetProperty("radius").GetSingle(), Vector3.Zero, 0, p.GetProperty("enabled").GetBoolean(), p.GetProperty("active").GetBoolean())).ToArray();
                partNames ??= shapes.Select(p => p.SourcePath).ToArray();
                partWeights ??= shapes.Select(p => p.Weight).ToArray();
                if (!partNames.SequenceEqual(shapes.Select(p => p.SourcePath))) throw new InvalidDataException("Part identities changed between samples.");
                if (!partWeights.SequenceEqual(shapes.Select(p => p.Weight))) throw new InvalidDataException("Animation cannot redefine base damage weights.");
                var muzzleRows=frame.GetProperty("muzzles").EnumerateArray().ToArray();
                if (muzzleRows.Length!=11) throw new InvalidDataException("Incomplete muzzle samples.");
                var ids=muzzleRows.Select(m=>m.GetProperty("id").GetString()??"").ToArray();
                var paths=muzzleRows.Select(m=>m.GetProperty("path").GetString()??"").ToArray();
                if (!ids.SequenceEqual(ExpectedRifles) ||
                    paths.Any(p=>p.Length>1200 || !p.StartsWith(playerPath+"/",StringComparison.Ordinal)))
                    throw new InvalidDataException("Invalid muzzle identities.");
                muzzleIds ??= ids; muzzlePaths ??= paths;
                if (!muzzleIds.SequenceEqual(ids) || !muzzlePaths.SequenceEqual(paths)) throw new InvalidDataException("Muzzle identities changed between frames.");
                for (int m=0;m<ids.Length;m++)
                {
                    if (bindings!=null && bindings.Get(ids[m]).MuzzlePath!=paths[m]) throw new InvalidDataException("Muzzle path differs from source binding.");
                    if (frameIndex==0) muzzleFrames.Add(ids[m],new RifleMuzzlePose[expected]);
                    muzzleFrames[ids[m]][frameIndex]=new(paths[m],V(muzzleRows[m].GetProperty("position")),Q(muzzleRows[m].GetProperty("rotation")),position,rotation);
                }
                snapshots[frameIndex++] = PlayerCollisionModel.InitializedFrame(hash, playerPath, position, rotation, shapes);
            }
            result.Add(name, new(length,snapshots,muzzleFrames,boneFrames));
        }
        var catalog=new PlayerPoseCatalog(hash,revision,result);
        catalog.LoadRig(root);
        return catalog;
    }
    private static Vector3 V(JsonElement e)
    {
        if (e.GetArrayLength()!=3) throw new InvalidDataException("Expected vector.");
        var v = new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());
        if (!PlayerHitbox.Finite(v)) throw new InvalidDataException("Invalid pose vector.");
        return v;
    }
    private static Quaternion Q(JsonElement e)
    {
        if (e.GetArrayLength()!=4) throw new InvalidDataException("Expected quaternion.");
        var q = new Quaternion(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
        if (!float.IsFinite(q.LengthSquared()) || Math.Abs(q.LengthSquared()-1)>0.0001f) throw new InvalidDataException("Invalid pose rotation.");
        return Quaternion.Normalize(q);
    }
}
