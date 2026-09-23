# Recovered pistol source package

`content/recovered-pistol-bindings.json` is a read-only Unity 2018 export from the recovered 1.4.0 `MainScene`. It binds all six `Google2u.Pistol_*` definitions to their exact inventory indexes, `PlayerClickWeapon`, concrete `Pistol`, pistol animation family, muzzle, `BulletSlow` prefab, shot offset, speed/check distance, critical multiplier and faction collision masks. `pistol-content-manifest.json` pins that scene export and the complete recovered source-sheet artifact.

| Family | Inventory index | Upgrade stages |
|---|---:|---:|
| Berreta | 13 | 36 |
| Desert Eagle | 0 | 66 |
| Jester | 52 | 76 |
| M1911 | 29 | 46 |
| Magnum 357 | 39 | 56 |
| Remmington 51 | 12 | 26 |
| **Total** | **6 unique** | **306** |

Every recovered pistol uses click input without autofire or scope, animation family 5, a 0.1-second serialized first-shot wait, table cadence 0.3 seconds, `BulletSlow` speed 30/check distance 0.5, critical multiplier 2 and the recovered 0.12 vertical shot offset. Damage, clip size and reload time come from the selected zero-based source stage.

`Pistol.ammoLeft` overrides the base property with an `int.MaxValue` getter and an empty setter. The host therefore publishes and preserves exactly `2,147,483,647` reserve rounds while still enforcing the finite source clip and reload duration. Reload fills the clip without decrementing that immutable reserve. Client-provided reserve, clip, damage, cadence or reload values cannot override the catalog.

Set `Battle__PistolContentManifestPath` with the base package to enable `unscored-pistol-combat`. Loading the current rifle, shotgun, SMG, pistol and burst-LMG packages enables `unscored-mixed-combat`, whose revision pins all five packages. The live collision path uses animated pistol muzzles, pistol cover/run poses, host projectile damage and independent per-slot ammunition. Focused tests pass 24 catalog, projectile, firing and infinite-reserve assertions. The live Unity/UDP audit switches AK-47 → CPW → P90 → Desert Eagle and verifies that one pistol click consumes one clip round while retaining `int.MaxValue` reserve in the authoritative snapshot and original recovered inventory presentation. Results remain unscored.
