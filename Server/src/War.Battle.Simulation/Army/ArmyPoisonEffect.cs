using System.Numerics;

namespace War.BattleServer;

/// <summary>One BulletPoison coroutine. Separate projectile hits retain separate instances.</summary>
internal sealed class ArmyPoisonEffect
{
    internal const int PulseCount=5;
    internal const int PulseIntervalTicks=MatchManifest.TickRate;
    private int remaining=PulseCount;
    private ulong nextTick;

    internal ArmyPoisonEffect(ulong projectileId,ulong entityKey,string attackerPlayerId,
        string victimPlayerId,float damagePerPulse,Vector3 position,ulong impactTick)
    {
        if(projectileId==0||entityKey==0||string.IsNullOrEmpty(attackerPlayerId)||
           string.IsNullOrEmpty(victimPlayerId)||!float.IsFinite(damagePerPulse)||
           damagePerPulse<=0||damagePerPulse>10_000_000||!PlayerHitbox.Finite(position)||
           impactTick>10_000_000)
            throw new InvalidDataException("Invalid Commando poison authority.");
        ProjectileId=projectileId;EntityKey=entityKey;AttackerPlayerId=attackerPlayerId;
        VictimPlayerId=victimPlayerId;DamagePerPulse=damagePerPulse;Position=position;
        nextTick=impactTick;
    }

    internal ulong ProjectileId { get; }
    internal ulong EntityKey { get; }
    internal string AttackerPlayerId { get; }
    internal string VictimPlayerId { get; }
    internal float DamagePerPulse { get; }
    internal Vector3 Position { get; }
    internal int Remaining=>remaining;

    internal bool TryTakePulse(ulong tick)
    {
        if(remaining==0||tick<nextTick)return false;
        if(tick!=nextTick)throw new InvalidDataException("Commando poison ticks are not contiguous with their source clock.");
        remaining--;
        if(remaining>0)nextTick=checked(nextTick+PulseIntervalTicks);
        return true;
    }
}
