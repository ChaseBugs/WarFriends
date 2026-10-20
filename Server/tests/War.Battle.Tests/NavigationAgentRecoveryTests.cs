using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares the server recovery prelude with the extracted expression evaluated by Unity math.</summary>
internal static class NavigationAgentRecoveryTests
{
    internal static int Run(string directory)
    {
        string path = Path.Combine(directory, "recovered-navigation-agent-recovery-unity-reference.json");
        byte[] bytes = File.ReadAllBytes(path);
        string digest = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
        if (digest != "51999625ea340a18e2570fc2f4c93a01b820f6b7a42ea456609b5f143486c90d")
        {
            throw new Exception("Unity recovery reference changed without review.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        if (root.GetProperty("_cases").GetArrayLength() != 16 ||
            root.GetProperty("_version").GetInt32() != 1 ||
            root.GetProperty("_sourceSha256").GetString() !=
                "4cad6f1a7f11f5323363ec0064b6b1e4f9c01a57f655da74f45e70c8f62830d5")
        {
            throw new Exception("Unity recovery reference has unexpected source provenance or coverage.");
        }
        string[] operations = root.GetProperty("_operations").EnumerateArray()
            .Select(value => value.GetString()!).ToArray();
        int assertions = 1;
        var identities = new HashSet<string>();
        foreach (JsonElement probe in root.GetProperty("_cases").EnumerateArray())
        {
            if (!identities.Add(probe.GetProperty("_id").GetString()!))
            {
                throw new Exception("Duplicate Unity recovery probe.");
            }
            var state = new NavigationAgentRecoveryState();
            NavigationAgentRecoveryState.Observation observation = Read(probe);
            NavigationAgentRecoveryState.Recovery? recovery = state.Observe(observation);
            if ((recovery != null) != probe.GetProperty("_shouldRecover").GetBoolean() ||
                (recovery != null && (recovery.NativeDestination != observation.NativeDestination ||
                !recovery.Operations.Select(value => value.ToString()).SequenceEqual(operations))))
            {
                throw new Exception("Recovery differs from Unity for " + probe.GetProperty("_id").GetString());
            }
            Reject(() => state.Observe(observation), typeof(InvalidOperationException));
            assertions += 2;
        }

        NavigationAgentRecoveryState.Observation valid = Read(root.GetProperty("_cases")[0]);
        var invalidStatusState = new NavigationAgentRecoveryState();
        Reject(() => invalidStatusState.Observe(valid with
        {
            Status = (NavigationAgentRecoveryState.PathStatus)99,
        }), typeof(InvalidDataException));
        if (invalidStatusState.Observe(valid) == null)
        {
            throw new Exception("Invalid path status consumed the valid callback frame.");
        }
        assertions += 2;
        foreach (Vector3 invalid in new[] { new Vector3(float.NaN), new Vector3(float.MaxValue) })
        {
            var state = new NavigationAgentRecoveryState();
            Reject(() => state.Observe(valid with { RawVelocity = invalid }), typeof(InvalidDataException));
            if (state.Observe(valid) == null)
            {
                throw new Exception("Rejected observation consumed the valid callback frame.");
            }
            assertions += 2;
        }
        return assertions;
    }

    private static NavigationAgentRecoveryState.Observation Read(JsonElement probe)
    {
        return new NavigationAgentRecoveryState.Observation
        {
            Frame = 1,
            WrapperIsStopped = probe.GetProperty("_stopped").GetBoolean(),
            Status = (NavigationAgentRecoveryState.PathStatus)probe.GetProperty("_status").GetInt32(),
            PathPending = probe.GetProperty("_pending").GetBoolean(),
            PathEndPosition = Vector(probe.GetProperty("_pathEndBits")),
            NativeDestination = Vector(probe.GetProperty("_destinationBits")),
            RawVelocity = Vector(probe.GetProperty("_velocityBits")),
        };
    }

    private static Vector3 Vector(JsonElement bits)
    {
        return new Vector3(BitConverter.Int32BitsToSingle(bits[0].GetInt32()),
            BitConverter.Int32BitsToSingle(bits[1].GetInt32()), BitConverter.Int32BitsToSingle(bits[2].GetInt32()));
    }

    private static void Reject(Action action, Type exceptionType)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception.GetType() == exceptionType)
        {
            return;
        }
        throw new Exception("Malformed or repeated recovery callback was accepted.");
    }
}
