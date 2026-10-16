# Co-op delayed shot callback

Recovered `EnemyController.PrepareToShoot` starts the obstacle preparation
animation and calls `Shoot` with the preparation clip length plus 0.05 seconds.
`Shoot` uses the inherited `Core_BaseScript.InvokeAfter`, which starts
`WaitAndCall`: one `WaitForSeconds` followed by the callback. The callback sets
`mIsShooting`, calls `SoldierBehaviour.ShootJustStarted` and invokes `onShoot`.
Normal `EnemyController.Update` polls `ShootingFromWeapon` separately.

The host now names these two boundaries in `CoopShotCallbackClock`:
`CallbackTick` retains the existing float addition and fixed-tick projection;
`FirstGameplayPollTick` selects the next Update. Reusable validation rejects
non-finite, nonpositive or out-of-catalog clip lengths and checked tick
overflow. This does not equate readiness with a guaranteed shot: weapon cadence,
live target validity and the prepared batch still govern round emission.

## Native observation workflow

Use the disposable rig procedure from
[gameplay preparation](COOP_OBSTACLE_QUERY_PHASE.md). Copy
`UnityCoopDelayedShotProbe.cs` into disposable `Assets/`, and update
`UnityCoopObstacleQueryInstaller.cs` under `Assets/Editor/`. In addition to the
gameplay query and post output variables, set
`WAR_COOP_OBSTACLE_DELAY_OUTPUT` to a separate absolute JSON path. Both
`WAR_COOP_OBSTACLE_EMISSION_PHASE` and
`WAR_COOP_OBSTACLE_PREPARATION_PHASE` must be `update`.

After source-relative preparation tick zero, the observer calls the actual
recovered `InvokeAfter`. It records the callback frame and scaled time, the
latest gameplay tick observed before that callback, and the first subsequent
gameplay poll. It does not implement its own waiting loop or substitute a
test coroutine. The final record must contain a nonnegative `firstReadyTick`;
the intermediate callback-only file is not a completed observation.

This isolates scheduling. It does not run the complete EnemyController, send
Photon RPCs, poll the actual Gun, measure callback-phase muzzle geometry or
prove live co-op damage. The exporter still owns normal round animation resets
and process termination. Preserve those boundaries when interpreting results.

## Reviewed Unity result

The Unity 2018.3.0f2 run completed all 82 post frames without a compiler error
or runtime exception. At capture rate 30 and time scale one, the source
preparation clip plus padding is 0.316666663 seconds. The actual coroutine
resumed at relative tick ten, and the next gameplay poll was tick eleven.
Preparation and callback Unity frames were three and thirteen. Scaled times
were approximately 0.053333335 and 0.3866667 seconds. The active host clock
produces the same callback and first-poll ticks.

The small raw record is `content/coop-delayed-shot-unity-reference.json`;
its SHA-256 is
`a550552508c9d74078708a9220155e7dc42e83effda1f28dcebd07d335b30f7d`.
`CoopShotCallbackClockTests` pins that digest, checks the source clip delay,
actual frame difference and both host boundaries, then rejects invalid clip
lengths and tick overflow. The existing `--coop-gameplay-query-only` command
also runs this test. The complete combat-content command includes it as well.

The paired geometry observation was inspected separately: all 243 combat
queries still agree with same-phase native distances within 0.00002 units,
and their centers exactly match the preceding post frame. It does not become
callback-phase muzzle evidence. No additional duplicate geometry dump is needed
for the timing fixture; the separately committed preparation proof retains
its existing raw hashes and coverage.

The disposable project's recovered sources were byte-equal to the active
Client at observation time. SHA-256 bindings:

| Source | SHA-256 |
| --- | --- |
| Core_BaseScript | `3a42957a1560169dc96af028905d93f0a70aa7d84050d6d5b640b06507f60dce` |
| EnemyController | `175413835772f6c538132930f5c5b3fbe93d147a737a5087d265622acb74aae0` |
| SoldierAnimationController | `f6971fe49c7717a96aedddc4ae41605b1f17da350f49828b1d2329462b9efe8a` |
| UnityCoopDelayedShotProbe | `89a0f9d477c7e773c8350abaec92effcb7df3e32201fe93bfb3351d78dc9fda7` |
| UnityCoopObstacleQueryInstaller | `5f9ed5fd30f2da91b8c124b1264657d28a22b39004ce06447333ba009893655e` |

This proves one isolated obstacle preparation at a fixed rate and time scale.
It does not establish arbitrary Unity process uptime, other preparation clips,
pause/resume, full controller callback behavior or a playable co-op match.

Windows validation after integration: the focused gameplay-query command and
full content executable exit zero, including 26,368 existing counted assertions
plus the observation fixtures. Native smoke builds with zero warnings/errors,
passes 1,037 protocol checks and 74 live MongoDB/HTTP/protobuf/UDP checks, and
verifies evidence persistence across Worker restarts. No full Unity match or
new Linux execution is claimed by these checks.
