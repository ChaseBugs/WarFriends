# Ordinary Mortar firing and relocation

This stage connects natural ordinary Mortar deployments to preparation, delayed missile launch,
host collision/explosion handling and another navigation/construction cycle. It follows the active
recovered 1.4.0 Client; it does not replace that gameplay with Ice MOBA's simulation model.

## Source contract and host ownership

- `EnemyController.MortarUpdate` calls `FireMortar` before `PrepareToShoot(false, false, 0)`.
  The host selects `mortar_hide`, then `mortar_up`, even if target preparation fails.
- `SoldierBehaviourMortar` chooses an opposing player's logical cover Shield position and
  subtracts 0.4 vertically. The target is captured before the callback and does not track movement.
- `SoldierBehaviour.StartShooting` consumes the recovered batch and real/fake draws. All supported
  Mortar rows produce one shot. The five-to-seven-second cooldown draw still occurs during
  preparation and completion even though the Mortar override replaces that deadline.
- `Shoot(0.3f)` schedules a coroutine callback. The fixed host projection currently places that
  callback nine ticks after preparation and the first gameplay poll one tick later. An actual
  Unity 2018.3.0f2 `Core_BaseScript.InvokeAfter` observation confirms both offsets at preparation
  ticks 5, 65 and 305. The pinned `mortar-clock-unity-reference.json` records imported-source and
  active-source fingerprints. It also observes hand return after 34 ticks and strict relocation
  after 61 ticks for these clip lengths. This empty-scene probe does not prove full gameplay order.
- `Weapon.willShoot` uses a strict two-second cadence, retained across relocation cycles.
  A shot snapshots current contact/explosion damage, speed, stop time and player shield policy.
  Later soldier removal cannot remove or alter an airborne missile's launch authority.
- `Mortar.Shoot` starts five units above the captured target. The shared straight Missile flight
  begins with negative progress from current stop time. It remains stationary during that delay,
  descends at current speed, arms after half a unit and traces on the following update.
- Real impacts use the reviewed shared 0.8/1.2-radius missile damage implementation. Fake impacts
  never apply damage. Host projectile/event capacity failure consumes the attempted shot without
  inventing a later damage-producing retry.
- `FireMortar` sets the movement deadline with left-associative binary32 additions of current
  time, `mortar_hide` length and `mortar_up` length. After the strict comparison passes, the host
  chooses a free same-fraction source point in original order, excludes the current point,
  validates the route, transfers occupancy and begins walking on the following tick. No candidate
  means retry next tick with the previous reservation intact. Construction and firing repeat;
  current health, weapon setup and cadence are retained.

During preparation windup, `GenerateNextShootTime` permits cover-change rotation again. The
first-fire branch still takes priority on its own tick. Shot completion resets the deadline to
maximum, ending further retargeting for that stationary cycle.

## Client integration

Projectile rows use `army-mortar` or `army-mortar-fake`, exact `ArmyUnitId=ID_UNIT-MORTAR`, no card
source, no weapon source and no poison. The portable SDK validates these fields before exposing
a snapshot/scan to Unity. The installed SDK DLLs and manifest were refreshed without changing
their metadata GUIDs.

`SelfHostedProjectilePresenter` resolves the normal Mortar weapon from the recovered behavior
inventory, copies its Missile projectile model and uses the recovered Small scale. The copied
visual contains meshes/renderers/transforms only. Impact presentation selects Small effects;
the original Missile, Photon and collision scripts are never activated on that visual.

The private Unity 2018.3.0f2 visual audit passed: one copied mesh, correct Small scale, no gameplay
or collision components. Its companion launcher audit passed 17 compiled methods, twelve enabled
scenes with no missing scripts, and eight serialized launcher fields. Static asset checks retain
1,052 script targets and 288,258 references with no broken references or missing attachments;
the same seventeen unmatched NGUI sprite selections remain. This is not original Unity 5.2.5,
Android, rendered normal gameplay or external-network-denial acceptance.

## Verification and open acceptance

The focused Mortar executable passed 684 checks after firing and relocation integration. The
final `--mortar-shooting-only` group passed 119 firing/flight/relocation/SDK and native-clock checks.
Natural launch fixtures exercise base, middle/special and final/special upgrades, callback-before-poll
ordering, frozen overhead origins, SDK row validation, shooter death and terminal missile cleanup.
A repeated-cycle fixture requires a different reserved point, rebuilt construction and a second
projectile while retaining the same current weapon setup. The complete Battle suite exited zero
with 248,560 engine/admission/SDK/geometry and real two-peer UDP assertions. That complete run
preceded the added native-clock regression tests; the final focused run above verifies those
against the pinned reference. The protocol executable passed 1,360 checks. Full-suite evidence
is local at `Server/.local/mortar-shooting-full.log`.
The native Windows MongoDB/HTTP/protobuf/UDP smoke also passed 74 checks with two independent
clients and no Photon, including transaction/replay and Worker restart/cancellation recovery.
Its isolated data/logs are at `Server/.local/smoke-d775a9ddd77045798444ac2afb328b52`.

Still required before calling Mortar complete: native full gameplay
update/animation order, visible world/hand weapon detach/reattach, the target indicator, source
particle/trail behavior, natural fake-shot and Sickness impact fixtures, and normal two-Unity-player
gameplay/reconnect plus Android build/runtime acceptance. A shared explosion implementation and
successful SDK validation do not prove all of those paths.

The next [weapon attachment stage](MORTAR_WEAPON_ATTACHMENT.md) implements and compares the
script-free detach/restore operations with the original swapper. It is not yet connected to
normal presentation; reconnect requires a source-backed captured world-pose contract first.
