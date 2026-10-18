namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Subscribes an internal host effect in the shared source spawn-observer order.</summary>
    internal void SubscribeArmySpawn(string effectId, Action<ulong> observer)
    {
        armySpawnCallbacks.Subscribe(effectId, observer);
    }

    /// <summary>Removes an internal spawn observer without changing already modified entities.</summary>
    internal bool UnsubscribeArmySpawn(string effectId)
    {
        return armySpawnCallbacks.Unsubscribe(effectId);
    }
}
