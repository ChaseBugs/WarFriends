using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks embedded source content ownership and exact portable reference admission.</summary>
internal static class ObservedPoseCatalogTests
{
    internal static void Run()
    {
        ObservedPoseProjectionTests.Run();
        ObservedInfantryPoseCatalogData catalog = ObservedInfantryPoseCatalogData.BuiltIn;
        ObservedInfantryPoseCatalog snapshot = catalog.Snapshot();
        foreach (ObservedInfantryPoseSample expected in snapshot.Samples)
        {
            var reference = new BattleInfantryObservedPoseReference
            {
                CatalogRevision = catalog.Revision, SampleId = expected.Id
            };
            reference = BattleInfantryObservedPoseReference.Parser.ParseFrom(reference.ToByteArray());
            ObservedInfantryPoseSample actual = catalog.GetSample(reference);
            if (!actual.Equals(expected))
            {
                throw new Exception("Embedded source lookup changed a reviewed sample.");
            }
            actual.Clips.Clear();
            if (catalog.GetSample(reference).Clips.Count == 0)
            {
                throw new Exception("A returned pose sample changed embedded authority.");
            }
        }
        snapshot.Skeleton.Clear();
        if (catalog.Snapshot().Skeleton.Count != 58)
        {
            throw new Exception("Catalog snapshots must isolate nested topology.");
        }
        Reject(() => catalog.GetSample(new BattleInfantryObservedPoseReference()));
        Reject(() => catalog.GetSample(new BattleInfantryObservedPoseReference
        {
            CatalogRevision = catalog.Revision, SampleId = 222
        }));
        Reject(() => catalog.GetSample(new BattleInfantryObservedPoseReference
        {
            CatalogRevision = new string('0', 64), SampleId = 1
        }));
        Reject(() => ObservedInfantryPoseCatalogData.Load(new byte[1]));
        Console.WriteLine("PASS: 221 embedded portable pose references and isolated source snapshots");
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
        throw new Exception("Unreviewed portable pose reference was accepted.");
    }
}
