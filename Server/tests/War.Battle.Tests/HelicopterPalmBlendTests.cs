using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares local-chain blending against actual Unity samples rather than point interpolation.</summary>
internal static class HelicopterPalmBlendTests
{
    private const int ExpectedReferenceCount = 30;
    private const float PositionTolerance = 0.00003f;

    internal static int Run(string directory, EnemyPoseCatalog poses)
    {
        string path = Path.Combine(directory, "recovered-helicopter-palm-blend.json");
        HelicopterPalmBlendCatalog catalog = HelicopterPalmBlendCatalog.Load(path, poses);
        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));
        JsonElement root = document.RootElement;
        JsonElement[] references = root.GetProperty("references").EnumerateArray().ToArray();
        if (references.Length != ExpectedReferenceCount)
        {
            throw new Exception("The native palm blend reference is truncated.");
        }
        Vector3 position = Vector(root.GetProperty("worldRootPosition"));
        float[] rotationValues = root.GetProperty("worldRootRotation").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        var rotation = new Quaternion(rotationValues[0], rotationValues[1], rotationValues[2], rotationValues[3]);
        float maximumError = 0;
        foreach (JsonElement reference in references)
        {
            maximumError = MathF.Max(maximumError, VerifyReference(catalog, reference, position, rotation));
        }
        VerifyInvalidSelections(catalog);
        var selection = new HelicopterPalmBlendSelection(0, 0, 0.5f);
        RequireInvalid(() => catalog.CreateSampledFrame(selection, position, default, Vector3.UnitX));
        RequireInvalid(() => catalog.CreateSampledFrame(selection, new Vector3(float.NaN), rotation, Vector3.UnitX));
        Vector3 before = catalog.Sample(selection);
        catalog.Sample(new HelicopterPalmBlendSelection(catalog.IdleFrameCount - 1, catalog.SlideFrameCount - 1, 1));
        if (catalog.Sample(selection) != before)
        {
            throw new Exception("Sampling another blend changed the catalog's source frames.");
        }
        Console.WriteLine($"PASS: 30 actual Unity palm blends and world poses; maximum error {maximumError}");
        return ExpectedReferenceCount * 2 + 10;
    }

    private static float VerifyReference(HelicopterPalmBlendCatalog catalog, JsonElement reference,
        Vector3 position, Quaternion rotation)
    {
        var selection = new HelicopterPalmBlendSelection(reference.GetProperty("idleFrame").GetInt32(),
            reference.GetProperty("slideFrame").GetInt32(), reference.GetProperty("weight").GetSingle());
        float localError = Vector3.Distance(catalog.Sample(selection), Vector(reference.GetProperty("palm")));
        HelicopterDescentFrame frame = catalog.CreateSampledFrame(selection, position, rotation, Vector3.UnitX);
        float worldError = Vector3.Distance(frame.LeftPalmPosition, Vector(reference.GetProperty("worldPalm")));
        float error = MathF.Max(localError, worldError);
        if (error > PositionTolerance)
        {
            throw new Exception($"Host palm blend differs from Unity by {error} at {selection}.");
        }
        return error;
    }

    private static void VerifyInvalidSelections(HelicopterPalmBlendCatalog catalog)
    {
        foreach (HelicopterPalmBlendSelection invalid in new[]
        {
            new HelicopterPalmBlendSelection(-1, 0, 0),
            new HelicopterPalmBlendSelection(catalog.IdleFrameCount, 0, 0),
            new HelicopterPalmBlendSelection(0, catalog.SlideFrameCount, 0),
            new HelicopterPalmBlendSelection(0, 0, float.NaN),
            new HelicopterPalmBlendSelection(0, 0, -1),
            new HelicopterPalmBlendSelection(0, 0, 2)
        })
        {
            RequireInvalid(() => catalog.Sample(invalid));
        }
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
            throw new Exception("An unknown frame or malformed palm blend weight was accepted.");
        }
        catch (InvalidDataException)
        {
            // No implicit frame wrapping, weight repair or invented pose is allowed.
        }
    }

    private static Vector3 Vector(JsonElement vector)
    {
        float[] values = vector.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        return new Vector3(values[0], values[1], values[2]);
    }
}
