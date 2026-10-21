namespace War.BattleServer;

/// <summary>Runs host spawn observers in the subscription order used by AIObject.AfterSpawned.</summary>
public sealed class ArmySpawnCallbacks
{
    private readonly Dictionary<string, Action<ulong>> _subscriptions = new(StringComparer.Ordinal);
    private Action<ulong>? _callbacks;

    /// <summary>Adds one effect's callback at the end of the invocation list.</summary>
    public void Subscribe(string effectId, Action<ulong> callback)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(effectId);
        ArgumentNullException.ThrowIfNull(callback);

        // Request IDs identify subscriptions; their lexical order must never set gameplay order.
        _subscriptions.Add(effectId, callback);
        _callbacks += callback;
    }

    /// <summary>Removes an effect; subscribing again places it after the remaining observers.</summary>
    public bool Unsubscribe(string effectId)
    {
        if (!_subscriptions.Remove(effectId, out Action<ulong>? callback))
        {
            return false;
        }

        _callbacks -= callback;
        return true;
    }

    /// <summary>Invokes the current delegate snapshot, preserving C# event mutation semantics.</summary>
    public void Invoke(ulong entityKey)
    {
        Action<ulong>? callbacks = _callbacks;
        callbacks?.Invoke(entityKey);
    }
}
