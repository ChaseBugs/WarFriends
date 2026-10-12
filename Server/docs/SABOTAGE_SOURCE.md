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
the result for a repeated request ID. Tests cover an opposing card Drone and
the source no-target spend. The normal `Turret` family and two-peer/Unity
presentation remain unverified.

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
authorities. Live tests cover Drone removal through the existing card-unit
death path; all mechanical family outcomes, statistics parity, and source
real-time/random-stream parity still require broader verification.

## Implementation boundary

1. Verify all eight mechanical army families through live command damage,
   including shared vehicle health, aircraft, Drone immunity, and kill credit.
   The currently unavailable normal `Turret` type must enter the same source
   ordering when its separate card route is implemented. Never infer a target
   or damage value from a Client packet.
2. Compare strict five-second host-tick age and both random draws with a
   running recovered Client. Unit tests prove the selection policy, while
   a live match currently proves one Drone target.
3. Verify ordered effect/death events on two connected Clients, Unity card
   consumption and visuals in Play Mode, and Android runtime loading of the
   updated `War.Client.dll` and `War.Shared.dll`.

Source files: `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardSabotage.cs`,
`GameShootableEntity.cs`, `AIObject.cs`, and `DestroyableObject.cs`; scene
identity: `Clients/ExportedProject/Assets/Scenes/MainScene.unity`.
