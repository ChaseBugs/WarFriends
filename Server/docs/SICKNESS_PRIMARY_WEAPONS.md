# Sickness ordinary gun bindings

The existing ordinary Assaulter binding now shares its validated damage/vitality mutation with
ordinary Snipers and Minigunners. `MatchEngine.SicknessPrimaryWeapons.cs` keeps an explicit
three-unit allowlist. It does not infer support for every SoldierBehaviour or enable SICKNESS
card activation while other weapon layouts remain unbound.

## Source rules and authority

`CardSickness.OnAfterSpawned` checks the opposing fraction, EnemyController identity and
`canBeFreezed`, calls `ImproveAllWeapons(0.5)` and refills current health to half maximum.
It does not halve maximum health or restore weapon damage when the subscription disconnects.
EnemyController excludes Vehicle, Helicopter and MachineGunPoint states from freezing;
ordinary Sniper Walk/Corner and Minigunner states pass this check.

The three reviewed ordinary launch paths consume the private `armyDamage` ledger. The shared
mutation validates both vitality mirrors, current damage and revision capacity before changing
health or weapon damage. Sniper critical probability/multiplier, cadence, target selection and
weapon setup remain separate source authority. Card-spawned units and other ordinary families
are rejected by this binding rather than silently treated as supported single-gun layouts.

## Verified scope

`SicknessPrimaryWeaponTests` deploys friendly and opposing ordinary units using trusted base
upgrade lanes. Its explicitly armed source window is connected to real start/finish and spawn
callbacks. The actual callback leaves friendly units unchanged, preserves maximum health and
sets opposing current health and current gun damage to half their source values. After the
window disconnects, repeated calls neither restore nor reapply the effect.

The fixture then advances normal host ticks until an affected soldier launches a real projectile:

| Ordinary unit | Captured launch damage | Host tick |
| --- | ---: | ---: |
| Sniper | 29.025 | 229 |
| Minigunner | 22.235 | 353 |

Each launch is bound to the affected soldier and its captured pre-effect damage, with special
upgrades absent. This proves automatic changed gun damage after the window closes, not special
critical behavior, every physical victim outcome or normal Unity presentation. Existing Assaulter
tests separately prove changed shield damage through a real collision.

The Sickness group passes 128 checks, the Assaulter group passes 110 and shared combat regression
passes 26,395 assertions. Release build has zero
warnings/errors. The full default Battle suite was last verified at commit 8ed268d3e with
247,551 assertions; it was not rerun for this binding checkpoint.

SICKNESS remains incomplete: other eligible weapon layouts, the global source spawn categories,
authorized card command/reservation consumption, SDK/normal Client activation, icon presentation
and terminal inventory proof still need integration. These tests arm the internal window directly
and must not be described as authorized card-use verification.
