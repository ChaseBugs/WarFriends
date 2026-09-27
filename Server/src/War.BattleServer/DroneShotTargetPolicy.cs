using System.Numerics;
namespace War.BattleServer;

public sealed record DroneShotTarget(int TransformFileId,int Type,Vector3 Position);
public static class DroneShotTargetPolicy
{
    public static DroneShotTarget? Select(Vector3 origin,IReadOnlyList<DroneShotTarget> targets,
        bool isPlayer,Vector3 playerRoot,Vector3 playerAimForward,bool hiding,float shieldProbability,Func<float> random)
    {
        if(!Finite(origin)||targets==null||targets.Count>100||!Finite(playerRoot)||!Finite(playerAimForward)||
           !float.IsFinite(shieldProbability)||shieldProbability< -1||shieldProbability>1||random==null)
            throw new InvalidDataException("Invalid Drone shot-target authority.");
        var ids=new HashSet<int>();
        foreach(var row in targets)
            if(row==null||row.TransformFileId<=0||!ids.Add(row.TransformFileId)||row.Type<0||row.Type>0xFFFFFF||!Finite(row.Position))
                throw new InvalidDataException("Invalid Drone shot-target definition.");
        if(!isPlayer)return Nearest(origin,targets,0xFFFFFB);
        if(shieldProbability<0)return null;
        Vector3 delta=origin-playerRoot;float denominator=MathF.Sqrt(playerAimForward.LengthSquared()*delta.LengthSquared());
        if(!float.IsFinite(denominator))throw new InvalidDataException("Drone aim-angle overflow.");
        float angle=denominator<1e-15f?0:MathF.Acos(Math.Clamp(Vector3.Dot(playerAimForward,delta)/denominator,-1,1))*57.29578f;
        int mask=2;
        // Match source short-circuit order: random is tested before hiding state.
        if(angle<50)
        {
            float draw=random();if(!float.IsFinite(draw)||draw<0||draw>1)throw new InvalidDataException("Invalid Drone shield sample.");
            if(draw>shieldProbability&&hiding)mask=9;
        }
        return Nearest(origin,targets,mask);
    }
    public static Vector3 Predict(Vector3 muzzle,Vector3 target,Vector3 velocity,float effectiveBulletSpeed,float timeScale)
    {
        if(!Finite(muzzle)||!Finite(target)||!Finite(velocity)||!float.IsFinite(effectiveBulletSpeed)||effectiveBulletSpeed<=0||
           !float.IsFinite(timeScale)||timeScale<0||timeScale>10)
            throw new InvalidDataException("Invalid Drone prediction authority.");
        float time=Vector3.Distance(muzzle,target)/effectiveBulletSpeed+.1f;
        Vector3 predicted=target+time*timeScale*velocity;
        if(!float.IsFinite(time)||!Finite(predicted))throw new InvalidDataException("Drone prediction overflow.");
        return predicted;
    }
    private static DroneShotTarget? Nearest(Vector3 origin,IReadOnlyList<DroneShotTarget> targets,int mask)
    {
        DroneShotTarget? selected=null;float best=float.MaxValue;
        foreach(var row in targets)
        {
            if((row.Type&mask)!=row.Type)continue;
            float distance=Vector3.Distance(origin,row.Position);
            if(!float.IsFinite(distance))throw new InvalidDataException("Drone target distance overflow.");
            if(distance<best){best=distance;selected=row;}
        }
        return selected;
    }
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}
