using System.Numerics;

namespace War.BattleServer;

/// <summary>Velocity projections for a pair of unit-mass, isotropic unit-inertia bodies.</summary>
internal readonly record struct HelicopterRopeJacobian(Vector3 LinearA, Vector3 AngularA,
    Vector3 LinearB, Vector3 AngularB)
{
    internal float Inner(HelicopterRopeJacobian other, bool hasConnectedBody)
    {
        float result = Vector3.Dot(LinearA, other.LinearA) + Vector3.Dot(AngularA, other.AngularA);
        if (hasConnectedBody)
        {
            result += Vector3.Dot(LinearB, other.LinearB) + Vector3.Dot(AngularB, other.AngularB);
        }
        return result;
    }

    internal HelicopterRopeJacobian Subtract(HelicopterRopeJacobian other, float scale)
    {
        return new HelicopterRopeJacobian(LinearA - other.LinearA * scale, AngularA - other.AngularA * scale,
            LinearB - other.LinearB * scale, AngularB - other.AngularB * scale);
    }
}

/// <summary>Prepared bilateral or unilateral row, retained across position and velocity phases.</summary>
internal sealed class HelicopterRopeConstraintRow
{
    internal readonly HelicopterRopeConstraintFrame Frame;
    internal HelicopterRopeJacobian Jacobian;
    internal float Error;
    private float _impulse;
    private bool _isLimit;
    internal bool IsLimit => _isLimit;

    internal HelicopterRopeConstraintRow(HelicopterRopeConstraintFrame frame,
        HelicopterRopeJacobian jacobian, float error)
    {
        Frame = frame;
        Jacobian = jacobian;
        Error = error;
    }

    internal static HelicopterRopeConstraintRow CreateLimit(HelicopterRopeConstraintFrame frame,
        HelicopterRopeJacobian jacobian, float error)
    {
        var row = new HelicopterRopeConstraintRow(frame, jacobian, error);
        row._isLimit = true;
        return row;
    }

    internal void RemoveProjection(HelicopterRopeConstraintRow previous)
    {
        bool hasConnected = Frame.ConnectedBodyIndex >= 0;
        float response = previous.Jacobian.Inner(previous.Jacobian, hasConnected);
        float scale = Jacobian.Inner(previous.Jacobian, hasConnected) / response;
        Jacobian = Jacobian.Subtract(previous.Jacobian, scale);
        Error -= previous.Error * scale;
    }

    internal void SolvePosition(HelicopterRopeSolverBody[] bodies)
    {
        Solve(bodies, -Error / HelicopterRopeSimulation.FixedDelta);
    }

    internal void SolveVelocity(HelicopterRopeSolverBody[] bodies) => Solve(bodies, 0);

    private void Solve(HelicopterRopeSolverBody[] bodies, float targetVelocity)
    {
        HelicopterRopeSolverBody first = bodies[Frame.BodyIndex];
        HelicopterRopeSolverBody? second = Frame.ConnectedBodyIndex >= 0 ? bodies[Frame.ConnectedBodyIndex] : null;
        float speed = Vector3.Dot(Jacobian.LinearA, first.Velocity) +
            Vector3.Dot(Jacobian.AngularA, first.AngularVelocity);
        if (second != null)
        {
            speed -= Vector3.Dot(Jacobian.LinearB, second.Velocity) +
                Vector3.Dot(Jacobian.AngularB, second.AngularVelocity);
        }
        float response = Jacobian.Inner(Jacobian, second != null);
        float nextImpulse = _impulse + (targetVelocity - speed) / response;
        if (_isLimit)
        {
            nextImpulse = MathF.Max(0, nextImpulse);
        }
        float delta = nextImpulse - _impulse;
        if (!float.IsFinite(delta) || !float.IsFinite(response) || response <= 0)
        {
            throw new InvalidDataException("Rope constraint has an invalid impulse response.");
        }
        first.Velocity += Jacobian.LinearA * delta;
        first.AngularVelocity += Jacobian.AngularA * delta;
        if (second != null)
        {
            second.Velocity -= Jacobian.LinearB * delta;
            second.AngularVelocity -= Jacobian.AngularB * delta;
        }
        _impulse = nextImpulse;
    }
}
