using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>One source barrel instance. OnDeath requires an explosion event before live use.</summary>
internal sealed class BarrelLifecycle
{
    internal float MaxHealth { get; }
    internal float Health { get; private set; }
    internal bool Destroyed { get; private set; }
    internal uint Revision { get; private set; }
    internal BarrelLifecycle(BarrelSourcePolicy policy,int ownerLevel,BarrelSceneBinding binding)
    {
        if(binding.ShotCoefficient!=1f)throw new InvalidDataException("Unsupported barrel shot coefficient.");
        MaxHealth=policy.MaxHealth(ownerLevel);
        Health=MaxHealth;
    }
    internal bool ApplyShot(float damage)
    {
        if(!float.IsFinite(damage) || damage<=0 || damage>1_000_000)
            throw new InvalidDataException("Invalid host barrel shot damage.");
        if(Destroyed)return false;
        // DestroyableObject.Shoot and DoDamage apply the serialized coefficient,
        // subtract health, then fire OnDeath once when health is no longer positive.
        Health-=damage;
        Destroyed=Health<=0;
        Revision++;
        return Destroyed;
    }
    // Called only after BarrelMatchSimulation has validated the complete chain.
    internal void CommitProjected(float health,bool destroyed,uint revision)
    { Health=health;Destroyed=destroyed;Revision=revision; }
}
