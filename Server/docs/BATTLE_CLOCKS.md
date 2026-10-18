# Battle clock integration

The active recovered 1.4.0 Client defines distinct time domains. The implementation must keep
them separate while retaining server authority and the existing protobuf identities.

| Domain | Client evidence | Current server boundary |
| --- | --- | --- |
| Raw real time | `WaitForRealSeconds.finished` compares `Time.realtimeSinceStartup` with its stored float deadline. Army spawn intervals use this wait through RadicalRoutine. | Worker now forwards its actual monotonic Stopwatch sample through Router and Endpoint to both runtime types. |
| Scaled game time | EnemyController schedules hide with InvokeAfter; MainGameEntity schedules final return the same way. Core_BaseScript yields WaitForSeconds. | The source-bound corpse clock is tested, but live corpse ownership is not connected to MatchEngine. |
| Pause-excluding real time | TimeManager.Update adds a real-frame delta clamped to 0-0.2 seconds when timeScale is nonzero and it is not frozen; otherwise its delta is zero. | Deployment state accepts a separate cooldown clock. The stored-float TimeManager accumulator is not migrated. |

The source references are under `Clients/ExportedProject/Assets`. Detailed native clock,
coroutine-phase and same-frame pool observations are recorded in
[Mortar integration](MORTAR_INDICATOR.md). These are Unity 2018.3.0f2 observations, not original
Unity 5.2.5, Android or normal two-Unity gameplay acceptance.

## Implemented real-time input

NetworkWorker samples elapsed seconds from one Stopwatch origin before applying its four-tick
catch-up cap. All catch-up ticks from that observation receive the same real-time sample.
The cap still limits simulation work; it no longer prevents the runtime from observing the
actual elapsed duration. No timer has been silently switched to that duration.

MatchRouter carries the sample into existing matches and initial allocation. MatchEndpoint
subtracts its allocation origin from simulation ticks, but does not subtract tick offsets from
real-time seconds. PvP MatchEngine and CoopMatchRuntime retain the sample separately from
their gameplay ticks. Negative, non-finite and backward samples reject before clock/state
publication. Repeated samples are valid during catch-up. A rejected strict combat tick gap
does not consume a future real-time sample.

Existing one-argument Advance calls explicitly use the legacy tick/rate projection. Production
Worker uses the real-time overload. Do not mix those providers after a backlog: the legacy
projection may be behind a previously observed real sample and must not roll it backward.

ObservedRealTimeSeconds is currently server-side runtime state. Protobuf snapshots, admission
claims, gameplay clocks, cooldown responses and reconnect deadlines retain their existing
semantics. Raw observation during reconnect does not mean pending deployment already advances
while paused. The two clocks are now available for that subsequent integration.

## Required timer consumers

The new `ArmyDeploymentRealtimeRoutine` supplies the source coroutine kernel for the first
requirement below. Its first iteration is immediately ready. Later readiness uses a strict
float comparison against a freshly constructed 0.3-second deadline. Preview is non-mutating;
CommitIteration records actual iteration completion and starts the next wait there. A late
callback cannot consume a later wait or emit multiple iterations at the same timestamp.
The final iteration still has a post-spawn wait before CommitFinished. An iteration count is
not proof that an entity spawned or that currency/energy/rewards were applied.

The deployment/frame group now passes 75 checks at
`Server/.local/army-realtime-routine-tests-final.log`, including source hashes for the original
wait, RadicalRoutine and spawning manager, float equality/next-representable-time boundaries,
hitches, actual completion versus preview time, invalid inputs and duplicate commits. This
kernel is not yet wired into ArmyDeploymentState or live MatchEngine scheduling; the legacy
queue remains active. The full real-time pipeline run below predates this newer kernel.

1. Migrate coroutine readiness to raw observations, preserving strict source float readiness
   and beginning each new wait after the actual preceding callback. The existing nominal
   nine-tick queue must not carry a frame hitch into later source waits as precomputed deadlines.
2. Port TimeManager's pause/freeze and clamped stored-float accumulator for cooldown and
   auto-deploy. Resume must discard paused elapsed time rather than applying it as catch-up.
3. Advance retained body waits on scaled frames, then process delayed spawn admission in the
   observed source phase order. Native evidence confirms return can free a slot before the
   same frame's end-of-frame continuation consumes it.
4. Preserve snapshot timestamps in their documented domain. BattleArmyEntityState already
   publishes the actual simulation tick at actor creation; it does not copy ArmySpawn.Tick.
   Cooldown projection and queued spawning during pause still require explicit integration.
5. Wire validated slot capacity, host-owned death-delay draws, corpse return/reclaim and
   observer-local warning history, then publish and validate the required Client state.

These are remaining implementation requirements, not claims that clock migration is complete.

## Verification

The frame/deployment group passes 44 checks at `Server/.local/battle-realtime-tests.log`.
Cases cover shared catch-up observations, independent paused/resumed time, rejected malformed
and backward samples, strict-gap rejection, allocation offsets and registration forwarding.
The co-op regression rejects a backward observation without changing its snapshot, then
accepts another fixed step with the same sample.

The source combat/co-op group passes 26,395 assertions at
`Server/.local/battle-realtime-coop-content.log`. The solution build reports zero warnings and
errors. Protocol tests pass 1,360 checks and native smoke passes 74 real MongoDB/HTTP/protobuf/
UDP checks at `Server/.local/battle-realtime-smoke.log`; isolated run data is
`Server/.local/smoke-83904bb7e06c484085aa404701e38677`.

The earlier clock/pool full run passed 263,399 assertions with exit code zero at
`Server/.local/mortar-clock-and-pool-full.log`. That executable predates the independent
deployment inputs and this real-time pipeline. Do not substitute it for complete verification
of those later changes.
Their new full run is tracked separately at `Server/.local/battle-realtime-full.log` and is
not yet recorded as passing.
