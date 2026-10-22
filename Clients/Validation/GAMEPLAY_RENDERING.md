# Gameplay scenes and default shields — 2026-10-23

This supersedes the Desert-only checkpoint in [DESERT_RENDERING.md](DESERT_RENDERING.md).
The active recovered 1.4.0 Client supplies the geometry, transforms, materials,
shield models and shield health rules. No new shield inventory item or purchase
requirement was introduced.

## Changes and cause

All ten gameplay scenes retain Unity 5 static submesh selectors that Unity 2018
otherwise imports without the required modern batch records. Restore the original
submesh range for 2,288 static environment renderers. Their vertices were already
baked in world coordinates, so their batch root must have an identity world matrix.
Where the original LevelRoot is translated, add one empty identity child with an
inverse local translation. Existing object transforms, names, IDs and child order
remain unchanged; mesh and texture image bytes are not rewritten.

Shields are mutable geometry: Shield.Awake and SwitchModel replace their mesh as
health changes. Sixty shields must therefore be excluded from static batching and
lightmap baking, and initially reference their existing intact model. Their original
colliders, map points, faction ownership and damage/repair scripts remain intact.

Clearing static batch records alone was insufficient. Each scene's LightingData
still assigned the shield a baked **uvMesh vertex stream from the combined static
mesh**. Unity applied that stream to the smaller intact/broken shield meshes. The
result had positive health and valid bounds but drew no pixels, even with an unlit
material. A fresh renderer using the identical mesh drew normally; removing only
the paired shield bake records restored the original renderer. Exactly 60 paired
records were removed. Every environment bake record, lightmap image and asset GUID
is preserved. No runtime renderer replacement is needed.

The two T4M four-layer shaders now pass one raw UV0 to the fragment stage and apply
the five source texture transforms there. This avoids the ForwardBase interpolator
limit while preserving layer blending and tiling. Six terrain control textures use
linear RGBA weights without alpha edge dilation. Both uncolored wind vegetation
variants retain vertex-alpha wind control and sample texture color/alpha directly.
The opaque lightmapped variant no longer multiplies the wind-control RGB values
into foliage color; this fixes the blue/black Park trees. Its baked-lighting sample
is enabled only for LIGHTMAP_ON.
Original shader source is unavailable; these are documented rendering repairs.

## Default shield rule

Shield.OnGameStarted uses IGameController.GetShieldHP(player), which reads the
current rank's SHIELDHP from the recovered PlayerBalance table, then refills the
shield. MapDefinition.InitShields binds the existing normal/gold material to each
map point. A new player already receives this cover without buying equipment.
Native rank-two bot runs start with max health **624**, matching that source row.
The fix makes this existing default visible rather than inventing a fixed health
value or a Backend entitlement.

## Verification and limits

Unity 2018.3.0f2 / Direct3D 11 in a reused disposable project checked all ten scenes:

- 2,288 static environment ranges with identity batch roots;
- 60 intact dynamic shields, each required to produce actual shield pixels through
  its original MeshRenderer, with the diagnostic material restored afterward;
- zero missing scripts and zero errors from the shaders referenced by the scenes;
- zero broken serialized references in the repository asset audit. The existing
  17 unmatched NGUI sprite selections remain separately recorded.

See [scene-report.json](gameplay-rendering/scene-report.json) and the per-scene
images in [gameplay-rendering](gameplay-rendering/). Single-player scenes received
scene rendering and default-shield pixel checks; this does not certify every
mission, co-op path, two-human PvP session or Android graphics backend.

The normal Client bot audit selects each Multiplayer map explicitly for rendering
coverage, preserving its normal login, bot controller, battle and result flow.
This map override is a diagnostic and is not proof of ordinary map-unlock UI rules.
All five Multiplayer maps (Desert, Aztec, City, Park and Snow) passed actual bot
combat and the visible result screen with zero gameplay errors/exceptions and
rank-table max shield health 624. Park was repeated after the foliage correction.
Its summaries and actual HUD/default-shield images are stored alongside the scene
proof in [battle-report.json](gameplay-rendering/battle-report.json). The tests use one existing disposable Unity Library and ephemeral MongoDB
runs with retention; they do not create another Library for each map.

## Repeatable checks

```powershell
python Clients/Validation/repair_gameplay_rendering.py
python Clients/Validation/audit_asset_references.py
python Clients/Validation/audit_ngui_assets.py
```

The repair command is dry-run by default and preflights all selected scenes and
paired lighting data before writing anything. Use --apply only to publish reviewed
repairs; --scene scopes it, and --manifest writes the native audit input. It is
idempotent. The retained manifest identifies this repair checkpoint, not an APK
source digest.

Copy Server/tools/UnityGameplayRenderingAudit.cs and
Server/tools/UnityDesertRenderingAudit.cs into the owned disposable project's
Assets/Editor folder. Generate manifest.json in an output directory, set
WAR_GAMEPLAY_RENDER_OUTPUT to it, and run Unity with graphics enabled:

```text
-batchmode -projectPath <owned disposable project> -executeMethod UnityGameplayRenderingAudit.Run -logFile <audit log>
```

For an actual bot battle capture, set WAR_BOT_RENDER_SCENE to one of the five
Multiplayer scene names and WAR_BOT_RENDER_CAPTURE to a PNG path, then invoke
Server/scripts/ClientBootSmoke.ps1 -VerifyBotBattleOnly with that disposable Unity
project and the native MongoDB executable. The normal -VerifyStarterBot check
continues to include offline cached boot and returning-account synchronization;
the map-only switch avoids repeating those unrelated phases for every renderer.
