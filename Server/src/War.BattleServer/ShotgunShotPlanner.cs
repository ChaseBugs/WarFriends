using System.Numerics;

namespace War.BattleServer;

internal sealed record ShotgunRule(float NearHalfAngle,float FarHalfAngle,float Radius,
    float MinDamage,float MaxDamage,bool FlatY,bool OnlyMain);
internal sealed record ShotgunCollider(string EntityId,string MainEntityId,Vector3 Center,bool Enemy);
internal sealed record ShotgunPellet(Vector3 Target,string? EntityId,float BaseDamage,bool Main);
internal sealed record ShotgunShotPlan(IReadOnlyList<ShotgunPellet> RealPellets,int FakePellets);

// BulletShotGun.Fire and ShotRealAtPos's eligibility/damage calculation. The
// caller supplies server-owned Physics.OverlapSphere collider order and later
// resolves each real pellet through authoritative BulletSlow collision.
internal static class ShotgunShotPlanner
{
    internal static ShotgunShotPlan Plan(ShotgunRule rule,Vector3 from,Vector3 aim,
        IReadOnlyList<ShotgunCollider> overlap)
    {
        if(rule==null || overlap==null || overlap.Count>128 || !PlayerHitbox.Finite(from) ||
            !PlayerHitbox.Finite(aim) || Vector3.DistanceSquared(from,aim)<1e-10f ||
            !float.IsFinite(rule.NearHalfAngle) || rule.NearHalfAngle is <=0 or >180 ||
            !float.IsFinite(rule.FarHalfAngle) || rule.FarHalfAngle is <=0 or >180 ||
            !float.IsFinite(rule.Radius) || rule.Radius is <=0 or >100 ||
            !float.IsFinite(rule.MinDamage) || !float.IsFinite(rule.MaxDamage) ||
            rule.MinDamage<0 || rule.MaxDamage<rule.MinDamage || rule.MaxDamage>1_000_000)
            throw new InvalidDataException("Invalid host shotgun rule or shot input.");
        var real=new List<ShotgunPellet>(8);
        if(TryPellet(rule,from,aim,aim,out float mainDamage))
            real.Add(new(aim,null,mainDamage,true));
        int extras=0;
        var counts=new Dictionary<string,int>(StringComparer.Ordinal);
        var colliderIds=new HashSet<string>(StringComparer.Ordinal);
        if(!rule.OnlyMain)
        foreach(var candidate in overlap)
        {
            if(candidate==null || candidate.EntityId==null || candidate.MainEntityId==null || candidate.EntityId.Length is <1 or >128 ||
                candidate.MainEntityId.Length is <1 or >128 ||
                candidate.EntityId.Any(char.IsControl) || candidate.MainEntityId.Any(char.IsControl) ||
                !colliderIds.Add(candidate.EntityId) ||
                !PlayerHitbox.Finite(candidate.Center))
                throw new InvalidDataException("Invalid host shotgun overlap candidate.");
            if(candidate.Enemy && counts.GetValueOrDefault(candidate.MainEntityId)<2 &&
                Vector3.Distance(aim,candidate.Center)>.3f &&
                TryPellet(rule,from,aim,candidate.Center,out float damage))
            {
                real.Add(new(candidate.Center,candidate.EntityId,damage,false));
                counts[candidate.MainEntityId]=counts.GetValueOrDefault(candidate.MainEntityId)+1;
                extras++;
            }
            // The recovered source breaks after the seventh successful extra.
            if(extras>6)break;
        }
        return new(Array.AsReadOnly(real.ToArray()),Math.Max(4-extras,0));
    }

    private static bool TryPellet(ShotgunRule rule,Vector3 from,Vector3 aim,Vector3 target,out float damage)
    {
        Vector3 axis=aim-from;
        if(rule.FlatY)axis.Y=0;
        Vector3 offset=target-from;
        float distance=offset.Length();
        float angle=axis.LengthSquared()<1e-10f || offset.LengthSquared()<1e-10f ? 0 :
            MathF.Acos(Math.Clamp(Vector3.Dot(Vector3.Normalize(axis),Vector3.Normalize(offset)),-1,1))*(180/MathF.PI);
        float ratio=Math.Clamp(distance/rule.Radius,0,1);
        float halfAngle=rule.NearHalfAngle+(rule.FarHalfAngle-rule.NearHalfAngle)*MathF.Sqrt(MathF.Sqrt(ratio));
        damage=Math.Clamp(rule.MinDamage+(rule.MaxDamage-rule.MinDamage)*Math.Clamp(1-ratio,0,1),0,float.MaxValue);
        return MathF.Abs(angle)<halfAngle;
    }
}
