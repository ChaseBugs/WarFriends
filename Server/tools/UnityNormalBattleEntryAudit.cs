using System;
using System.IO;
using System.Linq;

using UnityEngine;

using Newtonsoft.Json;
using War.Protocol;

namespace WarFriends.Validation
{
    /// <summary>Drives ordinary lobby actions and observes two independently booted Unity participants.</summary>
    public static class UnityNormalBattleEntryAudit
    {
        private static bool _hasStartedSearch;
        private static bool _hasReportedLobbyReady;
        private static bool _hasSubmittedCards;
        private static bool _hasReachedRunning;
        private static GameController _game;

        /// <summary>Gets whether this disposable process participates in the normal two-Unity battle gate.</summary>
        public static bool IsEnabled
        {
            get { return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_SELF")); }
        }

        /// <summary>Starts source matchmaking and waits for source loading plus authoritative running state.</summary>
        public static bool Observe()
        {
            if (_game == null)
            {
                _game = Resources.FindObjectsOfTypeAll<GameController>()
                    .First(controller => controller.gameObject.scene.IsValid());
            }
            if (!BothLobbiesAreReady())
            {
                return false;
            }
            if (!_hasStartedSearch)
            {
                _hasStartedSearch = true;
                _game.SwitchToDeathMatch();
                _game.gameControllerDeathMatch.StartRandomMatchMaking();
            }

            SelfHostedBattleClient client = SelfHostedBattleClient.Active;
            if (!_hasSubmittedCards && client != null && client.IsConnected && _game.opponent != null &&
                MatchManager.matchState == MatchState.BothPlayersConnected)
            {
                _hasSubmittedCards = true;
                _game.gameControllerDeathMatch.FinishChoosingCards();
            }
            if (!_hasReachedRunning && client != null && client.State != null &&
                client.State.Phase == BattlePhase.Running && _game.gameIsRunning)
            {
                _hasReachedRunning = true;
                File.WriteAllText(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_SELF"),
                    JsonConvert.SerializeObject(new { matchId = client.State.MatchId }) + "\n");
            }
            return _hasReachedRunning && File.Exists(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_PEER"));
        }

        private static bool BothLobbiesAreReady()
        {
            if (!_hasReportedLobbyReady)
            {
                _hasReportedLobbyReady = true;
                File.WriteAllText(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_SELF") + ".ready", "ready\n");
            }
            return File.Exists(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_PEER") + ".ready");
        }

        /// <summary>Returns bounded diagnostic state without session tokens or credentials.</summary>
        public static object Capture()
        {
            SelfHostedBattleClient client = SelfHostedBattleClient.Active;
            return new
            {
                hasStartedSearch = _hasStartedSearch,
                hasSubmittedCards = _hasSubmittedCards,
                hasReachedRunning = _hasReachedRunning,
                isConnected = client != null && client.IsConnected,
                matchId = client == null || client.State == null ? null : client.State.MatchId,
                phase = client == null || client.State == null ? null : client.State.Phase.ToString(),
                matchState = MatchManager.matchState.ToString(),
                players = PlayerController.players.Count
            };
        }
    }
}
