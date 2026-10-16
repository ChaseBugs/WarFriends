using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private string Apply(Participant participant, MatchCommand command)
    {
        switch (command.IntentCase)
        {
            case MatchCommand.IntentOneofCase.Ready:
                return ApplyReady(participant, command);
            case MatchCommand.IntentOneofCase.Forfeit:
                return ApplyForfeit(participant);
            case MatchCommand.IntentOneofCase.MoveCover:
                return StartPlayerMovement(participant, command.MoveCover.Direction,
                    command.MoveCover.HasTargetCoverIndex ? command.MoveCover.TargetCoverIndex : null);
            case MatchCommand.IntentOneofCase.SwitchWeapon:
                return ApplyWeaponSelection(participant, command);
            case MatchCommand.IntentOneofCase.Reload:
                return ApplyReload(participant);
            default:
                return "coop-command-unavailable";
        }
    }

    private string ApplyReady(Participant participant, MatchCommand command)
    {
        if (command.Ready.ManifestHash != ManifestHash)
        {
            return "manifest-mismatch";
        }
        if (participant.Ready)
        {
            return "already-ready";
        }
        if (!mission.MarkReady(participant.PlayerId, tick))
        {
            return "ready-unavailable";
        }

        participant.Ready = true;
        if (mission.Started)
        {
            StartReadyMission();
        }

        return "ready";
    }

    private void StartReadyMission()
    {
        if (bossAnchors != null && bossHealth != null)
        {
            boss = new CoopBossCombatState(mission, bossHealth, bossAnchors, tick);
            BossAttackCadence = new CoopBossAttackCadence(bossAttackTiming!, tick, chooseAttackFraction);
            BossArsenal = new CoopBossArsenal(BossLoadout!, bossWeaponContent!, tick);
        }
        if (shieldStates != null)
        {
            alliedShields = new CoopShieldMatchSimulation(
                manifest,
                shieldStates,
                shieldPolicy!,
                alliedFirstCover,
                tick);
        }
        if (boss != null)
        {
            enemyShields = new CoopShieldMatchSimulation(
                1,
                bossHealth!.Level,
                shieldStates!.ForMission(mission.MissionIndex).Bot,
                shieldPolicy!,
                firstCover: 0,
                startingTick: tick);
        }

        phase = BattlePhase.Running;
    }

    private string ApplyForfeit(Participant participant)
    {
        mission.Leave(participant.PlayerId);
        if (mission.Started)
        {
            End(BattlePhase.Ended, "forfeit");
        }
        else
        {
            // The loading dialog cancels before PlayCurrentMission, so no battle outcome exists yet.
            End(BattlePhase.Aborted, "cancelled-before-start");
        }

        return "forfeit";
    }

    private string ApplyWeaponSelection(Participant participant, MatchCommand command)
    {
        if (phase != BattlePhase.Running || !participant.Ready || participant.Dead)
        {
            return "match-not-running";
        }
        if (participant.Route != null)
        {
            return "moving";
        }
        if (participant.Weapons == null || !participant.Weapons.TrySelectSlot(command.SwitchWeapon.Slot, tick))
        {
            return "weapon-slot-unavailable";
        }

        if (participant.ShotTimeline != null)
        {
            UpdateSelectedWeaponAnimation(participant, command.SwitchWeapon.Slot);
        }

        return "weapon-selected";
    }

    private void UpdateSelectedWeaponAnimation(Participant participant, int selectedSlot)
    {
        CoopPlayerWeapon selected = PlayerWeapons!.ForPlayer(participant.PlayerId)
            .Single(weapon => weapon.Slot == selectedSlot);
        int family = playerWeaponBindings!.Get(selected.Weapon.SourceId).AnimationFamily;
        // Changing weapons ends the old cover animation but retains its one-second collision settling gate.
        if (UsesCoverShotTimeline(family))
        {
            participant.ShotTimeline = new RifleCoverTimeline(playerPoses!, family);
            participant.ShotTimeline.Advance(tick / (double)MatchManifest.TickRate);
        }
        else
        {
            participant.ShotTimeline = null;
        }

        participant.ShotAnimationFamily = family;
        participant.ShotPoseReadyTick = checked(tick + MatchManifest.TickRate);
    }

    private string ApplyReload(Participant participant)
    {
        if (phase != BattlePhase.Running || !participant.Ready || participant.Dead)
        {
            return "match-not-running";
        }

        CoopPlayerWeaponState? weapons = participant.Weapons;
        if (weapons == null || !weapons.TryStartReload(weapons.ActiveSlot, tick))
        {
            return "reload-unavailable";
        }

        return "reloading";
    }
}
