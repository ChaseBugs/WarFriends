using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Bounded dynamic-agent detour for a source-covered route blocked by allied
/// NavMeshAgent radii. Geometry remains pinned; this is not combat collision.
/// </summary>
internal static class ArmyRusherDetourPlanner
{
    internal static ArmyNavMeshCorridor? Plan(RecoveredBattleMap map,
        ArmyNavMeshConnectivity nav,Vector3 start,Vector3 goal,
        IReadOnlyList<Vector3> allies,float radius)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(nav);
        ArgumentNullException.ThrowIfNull(allies);
        if(!PlayerHitbox.Finite(start) || !PlayerHitbox.Finite(goal) ||
           !float.IsFinite(radius) || radius<=0 || radius>1 ||
           allies.Any(p=>!PlayerHitbox.Finite(p)))
            throw new InvalidDataException("Invalid Rusher dynamic detour input.");
        var travel=new Vector2(goal.X-start.X,goal.Z-start.Z);
        if(travel.LengthSquared()<.04f*.04f)return null;
        travel=Vector2.Normalize(travel);
        var side=new Vector2(travel.Y,-travel.X);
        ArmyNavMeshCorridor? best=null;
        foreach(var blocker in allies.OrderBy(p=>Vector2.DistanceSquared(
            new(start.X,start.Z),new(p.X,p.Z))))
        {
            if(Vector2.Distance(new(start.X,start.Z),new(blocker.X,blocker.Z))>1.5f)
                continue;
            foreach(float distance in new[]{.45f,.55f,.7f,.85f})
                foreach(int sign in new[]{1,-1})
                {
                    var point=new Vector3(blocker.X+sign*side.X*distance,
                        blocker.Y,blocker.Z+sign*side.Y*distance);
                    if(nav.Classify(map,start,point)!=ArmyNavMeshConnection.Connected ||
                       nav.Classify(map,point,goal)!=ArmyNavMeshConnection.Connected)
                        continue;
                    ArmyNavMeshCorridor? first,second;
                    try
                    {first=nav.PlanCorridor(map,start,point);
                     second=nav.PlanCorridor(map,point,goal);}
                    catch(InvalidDataException){continue;}
                    if(first is not {PlanarCovered:true} ||
                       second is not {PlanarCovered:true})continue;
                    var points=first.SmoothedPoints.Concat(second.SmoothedPoints.Skip(1)).ToArray();
                    if(!Clear(points,allies,2*radius))continue;
                    var audit=nav.InspectPolyline(map,points);
                    if(!audit.PlanarCovered || audit.MaxVerticalDeviation>.35f)continue;
                    float length=0;
                    for(int i=1;i<points.Length;i++)length+=Vector3.Distance(points[i-1],points[i]);
                    if(!float.IsFinite(length) || length<=.04f || length>10000 ||
                       best!=null && length>=best.SmoothedLength)continue;
                    var frozen=Array.AsReadOnly(points);
                    best=new(frozen,length,frozen,length,true,audit.MaxVerticalDeviation);
                }
        }
        return best;
    }

    private static bool Clear(IReadOnlyList<Vector3> points,
        IReadOnlyList<Vector3> allies,float diameter)
    {
        for(int i=1;i<points.Count;i++)
        {
            var a=new Vector2(points[i-1].X,points[i-1].Z);
            var b=new Vector2(points[i].X,points[i].Z);
            var delta=b-a;
            float length=delta.LengthSquared();
            foreach(var ally in allies)
            {
                var center=new Vector2(ally.X,ally.Z);
                float t=length>0 ? Math.Clamp(Vector2.Dot(center-a,delta)/length,0f,1f) : 0f;
                float nearest=Vector2.Distance(a+t*delta,center);
                if(nearest<diameter-.005f)return false;
            }
        }
        return true;
    }
}
