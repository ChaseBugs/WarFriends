namespace War.BattleServer;

public sealed class CoopMissionState
{
    private const int MaximumEvents = 4096;
    private readonly int totalWaves;
    private readonly HashSet<string> completedEvents=[];
    private readonly HashSet<string> participants=[];
    private readonly HashSet<string> ready=[];
    public int Wave { get; private set; }=1;
    public int TotalWaves => totalWaves;
    public bool Failed { get; private set; }
    public ulong DeadlineTick { get; }
    public bool Completed=>!Failed&&Wave>totalWaves;
    public bool Started { get; private set; }
    public CoopMissionState(int totalWaves,ulong deadlineTick=0)
    {
        if(totalWaves is <1 or >1000)throw new InvalidDataException("Invalid co-op wave count.");
        this.totalWaves=totalWaves;
        if(deadlineTick>10_000_000)throw new InvalidDataException("Invalid co-op mission deadline.");
        DeadlineTick=deadlineTick;
    }
    public bool AdvanceClock(ulong tick)
    {
        if(DeadlineTick==0||tick<DeadlineTick||Failed||Completed)return false;
        Failed=true;return true;
    }
    public bool AdvanceWave(string eventId,bool success)
    {
        if(!Guid.TryParseExact(eventId,"N",out _)||Failed||Completed||completedEvents.Count>=MaximumEvents||!completedEvents.Add(eventId))return false;
        if(!success){Failed=true;return true;}
        Wave=checked(Wave+1);return true;
    }
    public bool Admit(string playerId)
    {
        if(!Guid.TryParseExact(playerId,"N",out _)||Started||participants.Count>=2)return false;
        return participants.Add(playerId);
    }
    public bool MarkReady(string playerId)
    {
        if(!participants.Contains(playerId)||Started)return false;
        ready.Add(playerId);
        if(participants.Count==2&&ready.Count==2)Started=true;
        return true;
    }
    public bool Leave(string playerId)
    {
        if (!participants.Remove(playerId)) return false;
        ready.Remove(playerId);
        if (Started && !Completed) Failed = true;
        return true;
    }
    public IReadOnlyCollection<string> Participants => participants.ToArray();
    public void Validate(){
        if(Wave<1||Wave>totalWaves+1||participants.Count>2||ready.Count>participants.Count||
           participants.Any(x=>!Guid.TryParseExact(x,"N",out _))||ready.Any(x=>!participants.Contains(x))||
           (Started && (participants.Count!=2||ready.Count!=2))||(!Failed&&Wave==totalWaves+1&&Started==false))
            throw new InvalidDataException("Invalid co-op mission state.");
    }
}
