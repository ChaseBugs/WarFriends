using System;
using System.Collections.Generic;
using System.IO;
using War.Protocol;

namespace War.Client
{
    /// <summary>Validates and copies a confirmed, reviewed two-state base-layer animation frame.</summary>
    public sealed class InfantryAnimationFrameView
    {
        private const int MaximumBaseStates = 2;
        private const double TickRate = 30d;
        private const double WeightTolerance = 0.0001d;
        private const double PriorIdleDurationSeconds = 1d;
        private static readonly Dictionary<string, BattleInfantryAnimationWrap> SourceWraps =
            new Dictionary<string, BattleInfantryAnimationWrap>(StringComparer.Ordinal)
            {
                { "run_0", BattleInfantryAnimationWrap.Loop },
                { "idle", BattleInfantryAnimationWrap.Loop },
                { "idle_1", BattleInfantryAnimationWrap.Loop },
                { "stand_up_crawl", BattleInfantryAnimationWrap.ClampForever },
                { "stand_up_begin", BattleInfantryAnimationWrap.Clamp },
                { "rifle_shot_loop", BattleInfantryAnimationWrap.ClampForever },
                { "player_look_right3", BattleInfantryAnimationWrap.Clamp },
                { "player_fire_right3", BattleInfantryAnimationWrap.ClampForever },
                { "player_right_coverBack3", BattleInfantryAnimationWrap.Clamp },
                { "player_look_left3", BattleInfantryAnimationWrap.Clamp },
                { "player_fire_left3", BattleInfantryAnimationWrap.ClampForever },
                { "player_left_coverBack3", BattleInfantryAnimationWrap.Clamp }
            };

        private readonly BattleInfantryObservedPoseReference _observedPose;

        /// <summary>Gets the host observation tick, independently of the last root movement tick.</summary>
        public ulong SampleTick { get; }

        /// <summary>Gets the isolated read-only collection of source samples.</summary>
        public IReadOnlyList<InfantryAnimationClipView> Clips { get; }

        /// <summary>Gets an isolated reference to a validated local catalog sample, or null for clip-only frames.</summary>
        public BattleInfantryObservedPoseReference ObservedPose =>
            _observedPose == null ? null : _observedPose.Clone();

        private InfantryAnimationFrameView(BattleInfantryAnimationFrame source)
        {
            SampleTick = source.SampleTick;
            _observedPose = source.ObservedPose == null ? null : source.ObservedPose.Clone();
            var clips = new List<InfantryAnimationClipView>(source.Clips.Count);
            foreach (BattleInfantryAnimationClip clip in source.Clips)
            {
                clips.Add(new InfantryAnimationClipView(clip));
            }

            Clips = clips.AsReadOnly();
        }

        internal static InfantryAnimationFrameView FromEnemy(
            BattleCoopEnemySpawn enemy, MatchSnapshot snapshot, string observedPoseCatalogRevision)
        {
            BattleInfantryAnimationFrame frame = enemy.InfantryAnimation;
            if (frame == null)
            {
                return null;
            }
            if (snapshot.Phase != BattlePhase.Running || enemy.Behaviour != "Assaulter" || enemy.Health <= 0f ||
                enemy.CurrentRotation == null || frame.SampleTick != snapshot.ServerTick ||
                frame.SampleTick < enemy.PoseTick || frame.SampleTick < snapshot.StartTick ||
                frame.Clips.Count == 0 || frame.Clips.Count > MaximumBaseStates)
            {
                throw new InvalidDataException("Infantry animation requires a live, confirmed source pose and clock.");
            }

            if (frame.ObservedPose != null)
            {
                ValidateObservedPose(frame, snapshot, observedPoseCatalogRevision);
            }
            else
            {
                ValidateClips(frame, snapshot);
            }
            ValidateWalkingMirror(frame, enemy);
            return new InfantryAnimationFrameView(frame);
        }

        private static void ValidateObservedPose(
            BattleInfantryAnimationFrame frame, MatchSnapshot snapshot, string negotiatedRevision)
        {
            if (negotiatedRevision.Length == 0 || frame.ObservedPose.CatalogRevision != negotiatedRevision)
            {
                throw new InvalidDataException("Observed pose references require a negotiated renderer capability.");
            }

            ObservedInfantryPoseSample sample = ObservedInfantryPoseCatalogData.BuiltIn.GetSample(frame.ObservedPose);
            if (sample.Clips.Count != frame.Clips.Count ||
                sample.ObservationTick > frame.SampleTick - snapshot.StartTick)
            {
                throw new InvalidDataException("Observed pose clip count or observation clock is inconsistent.");
            }

            for (int index = 0; index < sample.Clips.Count; index++)
            {
                if (!sample.Clips[index].Equals(frame.Clips[index]))
                {
                    throw new InvalidDataException("Observed pose reference disagrees with its exact source clips.");
                }
            }
        }

        private static void ValidateClips(BattleInfantryAnimationFrame frame, MatchSnapshot snapshot)
        {
            var names = new HashSet<string>(StringComparer.Ordinal);
            double totalWeight = 0d;
            // The reviewed initial idle can begin partway through its one-second source clip.
            double maximumTime = (snapshot.ServerTick - snapshot.StartTick) / TickRate + PriorIdleDurationSeconds;
            foreach (BattleInfantryAnimationClip clip in frame.Clips)
            {
                BattleInfantryAnimationWrap expectedWrap;
                if (!SourceWraps.TryGetValue(clip.ClipName, out expectedWrap) || clip.Wrap != expectedWrap ||
                    !names.Add(clip.ClipName) || !IsFinite(clip.TimeSeconds) || clip.TimeSeconds < 0f ||
                    clip.TimeSeconds > maximumTime || !IsFinite(clip.Weight) || clip.Weight < 0f || clip.Weight > 1f)
                {
                    throw new InvalidDataException("Infantry animation has an unsupported source sample.");
                }

                totalWeight += clip.Weight;
            }
            if (Math.Abs(totalWeight - 1d) > WeightTolerance && !InfantryObstaclePreparationFrame.IsReviewed(frame))
            {
                throw new InvalidDataException(
                    "Animation weights must conserve one frame or match a reviewed obstacle preparation sample.");
            }
        }

        private static void ValidateWalkingMirror(BattleInfantryAnimationFrame frame, BattleCoopEnemySpawn enemy)
        {
            if (enemy.InfantryVisualClip.Length == 0)
            {
                return;
            }

            float seconds = (float)((enemy.InfantryVisualSampleTick - enemy.InfantryVisualStartTick) / TickRate);
            BattleInfantryAnimationClip clip = frame.Clips[0];
            if (frame.Clips.Count != 1 || clip.ClipName != enemy.InfantryVisualClip ||
                frame.SampleTick != enemy.InfantryVisualSampleTick || clip.TimeSeconds != seconds || clip.Weight != 1f)
            {
                throw new InvalidDataException("Legacy walking metadata disagrees with the complete animation frame.");
            }
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
