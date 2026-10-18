# Ordinary Grenadier primary damage verification

The ordinary host deployment now has physical pistol outcome coverage, separate from its grenade
launch and weapon-visibility tests. No production damage rule changed for this checkpoint.

## Real deployment and receipts

The fixture admits two source-backed participants on Park, selects and readies normally, and
uses DeployArmy for the ordinary Grenadier. It never creates a card actor, teleports a soldier,
injects an impact or calls a damage method. Host RNG selects primary and requests body targeting
when the source facing rule permits it; later shot rolls select real bullets. Retry ticks also
select primary rather than accidentally switching to a grenade after a failed exposure attempt.

Each published pistol projectile is bound to its frozen host launch damage and empty card ID.
The test correlates actual player Impact events with those projectile IDs, checks player health
loss against the source coefficient, and binds shield damage/destruction to the same launch set.
The owner's health stays unchanged. Shield-only and player-hit cases remain distinct outcomes.

## Observed cases

| Ordinary upgrade tuple | Raw pistol damage | Observed result |
| --- | --- | --- |
| Normal 39, special 126, Elite 127; trusted damage scale 1.5 | 165.858 | Player loses 82.92871 health at tick 378. Source player coefficient is 0.5. |
| Normal 0, no special/Elite; trusted damage scale 1.5 | 59.93142 | Shield damage/destruction is verified; both players retain health through tick 3000 in this covered fixture. |

The first basic-unit shield hit removes about 179.79425 health, matching raw damage times the
source UnitToShield coefficient of three. This fixture repeatedly damages and destroys the
cover shield. The covered basic case is not evidence that every basic Grenadier always misses
players; it records one fixed source geometry/RNG/cover scenario. It must not be reported as a
basic-unit player-hit proof. No target, damage, spawn or cover rule was changed to force a hit.

## Verification and remaining work

`--infantry-weapons-only` passes 83 checks, including ten new outcome assertions and additional
setup/launch guards. The two cases also run as part of the default Battle executable.
Ordinary grenade explosion outcomes, ordinary sickness, other maps/movement/upgrade tuples,
normal two-Unity-client rendering and Android/Linux runtime remain open. The positive case
proves a physical host player hit, not complete ordinary Grenadier gameplay or all upgrade tiers.
The complete default suite was not rerun for this test-only checkpoint.
