using System.Numerics;

namespace War.BattleServer;

internal readonly record struct GroundVehicleAim(Vector3 Direction,float AngleDegrees,int AimTicks);

/// <summary>Recovered TurretWeaponBasic horizontal angle gate and tween duration.</summary>
internal static class GroundVehicleAimPolicy
{
    internal static GroundVehicleAim Resolve(Vector3 origin,Vector3 facing,Vector3 target,
        float maxShotRotation,float aimTime)
    {
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(facing)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(maxShotRotation)||maxShotRotation<=0||maxShotRotation>360||
           !float.IsFinite(aimTime)||aimTime<0||aimTime>30)
            throw new InvalidDataException("Invalid ground vehicle aim authority.");
        facing.Y=0;var direction=target-origin;direction.Y=0;
        if(facing.LengthSquared()<1e-10f||direction.LengthSquared()<1e-10f)
            throw new InvalidDataException("Ground vehicle aim has no planar direction.");
        facing=Vector3.Normalize(facing);direction=Vector3.Normalize(direction);
        float angle=MathF.Acos(Math.Clamp(Vector3.Dot(facing,direction),-1,1))*180/MathF.PI;
        if(!float.IsFinite(angle)||angle>maxShotRotation)
            throw new InvalidDataException("Ground vehicle target is outside turret rotation.");
        int ticks=angle<2.5f?0:(int)MathF.Ceiling(MathF.Max(aimTime*angle/360f,.1f)*MatchManifest.TickRate);
        return new(direction,angle,ticks);
    }
}
