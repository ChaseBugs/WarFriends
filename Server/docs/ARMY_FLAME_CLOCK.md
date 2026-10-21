# Army flame source-clock correction (C31)

FlameAmmo.Fire stores TimeManager.realTimeWithoutPauses + 0.35f. Each Update uses a strict `>`
comparison, adds 0.35f to the previous deadline and executes at most one of six checks. The
old ArmyFlameBurst converted one interval to eleven ticks and multiplied it by the pulse ordinal.
That rounds each interval independently and changes the recovered cumulative schedule.

The executable source comparison reproduced this before production edits in
checkpoint-213d8d6c25e74353b732aecae9bd3ad1:

| Pulse | Client body, 30 Hz observations from zero | Previous server |
| --- | --- | --- |
| 1 | 11 | 11 |
| 2 | 22 | 22 |
| 3 | 32 | 33 |
| 4 | 43 | 44 |
| 5 | 53 | 55 |
| 6 | 64 | 66 |

These frame numbers describe that starting clock/input stream. Absolute binary32 time and different
frame observations can change the crossing frames. The fix reproduces the stored float arithmetic;
it does not hardcode this table or claim that every Unity device renders at 30 Hz.

## Ownership and frame order

ArmyFlamePulseClock now owns pulse ordinal, previous pulse time and accumulated float deadline.
ArmyFlameBurst retains identity and delegates its clock; cone/radius/collider/damage formulas remain
unchanged. The clock is a value type stored privately in the burst, avoiding another heap wrapper
per shot. Finite, nonnegative, nondecreasing time and an advancing representable deadline are required.
Equality is not due. A late observation can commit one pulse, preserving the previous deadline;
there is no catch-up loop and no reset to current time plus a rounded interval.

The engine supplies its existing BattleCooldownClock, which reproduces TimeManager's stored-float,
pause-excluding, per-frame-clamped accumulator. Flame checks remain in their original family order,
but now run on source frames even when no fixed combat tick executes. Army bullets and poison
retain their existing fixed-tick gates. Reconnect/terminal early returns still freeze flame effects.
The live muzzle, current source damage, collision query and complete world-effect order remain
engine-owned. Completion and missing-soldier handling retain their original positions. BulletPoison's
coroutine and MainGameEntity's revenge marker use Time.time rather than FlameAmmo's unscaled source
clock; this correction preserves their existing fixed-tick domain.

Source frames can share one simulation tick. Player and bonus-box receipts therefore bind the
committed pulse ordinal as well as projectile/victim identity, replacing tick-only discrimination.
Replaying a committed pulse is inert; the next committed pulse remains distinct in the same tick.
SkillShotControllerPlayer reads TimeManager.realTimeWithoutPauses too, so Flame skill-shot throttling
receives that same source clock. Other damage types retain their existing time input. The internal
bonus-box adapter now takes the committed burst directly; no test-only per-tick compatibility branch
or extra positional pulse argument was introduced.

## Executable evidence and limits

FlameAmmoClockReference compiles copies of the recovered Fire/Update bodies with identifier-only
substitutions for its local fields and geometry/destruction stubs. At runtime, anchored method-body
extraction checks those bodies against the current Client, allowing only those named substitutions
and whitespace. It does not interpret strings as executable code. The reference records callback
times and destruction delay without importing Unity, Photon or a Client project. Inspected Client/
binding hashes are recorded in tests/War.Battle.Tests/Match/Effects/flame-clock-provenance.json.

Ten groups cover the recovered schedule, absolute offsets, exact deadline/next-float boundaries,
late/repeated source frames, common-clock pause/resume, invalid/unrepresentable/reversed time and
burst isolation. Actual engine fixtures also cover naturally deployed player damage over deferred
frames with a fixed combat tick, source time at the skill-shot throttle, live reconnect pause/resume,
and bonus-box pulse/replay identity. The box callback fixture uses a real deployed soldier with
host-controlled damage/pulse setup; it is not proof of natural box targeting or packet authority.

The old geometry suite now asserts cumulative source deadlines instead of eleven ticks per pulse.
Existing bonus-box replay tests use committed source pulses and preserve their original no-repeat
and next-pulse damage assertions. A first new box fixture omitted ordinary PvP bonus policy and a
pause fixture requested an invalid one-second idle policy; their bounded failed reports record
fixture setup errors, not additional server defects. The fixtures now explicitly use ordinary bonus
policy and the valid two-second idle boundary.

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-clock --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-geometry --no-build
```

Both cases need no socket, Mongo instance, Unity project or Library copy. Debug and Release builds
pass without warnings/errors. Release passes all ten groups, the 29 existing geometry assertions
and every prior connection/weapon/movement/player-bullet/bazooka/grenade/army-bullet trace. Full
runtime/native integration is recorded below. Broader S07 state
ownership, poison timing audit, V07 provenance, throughput and normal Unity/Android remain separate.

## Final integrated result

checkpoint-a93bb2b4688d4a72bcea0c959226a3ae passed all 39 runtime/native stages on the final value-clock
code. The ten-group source/host gate passed in 3.5 seconds. The full battle stage reported 267,805
engine/admission/portable-SDK/map/two-peer UDP assertions in 607.9 seconds, including existing live
Flamethrower/Commando, geometry, bonus-box replay and revenge tests. Native
smoke-e91a68772cba46b9ba42424d558a9cb1 passed 74 live Mongo/HTTP/protobuf/UDP checks in 37.9 seconds,
reclaiming 210,868,162 bytes after owned shutdown. No duplicate full combat run was needed.

Four new C# files pass LF/width/whitespace checks; all six inspected Client/binding hashes remain
unchanged. Root .local remains 80,842 bytes and Server/.local 2,624,416,528 bytes/34,638 files. Managed
LOCALAPPDATA storage contains 473,108 bytes/73 files after retention. No managed run or test Backend/
Worker/battle process remains active; original Mongo service PID 6164 is preserved. C31 is complete
at its stated clock/receipt/throttle scope. Flame cone/overlap arithmetic, broader state ownership
and all wider source/gameplay/performance gates retain separate audits; elapsed correctness timings
are not comparative throughput measurements.

The later [C32 interpolation correction](ARMY_FLAME_INTERPOLATION.md) separately fixes the two
Mathf.Lerp clamps. C31's unchanged-geometry statements describe its own clock increment.
