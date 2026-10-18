# Ordinary Mortar weapon authority

The host initializes current ordinary Mortar weapon authority before the real spawn observers run.
[Navigation and construction entry](MORTAR_NAVIGATION.md) now connect real deployments to authored
destinations, construction deadlines and clips. [Construction facing](MORTAR_FACING.md) now connects
current/logical-cover rotation to collision and protobuf poses. [Firing and relocation](MORTAR_SHOOTING.md)
now connect captured targets, callbacks, overhead missiles and repeated construction cycles. Native
full gameplay order/presentation, normal Unity gameplay and authorized SICKNESS use remain required.

## Recovered rules

Evidence comes from the active 1.4.0 Client:

- `SoldierBehaviourMortar.ApplyWeaponsSetup` sets missile speed to 20, contact damage to
  composed damage times 0.1, explosion damage to composed damage, stop time to reciprocal
  `shotSpeed`, and shield reduction to the upgrade slot's `playerBehindShieldDamageRatio`.
- MainScene behavior component 41188 has serialized `baseDefinition.shotSpeed: 5`, but
  `UpgradeSlotsGeneric.LoadData` replaces it with `ArmyUpgrades.BULLETSPEED`, which is **0.43**
  for `Google2u.DBUpgradeSlotsMortar`. `BehaviourDefinititon.LoadZeros` and soldier lane loading
  preserve that replacement. `BehaviourDefinititon.ScaleByPerk` then multiplies it by the perk's
  shot speed coefficient. Unmodified stop time is therefore `1f / 0.43f`, not `1f / 5f`.
  Serialized defaults and upgrade shot-frequency fields must not substitute for runtime authority.
- The existing validated source catalog supplies 26 normal rows, six special rows beginning
  at index 26, and no Elite lane. Damage uses the admitted normal/special selection and mode scale.
- `SoldierBehaviour.ImproveAllWeapons` writes only `AmmoSetup.damageAmount`.
  It bypasses `MissileSetup.ScaleDamage`, so Sickness preserves explosion damage, speed,
  stop time and shield reduction. Current health refills to half maximum; maximum stays unchanged.
- `EnemyController.StartEnemyBehaviour` sets the spawn state before its base spawn event.
  Ordinary Mortar enters Walk, and later Mortar also passes `canBeFreezed`. Vehicle,
  Helicopter and MachineGunPoint remain excluded; this adapter does not cover their callbacks.

## Host changes and verification

`ArmyDeploymentCatalog.ComposeOrdinaryMortar` accepts an explicit admitted selection rather
than projectile fields from packets. The host captures the result before invoking spawn observers.
Its contact field lives separately from the unchanged `armyDamage` explosion mirror. The Sickness
adapter validates missile and vitality authority before publishing either change. Death removes
the current weapon row. No new client command or launch authorization is exposed.

The initial weapon/setup group passes 49 checks; `--ordinary-mortar-only` now includes navigation,
native destination bindings, construction facing, delayed flight and captured targeting for
632 checks at that targeting checkpoint. The subsequent firing/relocation checkpoint passed
684 focused checks; its native coroutine reference checks were added afterward. See
[firing verification](MORTAR_SHOOTING.md#verification-and-open-acceptance) for the current boundary.
Actual accepted Park deployments exercise base, middle/special and final/special rows; damage
scaling; faster/slower perk coefficients; friendly rejection; opposing current contact/health
changes; unchanged explosion/timing/setup; final deployment callbacks; disconnected-window
rejection; and death cleanup. Invalid/non-finite coefficients and the absent Elite lane fail.
These tests explicitly arm an internal trusted window. They do not prove automatic card activation,
inventory consumption, a natural Mortar shot or any projectile hit.

The full default Battle executable also passed 247,970 battle engine, admission, portable SDK,
geometry and real two-peer UDP assertions after the runtime shot-speed correction (exit 0).
Its local log is `Server/.local/ordinary-mortar-full.log`.

## Next required work

The in-progress targeting boundary is `MatchEngine.SelectMortarShotTarget`. It captures an
admitted opposing player's logical cover Shield position minus 0.4 units vertically. Source
`SoldierBehaviourMortar.PickPlayer` reads the shield probability only as a negative-value gate;
its walking multiplier does not introduce a probability draw or a body-target fallback. The
selector preserves both opponent and one-element Shield choices. It returns an immutable
position, so later movement cannot redirect an already prepared shot. The source's global
fallback to the local player when no active opponent exists is deliberately closed on the host;
the host never authorizes friendly targeting through that fallback.

Focused integration fixtures cover both fractions on all five maps, accepted cover movement
before physical arrival, retained earlier coordinates and removal on soldier death. The selector
is now called by the firing loop, which retains the vector through the delayed callback and freezes
current weapon setup at actual launch. See [firing and relocation](MORTAR_SHOOTING.md).

Validate normal Unity rotation/update order, complete world/hand attachment and indicator/particle/trail
presentation, and verify normal Unity gameplay. Compare source-backed baseline and Sickness launches after the
window closes; preserve the independent explosion fields through actual impacts.

The next source chain is explicit: `EnemyPointMortar.Awake` selects the Mortar state;
`EnemyController.SwitchStateToMortar` captures the stopped position and starts construction;
`MortarUpdate` uses a strict time comparison before `FireMortar` and `PrepareToShoot`.
`Mortar.Shoot` places the physical launch five units above the selected target.
`Missile.AnimateShot` initializes negative progress from stop time, and `Missile.Update`
clamps negative progress to zero before flight. Do not substitute a projectile launched from
the soldier's weapon muzzle or an invented ballistic arc for this overhead-delay path.
