using System.Numerics;

namespace War.BattleServer;

internal sealed record ArmyAirShotIntent(ulong EntityKey,string AttackerPlayerId,
    string VictimPlayerId,Vector3 TargetPosition,float MaxRange,bool IsReal);
internal sealed record ArmyAirPlayerImpact(ulong EntityKey,string AttackerPlayerId,
    string VictimPlayerId,Vector3 Position,float PartWeight,float Damage,bool IsReal);

/// <summary>Validates an air projectile collision before the player damage kernel.</summary>
internal static class ArmyAirImpactResolver
{
    internal static ArmyAirPlayerImpact Resolve(ArmyAirShotIntent intent,ShotCollision collision,float trustedDamage)
    {
        ArgumentNullException.ThrowIfNull(intent);ArgumentNullException.ThrowIfNull(collision);
        if(intent.EntityKey==0||!Guid.TryParseExact(intent.AttackerPlayerId,"N",out _)||
           !Guid.TryParseExact(intent.VictimPlayerId,"N",out _)||collision.PlayerId!=intent.VictimPlayerId||
           !PlayerHitbox.Finite(intent.TargetPosition)||!PlayerHitbox.Finite(collision.Position)||
           !float.IsFinite(intent.MaxRange)||intent.MaxRange<=0||intent.MaxRange>1000||
           Vector3.Distance(collision.Position,intent.TargetPosition)>intent.MaxRange||
           !float.IsFinite(collision.PartWeight)||collision.PartWeight<0||collision.PartWeight>1||
           !float.IsFinite(trustedDamage)||trustedDamage<=0||trustedDamage>10_000_000)
            throw new InvalidDataException("Air impact does not match its trusted shot intent.");
        return new(intent.EntityKey,intent.AttackerPlayerId,intent.VictimPlayerId,collision.Position,
            collision.PartWeight,trustedDamage,intent.IsReal);
    }
}
