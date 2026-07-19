# WarFriends hybrid recovered client

This workspace combines the newer **4.9.5 game resources** with the recoverable
**1.6.0 Mono C# runtime**:

- Resource source: `WarFriends_+PvP+Shooter+Game_4.9.5_APKPure.xapk`
- Script/runtime source: `com.chillingo.warfriends.android.gplay-1.6.0-APK4Fun.com.apk`
- Active Unity project: `ExportedProject`
- Unity version: **2020.3.49f1**

## Open the project

Use `-disable-assembly-updater`. Allowing Unity's automatic assembly updater to
rewrite the recovered precompiled runtime can invalidate the patched assemblies.

```powershell
& 'C:\Program Files\Unity\Hub\Editor\2020.3.49f1\Editor\Unity.exe' `
  -disable-assembly-updater `
  -projectPath 'E:\Github\Mobile\WarFriends\Client\ExportedProject'
```

`Assets/Scenes/SplashScene.unity` is first in Build Settings and loads
`Assets/Scenes/MainScene.unity`.

## What was recovered

- `WarFriends.Gameplay.dll` and `WarFriends.Gameplay.FirstPass.dll` contain the
  patched 1.6.0 Mono gameplay runtime.
- Serialized-field aliases bridge obfuscated 4.9.5 layouts to the matching 1.6.0
  fields. The patcher added 2,459 exact-layout aliases and 3,035 sequence-matched
  aliases.
- 1,193 serialized component references across 67 YAML assets were remapped to
  common 1.6.0 runtime types.
- `WarFriends.ResourceCompatibility*.dll` retain serialized definitions for
  4.9.5-only component types so scenes and prefabs remain loadable.
- Runtime guards cover obsolete Unity particle emitters, Android-only JNI paths,
  singleton scene transitions, optional Fuse SDK state, weapon inventory gaps,
  and legacy shutdown callbacks.
- Two compatibility sanitizer passes removed 70 list entries that referred to
  4.9.5-only level behaviours or object-pool types with no 1.6.0 implementation.
- `WarFriends.AWSSDK.Core.Compatibility.dll` gives the newer Pinpoint plugin its
  required strong-named AWS Core identity without displacing the unsigned AWS
  Core version used by the 1.6.0 gameplay runtime.
- AssetRipper's zeroed RIFF/data lengths were repaired in 239 recovered WAV files.
  Original WAV files are preserved in `AuxiliaryFiles/PreWavHeaderRepair`.

The patching utility is in `../Tools/LegacyAssemblyPatcher`; the WAV repair tool
is `../Tools/Repair-WavHeaders.ps1`. Pre-sanitizer scenes and original assemblies
remain under `AuxiliaryFiles`.

## Verified state

- All 14 enabled scenes load in Unity: 0 failed scenes and 0 missing scripts.
- `MainScene` loads 26,605 GameObjects and 56,463 components.
- All 252 audio clips pass the import/load audit: 0 failed clips.
- A 46-second Play Mode smoke run reports `SplashScene -> MainScene` with
  0 managed errors (`hybrid-playmode-smoke.txt`).
- The Android ARMv7 Mono development build succeeds with all 14 scenes. Output is
  a 38.5 MB APK plus a 495.9 MB OBB. The APK passes Android v1/v2 signature
  verification and declares package `com.chillingo.warfriends.android.gplay`,
  version code `495160`, minimum API 19, and target API 30.

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
$unity = 'C:\Program Files\Unity\Hub\Editor\2020.3.49f1\Editor\Unity.exe'
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

## Install the development build

The APK uses Unity's debug certificate. Install the expansion data under the
standard Android OBB name before launching:

```powershell
$adb = 'C:\Program Files\Unity\Hub\Editor\2020.3.49f1\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe'
$builds = 'E:\Github\Mobile\WarFriends\Client\Builds'
$package = 'com.chillingo.warfriends.android.gplay'

& $adb shell mkdir -p "/sdcard/Android/obb/$package"
& $adb push "$builds\main.495160.$package.obb" "/sdcard/Android/obb/$package/"
& $adb install -r "$builds\WarFriends-Hybrid-4.9.5-resources-1.6.0-runtime.apk"
```

The successful Unity build report includes two editor-only diagnostics from the
legacy `tk2dSprite.OnDestroy` method calling `Destroy` while BuildPipeline changes
scenes. They do not occur in Play Mode and did not fail the Android build.

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
