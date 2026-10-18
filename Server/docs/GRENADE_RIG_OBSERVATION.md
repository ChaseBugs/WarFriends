# Grenade rig observation

`content/recovered-grenade-rig.json` records actual Unity transforms for all 66 weapon roots,
the player root, and all five gameplay shot targets across 12 grenade-family clips and 289 frames.
The moving target is the existing type-16 target; its position was already available in the older
target artifact. This observation supplies its rotation and matrix as well as weapon-root transforms.

The SHA-256 is `842f1a0afe05f1d4065f3f5092aefe4f84baa8c8cd169dd7a136e2fbd7cb8365`.
Matrices are captured Unity `localToWorldMatrix` values in row-major field order, not reconstructed
from positions or assumed unit scale. These are observed nodes, not a complete skeleton hierarchy.

## Source and validation

`tools/UnityGrenadeRigExport.cs` ran in a disposable project with Unity 2018.3.0f2, without starting
gameplay or saving MainScene. It requires all source weapon identities, inventory indexes, and paths
to agree with the reviewed binding graph before exporting. It samples the same T-pose reset and
30 Hz grenade clips used by the existing shot-target exporter.

The current MainScene hash is
`5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.
The older target and binding artifacts retain their original scene hash
`d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
The new artifact records both identities explicitly. Restored LevelManager references are not a
reason to relabel historical observations as having come from the current scene.

Run from the repository root:

```powershell
python Server/tools/validate_grenade_rig.py Server/content/recovered-grenade-rig.json
```

The validator checks pinned binding and target inputs, the active scene and animation file hashes,
all 66 binding identities, all clip metadata and sample times, finite transform components,
unit quaternions, affine matrix translations, and exact equality of all 1,445 target positions
with the prior artifact. The published observation passed these checks.

## Verified boundary

This is source data for the remaining grenade common-pose integration. Runtime pose interpolation,
weapon-root queries during grenade selection, and delayed rifle LongShot evaluation do not yet
consume this artifact. The recovered LongShot rule reads the weapon's current transform at kill
time, so a launch-time weapon position is not a substitute.

This Editor observation does not prove original Unity 5.2.5f1, Android, rendered gameplay, or
two running Unity Client parity. The broader BattleServer checklist remains incomplete.
