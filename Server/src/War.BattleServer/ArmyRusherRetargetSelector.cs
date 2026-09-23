using System.Numerics;

namespace War.BattleServer;

internal sealed record ArmyRusherRetargetSelection(ArmyRusherPoint Point,bool Qualified);

/// <summary>
/// EnemyController.FindBestRusherPoint's ordered four-slot permutation scan.
/// Callers must supply the scene-resolved near-neighbour predicate; a selected
/// point is not an occupancy transaction or a navigation route.
/// </summary>
internal static class ArmyRusherRetargetSelector
{
    internal static ArmyRusherRetargetSelection Select(IReadOnlyList<ArmyRusherPoint> previous,
        IReadOnlyList<ArmyRusherPoint> destination,int currentIndex,
        Func<int,bool> occupied,
        Func<ArmyRusherPoint,ArmyRusherPoint,bool> freeWithNearNeighbour)
    {
        ArgumentNullException.ThrowIfNull(previous);
        ArgumentNullException.ThrowIfNull(destination);
        ArgumentNullException.ThrowIfNull(occupied);
        ArgumentNullException.ThrowIfNull(freeWithNearNeighbour);
        if(previous.Count!=4 || destination.Count!=4 || currentIndex is <0 or >3 ||
           previous.Select(p=>p.Index).Where(i=>i is >=0 and <4).Distinct().Count()!=4 ||
           destination.Select(p=>p.Index).Where(i=>i is >=0 and <4).Distinct().Count()!=4 ||
           previous.Where((p,i)=>p.Index!=i).Any() ||
           destination.Where((p,i)=>p.Index!=i).Any())
            throw new InvalidDataException("Rusher retarget requires ordered source four-slot covers.");
        int chosen=0;
        float nearest=float.MaxValue;
        bool qualified=false;
        int[] permutation=[0,1,2,3];
        void Visit(int from)
        {
            if(from==3)
            {
                foreach(var oldPoint in previous)
                {
                    var candidate=destination[permutation[oldPoint.Index]];
                    if(!occupied(oldPoint.ComponentFileId) ||
                       !freeWithNearNeighbour(candidate,oldPoint))continue;
                    float score=Vector3.Distance(oldPoint.Position,candidate.Position);
                    if(candidate.Index<2)score-=1.7f;
                    // The source checks the current soldier's mapped point
                    // separately from the point that supplied this score.
                    var mapped=destination[permutation[currentIndex]];
                    if(score<nearest && freeWithNearNeighbour(mapped,previous[currentIndex]))
                    {chosen=permutation[currentIndex];nearest=score;qualified=true;}
                }
                return;
            }
            Visit(from+1);
            for(int i=from+1;i<4;i++)
            {
                (permutation[from],permutation[i])=(permutation[i],permutation[from]);
                Visit(from+1);
                (permutation[from],permutation[i])=(permutation[i],permutation[from]);
            }
        }
        Visit(0);
        // The recovered method returns destination[0] even if no scan row
        // qualified. A live caller must not mistake that fallback for proof of
        // a free or reachable slot.
        return new(destination[chosen],qualified);
    }
}
