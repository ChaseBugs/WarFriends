# PvP player movement ownership

This third S07 increment gives physical cover, position, private path, progress, observed velocity
and arrival deadline one owner: Match/Movement/PvpPlayerMovementState. It does not extract army,
vehicle or air navigation, rifle animation/aim, allocation, collision queries or the global frame.
S07 remains open. Public engine, protobuf, map identities and Client assets retain their identities.

## State and authority

| Owner | Responsibility |
| --- | --- |
| PvpPlayerMovementState | Physical cover/position, private recovered route, travelled distance, destination and start/update/end clocks, frame velocity |
| MatchEngine command adapter | Map availability, grenade busy state, movement/status gates, direction/target assertions, cover reservation and revision/receipt publication |
| MatchEngine frame adapter | Existing update point, server-authored speed selection, velocity finalization and drone-target callback order |
| MatchEngine SlowMove adapter | Card authority/expiry and revision publication; passes the current absolute speed to deadline recalculation |
| RifleMatchSimulation and targeting consumers | Read-only physical/moving/logical-destination observations; their own animation, aim and collision authority |

The engine's Player now has getter-only adapters for Cover, Position, MoveVelocity, IsMoving,
MoveEnd and Destination. Route/start/progress fields are removed from Player rather than duplicated.
No route array is exposed. RecoveredBattleMap.Path already returns a copy, retained privately by
the movement owner. Each participant owns an independent instance.

Live weapon modes resolve their authoritative map from the pinned combat content after Player
construction. Movement is therefore bound at the existing validated start-cover commit, not to
the optional constructor map argument. A second map binding is rejected before changing state.
A focused check constructs a live rifle engine without an explicit map to protect this boundary.

## Preserved Client rules and server quantization

- PlayerController.GoTo defaults to a 0.02-second deferred NavMesh destination. Existing server
  quantization keeps a one-tick start delay. Neither the command tick nor that start tick advances
  the route, avoiding unsigned subtraction before the first movement step.
- Route length, elapsed-tick division, speed multiplication, accumulated distance and segment lerp
  keep their original binary32 evaluation order. Tick conversion keeps ceil(double seconds * 30),
  including the original float division before conversion. No geometry/path simplification occurs.
- A moving player retains the physical old cover; Destination reserves the new logical point.
  Arrival occurs at the inclusive deadline or when accumulated distance reaches path length, then
  snaps to the map cover position and clears the path. It does not replace the retained deadline.
- GameShootableEntity.velocity derives from the last frame's position change. The existing host
  observes that delta times 30, including skipped simulation ticks; it does not divide by skipped
  tick count. Repeated or idle frames observe zero velocity. This preserves current targeting
  semantics without claiming exact Unity NavMeshAgent/frame equivalence for every scheduling case.
- CardBelovedEnemy assigns absolute speed 0.5 and later restores the saved speed; it is not a
  multiplier. The prototype trace intentionally starts below 0.5 to prove that distinction.
  Existing ten-second expiry and remaining-distance deadline recalculation are retained. The
  active-expiry group starts a route just before expiry and checks its next restored-speed frame.
- Reconnect pauses advance host time without consuming route simulation time. Resume advances one
  simulation step rather than replaying the paused backlog. Trusted lethal damage cancels the path
  before terminal publication; cancellation retains the last position, cover, deadline and velocity.

PlayerController.cs, GameShootableEntity.cs and CardBelovedEnemy.cs were inspected. Their historical
hashes and the recovered map artifact hash are recorded alongside the trace. No Client source,
scene, library or generated content was changed. C13/V02 retain the broader source-formula audit.

## Update and failure order

Movement remains at the original frame point before all-slot reload completion and subsequent
army/card phases. AdvanceMovement captures the previous position, checks whether the route can
advance and selects the server-authored speed. Its finally block records observed velocity through
the movement owner, then updates drone targeting. Those last two operations remain separate so an
early return or route failure preserves the original callback/failure boundary.

Movement commands retain all admission, freeze, direction, asserted target and occupied-cover checks
before the route commit. The existing rifle StartMove callback follows that commit. SlowMove
activation and expiry still recalculate only active routes; revisions remain engine-owned. Expiry
keeps its existing later frame position, after that frame's movement step. Ordinary and barrel death
paths call CancelRoute at their former locations; no broad cleanup reorder is introduced.

## Before/after proof and focused workflow

Before editing movement simulation, the original engine was captured twice with identical output.
Eight frozen scenarios contain 431 complete observations: both directions of the 5-to-6 path on all
five maps, deferred/repeated ticks, rejected command assertions, command replay, absolute speed/card
replay and expiry, reconnect pause/resume and death-before-terminal. Full framed protobuf snapshots,
replies, terminal events and exact clock bits match after extraction. The temporary capture switch
was removed; normal tests cannot update expected hashes.

Eight additional groups cover deferred/duplicate frames and observed velocity, skipped ticks and
inclusive arrival, speed changes with retained progress, cancellation observations, independent
players/private setters/no exposed arrays, map rebinding, live map resolution and active-route expiry.
The previously frozen connection and weapon traces remain separate gates. These prototype traces
do not prove all 60 recovered paths, full combat physics or normal Unity gameplay by themselves.

```powershell
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-movement --no-build
```

The focused selector uses no database, socket, Unity project or Library copy and takes approximately
four seconds here. Its managed checkpoint retains small reports and removes disposable data after
owned shutdown. It also runs in fast/runtime/full checkpoints. Full combat and native integration
remain required for this simulation increment. Networking/calculation throughput improvement is
not inferred from encapsulating state or from correctness-test elapsed times.

## Verified result

Debug and Release solution builds passed with zero warnings/errors; the final test-only active-expiry
addition also builds without warnings/errors. Both configurations pass all eight frozen movement
traces and eight state/order groups. Final Debug checkpoint-5a2bb65b6da644cd9cf249a8a333e265 completed
that focused gate in 4.2 seconds. Existing connection and weapon traces also pass in both configurations.

checkpoint-608a06966f8b44689fae195ce8da32ea passed all 33 runtime/native stages, including 267,800
battle engine, admission, portable SDK, map and real two-peer UDP assertions. Full battle took
670.0 seconds. Native smoke-8b4608680810409990faa253136ead81 passed in 36.6 seconds with 74 live
Mongo/HTTP/protobuf/UDP checks and reclaimed 210,895,152 bytes after owned shutdown. The final
active-expiry group was added during that integrated run and verified separately afterward; no
simulation changed after the integrated run started and no redundant full combat run was required.

The three new C# files pass LF/width/whitespace checks; three Client evidence hashes and the map
artifact hash are unchanged. Historical root .local remains 80,842 bytes and Server/.local
2,835,453,402 bytes. Managed LOCALAPPDATA storage contains 934,794 bytes/104 files after retention.
No test Backend, Worker, battle test or managed run remains active; the original Mongo service is
preserved. S07's remaining systems, measured performance, V07 provenance and real Unity/Android
gameplay retain separate completion gates.
