using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks source RopeSlide commands during zero, partial and completed initial Idle fades.</summary>
internal static class IdleToSlideMixerTests
{
    private const string ReferenceDigest = "057da06e2d77ad8d10e7dfa03020ae05f63cf6aa1f0e2a385b67471e63a707b0";
    private const string VisibilityDigest = "e1b0f1532531da3a61d272c2675158681f684c1f5b52bd913681154529ecebdb";
    private const float ClockTolerance = 0.0000002f;

    internal static int Run(string directory)
    {
        int checks = VerifyCapture(directory, "recovered-idle-to-slide-unity-reference.json", ReferenceDigest);
        checks += VerifyCapture(directory, "recovered-idle-to-slide-visibility-unity-reference.json", VisibilityDigest);
        VerifyRejectedStarts();
        return checks + 5;
    }

    private static int VerifyCapture(string directory, string filename, string digest)
    {
        string text = File.ReadAllText(Path.Combine(directory, filename)).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == digest,
            "Idle-to-slide source reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement root = document.RootElement;
        JsonElement frames = root.GetProperty("frames");
        JsonElement commands = root.GetProperty("commands");
        Require(root.GetProperty("idleToSlideProbe").GetBoolean() && frames.GetArrayLength() == 37 &&
            commands.GetArrayLength() == 3, "Idle-to-slide capture lost command or frame coverage.");
        foreach (JsonElement command in commands.EnumerateArray())
        {
            VerifyScenario(frames, command);
        }
        Console.WriteLine($"PASS: 111 original Reset/Idle/RopeSlide snapshots: {filename}.");
        return 37 * 3 * 4;
    }

    private static void VerifyScenario(JsonElement frames, JsonElement command)
    {
        int scenario = command.GetProperty("scenario").GetInt32();
        int afterSample = command.GetProperty("afterSample").GetInt32();
        HelicopterSlideFadeSnapshot before = Layers(command.GetProperty("before"));
        HelicopterSlideFadeSnapshot after = Layers(command.GetProperty("after"));
        Require(after.Idle == before.Idle && after.Slide == (before.Slide with { IsEnabled = true }),
            "Source RopeSlide did not preserve its observed layer clocks/weights at the command boundary.");
        HelicopterSlideMixerState? state = null;
        for (int index = 0; index < frames.GetArrayLength(); index++)
        {
            JsonElement row = frames[index].GetProperty("scenarios")[scenario];
            bool isEnabled = row.GetProperty("componentEnabled").GetBoolean();
            HelicopterSlideFadeSnapshot expected;
            if (index <= afterSample)
            {
                SoldierResetIdleSnapshot idle = SoldierResetIdleMixer.AtFixedTicks((ulong)index);
                expected = new HelicopterSlideFadeSnapshot(idle.Idle, idle.StoppedSlide);
            }
            else
            {
                state ??= HelicopterSlideMixerState.FromObservedTransition(after);
                if (index > 0)
                {
                    if (isEnabled)
                    {
                        state.AdvanceEnabledFrame();
                    }
                    else
                    {
                        state.AdvanceDisabledFrame();
                    }
                }
                Require(state.Current.IsAnimationEnabled == isEnabled, "Source component visibility differs.");
                expected = state.Current.Layers;
            }
            VerifyLayer(expected.Idle, Layer(row.GetProperty("states"), "idle"));
            VerifyLayer(expected.Slide, Layer(row.GetProperty("states"), "helicopter_jump_pose"));
        }
    }

    private static void VerifyRejectedStarts()
    {
        var valid = new HelicopterSlideFadeSnapshot(new HelicopterFadeLayer(0, 0.5f, true),
            new HelicopterFadeLayer(0, 1, true));
        HelicopterSlideFadeSnapshot[] invalid =
        {
            valid with { Idle = valid.Idle with { Weight = float.NaN } },
            valid with { Idle = valid.Idle with { RawTime = -1 } },
            valid with { Slide = valid.Slide with { Weight = 0.5f } },
            valid with { Slide = valid.Slide with { RawTime = 0.1f } },
            valid with { Slide = valid.Slide with { IsEnabled = false } },
        };
        foreach (HelicopterSlideFadeSnapshot initial in invalid)
        {
            try
            {
                HelicopterSlideMixerState.FromObservedTransition(initial);
            }
            catch (InvalidDataException)
            {
                continue;
            }
            throw new Exception("Slide mixer accepted a malformed or unobserved transition start.");
        }
    }

    private static HelicopterSlideFadeSnapshot Layers(JsonElement layers)
    {
        return new HelicopterSlideFadeSnapshot(Layer(layers, "idle"), Layer(layers, "helicopter_jump_pose"));
    }

    private static HelicopterFadeLayer Layer(JsonElement layers, string name)
    {
        JsonElement layer = layers.EnumerateArray().Single(row => row.GetProperty("name").GetString() == name);
        return new HelicopterFadeLayer(layer.GetProperty("time").GetSingle(),
            layer.GetProperty("weight").GetSingle(), layer.GetProperty("enabled").GetBoolean());
    }

    private static void VerifyLayer(HelicopterFadeLayer actual, HelicopterFadeLayer expected)
    {
        Require(actual.IsEnabled == expected.IsEnabled &&
            MathF.Abs(actual.Weight - expected.Weight) <= ClockTolerance &&
            MathF.Abs(actual.RawTime - expected.RawTime) <= ClockTolerance,
            $"Idle-to-slide layer differs: {actual}, expected {expected}.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
