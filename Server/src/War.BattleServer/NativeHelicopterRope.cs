using System.Numerics;

namespace War.BattleServer;

/// <summary>Isolated native rope ownership; flight, extension, collision and live Worker use remain separate.</summary>
internal sealed class NativeHelicopterRope : IDisposable
{
    private const int MaximumBodies = 128;
    private const int HeaderSize = 14;
    private const int PoseSize = 7;
    private const int MotionSize = 13;
    private const int ExpectedAbiVersion = 2;
    private const float UnitRotationTolerance = 0.0001f;
    private static readonly HelicopterRopeBodySetup SourceBody = new(1f, 0.2f, 0.05f, true);
    private static readonly HelicopterRopeAngularLimits SourceLimits = new(-60f, 60f, 35f, 35f);
    private readonly object _gate = new();
    private readonly NativeRopeHandle _handle;
    private readonly int _bodyCount;
    private bool _hasFailed;

    internal ulong StepCount { get; private set; }

    internal NativeHelicopterRope(HelicopterRopeInitialState initial, HelicopterRopeBodyPose aircraft,
        Quaternion attachmentConnectedRestRotation)
    {
        if (initial?.Joints == null || initial.Joints.Count is < 2 or > MaximumBodies)
        {
            throw new InvalidDataException("Native rope exceeds its explicit body capacity or has no chain.");
        }
        initial = initial with { Joints = Array.AsReadOnly(initial.Joints.ToArray()) };
        HelicopterRopeConstraintSetup setup = HelicopterRopeConstraintFrames.Create(
            initial, aircraft, attachmentConnectedRestRotation);
        ValidateSupportedSettings(initial);
        if (NativeRopeMethods.GetAbiVersion() != ExpectedAbiVersion)
        {
            throw new NotSupportedException("The native rope ABI version does not match this host.");
        }
        _bodyCount = initial.Joints.Count;
        float[] input = PrepareInput(initial, aircraft, setup);
        int status = NativeRopeMethods.Create(input, input.Length, _bodyCount, out IntPtr identity);
        if (status != 0)
        {
            throw new InvalidOperationException($"Native rope creation failed with status {status}.");
        }
        _handle = new NativeRopeHandle(identity);
    }

    /// <summary>
    /// Applies source Transform inheritance without advancing physics or generating kinematic velocity.
    /// </summary>
    internal void ApplyAircraftTransform(HelicopterRopeBodyPose aircraft)
    {
        ArgumentNullException.ThrowIfNull(aircraft);
        float length = aircraft.Rotation.LengthSquared();
        if (!PlayerHitbox.Finite(aircraft.Position) || !float.IsFinite(length) ||
            MathF.Abs(length - 1) > UnitRotationTolerance)
        {
            throw new InvalidDataException("Aircraft transform requires a finite bounded unit pose.");
        }
        var values = new List<float>(PoseSize);
        AddPose(values, aircraft.Position, aircraft.Rotation);
        lock (_gate)
        {
            RequireAvailable();
            RequireSuccess(NativeRopeMethods.SetAircraftTransform(_handle, values.ToArray(), values.Count));
        }
    }

    internal void Advance()
    {
        lock (_gate)
        {
            RequireAvailable();
            ulong nextStep = checked(StepCount + 1);
            RequireSuccess(NativeRopeMethods.Step(_handle));
            StepCount = nextStep;
        }
    }

    internal IReadOnlyList<HelicopterRopeMotionBody> Snapshot()
    {
        lock (_gate)
        {
            RequireAvailable();
            var values = new float[_bodyCount * MotionSize];
            RequireSuccess(NativeRopeMethods.Snapshot(_handle, values, values.Length));
            var bodies = new HelicopterRopeMotionBody[_bodyCount];
            for (int index = 0; index < bodies.Length; index++)
            {
                bodies[index] = ReadBody(values, index * MotionSize);
            }
            return Array.AsReadOnly(bodies);
        }
    }

    public void Dispose()
    {
        lock (_gate)
        {
            _handle.Dispose();
        }
    }

    private HelicopterRopeMotionBody ReadBody(float[] values, int offset)
    {
        Vector3 position = ReadVector(values, offset);
        Quaternion rotation = new(values[offset + 3], values[offset + 4], values[offset + 5], values[offset + 6]);
        Vector3 velocity = ReadVector(values, offset + 7);
        Vector3 angular = ReadVector(values, offset + 10);
        if (!PlayerHitbox.Finite(position) || !IsFinite(velocity) || !IsFinite(angular) ||
            !float.IsFinite(rotation.LengthSquared()) ||
            MathF.Abs(rotation.LengthSquared() - 1) > UnitRotationTolerance)
        {
            _hasFailed = true;
            throw new InvalidDataException("Native rope returned an invalid motion state.");
        }
        return new HelicopterRopeMotionBody(new HelicopterRopeBodyPose(position, rotation), velocity, angular);
    }

    private void RequireAvailable()
    {
        ObjectDisposedException.ThrowIf(_handle.IsClosed, this);
        if (_hasFailed)
        {
            throw new InvalidOperationException("A failed native rope cannot resume from unproven physics state.");
        }
    }

    private void RequireSuccess(int status)
    {
        if (status != 0)
        {
            // Native simulation is not rollback-safe; a failed call permanently closes this owner's authority.
            _hasFailed = true;
            throw new InvalidOperationException($"Native rope operation failed with status {status}.");
        }
    }

    private static void ValidateSupportedSettings(HelicopterRopeInitialState initial)
    {
        foreach (HelicopterRopeInitialJoint joint in initial.Joints)
        {
            if (joint.Body != SourceBody ||
                joint.Connection is { AngularLimits: var limits } && limits != SourceLimits)
            {
                throw new InvalidDataException(
                    "Native rope requires the recovered Helicopter body and limit settings.");
            }
        }
    }

    private static float[] PrepareInput(HelicopterRopeInitialState initial, HelicopterRopeBodyPose aircraft,
        HelicopterRopeConstraintSetup setup)
    {
        var values = new List<float>(HeaderSize + initial.Joints.Count * PoseSize);
        AddPose(values, aircraft.Position, aircraft.Rotation);
        Quaternion rest = setup.Attachment.ConnectedFrame.Rotation;
        values.AddRange(new[] { rest.X, rest.Y, rest.Z, rest.W });
        Vector3 anchor = setup.Attachment.ConnectedFrame.Position;
        values.AddRange(new[] { anchor.X, anchor.Y, anchor.Z });
        foreach (HelicopterRopeInitialJoint joint in initial.Joints)
        {
            AddPose(values, joint.Position, joint.Rotation);
        }
        return values.ToArray();
    }

    private static void AddPose(List<float> values, Vector3 position, Quaternion rotation)
    {
        values.AddRange(new[] { position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, rotation.W });
    }

    private static Vector3 ReadVector(float[] values, int offset)
    {
        return new Vector3(values[offset], values[offset + 1], values[offset + 2]);
    }

    private static bool IsFinite(Vector3 value)
    {
        return float.IsFinite(value.X) && float.IsFinite(value.Y) && float.IsFinite(value.Z);
    }
}
