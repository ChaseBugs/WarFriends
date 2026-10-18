# Ordinary Grenadier physical explosion verification

Real ordinary deployments now have contact/fuse and shield explosion outcome coverage. The test
uses normal admission, selection, readiness and DeployArmy; it never injects a collision, explosion
or damage call. Both normal and special/Elite grenade setup originate from admitted owner lanes.

## Captured authority and outcomes

Before each host tick, the fixture captures published grenade IDs, frozen launch damage and the
latest physical contact-entry tick. A read-only internal diagnostic exposes that existing contact value;
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

| Owner upgrade tuple | Composed fuse | Latest contact-entry tick | Explosion tick | Resulting shield health |
| --- | --- | --- | --- | --- |
| Normal 0, no special/Elite | 3 | 259 | 349 | 308.288 |
| Normal 39, special 101 | 2.4 | 247 | 319 | 0 |
| Normal 39, special 126, Elite 127 | 0.9000001 | 247 | 273 | 0 |

The basic shield starts at 560. Its raw inner explosion damage is 41.952; the source explosion
coefficient two and UnitToShield coefficient three produce 251.712 damage. The test requires a
surviving damaged shield in this case, so destruction alone cannot satisfy the arithmetic check.
The upgraded cases verify real destruction and latest-contact-bound source countdown behavior.

## Verification and limits

`--infantry-weapons-only` now passes 107 checks, including ten explosion outcome assertions,
fourteen native-clock/contact-entry checks and additional deployment/launch guards. The subsequent
[source-executed fuse correction](GRENADIER_FUSE_CLOCK.md) replaces the original ceiling/first-contact
model with float countdown and contact-entry resets. The table above reflects that corrected model.

The native fixture proves original contact/countdown methods in an isolated thirty-Hz setup, not
complete native map physics or every Physics/Update ordering. Physical player explosion damage,
ordinary sickness, other geometry and target families, full normal two-Unity-client matches and
Android/Linux runtime remain open.

After the source fuse correction, the complete default Windows Battle executable passes 247,810
assertions with exit zero. That run includes the native clock replay and ordinary impact fixtures;
it does not replace normal Unity gameplay or full native collision-manifold validation.
