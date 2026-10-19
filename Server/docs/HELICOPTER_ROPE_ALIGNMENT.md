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

## Native slide transition clock

`UnityHelicopterFadeExport` now observes Play Mode after a fully weighted ordinary
idle alias at phases 0, 0.5 and 29/30, followed by the exact one-argument
`Animation.CrossFade("helicopter_jump_pose")` call used by `RopeSlide`.
It strips gameplay scripts, freezes physics and records sixteen distinct frames
at 30 Hz, including enabled states, raw clocks, weights and diagnostic hand positions.
The canonical `idle` alias resolves to the recorded `idle_1` source clip.

The original APK's `Clients/AuxiliaryFiles/GameAssemblies/UnityEngine.dll` has SHA-256
`e428db4e8652f5d548024ccbbb994dc1636a3c4ad374bac48e18e2fd5db6c76b`.
Reading its method metadata and IL with `System.Reflection.Metadata` shows the
one-string `CrossFade` wrapper (signature `2001010E`) has IL
`160A229A99993E0B0203070628971600062A`: it loads float 0.3 and integer play-mode zero
before forwarding the call. The captured Unity 2018 wrapper agrees on that default;
the different wrapper bytes are recorded in the native artifact.

`HelicopterSlideFade` projects this two-layer, fixed-step starting condition.
Weights accumulate independently as floats, while double-precision elapsed time
matches the exposed raw float clocks, including an idle crossing its loop end.
Slide weight reaches one at tick nine, but outgoing idle still has weight
`4.47034836E-08` and remains enabled. Only tick ten retires idle and resets its raw
clock to zero. `IsSettled` therefore requires the outgoing state to be disabled;
a nominal 0.3-second timer alone must not select the unblended hand catalog.

The reference digest is `0a9f8eae7a74d4d7353af3e411055ab7f73537fa4184e88790553090b9ea161c`.
The final capture exits zero at `.local/helicopter-fade-unity-verified.log` with no
logged exceptions. Component stripping reports dependency-removal diagnostics
before subsequent passes remove all scripts. An earlier export tried to hash
transient Play Mode clip paths; source identities are now captured before entry.
Another attempt wrote observations but crashed during Editor Mono finalization.
The final tool leaves Play Mode before exiting; failed attempts are not clean runs.

The solution builds with zero warnings/errors and protocol tests pass. The Windows
combat-content run exits zero with 26,916 assertions at `.local/helicopter-fade-host.log`.
New checks compare all 48 layer pairs, the settled boundary and invalid initial phases.
They retain the existing physics/navigation diagnostic limitations and do not prove
the complete Unity battle lifecycle.
The self-contained executable at `.local/linux-helicopter-fade` also exits zero
under Ubuntu WSL with the same 26,916 combat-content assertions; its log is
`.local/helicopter-fade-linux.log`. This is not the full Battle executable,
Mongo integration or a normal Unity match acceptance run.

This does not yet place live crew: other weapon idle clips, interrupted/additive
mixers, arbitrary frame deltas, between-frame bone evaluation, procedural edits
and the gameplay/animation update order still require evidence and integration.
The observed Unity 2018 transition does not establish original Unity 5.2 native
animation equivalence, despite the matching managed default. Hand positions in
this temporal artifact are diagnostic; the clock tests do not validate them.

## Rope extension command

`HelicopterRopeExtension.Prepare` implements the position calculation in
`Helicopter.Update`'s `QuickRope2.ExtendRope(0.7f)` call. It prepares movement of
joint one away from the anchor in the direction of joint two, then tests the
strict `distance > initialDistance * 1.5` insertion condition. It inserts at most
one position even when the head is stretched much farther. It does not silently
cap extension at the controller's configured maximum length: that check belongs
to the separate keyboard-controller update, not this explicit Helicopter call.

The spacing argument means the initial **measured** first-joint distance captured
by `QuickRope2.Start`, not the requested spline spacing. The two can differ after
the source spline is sampled. Live initialization still needs that measurement.
The helper validates inputs and intermediate overflow before returning immutable
command geometry; it does not mutate or solve the caller's joint state.

`UnityHelicopterRopeExtensionExport` directly calls the recovered method in Play
Mode on inactive synthetic joints, without an intervening physics solve. Its
eight cases cover ordinary movement, below/exact/above insertion distance,
far stretching, a tilted direction and zero/sub-epsilon direction. The fixture
deliberately injects the prefab's requested 0.35 spacing into `distBetweenJoints`;
it is not a capture of the real rope's initialization. It also records completion
of native anchor reconnection and first-joint dynamic flags. The position-only
host helper does not yet implement those body/constraint operations or insertion rotation.

The recovered prefab hash is `e91c07c1552988601ada89c769056354ebd5d94ea88356eeacc5fa3f3fb76408`;
the artifact includes the current matching QuickRope2 and Helicopter script hashes.
Its normalized-LF SHA-256 is
`28132ffe6c3619d07f2c1156d4efa32f168f336a5e89e3e9a9db80f93f15cc2e`.
The final Unity 2018.3.0f2 capture exits zero with no logged exceptions at
`.local/helicopter-rope-extension-unity-final.log`.

The solution builds with zero warnings/errors and protocol checks pass. The
Windows combat-content group exits zero with 26,948 assertions at
`.local/helicopter-rope-extension-host.log`. New checks compare moved/inserted
positions and insertion presence for all eight native cases, then reject invalid
positions, distances, deltas and overflow. Existing physics/navigation diagnostics
retain their documented differences; this is not full match acceptance.
The self-contained `.local/linux-rope-extension` executable also exits zero under
Ubuntu WSL with 26,948 combat-content assertions at
`.local/helicopter-rope-extension-linux.log`. No Mongo smoke or normal Unity
match acceptance is claimed by these command/geometry checks.

This command evidence is not dynamic rope parity: spline initialization, mass,
damping, gravity, angular constraints, joint insertion/connection, aircraft motion
and update ordering still need integration before supplying live descent joints.

## Initial spline and connection setup

`HelicopterRopeInitialization.Create` now generates the Helicopter prefab's
zero-control-point Catmull-Rom spline with the source's repeatedly accumulated
`0.0001f` sampling step and distance-based point selection. It keeps the original
endpoint positions, derives each initial joint facing and measures the first
joint distance from the generated result. Returned poses and setup records are
immutable and the sequence is owned/read-only. Invalid endpoints, spacing,
degenerate facing and arithmetic overflow fail before a setup is returned.

The ordinary prefab produces four joints and an initial distance around
`0.3500239`, rather than the requested `0.35`. Translation/rotation changes the
last float bits of that measurement. The orientation helper also follows the
observed near-collinear path: near vertical it uses the shortest rotation from
forward +Z, preserving small lateral components, rather than choosing an
arbitrary perpendicular axis. This is confined to rope initialization; it does
not replace other existing aircraft heading rules.
The companion `RunOrientationBoundary` probe bisects native `LookRotation` on
`(x, 1, 0)` down to adjacent float values. The last fallback is float bits
925353387 (`9.999999E-06`); the first matrix path is 925353388 (`1E-05`). Its
small [boundary reference](../content/recovered-helicopter-rope-orientation-boundary-unity-reference.json)
and `.local/helicopter-rope-orientation-boundary.log` record the result; the native
Edit Mode process exits zero. This verifies the cutoff for the captured Unity version.

The setup retains source mass 1, drag 0.2, angular drag 0.05, gravity, dynamic
unfrozen bodies, next-joint connection identity, locked linear axes, limited
angular axes, -60/60 X and 35-degree Y/Z stops, and automatic connected-anchor
configuration. These are connection/body **intent**, not a physical solver.
The aircraft attachment FixedJoint, spring/bounce/break behavior, activation,
automatic anchor realization and subsequent physics still require integration.
Inactive captured connected-anchor coordinates must not be treated as solved frames.

`UnityHelicopterRopeExtensionExport.RunInitialization` delegates to the companion
`UnityHelicopterRopeInitializationCapture` in the disposable Play Mode project.
It calls actual `ApplyRopeSettings` and `Start` on the original inactive prefab
before any physics solve. Nine fixtures cover original, translated/yawed and
tilted roots plus vertical/upward/near-vertical endpoint controls. The controls
deliberately move the instance's endpoint; they are not alternate recovered assets.
It records 36 joint setups, then invokes eight real extension calls per fixture
using the measured distance. Native comparisons cover those 72 composed commands
through the first insertion, not just an isolated extension with an injected spacing.

The source prefab and QuickRope2 hashes match the previous extension reference.
The normalized-LF artifact digest is
`dcd98cbe299229188790412d601a2ebef4ded4e8aa2fc0ab75286bda346563e4`.
The final capture exits zero with no logged exceptions at
`.local/helicopter-rope-initialization-unity-composed.log`. The active Client was
not modified. The initialization/extension subset contributes 541 checks to
`--helicopter-rope-initialization-only`, with position/quaternion comparison
tolerance `0.00001` and measured
distance tolerance `0.000001`. This is Unity 2018.3.0f2 evidence; original Unity
5.2 native physics/animation equivalence and normal match acceptance remain open.
The solution builds with zero warnings/errors and protocol tests pass. The Windows
combat-content run exits zero with 27,489 assertions at
`.local/helicopter-rope-initialization-host.log`, including the 541 new checks.
Existing physics/navigation diagnostics retain their documented deviations.
The self-contained executable at `.local/linux-rope-initialization` also exits
zero under Ubuntu WSL with 27,489 combat-content assertions; the log is
`.local/helicopter-rope-initialization-linux.log`. This is not a full Battle test
run, Mongo integration or normal Unity match acceptance.

This setup is not yet in the signed live content package or wired into a battle
rope solver. The composed command fixture deliberately has no intervening gravity,
constraint or collision solve and cannot establish the moving rope's actual path.

## Remaining integration

The [physical connection boundary](HELICOPTER_ROPE_PHYSICS.md) now covers active
automatic anchors and prepared aircraft/chain rest frames. Earlier inactive zero
connected-anchor values must not be used as effective solved physical frames.

The server still needs current rope-joint physics, the current blended left-palm
pose, integration of the root update ordering, NavMesh sampling and the landing
transition. Existing crew progress describes animation time, not those positions.
Likewise `AttachedTransportCrewPoses` reports transformed seat anchors; it does
not prove the actual soldier's root rotation during or after its initial 0.3-second
TweenRotation. The source Driving branch copies the point position, while the
Vehicle gunner branch copies both position and rotation. Do not treat those
branches as the same rigid attachment or promote anchor previews into hit authority.

Keep the full co-op collision world closed while those inputs are missing.
