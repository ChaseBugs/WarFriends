# Grenadier primary shield and player damage

`--grenadier-damage-only` verifies actual admitted-host collisions, not just projectile creation
or a synthetic hit assertion. The fixed Park fixture uses source main covers, source AK47
participant loadouts, one equipped ordinary Assaulter per participant and level 22. The owner
receives one trusted GREATGRENADIER inventory entry; the other participant receives none.
Both select their allocation lanes and ready normally. The owner activates the unit through
`UseUnitCardCommand`. No actor is teleported and no collision/damage callback is injected.

The fixture forces the source primary-weapon RNG branch, then ordinary real shots. The actual
Grenadier walks to its source corner, prepares its native pistol muzzle and fires. Tests retain
each published projectile's frozen raw damage and correlate subsequent Impact/ShieldDamaged/
ShieldDestroyed events with those exact projectile identities.

## Verified results

| Scenario | Captured raw damage | Source player coefficient | Observed player health loss | Impact tick |
| --- | ---: | ---: | ---: | ---: |
| Normal | 76.36814 | 0.5 | 38.184082 | 383 |
| Overtime | 76.36814 | 0.25 | 19.092041 | 413 |
| Sickness | 38.18407 | 0.5 | 19.092041 | 492 |

The physical victim has weight one in this fixture. The test compares actual health loss with
captured raw damage and the source player/overtime coefficient within 0.001, accounting for C#
float subtraction. It rejects a health change without a matching primary projectile Impact
against the opponent on that same tick. A barrel explosion cannot stand in for the pistol hit.

Normal and Sickness volleys first damage and destroy the opposing shield through actual hits.
The first ShieldDamaged event must match captured raw damage times the source UnitToShield
coefficient (3). The normal first shield hit removes approximately 229.10449 health; the source
level-zero shield has 560 health. The later destruction must reference a known primary projectile.
Shield damage is not reduced by the player-only coefficient.

Overtime uses a five-second test-owned duration and advances the actual host deadline before
unit activation. It requires OvertimeStarted, no scheduled end tick and destroyed shields before
recording damage. It does not set the private overtime flag.

Sickness uses the source-backed host spawn-window binding before the first shot. This proves
modified weapon damage, not authorized SICKNESS card use or automatic spawn callbacks.
Owner health and friendly shield controls remain unchanged in all three cases. These are negative
controls, not proof of a friendly body deliberately placed inside the ray.

## Verification and limits

Release build passes without warnings/errors. `--grenadier-damage-only` passes 23 outcome checks
plus selection/readiness/activation setup guards. It is registered in the default suite; the
complete default suite was not rerun. The latest source correction replaces the old player-child
Shield aim position with GameShootableEntityPlayer's current-cover Shield override. All three
fixtures now also observe the actual latch at that canonical point; this changes the impact ticks
by one while preserving source damage and coefficients. Original fixture creation changed no
production combat code; the later Shield correction deliberately changes the target projection.

The older fixture kills its Grenadier after its first shot, which hits terrain. This fixture
lets source volleys continue through shield destruction and a later physical player hit.
Geometry discovery also observed a shield hit after two normal movement commands in Aztec;
the committed regression uses explicit Park cases instead of searching for any passing map.

The [moving-acquisition correction](GRENADIER_MOVING_AIM.md) now replaces the unsupported eight-family
muzzle lookup with current-pose pistol binding, preserves source lead inputs and uses pistol
idle/run aliases. Native proof covers moving-body acquisition and scheduled launch, not a moving
victim hit. Remaining work includes warm/secondary pose transitions, in-ray friendly exclusions,
host-scheduled cosmetic shots and Client/UDP presentation.
