# MainScene provenance reconciliation

EN01 in [missing.md](../../missing.md) remains open. The historical snapshot mismatch now has an
executable explanation; this is not approval of a refreshed combat-content release.

## Proven source transition

Commit `f9f63d037d3a62466e224559bd3154b325ec312c` restored the original LevelManager payload.
Its parent contains exactly the scene bytes recorded by the older content exports:

- Before: `d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
- After/current: `5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.

Both snapshots contain 51,581 serialized Unity objects with identical identities. Only MonoBehaviour
45847 differs: 66 weapon setup pointers, 24 ordinary behavior pointers, three additional behavior
pointers and the original zero/empty initial progression fields were added. The exact delta matches
[the original restoration record](level-manager-bindings.json), including the final separator.
Every other byte, including the scene preamble, is preserved. This is not a line-ending difference.

The existing `restore_level_manager_bindings.py` was run without `--apply`. It reread the original
APK/OBB and managed assembly evidence, resolved all 93 pointers, and reported `changed: false`,
`applied: false`. No Client scene, prefab, library, catalog or gameplay source was changed.

The new auditor re-extracts the existing mission reader's values in memory: all 75 missions, five
mission map entries and five boss map entries equal the stored catalog. This establishes those
values only. It does not prove that all other exports or runtime-derived observations are unchanged
when LevelManager now receives its original bindings.

## Executable report and regression checks

```powershell
python Server/tools/test_main_scene_provenance.py
python Server/tools/audit_main_scene_provenance.py --check
```

The eight tests include unrelated-object and preamble changes, changed restored pointers, duplicate
objects/pointers, new objects and transitive artifact references. They recompute fixture hashes before
checking modified scenes, so a failure is not merely an unchanged-hash assertion.

The audit compares the real scene against both Git snapshots and the restoration record. It refuses
an unexplained newer scene rather than treating all later scenes as equivalent. Running without
`--check` prints deterministic JSON to stdout; it never updates source/content/report files itself.

[main-scene-provenance-audit.json](main-scene-provenance-audit.json) inventories 52 content JSON files
that directly reference the historical scene and 61 affected files including transitive SHA-256
dependencies. The scan covers current top-level `Server/content/*.json`; it is a dependency inventory,
not a proof that embedded resources, non-JSON references or external deployment packages are complete.
Byte-identical artifacts retain every referring path. The report explicitly sets `releaseVerified: false`.

The report is a historical-input audit. `--check` passing must not replace the still-failing mission,
score-streak, bonus or other source checks in the release checkpoint.

## Remaining release work

The [typed sheet audit](BATTLE_SHEET_VALUE_AUDIT.md) found 390 value differences in the existing
export, independent of this scene transition. The export precision defect is fixed in its producer;
corrected content has not been published. A digest-only refresh would preserve these old differences.

1. Classify each affected artifact by producer: static serialized extraction, native/managed runtime
   observation, derived package manifest, local match template or embedded catalog profile.
2. Re-extract static values from the current scene and compare semantic fields with the old release.
   Preserve the old report as provenance. Changed values require behavioral review, not just new hashes.
3. Re-run affected runtime exporters in an owned reusable Unity project where restored LevelManager
   initialization can affect the observation. Do not infer runtime equivalence from unchanged YAML blocks.
4. Publish the validated artifact set together with updated dependent manifests, templates and embedded
   release profiles. Inventory code/tests/docs that pin those revisions; preserve exact wire identities.
5. Run the complete source checkpoint and the relevant build, simulation, native and Client gates for
   the resulting content revision. Only then close EN01/C12/V07 as their individual scopes permit.

The current increment adds audit tooling and bounded evidence only. No production digest was changed,
no source check was bypassed and no new Unity project or Mongo database was created.

## Static mission candidate staging

The first three producers now expose explicit document builders. Their original command-line
extraction/check behavior remains; the mission command also rejects unknown arguments before any write.
The staging tool passes newly extracted mission and bot documents directly to their dependents,
without temporarily replacing files under `Server/content` or modifying module path globals.

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/tools/test_mission_content_candidates.py
python Server/tools/stage_mission_content.py
```

The stage first requires the current provenance report and exact historical production preimages.
It then re-extracts the current scene and compares every top-level value, including nested JSON
types. Boolean false cannot pass as numeric zero. Only these exact provenance differences are allowed:

| Candidate | Allowed changed fields | Unchanged gameplay values |
| --- | --- | --- |
| recovered-mission-catalog.json | sourceSha256 | 75 missions, five maps and five boss maps |
| recovered-coop-bot-rules.json | missionSourceSha256 | 15 source BotMission definitions |
| recovered-coop-bot-health.json | sceneSha256, botRulesSha256 | 44 PLAYERHP values and 15 boss health rows |

Ten tests cover all candidates, transitive staged-byte binding, historical scene reproduction,
mismatched input snapshots, altered rewards, added schema fields, numeric/Boolean confusion,
unrefreshed output and unknown staging arguments. The historical source reproduces all three
existing documents, including the original dependency digest, after the producer refactoring.

Successful candidates total 166,260 bytes and live under one managed `mission-candidates-*` run with
normal retention. `results.json` binds previous/candidate/producer hashes, the scene and the audit
report; its `releaseVerified` and `productionFilesWritten` fields remain false. No Unity project,
Library copy, database or additional content tree is created.

These three candidates are ready for the later coordinated release, not installed production data.
The other affected artifacts and runtime observations still need their own source verification.
The original source checks deliberately continue to reject the old production snapshot.

Final managed staging run: `mission-candidates-02d39792198b4504b151724ea9bb5d1a` under the external
`WarFriends/ServerTests/test-runs` root. It finished with status `passed`. All ten candidate tests
and eight transition tests passed. The three original production `--check` commands still exit 1
for their historical scene mismatch, confirming that no check was weakened to admit stale content.
