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
That initial attachment-only stage changed no .NET/protobuf contract. The wire integration below
is a subsequent stage; neither Editor audit establishes Android acceptance.

## Protobuf and production presenter integration

The [preparation-pose stage](MORTAR_PREPARATION_POSE.md) captures host world-transform authority
and its hand deadline. `BattleArmyEntityState.mortar_weapon_pose` now carries that immutable
capture and the page's observation tick. The host omits it after hand return or terminal cleanup.
`MortarWeaponPosePolicy` checks unit/card identity, clip phase, lifetime, finite bounded position,
unit rotation and source-scale bounds. Both SDK row receipt and paged roster assembly enforce it.

`SelfHostedInfantryPresenter` binds the adapter to the admitted ordinary Mortar inventory and
applies the absolute captured pose even when the actor first appears mid-windup. Later body
motion cannot move the detached weapon. Hand return follows authoritative match ticks, not a
local wall clock. An older page cannot resurrect a detachment once current match time has
reached its deadline. Removal disposes detached geometry before destroying the actor.

The private Unity 2018.3.0f2 production-presenter audit passed nine decoded protobuf checks:
late reconstruction, world rotation/scale, independence from body movement, removal, recreated
reconnect-state reconstruction, tick expiry, stale observation rejection and malformed input.
It also reran the source attachment and ordinary inventory audits. Evidence is local at
`Server/.local/mortar-pose-wire-unity-final.log`. This is an Editor adapter audit with synthetic
decoded rows, not a real two-Client network reconnect or rendered battle proof.

The preparation-focused .NET group passes 1,462 assertions, including actual host capture
serialization throughout windup, expiry and terminal cleanup, SDK malformed-pose rejection,
independent page observations and cloned replay rows. The protocol executable passes 1,360
assertions. The final focused Release run also encodes four independent copies of each real
detached host row in one authenticated page, verifying the existing 1,200-byte packet limit
throughout windup. This exercises page capacity without claiming four naturally deployed actors.
Active asset audits still resolve 1,052 script files and 288,258 references with
zero missing scripts or broken references; the existing seventeen unmatched sprite selections
remain. The private package manifest was restored after the owned Unity process exited.

The complete Battle executable passed 250,286 assertions with the wire/presenter production
changes. Its log is `Server/.local/mortar-pose-wire-full.log`. The additional four-row packet
budget assertion was then verified in the focused Release run without changing production code.
The final solution build passed with zero warnings/errors, and the native Windows isolated
MongoDB/HTTP/protobuf/UDP smoke passed all 74 live checks with two independent clients and no
Photon. It includes reconnect and restart/replay paths, not normal Unity gameplay. Its data/logs
are at `Server/.local/smoke-9f300b8a2689442582cbc521b124772e`; the aggregate log is
`Server/.local/mortar-pose-wire-smoke.log`.

The existing native coroutine reference observes hand return 34 ticks after preparation for
`mortar_hide` length 1.1000061 at 30 Hz. The preparation-pose observation now supplies the native
snap-point pose in both animation-controller orders. Full EnemyController/animation/TweenRotation
order remains separate from that stripped-rig evidence. The target indicator, missile particles/
trails, normal two-Unity-player gameplay and Android acceptance also remain open.
