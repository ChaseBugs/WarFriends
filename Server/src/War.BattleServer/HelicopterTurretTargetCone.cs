using System.Numerics;

namespace War.BattleServer;

// Helicopter prefab TurretWeaponBasic 11498443: turretParent 439132 has
// root-relative position (-.373,-.209,0) and a -90-degree Y rotation.
// Both visibility branches use PickRandom's strict ComputeAngle < 90 gate.
internal static class HelicopterTurretTargetCone
{
    private static readonly Vector3 OriginOffset=new(-.373f,-.209f,0);
    private static readonly Quaternion ParentRotation=new(0,-.7071068f,0,.7071067f);
    internal static bool Contains(Vector3 rootPosition,Quaternion rootRotation,Vector3 target)
    {
        if(!PlayerHitbox.Finite(rootPosition)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(rootRotation.LengthSquared())||Math.Abs(rootRotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Invalid Helicopter turret target geometry.");
        var origin=rootPosition+Vector3.Transform(OriginOffset,rootRotation);
        var direction=target-origin;
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(direction)||direction.LengthSquared()<1e-10f)
            return false;
        // Keep the serialized parent's rotation, pitch/bank and vertical target
        // displacement. jointVertical exists, so ComputeAngle does not flatten Y.
        var forward=Vector3.Transform(Vector3.Transform(Vector3.UnitZ,ParentRotation),rootRotation);
        float cosine=Vector3.Dot(Vector3.Normalize(forward),Vector3.Normalize(direction));
        float angle=MathF.Acos(Math.Clamp(cosine,-1,1))*180f/MathF.PI;
        return angle<90f;
    }
}
