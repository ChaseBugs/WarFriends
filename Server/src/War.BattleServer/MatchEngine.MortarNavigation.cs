using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float MortarArrivalDistance = 0.04f;
    private readonly MortarPointCatalog? _mortarPointCatalog;
    private readonly Dictionary<ulong, MortarPoint> _mortarPoints = [];
    private readonly Dictionary<int, ulong> _mortarOccupants = [];
    private readonly Dictionary<ulong, MortarWalk> _mortarWalks = [];
    private readonly Dictionary<ulong, float> _mortarBuildSeconds = [];
    private readonly Dictionary<ulong, MortarConstructionState> _mortarConstruction = [];

    /// <summary>Reads the soldier's exclusive source-authored destination.</summary>
    internal MortarPoint? MortarDestination(ulong entityKey)
    {
        return _mortarPoints.GetValueOrDefault(entityKey);
    }

    /// <summary>Reads the exclusive destination owner used by movement and death cleanup.</summary>
    internal ulong? MortarDestinationOccupant(int componentFileId)
    {
        return _mortarOccupants.TryGetValue(componentFileId, out ulong occupant) ? occupant : null;
    }

    /// <summary>Reads construction timing after natural navigation reaches the authored point.</summary>
    internal MortarConstructionState? MortarConstruction(ulong entityKey)
    {
        return _mortarConstruction.GetValueOrDefault(entityKey);
    }

    private (string Clip, ulong StartTick)? MortarConstructionPose(ulong entityKey)
    {
        if (!_mortarConstruction.TryGetValue(entityKey, out var state) || enemyPoses == null)
        {
            return null;
        }

        // BuildMortar plays mortar_down immediately, then queues mortar_down_idle.
        float downSeconds = enemyPoses.Clip("mortar_down").Length;
        float elapsedSeconds = (tick - state.EnteredTick) / (float)MatchManifest.TickRate;
        if (elapsedSeconds < downSeconds)
        {
            return ("mortar_down", state.EnteredTick);
        }

        ulong downTicks = (ulong)MathF.Round(downSeconds * MatchManifest.TickRate);
        return ("mortar_down_idle", checked(state.EnteredTick + downTicks));
    }

    private void InitializeMortarNavigation(ulong entityKey)
    {
        var entity = activeArmyEntities[entityKey];
        MortarPointCatalog catalog = _mortarPointCatalog ??
            throw new InvalidDataException("Ordinary Mortar lacks source destinations.");
        if (entity.UnitId != "ID_UNIT-MORTAR" || entity.SourceCardId.Length != 0 ||
            !_mortarBuildSeconds.ContainsKey(entityKey))
        {
            throw new InvalidDataException("Ordinary Mortar navigation lost its source setup.");
        }

        Vector3 position = new(entity.X, entity.Y, entity.Z);
        MortarPoint point = catalog.ForMap(map!).Where(candidate =>
            candidate.Fraction == entity.OwnerFraction && !_mortarOccupants.ContainsKey(candidate.ComponentFileId))
            .OrderBy(candidate => Vector3.Distance(position, candidate.Position)).ThenBy(candidate => candidate.Order)
            .FirstOrDefault() ?? throw new InvalidDataException("Mortar point capacity disagrees with source limits.");
        // There are four exclusive destinations per fraction and at most two ordinary Mortars.
        // No other currently supported spawn owns this point mask; exhaustion is damaged authority.
        ArmyNavMeshCorridor route = PlanMortarRoute(position, point);
        float speed = ArmySpeed(entityKey) ?? armyCatalog!.EffectiveSpeed(entity.UnitId, 1f);
        var motion = new CardSoldierWalkState(point.ComponentFileId, route, armyCatalog!.InfantryAgent, speed);
        _mortarOccupants.Add(point.ComponentFileId, entityKey);
        _mortarPoints.Add(entityKey, point);
        _mortarWalks.Add(entityKey, new MortarWalk(motion, checked(tick + 1)));
    }

    private ArmyNavMeshCorridor PlanMortarRoute(Vector3 position, MortarPoint destination)
    {
        if (map == null || armyNavMeshConnectivity == null)
        {
            throw new InvalidDataException("Ordinary Mortar lacks source navigation geometry.");
        }

        Vector3 start = armyNavMeshConnectivity.SampleNearest(map, position, 1.25f) ??
            throw new InvalidDataException("Mortar spawn lies outside its source NavMesh.");
        // Native Unity sampling preserves X/Z for all forty authored Mortar destinations.
        // Closest Euclidean projection onto a slope can shift X/Z beyond IsEnemyPointReached's 4cm limit.
        // The native detail-mesh height also differs slightly from exported coarse triangles.
        // Use the verified native sample rather than claim triangulation supplies exact Unity height.
        Vector3 end = destination.NavMeshPosition;
        ArmyNavMeshCorridor route = armyNavMeshConnectivity.PlanCorridor(map, start, end) ??
            throw new InvalidDataException("Mortar has no connected source navigation route.");
        return route.PlanarCovered ? route :
            throw new InvalidDataException("Mortar route leaves source navigation geometry.");
    }

    private void AdvanceMortarNavigation()
    {
        foreach (var (entityKey, walk) in _mortarWalks.OrderBy(row => row.Key).ToArray())
        {
            if (tick >= walk.FirstTick)
            {
                AdvanceMortarWalk(entityKey, walk.Motion);
            }
        }
    }

    private void AdvanceMortarWalk(ulong entityKey, CardSoldierWalkState motion)
    {
        var entity = activeArmyEntities[entityKey];
        MortarPoint point = _mortarPoints[entityKey];
        if (point.ComponentFileId != motion.PointFileId ||
            _mortarOccupants.GetValueOrDefault(point.ComponentFileId) != entityKey)
        {
            throw new InvalidDataException("Mortar navigation lost its exclusive destination.");
        }

        motion.AdvanceToRouteEndTick();
        entity.X = motion.Position.X;
        entity.Y = motion.Position.Y;
        entity.Z = motion.Position.Z;
        entity.PositionTick = tick;
        if (Vector2.Distance(new(entity.X, entity.Z), new(point.Position.X, point.Position.Z)) < MortarArrivalDistance)
        {
            _mortarWalks.Remove(entityKey);
            ulong buildTicks = (ulong)MathF.Floor(_mortarBuildSeconds[entityKey] * MatchManifest.TickRate);
            _mortarConstruction.Add(entityKey, new MortarConstructionState(tick, checked(tick + buildTicks + 1)));
            BeginMortarFacing(entityKey, motion.Facing ?? infantryAnimations[entityKey].Facing);
        }
    }

    private void RemoveMortarNavigation(ulong entityKey)
    {
        if (_mortarPoints.Remove(entityKey, out var point) &&
            (!_mortarOccupants.Remove(point.ComponentFileId, out ulong occupant) || occupant != entityKey))
        {
            throw new InvalidDataException("Mortar death lost its destination reservation.");
        }

        _mortarWalks.Remove(entityKey);
        _mortarBuildSeconds.Remove(entityKey);
        _mortarConstruction.Remove(entityKey);
        _mortarFacings.Remove(entityKey);
    }

    private sealed record MortarWalk(CardSoldierWalkState Motion, ulong FirstTick);
}
