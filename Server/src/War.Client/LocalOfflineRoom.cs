using System;

namespace War.Client
{
    public enum LocalRoomCallback
    {
        ConnectedToMaster,
        LeftRoom,
        CreatedRoom,
        JoinedRoom
    }

    /// <summary>
    /// The recovered Client creates one local solo room named OfflineRoom.
    /// This models its room state and callback order without Photon types.
    /// It does not simulate gameplay or dispatch callbacks to Unity objects.
    /// </summary>
    public sealed class LocalOfflineRoom
    {
        public const string SoloRoomName = "OfflineRoom";

        public bool IsOffline { get; private set; }
        public bool IsInRoom { get; private set; }
        public string RoomName => IsInRoom ? SoloRoomName : string.Empty;
        public int PlayerId => IsInRoom ? 1 : -1;
        public int MasterPlayerId => IsInRoom ? 1 : -1;
        public int PlayerCount => IsInRoom ? 1 : 0;

        public event Action<LocalRoomCallback> Callback;

        public void JoinSoloRoom()
        {
            // PhotonNetwork.offlineMode emits this callback only when it changes
            // from false to true. LeaveRoom is then called unconditionally.
            if (!IsOffline)
            {
                IsOffline = true;
                Callback?.Invoke(LocalRoomCallback.ConnectedToMaster);
            }

            LeaveRoom();
            IsInRoom = true;
            Callback?.Invoke(LocalRoomCallback.CreatedRoom);
            Callback?.Invoke(LocalRoomCallback.JoinedRoom);
        }

        public void LeaveRoom()
        {
            if (!IsOffline)
                return;

            // The bundled PhotonNetwork.LeaveRoom sends OnLeftRoom even when
            // its offline room is already null.
            IsInRoom = false;
            Callback?.Invoke(LocalRoomCallback.LeftRoom);
        }

        public void Disconnect()
        {
            // PhotonNetwork.Disconnect clears offlineMode and the room without
            // sending the offline LeaveRoom callback.
            IsInRoom = false;
            IsOffline = false;
        }
    }
}
