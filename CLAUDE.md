# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this repository is

This is **not** a from-source game project. It is a **reverse-engineering / asset-recovery
workspace** for the mobile game *WarFriends* (`com.chillingo.warfriends.android.gplay`,
originally Chillingo/EA). The goal is to reconstruct an openable, buildable Unity project
from shipped APK/XAPK/OBB binaries. Recovered C# is decompiled output, so most method
bodies are stubs or approximations — treat gameplay code as lossy, not authoritative.

Recovery procedure (unpack XAPK→APK+OBB, merge `assets/bin/Data`, recombine `.split*`
files, detect Mono vs IL2CPP, run AssetRipper) is documented in `how_to.md` (Korean).

## The active Unity project

| Path | Unity version | Role |
|------|--------------|------|
| `Client/ExportedProject` | **2018.4.23f1** | **The active/primary project** — a *hybrid*: 4.9.5 game resources + patched 1.6.0 Mono runtime. |
| (source binaries) | — | `*.apk` / `*.xapk` / OBB in repo root are the recovery inputs. |

The duplicate raw 1.6.0 Unity export was removed after its required C# runtime was integrated into
`Client/ExportedProject/Assets/Scripts/Gameplay*`. Those active folders are now also the Server's
protocol and behavioral-contract source.

> **Unity version note:** the hybrid was originally assembled in **2020.3.49f1**, but the
> working target is **2018.4.23f1** (the version installed across the dev fleet). It was
> retargeted from 2020.3 to 2018.4 on 2026-07-20 — see `Client/README.md` "Retarget to
> Unity 2018.4" for exactly what changed. Do **not** re-open it in 2020.3 and re-save, or
> the serialized data drifts back to the newer format.

The **hybrid** is the point of the project: the 4.9.5 release was built with IL2CPP (native,
non-recoverable code), so its serialized resources are now bound to editable 1.6.0 Mono gameplay
source plus an editable 4.9.5 ResourceCompatibility source layer. The asmdefs preserve the
original assembly identities while serialization aliases bridge the obfuscated field layouts.
Read `Client/README.md` before touching the hybrid — it records exactly what was patched
and the verified state.

## Opening and building the hybrid project

Always pass `-disable-assembly-updater`. Unity's automatic assembly updater can still rewrite
retained patched third-party plugins and invalidate the recovery.

```powershell
$unity = 'C:\Program Files\Unity\Hub\Editor\2018.4.23f1\Editor\Unity.exe'
$project = 'E:\Github\Mobile\WarFriends\Client\ExportedProject'

# Open in editor
& $unity -disable-assembly-updater -projectPath $project

# Headless validation / build via -executeMethod (each writes a CSV/txt report to Client/)
& $unity -batchmode -nographics -quit -disable-assembly-updater -projectPath $project `
  -executeMethod HybridSceneAudit.Run -logFile 'E:\Github\Mobile\WarFriends\Client\audit.log'

& $unity -batchmode -nographics -quit -disable-assembly-updater -projectPath $project `
  -buildTarget Android -executeMethod HybridBuild.BuildAndroid -logFile '...\build.log'
```

Build entry point is `HybridBuild.BuildAndroid` → produces an ARMv7 Mono development APK +
OBB in the ignored `Client/Builds` directory. Generated builds are not retained after workspace
cleanup. Startup scene is `Assets/Scenes/SplashScene.unity` (loads `MainScene`).

## Editor tooling (`Client/ExportedProject/Assets/Editor/`)

These `-executeMethod` targets drive validation and repair; each emits a `hybrid-*.csv/txt`
report into `Client/`:

- `HybridSceneAudit.Run` — loads all enabled scenes, reports missing scripts
- `HybridBuild.BuildAndroid` — the Android build
- `HybridPlayModeSmoke.Start` — timed Play Mode run, checks SplashScene→MainScene
- `HybridAudioAudit.Run`, `HybridResourceAudit.Run`, `HybridRuntimeFieldAudit.Run`
- `HybridCompatibilitySanitizer.Run` — strips list entries referencing 4.9.5-only types
- `ResourceCompatibilitySourceRemapper.RemapAllAssets` — validated two-phase migration from the
  retired ResourceCompatibility DLL identities to 402 source MonoScripts; it verifies all 1,193
  references before writing and rolls back touched YAML files on failure
- `HybridColliderMeshReadable.Run` — enumerates meshes used by `MeshCollider`s (scenes + prefabs)
  and lists them so their `m_IsReadable` flag can be flipped (AssetRipper-recovered collision
  meshes ship non-readable, which errors at Play time under non-uniform collider transforms)

## Native tooling (`Tools/`)

- **`LegacyAssemblyPatcher/`** (`net8.0` console app, Mono.Cecil-based) — the core of the
  hybrid. Rewrites recovered assemblies: renames/retargets assembly refs (`--retarget`,
  `--merge-assembly-ref old=new` to fold one ref into another without leaving a duplicate row),
  injects serialization-field aliases (exact-layout + sequence-matched) to bridge obfuscated
  4.9.5 layouts onto 1.6.0 fields, and injects runtime guards (`--guard-*`,
  `--fix-singleton-lifecycle`). Flags via `Program.cs`. References Unity's `Unity.Cecil.dll`
  from the 2020.3.49f1 install (Cecil is version-agnostic; the tool itself is unaffected by the
  editor retarget). `--dump-type-closure <seed-list> <csv>` calculates the exact assembly-local
  source dependency closure used by the ResourceCompatibility extraction.
- **`Export-ResourceCompatibilitySources.ps1`** — exports the 402 serialized source types plus
  the Cecil-proven dependency closure, assigns deterministic `.cs.meta` GUIDs, and regenerates
  the source/dependency manifests under `Client/`.
- **`WarFriends.LegacyCompat`** — hand-written shims, now **in-project scripts** under
  `Client/ExportedProject/Assets/LegacyCompat/` behind a `WarFriends.LegacyCompat.asmdef` (assembly
  name matches what the recovered gameplay source references, so Unity compiles them into
  `WarFriends.LegacyCompat` and the `Gameplay(.FirstPass)` asmdef references resolve). No longer a
  `Tools/` project or a `Plugins/*.dll`; edit the `.cs` and Unity recompiles. Contents: obsolete
  particle emitter compat; `ServerEndpoint.BaseUrl` — the single global constant for the backend URL
  (`--set-server-endpoint-constant` rewrites the client's `DJOJPKGADMP` URL builders to `ldsfld` it;
  edit that one line to repoint the client at a different server); plus
  `SingletonSupport.FindOrCreate/FirstOrDefault` used by the patcher's
  `--guard-singleton-instance` pass (rewrites the decompiled `FindObjectsOfType(typeof(T))[0]`
  and `GetComponents*<T>()[0]` accessors that throw `IndexOutOfRangeException` when a manager
  is absent from a battle scene). `--guard-battle-awakes` guards `Barrel.Awake` /
  `MapManager.Awake` against a missing component / null list. `--guard-dont-destroy-on-load`
  routes every `Object.DontDestroyOnLoad` through `SingletonSupport.DontDestroyOnLoadIfPlaying`
  (no-op in edit mode) so NGUI's `[ExecuteInEditMode]` `UIPanel`/`UIDrawCall` stop throwing
  `InvalidOperationException` when a scene is merely open in the editor.
  `--redirect-server-base-url <url>` overwrites both `DJOJPKGADMP` base-URL builders
  (`NPDIBOLPACA`, `BGMBGEOAKPP`) so `BeanstalkServerManager` posts to the local `Server/` backend
  instead of the retired AWS/Beanstalk host. The client builds `<url><action>/<version>`, so the
  value must end in `/` and use plain `http://` (BestHTTP then skips the pinned-cert validator
  `AACFNCKFCHO`). `http://localhost:8080/` matches the Server's `/:action(\d+)/:version?` route
  and default port. `--bypass-connectivity-check` rewrites
  `BeanstalkServerManager.CheckIsOnline(Action)` to invoke its success callback directly, skipping
  the `check.php` probe (the client demands the response body be exactly `"ok"`; the Server has no
  such route, so the probe otherwise blocks login with a "check connection" error).
  `--guard-ngui-drawcall` guards `UIDrawCall.UpdateMaterials`: returns immediately when the draw call's
  `mRen` (MeshRenderer) is null — recovered draw calls (e.g. the splash `GuiAtlasSplash`) can have a
  null renderer, so the tail `mRen.get_sharedMaterial()` NREs every frame — plus a null-`mSharedMat`
  guard on the clip-shader path. (The AssetRipper NGUI shaders under `Assets/Resources/shaders/` are
  also dummy `//DummyShaderTextExporter` stubs; they were replaced with real ShaderLab, GUIDs kept.)
- **`Repair-WavHeaders.ps1`** — repairs AssetRipper's zeroed RIFF/data lengths in recovered WAVs.
- **`Build-RecoveryInput.ps1`** / **`Build-4.9.5-ResourceInput.ps1`** — assemble the merged
  Android root (APK+OBB, recombine `.split*`) under `Recovery/` for AssetRipper.

Build the .NET tools with `dotnet build Tools/LegacyAssemblyPatcher/LegacyAssemblyPatcher.csproj`.

## Key facts and constraints

- Editable 1.6.0 gameplay lives under `Client/ExportedProject/Assets/Scripts/Gameplay*`; the
  editable 4.9.5-only resource type layer lives under `Assets/Scripts/ResourceCompatibility*`.
  The retired `WarFriends.Gameplay*.dll` and `WarFriends.ResourceCompatibility*.dll` plugins and
  rollback copies must not be restored. Binary plugins remain only where source is unavailable,
  including `WarFriends.AWSSDK.Core.Compatibility.dll`.
- Compatibility shim types intentionally contain **no invented gameplay logic** — they only
  retain serialized data/references so scenes and prefabs load. Preserve this; don't fabricate
  behaviour to make something "work."
- Intermediate patch-stage backups, lossy comparison scripts, Unity caches, and generated builds
  are intentionally excluded from the cleaned Client workspace.
- Recovery outputs (`Recovery/`, `Client-Hybrid-*-Test/`), `*.apk`/`*.xapk`/`*.obb`, and
  `*.fields.csv` are gitignored; large binaries are recovery inputs, not committed source.
- Online features (auth, matchmaking, PvP, ads, purchases, analytics via Photon/Fuse/Google
  Play/AWS) depend on retired historical backends — local scene/build success does not imply
  the online game works.
- **2018.4 retarget (2026-07-20):** 2018.4 lacks the split `UnityEngine.AndroidJNIModule`
  (its `AndroidJava*` types live in `UnityEngine.CoreModule`), so that assembly ref was merged
  into `CoreModule` in the recovered compatibility inputs and the retained
  `GoogleMobileAds.Android.dll` and `Facebook.Unity.Android.dll`. The ResourceCompatibility pair
  was subsequently converted to source. `com.unity.ide.visualstudio`
  was removed from `Packages/manifest.json` (2018.4 has native IDE integration; the package
  needs 2019.2+). The 27 NavMesh/LightingData `.asset` baked binaries were serialized at 2020.3
  and cannot be read by 2018.4, so they were deleted — **baked lighting and navmesh need a
  rebake in 2018.4** (outstanding).
