using System.Numerics;
namespace War.BattleServer;

// Conservative broadphase candidate only. Rounded contact manifolds and solver
// response must confirm this before it can authorize DroneDeathState collision.
internal static class DroneMapContactCandidate
{
    internal static bool Query(RecoveredBattleMap map,DroneColliderCatalog geometry,
        Vector3 position,Quaternion rotation,uint rootMask,uint childMask,float contactMargin)
    {
        ArgumentNullException.ThrowIfNull(map);ArgumentNullException.ThrowIfNull(geometry);
        if(!float.IsFinite(contactMargin)||contactMargin<0||contactMargin>.1f)
            throw new InvalidDataException("Invalid Drone contact margin.");
        foreach(var collider in geometry.Place(position,rotation))
        {
            var shape=collider.Hitbox;
            if(shape.Kind==PlayerHitboxKind.Box&&map.BoxOverlaps(shape.Center,
                shape.Size+new Vector3(contactMargin*2),shape.Rotation,rootMask))return true;
            if(shape.Kind==PlayerHitboxKind.Sphere&&map.SphereOverlaps(shape.Center,
                shape.Radius+contactMargin,childMask))return true;
        }
        return false;
    }
}
