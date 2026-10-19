using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares realized active Unity joint anchors with prepared local/world frames.</summary>
internal static class HelicopterRopeConstraintFrameTests
{
    private const string ReferenceDigest = "e87743347ee3fa3d7cb75ced89ab8e4d756e853b86e9751c77e3ec421ac4fc11";
    private const int ExpectedCases = 3;
    private const int ConstraintsPerCase = 4;
    private const float PositionTolerance = 0.000003f;
    private const float RotationTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        string reference = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-physics-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new InvalidDataException("The active native rope reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement[] cases = document.RootElement.GetProperty("initial").EnumerateArray().ToArray();
        if (cases.Length != ExpectedCases)
        {
            throw new Exception("Active native rope frame cases are incomplete.");
        }
        foreach (JsonElement scenario in cases)
        {
            VerifyCase(scenario);
        }
        VerifyInvalidInputs();
        Console.WriteLine(
            "PASS: 12 active native rope anchors, activation rest frames and malformed setup guards");
        return ExpectedCases * (1 + ConstraintsPerCase * 6) + 10;
    }

    private static void VerifyCase(JsonElement scenario)
    {
        JsonElement[] native = scenario.GetProperty("joints").EnumerateArray().ToArray();
        var initial = HelicopterRopeInitialization.Create(Vector(native[0].GetProperty("position")),
            Vector(native[^1].GetProperty("position")), scenario.GetProperty("requestedSpacing").GetSingle());
        JsonElement attachment = scenario.GetProperty("attachment");
        HelicopterRopeBodyPose aircraft = ConnectedPose(attachment);
        Quaternion activationRest = Rotation(scenario.GetProperty("attachmentConnectedRestRotation"));
        HelicopterRopeConstraintSetup setup = HelicopterRopeConstraintFrames.Create(initial, aircraft, activationRest);
        if (initial.Joints.Count != ConstraintsPerCase || setup.Links.Count != ConstraintsPerCase - 1 ||
            MathF.Abs(initial.InitialJointDistance - scenario.GetProperty("initialDistance").GetSingle()) >
                PositionTolerance)
        {
            throw new Exception("Active source rope topology or measured spacing differs from the prepared setup.");
        }
        VerifyIdentity(setup.Attachment, 0, HelicopterRopeConstraintFrames.AircraftBodyIndex);
        VerifyFrame(setup.Attachment, attachment, Pose(native[0]),
            Quaternion.Normalize(aircraft.Rotation * activationRest));
        for (int index = 0; index < setup.Links.Count; index++)
        {
            if (native[index].GetProperty("configurableJointCount").GetInt32() != 1)
            {
                throw new Exception("Deferred source joint destruction was not completed before capture.");
            }
            VerifyIdentity(setup.Links[index], index, index + 1);
            VerifyFrame(setup.Links[index], native[index].GetProperty("connection"), Pose(native[index]),
                Pose(native[index]).Rotation);
        }
    }

    private static void VerifyIdentity(HelicopterRopeConstraintFrame frame, int body, int connected)
    {
        if (frame.BodyIndex != body || frame.ConnectedBodyIndex != connected)
        {
            throw new Exception("Prepared rope constraint changed its body ownership.");
        }
    }

    private static void VerifyFrame(HelicopterRopeConstraintFrame frame, JsonElement native,
        HelicopterRopeBodyPose owner, Quaternion expectedWorldRest)
    {
        HelicopterRopeBodyPose connected = ConnectedPose(native);
        RequirePosition(frame.BodyFrame.Position, Vector(native.GetProperty("anchor")));
        RequirePosition(frame.ConnectedFrame.Position, Vector(native.GetProperty("connectedAnchor")));
        Vector3 bodyWorld = owner.Position + Vector3.Transform(frame.BodyFrame.Position, owner.Rotation);
        Vector3 connectedWorld = connected.Position +
            Vector3.Transform(frame.ConnectedFrame.Position, connected.Rotation);
        RequirePosition(bodyWorld, connectedWorld);
        Quaternion connectedRotation = Quaternion.Normalize(connected.Rotation * frame.ConnectedFrame.Rotation);
        float rotationError = MathF.Min((expectedWorldRest - connectedRotation).Length(),
            (expectedWorldRest + connectedRotation).Length());
        if (!float.IsFinite(rotationError) || rotationError > RotationTolerance ||
            !native.GetProperty("autoConfigureConnectedAnchor").GetBoolean())
        {
            throw new Exception(
                "Prepared rest frames do not agree in world space or source automatic anchors changed.");
        }
    }

    private static void RequirePosition(Vector3 actual, Vector3 expected)
    {
        float error = Vector3.Distance(actual, expected);
        if (!float.IsFinite(error) || error > PositionTolerance)
        {
            throw new Exception($"Prepared rope joint frame differs from active Unity by {error}.");
        }
    }

    private static void VerifyInvalidInputs()
    {
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            Vector3.Zero, -Vector3.UnitY, 0.35f);
        var aircraft = new HelicopterRopeBodyPose(Vector3.Zero, Quaternion.Identity);
        Quaternion rest = initial.Joints[0].Rotation;
        RequireInvalid(() => HelicopterRopeConstraintFrames.Create(initial, aircraft, default));
        RequireInvalid(() => HelicopterRopeConstraintFrames.Create(
            initial, aircraft with { Rotation = default }, rest));
        RequireInvalid(() => HelicopterRopeConstraintFrames.Create(
            initial, aircraft with { Position = new Vector3(float.NaN) }, rest));
        RequireInvalid(() => HelicopterRopeConstraintFrames.Create(
            initial with { InitialJointDistance = 0.35f }, aircraft, rest));
        RequireInvalid(() => HelicopterRopeConstraintFrames.Create(
            initial with { InitialJointDistance = float.NaN }, aircraft, rest));
        HelicopterRopeInitialJoint first = initial.Joints[0];
        HelicopterRopeConnectionSetup connection = first.Connection ?? throw new Exception("Missing test source link.");
        RequireBadFirst(initial, first with { Rotation = default }, aircraft);
        RequireBadFirst(initial, first with { Body = first.Body with { Mass = float.NaN } }, aircraft);
        RequireBadFirst(initial, first with { Connection = connection with { ConnectedJointIndex = 0 } }, aircraft);
        RequireBadFirst(initial, first with { Connection = connection with
        {
            AngularLimits = connection.AngularLimits with { MaximumY = float.NaN }
        } }, aircraft);
        HelicopterRopeConstraintSetup result = HelicopterRopeConstraintFrames.Create(initial, aircraft, rest);
        if (result.Links is not IList<HelicopterRopeConstraintFrame> links || !links.IsReadOnly)
        {
            throw new Exception("Prepared rope link frames expose mutable sequence ownership.");
        }
    }

    private static void RequireBadFirst(HelicopterRopeInitialState initial, HelicopterRopeInitialJoint replacement,
        HelicopterRopeBodyPose aircraft)
    {
        HelicopterRopeInitialJoint[] joints = initial.Joints.ToArray();
        joints[0] = replacement;
        RequireInvalid(() => HelicopterRopeConstraintFrames.Create(
            initial with { Joints = joints }, aircraft, initial.Joints[0].Rotation));
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
            throw new Exception("An invalid rope setup produced a physical constraint plan.");
        }
        catch (InvalidDataException)
        {
            // Never repair a malformed pose or retarget a damaged link into a valid body identity.
        }
    }

    private static HelicopterRopeBodyPose ConnectedPose(JsonElement connection)
    {
        return new HelicopterRopeBodyPose(Vector(connection.GetProperty("connectedPosition")),
            Rotation(connection.GetProperty("connectedRotation")));
    }

    private static HelicopterRopeBodyPose Pose(JsonElement body)
    {
        return new HelicopterRopeBodyPose(Vector(body.GetProperty("position")), Rotation(body.GetProperty("rotation")));
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }
}
