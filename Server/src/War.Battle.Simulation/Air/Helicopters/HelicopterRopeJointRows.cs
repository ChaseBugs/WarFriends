// Constraint preparation references NVIDIA PhysX 3.4. See THIRD_PARTY_NOTICES/PhysX.txt.
using System.Numerics;

namespace War.BattleServer;

/// <summary>Builds locked translation, fixed attachment and source hard angular-limit rows.</summary>
internal static class HelicopterRopeJointRows
{
    internal static HelicopterRopeConstraintRow[] Prepare(HelicopterRopeConstraintFrame frame,
        HelicopterRopeSolverBody[] bodies, HelicopterRopeBodyPose aircraft, HelicopterRopeAngularLimits? limits)
    {
        HelicopterRopeSolverBody body = bodies[frame.BodyIndex];
        HelicopterRopeBodyPose connected = frame.ConnectedBodyIndex < 0 ? aircraft :
            new HelicopterRopeBodyPose(
                bodies[frame.ConnectedBodyIndex].Position, bodies[frame.ConnectedBodyIndex].Rotation);
        Vector3 anchorA = body.Position + Vector3.Transform(frame.BodyFrame.Position, body.Rotation);
        Vector3 anchorB = connected.Position + Vector3.Transform(frame.ConnectedFrame.Position, connected.Rotation);
        Quaternion rotationA = Quaternion.Normalize(body.Rotation * frame.BodyFrame.Rotation);
        Quaternion rotationB = Quaternion.Normalize(connected.Rotation * frame.ConnectedFrame.Rotation);
        if (Quaternion.Dot(rotationA, rotationB) < 0)
        {
            rotationB = -rotationB;
        }
        var rows = new List<HelicopterRopeConstraintRow>();
        if (limits == null)
        {
            AddFixedAngular(rows, frame, rotationA, rotationB);
        }
        Vector3[] axes = { Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ };
        foreach (Vector3 localAxis in axes)
        {
            Vector3 axis = Vector3.Transform(localAxis, rotationA);
            var jacobian = new HelicopterRopeJacobian(axis, Vector3.Cross(anchorA - body.Position, axis),
                axis, Vector3.Cross(anchorB - connected.Position, axis));
            rows.Add(new HelicopterRopeConstraintRow(frame, jacobian, Vector3.Dot(anchorA - anchorB, axis)));
        }
        Orthogonalize(rows);
        if (limits != null)
        {
            AddLimits(rows, frame, new RotationPair(rotationA, rotationB), limits);
        }
        return rows.ToArray();
    }

    private static void Orthogonalize(List<HelicopterRopeConstraintRow> rows)
    {
        for (int index = 0; index < rows.Count; index++)
        {
            for (int previous = 0; previous < index; previous++)
            {
                rows[index].RemoveProjection(rows[previous]);
            }
        }
    }

    private static void AddFixedAngular(List<HelicopterRopeConstraintRow> rows,
        HelicopterRopeConstraintFrame frame, Quaternion first, Quaternion second)
    {
        Vector3 firstVector = new(first.X, first.Y, first.Z);
        Vector3 secondVector = new(second.X, second.Y, second.Z);
        Vector3 crossTerms = secondVector * first.W + firstVector * second.W;
        float diagonal = first.W * second.W - Vector3.Dot(firstVector, secondVector);
        Vector3[] axes =
        {
            (firstVector * second.X + secondVector * first.X +
                new Vector3(diagonal, crossTerms.Z, -crossTerms.Y)) * 0.5f,
            (firstVector * second.Y + secondVector * first.Y +
                new Vector3(-crossTerms.Z, diagonal, crossTerms.X)) * 0.5f,
            (firstVector * second.Z + secondVector * first.Z +
                new Vector3(crossTerms.Y, -crossTerms.X, diagonal)) * 0.5f
        };
        Quaternion relative = Quaternion.Conjugate(first) * second;
        float[] errors = { -relative.X, -relative.Y, -relative.Z };
        for (int index = 0; index < axes.Length; index++)
        {
            rows.Add(new HelicopterRopeConstraintRow(frame,
                new HelicopterRopeJacobian(Vector3.Zero, axes[index], Vector3.Zero, axes[index]), errors[index]));
        }
    }

    private static void AddLimits(List<HelicopterRopeConstraintRow> rows, HelicopterRopeConstraintFrame frame,
        RotationPair rotations, HelicopterRopeAngularLimits limits)
    {
        Quaternion relative = Quaternion.Normalize(Quaternion.Conjugate(rotations.First) * rotations.Second);
        var twist = new Quaternion(relative.X, 0, 0, relative.W);
        twist = twist.LengthSquared() > 0 ? Quaternion.Normalize(twist) : Quaternion.Identity;
        Quaternion swing = Quaternion.Normalize(relative * Quaternion.Conjugate(twist));
        float twistAngle = 2f * MathF.Atan2(twist.X, twist.W);
        float lower = limits.MinimumX * MathF.PI / 180f;
        float upper = limits.MaximumX * MathF.PI / 180f;
        Vector3 axis = Vector3.Transform(Vector3.UnitX, rotations.First);
        if (twistAngle < lower)
        {
            AddLimit(rows, frame, -axis, twistAngle - lower);
        }
        if (twistAngle > upper)
        {
            AddLimit(rows, frame, axis, upper - twistAngle);
        }
        float swingLength = MathF.Sqrt(swing.Y * swing.Y + swing.Z * swing.Z);
        float swingAngle = 2f * MathF.Atan2(swingLength, MathF.Abs(swing.W));
        float coneAngle = limits.MaximumY * MathF.PI / 180f;
        if (swingAngle > coneAngle && swingLength > 0)
        {
            Vector3 localAxis = new(0, swing.Y / swingLength, swing.Z / swingLength);
            AddLimit(rows, frame, Vector3.Transform(localAxis, rotations.First), coneAngle - swingAngle);
        }
    }

    private static void AddLimit(List<HelicopterRopeConstraintRow> rows,
        HelicopterRopeConstraintFrame frame, Vector3 axis, float error)
    {
        HelicopterRopeConstraintRow limit = HelicopterRopeConstraintRow.CreateLimit(frame,
            new HelicopterRopeJacobian(Vector3.Zero, axis, Vector3.Zero, axis), error);
        foreach (HelicopterRopeConstraintRow equality in rows)
        {
            if (!equality.IsLimit)
            {
                limit.RemoveProjection(equality);
            }
        }
        rows.Add(limit);
    }

    private readonly record struct RotationPair(Quaternion First, Quaternion Second);
}
