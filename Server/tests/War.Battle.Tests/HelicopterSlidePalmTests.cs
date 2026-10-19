using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks real slide-palm binding and its composition with the actual Unity rope reference.</summary>
internal static class HelicopterSlidePalmTests
{
    private const float PositionTolerance = 0.00002f;

    internal static int Run(string directory, EnemyPoseCatalog poses)
    {
        string path = Path.Combine(directory, "recovered-helicopter-slide-palm.json");
        HelicopterSlidePalmCatalog catalog = HelicopterSlidePalmCatalog.Load(path, poses);
        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));
        JsonElement root = document.RootElement;
        JsonElement reference = root.GetProperty("alignedReference");
        float[] rotation = reference.GetProperty("rootRotation").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        HelicopterDescentFrame frame = catalog.CreateSettledFrame(Vector(reference.GetProperty("rootPosition")),
            new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]), Vector3.UnitX);
        Vector3[] joints = reference.GetProperty("joints").EnumerateArray().Select(Vector).ToArray();
        var descent = new HelicopterDescentState(frame.RootPosition.Y, 0);
        HelicopterDescentResult result = descent.Advance(frame, 0.5f, joints);
        Require(Vector3.Distance(result.Position, Vector(reference.GetProperty("expected"))) < PositionTolerance,
            "The actual slide palm must reproduce the recovered Unity rope alignment.");
        Require(!catalog.HasConstantCurves && catalog.ClipLength > 0,
            "The source clip must not be silently promoted to a constant pose.");
        HelicopterDescentFrame local = catalog.CreateSettledFrame(Vector3.Zero, Quaternion.Identity, Vector3.UnitX);
        Require(Vector3.Distance(local.LeftPalmPosition, Vector(root.GetProperty("endPalm"))) < PositionTolerance,
            "The settled frame must retain the actual controller's left-palm binding.");
        RequireInvalid(() => catalog.CreateSettledFrame(Vector3.Zero, default, Vector3.UnitX));
        RequireInvalid(() => catalog.CreateSettledFrame(
            new Vector3(float.NaN), Quaternion.Identity, Vector3.UnitX));
        VerifyChangedBoneRejected(path, poses);
        Console.WriteLine("PASS: source slide palm, rotated world placement, Unity alignment and changed-bone rejection");
        return 6;
    }

    private static void VerifyChangedBoneRejected(string path, EnemyPoseCatalog poses)
    {
        string temporary = Path.GetTempFileName();
        try
        {
            File.WriteAllText(temporary, File.ReadAllText(path).Replace("cartoon_guyLArmPalm", "cartoon_guyRArmPalm"));
            RequireInvalid(() => HelicopterSlidePalmCatalog.Load(temporary, poses));
        }
        finally
        {
            File.Delete(temporary);
        }
    }

    private static Vector3 Vector(JsonElement vector)
    {
        float[] values = vector.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        return new Vector3(values[0], values[1], values[2]);
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
            throw new Exception("Invalid source slide palm was accepted.");
        }
        catch (InvalidDataException)
        {
            // A changed bone or invalid root cannot produce a trusted source frame.
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
