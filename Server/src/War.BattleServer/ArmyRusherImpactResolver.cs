using System.Numerics;

namespace War.BattleServer;

internal sealed record ArmyRusherPlayerImpact(ulong EntityKey,string AttackerPlayerId,
    string VictimPlayerId,Vector3 Position,float PartWeight,float Damage,bool IsReal);

/// <summary>
/// Validates the army-specific side of a Rusher projectile impact. It does not
/// mutate player health; the match combat authority consumes the returned proof.
/// </summary>
internal static class ArmyRusherImpactResolver
{
    internal static ArmyRusherPlayerImpact Resolve(
        MatchEngine.ArmyRusherShotIntent intent,ShotCollision collision,
        float trustedDamage)
    {
        ArgumentNullException.ThrowIfNull(intent);
        ArgumentNullException.ThrowIfNull(collision);
        if(!Guid.TryParseExact(intent.PlayerId,"N",out _) ||
           string.IsNullOrWhiteSpace(collision.PlayerId) ||
           collision.PlayerId!=intent.PlayerId ||
           !PlayerHitbox.Finite(intent.TargetPosition) ||
           !PlayerHitbox.Finite(collision.Position) ||
           Vector3.Distance(collision.Position,intent.TargetPosition)>2f ||
           !float.IsFinite(collision.PartWeight) || collision.PartWeight<0 ||
           collision.PartWeight>1 || !float.IsFinite(trustedDamage) ||
           trustedDamage<=0 || trustedDamage>10_000_000 ||
           intent.BatchIndex<0 || intent.BatchIndex>=intent.BatchSize ||
           intent.BatchSize<1 || intent.BatchSize>14)
            throw new InvalidDataException("Rusher impact does not match its trusted shot intent.");
        return new(intent.EntityKey,intent.PlayerId,collision.PlayerId,collision.Position,
            collision.PartWeight,trustedDamage,intent.IsReal);
    }
}
