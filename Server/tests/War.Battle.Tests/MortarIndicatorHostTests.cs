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
            MortarWeaponPoolHostTests.Run(directory) + CheckSlotReuse(content) + MortarWarningWireTests.Run() +
            CheckWarningProjection(content);
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
        return Require(host.Terminal && host.MortarIndicators().Count == 0 && host.MortarIndicatorHistoryCount == 0 &&
            host.MortarSlotObserverHistoryCount == 0,
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

    private static int CheckSlotReuse(BattleCombatContent content)
    {
        MatchEngine host = CreateLaunch(content);
        MortarIndicatorObservation first = host.MortarIndicators().Single();
        int? originalSlot = host.RetainedMortarWeaponSlot(first.EntityKey);
        host.ConfirmArmyDeath(first.EntityKey, false);
        ulong returnedTick = host.Snapshot().ServerTick + 120;
        while (!host.Terminal && host.Snapshot().ServerTick < returnedTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }
        int checks = Require(!host.Terminal && host.RetainedMortarWeaponCount == 0 &&
            host.MortarIndicators().Count == 0 && host.MortarSlotObserverHistoryCount == 2,
            "Weapon return discarded observer history or retained a completed actor warning.");
        checks += Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 4, DeployArmy = new DeployArmyCommand { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes[0] }
        }).Code == "army-deploying", "The source slot successor was not accepted.");
        MortarIndicatorObservation? reused = null;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && reused == null)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            reused = host.MortarIndicators().SingleOrDefault();
        }
        checks += Require(reused != null && reused.EntityKey != first.EntityKey &&
            reused.ProjectileId > first.ProjectileId && host.RetainedMortarWeaponSlot(reused.EntityKey) == originalSlot &&
            host.MortarSlotObserverHistoryCount == 2,
            "The successor used a new slot history or retained its retired actor's launch identity.");
        checks += Require(reused!.RotationFactor == 0f && Math.Abs(reused.Scale - 0.65f) < 0.00001f,
            "Reused hidden warning lost the source reactivation frame and retained shrink scale.");
        return checks;
    }

    private static int CheckWarningProjection(BattleCombatContent content)
    {
        MatchEngine host = CreateLaunch(content);
        MortarIndicatorObservation launch = host.MortarIndicators().Single();
        var row = host.MortarWarnings(OpponentId).Single();
        int checks = Require(host.MortarWarnings(OwnerId).Count == 0 && row.ObserverFraction == 2 &&
            row.ProjectileId == launch.ProjectileId && row.WeaponSlot == host.RetainedMortarWeaponSlot(launch.EntityKey),
            "Warning projection lost allied suppression, launch identity or physical slot.");
        row.Scale = float.NaN;
        checks += Require(float.IsFinite(host.MortarWarnings(OpponentId).Single().Scale),
            "A caller mutated the host warning through a returned protobuf row.");
        host.ConfirmArmyDeath(launch.EntityKey, false);
        checks += Require(host.MortarWarnings(OpponentId).Single().EntityKey == launch.EntityKey,
            "Warning publication disappeared with its shooter's roster entry.");
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
