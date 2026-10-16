# Co-op peer departure presentation

The recovered `GameControllerCoop.FinishGameCoopClient` calls
`DisalblePlayerAndResumeGame`. For a departing peer, that method shows the
partner-left notification, resumes the game, clears `currentPlayerPoint`,
marks network status inactive and start animation finished, then disables the
peer GameObject after three real-time seconds. It does not grant a local win.

## Connected path

The normal co-op `StartGame` now binds `SelfHostedCoopPeerBridge` after its
existing mission/UI/camera startup. The bridge subscribes to the adapter's
main-thread `StateReceived` event and also examines the current snapshot, so a
departure received during camera startup is not lost. `OnDisable` unsubscribes;
`OnEnable` resubscribes. The controller's existing virtual `Reset` immediately
disables and removes its bridge before resetting the match.

`SelfHostedCoopDepartureState` requires a running, started co-op mission, two
distinct expected admitted identities, exactly the local ally in the active
participant list, a living ready local player and an inactive remote player.
It uses the existing `participant_ids`/readiness projection, not readiness
alone. Loading, KIA spectators, shared terminal state, local departure and
malformed/duplicate roster histories do not trigger this presentation. No SDK
binary replacement or retired Photon call is needed for this predicate.

The bridge calls the original source presentation helper once. Repeated polls
and disable/re-enable cycles retain that one-shot state. A callback that throws
does not consume presentation, allowing a later snapshot to retry. The bridge
does not select a mission outcome, advance progression or authorize rewards.

## Confirmed local departure

`GameControllerOnline` now offers a mode-specific confirmation hook after its
existing asynchronous Forfeit recovery returns. PvP keeps its existing terminal
presentation. The co-op override requires `IsLocalDeparture`: the original
local identity must be the removed inactive peer while the other living,
ready ally remains in the running mission. It then follows the recovered local
Forfeit order: set the local Forfeit reason, call `FinishGame`, end the local
mission and schedule the existing delayed disconnect. Self-hosted `FinishGame`
already skips the original Photon RPC; disconnect closes only this Client's
adapter. The survivor's host snapshot is not rewritten into a terminal result.

Forfeit recovery also recognizes an already confirmed local departure before
attempting another reconnect or command. The normal source game-over response
and durable per-player settlement are still separate unfinished integration;
connecting this hook does not prove the rendered exit sequence or an accepted
Backend result. A master departure or shared terminal state continues to use
the shared terminal path rather than this non-master local hook.

## Verification boundary

`CoopDeparturePresentationTests` compiles the exact Unity predicate into the
.NET protocol test executable. Fourteen transition/identity checks include a
real protobuf round trip. The executable passes 1,051 checks with this fixture.

`UnityCoopPeerBridgeAudit.Run` is an Editor-mode Unity Mono audit of actual
adapter event publication and bridge callbacks. It explicitly invokes the
enable/disable lifecycle hooks to inspect subscription behavior; this is not a
Play Mode lifecycle or a rendered GUI test. Its first six checks cover complete
roster rejection, unsubscribe, re-enable, duplicate delivery and retry after a
failed callback.

Three further checks call actual `ForfeitWithRecovery` with an already
confirmed local departure and a portable SDK connection to an ephemeral
loopback UDP receiver. Recovery completes immediately, sends no datagram and
preserves the frozen running snapshot. This tests the early confirmation
branch, not lost-response recovery over an admitted co-op Worker session.

The disposable Unity 2018.3.0f2 run passed all nine checks and completed
its shutdown. The audited controller, bridge and predicate source hashes match
the active Client files. The new scripts retain explicit valid 32-character
GUIDs; the controller's existing GUID and serialized identities are unchanged.

The Windows solution build has zero warnings/errors. Native Mongo smoke passes
1,051 protocol checks and 74 live MongoDB/HTTP/protobuf/UDP checks, including
result persistence across Worker restarts. The asset-reference audit retains
1,052 resolved script targets and 288,080 references with zero missing-script
attachments or broken references. The NGUI audit remains unchanged at 17
unmatched original sprite selections; these are not repaired by this callback.

Worker co-op admission, the complete co-op input/AI presentation bridge, rendered
departed-player exit/spectator flow, durable per-player settlement, and two
normal Clients completing a mission remain open. This callback connection
does not open the existing combat/reward/admission gates or prove Android
execution. See [the runtime departure boundary](COOP_SURVIVOR_MISSION.md).
