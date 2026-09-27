using System.Numerics;
namespace War.BattleServer;

internal readonly record struct CachedFrictionAnchor(Vector3 BodyLocal,Vector3 MapWorld);
internal sealed class ContactFrictionCache
{
    internal Vector3 BodyNormal {get;}
    internal Vector3 MapNormal {get;}
    internal IReadOnlyList<CachedFrictionAnchor> Anchors {get;}
    internal bool Broken {get;}
    internal ContactFrictionCache(Vector3 root,Quaternion rotation,Vector3 normal,IReadOnlyList<Vector3> worldAnchors,bool broken)
    {
        ValidatePose(root,rotation);
        ArgumentNullException.ThrowIfNull(worldAnchors);
        if(!PlayerHitbox.Finite(normal)||Math.Abs(normal.LengthSquared()-1)>.0001f||worldAnchors.Count>2||
           worldAnchors.Any(a=>!PlayerHitbox.Finite(a)))throw new InvalidDataException("Invalid cached friction patch.");
        BodyNormal=Vector3.Transform(normal,Quaternion.Conjugate(rotation));MapNormal=normal;Broken=broken;
        Anchors=Array.AsReadOnly(worldAnchors.Select(a=>new CachedFrictionAnchor(
            Vector3.Transform(a-root,Quaternion.Conjugate(rotation)),a)).ToArray());
    }
    internal bool CanReuse(Vector3 root,Quaternion rotation,float normalTolerance,float correlationDistance)
    {
        ValidatePose(root,rotation);
        if(!float.IsFinite(normalTolerance)||normalTolerance<0||normalTolerance>1||
           !float.IsFinite(correlationDistance)||correlationDistance<0||correlationDistance>1)
            throw new InvalidDataException("Invalid friction cache thresholds.");
        if(Broken||Anchors.Count==0||Vector3.Dot(Vector3.Transform(BodyNormal,rotation),MapNormal)<=normalTolerance)return false;
        foreach(var anchor in Anchors)
        {
            var world=root+Vector3.Transform(anchor.BodyLocal,rotation);
            // Separation is tested along the transported body normal; tangential
            // drift intentionally survives to provide a restoring friction bias.
            if(Math.Abs(Vector3.Dot(world-anchor.MapWorld,Vector3.Transform(BodyNormal,rotation)))>=correlationDistance)return false;
        }
        return true;
    }
    private static void ValidatePose(Vector3 root,Quaternion rotation)
    {
        if(!PlayerHitbox.Finite(root)||!float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid friction cache pose.");
    }
}
