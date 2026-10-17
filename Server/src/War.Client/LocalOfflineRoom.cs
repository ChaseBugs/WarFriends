using System;

namespace War.Client
{
    /// <summary>
    /// The recovered Client creates one local solo room named OfflineRoom.
    /// This models its room state and callback order without Photon types.
    /// It does not simulate gameplay or dispatch callbacks to Unity objects.
    /// </summary>
    public sealed class LocalOfflineRoom
    {
        public const string SoloRoomName = "OfflineRoom";
        private const int UnassignedPlayerId = -1;
        private const int SoloPlayerId = 1;
        private int _localPlayerId = UnassignedPlayerId;

        public bool IsOffline { get; private set; }
        public bool IsInRoom { get; private set; }
        public string RoomName => IsInRoom ? SoloRoomName : string.Empty;
        /// <summary>Preserves the recovered local ID after leaving a room, until mode reset or disconnect.</summary>
        public int PlayerId => _localPlayerId;

        /// <summary>Reads the offline local master identity independently of current room membership.</summary>
        public int MasterPlayerId => IsOffline ? _localPlayerId : UnassignedPlayerId;
        public int PlayerCount => IsInRoom ? 1 : 0;

        public event Action<LocalRoomCallback> Callback;

        /// <summary>
        /// A recovered scene may enable offline mode before it calls
        /// JoinOfflineGame. The master callback already happened then, so
        /// adopting that state must not emit it a second time.
        /// </summary>
        public void ObserveExistingOfflineMode()
        {
            IsOffline = true;
        }

        /// <summary>Adopts an already-observed detached offline identity without replaying SDK callbacks.</summary>
        public void ObserveDetachedOfflinePlayer(int localPlayerId)
        {
            if (localPlayerId != UnassignedPlayerId && localPlayerId != SoloPlayerId)
            {
                throw new ArgumentOutOfRangeException(nameof(localPlayerId));
            }

            IsOffline = true;
            IsInRoom = false;
            _localPlayerId = localPlayerId;
        }

        public void JoinSoloRoom()
        {
            // PhotonNetwork.offlineMode emits this callback only when it changes
            // from false to true. LeaveRoom is then called unconditionally.
            if (!IsOffline)
            {
                IsOffline = true;
                _localPlayerId = UnassignedPlayerId;
                Callback?.Invoke(LocalRoomCallback.ConnectedToMaster);
            }

            if (!IsOffline)
            {
                throw new InvalidOperationException("Local solo room could not enter offline mode.");
            }

            LeaveRoom();
            if (!IsOffline)
            {
                throw new InvalidOperationException("Local solo room could not be created.");
            }
            IsInRoom = true;
            _localPlayerId = SoloPlayerId;
            Callback?.Invoke(LocalRoomCallback.CreatedRoom);
            Callback?.Invoke(LocalRoomCallback.JoinedRoom);
        }

        public void LeaveRoom()
        {
            if (!IsOffline)
            {
                return;
            }

            // The bundled PhotonNetwork.LeaveRoom sends OnLeftRoom even when
            // its offline room is already null.
            IsInRoom = false;
            // The original LeaveRoom clears the room but leaves the local player/master ID intact.
            Callback?.Invoke(LocalRoomCallback.LeftRoom);
        }

        public void Disconnect()
        {
            // PhotonNetwork.Disconnect clears offlineMode and the room without
            // sending LeftRoom, then reports its general disconnect callback.
            bool shouldNotify = IsOffline;
            IsInRoom = false;
            IsOffline = false;
            _localPlayerId = UnassignedPlayerId;
            if (shouldNotify)
            {
                Callback?.Invoke(LocalRoomCallback.Disconnected);
            }
        }
    }
}
