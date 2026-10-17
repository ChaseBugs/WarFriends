# RPG crate collection and source cover geometry

The intermittent `LivePvpBonusUdpTests.RunBazooka` failure came from its firing
position. The fixture selected a randomly placed crate and spent all seven
source RPG rounds from the initial cover. A particular valid City spawn was
hidden behind the original tires collider. The host correctly left it intact.

## Recovered rules and observed failure

`PlayerHoldWeapon.UpdateWeapon` captures `mAimPosition` when holding starts.
After the serialized 0.7-second hold, `Shoot` uses that saved position.
`Bazooka.ComputeFlyTimeToTarget` and the missile setup supply the finite flight.
The reviewed RPG-7 stage zero has seven rounds, a ten-second firing interval,
and a 1.4-unit outer explosion radius.

`KillStreakBonusBox` starts at one HP and can be destroyed while falling.
Its `OnCollisionEnter` marks it grounded on source static geometry. The host's
current falling model remains the previously documented vertical first-contact
approximation; this checkpoint adds no PhysX bounce or rotation behavior.

The failed live run put the grounded crate at
`(-0.86121786, 0.26820022, -1.5879494)`. Its first RPG targeted an older falling
position. All six subsequent accepted holds hit
`(-2.665122, 0.27044466, -0.47691548)`, approximately 2.12 units from the crate.
The static hit was `LevelRoot/CityMap/Barriers/barrier 1 mat/tires`.
No ammo rejection or explosion grant explains away this collision.

## Verification and fixture behavior

`PvpBonusOcclusionTests` fixes that spawn through existing internal engine draw
seams. Eight checks cover settling, accepted targeting, the preserved crate,
the out-of-radius impact, its exact source-static surface, normal adjacent
cover movement, a second accepted hold, and successful collection after moving.
Run it with:

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --pvp-bonus-occlusion-only
```

The production-Worker UDP fixture now waits for the target crate to settle and
uses ordinary authenticated cover commands to approach its lateral position.
It polls until movement finishes before spending a round and requires every
hold to be accepted. Both peers must still observe real host RPG impacts and
the box's removal. Failure output includes hold responses, target positions and
impact events. The three focused UDP reruns passed after this change.
The subsequent complete Battle test executable passed 143,214 assertions,
including the deterministic occlusion regression and live RPG fixture. The
solution build had zero warnings/errors and all 1,144 protocol checks passed.

`UnityPvpRpgOcclusionAudit.Run` independently opens the original City scene,
requiring SHA-256
`acaf878b188dbc17fca6795b5db7e9c7797b91dee0fcb6fb02d5e85d7cc11c4f`.
Its native Unity 2018.3 Physics query hits the same tires path within 0.001 units
of the observed host impact, with the crate outside the original radius.
The tool is in `Server/tools`; copy it into the disposable project's Editor
folder and invoke it with Unity batch mode. This verifies a controlled source
geometry query, not an entire native missile flight or rendered match.

No combat production rule, source asset, SDK or radius changed in this repair.
The randomized UDP run samples some crate locations; it does not establish
reachability from every cover or every spawn, complete Rigidbody parity,
normal two-Unity-client gameplay, Android, or a complete BattleServer release.
