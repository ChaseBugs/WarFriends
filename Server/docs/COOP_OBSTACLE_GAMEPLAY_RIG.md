# Gameplay-phase obstacle rig observation

The optional `WAR_COOP_OBSTACLE_WHOLE_RIG=1` mode extends the existing obstacle
volley exporter with all local transforms and enabled mixer states. It also
samples those states through the production script-free sampler on a separate
hierarchy. The source controller keeps normal Update scheduling, preparation
and round notification use the gameplay observer, and source animation remains
automatic. The comparator never samples or changes the source rig.

The reviewed capture is `coop-obstacle-gameplay-rig-reference.json.gz`.
It contains 82 contiguous observations (ticks -1 through 80), 59 transforms,
two round notifications, the strict crawl timer and a completed return.
Procedural look is disabled; optional source rigidbodies are frozen before
Play Mode to prevent detached weapon physics from contaminating comparison.
This is an isolated Unity 2018 Windows fixture, not normal gameplay or Unity
5.2, Linux, Android or rendered-pixel proof.

## Result and remaining requirement

All 82 primed replay samples satisfy the existing limits: position 0.00001,
normalized quaternion dot error 0.000001 and relative local scale 0.00001.
Maximum observed position error is 0.00000249395725 and relative scale error
is 0.00000486780573. Observed rotation error is zero at float precision.

Gameplay observation tick zero has total enabled weight 0.3333333; tick one
has 0.6666667. The production sampler can reproduce this sequence without
normalizing those weights. The SDK still rejects such frames because its
reviewed wire contract currently requires total weight one.

The replay hierarchy is copied after the source is primed at completed crawl.
It is then reused across observations. This does not prove that a newly
created actor in its original prefab pose can accept only the partial-weight
frame, or that skipped intermediate observations reproduce the same result.
Those controls are the next requirement before changing the SDK or publishing
host preparation ticks zero and one. Successful primed replay must not be
reported as stateless or full gameplay parity.

## Reproduce and validate

Use the existing exporter in a disposable project with these environment values:

- `WAR_COOP_OBSTACLE_POSE_PLAN`: absolute path to the pinned source plan.
- `WAR_COOP_OBSTACLE_POSE_OUTPUT`: absolute JSON observation destination.
- `WAR_COOP_OBSTACLE_QUERY_OUTPUT`: separate native query destination.
- `WAR_COOP_OBSTACLE_EMISSION_PHASE=update`.
- `WAR_COOP_OBSTACLE_PREPARATION_PHASE=update`.
- `WAR_COOP_OBSTACLE_WHOLE_RIG=1`.
- `WAR_COOP_OBSTACLE_POSE_LOOK=disabled`.

Invoke `UnityCoopObstacleVolleyPoseExport.Run` in batch Play Mode. Keep the
source prefab bytes unchanged in that disposable project: the initial attempt
found an already reserialized Unity 2018 prefab and correctly failed the
source-plan hash check. Restoring the original prefab in the disposable copy
allowed the final capture to bind the existing source digest. A separate trial
without all required environment values also failed and is not verification.

Validate the committed artifact with:

```powershell
python Server/tools/verify_coop_obstacle_gameplay_rig.py
```

The verifier pins the artifact digest and binds the prefab, controller, clips,
exporter, replay helper, production sampler and plan bytes. It checks complete
ordered observations, finite geometry, the partial-weight boundary and all
reported replay error limits. No source DLL, SDK binary, wire schema, asset,
economy, collider authority or public co-op admission changed in this increment.

## Independent prefab replay control

`UnityCoopObstacleFreshReplayAudit` now constructs a new script-free hierarchy
from the original prefab for each of the 82 captured frames. It attaches the
original weapon hierarchy as the source exporter does, creates a new production
sampler, applies only that frame's enabled states, and destroys the hierarchy.
No preparation, initial crawl sample or previous observation is applied.
Hierarchy path/name/count checks bind all 59 transforms. Root placement is
copied from the host observation separately from animation.

All frames, including both partial-weight observations, pass the unchanged
position/quaternion/relative-scale limits. This resolves the fresh-hierarchy
and missing-intermediate-frame control for this captured fixture. It uses the
same hierarchy copier and sampler as production, without rendered skins,
normal AI, networking or procedural aiming. It is not a normal battle proof.

The new audit reads the pinned compressed capture directly and writes its
reference, prefab, sampler and audit hashes into its result. Validate both
artifacts with `python Server/tools/verify_coop_obstacle_fresh_replay.py`.
The SDK weight gate and host ticks zero/one are still unchanged; they are the
next implementation step, with explicit partial-weight forms and rejection
coverage required before installation into the Client.
