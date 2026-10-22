using System;
using System.Linq;

using Google2u;
using UnityEngine;

namespace WarFriends.Validation
{
    /// <summary>Records the recovered random-match routing conditions without changing progression or device history.</summary>
    public static class UnityNormalMatchmakingReadinessAudit
    {
        private const float RepeatedLossBotThreshold = 3f;

        /// <summary>Explains whether the booted scene selects self-hosted admission or the recovered local-bot path.</summary>
        public static object Capture(GameController game, LevelManager levels)
        {
            try
            {
                GameVariables variables = FindSceneComponent<GameVariables>();
                UserDeviceManager device = FindSceneComponent<UserDeviceManager>();
                StatsManager statistics = FindSceneComponent<StatsManager>();
                if (game == null || levels == null || variables == null || device == null || statistics == null)
                {
                    return new { canEvaluate = false, failureType = "MissingReadySceneManagers" };
                }
                float averageFps = device.GetAverageMatchFPS();
                bool hasFiniteAverageFps = !float.IsNaN(averageFps) && !float.IsInfinity(averageFps);
                bool hasMeasuredHighPing = PhotonConnectionManager.HasMeasuredRegionPingAbove(
                    (float)variables.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE);
                bool usesEasyBot = BotManager.useEasyBot;
                bool isSlowDevice = device.IsSlowDevice();
                bool hasRepeatedLosses = statistics.deathMatchLossesInRow >= RepeatedLossBotThreshold;
                return new
                {
                    canEvaluate = true,
                    displayRank = levels.currentLevel.displayNumber,
                    easyBotThroughRank = (float)variables.constants.GetRow(
                        Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE,
                    minimumAverageFps = (float)variables.matchMakingConstants.GetRow(
                        MatchMakingConstants.rowIds.MatchmakingMinAverageFps).FLOATVALUE,
                    averageFps = hasFiniteAverageFps ? (float?)averageFps : null,
                    hasFiniteAverageFps,
                    hasMeasuredHighPing,
                    usesEasyBot,
                    isSlowDevice,
                    hasRepeatedLosses,
                    canUseSelfHostedMatchmaking = !hasMeasuredHighPing && !usesEasyBot && !isSlowDevice && !hasRepeatedLosses,
                    activeController = game.mainController == null ? "" : game.mainController.GetType().Name
                };
            }
            catch (Exception failure)
            {
                // Keep diagnostics explicit without replacing the original boot exception counters.
                return new { canEvaluate = false, failureType = failure.GetType().Name };
            }
        }

        private static T FindSceneComponent<T>() where T : Component
        {
            return Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(component => component.gameObject.scene.IsValid());
        }
    }
}
