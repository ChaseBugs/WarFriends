using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Preserves source reset/control order and exact widened viewport comparisons.</summary>
internal static class SoldierAnimationVisibilityTests
{
    private const string ReferenceDigest = "134a96ee59e081aaf076f16f1106a11546b48bcff98291e96403702d98f9a16d";

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-soldier-animation-reset-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Animation reset reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement rows = document.RootElement.GetProperty("rows");
        Require(rows.GetArrayLength() == 27, "Animation reset reference lost its lifecycle coverage.");
        var state = new SoldierAnimationVisibilityState();
        foreach (JsonElement row in rows.EnumerateArray())
        {
            Replay(state, row);
            Require(state.IsAnimationEnabled == row.GetProperty("enabled").GetBoolean() &&
                state.IsInScreen == row.GetProperty("inScreen").GetBoolean() &&
                state.IsForced == row.GetProperty("forced").GetBoolean(),
                "Animation reset/visibility ordering differs from the actual source controller.");
            string expectedCulling = state.IsForced ? "AlwaysAnimate" : "BasedOnRenderers";
            Require(row.GetProperty("culling").GetString() == expectedCulling,
                "Reset/force source culling mode changed.");
        }
        VerifyBoundaries();
        Console.WriteLine("PASS: 27 source animation reset/visibility steps and exact float viewport boundaries.");
        return 114;
    }

    private static void Replay(SoldierAnimationVisibilityState state, JsonElement row)
    {
        JsonElement position = row.GetProperty("viewport");
        var viewport = new Vector2(position[0].GetSingle(), position[1].GetSingle());
        switch (row.GetProperty("operation").GetString())
        {
            case "OnEnable":
                state.ReactivateComponent(viewport);
                break;
            case "Reset":
                state.Reset(viewport);
                break;
            case "CheckIfInScreen":
                state.CheckScreen(viewport);
                break;
            case "ForceInScreen":
                state.ForceInScreen();
                break;
            case "Pause":
                state.Pause();
                break;
            case "Resume":
                state.Resume();
                break;
            case "Stop":
                state.Stop();
                break;
            default:
                throw new Exception("Unsupported source visibility operation.");
        }
    }

    private static void VerifyBoundaries()
    {
        var state = new SoldierAnimationVisibilityState();
        state.Reset(new Vector2(0.5f));
        state.CheckScreen(new Vector2(-0.1f, 0.5f));
        Require(!state.IsAnimationEnabled, "Float -0.1 widens below the source double threshold.");
        state.CheckScreen(new Vector2(MathF.BitIncrement(-0.1f), 0.5f));
        Require(state.IsAnimationEnabled, "The adjacent inner float must remain in screen.");
        state.CheckScreen(new Vector2(1.1f, 0.5f));
        Require(!state.IsAnimationEnabled, "Float 1.1 widens above the source double threshold.");
        state.CheckScreen(new Vector2(MathF.BitDecrement(1.1f), 0.5f));
        Require(state.IsAnimationEnabled, "The adjacent upper inner float must remain in screen.");
        state.ForceInScreen();
        Reject(() => state.Reset(new Vector2(float.NaN)), state);
        Reject(() => state.CheckScreen(new Vector2(float.PositiveInfinity)), state);
    }

    private static void Reject(Action action, SoldierAnimationVisibilityState state)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            Require(state.IsForced && state.IsInScreen && state.IsAnimationEnabled,
                "Rejected viewport input changed retained source visibility state.");
            return;
        }
        throw new Exception("Visibility accepted a malformed viewport projection.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
