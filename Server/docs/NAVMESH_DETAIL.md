# Recovered navigation detail tiles

The original co-op NavMeshData assets contain VAND version-16 polygon and detail
arrays, beyond `NavMesh.CalculateTriangulation()` output. Their decoded artifacts
are in `content/coop-navmesh-detail`, with a complete digest/count manifest at
`content/recovered-coop-navmesh-detail.json`. All five maps contain 655 tiles.
These are reconstruction evidence; no replacement Worker sampler is enabled yet.

## Reproduce

Copy `tools/UnityNavMeshTileExport.cs` into the Editor folder of the disposable
`Server/.local/coop-geometry-project`. Set `WAR_NAVMESH_TILE_OUTPUT` to an absolute
output directory. Run Unity 2018.3.0f2 in batch mode with
`-executeMethod UnityNavMeshTileExport.Run`. The exporter guards against running
inside the active Client and only serializes loaded navigation objects. It does
not modify or rebake assets. The verified run exited zero; its log is
`.local/navmesh-serialized-tiles.log`.

From the repository root, with the exported JSON directory:

```powershell
python Server/tools/extract_navmesh_detail.py Server/.local/navmesh-serialized-tiles
python Server/tools/extract_navmesh_detail.py Server/.local/navmesh-serialized-tiles --check
python Server/tools/validate_navmesh_detail.py
```

The extractor checks the pinned packaged-asset digest, then locates every exported
tile payload inside that exact asset. Binary payloads and YAML hexadecimal payloads
are both supported. It rejects unknown tile versions, unbounded counts/vertices,
byte-count mismatch, invalid polygon/detail indexes and duplicate tile identities.
`--check` regenerates the complete expected artifacts and manifest without writing.

## Decoded layout

The observed little-endian v16 header is 72 bytes: magic/version, tile coordinates
and layer, six array counts, six bound floats and a quantization float. Following
arrays have these conserved strides:

| Array | Bytes per row |
| --- | ---: |
| Base vertex: three floats | 12 |
| Polygon: twelve UInt16 and two UInt32 fields | 32 |
| Detail mesh: two UInt32 bases and two UInt16 counts | 12 |
| Detail vertex: three floats | 12 |
| Detail triangle: three UInt16 indexes and flags | 8 |
| Bounding node: six UInt16 bounds and one Int32 field | 16 |

For each polygon, detail triangle indexes address its local base vertices followed
by its detail vertex lane. The extractor conserves every row and records source
offset, encoding, byte count and payload digest. Neighbor, flag and bounding-node
fields are preserved; their runtime query semantics are not inferred from layout.

## Verification boundary

All 275 successful positions in the extended Unity landing capture lie on decoded
detail triangles within 0.0001 world units; maximum observed height error is
0.000004963. Twenty tests reject truncated headers/payloads, unsupported versions
and negative counts, and representative tiles are decoded directly from both
binary and YAML sources again. No new .NET or native physics behavior changed.

This proves the captured heights are represented, not how Unity chooses a polygon
for an arbitrary input. General selection still needs source comparisons against
the original 18 mismatches and all offset/height probes. Build a validated immutable
.NET loader, reproduce polygon lookup and detail interpolation, then connect the
successful/failed query result to native-world arrival and Worker lifetime. Keep
the current mismatches visible until that sampler passes the actual query fixtures.
The capture runtime is Unity 2018.3.0f2, not original Unity 5.2.5 parity.

## Immutable .NET loader

`NavigationDetailCatalog.Load` now loads the pinned manifest and all five map
artifacts, checks the original asset and tile-payload digests, verifies complete
tile/polygon/detail-triangle totals and builds read-only polygon boundaries and
detail triangles. The catalog is returned only after the complete set succeeds.
No decoded geometry collection exposes its mutable construction list or array.

The .NET tests load all 5,693 polygons and 26,081 detail triangles, reject a damaged
artifact before publication, reject collection mutation, and locate all 275 Unity
sample heights on the loaded detail triangles within 0.0001 units. This validates
loading and represented heights, not query-to-polygon selection. The native runner
still reports the eighteen old sampler discrepancies separately. No Worker routing
or deployment packaging is changed by this loader.

## Polygon/detail sampler

`NavigationDetailSampler` projects to the polygon boundary in XZ, tests horizontal
coverage, and interpolates Y from the polygon's detail triangles. Within the bounded
radius, covering polygons take priority; otherwise boundary candidates are compared
by distance. The rule was inferred from captured Unity behavior and then tested on
a separate capture after implementation. It is not presented as Unity source code
or complete equivalence for arbitrary navigation assets.

The implementation passes all 275 successful development queries. The additional
`recovered-helicopter-landing-holdout-unity-reference.json` contains 105 newly chosen
positions, the original 50 map queries and one empty-mesh failure. All 155 successful
queries pass the same 0.002-unit tolerance. The new capture has LF digest
`e43d48abf790fb58756d336ae33b0562492f5e929e5cfbb8412e0eb8df9ca757`;
Unity exited zero at `.local/landing-holdout-unity.log`. Set
`WAR_ROPE_LANDING_HOLDOUT=1` and `WAR_ROPE_LANDING_EXTENDED=0` to reproduce it.

`CoopNavMeshConnectivity.BuildWithDetails` requires each detail map's source digest
to match exactly one stage's original navigation asset. The helicopter landing
method rejects use without that binding. Other conservative corridor/nearest-point
methods retain their existing behavior. Tests exercise the bound co-op entry point
and reject the previous approximate fallback. Worker construction and arrival do
not yet use this builder. PvP detail-map extraction, additional near-edge/stacked
surface/radius-boundary source probes, and normal crew landing acceptance remain open.

## Co-op arrival integration

`CoopMatchRuntime.BindTransportLandingNavigation` now accepts validated detail
navigation exactly once before participant admission. On the actual first stop
callback, it records the surface result, tick and query points. The source rope
origin uses the aircraft pose before this render's flight/orientation writes,
matching `ShowRope` inside `Steer`. The player plane comes from the source master's
current selected point, including a locked route destination rather than the
player's intermediate walking position. The source rope definition binds the actual
QuickRope root offset and prefab identity.

The decision is not replaced by later frames and is removed on transport death.
Tests run mission 46's transport through real runtime admission, flight and arrival;
the expected origin is calculated independently from the prior snapshot. They
require a real sampled surface, reject rebinding and verify decision retention and
death cleanup. Movement-time cover selection still needs a dedicated runtime case.
No binding means no landing decision; the old triangle sampler is never selected.

The normal Worker currently does not create this co-op runtime because the complete
collision/combat world is still closed. This integration does not open that gate,
instantiate native ropes, settle combat or land crew. A later runtime factory must
bind the verified navigation before admission and own native world cleanup before
normal UDP co-op is enabled.

### Correct rope origin identity

The initial runtime integration incorrectly used the crew's `ropePosition` marker
Transform 480871 (`y = -0.1304485777` relative to the aircraft). Source `ShowRope`
instead reads the QuickRope component's own Transform 436455 (`y = 0.331`). The
current code corrects that reference through `HelicopterRopeDefinition`, loaded
with the combat content. Crew alignment still uses its distinct marker.

`tools/extract_helicopter_rope.py --check` verifies the definition against the
unchanged original prefab. The artifact pins component 11471338, root 436455,
end 446016, spacing 0.35 and creation rest rotation. Its LF digest is
`8b1e4872243ad6aa489227fd080f5cfb73bf40145245d7caeb4f2d95fd9697ec`.
Tests compare generated joints and attachment rest rotation with all three existing
Unity initial physics captures, independent of the earlier crew-marker extraction.

`Helicopter.OnInstancied` activates the rope through `InvokeAfterRealTime(..., 2f)`.
That callback and QuickRope `OnEnable` must own initial world pose and physical
birth time in the next integration stage. The new definition is not permission to
create a rope at spawn or reset the match's existing physics clock.

## Realtime rope activation

`HelicopterRopeActivationState` now performs actual `NativeHelicopterPhysicsWorld.Add`
after the recovered wait. Evidence is `Core_BaseScript.InvokeAfterRealTime`,
`WaitForRealSeconds.finished` and `RadicalRoutine.Execute`: the float deadline is
strictly exceeded, and the callback resumes through `WaitForEndOfFrame`.
Activation must therefore be called after that frame's world render, with the
current aircraft pose. The state does not advance or reset the world's clock.

Native tests verify no allocation at exactly two seconds, allocation at the next
representable float on a zero-scaled-delta frame, initial pose from current aircraft,
preserved clock debt, and no physical/render work on the newborn until the next
frame. They also verify duplicate callback suppression, cancellation before due,
invalid realtime rejection and removed-identity reuse without an old callback
touching the replacement. The activated lease belongs to the match world; calling
`CancelPending` after activation is rejected because removal must go through that
lease owner. Allocation failure closes the activation state instead of retrying.

This is native scheduling acceptance driven by source code, not a new Unity
coroutine timing capture. The later native ownership checkpoint below adds pending
state ownership, explicit normal render calls, removal and termination cleanup.
General runtime frame timing and the normal Worker gate remain open work.

## Native ownership in the mission runtime

`CoopMatchRuntime.EnableTransportRopes` now installs a `CoopTransportRopeWorld`
only after landing navigation and prefab definition are bound, before admission.
The native ABI must be present; no alternative solver is selected. Generic
`Advance` rejects catch-up and advancing past a frame whose rope render has not
completed. The driver calls `RenderTransportRopes` after each new normal host tick.
The tested contract is 30 Hz; unchanged-tick pause renders and source hitch replay
still need a complete runtime frame driver and source comparisons.

The owner synchronizes the live transport roster, stamps delayed activation from
the actual spawn observation, applies sampled or failed arrival exactly once, and
allocates due ropes after rendering. Aircraft death removes active scenes or
cancels pending states immediately. Terminal mission paths and `Dispose` release
the world and pending callbacks. A failed native frame or explicit disposal uses
the existing `host-shutdown` abort path, preserving the terminal validator's known
reason contract rather than inventing a new settlement reason.
Arrival before rope activation remains explicitly rejected pending source proof;
it is not silently deferred into a different source callback order.

For native end-to-end verification, set `WAR_TEST_NATIVE_TRANSPORT_ROPES=1` and run
`--combat-content-only` with the same PhysX/native loader paths as the native runner.
The mission-46 fixture uses real runtime admission, spawning, per-frame flight,
activation, arrival and gunner timing. It checks the strict activation boundary,
current native roster after death and idempotent disposal, then allocates all 64
native slots before the old runtime leaves scope. This is a host lifecycle test,
not rendered Unity play, complete collision authority or normal UDP Worker admission.

Source `QuickRope2.OnEnable` reconstructs joints, while the prefab/pool can have an
earlier enable before `OnInstancied` disables the rope. A full source pooling/activation
capture is still required to audit that pre-activation joint state; this runtime
checkpoint does not establish parity for that interval or all possible short routes.

## Crew drop query and input binding

`EnemyController.SpawnFromHelicopter` differs from `Helicopter.ShowRope`: it calls
SamplePosition at the crew's `ropePosition` marker, radius ten/mask one, without
a player-height projection. `SampleHelicopterCrewLanding` now implements that
separate direct query over the bound detail sampler. A captured Unity direct query
verifies the entry point independently of the body-rope target path.

At actual regular-crew drop ticks, the native-enabled runtime records slot/tick,
the host's current attached-source soldier and aircraft poses, marker, nullable
surface, active native lease and physical sequence. The records are read-only and
do not get recomputed after the frame. They are cleared on transport removal or
runtime termination. They do not instantiate an independent soldier, award spawn
credit, or expose a damage target. A missing surface is retained as missing; no
zero-height fallback is selected.

The mission fixture extends through the first regular crew wave rather than
checking a zero drop mask before the five-second wait ends. Two captured slots
match their source schedule, initial marker/root placement and current rope lease.
The direct surface and physics-sequence checks pass before aircraft death, and
death/disposal removes the records along with the native scenes.

Remaining: verify actual source Driving/Spawning script and coroutine phase order,
recover each soldier's current animation mixer/palm before descent, consume fresh
rope poses each frame, and transfer completed units into independent navigation
and collision ownership. In particular, the attached-source placement recorded
here is not proof of the precise animated EnemyController root at coroutine resume.
Animation progress reaching one alone cannot authorize landing or a combat entity.

## Disabled animation and slide mixer clock

`SwitchStateToHelicopter` calls Idle and begins the rotation tween. RopeSlide later
calls the one-argument CrossFade. `SoldierAnimationController.Reset` enables
renderer-based culling, and CheckIfInScreen can disable the Animation component.
ForceInScreen is a separate path; it is not called by the recovered helicopter
Driving/Spawning transition itself. Consequently, spawn age alone is insufficient
evidence of the current sampled idle/slide state.

The disposable fade exporter now supports `WAR_HELICOPTER_FADE_VISIBILITY=1`:
after recording sample two it disables the component, then enables it after sample
six. It retains AlwaysAnimate culling to isolate the component-enabled effect.
The reference has sixteen observations for three initial idle phases and LF digest
`4659dcd8e160092abfd4aec09a9d4e7ab3e72327329dc44eb10eaa718b8209c2`.
The first attempt saved its capture but crashed during Play Mode asset unloading;
that provisional run is not the acceptance evidence. Clearing exporter static
references after writing allowed the subsequent run to exit zero. The accepted
log is `.local/helicopter-fade-visibility-unity.log`; the failed log is retained
locally as `.local/helicopter-fade-visibility-first.log`.

Samples three through six preserve clocks, weights and local sampled palm. On
sample seven, clocks and weights catch up over the hidden interval in one update.
Subsequent enabled frames use their normal fixed delta. This grouping changes
float residuals: idle disables at sample nine in the resumed capture while the
continuous control retains a tiny positive weight for one more sample. The model
preserves that difference without a generic small-weight cutoff.

`HelicopterSlideMixerState` now reproduces those clocks/flags for both captures
at speed one and 30 Hz, with the existing 0.0000002 clock/weight tolerance. It
does not choose visibility, infer an initial phase, evaluate skeleton bones or
change the runtime's crew collision gate. Disabled local bone sampling in this
stripped rig is not proof that procedural source-controller bone updates also
freeze. Renderer-based culling, initially disabled transitions, arbitrary speeds/
frame timing and full Driving-to-Spawning phase order still require separate proof.

## Source descent with live animated palm observations

`UnityHelicopterDescentObservation` extends the disposable fade exporter when
`WAR_HELICOPTER_FADE_DESCENT=1`. Three stripped animated rigs retain their original
clip playback. Separate inactive owners contain the original `EnemyController`,
`SoldierAnimationController`, `EnemyPointHelicopter` and `Helicopter` types. Their
global lifecycle does not run. Reflection calls the original private
`HelicopterUpdate`, with an explicit Spawning phase, start/end heights and four
supplied joint transforms. No replacement descent formula runs in the exporter.

The capture records sixteen samples per scenario, including fifteen updates.
Each update consumes the previous output root pose and the currently sampled
world palm. Output rotation follows alignment, including a tilted aircraft right
vector. Disabling animation for samples three through six does not pause source
descent; bones retain their local sample while their world position follows the
moving root. The fixture stops before completion callbacks to avoid inventing
navigation, point selection or singleton state.

The first attempt produced a provisional file but exited abnormally and had no
accepted log. That file is retained locally as
`.local/helicopter-descent-provisional.json`. Explicit destruction of the inactive
owners/aircraft/joints before exiting Play Mode and clearing static references
allowed a subsequent zero-exit run. Its accepted log is
`.local/helicopter-descent-unity-final.log`. The committed LF reference digest is
`5b34f17ec3bb4c85ccbd785e6957473a6d25bbfc0d5a0af991b34a6cd90dd0ca`.
The active and disposable EnemyController sources have the same SHA-256:
`175413835772f6c538132930f5c5b3fbe93d147a737a5087d265622acb74aae0`.

`HelicopterDescentReferenceTests` replays all 45 updates, checks exact float
progress and previous-output continuity, and compares position and sign-invariant
quaternion component distance at 0.00001 tolerance. This establishes the supplied
input calculation under Unity 2018.3, not original Unity 5.2 parity, native rope
motion fidelity or the real Driving-to-Spawning callback order. Normal runtime
registration, inferred animation phase, complete descent/landing and independent
combat entity ownership remain open.

## Descent replay using moving native joints

The explicit test command `--export-native-crew-descent <output>` exports sixteen
actual `NativeHelicopterPhysicsWorld` publications. It uses the source-bound rope
definition at aircraft height ten, begins floor extension toward zero, and moves
the aircraft by translation and yaw at 30 Hz. It captures joint positions in
native/source order, render counters, physics counters and aircraft right.
The committed LF input trace digest is
`5f745b12d48f8ad51c976d34eaa84502f9a35fbd57987735e94cafb8582e4bf8`.

With `WAR_HELICOPTER_DESCENT_NATIVE_INPUT` pointing to this trace, the disposable
Unity helper replaces its supplied joints before each call to the original
`HelicopterUpdate`. It grows/shrinks the joint list as the actual exported rope
requires and updates aircraft facing. The source rig still evaluates its real
idle-to-slide animation, including disabled/resumed component observations.
The accepted Unity process exits zero; log:
`.local/helicopter-descent-moving-unity.log`. The reference LF digest is
`00dc26188444aecb20ebd825cec934fe7a374edf90a5c0c88f1695f77f330aed`.

The native comparison now replays both stationary and moving-joint references:
90 source descent updates across six rig/phase scenarios. Besides position,
rotation and exact progress, it checks that every captured scenario consumed
the exact pinned native joint positions and that the native root changes each
frame. This closes the supplied-moving-joints calculation boundary, not the
normal spawn/coroutine integration or solver equivalence. The Windows-generated
trace is replay input on Linux; passing Linux descent replay does not mean Linux
regenerated an identical native trajectory. Existing native physics tests remain
separate. No independent landed entity or collision authority is added here.

## Driving point rotation is not soldier rotation

`Helicopter.SpawnAssaulter` assigns the helicopter point and starts Helicopter
behaviour after `SpawningManager.Spawn` resets the pooled soldier's world rotation
to identity. `SwitchStateToHelicopter` calls Idle, enters Driving and starts one
`TweenRotation.Begin` toward the point's current rotation. Subsequent Driving
updates assign position only. They do not refresh that initial tween target when
the aircraft/point rotates. Pool parent transforms and concurrent tweens still
need normal-scene observation before deriving a live soldier pose.

`UnityHelicopterDrivingExport` invokes the original `HelicopterUpdate` on inactive
unparented owners with all six actual prefab crew point transforms. It completes
the original TweenRotation with `Sample(1, true)` and then moves and rotates the
aircraft through sixteen observations per slot. All 96 rows follow point position
while holding the completed entry rotation. This verifies the endpoint and later
Driving method, not real-time tween scheduling or source coroutine execution.
The Unity process exits zero; accepted log: `.local/helicopter-driving-unity.log`.
The LF reference digest is
`acc7ceb748ad671e31fdae3abb86b3ea06c75848ba9d6d654fa6d5faa23828c6`.

The runtime's drop metadata now calls its transformed point pose `CrewPoint`
instead of `Soldier`, and the catalog API explicitly documents that limitation.
Its position is still an attached-point input; even that position is not proof
of the soldier's precise pose at coroutine resume. No held soldier rotation is
invented from current aircraft orientation, spawn age or this isolated endpoint
capture. Actual phase order and parent-space inputs remain required for runtime
descent registration.

## Unscaled NGUI clock for entry tween integration

The default `UITweener.ignoreTimeScale` is true. Unlike the existing scaled shot
tween path, helicopter entry therefore consumes `IgnoreTimeScale.UpdateRealTimeDelta`.
That method carries sub-millisecond residuals, rounds to the nearest millisecond,
subtracts the complete rounded interval, then caps the returned delta at one second.
Excess seconds are discarded, not saved as catch-up debt. OnEnable resets its
time origin and returned delta but does not clear the carried residual.

`NguiRealtimeClock` implements this calculation from explicit trusted realtime
observations. Malformed time/overflow rejects before publishing the new origin
or residual. It is not yet substituted into the scaled shot tween or normal crew
runtime: the exact caller update order, reuse, realtime observations and parent
pose must be preserved before that integration. Fixed tick age is not silently
treated as the original Unity unscaled clock.

`UnityNguiRealtimeClockExport` calls the original method on an inactive owner with
controlled prior timestamps and carried residuals, recording the method's actual
realtime and output. The first zero-exit capture lacked sufficient Editor uptime
to exercise long intervals; its local file is
`.local/ngui-realtime-short-uptime.json` and is not the cap acceptance evidence.
The exporter now waits 1.5 seconds in a fresh batch Editor before those cases.
The accepted run exits zero: `.local/ngui-realtime-unity-final.log`.
The LF reference digest is
`4a3d9307e13fa6b0ae9d70b977f943cb8a0814f6dbc92b4b174a4321026547b0`.
The source digest recorded in that reference is
`176759d03696dd5f7a165b4d131fe5c2466f683935b8d3c50d510c6045911576`.

Tests require all 27 rows and three observed intervals above 1.2 seconds that
return the one-second cap. Every delta and residual compares exactly; non-finite,
negative and overflowing observations must leave the next valid result unchanged.
This is clock calculation evidence under Unity 2018.3, not a completed real-time
entry tween, source Start/Update ordering or original Unity 5.2 proof.

## Entry rotation with unscaled clock and parent composition

`HelicopterEntryRotationTween` now consumes one validated NGUI unscaled delta per
original Update invocation. It uses the source 0.3-second duration and default
EaseInOut, preserves the strict `factor > 1` completion rule, and keeps local
rotation separate from parent composition. Begin accepts captured Euler-roundtripped
local endpoints; it does not convert a guessed world target or infer parent pose.
Clock observation and lifecycle dispatch remain explicit caller responsibilities.

`UnityHelicopterEntryTweenExport` invokes the original Start for the first cycle's
first update and Update for subsequent/reused calls on inactive components. Prior
clock origins are controlled, actual realtime/deltas are recorded, and the clock
residual survives reuse. Three parent/arc scenarios cover 33 calls: ten ordinary
updates and one capped long-frame reused update per scenario. Local and composed
world rotations are captured. This is explicit source-method dispatch, not a
recording of normal Unity PlayerLoop scheduling, pool reuse or coroutine resume.
The accepted Unity process exits zero; log: `.local/helicopter-entry-tween-unity.log`.
The LF reference digest is
`66efb96220882345c7029fb4eac040e5a1f78b61404920273647b309608ee82e`.

An initial server implementation rounded the multiplication before adding the
factor and diverged at update four. Retaining intermediate product precision and
rounding at assignment matches all captured factors exactly; the rotation
tolerance remains 0.00001 sign-invariant quaternion component distance. This is
the observed Unity 2018.3 Mono calculation boundary, not proof of original Unity
5.2 arithmetic. Guards also retain state after invalid deltas and test that factor
one remains enabled until a later positive update exceeds it.

Normal crew runtime registration still requires canonical entry endpoints,
actual pool parent transforms and the source spawn/Start/Update/coroutine order.
The existing scaled shot tween is unchanged; its first-frame callback handling
must not be copied as repeated unscaled fixed deltas into the entry path.

## Actual MainScene initial pool frame

`UnityHelicopterPoolFrameExport` opens the disposable MainScene in Edit Mode and
requires its unique `NetworkPool`. The source `NetworkObjectPool.Init` creates a
new container and assigns `transform.parent` with world-position preservation;
it then parents spawned objects into that container. ReInstantiate resets the
soldier's world position/rotation without changing its parent. The exporter
repeats these Transform operations on plain objects, not a running actor pool.
Edit Mode component initialization may run, but Play Mode, pool actor creation,
Photon allocation and original spawn callbacks are not exercised.

The real scene's NetworkPool world position is approximately
`(0.489697456, -0.88899827, -4.32201052)`, with identity rotation/unit scale.
Despite that offset, the new crew container retains world origin, identity
rotation and unit scale; its local translation cancels the pool offset. A reused
soldier at `(2, 10, 3)` has equal local/world position and identity local/world
rotation. The scene enemy entry points to the recovered enemy prefab with count
130. This is initial parent-space evidence, not a guarantee against subsequent
ancestor movement or a runtime capacity policy for the new server.

The active scene SHA-256 matches the disposable capture:
`5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.
The LF reference digest is
`34433001337ce0aaa8f504c97ccec6acdd6344abcd06b6524221b7879a1fd96a`.
The Unity process exits zero; log: `.local/helicopter-pool-frame-unity.log`.

`HelicopterCrewPoolFrame` pins that reference and validates the supported initial
container/reset rotations before BattleCombatContent publication. Native transport
enablement requires this binding. Actual mission drop records now carry
`InitialPoolParentRotation` and `SpawnResetRotation` separately from `CrewPoint`;
neither is relabeled as the soldier's current rotation. The real native-enabled
mission fixture verifies those inputs alongside both drops, direct landing
queries, live leases and cleanup. Original actor initialization, later pool
movement, entry endpoint capture and source callback/coroutine ordering remain
required before normal crew descent authority can be registered.
