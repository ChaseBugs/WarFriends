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

Twelve portable checks cover lifecycle, callback cancellation and detached
observation. The protocol executable passes 1,358
checks. The native reference probe independently records SDK state synchronously
inside each modeled callback kind, then compares every row and
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
modeled room callbacks plus the general offline disconnect, not every Photon failure event.
It is not a Photon-free campaign, Android or Unity 5.2 completion claim.

The final installed SDK also passes the native comparison in
`Server/.local/unity-local-room-state-sdk-final.log`; all seven installed and
native-tested DLL hashes match their manifest. The model update passes the
existing Chat/region/session/retry/cancellation modal regression in
`Server/.local/unity-local-room-state-ui-regression.log`. Static asset checks
still report zero broken references/missing scripts; the 17 existing sprite
mismatches remain unchanged. Original scenes, prefabs, GUIDs and Photon binaries
were not changed.

## General offline disconnect

The first state comparison omitted OnDisconnectedFromPhoton entirely. Extending
the native probe reproduced another missing callback in
`Server/.local/unity-local-disconnect-baseline.log`: reference `Disconnected`,
model empty. The bundled offline Disconnect clears mode/room/local ID, processes
StatusCode.Disconnect synchronously, then emits that callback. It emits no
LeftRoom and repeating Disconnect on the already disconnected reference peer
does not notify again.

LocalOfflineRoom now emits `LocalRoomCallback.Disconnected` after resetting all
state, only when it was offline. The enum moved to its own source file with
explicit existing values 0-3 preserved and the new value 4 appended; this is a
local SDK event, not a new protobuf command or server settlement proof. The
native probe records callback names independently so a missing enum notification
cannot disappear from the comparison.

The extended comparison passes first/replacement/explicit-leave/rejoin,
disconnect, repeated disconnect and pre-enabled-mode cases in
`Server/.local/unity-local-disconnect-final.log`. The active GameControllerOnline
disconnect callback currently only warns when its controller is active; this
change does not dispatch the model to game objects or migrate the actual solo
entry/ownership/RPC path.

The final installed SDK and native-tested files have matching hashes for all
seven manifest entries. The existing Chat/region/session/retry/cancellation
regression also passes with the new event:
`Server/.local/unity-local-disconnect-ui-regression.log`.
The full Release solution build also passes with zero warnings/errors. Static
asset checks remain at zero broken references/missing scripts with the same
17 existing sprite mismatches. [Callback cancellation](LOCAL_SOLO_CALLBACK_CANCELLATION.md)
now covers three disconnect phases and the actual manager's post-callback mirror.
Listener exceptions and general callback-driven reentrant joins remain separate
characterization work.
