# Mortar construction facing

Ordinary Mortars now rotate from their current host walking orientation toward the opponent's
current point shield while constructing. Accepted cover changes restart rotation from its current
sample. This affects the host collision pose and the existing protobuf infantry-facing fields.
Automatic firing, shot target preparation, overhead missiles, impacts, post-shot relocation and
normal Unity gameplay remain incomplete.

## Recovered control flow

`EnemyController.SwitchStateToMortar` invokes `Rotate` after stopping and beginning construction.
`Rotate` captures `enemyOf.currentPlayerPoint.point`, aims at its `shield.shotPosition` with Y
removed, and calls `TweenRotation.Begin` for 0.2 seconds with `ignoreTimeScale=false`.

`PlayerController.UpdateGoLeftRight` assigns the accepted destination to `currentPlayerPoint`
before `GoTo` starts physical movement. The host therefore uses an active route's `Destination`,
not its still-old physical `Cover`, for this logical point identity. The authoritative map supplies
the shield position; packets cannot provide Mortar yaw, rotation duration or target coordinates.

`MortarUpdate` gives its strict first-fire condition priority over the cover-change branch. The
adapter stops construction retargeting on `FirstFireEligibleTick`. A previously captured tween
continues sampling to completion. This implements branch priority, **not `FireMortar` execution**;
the shot executor is still required.

## Rotation model and native evidence

`TweenRotation` captures Euler rotations and calls `Quaternion.Slerp`. The active `UITweener`
defaults to EaseInOut, with `steeperCurves=false`; `Begin` resets its curve to the source keys.
Their segment tangents are both one, so the curve is linear after the sine easing:

```text
u = clamp(elapsed / 0.2, 0, 1)
eased = u - sin(2 * pi * u) / (2 * pi)
```

Native Unity observations show a near-rotation normalized-linear branch that differs from .NET's
default Slerp. `MortarFacingTween` uses normalized Lerp when the absolute quaternion dot is at
least 0.95 and Slerp otherwise. The native reference covers both sides and the boundary, small
angles, wraparound and half-turns. The vector error threshold stays at 0.00001; it was not widened
to hide that difference.

`UnityMortarFacingAudit.Run` exited zero in the disposable Unity 2018.3.0f2 project. It invokes
the actual source `TweenRotation.Begin/Sample` for 25 yaw cases and seven explicit factors each,
giving 175 native samples. The component is added before setting the requested start rotation:
Editor AddComponent invokes `UITweener.Reset`, which would otherwise erase the probe setup.
The final reference is LF-normalized and pinned as
`1fcae99a4e8ec9f51775f61cc7ce279d83bce0396d7c8b93731de8fc552e33b6`.

The copied tween source files matched the active Client bytes. Windows working-tree SHA-256
fingerprints used for this observation are:

```text
b413504f45103aa0cadaefb89141caa4b43d705953ee0b7450388a1e0551d375  TweenRotation.cs
9701b22bdb46bb2cf6e42f9d155dd5ad9453ce255b5a2bddd7a2d81ea576fef7  UITweener.cs
```

The native capture proves explicit factor sampling on an unparented probe. It does not prove
native `Update` order, variable frame timing, an original Unity 5.2.5 build, Android, arbitrary
rotated parents or normal battle-controller presentation. The host uses its existing 30 Hz clock:
it samples an old tween at the current tick before capturing a replacement, then publishes the
new facing before army projectile collision processing. Starting orientation still comes from
the existing host navigation model; exact native walking/turning equivalence remains separate.

## Verification and remaining work

`--mortar-facing-only` passes 308 checks. Native comparison covers all 175 samples. Real ordinary
deployments on both fractions of every multiplayer map verify immediate logical-cover retargeting
while the opponent remains physically at the old cover, current-orientation continuity, all six
rotation ticks, final shield-facing direction, collision/protobuf agreement, same-frame first-fire
priority and death cleanup. Protobuf is serialized and parsed using the existing infantry fields;
this is not normal Unity SDK/gameplay acceptance.

`--ordinary-mortar-only` now passes 520 checks including setup, navigation, native endpoints and
construction facing. The .NET solution build has zero warnings/errors and the protocol executable
passes 1,360 checks. The private Unity package manifest was restored byte-for-byte after the owned
audit exited. Active Client source, scenes, settings and owner library work were not changed.
The full default Battle executable exited zero with 248,439 engine/admission/SDK/geometry and
real two-peer UDP assertions; local evidence is `Server/.local/mortar-facing-full.log`.

Next, implement `FireMortar` and `PrepareToShoot(false, false, 0)` with their source callback order,
target selection, weapon cadence and world/hand attachment, then delayed overhead flight and
authoritative contact/explosion. Validate native callback/poll timing and actual Unity battles
before closing the complete Mortar feature.

The reviewed next-stage source chain is concrete:

- `FireMortar` plays `mortar_hide`/queued `mortar_up` and snaps the weapon into world space
  **before** `PrepareToShoot`. It schedules hand reattachment after `mortarShotTime` and
  relocation after the sum of the shot/up clip lengths.
- `PrepareToShoot` selects a target and initializes the real/fake batch. Its Mortar weapon
  branch calls `Shoot(0.3f)`. That method schedules `InvokeAfter`, which sets `mIsShooting`;
  `ShootingFromWeapon` then polls `SoldierBehaviour.Shooting`. `mortar_hide.anim` has no
  animation events, so inventing an animation launch event would change the contract.
- The base normal Mortar row has batch size one, real-shot probability one, five-to-seven-second shot-frequency fields
  and two seconds of construction. Preserve the source random draws and callbacks; after shot
  return, `ReturnToPreviousStateFromMortar` sets the next shoot time to maximum rather than
  letting the ordinary frequency alone authorize another stationary shot.
- `MortarEnemy.prefab` uses `Missile.prefab`, a two-second weapon cadence, straight trajectory,
  and the source 0.8/1.2 explosion radii. Runtime behavior overrides speed/stop time/damage as
  described in `ORDINARY_MORTAR.md`; prefab defaults cannot replace those current fields.
- `PickTarget` selects the shield target and subtracts 0.4 units vertically. `Mortar.Shoot`
  spawns five units above that target. Capture the current missile setup at launch and preserve
  it through later weapon changes or shooter death before awarding any impact.
