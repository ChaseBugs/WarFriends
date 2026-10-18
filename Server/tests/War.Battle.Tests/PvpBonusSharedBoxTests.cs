using War.Protocol;

/// <summary>Checks shared crate identity across asynchronous polls without accepting changed authority.</summary>
internal static class PvpBonusSharedBoxTests
{
    private const string BoxId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string OwnerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const int SourcePrefabIndex = 6;

    internal static int Run()
    {
        var first = new MatchSnapshot { ServerTick = 100, StateRevision = 10 };
        first.PvpBonusBoxes.Add(new BattlePvpBonusBoxState
        {
            BoxId = BoxId, OwnerPlayerId = OwnerId, PrefabIndex = SourcePrefabIndex
        });
        MatchSnapshot later = first.Clone();
        later.ServerTick++;
        later.StateRevision++;
        later.PvpBonusBoxes.Add(new BattlePvpBonusBoxState { BoxId = new string('c', 32) });
        Require(LivePvpBonusUdpTests.HasSameSelectedBox(first, first.Clone(), BoxId), "Identical views differ.");
        Require(LivePvpBonusUdpTests.HasSameSelectedBox(first, later, BoxId),
            "A later box invalidated the shared box.");

        MatchSnapshot changed = later.Clone();
        changed.PvpBonusBoxes[0].PrefabIndex++;
        Require(!LivePvpBonusUdpTests.HasSameSelectedBox(first, changed, BoxId), "Changed prefab was accepted.");
        changed = later.Clone();
        changed.PvpBonusBoxes[0].OwnerPlayerId = new string('d', 32);
        Require(!LivePvpBonusUdpTests.HasSameSelectedBox(first, changed, BoxId), "Changed owner was accepted.");
        changed = later.Clone();
        changed.PvpBonusBoxes.RemoveAt(0);
        Require(!LivePvpBonusUdpTests.HasSameSelectedBox(first, changed, BoxId),
            "Missing shared identity was accepted.");
        later.StateRevision = first.StateRevision;
        Require(!LivePvpBonusUdpTests.HasSameSelectedBox(first, later, BoxId),
            "Same revision published different IDs.");
        return 6;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
