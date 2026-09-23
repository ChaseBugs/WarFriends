namespace War.BattleServer;

public enum BattleObjectiveKind { DestroyCrates, DestroyEnemyCrates, GainSkillshots, Collect }
public sealed class BattleObjectiveState
{
    private const int MaximumEvents = 4096;
    private readonly Dictionary<BattleObjectiveKind,int> progress=[];
    private readonly HashSet<string> events=[];
    private readonly IReadOnlyDictionary<BattleObjectiveKind,int> targets;
    public BattleObjectiveState(IReadOnlyDictionary<BattleObjectiveKind,int> targets)
    {
        if(targets==null||targets.Count==0||targets.Any(x=>x.Key<BattleObjectiveKind.DestroyCrates||x.Value<1||x.Value>100000))
            throw new InvalidDataException("Invalid battle objective targets.");
        this.targets=new Dictionary<BattleObjectiveKind,int>(targets);
        foreach(var key in targets.Keys)progress[key]=0;
    }
    public int Record(BattleObjectiveKind kind,int amount)
    {
        if(amount<1||amount>1000||!targets.ContainsKey(kind))throw new InvalidDataException("Invalid objective event.");
        int next=Math.Min(targets[kind],checked(progress[kind]+amount));progress[kind]=next;return next;
    }
    public int RecordEvent(string eventId,BattleObjectiveKind kind,int amount)
    {
        if(!Guid.TryParseExact(eventId,"N",out _))throw new InvalidDataException("Invalid objective event ID.");
        if(events.Contains(eventId))return progress.GetValueOrDefault(kind);
        if (events.Count >= MaximumEvents) throw new InvalidDataException("Objective event capacity exhausted.");
        int value=Record(kind,amount);events.Add(eventId);return value;
    }
    public bool Complete(BattleObjectiveKind kind)=>targets.TryGetValue(kind,out var target)&&progress[kind]>=target;
    public int Progress(BattleObjectiveKind kind)=>progress.GetValueOrDefault(kind);
    public IReadOnlyDictionary<BattleObjectiveKind,int> ProgressSnapshot() =>
        new Dictionary<BattleObjectiveKind,int>(progress);
    public IReadOnlyDictionary<BattleObjectiveKind,int> TargetSnapshot() =>
        new Dictionary<BattleObjectiveKind,int>(targets);
}
