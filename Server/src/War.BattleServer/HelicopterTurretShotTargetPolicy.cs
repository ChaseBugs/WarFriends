using System.Numerics;

namespace War.BattleServer;

// TurretWeaponBasic.Fire chooses a different player mask while walking.
// This is intentionally distinct from DroneShotTargetPolicy.Select.
internal static class HelicopterTurretShotTargetPolicy
{
    internal static DroneShotTarget? Select(Vector3 turretPosition,DroneTargetDetails details,
        float shieldProbability,Func<float> random)
    {
        if(!PlayerHitbox.Finite(turretPosition)||details==null||details.Targets==null||
           details.Targets.Count is <1 or >100||!PlayerHitbox.Finite(details.Root)||
           !PlayerHitbox.Finite(details.AimForward)||!float.IsFinite(shieldProbability)||
           shieldProbability is < -1 or >1||random==null)
            throw new InvalidDataException("Invalid Helicopter turret target authority.");
        var ids=new HashSet<int>();
        foreach(var target in details.Targets)
            if(target==null||target.TransformFileId<=0||!ids.Add(target.TransformFileId)||
               target.Type is <0 or >0xFFFFFF||!PlayerHitbox.Finite(target.Position))
                throw new InvalidDataException("Invalid Helicopter turret shot target.");
        int mask=0xFFFFFB;
        if(details.IsPlayer)
        {
            if(shieldProbability<0)return null;
            Vector3 toward=turretPosition-details.Root;
            float denominator=MathF.Sqrt(details.AimForward.LengthSquared()*toward.LengthSquared());
            if(!float.IsFinite(denominator))
                throw new InvalidDataException("Helicopter turret player angle overflow.");
            float angle=denominator<1e-15f?0:MathF.Acos(Math.Clamp(
                Vector3.Dot(details.AimForward,toward)/denominator,-1,1))*180/MathF.PI;
            bool wholeBody=false;
            if(angle<=50&&details.Hiding)
            {
                float draw=random();
                if(!float.IsFinite(draw)||draw is <0 or >1)
                    throw new InvalidDataException("Invalid Helicopter turret shield sample.");
                wholeBody=!(draw<shieldProbability);
            }
            mask=wholeBody?9:details.Hiding?2:16;
        }
        DroneShotTarget? selected=null;float best=float.MaxValue;
        foreach(var target in details.Targets)
        {
            if((target.Type&mask)!=target.Type)continue;
            float distance=Vector3.Distance(turretPosition,target.Position);
            if(!float.IsFinite(distance))
                throw new InvalidDataException("Helicopter turret target distance overflow.");
            if(distance<best){best=distance;selected=target;}
        }
        return selected;
    }
}
