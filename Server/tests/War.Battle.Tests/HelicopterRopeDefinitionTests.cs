using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks prefab-defined rope anchors against independent Unity initialization captures.</summary>
internal static class HelicopterRopeDefinitionTests
{
    private const float PositionTolerance = 0.00002f;

    internal static int Run(string directory)
    {
        HelicopterRopeDefinition definition = HelicopterRopeDefinition.Load(
            Path.Combine(directory, "recovered-helicopter-rope-definition.json"));
        using JsonDocument capture = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-helicopter-rope-physics-unity-reference.json")));
        int checks = 0;
        foreach (JsonElement scenario in capture.RootElement.GetProperty("initial").EnumerateArray())
        {
            JsonElement attachment = scenario.GetProperty("attachment");
            var aircraft = new HelicopterRopeBodyPose(Vector(attachment.GetProperty("connectedPosition")),
                Rotation(attachment.GetProperty("connectedRotation")));
            HelicopterRopeInitialState initial = definition.CreateInitial(aircraft);
            JsonElement joints = scenario.GetProperty("joints");
            if (initial.Joints.Count != joints.GetArrayLength() ||
                Vector3.Distance(definition.RootPositionAt(aircraft), Vector(joints[0].GetProperty("position"))) >
                    PositionTolerance ||
                Quaternion.Dot(definition.CreationRestRotation,
                    Rotation(scenario.GetProperty("attachmentConnectedRestRotation"))) < 0.99999f)
            {
                throw new Exception("Actual prefab rope identity differs from captured Unity initialization.");
            }
            for (int index = 0; index < initial.Joints.Count; index++)
            {
                if (Vector3.Distance(initial.Joints[index].Position, Vector(joints[index].GetProperty("position"))) >
                    PositionTolerance)
                {
                    throw new Exception("Prefab rope initialization moved a captured source joint.");
                }
                checks++;
            }
            checks++;
        }
        return checks;
    }

    private static Vector3 Vector(JsonElement point)
    {
        return new Vector3(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement point)
    {
        return new Quaternion(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle(), point[3].GetSingle());
    }
}
