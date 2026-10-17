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

### Actual manager cancellation and observer lifetime

The native manager matrix now invokes the real JoinOfflineGame command for four
cases: disconnect in ConnectedToMaster, LeftRoom and CreatedRoom, plus leave in
CreatedRoom. It requires the exact recovered rejection message for the first two
cases and a normal return for CreatedRoom cancellation. Every callback samples
manager membership/count against SDK state, and every command checks final local
identity and membership.

The fixture also compares the complete pre-dispatch observer delegate before and
after each command. Rejected joins must remove their temporary subscription just
as successful returns do, preventing later SDK messages from mutating a stale
command observer. The native full comparison passes in
`Server/.local/unity-solo-cancellation-observer-lifetime.log`. Its exact expected
CreateRoom refusal count is now two: the standalone reference and actual-manager
LeftRoom-disconnect cases. The focused manager gate expects one. All other
runtime errors fail the gate. Earlier logs below retain their historical counts.

The active gameplay source search finds direct LeaveRoom/Disconnect calls only
inside PhotonConnectionManager. The separate direct offline-mode assignments in
GameController, GameControllerCampaign and GameControllerDeathMatch remain
legacy dependencies; passing this scoped matrix does not migrate them.

### Transitional callback-time membership

`UnityLocalOfflineRoomAudit.RunManagerVisibility` began as a failing diagnostic
for a production mismatch. It now samples the actual manager's membership/count
inside each SDK callback, then still performs the requested cancellation before
asserting the sample after the command returns. This avoids turning an assertion
exception into a different callback-cancellation scenario.

The previous manager mirrored its room only after SDK CreateRoom returned.
Consequently CreatedRoom observed SDK membership/count one while the manager
reported no membership/count zero. The temporary IsLocalSoloRoom creation flag
protected the online controller's two-player branch but did not repair those
reads. A successful post-return mirror comparison could not prove callback-time
visibility. The first diagnostic log is
`Server/.local/unity-solo-manager-visibility-baseline.log`; its callback exception
also interrupted cancellation, so use the isolated diagnostic for the clean
counterexample rather than interpreting that secondary membership failure as a
new post-return bug.
The isolated run in `Server/.local/unity-solo-manager-visibility-isolated.log`
fails only the sampled callback membership assertion after cancellation returns.

NetworkingPeer now provides a transitional BeforeLocalRoomCallback notification
before receiver discovery/delivery. JoinOfflineGame subscribes only while its
legacy local command runs and unsubscribes in finally, including rejected joins.
The observer silently adopts existing detached/joined identity before receivers
run, and resets the model on disconnect. Nested disconnect/leave callbacks update
the model before subsequent receivers and the final JoinedRoom notification.
The command does not synthesize another model join/callback sequence afterward.

Public getters still read only the model; this deliberately does not restore an
SDK fallback there. The observer itself still reads the legacy local SDK state,
so this is a migration seam, not a Photon-free lifecycle. Notifications outside
the scoped command, normal scene dispatch, reentrant joins and listener failures
remain separate acceptance requirements. Ownership/RPC/serialization still need
their own migration before removing the retained SDK.

The corrected focused visibility gate passes in
`Server/.local/unity-solo-manager-visibility-fixed.log`. Callback-time checks are
now unconditional in the actual-manager cases of the normal reference suite;
the complete comparison also passes in
`Server/.local/unity-solo-manager-visibility-complete.log`. The portable suite
adds silent repeated room adoption and subsequent leave-identity checks. All
seven installed/native SDK hashes agree with the manifest, and the complete
Release solution builds with zero warnings/errors. Static reference checks still
find zero missing scripts or broken references.
The existing combined Chat/region/session/loading/retry/modal regression also
passes in `Server/.local/unity-solo-visibility-ui-regression.log`, with no
unexpected runtime errors. This remains a controlled component fixture rather
than a complete campaign/menu test.

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

The portable suite passes 1,360 checks, including fourteen local lifecycle cases.
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
