# Recovered burst-LMG source package

`content/recovered-lmg-bindings.json` is a read-only Unity 2018 export of the eight `PlayerBurstWeapon` LMG families. It binds their exact inventory indexes, animation family, muzzle, `BulletSlow` prefab, shot offset, speed/check distance, critical multiplier and faction masks. The dedicated `Google2u.LMG_Minigun` uses `PlayerMinigunWeapon` and is deliberately excluded; its heat-up and motor state require separate authority.

| Family | Inventory index | Stages | Animation family |
|---|---:|---:|---:|
| M249 | 16 | 36 | 15 |
| M249 Elite | 48 | 76 | 15 |
| M60 | 36 | 66 | 15 |
| M60 Elite | 47 | 66 | 15 |
| MG4 | 23 | 56 | 15 |
| PK Machinegun | 15 | 26 | 15 |
| PK Machinegun Elite | 66 | 26 | 15 |
| SA80 | 24 | 46 | 9 |
| **Total** | **8 unique** | **398** | **2** |

The scene serializes burst size 5 and lock 0.3 seconds on each controller. Normal `RifleLevelsSetup` initialization replaces those values from `Google2u.WeaponUpgrades`: burst size 2, cadence 0.22 seconds and burst lock 0.11 seconds. The host preserves both facts and uses the runtime table values. At 30 Hz, the second round occurs seven ticks after the first and then starts the strict greater-than lock gate.

Set `Battle__LmgContentManifestPath` with the base package to enable `unscored-lmg-combat`. The live host owns the two-round continuation after one Client input, animated muzzle, collision, damage, clip/reserve, reload and event emission. Focused tests pass 29 source, timing, rejection and live-match assertions. The Unity/UDP audit switches the recovered inventory to M249, renders its source family-15 cover pose and projects exactly two host rounds and two spent clip rounds. Results stay unscored. Minigun remains the next separate firing implementation.
