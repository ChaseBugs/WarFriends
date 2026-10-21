using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const ulong AssaulterShotTurnTicks = 9;
    private const ulong AssaulterRoundHideTicks = MatchManifest.TickRate / 2 + 1;
    private readonly Dictionary<ulong, AssaulterVolleyState> _assaulterVolleys = [];
    private readonly CoopAssaulterQueueCatalog? _assaulterQueue;

    private void BeginAssaulterVolley(ulong entityKey, AssaulterCornerAttempt attempt, CardUnitInitialPoint point)
    {
        EnemyPoseCatalog poses = enemyPoses ?? throw new InvalidDataException("Assaulter lost source animation clips.");
        bool isRightSide = point.CornerRightSide ?? throw new InvalidDataException("Assaulter lost its Corner side.");
        string look = isRightSide ? "player_look_right3" : "player_look_left3";
        string fire = isRightSide ? "player_fire_right3" : "player_fire_left3";
        string cover = isRightSide ? "player_right_coverBack3" : "player_left_coverBack3";
        var clips = new CoopCornerPreparationPlan.Clips(look, fire, poses.Clip(look).Length, poses.Clip(cover).Length);
        BattleInfantryAnimationFrame? previous = AssaulterVolleyFrame(entityKey);
        CoopCornerPreparationPlan plan = previous == null
            ? CoopCornerPreparationPlan.FromIdle(clips) : CoopCornerPreparationPlan.FromFrame(clips, previous);
        Vector3 facing = infantryAnimations[entityKey].Facing;
        Quaternion start = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(facing.X, facing.Z));
        var entity = activeArmyEntities[entityKey];
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        Vector3 outward = -(point.CornerDirection ??
            throw new InvalidDataException("Assaulter lost Corner direction."));
        Vector3 toward = attempt.Aim.TargetPosition - position;
        float angle = MathF.Atan2(Vector3.Cross(-toward, outward).Y, Vector3.Dot(-toward, outward));
        Quaternion final = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(outward.X, outward.Z) - angle);
        _assaulterVolleys[entityKey] = new AssaulterVolleyState(attempt, plan, clips, (start, final));
    }

    private BattleInfantryAnimationFrame? AssaulterVolleyFrame(ulong entityKey)
    {
        if (!_assaulterVolleys.TryGetValue(entityKey, out AssaulterVolleyState? volley))
        {
            return null;
        }

        ulong? lastRound = volley.RoundOffsets.Count == 0 ? null : volley.StartTick + volley.RoundOffsets[^1];
        if (lastRound.HasValue && tick >= lastRound.Value + AssaulterRoundHideTicks)
        {
            ulong hideTick = lastRound.Value + AssaulterRoundHideTicks;
            float seconds = (tick - hideTick) / (float)MatchManifest.TickRate;
            bool isIdle = seconds >= volley.Clips.CoverSeconds;
            var frame = new BattleInfantryAnimationFrame { SampleTick = tick };
            frame.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = isIdle ? "idle_1" : volley.Clips.Cover,
                TimeSeconds = isIdle ? seconds - volley.Clips.CoverSeconds : seconds,
                Weight = 1f,
                Wrap = isIdle ? BattleInfantryAnimationWrap.Loop : BattleInfantryAnimationWrap.Clamp
            });
            return frame;
        }

        if (lastRound.HasValue)
        {
            var frame = new BattleInfantryAnimationFrame { SampleTick = tick };
            frame.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = volley.Clips.Fire, TimeSeconds = (tick - lastRound.Value) / (float)MatchManifest.TickRate,
                Weight = 1f, Wrap = BattleInfantryAnimationWrap.ClampForever
            });
            return frame;
        }

        return volley.Preparation.Sample(tick - volley.StartTick, tick);
    }

    private Vector3 AssaulterVolleyMuzzle(ulong entityKey, AssaulterVolleyState volley)
    {
        if (enemyMuzzles == null || _assaulterQueue == null)
        {
            throw new InvalidDataException("Assaulter lost native queued muzzle observations.");
        }

        ulong elapsed = tick - volley.StartTick;
        CoopQueuedMuzzleSample? sample;
        if (volley.RoundOffsets.Count == 0 && !volley.Preparation.UsesFreshLookClock)
        {
            BattleInfantryAnimationClip clip = volley.Preparation.Sample(elapsed - 1, tick - 1).Clips.Single();
            CoopMuzzlePose pose = enemyMuzzles.Place(clip.ClipName, Vector3.Zero,
                Quaternion.Identity, clip.TimeSeconds);
            sample = new CoopQueuedMuzzleSample(clip.TimeSeconds, pose.Position, pose.Rotation);
        }
        else
        {
            sample = CoopCornerFiringMuzzle.Sample(new CoopCornerFiringClock(volley.Clips.Look, volley.Clips.Fire,
                elapsed, volley.RoundOffsets), _assaulterQueue, enemyMuzzles);
        }

        if (sample == null)
        {
            throw new InvalidDataException("Assaulter callback has no source firing muzzle.");
        }

        var entity = activeArmyEntities[entityKey];
        Vector3 facing = infantryAnimations[entityKey].Facing;
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(facing.X, facing.Z));
        return new Vector3(entity.X, entity.Y, entity.Z) + Vector3.Transform(sample.LocalPosition, rotation);
    }
}
