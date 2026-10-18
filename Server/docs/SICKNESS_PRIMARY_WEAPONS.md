# Sickness ordinary gun bindings

The ordinary binding now covers Assaulter, Sniper, Minigunner, Paratrooper, SWAT, Gunslinger,
Commando, Shotgunner, Warper and Flamethrower source layouts. `MatchEngine.SicknessPrimaryWeapons.cs` keeps an explicit
ten-unit allowlist and separate ordinary Grenadier and Rocket Soldier adapters. It does not infer support for every SoldierBehaviour or enable SICKNESS
card activation while other weapon layouts remain unbound.

## Source rules and authority

`CardSickness.OnAfterSpawned` checks the opposing fraction, EnemyController identity and
`canBeFreezed`, calls `ImproveAllWeapons(0.5)` and refills current health to half maximum.
It does not halve maximum health or restore weapon damage when the subscription disconnects.
EnemyController excludes Vehicle, Helicopter and MachineGunPoint states from freezing;
ordinary Sniper Walk/Corner and Minigunner states pass this check.

The seven conventional gun families consume the private `armyDamage` ledger as gun damage.
Commando initializes both guns from the same damage, and its alternating launches read that
shared ledger. Paratrooper kevlar and Commando poison ratio are separate fields.
For Shotgunner and Warper this ledger instead represents the maximum falloff damage. The shared
mutation validates both vitality mirrors, current damage and revision capacity before changing
health or weapon damage. Sniper critical probability/multiplier, cadence, target selection and
weapon setup remain separate source authority. Card-spawned units and other ordinary families
are rejected by this binding rather than silently treated as supported single-gun layouts.

## Shotgun field exception

`SoldierBehaviourShotgunner.ApplyWeaponsSetup` and the Warper equivalent populate
`ShotGunBulletSetup.maxDamage` and `minDamage` independently of `damageAmount`.
`ImproveAllWeapons` assigns only `damageAmount`; it never calls `ScaleDamage`, which would also
scale both range fields. `BulletShotGun.ShotRealAtPos` then overwrites `damageAmount` from those
unchanged range fields before loading the real bullet. Accordingly Sickness refills current
health but does not change the host shotgun range authority. Halving the host maximum would
incorrectly halve both the minimum and maximum of every later real hit.

## Flame field exception

`SoldierBehaviourFlamethrower.ApplyWeaponsSetup` sets `FlameAmmoSetup.maxDamage` to
composed damage divided by six and `minDamage` to one tenth of that maximum.
`SoldierBehaviour.ImproveAllWeapons` does not change either field. `FlameAmmo.CheckHit`
replaces `damageAmount` with its distance interpolation on every pulse before loading the
setup and applying damage. The host therefore preserves the damage-range ledger while
refilling current health. Calling `FlameAmmoSetup.ScaleDamage` or halving that ledger would
invent a reduction in real flame damage absent from the recovered Sickness path.

The ordinary flame test uses real deployment callbacks, compares the first automatic burst
with a baseline host, and applies one trusted infantry damage pulse using real deployed
collision poses. The pulse origin is chosen by the test; this is not proof of natural AI
contact, every victim family, overtime or the separate death explosion.

## Verified scope

`SicknessPrimaryWeaponTests` deploys friendly and opposing ordinary units using trusted base
upgrade lanes. Its explicitly armed source window is connected to real start/finish and spawn
callbacks. The actual callback leaves friendly units unchanged, preserves maximum health and
sets opposing current health to half maximum. Conventional gun damage halves; the separate
shotgun min/max authority stays unchanged as described above. After the
window disconnects, repeated calls neither restore nor reapply the effect.

The fixture then advances normal host ticks until an affected soldier launches a real projectile:

| Ordinary unit | Captured launch damage | Host tick |
| --- | ---: | ---: |
| Sniper | 29.025 | 229 |
| Minigunner | 22.235 | 353 |
| SWAT | 58.075 | 551 |
| Commando | 29.27 | 444 |

The next consecutive round from the same Commando also retains half damage through its
alternating-gun path. Separate affected/baseline hosts produce matching launch ticks and
identical actual Shotgunner damage 30.46239 and Warper damage 187.64558; Sickness changes
current health but leaves the source shotgun falloff intact.

Paratrooper currently has spawn-mutation/disconnection proof only. Normal deployment can
select an airborne spawn without initializing the existing card parachute/landing executor.
The [ordinary Gunslinger shooting path](GUNSLINGER_SHOOTING.md) now supplies actual automatic
projectile evidence: the affected actor launches damage 118.245 at tick 324 after the window
closes. The test does not inject a shot or move the actor to conceal missing AI.

Each conventional-gun launch is bound to the affected soldier and its captured pre-effect damage, with special
upgrades absent. This proves automatic changed gun damage after the window closes, not special
critical behavior, every physical victim outcome or normal Unity presentation. Existing Assaulter
tests separately prove changed shield damage through a real collision.

The ordinary Mortar group adds 49 setup/deployment checks; the combined Sickness group passes 265.
The infantry weapon group retains 150.
The current full default Battle suite passes 248,439 battle/admission/SDK/geometry and real
two-peer UDP assertions, including Mortar setup/navigation/facing, ordinary Rocket and card Rocket regressions.

SICKNESS remains incomplete: other eligible weapon layouts, the global source spawn categories,
authorized card command/reservation consumption, SDK/normal Client activation, icon presentation
and terminal inventory proof still need integration. These tests arm the internal window directly
and must not be described as authorized card-use verification.

## Ordinary Grenadier

The ordinary Grenadier adapter validates current grenade authority before publishing the shared
primary-weapon and vitality mutation. Ordinary grenade setup now completes before spawn
observers, so callbacks cannot see missing grenade authority or have their changes overwritten. Source `SoldierBehaviour.ImproveAllWeapons` changes only
`AmmoSetup.damageAmount`: pistol damage and grenade Minimum halve, while separate Explosion
damage, fuse, throw setup and maximum health remain unchanged. Current health refills to half
maximum rather than multiplying the current wounded value.

`SicknessOrdinaryGrenadierTests` uses real Park deployment start/finish/spawn callbacks with an
explicitly armed trusted window. Base, special and Elite upgrade selections verify the mutation,
unchanged setup, real published grenade launch damage and rejection after window disconnection.
These host tests do not prove authorized SICKNESS card activation or normal Unity gameplay.

## Ordinary Rocket Soldier

The [ordinary Bazooka integration](ORDINARY_ROCKET_SOLDIER.md) binds source normal/special lanes
to current missile setup before spawn observers. Its adapter changes only missile contact damage
and current health. The shared `armyDamage` value represents the unchanged explosion authority;
that mirror is checked before mutation. Special speed, behind-shield reduction and frozen airborne
records stay unchanged. Real deployment/finish callbacks, natural Corner launches, shooter death
and missile completion are checked for base, middle/special and final/special selections.

## Remaining ordinary layouts

The recovered deployment catalog has sixteen soldier families. Ten scalar/range layouts and the
two specialized Grenadier/Rocket layouts above have reviewed host bindings. Mortar now has
spawn/current-weapon authority but no natural attack proof. The other three remain closed here;
their visible source expressions are requirements, not implementation:

| Ordinary family | Recovered field or eligibility constraint | Missing host proof |
| --- | --- | --- |
| Engineer | Base soldier weapon setup is separate from the turret it constructs. | Inventory layout, engineer lifecycle and exact spawned-owner scope. |
| Machinegunner | Its gun uses base damageAmount; MachineGunPoint is explicitly excluded by canBeFreezed. | Spawn/current-state eligibility, gun binding and normal attacks. |
| SciFi | ApplyWeaponsSetup writes grenade minimum and separate explosion; its initial Fly state is eligible. | Both current grenade fields, normal movement and actual flights. |
| Mortar | Contact is 0.1 times damage, explosion is full damage, speed is 20 and stopTime is reciprocal shotSpeed. | [Setup/spawn mutation](ORDINARY_MORTAR.md), [navigation](MORTAR_NAVIGATION.md) and [construction facing](MORTAR_FACING.md) pass; actual shots/flights/hits and normal Client remain open. |

`EnemyController.StartEnemyBehaviour(state)` assigns the supplied state before raising the base
AfterSpawned event. A future global adapter must test the actual spawn state rather than infer
eligibility from the unit name or later point type. Non-ordinary/card/crew spawn categories,
ordered global event subscription, authorized SICKNESS consumption and Client icon presentation
remain separate requirements. Completing this table alone will not complete the card.
