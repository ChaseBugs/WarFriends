using System.Numerics;

namespace War.BattleServer;

internal sealed record DeployableImpact(int EntityId,string VictimPlayerId,Vector3 Position,float Damage,float Distance);

/// <summary>Validates a host-owned deployable trigger before damage mutation.</summary>
internal static class DeployableImpactResolver
{
    internal static DeployableImpact Resolve(int entityId,string victimPlayerId,Vector3 origin,
        Vector3 hitPosition,float radius,float trustedDamage)
    {
        if(entityId<=0||!Guid.TryParseExact(victimPlayerId,"N",out _)||!PlayerHitbox.Finite(origin)||
           !PlayerHitbox.Finite(hitPosition)||!float.IsFinite(radius)||radius<=0||radius>100||
           !float.IsFinite(trustedDamage)||trustedDamage<=0||trustedDamage>10_000_000)
            throw new InvalidDataException("Invalid deployable impact authority.");
        float distance=Vector3.Distance(origin,hitPosition);
        if(!float.IsFinite(distance)||distance>radius+.001f)
            throw new InvalidDataException("Deployable impact is outside its trusted radius.");
        return new(entityId,victimPlayerId,hitPosition,trustedDamage,distance);
    }
}
