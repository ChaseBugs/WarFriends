# Local solo callback-visible state

The original comparison checked callback names and the final joined roster.
That missed an intermediate identity mismatch: replacement OnLeftRoom exposed
local player/master ID 1 in the bundled SDK but -1 in LocalOfflineRoom.
The expanded native comparison reproduced this in
`Server/.local/unity-local-room-state-baseline.log`.

## Preserved behavior

| Callback/transition | In room | Local player/master IDs | Player count |
| --- | --- | --- | --- |
| Initial ConnectedToMaster | No | -1 / -1 | 0 |
| First LeftRoom | No | -1 / -1 | 0 |
| CreatedRoom / JoinedRoom | Yes | 1 / 1 | 1 |
| Replacement or explicit LeftRoom | No | 1 / 1 | 0 |
| Disconnect | No | -1 / -1 | 0 |

Room membership and local identity are now separate model state. Leaving a room
clears membership/name/count without resetting the local ID; entering the solo
room assigns 1 before CreatedRoom and JoinedRoom; disconnect resets to -1.
The offline master follows the local player even outside a room. An identity
alone is not evidence of membership, server admission or reward authority.
Observing a previously enabled offline mode still emits no duplicate master
callback.

## Verification

Six portable checks cover first join, replacement, explicit leave, empty-room
rejoin, disconnect and pre-enabled mode. The protocol executable passes 1,352
checks. The native reference probe independently records SDK state synchronously
inside each of the four modeled callback kinds, then compares every row and
order with the portable model. It also compares explicit leave and rejoin.

`UnityLocalOfflineRoomAudit.Run` passes in the disposable Unity 2018 project:
`Server/.local/unity-local-room-state-clean-final.log`. The earlier first import
of the split runtime probe briefly lacked its Editor reference; the clean run
contains no compiler error. Copy `LocalOfflineRoomCallbackProbe.cs` into the
disposable project's runtime Scripts folder and the audit into Editor.

The model and probe changes do not replace PhotonConnectionManager.JoinOfflineGame
or GameController.Awake. Actual solo creation still uses the retained SDK, and
normal scene callback dispatch, ownership/RPC/serialization, reentrant callback
behavior and gameplay remain migration requirements. The comparison covers the
four modeled room callbacks, not every general Photon disconnect/failure event.
It is not a Photon-free campaign, Android or Unity 5.2 completion claim.

The final installed SDK also passes the native comparison in
`Server/.local/unity-local-room-state-sdk-final.log`; all seven installed and
native-tested DLL hashes match their manifest. The model update passes the
existing Chat/region/session/retry/cancellation modal regression in
`Server/.local/unity-local-room-state-ui-regression.log`. Static asset checks
still report zero broken references/missing scripts; the 17 existing sprite
mismatches remain unchanged. Original scenes, prefabs, GUIDs and Photon binaries
were not changed.
