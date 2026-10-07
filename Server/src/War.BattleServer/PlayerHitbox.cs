using System.Numerics;

namespace War.BattleServer;

public enum PlayerHitboxKind { Box, Sphere, Capsule, Mesh }
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
    private readonly TriangleMeshGeometry? mesh;
    private readonly Vector3 meshOrigin;

    public PlayerHitbox(string sourcePath, PlayerHitboxKind kind, float weight, Vector3 center,
        Vector3 size, Quaternion rotation, float radius, Vector3 axis, float halfSegment, bool enabled = true, bool active = true,
        Vector3? transformPosition = null)
    {
        if (string.IsNullOrEmpty(sourcePath) || sourcePath.Length > 1024 || sourcePath.Any(char.IsControl) || !Enum.IsDefined(kind) ||
            !float.IsFinite(weight) || weight is < 0 or > 1000 || !Finite(center) ||
            (transformPosition.HasValue && !Finite(transformPosition.Value)) || !Finite(size) || !Finite(axis) ||
            !float.IsFinite(rotation.LengthSquared()) || Math.Abs(rotation.LengthSquared()-1) > 0.0001f ||
            !float.IsFinite(radius) || !float.IsFinite(halfSegment) || radius is < 0 or > 100 || halfSegment is < 0 or > 100 ||
            kind == PlayerHitboxKind.Mesh ||
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

    internal PlayerHitbox(string sourcePath, float weight, Vector3 origin,
        Quaternion rotation, TriangleMeshGeometry geometry, Vector3 rootPosition)
        : this(sourcePath, PlayerHitboxKind.Box, weight,
            origin + Vector3.Transform(geometry.BoundsCenter, rotation),
            geometry.BoundsSize, rotation, 0, Vector3.Zero, 0,
            transformPosition: rootPosition)
    {
        Kind = PlayerHitboxKind.Mesh;
        mesh = geometry;
        meshOrigin = origin;
    }

    internal static bool Finite(Vector3 v) => float.IsFinite(v.X) && float.IsFinite(v.Y) && float.IsFinite(v.Z) && Math.Abs(v.X) <= 10000 && Math.Abs(v.Y) <= 10000 && Math.Abs(v.Z) <= 10000;
    // Unity Physics.OverlapSphere tests the collider volume, not just its center.
    internal bool OverlapsSphere(Vector3 center,float radius)
    {
        if(!Finite(center) || !float.IsFinite(radius) || radius is <=0 or >100)
            throw new InvalidDataException("Invalid host overlap sphere.");
        if(!Enabled || !Active)return false;
        if (mesh != null)
        {
            Vector3 local = Vector3.Transform(center - meshOrigin,
                Quaternion.Conjugate(Rotation));
            return mesh.Contains(local) || mesh.DistanceToSurface(local) <= radius;
        }
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
    // Unity's mine trigger is an oriented BoxCollider. This keeps the trigger
    // decision against the complete current collider volume instead of using a
    // broad center-distance approximation.
    internal bool OverlapsBox(Vector3 center,Vector3 size,Quaternion rotation)
    {
        if(!Finite(center)||!Finite(size)||size.X<=0||size.Y<=0||size.Z<=0||
           size.X>100||size.Y>100||size.Z>100||!float.IsFinite(rotation.LengthSquared())||
           Math.Abs(rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid host overlap box.");
        if(!Enabled||!Active)return false;
        if (mesh != null)
            throw new InvalidDataException("Mesh and box overlap requires a source-specific policy.");
        rotation=Quaternion.Normalize(rotation);var inverse=Quaternion.Conjugate(rotation);var half=size*.5f;
        if(Kind==PlayerHitboxKind.Sphere)
        {
            var local=Vector3.Transform(Center-center,inverse);
            return Vector3.DistanceSquared(local,Vector3.Clamp(local,-half,half))<=Radius*Radius;
        }
        if(Kind==PlayerHitboxKind.Capsule)
        {
            var a=Vector3.Transform(Center-Axis*HalfSegment-center,inverse);
            var b=Vector3.Transform(Center+Axis*HalfSegment-center,inverse);
            return SegmentBoxDistanceSquared(a,b,half)<=Radius*Radius;
        }
        Vector3[] aAxis=[Vector3.Transform(Vector3.UnitX,Rotation),Vector3.Transform(Vector3.UnitY,Rotation),Vector3.Transform(Vector3.UnitZ,Rotation)];
        Vector3[] bAxis=[Vector3.Transform(Vector3.UnitX,rotation),Vector3.Transform(Vector3.UnitY,rotation),Vector3.Transform(Vector3.UnitZ,rotation)];
        float[] aHalf=[Size.X*.5f,Size.Y*.5f,Size.Z*.5f];float[] bHalf=[half.X,half.Y,half.Z];
        var delta=center-Center;const float epsilon=1e-6f;
        float[,] r=new float[3,3],abs=new float[3,3];
        for(int i=0;i<3;i++)for(int j=0;j<3;j++){r[i,j]=Vector3.Dot(aAxis[i],bAxis[j]);abs[i,j]=Math.Abs(r[i,j])+epsilon;}
        float[] t=[Vector3.Dot(delta,aAxis[0]),Vector3.Dot(delta,aAxis[1]),Vector3.Dot(delta,aAxis[2])];
        for(int i=0;i<3;i++)if(Math.Abs(t[i])>aHalf[i]+bHalf[0]*abs[i,0]+bHalf[1]*abs[i,1]+bHalf[2]*abs[i,2])return false;
        for(int j=0;j<3;j++)if(Math.Abs(t[0]*r[0,j]+t[1]*r[1,j]+t[2]*r[2,j])>bHalf[j]+aHalf[0]*abs[0,j]+aHalf[1]*abs[1,j]+aHalf[2]*abs[2,j])return false;
        for(int i=0;i<3;i++)for(int j=0;j<3;j++)
        {
            int i1=(i+1)%3,i2=(i+2)%3,j1=(j+1)%3,j2=(j+2)%3;
            if(Math.Abs(t[i2]*r[i1,j]-t[i1]*r[i2,j])>
               aHalf[i1]*abs[i2,j]+aHalf[i2]*abs[i1,j]+bHalf[j1]*abs[i,j2]+bHalf[j2]*abs[i,j1])return false;
        }
        return true;
    }
    private static float SegmentBoxDistanceSquared(Vector3 a,Vector3 b,Vector3 half)
    {
        static float At(Vector3 p,Vector3 h)
        {var d=p-Vector3.Clamp(p,-h,h);return d.LengthSquared();}
        var direction=b-a;float left=0,right=1;
        // Squared distance from a segment to a convex box is convex. The fixed
        // iteration count is deterministic and comfortably below source-float precision.
        for(int i=0;i<40;i++)
        {float m1=(2*left+right)/3,m2=(left+2*right)/3;if(At(a+direction*m1,half)<=At(a+direction*m2,half))right=m2;else left=m1;}
        return Math.Min(Math.Min(At(a,half),At(b,half)),At(a+direction*((left+right)*.5f),half));
    }
    internal float DistanceToPoint(Vector3 point)
    {
        if(!Finite(point))throw new InvalidDataException("Invalid hitbox distance point.");
        if (mesh != null)
        {
            Vector3 local = Vector3.Transform(point - meshOrigin,
                Quaternion.Conjugate(Rotation));
            return mesh.Contains(local) ? 0 : mesh.DistanceToSurface(local);
        }
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
    // Unity's Collider.ClosestPointOnBounds uses the world-axis bounds, which
    // can select a different part than closest distance to its actual shape.
    internal float BoundsDistanceToPoint(Vector3 point)
    {
        if(!Finite(point))throw new InvalidDataException("Invalid hitbox bounds point.");
        if (mesh != null)
        {
            var bounds = mesh.WorldBounds(meshOrigin, Rotation);
            return Vector3.Distance(point, Vector3.Clamp(point, bounds.Min, bounds.Max));
        }
        Vector3 half;
        if(Kind==PlayerHitboxKind.Box)
        {
            var x=Vector3.Transform(Vector3.UnitX,Rotation);
            var y=Vector3.Transform(Vector3.UnitY,Rotation);
            var z=Vector3.Transform(Vector3.UnitZ,Rotation);
            half=new(Math.Abs(x.X)*Size.X*.5f+Math.Abs(y.X)*Size.Y*.5f+Math.Abs(z.X)*Size.Z*.5f,
                Math.Abs(x.Y)*Size.X*.5f+Math.Abs(y.Y)*Size.Y*.5f+Math.Abs(z.Y)*Size.Z*.5f,
                Math.Abs(x.Z)*Size.X*.5f+Math.Abs(y.Z)*Size.Y*.5f+Math.Abs(z.Z)*Size.Z*.5f);
        }
        else
        {
            half=new Vector3(Radius);
            if(Kind==PlayerHitboxKind.Capsule)
                half+=new Vector3(Math.Abs(Axis.X),Math.Abs(Axis.Y),Math.Abs(Axis.Z))*HalfSegment;
        }
        return Vector3.Distance(point,Vector3.Clamp(point,Center-half,Center+half));
    }
    public float? Raycast(Vector3 origin, Vector3 direction, float maxDistance)
    {
        if (!Finite(origin) || !Finite(direction) || direction.LengthSquared() < 1e-12f || !float.IsFinite(maxDistance) || maxDistance is <= 0 or > 10000)
            throw new ArgumentOutOfRangeException(nameof(direction));
        Vector3 ray = Vector3.Normalize(direction), relative = origin-Center;
        if (mesh != null)
        {
            Vector3 local = Vector3.Transform(origin - meshOrigin,
                Quaternion.Conjugate(Rotation));
            if (mesh.Contains(local)) return null;
            return mesh.Raycast(local,
                Vector3.Transform(ray, Quaternion.Conjugate(Rotation)), maxDistance);
        }
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
