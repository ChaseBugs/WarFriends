# Observed obstacle pose preservation candidate

The interruption fixture demonstrates that a current clip tuple is not a
complete description of every automatic transition pose. At observation two,
the zero-return and quarter-return cases expose identical enabled clip states,
clocks and weights but different automatic hierarchies. A catalog keyed only
by current clip/time/weight would collapse these distinct source histories.
The host must preserve prior transition state before resetting its crawl clock.

## Independent reconstruction experiment

`UnityCoopObstaclePoseOverrideAudit` starts a new original-prefab hierarchy and
production animation sampler for each of the twelve terminal calibration
cases. It applies the captured enabled states, measures the existing mismatch,
then applies only source-observed local position/scale rows that differ from
the source's own manual sample. It does not adjust rotations, clip clocks,
weights or root placement. Root placement remains separately host-owned.

All twelve reconstructed hierarchies satisfy the existing obstacle tolerances,
including all six previously failing cases. Applying the same observed rows
again preserves the result. Native error reports are zero at their current
measurement precision; this is not a claim of bit-identical quaternion data.
The six original failures are still present in the uncorrected control.

The observation requires zero through twenty-one transform rows per case.
Each row has six float32 position/scale values, at most 504 raw float bytes.
This excludes path/identity tags, protobuf fields, signatures and other actors.
It is not a measured packet size or a demonstrated transport budget. Current
UDP datagrams are capped at 1,200 bytes, while large replies already have a
separate chunk-transfer mechanism. A bound catalog/sample identity could avoid
sending all transforms, but no such wire extension is implemented here.

## Required implementation before promotion

The test proves that the observed position/scale channels can preserve these
specific automatic poses on independent hierarchies. It does not derive them
for every possible prior phase. The calibration contains six chosen return
fractions and only the first two terminal sample steps. Actual fixed-step crawl
phases, repeated interruptions, retained begin/fire branches, callback ordering,
procedural aiming and every supported actor style still need source evidence.

A usable implementation must bind immutable pose data to the exact source
prefab/skeleton revision and full prior transition identity; validate all rows
before applying any change; retain previous state before a new windup clears
its clock/history; and define replay, missing-catalog and lifecycle behavior.
Pose inputs must remain host-authored presentation and must not create hit,
projectile, score or economy authority. The current Client wire path does not
accept arbitrary transform arrays.

No protobuf schema, SDK binary, active Client script, gameplay mutation or
public co-op admission changed in this experiment. The original clip-only
strict gate intentionally still fails. This candidate requires implementation
and wider source verification before interruption support is complete.

Validate the pinned source controls and reconstruction measurements with:

```powershell
python Server/tools/verify_coop_obstacle_pose_override.py
```

To rerun the native audit, set `WAR_OBSTACLE_OVERRIDE_REFERENCE` to the absolute
compressed controls path and `WAR_OBSTACLE_OVERRIDE_OUTPUT` to a JSON output,
then execute `UnityCoopObstaclePoseOverrideAudit.Run` in the disposable Unity
2018 project with the original source prefab. These are isolated Windows
measurements, not rendered gameplay, Linux, Android or shipped Unity 5.2 proof.

The [fixed-step pose catalog](COOP_OBSTACLE_FIXED_STEP_CATALOG.md) now covers
17 nominal crawl phases and 221 source/reconstruction pairs. Observed channel
preservation passes the full matrix; eighteen clip-only failures remain.
Runtime loading, prior-state retention and validated host/SDK selection are
still required before this content becomes interruption support.
