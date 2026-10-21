using System.Collections.ObjectModel;
using System.Numerics;

namespace War.BattleServer;

public sealed class PlayerAimPose
{
    private static readonly IReadOnlyDictionary<int, Vector3> EmptyTargetPositions =
        new ReadOnlyDictionary<int, Vector3>(new Dictionary<int, Vector3>());
    private readonly Dictionary<string, RifleMuzzlePose> _muzzles;
    private readonly PlayerAimPoseDetails _details;
    private readonly IReadOnlyDictionary<int, Vector3> _targetPositions;

    public PlayerCollisionModel Collision { get; }
    public RifleMuzzlePose? MovingTarget => _details.MovingTarget;

    internal PlayerAimPose(
        PlayerCollisionModel collision,
        Dictionary<string, RifleMuzzlePose> muzzles,
        PlayerAimPoseDetails? details = null,
        IReadOnlyDictionary<int, Vector3>? targetPositions = null)
    {
        Collision = collision;
        _muzzles = muzzles;
        _details = details ?? new PlayerAimPoseDetails(
            null, new Dictionary<int, RifleMuzzlePose>(), null);
        _targetPositions = targetPositions?.ToDictionary(pair => pair.Key, pair => pair.Value)
            ?? EmptyTargetPositions;
        if (_targetPositions.Any(pair => pair.Key <= 0 || !PlayerHitbox.Finite(pair.Value)))
        {
            throw new InvalidDataException("Invalid position-only player target authority.");
        }
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

    /// <summary>Reads an animated target position without asserting an unrecovered target rotation.</summary>
    public Vector3 BodyTargetPosition(int transformFileId)
    {
        if (_targetPositions.TryGetValue(transformFileId, out Vector3 position))
        {
            return position;
        }

        return BodyTarget(transformFileId).Position;
    }

    public PlayerAimPose Place(Vector3 position, Quaternion rotation)
    {
        PlayerCollisionModel placedCollision = Collision.Place(position, rotation);
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

        Quaternion delta = Quaternion.Normalize(rotation * Quaternion.Inverse(Collision.RootRotation));
        var placedTargets = _targetPositions.Count == 0 ? null : _targetPositions.ToDictionary(pair => pair.Key,
            pair => position + Vector3.Transform(pair.Value - Collision.RootPosition, delta));
        return new PlayerAimPose(placedCollision, placedMuzzles, placedDetails, placedTargets);
    }
}
