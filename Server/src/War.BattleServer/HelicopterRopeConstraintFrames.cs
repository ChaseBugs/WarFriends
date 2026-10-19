using System.Numerics;

namespace War.BattleServer;

/// <summary>Unit-scale world body pose when the source constraint is created.</summary>
internal sealed record HelicopterRopeBodyPose(Vector3 Position, Quaternion Rotation);

/// <summary>A local constraint origin and rest orientation, relative to its owning body.</summary>
internal sealed record HelicopterRopeLocalFrame(Vector3 Position, Quaternion Rotation);

/// <summary>Local frames bound to their bodies; aircraft rest rotation precedes source rope activation.</summary>
internal sealed record HelicopterRopeConstraintFrame(int BodyIndex, int ConnectedBodyIndex,
    HelicopterRopeLocalFrame BodyFrame, HelicopterRopeLocalFrame ConnectedFrame);

/// <summary>
/// Prepared aircraft attachment and chain links; applying or solving them belongs to the physics adapter.
/// </summary>
internal sealed record HelicopterRopeConstraintSetup(HelicopterRopeConstraintFrame Attachment,
    IReadOnlyList<HelicopterRopeConstraintFrame> Links);

/// <summary>Realizes automatic unit-scale joint anchors from placed source poses before the first solve.</summary>
internal static class HelicopterRopeConstraintFrames
{
    internal const int AircraftBodyIndex = -1;
    private const int MaximumInitialJointCount = 10002;
    private const float UnitRotationTolerance = 0.0001f;
    private const float MaximumAngleDegrees = 180f;

    internal static HelicopterRopeConstraintSetup Create(
        HelicopterRopeInitialState initial, HelicopterRopeBodyPose aircraft, Quaternion attachmentConnectedRestRotation)
    {
        ArgumentNullException.ThrowIfNull(initial);
        ArgumentNullException.ThrowIfNull(aircraft);
        ValidatePose(aircraft.Position, aircraft.Rotation);
        ValidatePose(Vector3.Zero, attachmentConnectedRestRotation);
        initial = Snapshot(initial);
        ValidateInitialState(initial);
        var links = new HelicopterRopeConstraintFrame[initial.Joints.Count - 1];
        for (int index = 0; index < links.Length; index++)
        {
            links[index] = CreateFrame(index, index + 1, initial.Joints[index],
                new HelicopterRopeBodyPose(initial.Joints[index + 1].Position, initial.Joints[index + 1].Rotation));
        }
        HelicopterRopeConstraintFrame attachment = CreateFrame(
            0, AircraftBodyIndex, initial.Joints[0], aircraft);
        // The aircraft joint is created before QuickRope2 rotates the root during activation.
        HelicopterRopeLocalFrame connectedFrame = attachment.ConnectedFrame with
        {
            Rotation = Quaternion.Normalize(attachmentConnectedRestRotation)
        };
        attachment = attachment with { ConnectedFrame = connectedFrame };
        return new HelicopterRopeConstraintSetup(attachment, Array.AsReadOnly(links));
    }

    private static HelicopterRopeConstraintFrame CreateFrame(int bodyIndex, int connectedIndex,
        HelicopterRopeInitialJoint body, HelicopterRopeBodyPose connected)
    {
        Quaternion inverseConnected = Quaternion.Conjugate(Quaternion.Normalize(connected.Rotation));
        Vector3 localPosition = Vector3.Transform(body.Position - connected.Position, inverseConnected);
        Quaternion restRotation = Quaternion.Normalize(inverseConnected * Quaternion.Normalize(body.Rotation));
        ValidatePose(localPosition, restRotation);
        return new HelicopterRopeConstraintFrame(bodyIndex, connectedIndex,
            new HelicopterRopeLocalFrame(Vector3.Zero, Quaternion.Identity),
            new HelicopterRopeLocalFrame(localPosition, restRotation));
    }

    private static HelicopterRopeInitialState Snapshot(HelicopterRopeInitialState initial)
    {
        if (initial.Joints == null || initial.Joints.Count is < 2 or > MaximumInitialJointCount)
        {
            throw new InvalidDataException("Invalid source rope joint sequence.");
        }
        var joints = new HelicopterRopeInitialJoint[initial.Joints.Count];
        for (int index = 0; index < joints.Length; index++)
        {
            joints[index] = initial.Joints[index];
        }
        return new HelicopterRopeInitialState(Array.AsReadOnly(joints), initial.InitialJointDistance);
    }

    private static void ValidateInitialState(HelicopterRopeInitialState initial)
    {
        if (!float.IsFinite(initial.InitialJointDistance) || initial.InitialJointDistance <= 0)
        {
            throw new InvalidDataException("Invalid source rope initialization for constraint preparation.");
        }
        for (int index = 0; index < initial.Joints.Count; index++)
        {
            HelicopterRopeInitialJoint joint = initial.Joints[index];
            if (joint == null || joint.Body == null)
            {
                throw new InvalidDataException("Missing source rope body setup.");
            }
            ValidatePose(joint.Position, joint.Rotation);
            ValidateBody(joint.Body);
            int? expected = index < initial.Joints.Count - 1 ? index + 1 : null;
            if (joint.Connection?.ConnectedJointIndex != expected)
            {
                throw new InvalidDataException("Source rope links are missing, cyclic or reordered.");
            }
            if (joint.Connection != null)
            {
                ValidateLimits(joint.Connection.AngularLimits);
            }
        }
        float measured = Vector3.Distance(initial.Joints[0].Position, initial.Joints[1].Position);
        if (!float.IsFinite(measured) || measured != initial.InitialJointDistance)
        {
            throw new InvalidDataException("Source rope spacing is not bound to its initial body poses.");
        }
    }

    private static void ValidateBody(HelicopterRopeBodySetup body)
    {
        if (!float.IsFinite(body.Mass) || body.Mass <= 0 || !float.IsFinite(body.Drag) || body.Drag < 0 ||
            !float.IsFinite(body.AngularDrag) || body.AngularDrag < 0)
        {
            throw new InvalidDataException("Invalid rope body mass or damping.");
        }
    }

    private static void ValidateLimits(HelicopterRopeAngularLimits limits)
    {
        if (limits == null || !float.IsFinite(limits.MinimumX) || !float.IsFinite(limits.MaximumX) ||
            !float.IsFinite(limits.MaximumY) || !float.IsFinite(limits.MaximumZ) ||
            limits.MinimumX > limits.MaximumX || limits.MinimumX < -MaximumAngleDegrees ||
            limits.MaximumX > MaximumAngleDegrees || limits.MaximumY is < 0 or > MaximumAngleDegrees ||
            limits.MaximumZ is < 0 or > MaximumAngleDegrees)
        {
            throw new InvalidDataException("Invalid rope angular stops.");
        }
    }

    private static void ValidatePose(Vector3 position, Quaternion rotation)
    {
        float length = rotation.LengthSquared();
        if (!PlayerHitbox.Finite(position) || !float.IsFinite(length) ||
            MathF.Abs(length - 1f) > UnitRotationTolerance)
        {
            throw new InvalidDataException("Invalid unit-scale rope constraint frame.");
        }
    }
}
