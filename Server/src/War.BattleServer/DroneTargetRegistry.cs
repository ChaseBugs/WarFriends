namespace War.BattleServer;

// GameShootableEntity.generatedEntities: owner-type buckets survive OnDisable.
// Explicit bucket order avoids relying on the host Dictionary's iteration contract.
public sealed class DroneTargetRegistry
{
    private readonly List<string> types=[];
    private readonly Dictionary<string,List<string>> groups=new(StringComparer.Ordinal);
    private readonly Dictionary<string,(string Type,DroneTargetCandidate Candidate)> rows=new(StringComparer.Ordinal);
    public void Enable(string ownerType,DroneTargetCandidate candidate)
    {
        if(string.IsNullOrEmpty(ownerType)||ownerType.Length>100||ownerType.Any(char.IsControl)||
           candidate is null||string.IsNullOrEmpty(candidate.Id)||rows.ContainsKey(candidate.Id)||rows.Count>=1000)
            throw new InvalidDataException("Invalid Drone target registration.");
        Validate(candidate);
        if(!groups.TryGetValue(ownerType,out var group))
        {
            if(types.Count>=100)throw new InvalidDataException("Drone target owner-type capacity exceeded.");
            group=[];groups.Add(ownerType,group);types.Add(ownerType);
        }
        group.Add(candidate.Id);rows.Add(candidate.Id,(ownerType,candidate));
    }
    public void Update(DroneTargetCandidate candidate)
    {
        if(candidate is null||string.IsNullOrEmpty(candidate.Id)||!rows.TryGetValue(candidate.Id,out var row))
            throw new InvalidDataException("Unknown Drone target update.");
        Validate(candidate);rows[candidate.Id]=(row.Type,candidate);
    }
    public void Disable(string id)
    {
        if(id is null||!rows.Remove(id,out var row))
            throw new InvalidDataException("Unknown Drone target removal.");
        groups[row.Type].Remove(id);
    }
    public IReadOnlyList<DroneTargetCandidate> Snapshot()
        =>Array.AsReadOnly(types.SelectMany(type=>groups[type]).Select(id=>rows[id].Candidate).ToArray());
    public DroneTargetCandidate? Select(int fraction,Func<DroneTargetCandidate,bool> canSee)
        =>DroneTargetPolicy.Select(fraction,Snapshot(),canSee);
    private static void Validate(DroneTargetCandidate candidate)
        =>DroneTargetPolicy.Select(1,[candidate],_=>false);
}
