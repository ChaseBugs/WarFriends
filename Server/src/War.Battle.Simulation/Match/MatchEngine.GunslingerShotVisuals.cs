using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const string GunslingerStartClip = "colt_shooting_start";
    private const string GunslingerFireClip = "colt_shooting_loop";
    private const string GunslingerStopClip = "colt_shooting_stop";

    private (string Clip, float Seconds)? GunslingerShotPose(ulong entityKey)
    {
        GunslingerShotAttempt? attempt = GunslingerAttempt(entityKey);
        if (attempt == null)
        {
            return null;
        }

        ulong elapsed = tick - attempt.Aim.AcquisitionTick;
        ulong hideTick = GunslingerFiringClock.HideTick(attempt.Aim.AcquisitionTick);
        if (tick >= hideTick)
        {
            return (GunslingerStopClip, (tick - hideTick) / (float)MatchManifest.TickRate);
        }

        float? fireSeconds = GunslingerFiringClock.FireLoopSeconds(attempt.LoopEntry, elapsed,
            enemyPoses!.Clip(GunslingerStartClip).Length);
        return fireSeconds.HasValue ? (GunslingerFireClip, fireSeconds.Value) :
            (GunslingerStartClip, elapsed / (float)MatchManifest.TickRate);
    }

    private Vector3 GunslingerFiringMuzzle(ulong entityKey, GunslingerShotAttempt attempt)
    {
        CoopEnemyMuzzleCatalog muzzles = enemyMuzzles ??
            throw new InvalidDataException("Gunslinger callback lost its recovered rifle muzzle catalog.");
        float seconds = GunslingerFiringClock.FireLoopSeconds(attempt.LoopEntry,
            tick - attempt.Aim.AcquisitionTick, enemyPoses!.Clip(GunslingerStartClip).Length) ??
            throw new InvalidDataException("Gunslinger firing reached no native fire-loop phase.");
        var entity = activeArmyEntities[entityKey];
        Vector3 facing = infantryAnimations[entityKey].Facing;
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(facing.X, facing.Z));
        return muzzles.Place(GunslingerFireClip, new Vector3(entity.X, entity.Y, entity.Z), rotation, seconds).Position;
    }
}
