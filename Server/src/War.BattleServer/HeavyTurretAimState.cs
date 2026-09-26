using System.Numerics;

namespace War.BattleServer;

// TurretWeaponBasic.Aim for the source-pinned HeavyTurret prefab: root,
// horizontal parent and initial horizontal rotations are identity, aimTime=1,
// maxShotRotation=360, and jointVertical exists. Placement changes position only.
internal sealed class HeavyTurretAimState
{
    private float yaw,pendingYaw;
    private Quaternion vertical=Quaternion.Identity,pendingVertical=Quaternion.Identity;
    internal int Plan(Vector3 origin,Vector3 target)
    {
        var direction=target-origin;
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(target)||direction.LengthSquared()<1e-10f)
            throw new InvalidDataException("Invalid Heavy Turret aim geometry.");
        direction=Vector3.Normalize(direction);
        var forward=new Vector3(MathF.Sin(yaw),0,MathF.Cos(yaw));
        float currentAngle=MathF.Acos(Math.Clamp(Vector3.Dot(forward,direction),-1,1))*180/MathF.PI;
        pendingYaw=MathF.Atan2(direction.X,direction.Z);
        if(currentAngle<2.5f){pendingYaw=yaw;pendingVertical=vertical;return 0;}
        pendingVertical=Quaternion.CreateFromYawPitchRoll(pendingYaw,-MathF.Asin(Math.Clamp(direction.Y,-1,1)),0);
        // Quaternion.Angle between horizontal local rotations follows the
        // shortest arc; vertical pitch does not extend the horizontal callback.
        float delta=MathF.Abs(MathF.IEEERemainder(pendingYaw-yaw,2*MathF.PI));
        float seconds=Math.Max(delta/(2*MathF.PI),.1f);
        return (int)MathF.Ceiling(seconds*MatchManifest.TickRate);
    }
    internal void Complete(){yaw=pendingYaw;vertical=pendingVertical;}
    internal Vector3 MuzzleOffset(HeavyTurretSourceCatalog source)=>SightOffset(source)+source.WorldShotOffset;
    internal Vector3 SightOffset(HeavyTurretSourceCatalog source)=>Offset(source,source.SpawnOffset);
    private Vector3 Offset(HeavyTurretSourceCatalog source,Vector3 point)
    {
        var horizontal=Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw);
        var pivot=source.HorizontalPivot+Vector3.Transform(source.VerticalPivot-source.HorizontalPivot,horizontal);
        return pivot+Vector3.Transform(point-source.VerticalPivot,vertical);
    }
}
