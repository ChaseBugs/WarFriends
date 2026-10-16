using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares callback and next-poll muzzles with the actual recovered coroutine snapshots.</summary>
internal static class CoopShotCallbackMuzzleTests
{
    private const float PositionTolerance = 0.00002f;
    private const float RotationTolerance = 0.000001f;
    private const float MinimumWrongFrameDifference = 0.01f;

    internal static void Run(string directory, BattleCombatContent content)
    {
        const string ReviewedHash = "514dae0b51e244146856785fb939456bbac07ab14d860aaef68e1f03faf78418";
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "coop-callback-muzzle-unity-reference.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReviewedHash,
            "The callback muzzle observation must match the reviewed native run.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        Require(root.GetProperty("version").GetInt32() == 2, "The observation must contain callback geometry.");
        ulong callbackTick = root.GetProperty("callbackTick").GetUInt64();
        ulong firstReadyTick = root.GetProperty("firstReadyTick").GetUInt64();
        float clipSeconds = content.EnemyPoses.Clip("stand_up_begin").Length;
        Require(CoopShotCallbackClock.CallbackTick(0, clipSeconds) == callbackTick &&
            CoopShotCallbackClock.FirstGameplayPollTick(callbackTick) == firstReadyTick,
            "The observed callback and first poll must bind the active host clock.");
        var callbackClock = new CoopObstaclePoseClock(callbackTick, []);
        var firstPollClock = new CoopObstaclePoseClock(firstReadyTick, [firstReadyTick]);
        ComparePose(content, callbackClock, root.GetProperty("callbackPose"));
        ComparePose(content, firstPollClock, root.GetProperty("firstReadyPose"));
        CoopQueuedMuzzleSample oldSample = content.CoopAssaulterQueue.Sample(
            "stand_up_begin", "rifle_shot_loop", callbackTick)
            ?? throw new InvalidDataException("The obsolete frame must be available for regression comparison.");
        Require(Vector3.Distance(oldSample.LocalPosition,
            Vector(root.GetProperty("callbackPose").GetProperty("position"))) > MinimumWrongFrameDifference,
            "The native capture must distinguish the obsolete post-frame callback muzzle.");
        Console.WriteLine("PASS: native callback and first-poll muzzles select the source gameplay sampling phase");
    }

    private static void ComparePose(BattleCombatContent content, CoopObstaclePoseClock clock, JsonElement expected)
    {
        CoopQueuedMuzzleSample actual = content.CoopObstaclePoses.GameplayFiringMuzzle(clock, content.CoopEnemyMuzzles)
            ?? throw new InvalidDataException("A native firing callback must have a host muzzle.");
        JsonElement rotation = expected.GetProperty("rotation");
        var expectedRotation = new Quaternion(rotation[0].GetSingle(), rotation[1].GetSingle(),
            rotation[2].GetSingle(), rotation[3].GetSingle());
        Require(Vector3.Distance(actual.LocalPosition, Vector(expected.GetProperty("position"))) <= PositionTolerance,
            "The selected callback muzzle must match the actual source coroutine position.");
        Require(1f - Math.Abs(Quaternion.Dot(actual.LocalRotation, expectedRotation)) <= RotationTolerance,
            "The selected callback muzzle rotation must match the actual source coroutine rotation.");
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
