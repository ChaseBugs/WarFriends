# Sickness callback and calculation kernel

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

Release build passes with zero warnings/errors. `--sickness-window-only` passes 34 checks for
arming, friendly/vehicle/immune exclusions, neutral and reversed fractions, replacement and
reused-definition finishes, repeated callbacks, exact vitality/damage calculations, immutable
output, invalid-event/state rejection and ordered spawn subscriptions.
`--army-waves-only` passes its 12 lifecycle checks.
The new kernel test is registered in the default suite; the entire default suite was not rerun.

This does not activate Sickness in a match. Typed protocol and portable SDK methods, authorized
arming/card consumption, source-ordered host callbacks, actual weapon/vitality bindings, Client
UI/presentation, UDP proof and durable terminal consumption remain required. SICKNESS stays on
the incomplete effect list until those paths are implemented and verified.
Host integration must also verify callback ordering with other spawn-time health/weapon modifiers;
this independent kernel does not establish that ordering.

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
