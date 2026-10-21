using System.Numerics;

namespace War.BattleServer;

internal readonly record struct HelicopterSightRay(Vector3 Origin,Vector3 Direction,float Range,uint LayerMask);

// AIObject.CanSeeTargetStatic: PickRandom supplies .05, TurretSeesEnemy
// uses the .25 default. The target's near half-unit is excluded from the ray.
internal static class HelicopterTurretSightRay
{
    internal const uint SourceLayerMask=(1u<<8)|(1u<<13)|(1u<<22)|(1u<<23)|
        (1u<<24)|(1u<<26)|(1u<<27)|(1u<<30);
    internal static HelicopterSightRay ForSelection(Vector3 eye,Vector3 target)
        =>Create(eye,target,.05f);
    internal static HelicopterSightRay ForAimedShot(Vector3 eye,Vector3 target)
        =>Create(eye,target,.25f);
    private static HelicopterSightRay Create(Vector3 eye,Vector3 target,float offset)
    {
        if(!PlayerHitbox.Finite(eye)||!PlayerHitbox.Finite(target))
            throw new InvalidDataException("Invalid Helicopter turret sight endpoints.");
        var delta=target-eye;
        float distance=delta.Length();
        if(!float.IsFinite(distance))
            throw new InvalidDataException("Helicopter turret sight distance overflow.");
        var direction=distance>1e-5f?delta/distance:Vector3.Zero;
        var origin=eye+direction*offset;
        float range=MathF.Max(.1f,Vector3.Distance(origin,target)-.5f);
        if(!PlayerHitbox.Finite(origin)||!float.IsFinite(range))
            throw new InvalidDataException("Helicopter turret sight ray overflow.");
        return new(origin,direction,range,SourceLayerMask);
    }
}
