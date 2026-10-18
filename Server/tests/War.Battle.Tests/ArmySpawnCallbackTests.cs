using War.BattleServer;

/// <summary>Checks source event ordering, removal and changes during an invocation.</summary>
internal static class ArmySpawnCallbackTests
{
    internal static int Run()
    {
        int checks = CheckSubscriptionOrder();
        checks += CheckInvocationSnapshot();
        return checks;
    }

    private static int CheckSubscriptionOrder()
    {
        var callbacks = new ArmySpawnCallbacks();
        var observed = new List<string>();
        const ulong EntityKey = 42;
        callbacks.Subscribe("z-first", key => observed.Add($"first:{key}"));
        callbacks.Subscribe("a-second", key => observed.Add($"second:{key}"));

        callbacks.Invoke(EntityKey);
        int checks = Check(observed.SequenceEqual(["first:42", "second:42"]),
            "Opaque effect IDs reordered source subscriptions.");

        checks += Check(callbacks.Unsubscribe("z-first") && !callbacks.Unsubscribe("missing"),
            "Removing a subscription returned an incorrect result.");
        callbacks.Subscribe("z-first", key => observed.Add($"rearmed:{key}"));
        observed.Clear();
        callbacks.Invoke(EntityKey);
        checks += Check(observed.SequenceEqual(["second:42", "rearmed:42"]),
            "A rearmed subscription retained its old event position.");
        return checks;
    }

    private static int CheckInvocationSnapshot()
    {
        var callbacks = new ArmySpawnCallbacks();
        var observed = new List<string>();
        callbacks.Subscribe("first", _ =>
        {
            observed.Add("first");
            callbacks.Unsubscribe("second");
        });
        callbacks.Subscribe("second", _ => observed.Add("second"));

        callbacks.Invoke(1);
        int checks = Check(observed.SequenceEqual(["first", "second"]),
            "Removing an observer changed the already captured invocation list.");

        observed.Clear();
        callbacks.Invoke(1);
        checks += Check(observed.SequenceEqual(["first"]),
            "A removed observer survived into the next spawn callback.");
        return checks;
    }

    private static int Check(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
