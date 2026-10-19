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
coroutine timing capture. The co-op runtime still needs to own pending states,
invoke activation at its actual render boundary, cancel them on removal, and release
the native world on match termination. The normal Worker gate remains closed.
