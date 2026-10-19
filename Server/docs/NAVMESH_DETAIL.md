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
