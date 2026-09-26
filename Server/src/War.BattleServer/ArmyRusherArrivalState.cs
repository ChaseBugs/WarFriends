using System.Numerics;

namespace War.BattleServer;

public enum ArmyRusherTravelPhase { Walking, Settling, Rusher }

/// <summary>
/// Source-bound Rusher arrival state. This models the strict EnemyPoint arrival
/// gate and prefab TweenPosition/first-shot timing, but grants no attack authority.
/// </summary>
public sealed class ArmyRusherArrivalState
{
    private const int SettleTicks=MatchManifest.TickRate/2;
    private readonly ArmyNavMeshMotionState? motion;
    private readonly Vector3 target;
    private Vector3 settleStart;
    private int ticksSinceArrival;

    public ArmyRusherTravelPhase Phase { get; private set; }=ArmyRusherTravelPhase.Walking;
    public Vector3 Position { get; private set; }
    public Vector2 PlanarDirection => Phase==ArmyRusherTravelPhase.Walking ?
        motion!.PlanarDirection : Vector2.Zero;
    internal float PlanarSpeed => Phase==ArmyRusherTravelPhase.Walking ? motion!.Speed : 0;
    public bool InitialShotDelayElapsed => Phase==ArmyRusherTravelPhase.Rusher &&
        ticksSinceArrival>SettleTicks;
    internal int RejectedMotionTicks { get; private set; }
    internal float MotionProgress => motion?.Traveled??0;
    internal float MotionLength => motion?.Length??0;
    internal Vector3 Destination => target;

    public ArmyRusherArrivalState(ArmyNavMeshCorridor route,ArmyAgentConfig agent,float speed)
    {
        ArgumentNullException.ThrowIfNull(route);
        motion=new ArmyNavMeshMotionState(route,agent,speed);
        target=route.SmoothedPoints[^1];
        Position=motion.Position;
    }

    internal ArmyRusherArrivalState(Vector3 position,Vector3 destination)
    {
        if(!PlayerHitbox.Finite(position)||!PlayerHitbox.Finite(destination)||
           Vector3.Distance(position,destination)>.55f)
            throw new InvalidDataException("Invalid Warper-to-Rusher arrival gate.");
        Position=position;settleStart=position;target=destination;
        Phase=ArmyRusherTravelPhase.Settling;
    }

    public void AdvanceTick()
    {
        if(Phase==ArmyRusherTravelPhase.Walking)
        {
            motion!.AdvanceTick();
            Position=motion.Position;
            if(motion.Arrived)
            {
                settleStart=Position;
                Phase=ArmyRusherTravelPhase.Settling;
            }
            return;
        }
        ticksSinceArrival++;
        if(Phase==ArmyRusherTravelPhase.Rusher)return;
        float t=Math.Clamp((float)ticksSinceArrival/SettleTicks,0f,1f);
        // UITweener.Method.EaseInOut with steeperCurves=0 on enemy.prefab.
        float eased=t-MathF.Sin(t*MathF.Tau)/MathF.Tau;
        Position=Vector3.Lerp(settleStart,new Vector3(target.X,settleStart.Y,target.Z),eased);
        if(ticksSinceArrival>=SettleTicks)Phase=ArmyRusherTravelPhase.Rusher;
    }

    // Preserve the corridor state when another live agent occupies the proposed
    // radius. Waiting is deterministic and cannot consume an arrival/shot tick.
    internal bool TryAdvanceTick(Func<Vector3,Vector3,bool> allowed)
    {
        ArgumentNullException.ThrowIfNull(allowed);
        var before=Position;
        ArmyNavMeshMotionState.Checkpoint? checkpoint=motion?.Capture();
        var phase=Phase;
        var start=settleStart;
        int ticks=ticksSinceArrival;
        AdvanceTick();
        if(Position==before || allowed(before,Position))return true;
        RejectedMotionTicks++;
        if(checkpoint.HasValue)motion!.Restore(checkpoint.Value);
        Position=before;Phase=phase;settleStart=start;ticksSinceArrival=ticks;
        return false;
    }
}
