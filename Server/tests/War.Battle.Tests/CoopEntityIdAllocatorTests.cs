using War.BattleServer;

/// <summary>Checks shared actor ranges and exhausted/invalid requests without wrap or partial consumption.</summary>
internal static class CoopEntityIdAllocatorTests
{
    internal static int Run()
    {
        var allocator = new CoopEntityIdAllocator();
        Require(allocator.Allocate() == 1 && allocator.Reserve(6).SequenceEqual(new ulong[] { 2, 3, 4, 5, 6, 7 }) &&
            allocator.Allocate() == 8, "Mission and crew identity ranges overlapped or changed order.");
        Reject(() => allocator.Reserve(0));
        Reject(() => allocator.Reserve(7));
        Require(allocator.Allocate() == 9, "Invalid crew batch consumed an actor identity.");
        var exhausted = new CoopEntityIdAllocator(ulong.MaxValue - 2);
        Reject(() => exhausted.Reserve(3));
        Require(exhausted.Reserve(2).SequenceEqual(new[] { ulong.MaxValue - 2, ulong.MaxValue - 1 }),
            "Failed batch partially consumed the final actor identities.");
        Reject(() => exhausted.Allocate());
        Reject(() => exhausted.Reserve(1));
        Reject(() => new CoopEntityIdAllocator(0));
        return 9;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is ArgumentOutOfRangeException or InvalidOperationException)
        {
            return;
        }
        throw new Exception("Co-op actor identity allocation accepted invalid capacity or wrapped its counter.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
