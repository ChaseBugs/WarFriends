using System.Numerics;
namespace War.BattleServer;

internal readonly record struct ContactMaterial(float StaticFriction,float DynamicFriction,float Restitution);
internal readonly record struct MaterialContact(DroneNormalPoint Geometry,ContactMaterial Material);
internal sealed record FrictionContactPatch(Vector3 Normal,ContactMaterial Material,IReadOnlyList<DroneNormalPoint> Contacts);

// Initial correlation for one shape pair. Threshold is explicit pending Unity
// policy evidence; cached patches and material flags are not handled here.
internal static class ContactFrictionPatches
{
    internal static FrictionContactPatch[] Correlate(IReadOnlyList<MaterialContact> contacts,float normalTolerance)
    {
        ArgumentNullException.ThrowIfNull(contacts);
        if(contacts.Count>64||!float.IsFinite(normalTolerance)||normalTolerance<0||normalTolerance>1)
            throw new InvalidDataException("Invalid contact patch authority.");
        var points=contacts.ToArray();
        foreach(var c in points)
        {
            var g=c.Geometry;var m=c.Material;
            if(!PlayerHitbox.Finite(g.Point)||!PlayerHitbox.Finite(g.Normal)||Math.Abs(g.Normal.LengthSquared()-1)>.0001f||
               !float.IsFinite(g.Separation)||Math.Abs(g.Separation)>100||!float.IsFinite(m.StaticFriction)||
               m.StaticFriction<0||m.StaticFriction>1000||!float.IsFinite(m.DynamicFriction)||m.DynamicFriction<0||
               m.DynamicFriction>m.StaticFriction||!float.IsFinite(m.Restitution)||m.Restitution<0||m.Restitution>1)
                throw new InvalidDataException("Invalid material contact authority.");
        }
        var patches=new List<(Vector3 Normal,ContactMaterial Material,List<DroneNormalPoint> Points)>();
        for(int start=0;start<points.Length;)
        {
            int end=start+1;var first=points[start];
            while(end<points.Length&&points[end].Material==first.Material&&
                Vector3.Dot(points[end].Geometry.Normal,first.Geometry.Normal)>=normalTolerance)end++;
            int index=patches.FindIndex(p=>p.Material==first.Material&&Vector3.Dot(p.Normal,first.Geometry.Normal)>=normalTolerance);
            if(index<0)
            {
                if(patches.Count==32)throw new InvalidDataException("Excessive friction patches.");
                patches.Add((first.Geometry.Normal,first.Material,new()));index=patches.Count-1;
            }
            // PhysX prepends later contiguous groups to each correlated list.
            patches[index].Points.InsertRange(0,points[start..end].Select(c=>c.Geometry));
            start=end;
        }
        return patches.Select(p=>new FrictionContactPatch(p.Normal,p.Material,
            Array.AsReadOnly(p.Points.ToArray()))).ToArray();
    }
}
