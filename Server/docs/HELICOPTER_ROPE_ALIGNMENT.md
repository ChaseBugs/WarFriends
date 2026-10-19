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

## Remaining integration

The server still needs current rope-joint physics, the correctly sampled left
palm/slide pose, root rotation update ordering, NavMesh sampling and the landing
transition. Existing crew progress describes animation time, not those positions.
Likewise `AttachedTransportCrewPoses` reports transformed seat anchors; it does
not prove the actual soldier's root rotation during or after its initial 0.3-second
TweenRotation. The source Driving branch copies the point position, while the
Vehicle gunner branch copies both position and rotation. Do not treat those
branches as the same rigid attachment or promote anchor previews into hit authority.

Keep the full co-op collision world closed while those inputs are missing.
