using System.Numerics;

namespace War.BattleServer;

/// <summary>Isolated native rope ownership; flight, extension, collision and live Worker use remain separate.</summary>
internal sealed class NativeHelicopterRope : IDisposable
{
    private const int MaximumBodies = 128;
    private const int HeaderSize = 14;
    private const int PoseSize = 7;
    private const int MotionSize = 13;
    private const int ExpectedAbiVersion = 4;
    private const float UnitRotationTolerance = 0.0001f;
    private static readonly HelicopterRopeBodySetup SourceBody = new(1f, 0.2f, 0.05f, true);
    private static readonly HelicopterRopeAngularLimits SourceLimits = new(-60f, 60f, 35f, 35f);
    private readonly object _gate = new();
    private readonly NativeRopeHandle _handle;
    private readonly float _initialJointDistance;
    private int _bodyCount;
    private bool _hasFailed;
    private float? _extensionTargetHeight;
    private HelicopterPhysicsMode _physicsMode;

    internal ulong StepCount { get; private set; }
    internal ulong RenderFrameCount { get; private set; }
    internal ulong NominalPhysicsMilliseconds { get; private set; }
    internal bool IsExtending
    {
        get
        {
            lock (_gate)
            {
                RequireAvailable();
                return _extensionTargetHeight.HasValue;
            }
        }
    }

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
        _initialJointDistance = initial.InitialJointDistance;
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
        ValidateAircraftTransform(aircraft);
        var values = new List<float>(PoseSize);
        AddPose(values, aircraft.Position, aircraft.Rotation);
        lock (_gate)
        {
            RequireAvailable();
            RequireSuccess(NativeRopeMethods.SetAircraftTransform(_handle, values.ToArray(), values.Count));
        }
    }

    /// <summary>Starts the source ShowRope gate using a separately resolved NavMesh target height.</summary>
    internal void BeginExtension(float targetHeight)
    {
        if (!float.IsFinite(targetHeight) || !PlayerHitbox.Finite(new Vector3(0, targetHeight, 0)))
        {
            throw new InvalidDataException("Rope extension requires a finite bounded target height.");
        }
        lock (_gate)
        {
            RequireAvailable();
            _extensionTargetHeight = targetHeight;
        }
    }

    /// <summary>Arms the source failed SamplePosition result; the next render's height gate disables extension.</summary>
    internal void BeginFailedLanding()
    {
        lock (_gate)
        {
            RequireAvailable();
            // Unity 2018.3 returns a positive-infinite hit position on the captured failed query.
            // Keep this sentinel internal; it is never accepted as a network or successful landing target.
            _extensionTargetHeight = float.PositiveInfinity;
        }
    }

    /// <summary>
    /// Runs the source extension gate before aircraft Transform changes; fixed physics stays separate.
    /// </summary>
    internal void UpdateRenderFrame(float deltaTime, HelicopterRopeBodyPose aircraft)
    {
        if (!float.IsFinite(deltaTime) || deltaTime < 0)
        {
            throw new InvalidDataException("Rope render delta must be finite and nonnegative.");
        }
        ValidateAircraftTransform(aircraft);
        lock (_gate)
        {
            RequireAvailable();
            ulong nextFrame = checked(RenderFrameCount + 1);
            if (_extensionTargetHeight is float targetHeight)
            {
                // Helicopter.Update tests ropeEnd against the target before applying its next flight pose.
                if (Snapshot()[^1].Pose.Position.Y > targetHeight)
                {
                    Extend(deltaTime);
                }
                else
                {
                    _extensionTargetHeight = null;
                }
            }
            ApplyAircraftTransform(aircraft);
            RenderFrameCount = nextFrame;
        }
    }

    /// <summary>Applies one source render-update extension command without advancing the physical clock.</summary>
    internal void Extend(float deltaTime)
    {
        lock (_gate)
        {
            RequireAvailable();
            if (_bodyCount < 3)
            {
                throw new InvalidOperationException("Source rope extension requires at least three bodies.");
            }
            IReadOnlyList<HelicopterRopeMotionBody> bodies = Snapshot();
            var head = new HelicopterRopeHead(
                bodies[0].Pose.Position, bodies[1].Pose.Position, bodies[2].Pose.Position);
            HelicopterRopeExtensionResult command = HelicopterRopeExtension.Prepare(
                head, _initialJointDistance, deltaTime);
            var values = new List<float> { command.MovedFirst.X, command.MovedFirst.Y, command.MovedFirst.Z };
            if (command.InsertedPosition is Vector3 position)
            {
                if (_bodyCount == MaximumBodies)
                {
                    throw new InvalidOperationException("Native rope cannot insert beyond its body capacity.");
                }
                Vector3 facing = head.Anchor - command.MovedFirst;
                Quaternion rotation = HelicopterRopeInitialization.CreateJointRotation(Vector3.Normalize(facing));
                AddPose(values, position, rotation);
            }
            RequireSuccess(NativeRopeMethods.Extend(_handle, values.ToArray(), values.Count, _bodyCount));
            if (command.InsertedPosition != null)
            {
                _bodyCount++;
            }
        }
    }

    /// <summary>Selects source timing without stepping physics or changing the render clock.</summary>
    internal void SetPhysicsMode(HelicopterPhysicsMode mode)
    {
        _ = HelicopterPhysicsTiming.Seconds(mode);
        lock (_gate)
        {
            RequireAvailable();
            _physicsMode = mode;
        }
    }

    internal void Advance()
    {
        lock (_gate)
        {
            RequireAvailable();
            ulong nextStep = checked(StepCount + 1);
            ulong nextMilliseconds = checked(NominalPhysicsMilliseconds +
                HelicopterPhysicsTiming.Milliseconds(_physicsMode));
            RequireSuccess(NativeRopeMethods.Step(_handle, HelicopterPhysicsTiming.Seconds(_physicsMode)));
            StepCount = nextStep;
            NominalPhysicsMilliseconds = nextMilliseconds;
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

    /// <summary>Releases this scene's native bodies and constraints once.</summary>
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

    internal static void ValidateAircraftTransform(HelicopterRopeBodyPose aircraft)
    {
        ArgumentNullException.ThrowIfNull(aircraft);
        float length = aircraft.Rotation.LengthSquared();
        if (!PlayerHitbox.Finite(aircraft.Position) || !float.IsFinite(length) ||
            MathF.Abs(length - 1) > UnitRotationTolerance)
        {
            throw new InvalidDataException("Aircraft transform requires a finite bounded unit pose.");
        }
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
