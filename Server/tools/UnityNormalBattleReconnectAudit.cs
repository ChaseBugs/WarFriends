using System;
using System.IO;
using System.Threading.Tasks;

using UnityEngine;

using Newtonsoft.Json;
using War.Protocol;

namespace WarFriends.Validation
{
    /// <summary>Checks a real Backend-issued transport replacement inside a normally loaded battle scene.</summary>
    public static class UnityNormalBattleReconnectAudit
    {
        private const ulong RequiredResumedTicks = 90;
        private const int MaximumMarkerCharacters = 1024;
        private static Task _reconnect;
        private static SelfHostedBattleClient _client;
        private static PlayerController _localPlayer;
        private static PlayerController _opponent;
        private static string _matchId;
        private static string _failureType;
        private static ulong _beforeTick;
        private static ulong _resumedTick;
        private static ulong _beforeEventId;
        private static int _rebuildCount;
        private static bool _hasResumed;
        private static bool _hasCompleted;

        private static string MarkerPath
        {
            get { return Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_MARKER"); }
        }

        /// <summary>Requires both peers to retain the running scene until the replacement has resumed.</summary>
        public static bool Observe(GameController game, SelfHostedBattleClient client)
        {
            if (string.IsNullOrEmpty(MarkerPath))
            {
                return true;
            }
            if (_failureType != null)
            {
                return false;
            }
            try
            {
                if (Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_SELF") != "1")
                {
                    return ObservePeer(client);
                }
                return ObserveInitiator(game, client);
            }
            catch (Exception failure)
            {
                // Keep the gate failed without copying session-bearing exception messages into reports.
                _failureType = failure.GetBaseException().GetType().Name;
                Detach();
                return false;
            }
        }

        /// <summary>Reports bounded observations without recording grants, access tokens or network keys.</summary>
        public static object Capture()
        {
            return new
            {
                isInitiator = Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_SELF") == "1",
                hasStarted = _reconnect != null,
                hasCompleted = _hasCompleted,
                failureType = _failureType,
                rebuildCount = _rebuildCount,
                beforeTick = _beforeTick,
                resumedTick = _resumedTick,
                requiredResumedTicks = RequiredResumedTicks
            };
        }

        private static bool ObservePeer(SelfHostedBattleClient client)
        {
            if (!File.Exists(MarkerPath) || !IsRunning(client))
            {
                return false;
            }
            string marker = File.ReadAllText(MarkerPath);
            if (marker.Length > MaximumMarkerCharacters)
            {
                throw new FormatException("Reconnect completion marker exceeds its bound.");
            }
            CompletionMarker completed = JsonConvert.DeserializeObject<CompletionMarker>(marker);
            if (completed == null || completed.MatchId != client.State.MatchId)
            {
                throw new FormatException("Reconnect completion belongs to a different match.");
            }
            _hasCompleted = true;
            return true;
        }

        private static bool ObserveInitiator(GameController game, SelfHostedBattleClient client)
        {
            if (_hasCompleted)
            {
                return true;
            }
            if (_reconnect == null)
            {
                Begin(game, client);
                return false;
            }
            if (!_reconnect.IsCompleted)
            {
                return false;
            }
            _reconnect.GetAwaiter().GetResult();
            RequireRetainedScene(game, client);
            if (!IsRunning(client))
            {
                return false;
            }
            if (!_hasResumed)
            {
                _hasResumed = true;
                _resumedTick = client.State.ServerTick;
            }
            return CompleteAfterProgress(client);
        }

        private static void Begin(GameController game, SelfHostedBattleClient client)
        {
            if (!IsRunning(client) || game.mainPlayerController == null || game.opponent == null)
            {
                throw new InvalidOperationException("Reconnect requires a running scene with both players.");
            }
            _client = client;
            _localPlayer = game.mainPlayerController;
            _opponent = game.opponent;
            _matchId = client.State.MatchId;
            _beforeTick = client.State.ServerTick;
            _beforeEventId = client.ProcessedEventId;
            client.FullSnapshotRebuild += RecordRebuild;
            _reconnect = client.ReconnectWithRecoveredSession();
            UnityNormalWeaponSelectionAudit.RequireSelectionBlockedDuringReconnect(client);
        }

        private static void RequireRetainedScene(GameController game, SelfHostedBattleClient client)
        {
            if (client != _client || client.State == null || client.State.MatchId != _matchId ||
                game.mainPlayerController != _localPlayer || game.opponent != _opponent ||
                !game.gameIsRunning || PlayerController.players.Count != 2 ||
                client.State.ServerTick < _beforeTick || client.ProcessedEventId < _beforeEventId)
            {
                throw new InvalidOperationException("Reconnect did not retain the normal battle scene and state.");
            }
        }

        private static bool CompleteAfterProgress(SelfHostedBattleClient client)
        {
            if (client.State.ServerTick < _resumedTick ||
                client.State.ServerTick - _resumedTick < RequiredResumedTicks)
            {
                return false;
            }
            if (_rebuildCount != 1)
            {
                throw new InvalidOperationException("Reconnect must rebuild the scene snapshot exactly once.");
            }
            string pendingMarker = MarkerPath + ".pending";
            File.WriteAllText(pendingMarker,
                JsonConvert.SerializeObject(new CompletionMarker { MatchId = _matchId }) + "\n");
            File.Move(pendingMarker, MarkerPath);
            _hasCompleted = true;
            Detach();
            return true;
        }

        private static bool IsRunning(SelfHostedBattleClient client)
        {
            return client != null && client.IsConnected && !client.IsReconnecting &&
                client.State != null && client.State.Phase == BattlePhase.Running;
        }

        private static void RecordRebuild()
        {
            _rebuildCount++;
        }

        private static void Detach()
        {
            if (_client != null)
            {
                _client.FullSnapshotRebuild -= RecordRebuild;
            }
        }

        private sealed class CompletionMarker
        {
            public string MatchId { get; set; }
        }
    }
}
