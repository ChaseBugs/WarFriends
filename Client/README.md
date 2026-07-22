# WarFriends hybrid recovered client

This workspace combines the newer **4.9.5 game resources** with the recoverable
**1.6.0 Mono C# runtime**:

- Resource source: `WarFriends_+PvP+Shooter+Game_4.9.5_APKPure.xapk`
- Script/runtime source: `com.chillingo.warfriends.android.gplay-1.6.0-APK4Fun.com.apk`
- Active Unity project: `ExportedProject`
- Unity version: **2018.4.23f1** (originally assembled in 2020.3.49f1; retargeted to 2018.4 —
  see [Retarget to Unity 2018.4](#retarget-to-unity-20184) below)

## Open the project

Use `-disable-assembly-updater`. Allowing Unity's automatic assembly updater to
rewrite the retained compatibility plugins can invalidate their patched assembly references.

```powershell
& 'C:\Program Files\Unity\Hub\Editor\2018.4.23f1\Editor\Unity.exe' `
  -disable-assembly-updater `
  -projectPath 'E:\Github\Mobile\WarFriends\Client\ExportedProject'
```

Do **not** re-open the project in 2020.3.49f1 and re-save — that pushes the serialized
data back to the newer on-disk format, which 2018.4 then cannot read.

`Assets/Scenes/SplashScene.unity` is first in Build Settings and loads
`Assets/Scenes/MainScene.unity`.

## What was recovered

- `ExportedProject/Assets/Scripts/Gameplay` and `Gameplay.FirstPass` are the active,
  editable C# 7.3 gameplay runtime recovered from the patched 1.6.0 Mono assemblies.
- The source assemblies preserve the original `WarFriends.Gameplay` and
  `WarFriends.Gameplay.FirstPass` identities. All 35,981 serialized gameplay references in 840
  assets now point to source MonoScripts; the conversion report is `source-reference-remap.csv`.
- The retired gameplay DLLs and their rollback copies have been removed. The editable files under
  `Assets/Scripts` are the sole gameplay implementation loaded by the Unity project.
- Serialized-field aliases bridge obfuscated 4.9.5 layouts to the matching 1.6.0
  fields. The patcher added 2,459 exact-layout aliases and 3,035 sequence-matched
  aliases.
- The 402 4.9.5-only serialized component types were extracted to editable C# under
  `Assets/Scripts/ResourceCompatibility` and `ResourceCompatibility.FirstPass`. Their exact
  original assembly identities are retained by asmdefs, and all 1,193 references across 67 YAML
  assets now point to source MonoScript GUIDs with fileID `11500000`.
- The two precompiled `WarFriends.ResourceCompatibility*.dll` plugins were removed after the
  source compile, complete reference remap, all-scene audit, field audit, Play Mode smoke test,
  and Android build passed.
- Runtime guards cover obsolete Unity particle emitters, Android-only JNI paths,
  singleton scene transitions, optional Fuse SDK state, weapon inventory gaps,
  and legacy shutdown callbacks.
- Two compatibility sanitizer passes removed 70 list entries that referred to
  4.9.5-only level behaviours or object-pool types with no 1.6.0 implementation.
- `WarFriends.AWSSDK.Core.Compatibility.dll` gives the newer Pinpoint plugin its
  required strong-named AWS Core identity without displacing the unsigned AWS
  Core version used by the 1.6.0 gameplay runtime.
- AssetRipper's zeroed RIFF/data lengths were repaired in 239 recovered WAV files. The repaired
  files are the active assets; the redundant pre-repair copies were removed after verification.

The historical patching utility is in `../Tools/LegacyAssemblyPatcher`; the WAV repair tool
is `../Tools/Repair-WavHeaders.ps1`. Intermediate patch-stage backups are not part of the active
Client and were removed after the source runtime and scene references were verified.

## Source-backed ResourceCompatibility assemblies

The former `WarFriends.ResourceCompatibility.dll` and
`WarFriends.ResourceCompatibility.FirstPass.dll` preserved 4.9.5-only types that are absent from
the recovered 1.6.0 runtime. They are now fully source-backed:

- 277 main and 125 FirstPass serialized types are recorded in
  `resource-compatibility-source-map*.csv`.
- Cecil metadata/IL closure analysis selected 652 main and 454 FirstPass type definitions. This is
  1,106 required types in 1,103 `.cs` files; three generic type families share their decompiled
  source file.
- `WarFriends.ResourceCompatibility` and `WarFriends.ResourceCompatibility.FirstPass` asmdefs keep
  the original assembly names. Serialized fields and Unity attributes remain in their recovered
  source definitions.
- Deterministic `.cs.meta` GUIDs replaced all 1,057 main and 136 FirstPass DLL references with
  `(source GUID, 11500000)`. The complete result is
  `resource-compatibility-reference-remap.csv`: 402 mapped types, 1,193 references, 0 unresolved,
  and 0 residual serialized DLL references.

The recovered compatibility method bodies are still lossy decompiler/IL2CPP stubs; converting the
type layer to source makes it editable and preserves resource deserialization, but it does not
invent missing 4.9.5 gameplay behavior. Do not restore the retired compatibility DLL plugins.

## Retarget to Unity 2018.4

The hybrid was originally assembled in **2020.3.49f1** but is now worked on in
**2018.4.23f1** (the version installed across the dev fleet). Moving it to 2018.4
required three targeted changes (applied 2026-07-20):

1. **Editor packages.** `com.unity.ide.visualstudio@2.0.18` (and its transitive
   `com.unity.test-framework` / `com.unity.ext.nunit`) cannot compile under 2018.4 —
   they need the Unity 2019.2+ `Unity.CodeEditor` API. 2018.4 has native VS/IDE
   integration, so the package was removed from `Packages/manifest.json`. The stale
   `packages-lock.json` and `Library/PackageCache` were cleared so 2018.4 re-resolves.

2. **`UnityEngine.AndroidJNIModule`.** 2018.4 has no split AndroidJNI module — the
   `AndroidJava*` types live in `UnityEngine.CoreModule`. The `AndroidJNIModule` assembly
   reference was folded into `CoreModule` (via the patcher's `--merge-assembly-ref`) in the
   recovered assemblies that carried it. The ResourceCompatibility pair was subsequently
   converted to source; `GoogleMobileAds.Android.dll` and `Facebook.Unity.Android.dll` retain
   their repaired references. Without this they fail to load ("Unable to resolve
   reference … AndroidJNIModule" / "Unloading broken assembly").

3. **Baked binary assets.** The 13 `NavMeshData/NavMesh*.asset` and 14 per-scene
   `LightingData.asset` files were serialized at 2020.3 and cannot be read by 2018.4
   ("serialized with a newer version … higher SerializedFile version"). Binary `.asset`
   data is not downgradable, so all 27 (plus metas) were deleted. **Baked lighting and
   navmesh therefore need a rebake in 2018.4** — this is the one outstanding item; the
   files remain recoverable from git history if the 2020.3 bakes are ever wanted.

> If you regenerate any remaining patched third-party DLL, point the patcher's injected references at 2018.4's
> managed module set (`…/2018.4.23f1/Editor/Data/Managed`), not 2020.3's.

## Verified state

Under **2018.4.23f1** with the editable source runtime (`HybridSceneAudit.Run`, 2026-07-22):

- The ResourceCompatibility conversion preserves 2,168 main plus 379 FirstPass serialized fields
  with 0 schema mismatches against the retired assemblies; see
  `resource-compatibility-validation.txt`.
- All 14 enabled scenes load: 0 failed scenes, 0 missing scripts, 0 console errors.
- `MainScene` loads 26,605 GameObjects and 56,463 components (parity with the 2020.3 figures).
- The runtime-field audit deserializes all 24 targeted MainScene manager/gameplay components.
- A 46-second Play Mode smoke run reaches `SplashScene -> MainScene` with 0 managed errors.
- Both standalone C# 7.3 audit projects compile with 0 errors.

Carried over from the original **2020.3.49f1** assembly:

- All 252 audio clips pass the import/load audit: 0 failed clips.
- The Android ARMv7 Mono development build succeeds with all 14 scenes and 0 build errors. The
  verified source-compatibility build produced a 36,107,069-byte APK plus a 508,496,157-byte OBB
  for package `com.chillingo.warfriends.android.gplay`, version code `495160`, and minimum API 19.
  See `hybrid-android-build.txt` for the source-runtime build result. Generated APK/OBB
  files are ignored and are removed during workspace cleanup; rerun the build when needed.

Primary reports:

- `hybrid-scene-audit.csv`
- `hybrid-missing-script-details.csv`
- `hybrid-audio-audit.csv`
- `hybrid-playmode-smoke.txt`
- `hybrid-runtime-field-audit.txt`
- `hybrid-compatibility-sanitizer-initial.csv`
- `hybrid-compatibility-sanitizer.csv`
- `hybrid-wav-header-repair.csv`
- `hybrid-android-build.txt`
- `hybrid-android-verification.txt`

## Re-run validation

```powershell
$unity = 'C:\Program Files\Unity\Hub\Editor\2018.4.23f1\Editor\Unity.exe'
$project = 'E:\Github\Mobile\WarFriends\Client\ExportedProject'

& $unity -batchmode -nographics -quit -disable-assembly-updater `
  -projectPath $project -executeMethod HybridSceneAudit.Run `
  -logFile 'E:\Github\Mobile\WarFriends\Client\unity-hybrid-scene-audit.log'

& $unity -batchmode -nographics -disable-assembly-updater `
  -projectPath $project -executeMethod HybridPlayModeSmoke.Start `
  -logFile 'E:\Github\Mobile\WarFriends\Client\unity-hybrid-playmode-smoke.log'

& $unity -batchmode -nographics -quit -disable-assembly-updater `
  -projectPath $project -buildTarget Android -executeMethod HybridBuild.BuildAndroid `
  -logFile 'E:\Github\Mobile\WarFriends\Client\unity-hybrid-android-build.log'
```

## Install a newly generated development build

Run `HybridBuild.BuildAndroid` first. The APK uses Unity's debug certificate. Install the
expansion data under the standard Android OBB name before launching:

```powershell
$adb = 'C:\Program Files\Unity\Hub\Editor\2018.4.23f1\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe'
$builds = 'E:\Github\Mobile\WarFriends\Client\Builds'
$package = 'com.chillingo.warfriends.android.gplay'

& $adb shell mkdir -p "/sdcard/Android/obb/$package"
& $adb push "$builds\main.495160.$package.obb" "/sdcard/Android/obb/$package/"
& $adb install -r "$builds\WarFriends-Hybrid-4.9.5-resources-1.6.0-runtime.apk"
```

The recovered `tk2dSprite.OnDestroy` now uses immediate mesh destruction only when
Unity tears down `[ExecuteInEditMode]` components outside Play Mode. This removes the
two false editor errors previously emitted while BuildPipeline changed scenes; the
latest source-runtime Android report succeeds with `error_count=0`.

## Remaining limits

This is a functional editor-side hybrid recovery, not a source-complete 4.9.5
client. The 4.9.5 release used IL2CPP, so newer-only native gameplay code cannot
be reconstructed from serialized resources; its compatibility components retain
data and references but intentionally contain no invented gameplay logic.

Live authentication, matchmaking, PvP, analytics, ads, cloud data, and purchases
still depend on the original Chillingo/EA, Photon, Fuse, Google Play, and AWS
services and credentials. Those historical endpoints may be retired. The local
scene/runtime checks therefore do not prove that the original online backend is
available.
