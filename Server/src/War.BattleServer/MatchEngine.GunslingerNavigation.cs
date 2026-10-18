using System.Numerics;

namespace War.BattleServer;

internal sealed record GunslingerArrival(ulong EnteredTick, int? ShotsRemaining,
    ulong? FirstShotEligibleTick, ulong FirstPointChangeEligibleTick);

public sealed partial class MatchEngine
{
    private const ulong GunslingerPointRetryTicks = 5 * MatchManifest.TickRate;
    private const float GunslingerArrivalDistance = 0.04f;
    private readonly GunslingerPointCatalog? _gunslingerPointCatalog;
    private readonly Dictionary<ulong, GunslingerPoint> _gunslingerPoints = [];
    private readonly Dictionary<int, ulong> _gunslingerOccupants = [];
    private readonly Dictionary<ulong, GunslingerWalk> _gunslingerWalks = [];
    private readonly Dictionary<ulong, ulong> _gunslingerRetries = [];
    private readonly Dictionary<ulong, GunslingerArrival> _gunslingerArrivals = [];

    /// <summary>Reads the ordinary soldier's source destination without claiming completed shooting.</summary>
    internal GunslingerPoint? GunslingerPoint(ulong entityKey)
    {
        return _gunslingerPoints.GetValueOrDefault(entityKey);
    }

    /// <summary>Reads source arrival counters; the attack executor remains a separate integration.</summary>
    internal GunslingerArrival? GunslingerState(ulong entityKey)
    {
        return _gunslingerArrivals.GetValueOrDefault(entityKey);
    }

    private void InitializeGunslingerNavigation(ulong entityKey)
    {
        var entity = activeArmyEntities[entityKey];
        GunslingerPointCatalog catalog = _gunslingerPointCatalog ??
            throw new InvalidDataException("Normal Gunslinger lost its source point catalog.");
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        GunslingerPoint? point = catalog.ForMap(map!).Where(candidate =>
            candidate.Fraction == entity.OwnerFraction && !_gunslingerOccupants.ContainsKey(candidate.ComponentFileId))
            .OrderBy(candidate => Vector3.Distance(position, candidate.Position)).ThenBy(candidate => candidate.Order)
            .FirstOrDefault();
        if (point == null)
        {
            _gunslingerRetries[entityKey] = checked(tick + GunslingerPointRetryTicks);
            return;
        }

        ArmyNavMeshCorridor route = PlanCardSoldierRoute(position, point.Position);
        float speed = ArmySpeed(entityKey) ?? armyCatalog!.EffectiveSpeed(entity.UnitId, 1f);
        var motion = new CardSoldierWalkState(point.ComponentFileId, route, armyCatalog!.InfantryAgent, speed);
        _gunslingerOccupants.Add(point.ComponentFileId, entityKey);
        _gunslingerPoints.Add(entityKey, point);
        _gunslingerWalks.Add(entityKey, new GunslingerWalk(motion, checked(tick + 1)));
        _gunslingerRetries.Remove(entityKey);
    }

    private void AdvanceGunslingerNavigation()
    {
        foreach (var (entityKey, due) in _gunslingerRetries.OrderBy(row => row.Key).ToArray())
        {
            if (tick >= due)
            {
                InitializeGunslingerNavigation(entityKey);
            }
        }

        foreach (var (entityKey, walk) in _gunslingerWalks.OrderBy(row => row.Key).ToArray())
        {
            if (tick >= walk.FirstTick)
            {
                AdvanceGunslingerWalk(entityKey, walk.Motion);
            }
        }
    }

    private void AdvanceGunslingerWalk(ulong entityKey, CardSoldierWalkState motion)
    {
        var entity = activeArmyEntities[entityKey];
        GunslingerPoint point = _gunslingerPoints[entityKey];
        if (point.ComponentFileId != motion.PointFileId ||
            _gunslingerOccupants.GetValueOrDefault(point.ComponentFileId) != entityKey)
        {
            throw new InvalidDataException("Gunslinger route lost its source reservation.");
        }

        // SetFinalTarget uses stoppingDistance zero. The route's approximate arrival
        // flag must not stop a soldier outside EnemyPoint's strict authored-point test.
        motion.AdvanceToRouteEndTick();
        entity.X = motion.Position.X;
        entity.Y = motion.Position.Y;
        entity.Z = motion.Position.Z;
        entity.PositionTick = tick;
        if (Vector2.Distance(new(entity.X, entity.Z),
            new(point.Position.X, point.Position.Z)) < GunslingerArrivalDistance)
        {
            _gunslingerWalks.Remove(entityKey);
            EnterGunslingerState(entityKey);
        }
    }

    private void EnterGunslingerState(ulong entityKey)
    {
        float fraction = NextArmyFloat();
        if (!float.IsFinite(fraction) || fraction is < 0f or >= 1f)
        {
            throw new InvalidDataException("Gunslinger position-change draw lost source bounds.");
        }

        int? remainingShots = armyShots.TryGetValue(entityKey, out ArmyBaseShotStats? shot)
            ? shot.FireBatchSizeMax : null;
        // SwitchStateToGunslinger uses the maximum batch as its remaining attempts,
        // starts its strict shot clock now and draws Random.Range(2f, 4f) for moving again.
        ulong changeTick = checked(tick + (ulong)MathF.Floor((2f + fraction * 2f) * MatchManifest.TickRate) + 1);
        _gunslingerArrivals.Add(entityKey, new GunslingerArrival(tick,
            remainingShots, remainingShots.HasValue ? checked(tick + 1) : null, changeTick));
    }

    private void RemoveGunslingerNavigation(ulong entityKey)
    {
        if (_gunslingerPoints.Remove(entityKey, out var point) &&
            (!_gunslingerOccupants.Remove(point.ComponentFileId, out ulong occupant) || occupant != entityKey))
        {
            throw new InvalidDataException("Gunslinger death lost its destination owner.");
        }

        _gunslingerWalks.Remove(entityKey);
        _gunslingerRetries.Remove(entityKey);
        _gunslingerArrivals.Remove(entityKey);
        _gunslingerAimWeapons.Remove(entityKey);
    }

    private sealed record GunslingerWalk(CardSoldierWalkState Motion, ulong FirstTick);
}
