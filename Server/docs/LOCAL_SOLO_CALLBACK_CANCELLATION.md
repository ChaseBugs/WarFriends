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

### Open: actual callback-time membership

`UnityLocalOfflineRoomAudit.RunManagerVisibility` is an intentionally failing
diagnostic for an unresolved production mismatch, not part of the passing
reference suite. It samples the actual manager's membership/count inside the
SDK CreatedRoom callback, then still performs the requested cancellation before
asserting the sample after the command returns. This avoids turning an assertion
exception into a different callback-cancellation scenario.

The manager currently mirrors its room only after SDK CreateRoom returns.
Consequently CreatedRoom observes SDK membership/count one while the manager
reports no membership/count zero. The temporary IsLocalSoloRoom creation flag
protects the online controller's two-player branch but does not repair those
reads. A successful post-return mirror comparison cannot prove callback-time
visibility. The first diagnostic log is
`Server/.local/unity-solo-manager-visibility-baseline.log`; its callback exception
also interrupted cancellation, so use the isolated diagnostic for the clean
counterexample rather than interpreting that secondary membership failure as a
new post-return bug.
The isolated run in `Server/.local/unity-solo-manager-visibility-isolated.log`
fails only the sampled callback membership assertion after cancellation returns.

The replacement lifecycle must publish local state before callback dispatch,
allow cancellation to change the state seen by subsequent callbacks, and retain
the recovered final JoinedRoom notification after CreatedRoom cancellation.
Reading the retired SDK room from the new public getters would hide this mismatch
without completing the required Photon-free lifecycle. Normal scene dispatch,
reentrant joins and listener failures remain separate acceptance requirements.

The native manager fixture also delivers the actual OnConnectedToMaster method
from the reference SDK's synchronous local-mode callback. Its baseline in
`Server/.local/unity-solo-manager-connected-baseline.log` reproduced two false
Cloud-admission errors. The manager now returns for local offline mode before
the existing Cloud refusal. The offlineMode getter reads the SDK's local Boolean;
this guard does not connect, create a room or dispatch another callback. Because
the manager is inactive to avoid unrelated boot dependencies, callback delivery
in this fixture is explicit, not proof of normal scene-wide dispatch.
The complete native SDK/model/manager comparison passes with this delivery in
`Server/.local/unity-solo-manager-connected-final.log`; the runtime error gate
still permits only the single deliberate CreateRoom refusal described below.

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
