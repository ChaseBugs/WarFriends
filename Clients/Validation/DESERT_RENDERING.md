# Desert Multiplayer rendering repair — 2026-10-23

Historical first checkpoint. The all-ten-scene repair and the subsequent default
shield correction are documented in [GAMEPLAY_RENDERING.md](GAMEPLAY_RENDERING.md).
The eight mutable shields are now excluded from this initial static inventory;
current Desert static environment count is 223. The original images and manifest
below remain archived as evidence of the first diagnosis.

## Observed defects and fixes

The reported blue battlefield was a rendering defect in the recovered Unity scene.
The HUD and characters continued running while most static environment geometry
was drawn with the wrong submesh and transform. This was reproduced with Unity
2018.3.0f2 / Direct3D 11, using an owned disposable project.

1. All 231 recovered static MeshRenderers retained Unity 5 `m_SubsetIndices`, but
   imported with modern firstSubMesh=0, subMeshCount=0 and no static batch root.
   Their MeshFilters still referenced combined meshes with many submeshes. The
   scene now explicitly restores m_StaticBatchInfo from the original selector and
   binds m_StaticBatchRoot to the existing identity LevelRoot transform (1090).
   Original selector values remain present for provenance. No mesh, texture image,
   collider, navigation, object transform, name or GUID was replaced.
2. The recovered T4M surface shader failed ForwardBase compilation: `Too many
   texture interpolators would be used for ForwardBase pass (11 out of max 10)`.
   Unity selected a fallback whose unused MainTex is empty, producing white ground.
   The shader now carries one raw UV0 coordinate and applies each of the five
   original texture scale/offset values in the fragment stage. The four-layer blend
   and lighting remain intact; no higher shader target is required.
3. The uncolored vegetation reconstruction multiplied RGBA by wind-control vertex
   colors and used an alpha cutoff against the plants material's persisted value 1.
   Filtered foliage disappeared or became black fragments. It now uses texture
   color/alpha with transparent blending and no depth writes, consistent with the
   plants, palmtop and transparent materials' authored render queue 3000 and the
   separate transparent Colored shader variant. Vertex alpha still controls wind.
   This is an evidence-based rendering reconstruction; original shader source was
   not recovered from the APK.
4. The terrain's four-channel control texture was incorrectly imported as a color
   image with alpha edge dilation. Its importer now preserves RGBA weights and
   treats the data as linear. The PNG bytes and tiling remain unchanged.

Unity documents that [MeshRenderer.subMeshStartIndex](https://docs.unity3d.com/jp/2018.4/ScriptReference/MeshRenderer-subMeshStartIndex.html)
selects the first combined/static-batched submesh. Its value was zero for every
broken renderer, independently of the recovered selector stored in the scene.

## Verification

- `repair_desert_static_batches.py` validates all 231 original selectors against
  source mesh submesh counts and material counts. It is idempotent. Reversing only
  the added modern batch records/root pointers reproduces the exact prior scene.
- `UnityDesertRenderingAudit` validates source batch metadata, compiles the real
  terrain shader, requires its ForwardBase pass and zero shader errors, and checks
  linear/no-dilation control import. It renders the repaired scene, temporarily
  removes the metadata to reproduce the reported defect, then restores it without
  saving the temporary scene.
- Native Client run `client-boot-1f3d4fde6dea4cd2bfac97e02dc48d6f` used the current
  source snapshot, entered Desert_Multiplayer through normal beginner bot matching,
  and captured the real battle HUD. Its 223 surviving combined-mesh renderers all
  retained static batching, including both terrain surfaces. Gameplay errors and
  exceptions were zero. Result UI, offline cached boot and login synchronization
  also passed. This is not a two-human online battle or Android rendering proof.
- The asset-reference audit reports zero missing scripts and zero broken references.
  The NGUI audit retains the existing 17 unmatched sprite selections; none was
  replaced with guessed artwork.

[Broken batching reproduction](desert-rendering/before.png),
[repaired scene](desert-rendering/after.png), and
[actual battle with HUD](desert-rendering/gameplay.png).
Reports and the original selector manifest are retained beside these images.
Only the Desert_Multiplayer scene's batch metadata is repaired in this increment;
other scenes are not certified by this rendering proof.

The source preimage SHA-256 is
`d2acaeb238fb2dfdcfb0e1bb69a52628798498f7b6992ecf9418a727360368c1`;
repaired scene SHA-256 is
`559ae57c24b8ecf21e4ca3f7386de0334d067410618d3442ec769c9cf263403b`.

To rerun, use a disposable project under Server/.local, copy
Server/tools/UnityDesertRenderingAudit.cs into its Assets/Editor folder, copy the
retained manifest.json to a report directory, set WAR_DESERT_AUDIT_OUTPUT to that
directory, and launch Unity with -batchmode -executeMethod
UnityDesertRenderingAudit.Run. Keep graphics enabled. To capture the full normal
battle, set WAR_BOT_RENDER_CAPTURE to a PNG path and run ClientBootSmoke.ps1
-VerifyStarterBot with that disposable project.
