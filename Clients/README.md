# bf96d555b094d74baedd9c3cc87ee3bf1503545934 - Recovered Unity Project

Rebuilt from an Android package by `Tools/New-UnityProjectFromApk.ps1` on 2026-09-18 17:37.

> This is **not** the original developer project. It is decompiler and
> asset-ripper output. Comments, formatting, and original local variable names
> are gone, and some data is intentionally absent rather than lost.

## At a glance

| Property | Value |
| --- | --- |
| Unity version | **5.2.5f1** |
| Scripting backend | **Mono** |
| Native ABI kept | `armeabi-v7a` |
| Source archives merged | 2 |
| Split files rejoined | 24 |
| Assemblies decompiled | 33 |

## Opening the project

1. Install Unity **5.2.5f1** - this exact version.
   Older releases are under <https://unity.com/releases/editor/archive>.
2. In Unity Hub choose **Add project from disk** and pick the `ExportedProject/` folder.
3. Expect a long first import while Unity builds its Library cache.

> Unity asset serialization is version-sensitive. Opening this with a newer
> editor triggers an automatic upgrade that can break prefab, shader, and
> material references in ways that are hard to undo. If you must upgrade,
> copy the project first.

## Folder layout

```text
ExportedProject/      the Unity project - open this one
  Assets/             recovered assets, grouped by type
  ProjectSettings/    ProjectVersion.txt, tags, layers, physics, quality
AuxiliaryFiles/
  GameAssemblies/     the original managed DLLs shipped in the package
  path_id_map.json    exported asset -> original PathID mapping
DecompiledCSharp/     ILSpy output, one folder per assembly
recovery-summary.json machine-readable result of this run
assetripper.log       full AssetRipper import/export log
```

## Scripting backend: Mono

The package shipped real managed assemblies, so method bodies decompile to
near-original C#. This is the good case: typically 90-98% of the logic is
readable.

| | |
| --- | --- |
| Recovered | class/member names, **method bodies**, serialized data, enum values |
| Not recovered | comments, formatting, original local variable names |

Decompiled sources are in `DecompiledCSharp/`. For interactive inspection or
patching, open the DLLs in `AuxiliaryFiles/GameAssemblies/` with dnSpyEx.

## Asset inventory

6533 exported asset files (excluding `.meta`).

| Kind | Count |
| --- | --- |
| Scenes | 12 |
| Prefabs | 781 |
| Scripts | 2892 |
| Materials | 523 |
| Shaders | 89 |
| Textures (png) | 940 |
| ScriptableObjects / data | 917 |
| Animation clips | 152 |
| Audio (wav) | 191 |
| Audio (ogg) | 3 |
| Physic materials | 1 |

Top-level `Assets/` folders: `AnimationClip`, `Avatar`, `Font`, `GameObject`, `Material`, `Mesh`, `MonoBehaviour`, `NavMeshData`, `PhysicMaterial`, `Plugins`, `RenderTexture`, `Resources`, `Scenes`, `Scripts`, `Shader`, `TextAsset`, `Texture2D`

## How this was produced

Source package: `bf96d555b094d74baedd9c3cc87ee3bf1503545934.apk`

Archives merged into a single Android root, in this order:

1. `bf96d555b094d74baedd9c3cc87ee3bf1503545934.apk`
1. `main.14008.com.chillingo.warfriends.android.gplay.obb`

AssetRipper export settings used:

| Setting | Value |
| --- | --- |
| Script export mode | Hybrid |
| Script content level | Level2 |
| Shaders | Dummy |
| Bundled assets | DirectExport |
| Sprites | Yaml |
| Images | Png |
| Audio | Default |

Reproduce this run:

```powershell
.\Tools\New-UnityProjectFromApk.ps1 `
    -Package "E:\Github\Mobile\War friends\bf96d555b094d74baedd9c3cc87ee3bf1503545934.apk" `
    -OutputRoot "E:\Github\Mobile\War friends\Clients\WarFriends" `
    -ScriptExportMode Hybrid -ScriptContentLevel Level2 `
    -ShaderExportMode Dummy -Abi armeabi-v7a `
    -Decompile
```

## Known limitations

| Category | Status |
| --- | --- |
| Assets, scenes, prefabs, textures, audio, animation | Recovered |
| Class/field/method names, serialized data | Recovered |
| C# method bodies | Recovered (Mono decompile) |
| Comments, formatting, local variable names | Not recoverable |
| Complete shader source | Partial - see the shader export mode above |
| Server logic, API signatures, auth tokens | Not in the package; must be rebuilt |

A null mesh, missing material slot, or empty reference is often intentional
(runtime-generated, optional, or absent in the original) rather than conversion
loss. Classify before you "fix" it.

## Warnings from this run

- Requested ABI 'arm64-v8a' is not in the package; using 'armeabi-v7a'.

---

Only analyze packages you own or are authorized to inspect.
