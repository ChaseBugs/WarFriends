using System.Numerics;

namespace War.BattleServer;

/// <summary>One immutable rope body result; angular velocity is in world radians per second.</summary>
internal sealed record HelicopterRopeMotionBody(HelicopterRopeBodyPose Pose,
    Vector3 Velocity, Vector3 AngularVelocity);

/// <summary>Private step workspace for the source's unit-mass, unit-inertia, zero-COM rope bodies.</summary>
internal sealed class HelicopterRopeSolverBody
{
    private const float MaximumAngularSpeed = 7f;
    private const float UnitTolerance = 0.0001f;
    internal Vector3 Position;
    internal Quaternion Rotation;
    internal Vector3 Velocity;
    internal Vector3 AngularVelocity;

    internal HelicopterRopeSolverBody(HelicopterRopeInitialJoint source)
    {
        Position = source.Position;
        Rotation = source.Rotation;
    }

    private HelicopterRopeSolverBody(HelicopterRopeSolverBody source)
    {
        Position = source.Position;
        Rotation = source.Rotation;
        Velocity = source.Velocity;
        AngularVelocity = source.AngularVelocity;
    }

    internal HelicopterRopeSolverBody Copy() => new(this);

    internal void ApplyForces(HelicopterRopeBodySetup settings)
    {
        float deltaTime = HelicopterRopeSimulation.FixedDelta;
        if (settings.ShouldUseGravity)
        {
            Velocity += new Vector3(0, -HelicopterRopeSimulation.Gravity, 0) * deltaTime;
        }
        Velocity *= MathF.Max(0, 1f - settings.Drag * deltaTime);
        AngularVelocity *= MathF.Max(0, 1f - settings.AngularDrag * deltaTime);
        float speed = AngularVelocity.Length();
        if (speed > MaximumAngularSpeed)
        {
            AngularVelocity *= MaximumAngularSpeed / speed;
        }
        Validate();
    }

    internal void Integrate()
    {
        float deltaTime = HelicopterRopeSimulation.FixedDelta;
        Position += Velocity * deltaTime;
        float speed = AngularVelocity.Length();
        if (speed > 0)
        {
            Quaternion change = Quaternion.CreateFromAxisAngle(AngularVelocity / speed, speed * deltaTime);
            Rotation = Quaternion.Normalize(change * Rotation);
        }
        Validate();
    }

    internal HelicopterRopeMotionBody Snapshot()
    {
        return new HelicopterRopeMotionBody(new HelicopterRopeBodyPose(Position, Rotation), Velocity, AngularVelocity);
    }

    internal void Validate()
    {
        float length = Rotation.LengthSquared();
        if (!PlayerHitbox.Finite(Position) || !FiniteVector(Velocity) ||
            !FiniteVector(AngularVelocity) || !float.IsFinite(AngularVelocity.LengthSquared()) ||
            !float.IsFinite(length) || MathF.Abs(length - 1f) > UnitTolerance)
        {
            throw new InvalidDataException($"Rope body motion lost its finite unit-pose invariant: " +
                $"position {Position}, rotation {Rotation}, velocity {Velocity}, angular {AngularVelocity}.");
        }
    }

    private static bool FiniteVector(Vector3 value)
    {
        // Joint position bias may exceed the map-coordinate bound; the free-motion cap is applied before solving.
        return float.IsFinite(value.X) && float.IsFinite(value.Y) && float.IsFinite(value.Z);
    }
}
