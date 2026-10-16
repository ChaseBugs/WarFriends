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

Moving volleys now publish a presentation estimate combined with the known
tween stage, as described in [infantry facing](COOP_INFANTRY_FACING.md).
Their native rotation conflict remains explicit. The general native moving-root
model and Client synchronization remain required before collision authority.

## Reproduction

1. Set `WAR_COOP_OBSTACLE_TURN_PLAN` to an output path and run the Battle test
   executable with `--combat-content-only` to export the actual fixture state.
2. Copy `UnityCoopObstacleTurnExport.cs` into a disposable full project's
   `Assets/Editor` folder and `UnityCoopObstacleTurnPhaseProbe.cs` into `Assets/`.
   Set the plan environment variable to that input and
   `WAR_COOP_OBSTACLE_TURN_OUTPUT` to a new output path. Set
   `WAR_COOP_OBSTACLE_TURN_PHASE_OUTPUT` to a separate JSON path for phase capture.
3. Run Unity with `-batchmode -projectPath <copy> -executeMethod
   UnityCoopObstacleTurnExport.Run -logFile <log>`, without `-quit`. Require
   exit zero and `COOP_OBSTACLE_TURN_EXPORT_PASSED frames=60`.
4. The combat-content suite pins the complete reference and plan and checks
   frame order, finite unit poses, source clock/speed, target arrival and the
   later native rotation divergence.

## Root composition phase

The next capture adds a runtime observer at Update order minus ten and records
the root again in LateUpdate. The recovered TweenRotation runs ordinary Update
at order zero. The first observer frame occurs after `UITweener.Start` has
already invoked its extra Update; its incoming root is therefore not a pure
navigation-only observation. Later frames retain the external native rotation
before the ordinary tween write. These phase names must not be collapsed into
a claimed reconstruction of native navigation's private algorithm.

The paired capture has 59 before/after phase frames and 60 original post frames.
The six active tween frames overwrite the incoming rotation. Frame six still
writes the target and only then disables the component. On frames seven through
59 the pre-Update root survives unchanged into LateUpdate and the editor post
sample, even as native navigation continues to change it. The first such yaw
is approximately 116.75 degrees, rather than the 123.57-degree firing target.

`CoopShotRootComposition.AfterFrame` now models that ownership handoff. It
advances the source-tested tween, retaining the completion frame's final write,
and preserves its trusted incoming root once the tween is disabled. Invalid
rotation or delta-time input must not consume the one-time Start update.
The stationary runtime publication path now uses the same composition boundary.
Moving windups combine an estimated incoming root with the known tween stage
and retain their explicit navigation conflict. The Worker does not possess a verified
generator for the incoming moving rotation and does not accept one from a
Client packet.

`CoopShotRootCompositionTests` compares every composed rotation and enabled flag
with the actual 59 phase frames and their matching post samples. It checks six
tween writes and 53 later external-root frames, plus rejection atomicity against
the first valid native frame. The focused `--coop-gameplay-query-only` command
and full combat-content command include this fixture. This proves composition
given the captured input; it does not supply the missing native steering model.

The new post schema is version two. Both raw files pin their reviewed digests:

| File | SHA-256 |
| --- | --- |
| Phase reference | `8d7c3201bbfcdd7d55ec316b95b7c42e27caf55de51d734e28429687001a85e7` |
| Paired post reference | `b6f88677bdbb625a63c15d050ea3c5cd589a035f70c3b023a32923e45f5b2edd` |

The post record also pins the phase observer and updated exporter sources.
The earlier schema-one reference retains its historical source digest; do not
overwrite it with newer metadata. The new run uses the same frozen host plan,
recovered mesh and source agent configuration, and reports
`COOP_OBSTACLE_TURN_EXPORT_PASSED frames=60` without compiler error or runtime
exception. Native movement history before the frozen checkpoint, full
EnemyController scheduling, pooled state and normal Unity gameplay remain
unverified. No moving world muzzle or collision authority is opened here.

Windows validation after integration: the focused composition fixture and full
content executable exit zero, including 26,368 existing counted assertions plus
the observation fixtures. Sequential native smoke builds with zero warnings
and errors, passes 1,037 protocol and 74 live MongoDB/HTTP/protobuf/UDP checks,
and verifies persisted evidence across Worker restarts. No new Linux execution
or full Unity match is claimed by these checks.
