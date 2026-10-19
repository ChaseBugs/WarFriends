using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Stationary-aircraft rope dynamics workspace; live flight, extension and collision integration remain separate.
/// </summary>
internal sealed class HelicopterRopeSimulation
{
    internal const float FixedDelta = 0.02f;
    internal const float Gravity = 9.81f;
    private const float ExpectedBodyMass = 1f;
    private readonly HelicopterRopeInitialState _initial;
    private readonly HelicopterRopeBodyPose _aircraft;
    private readonly HelicopterRopeConstraintSetup _constraints;
    private HelicopterRopeSolverBody[] _bodies;

    internal ulong StepCount { get; private set; }

    internal HelicopterRopeSimulation(HelicopterRopeInitialState initial, HelicopterRopeBodyPose aircraft,
        Quaternion attachmentConnectedRestRotation)
    {
        _constraints = HelicopterRopeConstraintFrames.Create(initial, aircraft, attachmentConnectedRestRotation);
        _initial = initial with { Joints = Array.AsReadOnly(initial.Joints.ToArray()) };
        _aircraft = aircraft;
        foreach (HelicopterRopeInitialJoint joint in _initial.Joints)
        {
            if (joint.Body.Mass != ExpectedBodyMass || joint.Connection is { AngularLimits: var limits } &&
                limits.MaximumY != limits.MaximumZ)
            {
                throw new InvalidDataException(
                    "Rope simulation requires the recovered unit inertia/mass and circular cone.");
            }
        }
        _bodies = _initial.Joints.Select(joint => new HelicopterRopeSolverBody(joint)).ToArray();
    }

    internal IReadOnlyList<HelicopterRopeMotionBody> Snapshot()
    {
        return Array.AsReadOnly(_bodies.Select(body => body.Snapshot()).ToArray());
    }

    internal void Advance()
    {
        ulong nextStep = checked(StepCount + 1);
        HelicopterRopeSolverBody[] working = _bodies.Select(body => body.Copy()).ToArray();
        for (int index = 0; index < working.Length; index++)
        {
            working[index].ApplyForces(_initial.Joints[index].Body);
        }
        HelicopterRopeConstraintRow[][] batches = Prepare(working);
        foreach (HelicopterRopeConstraintRow row in batches.SelectMany(rows => rows))
        {
            row.SolvePosition(working);
        }
        foreach (HelicopterRopeSolverBody body in working)
        {
            body.Integrate();
        }
        foreach (HelicopterRopeConstraintRow row in batches.SelectMany(rows => rows))
        {
            row.SolveVelocity(working);
        }
        foreach (HelicopterRopeSolverBody body in working)
        {
            body.Validate();
        }
        _bodies = working;
        StepCount = nextStep;
    }

    private HelicopterRopeConstraintRow[][] Prepare(HelicopterRopeSolverBody[] working)
    {
        var result = new List<HelicopterRopeConstraintRow[]>();
        // Non-sharing even links can solve together, followed by odd links and the fixed aircraft attachment.
        for (int parity = 0; parity < 2; parity++)
        {
            for (int index = parity; index < _constraints.Links.Count; index += 2)
            {
                HelicopterRopeConnectionSetup connection = _initial.Joints[index].Connection ??
                    throw new InvalidDataException("Missing initial rope connection.");
                result.Add(HelicopterRopeJointRows.Prepare(_constraints.Links[index], working,
                    _aircraft, connection.AngularLimits));
            }
        }
        result.Add(HelicopterRopeJointRows.Prepare(_constraints.Attachment, working, _aircraft, null));
        return result.ToArray();
    }
}
