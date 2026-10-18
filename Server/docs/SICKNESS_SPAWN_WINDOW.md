# Sickness callback and calculation kernel

The later [ordinary gun bindings](SICKNESS_PRIMARY_WEAPONS.md) connect current damage/vitality
for nine ordinary layouts, with separate source shotgun min/max semantics. Paratrooper and
Gunslinger automatic AI remain unbound. The combined focused Sickness group passes 163 checks; authorized SICKNESS card activation remains incomplete.

`SicknessSpawnWindow` implements the recovered `CardSickness` event rules independently of
network admission and mutable host entity state. It consumes the source option identities in
`ArmyDeploymentCatalog` and the [deployment wave metadata](ARMY_DEPLOYMENT_WAVES.md).

## Source behavior

- Arming subscribes to future events and resets the remembered definition. It does not attach
  retroactively to a deployment already in progress and has no fixed expiry timer.
- An opposing `SoldierBehaviour` start opens the window. Another eligible start replaces the
  remembered persistent definition, including while the window is already active.
- `AfterSpawned` checks opposing fraction, `EnemyController` identity and `canBeFreezed`. It does
  not restrict the entity to the remembered deployment occurrence. The literal source inequality
  also admits a neutral-fraction eligible `EnemyController` callback.
- A matching opposing finish disconnects callbacks. Definitions are reused by source option,
  so an older overlapping occurrence of the same option can end the window. Unique wave IDs
  cannot substitute for that reference comparison.

The kernel validates event definitions against the copied source catalog, including unit and
soldier classification. Target facts must come from the host's actual entity classification;
they are not Client assertions or an inference from soldier-family membership alone.

## Exact calculation

The MainScene SICKNESS component records `multiplierMaxHealth = 0.5` and
`multiplierDamage = 0.5`. `SoldierBehaviour.ImproveAllWeapons` multiplies every current weapon's
`AmmoSetup.damageAmount`. The one-argument `DestroyableObject.RefillTo` sets current health and
clears immortality/death flags; it does not change maximum health.

Accordingly, current health 10 with maximum 100 becomes current health 50, not 5, while maximum
stays 100. Weapon damage 20/0/80 becomes 10/0/40. Results copy the ordered damage list, reject
non-finite/negative authority before calculation, and do not mutate input data. Another actual
source callback multiplies damage again but refills health to half maximum again. Disconnect
does not restore modifications already applied to units.

The scene's card cooldown is not the pending spawn-window lifetime. No five-second or other
arbitrary effect lease is introduced here.

## Verification and boundary

Release build passes with zero warnings/errors. `--sickness-window-only` passes 116 checks for
arming, friendly/vehicle/immune exclusions, neutral and reversed fractions, replacement and
reused-definition finishes, repeated callbacks, exact vitality/damage calculations, immutable
output, invalid-event/state rejection, ordered spawn subscriptions and actual host deployment callbacks.
`--army-waves-only` passes its 12 lifecycle checks.
The new kernel test is registered in the default suite; the entire default suite was not rerun.

This does not activate Sickness in a match. Typed protocol and portable SDK methods, authorized
arming/card consumption, complete source-ordered spawn-effect dispatch, actual weapon/vitality bindings, Client
UI/presentation, UDP proof and durable terminal consumption remain required. SICKNESS stays on
the incomplete effect list until those paths are implemented and verified.
Host integration must also verify callback ordering with other spawn-time health/weapon modifiers;
this independent kernel does not establish that ordering.

## Actual host deployment notifications

`MatchEngine` now publishes internal start and finish notifications with the accepted source wave
and owning fraction. Start runs after successful host eligibility/reservation and statistics, before
the first entity is generated. Rejected commands do not notify. Finish runs after the returned
spawn batch is fully initialized and the strict final wait has elapsed; observing the same tick
again does not repeat a completion. These are host callbacks, not Client-supplied wave claims.

`SicknessHostDeploymentTests` subscribes the actual kernel to these notifications in a fixed Park
match. Both players use normal accepted DeployArmy commands. A friendly deployment leaves the
window pending; an opposing Assaulter deployment opens it. The finish observer reads all roster
pages and verifies the full opposing batch exists. Equality with the final wait keeps the window
open; the next tick disconnects it exactly once. This adds eight checks to the previous 92.

This test explicitly arms/subscribes the kernel. Production SICKNESS activation, automatic
AfterSpawned mutation across all eligible units and subscription cleanup are still required.
It does not prove network card consumption, Sickness UI or normal Unity gameplay.
The Release build has zero warnings/errors, and `--combat-only` still passes 26,395 assertions
after these host notification changes. The full default suite was not rerun.

## Normal Assaulter spawn mutation

`ApplySicknessToArmyAssaulter` now binds the kernel to the normal ID_UNIT-ASSAULT's private
current weapon and vitality ledgers. It checks the current public/private vitality mirrors and
revision capacity before mutation. Current health becomes half the current maximum, the maximum
stays unchanged, and current weapon damage halves. Other unit/weapon layouts are separate bindings;
this method is not a general soldier-family eligibility inference.

The host fixture now registers this binding in the existing shared `ArmySpawnCallbacks` dispatcher,
alongside the real deployment start/finish notifications. Four actual generated Assaulters prove
opposing-only modification, unchanged friendly weapon/health authority, retained maximum health,
disconnected-window refusal and observer removal. Sixteen additional checks bring the focused
suite to 116. Deployment lifecycle checks pass 12 and Grenadier damage checks pass 20; the Release
build has zero warnings/errors. Combat/default suites were not rerun after this internal binding.

This is automatic mutation during actual spawn dispatch after explicit test arming/subscription,
not authorized SICKNESS card use. Card-spawned units still need shared source-ordered dispatch,
and the remaining normal weapon/vitality layouts need individual bindings.

A further fixed Park observation did not produce an opposing normal Assaulter shot through tick
3000: all four entities retained idle_1. Inspection confirms InitializeStationaryArmyCombat only
starts Sniper/Minigunner, while Rusher initialization requires an assigned Rusher slot. Normal
Assaulter navigation/volley execution is not connected by this checkpoint. Therefore the new
damage ledger mutation is not claimed as proof of an actual Assaulter projectile or victim hit.
That missing normal PvP path remains required and must be implemented rather than bypassed by
injecting a shot into this fixture.
The later [normal navigation implementation](ASSAULTER_PVP_NAVIGATION.md) now moves ground-spawned
Assaulters to their source Corners. It does not yet connect the normal targeting/volley controller,
so the Assaulter projectile boundary above remains open.

## Host subscription ordering

`ArmySpawnCallbacks` now owns the host's spawn observer list. Successful army-health card use
registers its observer after modifying existing entities; expiration or owner removal unregisters
it. New entities invoke that list instead of sorting the health effects by opaque request ID.
Subscription removal and re-subscription follow C# delegate ordering, including a captured
invocation list when an observer removes another observer during dispatch.

The recovered `CardHealthForSoldiers.ChangeMaxHealth` subscribes after its initial health update.
Its `OnAfterSpawned` multiplies maximum health by 1.2 and refills current health. Therefore health
then Sickness leaves maximum 120/current 60 from 100/100, whereas Sickness then health leaves
120/120. Two calculation tests exercise both orders through the same dispatcher now used by the
host. These composition tests do not claim actual host Sickness activation.

`--combat-only` passes 26,369 assertions, including an actual host Assaulter deployment: the
card heals an existing injured soldier by 20% of its old maximum, replay does not stack it,
and later members of that same wave receive the increased maximum and full refill through
the registered observer. This is native host verification, not a Unity scene or UDP proof.

The current host health-card target predicates remain unchanged. They use family matching;
the recovered soldier-card existing-unit predicate uses `canBeFreezed`, while its future-spawn
callback only checks fraction and `EnemyController` identity. Auditing that distinction against
every host entity classification remains necessary before claiming complete health-card parity.
Sickness weapon bindings must also be initialized before its future observer is registered at
the entity creation dispatch point. This change supplies ordering, not those missing bindings.

## Grenadier secondary weapon binding

`SoldierBehaviourGrennader.ApplyWeaponsSetup` sets the secondary grenade's `damageAmount`
from `grenadeMinDamage` and its separate `explodeDamageAmount` from `grenadeExplodeDamage`.
`GrenadeAmmoSetup.ScaleDamage` would scale both fields, but `ImproveAllWeapons` does not call
that method: it directly assigns each weapon's `AmmoSetup.damageAmount`. Sickness therefore
halves only the grenade minimum. `GrenadeAmmo` copies both fields into the explosion info.

`SicknessSpawnWindow.ApplyGrenadeDamage` preserves the separate explosion field. For minimum
20/explosion 100, the changed fields are 10/100. In the host's existing explosion calculation,
inner damage stays 100, outer minimum becomes 10 and midpoint damage changes from 40 to 32.5;
halving the final composed blast would produce the wrong result. Repeated actual callbacks
halve the current minimum again. Invalid non-finite or inverted damage fields reject.

Card Grenadier now keeps its current secondary damage in a match-owned map initialized from
immutable source stats. Actual grenade launches capture that current record. The host-only
`ApplySicknessToCardGrenadier` binding changes the current setup only while the supplied
window affects this opposing EnemyController. This unit's Walk/Parachute/Corner states pass
`canBeFreezed`. Death removes its current setup. No packet can directly invoke this binding.

`--combat-only` passes 26,374 assertions with the native host binding: an unarmed window refuses,
an armed window halves the current grenade minimum, the actual launched grenade captures it,
a second modification changes future minimum without changing the airborne grenade's captured
damage, disconnect prevents further changes, and death removes the setup. The test starts a
source-backed deployment window explicitly; it does not activate a SICKNESS card through a
network command. The final build also includes the three additional inner/outer/midpoint
calculation assertions in the focused suite; no runtime code changed after the combat run.

This initially supplied only the secondary grenade binding. The current-health and primary-weapon
extensions below also apply. Automatic start/spawn/finish dispatch, authorized card use,
other eligible units, protocol/SDK/Unity presentation and durable terminal proof remain open.

## Rocket weapon and current-health binding

`SoldierBehaviourBazooka.ApplyWeaponsSetup` assigns missile `damageAmount` to one tenth of
the composed soldier damage and `explodeDamageAmount` to the full composed damage. As with
grenades, `ImproveAllWeapons` bypasses the `MissileSetup.ScaleDamage` override. Sickness
therefore halves current contact damage while leaving the separate explosion field intact.
It does not change speed or the behind-shield damage ratio.

`ApplyRocketDamage` copies that exact change and rejects invalid current damage, speed or
shield-ratio authority. Focused tests cover unarmed and friendly exclusions, repeated callbacks,
unchanged source/other fields, non-finite fields, inverted damage and invalid flight setup.

The host-only `ApplySicknessToCardRocket` binding updates the existing match-owned
`cardRocketMissiles` record for BIGROCKET. The source Bazooka EnemyController uses Walk at
spawn and Corner after navigation, both accepted by `canBeFreezed`. Existing launch code reads
the current record and freezes it in `rocketLaunches`; later weapon changes do not rewrite
that captured record. Soldier death removes the current weapon but retains launched authority.

The same binding validates that the public roster and card-unit damage authority agree,
then refills current health to half maximum through `CardUnitCombatLifecycle.RefillHealth`.
It preserves source maximum health and kevlar. Damage and vitality calculations validate before
the first write, and the single-writer host publishes the updated roster and both revisions.
Missing/dead entities or exhausted revisions cannot authorize the binding. Repeated callbacks
refill current health to half maximum again rather than multiplying current health repeatedly.

The final Release build passes with zero warnings/errors. `--sickness-window-only` passes 53
checks and `--combat-only` passes 26,382 assertions. The native Rocket fixture injures the unit
to one-quarter health, applies the binding, verifies unchanged maximum and half-maximum current
health, then applies another authoritative hit from that updated health. It launches an actual
missile with modified contact damage, reapplies Sickness without changing the airborne record,
verifies the half-maximum refill again, disconnects, and removes the soldier while retaining
the launched missile through its terminal impact. The complete default suite was not rerun.

This supplies the Card Rocket weapon/current-health binding only. The test arms a source-backed
window explicitly; no automatic Sickness subscription, authorized network card activation or
Unity presentation is implied. Other eligible unit bindings and the complete automatic
start/spawn/finish lifecycle remain required.

## Grenadier current-health extension

The Grenadier binding now shares `RefillSicknessCardUnit` with the Rocket binding. Both verify
public/current damage-authority vitality mirrors, validate the calculated health before writing,
refill current health to half maximum, preserve maximum health/kevlar, and advance both host
revisions. Missing entities or exhausted revisions cannot authorize a mutation. The grenade's
current minimum still scales separately while its explosion field and airborne records stay intact.

Release build passes with zero warnings/errors. `--sickness-window-only` passes 53 checks;
`--combat-only` passes 26,385 assertions. The Grenadier fixture now injures the unit to one-quarter
health, verifies a half-maximum refill, applies another authoritative hit from that new health,
continues movement and an actual grenade launch, and verifies another refill during repeated
Sickness. The existing Rocket vitality/airborne-authority checks pass through the shared helper.
The complete default suite was not rerun.

The [primary-fire report](GRENADIER_PRIMARY_FIRE.md) records the subsequently implemented
normal/card pistol binding and real/cosmetic launch path. Sickness now changes that current
primary damage together with secondary minimum and vitality. A native primary fixture verifies
modified launch damage, immutable airborne authority, soldier death cleanup and collision;
dedicated victim-damage, animated-pose, UDP and Client presentation proof remain open.
The [native corner muzzle correction](GRENADIER_CORNER_MUZZLES.md) now supplies ten actual
pistol callback poses and the first-shot delay. Normal-controller/warm-state and Client proof
remain separate; the fixed Park fixture still hits terrain and proves no victim damage.
