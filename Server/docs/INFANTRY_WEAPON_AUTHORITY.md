# Host-owned card infantry weapon visibility

The Worker now publishes source inventory visibility for all six supported infantry cards, and
the portable SDK and Unity presenter consume that state. This connects the previously isolated
card weapon-set builder to the PvP roster presentation path. It does not prove full normal
two-client battle entry, every firing effect or ordinary multi-weapon infantry behavior.

## Wire contract

| Item | Meaning |
| --- | --- |
| Message | BattleArmyEntityState |
| Field | infantry_weapon_mask, protobuf field 46, uint32 |
| Five single-weapon infantry cards | Exactly one: source inventory index zero |
| GREATGRENADIER | One for the basic gun, two for the grenade; never both |
| Ordinary units and HEAVYDRONE | Zero: this projection is not enabled for those entities |
| Authority | Worker state only; no player weapon-switch command exists |

`InfantryWeaponVisibility.IsValid` rejects incompatible card/unit identities and masks before
the SDK publishes an army roster. The presenter checks the same policy for a bound PvP context,
constructs all source-ordered card weapons once and applies later masks without local timers.
Paged roster reads supply the current value on recovery rather than requiring replay of a local
weapon-switch animation. The portable SDK binaries installed in the Client include the field and policy.

## Grenadier source lifecycle

`SoldierBehaviourGrennader.PickTarget` selects the secondary weapon before choosing a target or
checking Corner exposure. A failed target attempt leaves that inventory selection intact; a later
probability draw that does not choose secondary is not a request to restore primary. The host
retains that selection, and shot application reads the current inventory role rather than an
obsolete choice flag. This also corrects the earlier stateless host selection after a retained attempt.

After a secondary shot, `SoldierBehaviour.Shooting` schedules `SwitchWeapon(false)` using the
recovered `Core_BaseScript.InvokeAfter` with a half-second delay. The native coroutine probe at
30 Hz records schedule/callback ticks 1/16, 324/339 and 340/355. The Worker therefore schedules a
fifteen-tick return, preserving separate pending callbacks and clearing them when the actor dies.
Callbacks execute after shooting for the tick, matching the source Update/coroutine ordering.

The native fixture binds executed coroutine/probe/exporter bytes and separately binds inspected
SoldierBehaviour, Grenadier and inventory sources. It observes the coroutine, not the complete
original shooting controller. Original Unity 5.2.5 timing parity remains unverified.

## Verification

```powershell
python -B Server/tools/verify_grenadier_weapon_return.py --check
dotnet run --project Server/tests/War.Battle.Tests -c Release -- --infantry-weapons-only
```

The focused group passes nineteen checks: native evidence identity/timing, protobuf/SDK mask
boundaries, real host deployment and secondary selection, actual grenade launch at tick 203,
retained secondary state through tick 217, primary return at 218, death cancellation and retained
selection across a later non-secondary draw. It does not claim every possible overlapping timer scenario.

The refreshed Unity component audit passes 240 card appearance/weapon checks across twenty-four
actors and both local perspectives, including decoded primary/secondary/primary updates. Existing
56 shield checks, seventeen owner/presenter checks, sixteen-family regression and Gunslinger
weapon/holster checks pass. Native Windows MongoDB/HTTP/protobuf/UDP smoke passes 74 checks with
independent clients and restart coverage; the protocol executable passes 1,360 checks. That smoke
does not specifically drive a live Grenadier weapon switch through two Unity Clients.
The final default Windows Battle executable also passes 247,726 assertions with exit code zero;
live UDP polling makes that total variable across runs. The Release solution builds with zero
warnings/errors. The complete default run includes the retained-selection correction described above.

Deploy the updated Worker and portable SDK together: card rows from an older host omit the new
required card mask and are rejected by the new SDK rather than guessed as a primary weapon.

[Ordinary startup weapon sets](ORDINARY_INFANTRY_WEAPONS.md) now include Commando's simultaneous
weapons. Authoritative ordinary weapon switching, live two-client rendering,
full active Client/Android validation and Linux runtime remain open. See the
[feature checklist](BATTLE_SERVER_FEATURES.md).

## Shared Grenadier selection lifecycle

`GrenadierWeaponState` now owns retained secondary selection and independent return callbacks.
The existing card combat path uses it for target selection, actual shooting, callback advancement
and actor removal. The class deliberately has no card identity check; the owning MatchEngine
adapter still verifies that every due callback belongs to a live GREATGRENADIER actor.
It is ready for ordinary integration, but does not make that integration exist.

The focused group adds five overlapping-callback checks: the first return does not cancel the
second, a later selection survives until the next old callback, and actor removal cancels both
selection and pending authority reads. Due actors are validated before applying the callback batch.

### Ordinary integration sequence

The current ordinary gap is larger than a missing protobuf bit. `InitializeCardGrenadier` requires
`CardUnitEntity` and card base stats. `CardGrenadierChooseTarget`, attack advancement and the walking
pose projection also explicitly require GREATGRENADIER. Removing those guards alone would bypass
owner-bound normal/special/Elite composition and reuse card-only balancing.

1. Compose ordinary grenade damage, shot fields, secondary probability and special fuse from the
   admitted owner's recovered upgrade lanes. `SoldierBehaviourGrennader.ApplyWeaponsSetup` uses
   three seconds without special and `3 - 3 * special` when special is enabled.
2. Connect ordinary spawn, Corner navigation, target acquisition, latched attack and launch through
   those composed values. Keep server RNG and outcomes authoritative.
3. Reuse the shared selection lifecycle without resetting selection on an unsuccessful RNG draw.
   Read the current held role at actual shooting, then run due returns after shooting.
4. Project ordinary Grenadier masks through host, protobuf, SDK and retained presenter weapon sets.
   Keep ordinary non-Grenadier policies explicit instead of treating every unit as two-weapon.
5. Verify normal and Elite real deployments, special fuse, primary/secondary damage, callback/death
   ordering and decoded Unity roster updates before claiming ordinary combat integration.

After extraction, `--infantry-weapons-only` passes 24 checks, `--grenadier-damage-only` passes 23,
and `--grenadier-moving-only` passes 25. The native coroutine fixture verifier also passes.
These targeted runs do not replace a complete default suite or two-Unity-client match proof.

## Ordinary grenade composition boundary

`ArmyDeploymentCatalog.ComposeOrdinaryGrenadier` now composes the ordinary minimum/explosion
fields from validated normal, optional special and optional Elite lanes. It applies the trusted
mode damage scale after addition, matching `ScaleDamageAndHP`. It does not use card interpolation
or its integer truncation. The fuse remains three seconds without a special lane; with special
it uses `3 - 3 * ComposeSpecial(...)`, matching `ApplyWeaponsSetup`.

The focused group now includes seventeen composition checks: nine source-sheet comparisons across
normal indexes 0/39/100 and absent/first/last special with Elite, plus eight invalid scale/lane cases.
The source sheet establishes special indexes 101-126 and Elite beginning at 127. This is validated
composition for subsequent spawn integration, not a claim that ordinary Grenadier combat runs.
Its use in ordinary MatchEngine initialization, attack/navigation, damage and presentation remains open.

Verification: the rebuilt `--infantry-weapons-only` executable passes 41 checks, including the
existing real card lifecycle and new ordinary composition cases. Full-suite and normal Unity match
verification were not rerun for this composition-only increment.
