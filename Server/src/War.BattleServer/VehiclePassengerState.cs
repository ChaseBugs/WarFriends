namespace War.BattleServer;

internal sealed record VehiclePassengerSnapshot(string Role,float Health,float Maximum,
    ulong RespawnTick,bool Active,GroundVehiclePassengerBinding Binding);

/// <summary>One recovered EnemyPointVehicle soldier owned by its mechanical unit.</summary>
internal sealed class VehiclePassengerState
{
    private readonly float maximum;private readonly int respawnTicks;
    internal GroundVehiclePassengerBinding Binding {get;}
    internal float Health {get;private set;}
    internal ulong RespawnTick {get;private set;}
    internal ulong AnimationStartTick {get;private set;}
    internal bool Active=>Health>0;

    internal VehiclePassengerState(GroundVehiclePassengerBinding binding,float maximum,
        int respawnTicks,ulong tick)
    {
        if(binding==null||!float.IsFinite(maximum)||maximum<=0||maximum>10_000_000||
           respawnTicks is <1 or >10_000_000||tick>10_000_000)
            throw new InvalidDataException("Invalid vehicle passenger authority.");
        Binding=binding;this.maximum=maximum;this.respawnTicks=respawnTicks;Health=maximum;
        AnimationStartTick=tick;
    }

    internal bool ApplyDamage(float amount,ulong tick)
    {
        if(!float.IsFinite(amount)||amount<=0||amount>10_000_000||tick>10_000_000)
            throw new InvalidDataException("Invalid vehicle passenger damage.");
        if(!Active)return false;
        Health=Math.Max(0,Health-amount);
        if(Health==0)RespawnTick=checked(tick+(ulong)respawnTicks);
        return true;
    }

    internal bool Advance(ulong tick)
    {
        if(tick>10_000_000)throw new InvalidDataException("Invalid vehicle passenger tick.");
        if(Active||RespawnTick==0||tick<RespawnTick)return false;
        Health=maximum;RespawnTick=0;AnimationStartTick=tick;return true;
    }

    internal VehiclePassengerSnapshot Snapshot()=>new(Binding.Role,Health,maximum,RespawnTick,Active,Binding);
}
