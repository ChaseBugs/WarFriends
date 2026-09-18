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
