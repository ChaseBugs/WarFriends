# Recovered player collision

The collision continuation adds `PlayerHitbox`, `PlayerCollisionModel`, and the internal `ShotCollisionWorld`. The host can resolve the nearest player body part against map geometry, obtaining player identity and part weight from server-owned poses rather than client assertions. It excludes the shooter and prevents the menu preview rig from becoming combat authority. Static geometry wins a distance tie.

## Evidence

`SelfHostedPlayerCollisionExport.Run` reads MainScene without saving it and exports `content/recovered-player-collision.json`. It records the MainScene SHA-256, exact hierarchy paths, root transforms, collider dimensions/orientation, part weights and serialized enabled/active flags. Two rigs exist: the gameplay player and the ArmyUnitRig preview player. Each has one box and one sphere hit-part collider. The sphere is disabled in the serialized reference, while `PlayerController.InitPlayer` enables every hit-part collider after disabling ragdoll colliders. Do not confuse the reference state with initialized gameplay.

The exporter creates isolated temporary colliders and records eight Unity `Collider.Raycast` comparisons per part (32 total), then destroys the temporary objects. These comparisons validate primitive shape math without inactive-rig or overlapping-ragdoll interference. They do not prove animated collision parity or determine an authoritative gameplay stance.

Set `WAR_PLAYER_COLLISION_OUTPUT` to an absolute path and run the Editor method in a disposable Unity project. The current artifact was generated and verified in Unity 2018.3.0f2. It is marked `serialized-reference-only` and the importer requires that identity.

## Implemented

- Bounded box, sphere and capsule ray intersection, including rotated boxes, capsule caps, inside-origin exclusion and range limits. Capsule tests use synthetic fixtures because these two recovered rigs contain no capsule hit parts.
- Immutable imported geometry with bounded finite dimensions, normalized rotations, unique model/part identities and an exact gameplay/preview role pair.
- Rigid placement preserving source geometry and enabled flags; reference geometry remains unchanged.
- Nearest enabled player-part selection and recovered map occlusion. No target identity, part weight or health is read from a Client command.
- Inclusive map-ray range boundaries; this prevents a surface exactly at the range limit from disappearing ahead of a player.

## Remaining connection work

The normal `FireCommand` is still not connected to player damage. A serialized pose must not be promoted into animated collision authority. The next steps are initialization state, source animation sampling/blending and cover transitions, weapon spawn transforms and fraction masks, then projectile scheduling and reliable shot/impact presentation.

`BulletSlow` is not a generic instant hitscan: its normal path limits the initial target to 50 units, offsets the first ray by 0.1, animates toward a hit and performs later segment checks. Its `fast` path selects collision at firing time, predicts a target position from velocity, and still delays `OnHit` through animation. `BulletShotGun` adds its own target selection and damage falloff. Those behaviors must remain distinct in the server port. No fabricated one-size-fits-all projectile implementation is enabled here.

The collision world currently operates on explicitly supplied host reference poses and is exercised by regression fixtures. It does not select or accept a live client pose, award a kill, or expose a public hit-report route. See [player damage](PLAYER_DAMAGE.md) for the separately tested health transition.

Validation: the Unity export completed successfully; all 32 source part-ray comparisons and the expanded Battle suite passed (520 assertions in the final run; polling can vary the total). The solution built with zero warnings/errors, 1,017 protocol checks passed, and native Mongo/HTTP/UDP smoke passed 44 checks. No Client scene/prefab was saved or modified by the export. These checks do not constitute animated gameplay or Android verification.
