using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Loads a real Worker UDP checkpoint and compares .NET and Unity Mono reconstruction.</summary>
public static class UnityMortarCheckpointSdkAudit
{
    private const float Tolerance = 0.00001f;
    private const ulong ForwardFrames = 5;

    public static void Run()
    {
        try
        {
            string directory = Environment.GetEnvironmentVariable("WAR_MORTAR_WARNING_FIXTURE");
            if (string.IsNullOrEmpty(directory))
            {
                throw new InvalidOperationException("A real Worker warning fixture directory is required.");
            }
            BattleMortarWarningState received = BattleMortarWarningState.Parser.ParseFrom(
                File.ReadAllBytes(Path.Combine(directory, "mortar-warning.pb")));
            BattleMortarWarningState expected = BattleMortarWarningState.Parser.ParseFrom(
                File.ReadAllBytes(Path.Combine(directory, "mortar-warning-future.pb")));
            float derivedSpeed = 1f / (received.StopSeconds - 0.3f);
            Debug.Log("Mortar checkpoint diagnostic: storedRate=" + received.Clock.ShrinkSpeed.ToString("R") +
                ", derivedRate=" + derivedSpeed.ToString("R") + ", equal=" + (derivedSpeed == received.Clock.ShrinkSpeed) +
                ", storedBits=" + BitConverter.ToInt32(BitConverter.GetBytes(received.Clock.ShrinkSpeed), 0) +
                ", derivedBits=" + BitConverter.ToInt32(BitConverter.GetBytes(derivedSpeed), 0) +
                ", rotationEqual=" + (received.RotationFactor == received.Clock.RotationFactor) +
                ", scaleEqual=" + (received.Scale == received.Clock.Scale) +
                ", alphaEqual=" + (received.Alpha == received.Clock.Alpha));
            MortarWarningPolicy.Validate(new[] { received }, received.ObservedTick, received.ObserverFraction);
            BattleMortarWarningState damaged = received.Clone();
            damaged.Clock.ShrinkSpeed += 0.001f;
            bool rejected = false;
            try
            {
                MortarWarningPolicy.Validate(new[] { damaged }, damaged.ObservedTick, damaged.ObserverFraction);
            }
            catch (InvalidOperationException)
            {
                rejected = true;
            }
            Require(rejected, "The binary32 compatibility fix accepted an altered source rate.");
            Require(received.Clock != null && received.Clock.HasBegun && received.Clock.Visible,
                "Unity did not decode the complete live UDP checkpoint.");
            BattleMortarWarningState projected = MortarWarningReconstruction.AtTick(received,
                received.ObservedTick + ForwardFrames);
            Require(projected != null && projected.EntityKey == expected.EntityKey &&
                projected.ProjectileId == expected.ProjectileId && projected.WeaponSlot == expected.WeaponSlot &&
                projected.ObserverFraction == expected.ObserverFraction && projected.ObservedTick == expected.ObservedTick,
                "Unity changed frozen warning authority during reconstruction.");
            Require(Math.Abs(projected.Scale - expected.Scale) < Tolerance &&
                Math.Abs(projected.Alpha - expected.Alpha) < Tolerance &&
                Math.Abs(projected.RotationFactor - expected.RotationFactor) < Tolerance,
                "Unity Mono disagrees with .NET warning samples.");
            Require(projected.Clock.HasBlinkStarted == expected.Clock.HasBlinkStarted &&
                projected.Clock.SkipReactivationFrame == expected.Clock.SkipReactivationFrame &&
                projected.Clock.Shrinking == expected.Clock.Shrinking &&
                projected.Clock.Blinking == expected.Clock.Blinking &&
                projected.Clock.BlinkBoundaryCount == expected.Clock.BlinkBoundaryCount &&
                projected.Clock.BlinkSpeed == expected.Clock.BlinkSpeed,
                "Unity lost checkpoint startup, direction or boundary history.");
            ulong expiry = received.ObservedTick + (ulong)Math.Ceiling((received.StopSeconds + 1f) * 30f);
            Require(MortarWarningReconstruction.AtTick(received, expiry) == null,
                "Unity retained the live warning after its source hide boundary.");
            File.WriteAllText(Path.Combine(Application.dataPath, "../mortar-checkpoint-sdk-audit.json"),
                "{\"checks\":6,\"scope\":\"real UDP checkpoint decoded and reconstructed by Unity Mono\"}\n");
            Debug.Log("PASS: 6 Unity Mono live Mortar checkpoint SDK checks; no rendered warning acceptance.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
