# Ordinary Grenadier physical explosion verification

Real ordinary deployments now have contact/fuse and shield explosion outcome coverage. The test
uses normal admission, selection, readiness and DeployArmy; it never injects a collision, explosion
or damage call. Both normal and special/Elite grenade setup originate from admitted owner lanes.

## Captured authority and outcomes

Before each host tick, the fixture captures published grenade IDs, frozen launch damage and the
first physical contact tick. A read-only internal diagnostic exposes that existing contact value;
it does not change flight or damage behavior. Actual shield damage events must reference a captured
grenade ID and the same physical explosion tick.

The fixture independently calculates expected shield loss from the recovered overlap collider,
source inner/outer falloff, explosion coefficient and UnitToShield coefficient, capped by current
shield health. It does not call the production grenade damage resolver to obtain its expectation.
The legacy projectile kind remains `card-grenadier` for this shared flight; the deployed actor's
SourceCardId is empty, and no card entity or card interpolation is used.

A trusted test-authored damage scale of 0.25 makes the basic grenade's shield arithmetic observable
without reaching zero health. This is a fixture input to the existing mode-scaling contract, not
a production balancing change or proof of a particular buff/card activation.

| Owner upgrade tuple | Composed fuse | First contact tick | Explosion tick | Resulting shield health |
| --- | --- | --- | --- | --- |
| Normal 0, no special/Elite | 3 | 259 | 349 | 308.288 |
| Normal 39, special 101 | 2.4 | 247 | 319 | 0 |
| Normal 39, special 126, Elite 127 | 0.9000001 | 247 | 275 | 0 |

The basic shield starts at 560. Its raw inner explosion damage is 41.952; the source explosion
coefficient two and UnitToShield coefficient three produce 251.712 damage. The test requires a
surviving damaged shield in this case, so destruction alone cannot satisfy the arithmetic check.
The upgraded cases verify real destruction and first-contact-bound fuse behavior.

## Verification and limits

`--infantry-weapons-only` passes 93 checks, including ten new explosion outcome assertions and
additional deployment/launch guards. The new cases are registered in the complete default suite;
that suite was not rerun for this verification increment. Production flight/damage behavior is
unchanged; the only server addition is the internal read-only first-contact accessor.

The timing check proves the current host's thirty-Hz ceiling projection. The recovered
GrenadeAmmoBase uses OnCollisionEnter plus an Update countdown with a strict negative threshold;
this test does not prove exact native Unity Physics/Update ordering or float-frame parity.
Physical player explosion damage, ordinary sickness, other geometry and target families,
full normal two-Unity-client matches and Android/Linux runtime remain open.
