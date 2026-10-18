using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks natural host launch, shooter death, frozen logical ticks and terminal cleanup.</summary>
internal static class MortarIndicatorHostTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumTick = 1200;
    private const ulong NativeFirstWarningTicks = 74;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        return CheckShooterDeath(content) + CheckTerminal(content) + CheckReconnectPause(content) +
            MortarWeaponPoolHostTests.Run(directory);
    }

    private static int CheckShooterDeath(BattleCombatContent content)
    {
        MatchEngine host = CreateLaunch(content);
        MortarIndicatorObservation first = host.MortarIndicators().Single();
        MortarShotAttempt attempt = host.MortarAttempt(first.EntityKey)!;
        int checks = Require(first.OwnerPlayerId == OwnerId && first.OwnerFraction == 1 && !first.IsFake &&
            first.ProjectileId == attempt.ProjectileId && first.LaunchTick == attempt.CompletedTick &&
            first.ObservedTick == first.LaunchTick && first.StopSeconds == 1f / 0.43f &&
            first.Position == attempt.Target!.Position + Vector3.UnitY * 0.04f,
            "Natural host launch lost source target offset, owner, timing or current weapon setup.");
        host.Advance(first.ObservedTick);
        checks += Require(host.MortarIndicators().Single() == first,
            "A same-tick host poll advanced the warning twice.");
        checks += Require(host.ConfirmArmyDeath(first.EntityKey, false) &&
            host.MortarIndicators().Single() == first,
            "Shooter death removed its world-parented warning before the source callback.");
        ulong hiddenTick = first.LaunchTick + NativeFirstWarningTicks;
        while (!host.Terminal && host.Snapshot().ServerTick < hiddenTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            ulong tick = host.Snapshot().ServerTick;
            checks += Require(host.MortarIndicators().Count == (tick < hiddenTick ? 1 : 0),
                "The dead shooter's warning did not retain the native first-activation deadline.");
        }
        checks += Require(!host.Terminal && host.MortarIndicatorHistoryCount == 0,
            "A completed dead weapon retained mutable warning history.");
        return checks;
    }

    private static int CheckTerminal(BattleCombatContent content)
    {
        MatchEngine host = CreateLaunch(content);
        host.Command(OwnerId, new MatchCommand { CommandId = 4, Forfeit = new ForfeitCommand() });
        return Require(host.Terminal && host.MortarIndicators().Count == 0 && host.MortarIndicatorHistoryCount == 0,
            "Terminal match retained live or hidden warning authority.");
    }

    private static MatchEngine CreateLaunch(BattleCombatContent content)
    {
        return CreateLaunch(OrdinaryArmyTestHost.Create(content, UnitId));
    }

    private static MatchEngine CreateLaunch(MatchEngine host)
    {
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "Warning fixture rejected its natural Mortar deployment.");
        host.Advance(61);
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && host.MortarIndicators().Count == 0)
        {
            host.Resume(OwnerId);
            host.Resume(OpponentId);
            host.Advance(host.Snapshot().ServerTick + 1);
        }
        Require(!host.Terminal && host.MortarIndicators().Count == 1,
            "Natural Mortar never issued its warning: " + host.Snapshot().TerminalReason);
        return host;
    }

    private static int CheckReconnectPause(BattleCombatContent content)
    {
        const ulong PausedHostTicks = 120;
        MatchEngine host = CreateLaunch(OrdinaryArmyTestHost.CreateWithIdleTimeout(content, UnitId, 2));
        MortarIndicatorObservation before = host.MortarIndicators().Single();
        while (!host.Terminal && !host.Snapshot().Players.Any(player => player.Reconnecting))
        {
            before = host.MortarIndicators().Single();
            host.Resume(OpponentId);
            host.Advance(host.Snapshot().ServerTick + 1);
        }
        MatchSnapshot paused = host.Snapshot();
        int checks = Require(!host.Terminal && paused.Players.Any(player => player.Reconnecting) &&
            paused.ServerTick == before.ObservedTick && host.MortarIndicators().Single() == before,
            "Idle detection partially advanced the warning's simulation frame.");
        host.Advance(paused.PauseHostTick + PausedHostTicks);
        checks += Require(host.MortarIndicators().Single() == before && host.Snapshot().ServerTick == paused.ServerTick,
            "Host wall time aged the paused warning.");
        host.Resume(OwnerId);
        host.Resume(OpponentId);
        host.Advance(paused.PauseHostTick + PausedHostTicks + 1);
        checks += Require(!host.Terminal && host.Snapshot().ServerTick == paused.ServerTick + 1 &&
            host.MortarIndicators().Single().ObservedTick == before.ObservedTick + 1 &&
            host.CardRocketLaunchMissile(before.ProjectileId) != null,
            "Resume skipped a source frame or invalidated the still-airborne missile.");
        return checks;
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
