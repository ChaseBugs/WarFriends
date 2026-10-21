# PvP army flame and poison ownership

Match/Effects/PvpArmyFlameSystem now owns flame burst membership, captured source frames and
completion. PvpArmyPoisonSystem separately owns independent poison coroutines, captured fixed-tick
frames and outstanding pulse reservations. MatchEngine retains source lookup, collision queries,
damage/event/revenge application, shared capacity and terminal decisions.

| Owner or observation | Responsibility |
| --- | --- |
| PvpArmyFlameSystem | Private burst storage, sorted frame capture, preflight/commit/completion lifecycle |
| ArmyFlameSource | Detached identity for live source and geometry preflight |
| ArmyFlamePulse | Detached source identity and committed pulse ordinal for receipts/world effects |
| PvpArmyPoisonSystem | Private coroutine storage, sorted frame capture and pending-pulse sum |
| ArmyPoisonSource | Detached projectile, soldier, attacker and victim identities |
| ArmyPoisonPulse | Detached source, launch damage/position and remaining pulse count |

Frame cursors and observations are value types. No per-pulse wrapper object or callback delegate was
added. Existing burst/effect objects and sorted capture arrays remain. Diagnostic progress queries
return detached arrays, and no stored mutable burst or poison effect escapes its owner. These changes
clarify ownership; they do not establish a measured allocation, calculation or network speed gain.

## Distinct update contracts

FlameAmmo.Fire and Update use pause-excluding source time, six strict accumulated binary32 deadlines
and at most one pulse per source frame. The C31 clock and C32 clamped interpolation are unchanged.
The owner first returns a due source identity without advancing its clock. The engine checks the live
soldier/owner, resolves the current target/muzzle/damage and performs player collision preflight. Only
then does CommitCurrent advance the clock and return its receipt ordinal. Player and world effects
run in the original order; CompleteCurrent removes the sixth pulse afterward. A missing soldier or
owner is discarded before commit, only when due. Terminal cleanup clears flame at its original point.
Deferred source frames can advance flame while the fixed simulation tick stays unchanged.

BulletPoison.OnHit starts an independent DoPoison coroutine for each hit. The existing server model
uses the pinned Commando duration with five pulses at impact plus 0/30/60/90/120 simulation ticks.
TryTakeNext decrements the coroutine before the engine checks its current victim, matching the prior
engine's reservation/observation order. A missing/dead victim releases the effect. Otherwise the engine
publishes impact, applies poison damage and conditionally credits revenge to a still-live source
soldier. Completion removes a finished coroutine only after those effects. Different hits retain
independent deadlines; soldier death does not cancel already-issued poison.

Both frames capture ascending projectile IDs at the same original engine points. Later insertions are
excluded. Each observation must complete or discard before another is taken; terminal effects may
stop the frame before later entries advance. Existing model validation and exception classification
remain unchanged. Flame preflight and poison consumption deliberately have different commit points.

The old server retained poison state when a match ended and stopped advancing it. This extraction
preserves that boundary; it does not certify that retention as the final Client lifecycle policy.
V02 retains that decision and wider coroutine/native-physics fidelity work. Poison's source Time.time
domain is not silently converted into FlameAmmo's realTimeWithoutPauses domain.

## Before/after evidence and focused verification

Two original-engine captures after C31/C32 and before this extraction produced nine identical frozen
traces containing 16,238 observations. They include full snapshot/reply/event bytes, exact clock bits
and detached per-effect progress. Scenarios cover natural flame/poison completion, soldier death,
terminal boundaries, deferred flame frames, stacked poison and live reconnect pause/resume.
Deploy commands are replayed. Historical capture inputs are recorded in
tests/War.Battle.Tests/Match/Effects/pvp-army-effect-baseline-provenance.json. The temporary capture
switch was removed; normal execution compares frozen hashes and cannot rewrite the baseline.

Six flame and six poison owner/order groups cover the distinct commit points, final reservation
lifetime, captured insertion boundaries, dead-source/victim discard, strict/duplicate/skipped clock
rules, detached observations, invalid construction, match isolation and compiled ownership.

From the repository root, after a successful Debug solution build:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-army-effects --no-build
```

The case is also included in fast/runtime checkpoints. It uses existing small content inputs without
copying the Unity project, launching the Editor or creating a Library. Managed lifecycle/retention
rules own reports and temporary files. See [TESTING.md](TESTING.md) for final integrated verification.
These source/SDK/UDP fixtures do not establish normal Unity/Android gameplay, native physics fidelity
or production throughput. S07 remains open for other army families and shared engine orchestration.

Final Debug/Release builds pass without warnings/errors. The runtime/native checkpoint
checkpoint-f3efee39a592439aa6e0a29c7e6ab030 passes all 41 stages, including this gate in 5.5 seconds,
267,855 full battle assertions in 666.0 seconds and 74 native live checks in 37.6 seconds.
The owned smoke reclaimed 210,866,502 bytes after shutdown. External retained evidence is under one
megabyte; historical workspace evidence is preserved. These correctness timings are not benchmarks.
