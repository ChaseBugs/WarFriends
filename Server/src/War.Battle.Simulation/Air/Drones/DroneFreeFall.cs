using System.Numerics;
namespace War.BattleServer;

// Unity 2018 isolated Rigidbody oracle only; contact solving is separate.
internal static class DroneFreeFall
{
    internal static (Vector3 Position,Vector3 Velocity) Step(Vector3 position,Vector3 velocity)
    {
        if(!PlayerHitbox.Finite(position)||!PlayerHitbox.Finite(velocity))
            throw new InvalidDataException("Invalid Drone free-fall state.");
        const float step=.02f,drag=1;
        velocity+=new Vector3(0,-9.81f,0)*step;
        velocity*=Math.Max(0,1-drag*step);
        position+=velocity*step;
        if(!PlayerHitbox.Finite(position)||!PlayerHitbox.Finite(velocity))
            throw new InvalidDataException("Drone free-fall arithmetic overflow.");
        return(position,velocity);
    }
}
