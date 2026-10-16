# Obstacle collider query phase

On 2026-10-17 a disposable Unity 2018.3.0f2 rig recorded native
`Collider.Raycast` calls in `MonoBehaviour.Update` at execution order zero.
The recovered animation controller runs at order minus three. The existing
volley exporter still emits rounds in `EditorApplication.update`; this probe
does not claim to reproduce the source gameplay emission phase.

The observation changes the next implementation step: editor-phase collider
poses cannot stand in for gameplay-query poses. Of 243 matched body/head
centers across 81 frames, 139 differ between Update and the editor callback;
the maximum component difference is 0.055532456 world units. Matching uses
the same absolute Unity frame, source path and collider kind, with both
centers expressed in the enemy root's coordinates.

All 243 body/head native queries agree with analytic box/sphere intersections
at their recorded Update transforms within 0.00002 world units. Maximum
distance error is 0.0000178058. There are no hit/miss disagreements. This is
one forward ray per collider per frame, not exhaustive geometry verification.
The 567 queries including weapon, helmet and aim helpers have 33 distance
differences above that tolerance, with maximum 0.0011374392. Those auxiliary
shapes must not be represented as verified combat hitboxes.

`Physics.autoSyncTransforms` and `Physics.queriesHitTriggers` are both true
in this project. The observer does not call `Physics.SyncTransforms` or change
either setting. The result is specific to this Unity version and project.
The original package's Unity 5.2.5 runtime is not validated by this capture.

## Reproduction

Use the same disposable full project and launch procedure as
[the volley observation](COOP_OBSTACLE_POSES.md). Copy
`UnityCoopObstacleQueryProbe.cs` to `Assets/` and
`UnityCoopObstacleQueryInstaller.cs` to `Assets/Editor/`. A MonoBehaviour in
the Editor folder cannot be attached at runtime. Set
`WAR_COOP_OBSTACLE_QUERY_OUTPUT` to a separate absolute JSON output path and
`WAR_COOP_OBSTACLE_POSE_LOOK=enabled`, retaining the existing plan/output
variables. Run `UnityCoopObstacleVolleyPoseExport.Run`.

The observer attaches after the initial editor callback, so the query record
has 81 frames and the original exporter has 82. The successful run reports
`COOP_OBSTACLE_VOLLEY_POSE_EXPORT_PASSED frames=82`, with no compiler error or
exception. Its post-frame output is byte-identical to the existing neutral
look reference, so that file also serves as the paired post observation.

```powershell
python Server/tools/analyze_coop_query_phase.py `
  Server/content/coop-obstacle-query-unity-reference.json `
  --post-observation Server/content/coop-obstacle-volley-neutral-look-reference.json
```

The query observer writes at most 240 samples. It persists each frame because
the existing exporter owns process termination. The analyzer performs only
offline observation comparisons; it does not authorize gameplay damage.

Reviewed SHA-256 bindings:

| File | SHA-256 |
| --- | --- |
| Query reference | `acea1ed66f7d01369124d9859d75af640ff1a8195fdf74bd72c512e4d719443d` |
| Paired neutral reference | `32f9d91dca9c0e712010327328c901c5add003cb7964a2c62c6b4c885e148738` |
| Query probe | `0e7fc0f571da4bd70e0ee8f98e5d2c8ce1296742bd0322b7a934dc9846f15999` |
| Editor installer | `4b0805780fc35d89c8f501db5481c11c78a9b7b5adf48dfadb8a72269ba40a9d` |

## Remaining implementation

Capture rounds in gameplay Update before `OnShot`, including muzzle and
animation state at that query point. Reconstruct the resulting sampling clock
in the host and compare every body/head pose and firing origin. Moving roots,
nonzero procedural look and pooled state still need their own source proof.
Current runtime obstacle poses remain diagnostic and collision authority stays
closed. Existing timer and editor-phase comparisons remain valid within their
documented scope.

## Gameplay emission capture

The subsequent capture sets `WAR_COOP_OBSTACLE_EMISSION_PHASE=update`.
The runtime observer calls the editor bridge after recording collider queries,
muzzle position and enabled animation states. The bridge invokes the actual
recovered `ShootFromCrawl(0.5f, 1f, Riffle)` at source-relative ticks 11 and 22;
the editor callback suppresses its own round emissions. The initial preparation
still runs in the initializing editor callback. This remains an isolated rig,
not the full `EnemyController` or a complete match.

`coop-gameplay-query-unity-reference.json` uses query schema two and
`coop-gameplay-query-post-reference.json` uses post schema five. The latter
pins the changed exporter digest; previous schema-four artifacts retain their
historical exporter binding from commit `9ab148846` and earlier. They must not
be silently regenerated with the newer exporter and called byte-identical.

The final Unity process reports all 82 post frames and no compiler error or
exception. Its 81 Update frames provide 243 combat queries with no native/host
hit or distance mismatch at the 0.00002 tolerance. All 243 centers are exactly
equal to the preceding post frame, while 136 differ from the same post frame.
The .NET content fixture also verifies every muzzle against the preceding
sample and runs the actual host `PlayerHitbox.Raycast` against native distances.
This verifies geometry at observed transforms; it does not verify that the
current runtime pose selector chooses those transforms.

The first round changes from a queued animation clone to the ordinary loop.
At query tick 12 the ordinary loop is at time zero. At query tick 23, following
the next reset, it is already at approximately 0.0333333 seconds. Therefore a
uniform subtraction from every reset clock does not reproduce this trace.
Likewise, the controller can change enabled state to crawl before Update while
the transforms still hold the preceding animation sample. Reconstruct both
state transitions and transform sampling before opening damage authority.

```powershell
python Server/tools/analyze_coop_query_phase.py `
  Server/content/coop-gameplay-query-unity-reference.json `
  --post-observation Server/content/coop-gameplay-query-post-reference.json
dotnet run --project Server/tests/War.Battle.Tests -- --combat-content-only
```

The gameplay pair's raw SHA-256 bindings are enforced by
`CoopGameplayQueryObservationTests`; the baseline catalog still requires its
original schema-four neutral-look proof. No production authority gate changes
as a result of these observations.
