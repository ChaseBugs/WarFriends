namespace War.BattleServer;
public enum BattleLoadingPhase { Waiting, Started, Cancelled, TimedOut }

public sealed class BattleLoadingState
{
    private readonly string manifest;
    private readonly ulong deadline;
    private readonly HashSet<string> admitted=[];
    private readonly HashSet<string> ready=[];
    public bool Started { get; private set; }
    public bool Cancelled { get; private set; }
    public BattleLoadingPhase Phase=>Cancelled?BattleLoadingPhase.Cancelled:Started?BattleLoadingPhase.Started:BattleLoadingPhase.Waiting;
    public BattleLoadingState(string manifestHash,ulong deadlineTick=0){if(!System.Text.RegularExpressions.Regex.IsMatch(manifestHash??"",@"\A[0-9a-f]{64}\z")||deadlineTick>10_000_000)throw new InvalidDataException("Invalid loading manifest.");manifest=manifestHash!;deadline=deadlineTick;}
    public bool TimedOut(ulong tick)=>deadline!=0&&!Started&&tick>=deadline;
    public BattleLoadingPhase PhaseAt(ulong tick)=>Cancelled?BattleLoadingPhase.Cancelled:Started?BattleLoadingPhase.Started:TimedOut(tick)?BattleLoadingPhase.TimedOut:BattleLoadingPhase.Waiting;
    public bool Cancel(string reason){if(Started||Cancelled||string.IsNullOrWhiteSpace(reason)||reason.Length>64)return false;Cancelled=true;return true;}
    public bool Apply(BattleLoadingCommand command)
    {
        BattleLoadingCommandValidator.Validate(command);
        return command.Kind switch
        {
            BattleLoadingCommandKind.Admit=>Admit(command.PlayerId),
            BattleLoadingCommandKind.Ready=>MarkReady(command.PlayerId,command.ManifestHash,true),
            BattleLoadingCommandKind.Cancel=>Cancel(command.Reason),
            _=>false
        };
    }
    public bool Admit(string playerId){if(Started||Cancelled||!Guid.TryParseExact(playerId,"N",out _)||admitted.Count>=2)return false;return admitted.Add(playerId);}
    public bool MarkReady(string playerId,string manifestHash,bool sceneReady)
    {
        if(Started||Cancelled||!admitted.Contains(playerId)||manifestHash!=manifest||!sceneReady)return false;
        ready.Add(playerId);if(admitted.Count==2&&ready.Count==2)Started=true;return true;
    }
}
