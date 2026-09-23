using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record PlayerHit(float Distance, Vector3 Position, string PartPath, float Weight);

// Serialized reference pose only; no caller can promote it to an animated stance.
public sealed class PlayerCollisionModel
{
    public string SourceHash { get; }
    public string SourcePath { get; }
    public string Role { get; }
    public string PoseKind { get; }
    public Vector3 RootPosition { get; }
    public Quaternion RootRotation { get; }
    public IReadOnlyList<PlayerHitbox> Parts { get; }
    private PlayerCollisionModel(string hash, string path, string role, Vector3 position, Quaternion rotation, PlayerHitbox[] parts, string poseKind = "serialized-reference-only")
    { SourceHash = hash; SourcePath = path; Role = role; PoseKind = poseKind; RootPosition = position; RootRotation = rotation; Parts = Array.AsReadOnly(parts); }

    internal static PlayerCollisionModel InitializedFrame(string hash, string path, Vector3 position, Quaternion rotation, PlayerHitbox[] parts,string poseKind="initialized-single-clip-samples")
    {
        if (poseKind is not ("initialized-single-clip-samples" or "local-rig-blend") || parts.Length != 2 || parts.Any(p => !p.Enabled || !p.Active) || parts[0].Kind != PlayerHitboxKind.Box || parts[1].Kind != PlayerHitboxKind.Sphere ||
            parts.Select(p => p.SourcePath).Distinct(StringComparer.Ordinal).Count() != 2 || parts.Any(p => !p.SourcePath.StartsWith(path+"/", StringComparison.Ordinal)))
            throw new InvalidDataException("Invalid initialized player part snapshot.");
        return new(hash, path, "gameplay", position, rotation, parts.ToArray(), poseKind);
    }

    public PlayerHit? Raycast(Vector3 origin, Vector3 direction, float maxDistance)
    {
        PlayerHit? nearest = null;
        foreach (var part in Parts)
        {
            if (!part.Enabled || !part.Active) continue;
            var hit = part.Raycast(origin, direction, maxDistance);
            if (hit.HasValue && (nearest == null || hit.Value < nearest.Distance))
                nearest = new(hit.Value, origin+Vector3.Normalize(direction)*hit.Value, part.SourcePath, part.Weight);
        }
        return nearest;
    }

    public PlayerCollisionModel Place(Vector3 position, Quaternion rotation)
    {
        if (!PlayerHitbox.Finite(position) || !float.IsFinite(rotation.LengthSquared()) || Math.Abs(rotation.LengthSquared()-1)>0.0001f)
            throw new InvalidDataException("Invalid server pose.");
        rotation = Quaternion.Normalize(rotation);
        var delta = Quaternion.Normalize(rotation * Quaternion.Inverse(RootRotation));
        var parts = Parts.Select(p =>
        {
            var center=position+Vector3.Transform(p.Center-RootPosition,delta);
            var transform=position+Vector3.Transform(p.TransformPosition-RootPosition,delta);
            var partRotation=Quaternion.Normalize(delta*p.Rotation);
            var axis=p.Axis==Vector3.Zero ? Vector3.Zero :
                Vector3.Normalize(Vector3.Transform(p.Axis,delta));
            return new PlayerHitbox(p.SourcePath,p.Kind,p.Weight,center,p.Size,
                partRotation,p.Radius,axis,p.HalfSegment,p.Enabled,p.Active,transform);
        }).ToArray();
        return new(SourceHash, SourcePath, Role, position, rotation, parts, PoseKind);
    }

    public static IReadOnlyList<PlayerCollisionModel> Load(string path)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > 4*1024*1024) throw new InvalidDataException("Player collision artifact exceeds bound.");
        using var doc = JsonDocument.Parse(stream, new JsonDocumentOptions { MaxDepth = 24 });
        var root = doc.RootElement;
        if (root.GetProperty("client").GetString() != "1.4.0" || root.GetProperty("source").GetString() != "Assets/Scenes/MainScene.unity" ||
            root.GetProperty("pose").GetString() != "serialized-reference-only") throw new InvalidDataException("Wrong collision provenance/pose.");
        string hash = root.GetProperty("sha256").GetString() ?? "";
        if (!Regex.IsMatch(hash, @"\A[0-9a-f]{64}\z")) throw new InvalidDataException("Invalid collision digest.");
        var models = root.GetProperty("models");
        if (models.GetArrayLength() != 2) throw new InvalidDataException("Expected gameplay and preview reference models.");
        var result = new List<PlayerCollisionModel>();
        var names = new HashSet<string>(StringComparer.Ordinal);
        var roles = new HashSet<string>(StringComparer.Ordinal);
        foreach (var model in models.EnumerateArray())
        {
            string name = model.GetProperty("path").GetString() ?? "";
            string role = model.GetProperty("role").GetString() ?? "";
            if (role is not ("gameplay" or "preview") || !roles.Add(role)) throw new InvalidDataException("Invalid/duplicate model role.");
            if (name.Length is < 1 or > 1024 || name.Any(char.IsControl) || !names.Add(name)) throw new InvalidDataException("Duplicate/invalid model.");
            var parts = model.GetProperty("parts");
            if (parts.GetArrayLength() != 2) throw new InvalidDataException("Expected both recovered part colliders.");
            var rows = new List<PlayerHitbox>(); var paths = new HashSet<string>(StringComparer.Ordinal);
            foreach (var p in parts.EnumerateArray())
            {
                string identity = p.GetProperty("path").GetString() ?? "";
                if (!identity.StartsWith(name+"/", StringComparison.Ordinal) || !paths.Add(identity)) throw new InvalidDataException("Invalid part identity.");
                var kind = p.GetProperty("type").GetString() switch { "BoxCollider" => PlayerHitboxKind.Box, "SphereCollider" => PlayerHitboxKind.Sphere,
                    "CapsuleCollider" => PlayerHitboxKind.Capsule, _ => throw new InvalidDataException("Unsupported player collision shape.") };
                if (p.GetProperty("trigger").GetBoolean()) throw new InvalidDataException("Trigger cannot define a player hit part.");
                rows.Add(new(identity, kind, p.GetProperty("weight").GetSingle(), Vector(p.GetProperty("center")), Vector(p.GetProperty("size")),
                    Rotation(p.GetProperty("rotation")), p.GetProperty("radius").GetSingle(), Vector(p.GetProperty("axis")), p.GetProperty("halfSegment").GetSingle(),
                    p.GetProperty("enabled").GetBoolean(), p.GetProperty("active").GetBoolean()));
            }
            result.Add(new(hash, name, role, Vector(model.GetProperty("position")), Rotation(model.GetProperty("rotation")), rows.ToArray()));
        }
        return result.AsReadOnly();
    }
    private static Vector3 Vector(JsonElement e)
    {
        if (e.GetArrayLength()!=3) throw new InvalidDataException("Expected Vector3.");
        var v = new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());
        if (!PlayerHitbox.Finite(v)) throw new InvalidDataException("Invalid finite Vector3.");
        return v;
    }
    private static Quaternion Rotation(JsonElement e)
    {
        if (e.GetArrayLength()!=4) throw new InvalidDataException("Expected Quaternion.");
        var q = new Quaternion(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
        if (!float.IsFinite(q.LengthSquared()) || Math.Abs(q.LengthSquared()-1)>0.0001f) throw new InvalidDataException("Invalid Quaternion.");
        return Quaternion.Normalize(q);
    }
}
