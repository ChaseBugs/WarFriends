namespace War.BattleServer;

public sealed record PvpBonusSelection(PvpBonusSource Prefab, int SourceIndex, bool UsedQueuedOverride)
{
    // The original upper-endpoint fallthrough can keep prefab 8 but send index
    // 9. Preserve that observation; it is not permission to publish an invalid RPC.
    public bool HasValidSourceIndex => SourceIndex == Prefab.Index;
}
