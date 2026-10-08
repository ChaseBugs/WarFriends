# Recovered 1.4.0 local-room contract

This is the B33 migration boundary for solo play. It is based on the bundled
`Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/PhotonNetwork.cs`
and the active recovered gameplay scripts. The retained Photon assembly still
implements local solo rooms; passing the Cloud-call audit does not retire it.

`PhotonConnectionManager.JoinOfflineGame()` is called by campaign, tutorial,
offline DeathMatch, and the instant-battle animation. It stops the manager's
coroutines, selects local master ownership, enables `PhotonNetwork.offlineMode`,
leaves any previous local room, and creates `OfflineRoom`. The bundled Photon
implementation proves these are distinct steps:

1. Setting `offlineMode` changes the local player ID and emits
   `OnConnectedToMaster`. It does **not** create a room.
2. Offline `CreateRoom` refuses a second room until the old one is left. On
   success it creates a `Room`, sets the local player ID and master ID to `1`,
   then emits `OnCreatedRoom` followed by `OnJoinedRoom`.
3. Offline `LeaveRoom` clears that room and emits `OnLeftRoom`.

`GameControllerOnline.OnJoinedRoom` reads the room name, local player, and
player list; it only advances the two-player connected path when the room has
two players. `GameControllerCoop.Update` checks room ownership when a co-op
bot is choosing cards. Other shared gameplay scripts still read
`PhotonNetwork.offlineMode`, `room`, or player count. A local-room replacement
must provide those values and callback order before these three remaining
direct calls can be removed. Replacing only `CreateRoom` with a Boolean flag
would leave the recovered controllers with no room object or join callback.

The co-op bot and War Arena card-readiness guards now use
`PhotonConnectionManager.isInRoom`; this reports either an owned self-hosted
match or the existing Photon room. The co-op shield lock still reads the
Photon room and sends a Photon RPC when two players are present, so its guard
must move together with server-owned lock arbitration rather than alone.

The next implementation slice is a Client-owned local room state and callback
bridge, followed by call-site migration for the four solo entry points and
their shared room guards. Then migrate local PhotonView/RPC/object lifecycle
usage in those scenes and verify campaign, tutorial, offline DeathMatch, and
instant battle in Unity Play Mode. The self-hosted UDP room remains separate
and authoritative for multiplayer; solo campaign simulation may stay local.

`War.Client.LocalOfflineRoom` now models this fixed `OfflineRoom` lifecycle without Photon types. Its first join emits `ConnectedToMaster`, `LeftRoom`, `CreatedRoom`, `JoinedRoom`; replacing an existing solo room omits the repeated master connection callback. It exposes local/master player ID 1 and one occupant, then clears ownership on disconnect. `PhotonConnectionManager` mirrors successful offline room creation into this state and uses it for local `isInRoom` and player-count reads. This is a partial migration: the bundled Photon room still creates the Unity `Room`/`PhotonPlayer` objects and dispatches scene callbacks, and recovered solo gameplay still calls their APIs. The model cannot replace those calls until their consumers and callback bridge are migrated together.

`GameControllerOnline.OnJoinedRoom` now takes an explicit solo branch before reading a Photon `Room`, `PhotonPlayer`, or player list. The bundled `NetworkingPeer.SendMonoMessage` calls Unity `SendMessage` synchronously inside offline `CreateRoom`, so `PhotonConnectionManager.IsLocalSoloRoom` includes a short creation flag until the portable model records the completed join. Solo join logs and returns without entering the two-player `AllPlayersConnected` path; the multiplayer branch retains its existing behavior. This removes those room/player reads from the solo join callback, but Photon still delivers the callback and other solo controller methods still consume Photon objects. Unity compilation is the current proof; a full solo Play Mode run remains required.

The callback order is now checked in Unity 2018.3 Play Mode by `Server/tools/UnityLocalOfflineRoomAudit.cs`. Copy it into the disposable project's `Assets/Editor`, then run Unity with `-batchmode -nographics -projectPath <disposable-project> -executeMethod UnityLocalOfflineRoomAudit.Run -logFile <log>` without `-quit`; the audit exits the Editor itself. It creates an empty scene and a callback receiver, compares the bundled offline Photon callbacks with `LocalOfflineRoom` for first and replacement joins, checks room name/local/master ID/player count, and checks disconnect cleanup. The October 8 run logged `LOCAL_OFFLINE_ROOM_AUDIT_PASSED`. This validates the room model and source callback order, not the campaign/tutorial controller behavior or removal of the remaining Photon objects.

`GameController.Awake` sets `PhotonNetwork.offlineMode = true` before some later `JoinOfflineGame` calls. The SDK model now has `ObserveExistingOfflineMode()` so the manager can adopt that already-enabled state without replaying `ConnectedToMaster` during room creation. The isolated Unity Play Mode audit now exercises this pre-enabled path as well as first/replacement join and disconnect; it passed again. This matters for the eventual callback bridge because the master connection event belongs to the earlier scene transition, not the later room join.
