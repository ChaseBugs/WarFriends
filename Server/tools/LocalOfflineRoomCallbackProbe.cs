using System.Collections.Generic;
using UnityEngine;
using War.Client;

/// <summary>Records the bundled SDK's synchronous callback-visible room state in a disposable scene.</summary>
public sealed class LocalOfflineRoomCallbackProbe : MonoBehaviour
{
    public List<string> Callbacks { get; } = new List<string>();
    public List<string> States { get; } = new List<string>();

    private void OnConnectedToMaster()
    {
        Record(nameof(LocalRoomCallback.ConnectedToMaster));
    }

    private void OnLeftRoom()
    {
        Record(nameof(LocalRoomCallback.LeftRoom));
    }

    private void OnCreatedRoom()
    {
        Record(nameof(LocalRoomCallback.CreatedRoom));
    }

    private void OnJoinedRoom()
    {
        Record(nameof(LocalRoomCallback.JoinedRoom));
    }

    private void OnDisconnectedFromPhoton()
    {
        Record("Disconnected");
    }

    private void Record(string callback)
    {
        string roomName = PhotonNetwork.room == null ? string.Empty : PhotonNetwork.room.name;
        int masterId = PhotonNetwork.masterClient == null ? -1 : PhotonNetwork.masterClient.ID;
        int playerCount = PhotonNetwork.room == null ? 0 : PhotonNetwork.room.playerCount;
        Callbacks.Add(callback);
        States.Add(callback + "|" + PhotonNetwork.offlineMode + "|" + roomName + "|" +
            PhotonNetwork.player.ID + "|" + masterId + "|" + playerCount);
    }
}
