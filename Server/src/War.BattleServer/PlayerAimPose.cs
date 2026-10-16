using System.Numerics;

namespace War.BattleServer;

internal sealed record AimBone(string Path,Vector3 Position,Quaternion Rotation,Quaternion ParentRotation)
{
    internal (Vector3 Position,Quaternion Rotation) Apply(string path,Vector3 position,Quaternion rotation,Quaternion localOverride)
    {
        if (path!=Path && !path.StartsWith(Path+"/",StringComparison.Ordinal)) return (position,rotation);
        var delta=Quaternion.Normalize(ParentRotation*localOverride*Quaternion.Inverse(Rotation));
        return (Position+Vector3.Transform(position-Position,delta),Quaternion.Normalize(delta*rotation));
    }
}

internal sealed record WeaponRootPoseSource(
    RigWorldTransform[] Rig,
    IReadOnlyDictionary<string, (int Node, string Path)> Bindings,
    Vector3? PlacedPosition = null,
    Quaternion? PlacedRotation = null);

internal sealed record PlayerAimPoseDetails(
    RifleMuzzlePose? MovingTarget,
    IReadOnlyDictionary<int, RifleMuzzlePose> BodyTargets,
    WeaponRootPoseSource? WeaponRoots);

public sealed class PlayerAimPose
{
    private readonly Dictionary<string, RifleMuzzlePose> _muzzles;
    private readonly PlayerAimPoseDetails _details;

    public PlayerCollisionModel Collision { get; }
    public RifleMuzzlePose? MovingTarget => _details.MovingTarget;

    internal PlayerAimPose(
        PlayerCollisionModel collision,
        Dictionary<string, RifleMuzzlePose> muzzles,
        PlayerAimPoseDetails? details = null)
    {
        Collision = collision;
        _muzzles = muzzles;
        _details = details ?? new PlayerAimPoseDetails(
            null, new Dictionary<int, RifleMuzzlePose>(), null);
    }

    public RifleMuzzlePose Muzzle(string rifle)
    {
        return _muzzles.TryGetValue(rifle, out var value)
            ? value
            : throw new InvalidDataException("Unknown aimed rifle.");
    }

    internal RifleMuzzlePose WeaponRoot(string weaponId)
    {
        WeaponRootPoseSource? source = _details.WeaponRoots;
        if (source == null || !source.Bindings.TryGetValue(weaponId, out var binding))
        {
            throw new InvalidDataException("Unknown posed weapon root.");
        }

        RigWorldTransform node = source.Rig[binding.Node];
        RigWorldTransform root = source.Rig[0];
        var weapon = new RifleMuzzlePose(binding.Path, node.Position, node.Rotation,
            root.Position, root.Rotation);
        return source.PlacedPosition.HasValue && source.PlacedRotation.HasValue
            ? weapon.Place(source.PlacedPosition.Value, source.PlacedRotation.Value)
            : weapon;
    }

    public RifleMuzzlePose BodyTarget(int transformFileId)
    {
        return _details.BodyTargets.TryGetValue(transformFileId, out var value)
            ? value
            : throw new InvalidDataException("Unknown posed Body target.");
    }

    public PlayerAimPose Place(Vector3 position, Quaternion rotation)
    {
        var placedMuzzles = _muzzles.ToDictionary(
            pair => pair.Key,
            pair => pair.Value.Place(position, rotation),
            StringComparer.Ordinal);
        var placedBodies = _details.BodyTargets.ToDictionary(
            pair => pair.Key,
            pair => pair.Value.Place(position, rotation));
        WeaponRootPoseSource? placedRoots = null;
        if (_details.WeaponRoots is { } weaponRoots)
        {
            placedRoots = weaponRoots with
            {
                PlacedPosition = position,
                PlacedRotation = rotation
            };
        }

        var placedDetails = new PlayerAimPoseDetails(
            MovingTarget?.Place(position, rotation),
            placedBodies,
            placedRoots);

        return new PlayerAimPose(Collision.Place(position, rotation),
            placedMuzzles, placedDetails);
    }
}
