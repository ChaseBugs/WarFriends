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
