namespace War.BattleServer;

/// <summary>Preserves source master/peer ownership independently of the signed roster's storage order.</summary>
internal static class CoopSceneRoles
{
    private const int ParticipantCount = 2;
    private const int MasterStartIndex = 0;
    private const int PeerStartIndex = 1;

    internal static string GetMasterPlayerId(MatchManifest manifest)
    {
        ArgumentNullException.ThrowIfNull(manifest);
        if (manifest.Mode != MatchManifest.CoopMissionMode || manifest.Players.Length != ParticipantCount)
        {
            throw new InvalidDataException("Co-op scene roles require the validated two-player allocation.");
        }

        string masterId = manifest.SceneMasterPlayerId ?? manifest.Players[MasterStartIndex].PlayerId;
        if (!manifest.Players.Any(player => player.PlayerId == masterId))
        {
            throw new InvalidDataException("Co-op scene master is outside the signed roster.");
        }

        return masterId;
    }

    internal static int GetMainPositionIndex(MatchManifest manifest, string playerId)
    {
        string masterId = GetMasterPlayerId(manifest);
        if (!manifest.Players.Any(player => player.PlayerId == playerId))
        {
            throw new InvalidDataException("Co-op start owner is outside the signed roster.");
        }

        return playerId == masterId ? MasterStartIndex : PeerStartIndex;
    }
}
