# Fixed-step obstacle pose catalog

The source experiment now covers every nominal 30 Hz crawl time from zero
through sixteen ticks, followed by thirteen automatic observations per phase:
221 source poses with their complete 59-transform hierarchy. The recovered
crawl length is slightly greater than half a second; fifteen fixed steps are
still below that length, while sixteen are completed/clamped. No fractional
interpolation or extrapolation is introduced by the catalog.

The original obstacle method is invoked on an inactive controller wired only
for this method. The first command follows a manually primed crawl; subsequent
Animation evaluation is automatic. Controller lifecycle, normal AI, emitted
round callbacks and procedural aiming do not execute. These Editor-phase
observations do not prove gameplay-Update callback order or all prior histories.

## Verified content

The first queued-fire observations across prior return ticks 0-16 are:

`2, 2, 2, 2, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 7`.

Clip-only reconstruction fails the existing obstacle limits in eighteen
observations: phases 2-4 at step one and phases 2-16 at step two. Independent
prefab reconstruction with the observed position/scale rows passes all 221
cases, retaining the clip-only failures as negative controls. Reapplying the
same absolute rows preserves the result. Rotations remain sampled normally;
root placement remains separately host-owned.

The reconstruction basis uses the same JSON float representation as the source
artifact before selecting changed channels. Comparing parsed doubles with
in-memory single values directly had counted serialization differences as
additional overrides. Canonical representation removes those false additions
without changing any pose tolerance. The final matrix needs at most twenty-one
position/scale rows, or 504 raw float bytes before identities/transport fields.

Source prefab, controller, builder, probe, sampler and audit hashes are bound
to the artifacts. Source animation clip file digests are checked before and
after observation and validated against the active recovered clip files.
The source capture and independent basis remain separate immutable evidence.

## Generated catalog

`coop-obstacle-fixed-step-pose-catalog.json.gz` contains the ordered non-root
skeleton identities, each source clip frame, and only the observed changed
position/scale rows. Sample IDs are contiguous 1-221 in prior-phase/observation
order; the revision hashes the complete canonical content and provenance.
Transform indexes retain their source hierarchy identity. Generated queue
names and process-local clip instance IDs are never catalog identities.

The catalog is a verified content artifact, not an installed runtime feature.
It is not yet loaded by the Worker, SDK or Unity presenter. The host now preserves nominal prior return and scoped round context before
resetting its clock/history; see [origin capture](COOP_OBSTACLE_PREPARATION_ORIGIN.md).
It still needs complete branch/evaluation validation and a bound catalog
revision/sample identity in the protocol contract. The Client must
validate the entire source binding and override set before applying it and
retain existing lifecycle/replay behavior. No arbitrary client pose array may
become combat or economy authority.

The matrix covers interrupted crawl at these fixed times. Retained begin,
fire restart, repeated interruption, normal callback timing, procedural aim,
all actor styles and two-client gameplay remain separate requirements. The
older clip-only strict gate still intentionally fails, and public co-op combat
admission remains closed. This does not prove shipped Unity 5.2, Linux,
Android or rendered pixels.

## Validation and reproduction

```powershell
python Server/tools/verify_coop_obstacle_fixed_steps.py
python Server/tools/build_coop_obstacle_pose_catalog.py
```

The generator checks reproducibility by default; `--write` regenerates only
the catalog after source/reconstruction verification. Both input captures are
pinned independently. For native capture set `WAR_OBSTACLE_FIXED_STEP_OUTPUT`
and execute `UnityCoopObstacleFixedStepExport.Run`. Compress the JSON into the
reviewed source artifact, then set `WAR_OBSTACLE_MATRIX_REFERENCE` to that
artifact and `WAR_OBSTACLE_MATRIX_OUTPUT` to the replay destination and execute
`UnityCoopObstacleFixedStepReplayAudit.Run` in the disposable Unity 2018 project.
Use the original source prefab; its digest guard rejects reserialized copies.
