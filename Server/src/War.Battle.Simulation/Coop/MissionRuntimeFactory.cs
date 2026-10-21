namespace War.BattleServer;

/// <summary>Creates per-match state from immutable mission definitions.</summary>
public static class MissionRuntimeFactory
{
    public static MissionObjectiveState CreateObjectiveState(this MissionCatalog catalog, int missionIndex)
    {
        return new MissionObjectiveState(catalog.Get(missionIndex));
    }

    public static MissionAutomaticSpawnState CreateAutomaticSpawnState(
        this MissionCatalog catalog, int missionIndex, Func<int, int>? chooseBehaviour = null)
    {
        return new MissionAutomaticSpawnState(catalog.Get(missionIndex), chooseBehaviour);
    }
}
