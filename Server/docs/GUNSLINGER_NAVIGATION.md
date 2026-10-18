# Normal Gunslinger ground navigation

Ordinary Gunslinger deployment now selects, reserves and walks to its original multiplayer
destination rather than remaining idle at the spawn. This is ground navigation and source
arrival-state initialization. Automatic shooting is verified separately below.

## Recovered evidence

MainScene behavior component 36243 has unit ID `ID_UNIT-GUNSLINGER` and enemy-point mask 2048.
`SoldierBehaviour.GetInitPoint` delegates to `SpawningManager.GetPoint`, which filters free
same-fraction accepted points and chooses the nearest, preserving collection order for ties.
`EnemyPointGunslinger.position` is its transform position and its switch state is Gunslinger.
The five multiplayer collections contain three points per fraction per map: 30 total.

`extract_gunslinger_points.py --check` reproduces the source artifact, including MainScene and
map SHA-256 provenance, component identities, transform positions/rotations and original order.
Artifact SHA-256 is `2cedfa3154c81be469a9fde9f742eed1304ba3a4c3be511865d8d420be5ff059`.
Git pins this new artifact to LF so Windows checkout does not invalidate its byte digest.
The runtime validates the complete artifact and source map identities before exposing immutable
point rows. The existing 33-row card point artifact remains unchanged and passes its own check.

## Runtime

The match selects a nearest unoccupied point of the soldier's fraction, reserves it and creates
the existing source-bound NavMesh route. Missing free points retry after five seconds, as in
`GenerateInitPoint`. Movement publishes the Gunslinger walking clip and bounded position ticks;
death releases both navigation state and the exclusive destination.

`SetFinalTarget` sets stoppingDistance to zero. The existing motion candidate can report arrival
within 0.04 of its projected endpoint before the soldier satisfies `EnemyPoint.IsEnemyPointReached`
against the authored point. This occurred on Desert at approximately 0.042 from the authored
point. The new explicit route-end advancement continues ordinary fixed-tick motion until the
source authored-point test passes. It does not enlarge that threshold or teleport the soldier.
Other callers retain their existing arrival behavior.

`SwitchStateToGunslinger` initializes remaining attempts from composed `fireBatchSizeMax`, a
strict next-tick first-shot deadline and a random two-to-four-second position-change deadline.
The host now records these source entry values. Diagnostic manifests without upgrade authority
have no invented shot count/deadline. The old BaseShot-only initialization skipped Gunslinger's
recovered upgrade shot lanes; initialization now composes those lanes explicitly.

## Verified boundary

`--gunslinger-navigation-only` passes 50 checks with actual two-soldier deployments on all maps:

| Map | Last soldier entry tick |
| --- | ---: |
| Aztec | 443 |
| City | 418 |
| Desert | 349 |
| Park | 371 |
| Snow | 425 |

The checks cover nearest free selection at spawn, walking clips, separate reservations,
same-fraction authored arrival, exact source entry counters/deadlines and death cleanup.
The ordinary-unit test host is shared with Sickness fixtures, which now pass 164 checks including a real Gunslinger launch.
Shared combat regression also passes 26,395 assertions after the navigation integration.
Release build has zero warnings/errors. The complete default suite, Unity and Linux runtime
were not rerun for this checkpoint.

The later [ordinary shooting path](GUNSLINGER_SHOOTING.md) now executes shot preparation,
callback muzzle/aim prediction, one-shot attempts and real/cosmetic projectiles. Exhausted-attempt
[point changes](GUNSLINGER_POINT_CHANGES.md) now transfer reservations and walk to a fresh firing
cycle. [Holster metadata](GUNSLINGER_HOLSTER.md) now follows spawn, arrival and final-shot timing;
visible gun snapping and normal Client presentation remain open. Paratrooper descent/landing
is a separate missing normal-unit path. These remain on the BattleServer feature checklist.

[Stand timing evidence](GUNSLINGER_STAND_TIMING.md) verifies native animation callbacks,
next gameplay polls and both source hide transitions independently of real projectile tests.
