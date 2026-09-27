using System.Numerics;
namespace War.BattleServer;

// DroneSteering.Update uses retained heading and bank, not velocity LookRotation.
public sealed class DroneOrientationState
{
    private float angle;
    private Quaternion vertical=Quaternion.Identity,horizontal=Quaternion.Identity;
    public Quaternion Rotation=>vertical*horizontal;
    public void Advance(Vector3 position,Vector3 velocity,Vector3 steering,float deltaTime,Vector3? lookTarget)
    {
        if(!Finite(position)||!Finite(velocity)||!Finite(steering)||
            (lookTarget.HasValue&&!Finite(lookTarget.Value))||!float.IsFinite(deltaTime)||deltaTime<=0||deltaTime>.2f)
            throw new InvalidDataException("Invalid Drone orientation authority.");
        float signed=MathF.Atan2(Vector3.Dot(Vector3.UnitY,Vector3.Cross(steering,velocity)),
            Vector3.Dot(steering,velocity))*57.29578f;
        float nextAngle=angle+(signed-angle)*Math.Clamp(deltaTime*5,0,1);
        float magnitude=steering.Length()/deltaTime;
        if(!((nextAngle>0&&nextAngle<90)||(nextAngle< -270&&nextAngle> -360)))magnitude=-magnitude;
        Vector3 axis=Vector3.Cross(Vector3.UnitY,velocity);
        float bankDegrees=magnitude*150000f/60f; // Recovered DroneSteering.multiplier.
        if(!float.IsFinite(nextAngle)||!float.IsFinite(bankDegrees)||!float.IsFinite(axis.LengthSquared()))
            throw new InvalidDataException("Drone orientation overflow.");
        Quaternion bank=axis.Length()>1e-5f?Quaternion.CreateFromAxisAngle(Vector3.Normalize(axis),bankDegrees*MathF.PI/180):Quaternion.Identity;
        Quaternion nextHorizontal=Quaternion.Slerp(horizontal,bank,Math.Clamp(deltaTime,0,1));
        Quaternion nextVertical=vertical;
        if(lookTarget.HasValue)
        {
            Vector3 forward=position-lookTarget.Value;forward.Y=0;
            // Unity LookRotation on zero forward logs and returns identity.
            Quaternion heading=forward.Length()>1e-5f?Quaternion.CreateFromAxisAngle(Vector3.UnitY,
                MathF.Atan2(forward.X,forward.Z)):Quaternion.Identity;
            nextVertical=Quaternion.Slerp(vertical,heading,Math.Clamp(deltaTime*5,0,1));
        }
        if(!float.IsFinite((nextVertical*nextHorizontal).LengthSquared()))
            throw new InvalidDataException("Invalid Drone orientation result.");
        angle=nextAngle;horizontal=nextHorizontal;vertical=nextVertical;
    }
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}
