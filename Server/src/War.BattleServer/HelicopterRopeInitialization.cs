using System.Numerics;

namespace War.BattleServer;

/// <summary>Generated initial pose before physics changes a rope joint.</summary>
internal sealed record HelicopterRopeInitialJoint(Vector3 Position, Quaternion Rotation,
    HelicopterRopeBodySetup Body, HelicopterRopeConnectionSetup? Connection);

/// <summary>Recovered body settings shared by the generated rope joints.</summary>
internal sealed record HelicopterRopeBodySetup(float Mass, float Drag, float AngularDrag, bool ShouldUseGravity)
{
    internal bool IsKinematic => false;
    internal bool HasFrozenAxes => false;
}

/// <summary>Recovered angular stops; the source locks each of the three linear axes.</summary>
internal sealed record HelicopterRopeAngularLimits(float MinimumX, float MaximumX, float MaximumY, float MaximumZ);

/// <summary>Connection intent; a physical adapter must configure anchors after placing both bodies.</summary>
internal sealed record HelicopterRopeConnectionSetup(int ConnectedJointIndex, HelicopterRopeAngularLimits AngularLimits)
{
    internal bool ShouldLockLinearMotion => true;
    internal bool ShouldLimitAngularMotion => true;
    internal bool ShouldAutoConfigureConnectedAnchor => true;
}

/// <summary>Source spline geometry and the measured spacing used by subsequent extension commands.</summary>
internal sealed record HelicopterRopeInitialState(
    IReadOnlyList<HelicopterRopeInitialJoint> Joints, float InitialJointDistance);

/// <summary>Source QuickRope2 initialization for the Helicopter prefab's empty control-point list.</summary>
internal static class HelicopterRopeInitialization
{
    private const float SourceSampleStep = 0.0001f;
    private const float NormalizeEpsilon = 0.00001f;
    private const float MinimumRightLength = NormalizeEpsilon;
    private const float UnitRotationTolerance = 0.0001f;
    private const float SourceMass = 1f;
    private const float SourceDrag = 0.2f;
    private const float SourceAngularDrag = 0.05f;
    private const float SourceMinimumX = -60f;
    private const float SourceMaximumX = 60f;
    private const float SourceMaximumY = 35f;
    private const float SourceMaximumZ = 35f;
    private static readonly HelicopterRopeBodySetup SourceBody =
        new(SourceMass, SourceDrag, SourceAngularDrag, true);
    private static readonly HelicopterRopeAngularLimits SourceAngularLimits =
        new(SourceMinimumX, SourceMaximumX, SourceMaximumY, SourceMaximumZ);

    internal static HelicopterRopeInitialState Create(Vector3 anchor, Vector3 end, float requestedSpacing)
    {
        float length = (end - anchor).Length();
        if (!PlayerHitbox.Finite(anchor) || !PlayerHitbox.Finite(end) || !float.IsFinite(length) ||
            length <= NormalizeEpsilon || !float.IsFinite(requestedSpacing) || requestedSpacing <= 0)
        {
            throw new InvalidDataException("Invalid zero-control-point Helicopter rope initialization.");
        }
        Vector3 direction = (end - anchor) / length;
        var curve = new CurvePoints(anchor - direction, anchor, end, end + direction);
        Vector3[] spline = SampleSpline(curve, requestedSpacing);
        HelicopterRopeInitialJoint[] joints = CreateJoints(anchor, end, spline);
        float initialDistance = Vector3.Distance(joints[0].Position, joints[1].Position);
        if (!float.IsFinite(initialDistance) || initialDistance <= 0)
        {
            throw new InvalidDataException("Generated Helicopter rope lost its initial joint spacing.");
        }
        return new HelicopterRopeInitialState(Array.AsReadOnly(joints), initialDistance);
    }

    private static HelicopterRopeInitialJoint[] CreateJoints(Vector3 anchor, Vector3 end, Vector3[] spline)
    {
        var joints = new HelicopterRopeInitialJoint[spline.Length];
        for (int index = 0; index < joints.Length; index++)
        {
            Vector3 facing = index == 0 ? spline[0] - spline[1] : spline[index - 1] - spline[index];
            float facingLength = facing.Length();
            if (!float.IsFinite(facingLength) || facingLength <= NormalizeEpsilon)
            {
                throw new InvalidDataException("Generated Helicopter rope has a degenerate joint facing.");
            }
            Quaternion rotation = LookRotation(facing / facingLength);
            float rotationLength = rotation.LengthSquared();
            if (!float.IsFinite(rotationLength) || MathF.Abs(rotationLength - 1f) > UnitRotationTolerance)
            {
                throw new InvalidDataException("Generated Helicopter rope rotation is invalid.");
            }
            // GenerateJointObjects retains the original endpoint objects, not their rounded spline samples.
            Vector3 position = spline[index];
            if (index == 0)
            {
                position = anchor;
            }
            else if (index == joints.Length - 1)
            {
                position = end;
            }
            HelicopterRopeConnectionSetup? connection = null;
            if (index < joints.Length - 1)
            {
                connection = new HelicopterRopeConnectionSetup(index + 1, SourceAngularLimits);
            }
            joints[index] = new HelicopterRopeInitialJoint(position, rotation, SourceBody, connection);
        }
        return joints;
    }

    private static Vector3[] SampleSpline(CurvePoints curve, float spacing)
    {
        var samples = new List<Vector3> { Evaluate(curve, 0) };
        // Source repeatedly adds a float step; integer-index division selects different sample positions.
        for (float time = 0; time <= 1f; time += SourceSampleStep)
        {
            Vector3 sample = Evaluate(curve, time);
            if (Vector3.Distance(samples[^1], sample) >= spacing)
            {
                samples.Add(sample);
            }
        }
        samples.Add(Evaluate(curve, 1));
        return samples.ToArray();
    }

    private static Quaternion LookRotation(Vector3 forward)
    {
        Vector3 right = Vector3.Cross(Vector3.UnitY, forward);
        float rightLength = right.Length();
        if (rightLength < MinimumRightLength)
        {
            // Near-collinear native samples use the shortest rotation from +Z, preserving small lateral components.
            Vector3 axis = Vector3.Cross(Vector3.UnitZ, forward);
            return Quaternion.Normalize(new Quaternion(axis, 1f + forward.Z));
        }
        right /= rightLength;
        Vector3 up = Vector3.Cross(forward, right);
        var matrix = new Matrix4x4(right.X, right.Y, right.Z, 0, up.X, up.Y, up.Z, 0,
            forward.X, forward.Y, forward.Z, 0, 0, 0, 0, 1);
        return Quaternion.Normalize(Quaternion.CreateFromRotationMatrix(matrix));
    }

    private static Vector3 Evaluate(CurvePoints curve, float time)
    {
        Vector3 position = 0.5f * (
            (-curve.Before + 3f * curve.Start - 3f * curve.End + curve.After) * (time * time * time) +
            (2f * curve.Before - 5f * curve.Start + 4f * curve.End - curve.After) * (time * time) +
            (-curve.Before + curve.End) * time + 2f * curve.Start);
        if (!PlayerHitbox.Finite(position))
        {
            throw new InvalidDataException("Helicopter rope spline overflow.");
        }
        return position;
    }

    private readonly record struct CurvePoints(Vector3 Before, Vector3 Start, Vector3 End, Vector3 After);
}
