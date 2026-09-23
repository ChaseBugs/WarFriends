using System.Numerics;

namespace War.BattleServer;

/// <summary>Recovered PlayerMinigunWeapon hold/spin-up and acceleration clock.</summary>
internal sealed class MinigunFireState
{
    private double pressedSeconds,lastShotSeconds,nextLockSeconds;
    private bool hasShot;
    internal bool Active {get;private set;}
    internal Vector3 Target {get;private set;}
    internal void Press(ulong tick,Vector3 target)
    {if(!PlayerHitbox.Finite(target))throw new InvalidDataException("Invalid minigun target.");Active=true;pressedSeconds=tick/(double)MatchManifest.TickRate;lastShotSeconds=0;nextLockSeconds=0;hasShot=false;Target=target;}
    internal void UpdateTarget(Vector3 target){if(!Active||!PlayerHitbox.Finite(target))throw new InvalidDataException("Invalid minigun hold target.");Target=target;}
    internal void Release(){Active=false;hasShot=false;}
    internal Vector3? Due(ulong tick,MinigunStage stage,MinigunBinding binding)
    {
        if(!Active)return null;
        double now=tick/(double)MatchManifest.TickRate;
        if(now<=pressedSeconds+binding.SpinUpSeconds||now<=nextLockSeconds||hasShot&&now<=lastShotSeconds+stage.CadenceSeconds)return null;
        return Target;
    }
    internal void ShotAccepted(ulong tick,MinigunStage stage)
    {
        if(!Active)throw new InvalidDataException("Inactive minigun accepted a shot.");
        double now=tick/(double)MatchManifest.TickRate;
        double elapsed=now-pressedSeconds;
        double factor=Math.Clamp(elapsed/stage.HeatSeconds,0,1);
        double extra=Math.Clamp(.3-factor*.3,0,.3);
        lastShotSeconds=now;nextLockSeconds=now+extra;hasShot=true;
    }
}
