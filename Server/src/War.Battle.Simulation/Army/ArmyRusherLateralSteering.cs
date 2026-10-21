using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Bounded opposing-agent steering over a source-bound corridor. The published
/// offset remains on the pinned NavMesh but does not authorize combat hits.
/// </summary>
internal sealed class ArmyRusherLateralSteering
{
    private Vector2 offset;
    private Vector2 lockedSide;
    private bool engaged;
    public Vector3 Position { get; private set; }
    public Vector2 Offset => offset;
    public int BlockedSteps { get; private set; }
    public int RejectedSideSteps { get; private set; }
    public string FirstBlockedDiagnostic { get; private set; }="";

    internal ArmyRusherLateralSteering(Vector3 start)
    {
        if(!PlayerHitbox.Finite(start))throw new InvalidDataException("Invalid Rusher steering origin.");
        Position=start;
    }

    internal void Advance(Vector3 basePosition,Vector2 direction,
        IReadOnlyList<(Vector3 Position,Vector2 Direction)> opponents,
        Func<Vector3,Vector3,bool> covered)
    {
        ArgumentNullException.ThrowIfNull(opponents);
        ArgumentNullException.ThrowIfNull(covered);
        if(!PlayerHitbox.Finite(basePosition) || !float.IsFinite(direction.X) ||
           !float.IsFinite(direction.Y) || direction.LengthSquared()>1.01f)
            throw new InvalidDataException("Invalid Rusher steering input.");
        if(opponents.Count==0 && offset==Vector2.Zero)
        {Position=basePosition;engaged=false;return;}
        Vector2 desired=Vector2.Zero;
        if(direction.LengthSquared()>.5f)
        {
            float nearest=float.MaxValue;
            foreach(var opponent in opponents)
            {
                if(!PlayerHitbox.Finite(opponent.Position) ||
                   !float.IsFinite(opponent.Direction.X) ||
                   !float.IsFinite(opponent.Direction.Y) ||
                   opponent.Direction.LengthSquared()>1.01f)
                    throw new InvalidDataException("Invalid opposing Rusher steering input.");
                var toOther=new Vector2(opponent.Position.X-basePosition.X,
                    opponent.Position.Z-basePosition.Z);
                float distance=toOther.Length();
                if(distance<nearest)nearest=distance;
            }
            if(!engaged && nearest<2f)
            {
                // Lock the entry tangent through the encounter. Recomputing
                // "right" at every sharp source corner cancels the sidestep.
                lockedSide=new Vector2(direction.Y,-direction.X);
                engaged=true;
            }
            if(engaged && nearest>2.3f)engaged=false;
            if(engaged)desired=lockedSide*.24f;
        }
        else engaged=false;
        var change=desired-offset;
        if(change.LengthSquared()>.015f*.015f)
            change=Vector2.Normalize(change)*.015f;
        Vector2 nextOffset=offset+change;
        Vector3 projected=new(basePosition.X+nextOffset.X,basePosition.Y,
            basePosition.Z+nextOffset.Y);
        if(!covered(Position,projected))
        {
            RejectedSideSteps++;
            nextOffset=offset;
            projected=new(basePosition.X+offset.X,basePosition.Y,basePosition.Z+offset.Y);
            if(!covered(Position,projected))
            {
                nextOffset=Vector2.Zero;
                projected=basePosition;
                if(!covered(Position,projected))
                {
                    if(BlockedSteps==0)
                        FirstBlockedDiagnostic=$"from {Position} to base {basePosition}, offset {offset}";
                    BlockedSteps++;return;
                }
            }
        }
        offset=nextOffset;
        Position=projected;
    }
}
