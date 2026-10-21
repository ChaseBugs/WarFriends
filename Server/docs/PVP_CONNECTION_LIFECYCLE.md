# PvP connection lifecycle ownership

This is the first S07 simulation-state extraction. It moves connection admission/readiness and
reconnect policy out of the shared MatchEngine Player fields and partial logic. S07 remains open:
global phase/clock transitions, weapons, projectiles, army/vehicles, card effects and projections
still require their own cohesive ownership work.

## Owners

| Type/location | Owns | Does not own |
| --- | --- | --- |
| Match/Lifecycle/PvpConnectionLifecycle | Validated roster binding, admission/idle policy, ready gates, active reconnect detection and grace/forfeit decisions | World cleanup, phase assignment, state revision or terminal publication |
| Match/Lifecycle/PvpParticipantConnection | One participant's admitted, loading/presentation ready, last-seen, reconnect flag/attempts/deadline | Gameplay health, weapons, transport sessions or database state |
| PvpReconnectDecision/Disposition | Explicit pause, opponent-forfeit, both-disconnected or no-change decision | Callbacks, event buses or worker services |
| MatchEngine.ReconnectPause | Applies the decision at the existing frame position; performs cleanup and terminal calls | Independent connection flags or duplicate idle policy |
| MatchEngine Player adapters | Getter-only access for remaining simulation/projection consumers | Writable copies of the seven connection fields |

The lifecycle is allocated once from the already validated manifest and its exact digest. Participant
IDs retain ordinal matching. Admission/idle durations are captured once. The component has no
engine back-reference, network, database, signing key, Unity type, event bus or thread of its own.
NetworkWorker's existing command/tick owner remains the only writer.

## Authority and Client evidence

The active 1.4.0 GameControllerOnline distinguishes loading-ready from presentation-ready and
uses a two-second SyncMatchStart offset. The phase/countdown assignment remains in MatchEngine;
the connection owner decides when both admitted participants have passed the exact manifest-hash
ready gate. A wrong phase is still rejected before a wrong hash, and presentation readiness still
requires Running and prior loading readiness.

GameControllerOnline.CheckIfDisconnected3rdTime checks reconnectsCount > 3. MatchManager defines
30/20/10-second reconnect windows. The server keeps that sequence and the fourth-disconnect forfeit.
The idle threshold/admission duration and the no-winner abort when the other peer is also silent
remain existing self-hosted authority policy; they are not recovered original-server formulas.
No Photon operation is introduced and no Client source or asset is modified.

CanResume is read-only. Resume refreshes presence and clears only the reconnect flag/deadline,
retaining the lifetime attempt count. Valid polls and exact command replays refresh last-seen time
but never resume a paused participant. Loading/presentation readiness is not reset on reconnect.
These details preserve source callback/replay behavior rather than treating every packet as a resume.

## Same-frame order retained

1. Validate the requested host tick, real-time/cooldown observations and existing no-skipped-frame
   requirements before changing a clock or connection state.
2. Record observed real time and host tick. A terminal match returns without advancing its frozen
   simulation tick or replacing terminal evidence.
3. If already reconnecting, observe a paused cooldown frame, preserve the existing revision change,
   evaluate inclusive grace expiry and publish the same terminal result when required. Existing
   real-time army-deployment handling remains at the same point; it is not a blanket thread pause.
4. Otherwise, detect idle participants before partially advancing the simulation frame. Two idle
   participants abort without incrementing either attempt counter. One idle participant records
   its attempt; attempt four forfeits immediately.
5. For attempts one through three: record attempt, remove owned deployables, then activate the
   visible reconnect flag/deadline and increment state revision. If cleanup throws, only the attempt
   increment remains. Combining preparation and activation would change this failure boundary.
6. Without a pause decision, observe the active cooldown frame and advance the simulation clock.
   Existing combat, admission timeout, countdown-idle, start, duration and overtime order is retained.
7. Terminal validation/statistics checks still precede reconnect cleanup; projectile/performance
   cleanup, phase/reason/winner assignment and terminal event publication retain their original order.

End reason literals remain in the engine adapter so the existing complete terminal-reason audit
continues to cover every durable reason. The lifecycle returns decisions rather than publishing a
terminal result or granting any reward.

## Before/after evidence

Before editing the simulation, the trace fixture ran twice against the original engine and produced
identical hashes for nine scenarios and 108 observations. The frozen JSON baseline records scenario,
observation count, complete-byte digest and human-readable final phase/tick/reason. Historical
source hashes, including Client evidence, are in pvp-connection-baseline-provenance.json. They are
capture provenance, not pins to the now-refactored implementation.

Each observation hashes framed complete protobuf snapshots, command replies where present,
terminal evidence and event batches where terminal, plus exact real-time/cooldown floating-point
bits. Lengths and floating-point bits use explicit little-endian encoding. The fixture uses a small
synthetic prototype weapon, fixed IDs, deterministic inputs and no wall clock, Mongo, socket or
Unity runtime. Its capture-to-console switch was removed after freezing the baseline; the normal
gate only compares and never regenerates expected hashes.

The cases cover admission deadline/terminal freeze, hash/countdown/presentation order, prestart
idle rejection, pause/resume without time backlog, all three grace windows/fourth disconnect,
inclusive expiry with an active opponent, no winner for a silent peer, polls/replays/presentation/
forfeit while paused, and shutdown clearing pause state. Explicit assertions complement hashes.
This proves the reviewed traces retain complete engine bytes, not that every combat formula or
normal Unity scene is correct.

Six additional owner groups check admission/ready order, query non-mutation, cleanup-failure
preparation, traffic versus resume, idle/grace boundaries and compiled state ownership. The nested
Player has no independently writable connection fields; participant flag setters are private.
Global phase/revision/weapon fields are deliberately not described as extracted by this checkpoint.

Run the focused gate from the repository root after building Debug binaries:

```powershell
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-connection --no-build
```

The case is also part of fast/runtime/full checkpoints. A complete runtime combat run and native
Mongo/HTTP/UDP smoke remain required for this simulation change; a focused prototype trace alone
cannot establish live weapon/projectile/reconnect compatibility.

## Verified checkpoint

Debug and Release solution builds passed with zero warnings/errors. The focused case passed in
checkpoint-a42adc6e28234304a08ebe79c1c248a5. The complete runtime/native gate passed all 31 stages
in checkpoint-878944a56acd45f881fb1ca162243609, including 267,866 engine/admission/SDK/map/real-UDP
assertions. Its full battle stage took 716.7 seconds while the independent Release queue gate was
also running; this is a workstation test duration, not a throughput comparison or speed claim.

Native smoke-df8582c3054b4bce8c36b9909875ee10 passed the actual Mongo/HTTP/protobuf/UDP boundary
in 36.5 seconds and reclaimed 210,894,851 bytes. Release
backend-queue-399769cc221e406ea85d0d805e6676b4 passed queue, grant/reconnect, cancellation, rematch,
Backend restarts and Worker-outage recovery, reclaiming 212,591,914 bytes. These include source
adapter/SDK execution; they do not prove ordinary Unity/Android scene gameplay or Linux services.

The seven new/extracted connection source/test files pass LF/width/whitespace checks. The inspected
Client lifecycle source hashes are unchanged. Simulation now has 614 authored C# files, with no
new host/library root implementation files. S07 remains open for the remaining systems above.
