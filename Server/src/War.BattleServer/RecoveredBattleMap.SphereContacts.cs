using System.Numerics;
namespace War.BattleServer;

internal sealed record MapSphereSurfaceContact(int ColliderIndex,string SourcePath,int Layer,
    Vector3 SurfacePoint,Vector3 Normal,float Separation);

public sealed partial class RecoveredBattleMap
{
    // Triangle surfaces only: convex cooked meshes require their hull manifold.
    // One nearest surface per collider; not a complete PhysX contact manifold.
    internal IReadOnlyList<MapSphereSurfaceContact> TriangleSphereContacts(Vector3 center,float radius,
        float margin,uint layerMask)
    {
        if(!Finite(center)||!float.IsFinite(radius)||radius<=0||radius>100||
           !float.IsFinite(margin)||margin<0||margin>.1f)
            throw new InvalidDataException("Invalid sphere contact query.");
        var extent=new Vector3(radius+margin);var result=new List<MapSphereSurfaceContact>();
        foreach(var shape in shapes)
        {
            if(shape.Hull!=null||(layerMask&(1u<<shape.Layer))==0||
                !BoundsOverlap(center-extent,center+extent,shape.Min,shape.Max))continue;
            float best=float.PositiveInfinity;Vector3 point=default,faceNormal=default;
            for(int i=0;i<shape.Triangles.Length;i+=3)
            {
                var a=shape.Triangles[i];var b=shape.Triangles[i+1];var c=shape.Triangles[i+2];
                var candidate=ClosestTrianglePoint(center,a,b,c);float distance=Vector3.DistanceSquared(center,candidate);
                if(distance>=best)continue;
                best=distance;point=candidate;faceNormal=Vector3.Cross(b-a,c-a);
            }
            float length=MathF.Sqrt(best);
            if(length>radius+margin)continue;
            var normal=length>1e-8f?(center-point)/length:Vector3.Normalize(faceNormal);
            if(!Finite(normal))throw new InvalidDataException("Degenerate map contact surface.");
            result.Add(new(shape.SourceIndex,shape.Path,shape.Layer,point,normal,length-radius));
        }
        return result.AsReadOnly();
    }
    private static Vector3 ClosestTrianglePoint(Vector3 p,Vector3 a,Vector3 b,Vector3 c)
    {
        var ab=b-a;var ac=c-a;var ap=p-a;float d1=Vector3.Dot(ab,ap),d2=Vector3.Dot(ac,ap);
        if(d1<=0&&d2<=0)return a;
        var bp=p-b;float d3=Vector3.Dot(ab,bp),d4=Vector3.Dot(ac,bp);if(d3>=0&&d4<=d3)return b;
        float vc=d1*d4-d3*d2;if(vc<=0&&d1>=0&&d3<=0)return a+(d1/(d1-d3))*ab;
        var cp=p-c;float d5=Vector3.Dot(ab,cp),d6=Vector3.Dot(ac,cp);if(d6>=0&&d5<=d6)return c;
        float vb=d5*d2-d1*d6;if(vb<=0&&d2>=0&&d6<=0)return a+(d2/(d2-d6))*ac;
        float va=d3*d6-d5*d4;if(va<=0&&d4-d3>=0&&d5-d6>=0)return b+((d4-d3)/((d4-d3)+(d5-d6)))*(c-b);
        float denominator=1/(va+vb+vc);return a+ab*(vb*denominator)+ac*(vc*denominator);
    }
}
