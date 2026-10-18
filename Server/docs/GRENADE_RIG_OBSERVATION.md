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

The BattleServer embeds and hash-verifies this artifact. `GrenadeShotTargetCatalog` loads the
observed rig and checks target identities against combat authority. The common runtime grenade
pose now exposes all weapon roots, full target poses, and the type-16 moving target. Sampling uses
the existing 30 Hz floor/clamp clock and float clip lengths, including the final short sample.
Placement uses captured root transforms; Unity matrices are transposed for System.Numerics.
The flat observed node list is not treated as a parented skeleton or used for procedural blending.

The recovered LongShot rule reads the weapon's current transform at kill time. The existing
mixed-combat query can now obtain that root while a grenade is selected; it does not substitute
a launch-time position. The [delayed rifle host scenarios](MIXED_GRENADE_LONGSHOT.md) now verify
lethal contacts during FRAG selection with one long-range award and one non-award comparison,
including private terminal evidence. Rendered Unity gameplay remains outside that proof.

Verification after runtime integration:

- Release rebuild: zero warnings and errors.
- `--grenade-pose-view-only`: 49,144 checks, including every observed weapon/target position and rotation.
- `--mixed-grenade-host-only`: 13 checks.
- `--mixed-grenade-udp-only`: 12 checks with two signed SDK peers.
- UDP artifacts: `.local/mixed-grenade-udp-7a31e9cb6bf642dc9fc66ceb9f91429b`.

The focused grenade regression suite also passed 28,935 checks before the final rotation assertions
were added. This is not a new full native-suite result; the complete BattleServer suite was not rerun
for this checkpoint.

This Editor observation does not prove original Unity 5.2.5f1, Android, rendered gameplay, or
two running Unity Client parity. The broader BattleServer checklist remains incomplete.
