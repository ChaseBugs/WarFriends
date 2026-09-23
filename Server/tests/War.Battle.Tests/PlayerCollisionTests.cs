using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

internal static class PlayerCollisionTests
{
    internal static int Run(string path, RecoveredBattleMap map)
    {
        int count = 0;
        void Check(bool value, string name) { if (!value) throw new Exception(name); count++; }
        void Reject(Action action)
        {
            try { action(); } catch (Exception e) when (e is InvalidDataException or ArgumentException) { count++; return; }
            throw new Exception("Invalid collision authority accepted.");
        }
        var models = PlayerCollisionModel.Load(path);
        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        Vector3 V(JsonElement e) => new(e[0].GetSingle(), e[1].GetSingle(), e[2].GetSingle());
        int modelIndex = 0;
        foreach (var m in doc.RootElement.GetProperty("models").EnumerateArray())
        {
            int partIndex = 0;
            foreach (var p in m.GetProperty("parts").EnumerateArray())
            {
                var part = models[modelIndex].Parts[partIndex++];
                foreach (var ray in p.GetProperty("rays").EnumerateArray())
                {
                    float? hit = part.Raycast(V(ray.GetProperty("origin")), V(ray.GetProperty("direction")), ray.GetProperty("distance").GetSingle());
                    Check(hit.HasValue == ray.GetProperty("hit").GetBoolean() && (!hit.HasValue || Math.Abs(hit.Value-ray.GetProperty("hitDistance").GetSingle())<0.0002f), "Unity part-ray parity");
                }
                Check(part.Raycast(part.Center, Vector3.UnitX, 10) == null, "inside origins do not hit");
            }
            modelIndex++;
        }
        var gameplay = models.Single(m => m.Role == "gameplay");
        Check(gameplay.Parts.Count == 2 && gameplay.Parts.Count(p => p.Enabled) == 1, "source enabled-state conservation");
        var rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0.8f);
        var target = gameplay.Place(new Vector3(2,3,4), rotation);
        var originalPart = gameplay.Parts[0]; var placedPart = target.Parts[0];
        var delta = rotation*Quaternion.Inverse(gameplay.RootRotation);
        var origin = originalPart.Center+Vector3.UnitX*5;
        var movedOrigin = target.RootPosition+Vector3.Transform(origin-gameplay.RootPosition, delta);
        Check(Math.Abs(originalPart.Raycast(origin, -Vector3.UnitX, 10)!.Value-placedPart.Raycast(movedOrigin, Vector3.Transform(-Vector3.UnitX, delta), 10)!.Value)<0.0001f, "rigid pose invariance");
        Check(gameplay.RootPosition != target.RootPosition && gameplay.Parts[1].Enabled == target.Parts[1].Enabled, "placement does not mutate source or enable disabled shapes");
        var capsule = new PlayerHitbox("fixture/capsule", PlayerHitboxKind.Capsule, 1, Vector3.Zero, Vector3.Zero, Quaternion.Identity, 0.5f, Vector3.UnitY, 1);
        Check(Math.Abs(capsule.Raycast(new(2,0,0), -Vector3.UnitX, 10)!.Value-1.5f)<0.00001f, "capsule cylinder");
        Check(Math.Abs(capsule.Raycast(new(0,3,0), -Vector3.UnitY, 10)!.Value-1.5f)<0.00001f, "capsule cap");
        Check(capsule.Raycast(new(2,3,0), -Vector3.UnitX, 10) == null, "capsule miss");
        Check(capsule.Raycast(new(2,0,0), -Vector3.UnitX, 1) == null, "finite range");
        Reject(() => capsule.Raycast(Vector3.Zero, Vector3.Zero, 1));
        Reject(() => gameplay.Place(Vector3.Zero, new Quaternion(0,0,0,0)));
        Reject(() => new PlayerHitbox("x", PlayerHitboxKind.Sphere, float.NaN, Vector3.Zero, Vector3.Zero, Quaternion.Identity, 1, Vector3.Zero, 0));
        string a = new('a',32), b = new('b',32);
        var world = new ShotCollisionWorld(null, [new(a, gameplay), new(b, target)]);
        var hitPlayer = world.Raycast(a, movedOrigin, Vector3.Transform(-Vector3.UnitX, delta), 10);
        Check(hitPlayer?.PlayerId == b && hitPlayer.PartWeight == placedPart.Weight, "host resolves target identity and part weight");
        Reject(() => new ShotCollisionWorld(null, [new(a, models.Single(m => m.Role == "preview")), new(b, target)]));
        Reject(() => world.Raycast(new string('c',32), movedOrigin, -Vector3.UnitX, 10));
        Reject(() => world.Raycast(a, movedOrigin, -Vector3.UnitX, float.NaN));
        // Use a source ground hit to put a player behind real geometry.
        var groundOrigin = map.Covers[0].Position + Vector3.UnitY*5;
        var ground = map.Raycast(groundOrigin, -Vector3.UnitY, 100) ?? throw new Exception("No source ground hit.");
        Check(map.Raycast(groundOrigin, -Vector3.UnitY, ground.Distance)?.SourcePath == ground.SourcePath, "map includes exact range boundary");
        var behind = gameplay.Place(ground.Position-Vector3.UnitY*3, Quaternion.Identity);
        var blocked = new ShotCollisionWorld(map, [new(a, gameplay), new(b, behind)]).Raycast(a, groundOrigin, -Vector3.UnitY, 100);
        Check(blocked != null && blocked.PlayerId == null && blocked.SourcePath == ground.SourcePath, "map occludes player behind geometry");

        var json = JsonNode.Parse(File.ReadAllText(path))!;
        string temp = System.IO.Path.GetTempFileName();
        try
        {
            json["models"]![0]!["parts"]!.AsArray().RemoveAt(1);
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerCollisionModel.Load(temp));
        }
        finally { File.Delete(temp); }
        return count;
    }
}
