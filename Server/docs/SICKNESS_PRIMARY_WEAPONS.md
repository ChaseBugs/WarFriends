# Sickness ordinary gun bindings

The ordinary binding now covers Assaulter, Sniper, Minigunner, Paratrooper, SWAT, Gunslinger,
Commando, Shotgunner and Warper source layouts. `MatchEngine.SicknessPrimaryWeapons.cs` keeps an explicit
nine-unit allowlist. It does not infer support for every SoldierBehaviour or enable SICKNESS
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

Paratrooper and Gunslinger currently have spawn-mutation/disconnection proof only. Normal
Paratrooper deployment can select an airborne spawn without initializing the existing card
parachute/landing executor. [Normal Gunslinger navigation](GUNSLINGER_NAVIGATION.md) now reaches
its source point and initializes entry counters, but has no ordinary shot/burst executor yet.
Those independent gameplay paths remain explicit implementation work; their tests report no
automatic-fire proof, and do not inject a shot or a ground position to conceal the missing AI.

Each conventional-gun launch is bound to the affected soldier and its captured pre-effect damage, with special
upgrades absent. This proves automatic changed gun damage after the window closes, not special
critical behavior, every physical victim outcome or normal Unity presentation. Existing Assaulter
tests separately prove changed shield damage through a real collision.

The Sickness group passes 163 checks, the Assaulter group passes 110 and shared combat regression
passes 26,395 assertions. Release build has zero
warnings/errors. The full default Battle suite was last verified at commit 8ed268d3e with
247,551 assertions; it was not rerun for this binding checkpoint.

SICKNESS remains incomplete: other eligible weapon layouts, the global source spawn categories,
authorized card command/reservation consumption, SDK/normal Client activation, icon presentation
and terminal inventory proof still need integration. These tests arm the internal window directly
and must not be described as authorized card-use verification.
