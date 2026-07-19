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

## The three Unity projects

| Path | Unity version | Role |
|------|--------------|------|
| `Client/ExportedProject` | **2020.3.49f1** | **The active/primary project** — a *hybrid*: 4.9.5 game resources + patched 1.6.0 Mono runtime. |
| `Client-Decompiled-Mono-1.6.0/ExportedProject` | 2017.4.30f1 | Raw AssetRipper decompile of the 1.6.0 Mono APK. Source of the recoverable C# runtime. |
| (source binaries) | — | `*.apk` / `*.xapk` / OBB in repo root are the recovery inputs. |

The **hybrid** is the point of the project: the 4.9.5 release was built with IL2CPP (native,
non-recoverable code), so its serialized resources are married to the 1.6.0 Mono gameplay
DLLs, with a large compatibility shim layer bridging the two obfuscated field layouts.
Read `Client/README.md` before touching the hybrid — it records exactly what was patched
and the verified state.

## Opening and building the hybrid project

Always pass `-disable-assembly-updater`. Unity's automatic assembly updater will rewrite
the patched precompiled runtime DLLs and invalidate the recovery.

```powershell
$unity = 'C:\Program Files\Unity\Hub\Editor\2020.3.49f1\Editor\Unity.exe'
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
OBB in `Client/Builds`. Startup scene is `Assets/Scenes/SplashScene.unity` (loads `MainScene`).

## Editor tooling (`Client/ExportedProject/Assets/Editor/`)

These `-executeMethod` targets drive validation and repair; each emits a `hybrid-*.csv/txt`
report into `Client/`:

- `HybridSceneAudit.Run` — loads all enabled scenes, reports missing scripts
- `HybridBuild.BuildAndroid` — the Android build
- `HybridPlayModeSmoke.Start` — timed Play Mode run, checks SplashScene→MainScene
- `HybridAudioAudit.Run`, `HybridResourceAudit.Run`, `HybridRuntimeFieldAudit.Run`
- `HybridCompatibilitySanitizer.Run` — strips list entries referencing 4.9.5-only types
- `ResourceCompatibilityRemapper.RemapAllAssets` — remaps serialized component refs to 1.6.0 types

## Native tooling (`Tools/`)

- **`LegacyAssemblyPatcher/`** (`net8.0` console app, Mono.Cecil-based) — the core of the
  hybrid. Rewrites recovered assemblies: renames/retargets assembly refs, injects
  serialization-field aliases (exact-layout + sequence-matched) to bridge obfuscated 4.9.5
  layouts onto 1.6.0 fields, and injects runtime guards (`--guard-*`, `--fix-singleton-lifecycle`).
  Flags via `Program.cs`. References Unity's `Unity.Cecil.dll` from the 2020.3.49f1 install.
- **`WarFriends.LegacyCompat/`** (`netstandard2.0`) — hand-written shims (e.g. obsolete
  particle emitter compat) compiled into `WarFriends.LegacyCompat.dll` and dropped in the project's `Plugins`.
- **`Repair-WavHeaders.ps1`** — repairs AssetRipper's zeroed RIFF/data lengths in recovered WAVs.
- **`Build-RecoveryInput.ps1`** / **`Build-4.9.5-ResourceInput.ps1`** — assemble the merged
  Android root (APK+OBB, recombine `.split*`) under `Recovery/` for AssetRipper.

Build the .NET tools with `dotnet build Tools/LegacyAssemblyPatcher/LegacyAssemblyPatcher.csproj`.

## Key facts and constraints

- The patched gameplay DLLs live in `Client/ExportedProject/Assets/Plugins/`:
  `WarFriends.Gameplay.dll`, `WarFriends.Gameplay.FirstPass.dll`,
  `WarFriends.ResourceCompatibility*.dll`, `WarFriends.LegacyCompat.dll`,
  `WarFriends.AWSSDK.Core.Compatibility.dll`. These are **build products of the tools above** —
  do not hand-edit; regenerate via the patcher.
- Compatibility shim types intentionally contain **no invented gameplay logic** — they only
  retain serialized data/references so scenes and prefabs load. Preserve this; don't fabricate
  behaviour to make something "work."
- Pre-patch scenes and original assemblies are preserved under `*/AuxiliaryFiles/`.
- Recovery outputs (`Recovery/`, `Client-Hybrid-*-Test/`), `*.apk`/`*.xapk`/`*.obb`, and
  `*.fields.csv` are gitignored; large binaries are recovery inputs, not committed source.
- Online features (auth, matchmaking, PvP, ads, purchases, analytics via Photon/Fuse/Google
  Play/AWS) depend on retired historical backends — local scene/build success does not imply
  the online game works.
