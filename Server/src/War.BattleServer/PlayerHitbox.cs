using System.Numerics;

namespace War.BattleServer;

public enum PlayerHitboxKind { Box, Sphere, Capsule }
public sealed record PlayerHitbox
{
    public string SourcePath { get; }
    public PlayerHitboxKind Kind { get; }
    public float Weight { get; }
    public Vector3 Center { get; }
    public Vector3 TransformPosition { get; }
    public Vector3 Size { get; }
    public Quaternion Rotation { get; }
    public float Radius { get; }
    public Vector3 Axis { get; }
    public float HalfSegment { get; }
    public bool Enabled { get; }
    public bool Active { get; }

    public PlayerHitbox(string sourcePath, PlayerHitboxKind kind, float weight, Vector3 center,
        Vector3 size, Quaternion rotation, float radius, Vector3 axis, float halfSegment, bool enabled = true, bool active = true,
        Vector3? transformPosition = null)
    {
        if (string.IsNullOrEmpty(sourcePath) || sourcePath.Length > 1024 || sourcePath.Any(char.IsControl) || !Enum.IsDefined(kind) ||
            !float.IsFinite(weight) || weight is < 0 or > 1000 || !Finite(center) ||
            (transformPosition.HasValue && !Finite(transformPosition.Value)) || !Finite(size) || !Finite(axis) ||
            !float.IsFinite(rotation.LengthSquared()) || Math.Abs(rotation.LengthSquared()-1) > 0.0001f ||
            !float.IsFinite(radius) || !float.IsFinite(halfSegment) || radius is < 0 or > 100 || halfSegment is < 0 or > 100 ||
            (kind == PlayerHitboxKind.Box && (size.X <= 0 || size.Y <= 0 || size.Z <= 0 || size.X > 100 || size.Y > 100 || size.Z > 100 || radius != 0 || halfSegment != 0 || axis != Vector3.Zero)) ||
            (kind != PlayerHitboxKind.Box && (radius <= 0 || size != Vector3.Zero)) ||
            (kind == PlayerHitboxKind.Sphere && (halfSegment != 0 || axis != Vector3.Zero)) ||
            (kind == PlayerHitboxKind.Capsule && Math.Abs(axis.LengthSquared()-1) > 0.0001f))
            throw new InvalidDataException("Invalid source player hitbox.");
        SourcePath = sourcePath; Kind = kind; Weight = weight; Center = center;
        TransformPosition = transformPosition ?? center; Size = size;
        Rotation = Quaternion.Normalize(rotation); Radius = radius;
        Axis = kind == PlayerHitboxKind.Capsule ? Vector3.Normalize(axis) : axis; HalfSegment = halfSegment;
        Enabled = enabled; Active = active;
    }

    internal static bool Finite(Vector3 v) => float.IsFinite(v.X) && float.IsFinite(v.Y) && float.IsFinite(v.Z) && Math.Abs(v.X) <= 10000 && Math.Abs(v.Y) <= 10000 && Math.Abs(v.Z) <= 10000;
    // Unity Physics.OverlapSphere tests the collider volume, not just its center.
    internal bool OverlapsSphere(Vector3 center,float radius)
    {
        if(!Finite(center) || !float.IsFinite(radius) || radius is <=0 or >100)
            throw new InvalidDataException("Invalid host overlap sphere.");
        if(!Enabled || !Active)return false;
        Vector3 offset=center-Center;
        if(Kind==PlayerHitboxKind.Box)
        {
            var local=Vector3.Transform(offset,Quaternion.Conjugate(Rotation));
            var half=Size*.5f;
            var closest=Vector3.Clamp(local,-half,half);
            return Vector3.DistanceSquared(local,closest)<=radius*radius;
        }
        if(Kind==PlayerHitboxKind.Sphere)
            return offset.LengthSquared()<=(radius+Radius)*(radius+Radius);
        float axial=Math.Clamp(Vector3.Dot(offset,Axis),-HalfSegment,HalfSegment);
        return Vector3.DistanceSquared(offset,Axis*axial)<=(radius+Radius)*(radius+Radius);
    }
    internal float DistanceToPoint(Vector3 point)
    {
        if(!Finite(point))throw new InvalidDataException("Invalid hitbox distance point.");
        Vector3 offset=point-Center;
        if(Kind==PlayerHitboxKind.Box)
        {
            var local=Vector3.Transform(offset,Quaternion.Conjugate(Rotation));var half=Size*.5f;
            return Vector3.Distance(local,Vector3.Clamp(local,-half,half));
        }
        if(Kind==PlayerHitboxKind.Sphere)return Math.Max(0,offset.Length()-Radius);
        float axial=Math.Clamp(Vector3.Dot(offset,Axis),-HalfSegment,HalfSegment);
        return Math.Max(0,Vector3.Distance(offset,Axis*axial)-Radius);
    }
    public float? Raycast(Vector3 origin, Vector3 direction, float maxDistance)
    {
        if (!Finite(origin) || !Finite(direction) || direction.LengthSquared() < 1e-12f || !float.IsFinite(maxDistance) || maxDistance is <= 0 or > 10000)
            throw new ArgumentOutOfRangeException(nameof(direction));
        Vector3 ray = Vector3.Normalize(direction), relative = origin-Center;
        if (Kind == PlayerHitboxKind.Box)
        {
            var inverse = Quaternion.Conjugate(Rotation);
            relative = Vector3.Transform(relative, inverse); ray = Vector3.Transform(ray, inverse);
            var half = Size*0.5f;
            if (Math.Abs(relative.X) < half.X && Math.Abs(relative.Y) < half.Y && Math.Abs(relative.Z) < half.Z) return null;
            float near = 0, far = maxDistance;
            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(ray[i]) < 1e-8f) { if (Math.Abs(relative[i]) > half[i]) return null; continue; }
                float a = (-half[i]-relative[i])/ray[i], b = (half[i]-relative[i])/ray[i];
                near = Math.Max(near, Math.Min(a,b)); far = Math.Min(far, Math.Max(a,b));
                if (near > far) return null;
            }
            return near;
        }
        if (Kind == PlayerHitboxKind.Sphere) return Sphere(relative, ray, Radius, maxDistance);
        float axial = Vector3.Dot(relative, Axis);
        var closest = Axis*Math.Clamp(axial, -HalfSegment, HalfSegment);
        if ((relative-closest).LengthSquared() < Radius*Radius) return null;
        float? nearest = null;
        void Take(float? value) { if (value.HasValue && (!nearest.HasValue || value.Value < nearest.Value)) nearest = value; }
        Take(Sphere(relative-Axis*HalfSegment, ray, Radius, maxDistance));
        Take(Sphere(relative+Axis*HalfSegment, ray, Radius, maxDistance));
        float alongRay = Vector3.Dot(ray, Axis);
        var perpendicularRay = ray-Axis*alongRay;
        var perpendicularOrigin = relative-Axis*axial;
        float aa = perpendicularRay.LengthSquared(), bb = Vector3.Dot(perpendicularOrigin, perpendicularRay);
        float cc = perpendicularOrigin.LengthSquared()-Radius*Radius;
        float discriminant = bb*bb-aa*cc;
        if (aa > 1e-10f && discriminant >= 0)
        {
            float t = (-bb-MathF.Sqrt(discriminant))/aa;
            if (t >= 0 && t <= maxDistance && Math.Abs(axial+t*alongRay) <= HalfSegment) Take(t);
        }
        return nearest;
    }
    private static float? Sphere(Vector3 origin, Vector3 ray, float radius, float maxDistance)
    {
        float c = origin.LengthSquared()-radius*radius;
        if (c < 0) return null;
        float b = Vector3.Dot(origin, ray), discriminant = b*b-c;
        if (discriminant < 0) return null;
        float t = -b-MathF.Sqrt(discriminant);
        return t >= 0 && t <= maxDistance ? t : null;
    }
}
