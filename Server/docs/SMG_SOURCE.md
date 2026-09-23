# Recovered SMG source package

`content/recovered-smg-bindings.json` is a read-only Unity 2018 export from the recovered 1.4.0 `MainScene`. `SelfHostedSmgExport.Run` binds all eight `Google2u.SMG_*` definitions to their recovered `PlayerBurstWeapon`, `LightMachinegun`, inventory index, muzzle, animation family, projectile prefab, shot offset, bullet speed/check distance, critical multiplier and faction collision masks. The package manifest pins both that export and the complete recovered source-sheet artifact.

| Family | Inventory index | Stages | Animation family |
|---|---:|---:|---:|
| CPW | 18 | 36 | 5 |
| MP5 | 17 | 26 | 0 |
| MP5 elite | 43 | 26 | 0 |
| MP7 | 28 | 56 | 0 |
| P90 | 35 | 66 | 13 |
| P90 Elite | 49 | 66 | 13 |
| UMP45 | 9 | 46 | 0 |
| Vector | 56 | 76 | 13 |
| **Total** | **8 unique** | **398** | **3** |

`SmgCatalog` requires every stage and binding before publication. Each source definition has burst size 3, rate of fire 0.11 seconds, burst lock 0.11 seconds, critical probability 0.03 and the recovered player/overtime damage ratios. Unity serialization supplies a 0.1-second controller first-shot wait and a 0.45-second prefab default lock; `WeaponLevelsSetup.LoadDefinition` replaces the prefab burst and lock with the source definition during normal initialization, so the runtime authority uses the table's 0.11-second lock. The distinction remains recorded rather than silently treating the serialized default as runtime policy.

All eight use `BulletSlow`, speed 30, check distance 0.5, critical multiplier 2, a 0.12 vertical shot offset, and their recovered faction masks. The catalog derives clip, reserve, reload and cadence manifests only from a selected source upgrade stage and rejects missing families and stage overflow.

`SmgBurstScheduler` owns continuation after the first authoritative shot. At 30 Hz the 0.11-second cadence rounds upward to four ticks, producing the second and third shots at exact server ticks. Releasing input cannot cancel those remaining rounds. The third shot starts the source table's strict greater-than lock gate, target updates are finite and server-validated, skipped simulation ticks fail closed, and selection/reload/death explicitly cancels a pending continuation. `SmgCatalog.Prepare` creates bounded `BulletSlow` flights from an authoritative animated muzzle, retains the firing source ID, and applies the recovered critical and player/overtime damage coefficients.

Set `Battle__SmgContentManifestPath` beside the base combat package to enable `unscored-smg-combat`. Startup validates the complete package and adds all eight muzzle nodes to the 142-transform rig. The pose artifact now includes the recovered pistol cover/run family used by CPW as well as the default and QBZ2 families used by the other SMGs. Allocation requires `BattleCombatContent.SmgRevision` and exact catalog-derived weapon stages; altered revision, ammo, cadence, reload, family, muzzle or stage fails before admission.

The live host connects cover first-shot scheduling, authoritative three-round continuation, animated muzzles, collision, damage, ammunition, reload cancellation, event emission and UDP snapshots. A real `NetworkWorker` test sends one Client fire command and observes exactly three host shots and three spent rounds without follow-up commands. Focused source/live tests pass 86 assertions. A live Worker plus Unity 2018 audit switches the recovered inventory from AK-47 to CPW and then P90, renders CPW pistol-family cover poses and P90 QBZ2 running, and projects the authoritative three-round burst and ammunition into the original player objects. A separate two-process Client proof and rendered HUD feedback remain open, so every mode stays explicitly unscored.
