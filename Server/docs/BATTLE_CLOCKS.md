# Battle clock integration

The active recovered 1.4.0 Client defines distinct time domains. The implementation must keep
them separate while retaining server authority and the existing protobuf identities.

| Domain | Client evidence | Current server boundary |
| --- | --- | --- |
| Raw real time | `WaitForRealSeconds.finished` compares `Time.realtimeSinceStartup` with its stored float deadline. Army spawn intervals use this wait through RadicalRoutine. | Worker now forwards its actual monotonic Stopwatch sample through Router and Endpoint to both runtime types. |
| Scaled game time | EnemyController schedules hide with InvokeAfter; MainGameEntity schedules final return the same way. Core_BaseScript yields WaitForSeconds. | Live ordinary Mortar ownership advances its two body waits on unpaused host frames before spawn admission. Client physical-slot presentation remains pending. |
| Pause-excluding real time | TimeManager.Update adds a real-frame delta clamped to 0-0.2 seconds when timeScale is nonzero and it is not frozen; otherwise its delta is zero. | MatchEngine observes the stored-float accumulator and uses it for deployment deadlines. Auto-deploy remains pending. |

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
claims, fixed combat clocks and reconnect deadlines retain their existing semantics. Army
deployment now consumes raw observations even during reconnect pause; its source cooldown
consumes pause-excluding seconds. The existing countdown wire field projects remaining seconds
relative to the current game tick without changing that tick's domain.

## Required timer consumers

`BattleCooldownClock` now reproduces the source float timestamp subtraction, 0.2-second frame
clamp and float accumulation. Its first observation establishes the allocation baseline. Repeated
Worker catch-up samples contribute zero additional time. Both an existing reconnect pause and
the frame that enters an idle pause update the observation with zero delta, discarding paused
backlog. A resumed frame can add only the interval since that last observation. Nonzero source
timeScale does not multiply this clock. The host validates float representability before publishing
the new raw observation or host tick. Terminal matches do not advance the cooldown accumulator.

This observer is internal and not a wire clock. Live deployment and countdown projection now
consume it; auto-deploy progress still requires migration. This does not close every timer feature.
The focused frame/deployment group passes 118 checks at
`Server/.local/battle-cooldown-clock-tests.log`, including source float rounding, catch-up,
hitches, pause/resume and malformed input rejection before host snapshot mutation.

The separate real-time deployment state now consumes float cooldown seconds and stores
`NextCooldownSeconds = now + (baseCooldown + optionCooldown) * multiplier`, preserving source
float arithmetic rather than rounding authority to ticks. Recovered `canSendUnit` accepts
`progress <= 0`, so an exact deadline is eligible; the strict `>` used for coroutine waits is
a different contract. Rejected attempts leave the accepted deadline and reservations unchanged.
`ProjectNextDeployTick` converts only the remaining duration to a ceiling-rounded relative
game tick for the existing Client parser, which subtracts `State.ServerTick` and divides by 30.
It is a presentation projection, not the authoritative cooldown. A deployment state cannot
switch legacy/real-time scheduling after its first accepted wave, even after completion.
Live MatchEngine deployment and response construction now use these methods. Both players pass
real-time spawn preflight before either commits, preserving the existing energy/entity guard.
Entity setup and callbacks retain their original order in a dedicated partial class. Reconnect
pause can create units and complete final waits at the frozen game tick; terminal grace expiry
is resolved before that paused spawn processing. Corpses, movement and projectiles do not gain
raw-time advancement from this change. Auto-deploy remains a separate pending consumer.
The latest state/frame group passes 126 checks at
`Server/.local/army-cooldown-consumer-tests.log`; Sickness callback/host damage regression passes
265 checks at `Server/.local/army-cooldown-sickness-tests.log`. These focused runs cover the
state consumer, deadline equality, remaining-time projection and schedule-switch rejection,
not live normal-Client acceptance.

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
kernel now has a separate ArmyDeploymentState real-time path. It preserves energy reservations,
shared spawn preflight, entity provenance and actual final-wait completion metadata. Preview
does not commit time or resources. Active legacy and real-time schedules cannot be mixed.
The live MatchEngine now uses this real-time path. The legacy state API remains for explicit
kernel fixtures. The full pipeline run below predates this live consumer migration.

Real-time start/completion events use explicit float timestamps, with legacy tick dates left
unset (zero). A completion copies the original event and adds the actual completion timestamp;
it does not mutate the published start. Sickness rejects premature completion and reopening
with an already completed event, while retaining the recovered persistent definition comparison.
Simultaneously ready waves use deadline/ID order as explicit deterministic host policy; native
evidence does not establish general Unity ordering among multiple concurrent source coroutines.

The latest state/routine/frame group passes 100 checks at
`Server/.local/army-realtime-state-tests.log`. It includes frozen gameplay ticks, delayed frames,
strict final waits, preview/commit equality, rejected malformed or backward samples, preserved
Sickness event order, nonmutating energy-preflight failure and exclusive clock schedules.
The existing Sickness callback/host damage group also passes 265 checks at
`Server/.local/army-realtime-state-sickness.log` with the changed event validation.

1. Live coroutine readiness now uses raw observations with strict float readiness and fresh
   waits. Extend normal two-Unity acceptance to delayed frames and paused multi-unit waves.
2. TimeManager's clamped stored-float accumulator now owns live deployment cooldowns. Migrate
   auto-deploy progress and audit remaining source pause/freeze consumers separately.
3. Advance retained body waits on scaled frames, then process delayed spawn admission in the
   observed source phase order. Native evidence confirms return can free a slot before the
   same frame's end-of-frame continuation consumes it. The host ledger now uses this order;
   Client physical-slot/observer integration remains open.
4. Preserve snapshot timestamps in their documented domain. BattleArmyEntityState already
   publishes the actual simulation tick at actor creation; it does not copy ArmySpawn.Tick.
   Cooldown projection and paused queued spawning are wired; rendered Client parity remains unverified.
5. Wire validated slot capacity, host-owned death-delay draws, corpse return/reclaim and
   observer-local warning history, then publish and validate the required Client state.

These are remaining implementation requirements, not claims that clock migration is complete.

The live consumer change passes 130 frame/state checks at `Server/.local/live-army-clock-tests.log`
and 265 Sickness callback/host damage checks at `Server/.local/live-army-sickness-tests.log`.
The latter checks the actual completion timestamp and original deployment identity, rather than
assuming a precomputed legacy finish tick. Full regression is tracked separately and must not
be inferred from these focused groups.

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
Their new full run passed 263,365 assertions at `Server/.local/battle-realtime-full.log`.
It predates the real-time routine and state integration and cannot validate those later changes.
The later state integration run passed 263,419 assertions with exit code zero at
`Server/.local/army-realtime-state-full.log`. It predates the live scheduling consumer migration.
Subsequent runs at `live-army-clock-full.log` and `client-auto-deploy-full.log` stopped at the
source-fingerprint guard after deliberate concurrent Client edits; neither is a full passing
regression. The reviewed current fingerprint and fresh focused proof are recorded in
[automatic deployment](CLIENT_AUTO_DEPLOY.md).
