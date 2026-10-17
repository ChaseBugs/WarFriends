# Cancellation inside local solo callbacks

The native reference gate now lets the callback receiver disconnect itself.
It reproduced a model error in
`Server/.local/unity-local-callback-cancellation-baseline.log`: cancellation in
ConnectedToMaster stopped the recovered join command, but the model continued
to CreatedRoom/JoinedRoom with offline mode already false.

## Command behavior

| Disconnect inside | Reference callback trace | Join command |
| --- | --- | --- |
| ConnectedToMaster | ConnectedToMaster, Disconnected | Rejected before LeaveRoom |
| LeftRoom | ConnectedToMaster, LeftRoom, Disconnected | Room creation rejected |
| CreatedRoom | ConnectedToMaster, LeftRoom, CreatedRoom, Disconnected, JoinedRoom | Returns normally, but no room remains |

LocalOfflineRoom now checks offline mode after the first connection callback
and after LeaveRoom, before publishing a new room. It deliberately does not
suppress JoinedRoom after a CreatedRoom listener disconnects: the recovered SDK
also emits that final callback with mode/room cleared and IDs reset. A callback
or successful command return is not itself proof of membership/admission.

## Actual manager mirror

The active PhotonConnectionManager still executes the legacy solo SDK path,
then mirrors it into LocalOfflineRoom. A separate native baseline reproduced
the mirror recreating membership after CreatedRoom cancelled the actual SDK
room: `Server/.local/unity-local-manager-cancellation-baseline.log`.

The manager now observes the SDK state after its callbacks unwind. If mode is
off it disconnects the model; if mode remains offline but the room was left,
it silently adopts the detached local ID. ObserveDetachedOfflinePlayer accepts
only the recovered -1/1 identities and rejects invalid values before mutation.
It does not replay callbacks. Native tests invoke the actual manager command
with a controlled inactive manager and verify both disconnect and leave during
CreatedRoom, including the public membership/count reads after return.

This does not prove helper visibility inside every original SDK callback or
wire the model to normal scene dispatch. General reentrant joins, listener
exceptions, gameplay ownership/RPC/serialization and Photon-free solo creation
remain open.

## Verification

The portable suite passes 1,358 checks, including twelve local lifecycle cases.
The extended native SDK/model/manager comparison passes in
`Server/.local/unity-local-callback-cancellation-errors-final.log`. Its runtime
error gate requires exactly the known CreateRoom refusal caused by disconnect
inside LeftRoom, and rejects all other runtime errors. The focused manager gate
can be reproduced with `UnityLocalOfflineRoomAudit.RunManagerCancellation`.
These are disposable Unity 2018 component/command gates, not full menu/campaign,
Android or Unity 5.2 proof.

The complete Release solution builds with no warnings or errors. The existing
combined NGUI/component regression passes in
`Server/.local/unity-local-callback-cancellation-ui-regression.log`.
All seven installed SDK hashes match both the manifest and the disposable
native validation project. Static asset checks find no missing scripts or
broken references; the seventeen previously recorded atlas selections remain.
