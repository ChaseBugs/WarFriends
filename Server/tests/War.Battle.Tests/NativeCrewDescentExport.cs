using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Exports actual native joint publications for replay through the original Unity descent method.</summary>
internal static class NativeCrewDescentExport
{
    internal static void Write(string directory, string output)
    {
        HelicopterRopeDefinition definition = HelicopterRopeDefinition.Load(
            Path.Combine(directory, "recovered-helicopter-rope-definition.json"));
        var aircraft = new HelicopterRopeBodyPose(new Vector3(0, 10, 0), Quaternion.Identity);
        using var world = new NativeHelicopterPhysicsWorld();
        HelicopterPhysicsLease lease = world.Add(1, definition.CreateInitial(aircraft), aircraft,
            definition.CreationRestRotation);
        world.BeginExtension(lease, 0);
        var frames = new List<object> { Frame(world.Snapshot(), aircraft) };
        for (int index = 1; index < 16; index++)
        {
            aircraft = new HelicopterRopeBodyPose(new Vector3(index * 0.03f, 10, index * 0.01f),
                Quaternion.CreateFromAxisAngle(Vector3.UnitY, index * 0.01f));
            HelicopterPhysicsWorldSnapshot snapshot = world.AdvanceFrame(1f / MatchManifest.TickRate,
                new[] { new HelicopterPhysicsRenderInput(lease, aircraft) }, HelicopterPhysicsMode.Normal);
            frames.Add(Frame(snapshot, aircraft));
        }
        string text = JsonSerializer.Serialize(new
        {
            version = 1, backend = "PhysX 3.4 native", captureRate = MatchManifest.TickRate,
            fixture = "Source rope definition, floor extension, translating/yawing aircraft; " +
                "no Unity solver parity claim.",
            frames
        }, new JsonSerializerOptions { WriteIndented = true }) + "\n";
        File.WriteAllText(output, text.Replace("\r\n", "\n"));
        Console.WriteLine("PASS: exported 16 actual native crew descent input publications.");
    }

    private static object Frame(HelicopterPhysicsWorldSnapshot snapshot, HelicopterRopeBodyPose aircraft)
    {
        HelicopterPhysicsMemberSnapshot member = snapshot.Members.Single();
        return new
        {
            renderFrame = snapshot.RenderFrames, physicsStep = snapshot.PhysicsSteps,
            helicopterRight = Values(Vector3.Transform(Vector3.UnitX, aircraft.Rotation)),
            joints = member.Bodies.Select(body => Values(body.Pose.Position)).ToArray()
        };
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.X, value.Y, value.Z };
    }
}
