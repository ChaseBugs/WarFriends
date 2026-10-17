# Start-camera completion over the self-hosted protocol

The recovered PVP and Coop controllers finish their local camera, notify the
other player, then call StartCameraAnimationFinishedRPC locally. The local call
sets PlayerNetworkStatus.startAnimationFinished and may close the existing
reconnect presentation. The old self-hosted string router merely returned true;
it did not transmit this state.

## Wire and authority

| Contract | Field | Meaning |
| --- | --- | --- |
| PresentationReadyCommand | Empty | Reports the authenticated participant's completed presentation |
| MatchCommand | presentation_ready = 55 | Uses the existing ordered, replay-safe mutation stream |
| BattlePlayerState | presentation_ready = 58 | Monotonic host-retained participant state |

There is no player ID, Boolean choice, timestamp, reward or combat outcome in the
request. MatchEndpoint derives the owner from its authenticated session and
canonicalizes the empty command, rejecting extra fields through its existing
wire check. Both MatchEngine and CoopMatchRuntime accept it only after loading
readiness, in Running. It cannot start/advance the battle, complete another
participant, pause simulation or authorize a reward. The camera runs after
Running in the recovered Client; adding it to the loading barrier would deadlock.

Before admission, commands return not-admitted. Waiting/countdown reports return
wrong-phase. A new terminal command returns match-terminal, while an exact retry
of an already consumed command retains its immutable original receipt. Existing
admission/terminal/departure guards remain in force. No report can clear the flag.
The connected participant may also report while its opponent is reconnecting;
that presentation-only command does not clear the opponent's reconnect state or
advance/resume the paused combat clock. Combat commands remain gated.

## Client path

MatchConnection.MarkPresentationReadyAsync sends the typed command. PVP and Coop
call SelfHostedBattleClient.ReportStartCameraAnimationFinished instead of the
string router, which no longer recognizes the no-op camera alias. The original
local callback still executes immediately; network completion does not delay its
animation/UI timing.

The observed asynchronous report shares one in-flight owner token. It allows at
most three send attempts, uses the existing Backend/session reconnect on a UDP
timeout, and checks the exact report/match owner before sending or applying a
reply. Obsolete completions cannot report into a replacement battle. Failures
are logged and published through ConnectionError rather than acknowledged as
success. This does not add a new grant policy or an arbitrary RPC tunnel.
An unresolved earlier mutation is retried with its existing identity before the
new presentation intent is submitted. Cancellation belonging to the shared
reconnect waits for that operation; a replaced/disposed old connection retries
under the current owner instead of publishing an obsolete camera failure.

Player initialization binds the two actual actors to the SDK's ordered trusted
roster. Snapshot application sets only host-confirmed completion flags on those
bound actors. False snapshots do not undo the recovered local optimistic flag.
Binding an existing snapshot restores already completed presentation, and Close
clears bindings/report ownership. Health, score, economy and player identity are
not changed by this projection.

## Verification

- --presentation-ready-only passes 149 focused readiness/UDP transfer assertions:
  admission/phase rejection, owner isolation, no combat/tick change, immutable
  retry, terminal protection, and fresh authenticated generation/cursor restore.
  The final three checks cover reporting during opponent reconnect without
  resuming or advancing combat.
- The broad suite checkpoint passed 143,258 assertions in
  Server/.local/start-presentation-battle-suite.log before those final three
  reconnect checks were added; the latest focused run verifies that addition.
- --combat-content-only passes 26,368 content assertions and its co-op SDK UDP
  departure/recovery test now also checks master-only presentation delivery.
- --unity-rifle-only passes the actual Mono report, real Worker receipt, independent
  SDK peer observation, both recovered actor flags and restoration from the fresh
  reconnect generation. Evidence: Server/.local/unity-start-presentation-live-rifle.log.
  It retains the existing deliberately injected post-admission reconnect failure;
  that is not a camera report error.
- The complete Release solution builds with zero warnings/errors; the protocol
  executable passes 1,360 checks.
- The controlled actor/UI gate passes reordered player rows, preservation of
  optimistic/confirmed completion against false snapshots, and rejection of
  another match's projection. Its existing UI regression also passes:
  Server/.local/unity-start-presentation-final-component-gate.log. All seven
  installed/native SDK hashes match their manifest. Static references remain
  unbroken, with the same seventeen previously documented atlas selections.

The Unity gate uses one Editor process, two copied source rigs and an SDK peer;
it invokes the production reporter but does not run GameCamera's entire startup
animation or normal menu/controller bootstrap. Two normal Unity clients, dedicated
camera-report timeout/exhaustion, prior-receipt loss and cancellation-race
injection, original Unity 5.2, Android and this
feature's Linux runtime proof remain open. Existing full-gameplay and Photon
retirement requirements are unchanged.
