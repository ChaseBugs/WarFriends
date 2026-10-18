# Card Grenadier primary fire

Card Grenadier primary choices now launch the selected pistol through the host's shared army
projectile collision path. Earlier code skipped every non-grenade intent. The new binding also
lets Sickness change both current weapon damage fields and current health together. Complete
Grenadier combat and Sickness integration still require the remaining verification below.

## Recovered evidence

- `SoldierBehaviourGrennader.PickTarget` chooses the secondary weapon before choosing a target.
  `ArmyCardGrenadierRuntime.SecondaryWeaponProbability` is currently source-backed at 0.4.
  The other branch needs primary fire; a fixed grenade-only fixture cannot prove that branch.
- MainScene Grenadier inventory component 41066 has matching `weapons` and `cardWeapons` arrays.
  Both use primary component 11431434, GUID `16439357c0b8cbc4a91424818b10119d`, runtime type 0,
  right hand; this resolves to `Assets/GameObject/PistolEnemy.prefab`.
- The secondary component is 11419550, GUID `bd74fc4b54938454a92a050c5517d60b`, runtime type 1.
- The pistol's Gun component points to spawn transform 434467 and BulletSlow component 11409266,
  GUID `855689762fa6e774aaee190652b08c6f`. `Weapon.ammoSetup` gets the AmmoSetup on the weapon's
  own GameObject. Follow that exact component and transform chain; the prefab contains other
  speed fields that must not be confused with the selected weapon's setup.
- `SoldierBehaviour.ApplyWeaponsSetup` assigns primary damage from the composed soldier definition,
  player damage coefficients from upgrade slots and cadence 0.35 seconds. The Grenadier override
  uses BulletSlow and separately configures the secondary grenade's minimum/explosion fields.
- The pinned `recovered-rusher-weapon-bindings.json` currently contains eight other families,
  excluding `ID_UNIT-GRENADIER`. Its schema and revision are preserved. The separate embedded
  Grenadier primary artifact supplies this unit's selected weapon instead.

## Implemented native path

`tools/extract_grenadier_primary_weapon.py` verifies normal/card inventory equality, inventory
attachment to the actual Grenadier behavior, asset GUID metadata, the same-GameObject AmmoSetup,
right-hand rig/weapon spawn chain, BulletSlow identity and runtime override source. It exports
`content/recovered-grenadier-primary-weapon.json`, SHA-256
`c2d37997ce348808aacc46ec0a484e45ac8ed7ab696abd2c1b4d8fe162c63edf`.
Reproduce it with `python Server/tools/extract_grenadier_primary_weapon.py --check` from the root.

The selected runtime speed is 5, collision check distance 0.35 and fake speed 7.5. The prefab has
other speed fields, which are not the same-GameObject selected AmmoSetup. The exported resting
enemy-rig muzzle is approximately `(0.3178592, 0.18429394, 0.051513106)`; no animated-hand pose
parity is claimed. `GrenadierPrimaryWeapon` validates the entire artifact hash before publishing
immutable values. The resting muzzle is retained as provenance; actual firing now uses the
[native corner callback samples](GRENADIER_CORNER_MUZZLES.md).

`LaunchCardGrenadierPrimary` uses current match-owned primary damage initialized from the card
row. Real bullets use the ordinary army flight and collision authority. Fake bullets use the
same collision-free doubled-distance tween as `BulletBase.AnimateShot`, with fake speed 7.5.
The shared flight flag is now named `cosmeticTrail` because it is used by both fake pistol shots
and shotgun trails. Primary launches freeze raw damage and the source player/overtime damage
policy. Shield hits keep raw weapon damage; player hits consume the separate source coefficients.

`ApplySicknessToCardGrenadier` validates both weapon calculations and vitality before publication.
It halves current primary damage and secondary minimum, preserves separate grenade explosion
damage, and refills current health to half maximum. Death removes current primary damage while
retaining already launched projectile authority. Subsequent Sickness cannot rewrite that authority.

Focused checks cover exact selected fields, native callback muzzles in two directions, corrupt
artifact/invalid pose rejection and collision-free fake flight. Native combat uses an explicit
host RNG: primary selection first, then real-shot draws. It verifies actual primary intent,
projectile speed/damage, Sickness changes before/after launch, current-weapon cleanup on death
and a subsequent actual host collision. The fixture does not assert a particular victim-health
or shield delta; dedicated damage/friendly-exclusion fixtures remain required.

## Remaining verification

Release build passes with zero warnings/errors. `--sickness-window-only` passes 92 checks,
including native muzzle/source verification. `--combat-only` passes 26,395 assertions with the
native primary-choice fixture. The full default suite was not rerun.

1. Verify victim health/shield deltas and friendly exclusions for actual primary shots, including
   the source player/overtime coefficients. Extend fake-flight checks to host-scheduled fake shots.
2. Extend the direct native animation-controller observation to normal EnemyController execution,
   warm-state reuse and Client presentation. Five firing rounds on both sides are now observed.
3. Add authenticated UDP and Client presentation proof before treating the complete unit behavior
   as finished. These are separate from both the native primary fixture and grenade fixture.

Automatic Sickness arming/start/spawn/finish dispatch and authorized card use remain separate
incomplete work. The current host-only binding and native tests do not activate a SICKNESS card
through a Client command.
