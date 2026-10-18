# Grenadier physical player blast outcomes

Ordinary grenade deployments now have direct player explosion coverage as well as shield outcomes.
Two recovered rules were corrected in the shared ordinary/card player blast path:

- Explosion.MissileExplode collects colliders using the full hurt radius, selects each victim's
  nearest bounds collider, then applies playerRadiusCoef to its distance gates. The old server
  reduced the collection radius itself and could discard a valid rotated-box candidate.
- A nearby Shield enables player attenuation only when healthRatio is strictly above 0.01.
  Merely remaining alive/collidable is insufficient. Map shield damage still applies below that
  threshold, and the protection flag is derived before the explosion changes shield health.

## Native geometry boundary

`UnityGrenadierExplosionOverlapAudit` executes Unity Physics.OverlapSphere and ClosestPointOnBounds
for an isolated rotated box. The first point overlaps at radius 1.2, does not overlap at radius
0.84, but has bounds distance about 0.0813709: the source later classifies it inside the scaled
inner gate 0.63. The second point still overlaps the full radius but its bounds distance about
0.9075378 exceeds the scaled outer gate 0.84, so it must receive no damage.

The artifact binds the executed audit and separately inspected original Explosion.cs. It does
not execute MissileExplode's effects/component dispatch or claim a native recovered player pose.
Host classifier tests reproduce both Unity geometry inputs, retain the first candidate, apply
shield attenuation and reject the second candidate. Shield component tests separately verify
protection above 1%, no protection just below 1% while still collidable, and no protection after
actual shield destruction.

## Actual deployment outcomes

Three source-backed Park fixtures use normal allocation, selection, readiness and DeployArmy.
They never activate a unit card, teleport an actor, inject a hit or call damage methods. A trusted
fixture damage scale of 0.25 keeps losses measurable; it is not a change to production balancing.
The tests capture frozen published launch damage and the victim's current collision pose before
advance, matching grenade damage's position before the later rifle-animation update.

| Ordinary upgrade tuple | Fuse | Explosion tick | Expected player loss | Observed player loss |
| --- | --- | --- | --- | --- |
| Normal 0 | 3 | 349 | 10.907519 | 10.907227 |
| Normal 39, special 101 | 2.4 | 319 | 31.91108 | 31.911133 |
| Normal 39, special 126, Elite 127 | 0.9000001 | 273 | 31.91108 | 31.911133 |

Expected loss is calculated independently from full-radius collider collection, scaled bounds
gates, source inner/outer damage, pre-explosion shield protection and the player coefficient.
The three cases use the inner explosion branch, source behind-shield ratio 0.52 and player
coefficient 0.5. Float health subtraction is compared within 0.002. Upgraded blasts destroy their
shield but retain the source pre-damage attenuation for that same explosion.

Each health loss must coincide with one captured real grenade and its physical Impact event.
A barrel destruction on that tick rejects the fixture as direct grenade proof. The distant
owner's health remains unchanged. The legacy projectile kind is still `card-grenadier` for the
shared flight; the actor is an ordinary deployment with ordinary upgrade composition.

## Verification boundary

The focused `--infantry-weapons-only` group passes 150 checks: fifteen new actual-player outcome
assertions and nine geometry/shield rule checks extend the previous 126. The native overlap
artifact verifier passes. The complete default Windows Battle executable passes 247,854 assertions
with exit code zero, including actual two-peer UDP; live polling makes the count variable. Exact results apply to these stationary Park scenarios, not all maps,
moving victims, outer-ring gameplay hits, overtime, friendly bodies inside the radius or modifier
combinations. Ordinary sickness, full capsule/contact acquisition, two normal Unity Clients,
Android/Linux runtime and original Unity 5.2.5 parity remain open.
