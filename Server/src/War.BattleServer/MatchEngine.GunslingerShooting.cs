using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const ulong GunslingerTurnTicks = MatchManifest.TickRate / 5;
    private readonly Dictionary<ulong, GunslingerShotAttempt> _gunslingerAttempts = [];

    /// <summary>Reads actual match-owned preparation, callback and completion evidence.</summary>
    internal GunslingerShotAttempt? GunslingerAttempt(ulong entityKey)
    {
        return _gunslingerAttempts.GetValueOrDefault(entityKey);
    }

    private void AdvanceGunslingerPreparations()
    {
        foreach (var (entityKey, arrival) in _gunslingerArrivals.OrderBy(row => row.Key).ToArray())
        {
            GunslingerShotAttempt? previous = GunslingerAttempt(entityKey);
            if (previous != null && !previous.CompletedTick.HasValue)
            {
                continue;
            }

            if (arrival.ShotsRemaining is not > 0 || !arrival.FirstShotEligibleTick.HasValue ||
                tick < arrival.FirstShotEligibleTick.Value)
            {
                continue;
            }

            PrepareGunslingerShot(entityKey, arrival, previous);
        }
    }

    private void PrepareGunslingerShot(ulong entityKey, GunslingerArrival arrival, GunslingerShotAttempt? previous)
    {
        GunslingerPreparedAim? aim = CaptureGunslingerAim(entityKey);
        if (aim == null)
        {
            // Unresolved target geometry cannot authorize a substituted target or invented cooldown.
            return;
        }

        CoopInfantryShotBatch batch = GunslingerShotBatchPolicy.Create(armyShots[entityKey], armyChoice, NextArmyFloat);
        GunslingerFireLoopEntry entry = NextGunslingerLoopEntry(previous);
        float delay = previous == null ? enemyPoses!.Clip("colt_shooting_start").Length : 0f;
        var entity = activeArmyEntities[entityKey];
        Vector3 facing = infantryAnimations[entityKey].Facing;
        Quaternion start = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(facing.X, facing.Z));
        Vector3 toward = aim.TargetPosition - new Vector3(entity.X, entity.Y, entity.Z);
        Quaternion final = toward.X == 0f && toward.Z == 0f ? start :
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(toward.X, toward.Z));
        var attempt = new GunslingerShotAttempt(aim, batch,
            (entry, GunslingerFiringClock.CallbackTick(tick, delay)), (start, final));
        RefreshGunslingerTarget(attempt);
        _gunslingerAttempts[entityKey] = attempt;
        _gunslingerArrivals[entityKey] = arrival with { ShotsRemaining = arrival.ShotsRemaining - 1 };
        ConsumeGunslingerCooldownDraw(entityKey);
    }

    private static GunslingerFireLoopEntry NextGunslingerLoopEntry(GunslingerShotAttempt? previous)
    {
        if (previous == null)
        {
            return GunslingerFireLoopEntry.FreshQueuedFire;
        }

        if (previous.LoopEntry == GunslingerFireLoopEntry.FreshQueuedFire)
        {
            return GunslingerFireLoopEntry.ReplaceQueuedClone;
        }

        return GunslingerFireLoopEntry.RestartEnabledFire;
    }

    private void AdvanceGunslingerShots()
    {
        foreach (var (entityKey, attempt) in _gunslingerAttempts.OrderBy(row => row.Key).ToArray())
        {
            // The source TweenRotation can outlive a zero-delay callback and
            // its one-shot completion. Keep the full 0.2-second turn running.
            UpdateGunslingerTurn(entityKey, attempt);
            if (attempt.CompletedTick.HasValue)
            {
                continue;
            }

            RefreshGunslingerTarget(attempt);
            if (attempt.Prediction == null && tick >= attempt.CallbackTick)
            {
                ExecuteGunslingerCallback(entityKey, attempt);
            }

            if (attempt.Prediction != null && tick >= attempt.PollTick)
            {
                LaunchGunslingerRound(entityKey, attempt);
                if (Terminal)
                {
                    return;
                }

                CompleteGunslingerShot(entityKey, attempt);
            }
        }
    }

    private void ExecuteGunslingerCallback(ulong entityKey, GunslingerShotAttempt attempt)
    {
        GunslingerWeaponAimState weapon = _gunslingerAimWeapons[entityKey];
        Vector3 muzzle = GunslingerFiringMuzzle(entityKey, attempt);
        attempt.Prediction = attempt.Aim.Target.IsPlayer
            ? weapon.StartPlayerShot(muzzle, attempt.LastTargetPosition, attempt.LastTargetVelocity)
            : weapon.StartEntityShot(muzzle, attempt.LastTargetPosition, attempt.LastTargetVelocity);
    }

    private void CompleteGunslingerShot(ulong entityKey, GunslingerShotAttempt attempt)
    {
        attempt.CompletedTick = tick;
        ConsumeGunslingerCooldownDraw(entityKey);
        GunslingerArrival arrival = _gunslingerArrivals[entityKey];
        if (arrival.ShotsRemaining == 0)
        {
            _gunslingerHolsterDueTicks[entityKey] = GunslingerFiringClock.HolsterTick(tick);
        }

        // ReturnToPreviousStateFromShot generates a random cooldown before the
        // Gunslinger override replaces it with cadence and a two-second move clock.
        _gunslingerArrivals[entityKey] = arrival with
        {
            FirstShotEligibleTick = GunslingerFiringClock.NextPreparationTick(tick),
            FirstPointChangeEligibleTick = checked(tick + 2 * MatchManifest.TickRate + 1)
        };
    }

    private void ConsumeGunslingerCooldownDraw(ulong entityKey)
    {
        ArmyBaseShotStats shot = armyShots[entityKey];
        float seconds = shot.MinShootTime + NextArmyFloat() * (shot.MaxShootTime - shot.MinShootTime);
        if (!float.IsFinite(seconds) || seconds < 0f)
        {
            throw new InvalidDataException("Gunslinger source cooldown draw lost its composed bounds.");
        }
    }

    private void UpdateGunslingerTurn(ulong entityKey, GunslingerShotAttempt attempt)
    {
        ulong elapsed = tick - attempt.Aim.AcquisitionTick;
        float fraction = elapsed >= GunslingerTurnTicks ? 1f : elapsed / (float)GunslingerTurnTicks;
        float eased = fraction - MathF.Sin(fraction * MathF.Tau) / MathF.Tau;
        Quaternion rotation = Quaternion.Slerp(attempt.StartRotation, attempt.FinalRotation, eased);
        infantryAnimations[entityKey].Facing = Vector3.Normalize(Vector3.Transform(Vector3.UnitZ, rotation));
    }
}
