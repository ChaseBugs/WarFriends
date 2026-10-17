using System;
using War.Protocol;

namespace War.Client
{
    /// <summary>
    /// Recognizes only the two partial-weight obstacle frames verified against independent prefab replay.
    /// </summary>
    internal static class InfantryObstaclePreparationFrame
    {
        private const float SourceTolerance = 0.000001f;
        private const float FirstStepSeconds = 1f / 30f;
        private const float CompletedCrawlSampleSeconds = 0.5333335f;
        private const float InitialCrawlWeight = 1f / 3f;
        private const float FirstBeginWeight = 2f / 3f;

        internal static bool IsReviewed(BattleInfantryAnimationFrame frame)
        {
            if (frame.Clips.Count == 1)
            {
                BattleInfantryAnimationClip begin = frame.Clips[0];
                return begin.ClipName == "stand_up_begin" && Near(begin.TimeSeconds, FirstStepSeconds) &&
                    Near(begin.Weight, FirstBeginWeight);
            }
            if (frame.Clips.Count != 2)
            {
                return false;
            }

            BattleInfantryAnimationClip crawl = frame.Clips[0];
            BattleInfantryAnimationClip start = frame.Clips[1];
            // The clamped crawl clock uses the canonical completed sample from the recovered fixture.
            return crawl.ClipName == "stand_up_crawl" && Near(crawl.TimeSeconds, CompletedCrawlSampleSeconds) &&
                Near(crawl.Weight, InitialCrawlWeight) && start.ClipName == "stand_up_begin" &&
                start.TimeSeconds == 0f && start.Weight == 0f;
        }

        private static bool Near(float actual, float expected)
        {
            return Math.Abs(actual - expected) <= SourceTolerance;
        }
    }
}
