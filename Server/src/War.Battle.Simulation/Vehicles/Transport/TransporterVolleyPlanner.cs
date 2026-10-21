namespace War.BattleServer;

internal sealed record TransporterShotPlan(int WeaponIndex,int TickOffset,bool Real);

/// <summary>Recovered TransporterTurret split: floor-half left, delayed remainder right.</summary>
internal static class TransporterVolleyPlanner
{
    internal static IReadOnlyList<TransporterShotPlan> Plan(int batch,float firstCadence,
        float secondCadence,float probability,bool firstReal,Func<float> random)
    {
        if(batch is <1 or >64||!float.IsFinite(firstCadence)||firstCadence<=0||firstCadence>10||
           !float.IsFinite(secondCadence)||secondCadence<=0||secondCadence>10||
           !float.IsFinite(probability)||probability is <0 or >1||random==null)
            throw new InvalidDataException("Invalid Transporter volley authority.");
        int first=batch/2,second=batch-first;bool firstShot=true;
        var result=new List<TransporterShotPlan>(batch);
        void Add(int weaponIndex,int count,int initialDelay,float cadenceSeconds)
        {
            int cadence=(int)MathF.Ceiling(cadenceSeconds*MatchManifest.TickRate);
            for(int i=0;i<count;i++)
            {
                result.Add(new(weaponIndex,checked(initialDelay+i*cadence),
                    firstShot?firstReal:random()<probability));
                firstShot=false;
            }
        }
        Add(0,first,0,firstCadence);
        Add(1,second,(int)MathF.Ceiling(secondCadence*.5f*MatchManifest.TickRate),secondCadence);
        if(result.Count!=batch)throw new InvalidDataException("Transporter volley lost a source round.");
        return result.AsReadOnly();
    }
}
