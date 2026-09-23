namespace War.BattleServer;

public sealed class OfflineCampaignPolicy
{
    private const int MaximumObjectiveEvents = 8192;
    private readonly HashSet<int> completed=[];
    private readonly HashSet<int> active=[];
    private readonly HashSet<string> objectiveEvents=[];
    private readonly Dictionary<int,int> objectives=[];
    public bool TryStart(int missionId)
        =>missionId is >=1 and <=1000&&!completed.Contains(missionId)&&active.Add(missionId);
    public bool Complete(int missionId)
    {
        if(missionId is <1 or >1000||completed.Contains(missionId)||!active.Remove(missionId))return false;
        completed.Add(missionId);return true;
    }
    public bool IsCompleted(int missionId)=>completed.Contains(missionId);
    public int RecordObjective(int missionId,string eventId,int amount,int target)
    {
        if(missionId is <1 or >1000||!Guid.TryParseExact(eventId,"N",out _)||amount<1||amount>1000||target<1||target>100000)
            throw new InvalidDataException("Invalid offline campaign objective.");
        if(objectiveEvents.Contains(eventId))return objectives.GetValueOrDefault(missionId);
        if(objectiveEvents.Count >= MaximumObjectiveEvents)throw new InvalidDataException("Offline objective event capacity exhausted.");
        objectiveEvents.Add(eventId);
        objectives[missionId]=Math.Min(target,checked(objectives.GetValueOrDefault(missionId)+amount));return objectives[missionId];
    }
    public void Validate()
    {
        if (active.Count > 1000 || completed.Count > 1000 || active.Overlaps(completed) ||
            active.Any(x => x is < 1 or > 1000) || completed.Any(x => x is < 1 or > 1000) ||
            objectives.Any(x => x.Key is < 1 or > 1000 || x.Value < 0 || x.Value > 100000) ||
            objectiveEvents.Count > MaximumObjectiveEvents)
            throw new InvalidDataException("Invalid offline campaign state.");
    }
    public IReadOnlyList<int> ActiveMissions() => active.OrderBy(x => x).ToArray();
    public IReadOnlyList<int> CompletedMissions() => completed.OrderBy(x => x).ToArray();
    public IReadOnlyDictionary<int,int> ObjectiveProgress() => new Dictionary<int,int>(objectives);
}
