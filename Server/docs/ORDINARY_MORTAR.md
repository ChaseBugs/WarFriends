# Ordinary Mortar weapon authority

The host initializes current ordinary Mortar weapon authority before the real spawn observers run.
[Navigation and construction entry](MORTAR_NAVIGATION.md) now connect real deployments to authored
destinations, construction deadlines and clips. Automatic firing, flights, collision, complete
construction rotation/presentation, normal Unity gameplay and authorized SICKNESS use remain required.

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

The initial weapon/setup group passes 49 checks; `--ordinary-mortar-only` now includes navigation
and native destination bindings for 212 checks in total.
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

Complete construction-facing rotation and firing callbacks, shield target selection with its
vertical offset, delayed overhead missile flights,
contact and explosion authority, airborne shooter-death cleanup, protobuf/SDK presentation,
and normal Unity gameplay. Compare source-backed baseline and Sickness launches after the
window closes; preserve the independent explosion fields through actual impacts.

The next source chain is explicit: `EnemyPointMortar.Awake` selects the Mortar state;
`EnemyController.SwitchStateToMortar` captures the stopped position and starts construction;
`MortarUpdate` uses a strict time comparison before `FireMortar` and `PrepareToShoot`.
`Mortar.Shoot` places the physical launch five units above the selected target.
`Missile.AnimateShot` initializes negative progress from stop time, and `Missile.Update`
clamps negative progress to zero before flight. Do not substitute a projectile launched from
the soldier's weapon muzzle or an invented ballistic arc for this overhead-delay path.
