using System.Numerics;

namespace War.BattleServer;

internal sealed record HelicopterTurretAimPose(bool Immediate,bool Clipped,float AimSeconds,
    Quaternion HorizontalLocalRotation,Quaternion VerticalWorldRotation,
    Vector3 SightPosition,Vector3 MuzzlePosition);

// Final transform expressions from TurretWeaponBasic.Aim and Helicopter.prefab.
// This describes a completed aim from the prefab's rest joints; it does not
// advance the Unity tween or authorize a shot before its completion.
internal static class HelicopterTurretAim
{
    private static readonly Vector3 ParentOffset=new(-.373f,-.209f,0);
    private static readonly Quaternion ParentLocalRotation=new(0,-.7071068f,0,.7071067f);
    private static readonly Vector3 HorizontalOffset=new(-.024999976f,.212f,-.025624692f);
    private static readonly Vector3 VerticalOffset=new(0,0,.008f);
    private static readonly Vector3 MuzzleOffset=new(-.0009999033f,.068f,.17699999f);
    private const float DegreesToRadians=MathF.PI/180f;

    internal static HelicopterTurretAimPose FromRest(Vector3 rootPosition,Quaternion rootRotation,
        Vector3 target)
    {
        if(!PlayerHitbox.Finite(rootPosition)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(rootRotation.LengthSquared())||
           Math.Abs(rootRotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Invalid Helicopter turret aim geometry.");
        var parentPosition=rootPosition+Vector3.Transform(ParentOffset,rootRotation);
        var parentRotation=Quaternion.Normalize(rootRotation*ParentLocalRotation);
        var direction=target-parentPosition;
        if(!PlayerHitbox.Finite(parentPosition)||!PlayerHitbox.Finite(direction)||
           direction.LengthSquared()<1e-10f)
            throw new InvalidDataException("Helicopter turret target is at its pivot.");

        var forward=Vector3.Transform(Vector3.UnitZ,parentRotation);
        var normalized=Vector3.Normalize(direction);
        float dot=Math.Clamp(Vector3.Dot(forward,normalized),-1f,1f);
        float angle=MathF.Acos(dot)/DegreesToRadians;
        bool immediate=angle<90f&&angle<2.5f;
        bool clipped=!immediate&&angle>90f&&angle<270f-90f;
        Quaternion yaw=Quaternion.Identity;
        Quaternion vertical=parentRotation;
        float seconds=0;
        if(!immediate)
        {
            var cross=Vector3.Cross(forward,normalized);
            if(cross.LengthSquared()<1e-10f)
                cross=Vector3.Transform(Vector3.UnitY,parentRotation);
            var axis=Vector3.Normalize(cross);
            float turnAngle=clipped?90f:angle;
            var turn=Quaternion.CreateFromAxisAngle(axis,turnAngle*DegreesToRadians);
            // Unity Quaternion.eulerAngles.y on the FromToRotation result,
            // then Quaternion.AngleAxis(yaw, Vector3.up) for the horizontal joint.
            float yawRadians=MathF.Atan2(2f*(turn.W*turn.Y+turn.X*turn.Z),
                1f-2f*(turn.X*turn.X+turn.Y*turn.Y));
            yaw=Quaternion.CreateFromAxisAngle(Vector3.UnitY,yawRadians);
            float yawDegrees=2f*MathF.Acos(Math.Clamp(MathF.Abs(yaw.W),0f,1f))/DegreesToRadians;
            seconds=MathF.Max(yawDegrees/360f,.1f);
            vertical=HelicopterOrientationState.LookRotation(direction);
        }
        var horizontalRotation=Quaternion.Normalize(parentRotation*yaw);
        var pivot=parentPosition+Vector3.Transform(HorizontalOffset,parentRotation);
        var sight=pivot+Vector3.Transform(VerticalOffset,horizontalRotation);
        var muzzle=sight+Vector3.Transform(MuzzleOffset,vertical);
        if(!PlayerHitbox.Finite(sight)||!PlayerHitbox.Finite(muzzle)||
           !float.IsFinite(vertical.LengthSquared())||!float.IsFinite(yaw.LengthSquared()))
            throw new InvalidDataException("Helicopter turret aim pose overflow.");
        return new(immediate,clipped,seconds,yaw,vertical,sight,muzzle);
    }
}
