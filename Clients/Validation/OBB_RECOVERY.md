# APK + OBB asset recovery — 2026-09-18

The matching OBB exists at the repository root:
`main.14008.com.chillingo.warfriends.android.gplay.obb` (207,834,298 bytes).
Its SHA-256 is
`078cd1c4ebaeef4a39646274a54d35ce05741bc15a2e13d95ae55340711b5125`.
The same file is inside `WarFriends 1.4.0/assets/qqes.zip`.

The original export included the expansion data, but failed to initialize its
Mono assembly manager because two DLLs used the P31RestKit assembly identity.
It then exported without script field data. A corrected extraction with
AssetRipper 1.3.14, omitting only duplicate `P31RestKit 1.dll` from the temporary
input, recognized 33 Mono assemblies and exported their component payloads.

`restore_obb_fields.py` merged **22,921 component payloads in 365 files**:
12 scenes, 171 files under GameObject, 170 under Resources, and 12 under
MonoBehaviour. Existing asset GUIDs, object IDs, script bindings, enabled states,
native asset data, and repaired code were retained. Expanded local scenes keep
SplashScene's `downloadOBB` false. No server or library implementation was changed.
The pre-merge files are archived in `before-obb-fields.zip`; per-file counts are
in `obb-field-restoration.json`.

Restored bindings include GuiManager.root/guiCamera,
GameController.mainPlayerController/gameControllerCampaign, and
WeaponPreviewCamera.weaponParent/target. Both preview fields now reference the
original Transform 33098. Atlas definitions, font data, scene configuration,
prefab fields, and UI selections were recovered from the matching binaries.

Thirty additional empty missing-script records across the ten battle scenes
were archived in `../QuarantinedRecoveredSources/obb-empty-components.json` and
their empty component slots removed. Each is also empty in the corrected source,
has no serialized custom payload, and was referenced only by its own GameObject's
component list. No GameObjects were removed. Two equivalent MainScene records
had already been archived earlier. This is cleanup of source-empty records,
not recovery of their unknown original types.

## Verification

- `audit_asset_references.py`: 2,375 YAML documents, 23,513 remaining script
  components, 288,080 nonzero serialized references, 1,052 script-file targets;
  **zero missing script attachments and zero broken GUID/file-ID references**.
- `obb-inventory-audit.json`: no non-code asset files missing relative to the
  corrected extraction; compared binary/text asset contents match. Shader
  implementations and YAML serialization were excluded from the binary hash
  comparison. This does not recover original shader source.
- `audit_ngui_assets.py`: 30 atlas components and 8,047 sprites; 17 original
  selections are absent from their assigned atlases, and 509 are empty/dynamic.
  Preserve the source and examine these in context before changing artwork.
- `ObbRecoveryAudit.Run` is prepared to open all 12 scenes and check critical
  bindings in Unity. Its attempted run was blocked by concurrent owner library
  updates producing C# compile errors. Those libraries were left untouched.
  The earlier successful compilation/startup logs predate this asset restoration.

This verifies recovered serialization and file availability. It does **not**
prove current compilation, rendering, Play Mode, or a complete playable client.

## Reproduction

The temporary merged input and corrected comparison export are under
`E:/Temp/WarFriends-obb-recovery`. `assetripper-obb.log` retains the successful
Mono import/export evidence. The comparison export is not a Client dependency.
Run `restore_obb_fields.py` without `--apply` for a reference-checked dry run;
its backup guard prevents accidentally overwriting the first recovery backup.
Run the two Python audits after subsequent scene or prefab edits. Once the
library updates compile, run `ObbRecoveryAudit.Run` in the disposable Unity
validation project before making runtime claims.
