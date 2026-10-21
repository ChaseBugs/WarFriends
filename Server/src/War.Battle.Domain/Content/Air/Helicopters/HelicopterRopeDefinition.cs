using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Actual source QuickRope root/end; the crew alignment marker is a different Transform.</summary>
internal sealed class HelicopterRopeDefinition
{
    private const string ArtifactDigest = "8b1e4872243ad6aa489227fd080f5cfb73bf40145245d7caeb4f2d95fd9697ec";
    private const int MaximumArtifactBytes = 4096;

    private HelicopterRopeDefinition(Vector3 root, Vector3 end, Quaternion rotation, float spacing)
    {
        RootPosition = root;
        EndPosition = end;
        CreationRestRotation = rotation;
        JointSpacing = spacing;
    }

    internal Vector3 RootPosition { get; }
    internal Vector3 EndPosition { get; }
    internal Quaternion CreationRestRotation { get; }
    internal float JointSpacing { get; }

    internal static HelicopterRopeDefinition Load(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length is <= 0 or > MaximumArtifactBytes ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != ArtifactDigest)
        {
            throw new InvalidDataException("Helicopter rope definition differs from the source-bound artifact.");
        }
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        Vector3 position = Point(root.GetProperty("rootPosition"));
        Vector3 end = Point(root.GetProperty("endPosition"));
        JsonElement row = root.GetProperty("rootRotation");
        var rotation = new Quaternion(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle(), row[3].GetSingle());
        HelicopterAircraftPosePolicy.Validate(new HelicopterRopeBodyPose(position, rotation));
        return new HelicopterRopeDefinition(position, end, rotation, root.GetProperty("jointSpacing").GetSingle());
    }

    internal Vector3 RootPositionAt(HelicopterRopeBodyPose aircraft)
    {
        HelicopterAircraftPosePolicy.Validate(aircraft);
        Vector3 position = aircraft.Position + Vector3.Transform(RootPosition, aircraft.Rotation);
        if (!PlayerHitbox.Finite(position))
        {
            throw new InvalidDataException("Helicopter rope root exceeds bounded world coordinates.");
        }
        return position;
    }

    internal HelicopterRopeInitialState CreateInitial(HelicopterRopeBodyPose aircraft)
    {
        Vector3 root = RootPositionAt(aircraft);
        Vector3 end = aircraft.Position + Vector3.Transform(EndPosition, aircraft.Rotation);
        return HelicopterRopeInitialization.Create(root, end, JointSpacing);
    }

    private static Vector3 Point(JsonElement row)
    {
        var point = new Vector3(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle());
        if (!PlayerHitbox.Finite(point))
        {
            throw new InvalidDataException("Helicopter rope definition has invalid coordinates.");
        }
        return point;
    }
}
