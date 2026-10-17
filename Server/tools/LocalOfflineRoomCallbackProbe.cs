using System.Collections.Generic;
using UnityEngine;
using War.Client;

/// <summary>Records the bundled SDK's synchronous callback-visible room state in a disposable scene.</summary>
public sealed class LocalOfflineRoomCallbackProbe : MonoBehaviour
{
    public List<LocalRoomCallback> Callbacks { get; } = new List<LocalRoomCallback>();
    public List<string> States { get; } = new List<string>();

    private void OnConnectedToMaster()
    {
        Record(LocalRoomCallback.ConnectedToMaster);
    }

    private void OnLeftRoom()
    {
        Record(LocalRoomCallback.LeftRoom);
    }

    private void OnCreatedRoom()
    {
        Record(LocalRoomCallback.CreatedRoom);
    }

    private void OnJoinedRoom()
    {
        Record(LocalRoomCallback.JoinedRoom);
    }

    private void Record(LocalRoomCallback callback)
    {
        string roomName = PhotonNetwork.room == null ? string.Empty : PhotonNetwork.room.name;
        int masterId = PhotonNetwork.masterClient == null ? -1 : PhotonNetwork.masterClient.ID;
        int playerCount = PhotonNetwork.room == null ? 0 : PhotonNetwork.room.playerCount;
        Callbacks.Add(callback);
        States.Add(callback + "|" + PhotonNetwork.offlineMode + "|" + roomName + "|" +
            PhotonNetwork.player.ID + "|" + masterId + "|" + playerCount);
    }
}
