using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;

/// <summary>Compares local room callbacks and their visible state with the bundled SDK in an empty scene.</summary>
[InitializeOnLoad]
public static class UnityLocalOfflineRoomAudit
{
    private const string Active = "WarFriends.LocalOfflineRoomAudit";
    private const string ExpectedCreateRefusal = "CreateRoom failed. Client is not on Master Server or not yet ready " +
        "to call operations. Wait for callback: OnJoinedLobby or OnConnectedToMaster.";
    private static readonly List<string> RuntimeErrors = new List<string>();
    private static int _referenceRefusals;

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

    /// <summary>Runs only the actual manager's callback-cancelled SDK mirror cases.</summary>
    public static void RunManagerCancellation()
    {
        SessionState.SetBool(Active + ".ManagerOnly", true);
        Run();
    }

    /// <summary>Diagnoses the still-open callback-time visibility boundary in the actual manager.</summary>
    public static void RunManagerVisibility()
    {
        SessionState.SetBool(Active + ".CheckVisibility", true);
        RunManagerCancellation();
    }

    private static void RunInPlayMode()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }
        EditorApplication.update -= RunInPlayMode;
        RuntimeErrors.Clear();
        _referenceRefusals = 0;
        Application.logMessageReceived += CaptureRuntimeError;
        try
        {
            var owner = new GameObject("LocalOfflineRoomCallbackProbe");
            var scenario = new Scenario(owner.AddComponent<LocalOfflineRoomCallbackProbe>());
            if (SessionState.GetBool(Active + ".ManagerOnly", false))
            {
                VerifyManagerCancellation(scenario, PhotonNetwork.Disconnect);
                VerifyManagerCancellation(scenario, () => PhotonNetwork.LeaveRoom());
                VerifyRuntimeErrors(0);
                Debug.Log("LOCAL_OFFLINE_MANAGER_CANCELLATION_PASSED");
                Finish(0);
                return;
            }
            VerifyFirstJoin(scenario);
            VerifyReplacement(scenario);
            VerifyLeaveAndRejoin(scenario);
            VerifyDisconnect(scenario);
            VerifyRepeatedDisconnect(scenario);
            VerifyPreEnabledScene(scenario);
            VerifyDisconnect(scenario);
            VerifyCallbackCancellation(scenario, LocalRoomCallback.ConnectedToMaster);
            VerifyCallbackCancellation(scenario, LocalRoomCallback.LeftRoom);
            VerifyCallbackCancellation(scenario, LocalRoomCallback.CreatedRoom);
            VerifyManagerCancellation(scenario, PhotonNetwork.Disconnect);
            VerifyManagerCancellation(scenario, () => PhotonNetwork.LeaveRoom());
            VerifyRuntimeErrors(1);
            Debug.Log("LOCAL_OFFLINE_ROOM_AUDIT_PASSED");
            Finish(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            Finish(1);
        }
        finally
        {
            Application.logMessageReceived -= CaptureRuntimeError;
        }
    }

    private static void CaptureRuntimeError(string condition, string stack, LogType type)
    {
        if (type != LogType.Error && type != LogType.Exception && type != LogType.Assert)
        {
            return;
        }
        if (type == LogType.Error && condition == ExpectedCreateRefusal)
        {
            _referenceRefusals++;
        }
        else
        {
            RuntimeErrors.Add(condition);
        }
    }

    private static void VerifyRuntimeErrors(int expectedRefusals)
    {
        Require(_referenceRefusals == expectedRefusals && RuntimeErrors.Count == 0,
            "Unexpected reference/runtime errors: " + string.Join(" | ", RuntimeErrors.ToArray()));
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

    private static void VerifyCallbackCancellation(Scenario scenario, LocalRoomCallback cancelAt)
    {
        scenario.Clear();
        scenario.Probe.AfterCallback = callback =>
        {
            if (callback == cancelAt.ToString())
            {
                PhotonNetwork.Disconnect();
            }
        };
        Action<LocalRoomCallback> cancelModel = callback =>
        {
            if (callback == cancelAt)
            {
                scenario.Room.Disconnect();
            }
        };
        scenario.Room.Callback += cancelModel;
        try
        {
            bool referenceAccepted = TryReferenceJoin();
            bool modelAccepted = true;
            try
            {
                scenario.Room.JoinSoloRoom();
            }
            catch (InvalidOperationException)
            {
                modelAccepted = false;
            }
            scenario.Compare("cancellation in " + cancelAt);
            Require(referenceAccepted == modelAccepted && !scenario.Room.IsOffline && !scenario.Room.IsInRoom,
                "Callback cancellation published a room unlike the recovered join command.");
        }
        finally
        {
            scenario.Probe.AfterCallback = null;
            scenario.Room.Callback -= cancelModel;
        }
    }

    private static bool TryReferenceJoin()
    {
        // These are the actual guard and call order in PhotonConnectionManager.JoinOfflineGame.
        PhotonNetwork.offlineMode = true;
        if (!PhotonNetwork.offlineMode)
        {
            return false;
        }
        PhotonNetwork.LeaveRoom();
        return PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName);
    }

    private static void VerifyManagerCancellation(Scenario scenario, Action cancel)
    {
        const BindingFlags StaticFields = BindingFlags.Static | BindingFlags.NonPublic;
        FieldInfo singleton = typeof(Singleton<PhotonConnectionManager>).GetField("_instance", StaticFields);
        object previousManager = singleton.GetValue(null);
        var model = (LocalOfflineRoom)typeof(PhotonConnectionManager).GetField("mLocalOfflineRoom", StaticFields)
            .GetValue(null);
        var owner = new GameObject("InactiveLocalManagerCancellation");
        owner.SetActive(false);
        var manager = owner.AddComponent<PhotonConnectionManager>();
        singleton.SetValue(null, manager);
        scenario.Clear();
        bool callbackMembershipMatches = true;
        scenario.Probe.AfterCallback = callback =>
        {
            if (callback == nameof(LocalRoomCallback.ConnectedToMaster))
            {
                // The inactive fixture needs explicit delivery of this actual manager callback.
                typeof(PhotonConnectionManager).GetMethod("OnConnectedToMaster",
                    BindingFlags.Instance | BindingFlags.NonPublic).Invoke(manager, null);
            }
            if (callback == nameof(LocalRoomCallback.CreatedRoom))
            {
                if (SessionState.GetBool(Active + ".CheckVisibility", false))
                {
                    callbackMembershipMatches = PhotonConnectionManager.isInRoom &&
                        PhotonConnectionManager.GetPlayerCount() == 1;
                }
                cancel();
            }
        };
        bool isQuitting = Singleton.applicationIsQuitting;
        try
        {
            PhotonConnectionManager.JoinOfflineGame();
            Require(callbackMembershipMatches,
                "CreatedRoom observes an SDK member but the actual manager reports no local membership.");
            Require(PhotonNetwork.room == null && !model.IsInRoom && model.PlayerCount == 0 &&
                model.IsOffline == PhotonNetwork.offlineMode && model.PlayerId == PhotonNetwork.player.ID &&
                !PhotonConnectionManager.isInRoom && PhotonConnectionManager.GetPlayerCount() == 0,
                "The actual manager recreated model membership after its SDK room was cancelled in CreatedRoom.");
        }
        finally
        {
            scenario.Probe.AfterCallback = null;
            PhotonNetwork.Disconnect();
            model.Disconnect();
            UnityEngine.Object.DestroyImmediate(owner);
            Singleton.applicationIsQuitting = isQuitting;
            singleton.SetValue(null, previousManager);
        }
    }

    private static void Finish(int code)
    {
        SessionState.SetBool(Active, false);
        SessionState.SetBool(Active + ".ManagerOnly", false);
        SessionState.SetBool(Active + ".CheckVisibility", false);
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
