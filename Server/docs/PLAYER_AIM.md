# Procedural player aiming

`PlayerAimState` ports the normal-time-scale procedural state in recovered `SoldierAnimationController.LookAt`, `LookAtUpperBody`, `SetUpperBodyRot`, and the rotation portions of `Update`/`LateUpdate`. It is host-only and is not yet attached to the Worker or rig snapshots.

Preserved behavior:

- Look-back defaults true and reverses the full-body direction. Without look-back, `LookAt` uses a fixed half-second deadline even when another duration was supplied.
- Full-body interpolation uses `Quaternion.LookRotation(direction) * inverse(parentRotation)` in that exact order, with clamped `delta * 10` slerp.
- Upper-body signed angle follows `GeometryTools.AngleSigned(direction, parent.forward, up)`. It is limited to ±70 degrees; excess turns the body. The upper timeout is fixed at 0.25 seconds, while the body's excess-turn timeout depends on look-back.
- Upper interpolation uses clamped `delta * 12`. A local X-axis rotation replaces the sampled bone rotation only when the absolute current angle exceeds one degree. The result therefore exposes a nullable override, rather than overwriting animation with identity below the threshold.
- Both deadlines use strict `now > deadline`, resetting the target after the current interpolation. An earlier full-body direction remains present after an upper-body request, matching the recovered code's subsequent recomputation.
- Disabled looking makes no bone write and preserves the aim state. Server application time cannot move backwards, including across input calls.

Inputs are bounded, finite server simulation values. Vertical-only full-body directions are currently rejected because the Unity look-rotation fallback has not been ported; zero direction is invalid. This kernel assumes time scale one and initial body rotation identity. It does not implement source slow-motion/time scaling, clip selection, cross-fades, additive animations, reverse transitions or bone hierarchy application.

`SelfHostedAimExport.Run` writes `recovered-aim-reference.json` using actual Unity `Quaternion.LookRotation`, `Slerp`, `AngleAxis` and recovered `GeometryTools.AngleSigned`. Set `WAR_AIM_OUTPUT` to the output path. Eighteen combinations of parent yaw and horizontal/pitched aim directions verify server body/upper rotations and signed angles. These are math comparisons, not complete Client frame execution. Boundary tests cover expiry ordering, look-back, angle limits, disable behavior and malformed input.

`PlayerPoseCatalog.SampleAimed` now applies body and optional upper-body local rotation overrides to the sampled hierarchy. The artifact includes both animated bone pivots/world rotations and parent rotations. The importer requires stable nested bone identities and positive uniform parent scales. Descendant paths determine which parts move. The child override is composed in the sampled world before the full-body override, producing the same final transform as Unity's parent-then-child writes. A null upper override preserves the sampled animation rotation.

`PlayerAimPose` keeps the transformed collision model and all eleven muzzles together and supports subsequent rigid placement. Gun's world-space shot offset remains separate and is added after placement. Unity export independently applies 20-degree body yaw and minus-35-degree upper-body X rotation to the actual hierarchy at every frame. Tests compare all 964 hit-part and 5,302 muzzle positions and rotations against those Unity results. The exporter restores local rotations and never saves a scene.

Remaining integration includes source clip transitions/blending, matching animation/aim/shot call order, applying `PlayerAimState` output each host tick, and binding this to live Worker firing and Client presentation. The host must not use the test's fixed override angles as a combat stance.
