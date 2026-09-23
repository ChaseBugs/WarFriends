using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoverNode(int SourceIndex, int Fraction, bool Main, Vector3 Position, Vector3 ShotPosition, float ShieldBaseHealth,Quaternion Rotation,string SourcePath);
public sealed record MapHit(float Distance, Vector3 Position, string SourcePath, string? DynamicOwner, int Layer, int ColliderIndex);
public sealed record MapDynamicCollider(int ColliderIndex, string SourcePath, string DynamicOwner, int Layer,
    Vector3 TransformPosition,Vector3 BoundsMin,Vector3 BoundsMax);
public sealed record MapSphereCandidate(MapDynamicCollider Collider,float BoundsDistance);

/// <summary>Read-only collision/navigation data exported from the actual Unity maps.
/// Geometry query only: damage, shield regeneration and target ownership remain
/// separate simulation rules. Do not treat the map's serialized base HP as player HP.</summary>
public sealed class RecoveredBattleMap
{
    private sealed record Shape(int SourceIndex, string Path, string? DynamicOwner, int Layer, Vector3 TransformPosition,
        Vector3 Min, Vector3 Max, Vector3[] Triangles, Vector4[]? Hull);
    private readonly Shape[] shapes;
    private readonly Dictionary<(int, int), Vector3[]> paths;
    private readonly CoverNode[] covers;
    public string Source { get; }
    public string SourceHash { get; }
    public IReadOnlyList<CoverNode> Covers => Array.AsReadOnly(covers);
    public int ColliderCount => shapes.Length;
    public IReadOnlyList<MapDynamicCollider> DynamicColliders => Array.AsReadOnly(shapes.Where(s=>s.DynamicOwner!=null)
        .Select(s=>Dynamic(s)).ToArray());
    private static MapDynamicCollider Dynamic(Shape s)=>new(s.SourceIndex,s.Path,s.DynamicOwner!,s.Layer,
        s.TransformPosition,s.Min,s.Max);
    /// <summary>Broadphase only. AABB candidates need source layer/component and
    /// Unity-equivalent shape overlap checks before they can authorize damage.</summary>
    public IReadOnlyList<MapSphereCandidate> DynamicSphereCandidates(Vector3 center,float radius,
        uint layerMask=uint.MaxValue,Func<int,bool>? colliderEnabled=null,
        Func<int,int,int>? runtimeLayer=null)
    {
        if(!Finite(center) || !float.IsFinite(radius) || radius is <=0 or >100)
            throw new ArgumentOutOfRangeException(nameof(radius));
        var result=new List<MapSphereCandidate>();
        foreach(var shape in shapes)
        {
            int layer=runtimeLayer?.Invoke(shape.SourceIndex,shape.Layer) ?? shape.Layer;
            if(layer is <0 or >31)throw new InvalidDataException("Invalid dynamic runtime layer.");
            if(shape.DynamicOwner==null || (layerMask&(1u<<layer))==0 ||
               (colliderEnabled!=null && !colliderEnabled(shape.SourceIndex)))continue;
            Vector3 nearest=Vector3.Clamp(center,shape.Min,shape.Max);
            float distance=Vector3.Distance(center,nearest);
            if(distance<=radius)result.Add(new(Dynamic(shape) with {Layer=layer},distance));
        }
        return Array.AsReadOnly(result.OrderBy(c=>c.Collider.ColliderIndex).ToArray());
    }
    internal IReadOnlyList<MapDynamicCollider> DynamicSphereOverlaps(Vector3 center,float radius,uint layerMask=uint.MaxValue,
        Func<int,bool>? colliderEnabled=null,Func<int,int,int>? runtimeLayer=null)
    {
        var candidates=DynamicSphereCandidates(center,radius,layerMask,colliderEnabled,runtimeLayer);
        var result=new List<MapDynamicCollider>();
        foreach(var candidate in candidates)
        {
            var shape=shapes.Single(x=>x.SourceIndex==candidate.Collider.ColliderIndex);
            bool inside=shape.Hull!=null&&shape.Hull.All(p=>Vector3.Dot(new Vector3(p.X,p.Y,p.Z),center)+p.W<=0);
            bool overlap=inside;
            for(int i=0;!overlap&&i<shape.Triangles.Length;i+=3)
                overlap=PointTriangleDistanceSquared(center,shape.Triangles[i],shape.Triangles[i+1],shape.Triangles[i+2])<=radius*radius;
            if(overlap)result.Add(candidate.Collider);
        }
        return Array.AsReadOnly(result.ToArray());
    }
    private static float PointTriangleDistanceSquared(Vector3 p,Vector3 a,Vector3 b,Vector3 c)
    {
        var ab=b-a;var ac=c-a;var ap=p-a;float d1=Vector3.Dot(ab,ap),d2=Vector3.Dot(ac,ap);
        if(d1<=0&&d2<=0)return Vector3.DistanceSquared(p,a);
        var bp=p-b;float d3=Vector3.Dot(ab,bp),d4=Vector3.Dot(ac,bp);if(d3>=0&&d4<=d3)return Vector3.DistanceSquared(p,b);
        float vc=d1*d4-d3*d2;if(vc<=0&&d1>=0&&d3<=0){float v=d1/(d1-d3);return Vector3.DistanceSquared(p,a+v*ab);}
        var cp=p-c;float d5=Vector3.Dot(ab,cp),d6=Vector3.Dot(ac,cp);if(d6>=0&&d5<=d6)return Vector3.DistanceSquared(p,c);
        float vb=d5*d2-d1*d6;if(vb<=0&&d2>=0&&d6<=0){float w=d2/(d2-d6);return Vector3.DistanceSquared(p,a+w*ac);}
        float va=d3*d6-d5*d4;if(va<=0&&d4-d3>=0&&d5-d6>=0){float w=(d4-d3)/((d4-d3)+(d5-d6));return Vector3.DistanceSquared(p,b+w*(c-b));}
        float denominator=1/(va+vb+vc),v2=vb*denominator,w2=vc*denominator;return Vector3.DistanceSquared(p,a+ab*v2+ac*w2);
    }
    public int PathCount => paths.Count;
    public int ConvexColliderCount { get; private init; }
    private static Quaternion CoverRotation(JsonElement value)
    {
        if (value.GetArrayLength()!=4) throw new InvalidDataException("Invalid cover rotation.");
        var q=new Quaternion(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle(),value[3].GetSingle());
        if (!float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.0001f) throw new InvalidDataException("Invalid cover rotation.");
        return Quaternion.Normalize(q);
    }
    private RecoveredBattleMap(string source, string hash, CoverNode[] covers, Dictionary<(int, int), Vector3[]> paths, Shape[] shapes)
    {
        Source = source; SourceHash = hash; this.covers = covers; this.paths = paths; this.shapes = shapes;
    }
    public Vector3[] Path(int from, int to) => paths.TryGetValue((from, to), out var p) ? p.ToArray() : throw new InvalidOperationException("No recovered complete path for that transition.");
    public int Adjacent(int from, int direction, int fraction)
    {
        if (from < 0 || from >= covers.Length || direction is not (-1 or 1) || covers[from].Fraction != fraction) return -1;
        for (int i = from + direction; i >= 0 && i < covers.Length; i += direction)
            if (covers[i].Fraction == fraction) return paths.ContainsKey((from, i)) ? i : -1;
        return -1;
    }
    public static IReadOnlyList<RecoveredBattleMap> Load(string file)
    {
        using var stream = File.OpenRead(file);
        if (stream.Length > 32 * 1024 * 1024) throw new InvalidDataException("Battle content exceeds the load bound.");
        using var json = JsonDocument.Parse(stream, new JsonDocumentOptions { MaxDepth = 32 });
        var root = json.RootElement;
        if (root.GetProperty("client").GetString() != "1.4.0") throw new InvalidDataException("Wrong Client content version.");
        var maps = root.GetProperty("maps");
        if (maps.GetArrayLength() != 5) throw new InvalidDataException("Expected all five recovered multiplayer maps.");
        var expected = new HashSet<string>(StringComparer.Ordinal) { "Aztec_Multiplayer", "City_Multiplayer", "Desert_Multiplayer", "Park_Multiplayer", "Snow_Multiplayer" };
        var result = new List<RecoveredBattleMap>();
        foreach (var map in maps.EnumerateArray())
        {
            string source = map.GetProperty("source").GetString() ?? "";
            if (!expected.Remove(System.IO.Path.GetFileNameWithoutExtension(source))) throw new InvalidDataException("Duplicate/unrecognized map identity.");
            string hash = map.GetProperty("sha256").GetString() ?? "";
            if (!System.Text.RegularExpressions.Regex.IsMatch(hash, @"\A[0-9a-f]{64}\z")) throw new InvalidDataException("Invalid source digest.");
            var nodes = map.GetProperty("points").EnumerateArray().Select(p => new CoverNode(p.GetProperty("sourceIndex").GetInt32(), p.GetProperty("fraction").GetInt32(),
                p.GetProperty("main").GetBoolean(), Vector(p.GetProperty("position")), Vector(p.GetProperty("shotPosition")), Number(p.GetProperty("shieldBaseHealth"), 0, 10000000),CoverRotation(p.GetProperty("rotation")),
                p.GetProperty("path").GetString()??"")).ToArray();
            string rootName=System.IO.Path.GetFileNameWithoutExtension(source) switch
            {"Aztec_Multiplayer"=>"LevelRootAztec","Park_Multiplayer"=>"LevelRootPark",_=>"LevelRoot"};
            if (nodes.Length != 8 || nodes.Where((p, i) => p.SourceIndex != i || p.Fraction is not (1 or 2) || p.ShieldBaseHealth <= 0).Any() ||
                nodes.Any(p=>p.SourcePath.Length is <1 or >1024 || p.SourcePath.Any(char.IsControl) ||
                    p.SourcePath!=rootName+"/DefendPositions/"+(p.Fraction==1?"Enemies":"Allies")+
                        "/DefendPositionSingleLeft"+(p.SourceIndex%4).ToString(System.Globalization.CultureInfo.InvariantCulture)) ||
                new[] { 1, 2 }.Any(f => nodes.Count(p => p.Fraction == f) != 4 || nodes.Count(p => p.Fraction == f && p.Main) != 2))
                throw new InvalidDataException("Invalid cover identity/side/start snapshot.");
            var navigation = new Dictionary<(int, int), Vector3[]>();
            foreach (var path in map.GetProperty("paths").EnumerateArray())
            {
                int from = path.GetProperty("from").GetInt32(), to = path.GetProperty("to").GetInt32();
                if (from is < 0 or >= 8 || to is < 0 or >= 8 || from == to || nodes[from].Fraction != nodes[to].Fraction ||
                    !path.GetProperty("complete").GetBoolean()) throw new InvalidDataException("Invalid/incomplete recovered navigation edge.");
                var corners = path.GetProperty("corners").EnumerateArray().Select(Vector).ToArray();
                if (corners.Length is < 2 or > 64 || Vector3.Distance(corners[0], nodes[from].Position) > 0.5f || Vector3.Distance(corners[^1], nodes[to].Position) > 0.5f ||
                    !navigation.TryAdd((from, to), corners)) throw new InvalidDataException("Invalid path endpoints/duplicate edge.");
            }
            if (navigation.Count != 12) throw new InvalidDataException("Truncated recovered navigation graph.");
            var collision = new List<Shape>();
            int convex = 0;
            var colliders = map.GetProperty("colliders");
            if (colliders.GetArrayLength() is < 1 or > 4096) throw new InvalidDataException("Invalid collider count.");
            for(int colliderIndex=0;colliderIndex<colliders.GetArrayLength();colliderIndex++)
            {
                var collider=colliders[colliderIndex];
                // Validate supported geometry even when the collider is initially inactive.
                string type = collider.GetProperty("type").GetString() ?? "";
                int layer = collider.GetProperty("layer").GetInt32();
                if (layer is < 0 or > 31) throw new InvalidDataException("Invalid layer.");
                var values = collider.GetProperty("matrix").EnumerateArray().Select(x => Number(x, -10000, 10000)).ToArray();
                if (values.Length != 16) throw new InvalidDataException("Invalid transform.");
                var matrix = new Matrix4x4(values[0],values[1],values[2],values[3],values[4],values[5],values[6],values[7],values[8],values[9],values[10],values[11],values[12],values[13],values[14],values[15]);
                Vector3[] vertices;
                int[] indices;
                if (type == "BoxCollider")
                {
                    Vector3 center = Vector(collider.GetProperty("boxCenter")), half = Vector(collider.GetProperty("boxSize")) / 2;
                    if (half.X <= 0 || half.Y <= 0 || half.Z <= 0) throw new InvalidDataException("Invalid box dimensions.");
                    vertices = new Vector3[8];
                    for (int i = 0; i < 8; i++) vertices[i] = center + new Vector3((i & 1) == 0 ? -half.X : half.X, (i & 2) == 0 ? -half.Y : half.Y, (i & 4) == 0 ? -half.Z : half.Z);
                    indices = [0,2,1,1,2,3,4,5,6,5,7,6,0,1,4,1,5,4,2,6,3,3,6,7,0,4,2,2,4,6,1,3,5,3,7,5];
                }
                else if (type == "MeshCollider")
                {
                    // A source MeshCollider with no sharedMesh has no physics shape.
                    if (collider.GetProperty("meshId").ValueKind == JsonValueKind.Null && collider.GetProperty("meshAsset").ValueKind == JsonValueKind.Null) continue;
                    string meshId = collider.GetProperty("meshId").GetString() ?? throw new InvalidDataException("Missing mesh ID.");
                    var mesh = root.GetProperty("meshes").GetProperty(meshId);
                    vertices = mesh.GetProperty("vertices").EnumerateArray().Select(Vector).ToArray();
                    indices = mesh.GetProperty("triangles").EnumerateArray().Select(x => x.GetInt32()).ToArray();
                    if (vertices.Length is < 3 or > 100000 || indices.Length is < 3 or > 300000 || indices.Length % 3 != 0 || indices.Any(i => i < 0 || i >= vertices.Length))
                        throw new InvalidDataException("Invalid mesh geometry.");
                }
                else throw new InvalidDataException("Unsupported recovered collider type: " + type);
                for (int i = 0; i < vertices.Length; i++) vertices[i] = Vector3.Transform(vertices[i], matrix);
                if (!collider.GetProperty("enabled").GetBoolean() || !collider.GetProperty("active").GetBoolean() || collider.GetProperty("trigger").GetBoolean()) continue;
                if (collider.GetProperty("meshConvex").GetBoolean()) convex++;
                Vector3 min = vertices.Aggregate(Vector3.Min), max = vertices.Aggregate(Vector3.Max);
                Vector4[]? hull = collider.GetProperty("meshConvex").GetBoolean() ? HullPlanes(vertices) : null;
                collision.Add(new Shape(colliderIndex,collider.GetProperty("path").GetString()!, collider.GetProperty("dynamicOwner").GetString(), layer,
                    Vector3.Transform(Vector3.Zero,matrix),min,max,hull == null ? indices.Select(i => vertices[i]).ToArray() : [], hull));
            }
            foreach(var cover in nodes)
            {
                string owner=cover.SourcePath+"/riot_shield";
                if(collision.Count(s=>s.Path==owner && s.DynamicOwner==owner && s.Layer==24)!=1)
                    throw new InvalidDataException("Missing source-bound shield collider.");
            }
            result.Add(new RecoveredBattleMap(source, hash, nodes, navigation, collision.ToArray()) { ConvexColliderCount = convex });
        }
        return result.AsReadOnly();
    }
    private static float Number(JsonElement value, float min, float max)
    {
        float f = value.GetSingle();
        if (!float.IsFinite(f) || f < min || f > max) throw new InvalidDataException("Invalid geometry scalar.");
        return f;
    }
    private static Vector3 Vector(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Array || value.GetArrayLength() != 3) throw new InvalidDataException("Expected finite Vector3.");
        return new Vector3(Number(value[0], -10000, 10000), Number(value[1], -10000, 10000), Number(value[2], -10000, 10000));
    }
    public MapHit? Raycast(Vector3 origin, Vector3 direction, float distance, uint layerMask = uint.MaxValue,
        Func<string,bool>? dynamicEnabled=null,Func<int,bool>? colliderEnabled=null,
        Func<int,int,int>? runtimeLayer=null)
    {
        if (!Finite(origin) || !Finite(direction) || !float.IsFinite(distance) || distance <= 0 || distance > 10000 || direction.LengthSquared() < 0.000001f)
            throw new ArgumentOutOfRangeException(nameof(direction));
        direction = Vector3.Normalize(direction);
        MapHit? nearest = null;
        foreach (var shape in shapes)
        {
            int layer=runtimeLayer?.Invoke(shape.SourceIndex,shape.Layer) ?? shape.Layer;
            if(layer is <0 or >31)throw new InvalidDataException("Invalid dynamic runtime layer.");
            if ((layerMask & (1u << layer)) == 0 ||
                (shape.DynamicOwner!=null && dynamicEnabled!=null && !dynamicEnabled(shape.DynamicOwner)) ||
                (colliderEnabled!=null && !colliderEnabled(shape.SourceIndex)) ||
                !BoundsHit(origin, direction, shape.Min, shape.Max, distance)) continue;
            if (shape.Hull != null)
            {
                float? hullHit = HullHit(shape.Hull, origin, direction, distance);
                if (hullHit.HasValue && hullHit.Value <= distance && (nearest == null || hullHit.Value < nearest.Distance))
                {
                    distance = hullHit.Value;
                    nearest = new MapHit(distance, origin + direction * distance, shape.Path, shape.DynamicOwner, layer,shape.SourceIndex);
                }
                continue;
            }
            for (int i = 0; i < shape.Triangles.Length; i += 3)
            {
                float? hit = TriangleHit(origin, direction, shape.Triangles[i], shape.Triangles[i+1], shape.Triangles[i+2]);
                if (hit.HasValue && hit.Value <= distance && (nearest == null || hit.Value < nearest.Distance))
                {
                    distance = hit.Value;
                    nearest = new MapHit(distance, origin + direction * distance, shape.Path, shape.DynamicOwner, layer,shape.SourceIndex);
                }
            }
        }
        return nearest;
    }
    private static bool Finite(Vector3 v) => float.IsFinite(v.X) && float.IsFinite(v.Y) && float.IsFinite(v.Z);
    private static Vector4[] HullPlanes(Vector3[] input)
    {
        // The recovered convex meshes have only 16/36 vertices. A bounded support
        // plane construction preserves convex collision rather than using the
        // concave render triangles. Larger future meshes require a new importer.
        var vertices = input.Distinct().ToArray();
        if (vertices.Length is < 4 or > 64) throw new InvalidDataException("Unsupported convex hull vertex count.");
        var planes = new List<Vector4>();
        for (int a = 0; a < vertices.Length-2; a++)
        for (int b = a+1; b < vertices.Length-1; b++)
        for (int c = b+1; c < vertices.Length; c++)
        {
            Vector3 normal = Vector3.Cross(vertices[b]-vertices[a], vertices[c]-vertices[a]);
            if (normal.LengthSquared() < 1e-12f) continue;
            normal = Vector3.Normalize(normal);
            float offset = -Vector3.Dot(normal, vertices[a]);
            bool positive = false, negative = false;
            foreach (var vertex in vertices)
            {
                float side = Vector3.Dot(normal, vertex)+offset;
                positive |= side > 0.00001f; negative |= side < -0.00001f;
                if (positive && negative) break;
            }
            if (positive == negative) continue;
            if (positive) { normal = -normal; offset = -offset; }
            if (!planes.Any(p => Vector3.Dot(new Vector3(p.X,p.Y,p.Z), normal) > 0.99999f && Math.Abs(p.W-offset) < 0.00001f))
                planes.Add(new Vector4(normal, offset));
        }
        if (planes.Count < 4) throw new InvalidDataException("Degenerate convex mesh.");
        return planes.ToArray();
    }
    private static float? HullHit(Vector4[] planes, Vector3 origin, Vector3 ray, float far)
    {
        float near = 0;
        bool inside = true;
        foreach (var plane in planes)
        {
            var normal = new Vector3(plane.X,plane.Y,plane.Z);
            float side = Vector3.Dot(normal,origin)+plane.W;
            inside &= side <= 0;
            float denominator = Vector3.Dot(normal,ray);
            if (Math.Abs(denominator) < 1e-8f) { if (side > 0) return null; continue; }
            float t = -side/denominator;
            if (denominator < 0) near = Math.Max(near,t); else far = Math.Min(far,t);
            if (near > far) return null;
        }
        return inside ? null : near;
    }
    private static bool BoundsHit(Vector3 origin, Vector3 ray, Vector3 min, Vector3 max, float far)
    {
        float near = 0;
        for (int i = 0; i < 3; i++)
        {
            if (Math.Abs(ray[i]) < 1e-8f) { if (origin[i] < min[i] || origin[i] > max[i]) return false; continue; }
            float a = (min[i] - origin[i]) / ray[i], b = (max[i] - origin[i]) / ray[i];
            near = Math.Max(near, Math.Min(a, b)); far = Math.Min(far, Math.Max(a, b));
            if (near > far) return false;
        }
        return true;
    }
    private static float? TriangleHit(Vector3 origin, Vector3 ray, Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 ab = b-a, ac = c-a, cross = Vector3.Cross(ray, ac);
        float determinant = Vector3.Dot(ab, cross);
        if (determinant < 1e-7f) return null; // Unity default: do not hit mesh back faces.
        float inverse = 1 / determinant;
        Vector3 relative = origin-a;
        float u = Vector3.Dot(relative, cross) * inverse;
        if (u < 0 || u > 1) return null;
        Vector3 q = Vector3.Cross(relative, ab);
        float v = Vector3.Dot(ray, q) * inverse;
        if (v < 0 || u+v > 1) return null;
        float t = Vector3.Dot(ac, q) * inverse;
        return t >= 0 ? t : null;
    }
}
