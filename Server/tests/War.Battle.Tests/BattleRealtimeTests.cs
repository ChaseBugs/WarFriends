using System.Reflection;

using Google.Protobuf;
using War.BattleServer;

/// <summary>Checks that actual elapsed observations survive paused/catch-up ticks without changing combat time.</summary>
internal static class BattleRealtimeTests
{
    private static readonly string FirstOwnerId = new('a', 32);
    private static readonly string SecondOwnerId = new('b', 32);
    private static readonly string SigningKey = Convert.ToBase64String(Enumerable.Repeat((byte)3, 32).ToArray());

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        return CheckRunning(content) + CheckPaused(content) + CheckEndpointAndRegistry();
    }

    private static int CheckRunning(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, "ID_UNIT-MORTAR");
        host.Advance(61, 10d);
        host.Advance(62, 10d);
        int checks = Require(host.ObservedRealTimeSeconds == 10d && host.Snapshot().ServerTick == 62,
            "Catch-up ticks replaced their real-time sample with a derived tick time.");
        byte[] before = host.Snapshot().ToByteArray();
        foreach (double invalid in new[] { double.NaN, double.PositiveInfinity, double.NegativeInfinity, -1d, 9d })
        {
            bool rejected = false;
            try
            {
                host.Advance(63, invalid);
            }
            catch (ArgumentOutOfRangeException)
            {
                rejected = true;
            }
            checks += Require(rejected && host.ObservedRealTimeSeconds == 10d &&
                host.Snapshot().ToByteArray().AsSpan().SequenceEqual(before),
                "Malformed or backward real time changed the combat snapshot before rejection.");
        }
        bool gapRejected = false;
        try
        {
            host.Advance(64, 11d);
        }
        catch (InvalidOperationException)
        {
            gapRejected = true;
        }
        checks += Require(gapRejected && host.ObservedRealTimeSeconds == 10d,
            "A rejected combat frame gap consumed a future real-time observation.");
        host.Advance(63, 10.1d);
        return checks + Require(host.Snapshot().ServerTick == 63 && host.ObservedRealTimeSeconds == 10.1d,
            "The next valid frame could not advance after rejected clock input.");
    }

    private static int CheckPaused(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateWithIdleTimeout(content, "ID_UNIT-MORTAR", 2);
        for (ulong tick = 61; tick <= 120; tick++)
        {
            host.Resume(FirstOwnerId);
            host.Advance(tick, tick / (double)MatchManifest.TickRate + 8d);
        }
        ulong frozenTick = host.Snapshot().ServerTick;
        host.Advance(121, 20d);
        int checks = Require(host.Snapshot().PauseHostTick == 121 && host.Snapshot().ServerTick == frozenTick &&
            host.ObservedRealTimeSeconds == 20d,
            "Reconnect pause froze raw real time or advanced the paused simulation.");
        bool resumed = host.Resume(SecondOwnerId);
        host.Advance(122, 20d);
        return checks + Require(resumed && host.Snapshot().ServerTick == frozenTick + 1 &&
            host.ObservedRealTimeSeconds == 20d,
            "Resume replayed wall-time backlog as combat frames.");
    }

    private static int CheckEndpointAndRegistry()
    {
        MatchManifest definition = CreateDefinition();
        var engine = new MatchEngine(definition);
        var endpoint = new MatchEndpoint(definition, SigningKey, engine, 100);
        endpoint.Advance(101, 10d);
        int checks = Require(engine.Snapshot().ServerTick == 1 && engine.ObservedRealTimeSeconds == 10d &&
            endpoint.ObservedRealTimeSeconds == 10d,
            "Endpoint allocation offset shifted the independent real-time observation.");
        var router = new MatchRouter([], definition.ServerId, SigningKey);
        router.Advance(4, 5d);
        checks += Require(router.Register(definition).Code == "registered", "Clock fixture allocation failed.");
        var matches = (Dictionary<string, MatchEndpoint>)typeof(MatchRouter).GetField("matches",
            BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(router)!;
        checks += Require(matches[definition.MatchId].ObservedRealTimeSeconds == 5d,
            "A new allocation replaced current real time with its executed tick counter.");
        bool rejected = false;
        try
        {
            router.Advance(5, 4d);
        }
        catch (ArgumentOutOfRangeException)
        {
            rejected = true;
        }
        checks += Require(rejected && router.ObservedRealTimeSeconds == 5d &&
            matches[definition.MatchId].ObservedRealTimeSeconds == 5d,
            "The registry published backward real time before rejecting it.");
        router.Advance(5, 5.1d);
        router.Advance(6, 5.1d);
        return checks + Require(matches[definition.MatchId].ObservedRealTimeSeconds == 5.1d,
            "Registry catch-up did not forward a shared real-time sample.");
    }

    private static MatchManifest CreateDefinition()
    {
        string hash = new('a', 64);
        var weapon = new WeaponManifest("fixture-weapon", 2, 3, 0.1, 0.2);
        return new MatchManifest("clock-registry", "clock-host", "fixture-map", hash, hash,
            MatchManifest.PrototypeMode, 10, 60, 120,
            [new(FirstOwnerId, weapon), new(SecondOwnerId, weapon)]);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
