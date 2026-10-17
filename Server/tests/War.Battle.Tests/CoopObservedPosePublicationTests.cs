using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Checks snapshot-time pose capture and per-connection delivery without retiming old replies.</summary>
internal static class CoopObservedPosePublicationTests
{
    internal static void Run(CoopMatchRuntime runtime, ulong enemyId)
    {
        var retained = new MatchReply { Code = "state", Snapshot = runtime.Snapshot() };
        byte[] original = retained.ToByteArray();
        BattleInfantryAnimationFrame frame = retained.Snapshot.Coop.EnemySpawns
            .Single(enemy => enemy.EntityId == enemyId).InfantryAnimation;
        if (frame?.ObservedPose == null)
        {
            throw new Exception("The completed-return fixture did not publish an observed reference.");
        }

        Require(frame.ObservedPose.SampleId == runtime.ObstaclePreparationSampleId(enemyId),
            "A verified completed return must capture its exact observed sample at snapshot creation.");
        string revision = ObservedInfantryPoseCatalogData.BuiltIn.Revision;
        MatchReply supported = MatchPresentationProjection.ForConnection(retained, revision);
        Require(CoopEnemyViewProjection.FromSnapshot(supported.Snapshot,
            supported.Snapshot.Coop.SceneMasterPlayerId, revision).Single(enemy => enemy.EntityId == enemyId)
            .InfantryAnimation.ObservedPose.SampleId == frame.ObservedPose.SampleId,
            "The negotiated SDK view must accept the actual host-selected reference and source clips.");
        MatchReply legacy = MatchPresentationProjection.ForConnection(retained, string.Empty);
        Require(CoopEnemyViewProjection.FromSnapshot(legacy.Snapshot, legacy.Snapshot.Coop.SceneMasterPlayerId)
            .Single(enemy => enemy.EntityId == enemyId).InfantryAnimation == null,
            "A clip-only connection must not receive an incorrect clip-only substitute for observed poses.");
        Require(retained.ToByteArray().SequenceEqual(original),
            "Connection projection must leave the retained host reply unchanged.");
        runtime.Advance(retained.Snapshot.ServerTick + 1);
        Require(MatchPresentationProjection.ForConnection(retained, revision).Snapshot.ToByteArray()
            .SequenceEqual(supported.Snapshot.ToByteArray()),
            "Delivering an older reply must preserve its captured pose rather than use the current runtime clock.");
        string? output = Environment.GetEnvironmentVariable("WAR_OBSERVED_HOST_FRAME_OUTPUT");
        if (!string.IsNullOrEmpty(output))
        {
            File.WriteAllBytes(output, supported.ToByteArray());
        }

        Console.WriteLine("PASS: host observed-pose capture, negotiated delivery, " +
            "clip-only isolation and frozen replay");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
