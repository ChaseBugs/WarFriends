# Recovered rifle upgrade statistics

`RifleStatCatalog` loads eleven `Google2u.AssaultRifle_*` lanes (586 stages) from `content/recovered-battle-content.json`. The caller supplies expected whole-file and MainScene SHA-256 revisions. Duplicate sheets/definitions, missing lanes, changed stage counts, invalid numbers and provenance mismatches fail loading. Stage records are immutable; backing arrays are private.

Recovered `WeaponLevelsSetup<T>.SetUpWeapon` selects one zero-based upgrade row, clears the common definition, then applies `RELOADTIME`, `DAMAGE`, `CLIPSIZE` and `AMMO`. These are complete stage values, not cumulative deltas. `LoadDefinition` supplies cadence and critical probability from `WeaponUpgrades`; the weapon setup supplies normal/overtime player damage ratios. Parsing uses binary32 values to match Client floats. `CreateManifest` projects ammunition/cadence/reload from a validated stage and preserves the exact source identity.

This is a stat catalog, not an ownership check. The allocator must validate the owned upgrade before selecting a row. Other weapon families remain unsupported by this loader. Existing prototype manifests remain operator-authored and unscored.

## Scene weapon bindings

`SelfHostedWeaponExport.Run` exports `recovered-rifle-bindings.json` from MainScene in the disposable Unity project. Set `WAR_WEAPON_OUTPUT` to the absolute output file. It inspects attached `RifleLevelsSetup` components because LevelManager's weapon list is initialized at runtime. It resolves each setup's inventory index against the gameplay player's serialized inventory, records exact hierarchy/asset identities and hashes, and never saves the scene.

All eleven source rifles bind to `PlayerClickWeapon`, `AutomaticRifle` and the same `BulletSlow` prefab. Their definition speed is 30, speed multiplier 1, collision check distance 0.5 and critical multiplier 2. The artifact records each muzzle and world-space shot offset individually. `RifleBindingCatalog` validates supported identities, complete unique inventory bindings, provenance and numerical limits. Its internal projectile preparation uses the definition speed, source shot offset, strict `roll < criticalProbability` rule and normal/overtime player coefficients, binding both catalog revisions. Random rolls and animated muzzle positions are host inputs, never client assertions.

The Worker installs this factory in the opt-in [rifle mode](LIVE_RIFLE_COMBAT.md), using animated/blended muzzle placement and procedural aim for all eleven recovered assault rifles across four animation families. Bindings include each rifle's source animation family and the GlobalStorage faction bullet masks. The `WeaponUpgrades.SPEED` column alone does not prove the speed assigned by `RifleLevelDefinition.SetWeaponparameters`; the scene definition supplies that evidence. Complete friendly-fire policy and overtime phase still require mode integration.

Validation: Unity 2018.3 batch export completed with `WEAPON_EXPORT_PASSED rifles=11`; Battle tests cover initial/final AK47 stats, lane sizes, malformed data, unsupported families/controllers, stage bounds, exact identities, critical probability boundaries and world-space offsets. This export is Editor execution, not a rendered gameplay, Android or Linux runtime proof.

Latest checks: solution build zero warnings/errors; Battle tests 2,107 assertions (UDP polling can vary the total); protocol tests 1,017 assertions. The native Mongo smoke previously passed 44 checks; this binding change does not alter the network protocol or Backend.

`War.Backend.BattleRifleManifestCatalog` independently validates the same content manifest and all 586 rows at Backend startup. During matchmaking it replaces the template participant weapon with the durable first equipped rifle and upgrade stage. A cross-component regression check compares its generated fields with `RifleStatCatalog.CreateManifest`; an unsupported class, out-of-lane upgrade, content digest mismatch, scene mismatch, or template package mismatch fails before Worker provisioning.
