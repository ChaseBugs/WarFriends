using System.Numerics;

namespace War.BattleServer;

internal sealed class BazookaHoldState
{
    private ulong started;
    internal bool Active{get;private set;}
    internal Vector3 Target{get;private set;}
    internal void Press(ulong tick,Vector3 target)
    {
        if(!PlayerHitbox.Finite(target))throw new InvalidDataException("Invalid bazooka target.");
        if(Active)return;
        Active=true;started=tick;Target=target;
    }
    internal Vector3? Due(ulong tick,float holdSeconds)
    {
        if(!float.IsFinite(holdSeconds)||holdSeconds<=0||holdSeconds>10)throw new InvalidDataException("Invalid bazooka hold time.");
        if(!Active||tick/(double)MatchManifest.TickRate<=started/(double)MatchManifest.TickRate+holdSeconds)return null;
        Active=false;return Target;
    }
    internal void Cancel(){Active=false;started=0;}
}
