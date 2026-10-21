using System.Numerics;

namespace War.BattleServer;

internal sealed class SniperAimState
{
    private double? armed;
    internal bool Active{get;private set;}
    internal Vector3 Target{get;private set;}
    internal void Press(ulong tick,Vector3 target,bool ready){if(!PlayerHitbox.Finite(target))throw new InvalidDataException("Invalid sniper target.");Active=true;armed=ready?tick/(double)MatchManifest.TickRate:null;Target=target;}
    internal void Arm(ulong tick){if(Active&&!armed.HasValue)armed=tick/(double)MatchManifest.TickRate;}
    internal void Update(Vector3 target){if(!Active||!PlayerHitbox.Finite(target))throw new InvalidDataException("Invalid sniper aim update.");Target=target;}
    internal bool ScopeVisible(ulong tick,float scopeShowSeconds)
    {return Active&&armed.HasValue&&tick/(double)MatchManifest.TickRate>armed.Value+scopeShowSeconds;}
    internal Vector3? Release(ulong tick,float scopeShowSeconds,bool cancelled)
    {if(!Active)return null;Active=false;double now=tick/(double)MatchManifest.TickRate;var result=!cancelled&&armed.HasValue&&now>armed.Value+scopeShowSeconds?Target:(Vector3?)null;armed=null;return result;}
    internal void Cancel(){Active=false;armed=null;}
}
