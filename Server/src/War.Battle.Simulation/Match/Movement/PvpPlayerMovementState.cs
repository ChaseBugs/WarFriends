using System.Numerics;

namespace War.BattleServer;

/// <summary>Owns a player's physical cover, private route, progress and observed frame velocity.</summary>
internal sealed class PvpPlayerMovementState
{
    private const ulong DestinationDelayTicks = 1;

    private RecoveredBattleMap? _map;
    private Vector3[]? _route;
    private float _routeLength;
    private float _routeTravelled;
    private ulong _moveStart;
    private ulong _lastMoveTick;

    internal int Cover { get; private set; } = -1;
    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; private set; }
    internal int Destination { get; private set; }
    internal ulong MoveEnd { get; private set; }
    internal bool IsMoving => _route != null;

    internal void InitializeCover(RecoveredBattleMap map, int cover)
    {
        // Match allocation validates the map, side and allowed starting cover before this commit.
        if (_map != null)
        {
            throw new InvalidOperationException("Player movement is already bound to its recovered map.");
        }
        _map = map;
        Cover = cover;
        Position = map.Covers[cover].Position;
    }

    internal void BeginRoute(int destination, ulong tick, float speed)
    {
        // Path returns a private copy. Neither the engine nor projection consumers receive this array.
        Vector3[] route = _map!.Path(Cover, destination);
        float length = 0;
        for (int index = 1; index < route.Length; index++)
        {
            length += Vector3.Distance(route[index - 1], route[index]);
        }

        _route = route;
        _routeLength = length;
        _routeTravelled = 0;
        Destination = destination;
        // PlayerController.GoTo defaults to a deferred 0.02-second destination. Keep one host tick.
        _moveStart = tick + DestinationDelayTicks;
        _lastMoveTick = _moveStart;
        MoveEnd = _moveStart + Math.Max(1, Ticks(length / speed));
    }

    internal bool CanAdvanceAt(ulong tick)
    {
        return _route != null && tick > _moveStart && tick > _lastMoveTick;
    }

    internal void AdvanceRoute(ulong tick, float speed)
    {
        if (!CanAdvanceAt(tick))
        {
            return;
        }

        ulong elapsedTicks = tick - _lastMoveTick;
        // Preserve binary32 evaluation order, including the speed multiplication after division.
        float distanceStep = (float)elapsedTicks / MatchManifest.TickRate * speed;
        _routeTravelled = Math.Min(_routeLength, _routeTravelled + distanceStep);
        _lastMoveTick = tick;
        if (_routeTravelled >= _routeLength || tick >= MoveEnd)
        {
            Cover = Destination;
            Position = _map!.Covers[Cover].Position;
            _route = null;
            return;
        }

        Position = SampleRoute(_routeTravelled);
    }

    internal void ObserveFrameVelocity(Vector3 previousPosition)
    {
        // GameShootableEntity.velocity uses the last frame's position delta. This is deliberately
        // not divided by skipped ticks: soldier/turret prediction consumes the observed frame delta.
        Velocity = (Position - previousPosition) * MatchManifest.TickRate;
    }

    internal void RecalculateDeadline(ulong tick, float speed)
    {
        if (_route == null)
        {
            return;
        }

        float remainingDistance = Math.Max(0, _routeLength - _routeTravelled);
        ulong fromTick = Math.Max(tick, _moveStart);
        MoveEnd = checked(fromTick + Math.Max(1, Ticks(remainingDistance / speed)));
    }

    internal void CancelRoute()
    {
        // Death cancels traversal without inventing a new cover or clearing the last observed velocity.
        _route = null;
    }

    private Vector3 SampleRoute(float travelled)
    {
        Vector3[] route = _route!;
        for (int index = 1; index < route.Length; index++)
        {
            float segment = Vector3.Distance(route[index - 1], route[index]);
            if (travelled <= segment && segment > 0)
            {
                return Vector3.Lerp(route[index - 1], route[index], travelled / segment);
            }
            travelled -= segment;
        }
        return route[^1];
    }

    private static ulong Ticks(double seconds)
    {
        return checked((ulong)Math.Ceiling(seconds * MatchManifest.TickRate));
    }
}
