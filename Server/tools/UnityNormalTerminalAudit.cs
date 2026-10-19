using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;
using War.Protocol;

namespace WarFriends.Validation
{
    /// <summary>Observes server-confirmed termination and the recovered result-screen pipeline.</summary>
    public static class UnityNormalTerminalAudit
    {
        private static Task _forfeit;
        private static string _failureType;
        private static bool _hasObservedEnded;
        private static bool _hasShownResults;
        private static string _endReason;
        private static string _serverResponse;

        /// <summary>Gets whether this run explicitly requires the normal result-screen continuation.</summary>
        public static bool IsEnabled
        {
            get { return Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_TERMINAL") == "1"; }
        }

        /// <summary>Uses an authenticated forfeit only after both peers finish reconnect observation.</summary>
        public static bool Observe(GameController game, SelfHostedBattleClient client)
        {
            if (!IsEnabled)
            {
                return true;
            }
            try
            {
                string self = Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_SELF") + ".terminal-ready";
                string peer = Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_PEER") + ".terminal-ready";
                if (!File.Exists(self))
                {
                    File.WriteAllText(self, "ready\n");
                }
                if (!File.Exists(peer))
                {
                    return false;
                }
                if (_forfeit == null &&
                    Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_SELF") == "1")
                {
                    _forfeit = client.Forfeit();
                }
                if (_forfeit != null && _forfeit.IsFaulted)
                {
                    throw _forfeit.Exception.GetBaseException();
                }
                _hasObservedEnded |= client.State != null && client.State.Phase == BattlePhase.Ended;
                _endReason = game.gameEndReason.ToString();
                _serverResponse = game.gameEndServerResponse.ToString();
                _hasShownResults = Resources.FindObjectsOfTypeAll<EndScreen>()
                    .Any(screen => screen.gameObject.scene.IsValid() && screen.gameObject.activeInHierarchy);
                return _hasObservedEnded && _hasShownResults &&
                    game.gameEndServerResponse == GameController.ServerResponse.Success;
            }
            catch (Exception failure)
            {
                // Record only a type; transport exception messages can contain session details.
                _failureType = failure.GetBaseException().GetType().Name;
                return false;
            }
        }

        /// <summary>Captures terminal observations independently of the earlier Running milestone.</summary>
        public static object Capture()
        {
            return new
            {
                isEnabled = IsEnabled,
                hasRequestedForfeit = _forfeit != null,
                hasObservedEnded = _hasObservedEnded,
                hasShownResults = _hasShownResults,
                endReason = _endReason,
                serverResponse = _serverResponse,
                failureType = _failureType
            };
        }
    }
}
