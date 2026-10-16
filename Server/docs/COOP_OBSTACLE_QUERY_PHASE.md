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
At that checkpoint this verified geometry at observed transforms, without
verifying runtime pose selection. The subsequent selector integration below
extends that boundary.

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

## Host gameplay pose selection

`CoopObstaclePoseCatalog.Gameplay.cs` now separates gameplay sampling from the
existing editor-phase selector. Preparation uses the preceding sampled frame.
The first `OnShot` replacing the queued clone takes one frame before the
ordinary loop advances; subsequent ordinary-loop resets advance during the
same frame's animation evaluation. Both paths ignore a shot on the current
query tick, because the source fires before `OnShot`.

The return Update changes animation state before it changes sampled geometry.
The return tick therefore retains the firing sample; the following tick uses
the first crawl sample. Firing-muzzle availability follows that sampled pose,
rather than the controller's newly enabled animation state.

The gameplay observation fixture now compares the selector's complete body
and head shapes (position, rotation, dimensions and activity) against all 243
actual sampled parts. It also checks firing availability and every exposed
muzzle position. The runtime's obstacle collider candidates and emitted-round
muzzles call these new methods. Historical editor observations retain their
separate selector and exact comparisons.

This closes the isolated neutral-look, fixed-root query-clock comparison.
Initial preparation still comes from the isolated editor setup. Full controller
preparation, moving roots, pooled residual state, nonzero procedural look,
clock synchronization and complete live co-op damage remain unverified.
Obstacle collider candidates continue to be reported as unplaced for live
authority; this change does not register a complete playable co-op mode.

Windows validation: the focused content executable exits zero with 26,368
existing counted assertions plus the new gameplay selector comparisons. Native
smoke builds the solution with zero warnings/errors, passes 1,037 protocol
checks and 74 real MongoDB/HTTP/protobuf/UDP checks, and verifies durable
evidence across Worker restarts. These do not prove full Unity co-op gameplay.

## Preparation inside gameplay Update

The next isolated capture also sets
`WAR_COOP_OBSTACLE_PREPARATION_PHASE=update`. After initialization primes the
fully completed crawl, the first observer Update records relative tick zero
and invokes the actual recovered preparation animation method. Rounds still
run at relative ticks 11 and 22. The raw post observation uses schema six:
its initial editor setup sample is tick minus one, followed by ticks zero
through 80. The paired query observation has 81 samples, starting at zero.

This follows the animation-call phase in recovered `EnemyController.PrepareToShoot`:
the obstacle branch calls `ShootFromCrawl(1f)` during Update, then schedules
the firing callback for `GetStandUpFromCrawlLength(...) + 0.05f`. This probe
does not execute the complete controller, target selection, Photon RPC, root
tween or delayed firing callback. It invokes the same animation method and
uses the already source-backed round schedule; those distinctions remain open.

The completed run reports 82 post frames with no compiler error or runtime
exception. All 243 combat queries match native ray results within 0.00002
world units, and their centers exactly equal the preceding post sample.
Compared with editor preparation, relative query tick two differs by about
0.0034 to 0.0040 world units across the three combat shapes. Every later
shared combat-center sample agrees. The auxiliary colliders still have 32
distance differences outside that tolerance and do not become combat authority.

The host now uses the reviewed gameplay-preparation blend frame by default.
`CoopObstaclePreparationPhase.EditorCallback` preserves the historical isolated
proof explicitly; it is an internal test clock choice, not a Client option.
Startup requires the new post observation, checks its bounded size, raw SHA-256,
schema and source prefab binding before constructing collider lookup state.
Missing or modified preparation proof is tested at the actual loading boundary.

The old and new preparation scenarios compare 486 complete selected combat
shapes and every available firing muzzle, while retaining native host-ray
comparisons. Run just these comparisons with:

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --coop-gameplay-query-only
```

Raw SHA-256 bindings:

| File | SHA-256 |
| --- | --- |
| Gameplay preparation query | `8a1c0a49fd0f6d83faabd0d3a9039384a12e0812817092910cf251b2c419effe` |
| Gameplay preparation post | `46a8d4893f4adc0fc6aca4eb8af2063619dc76e47045192269054369cee71156` |

The first attempt encountered repeated Package Manager exit code 101 and local
server connection failure before observation started. Only that owned Unity
process was stopped. The successful retry used the documented Unity 2018.3
[`-noUpm` option](https://docs.unity3d.com/cn/2018.3/Manual/CommandLineArguments.html)
on the disposable project. It required a full script recompile; no active
Client assets or owner Unity processes were changed. Schema-four and schema-five
captures retain their historical exporter digests; the new schema-six post
capture binds the current exporter source.

This closes the isolated initial-preparation phase discrepancy. Full controller
execution, moving roots, pooled state, procedural look input, normal Unity
match play and complete live co-op damage remain unverified. Collision
authority remains closed for these obstacle candidates.

Validation after this integration: both focused preparation scenarios pass;
the full content executable exits zero with 26,368 counted assertions and the
additional pose/proof checks. Native smoke also exits zero: solution build has
zero warnings/errors, 1,037 protocol checks and 74 live integration checks pass,
including durable evidence replay across Worker restarts.
