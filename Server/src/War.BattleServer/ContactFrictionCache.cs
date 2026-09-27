using System.Numerics;
namespace War.BattleServer;

internal readonly record struct CachedFrictionAnchor(Vector3 BodyLocal,Vector3 MapWorld);
internal sealed class ContactFrictionCache
{
    internal Vector3 BodyNormal {get;}
    internal Vector3 MapNormal {get;}
    internal IReadOnlyList<CachedFrictionAnchor> Anchors {get;}
    internal bool Broken {get;}
    private ContactFrictionCache(Vector3 bodyNormal,Vector3 mapNormal,IReadOnlyList<CachedFrictionAnchor> anchors,bool broken)
    {BodyNormal=bodyNormal;MapNormal=mapNormal;Anchors=anchors;Broken=broken;}
    internal ContactFrictionCache WithBroken(bool broken)=>new(BodyNormal,MapNormal,Anchors,broken);
    internal ContactFrictionCache Grow(Vector3 root,Quaternion rotation,IReadOnlyList<DroneNormalPoint> contacts,
        float correlationDistance,float offsetThreshold)
    {
        ValidatePose(root,rotation);
        var fresh=ContactFrictionAnchors.Select(contacts,correlationDistance,offsetThreshold);
        if(contacts.Count==0)return this;
        if(Anchors.Count==2)
        {
            var minimum=contacts.Select(c=>c.Point).Aggregate(Vector3.Min);
            var maximum=contacts.Select(c=>c.Point).Aggregate(Vector3.Max);
            if(Vector3.DistanceSquared(Anchors[0].BodyLocal,Anchors[1].BodyLocal)*4>=(maximum-minimum).LengthSquared())return this;
            return new(root,rotation,Vector3.Transform(BodyNormal,rotation),fresh,false);
        }
        if(Anchors.Count==1)
        {
            var initial=root+Vector3.Transform(Anchors[0].BodyLocal,rotation);
            var grown=ContactFrictionAnchors.Select(contacts,correlationDistance,offsetThreshold,initial);
            if(grown.Length==1)return this;
            var added=new CachedFrictionAnchor(Vector3.Transform(grown[1]-root,Quaternion.Conjugate(rotation)),grown[1]);
            return new(BodyNormal,MapNormal,Array.AsReadOnly(new[]{Anchors[0],added}),false);
        }
        return new(root,rotation,Vector3.Transform(BodyNormal,rotation),fresh,false);
    }
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
