# PvP Rocket Soldier and Mortar flight ownership

Match/Projectiles/PvpArmyMissileSystem now owns the shared Rocket Soldier/Mortar flight set. Each
private value entry pairs a mutable CardRocketMissileFlight with its immutable
CardRocketLaunchAuthority. The engine no longer holds parallel flight and authority dictionaries.
The owner also retains the last executed frame's impact diagnostics. Existing namespaces and
CardRocketLaunchAuthority construction remain compatible.

| Owner or observation | Responsibility |
| --- | --- |
| PvpArmyMissileSystem | Paired membership, sorted capture, completion, projections and impact diagnostics |
| CardRocketLaunchAuthority | Frozen owner, missile damage/player policy and optional Mortar setup |
| PvpArmyMissileStep | Value observation of the captured ID, launch authority and optional impact |
| FlightFrame | Value cursor that advances one captured flight before the engine observes its result |

Entry, cursor and step are value types; no per-flight wrapper object was added. Existing flight and
authority objects, capture arrays and impact records remain. Pairing removes duplicate storage/lookups
and makes an orphaned flight/authority pair unrepresentable through ordinary owner operations.
This structural result is not evidence of a measured CPU, allocation or network speed improvement.

## Retained source and engine boundaries

Missile.Fire/AnimateShot/Update and Mortar.Shoot were inspected. The existing straight flight model,
fifty-unit target cap, negative Mortar progress/overhead origin, stationary stop period, collision
arming, ray length, expiry calculation and validation are unchanged. Ordinary Rocket/Mortar setup,
sickness adjustments, source random draws, shot callbacks, shared ID/capacity/event checks and
indicator creation remain at their existing launch sites. Launch metadata is constructed before
the complete pair is inserted. Soldier removal still preserves an already-airborne missile.

Frames capture ascending IDs at the original engine point. Later launches are excluded. Completion
removes flight and authority together, then appends impact diagnostics, before the engine publishes
the impact event and applies any real explosion. A fake impact retains its flag and metadata but the
owner never applies world damage. Geometry, direct/explosion damage, shields, army/vehicle/barrel/
bonus damage, revenge and terminal publication remain in the engine with their original order.
Exceptions retain their original classification and propagation.

BeginFlightFrame clears diagnostics even when it captures no active flights; the existing engine
gate includes HasImpacts to execute that final cleanup frame. Reconnect/deferred fixed-tick gates
remain unchanged. Terminal cleanup clears active pairs but retains the last impact observations.
The original loop can continue already-captured flights after a terminal callback. If a later one
impacts after its authority was cleared, it records diagnostics and then throws the same missing-
authority InvalidDataException before publishing another world impact. This historical boundary is
preserved explicitly; it is not certified as the final Client terminal policy under V02.

Snapshots remain ID-sorted at their original family position. Kind stays card-rocket/card-rocket-fake
or army-mortar/army-mortar-fake; ArmyUnitId remains empty for Rocket and ID_UNIT-MORTAR for Mortar.
Owner, position, velocity and default fields are unchanged. Protobuf rows and impact arrays are
detached; immutable launch queries expose no stored mutable flight. Shared capacity still counts
each active flight exactly once.

## Before/after proof and small tests

Two original-engine captures before production changes matched ten traces with 10,789 observations.
They cover natural real/fake Rocket and Mortar, each shooter's death, each terminal cleanup, a live
Mortar reconnect pause/resume and BIGROCKET card deployment. Deployment/card commands are replayed.
Full snapshot/reply/event bytes, exact clock bits, frozen missile queries and complete last-frame
impact records are compared. Fake fixtures use a trusted 0.5 accuracy coefficient and constrain random
draws to firing eligibility; the normal shared host retains its prior coefficient of one.
Capture inputs are recorded in pvp-army-missile-baseline-provenance.json as historical provenance.
The capture selector was removed; ordinary execution cannot regenerate expected hashes.

Eight owner/order groups protect paired/duplicate insertion, sorted detached projections, completion
before world observation, captured insertion boundaries, duplicate/skipped ticks, collision exceptions,
fake completion, Mortar stop time, impact lifetime, isolation, terminal-cleared captures and compiled
ownership. The focused case runs in memory with existing content; it needs no MongoDB, Unity Editor,
project copy or Library. From the repository root, after a successful Debug solution build:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-army-missiles --no-build
```

The case also runs in fast/runtime checkpoints. See [TESTING.md](TESTING.md) for final integrated
results. Source/SDK/UDP fixtures do not establish normal Unity/Android gameplay or native physics
fidelity. This ownership checkpoint preserves the pre-existing flight algorithm. The later
[C33 correction](ARMY_MISSILE_EXPIRY.md) separately moves expiry before collision to match source
priority. Its source-anchored regressions pass without changing these ten frozen engine traces.
Other army families and world-impact orchestration remain open under S07.

Final Debug/Release builds pass without warnings/errors. The runtime/native checkpoint
checkpoint-4a067ac89aa8419e851f690e91880b51 passes all 42 stages, including this gate in 7.0 seconds,
267,866 full battle assertions in 641.0 seconds and 74 live native checks in 36.7 seconds. The smoke
reclaimed 210,895,163 bytes after owned shutdown; external retained managed evidence is under one
megabyte. No test host remains active, and historical workspace evidence remains preserved.
