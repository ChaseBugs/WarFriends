# SABOTAGE card: recovered 1.4.0 contract

This records a **partially verified** BattleServer card. The scene enables
`SABOTAGE` and binds `CardSabotage`. The Worker now accepts an authenticated
request-ID-only protobuf command, and the normal offline Client routes the
card through the installed portable SDK. Unity Play Mode and Android use have
not yet been verified.

`SabotageTargetPolicy` now implements and tests the two-draw selection over
an explicit, ordered host candidate snapshot. `MatchEngine` can project its
live mechanical army roots into that snapshot; a spawned card Drone enters
the opposing set and leaves it on death in a live match test. A normal
authenticated command now selects a target, consumes one selected card,
applies source-max-health host damage while ignoring immortality, and retains
the result for a repeated request ID. A normal authenticated command now
destroys each of the eight recovered mechanical army families: Humvee, Buggy,
Transporter, Tank, Helicopter, Assault Helicopter, Drone, and Mech. Each match
proves one card consumption, replay without a second spend, and identical
ordered effect/death events through both participants' host event pages. The
source no-target spend is also covered. Eight signed two-peer UDP matches
now prove deployment and a live `SABOTAGE` kill for each mechanical family,
one card activation per match, retry without a second spend, and identical
ordered card-effect/death events on both sockets. The normal `Turret`
family and Unity presentation remain unverified.

## Client behavior

`CardSabotage.UseCard` runs target selection only on the old Photon master,
then consumes the card even if there is no target. The replacement must make
the BattleServer the sole selector and consume one Backend-provisioned card
through the existing idempotent card receipt. The Client must send the card
identity and request ID, never a target or damage value.

`GameShootableEntity.GetAllMechanicalTypes()` lists, in order: `AICar`,
`AICarBuggy`, `AICarTransporter`, `Tank`, `Helicopter`,
`AssaultHelicopter`, `Drone`, `Turret`, and `Mech`. `GetRandomOpponent`
collects visible, living, opposing shootable entries in that type order and
draws one uniformly. `CardSabotage` then collects the subset whose owner is an
`AIObject`, whose shootable part is `isMain`, and whose real-time age is
strictly greater than five seconds. If that subset is nonempty, a second
uniform draw from it replaces the first choice. An empty mature subset does
**not** make the card inert: the first draw can still select a younger or
non-main mechanical entry. With no visible living opposing entry, the card
is spent without a hit.

The eight recovered army families map to the first seven source classes and
`Mech`; normal `Turret` is a separate class and has no currently enabled
self-hosted card route. The recovered `HeavyTurret` prefab also has a visible
main shootable, but its owner class is **not** `Turret`, so it is excluded by
the source type list. Each of the ten checked mechanical prefabs has one
`GameShootableEntity` component with `visible: 1`. The source defaults
`isMain` to true; only `MiniDrone` assigns it false, and `MiniDrone` is not
one of the nine selected owner types. This supports one root candidate per
currently deployed mechanical army entity. The host expresses the strict
five-second age in 30 Hz simulation ticks; real-time Unity timing parity
still needs a running Client comparison.

The selected `DestroyableObject` receives one `Shot` damage operation of its
own `maxHealth`, with `isOneHit` and `ignoreImmortality` set, part index zero,
no weapon, and the activating player's ownership. This is not automatically
equivalent to deleting an entire vehicle: multi-part damage, shared health,
statistics, and death callbacks must pass through their existing host
authorities. Live host-state tests verify each of the eight deployed
mechanical families uses its ordinary death and cleanup path; normal-command
tests now verify all eight in isolated matches. Statistics parity and source
real-time/random-stream parity still require verification.

`SkillShotController` handles the card's player-owned `Shot` death callback.
For each of these eight mechanical families it marks `Kill`, `OneHitKill`,
and `VehicleDestroyed`; a Tank also marks `TankDestroyed`. The host now
records `card-sabotage` only after confirmed removal, with the exact unit,
victim, attacker, and tick. Terminal validation limits those records to the
attacker's trusted `SABOTAGE` usage, and a read-only result projection exposes
the four source-shaped counts. Tests cover all eight families and reject a
forged card kill without a card use. This is candidate statistics evidence,
not a complete `SkillShotManager` or reward implementation.
Card-spawned Drone deaths now retain the released registry's `HEAVYDRONE`
source ID, spawn request ID, and spawn tick in private terminal evidence.
Validation requires the card entity namespace, unique canonical spawn request,
ordered spawn/death ticks, exact Drone identity, and sufficient trusted
`CardSpawnUnit` usage by the victim owner as well as `SABOTAGE` usage by the
attacker. The card death does not consume ordinary army loss/deployment capacity.
Focused tests verify the credit and reject forged source, request, timestamp,
owner, cause, and missing matching spawn-card usage. A signed two-peer UDP
match now activates HEAVYDRONE, kills it with SABOTAGE, replays both peers'
effect/death events, and ends by authenticated forfeit. The Worker's persisted
outbox retains the exact spawn request, source, owner, attacker, entity, and
tick; its validated projection reports one card kill. A native Mongo-backed
test now submits that real UDP result through `BattleTerminalAcceptance`,
checks accepted/replayed delivery, reopens the Mongo repository, and verifies
exact bytes, provenance, and source-shaped statistics. Forged spawn provenance
is rejected without changing the stored result. The HTTP variant starts the
real Backend executable and uses `BackendResultForwarder` to submit the same
UDP/outbox evidence through the production signed endpoint. It verifies first
acceptance, exact replay, Mongo provenance/statistics reads, HTTP 401 for
unsigned/wrong-key requests, and HTTP 400 for signed forged spawn provenance.
The automatic-forward variant configures the real Worker's result endpoint
and control key, waits for Mongo persistence without directly submitting the
result, then checks durable `.ack` creation and an empty pending outbox.
It reopens the acknowledged outbox to validate its match/roster binding.
Worker delivery and acknowledgement for this card case are now verified.
The outage variant observes an actual HTTP 503 on the first Worker delivery,
checks the durable pending result and absence from Mongo, restores forwarding,
and verifies automatic retry, byte-identical Mongo evidence, and durable ack.
The connection-loss variant aborts the first delivery connection before
Backend submission, then drops the first successful Backend response after
its commit. It verifies retained evidence and the exact `accepted` then
`already-accepted` response sequence before durable Worker acknowledgement.
HTTP 503, abrupt connection loss, and lost commit-response recovery are now
verified. Worker/process-restart recovery for this card case and Unity
statistics presentation remain unverified.

Run the optional live storage test against a disposable native Mongo instance:
`dotnet run --project Server/tests/War.Battle.Tests -c Release -- --sabotage-backend-live mongodb://127.0.0.1:27017/`.
It creates and removes its own randomly named test database; no Docker is used.
For the signed HTTP variant, use `--sabotage-http-live` instead, against a
native Mongo replica set and after building the Release Backend executable.
Use `--sabotage-worker-forward-live` for the automatic Worker delivery/ack test.
Use `--sabotage-outage-live` for observed HTTP 503 retention and recovery.
Use `--sabotage-connection-loss-live` for connection abort and lost commit-response replay.

## Implementation boundary

1. Compare the remaining `SkillShotManager` callbacks, current-weapon kill
   attribution, and durable statistics with the running recovered Client.
   The currently unavailable normal `Turret` type must enter the same source
   ordering when its separate card route is implemented. Never infer a target
   or damage value from a Client packet.
2. Compare strict five-second host-tick age and both random draws with a
   running recovered Client. Policy tests and signed UDP matches prove one
   target in each family, but do not establish Unity timing parity.
3. Verify Unity card consumption and visuals in Play Mode, plus Android
   runtime loading of the
   updated `War.Client.dll` and `War.Shared.dll`.

Source files: `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardSabotage.cs`,
`GameShootableEntity.cs`, `AIObject.cs`, and `DestroyableObject.cs`; scene
identity: `Clients/ExportedProject/Assets/Scenes/MainScene.unity`.
