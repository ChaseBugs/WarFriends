using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
        private static readonly FieldInfo ResourceLoads = typeof(GameController).GetField(
            "_battleResourceLoads", BindingFlags.Instance | BindingFlags.NonPublic);
        private static string _assignedMapId;
        private static string _assignedMapRevision;
        private static string _assignedMatchId;
        private static string _loadingFailureType;
        private static string _loadingFailureSource;
        private static readonly Dictionary<string, double> LoadingStages = new Dictionary<string, double>();
        private static bool _hasCompletedReconnect;
        private static bool _hasCompletedTerminal;

        /// <summary>Gets whether this disposable process participates in the normal two-Unity battle gate.</summary>
        public static bool IsEnabled
        {
            get { return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_SELF")); }
        }

        /// <summary>Requires both normal participants to have observed authoritative and local Running state.</summary>
        public static bool HasCompletedEntry
        {
            get
            {
                return _hasReachedRunning && _hasCompletedReconnect &&
                    (!UnityNormalTerminalAudit.IsEnabled || _hasCompletedTerminal) &&
                    File.Exists(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_PEER"));
            }
        }

        /// <summary>Records only known source milestones, without copying message bodies or session values.</summary>
        public static void RecordStageLog(string condition)
        {
            if (!IsEnabled || string.IsNullOrEmpty(condition))
            {
                return;
            }
            string stage = ResolveStageName(condition);
            if (stage != null && !LoadingStages.ContainsKey(stage))
            {
                LoadingStages.Add(stage, Time.realtimeSinceStartup);
            }
        }

        private static string ResolveStageName(string condition)
        {
            if (condition == "ALL PLAYERS CONNECTED")
            {
                return "playersConnected";
            }
            if (condition == "StopMessageQueue")
            {
                return "cardsAccepted";
            }
            if (condition.StartsWith("Aquiire map id ", StringComparison.Ordinal))
            {
                return "mapSelected";
            }
            if (condition == "Map Loaded")
            {
                return "mapLoaded";
            }
            if (condition.StartsWith("Set time to: ", StringComparison.Ordinal))
            {
                return "pvpSetupStarted";
            }
            if (condition.StartsWith("Create player instance at ", StringComparison.Ordinal))
            {
                return "localPlayerPlaced";
            }
            return null;
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
            CaptureLoadingFailure();
            if (!_hasStartedSearch)
            {
                _hasStartedSearch = true;
                _game.SwitchToDeathMatch();
                _game.gameControllerDeathMatch.StartRandomMatchMaking();
            }

            SelfHostedBattleClient client = SelfHostedBattleClient.Active;
            if (client != null && client.IsConnected && client.State != null)
            {
                _assignedMapId = client.MapId;
                _assignedMapRevision = client.MapRevision;
                _assignedMatchId = client.State.MatchId;
            }
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
            if (_hasCompletedReconnect)
            {
                _hasCompletedTerminal = UnityNormalTerminalAudit.Observe(_game, client);
                return HasCompletedEntry;
            }
            if (_hasReachedRunning && File.Exists(Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_PEER")) &&
                UnityNormalWeaponSelectionAudit.Observe(_game, client) &&
                UnityNormalReloadAudit.Observe(_game, client))
            {
                _hasCompletedReconnect = UnityNormalBattleReconnectAudit.Observe(_game, client);
            }
            return HasCompletedEntry;
        }

        private static void CaptureLoadingFailure()
        {
            BattleResourceLoadScope scope = ResourceLoads.GetValue(_game) as BattleResourceLoadScope;
            if (_loadingFailureType != null || scope == null || scope.FirstFailure == null)
            {
                return;
            }
            Exception failure = scope.FirstFailure.GetBaseException();
            _loadingFailureType = failure.GetType().Name;
            _loadingFailureSource = (failure.StackTrace ?? "").Split('\n')
                .FirstOrDefault(frame => frame.Contains("Assets"));
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
                matchId = _assignedMatchId,
                mapId = _assignedMapId,
                mapRevision = _assignedMapRevision,
                loadingFailureType = _loadingFailureType,
                loadingFailureSource = _loadingFailureSource,
                loadingStages = LoadingStages,
                reconnect = UnityNormalBattleReconnectAudit.Capture(),
                weaponSelection = UnityNormalWeaponSelectionAudit.Capture(),
                reload = UnityNormalReloadAudit.Capture(),
                terminal = UnityNormalTerminalAudit.Capture(),
                phase = client == null || client.State == null ? null : client.State.Phase.ToString(),
                matchState = MatchManager.matchState.ToString(),
                players = PlayerController.players.Count
            };
        }
    }
}
