using System.Numerics;
namespace War.BattleServer;

public sealed record DroneTargetCandidate(string Id,int Fraction,bool Alive,bool Visible,
    bool IsDecoy,int? UnitType,Vector3 Position);
public sealed record DroneSightRay(Vector3 Origin,Vector3 Direction,float Range);

public static class DroneTargetPolicy
{
    // Caller must provide the source registry ordering; never nearest/random sort.
    public static DroneTargetCandidate? Select(int fraction,IReadOnlyList<DroneTargetCandidate> registry,
        Func<DroneTargetCandidate,bool> canSee)
    {
        if(fraction is not (1 or 2)||registry==null||registry.Count>1000||canSee==null)
            throw new InvalidDataException("Invalid Drone target registry.");
        var ids=new HashSet<string>(StringComparer.Ordinal);
        foreach(var row in registry)
            if(row==null||string.IsNullOrEmpty(row.Id)||row.Id.Length>100||row.Id.Any(char.IsControl)||
               !ids.Add(row.Id)||row.Fraction is not (1 or 2)||
               row.UnitType is <0 or >3||!Finite(row.Position))
                throw new InvalidDataException("Invalid Drone target identity.");
        var opponents=registry.Where(r=>r.Fraction!=fraction&&r.Alive&&r.Visible).ToArray();
        DroneTargetCandidate? First(IEnumerable<DroneTargetCandidate> rows)=>rows.FirstOrDefault(canSee);
        var selected=First(opponents.Where(r=>r.IsDecoy));
        if(selected!=null)return selected;
        selected=First(opponents.Where(r=>r.UnitType==3));
        if(selected!=null)return selected;
        foreach(int group in new[]{1,3,2,0})
        {
            selected=First(opponents.Where(r=>r.UnitType==group));
            if(selected!=null)return selected;
        }
        return First(opponents);
    }
    // AIObject.CanSeeTarget(targetPosition), not the Static overload used by turret.
    public static DroneSightRay Sight(Vector3 dronePosition,Vector3 targetPosition)
    {
        if(!Finite(dronePosition)||!Finite(targetPosition))throw new InvalidDataException("Invalid Drone sight positions.");
        Vector3 origin=dronePosition+Vector3.UnitY*.5f,delta=targetPosition-origin;
        float distance=delta.Length();
        if(!float.IsFinite(distance))throw new InvalidDataException("Drone sight distance overflow.");
        Vector3 direction=distance>1e-5f?delta/distance:Vector3.Zero;
        origin+=direction*.5f;
        float range=Math.Max(.1f,Vector3.Distance(origin,targetPosition)-.5f);
        if(!Finite(origin)||!float.IsFinite(range))throw new InvalidDataException("Drone sight ray overflow.");
        return new(origin,direction,range);
    }
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}
