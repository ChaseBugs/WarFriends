# Recovered army air geometry

The active 1.4.0 deployment artifact has three air families. The extracted geometry is evidence for the next host collision integration; it is not yet consumed by the Worker and does not establish air-unit gameplay completion.

| Unit | Prefab | Transforms | Colliders | Source shot target |
|---|---|---:|---:|---|
| `ID_UNIT-HELICOPTER` | `Helicopter.prefab` | 74 | 11 boxes | Transform 414249, serialized `None` mask 0 |
| `ID_UNIT-ASSAULTHELI` | `assaultHelicopter.prefab` | 40 | 3 boxes, 8 convex mesh components | Transform 479075, legacy Body mask 1 |
| `ID_UNIT-DRONE` | `dronePrototype.prefab` | 18 | 1 box, 1 sphere | Transform 454360, Body mask 1 |

`miniDrone.prefab` is the Transporter repair drone and is outside this army-air set. The deployment source binds Helicopter and Drone to Defender (0), and Assault Helicopter to Shooter (2).

[The source inventory](../content/recovered-air-unit-geometry.json) preserves prefab SHA-256, every Transform and parent, component script identities, damage-part weights and explicit owner references, collider enabled/trigger/layer/ancestor-active state, rest transforms, shape parameters, exact shot-target masks and six assigned collision-mesh source digests. Two Assault Helicopter mesh components have serialized null mesh references. They remain explicit null bindings; the extraction does not fabricate replacement collision shapes. Colliderless damage parts remain in the component inventory.

[The independent Unity export](../content/recovered-air-unit-unity-geometry.json) contains asset-local component IDs, rest collider centers/rotations/scales, shot-target positions/masks, mesh bindings, and actual vertices/triangle indexes for all six assigned collision meshes. The disposable Unity 2018.3 exporter passed with three prefabs and 24 colliders. The comparison checks all rest transforms within 0.2 mm, matching component and mesh identities, source digests, rotation agreement, shot-target identities/masks/positions, and finite indexed mesh geometry. This verifies rest geometry; it does not verify PhysX cooked convex hulls, animated flight poses, or gameplay damage.

Reproduce the source extraction and comparison:

```powershell
python Server/tools/extract_air_unit_geometry.py --check
python Server/tools/verify_air_unit_geometry.py
```

To regenerate the Unity artifact, set `WAR_AIR_GEOMETRY_OUTPUT` to its absolute destination and invoke `SelfHostedAirGeometryExport.Run` in the disposable Unity copy. The exporter reads prefab assets without changing scenes or invoking gameplay. Preserve the source Client Unity-version provenance; this audit is not an upgrade.

The host integration still needs the following source behavior:

1. Validate and bind this geometry into the combat package; retain convex mesh shapes and exact damage-owner relationships. Assault Helicopter glass parts explicitly belong to a separate `DestroyableObjectMultipleParts`; its root `Awake` excludes parts already owned by that other object. They cannot all be collapsed into aircraft health.
2. Project each live flight/steering/animation pose and faction layer. Preserve collider activation, glass break/disable behavior, and source normal/elite variants. Obtain independent Unity motion and collision probes before treating rest coordinates as moving hitboxes.
3. Implement Drone's source special timer and immortality transitions. `Drone.Update` toggles `destroyableObj.isImmortal` and renderer transparency; `SetTransparent` does not remove its `GameShootableEntity` from target selection. Do not infer untargetability from transparency.
4. Connect typed projectile/explosion collision to the proper air health/subsystem authority, then add air targets to the turret's ordered secondary groups, source sight, nearest-target selection and movement prediction. Helicopter's mask 0 is deliberately preserved: `GameShootableEntity.GetShotTargets` uses subset-mask comparison, so that target remains eligible for `AllIn`.
5. Verify acquisition, real trajectories and damage/death in live host matches, then two-process/device Client presentation and hit proof. Existing generic `AirEntityHealthState` tests are not proof of these recovered behaviors.

Source behavior comes from `GameShootableEntity.Awake/GetShotTargets`, `DestroyableObjectMultipleParts.Awake`, `DestroyableObjectpart.DoDamage`, `Glass.Enable/DestroyableObjectOnOnDeath`, and `Drone.OnInstancied/Update/SetTransparent`. The inventory carries their component GUID/type bindings for follow-up inspection.
