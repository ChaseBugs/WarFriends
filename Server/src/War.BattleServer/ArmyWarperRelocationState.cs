using System.Numerics;

namespace War.BattleServer;

public enum ArmyWarperRelocationPhase { Edge, Pause, Final, Complete }
public enum ArmyWarperPresentationTransition { None, WarpStarted, WarpEnded }

/// <summary>Server-owned initial Warper edge-hop sequence from EnemyController.WarpUpdate.</summary>
public sealed class ArmyWarperRelocationState
{
    private readonly ArmyWarperRelocation policy;
    private readonly ArmyWarperField field;
    private readonly RecoveredBattleMap map;
    private readonly ArmyNavMeshConnectivity navigation;
    private readonly ArmyAgentConfig agent;
    private readonly float effectiveSpeed;
    private readonly Vector3 finalDestination;
    private readonly Func<float> random;
    private ArmyNavMeshMotionState motion;
    private bool side;
    private int edgeHopsRemaining;
    private int legTicks;
    private int pauseTicks;

    public ArmyWarperRelocationPhase Phase { get; private set; }=ArmyWarperRelocationPhase.Edge;
    public Vector3 Position => motion.Position;
    public Vector2 PlanarDirection => Phase is ArmyWarperRelocationPhase.Edge or ArmyWarperRelocationPhase.Final
        ? motion.PlanarDirection : Vector2.Zero;
    internal float PlanarSpeed => Phase is ArmyWarperRelocationPhase.Edge or ArmyWarperRelocationPhase.Final
        ? motion.Speed : 0;
    public bool Transparent => (Phase is ArmyWarperRelocationPhase.Edge or ArmyWarperRelocationPhase.Final) &&
        legTicks>(int)MathF.Floor(policy.WarpAfterSeconds*MatchManifest.TickRate);
    public int CompletedEdgeHops { get; private set; }

    public ArmyWarperRelocationState(Vector3 start,Vector3 finalDestination,
        ArmyWarperRelocation policy,ArmyWarperField field,RecoveredBattleMap map,
        ArmyNavMeshConnectivity navigation,ArmyAgentConfig agent,float effectiveSpeed,Func<float> random,
        bool repeatAfterShot=false)
    {
        if(!PlayerHitbox.Finite(start)||!PlayerHitbox.Finite(finalDestination)||
           !float.IsFinite(effectiveSpeed)||effectiveSpeed<=0||effectiveSpeed>=2)
            throw new InvalidDataException("Invalid initial Warper relocation inputs.");
        this.policy=policy??throw new ArgumentNullException(nameof(policy));
        this.field=field??throw new ArgumentNullException(nameof(field));
        this.map=map??throw new ArgumentNullException(nameof(map));
        this.navigation=navigation??throw new ArgumentNullException(nameof(navigation));
        this.agent=agent??throw new ArgumentNullException(nameof(agent));
        this.effectiveSpeed=effectiveSpeed;this.finalDestination=finalDestination;
        this.random=random??throw new ArgumentNullException(nameof(random));
        side=Next()>.5f;
        edgeHopsRemaining=repeatAfterShot
            ? policy.RepeatWarpCountMin+1+(int)MathF.Floor(Next()*
                (policy.RepeatWarpCountMaxExclusive-policy.RepeatWarpCountMin))
            : policy.InitialWarpCountMin+(int)MathF.Floor(Next()*
                (policy.InitialWarpCountMaxExclusive-policy.InitialWarpCountMin));
        motion=CreateEdge(start);edgeHopsRemaining--;
        if(repeatAfterShot)legTicks=(int)MathF.Ceiling(1.3f*MatchManifest.TickRate);
    }

    public ArmyWarperPresentationTransition AdvanceTick()
    {
        if(Phase==ArmyWarperRelocationPhase.Complete)return ArmyWarperPresentationTransition.None;
        if(Phase==ArmyWarperRelocationPhase.Pause)
        {
            if(++pauseTicks<(int)MathF.Ceiling(policy.ArrivalPauseSeconds*MatchManifest.TickRate))
                return ArmyWarperPresentationTransition.None;
            pauseTicks=0;
            if(edgeHopsRemaining>0)
            {motion=CreateEdge(Position);edgeHopsRemaining--;Phase=ArmyWarperRelocationPhase.Edge;}
            else
            {motion=CreateMotion(Position,finalDestination);Phase=ArmyWarperRelocationPhase.Final;}
            return ArmyWarperPresentationTransition.None;
        }
        bool wasTransparent=Transparent;
        legTicks++;
        float seconds=legTicks/(float)MatchManifest.TickRate;
        float desired=seconds<policy.AccelerationSeconds
            ? policy.StartSpeed+(effectiveSpeed-policy.StartSpeed)*(seconds/policy.AccelerationSeconds)
            : effectiveSpeed;
        if(seconds>policy.WarpAfterSeconds&&desired<2)desired=policy.WarpSpeed;
        motion.SetMaximumSpeed(desired);motion.AdvanceTick();
        if(!motion.Arrived)
            return !wasTransparent&&Transparent
                ?ArmyWarperPresentationTransition.WarpStarted
                :ArmyWarperPresentationTransition.None;
        legTicks=0;
        if(Phase==ArmyWarperRelocationPhase.Final)Phase=ArmyWarperRelocationPhase.Complete;
        else {CompletedEdgeHops++;Phase=ArmyWarperRelocationPhase.Pause;}
        return wasTransparent
            ?ArmyWarperPresentationTransition.WarpEnded
            :ArmyWarperPresentationTransition.None;
    }

    private ArmyNavMeshMotionState CreateEdge(Vector3 start)
    {
        var destination=ArmyWarperDestinationPolicy.Select(policy,field,side,random,
            (point,radius)=>navigation.SampleNearest(map,point,radius));
        side=!side;return CreateMotion(start,destination);
    }
    private ArmyNavMeshMotionState CreateMotion(Vector3 start,Vector3 destination)
    {
        var route=navigation.PlanCorridor(map,start,destination);
        if(route is not {PlanarCovered:true})
            throw new InvalidDataException("Warper destination lacks a covered host corridor.");
        return new(route,agent,policy.WarpSpeed);
    }
    private float Next()
    {
        float value=random();
        if(!float.IsFinite(value)||value<0||value>=1)
            throw new InvalidDataException("Warper random source returned an invalid value.");
        return value;
    }
}
