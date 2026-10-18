# Ordinary Rocket Soldier

Normal `DeployArmy` now binds `ID_UNIT-ROCKETSOLDIER` to the same source Bazooka movement,
Corner attack, missile flight and explosion implementation used by `BIGROCKET`.
The ordinary actor retains an empty `SourceCardId`, its real deployment option, admitted owner,
normal health/shot authority and ordinary kill-energy lifecycle. It never acquires a card identity
or reads a card entity's interpolated upgrade rows.

## Recovered rules

`SoldierBehaviourBazooka.ApplyWeaponsSetup` assigns missile contact damage to composed damage
multiplied by 0.1, explosion damage to full composed damage, and behind-shield reduction to its
ArmyUpgrades policy. Without a selected special upgrade speed is 3. With a selected special
upgrade speed is `(1 + composed SPECIAL) * 3`. Both branches use the same straight source
missile, not the player's separate held Bazooka implementation.

The recovered Bazooka upgrade rules contain 96 normal rows and 16 special rows starting at
index 96. There are no Elite rows. `ComposeOrdinaryRocket` validates those lanes through the
existing owner-bound catalog before building missile fields; a missing Elite lane is rejected.
Mode damage scaling is applied to the composed damage before separating contact/explosion.
Flight accepts positive bounded speed, including these source special speeds; card composition
continues to supply the non-special speed of 3.

Weapon setup exists before the source spawn observer runs. This allows a Sickness callback to
change current contact damage without being overwritten by later initialization. Source
`ImproveAllWeapons` changes only `damageAmount`; explosion damage, special speed and the
behind-shield policy remain unchanged. Current health refills to half maximum; maximum health
and the base explosion-damage ledger remain unchanged. These tests explicitly arm a trusted
window; they do not authorize the still-incomplete SICKNESS card command.

## Shared runtime

The recovered point catalog uses the `BIGROCKET` policy key to select Bazooka points. This is
a point-layout identity, not the ordinary actor's card provenance. Owner-composed movement
speed, initial cooldown, source shot batches, Corner exposure, uncover delay and animated
muzzle feed the existing missile launcher. Ordinary and card shot rows remain separate.

Ordinary death removes missile setup, pending point retry, navigation, attack, latched aim and
point reservation. Already launched missiles keep immutable launch authority and complete
independently. Reconnect projectile rows and events retain the existing `card-rocket` and
`card-rocket-fake` transport kinds, which identify the shared projectile family. They do not
assert that the firing soldier came from a card. No protobuf schema or SDK binary changes are
required for those existing kinds.

## Validation boundary

The focused ordinary Rocket group passes 46 checks, including its Sickness extension. The
complete Sickness group passes 216 checks. Full-suite results are recorded separately below.


`OrdinaryRocketTests` uses actual readiness, selection, normal deployment, navigation and
automatic launches. It checks base `(0, absent)`, middle/special `(39, 96)` with a trusted 1.5
mode scale, and final/special `(95, 111)` selections. It compares launch setup to separately
composed owner damage and special speed, removes the shooter during flight, and observes the
same projectile finish and release its frozen authority. A separate test rejects an Elite row.

`SicknessOrdinaryRocketTests` connects the explicitly armed window to real deployment
start/finish/spawn callbacks for those same selections. It checks source current-health and
contact-only changes, no reapplication after disconnect, and the shared natural launch/death
lifecycle with the changed missile setup.

This is host gameplay evidence. Normal two-Unity-player presentation, Android/Linux runtime,
original Unity 5.2.5 parity, other maps and point categories, special-speed physical damage
outcomes against every victim family, full SICKNESS activation and battle terminal inventory
proof remain open. The existing card Rocket damage tests remain separate regression evidence;
they do not automatically prove every ordinary special-speed collision path.

## Full regression

The complete default test executable passes 247,923 assertions covering battle engine,
admission, portable SDK, map geometry and real two-peer UDP. This run includes existing card
Rocket regressions as well as the new ordinary and Sickness paths. It is not a normal two-Unity
match or Linux/Android runtime proof. Only method naming, comments and line wrapping were
adjusted afterward; the final source is rebuilt and the focused ordinary Rocket group rerun.
