namespace War.BattleServer;

internal sealed record HelicopterGunnerSnapshot(int PointComponentFileId,float MaximumHealth,
    float Health,ulong SpawnTick,ulong RespawnTick,bool TurretEnabled);

// Helicopter.GenerateMachineGunner and EnemyAtTurretOnKilled own a soldier
// separate from the ordered rope crew. This models that soldier's lifecycle;
// hitbox selection and kill credit remain with the host combat kernel.
internal sealed class HelicopterGunnerState
{
    private readonly int pointComponentFileId;
    private readonly float maximum;
    private readonly int respawnTicks;
    private float health;
    private ulong spawnTick;
    private ulong respawnTick;

    internal HelicopterGunnerState(int pointComponentFileId,float maximum,int respawnTicks,ulong tick)
    {
        if(pointComponentFileId<=0||!float.IsFinite(maximum)||maximum<=0||maximum>10_000_000||
           respawnTicks<=0||tick==0)
            throw new InvalidDataException("Invalid source Helicopter gunner authority.");
        this.pointComponentFileId=pointComponentFileId;
        this.maximum=maximum;
        this.respawnTicks=respawnTicks;
        health=maximum;
        spawnTick=tick;
    }
    internal HelicopterGunnerSnapshot Snapshot()=>new(pointComponentFileId,maximum,health,
        spawnTick,respawnTick,health>0);
    internal bool Damage(float amount,ulong tick)
    {
        if(!float.IsFinite(amount)||amount<=0||amount>10_000_000||tick<spawnTick||health<=0)
            return false;
        float nextHealth=MathF.Max(0,health-amount);
        if(nextHealth==0)
        {
            if(tick>ulong.MaxValue-(ulong)respawnTicks)
                throw new InvalidDataException("Helicopter gunner respawn tick overflow.");
            respawnTick=tick+(ulong)respawnTicks;
        }
        health=nextHealth;
        return true;
    }
    internal void Advance(ulong tick)
    {
        if(respawnTick==0||tick<respawnTick)return;
        health=maximum;
        spawnTick=respawnTick;
        respawnTick=0;
    }
}
