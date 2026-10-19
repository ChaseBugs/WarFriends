using System.Numerics;

namespace War.BattleServer;

/// <summary>Current soldier pose and vertically interpolated root from the host's descent step.</summary>
internal sealed record HelicopterRopeAlignmentPose(
    Vector3 BasePosition, Vector3 RootPosition, Vector3 LeftPalmPosition, Quaternion RootRotation);

/// <summary>Recovered EnemyController.GetRopePosition; it does not simulate rope physics or landing.</summary>
internal static class HelicopterRopeAlignment
{
    // Host input budget; the recovered method has no explicit joint-count limit.
    private const int MaximumJointCount = 256;
    private const float ForwardOffset = 0.02f;
    private const float RightOffset = 0.04f;
    private const float RotationTolerance = 0.0001f;

    internal static Vector3 Align(HelicopterRopeAlignmentPose pose, IReadOnlyList<Vector3>? joints)
    {
        Validate(pose, joints);
        if (joints == null)
        {
            return pose.BasePosition;
        }

        Vector3 palm = pose.BasePosition + pose.LeftPalmPosition - pose.RootPosition;
        Vector3 offset = Vector3.Transform(Vector3.UnitZ, pose.RootRotation) * ForwardOffset -
            Vector3.Transform(Vector3.UnitX, pose.RootRotation) * RightOffset;
        Vector3 previous = joints[0];
        if (palm.Y >= previous.Y)
        {
            previous.Y = palm.Y;
            return CheckedPosition(pose.BasePosition + (previous - palm) + offset);
        }

        for (int index = 1; index < joints.Count; index++)
        {
            Vector3 joint = joints[index];
            if (joint.Y <= palm.Y)
            {
                float fraction = (joint.Y - palm.Y) / (joint.Y - previous.Y);
                Vector3 alignedPalm = Vector3.Lerp(joint, previous, Math.Clamp(fraction, 0f, 1f));
                return CheckedPosition(pose.BasePosition + (alignedPalm - palm) + offset);
            }
            previous = joint;
        }

        // The source leaves the root unchanged when the palm is below every joint.
        return pose.BasePosition;
    }

    private static void Validate(HelicopterRopeAlignmentPose pose, IReadOnlyList<Vector3>? joints)
    {
        ArgumentNullException.ThrowIfNull(pose);
        float rotationLength = pose.RootRotation.LengthSquared();
        if (!PlayerHitbox.Finite(pose.BasePosition) || !PlayerHitbox.Finite(pose.RootPosition) ||
            !PlayerHitbox.Finite(pose.LeftPalmPosition) || !float.IsFinite(rotationLength) ||
            MathF.Abs(rotationLength - 1f) > RotationTolerance)
        {
            throw new InvalidDataException("Invalid Helicopter rope alignment pose.");
        }
        if (joints != null && (joints.Count is < 1 or > MaximumJointCount ||
            joints.Any(joint => !PlayerHitbox.Finite(joint))))
        {
            throw new InvalidDataException("Invalid Helicopter rope joints.");
        }
        CheckedPosition(pose.BasePosition + pose.LeftPalmPosition - pose.RootPosition);
    }

    private static Vector3 CheckedPosition(Vector3 position)
    {
        if (!PlayerHitbox.Finite(position))
        {
            throw new InvalidDataException("Helicopter rope alignment overflow.");
        }
        return position;
    }
}
