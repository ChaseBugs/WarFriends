using System.Numerics;
namespace War.BattleServer;

internal sealed record DroneDeathExplosion(Vector3 Position,float Damage,float SplashDamage,
    float DeadRadius,float HurtRadius);

// Death disables steering; only the first subsequent physical collision explodes.
// Falling-body contact must come from the host, never a client packet.
internal sealed class DroneDeathState
{
    private readonly float maximumHealth;
    private float observed;
    internal float? DestructionDeadline { get; private set; }
    internal DroneDeathState(float deathTime,float maximumHealth)
    {
        if(!float.IsFinite(deathTime)||deathTime<0||!float.IsFinite(maximumHealth)||maximumHealth<=0||maximumHealth>10000000)
            throw new InvalidDataException("Invalid Drone death authority.");
        observed=deathTime;this.maximumHealth=maximumHealth;
    }
    internal DroneDeathExplosion? ObserveCollision(float time,Vector3 position)
    {
        if(!float.IsFinite(time)||time<observed||!PlayerHitbox.Finite(position))
            throw new InvalidDataException("Invalid Drone death collision authority.");
        if(DestructionDeadline.HasValue){observed=time;return null;}
        float deadline=time+.2f;
        if(!float.IsFinite(deadline)||deadline<=time)
            throw new InvalidDataException("Drone death destruction clock overflow.");
        observed=time;DestructionDeadline=deadline;
        return new(position,maximumHealth*.5f,maximumHealth*.05f,.7f,1.4f);
    }
}
