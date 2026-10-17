using War.Client;
using War.Protocol;

/// <summary>Checks exact catalog frame admission without changing default clip-only callers.</summary>
internal static class ObservedPoseProjectionTests
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    internal static void Run()
    {
        ObservedInfantryPoseCatalogData catalog = ObservedInfantryPoseCatalogData.BuiltIn;
        foreach (ObservedInfantryPoseSample sample in catalog.Snapshot().Samples)
        {
            MatchSnapshot snapshot = CreateSnapshot(sample, catalog.Revision);
            InfantryAnimationFrameView view = CoopEnemyViewProjection.FromSnapshot(
                snapshot, PlayerId, catalog.Revision)[0].InfantryAnimation;
            view.ObservedPose.SampleId = 0;
            if (view.ObservedPose.SampleId != sample.Id)
            {
                throw new Exception("A copied pose reference changed the accepted view.");
            }

            Reject(() => CoopEnemyViewProjection.FromSnapshot(snapshot, PlayerId));
            snapshot.Coop.EnemySpawns[0].InfantryAnimation.Clips[0].TimeSeconds += 0.01f;
            Reject(() => CoopEnemyViewProjection.FromSnapshot(snapshot, PlayerId, catalog.Revision));
        }

        MatchSnapshot premature = CreateSnapshot(catalog.Snapshot().Samples.Last(), catalog.Revision);
        premature.ServerTick = 10;
        premature.Coop.EnemySpawns[0].InfantryAnimation.SampleTick = 10;
        Reject(() => CoopEnemyViewProjection.FromSnapshot(premature, PlayerId, catalog.Revision));
        Reject(() => CoopEnemyViewProjection.FromSnapshot(premature, PlayerId, "unknown"));

        Console.WriteLine("PASS: 221 negotiated pose projections; " +
            "clip-only, mismatched-clip and reference-copy guards");
    }

    private static MatchSnapshot CreateSnapshot(ObservedInfantryPoseSample sample, string revision)
    {
        MatchSnapshot snapshot = CoopEnemyViewTests.CreateSnapshot();
        var frame = new BattleInfantryAnimationFrame
        {
            SampleTick = snapshot.ServerTick,
            ObservedPose = new BattleInfantryObservedPoseReference { CatalogRevision = revision, SampleId = sample.Id }
        };
        foreach (BattleInfantryAnimationClip clip in sample.Clips)
        {
            frame.Clips.Add(clip.Clone());
        }

        snapshot.Coop.EnemySpawns[0].InfantryAnimation = frame;
        return snapshot;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("An unnegotiated or mismatched observed pose frame was accepted.");
    }
}
