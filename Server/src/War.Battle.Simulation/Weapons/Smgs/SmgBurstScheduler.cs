using System.Numerics;

namespace War.BattleServer;

/// <summary>Match-owned continuation of PlayerBurstWeapon after its first
/// authoritative shot. A released input cannot cancel the remaining rounds.</summary>
internal sealed class SmgBurstScheduler
{
    private int remaining;
    private ulong nextShotTick,lockThroughTick,lastTick;
    private Vector3 target;
    public bool Active=>remaining>0;
    public int Remaining=>remaining;
    public ulong NextShotTick=>nextShotTick;
    public ulong LockThroughTick=>lockThroughTick;
    public bool CanStart(ulong tick)=>!Active&&tick>lockThroughTick;

    internal void StartAfterFirstShot(ulong tick,Vector3 authoritativeTarget,IBurstStage stage)
    {
        Time(tick);
        if(!PlayerHitbox.Finite(authoritativeTarget)||stage==null||stage.BurstSize is <2 or >32||
           !float.IsFinite(stage.CadenceSeconds)||stage.CadenceSeconds is <.01f or >60||
           !float.IsFinite(stage.BurstLockSeconds)||stage.BurstLockSeconds is <.01f or >60||!CanStart(tick))
            throw new InvalidDataException("Invalid SMG burst start.");
        target=authoritativeTarget;remaining=stage.BurstSize-1;
        nextShotTick=checked(tick+Ticks(stage.CadenceSeconds));lastTick=tick;
    }

    internal Vector3? Advance(ulong tick,IBurstStage stage)
    {
        Time(tick);lastTick=tick;
        if(!Active||tick<nextShotTick)return null;
        if(tick!=nextShotTick)throw new InvalidDataException("SMG burst skipped an authoritative simulation tick.");
        remaining--;
        if(remaining==0)
        {
            lockThroughTick=checked(tick+Ticks(stage.BurstLockSeconds));nextShotTick=0;
        }
        else nextShotTick=checked(tick+Ticks(stage.CadenceSeconds));
        return target;
    }

    internal void UpdateTarget(Vector3 authoritativeTarget)
    {
        if(!Active||!PlayerHitbox.Finite(authoritativeTarget))throw new InvalidDataException("Invalid SMG burst target update.");
        target=authoritativeTarget;
    }

    internal void Cancel()
    {remaining=0;nextShotTick=0;}

    private void Time(ulong tick)
    {if(tick<lastTick||tick>10_000_000)throw new InvalidDataException("Invalid SMG burst clock.");}
    private static ulong Ticks(float seconds)=>checked((ulong)Math.Ceiling(seconds*MatchManifest.TickRate));
}
