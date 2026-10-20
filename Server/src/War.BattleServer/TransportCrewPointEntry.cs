using System.Numerics;

namespace War.BattleServer;

/// <summary>Source hidden-state flags, animation choice and scaled controller deadlines for one crew arrival.</summary>
internal sealed class TransportCrewPointEntry
{
    private const float MinimumRepositionDelay = 2f;
    private const float RepositionDelayRange = 2f;
    private const float CornerTweenDurationSeconds = 0.5f;

    internal CoopInfantryPointState State { get; }

    internal float ControllerTime { get; }

    internal float NextShootTime { get; }

    internal float NextEnemyChangeTime { get; }

    internal float? NextRepositionTime { get; }

    internal bool IsAgentStopped => true;

    internal bool IsCrawling => State == CoopInfantryPointState.ObstacleHiding;

    internal bool IsHidingBehindCorner => State == CoopInfantryPointState.CornerHiding;

    internal string AnimationClip => IsCrawling ? "stand_up_crawl" : "idle_1";

    internal Vector3? CornerTweenPosition { get; }

    internal Vector3? CornerTweenLookDirection { get; }

    internal float? CornerTweenDuration => IsHidingBehindCorner ? CornerTweenDurationSeconds : null;

    internal TransportCrewPointEntry(EntryContext context, ArmyBaseShotStats shot, RandomDraws draws)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(shot);
        ArgumentNullException.ThrowIfNull(draws);
        Validate(context, shot, draws);
        State = context.Arrival.State;
        ControllerTime = context.ControllerTime;
        NextShootTime = Deadline(shot.MinShootTime + (shot.MaxShootTime - shot.MinShootTime) * draws.ShotFraction);
        NextEnemyChangeTime = Deadline(draws.PointChangeSeconds);
        if (IsCrawling)
        {
            NextRepositionTime = Deadline(MinimumRepositionDelay + RepositionDelayRange *
                draws.RepositionFraction.GetValueOrDefault());
        }
        else
        {
            // TweenPosition preserves the accepted soldier height, rather than the scene point's height.
            CornerTweenPosition = new Vector3(context.Point.Position.X, context.Arrival.ObservedPosition.Y,
                context.Point.Position.Z);
            CornerTweenLookDirection = -context.Point.CornerDirection.GetValueOrDefault();
        }
    }

    private float Deadline(float delay)
    {
        float deadline = ControllerTime + delay;
        if (!float.IsFinite(deadline) || deadline < ControllerTime || (delay > 0 && deadline == ControllerTime))
        {
            throw new InvalidDataException("Crew hidden-state deadline exceeds source float time resolution.");
        }
        return deadline;
    }

    private static void Validate(EntryContext context, ArmyBaseShotStats shot, RandomDraws draws)
    {
        bool obstacle = context.Arrival.State == CoopInfantryPointState.ObstacleHiding;
        string expectedType = obstacle ? "EnemyPointObstacle" : "EnemyPointCorner";
        if (!Enum.IsDefined(context.Arrival.State) || context.Point.ComponentType != expectedType ||
            context.Point.ComponentFileId != context.Arrival.PointComponentFileId ||
            !PlayerHitbox.Finite(context.Point.Position) || !PlayerHitbox.Finite(context.Arrival.ObservedPosition) ||
            !float.IsFinite(context.ControllerTime) || context.ControllerTime < 0 ||
            !float.IsFinite(shot.MinShootTime) || !float.IsFinite(shot.MaxShootTime) ||
            shot.MinShootTime < 0 || shot.MaxShootTime < shot.MinShootTime ||
            !IsFraction(draws.ShotFraction) || draws.PointChangeSeconds is < 10 or >= 20 ||
            (obstacle && (!draws.RepositionFraction.HasValue || !IsFraction(draws.RepositionFraction.Value))) ||
            (!obstacle && (draws.RepositionFraction.HasValue ||
                context.Point.CornerDirection is not Vector3 direction || !PlayerHitbox.Finite(direction) ||
                !float.IsFinite(direction.LengthSquared()) || direction.LengthSquared() == 0)))
        {
            throw new InvalidDataException("Crew hidden-state entry requires source point, timing and random draws.");
        }
    }

    private static bool IsFraction(float value)
    {
        return float.IsFinite(value) && value is >= 0 and <= 1;
    }

    internal sealed record EntryContext(CoopMatchRuntime.TransportCrewPointArrival Arrival,
        CoopEnemyPoint Point, float ControllerTime);

    internal sealed record RandomDraws(float ShotFraction, int PointChangeSeconds, float? RepositionFraction);
}
