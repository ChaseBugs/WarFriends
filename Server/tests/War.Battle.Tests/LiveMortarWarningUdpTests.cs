using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Receives natural Mortar warnings through the actual Worker, authenticated UDP and portable SDK.</summary>
internal static class LiveMortarWarningUdpTests
{
    private const int DeadlineSeconds = 60;
    private const int PollMilliseconds = 100;
    private const ulong FirstSession = 13901;
    private const ulong SecondSession = 13902;

    internal static async Task<int> RunAsync(string directory)
    {
        await using var fixture = new MixedBattleUdpFixture(directory, "ID_UNIT-MORTAR");
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(DeadlineSeconds));
        await fixture.StartAsync(deadline.Token);
        using MatchConnection owner = fixture.CreateViewedConnection(fixture.Manifest.Players[0].PlayerId, FirstSession);
        using MatchConnection observer = fixture.CreateViewedConnection(fixture.Manifest.Players[1].PlayerId, SecondSession);
        Require((await owner.ConnectAsync(deadline.Token)).Code == "admitted" &&
            (await observer.ConnectAsync(deadline.Token)).Code == "admitted", "Warning peers were not admitted.");
        await PrepareAsync(owner, fixture.Manifest.Allocations![0], deadline.Token);
        await PrepareAsync(observer, fixture.Manifest.Allocations![1], deadline.Token);
        MatchReply state;
        do
        {
            await Task.Delay(PollMilliseconds, deadline.Token);
            state = await owner.PollAsync(deadline.Token);
        }
        while (state.Snapshot.Phase != BattlePhase.Running);
        MatchArmyBatch offers = await owner.PollArmyAsync(deadline.Token);
        int option = offers.OptionIndexes.First(index => fixture.Content.Army.Option(index).Count == 1);
        Require((await owner.DeployArmyAsync(option, deadline.Token)).Code == "army-deploying",
            "Worker rejected an issued natural Mortar deployment.");
        MatchProjectileBatch scan = await WaitForWarningAsync(observer, deadline.Token);
        BattleMortarWarningState frozen = scan.MortarWarnings.Single().Clone();
        Require(frozen.OwnerPlayerId == fixture.Manifest.Players[0].PlayerId && frozen.ObserverFraction == 2 &&
            frozen.Clock != null && frozen.Clock.Visible, "SDK lost admitted warning owner or complete checkpoint.");
        Require((await owner.FetchProjectilesAsync(deadline.Token)).MortarWarnings.Count == 0,
            "An allied warning leaked through the live endpoint.");
        await CheckFrozenRetryAsync(observer, scan, frozen, deadline.Token);
        Console.WriteLine("Mortar warning UDP artifacts: " + fixture.RunDirectory);
        return 11;
    }

    private static async Task PrepareAsync(MatchConnection peer, BattleAllocationProjection allocation,
        CancellationToken cancellationToken)
    {
        Require((await peer.SelectCardsAsync([], allocation.NormalUpgradeIndexes, allocation.SpecialUpgradeIndexes,
            allocation.EliteUpgradeIndexes, [], cancellationToken)).Code == "cards-selected",
            "The warning peer could not select its trusted source lanes.");
        Require((await peer.ReadyAsync(cancellationToken)).Code == "ready", "The warning peer was not ready.");
    }

    private static async Task<MatchProjectileBatch> WaitForWarningAsync(MatchConnection observer,
        CancellationToken cancellationToken)
    {
        ulong scanId = 1;
        while (true)
        {
            MatchProjectileBatch scan = await observer.PollProjectilesAsync(scanId++, 0, cancellationToken);
            if (scan.MortarWarnings.Count > 0)
            {
                return scan;
            }
            await Task.Delay(PollMilliseconds, cancellationToken);
        }
    }

    private static async Task CheckFrozenRetryAsync(MatchConnection observer, MatchProjectileBatch scan,
        BattleMortarWarningState frozen, CancellationToken cancellationToken)
    {
        scan.MortarWarnings[0].Clock.Scale = 0f;
        await Task.Delay(PollMilliseconds, cancellationToken);
        MatchProjectileBatch retry = await observer.PollProjectilesAsync(scan.ScanId, 0, cancellationToken);
        Require(retry.SnapshotTick == scan.SnapshotTick && retry.MortarWarnings.Single().Equals(frozen),
            "Live retry changed a frozen warning or aliased a caller's mutated row.");
        MatchReply now = await observer.PollAsync(cancellationToken);
        BattleMortarWarningState? current = MortarWarningReconstruction.AtTick(frozen, now.Snapshot.ServerTick);
        Require(current != null && current.ObservedTick == now.Snapshot.ServerTick &&
            frozen.ObservedTick == scan.SnapshotTick, "Decoded checkpoint failed current-tick reconstruction.");
        ulong expiryTick = frozen.ObservedTick + (ulong)Math.Ceiling((frozen.StopSeconds + 1f) * MatchManifest.TickRate);
        Require(MortarWarningReconstruction.AtTick(frozen, expiryTick) == null,
            "Decoded checkpoint restarted a warning beyond its source hide boundary.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
