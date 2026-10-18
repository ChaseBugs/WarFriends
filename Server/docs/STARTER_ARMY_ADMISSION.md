# Starter army admission prerequisite

This checkpoint connects the already implemented durable unit presentation to
the mixed-combat manifest. It does not implement automatic account allocations
or prove a normal Unity match.

## Source ordering and authority

Recovered `GameControllerOnline.SubmitSelfHostedCards` echoes the authenticated
`local.Units` list. That list uses ordinal source identity order in
`BattlePlayerPresentationSource`, independently of the full 24-row
`LevelManager.behaviours` array. The manifest must use that same equipped-only
order for identities and all three upgrade lanes.

`BattleArmyManifestProjection` resolves each source sheet through the Worker's
reviewed `ArmyDeploymentCatalog.Families`, then checks its normal and active
optional stages through `ComposeStats`. It builds every field before modifying
the participant. Unknown sources or invalid stages reject without publishing a
partial weapon/army update. Empty presentations remove old lane fields rather
than retaining stale template authority.

The actual initial unit order is Assaulter, Grennader, MachineGunner, Shotgunner,
mapped to ID_UNIT-ASSAULT, ID_UNIT-GRENADIER, ID_UNIT-MACHINEGUNNER and
ID_UNIT-SHOTGUNNER. Their normal stages are zero and optional lanes are -1.
Configured army modifier vectors and new-unit flags reject until a durable
builder can refresh them; this checkpoint does not copy old perks or new-unit
status from a template.

## Grenade package discovery

The original four-weapon starter contains FRAG. Testing that exact presentation
exposed two admission omissions: Backend did not pass its grenade package
configuration to the mixed loader, and mixed validation classified grenade
identities as rifle bindings. Both paths now use the pinned grenade catalog.
Backend and Worker must load the same grenade package and matching mixed
revision. The older local mixed template remains unchanged.

Generate a separate source-validated template with:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --write-starter-template Server/content/local-starter-match-template.json
```

This template is an admission fixture, not a complete starter gameplay preset.
Its weapon placeholders are replaced from durable presentation by the factory.

## Verification and remaining requirements

`--allocator-mixed-only` includes the real initial four weapons and four units,
checks the Worker's complete package validation, configures both participants'
allocation lanes, rejects a changed Client stage and accepts the unchanged
selection echo. Its empty card inventory is an explicit test fixture; it does
not establish the recovered account's initial card hand or card economy.

Mixed grenade gameplay remains incomplete. `MatchEngine` creates
`GrenadeMatchSimulation` only for GrenadeCombatMode; the simulation also requires
that mode and binds each actor to its initial weapon. Mixed mode instead creates
`RifleMatchSimulation`, whose LiveWeaponClass excludes grenade/launcher classes.
Admission and a valid selection echo therefore cannot prove that switching to
the real starter FRAG works. The next implementation must connect mixed weapon
switching, grenade gestures, launch timing, ammunition, source poses, moving
collision targets, snapshots and return to other weapon classes, then verify
the exact starter slot through the host and Client.

Automatic allocation remains absent: queue admission still requires a trusted
`battle_allocations` row. Durable card ownership, Buddy payloads, account revision
consistency, selection limits, modifier projection and normal controller entry
also remain open. Do not seed an empty allocation to bypass these requirements.

At this checkpoint, the Release solution builds with zero warnings/errors.
`--allocator-mixed-only` passes existing eight-slot binding checks and 14 starter
army/host checks. `--initial-loadout-only` passes 54,236 checks.
`--grenade-only` passes 267 checks including grenade-mode UDP and Tank impacts;
those are single-class grenade tests, not mixed grenade gameplay proof.

The [grenade selection prerequisite](GRENADE_WEAPON_SELECTION.md) now fixes
grenade-only slot switching: launch identity, upgrade, gesture pose and active
ammunition follow the selected slot rather than the initial participant weapon.
Mixed-class coordination remains open.
