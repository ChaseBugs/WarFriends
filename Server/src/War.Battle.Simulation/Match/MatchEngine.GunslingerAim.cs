using System.Numerics;

namespace War.BattleServer;

internal sealed record GunslingerPreparedAim(ulong ActorEntityKey, ulong AcquisitionTick,
    AssaulterShotTarget Target, GunslingerAimPrediction? MovingPrediction)
{
    internal Vector3 TargetPosition => MovingPrediction?.TargetPosition ?? Target.TransformPosition;
}

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, GunslingerWeaponAimState> _gunslingerAimWeapons = [];

    /// <summary>Reads the actor's mutable source speed, separately from immutable shared catalog data.</summary>
    internal GunslingerWeaponAimState? GunslingerAimWeapon(ulong entityKey)
    {
        return _gunslingerAimWeapons.GetValueOrDefault(entityKey);
    }

    /// <summary>Captures source target-selection aim before the later stand callback resamples its target.</summary>
    internal GunslingerPreparedAim? CaptureGunslingerAim(ulong entityKey)
    {
        AssaulterShotTarget? target = SelectGunslingerShotTarget(entityKey);
        if (target == null)
        {
            return null;
        }

        GunslingerWeaponAimState weapon = GunslingerAimWeapon(entityKey) ??
            throw new InvalidDataException("Gunslinger target capture lost its trusted weapon speed.");
        GunslingerAimPrediction? prediction = null;
        if (target.IsPlayer && target.ShotTargetType == AssaulterMovingMask)
        {
            Player player = Find(target.OwnerPlayerId) ??
                throw new InvalidDataException("Gunslinger moving aim lost its selected player.");
            prediction = weapon.SelectMovingPlayer(StationarySoldierAcquisitionMuzzle(entityKey),
                target.TransformPosition, HeavyTurretPlayerVelocity(player));
        }

        return new GunslingerPreparedAim(entityKey, tick, target, prediction);
    }
}
