# Helicopter rope alignment

This implements one missing descent calculation from recovered 1.4.0
`EnemyController.GetRopePosition`. It does not enable co-op Fire, simulate a rope,
place a descending soldier's complete collision rig, or authorize landing.

## Recovered behavior

`SpawnFromHelicopter` starts RopeSlide, captures the current root height and the
NavMesh-sampled landing height, and takes the Helicopter's current rope joints.
`HelicopterUpdate` advances a clamped one-second vertical progress. It passes
that vertically interpolated base position to `GetRopePosition`, then changes
the root's facing to the Helicopter's right vector. The order matters: alignment
uses the current root's forward/right, before that later rotation assignment.

`HelicopterRopeAlignment.Align` takes the current root position/rotation, left
palm world position, interpolated base position and ordered joint positions.
It preserves the source float calculation:

- Shift the palm to the proposed base position.
- At or above the first joint, align horizontally with that joint while retaining
  the proposed vertical position.
- Otherwise use the first successive joint pair that crosses the palm height.
  Match Unity's clamped `Vector3.Lerp` and the source forward `0.02` minus right `0.04` offset.
- Below every joint, return the base position unchanged, without the offset.
- A null joint list also returns the base unchanged. Do not replace it with an
  invented vertical rope or fabricated ground contact.

The host rejects empty, non-finite or overflowing geometry and non-unit root
rotations. A 256-joint input budget is an explicit host safety policy; the
original method has no such count limit. Invalid inputs are rejected, never
truncated or repaired into plausible contact positions. The source's empty-list
access can throw; rejection here is not proof that an empty rope implies landing.

## Actual method reference

`tools/UnityHelicopterRopeAlignmentProbe.cs` instantiates the recovered enemy
prefab in an isolated Edit Mode project, assigns each test's root, palm and
joint inputs, then invokes the actual private method through reflection.
It does not reimplement the expected-result formula. Using the original prefab
avoids the animation controller's Reset callback on an incomplete added component.
An earlier fixture did log that Reset exception; it is not the final reference run.

The final probe exits zero under Unity 2018.3.0f2 with **24 cases and zero logged
exceptions**. It covers three root yaws and heights above, exactly on, between,
and below the three joint points, plus null joints. This proves this method's
math against the recovered source compiled in that Editor, not original Unity
5.2.5 physics or a running rope simulation.

- Source controller SHA-256: `175413835772f6c538132930f5c5b3fbe93d147a737a5087d265622acb74aae0`.
- LF reference SHA-256: `33698f7b21d8f24356fd7829d1031ce756e41115f6c97172982d3e4816fb5c32`.
- Reference: `content/recovered-helicopter-rope-alignment-unity-reference.json`.
- Final Unity log: `.local/rope-alignment-unity-final.log`.

To recapture, copy the probe into the disposable project's `Assets/Editor`, set
`WAR_ROPE_ALIGNMENT_OUTPUT` to the reference destination, and launch that project
with `-batchmode -nographics -noUpm -executeMethod UnityHelicopterRopeAlignmentProbe.Run`.
Require terminal exit zero and inspect the completed log for exceptions. The
active and disposable controller hashes matched before capture. Active Client
code, prefab identities and scenes were not modified.

`HelicopterRopeAlignmentTests` pins the normalized-LF reference digest and source
identity, compares every result within 0.00002 world units, checks that alignment
does not mutate shared joints, and rejects invalid geometry/budget inputs.
Its **56 checks pass**, including every captured method result.
The complete Windows combat-content group also exits zero with **26,452** assertions;
its log is `.local/heli-rope-alignment-host.log`. Protocol tests pass.

A self-contained linux-x64 test executable at `.local/linux-rope-alignment` also
executes all 56 checks under Ubuntu 22.04 WSL and exits zero. This is actual Linux
execution, not publication alone. Use `--helicopter-rope-alignment-only` on the test
executable for the focused comparison on either platform. It discovers the reference
above the executable directory, so keep the published runner under the repository tree.

## Descent state and fixed-step progress

`HelicopterDescentState` now composes source progress, vertical interpolation,
rope alignment and subsequent facing. Its constructor captures the starting and
host-sampled landing heights once. Each step receives the current root/palm,
aircraft right vector, scaled frame delta and current rope joints. It computes
all results before committing progress, so malformed joints or pose inputs do
not consume part of the animation. Invalid or near-vertical aircraft facing is
rejected rather than substituting an unverified LookRotation singularity.

The step preserves `mProgress = Clamp01(mProgress + deltaTime)` using floats;
it aligns using the old root rotation and then faces the aircraft's right.
Completion stops further descent steps but grants no landing, enemy-point claim
or mission progress. The actual `OnHeliSpawnFinished` transition is still separate.
The helper is not connected to the live co-op loop without its missing physical inputs.

`HelicopterCrewState.DescentSnapshot` now uses a private precomputed float-addition
table for the host's fixed 30 Hz animation projection. It no longer divides elapsed
ticks directly; the source additions round differently before completion. Lookup
is bounded even for a large elapsed tick gap. This remains a fixed-step projection,
not proof of the original variable-frame client's rope physics or landing time.

Native tests cover old-facing alignment, new-facing output, float accumulation,
all 31 fixed-step samples, completion and seven rejected-frame cases without progress
mutation. A source-bound crew fixture also checks the actual crew projection one
tick before completion. The existing 24 actual Unity alignment references remain unchanged;
these additional descent-state checks are native host tests, not a new capture of the
complete Unity `HelicopterUpdate` lifecycle.

The current solution build passes with zero warnings/errors and protocol tests pass.
The complete Windows combat-content group exits zero with 26,498 assertions;
its log is `.local/helicopter-descent-state-host.log`. The focused alignment/descent
runner also exits zero on Windows and as a self-contained Linux executable at
`.local/linux-descent-state` under Ubuntu WSL, using `--helicopter-rope-alignment-only`.
The Linux focused run does not repeat the full combat-content group or the full
crew-runtime fixture. No new live co-op or Android acceptance is claimed.

## Source slide-palm binding

`UnityHelicopterSlidePoseExport` now samples the actual restored
`EnemyController.mSoldierAnimationController.leftPalm` binding at the start and
end of `helicopter_jump_pose`. The original prefab/clip and their metadata were
copied into the disposable project before capture; input and loaded prefab
SHA-256 both match the existing enemy-pose source:
`64b4db85d1c9a0bd46a690a86102a22f66feeab8d4157a4c87824ac3d5dbeb54`.
The active Client was not modified. The final Edit Mode export under Unity
2018.3.0f2 exits zero with no logged exceptions at
`.local/helicopter-slide-palm-final.log`.

The clip's source duration is `0.0333328247` seconds, with ClampForever wrap.
Its 237 curves do not satisfy the probe's strict constant-value/zero-tangent
criterion. Nearly equal start/end palm positions are therefore not used as proof
that every intermediate or blended pose is constant.

`HelicopterSlidePalmCatalog` pins the artifact's normalized-LF SHA-256
`8a3c1f5d3022c0bd05165e71b443fcf056b9203ba4ead45c7498ae636b716760`,
binds it to `EnemyPoseCatalog`, verifies original unit scale and clip identity,
and exposes only a settled, unblended end-pose frame. It does not interpolate
unknown palm samples or decide when a CrossFade has finished. Runtime scaling
must also be established before that unit-scale frame can be used.

The reference also invokes the actual recovered `GetRopePosition` with that
sampled end pose at a rotated world root. Native tests create the same frame
from the catalog, compose it with `HelicopterDescentState`, and match the recorded
Unity result. They also reject a changed palm-bone identity and invalid root poses.
The Windows combat-content run exits zero with 26,504 assertions at
`.local/helicopter-slide-palm-host.log`; the solution build has zero warnings/errors
and protocol tests pass. This reference is bone/geometry evidence in the stated
Editor, not proof of original Unity 5.2.5 animation/physics equivalence.
The self-contained Linux runner at `.local/linux-slide-palm` also executes the
complete combat-content group under Ubuntu WSL and exits zero with 26,504 assertions.
Its log is `.local/helicopter-slide-palm-linux.log`. This is the focused combat-content
group, not the full Battle test executable, Mongo integration or normal Unity gameplay.

This is a standalone reviewed catalog, not a negotiated live content extension.
Before live use, include its source identity in the signed battle-content package
and establish current blend state, physical rope joints, root update ordering and
landing authority. Co-op Fire and Worker registration remain closed.

## Explicit sampled palm blends

`HelicopterPalmBlendCatalog` composes eleven original local bone transforms after
blending each local position, rotation and scale. It never interpolates the two
world-space hand points. The owned arrays remain private, and frame indexes and
weights must be explicit valid inputs; no animation time rounding or wrapping is inferred.
`CreateSampledFrame` places that palm at a validated unit-scale world root and
returns the same descent-frame type used by the settled-palm path.

`UnityHelicopterPalmBlendExport` captures 31 idle frames, two slide frames and
30 actual `Animation.Sample` comparisons across three idle phases, both slide
samples and five weights. Each comparison includes both root-relative and rotated,
translated world-space palms. Before each sample it resets with the original
`T_pose`; the artifact records that clip's source hash, length, wrap, layer and
blend mode as well as both sampled clips and the original prefab identity.
The source reset hash is `9ca7a5a1ea196960f641b7861eb6dc86a38ffc023502068e357452e48d19e8e6`.
The normalized-LF artifact digest is
`663c3260d0f833716b46e6fd42bc2507f1e97d43f2b2a6234a7f31f02b9e8f8f`.
The final disposable Unity 2018.3.0f2 capture exits zero with no logged exceptions
at `.local/helicopter-palm-blend-provenance.log`. No active Client asset was changed.

The solution builds with zero warnings/errors and protocol tests pass. The Windows
combat-content group exits zero with 26,574 assertions at
`.local/helicopter-palm-blend-host-final.log`. The 30 local/world comparisons have a
maximum position error of `4.7683716E-07`; malformed selections, placement inputs
and private-frame isolation are also checked. Existing native physics/navigation
diagnostics retain their documented differences from Unity.
The self-contained Linux executable at `.local/linux-palm-blend` runs the same
combat-content group under Ubuntu WSL and exits zero with 26,574 assertions at
`.local/helicopter-palm-blend-linux.log`. Its local/world palm maximum error is
also `4.7683716E-07`. This does not cover normal Unity gameplay or Mongo integration.

The comparisons validate explicit captured frames and weights, not automatic
`CrossFade` scheduling, interpolation between frames, procedural animation edits,
runtime scaling, physical rope joints or landing. This catalog is not yet part of
the signed battle-content manifest or the live co-op collision world.

## Remaining integration

The server still needs current rope-joint physics, the current blended left-palm
pose, integration of the root update ordering, NavMesh sampling and the landing
transition. Existing crew progress describes animation time, not those positions.
Likewise `AttachedTransportCrewPoses` reports transformed seat anchors; it does
not prove the actual soldier's root rotation during or after its initial 0.3-second
TweenRotation. The source Driving branch copies the point position, while the
Vehicle gunner branch copies both position and rotation. Do not treat those
branches as the same rigid attachment or promote anchor previews into hit authority.

Keep the full co-op collision world closed while those inputs are missing.
