using System.Numerics;

namespace War.BattleServer;

internal sealed record ArmyFlameHit(float Distance,float RawDamage,string PartPath);

/// <summary>Recovered FlameAmmo pulse clock and cone query; MatchEngine owns all mutation.</summary>
internal sealed class ArmyFlameBurst
{
    internal const int HitsPerShot=6;
    internal const float SecondsBetweenHits=.35f;
    internal const float Radius=3f;
    internal const float HalfAngle=40f;
    internal const float HalfAngleNear=60f;
    internal const float MinimumDistance=.3f;
    internal const ulong PulseIntervalTicks=(ulong)(SecondsBetweenHits*MatchManifest.TickRate)+1;
    private readonly ulong startedTick;
    internal ulong ProjectileId { get; }
    internal ulong EntityKey { get; }
    internal string OwnerPlayerId { get; }
    internal int PulseIndex { get; private set; }
    internal bool Finished=>PulseIndex>=HitsPerShot;
    internal ulong NextPulseTick=>checked(startedTick+(ulong)(PulseIndex+1)*PulseIntervalTicks);

    internal ArmyFlameBurst(ulong projectileId,ulong entityKey,string ownerPlayerId,ulong startedTick)
    {
        if(projectileId==0||entityKey==0||!Guid.TryParseExact(ownerPlayerId,"N",out _)||
           ownerPlayerId!=ownerPlayerId.ToLowerInvariant()||startedTick>10_000_000)
            throw new InvalidDataException("Invalid army flame burst identity.");
        ProjectileId=projectileId;EntityKey=entityKey;OwnerPlayerId=ownerPlayerId;this.startedTick=startedTick;
    }

    internal bool Due(ulong tick)=>!Finished&&tick>=NextPulseTick;

    internal void CommitPulse(ulong tick)
    {
        if(!Due(tick)||tick!=NextPulseTick)throw new InvalidOperationException("Army flame pulse missed its source clock.");
        PulseIndex++;
    }

    internal static ArmyFlameHit? ResolvePlayer(Vector3 origin,Vector3 forward,
        PlayerCollisionModel collision,float sourceDamage)
    {
        if(collision==null)throw new InvalidDataException("Invalid army flame player collision authority.");
        return ResolveParts(origin,forward,collision.Parts,sourceDamage);
    }

    internal static ArmyFlameHit? ResolveParts(Vector3 origin,Vector3 forward,
        IReadOnlyList<PlayerHitbox> parts,float sourceDamage)
    {
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(forward)||forward.LengthSquared()<1e-10f||
           parts==null||parts.Count==0||parts.Any(p=>p==null)||
           !float.IsFinite(sourceDamage)||sourceDamage<0||sourceDamage>10_000_000)
            throw new InvalidDataException("Invalid army flame query.");
        forward.Y=0;
        if(forward.LengthSquared()<1e-10f)throw new InvalidDataException("Army flame has no planar direction.");
        forward=Vector3.Normalize(forward);
        foreach(var part in parts)
        {
            if(!part.Enabled||!part.Active||!part.OverlapsSphere(origin,Radius))continue;
            var hit=ResolveCenter(origin,forward,part.Center,sourceDamage,part.SourcePath);
            if(hit!=null)return hit;
        }
        return null;
    }

    // FlameAmmo.CheckHit uses the collider's transformed center after its
    // overlap query. Map shields supply that center independently of player rigs.
    internal static ArmyFlameHit? ResolveCenter(Vector3 origin,Vector3 forward,
        Vector3 center,float sourceDamage,string sourcePath)
    {
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(forward)||!PlayerHitbox.Finite(center)||
           forward.LengthSquared()<1e-10f||!float.IsFinite(sourceDamage)||
           sourceDamage<0||sourceDamage>10_000_000||string.IsNullOrEmpty(sourcePath))
            throw new InvalidDataException("Invalid army flame collider center.");
        forward.Y=0;
        if(forward.LengthSquared()<1e-10f)throw new InvalidDataException("Army flame has no planar direction.");
        forward=Vector3.Normalize(forward);
        Vector3 offset=center-origin;float distance=offset.Length();
        if(distance<MinimumDistance||distance==0)return null;
        float angle=MathF.Acos(Math.Clamp(Vector3.Dot(forward,Vector3.Normalize(offset)),-1,1))*180/MathF.PI;
        float allowed=HalfAngleNear+(HalfAngle-HalfAngleNear)*MathF.Pow(distance,.25f);
        if(!(MathF.Abs(angle)<allowed))return null;
        float fraction=1-distance/Radius;
        float minimum=sourceDamage*.1f/HitsPerShot;
        float maximum=sourceDamage/HitsPerShot;
        float damage=minimum+(maximum-minimum)*fraction;
        if(!float.IsFinite(damage)||damage<0)throw new InvalidDataException("Army flame damage escaped its source domain.");
        return new(distance,damage,sourcePath);
    }
}
