using System.Numerics;

namespace War.BattleServer;

/// <summary>One observed descent step bound to the same live rope generation and render publication.</summary>
internal sealed record HelicopterCrewDescentObservation(
    HelicopterDescentFrame Pose, HelicopterPhysicsWorldSnapshot Physics, float DeltaTime);

/// <summary>Owns descent progress without inferring animation phase, visibility, landing or combat authority.</summary>
internal sealed class HelicopterCrewDescentState
{
    private const float RootRotationUnitTolerance = 0.0002f;

    private readonly HelicopterPhysicsLease _ropeLease;
    private readonly HelicopterDescentState _descent;
    private ulong _lastRenderFrame;
    private ulong _lastPhysicsStep;

    internal HelicopterCrewDescentState(HelicopterPhysicsLease ropeLease,
        HelicopterPhysicsWorldSnapshot initialPhysics, float startingHeight, float landingHeight)
    {
        ArgumentNullException.ThrowIfNull(initialPhysics);
        if (ropeLease.WorldId == Guid.Empty || ropeLease.EntityId == 0 || ropeLease.Generation == 0)
        {
            throw new InvalidDataException("Crew descent requires an owned live rope generation.");
        }
        _ropeLease = ropeLease;
        RequireRope(initialPhysics);
        _descent = new HelicopterDescentState(startingHeight, landingHeight);
        _lastRenderFrame = initialPhysics.RenderFrames;
        _lastPhysicsStep = initialPhysics.PhysicsSteps;
    }

    internal float Progress => _descent.Progress;

    /// <summary>Binds source drop inputs to the actual root height and the exact live publication at drop.</summary>
    internal static HelicopterCrewDescentState FromDrop(CoopMatchRuntime.TransportCrewDrop drop,
        HelicopterRopeBodyPose observedRoot, HelicopterPhysicsWorldSnapshot physics)
    {
        ArgumentNullException.ThrowIfNull(drop);
        ArgumentNullException.ThrowIfNull(observedRoot);
        ArgumentNullException.ThrowIfNull(physics);
        float rotationLength = observedRoot.Rotation.LengthSquared();
        if (drop.Birth.ActorEntityId == 0 || drop.Birth.ActorEntityId == drop.RopeLease.EntityId ||
            drop.PhysicsSequence != physics.PhysicsSteps || drop.RenderFrame != physics.RenderFrames ||
            !PlayerHitbox.Finite(observedRoot.Position) || !float.IsFinite(rotationLength) ||
            MathF.Abs(rotationLength - 1f) > RootRotationUnitTolerance ||
            drop.LandingSurface is not Vector3 surface || !PlayerHitbox.Finite(surface))
        {
            throw new InvalidDataException("Crew descent start lost its observed root, landing surface or drop frame.");
        }
        // SpawnFromHelicopter reads the soldier's actual transform Y, not the seat or rope marker Y.
        return new HelicopterCrewDescentState(drop.RopeLease, physics, observedRoot.Position.Y, surface.Y);
    }

    internal HelicopterDescentResult Advance(HelicopterCrewDescentObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        ArgumentNullException.ThrowIfNull(observation.Physics);
        HelicopterPhysicsWorldSnapshot physics = observation.Physics;
        if (_lastRenderFrame == ulong.MaxValue || physics.RenderFrames != _lastRenderFrame + 1 ||
            physics.PhysicsSteps < _lastPhysicsStep)
        {
            throw new InvalidDataException("Crew descent requires the next complete native render publication.");
        }
        HelicopterPhysicsMemberSnapshot rope = RequireRope(physics);
        Vector3[] joints = rope.Bodies.Select(body => body.Pose.Position).ToArray();

        // The source consumes current joint transforms, not the initial rope or its spawn-age projection.
        HelicopterDescentResult result = _descent.Advance(observation.Pose, observation.DeltaTime, joints);
        _lastRenderFrame = physics.RenderFrames;
        _lastPhysicsStep = physics.PhysicsSteps;
        return result;
    }

    private HelicopterPhysicsMemberSnapshot RequireRope(HelicopterPhysicsWorldSnapshot physics)
    {
        HelicopterPhysicsMemberSnapshot[] matches = physics.Members
            .Where(member => member.Lease.EntityId == _ropeLease.EntityId).ToArray();
        if (matches.Length != 1 || matches[0].Lease != _ropeLease || matches[0].Bodies.Count == 0)
        {
            throw new InvalidDataException("Crew descent lost its live rope or observed a reused entity generation.");
        }
        return matches[0];
    }
}
