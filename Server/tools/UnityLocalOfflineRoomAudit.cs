using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;

public sealed class LocalOfflineRoomCallbackProbe : MonoBehaviour
{
    public readonly List<LocalRoomCallback> Callbacks =
        new List<LocalRoomCallback>();

    private void OnConnectedToMaster()
    {
        Callbacks.Add(LocalRoomCallback.ConnectedToMaster);
    }

    private void OnLeftRoom()
    {
        Callbacks.Add(LocalRoomCallback.LeftRoom);
    }

    private void OnCreatedRoom()
    {
        Callbacks.Add(LocalRoomCallback.CreatedRoom);
    }

    private void OnJoinedRoom()
    {
        Callbacks.Add(LocalRoomCallback.JoinedRoom);
    }
}

/// <summary>
/// Run in a disposable Unity project with -executeMethod and without -quit.
/// Compares the bundled offline Photon callback order with the portable model.
/// </summary>
[InitializeOnLoad]
public static class UnityLocalOfflineRoomAudit
{
    private const string Active = "WarFriends.LocalOfflineRoomAudit";

    static UnityLocalOfflineRoomAudit()
    {
        if (SessionState.GetBool(Active, false))
            EditorApplication.update += RunInPlayMode;
    }

    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(Active, true);
        EditorApplication.update += RunInPlayMode;
        EditorApplication.isPlaying = true;
    }

    private static void RunInPlayMode()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
            return;

        EditorApplication.update -= RunInPlayMode;
        try
        {
            var gameObject = new GameObject("LocalOfflineRoomCallbackProbe");
            var probe = gameObject.AddComponent<LocalOfflineRoomCallbackProbe>();
            var localRoom = new LocalOfflineRoom();
            var modelCallbacks = new List<LocalRoomCallback>();
            localRoom.Callback += modelCallbacks.Add;

            PhotonNetwork.offlineMode = true;
            Require(PhotonNetwork.offlineMode, "Photon did not enter offline mode.");
            PhotonNetwork.LeaveRoom();
            Require(PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName),
                "Photon did not create the first offline room.");
            localRoom.JoinSoloRoom();
            CompareCallbacks(probe, modelCallbacks, "first join");
            Require(PhotonNetwork.room != null &&
                PhotonNetwork.room.name == localRoom.RoomName &&
                PhotonNetwork.player.ID == localRoom.PlayerId &&
                PhotonNetwork.masterClient.ID == localRoom.MasterPlayerId &&
                PhotonNetwork.room.playerCount == localRoom.PlayerCount,
                "The portable solo roster differs from the bundled room.");

            probe.Callbacks.Clear();
            modelCallbacks.Clear();
            PhotonNetwork.LeaveRoom();
            Require(PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName),
                "Photon did not replace its offline room.");
            localRoom.JoinSoloRoom();
            CompareCallbacks(probe, modelCallbacks, "replacement join");

            PhotonNetwork.Disconnect();
            localRoom.Disconnect();
            Require(!PhotonNetwork.offlineMode && PhotonNetwork.room == null &&
                !localRoom.IsOffline && !localRoom.IsInRoom,
                "The portable solo room did not clear on disconnect.");

            Debug.Log("LOCAL_OFFLINE_ROOM_AUDIT_PASSED");
            Finish(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            Finish(1);
        }
    }

    private static void CompareCallbacks(LocalOfflineRoomCallbackProbe probe,
        List<LocalRoomCallback> modelCallbacks, string scenario)
    {
        Require(probe.Callbacks.SequenceEqual(modelCallbacks),
            "Offline callback order differs on " + scenario + ": Photon=" +
            string.Join(",", probe.Callbacks.Select(value => value.ToString()).ToArray()) +
            " model=" +
            string.Join(",", modelCallbacks.Select(value => value.ToString()).ToArray()));
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
            throw new InvalidOperationException(message);
    }

    private static void Finish(int code)
    {
        SessionState.SetBool(Active, false);
        EditorApplication.Exit(code);
    }
}
