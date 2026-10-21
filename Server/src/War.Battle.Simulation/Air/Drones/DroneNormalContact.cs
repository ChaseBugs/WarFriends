using System.Numerics;
namespace War.BattleServer;

internal readonly record struct PreparedNormalContact(float VelocityMultiplier,float BiasedError,float UnbiasedError);

// Static-map, zero-restitution preparation for the recovered default materials.
// Other material restitution and moving counterpart bodies are not covered.
internal static class DroneNormalContact
{
    internal static PreparedNormalContact Prepare(DroneImpulseResponse response,Vector3 root,Quaternion rotation,
        Vector3 initialVelocity,Vector3 initialAngularVelocity,Vector3 worldPoint,Vector3 normal,
        float separation,float restDistance,float maximumDepenetrationVelocity,float timestep)
    {
        if(!float.IsFinite(separation)||Math.Abs(separation)>100||!float.IsFinite(restDistance)||
           restDistance<0||restDistance>1||!float.IsFinite(maximumDepenetrationVelocity)||
           maximumDepenetrationVelocity<0||!float.IsFinite(timestep)||timestep<=0||timestep>1)
            throw new InvalidDataException("Invalid normal contact preparation authority.");
        float multiplier=response.ContactVelocityMultiplier(root,rotation,worldPoint,normal);
        float initialSpeed=Vector3.Dot(normal,response.PointVelocity(root,rotation,
            initialVelocity,initialAngularVelocity,worldPoint));
        float penetration=separation-restDistance;
        float biasSpeed=Math.Max(-maximumDepenetrationVelocity,penetration*(.8f/timestep));
        float scaledBias=multiplier*biasSpeed;
        float target=-initialSpeed*multiplier;
        var result=new PreparedNormalContact(multiplier,target-scaledBias,target-Math.Max(scaledBias,0));
        if(!float.IsFinite(result.BiasedError)||!float.IsFinite(result.UnbiasedError))
            throw new InvalidDataException("Normal preparation arithmetic overflow.");
        return result;
    }
}
