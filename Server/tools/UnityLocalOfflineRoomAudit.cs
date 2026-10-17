using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;

/// <summary>Compares local room callbacks and their visible state with the bundled SDK in an empty scene.</summary>
[InitializeOnLoad]
public static class UnityLocalOfflineRoomAudit
{
    private const string Active = "WarFriends.LocalOfflineRoomAudit";

    static UnityLocalOfflineRoomAudit()
    {
        if (SessionState.GetBool(Active, false))
        {
            EditorApplication.update += RunInPlayMode;
        }
    }

    /// <summary>Runs only the local reference comparison; no Photon Cloud connection is made.</summary>
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
        {
            return;
        }
        EditorApplication.update -= RunInPlayMode;
        try
        {
            var owner = new GameObject("LocalOfflineRoomCallbackProbe");
            var scenario = new Scenario(owner.AddComponent<LocalOfflineRoomCallbackProbe>());
            VerifyFirstJoin(scenario);
            VerifyReplacement(scenario);
            VerifyLeaveAndRejoin(scenario);
            VerifyDisconnect(scenario);
            VerifyRepeatedDisconnect(scenario);
            VerifyPreEnabledScene(scenario);
            VerifyDisconnect(scenario);
            Debug.Log("LOCAL_OFFLINE_ROOM_AUDIT_PASSED");
            Finish(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            Finish(1);
        }
    }

    private static void VerifyFirstJoin(Scenario scenario)
    {
        PhotonNetwork.offlineMode = true;
        Require(PhotonNetwork.offlineMode, "The reference SDK did not enter offline mode.");
        PhotonNetwork.LeaveRoom();
        Require(PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName), "The first reference room was not created.");
        scenario.Room.JoinSoloRoom();
        scenario.Compare("first join");
        Require(PhotonNetwork.room.name == scenario.Room.RoomName &&
            PhotonNetwork.player.ID == scenario.Room.PlayerId &&
            PhotonNetwork.masterClient.ID == scenario.Room.MasterPlayerId &&
            PhotonNetwork.room.playerCount == scenario.Room.PlayerCount,
            "The joined local roster differs from the reference SDK.");
    }

    private static void VerifyReplacement(Scenario scenario)
    {
        scenario.Clear();
        PhotonNetwork.LeaveRoom();
        Require(PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName), "The replacement room was not created.");
        scenario.Room.JoinSoloRoom();
        scenario.Compare("replacement join");
    }

    private static void VerifyLeaveAndRejoin(Scenario scenario)
    {
        scenario.Clear();
        PhotonNetwork.LeaveRoom();
        scenario.Room.LeaveRoom();
        scenario.Compare("explicit leave");
        scenario.Clear();
        PhotonNetwork.LeaveRoom();
        Require(PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName), "The empty room was not rejoined.");
        scenario.Room.JoinSoloRoom();
        scenario.Compare("rejoin after explicit leave");
    }

    private static void VerifyDisconnect(Scenario scenario)
    {
        scenario.Clear();
        PhotonNetwork.Disconnect();
        scenario.Room.Disconnect();
        Require(!PhotonNetwork.offlineMode && PhotonNetwork.room == null &&
            !scenario.Room.IsOffline && !scenario.Room.IsInRoom && scenario.Room.PlayerId == -1 &&
            scenario.Room.MasterPlayerId == -1,
            "Disconnect did not reset the local state.");
        scenario.Compare("disconnect");
    }

    private static void VerifyPreEnabledScene(Scenario scenario)
    {
        scenario.Clear();
        PhotonNetwork.offlineMode = true;
        scenario.Room.ObserveExistingOfflineMode();
        Require(scenario.Probe.Callbacks.SequenceEqual(new[] { nameof(LocalRoomCallback.ConnectedToMaster) }) &&
            scenario.Probe.States.Single() == scenario.ModelState(LocalRoomCallback.ConnectedToMaster),
            "The earlier offline transition has an unexpected callback or visible identity.");
        scenario.Clear();
        PhotonNetwork.LeaveRoom();
        Require(PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName), "The pre-enabled room was not created.");
        scenario.Room.JoinSoloRoom();
        scenario.Compare("pre-enabled offline mode");
    }

    private static void VerifyRepeatedDisconnect(Scenario scenario)
    {
        scenario.Clear();
        PhotonNetwork.Disconnect();
        scenario.Room.Disconnect();
        scenario.Compare("repeated disconnect");
        Require(scenario.Probe.Callbacks.Count == 0, "An already disconnected peer repeated its notification.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private static void Finish(int code)
    {
        SessionState.SetBool(Active, false);
        EditorApplication.Exit(code);
    }

    private sealed class Scenario
    {
        internal Scenario(LocalOfflineRoomCallbackProbe probe)
        {
            Probe = probe;
            Room.Callback += callback =>
            {
                ModelCallbacks.Add(callback);
                ModelStates.Add(ModelState(callback));
            };
        }

        internal LocalOfflineRoomCallbackProbe Probe { get; private set; }
        internal LocalOfflineRoom Room { get; } = new LocalOfflineRoom();
        internal List<LocalRoomCallback> ModelCallbacks { get; } = new List<LocalRoomCallback>();
        internal List<string> ModelStates { get; } = new List<string>();

        internal string ModelState(LocalRoomCallback callback)
        {
            return callback + "|" + Room.IsOffline + "|" + Room.RoomName + "|" +
                Room.PlayerId + "|" + Room.MasterPlayerId + "|" + Room.PlayerCount;
        }

        internal void Clear()
        {
            Probe.Callbacks.Clear();
            Probe.States.Clear();
            ModelCallbacks.Clear();
            ModelStates.Clear();
        }

        internal void Compare(string scenario)
        {
            Require(Probe.Callbacks.SequenceEqual(ModelCallbacks.Select(callback => callback.ToString())),
                "Room callback order differs on " + scenario + ": reference=" +
                string.Join(",", Probe.Callbacks.ToArray()) + " model=" +
                string.Join(",", ModelCallbacks.Select(callback => callback.ToString()).ToArray()));
            Require(Probe.States.SequenceEqual(ModelStates),
                "Callback-visible state differs on " + scenario + ": Photon=" +
                string.Join(",", Probe.States.ToArray()) + " model=" + string.Join(",", ModelStates.ToArray()));
        }
    }
}
