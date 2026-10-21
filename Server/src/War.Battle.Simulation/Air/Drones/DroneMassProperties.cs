using System.Numerics;
namespace War.BattleServer;

internal sealed record DroneBodyMass(Vector3 CenterOfMass,Matrix4x4 Inertia);
internal static class DroneMassProperties
{
    internal static DroneBodyMass Compute(DroneColliderCatalog geometry)
    {
        var parts=geometry.Place(Vector3.Zero,Quaternion.Identity);
        var box=parts.Single(p=>p.Hitbox.Kind==PlayerHitboxKind.Box).Hitbox;
        var sphere=parts.Single(p=>p.Hitbox.Kind==PlayerHitboxKind.Sphere).Hitbox;
        float boxVolume=box.Size.X*box.Size.Y*box.Size.Z;
        float sphereVolume=(4f/3f)*MathF.PI*sphere.Radius*sphere.Radius*sphere.Radius;
        float boxMass=boxVolume/(boxVolume+sphereVolume),sphereMass=1-boxMass;
        var center=box.Center*boxMass+sphere.Center*sphereMass;
        var diagonal=new Vector3(boxMass*(box.Size.Y*box.Size.Y+box.Size.Z*box.Size.Z)/12,
            boxMass*(box.Size.X*box.Size.X+box.Size.Z*box.Size.Z)/12,
            boxMass*(box.Size.X*box.Size.X+box.Size.Y*box.Size.Y)/12)+
            new Vector3(.4f*sphereMass*sphere.Radius*sphere.Radius);
        var inertia=Matrix4x4.CreateScale(diagonal);
        void Offset(Vector3 delta,float mass)
        {
            inertia.M11+=mass*(delta.Y*delta.Y+delta.Z*delta.Z);
            inertia.M22+=mass*(delta.X*delta.X+delta.Z*delta.Z);
            inertia.M33+=mass*(delta.X*delta.X+delta.Y*delta.Y);
            inertia.M12-=mass*delta.X*delta.Y;inertia.M21=inertia.M12;
            inertia.M13-=mass*delta.X*delta.Z;inertia.M31=inertia.M13;
            inertia.M23-=mass*delta.Y*delta.Z;inertia.M32=inertia.M23;
        }
        Offset(box.Center-center,boxMass);Offset(sphere.Center-center,sphereMass);
        return new(center,inertia);
    }
}
