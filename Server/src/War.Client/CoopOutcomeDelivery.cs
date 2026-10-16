using System;
using War.Protocol;

namespace War.Client
{
    /// <summary>Delivers one validated shared co-op outcome to a scene's finish callback.</summary>
    public sealed class CoopOutcomeDelivery
    {
        private readonly string _matchId;
        private readonly string _manifestHash;
        private readonly string _playerId;
        private readonly Action<ClientGameEndReason> _onFinished;
        private bool _isDelivering;
        private bool _hasDelivered;

        /// <summary>Binds delivery to one admitted match and local player for the lifetime of a scene.</summary>
        public CoopOutcomeDelivery(string matchId, string manifestHash, string playerId,
            Action<ClientGameEndReason> onFinished)
        {
            if (string.IsNullOrEmpty(matchId) || string.IsNullOrEmpty(manifestHash) ||
                string.IsNullOrEmpty(playerId))
            {
                throw new ArgumentException("A match, manifest and local player identity are required.");
            }

            _matchId = matchId;
            _manifestHash = manifestHash;
            _playerId = playerId;
            _onFinished = onFinished ?? throw new ArgumentNullException(nameof(onFinished));
        }

        /// <summary>Ignores unrelated and replayed states; callback failures remain visible and retryable.</summary>
        public bool ApplySnapshot(MatchSnapshot snapshot)
        {
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            if (_hasDelivered || _isDelivering || snapshot.MatchId != _matchId ||
                snapshot.ManifestHash != _manifestHash)
            {
                return false;
            }

            // The shared mission finish is distinct from a running peer's private KIA or local departure.
            if (snapshot.Coop == null || string.IsNullOrEmpty(snapshot.Coop.MissionType))
            {
                return false;
            }

            ClientGameEndReason reason = CoopOutcomeProjection.ForPlayer(snapshot, _playerId);
            if (reason == ClientGameEndReason.None || HasLocalDeparture(snapshot))
            {
                return false;
            }

            return Deliver(reason);
        }

        private bool HasLocalDeparture(MatchSnapshot snapshot)
        {
            foreach (BattlePlayerState player in snapshot.Players)
            {
                if (player.PlayerId == _playerId)
                {
                    // Local departure already uses its recovered FinishGame/EndMission/Disconnect path.
                    return player.CoopDeparted;
                }
            }

            return false;
        }

        private bool Deliver(ClientGameEndReason reason)
        {
            _isDelivering = true;
            try
            {
                // Scene reset can synchronously publish another snapshot during this callback.
                _onFinished(reason);
                _hasDelivered = true;
                return true;
            }
            finally
            {
                _isDelivering = false;
            }
        }
    }
}
