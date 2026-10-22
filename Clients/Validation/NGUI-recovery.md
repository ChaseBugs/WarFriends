# NGUI comparison and splash repair

Compared WarFriends with Pocket-troops at
`E:/Github/Mobile/Heyworks/Clients/Pocket-troops/ExportedProject/Assets/Scripts/Assembly-CSharp/NGUI/Runtime`.

The exact release numbers are not established, but the serialized APIs differ:

| Area | WarFriends | Pocket-troops |
| --- | --- | --- |
| Atlas | `UIAtlas.Sprite`, Rect-based `sprites` | `UISpriteData` in `mSprites`, legacy migration support |
| Root scaling | PixelPerfect, FixedSize, FixedSizeOnMobiles, FixedWidth, FixedWidthShrinkOnly | Flexible, Constrained, ConstrainedOnMobiles plus separate constraints |

A folder replacement would reinterpret saved enum values and break custom API
callers. Retain WarFriends' NGUI while repairing its missing data and specific
compatibility defects.

The white splash was caused by omitted component and atlas fields. Restored
the original APK's sprite selections, atlas rectangles, colors, panel settings,
root scaling, and launcher references. Unity Rect YAML requires
`serializedVersion: 2`; without it the recovered rectangles deserialize empty
and all vertices sample one white atlas pixel. UIPanel now calls
DontDestroyOnLoad only during Play Mode so editor rendering works too.

`SplashVisualAudit.Run` rendered both panels using Unity 2018.3.0f2, with exit
code 0. Visually checked `splash-ours.png` and `splash-chillingo.png`: both logos
are visible and centered. This is a rendering check, not proof of service
bootstrap or all game UI functionality.

`inspect_splash.py` decodes matching APK data using UnityPy 1.25.3 and
TypeTreeGeneratorAPI 0.0.10. `restore_splash_visuals.py` writes the recovered
fields using PyYAML 6.0.3, preserving the exported script GUIDs. The duplicate
P31RestKit assembly is omitted from the type generator to avoid its name collision.

The matching expansion data is now confirmed at the repository root and inside
`WarFriends 1.4.0/assets/qqes.zip`. A corrected APK+OBB extraction recovered the
other scenes' component fields. See `OBB_RECOVERY.md` for restoration evidence.
The previous statement that the OBB was unavailable was incorrect.

The static NGUI audit finds 30 atlas components and 8,047 UISprites. Of 7,538
nonempty sprite selections with an assigned atlas, 17 retain source-original
names absent from that atlas; 509 other widgets have empty/dynamic assignments.
Examples include icons assigned by InventoryItem, UnitIndicator, and comparison
records at runtime. These are reported in `ngui-asset-audit.json`, not replaced
with guessed artwork. Their visibility still requires a Unity runtime check.

## UI transparency and clipping repair — 2026-10-22

The tutorial hand's triangular fragments and stripes were reproduced with the
actual recovered texture and shader on Unity 2018.3.0f2 / Direct3D 11. The source
`GuiAtlasCommon.png` has black RGB at zero alpha. `alphaIsTransparency: 1`
made Unity dilate neighboring colors into those pixels. The premultiplied shader
uses `Blend One OneMinusSrcAlpha`, so these colors were visibly added even when
alpha was zero. This is an import/shader contract defect; changing Editor
versions is not required for this repair.

The 44 textures referenced by premultiplied UI materials or loaded dynamically
by `AtlasPreparer` now preserve RGB, disable mipmaps, use bilinear filtering,
and import uncompressed. Opaque map textures may become RGB24; alpha-bearing
atlases remain RGBA32. This avoids atlas mip bleeding and compression fringes,
at the cost of larger GPU texture storage than compressed formats. Original
PNG bytes, sprite rectangles, identities and GUIDs are unchanged.

The six AlphaClip/SoftClip shader variants now match `UIDrawCall`'s existing
contract: `_MainTex_ST` transforms panel-local positions for clipping, while
atlas UVs remain unchanged; `_ClipSharpness` controls soft edges. The previous
shaders transformed atlas UVs and read `_ClipRange0`/`_ClipArgs0`, which this
NGUI runtime never supplies.

The two solid white header rectangles were a separate `GuiEffectShader` defect.
`UIReflectionEffect.SlicedEffect` supplies the moving highlight in UV2, but the
shader sampled both textures with UV0 and ignored the effect's alpha mask.
It now samples the effect with UV2 and multiplies both masks and vertex color,
preserving the existing reflection timing instead of hiding the widgets.

Verification:

- `UnityUiAlphaAudit`: 281,779 nonblack zero-alpha pixels before repair, zero
  afterward; GPU captures reproduce the reported hand artifact and remove it.
- `UnityUiClippingAudit`: all 44 real imports and six translated-panel clipping
  variants pass. Colored texture samples check that clipping does not alter UVs.
  A reflection check holds UV0 constant while moving UV2 between transparent
  and visible samples, proving the inactive overlay no longer draws a white box.
- `audit_ui_alpha.py`: checks material references plus runtime atlas paths;
  `--fix` repairs only the relevant metadata.
- Asset reference audit: 1,052 script targets, 288,258 references, zero broken
  references or missing scripts. The existing 17 unmatched sprite selections
  remain a separate source-data limitation.

The native audit scripts are in `Server/tools`. Copy them to `Assets/Editor` in
a disposable project and run `UnityUiAlphaAudit.Run` / `UnityUiClippingAudit.Run`
with a graphics device, never `-nographics`. Set `WAR_UI_AUDIT_OUTPUT` to an
artifact directory; the clipping audit reads `texture-paths.txt` there, containing
project-relative texture paths from `audit_ui_alpha.texture_paths()` without
the `.meta` suffix. The alpha audit deliberately restores the old bad import
settings before its before/after comparison, so never run it in the active Client.

`ClientBootSmoke.ps1 -RenderUi` also saves `lobby.png` and
`battle-preparation.png` from the normal account bootstrap and GUI navigation
against an isolated Backend. The default smoke remains headless.

The rendered boot run `client-boot-85fd20c38d8446a5bf50d3536cb96979` reached
account data ready without a blocking dialog. Its menu navigation exposed a
separate handled null exception: `TryGetNewArena` tried to expire an absent
offline Arena configuration. That path now returns without sending an expiry
request, preserving the closed Arena state and letting menu setup finish.
Rendered bootstrap verification now also requires zero logged errors, including
handled exceptions logged by `Crittercism`.
The lobby and battle-preparation captures were visually inspected; the header
rectangles and atlas fragments are gone. See [battle preparation](ui-rendering/battle-preparation.png),
[lobby](ui-rendering/lobby.png), and the isolated hand [before](ui-rendering/hand-before.png) /
[after](ui-rendering/hand-after.png) comparison. This verifies the shared fixes
and these rendered screens, not every gameplay screen or every locale.
The disposable Unity project was removed after verifying all 15,607 source
inputs were unchanged relative to the tested repair snapshot.

Final verification after the Arena guard:
`client-boot-dcf21799ec134cfe87e13b0824832881` passed with **zero errors and zero
exceptions**. It opens the normal battle-preparation screen, captures the daily
assignment notice, dismisses it through the existing `OnBack` handler and
captures the unobstructed screen. The archived images above reflect this final
run; `ui-rendering/boot-report.json` retains its non-secret result summary.
