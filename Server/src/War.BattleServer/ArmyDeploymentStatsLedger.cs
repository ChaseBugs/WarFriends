namespace War.BattleServer;

public sealed record ArmyDeploymentUsage(int OptionIndex,string UnitId,int Deployments,
    int PlannedSpawns,int ConfirmedSpawns);

/// <summary>Accepted deployment versus actual spawn evidence, by source option.</summary>
public sealed class ArmyDeploymentStatsLedger
{
    private readonly Dictionary<int,(int Deployments,int Confirmed)> rows=[];
    public bool CanRecordAccepted(int optionIndex)
    {
        var option=ArmyOptionIdentityCatalog.Get(optionIndex);
        var current=rows.GetValueOrDefault(optionIndex);
        return current.Deployments<100_000 &&
            (long)(current.Deployments+1)*option.SpawnCount<=100_000;
    }
    public void RecordAccepted(int optionIndex)
    {
        var option=ArmyOptionIdentityCatalog.Get(optionIndex);
        if(!CanRecordAccepted(optionIndex))
            throw new InvalidDataException("Army deployment statistics exceed the match bound.");
        var current=rows.GetValueOrDefault(optionIndex);
        int next=checked(current.Deployments+1);
        rows[optionIndex]=(next,current.Confirmed);
    }
    public void RecordSpawn(int optionIndex,string unitId)
    {
        var option=ArmyOptionIdentityCatalog.Get(optionIndex);
        if(option.UnitId!=unitId || !rows.TryGetValue(optionIndex,out var current) ||
           current.Confirmed>=(long)current.Deployments*option.SpawnCount)
            throw new InvalidDataException("Army spawn lacks an accepted source deployment.");
        rows[optionIndex]=(current.Deployments,checked(current.Confirmed+1));
    }
    public IReadOnlyList<ArmyDeploymentUsage> Snapshot()=>rows.OrderBy(pair=>pair.Key)
        .Select(pair=>
        {
            var option=ArmyOptionIdentityCatalog.Get(pair.Key);
            return new ArmyDeploymentUsage(option.Index,option.UnitId,pair.Value.Deployments,
                checked(pair.Value.Deployments*option.SpawnCount),pair.Value.Confirmed);
        }).ToArray();
}
