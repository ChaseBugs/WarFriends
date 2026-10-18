# Normal Assaulter unit-versus-unit combat

The ordinary host now has a live opposing-deployment fixture covering automatic entity targeting,
real flight, nonlethal damage, a projectile-caused unit death and the shooter's next preparation.
This verifies an existing impact path; this checkpoint adds tests rather than changing combat rules.

## Source contract

`SoldierBehaviourAssaulter.PickTarget` prefers the recovered Rusher unit group after Decoys,
then follows its source unit fallback. A player is selected only when that entity list is empty.
`ShootJustStarted` multiplies real bullet speed by three for a non-player target. The generic
shooting branch consumes the prepared batch and real/fake mask. Infantry collision damage uses
the recovered collider weight; player and overtime coefficients do not apply to that unit hit.
The pinned infantry head weight is 1.5. The existing shared damage authority owns lethal cleanup.

## Actual host evidence

`AssaulterDuelTests` submits ordinary deployments for both players in Park and advances the
normal host one tick at a time. All four soldiers remain under automatic control; the test submits
no shot, health mutation, teleport or forced death. It observes non-player callback speed 15 and
actual speed-15 flights. Launch identity, owner and raw damage are captured before flight authority
retires on collision. Each observed health reduction must have one corresponding physical impact
and match the frozen source weapon damage times the head weight.

The fixed fixture observes three nonlethal hits at ticks 567, 578 and 687. Each removes 44.4 health
from a raw 29.6 shot. The next impact kills that soldier at tick 698, emits exactly one matching
ArmyDied event and removes its Corner reservation, entry, pending attempt and executed callback.
The lethal transition is checked against the victim's previous health and launch damage. The
surviving shooter then reaches its next automatic preparation and selects another living enemy
soldier rather than the removed unit or a substituted player.

The complete `--assaulter-volley-only` group passes 110 checks with this fixture. Release build
has zero warnings/errors. This evidence is one fixed host scenario, not every infantry matchup,
moving-target hit, vehicle/air hit, original Unity collision parity or normal Client gameplay.
Those broader integration requirements remain on the BattleServer checklist.

After the moving-roster UDP correction below, the complete default Windows Battle test executable
passes 247,551 assertions with exit code zero. This covers its battle engine, admission, portable
SDK, map geometry and real two-peer UDP paths. It does not run the optional Unity Editor audit
or establish Linux runtime behavior or a complete playable normal Client integration.

## Moving-roster UDP regression

The live barrel UDP fixture also deploys ordinary soldiers. Independent peer/reconnect reads can
observe different host ticks while those soldiers walk, so it now compares the complete ordered
spawn identities rather than requiring mutable positions and animation clocks to be identical.
Entity, owner, fraction, local ID, option, unit, card, spawn component, reservation and spawn tick
must all agree. The existing per-page position timestamp bounds remain enforced. Event replay
comparison uses the first reader's final event ID, so later events do not invalidate a shared
immutable history prefix. All 21 focused barrel UDP assertions pass with autonomous soldiers.
