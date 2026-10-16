# Moving obstacle root rotation

Status: a native Unity counterexample is verified; the general moving root
model and authoritative co-op damage remain incomplete.

## Source behavior

`EnemyController.PrepareToShoot` begins a scaled 0.2-second `TweenRotation`
toward the selected target. Obstacle repositioning has already resumed the
native NavMeshAgent; this branch does not stop it. The source enemy prefab
sets angular speed to 600 degrees per second. Native navigation and the source
tween can therefore both write the same root rotation.

## Captured experiment

`coop-obstacle-turn-source-plan.json` comes from the real moving-shot runtime
fixture, at host tick 383. It retains the source-bound enemy identity, actual
current position, reserved destination, start/target rotations and recovered
Assaulter speed of 0.9. It uses the recovered Desert NavMesh_7.
This is a frozen host checkpoint. Later root-publication changes can export
different starting rotations; refreshing a capture must retain its matching
input and observation together.

`UnityCoopObstacleTurnExport` loads that mesh in a disposable Unity 2018.3
project and configures a native agent from the original prefab's settings.
It runs the recovered `TweenRotation` in normal Play Mode while the agent
travels to the host destination. The output pins the input, exporter, mesh and
tween digests and records 60 fixed-rate frames of position, root rotation,
velocity, desired velocity and tween activity.

The tween reaches its target at relative tick 6. Native navigation subsequently
changes that rotation; the final observed angle differs from the target by
about 59 degrees even after the agent stops. A root rotation frozen at the
prepared firing target is therefore not a general moving-shot pose.

This experiment starts a fresh agent at rest from the host's mid-route state.
It does not reproduce the original agent's complete velocity history, retain
the full EnemyController, or validate moving animation/collision. It proves the
competing rotation writes with a source route and source components; it is not
a complete gameplay parity claim. No active Client asset or script was changed.

## Runtime consequence

Windups now retain `HasNavigationRotationConflict` when preparation begins
during obstacle movement. Such volleys keep source shot scheduling and local
fire-loop muzzle observations, but do not publish a fixed-root world launch
origin, shot-start world muzzle or placed collider candidates. The uncertainty
survives the end of movement because the native final orientation can still
differ from the firing target. Stationary volleys retain their verified path.

The moving-shot runtime fixture verifies that rounds still emit while their
unsupported world origins remain absent. A walking-target second aim stage
also stays unavailable when its required world muzzle is unknown; this is an
explicit remaining integration gap, not a fabricated trajectory.

Next implement and compare the host's live moving root, including navigation
history, tween writes and transform sample phase. Then use that rotation for
world muzzles and colliders before opening collision/damage authority.

## Recovered tween stage

`CoopShotRootTween` now implements the source `UITweener` and `TweenRotation`
stage: float factor accumulation, default EaseInOut, quaternion interpolation
and strict completion only after the factor exceeds one. `UITweener.Start`
calls Update once in addition to the regular Update on the first active frame.
Begin on a reused component resets the factor but does not repeat Start.

The model reproduces all seven recorded frames from initialization through
the final tween write, including the enabled flag. Tests also cover reused
components, paused time and rejected invalid input. This validates the tween
stage, not the native rotation that changes the root after the tween finishes.
No fitted native steering formula has been promoted into gameplay authority.

The co-op runtime now publishes this root rotation for stationary obstacle
volleys. Previously those snapshots retained the spawn rotation even though
diagnostic muzzle placement used the final shot target. A host fixture checks
the first published transition against the source-tested tween. Component
lifecycle is owned per live host entity: it survives successive volleys and
path changes, then ends at death/match cleanup. Original Unity pool-object reuse
and normal Client frame scheduling are not proved by this lifecycle policy.

Moving volleys advance the tween stage without publishing it as the complete
root. Their native rotation conflict remains explicit. The general moving-root
model and Client synchronization remain required before collision authority.

## Reproduction

1. Set `WAR_COOP_OBSTACLE_TURN_PLAN` to an output path and run the Battle test
   executable with `--combat-content-only` to export the actual fixture state.
2. Copy `UnityCoopObstacleTurnExport.cs` into a disposable full project's
   `Assets/Editor` folder. Set the plan environment variable to that input and
   `WAR_COOP_OBSTACLE_TURN_OUTPUT` to a new output path.
3. Run Unity with `-batchmode -projectPath <copy> -executeMethod
   UnityCoopObstacleTurnExport.Run -logFile <log>`, without `-quit`. Require
   exit zero and `COOP_OBSTACLE_TURN_EXPORT_PASSED frames=60`.
4. The combat-content suite pins the complete reference and plan and checks
   frame order, finite unit poses, source clock/speed, target arrival and the
   later native rotation divergence.
