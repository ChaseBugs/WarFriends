using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks enabled, disabled and resumed mixer state against actual Unity observations.</summary>
internal static class HelicopterSlideMixerTests
{
    private const float ClockTolerance = 0.0000002f;
    private sealed record Reference(string Filename, string Digest, bool HasVisibility);

    internal static int Run(string directory)
    {
        var references = new[]
        {
            new Reference("recovered-helicopter-fade-unity-reference.json",
                "0a9f8eae7a74d4d7353af3e411055ab7f73537fa4184e88790553090b9ea161c", false),
            new Reference("recovered-helicopter-fade-visibility-unity-reference.json",
                "4659dcd8e160092abfd4aec09a9d4e7ab3e72327329dc44eb10eaa718b8209c2", true),
        };
        int checks = VerifyLifecycle();
        foreach (Reference reference in references)
        {
            checks += VerifyCapture(directory, reference);
        }
        return checks;
    }

    private static int VerifyLifecycle()
    {
        var state = new HelicopterSlideMixerState(0.5f);
        HelicopterSlideMixerSnapshot initial = state.Current;
        for (int frame = 0; frame < 4; frame++)
        {
            HelicopterSlideMixerSnapshot disabled = state.AdvanceDisabledFrame();
            if (disabled.Layers != initial.Layers || disabled.IsAnimationEnabled ||
                disabled.RenderFrames != (ulong)(frame + 1) || disabled.EvaluatedFrames != 0)
            {
                throw new Exception("Disabled mixer advanced evaluation or lost its retained layers.");
            }
        }

        HelicopterSlideMixerSnapshot resumed = state.AdvanceEnabledFrame();
        if (!resumed.IsAnimationEnabled || resumed.RenderFrames != 5 || resumed.EvaluatedFrames != 1)
        {
            throw new Exception("Resumed mixer replayed hidden frames instead of evaluating once.");
        }

        float[] invalidPhases = { float.NaN, float.PositiveInfinity, float.NegativeInfinity, -0.1f, 1f };
        foreach (float phase in invalidPhases)
        {
            try
            {
                _ = new HelicopterSlideMixerState(phase);
            }
            catch (InvalidDataException)
            {
                continue;
            }
            throw new Exception("Mixer accepted a phase outside its captured source domain.");
        }
        return 10;
    }

    private static int VerifyCapture(string directory, Reference reference)
    {
        string text = File.ReadAllText(Path.Combine(directory, reference.Filename)).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) != reference.Digest)
        {
            throw new Exception("Slide mixer reference changed.");
        }
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement frames = document.RootElement.GetProperty("frames");
        if (frames.GetArrayLength() != 16)
        {
            throw new Exception("Slide mixer reference lost its frame coverage.");
        }
        for (int scenario = 0; scenario < 3; scenario++)
        {
            VerifyScenario(frames, scenario, reference.HasVisibility);
        }
        Console.WriteLine($"PASS: source mixer clocks/flags and component visibility: {reference.Filename}.");
        return 16 * 3 * 5;
    }

    private static void VerifyScenario(JsonElement frames, int scenario, bool hasVisibility)
    {
        float phase = frames[0].GetProperty("scenarios")[scenario].GetProperty("idlePhase").GetSingle();
        var state = new HelicopterSlideMixerState(phase);
        Vector3 previousPalm = default;
        for (int index = 0; index < frames.GetArrayLength(); index++)
        {
            JsonElement row = frames[index].GetProperty("scenarios")[scenario];
            bool isEnabled = !hasVisibility || row.GetProperty("componentEnabled").GetBoolean();
            if (index > 0)
            {
                _ = isEnabled ? state.AdvanceEnabledFrame() : state.AdvanceDisabledFrame();
            }
            if (hasVisibility && scenario == 0 && index is 2 or 7 or 8 or 9)
            {
                Console.WriteLine($"Visibility mixer frame {index}: {state.Current.Layers}.");
            }
            VerifyLayer(state.Current.Layers.Idle, row, "idle");
            VerifyLayer(state.Current.Layers.Slide, row, "helicopter_jump_pose");
            JsonElement palm = row.GetProperty("palm");
            var position = new Vector3(palm[0].GetSingle(), palm[1].GetSingle(), palm[2].GetSingle());
            if (state.Current.IsAnimationEnabled != isEnabled || (!isEnabled && position != previousPalm))
            {
                throw new Exception("Disabled source animation changed its component flag or sampled local pose.");
            }
            previousPalm = position;
        }
    }

    private static void VerifyLayer(HelicopterFadeLayer actual, JsonElement row, string name)
    {
        JsonElement expected = row.GetProperty("states").EnumerateArray()
            .Single(layer => layer.GetProperty("name").GetString() == name);
        if (MathF.Abs(actual.RawTime - expected.GetProperty("time").GetSingle()) > ClockTolerance ||
            MathF.Abs(actual.Weight - expected.GetProperty("weight").GetSingle()) > ClockTolerance ||
            actual.IsEnabled != expected.GetProperty("enabled").GetBoolean() ||
            expected.GetProperty("speed").GetSingle() != 1 || expected.GetProperty("layer").GetInt32() != 0 ||
            expected.GetProperty("blendMode").GetString() != "Blend")
        {
            throw new Exception($"Slide mixer {name} state differs: actual {actual}, expected {expected}.");
        }
    }
}
