using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares extension-command positions with direct recovered QuickRope2 calls.</summary>
internal static class HelicopterRopeExtensionTests
{
    private const string ReferenceDigest = "28132ffe6c3619d07f2c1156d4efa32f168f336a5e89e3e9a9db80f93f15cc2e";
    private const int ExpectedCaseCount = 8;
    private const float PositionTolerance = 0.000001f;

    internal static int Run(string directory)
    {
        string reference = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-extension-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new InvalidDataException("The source rope extension reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement root = document.RootElement;
        JsonElement[] cases = root.GetProperty("cases").EnumerateArray().ToArray();
        if (cases.Length != ExpectedCaseCount)
        {
            throw new Exception("Missing native rope extension cases.");
        }
        float spacing = root.GetProperty("jointSpacing").GetSingle();
        float deltaTime = root.GetProperty("deltaTime").GetSingle();
        foreach (JsonElement scenario in cases)
        {
            VerifyCase(scenario, spacing, deltaTime);
        }
        VerifyInvalidInputs();
        Console.WriteLine("PASS: eight native rope extension commands, strict insertion boundary and input guards");
        return ExpectedCaseCount * 3 + 8;
    }

    private static void VerifyCase(JsonElement scenario, float spacing, float deltaTime)
    {
        var head = new HelicopterRopeHead(Vector(scenario.GetProperty("anchor")),
            Vector(scenario.GetProperty("first")), Vector(scenario.GetProperty("second")));
        HelicopterRopeExtensionResult actual = HelicopterRopeExtension.Prepare(head, spacing, deltaTime);
        JsonElement inserted = scenario.GetProperty("inserted");
        bool hasInserted = inserted.ValueKind != JsonValueKind.Null;
        if (!scenario.GetProperty("anchorReconnected").GetBoolean() ||
            !scenario.GetProperty("firstIsDynamic").GetBoolean() ||
            scenario.GetProperty("jointCount").GetInt32() != (hasInserted ? 4 : 3))
        {
            throw new Exception("Native reference did not complete its source joint command.");
        }
        bool movedMatches = Vector3.Distance(actual.MovedFirst,
            Vector(scenario.GetProperty("movedFirst"))) <= PositionTolerance;
        bool insertionMatches = actual.InsertedPosition.HasValue == hasInserted;
        bool positionMatches = !hasInserted || actual.InsertedPosition is Vector3 position &&
            Vector3.Distance(position, Vector(inserted)) <= PositionTolerance;
        if (!movedMatches || !insertionMatches || !positionMatches)
        {
            throw new Exception("Host rope extension differs from native case " + scenario.GetProperty("name"));
        }
    }

    private static void VerifyInvalidInputs()
    {
        var head = new HelicopterRopeHead(Vector3.Zero, -Vector3.UnitY, -Vector3.UnitY * 2);
        foreach (float spacing in new[] { 0f, -1f, float.NaN, float.MaxValue })
        {
            RequireInvalid(() => HelicopterRopeExtension.Prepare(head, spacing, 1f / MatchManifest.TickRate));
        }
        foreach (float deltaTime in new[] { -1f, float.NaN, float.PositiveInfinity })
        {
            RequireInvalid(() => HelicopterRopeExtension.Prepare(head, 0.35f, deltaTime));
        }
        var invalidHead = head with { Anchor = new Vector3(float.NaN) };
        RequireInvalid(() => HelicopterRopeExtension.Prepare(invalidHead, 0.35f, 0));
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
            throw new Exception("Invalid rope input produced a valid extension command.");
        }
        catch (InvalidDataException)
        {
            // No repaired pose or spacing may authorize insertion.
        }
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }
}
