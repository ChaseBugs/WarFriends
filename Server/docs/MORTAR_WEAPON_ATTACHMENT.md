# Mortar weapon attachment boundary

The source Mortar has a distinct weapon-placement rule in addition to its missile flight.
`EnemyController.FireMortar` calls `SoldierParts.SnapWeaponToWorld` after starting the firing
animation. That calls `FakeRigidBodySwapper.SetParent`, which retains the snap point's current
world position, rotation and scale. The weapon must therefore remain still while the soldier's
body and facing can continue to change. The source coroutine calls `SnapToHand` afterward;
`Swap(false)` returns the snap point to `NoRigidBodyObject` with identity local position,
rotation and scale, enables the held object and disables its rigid-body alternative.

`MortarEnemy.prefab` binds swapper component 11477035, snap-point GameObject 161526, held
GameObject 179954 and rigid-body GameObject 109266. These are existing recovered identities.
The new adapter uses their actual transform references; it does not search for invented node names.

## Implemented and verified

`SelfHostedInfantryWeaponSet` retains its source-to-copy transform maps. Held-state restoration
reparents the copied snap point, so resolving its original sibling/name path afterward is not
reliable. `ResolveSource` instead uses the original reference identity inside the selected weapon.

`SelfHostedMortarWeaponAttachment` binds one ordinary Mortar inventory and its script-free copy.
It implements idempotent world detachment, exact held-state restoration and explicit lifetime
cleanup. Detached geometry is rejoined to the owner before owner destruction. If the owner is
already gone, disposal removes the detached geometry independently. No recovered weapon,
physics, Photon, sound or analytics component is activated on the copied visual.

The private Unity audit compares these operations against the inherited original
`FakeRigidBodySwapper.SetParent` and `Swap(false)` methods across all 26 supported normal
upgrade selections. It checks snap/model world transforms, retained poses after actor movement
and rotation, restored hand following, source mesh/material/visibility and disposal cleanup.
The observation is an Editor transform comparison, not a normal running battle.

The Unity 2018.3.0f2 run passed 1,015 attachment checks. The ordinary-inventory regression audit
also passed 530 checks across 64 source cases and 72 weapon copies. The launcher/scene audit
passed 17 compiled methods, twelve enabled scenes without missing scripts, and eight serialized
launcher fields. Active asset audits retained 1,052 script targets and 288,258 references with
no missing scripts or broken references; the same seventeen unmatched NGUI selections remain.
The private package manifest was restored byte-for-byte after the Unity process exited.

Local evidence is `Server/.local/mortar-attachment-unity-final.log` and
`Server/.local/coop-geometry-project/mortar-weapon-attachment-audit.json`. The compiled reference
`FakeRigidBodySwapper.cs` and `SoldierParts.cs` were byte-identical to the active recovered source.
No .NET/protobuf contract changed in this stage, and no new Battle/Mongo or Android acceptance
is claimed from these Unity Editor checks.

## Required before connecting normal gameplay

The current `SelfHostedInfantryPresenter` does not yet invoke this adapter. No new host
attachment snapshot or protobuf field has been added in this stage. Therefore visible Mortar
world/hand behavior is still an open integration requirement.

Do not infer the detached world transform from a late `mortar_hide` row and the receiver's
current hand. The hand may already be sampling another animation phase, and Mortar can retarget
its body during windup. A reconnect must restore the original captured world pose rather than
detach at the receiver's current pose. The next stage needs source-backed preparation-pose
sampling and an authoritative captured transform or an equally complete deterministic
reconstruction contract, validated through SDK projection, replay and Unity rendering.

The existing native coroutine reference observes hand return 34 ticks after preparation for
`mortar_hide` length 1.1000061 at 30 Hz. It does not prove the exact pre-detachment bone pose or
the full EnemyController/animation/TweenRotation execution order. Verify those before choosing
the host capture phase. The target indicator, missile particles/trails, normal two-Unity-player
gameplay and Android acceptance also remain open.
