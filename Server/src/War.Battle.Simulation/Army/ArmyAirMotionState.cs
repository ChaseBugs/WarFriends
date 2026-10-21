using System.Numerics;

namespace War.BattleServer;

/// <summary>Fixed-tick, NavMesh-independent motion for recovered air-unit families.</summary>
public sealed class ArmyAirMotionState
{
    private readonly float speed;
    private readonly float arrivalRadius;
    public Vector3 Position { get; private set; }
    public Vector3 Destination { get; }
    public bool Arrived => Vector3.Distance(Position,Destination)<=arrivalRadius;

    public ArmyAirMotionState(Vector3 start,Vector3 destination,float effectiveSpeed,float arrivalRadius=.04f)
    {
        if(!Finite(start)||!Finite(destination)||!float.IsFinite(effectiveSpeed)||effectiveSpeed<=0||effectiveSpeed>20||
           !float.IsFinite(arrivalRadius)||arrivalRadius<=0||arrivalRadius>5)
            throw new InvalidDataException("Invalid recovered air-unit motion inputs.");
        Position=start;Destination=destination;speed=effectiveSpeed;this.arrivalRadius=arrivalRadius;
    }

    public void AdvanceTick()
    {
        if(Arrived)return;
        float step=speed/MatchManifest.TickRate;
        Vector3 delta=Destination-Position;
        float distance=delta.Length();
        if(!float.IsFinite(distance))throw new InvalidDataException("Invalid air-unit distance.");
        Position=distance<=step ? Destination : Position+delta/distance*step;
    }

    private static bool Finite(Vector3 value)=>float.IsFinite(value.X)&&float.IsFinite(value.Y)&&float.IsFinite(value.Z);
}
