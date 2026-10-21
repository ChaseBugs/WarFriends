# Source sheet values and float export correction

EN01/C12 remain open. Comparing actual values revealed a separate export defect, not just the
historical MainScene digest change. [The report](battle-sheet-value-audit.json) records 78,955
scalar fields across 132 sheets. It compares each declared C# field type with its unique scene
component, decodes initialized ObscuredInt/ObscuredFloat values and compares floats as binary32.
The explicitly empty Squads table retains its closed state.

## Findings

Heavy Turret's historical scene pin is now replaced by a required manifest-provided expected scene,
with lowercase SHA-256 shape validation. Geometry, target and balance checks remain exact. Release
build passes with zero warnings/errors; eight weapon packages and positive/wrong-scene checks for
Land Mine and Heavy Turret pass. Full diagnostic
`combat-candidate-audit-6e3a60a44eb74558bbfd0d0cd09bab4e` now fails at Mortar pool's hardcoded
whole-file revision. Its replacement must bind a reviewed release revision across Backend and Worker;
the integrity check must not be dropped. Managed retention now runs after diagnostic completion.

Native pose run `pose-recapture-3e0f80e9d05f4f9f9644edcd7b020cd6` passes both original grenade and
player pose exporters in one owned import. Every sampled field and animation identity matches the
old documents except current scene provenance. All 15,599 source/package inputs remain unchanged;
temporary data was removed. Shared batch preparation preserves recorded success-exit substitutions
for weapon and pose runners. Three batching and two strict pose tests pass. The retained outputs
must still be bound into candidates before the grenade and full-combat manifests can be published.
This samples Unity 2018.3 reference animation; it does not prove normal gameplay or original 5.2 parity.

The Minigun schema difference below is now resolved by explicit native composition. Run
`weapon-family-recapture-93b8eed0ee2244cca18f167ad41c7dd4` executes all-weapon plus nine family
exporters in one import. `compose_minigun_binding.py` requires identical source/player identities
and every shared weapon field, then adds only `setupType`, `ammoSetupType`, `weaponComponents`.
Raw reference-pose fields remain in the native output; the composed document retains the runtime
schema. All nine family packages match existing values except scene provenance. The run verified
15,599 unchanged inputs and removed its temporary project. Five composition and three batching
tests pass. Retained-evidence integration and production manifests remain pending.

Family batch run `weapon-family-recapture-e2af4a0ecbae4823be34bf2abefb636c` produced all nine native
outputs in one import and revalidated 15,599 unchanged source files. Eight outputs match existing
values except scene provenance. Minigun correctly fails exact comparison: its original family
exporter includes `muzzlePosition`, `muzzleRotation`, `motorPath`, while the packaged artifact instead
contains `setupType`, `ammoSetupType`, `weaponComponents`. Those latter fields exist in the separately
verified all-weapon identity export. A reviewed composition must bind both native inputs and preserve
their full evidence; it must not fill gaps from old production values. The failed owned run retains
its project and raw outputs. Three batch tests pass; production and staged family catalogs remain
unchanged. Original Client scripts were not edited; only copied success-exit calls were replaced,
with original/prepared exporter hashes and the batch wrapper retained in the run.

Native all-weapon capture `weapon-recapture-74716ddc1e2246c8a524de5ae28d0355` passed using the actual
`SelfHostedAllWeaponExport.Run` against unmodified current MainScene. All 66 full records match the
old export except scene provenance. Its raw output SHA-256 is
`f77374b540193f23df1a7b3f5e7e4b265a1990a761d3296bc2ea98fc49ec4be6`.
The runner revalidated 15,599 source/package files, retained output/inventory/logs, and removed the
temporary project. Five weapon comparison tests and three existing capture tests pass. The export
now binds into the candidate chain as described below; individual weapon-family outputs
and production manifests remain unresolved. Unity 2018.3 identity capture is not original Unity 5.2
or full gameplay verification.

Latest candidate verification: `sheet-candidates-52708cf7f5aa4c5b8518017a008c4af6` passed with
67 dependent artifacts, including twelve mission/scene-chain artifacts and retained native evidence for
120 boss routes. Production files were not written, temporary run data was removed, and
`releaseVerified` remains false.

V14 also requires `CoopAssaulterWeaponRevision`, validated and included in package identity by both
Backend and Worker. V13 keeps its historical identity. The Assaulter loader preserves exact firing,
prefab and geometry rules while distinguishing the reviewed SoldierBehaviour visual-loader source
transition. Six generator tests pass; Release build has zero warnings/errors. Both v13/v14 focused
loaders accept valid inputs and reject wrong Assaulter scene/artifact hashes. Full diagnostic
`combat-candidate-audit-18c3d71503ea4311a55c0c6d98550fbe` next rejects the historical air-geometry
inventory pin. Shared collider loaders and dependent native geometry still need coordinated binding.

The candidate combat manifest is now version 14 and explicitly binds `MortarWeaponPoolRevision`.
Backend and Worker share version resolution and include the selected pool hash in package identity.
Legacy v13 retains its reviewed fixed pool hash; v14 requires an explicit canonical SHA-256. Five
generator tests pass. Release build has zero warnings/errors. Production v13 and candidate v14 pass
the eight weapon loaders, Backend rifle catalog and deployable scene/hash guards. Full diagnostic
`combat-candidate-audit-4c2fed579c09496992667dd813e46995` passes Mortar and next rejects co-op
Assaulter's historical artifact pin. Runtime release readiness remains unproven.

The full combat diagnostic exposed a packaging defect: indenting native player poses expanded
37,316,975 bytes to 106,655,667 bytes, exceeding the production 48 MiB limit. Candidates now preserve
the exact verified native bytes. Land Mine also used a hardcoded historical scene hash; its loader
now requires the manifest's valid expected scene and rejects mismatches. Release build has zero
warnings/errors; eight weapon loaders and positive/wrong-scene Land Mine checks pass. Four pose and
three overlay validation guards pass. Diagnostic run
`combat-candidate-audit-3d549a954284425e8ea4e88621842d71` reaches Heavy Turret and rejects its
equivalent historical scene pin. This is an unresolved full-loader gate; failed overlays retain logs
and input inventories. They are diagnostic combinations, never publishable release packages.

This total includes 51 changed candidates and 16 byte-identical dependency copies. The combat
manifest now resolves every direct dependency by its original pinned hash, selecting a reviewed
candidate where available. Source-audit-affected dependencies may never fall back to old bytes.
Four tests cover exact binding, absent affected candidates, changed pinned bytes and mixed scenes.
Complete `BattleCombatContent.Load` also consumes auxiliary files outside the manifest; assembling
and validating that full runtime package remains open. No new native proof is claimed for copied files.

The player shot-target producer now accepts explicit scene bytes and reconstructs both gameplay and
rendering players' ten targets. All fields except scene provenance match existing content exactly.
Twenty-eight mission/scene tests pass, including historical reproduction and a changed-coordinate
rejection. Serialized reference positions are not proof of animated projectile collision authority.

Both native pose documents and the Grenade manifest are included through `--pose-run`. Four pose
evidence tests and five manifest tests pass. Actual retained-evidence rebinding reproduces both pose
candidate byte streams. Release build passes with zero warnings/errors; all eight production weapon
loaders accept these candidate packages, including Grenade's pose dependency. The full combat
manifest and other pose-derived artifacts remain pending; this is not complete gameplay proof.

Seven simple weapon manifests now bind exact candidate stat/binding bytes and one scene hash.
Four generator tests reject missing candidates and mixed snapshots. The Release battle-test build
passes with zero warnings/errors; `--weapon-candidate-path` successfully loads all seven packages
using production C# loaders. Grenade and the full combat manifest still need additional dependencies.
These checks do not prove complete numerical gameplay parity or authorize coordinated publication.

All nine weapon family packages are now included through `--weapon-family-run`. The binder repeats
full source inventory checks, validates original/prepared exporter hashes, checks native outputs
against captured hashes and current package values, and reconstructs Minigun from raw native inputs.
Five integrity tests pass. Actual retained-evidence rebinding reproduced every family candidate
byte stream. Evidence includes the raw outputs, source inventory, preparation report, wrapper and
Minigun composition, so the original capture can be pruned without losing the candidate's evidence.

This stage includes native all-weapon evidence for 66 records. `--weapon-run` accepts a completed
capture or a stage retaining `weaponEvidence`; both revalidate the entire current input inventory,
native output hash, exact scene binding and typed weapon fields. Actual retained-stage rebinding
reproduced the candidate bytes. Five evidence guards and eight capture/validation tests pass.
The retained output, inventory and report survive normal pruning of the original capture.

The prefab collider producer now accepts explicit scene bytes, retaining its original CLI source
pin. It re-extracts 32 prefabs, 128 collider records and 14 WheelCollider counts. Staging allows only
`mainSceneSha256` to change; geometry, flags, transforms, pool references and source hashes remain
exact. Twenty-five mission tests pass, including historical reproduction and a changed collider flag.
Prefab-local shapes do not establish animated world hitboxes or authorize projectile hits.

The six existing Unity-exported prefab meshes now bind the exact staged collider bytes. Their 176
vertices and 284 triangles are retained only when source asset hashes and complete collider values
remain unchanged. Boolean vertex coordinates are rejected alongside invalid triangle indexes.
Twenty-seven mission regressions pass. This is verified reuse of an existing native export, not an
independent compressed-mesh decoder or a new runtime hitbox proof.

The co-op detail producer now checks every native tile against the stored decoded geometry before
changing only `sourceManifestSha256`. All 655 tiles, 5,693 polygons and 26,081 detail triangles
match. Twenty-four mission regressions include last-tile corruption and missing tiles in binary
and YAML assets. Existing build settings remain bound to the unchanged artifact hash; they were
not independently reconstructed. This establishes data consistency, not new Unity surface-selection,
pathfinding or complete gameplay proof. Remaining implementation gates are tracked in
[EN01](../../missing.md#en01--resolve-source-provenance-before-content-release).

There are 390 differences: 386 ObscuredFloat values and four BotNames strings. No gameplay value
has been changed in production content by this increment.

`SelfHostedBattleExport` previously converted boxed ObscuredFloat through `ToString()` followed by
`float.Parse`. The recovered struct's ToString calls the decrypted Single's default formatter.
Unity 2018.3 Mono rounds that text to seven significant digits. For example, Assaulter row 134 HP
changes from binary32 `1908.5103759765625` to `1908.510009765625` after the string round trip.

The exporter now uses the original `(float)(ObscuredFloat)value` conversion directly. ObscuredInt
also uses its direct conversion. This changes only the Editor export utility; no gameplay controller,
scene, prefab, GUID or server catalog was rewritten. Future exports must undergo coordinated source
and behavior validation before replacing the old content and its dependent hashes.

The four string differences now have a reproduced Unity import cause:

| BotNames row index | Serialized scene value | Existing exported value |
| ---: | --- | --- |
| 182 | `ˇvampireˇ66` | `ˇvampireˇ` |
| 205 | `spooked°,°kitty` | `spooked°,°kit` |
| 231 | `sneaky§thisguys` | `sneaky§thisguy` |
| 240 | `brown(‿ˠ‿)mailr` | `brown(‿ˠ‿)` |

The scene transition audit proves these blocks did not change with LevelManager restoration.
[Original package verification](bot-name-source-audit.json) independently decodes the complete
7,392-byte BotNames payload, verifies its MonoScript identity, both 269-entry arrays, row order,
strict UTF-8, zero alignment and exact end of payload. Every current scene string matches the
original APK/OBB evidence. The original Unity version is 5.2.5f1.

`probe_bot_name_import.py` creates a tiny owned Unity 2018.3 project with two prefabs and two scripts.
The plain fixture retains the scene's exact Rows text. The escaped fixture represents the same
269 strings as ASCII escaped, quoted YAML. Native AssetDatabase import reproduces exactly the
four existing truncations for plain YAML and zero differences for escaped YAML. This diagnoses
the 2018.3 import path; it is not a full game or original Unity 5.2.5 runtime verification.

Run `bot-name-import-250b9b1240de4a55bfa6fa0b084120ba` passed with source, original-package, probe
and Editor hashes in its retained results. Its temporary project and Library were removed by the
managed run lifecycle. No production scene, prefab or catalog was changed. Six decoder regressions
cover Unicode byte lengths, header/trailing bytes, array/length bounds, UTF-8, alignment and row order.
The original-source report remains explicitly `releaseVerified: false`.

`prepare_bot_name_import.prepare_scene` now supplies the native probe's escaped input. It returns
bytes in memory for a disposable export project, never writes the active scene, and changes only
the four unquoted Unicode NAME lines. It validates the 269 ordered row identities and exact schema,
checks semantic equality of the complete component, retains existing quoted strings and the BOM,
and leaves every other scene byte unchanged. Four regressions check the exact changed lines,
idempotence, BOM preservation and missing/duplicate component rejection. The native probe verifies
the output of this production-input preparation function rather than separately rebuilding all rows.
The full battle recapture runner still needs to adopt this preparation and record both original and
prepared input hashes; a prepared-scene hash must never masquerade as the original source identity.

```powershell
python Server/tools/test_bot_name_source.py
python Server/tools/test_bot_name_import.py
python Server/tools/audit_bot_name_source.py --check
python Server/tools/probe_bot_name_import.py --unity `
  'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe'
```

## Verification

```powershell
python Server/tools/test_battle_sheet_values.py
python Server/tools/audit_battle_sheet_values.py
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/tools/verify_mono_float_export.py --editor-data `
  'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Data'
```

The value audit prints JSON and exits **1** while differences exist. It is a refusal, not a green
release gate. It requires PyYAML and never rewrites source or catalog files. Eight small regressions
cover encrypted decoding, malformed initialization, duplicate YAML keys, string spelling, scalar
types, non-finite values and integer width. Original schema bytes are recorded in the report.

The Mono probe compiles a small console executable and loads three original managed dependencies:
Assembly-CSharp-firstpass, UnityEngine and Newtonsoft.Json. It executes the original ObscuredFloat
conversion and ToString operators. For all 386 source values, the old formatting path reproduces
the exact old exported bits, while direct conversion and the original Newtonsoft JSON round trip
preserve every source bit. Neither a copied conversion algorithm nor a tolerance comparison is used
for that runtime proof. The Python seven-digit classification is only an initial explanatory hint.

The same runner compiles the actual edited exporter against Unity 2018.3 Editor/engine references
and original game assemblies. This is exporter compilation and managed scalar execution, not a
Unity scene export or a full game build. No Editor process, Asset import, Library copy or database
is started. The owner's existing Unity process remains untouched.

Run `float-export-3b76ab391d424f07b516d4dd417d668b` passed both checks. The managed run retains bounded
logs/results and removes its temporary executable and three copied DLLs on success. Its report
includes probe/compiler/runtime/exporter/audit/reference-assembly hashes. Three old-library files
are isolated from the original directory so its older mscorlib cannot replace the Mono host runtime.

## Remaining work

### Combat precision boundary checks and army deployment candidate

`ContentPrecisionBoundaryTests` now exercises the real VehicleHealthState and AirEntityHealthState
with all 386 reviewed numeric corrections: 28 HP inputs and 358 damage inputs. Each uses a synthetic
target at the old/new representable-value boundary. The real vitality owners distinguish surviving
from dead rather than hiding the difference behind an epsilon. Both owners agree on remaining HP.
This proves sensitivity of shared scalar application; it does not prove every unit's attack routing,
modifier stack, animation/collision callback or full match outcome after changing the catalog.

```powershell
dotnet build Server/tests/War.Battle.Tests/War.Battle.Tests.csproj -c Release --no-restore
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --content-precision-only
```

The Release test build passes with zero warnings/errors and all 386 boundary cases pass. The new
focused checkpoint selector is `content-precision`. Existing test-argument refusal checks also pass.

Army deployment extraction now accepts explicit scene/content bytes. Stage
`sheet-candidates-7d990f5d337f4cf6b2e22aa63a4dffff` includes this fifth direct dependent alongside
the profile, score policy, bonus catalog and unit rules. All 24 family identities, options, cooldowns,
power, base shots and agent settings remain exact. Eighteen movementSpeed JSON values use longer
decimal spelling but preserve binary32 bits. The artifact retains its required CRLF encoding.
Eight dependent tests pass, including changed movement-bit rejection and CRLF preservation.
Unknown CLI arguments are rejected before source reads/writes. No production battle catalog or
deployment artifact was replaced by this increment.

### Full native recapture

`recapture_battle_content.py` now runs the actual `SelfHostedBattleExport.Run` in an owned copy of
Assets, Packages and ProjectSettings. It does not copy the asset database, compiled assemblies or
shader cache from the existing Library. Cached package source dependencies are copied separately.
The prepared MainScene preserves source values while escaping the four affected name lines.

Native run `battle-recapture-3d0e18dd6ba14280a035f6c83abaf1bb` compiled the three game/Editor
assemblies without C# errors and exported five maps and 132 sheets using Unity 2018.3.0f2.
Every typed sheet value matches the original-source reader. Map and mesh JSON values and sheet
identity/order exactly match existing content. The 5,983,286-byte raw native result retains its
actual prepared-scene hash; the original source hash is recorded separately. Its SHA-256 is
`43d25e9fc6610afe3ae98da6ec74ee0eaa43376a1686e3d3d44badee7d496889`.

Post-capture verification checked every inventoried original input remained unchanged. This first
run inventories Assets/Packages/ProjectSettings; subsequent runs also hash copied package-cache
sources and the Editor executable. Raw native output and verification reports are retained externally.
No production file was published and no original Client asset changed. Export success is not Play
Mode account bootstrap, a starter-loadout re-observation or normal two-player gameplay verification.

Successful cleanup initially encountered read-only package documentation. The shared owned-tree
cleanup now retries only read-only regular files within the already checked boundary; other access
errors and linked paths remain rejected. After confirming both recorded Python owner and Unity child
had exited and verifying the native result hash, this run's finalization was recovered and its
remaining 44,047,123 temporary bytes removed. `finalization-recovery.json` records that recovery;
the ownership manifest retains its exact validated schema and passed status.
All three native-result guard tests and 22 artifact lifecycle tests pass, including a real read-only
file fixture. The temporary project/Library no longer exists.

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/tools/recapture_battle_content.py --unity `
  'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe'
python Server/tools/test_battle_recapture.py
```

The native output now provides evidence for coordinated candidate publication. Remaining gates
include the separate prepared/original provenance binding, dependent calculations and all dependent
artifact regeneration/verification; the unit observation mismatch is not resolved by this export.

### Complete sheet candidate staging

`stage_battle_sheet_content.py` reuses the typed source reader to extract every cell in all 132
sheets. It requires the current reviewed audit, independently rechecks original BotNames evidence,
and rejects differences outside the explained float and name defects. It verifies every resulting
cell and preserves map/mesh/native observations and sheet identities/order. JSON float text may use
the exact binary32 expansion; equality is checked in the declared source type, not text precision.

Five regressions cover all 390 corrected values, unchanged native geometry, stale input binding,
unexplained changes, missing original-name proof and an incomplete reviewed difference set.
The shared scalar-reader regressions also pass after extracting the reusable reader.

```powershell
python Server/tools/test_battle_sheet_candidates.py
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/tools/stage_battle_sheet_content.py
```

Run `sheet-candidates-06b6fb47001b463ca7a5830b6bd7a593` retains a 6,045,583-byte candidate and
bounded report under the managed external root. Source/prepared scene hashes are separate;
the temporary prepared scene is removed on success. Producer/helper/schema/package hashes bind
the inputs. `releaseVerified`, `productionFilesWritten` and `nativeGeometryRecaptured` are false.
This is a complete source-sheet candidate, not a full native battle export. Existing geometry
evidence is carried forward without recertification; coordinated publication remains closed.

### Army perk dependency staging

Run `sheet-candidates-13d94cdc51224f249bf84fd93fe44cab` retains verified native evidence and the
current starter observation, and stages six dependent catalogs. `extract_army_perks.py` now builds
from explicit scene, battle-content and deployment bytes. It requires all three scene identities to
agree, records exact candidate byte hashes, rechecks disk-backed source files and uses a fresh source
collector for each build. Its previous process-global collector could carry state between calls.

All 24 ordered perk families remain identical, including elite coefficients, recipes, selectors and
affected unit identities. Only the deployment scene binding and the three reviewed dependency/tool
hashes change. Staging rejects other source or gameplay changes. Twelve dependent regressions pass;
they cover exact dependency binding, mixed scene rejection, independent repeated builds, altered
gameplay and unknown CLI arguments. The production `--check` intentionally fails on mixed snapshots
without writing content. This is candidate preparation, not coordinated release publication.

### Direct dependent staging

Run `sheet-candidates-6c88ea0abf384ba6bd30afda96a77678` adds the co-op NavMesh source manifest as
dependent 26. The builder uses explicit mission bytes and checks all five ordered scene stages,
scene digests, unique NavMesh GUIDs and supported asset formats. Source and packaged native assets
are compared byte-for-byte and against each manifest hash before staging. All map/asset fields remain
exact; only missionSourceSha256 changes. No native assets are copied, replaced or rebaked.

Twenty-two mission regressions pass, including retained source/package equality, corrupted package
bytes, stale scenes and reordered stages. The derived co-op detail/triangulation/path artifacts and
full movement proof remain separate release gates. The completed run retains native evidence and
cleans temporary data without publishing production content.

Run `sheet-candidates-cd1604d951234a50875fad0e1d60e38b` adds the Mortar weapon pool as dependent
25. Its explicit scene/deployment inputs must agree. Source pool capacity remains four and the
per-owner deployment limit remains two; allocation order, delayed weapon-return rules and normalized
source hashes remain exact. Only deployment.revision and deployment.sceneRevision change.

The builder requires an actual integer deployment count and conservation of the two-player pool.
Forty-one dependent regressions pass, including changed return policy, fractional/Boolean counts,
over-allocation and mixed snapshots. The stage does not change runtime pool behavior or certify
full multiplayer exhaustion/recovery. Native evidence is retained and production content is unchanged.

Run `sheet-candidates-47eea05ec369404e8dea2d1313d87bd8` adds Land Mine and Heavy Turret sources,
bringing the candidate to 24 dependents. Both builders consume explicit scene/content bytes and
recheck referenced map/prefab data. Mine values are unchanged except the nested scene hash; duplicate
damage constant definitions are now rejected instead of silently overwriting an earlier row.

Turret behavior provenance changes, plus four decimal expansions in stats: row-zero DAMAGE and
row-one HP, DAMAGE and REALSHOTPROBABILITY. Each old/new pair has identical binary32 bits. Only
these four float-typed fields can normalize for comparison; changed bits, other gameplay changes,
map or prefab differences are rejected. Thirty-eight dependent regressions pass. No runtime authority
or production content is published by this stage, and complete deployable behavior remains separate.

Run `sheet-candidates-f1327cab8b7d4ad68ba9ca806c0b4980` adds the co-op Assaulter rifle as dependent
22. Its builder accepts explicit scene bytes, resolves the normal/card inventory owner and rifle
GUID, rereads muzzle/projectile prefabs and checks the recovered cadence, launch, bullet-setup and
critical rules. Every gameplay field remains exact. Only the scene digest and the already reviewed
base SoldierBehaviour hash transition change; both Rusher and Assaulter validation share that pair.

Thirty-five dependent regressions pass, including flight/cadence preservation, changed source or
inventory rejection, and non-writing unknown-argument refusal. The stage retains verified native
battle/boss evidence and cleans temporary data. This is configuration preservation, not proof of
complete normal Client combat or co-op execution, and production files remain unchanged.

Run `sheet-candidates-751e7b3b578540b8968658d637f3305c` adds Rusher weapon bindings as dependent
21. Explicit scene/content/deployment bytes must agree. Eight families retain inventory references,
windups, cadence values, shotgun falloff and ability rules; five-map Warper relocation is unchanged.

The first strict comparison rejected four stale cadence-source hashes. Review traced them to
`d44cbdbd89e54d18bdf7f8013ee15e6cf767e727`: four visual-loading coroutine calls were wrapped in
BattleResourceLoadScope; cadence logic was untouched. The parent SoldierBehaviour.cs with CRLF
reproduces `26568579f6b4e7994b5a2266009de3e5ccb42e41169546056f71ffe5acb7ae39`; current LF bytes hash
to `d3da6f858f06c325ace44acb654163df0a47ed6c278b36b3b559c2801d03dccd`. Only this exact transition
for four base-cadence references is accepted alongside the scene refresh. Other source/schema/value
changes remain rejected. Thirty-two dependent tests pass, including altered cadence, unknown source
revisions and non-writing CLI refusal. No production content or Client source was changed.

Run `sheet-candidates-13c664d3c4b248e38f22f264d2613ccc` adds air-unit geometry as dependent 20.
The producer rereads Helicopter, assaultHelicopter and dronePrototype prefabs, resolves their script
and mesh identities, and derives the same hierarchy, rest transforms, colliders and shootable targets.
Every non-dependency field compares exactly with production. Only deploymentSource.sha256 changes;
the artifact's pinned CRLF is retained. This is static prefab evidence, not dynamic collision parity.

Explicit deployment bytes bind the staged dependency. Duplicate air-family coverage and non-Boolean
classification are rejected, and unknown CLI arguments fail before extraction/writes. Twenty-nine
dependent regressions pass, including exact geometry, source mesh hashes, dependency binding, line
endings and changed collider rejection. Native battle/boss evidence is retained and revalidated.

Run `sheet-candidates-b1860d44292f43a583542573c877d82a` adds soldier enemy-point masks as dependent
19. The producer consumes the staged deployment and exact scene bytes and rejects mixed revisions.
All 16 soldier identities/masks and sniper distance six remain exact. `SoldierBehaviour.AcceptsPoint`
uses this mask together with fraction and corner restrictions; the artifact retains only its existing
serialized configuration, without claiming complete runtime point-selection parity.

Duplicate soldier component/unit identities cannot satisfy coverage by count, and classification
requires a real Boolean. The CLI rejects unknown arguments before writes. Twenty-six dependent
tests pass, including source-preserving comparison, changed masks, duplicates, classification types
and mixed snapshots. The integrated run revalidates retained native evidence without a Unity launch.

Run `sheet-candidates-9e3664ada69e4d3785f9c9e630a6b584` adds initial mission shield states as the
eighteenth dependent. `MissionDefinitionShieldState` supplies default ratios of one and enabled
regeneration/automatic repair; `Mission` applies the ordered player/bot lists. All 75 candidate rows
retain their previous values and JSON types. Only the reviewed MainScene source digest changes.

The producer accepts explicit scene/catalog bytes, requires all 75 missions and checks each DATA
digest before extracting states. Its CLI parses arguments before writing and supports a read-only
check. Twenty mission regressions pass, including defaults, malformed ratios/flags, incomplete
catalogs and altered DATA. Native battle and boss-path proofs are revalidated from retained evidence;
no Unity copy or launch is needed. The damage/repair lifecycle and full content release remain open.

Run `sheet-candidates-12b96d7e005f4496aae18cb5f66b2a16` binds the native boss capture and includes
17 dependents. The optional `--boss-path-run` accepts either a completed capture or a completed
sheet stage retaining its evidence. It rejects active/failed runs and links, validates the exact
source inventory and current bytes, requires identical candidate anchor/navigation inputs, checks
raw and candidate hashes, repackages every route and permits only the reviewed anchor hash change.

Four retained evidence files keep the native output, anchors, navigation and original report with
the staged candidate. Their hashes are checked again when a later stage reuses them. Actual rebinding
from this retained stage reproduces the candidate bytes and all 120 routes. Six synthetic binding
regressions and five packaging regressions pass. Temporary data is removed and production content
is unchanged. Complete release and normal Client movement verification remain open.

### Minimal native boss-path recapture

The missing historical raw path output is superseded by actual managed capture
`boss-path-capture-6410b987bf5d4e0295c23bccd4eb2159`. `capture_boss_paths.py` constructs a small
Unity 2018.3 project with one Editor script and five original NavMesh assets plus their metadata:
971,149 copied asset/meta bytes. It does not copy Client scripts, scenes, packages or Library.
Current map digests and asset hashes are checked, and all source bytes are rechecked after capture.

Unity independently samples the eight current anchors per map and calculates all 24 ordered
same-side paths per map. All 120 packaged routes exactly reproduce the previous route payload;
raw output SHA-256 is `84b0edf3fd9e9d7e5c2d41e0c417588e315f2fd729a94bcb57edc59e8addb56a`.
The run retains raw output, input points, anchor/navigation bytes, candidate and source hashes;
successful cleanup removes the whole disposable project. Five synthetic packaging regressions
separately reject missing/partial routes, changed endpoints and Boolean coordinates.

This is a native query proof for the recovered NavMesh assets under the recorded tooling version,
not a rendered Client movement test or original Unity 5.2 runtime proof. Combined release staging
still needs explicit binding to this completed capture; it remains at 16 dependents for now.

Run `sheet-candidates-3dd47f411f4747ff84c7aecef33743af` adds boss anchors: six mission artifacts and
16 total dependents. Five distinct multiplayer scenes are checked against their mission digests
before extracting all eight ordered defend positions per scene. All 40 positions, rotations and
serialized identities remain exact; only the mission source digest changes. Seventeen mission
regressions pass, including duplicate-map and stale-map rejection and historical reconstruction.

The next boss-path gate is explicit: `package_coop_boss_paths.py --check` fails because its raw
`Server/.local/coop-boss-path-output.json` is absent. A filename search found no replacement under
Server/.local or the external managed run root. The existing packaged route catalog was not used to
fabricate an independent Unity observation. Restore verified raw evidence or capture routes again
before adding that candidate. This does not prevent the independently validated anchor increment.

Run `sheet-candidates-81339759b0b54f529751a6a47768980d` adds boss attack timing and loadouts to the
mission chain: five mission artifacts and 15 total dependents. Both producers take explicit bytes.
Loadouts still recover and validate the 66-weapon order from the matching OBB; they additionally
require the attack artifact to bind the exact supplied bot bytes, not merely the same scene hash.
Timing decimal parsing rejects overflow to infinity before it can enter a duration or probability.

All 15 timing records, 66 ordered weapon identities and 15 four-slot loadouts compare exactly with
the previous gameplay data. Only reviewed scene/dependency hashes change. Fifteen mission tests
pass, including reconstruction from the historical scene, exact dependency hashes and malformed
input rejection. The unified stage retains native and restoration evidence, clears temporary data
and writes no production content. Co-op execution and the full release remain unverified.

Run `sheet-candidates-412579961ac54d67a0a24ecf5865524a` unifies the previously separate mission
candidate chain with the sheet candidates, bringing the dependent count to thirteen. The three
mission/bot artifacts retain their full restoration-audit, preimage and semantic comparison gates.
`missionEvidence` embeds that report; producer and helper hashes remain recorded. The enclosing
stage supplies its exact scene bytes and rejects any mismatch before mission candidate construction.
Duplicate artifact ownership across the two producer groups is rejected rather than overwritten.

Twelve mission regressions pass, including same-scene integration and retained report/payload proof.
All 75 missions, 44 player-health values and 15 boss-health records retain their reviewed values.
The full staged run reuses and revalidates native evidence, writes no production content, and cleans
temporary data. Combining these candidates does not complete the remaining dependent release graph.

Run `sheet-candidates-b56e340dec3d4e1db9b21663c326b6a0` adds ordinary card identities as the tenth
dependent. `Card.rarity` and `Card.implemented` expose the recovered definition's RARITY and
IMPLEMENTED fields; the candidate preserves all 67 ordered identities and their exact field values,
including ten source-disabled entries. Only the source content hash changes in this candidate.

The builder takes explicit candidate bytes, but the production CLI retains its reviewed content
hash requirement. It now supports read-only `--check` and rejects unknown arguments before writes.
Rarity must be an actual JSON integer, excluding Boolean, float and string substitutions; flags
remain Boolean. Twenty-three dependent tests pass. This catalog does not certify or enable missing
card effects, and the complete content release is still unverified.

Run `sheet-candidates-7c417d03ef8b45c2b0d7a274fbd380ab` adds both skill-shot score catalogs, bringing
the staged dependent count to nine. `SkillShotManager.SkillShotItemDefinition.points` selects
SCORESINGLE for missions and SCOREMP otherwise; the generators preserve those distinct columns.
All 19 active rows in each mode, enum/code bindings, dictionary identities, combo window and PvP
long-shot distance remain exact. Only scene and content hashes change in these two candidates.

Both producers accept explicit input bytes and validate exactly one skill-shot sheet. The mission
producer now rejects Boolean points rather than accepting Python's Boolean-as-integer subtype;
both reject fractional, negative and oversized points. Both CLIs parse arguments before any write,
support read-only `--check`, and reject unknown flags. Twenty dependent regressions pass. The latest
stage revalidates retained native evidence, removes its temporary data and leaves production files
untouched. This is not proof of kill attribution, ordinary settlement or complete mode execution.

The latest run `sheet-candidates-562d326469c645bf88ede64378301cbe` includes a seventh dependent,
`recovered-coop-card-rows.json`, and reuses the retained native evidence with full validation. All
eight ordered family records remain exact. `UpgradeSlots.LoadDataForCard` lines 856-877 explain
the preserved fallback: if either card row is absent, both indexes become zero before interpolation.
This stage does not certify the interpolation or open the closed co-op mode.

The producer now takes explicit scene/content/army bytes and rejects unknown arguments before
reading or writing production content. Family coverage requires unique behavior and unit identities;
eight duplicated rows cannot stand in for eight distinct source families. HP/DAMAGE must be finite
JSON numbers, excluding Boolean values, before the existing positive-HP/nonnegative-damage checks.
Sixteen dependent tests pass, covering preserved rows, exact dependency byte hashes, duplicate
family rejection, NaN/Infinity/Boolean rejection, mixed scenes and unchanged production on failure.

The latest stage accepts `--native-run <completed-battle-recapture-run>` and independently verifies
the completed ownership record, original/prepared hashes, complete source inventory and current
source bytes, native output hash, typed values, sheet order and non-sheet observations. It checks
candidate rows again rather than trusting a success flag. The stage retains copies of native output,
source inventory and the native report under `evidence`, so retention of an older source run does
not silently remove the evidence for the current candidate. Its `nativeEvidence` record binds each
hash separately; `nativeGeometryRecaptured` is true while `releaseVerified` remains false.

Run `sheet-candidates-0e0bce185f734575a05aff82ac4b6043` passes this complete binding and includes
three direct dependents: the catalog profile, score-streak policy and PvP bonus catalog. Bonus
probability rows, prefab identities/hashes, rewards and source-code bindings remain exact. Only
`warbucksScalingBase` and `lowAmmoThreshold` have longer JSON decimal spellings; their recovered
binary32 bits remain identical. No reward or probability is inferred or retuned.

Seven dependent tests and four native-evidence boundary tests pass. They reject live/incomplete
runs, stale original input, unsafe or omitted inventory paths, changed bonus bits, Boolean-as-float,
unreviewed gameplay/schema changes and stale dependency hashes. The bonus producer now accepts
explicit scene/content bytes and rejects unknown CLI arguments before any production write.

```powershell
python Server/tools/test_sheet_dependents.py
python Server/tools/test_native_evidence_binding.py
python Server/tools/stage_battle_sheet_content.py --native-run `
  "$env:LOCALAPPDATA/WarFriends/ServerTests/test-runs/battle-recapture-3d0e18dd6ba14280a035f6c83abaf1bb"
```

The same run now builds `legacy-catalog-profile.json` and `recovered-pvp-score-streak-policy.json`
from explicit candidate bytes. It checks all non-provenance fields against existing documents.
Only the four proven BotNames ordered identities may change in the profile; all other identities,
schemas and closed flags remain exact. Both dependent hashes bind the candidate's actual bytes.
Score ratio 0.75, threshold 100, decay 1.1 and maximum one bonus per update remain unchanged.

The score source checker now recognizes the current named `KillStreakThreshold = 100f` and both
local/opponent comparisons/subtractions. Current ScoreManager deliberately bypasses local streak
advancement while self-hosted score authority is active and presents host snapshots. Source hashes
for ScoreManager and GameControllerOnline change with their existing integration; this candidate
does not claim new end-to-end gameplay verification from those textual source checks.

Run `sheet-candidates-91e8216eabb2435b8973115c28c139ba` passed. Five dependent tests cover exact
dependency hashes, unchanged gameplay, unexpected profile identity changes, stale hashes and CLI
argument rejection before writing. Run `python Server/tools/test_sheet_dependents.py` to repeat them.
The existing production legacy profile still passes `build_legacy_catalog_profile.py --check`.

The earlier WeaponInventory.cs observation gate is now resolved by a real fresh-account startup.
See [current starter proof](CLIENT_STARTER_LOADOUT.md). Observation/index/initial-state/unit artifacts
and their Backend pins were refreshed together without changing gameplay values. The unit builder
accepts explicit observation bytes while retaining source checks and the CLI's reviewed-content pin.

Current stage `sheet-candidates-6c5a536eeb284f8093bf1725e6ff7258` includes the unit-rule candidate
against corrected sheets and retains the fresh observation. It reuses copied native evidence from
an earlier successful stage after ordinary retention removed the original native run. Both original
and retained evidence paths repeat full hash/source/value verification; five boundary tests include
tampering with the retained report. The evidence-input run and original native run identities remain
distinct. Seven dependent and three explicit observation-input regressions pass. Remaining full
release gates concern other dependent artifacts and numerical behavior, not stale starter provenance.

Use the verified native capture and its separate input provenance, review dependent simulation
calculations affected by the 386 value corrections, and rebuild all
dependent manifests/templates/profiles as one release. Then run relevant source, numeric, runtime
and native gates. The current staged mission candidates are unchanged; their exact-value proofs
must not be generalized to this separate sheet data.

## Air inventory integration checkpoint

Air geometry now uses one reviewed inventory validator across all six consumers. Backend-admitted
inventory/deployment revisions reach the collider, weapon and target loaders; Drone reports the
accepted revision. Legacy defaults and the independent native mesh pin remain intact. Release build
passes with zero warnings/errors. Legacy and candidate focused loaders pass, including wrong hashes,
wrong deployment binding and recomputed-hash geometry tampering. Full diagnostic run
`combat-candidate-audit-e74047444098469e8f7254b68e670842` passes the air loaders and next rejects grenade
shot-target provenance. No production content was published; complete package validation remains open.

## Grenade target integration checkpoint

Native grenade shot-target recapture now passes: 12 clips, 289 frames and all five targets match
reviewed values exactly apart from scene provenance. Capture
`grenade-target-recapture-2aa4b73d43264faf9ee61c34a9f4dd44` verifies 15,599 unchanged inputs and removes
its temporary project. Five evidence guards plus six pose regressions pass. The bounded C# reader
binds the admitted scene and a reviewed fingerprint of every other field; the combat revision uses
the actual admitted target artifact hash. Release build has zero warnings/errors, and both legacy
and candidate focused production loaders pass, including wrong-scene and changed-position rejection.

Combined stage `sheet-candidates-9f8cd54e8b6940e0b077c7d99d28278e` contains 68 dependents. Retained
native evidence reproduces the exact target candidate. Full diagnostic
`combat-candidate-audit-68e21e5781b446d981762ca29beaf713` passes grenade target loading and next rejects
PvP bonus catalog's old whole-file revision. No production content was published; this is not full
combat, runtime parity or release verification.

## PvP bonus evidence integration

PvP bonus catalog loading now validates admitted scene/content revisions and the complete reviewed
rule/source snapshot. Only the two recovered binary32 fields normalize their JSON spelling after
exact value checks; probabilities, prefab identities and all other fields retain fingerprint checks.
The independent Unity arithmetic reference remains pinned. Release build has zero warnings/errors;
legacy/candidate focused checks reject wrong bindings, altered scaling and altered probabilities.
The existing source PvP bonus suite passes 1,800 assertions; 41 sheet-dependent tests also pass.

Full diagnostic `combat-candidate-audit-bf1cd5a5ed1b4a02bddc4c31bf0779c6` now passes bonus catalog
loading and stops at the score-streak policy's historical pin. Its candidate changes scene/content
provenance and two Client source hashes, not policy numbers. Latest relevant commits include
`e74f003fd` (co-op score HUD projection) and `53f6b2927` (scoped loading readiness); these latest diffs
alone do not establish the complete old-to-current source transition. Review that transition before
admitting refreshed score policy provenance. No production content was published.

## Score-streak source transition

Score-streak provenance now admits two complete reviewed code-source snapshots, with scene/content
bindings checked independently. Mixed old/current code hashes, unknown source hashes and changed
thresholds remain rejected. `audit_score_streak_provenance.py` recovers the exact legacy CRLF hashes
from Git baselines `5bab66c53f82b7bba692e1d94d920d0bd13e5ecc` (ScoreManager) and
`0fc5a46c288e2fd113bed5aee4b42350dae1b10a` (GameControllerOnline), pins current source bytes, and compares
local streak arithmetic/order plus crate eligibility. Host-owned presentation and lifecycle changes
are reviewed separately; this audit does not claim complete Client gameplay equivalence.

Three source-comparison regression tests pass. Release build has zero warnings/errors; legacy and
candidate focused loaders pass source-tuple/threshold/binding rejection checks. The existing PvP
score-state suite passes 47 assertions. Full diagnostic
`combat-candidate-audit-d980973ea39246d0830d1933649a4050` now passes score-streak loading and next
rejects the PvP skill-shot score catalog's historical pin. That candidate changes only scene/content
hashes; source code hashes and score rows are unchanged. No production content was published.

## Complete diagnostic loader acceptance

PvP skill-shot loading now binds the admitted scene/content and a fingerprint of the complete
reviewed 19-row score/source snapshot. Wrong bindings, score changes and code-hash changes remain
rejected. Malformed JSON retains the existing InvalidDataException contract; the source score suite
caught that exception regression and passes after correction. Release build has zero warnings/errors;
legacy/candidate focused checks pass, along with 39 skill-shot assertions and three overlay guards.

Full diagnostic `combat-candidate-audit-cdd05902ea6f4b5fa3aaf308d2250cbf` now PASSES the production
combat loader using stage `sheet-candidates-9f8cd54e8b6940e0b077c7d99d28278e` over unchanged production
auxiliary files. This is diagnostic overlay acceptance, not a standalone release. The runner now
writes `source-closure.json` and records eight affected artifacts absent from the candidate:

- `recovered-coop-navmesh-paths.json`
- `recovered-coop-navmesh-triangulation.json`
- `recovered-grenade-rig.json`
- `recovered-player-collision.json`
- `recovered-player-weapon-indexes.json`
- `recovered-rig-blend-reference.json`
- `recovered-walking-shot-reference.json`
- `unity-player-explosion-overlap-reference.json`

These require source/dependency review and explicit candidate ownership or a documented exclusion;
a loader accepting existing auxiliary files does not prove their provenance is current. No production
content was published. Successful diagnostic temporary data is removed by the managed lifecycle.

## Co-op navigation candidate references

Co-op native navigation references now join the candidate chain. Reuse requires exact reviewed
navigation/spawn/observation preimages, unchanged complete map inputs, byte-identical original and
packaged NavMesh assets, verified native mesh hashes and validated mesh counts. Only the navigation
manifest dependency hash changes: all 60 defend routes and 9,682 triangles across five maps remain
unchanged. Changed geometry, map order or native mesh bytes require review/recapture rather than
provenance substitution. No new Unity observation is claimed for this increment.

All 32 mission candidate tests pass. Stage `sheet-candidates-7eecd1e27c284285817335f9de8b0216` contains
70 dependents. Diagnostic `combat-candidate-audit-eb2140ba827f48c68f2679982183cf3f` passes the PvP
combat package loader and reports six unstaged affected artifacts. This does not prove co-op loading:
`CoopNavMeshTriangulationCatalog` still pins the old manifest, and the current diagnostic entry does
not instantiate that catalog. Co-op candidate loading needs its own production-loader gate.

Remaining unstaged affected artifacts: grenade rig, player collision, player weapon indexes,
rig-blend reference, walking-shot reference and Unity player explosion-overlap reference. The weapon
index producer still binds historical all-weapon bytes and needs an explicit candidate input tied to
the existing current starter observation. Keep production publication and full release gates closed.

## Candidate weapon identity binding

Weapon index generation now accepts explicit candidate binding bytes while retaining the pinned
legacy default. Candidate admission requires the observed current scene and an exact full-graph
comparison against reviewed weapon values; unknown fields, changed indexes or missing weapons fail.
The current starter observation and all its rule sources are revalidated. All 66 mappings remain
identical; only `combatBindingsSha256` changes in the candidate identity artifact.

Five candidate-index guards and three observation-input regressions pass; the legacy identity check
still reproduces production bytes. Release build has zero warnings/errors. Focused legacy/candidate
C# checks now compare all 66 mappings in both directions against the actual Backend resolver and
verify the binding artifact hash. Backend still uses its pinned embedded map: this proves mapping
compatibility, not publication or startup admission of a new embedded artifact.

Stage `sheet-candidates-5296b63ca4cd45d3866386f2a666c79a` contains 71 dependents. Diagnostic
`combat-candidate-audit-47c04cacc9ad49b5861b0a3b39b34747` passes the PvP loader and reports five
unstaged affected artifacts: grenade rig, player collision, rig-blend reference, walking-shot
reference and Unity player explosion-overlap reference. Co-op runtime admission remains separate;
its triangulation loader still pins the historical manifest. No production artifacts were published.

## Co-op navigation loader admission

Co-op navigation now has an explicit production-loader diagnostic scope. It loads mission, spawn,
navigation source, defend routes and Unity triangulation catalogs, then builds connectivity. The
triangulation reader bounds input and pins the complete reviewed geometry manifest independently
of its navigation dependency; existing map, source-asset, mesh-hash, vertex/index and area checks
remain. Restored-scene missions require the exact reviewed candidate artifact hash, while legacy
mission compatibility retains its existing validation.

Release build passes with zero warnings/errors. Legacy content and candidate diagnostic
`combat-candidate-audit-5ed2e461378949e7baac09806a5b5a4f` both pass all five maps, 60 routes and 9,682
triangles plus connectivity construction. Negative checks reject changed triangle counts, dependency
hashes, actual mesh bytes, unknown mission source and changed candidate mission rewards. Three Python
overlay guards pass. Successful diagnostic temporary data is removed; production content is unchanged.

Use `audit_combat_candidate.py --scope coop-navigation` separately from default `--scope combat`.
The recorded loader scope is navigation only, not complete co-op runtime or Client gameplay proof.
Stage `sheet-candidates-5296b63ca4cd45d3866386f2a666c79a` still lacks five affected native-reference
candidates: grenade rig, player collision, rig-blend, walking-shot and player explosion overlap.

## Player reference extension admission

Player reference capture and candidate loading now pass. Native run
`player-reference-recapture-7bae74643a7d46af80e13ddeb9c3f603` verifies 15,599 unchanged inputs,
matching collision/walking-shot values and the reviewed 144-node rig-blend extension. All previous
142 nodes and 12 sample cases remain equal; the two head-target nodes stay in the candidate.
Complete extended values are fingerprinted after separate scene validation. Eight extension guards
and seven capture/evidence tests pass. Successful temporary Unity project data is removed.

Combined stage `sheet-candidates-988ca9fb9e17424dbecbe54689374d77` contains 74 dependents and retains
all native evidence. Player-reference diagnostic `combat-candidate-audit-c097de86fe924e068454c2ac2d17d19c`
passes 9,444 assertions. PvP diagnostic `combat-candidate-audit-16d86847be044761bd1766450c708e2d` and
co-op navigation diagnostic `combat-candidate-audit-b6a75fde3b2749d3bf31dcf77078ae67` also pass.
Their temporary data is removed; production content is unchanged.

Two affected artifacts remain unstaged: `recovered-grenade-rig.json` and
`unity-player-explosion-overlap-reference.json`. Resolve their native input/dependency chain next.
These diagnostics are not complete co-op runtime, two-Client gameplay or original Unity 5.2 proof.
Coordinated publication, normal reward settlement and the broader release gates remain open.
