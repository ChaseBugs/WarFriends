using System.Numerics;

namespace War.BattleServer;

internal sealed record AssaulterCornerAttempt(AssaulterPreparedAim Aim, CoopInfantryShotBatch Batch,
    ulong NextShotEligibleTick, ulong? CallbackTick);

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, AssaulterCornerAttempt> _assaulterAttempts = [];

    /// <summary>Reads the last host attempt and its frozen source inputs without asserting a fired shot.</summary>
    internal AssaulterCornerAttempt? AssaulterAttempt(ulong entityKey)
    {
        return _assaulterAttempts.GetValueOrDefault(entityKey);
    }

    private void AdvanceAssaulterPreparations()
    {
        foreach (var (entityKey, corner) in _assaulterCorners.OrderBy(row => row.Key))
        {
            AssaulterCornerAttempt? previous = AssaulterAttempt(entityKey);
            if (previous?.CallbackTick != null)
            {
                // A successful preparation remains pending until its callback and
                // volley complete. A new target must not overwrite that source latch.
                continue;
            }

            ulong? eligibleTick = previous?.NextShotEligibleTick ?? corner.FirstShotEligibleTick;
            if (!eligibleTick.HasValue || tick < eligibleTick.Value)
            {
                continue;
            }

            TryPrepareAssaulter(entityKey);
        }
    }

    private void TryPrepareAssaulter(ulong entityKey)
    {
        AssaulterPreparedAim? aim = CaptureAssaulterAim(entityKey);
        if (aim == null)
        {
            // Unresolved opponent geometry cannot authorize either a substituted
            // player target or a fabricated source rejection/cooldown transition.
            return;
        }

        ArmyBaseShotStats shot = armyShots.GetValueOrDefault(entityKey) ??
            throw new InvalidDataException("Assaulter preparation lost its composed shot authority.");
        // PrepareToShoot calls StartShooting before its Corner side/angle test.
        // Even a rejected side consumes the original batch and real/fake draws.
        CoopInfantryShotBatch batch = AssaulterShotBatchPolicy.Create(shot, armyChoice, NextArmyFloat);
        CardUnitInitialPoint point = cardEnemyPoints?.Find(entityKey) ??
            throw new InvalidDataException("Assaulter preparation lost its source Corner.");
        if (point.CornerDirection is not Vector3 direction || point.CornerRightSide is not bool rightSide)
        {
            throw new InvalidDataException("Assaulter preparation lost its source Corner geometry.");
        }

        var entity = activeArmyEntities[entityKey];
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        bool canExpose = CornerShotPolicy.CanExpose(direction, rightSide, position, aim.TargetPosition);
        ulong nextTick = NextAssaulterShotTick(shot);
        // uncoverLength always reads player_look_right3, including left-side shots.
        ulong? callback = canExpose
            ? CoopShotCallbackClock.CallbackTick(tick, enemyPoses?.Clip("player_look_right3").Length ??
                throw new InvalidDataException("Assaulter preparation lost its source uncover clip."))
            : null;
        _assaulterAttempts[entityKey] = new AssaulterCornerAttempt(aim, batch, nextTick, callback);
    }
}
