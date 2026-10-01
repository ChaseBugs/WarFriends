using System.Numerics;

namespace War.BattleServer;

// Helicopter.Update heading and bank after Steer/position integration.
// The caller supplies Unity's scaled frame delta separately from realtime Steer.
internal sealed class HelicopterOrientationState
{
    private Quaternion horizontal=Quaternion.Identity,vertical=Quaternion.Identity;
    private float angle;
    internal Quaternion Rotation=>horizontal*vertical;

    internal void Advance(Vector3 position,Vector3 velocity,Vector3 steering,
        Vector3 target,bool breaking,float frameDelta)
    {
        if(!PlayerHitbox.Finite(position)||!PlayerHitbox.Finite(velocity)||
           !PlayerHitbox.Finite(steering)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(frameDelta)||frameDelta<=0||frameDelta>.2f)
            throw new InvalidDataException("Invalid Helicopter orientation frame.");
        Vector3 forward=breaking?target-position:velocity;
        if(forward.Y>0&&!breaking)forward.Y=-forward.Y;
        else forward.Y=0;
        Quaternion nextVertical=vertical;
        if(forward.LengthSquared()>1e-10f)
            nextVertical=Slerp(vertical,LookRotation(forward),
                Math.Clamp(frameDelta*(breaking?2f:5f),0,1));
        Quaternion nextHorizontal=horizontal;
        float nextAngle=angle;
        if(velocity.LengthSquared()>0&&steering.LengthSquared()>0)
        {
            float signed=MathF.Atan2(Vector3.Dot(Vector3.UnitY,Vector3.Cross(steering,velocity)),
                Vector3.Dot(steering,velocity))*57.29578f;
            nextAngle=angle+(signed-angle)*Math.Clamp(frameDelta*5f,0,1);
            float degrees=nextAngle*50f*(steering.Length()/frameDelta);
            if(!float.IsFinite(degrees))throw new InvalidDataException("Helicopter bank overflow.");
            Quaternion bank=Quaternion.CreateFromAxisAngle(Vector3.Normalize(velocity),degrees*MathF.PI/180f);
            nextHorizontal=Slerp(horizontal,breaking?Quaternion.Identity:bank,
                Math.Clamp(frameDelta*(breaking?.5f:1f),0,1));
        }
        var rotation=nextHorizontal*nextVertical;
        if(!float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Helicopter orientation lost unit rotation.");
        horizontal=nextHorizontal;vertical=nextVertical;angle=nextAngle;
    }
    internal static Quaternion LookRotation(Vector3 forward)
    {
        var z=Vector3.Normalize(forward);
        var x=Vector3.Cross(Vector3.UnitY,z);
        if(x.LengthSquared()<1e-10f)x=Vector3.Cross(Vector3.UnitZ,z);
        x=Vector3.Normalize(x);var y=Vector3.Cross(z,x);
        var matrix=new Matrix4x4(x.X,x.Y,x.Z,0,y.X,y.Y,y.Z,0,z.X,z.Y,z.Z,0,0,0,0,1);
        return Quaternion.Normalize(Quaternion.CreateFromRotationMatrix(matrix));
    }
    private static Quaternion Slerp(Quaternion from,Quaternion to,float amount)
    {
        float dot=Quaternion.Dot(from,to);
        if(dot<0){to=-to;dot=-dot;}
        return dot>=.95f?Quaternion.Normalize(from*(1-amount)+to*amount):Quaternion.Slerp(from,to,amount);
    }
}
