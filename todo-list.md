# WarFriends server improvement plan

Current priority is missing gameplay implementation, starting with ordinary PvP settlement (BE01).
Action 62 now connects accepted host outcomes to source-backed rank/XP, currency, streak and medal
calculation. An explicit offline policy is frozen into each eligible allocation. Both account
successors, exact replay responses and the result marker share one MongoDB transaction. Release
build and policy/rank tests pass; native concurrent/recreated-store replay, overflow rollback and
session rejection checks passed on 2026-10-22. The full solution build, protocol console and native
Mongo/HTTP/UDP smoke also pass. Legacy wire smoke passes 561 assertions including the new action-62
refusal/pending-evidence checks; registry dispatch passes ten groups.
See [policy and remaining gates](Server/docs/OFFLINE_BATTLE_REWARDS.md). Mission/achievement updates,
rank-up dog tags, league lifecycle and two normal Clients' result/rematch flow remain unfinished.

The previous native blast capture and combined stage completed; their candidate runtime/publication
gates remain separate follow-up work. Do not let further provenance-only increments displace BE01.

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

Earlier checkpoints below retain their original verification scope.

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

Air geometry now uses one reviewed inventory validator across all six consumers. Backend-admitted
inventory/deployment revisions reach the collider, weapon and target loaders; Drone reports the
accepted revision. Legacy defaults and the independent native mesh pin remain intact. Release build
passes with zero warnings/errors. Legacy and candidate focused loaders pass, including wrong hashes,
wrong deployment binding and recomputed-hash geometry tampering. Full diagnostic run
`combat-candidate-audit-e74047444098469e8f7254b68e670842` passes the air loaders and next rejects grenade
shot-target provenance. No production content was published; complete package validation remains open.

Co-op Assaulter now uses an explicit v14 release revision shared by Backend/Worker, retaining v13
compatibility and exact weapon semantics. Reviewed visual-loader source provenance is distinguished
from the legacy snapshot. Six generator tests, Release build and both-version focused loaders pass.
Full combat now stops at air-geometry's old inventory pin; coordinated collider binding remains.

Candidate combat manifest v14 now owns `MortarWeaponPoolRevision`; Backend/Worker share version
validation and bind the selected hash into package identity. Legacy v13 retains its reviewed pin.
Five generator tests, Release build and both v13/v14 focused loader/admission checks pass, including
wrong Mortar artifact hash rejection. Full loading next stops at co-op Assaulter's historical pin.

Heavy Turret now validates the admitted manifest scene instead of hardcoding the historical scene.
Release build and eight weapon packages plus Land Mine/Heavy Turret positive and wrong-scene checks
pass. Full loading next rejects Mortar pool's old whole-file pin; explicit package revision ownership
must be added without weakening integrity. Diagnostic overlays now apply managed retention after runs.

Full combat loader diagnostics found and fixed two candidate integration defects: pretty-printing
expanded the native player-pose file beyond its 48 MiB bound, and Land Mine hardcoded old scene
provenance. Native pose bytes are now preserved; Land Mine validates the manifest-provided scene.
Release build and eight weapon loaders plus Land Mine scene acceptance/rejection pass. Full combat
loading currently stops at Heavy Turret's old scene pin. Three overlay-stage and four pose guards pass.

The combat manifest now binds its direct dependency graph to reviewed candidates or byte-identical
unaffected pinned files. Four generator guards pass. The combined stage contains 67 dependents,
including 16 unchanged dependency copies. Full combat loading still requires auxiliary files beyond
the manifest; this increment does not establish a release-ready complete runtime package.

Player shot-target extraction now accepts explicit scene bytes and joins the combined candidate
stage (50 dependents). Both player roles and all ten ordered target identities/coordinates remain
exact. Twenty-eight mission/scene candidate tests pass. Animated hit authority remains a separate gate.

Native player/grenade poses and the Grenade manifest now join the combined candidate stage (49
dependents). Four pose-evidence and five manifest tests pass. Release build has zero warnings/errors;
all eight production weapon loaders accept the candidates. Actual retained pose rebinding reproduces
both byte streams. Full combat manifest and derived pose artifacts remain open.

Native pose recapture now passes for grenade and player pose documents against current MainScene.
Run `pose-recapture-3e0f80e9d05f4f9f9644edcd7b020cd6` confirms exact sampled values, 15,599 unchanged
original inputs and successful temporary-project cleanup. Weapon and pose runners share batch
preparation; five relevant tests pass. Candidate evidence binding and manifest integration remain.

Seven simple weapon manifests now bind exact staged content and family bytes, taking the combined
stage to 46 dependents. Four generator guards pass. Release build reports zero warnings/errors;
`--weapon-candidate-path` loads all seven packages using production C# catalog loaders. Grenade and
full combat manifests remain open because their extra pose/content dependencies are not ready.

Nine native weapon families are now included through `--weapon-family-run`, bringing the combined
candidate stage to 39 dependents. Five integrity tests pass, and actual retained-evidence rebinding
reproduces every family candidate byte stream. Minigun is recomposed from native inputs each time.
Production manifests and coordinated release verification remain open.

Minigun native composition is resolved without copying old values: three identity metadata fields
come from the same-run all-weapon export after exact overlap validation. Native family capture
`weapon-family-recapture-93b8eed0ee2244cca18f167ad41c7dd4` passes all nine packages, verifies 15,599
unchanged inputs and removes temporary data. Five composition and three batch tests pass. Family
evidence still needs integration into the combined release candidate and production manifests.

Weapon-family batch capture now runs nine exporters in one owned import. Actual execution produced
all nine outputs; eight match the packaged values except scene provenance. Minigun exposed a schema
composition difference between its exporter and packaged binding, documented under EN01 in
`missing.md`. The failed run retains diagnostics and all original inputs remained unchanged.
Three batching/comparison tests pass. Explicit Minigun composition remains required before promotion.

Native weapon evidence is now connected to the combined stage through `--weapon-run`. Completed
captures and retained stage evidence both repeat source/output/value validation. The combined stage
contains 30 dependents; actual retained rebinding reproduces all 66 weapon records exactly. Five new
binding guards and eight capture/validation tests pass. No production content was published.

Native weapon identity increment: the actual Unity exporter reproduced all 66 complete bindings
against current MainScene, changing only scene provenance. Run
`weapon-recapture-74716ddc1e2246c8a524de5ae28d0355` verified 15,599 unchanged input files and removed
its temporary project. Five weapon validation tests and three capture regressions pass. Coordinated
candidate binding and individual weapon-family native captures remain open.

Prefab mesh follow-up: six existing Unity-exported meshes now bind the staged collider artifact.
Source asset hashes and complete collider values must remain unchanged; otherwise native recapture
is required. Boolean vertex coordinates are rejected. Twenty-seven mission candidate tests pass.
Independent mesh decompression and runtime world-hitbox parity remain separate verification gates.

Latest EN01/C12 increment: the co-op prefab collider producer accepts explicit scene bytes and joins
the coordinated candidate chain. It preserves 32 prefab identities, 128 collider records and 14
WheelCollider counts, changing only scene provenance. Twenty-five mission candidate tests pass.
Production publication and animated world-hitbox verification remain open; see `missing.md` EN01.

Reviewed and implementation started 2026-10-21.

This is the active structure, correctness, performance, and testing backlog for the .NET server.
It does not replace the historical `todo_list.md` or claim that the recovered Unity game is fully playable.
Conversation is Korean; source, documentation, and test output remain English.
Checked items describe the original finding and required fix; see the implementation log for the
verified result. Unchecked items remain open even where a first part has been implemented.

## Baseline and evidence

Hand-written source inventory, excluding `bin` and `obj`:

| Project | C# files | Files directly in root | Source lines |
| --- | ---: | ---: | ---: |
| War.Backend | 40 | 29 | 7,193 |
| War.BattleServer | 660 | 660 | 76,938 |
| War.Persistence | 39 | 39 | 3,754 |

`MatchEngine` has 81 partial files; its main file is 3,723 lines, Army partial 4,751, and CardUnits
partial 2,479. `CoopMatchRuntime` has 36 partial files and a 4,019-line main file.
`LegacyEndpoints.cs` is 1,611 lines and `LegacyBuffer.cs` is 1,551 lines. These are responsibility
problems as well as navigation problems: moving partial files does not create encapsulated systems.

Both Backend and Persistence directly reference the BattleServer executable project. Backend startup
also mixes configuration, catalog loading, DI registrations, middleware, authentication, and routes.

Initial checks: solution build passed with zero warnings/errors; protocol console suite passed and
reported 1,360 protocol/admission/replay checks plus its separately reported suites. Battle and native
legacy checks were started; their current verified outcomes are recorded in the implementation log.
The live Battle suite reported a 32-match UDP poll fixture with p95 34.7 ms over 8.07 seconds. This is
a local fixture observation, not production capacity, WAN latency, or a full combat benchmark.

Evidence uses the current 1.4.0 Client under `Clients/ExportedProject`. Historical TypeScript checks,
1.6.0 routes, and 4.9.5 balance assumptions must not be substituted for current .NET coverage.
Review covered host entry points, transport, persistence boundaries, legacy purchases/cards/squads,
representative combat hot paths, source-audit tools, and test scripts. It is not a proof that every
combat formula in 76,938 source lines is correct; the remaining review matrix is explicit below.

## Rules for implementing this plan

- P0: authority/data-integrity defects. P1: observable correctness or release-blocking defects.
  P2: maintainability and measured efficiency. P3: later scale improvements.
- A confirmed source defect has a concrete failing code path. A performance candidate needs measurement.
  A missing feature is not automatically a bug in an implemented feature.
- Make folder moves behavior-free. Preserve public namespaces initially, protobuf numbers, wire names,
  catalog identity/digests, assembly identities, and Client assets. Namespace migration is a later task.
- Keep one owner of mutable battle state. Do not parallelize systems inside a match without an explicit
  ownership and ordering proof. Backend owns Mongo/economy; Worker owns authoritative combat.
- Keep offline native Windows/Linux deployment. No Photon, retired service, Docker, or Redis prerequisite.
- Prefer descriptive methods and feature ownership over generic repositories, service locators,
  reflection dispatch, broad interfaces, or an event bus in the combat loop.
- Every completed item needs relevant verification and an honest boundary. Do not call SDK checks
  complete Unity gameplay, Linux runtime, or Android validation.

## First implementation sequence

1. Record this plan and the current test outcomes.
2. T01-T04: inventory test storage, introduce owned run directories and retention, prevent further growth.
3. S01-S03: update source discovery, move root files, enforce the resulting structure.
4. C05-C07 and C10: small, evidenced calculation and wire-contract fixes with focused regression checks.
5. C01-C04, C08-C09: transactional publication, retry identity, and concurrency correctness.
6. S04-S08: extract host-independent domain and feature responsibilities after behavior is protected.
7. P01-P08: establish representative baselines and optimize only measured hot paths.
8. V01-V06: finish the audit matrix and release gates; keep open gameplay work visibly separate.

## Structure and SOLID

- [x] S01 / P1 — Make source audits relocation-safe. `audit_battle_terminal_reasons.py` uses a root-only
  `glob("MatchEngine*.cs")`; `BattleAbortReasonCoverageTests` also enumerates only the root.
  Card/army identity audit tools hardcode source paths. Update these before moving files; require an
  exact inventory or expected count so missing a subtree cannot produce a false pass.
- [x] S02 / P2 — Move Backend root files into feature folders using the map below. Leave `Program.cs`
  at root; keep runtime configuration and `.csproj` there. Preserve namespaces during the move and
  update executable source references. Build and run relevant tests after the move.
- [x] S03 / P2 — Move BattleServer root files into the feature tree below. Keep each partial family
  together for the first pass. Put `AssemblyInfo.cs` under `Properties`. Produce a checked source move
  manifest and a guard against new root-level implementation files or duplicate/missing destinations.
- [x] S04 / P2 — Remove executable-to-executable references. Extract shared manifest, allocation,
  terminal validation, and source-content types into a server-only `War.Battle.Domain` library.
  Then extract simulation into `War.Battle.Simulation`; Backend/Persistence depend on Domain, never
  Worker hosting. Do not put signing secrets or Mongo types into portable `War.Shared`/`War.Client`.
  Inventory transitive dependencies and embedded resources first; verify publish output ownership.
  First extraction: War.Battle.Domain owns match/terminal/queue contracts and required source rules.
  Persistence no longer references the executable or signer; its only project dependencies are
  Domain/Shared. Thirty Worker sources moved fully, three split out shared declarations, and one
  queue identity moved from Infrastructure. The signer's 300-second constant now aliases Domain
  policy; cryptography remains Infrastructure-owned. Sixty-nine extracted types have separate files.
  The second extraction now gives Backend the shared content through Domain and moves mutable
  execution to War.Battle.Simulation. Domain references Shared; Simulation references Domain/Shared.
  Backend/Persistence have no Worker/Simulation reference. Current source inventory is 632 origins/915
  destinations, with 59 Worker, 306 Domain and 610 Simulation C# files. Sixty-five compiled checks
  cover ownership, dependencies, resources, portable SDKs and native imports. All 22 runtime/native
  stages, legacy storage/HTTP and fresh independent Release publish graphs passed. Both hosts publish
  the same Domain DLL and only their own runtime metadata. Test consoles intentionally reference
  hosts to exercise actual implementations. Native provisioning, V07 and deeper state ownership
  retain their separate gates; S04 does not close the whole goal.
  See Server/docs/BATTLE_PROJECT_BOUNDARIES.md and battle-project-extraction.json.
- [x] S05 / P2 — Reduce composition roots. Extract `AddBackendServices`, validated immutable options,
  middleware, and feature route mapping. Route handlers parse/authenticate/map responses; application
  services execute use cases; pure rules calculate; stores implement atomic persistence.
  Backend Program now composes settings, services, initialization, pipeline and feature maps in 27 lines.
  Accounts, connectivity, grant/reconnect, queue and rematch have typed application owners without
  HttpContext or request-service lookup. Pure rules/projections and atomic stores retain ownership.
  Nineteen exact modern method/path/limiter mappings, bounded input/MAC tests, native HTTP/UDP,
  Legacy contracts and actual Release queue/reconnect/rematch/restart recovery pass. Legacy action
  dispatch remains S06; shared combat state remains S07-S09. Worker Program is now 22 composition
  lines, with explicit host/control owners and a nine-route graph. Shared server-only stream/MAC
  policies keep transport out of rule libraries. Native size/MAC/shape/closure and actual Release
  restart/reconnect/rematch checks pass. See Server/docs/BACKEND_HTTP_STRUCTURE.md and
  Server/docs/WORKER_HOST_STRUCTURE.md. This does not close cohesive simulation ownership.
- [x] S06 / P2 — Split legacy actions by Accounts, Player, Inventory, Economy, Cards, Squads, and Battle.
  Replace the large switch only with an explicit typed action registry that proves one disposition
  per action. Preserve RequestBuffer ordering, per-action errors, rollback fields, and raw action 157.
  Avoid adding an interface per trivial calculator; use interfaces at I/O/time/random boundaries.
  Direct HTTP extraction now has 175 explicit dispositions: 4 anonymous, 60 authenticated,
  25 buffered-only and 86 closed. Feature owners replace the dispatcher switch; authentication is
  a narrow I/O boundary. The 25 nested buffered actions now have their own typed registry and
  independent stateless Inventory/Economy/Cards/Squads owners. One explicit per-request publication
  context retains atomic wallet/blob planning, time and seeded draws without a shared partial
  family. Recursive producer guards, compiled ownership/isolation checks, Client callback tests,
  transaction/replay/fault groups and all 954 Legacy HTTP/base checks pass. See
  Server/docs/LEGACY_ACTION_STRUCTURE.md for the mapping and remaining authority/performance audits.
- [ ] S07 / P2 — Extract cohesive systems from `MatchEngine` incrementally: lifecycle, player weapons,
  projectiles, army, vehicles/air units, cards/status effects, collision queries, and projections.
  Give each system its own state instead of sharing dozens of engine dictionaries through partials.
  Specify update order and same-tick effects; compare deterministic snapshots before/after extraction.
  First increment extracts admission/readiness/reconnect state into PvpConnectionLifecycle and
  per-participant connection owners with private flag setters. Existing Player members are
  getter-only adapters; cleanup and terminal publication remain at their original engine points.
  Nine pre-extraction traces (108 full observations) and six owner/order groups pass. Global
  lifecycle/clock, weapon/projectile/army/vehicle/card state and projections remain open under S07.
  See Server/docs/PVP_CONNECTION_LIFECYCLE.md for source rules, update order and verification scope.
  The next increment moves fixed slot membership/selection and magazine/reserve/reload/fire
  state into PvpWeaponLoadout/PvpWeaponSlotState with private setters and read-only membership.
  Eight prior-engine weapon traces (99 observations) and six state/ownership groups pass; the
  original nine connection traces still match. Trigger/aim/damage/projectile and frame ownership
  remain separate S07 work. See Server/docs/PVP_WEAPON_STATE.md for boundaries and C29 arithmetic.
  The third increment moves physical player cover/position, private path/progress, arrival clocks
  and observed velocity into PvpPlayerMovementState. Eight prior-engine movement traces (431 full
  observations) match after extraction; focused ownership/boundary groups protect source speed,
  expiry, deferred frames, map binding and cancellation. No mutable route array escapes the owner.
  Command authority, animation, global frames and non-player navigation retain their own systems.
  See Server/docs/PVP_PLAYER_MOVEMENT.md; integrated verification is recorded in the implementation log.
  The fourth increment gives player real/cosmetic bullet membership, advancement, completion,
  snapshots and cleanup to PvpPlayerBulletSystem. Seven prior-engine traces (350 observations) match
  after extraction; seven ownership/order groups protect one-impact-at-a-time processing, captured
  frame order and terminal interruption. Shared IDs/capacity, factories, world impact application and
  other projectile families remain separate work. See Server/docs/PVP_PLAYER_BULLETS.md.
  The fifth increment moves active/delayed bazookas and curve history into PvpPlayerBazookaSystem,
  with immutable launch/payload/step types. Six prior-engine source-bound traces (914 observations)
  match; six owner/order and three shared-capacity groups pass. Shared budget omission C30 is a
  separate intentional correction. See Server/docs/PVP_PLAYER_BAZOOKAS.md.
  The sixth increment separates equipped grenade flights into PvpPlayerGrenadeSystem and bonus/card
  flights/pending explosions into PvpBonusGrenadeFlightSystem. Seven original-engine traces (1,075
  observations) match; eight owner/order groups protect collision/publication boundaries and late
  shared-damage reads. World effects, burst scheduling and global frames remain engine-owned.
  See Server/docs/PVP_PLAYER_GRENADES.md; S07 remains open beyond these extracted owners.
  The seventh increment combines real/cosmetic army flight and launch-authority dictionaries in
  PvpArmyBulletSystem. Nine original-engine traces (5,625 observations) match; eight owner/order
  groups protect completion, capture, clock/exception and detached observation boundaries. Private
  entries, cursors and steps are value types. World impacts and other army families remain open.
  See Server/docs/PVP_ARMY_BULLETS.md for source boundaries and final integrated evidence.
  C31 separately corrects FlameAmmo's accumulated deadline/source-frame clock and coupled receipt/
  throttle identity. The eighth increment gives flame/poison storage and captured frames separate
  PvpArmyFlameSystem/PvpArmyPoisonSystem owners. Nine prior-engine traces (16,238 observations) match;
  six flame and six poison owner/order groups protect preflight/commit/completion and reservations.
  World effects, shared capacity and other army families remain open. See Server/docs/PVP_ARMY_EFFECTS.md.
  The ninth increment pairs Rocket Soldier/Mortar flights with immutable launch authority inside
  PvpArmyMissileSystem and owns last-frame impacts. Ten prior-engine traces (10,789 observations)
  match; eight owner/order groups protect projections, completion, capture, errors and terminal
  boundaries. Grenadier flights and remaining army/world orchestration stay open under S07.
  See Server/docs/PVP_ARMY_MISSILES.md for original source and lifecycle evidence.
- [ ] S08 / P2 — Apply the same ownership split to `CoopMatchRuntime`. Keep co-op admission closed
  until its existing gameplay gates pass. Reuse genuinely identical policies; preserve mode-specific
  targeting, scoring, objectives, spawn timing, and callback order.
- [ ] S09 / P2 — Use narrow ports where consumers differ: command execution, read-only projections,
  durable terminal publication, and allocator control. Existing `IMatchRuntime` is a useful seam;
  split only when independent consumers need it. Test PvP/co-op substitution contracts explicitly.
- [ ] S10 / P2 — Apply `Docs/CODE_STYLE.md` to new code; format existing dense files separately from
  behavioral fixes. Add a short folder ownership guide and dependency diagram. Preserve recovered
  source comments explaining authority, binary32 rounding, callback order, and replay constraints.

### Backend move map

| Destination under War.Backend | Existing root files |
| --- | --- |
| `Transport/Http/` | `HttpProtocol.cs` |
| `Features/Battle/Allocations/` | `BattleAllocationSource.cs` |
| `Features/Battle/Manifests/` | `BattleManifestFactory*.cs`, `PreparedBattleManifest.cs` |
| `Features/Battle/Loadouts/` | `BattleArmyCombatProjection.cs`, `BattleArmyManifestProjection.cs`, `BattleArmyPerkCatalog.cs`, `BattleClientWeaponIndices.cs`, `BattleUnitProjection.cs`, `BattleWeaponOwnership.cs`, `UnitOwnershipContext.cs`, `WeaponOwnershipContext.cs` |
| `Features/Battle/Catalogs/` | `IBattleArmyManifestCatalog.cs`, `IBattleWeaponManifestCatalog.cs`, `BattleMixedManifestCatalog.cs`, `BattleRifleManifestCatalog.cs`, `BattleShotgunManifestCatalog.cs` |
| `Features/Battle/Provisioning/` | `BattleMatchProvisioner.cs`, `BattlePlayerPresentationSource.cs` |
| `Features/Battle/Cancellation/` | `BattleCancellationPreparation.cs`, `BattleCancellationRecoveryService.cs`, `BattlePairedCancellation.cs` |
| `Features/Battle/Rematch/` | `BattleRematchAllocator.cs`, `BattleRematchCancellation.cs`, `BattleRematchEndpoints.cs` |
| `Features/Battle/Results/` | `BattleResultArchivalService.cs`, `BattleTerminalAcceptance.cs` |
| `Legacy/` initially | Existing legacy files; split by S06 after correctness fixes |

### BattleServer target tree

```text
War.BattleServer/
  Program.cs
  Properties/                  AssemblyInfo
  Hosting/                     NetworkWorker, runtime/key/settings, startup manifest discovery
  Transport/
    Admission/                 tickets, sessions, reconnect
    Udp/                       endpoint, MTU, sender budgets
    Reliability/               event windows, cursors, chunks, reply transfers
    Snapshots/                 projection, interpolation, baseline/interest policies
  Matches/                     router, manifest, lifecycle contracts
  Simulation/
    Match/                     MatchEngine partial family, then extracted systems
    Coop/                      CoopMatchRuntime partial family and mission policies
    Army/                      deployment, infantry, targeting and movement
    Vehicles/                  ground vehicles, passengers, transporters
    Air/                       helicopters, drones, flight and crew
    Weapons/                   rifle, shotgun, pistol, SMG, LMG, minigun, sniper
    Projectiles/               bullets, grenades, bazookas, mortar and explosions
    Cards/                     cards, deployables, mines, turrets, medkits, status effects
    World/                     map, navigation, collision, covers and barrels
    Physics/                   native rope and contact solver adapters
    Progression/               PvP bonuses, score policies, arena policy prototypes
  Content/                     cross-feature content loading and validation
  Persistence/                 terminal outbox and active-match journal (no Mongo)
  Backend/                     allocator/result HTTP adapters
```

Keep feature-specific catalogs beside their systems; `Content` is for cross-feature packages.
Do not create a miscellaneous folder for unresolved ownership. Review each move-map exception.
After S04, most `Simulation`, `Content`, and manifest types leave the executable project.

### SOLID acceptance criteria

| Principle | Concrete application |
| --- | --- |
| Single responsibility | Transport never calculates rewards; a weapon system does not publish Mongo state. |
| Open/closed | Add a reviewed action/system through explicit composition and coverage, not unrelated switches. |
| Liskov substitution | Runtime implementations preserve admission, terminal, replay, and snapshot guarantees. |
| Interface segregation | Read-only projection consumers do not receive mutation or storage APIs. |
| Dependency inversion | Use cases depend on narrow persistence/control ports; pure rules need no host. |

## Confirmed correctness findings and repair guides

- [x] C01 / P0 — Atomically publish ordinary buffered purchases. In `LegacyBuffer.WorkingState.Flush`,
  non-card subsystem blobs are written through `SetSerialized` before a separate wallet `$inc`.
  There is no expected-revision/balance filter for this path; two distinct buffers can spend the
  same starting balance, overwrite inventory, or leave an unpaid grant after a crash. Card packs
  already have a dedicated CAS path; do not misreport them as using the ordinary path.
  Build one validated successor and publish all changed blobs/balances with expected revision.
  Test two purchases with funds for one, interruption before commit, and exact conservation.
- [x] C02 / P0 — Make receipt and mutation one transaction. `LegacyBufferStore.TryClaim`, player
  mutation, and `Complete` are independent writes. A crash after claim strands a request; after
  mutation it loses the authoritative reply. Mongo replica sets are already required: use one
  transaction for effect plus receipt, with bounded retries and deterministic random outcomes.
  Bind receipt to player/buffer/index/action/payload digest and store the required response fields.
  Replay currently ignores stored `ActionId` and returns only Result except a card-pack special case.
  Test altered retries, concurrent replay, timeout after commit, and failure rollback response replay.
- [ ] C03 / P0 — Make card pool transfers atomic. `DepositCards` writes inventory and deposits in
  separate unconditional writes; `WithdrawCard` separately replaces donor deposits and receiver
  cards/cooldown. Two receivers can both take the same last card. Use one transaction for donor,
  receiver, eligibility/cooldown proof and receipt; same-player transfers must have a defined path.
  Use checked amount/reputation arithmetic. Test concurrent last-card withdrawal and crash recovery.
  Atomic publication and source-backed cooldown/reputation fixes are implemented; details and tests
  are in `Server/docs/CARD_POOL_PUBLICATION.md`. Optional OperationId callers are retry-safe. This
  remains open because the recovered Client deposit builder sends no nonce, so a lost-response
  retry cannot be distinguished from an identical new deposit without deliberate Client integration.
  Include direct squad mutations in that nonce migration: their state fences prevent common duplicate
  effects, but cannot distinguish a delayed old move/leave after subsequent legitimate membership changes.
  Include direct dog-tag actions in that protocol review: same-pool concurrent refills conserve one
  charge, but a delayed replay after intervening penalties has no stable identity; penalty requests
  are distinct operations until a reviewed Client/server nonce contract exists.
  Include direct paid rename and profile replacements: a delayed old request after intervening
  choices has no nonce or expected source count. Atomic session/revision publication is implemented,
  but must not be described as per-intent replay protection.
- [x] C04 / P0 — Make squad membership and leadership atomic. Create inserts a squad before charging;
  its player predicate checks funds but not still-squadless/revision/creation count. Join/accept/leave/
  kick/leadership transfer update squad and player mirrors separately. Use transaction-bound role,
  membership, price and revision checks. Test simultaneous joins to different squads, two creates,
  leader transfer versus kick, and rollback after every write boundary. Do not invent capacity policy.
  Source review also confirmed a rank calculation defect: numeric 0/1/2/3 are Member/Veteran/Leader/
  Coleader, but `MiscTools.CompareSquadRanks` orders Member < Veteran < Coleader < Leader. Replace
  arithmetic promotion/demotion with explicit transitions and validate actor/target authority from
  `MemberRecord`. `SquadMemberContent.canBePromotedToColeader` limits Coleaders to three; this does
  not supply a missing general member-capacity policy.
  Implemented source-compatible one/two-roster transactions, explicit rank transitions and current
  actor/target authority. Non-Leaders may directly move squads, matching SquadRecord.JoinClick;
  Leaders must transfer leadership first. See `Server/docs/SQUAD_PUBLICATION.md` for publication,
  unkeyed retry limits, six pure/five race/thirteen rollback scenarios and 45 HTTP assertions.
- [x] C05 / P1 — Fix rename price overflow and stale-price concurrency. `ChangePlayerName` calculates
  `(1 << Clamp(RenameCount - 1, 0, 30)) * cost` in unchecked Int32. With source cost 25 and count 28,
  this becomes -939,524,096, so the `price > 0` debit is skipped. Count 29 is also negative.
  Compute in checked wider arithmetic, reject a price outside the source Int32 contract, validate
  count/cost, and CAS the expected rename count as well as funds. Never clamp corrupted count into
  a valid price. Test counts 0, 1, 27, 28, negative/maximum count, and simultaneous free renames.
  The single price owner is now Persistence/Legacy/Profile/LegacyRenamePolicy; the Backend helper
  delegates to it. Name/count/debit publication also requires current session/expiry/revision and
  returns committed fields. Ten profile Mongo groups include forced free and paid rename races.
- [x] C06 / P1 — Match instant-completion precision. `LegacyBuffer.ConvertTimeIntoGold` uses double
  minutes/constants; Client `MiscTools.ConvertTimeIntoGold` first uses binary32 minutes/constants.
  With catalog coefficients 0.6325/-0.175 and 324,478 seconds, .NET reproduction gives Client 761
  versus Backend 760 Gold. Source delivery tables contain durations above this value (maximum
  observed 705,540), so the remainder is representable. Preserve the Client conversion order for
  valid values, add finite/range checks, and test rounding boundaries and rejected invalid policy.
- [x] C07 / P1 — Repair status response and validation. `LegacyEndpoints` action 29 returns only
  Result. Client `ServerResponseHandler.OnSetPlayerStatus` unconditionally reads `Time` unless
  `IsOffline` is present. Return one captured supported Unix second; validate the exact status enum.
  `LegacyRequest.Int` currently turns missing/malformed values into zero and refreshes presence.
  Test required Time, malformed heartbeats, unknown enum, and atomic Status/LastAction publication.
- [x] C08 / P1 — Fix legacy account/session insertion. `LegacyPlayerDocument.SessionHash` defaults
  to empty string, has a unique sparse index, and is inserted before `IssueSession`. Empty strings
  are still indexed: concurrent creates can collide; a crash can leave a permanently colliding row.
  Generate/hash the initial session before the single insert. Validate Locale/DeviceToken/UtcOffset
  at the reusable account boundary, and validate starter policy before password work. Test parallel
  creation, failed insert, session issuance, and existing damaged-row handling without silent repair.
  Implemented one initial insert with precomputed credentials/session, reusable metadata/start-state
  validation, frozen starter policy and committed-revision session rotation. Empty historical hashes
  remain refused without repair. Source CreateAccount omits DeviceToken, so it is optional at first
  registration but validated when present; direct action 13 requires the complete token/Locale tuple.
  See `Server/docs/ACCOUNT_PUBLICATION.md` for four pure/seven storage scenarios and 28 HTTP assertions.
- [x] C09 / P1 — Return the committed player after buffer retry. `Apply` replaces only its local
  player reference when a card-pack CAS conflicts; `GetPlayerData` still projects its original object
  and passes that stale object to later buffers. Ordinary Flush also increments durable Revision
  without advancing the in-memory mirror. Return the committed snapshot or reload once after all
  buffers; keep revision and balances consistent. Test an injected conflict followed by another
  buffer and require the response to match the committed document exactly.
- [x] C10 / P1 — Preserve rollback fields on replay. Repeating a failed equip/purchase currently
  returns bare ActionId/Result, losing the InventoryData, LevelName/Weapon/Unit, delivery, wallet or
  cosmetic fields expected by `ServerResponseHandler.ProcessBuffer`. Persist complete response
  evidence in C02 and test every implemented failure branch against the actual 1.4.0 parser.
  Complete canonical response persistence, current rollback projection, and source-backed delivery-clock
  projection are implemented and exercised by the existing HTTP fixtures.
  The recovered callback matrix now covers all 25 supported actions and 180 Client failure branches;
  its 1,188 checks use actual ProcessBuffer/StringParser control flow with instrumented manager/UI
  boundaries. Fifty original producer scenarios plus 149 catalog-fixture scenarios now exercise every
  current literal server action/result disposition (126 total). Each disposition requires first-delivery
  and changed-authority replay assertions against both wire values and decoded Client state. The
  reviewed source inventory and six scanner guard tests prevent a new disposition being omitted.
  Complete catalog/state policy validation and the direct-action builder/caller inventory remain C12/C13/V01.
- [x] C11 / P1 — Reject malformed buffer shapes before claims. `ParseRequests` skips invalid entries,
  accepts noncanonical/negative indexes, and stops after adding request 257 despite a limit of 256.
  `ParseBuffers` silently stops at 64; direct action 98 lacks the same BufferId length gate.
  `GetValue<int/string>` can throw shape errors outside the `JsonException` catch.
  Validate exact envelopes, bounded counts/identities, duplicates and types before mutation; produce
  callback-safe per-action errors where appropriate. Test limit/limit+1 and no partially applied input.
- [ ] C12 / P1 — Replace permissive catalog authority with validated immutable types. `LegacyCatalog`
  skips malformed rows, merges duplicate sheet types, overwrites duplicate constants, exposes mutable
  JsonObjects, casts doubles to Int32 and scans rows per lookup. Validate source-specific required
  sheets, identity, provenance, prices, durations, indexes, finite numbers and duplicates at startup.
  Build immutable indexed tables after validation. Do not reuse historical version-specific counts.
  First increment implemented: bounded strict envelopes, immutable scalar/row/sheet storage, frozen
  reviewed NAME/DBKEY indexes, exact integer readers and consumed price/duration/constant validation.
  Configured startup requires current sheets/constants and referenced stages. Unpriced helper combat
  tables and unrelated sheets cannot be selected as upgrade prices. The next increment binds all
  132 sheets to recovered field types/counts/identities and exact snapshot bytes, validates typed
  upgrade lanes/offsets and excludes the three scene-proven helper units from player admission.
  Remaining work: source-value and per-source provenance reconciliation, including the known V07
  mismatch. The embedded profile protects the reviewed export but does not prove scene fidelity.
  See `LEGACY_CATALOG_VALIDATION.md`.
  EN01's typed scene audit additionally finds 386 ObscuredFloat values rounded by the old exporter's
  string round trip and four unresolved BotNames differences. The exporter now uses direct conversion;
  original managed-type/Mono tests reproduce old bits and preserve corrected JSON bits. See
  Server/docs/BATTLE_SHEET_VALUE_AUDIT.md. Production re-export and dependency validation remain open.
- [ ] C13 / P1 — Validate complete stored player/subsystem state. The original `PlayerState.Read`
  allowed numeric strings/default replacement and `UpdateSettings` accepted partial/unknown JSON;
  those parser/Settings defects are fixed. Full legacy progression validation remains incomplete.
  Distinguish absent legacy schema from present damaged state, implement explicit migrations, and
  validate each mutation successor. Test negative/overflow amounts, null containers, partial Settings,
  invalid rank/delivery/ownership state and unknown fields; preserve legitimate unmodeled data.
  First increment: bounded strict typed JSON, present-null/absence distinction, required container and
  case-alias/key guards, immutable serializer options and conserved root/nested metadata. Fourteen
  DTOs now have separate files with unchanged public/JSON identities. Complete six-Boolean Settings
  is validated at request, durable update, authentication, login rotation and boot; revision/session
  CAS preserves current metadata, and the generic write bypass is closed. Source defaults and input
  shape are executable against unchanged recovered Settings code. The second increment requires
  eighteen exact present BSON integer fields and validates wallet/rank/tier/counter domains at shared
  reads, authentication, transactions and projection. It fixes the ten-versus-one starting placement
  mismatch and prevents Client ArmyPower-times-ten overflow before publication. Global/division medals
  remain independent. Direct action 192 requires one canonical bounded assertion and authenticated
  session/revision publication; malformed assertions cannot poison the account. Complete authoritative
  Army Power recomputation from validated inventory remains open; display assertions must not grant
  value or select combat/matchmaking outcomes. Existing placement-ten and missing numeric records
  require reviewed migration,
  never silent reset. The whole task stays open for complete root/subsystem semantics,
  catalog-bound ownership/delivery, explicit missing-field
  migrations and all successor boundaries. See `Server/docs/STORED_STATE_VALIDATION.md`.
  Profile increment: five direct mutations now delegate to Profile feature owners, with immutable
  token/locale/status/country changes and one source-priced name/count/Gold publication. Current
  session/revision predicates block stale-session writes; exact canonical fields/diagnostic agreement
  prevent alias or duplicate-value selection. Status/LastAction extend strict root BSON to twenty
  numeric fields. Generic TryUpdate and Update were removed after tutorial/analytics gained feature
  owners. Fixture-era SetSerialized was also removed, with card setup confined to the test assembly.
  Complete profile schema migrations and shared subsystem successors still require follow-up.
- [x] C14 / P1 — Guard dog-tag and time calculations. `CurrentDogTagSeconds` added/subtracted Int32
  times before clamping; `PayOneDogTag` performs stale unconditional replacement, and refill CAS
  checks funds without the dog-tag revision. Capture one time, validate tuple and finite policy,
  use checked intermediates, and CAS the full expected state. Compare 1.4.0 VIP/debt behavior before
  choosing bounds. Test concurrent penalty/refill, full cap, future cursor, overflow and deadlines.
  Source-backed frozen policy and pure rules now preserve negative base debt, include the two-tag
  VIP bonus in refill pricing/fullness and widen regeneration before capping. Session/revision-bound
  atomic writes recalculate after definite conflicts; an older request cannot rewind a newer cursor.
  Boot and expiry project valid base state without deleting debt; response Time, dog-tag cursor and
  UTC midnight share one checked clock. The oracle passes 144 original Client comparisons plus two
  invalid-authority/policy groups. Eight real Mongo conflict/failure groups and 14 direct HTTP checks
  pass in the existing owned replica. See `Server/docs/DOG_TAG_PUBLICATION.md`. Stable direct intent
  identity remains under C03; complete progression validation remains C13.
- [x] C15 / P1 — Unify MTU policy. Config accepted 576-1400, receive clamped to 1200, but outbound sizing
  uses fixed `PacketCodec.MaximumDatagramBytes` and 900-byte reply chunks. A configured 576-byte
  budget does not bound replies. Either require the current protocol's fixed 1200 or thread one
  supported negotiated budget through both peers, packet sizing and chunks. Test every allowed
  configuration using real packets; do not merely test receive filtering.
  The current protocol now accepts only 1200 at startup, matching PacketCodec, host paging and SDK;
  the Worker no longer clamps an independently configured receive limit. The new fast/full selector
  passes 314 configuration, real authenticated 1199/1200-byte UDP, 1201-byte refusal and near-maximum
  reply-transfer chunk checks with full-width metadata. Existing real Worker/two-SDK transfer checks
  pass 152 assertions. See `Server/docs/UDP_BUDGET.md`; adaptive MTU negotiation is not introduced.
- [x] C16 / P1 — Validate Backend deployment policy once. Starter settings are mutable/unvalidated;
  missing configured content silently selects empty fallback; rate/port/key configuration differs
  between hosts. Require explicit supported values and intentional catalog-free mode, sharing
  validation where semantics agree. Test startup failures before accepting accounts or matches.
  BackendDeploymentOptions now freezes database, rate, battle/content and legacy policy before
  Mongo clients; BattleHostStartupOptions captures Worker policy before journals/listeners. Shared
  Infrastructure rules reject malformed ports/endpoints, zero/equal keys and supplied invalid values.
  Catalog-free startup requires explicit opt-in; configured content cannot silently fall back.
  Ten pure policy groups, fifteen real process refusals, all 24 runtime/native stages and source-backed
  legacy storage/HTTP checks passed. See Server/docs/BACKEND_STARTUP.md and the verification log.
  This closes deployment validation, not C12/C13 catalog/state review or S05 route extraction.
- [x] C17 / P1 — Define replay retention safely. Buffer receipts expire after 30 days but legacy
  buffers are persisted by the Client, without a server-authenticated maximum replay age. After TTL
  deletion the same identity can apply again. Establish a durable replay fence/tombstone policy
  compatible with current buffer IDs; do not infer trusted age from a client-generated ID.
  Test a replay after receipt expiry and a fresh legitimate buffer without reopening old authority.
- [ ] C18 / P1 — Finish ordinary GameEnded only from host evidence. Action 62 remains unimplemented;
  `NORMAL_UNITY_TERMINAL.md` documents mandatory LevelExperience and conditional reward/ranking
  tuples. Reuse accepted roster/manifest-bound terminal proof and existing card-consumption receipts.
  Keep settlement atomic and retry-safe; do not fabricate success, rewards, or Scored/Settled flags.
  This is a known feature boundary, not evidence that existing combat unit tests failed.
- [x] C19 / P1 — Correct rank/display-level comparisons. Durable Level is a recovered rank index
  0-42, but weapon/unit/cosmetic purchases and tier promotion compare it with raw display-level rows.
  Recovered predicates use index >= CANBEBOUGHT/UNLOCKLEVEL - 1, or displayNumber >= UNLOCKTIER.
  Centralize this comparison without changing stored rank or starter policy; test below/at gates,
  first rank, final display level 43, max-tier sentinel and malformed authority against Client rules.
  LegacyRankGate now owns all four comparisons. Thirteen real producer scenarios, malformed-authority
  rejection and comparisons with six unchanged compiled Client rank properties pass. General durable
  rank/catalog validation remains part of C12/C13 rather than being inferred from a local gate helper.
- [x] C20 / P1 — Enforce recovered upgrade ceilings and completion authority. The previous weapon
  bound allowed purchase at the Client's reserved final state row, normal units ignored their current
  tier ceiling, and Elite/parts paths allowed a terminal lane purchase. Typed immutable tracks now
  reproduce weapon rows-minus-two, tier-specific normal count-minus-one and Elite count-minus-one
  boundaries. Before normal/instant completion, require current ownership, a legal next index and
  active delivery matching identity/index/normal SlotId; reject before debit or increment. Clear all
  delivery proof on success. Ten unchanged Client getters/methods independently check all 66 weapons
  and 24 player units; 63 planner/callback cases cover caps, invalid/stale proofs, kinds and helpers.
  Complete durable-state validation and special-track support remain separately open.

- [x] C21 / P1 — Publish shown-once analytics flags from current authority. The former
  SetAnalyticsFlag read the authenticated snapshot and replaced PlayerAnalyticsData through an
  unconditional SetSerialized. Two different flags can overwrite each other, or an older flag
  request can erase newer counters/transactions/pack metadata. A present JSON null/non-object is
  currently replaced with an empty object. Read the recovered seven builders/callbacks and data
  members, validate bounded canonical state without default repair, patch the current flag only,
  and CAS the same current session/revision. Preserve exact unknown Int64 metadata and refuse
  unsupported flag identities. Force two flag reads, a concurrent buffered analytics update,
  session rotation, corrupt present data, failed write and repeated true flags in one owned replica.
  Implemented under Legacy/Analytics in Backend/Persistence. Seven closed flag identities use
  current session/revision CAS; repeated true is read-only. Shared 33-field validation rejects
  damaged present state before auth/boot/buffer publication and preserves exact unknown metadata.
  The buffered chat marker now shares the contract and canonical nonnegative Int32 parsing.
  Four source-backed groups, eight forced Mongo groups and 79 HTTP assertions pass without an
  extra Mongo process or Unity copy. See Server/docs/ANALYTICS_PUBLICATION.md. Complete analytics
  reward/receipt lifecycles and missing-field migrations remain C13, not part of this closure.
- [x] C22 / P1 — Bind tutorial start/end to current durable state. The former unconditional writes
  let old end A clear a newer pending B and accepted completed replay without binding BattleId.
  Backend/Persistence Legacy/Tutorial now owns a strict versioned pending/terminal identity, coherent
  legacy mirrors and bounded current-session/revision CAS. Concurrent starts converge; matching
  completion publishes once; unrelated terminal IDs and stale sessions cannot mutate or replay.
  Unambiguous legacy empty/pending states migrate atomically. Old completion without retained ID
  remains readable for boot but cannot acquire invented replay proof. Mandatory BattleId and current
  LevelExperience/TutorialData callbacks are preserved without client-reported rewards. Four pure
  source/BSON groups, eight forced Mongo groups and 20 HTTP checks pass, including old-A/new-B,
  duplicate start/end, current-XP replay, session replacement/expiry and database write failure.
  Generic Update and fixture-era SetSerialized were removed. See Server/docs/TUTORIAL_PUBLICATION.md.
  Host-derived combat/reward completion remains separate C18; complete migrations remain C13.
- [x] C23 / P1 — Restore required rename error fields. NotEnoughGoldForChangeName previously returned
  only Result, but the active ServerErrorHandler directly indexes RenameCount and PlayerGold before
  restoring its wallet view. True insufficient funds now return both validated current values;
  stale revision is WrongPlayerData and a failed CAS re-reads session authority to identify revoked/
  expired sessions as InvalidToken. The unchanged source error branch executes in the headless
  oracle, including missing-key proofs; HTTP tests verify current rollback and zero mutation.
- [x] C24 / P1 — Enforce exact canonical player GUIDs at shared server boundaries. MatchManifest.Validate
  originally used Guid.TryParseExact plus lower-case equality, but the parser accepts surrounding whitespace.
  Its distinct-player HashSet compares the original strings. A compiled-domain reproduction accepts
  both a normal two-player manifest and a manifest containing the same parsed GUID twice, once as
  32 lower-case characters and once with one leading/trailing space (34 characters). This contradicts
  the existing exact/distinct identity contract and can disagree with GUID-based ticket encoding.
  Introduce one allocation-free exact 32-character lower-case hexadecimal policy where a canonical
  N GUID is required; do not trim or normalize damaged authority. Audit manifest/admission, terminal,
  queue/account and SDK call sites without imposing GUID rules on opaque provider, match or content IDs.
  Test padding/control whitespace, uppercase, alternate GUID forms, same-GUID aliases and distinct valid
  players before allocation/signing/publication, including signed malformed-control input and no writes.
  Preserve the strict tutorial behavior already covered by C22. This defect predates S04 extraction;
  the first project move retained it until this separate correction was verified. All 217 common-policy
  call sites now use exact lexical validation; no authored Server/src GUID parser gates remain.
  Account drafts receive a server-generated ID before validation/insertion; damaged stored identities
  cannot rotate sessions, plan a buffer, publish receipts or claim/release cover ownership.
  See Server/docs/CANONICAL_IDENTITIES.md and the integrated verification log below. This closes the
  identity-format finding only; complete durable schemas and historical repair remain C13.
- [x] C25 / P2 — Make oversized internal result requests return the documented size failure.
  Program.cs currently returns 404 for ContentLength > 65536 at /internal/battle/results/accept,
  while the same route's streamed-size guard and other internal routes return 413. This is a
  confirmed source-level inconsistency. Native smoke-19e441cac55d4f7d8f173ce9b7a038b3 reproduced
  result oversize returning 404. Both result and allocation routes now return 413. A shared bounded
  reader handles declared/unknown length, consumes at most limit + 1 and refuses before retaining
  excess data. Twenty-two native checks cover declared/chunked limits, unsigned at-limit input,
  valid/stale/wrong-domain MACs, zero result writes on refusal and exact accepted terminal replay.
  HTTP envelope capacity versus binary terminal capacity remains a separate C26 finding.
- [x] C26 / P1 — Align terminal HTTP envelope capacity with the accepted binary payload budget.
  TerminalResultDigest and BackendResultForwarder accept up to 65,536 snapshot bytes, while Backend's
  result HTTP body is capped at 65,536 bytes. A 49,152-byte in-budget snapshot becomes 65,536
  Base64 characters before JSON metadata; the configured budgets therefore cannot transport every
  accepted terminal. Default JSON escaping can expand the string further. Derive a bounded shared
  envelope budget/serializer from the binary contract, preserve other route limits and MAC/digest
  bytes, and refuse oversized encoded envelopes locally. Reproduce with a valid large terminal over
  real signed HTTP; prove exact maximum acceptance/replay and over-budget refusal without writes.
  Do not weaken snapshot validation or hide a stuck durable outbox through truncation.
  Native smoke-63366e3984f148e8bb62cca74e39fdb8 reproduced HTTP 413 for a validated canonical
  65,536-byte snapshot. Infrastructure's TerminalResultEnvelope now derives an 87,630-byte decoded
  JSON cap and a finite 525,785-byte HTTP/1 wire cap, writing binary Base64 without HTML expansion.
  Only Backend result acceptance raises its Kestrel feature; other API and UDP limits are unchanged.
  Exact maximum accepted/stored/replayed bytes, normal/raw one-byte chunks, binary excess refusal,
  unchanged other-route limits and local zero-send refusal pass. The semantic engine snapshot plus
  canonical compatibility-field padding is documented, not claimed as normal Unity gameplay.
  See Server/docs/TERMINAL_HTTP_ENVELOPE.md.
- [x] C27 / P1 — Advertise HTTP/1 closure when rejecting an unread oversized body. A 413 could finish
  before Kestrel drained the request; a late body-limit failure then closed a still-reusable socket.
  The following provision request reproducibly failed with ResponseEnded in native
  smoke-4e48f4ab545142d18f7d6b54b56eb7e0; debug logs bind it to post-response body drain. Backend 413
  handling and Worker early size refusal now send Connection: close for HTTP/1. A pure protocol
  check preserves HTTP/2 behavior; sequential native negative requests require 413/closure and
  continue without retrying a failed response. See the terminal-envelope guide for evidence.

- [x] C28 / P2 — Remove raw diagnostic fields from operational logs and fix length units.
  LegacyDiagnosticEndpoint still logs client-controlled ExceptionMessage/DbAction, showedOffers,
  ArenaId and cheater-report fields verbatim, preserving the pre-extraction behavior. These strings
  can carry control characters or credential-like content. Log server-owned caller/action metadata
  and bounded lengths instead; do not mistake structured-log placeholders for payload redaction.
  ReceiveLog currently labels string.Length as bytes, although it counts UTF-16 code units.
  Choose and name the intended unit explicitly. Add a capturing-logger regression with multiline,
  credential-like and non-ASCII sentinel input; prove log omission/unit correctness while retaining
  the Client's mandatory PlayerID echo, LogId and acknowledgement shapes. This is a source finding,
  not evidence that production credentials were exposed.
  Diagnostic handlers now log validated caller IDs and UTF-8 byte counts without client payload
  strings in rendered or structured logs. Capturing-logger regressions fail against the former code
  and pass with ASCII/Korean/supplementary input; mandatory PlayerID echo and generated LogId remain.

- [x] C29 / P2 — Make the internal generic capped-ammo grant monotonic and overflow-safe.
  The previous TryResolveCardAmmo arithmetic could reduce legitimate Ammo Box overfill: starting
  reserve 3, current 4, grant 1 became 3. Its checked Int32 addition also rejected valid grants near
  the maximum/sentinel. Preserve existing cap policy while leaving at/above-cap reserve unchanged
  and widening before saturating under-cap addition. A focused regression failed against the old
  math and passes after correction; all 32 runtime/native stages and Release focused checks pass. The generic
  callback currently has no production source callers; this is a latent internal-API finding, not
  observed live-player loss. Wider cap-policy/source review stays in C13.

- [x] C30 / P1 — Include active player bazooka missiles in the global projectile resource budget.
  PendingProjectileCount counted scheduledBazookas but omitted bazookaProjectiles. A source-bound
  RPG could be visibly active yet contribute zero; an M202 secondary reservation disappeared when
  it became a still-live missile. Count active plus delayed missiles once within the existing shared
  128-projectile budget, retaining whole-volley refusal before ammo/ID/event publication. The original
  counter regression fails; corrected source RPG/M202 and controlled full-budget hold/fire tests pass.
  All 35 runtime/native stages pass; verification is recorded below. This is not an observed production incident.

- [x] C31 / P1 — Preserve FlameAmmo's cumulative binary32 deadlines and source-frame clock.
  At 30 Hz from zero, copied/verified Client bodies produce pulses at 11/22/32/43/53/64; the old
  server's repeated eleven-tick interval produces 11/22/33/44/55/66. ArmyFlamePulseClock now owns
  accumulated strict deadlines and one pulse per source frame, using the existing pause-excluding
  BattleCooldownClock. Source frames can share a combat tick: player/box receipts bind pulse ordinal,
  and Flame skill-shot throttling receives the same source time. Ten source/host groups and existing
  geometry/replay fixtures verify boundaries; all 39 runtime/native stages pass. See
  Server/docs/ARMY_FLAME_CLOCK.md. Flame/poison ownership is extracted in S07's eighth increment;
  its world-effect orchestration remains separate work.

- [x] C32 / P1 — Match the two Mathf.Lerp clamps in FlameAmmo.CheckHit.
  The original managed UnityEngine.dll confirms clamped interpolation. The server extrapolated the
  distance-based cone below its configured far angle and damage below its minimum for large
  overlapping colliders whose centers lie outside the radius. Both regressions fail before the fix;
  clamped inputs pass eight source/geometry groups, including 440 matrix probes and unchanged
  overlap/minimum-distance/order/invalid-authority gates. All 40 runtime/native stages pass. See
  Server/docs/ARMY_FLAME_INTERPOLATION.md. The managed original-math oracle needs no Unity project.

- [x] C33 / P1 — Preserve straight army missile expiry priority before collision.
  Missile.Update expires at progress > 3 before CheckHit; TryKill sets mExploded. The server queried
  collision first and could select a different impact or reject collision authority after source
  expiry. Six source-anchored groups fail before the fix; all eight pass after moving the unchanged
  expiry branch ahead of collision, after finite-position validation. Fifty matrix scenarios cover
  real/fake missiles, negative-progress Mortar, path/speed extremes, strict boundary and early hits.
  Tick/finite/collision guards, speed/stop time, arming, ray length, IDs and launch authority remain
  unchanged. Ten prior-engine traces still match without replacing baselines. All 43 runtime/native
  stages pass. See Server/docs/ARMY_MISSILE_EXPIRY.md. The reference is a managed straight-policy
  translation with synthetic rays, not execution of original Unity/native physics or normal gameplay.

## Performance work: measure before claiming improvement

- [ ] P01 / P1 — Add separate Release baselines for HTTP parsing, authenticated UDP round trips,
  full combat ticks, collision, serialization, and Mongo transactions. Record hardware/runtime,
  scenario/content revision, warmup, p50/p95/p99/max, throughput, allocations, GC pauses and drops.
  A 30 Hz tick has 33.33 ms total host budget; set operating capacity with headroom from measurements,
  not the config's maximum 1,024 matches. Keep benchmark artifacts small and isolated from correctness.
  No standalone benchmark harness currently exists in the solution. BattlePerformanceLedger records
  gameplay/card/objective evidence and is not a timing/allocation harness. Add an explicit development
  tool under Server/tools/War.Server.Benchmarks, separate from the default correctness executable.
  Begin with repeatable in-process combat/collision/serialization cases against recovered content,
  then add isolated native HTTP/UDP/Mongo scenarios. Bind every report to build/configuration, content
  revision, seed, case inputs and sample/warmup counts; keep operation units explicit. Use managed
  external test-run ownership/cleanup, bounded aggregate/raw reports and no Unity project/Library
  copy. Run native performance scenarios without simultaneous correctness/Mongo suites so disk and
  process contention are visible rather than mixed into a claimed server capacity result.
- [ ] P02 / P2 — Remove synchronous disk work from the shared tick using a bounded persistence
  coordinator. `NetworkWorker` calls `ActiveMatchJournal.Begin`/`PersistTerminals`; both journals
  can `Flush(true)`. Outbox polling/pruning shares a lock with publication. Preserve durability-before-
  successful-control-response and crash recovery; no fire-and-forget loss of terminal evidence.
  Test slow/failed disk, full queue, shutdown, restart and continued progress of unrelated matches.
- [ ] P03 / P2 — Index authenticated session ownership in `MatchRouter`. `Owns` and `Handle` scan
  matches per packet. Maintain a session-to-endpoint map on admission/reconnect/expiry, preserving
  revocation and collision checks. Benchmark at 1/8/32 matches before raising capacity.
- [ ] P04 / P2 — Profile tick allocations. `MatchEngine.Advance` and army paths repeatedly snapshot,
  sort, clone and allocate LINQ collections. Use reusable bounded scratch storage and stable iteration
  only for measured hot paths; preserve mutation-safe iteration and deterministic tie breaking.
- [ ] P05 / P2 — Profile static/dynamic collision separately. `RecoveredBattleMap.Raycast` traverses
  shapes and candidate triangles. Evaluate a precomputed spatial index and dynamic broad phase;
  preserve layer masks, disabled colliders, closest-hit ordering, overlap and float tolerances.
  Run recovered reference rays/overlaps and full combat comparisons before accepting speed gains.
- [ ] P06 / P2 — Reduce redundant snapshot encoding. `FitSnapshotDatagram` repeatedly computes
  protobuf size and searches/removes the oldest projectile. Prepare stable ordered projection once,
  size pages incrementally and cache only by exact revision/connection presentation contract.
  Preserve full authoritative mutation replies, digest verification and bounded chunk replay.
- [ ] P07 / P2 — Measure UDP ingress/send contention. Receive allocates/copies/parses before sender
  admission; the tick awaits each send and all poll types share four authenticated packets per tick.
  Measure malformed-flood CPU, fairness, poll starvation and send stalls. Pool buffers only with
  explicit ownership/return rules; bounded sends must not reorder mutation replies or drop receipts.
- [ ] P08 / P2 — Optimize Backend I/O after correctness. Share an injected Mongo client/database;
  narrow queries/projections, inspect actual query plans and add proven indexes. Cache immutable
  catalog/card pools, avoid repeated JSON decoding, and bound CAS retries. Rate-limit legacy login/
  account creation independently from ordinary API traffic; never lower password security for speed.
- [ ] P09 / P3 — Scale across independent match owners/Worker processes only after baseline gates.
  Preserve per-match ordering, bounded capacity, admission routing and durable host ownership.
  No blanket parallel loops, ECS rewrite, new serializer, or native rewrite without measured need.

## Test storage and developer workflow

- [x] T01 / P1 — Inventory every workspace `.local` directory by size, age and purpose. Identify live
  processes and pinned evidence. Never recursively delete the entire directory: it can contain
  expensive Unity projects, native builds, source-reference evidence and Worker recovery journals.
  Produce a dry-run report before pruning old data and verify canonical paths remain within scope.
- [ ] T02 / P1 — Give new test runs an ownership manifest, status, timestamps and process identity.
  Separate small retained logs/reports from disposable Mongo data and temporary exports. Successful
  runs should discard disposable data after all owned processes exit; failures retain useful reports
  with bounded count/age/bytes. An explicit keep-artifacts option preserves full troubleshooting data.
  Implemented for checkpoint/native/legacy runs with PID and process-creation identity. New v2
  manifests bind Windows creation FILETIME or Linux boot UUID/start ticks; completion checks the
  same owner before disposal, and pruning distinguishes PID reuse from the original live owner.
  Inaccessible identity preserves data; legacy v1 keeps conservative PID-only handling. Nineteen
  lifecycle checks pass on Windows/WSL. Checkpoint console stages now confine TEMP/TMP/TMPDIR to the
  run's disposable data, covering their C# GetTempPath producers without extra copies. Direct console
  invocations and remaining independent producers still need migration.
- [x] T03 / P1 — Add safe retention tooling: dry-run by default, explicit apply, skip active/pinned/
  unknown runs and links/junctions, validate root/child paths, and report reclaimed bytes. Do not
  delete production outboxes, shared native toolchains or unmarked historical folders automatically.
- [ ] T04 / P2 — Apply the lifecycle to Windows/Linux native and legacy smoke scripts and reusable
  test helpers. Avoid rebuilding an unchanged solution per script; offer a validated no-build mode.
  Reuse fixtures within a suite, not mutable account state across independent tests. Bound timeouts,
  restore environment and stop/wait only owned processes even on failure.
  Windows native/legacy scripts and Linux native script now use the lifecycle and no-build option.
  Windows legacy passed; integrated native results are recorded below. Linux syntax passed, but
  Linux execution and migration of the remaining reusable C# helpers are still open.
  The Windows scripts now restore absent environment keys through the provider, keeping explicit
  empty values separate. Same-shell legacy-to-native execution exposed and now verifies this
  PowerShell 7.6 null-string binding defect; both installed PowerShell hosts pass isolation checks.
  The native/legacy scripts now set TEMP/TMP/TMPDIR to live creation-identity-validated run storage
  after builds, then restore the caller's original environment. Linux native smoke exports equivalent
  child paths after the same owner check. The lifecycle suite now has 21 Windows/WSL checks; direct
  C# invocations and explicit `.local`/Unity export producers remain follow-up work.
  TestBackendQueue.ps1 now owns the Release live queue/reconnect/rematch replica and temporary
  output, restores TEMP/TMP/TMPDIR and removes successful data. BackendQueueLiveTests no longer
  writes Server/.local. Six explicit C# .local producers and reusable Unity leases still remain.
- [ ] T05 / P2 — Separate fast pure/protocol tests, storage integration, real UDP combat, native
  physics, performance and Unity/Android gates. Add explicit selectors and a machine-readable run
  report; default developer checks must not clone/import a Unity project or create a Mongo replica.
  Keep console test executables explicit: `dotnet test` does not run the current assertion suites.
  Added `fast`, `runtime`, and `battle` checkpoint selectors with stage logs, exit codes and timings.
  Unknown/malformed War.Battle.Tests arguments now exit 2 with a fixed safe diagnostic before the
  shared/full-suite prelude. Four existing shared entry shapes remain allowed; Unity path arguments
  must be nonblank. Eighteen actual process refusals and a real valid pure selector pass, with no
  scratch data created. Debug/Release also pass the actual shared-prefix allocation-inventory path.
  Still open: finer storage/physics/performance selectors and migration of existing test producers.
- [ ] T06 / P2 — Reuse a small number of disposable Unity audit projects keyed by source/import
  revision. Preserve original Client and library work, use exclusive leases, and invalidate caches
  deliberately. Do not make a new complete Library/project copy for every normal test run.
- [x] T07 / P2 — Add concurrency/fault tests to the areas in C01-C04 rather than inflating assertion
  counts from loops. A test must prove setup, interleaving/failure, action and conserved result.
  Produce compact failures with scenario ID/seed; never log passwords, tokens, signing keys or bodies.
  Deterministic transaction fixtures use forced competing reads, receipt/account/roster write faults
  and complete conserved-state assertions. Selector/method/scenario names identify failures; unused
  random outcome seeds are not invented. Test output does not print credentials or request bodies.

## Completion and remaining audit matrix

- [ ] V01 — For each implemented legacy action, trace builder, parser and caller; enumerate exact
  success/failure fields, numeric types, optimistic rollback and replay behavior. Do not port absent
  server policy from a different version. Maintain one executable action-disposition inventory.
- [ ] V02 — Audit combat by family: weapons/cadence/ammo/reload; projectile travel/falloff; shields/
  armor/healing; army deployment/targeting; vehicle/air crew; card stacking/expiry; map/pose/collision;
  PvP clock/scoring; co-op spawn/objective/terminal state. Test finite extremes, zero vectors, empty
  targets, same-tick events, entity removal, duplicate commands, reconnect and deterministic order.
  Explicitly resolve terminal bonus/card grenade retention versus equipped-grenade cleanup. S07's
  frozen terminal trace preserves prior server behavior, not a verified Client terminal contract.
  C32 closes the two Flame Mathf.Lerp clamp mismatches using the original managed math binary.
  C33 closes straight-missile expiry/collision priority with source-anchored control-flow regressions;
  complete native physics, moving-target, curved trajectory and pause fidelity retain separate scope.
  Broader native overlap, collider-center placement and complete geometry authority remain in V02;
  the synthetic large-collider regression is not full recovered-scene gameplay proof.
- [ ] V03 — Validate packet/resource budgets under loss, duplicate, reordering, delayed chunks,
  reconnect and hostile valid-size traffic. Preserve HMAC, replay windows, endpoint binding,
  fragment limits, generation revocation and bounded queues. Encryption is a separate deployment
  decision; do not describe existing HMAC integrity as confidentiality.
- [ ] V04 — Run build, protocol suite, Battle suite, source audits, native Mongo/UDP smoke and legacy
  smoke appropriate to changed behavior. Run full gates once per integrated change; use targeted
  tests during iteration. Record actual exits/results instead of copying old README counts.
- [ ] V05 — Verify native Linux deployment and real Unity/Android separately. Keep current normal
  Unity terminal/rendering/co-op gaps linked to `Server/docs/BATTLE_SERVER_FEATURES.md` and
  `Server/docs/NORMAL_UNITY_TERMINAL.md`; component tests cannot close those gates.
- [ ] V06 — Update `Server/README.md`, feature boundaries, move map and this checklist after each
  verified increment. Separate confirmed fixes, performance measurements and remaining work.
  Folder organization alone must never be advertised as faster networking or calculations.
- [ ] V07 / P1 — Reconcile MainScene provenance before calling the full source checkpoint green.
  HEAD and working MainScene SHA-256 are both
  `5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`; the mission catalog records
  `d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
  Re-extracted mission rules, map records and boss records are equal. The card-source audit also
  rejects its recorded scene hash. The PvP score-streak and bonus catalog audits reject their
  cross-scene binding too. Trace the extraction snapshot and validate all dependent content;
  do not replace hashes simply to pass. No Client scene/content artifact was changed in this increment.
  EN01 now traces the exact transition to commit f9f63d037: only the original LevelManager payload
  was restored. The executable audit verifies all other scene bytes, unchanged mission values and
  61 affected JSON artifacts (52 direct scene references). Original APK/OBB verification resolves
  all 93 restored pointers. Eight audit regressions pass. See Server/docs/MAIN_SCENE_PROVENANCE.md;
  coordinated re-extraction/native recapture and content release validation still remain open.
  The first static candidate chain now re-extracts missions, bot definitions and bot health without
  writing production files. Ten regression tests pass, including exact historical reproduction;
  candidate data is 166,260 bytes in one managed run. All three production source checks still
  reject their old scene binding. Full affected-content publication remains pending under EN01.

## Implementation log

### EN01/C12 — Precision-sensitive vitality boundaries and army deployment

- Added a focused Release check using real VehicleHealthState/AirEntityHealthState with 28 HP and
  358 damage corrections at synthetic old/new death thresholds. All 386 cases pass and remain
  distinguishable without tolerance-based normalization. This is not full unit attack/modifier parity.
- Refactored army deployment extraction to explicit inputs and staged its candidate. All 24 family
  options/settings remain exact; 18 movement decimal spellings retain binary32 bits and artifact
  CRLF is preserved. Eight dependent regressions pass.
- Release test build has zero warnings/errors; argument-refusal tests and new-file style checks pass.
  Added checkpoint selector content-precision. Production battle/deployment content remains unchanged.
- C12 follow-up: Army perk extraction now accepts explicit candidate inputs and rejects mixed scene
  snapshots. Per-build source collection replaces shared global state. The sixth staged dependent
  preserves all 24 family rules and binds the exact staged battle/deployment bytes; twelve dependent
  tests pass. Existing native evidence is reused without another Unity project copy. Production
  `--check` rejects its still-mixed snapshot without writes; coordinated content release remains open.
- C12 follow-up: co-op card-row extraction accepts explicit candidate bytes and joins staging as the
  seventh dependent. All eight family indexes and source row-zero fallback remain exact. Duplicate
  family identities and NaN/Infinity/Boolean combat scalars are rejected; sixteen dependent tests
  pass. This changes extraction validation, not production content or co-op mode admission.
- C12 follow-up: PvP/mission skill-shot score catalogs join candidate staging. Both preserve their
  19 active rows and timing rules with refreshed exact input hashes. Producers have read-only checks
  and reject unknown arguments; mission Boolean-as-integer acceptance and ambiguous duplicate sheet
  lookup are corrected. Twenty dependent tests pass; no production score or reward path is opened.
- C12 follow-up: ordinary card identities join candidate staging as the tenth dependent. All 67
  ordered cards, rarities and enabled/disabled flags remain exact. Typed rarity validation rejects
  Boolean/float/string substitutions, while production writes retain the reviewed content-hash gate.
  Read-only and unknown-argument CLI checks leave content unchanged; 23 dependent tests pass.
- C12 follow-up: unified sheet staging now includes the three mission/bot candidates and their full
  restoration-audit evidence. An enclosing stage must supply identical current scene bytes; stale
  preimages, semantic changes and duplicate producer ownership remain rejected. Twelve mission
  regressions pass. The candidate now contains thirteen dependents; no production files are written.
- C12 follow-up: boss attack timing and four-slot loadouts join the mission candidate chain. All 66
  OBB-ordered weapons and 15 mission configurations retain their values. Exact bot-byte dependency
  validation and finite-decimal checks prevent mixed versions and overflowing timings. Fifteen
  mission tests pass, including historical reconstruction; the combined stage has 15 dependents.
- C12 follow-up: boss anchors join the staged mission chain, preserving all 40 ordered positions
  across five independently hash-checked maps. Duplicate map coverage is rejected. Seventeen mission
  tests pass; the combined candidate has 16 dependents. Boss paths still need their missing native
  output or a new verified capture; no path data or native evidence has been fabricated.
- C12/EN06 follow-up: added minimal native boss-path capture. Five NavMesh assets and metadata total
  971,149 bytes; no Client/Library copy is required. Actual Unity 2018.3 capture reproduces all 120
  packaged routes exactly and successful managed cleanup removes its temporary project. Raw evidence
  is retained for candidate integration. Five synthetic packaging boundary tests pass separately.
- C12 follow-up: native boss paths now bind into unified staging with exact input/output hashes,
  complete current source inventory validation and retained raw evidence. The seventeenth dependent
  preserves all 120 routes. Six binding tests and five packaging tests pass; running captures,
  altered evidence and mismatched anchors are rejected. No production catalog is published.
- C12 follow-up: mission shield states join staged mission extraction. All 75 rows and Client defaults
  remain exact. A complete mission inventory and matching DATA hashes are mandatory; the CLI now
  rejects unknown arguments before writes. Twenty mission tests pass. Existing native battle and
  boss-path evidence is reused without another Unity launch; the candidate has 18 dependents.
- C12 follow-up: soldier enemy-point masks join staging as dependent 19. All 16 masks, serialized
  identities and sniper distance remain exact. Duplicate rows and coerced Boolean classification
  are rejected, as are mixed scene/deployment inputs and unknown CLI arguments. Twenty-six dependent
  tests pass; this does not certify the full point selection or movement runtime.
- C12 follow-up: air-unit geometry joins candidate staging as dependent 20. Three source prefabs,
  resolved meshes, hierarchy/collider/target values and pinned CRLF are preserved exactly; only the
  deployment digest changes. Duplicate air inventory is rejected and unknown CLI flags fail before
  writes. Twenty-nine dependent regressions pass; runtime dynamic-pose verification remains separate.
- C12 follow-up: Rusher/Minigunner/Sniper weapon bindings join staging as dependent 21. Eight families
  and Warper geometry remain exact. Initial strict comparison exposed four stale SoldierBehaviour
  source pins; d44cbdbd8 changes only four visual-loader coroutine wrappers, while its parent CRLF
  hash matches the old artifact. Only that exact reviewed hash pair is accepted. Thirty-two dependent
  tests pass; unknown CLI arguments and mixed input snapshots cannot write production content.
- C12 follow-up: co-op Assaulter primary/card rifle joins staging as dependent 22. All projectile,
  muzzle and attack values remain exact. The reviewed base-soldier hash transition is shared with
  Rusher validation, while other source/gameplay changes remain rejected. Thirty-five dependent
  tests pass, including corrupted inventory ownership, altered cadence and unknown CLI refusal.
- C12 follow-up: Land Mine and Heavy Turret sources join staging as dependents 23/24. Placement and
  prefab data remain exact; four turret stat decimal expansions retain identical binary32 values.
  Only those reviewed float fields may change spelling. Duplicate mine damage definitions and mixed
  scene/content are rejected; unknown CLI flags cannot write. Thirty-eight dependent tests pass.
- C12 follow-up: Mortar weapon pool joins staging as dependent 25. Capacity four, per-owner count
  two, allocation/return rules and normalized source hashes remain exact. Explicit inputs reject
  mixed scenes; fractional/Boolean counts and broken two-owner capacity conservation fail. Forty-one
  dependent tests pass. Runtime pool behavior is not inferred from catalog preservation.
- C12 follow-up: co-op NavMesh source manifest joins staging as dependent 26. All five source maps,
  asset hashes and packaged bytes are preserved and rechecked. Explicit mission input retains stage
  ordering and scene validation; unknown arguments fail before writes. Twenty-two mission tests pass,
  including package corruption and reordered/stale maps. No NavMesh assets are copied or replaced.
- C12 follow-up: co-op detail manifest joins staging as dependent 27. Complete binary/YAML native
  tile inventories are re-decoded and compared, extending the prior first-tile spot check to all 655
  tiles, 5,693 polygons and 26,081 detail triangles. Artifact hashes/counts and unchanged native assets
  remain mandatory. Twenty-four mission tests pass, including final-tile corruption and omissions.

### EN01/C12 — Current native starter observation and coherent metadata publication

- Actual fresh-account Backend/Mongo/Unity boot completed: 24 units, 66 weapons, 133 index checks,
  zero runtime exceptions and the same 70 error diagnostics. All prior gameplay/context/state values
  match; only WeaponInventory.cs provenance differs. The isolated source project/Library and Mongo
  temporary data were removed after successful owned shutdown; 15,599 original inputs stayed unchanged.
- Refreshed observation, weapon-index map, initial subsystem state, unit rules and four Backend pins.
  Derived artifact differences are limited to observationSha256. Updated the two corresponding
  provenance-audit preimage hashes after explicit comparison; MainScene transition evidence is unchanged.
- Release build passes with zero warnings/errors; 54,236 loadout/ownership/unit checks, 268 index
  checks, protocol, native live smoke and legacy smoke (563 assertions) pass. Three input-plumbing
  regressions, seven dependent tests and five native evidence guards pass.
- Candidate staging now accepts the current observation and retained native evidence, preserving
  its source/run/hash history across ordinary cleanup. Broad corrected-sheet publication and remaining
  numerical/dependent gates remain open; starter provenance is no longer blocking unit staging.

### EN01/C12 — Native evidence binding and bonus dependency

- Candidate staging can now bind a completed native recapture using explicit original/prepared/output/
  candidate hashes. It rechecks the complete source inventory and every typed candidate row, retaining
  native evidence beside the candidate. Failed/running or stale/incomplete evidence cannot authorize it.
- Added explicit-input PvP bonus extraction and dependent staging. Nine probability/prefab rows and
  rewards remain exact; two decimal representations preserve recovered binary32 bits. Seven dependent
  tests and four evidence-boundary tests pass. Current candidate run ends in 0e0bce185f734575a05aff82ac4b6043.
- Corrected recovery evidence placement into a separate JSON file, keeping the native run ownership
  manifest's exact schema valid. Production publication, numeric gates and starter observation remain open.

### EN01/C12 — Full native content recapture

- Actual Unity 2018.3 export from a fresh imported source copy succeeded: five maps, 132 sheets,
  no C# compiler errors, exact typed source values, unchanged map/mesh JSON and sheet identity/order.
  The raw output preserves the actual prepared-scene hash and remains outside production content.
- Verified inventoried original inputs unchanged. Retained native report/output and removed the
  temporary project/Library. Fixed read-only Unity package cleanup within owned deletion boundaries;
  recovery of the first run's finalization is explicitly recorded in its manifest.
- Three native-result validation tests and 22 shared storage tests pass. This does not refresh the
  starter observation or prove normal gameplay; dependent release and numeric gates remain open.

### EN06/T04 — Managed Client boot diagnostics

- Migrated ClientBootSmoke to shared run ownership, Mongo/temp isolation, bounded retention and
  absence-preserving environment restoration. Successful temporary data is removed after owned
  process shutdown; failed diagnostics and requested KeepArtifacts data remain.
- Starter export retains its disposable-project guard and uses a unique scratch path, then copies
  validated output into the managed run. External artifact roots and spaces are supported.
- Early-build-failure regression passes on PowerShell 5/7 without launching Unity/Mongo. All 21
  shared lifecycle tests pass. Current Client re-observation remains pending, including the
  WeaponInventory.cs provenance mismatch; no observation hash was silently refreshed.

### EN01/C12 — Original BotNames and native YAML import evidence

- Explicit-input builders now stage the legacy catalog profile and score-streak policy alongside
  corrected sheets, with exact transitive hashes. Five dependent regressions pass. Current named
  score threshold checks preserve ratio/threshold/decay/one-bonus behavior. Unit-rule staging remains
  gated by a WeaponInventory.cs mismatch in the existing Client observation; re-observation is required.

- Complete source-sheet staging now re-extracts 132 sheets/78,955 cells and corrects all 390 reviewed
  scalar differences. Five regression cases cover candidate values, geometry conservation and
  evidence failures. The 6,045,583-byte candidate is retained by managed storage; production remains
  unchanged. Native recapture and dependent numeric/release validation are still required.

- Added reusable in-memory disposable-scene preparation. It changes only four affected scalar lines,
  verifies complete component semantics and row identities, preserves all other bytes and existing
  quoted names, and is idempotent. Four tests pass. The native probe now consumes this same function;
  full recapture integration and separate original/prepared provenance remain required.

- Added strict original APK/OBB BotNames verification and a hash-bound source report. All 269 current
  scene names match the complete original serialized payload; four existing export strings are truncated.
- A tiny managed Unity 2018.3 project reproduces exactly those four plain-YAML import truncations.
  ASCII-escaped quoted YAML preserves all 269 names. Probe results bind Editor/source/tool hashes.
- Six malformed-payload/Unicode regression tests and the original-source check pass. The successful
  probe removes its temporary project and Library; existing user projects/processes are untouched.
- Production content is unchanged. C12/EN01 remain open for lossless full recapture, dependent
  calculations and coordinated publication. See `Server/docs/BATTLE_SHEET_VALUE_AUDIT.md`.

- 2026-10-21: Plan created from source inspection and independent arithmetic reproductions.
  Moved 687 C# files (Backend 28, BattleServer 659), preserving every moved file's original bytes and
  namespaces. Only Program.cs remains at both host roots. Added a checked move inventory and
  relocation-safe source audits. Domain-library extraction and responsibility separation remain open.
- Fixed C05-C07 with 23 calculation boundary checks and legacy integration checks. Rename pricing
  rejects Int32 overflow, and its CAS includes expected revision/count; simultaneous free renames
  produced exactly one success. Instant-completion prices preserve the Client's float intermediates.
  Status heartbeats always supply Time; invalid input cannot refresh durable presence.
- Solution build passed with zero warnings/errors. Protocol checks and the selected economy checks
  passed. Legacy smoke passed 260 assertions; its owned run reclaimed 210,689,138 bytes of disposable
  data after stopping services, retaining logs. Eight artifact lifecycle/safety tests passed on both
  Windows Python 3.13 and WSL Python 3.10.
- The integrated `runtime --no-build --native-smoke` checkpoint passed all six selected stages.
  Full Battle tests passed 267,356 assertions in 757.9 seconds. Native smoke passed 74 live
  Mongo/HTTP/protobuf/UDP checks plus its storage/ordering suites, including cancellation evidence
  and pending/acknowledged outbox recovery across Worker restarts. It completed in 59.6 seconds and
  reclaimed 210,954,351 disposable bytes. Reports were retained under
  `Server/.local/test-runs/checkpoint-af97cf26369d466fb4963fff2915b94f/`.
- Added documented fast/runtime/source checkpoint selection and compact per-stage reports. The
  fast no-build gate passed in approximately 4.6 seconds on this workstation. PowerShell parsing and
  Linux smoke Bash syntax passed. Linux runtime and Unity/Android validation were not performed.
- Storage inspection found approximately 2.05 GiB in Server/.local, not the reported 100+ GiB.
  The largest retained item is a 1.40 GiB Unity geometry project. New owned runs separate disposable
  data from logs; bounded pruning defaults to preview and excludes active/pinned/unmarked evidence.
  Automatic approval review blocked deletion of one old unmarked DB folder without giving a
  specific reason. It was retained; the new owned-run lifecycle is verified independently.
- Full source checkpoint failed at the mission-catalog source audit described in V07; it is not a
  passing release gate. Runtime results above are separate from source provenance, real Unity/Android
  gameplay, production Linux verification, and measured network/calculation performance improvements.

### Buffered economy transaction increment

- C01/C02: replaced split blob/wallet/claim/complete publication with one replica-set transaction per
  action. It reads current authority, computes without I/O, publishes all changed blobs and balances
  with one revision increment, and stores the complete response in the same commit. Retries reuse
  captured time and random seed; execution has one linked 30-second deadline and at most four
  duplicate-insert retries. The old card-only CAS path and its update DTO were removed.
- C09: ApplyAsync returns the committed account. GetPlayerData passes it to following buffers and
  builds PlayerData from it. Both stale-caller storage tests and HTTP boot purchase/replay tests pass.
- C11: extracted a strict parser with canonical unique nonnegative indexes, exact typed fields,
  duplicate detection, count/ID limits and coherent optional Client metadata. All pending envelopes
  are parsed before the first boot mutation. Malformed input returns JsonFailure without partial
  application or an unhandled shape exception from the envelope parser.
- C17: removed receipt TTL indexes; current Client buffers have no authenticated replay deadline.
  Existing complete responses remain durable. Old unbound/null-result entries remain refused;
  receipts already erased by an earlier TTL deployment cannot be recovered or safely inferred.
  Receipt bounds and the ongoing storage cost are explicit in
  `Server/docs/BUFFERED_ECONOMY_PUBLICATION.md`.
- Eight real Mongo scenarios pass, including competing purchases, duplicate delivery, altered retry,
  receipt failure after the account write, service recreation after reply loss, failed rollback replay,
  historical claims, TTL migration/old replay, and fresh committed-account projection. Legacy HTTP
  smoke passes 331 assertions, including stable outcomes/current rollback fields on replay and no
  partial application of malformed request/boot input. The general native smoke remains a separate gate.
- Final integrated build passed with zero warnings/errors. The fast-plus-native checkpoint passed
  all six selected stages, including 74 live HTTP/Mongo/protobuf/UDP checks and its separate storage,
  card-consumption and restart checks. Native integration took 64.6 seconds. Reports were written to
  `Server/.local/test-runs/checkpoint-feba0a4d17424d8c97d78e64ee91ccfa/`; legacy reports were written to
  `Server/.local/test-runs/legacy-8e725782fa524431b9d6eeb67a84c750/`. Successful runs reclaimed about
  201 MiB each. V07 was rechecked and still fails at source provenance.
- Pure input checks passed 48 cases. Typed request string/Boolean readers turn incompatible JSON
  values into per-action JsonFailure without coercion; malformed durable/catalog authority remains
  part of C12/C13. The competing-wallet fixture forces both original transaction reads and requires
  a real recalculation; HTTP boot verifies purchase state survives a following pending buffer.
- Recovered Client timer review found that DeliveryTime is relative to currentTimestamp. Added
  private receipt metadata for the original delivery identity/deadline and ten golden projection
  cases so replay cannot restart an expired timer or adjust an unrelated upgrade. Seven rollback
  cases verify current ownership/wallet projection without modifying the canonical stored outcome,
  including rejection of a present null inventory blob. Full C10/C13 matrices remain open.
- Windows PowerShell 5.1 wraps ConvertFrom-Json arrays differently from PowerShell 7. Extracted replay
  assertions, used explicit object-array conversion, and verified seven pure scenarios on both shells.
  Artifact ownership tests now cover WAR_TEST_RUN_ROOT redirection (nine passing safety tests).
  This allows disposable DB data to live on a suitable local volume instead of the checkout drive.
- Final response-projection checkpoint: zero-warning/error solution build; 48 input, ten delivery-clock,
  and seven current-rollback checks; seven shell assertions on both PowerShell 5.1 and 7; nine artifact
  ownership checks on Windows and WSL; eight real Mongo scenarios; 331 legacy HTTP assertions; and
  all seven Windows fast/native stages passed. Native Mongo/HTTP/UDP integration reported its 74 live
  checks plus the separate storage/restart suites. The C: override run completed legacy smoke in
  12 seconds and native smoke in 48.4 seconds; each disposed about 201 MiB after stopping owned services.
  These local observations do not establish WAN or combat performance. Reports were written beneath
  `%LOCALAPPDATA%/WarFriends/ServerTests/test-runs/` as `legacy-554a2903207d478aa5427f7f30a6cef9`
  and `checkpoint-49145d430dac4894a3e4d2fb2ef22e48`. Source provenance V07 still prevents a green
  full source checkpoint. Full goal completion remains unproven and the unchecked backlog remains active.
- C03/C04 and C08 remain high-priority: card pool transfers, squad transitions and initial account
  session publication. Complete catalog/state validation, the exhaustive rollback matrix, domain
  extraction, performance measurements and V07 remain open. This increment does not complete the goal.
- C03 atomic transfer increment: extracted Backend card-pool parsing, immutable source policy,
  pure rules and HTTP adapter; Persistence commits inventory/deposits, donor reputation, cooldown,
  squad revision fence and receipt together. Source correction: 240-minute cooldown (14,400 seconds)
  and donor reputation 5/15/45. Self-withdrawal is refused; own RemovedCards remains supported.
  Malformed double-encoded entries no longer partially mutate a request. Checked Int32 arithmetic
  refuses inventory/deposit/reputation/deadline overflow. Optional OperationId binds actor/action/
  canonical intent; explicit blank identities and changed reuse reject. Current wire cooldowns are
  projected from committed actor state, including old keyed replay. The recovered Client sends no
  nonce, so unkeyed deposit retry ambiguity remains explicitly open; no Client files changed.
- C03 verification passed: zero-warning/error solution build, pure source/rule/parser/damaged-state
  scenarios, five real Mongo race/replay/rollback scenarios, eight existing buffer transaction
  scenarios, 338 HTTP assertions and all eight fast/native stages. Native smoke completed in 37.9
  seconds. Reports: `legacy-91408e8add46442face36a1a0111384e` and
  `checkpoint-a52890a170144c4c851af1598a81f8b4` under the LOCALAPPDATA test root. Successful legacy
  execution discarded 210,761,153 bytes of disposable Mongo data, retaining compact evidence.
  This does not verify full Unity gameplay, WAN performance, Linux service execution or V07 provenance.
- C04/T07 increment: extracted thirteen squad mutations and their source parsing/policy/admission/
  role/settings/projection responsibilities. One transaction now commits squad creation price/count,
  one/two-roster admission, rank/leadership mirrors, leave/kick and authorized settings. Removed the
  old standalone squad mutation helpers. Reverse membership reads are indexed and capped at two IDs.
  Source fixes include Member -> Veteran -> Coleader ordering, Leader-only founder/settings authority,
  three Coleaders, and direct non-Leader squad moves. Last-member leave deletes the squad; a Leader
  cannot abandon a non-empty roster. Invalid mirrors abort with a logged Client-readable maintenance
  result. No Client source/assets or invented general capacity/first-join reward policy were changed.
- C04/T07 verification: zero-warning/error solution build; six pure source/rule/parser scenarios;
  five forced competing-read races; thirteen account/roster write faults with full-state rollback
  comparison; 45 authenticated squad HTTP assertions; the existing eight buffer/five card-pool Mongo
  scenarios and 338 HTTP assertions; all nine fast/native checkpoint stages. Native smoke took 36.9
  seconds. Reports under the LOCALAPPDATA test root: `legacy-1c329680ea024da6a2d7428af940d21d` and
  `checkpoint-fe239e84f0af40ffbb582d72d9fbd155`. The successful legacy run disposed 210,802,732 bytes
  of Mongo data and retained compact evidence. Direct unkeyed retry identity remains explicit in C03;
  C08, the remaining structure/state/catalog/performance work and V07 are still open.
- C08 increment: extracted guest account/session parsing, immutable starter policy, orchestration
  and HTTP projection. Persistence now validates metadata/starter/session bounds before credential
  work and commits the generated password hash, session hash/expiry, Locale/optional exact DeviceToken,
  diagnostic UtcOffset and reviewed initial state in one insert at revision 1. Login rotates by current
  revision and returns the committed document; deleted/changed credentials and historical damaged
  sessions are refused without silent repair. The 600,000-iteration password work factor is unchanged.
- Source starter integer parsing now rejects fractional/underflow/overflow values exactly. Configured
  missing/malformed/empty catalogs fail startup instead of silently changing starting currency;
  catalog-free compatibility defaults remain only when no path is supplied. Direct action 13 now
  requires the complete validated DeviceToken/Locale tuple without changing presence on rejection.
  Closed provider compatibility remains closed; no Client or external provider integration changed.
- Thirteen transport/gameplay fixture insertion sites now use explicit trusted setup and skip
  password derivation they do not verify. Actual credential tests retain real hashing. Legacy smoke
  reuses its one owned Mongo process for account, allocation/inventory, rematch, buffer, card-pool and
  squad storage groups; it creates no extra data directory or Unity copy. Live queue fixture execution
  remains a separate selected gate rather than being implied by these storage checks.
- C08 verification passed: zero-warning/error solution build; four pure account/parser/source/startup
  scenarios; seven Mongo publication/session/failure scenarios; allocation/preparation/inventory/
  card-pack and rematch storage groups; 28 new account HTTP assertions alongside 338 base and 45
  squad assertions; all ten fast/native checkpoint stages. Native smoke took 35.7 seconds. Reports
  under the LOCALAPPDATA test root: `legacy-179edff803fa46a5b159e4a04ee00a74` and
  `checkpoint-ba800dcf9fb04ee48f5355993140fa43`. Successful legacy execution disposed 212,033,251 bytes
  of Mongo data while retaining compact evidence. A final build and focused account gate also passed
  after readability-only cleanup. C03, C10/C12-C16, architecture/performance work and V07 remain open;
  this does not complete the full goal or prove Unity gameplay, Linux runtime or WAN performance.
- C10 increment: separated pure buffered action calculation into `Legacy/Buffering/LegacyBufferPlanner`,
  grouped by feature. The coordinator retains the explicit frozen action allowlist, captured time/RNG
  seed, transaction boundary and wire replay. Existing action bodies were moved without a policy rewrite;
  the confirmed cosmetic response defects are the deliberate behavior changes in this increment.
- The recovered BuyDecal callback unconditionally reads DecalId/ExpiresOn. Owned no-op success now
  supplies both and preserves current expiry. Bound historical bare success is projected only with
  matching request identity and current ownership, without rewriting canonical evidence. New permanent
  ownership commits zero expiry, including a prior expired promotion. Invalid/missing/conflicting
  cosmetic evidence fails closed; nine focused replay/corruption checks pass.
- Added `War.LegacyContract.Tests`: the unchanged 1.4.0 ProcessBuffer/StringParser and enums execute
  against the original JSON runtime, with instrumented manager/UI boundaries. Five reviewed source
  hashes and the two original managed dependency hashes guard the extraction. No native Unity,
  Editor, full project/Library copy, extra Mongo instance or retired online service is needed.
  All 25 actions and 180 Client failure branches are represented by 1,188 matrix checks; 50 actual
  planner/projector scenarios cover the first producer inventory. Remaining catalog-backed producer
  branches and complete builder/caller tracing keep C10/V01 open. See `LEGACY_BUFFER_CONTRACTS.md`.
- Verification: solution build passed with zero warnings/errors; focused envelope/replay and callback
  gates passed; Windows legacy storage/concurrency/fault suites and 339 base + 45 squad + 28 account
  HTTP assertions passed. All 12 fast/native checkpoint stages passed; native smoke took 35.3 seconds,
  and the headless callback gate took 0.9 seconds on this workstation. Final legacy reports are under
  LOCALAPPDATA `legacy-45e7fbac730d476ca4e71b622c62c48d`; checkpoint reports are under
  `checkpoint-e9e939b636014349898be8de2cf77960`. The final legacy run reclaimed 212,033,401 bytes of
  disposable data. The callback test's complete Debug output is approximately 20.91 MiB.
- Read-only storage remeasurement: `Server/.local` is 2,835,174,015 bytes (about 2.64 GiB), and root
  `.local` is 80,842 bytes. The 1.40 GiB Unity geometry reference and historical unmarked data remain
  preserved. New tests use the owned lifecycle and minimum relevant gates. C12/C13, the remaining
  architecture/performance backlog and V07 remain open; this increment is not full gameplay,
  Linux/Android runtime, all-source provenance validation, or proof of a network speed improvement.
- C10 complete: added two static synthetic catalog fixtures (15,288 bytes total) and 149 populated
  producer scenarios. All 126 current literal action/result dispositions must execute successfully
  through both first-delivery and changed-authority assertions. Checks compare wallet, item identity/
  ownership, delivery evidence, inventory, card and cosmetic rollback with current authority and the
  decoded Client values. Original receipt outcomes remain fixed. The 50 earlier producer scenarios,
  1,188 Client matrix checks and nine bound cosmetic replay checks remain separate evidence.
- A bounded planner-method inventory now verifies the reviewed server result sets before oracle
  generation. Six scanner regressions cover helper/expression/block bodies, comment/string noise,
  duplicate/missing methods and unsupported literal syntax. This guard is not advertised as a full
  C# coverage collector. Fixtures are ordinary test input files; no new temporary project, export or
  database is created for these checks. Full builder/caller coverage remains V01.
- C19 found and fixed while tracing that source: purchase and tier gates compared zero-based Level
  with one-based catalog requirements. This delayed valid unlocks and made display-level-43 tier
  gates unreachable in the valid 0-42 rank domain. A pure LegacyRankGate now compares the displayed
  value across weapon/unit/cosmetic purchase and promotion, preserves zero gates and sentinel 999,
  and rejects invalid local authority. Initial/wire rank identity is unchanged. Thirteen producer
  boundary scenarios and unchanged compiled Client predicates verify the fix; six source-property
  hashes extend the existing five-source provenance review without changing Client files.
- Final verification passed: solution build with zero warnings/errors; all 12 fast checkpoint stages
  (including protocol, artifact, scanner and oracle checks); and Windows legacy Mongo transaction,
  concurrency/fault groups plus 339 base, 45 squad and 28 account HTTP assertions. The expanded oracle
  stage took 0.9 seconds on this workstation. Final reports under the LOCALAPPDATA test root are
  `checkpoint-5d252bab5f3e429093cf7dec9725f961` and `legacy-92c90e8e56dc44f699e45d827106676f`.
  The final legacy run reclaimed 212,012,779 bytes of disposable data. C12-C16, C18, architecture,
  measured performance and remaining V01-V07 work keep the full goal active; this increment does
  not claim full Unity/Android gameplay, Linux execution or measured network speed gains.
- C12 foundation: replaced mutable catalog JsonObjects with immutable scalar/row/sheet types and
  frozen reviewed identity/constant indexes under `Legacy/Catalog`. Parsing rejects malformed and
  duplicate envelopes, duplicate sheet types and ambiguous consumed identities instead of skipping,
  merging or choosing the first row. Source order is preserved for all 132 sheets/7,554 current rows.
  Unconsumed Packs/PlayerBots duplicate-name variants remain read-only data without a NAME authority index.
- Consumed prices/durations and linked upgrade rows now require exact nonnegative Int32 values;
  missing fields, fractions, numeric strings and overflow cannot become zero-cost authority.
  ConstantInt no longer casts double. Starter/card-pool/squad policy share exact indexed readers;
  the source negative GoldExpCoefficient (-0.175) remains valid. Shared integer parsing preserves
  exact exponent notation and Int64 endpoints while refusing underflow and tiny fractional tails.
  The account rule test now mutates input copies, proving it cannot edit a live catalog alias.
- Only base-item identities with validated price rows enter the upgrade index. The three unpriced
  starting-tier-zero turret combat tables remain outside it. Weapon/unit regressions for an owned
  slot naming the unrelated Constants sheet now return PriceNotFound instead of treating missing
  price fields as a free upgrade. The populated callback suite grows from 149 to 151 scenarios while
  retaining all 126 current result dispositions and the existing rank/receipt contracts.
- Configured startup now requires provenance metadata, eight consumed dependency sheets, needed
  constants, referenced stage sheets and coherent pack thresholds/counts. Package bytes have a
  recorded SHA-256 identity. The Unity export label and MainScene digest remain provenance claims;
  neither digest was rewritten and the known V07 current-scene mismatch remains unresolved.
  C12 stays open for the complete source identity/count/track/sentinel profile, non-player purchase
  admission and per-source provenance reconciliation. See `LEGACY_CATALOG_VALIDATION.md`.
- Verification passed: zero-warning/error solution build; eight focused immutable catalog/schema/
  numeric/provenance/binding scenarios; existing source, account, callback and rank gates; all 13
  fast/native checkpoint stages; and Windows legacy Mongo concurrency/fault groups plus 339 base,
  45 squad and 28 account HTTP assertions. Native smoke took 35.1 seconds and the expanded oracle
  stage 1.0 second on this workstation. Reports under LOCALAPPDATA are
  `checkpoint-01ebf404dcb44cb6af41c3ecdac77109` and `legacy-a2d21e991a7e4c0a974b2a961d5ff87b`.
  Successful legacy cleanup reclaimed 212,027,969 bytes of disposable data. Catalog tests use only
  in-memory inputs and existing small fixtures; no Unity copy, catalog export or extra Mongo was
  created. The full architecture, correctness, performance and validation goal remains active.
- C12 source profile / C20 upgrade authority: configured startup now checks all 132 sheets and
  7,554 rows against recovered row-class fields/types, component-declared counts, ordered identities
  and exact reviewed snapshot bytes. The empty Squads export stays explicitly closed. Normalized
  source hashes and a small embedded profile protect this existing export; they do not resolve V07
  or certify a fresh scene extraction. Read-only current-scene traversal confirms the 24 player and
  three helper identity sets without changing any Client asset or digest.
- Typed immutable upgrade tracks cache the source normal/special/Elite lanes and current-tier
  ceilings. The actual 1.4.0 player lane counts are 1,724/344/42. Fixed the weapon extra-row ceiling,
  normal-unit tier ceiling, Elite terminal purchase and parts-at-cap paths. Normal/instant completion
  proves ownership, current index and active normal delivery before debit/increment. Helper combat
  units are refused as player purchases, promotions, activations and equipment. Complete durable-state
  validation and special-track support remain separate work; no historical receipt/state repair is claimed.
- Testing uses nine catalog groups, eight complete release groups, the existing 1,188 callback
  checks/50 original producers/151 populated scenarios/126 dispositions/13 rank cases, and 63 new
  upgrade/admission scenarios. Ten unchanged Client upgrade getters/methods independently check all
  66 weapon and 24 player-unit tracks. Source review now has 21 entries; the two static synthetic
  fixtures total 20,290 bytes. New release corruption tests run entirely in memory. No Unity clone,
  temporary catalog export or additional Mongo instance was introduced.
- Verification passed: solution build with zero warnings/errors; all 15 selected fast/native stages
  in `checkpoint-5e83e0a67a9346f49b1b3dc6395f80e3` (native smoke 34.5 seconds); and legacy transaction,
  forced concurrency/fault suites plus 339 base, 45 squad and 28 account HTTP assertions in
  `legacy-1c95f3e57d4f4566b47fcd5b54fac0ac`. Both reports use the LOCALAPPDATA managed root. The
  successful legacy run reclaimed 212,024,106 bytes of disposable data. C20 is complete; C12 stays
  open for source-value and provenance reconciliation. The full goal remains active, with no claim
  of measured network/combat speed gains, normal Unity gameplay or Linux runtime verification.
- C15 complete: fixed the inconsistent configurable receive budget by requiring the existing
  1200-byte protocol envelope, including MAC, at shared Backend/Worker startup. Unsupported values
  fail before traffic; the Worker no longer clamps them. Existing codec/SDK/page behavior remains
  compatible. Added a focused transport selector to fast/runtime/full checkpoints, using actual
  loopback packets at 1199/1200 bytes, outbound 1201 refusal, invalid/frozen config and every page of
  a near-maximum reply transfer with full-width envelope/transfer IDs. It needs no files, Unity or Mongo.
- Final networking verification passed: zero-warning/error solution build, 314 focused MTU checks,
  152 actual Worker/two-SDK reply-transfer assertions, and all 16 fast/native stages in
  `checkpoint-bf22527dac4440169a21d0b8977d315d`. Native smoke took 34.3 seconds and reclaimed
  210,856,189 bytes of disposable data in `smoke-fe59a7031fee4ddbbb717fe094dfd1d2`. Reports stay under
  LOCALAPPDATA with bounded retention. Measured checkout storage remains about 2.64 GiB under
  Server/.local and 80,842 bytes under root .local; this is not evidence of a current 100-GB directory.
  Historical unowned databases and the Unity reference copy remain preserved. C12/C13/C14/C16/C18,
  architecture, measured performance and remaining validation keep the full goal active.
- C14 complete: extracted immutable dog-tag source policy, pure debt/VIP/refill calculation, direct
  callbacks and session/revision-bound persistence. Recovered PayOneDogTag retains negative debt;
  only availability/price clamps at zero. VIP contributes the source's two bonus tags, making an
  empty-base VIP refill 31 Gold. Regeneration/debit use widened intermediates and exact wire bounds;
  invalid/future state, underflow and incompatible starter capacity fail before publication.
- Removed unconditional penalty replacement and funds-only refill updates. Eight forced real-Mongo
  groups prove same-read refill/penalty races, conserved mixed outcomes, wallet/session fences,
  an older clock refusing a later cursor, corrupt-state refusal and atomic database write failure.
  This does not invent per-intent replay identity for the original nonce-free direct requests.
- Extracted PlayerData boot flow from the dispatcher and shared the checked wire clock under
  Legacy/Time. Boot applies pending buffers before projecting their committed account, then uses
  one clock for Time, base seconds/cursor and UTC midnight. Expiry resynchronizes both guarded
  fields without storing VIP capacity or deleting debt. Broader subsystem validation remains C13.
- Seven newly reviewed Client sections preserve every prior hash and bring the source inventory
  to 28 entries. Unchanged dog-tag getters/PayOneDogTag execute across 144 source combinations;
  invalid-authority and policy groups bring the focused oracle to 146 scenarios. Fourteen live HTTP
  checks prove VIP price, callback fields, debt, clock coherence and corrupt-state rejection. Existing
  buffered callback/rank/upgrade and account/squad transaction gates remain green; no Client file changed.
- Final C14 verification passed: zero-warning/error solution build; all 16 fast/native stages in
  `checkpoint-db80146d43984fa89e101390610c6a91`; and all legacy store/fault groups plus 339 base,
  45 squad, 28 account and 14 dog-tag HTTP assertions in `legacy-bca2a080d6f34457829f6ec01b319e8c`.
  Native smoke took 34.8 seconds and reclaimed 210,895,040 bytes; successful legacy cleanup reclaimed
  212,146,084 bytes. Reports remain under the bounded LOCALAPPDATA root. Source tests use existing
  files and memory, and dog-tag integration reuses the one owned replica without extra DB/Unity copies.
  The full architecture, correctness, measured-performance and validation goal remains active.
- C13 first increment: typed state no longer accepts numeric strings or turns present JSON null/
  empty text into a new object. The key-aware reader distinguishes a missing subsystem from a
  present null dictionary value. Bounded unique JSON, canonical integer keys, known-field case guards,
  required container/model-row checks and frozen serializer options now precede interpretation/write.
  Permitted root/nested metadata survives known-field mutations, including exact Int64 values;
  card-pool authority retains its reviewed stricter unmapped-field boundary.
- Split the 14 existing state DTOs into Legacy/State/Models, preserving public namespaces, ordered
  JSON fields, property types and initializers. Legacy/State owns contract validation and authority
  failure mapping; War.Persistence/Legacy/State owns the shared bounded JSON envelope. Invalid
  persisted typed state is separate from malformed client payload and cannot consume a failed-input
  buffer receipt. HTTP regressions prove BSON/JSON null, null required containers and numeric-string
  authority leave both damaged state and receipt capacity unchanged.
- Completed the six-Boolean notification Settings boundary under Legacy/Preferences and its
  persistence counterpart. Partial/unknown/coercive/duplicate/case-shadowed requests and repeated
  form fields are refused. Immutable complete replacements publish with current session/revision
  authority, retaining newer metadata and other subsystem blobs. Authentication, boot and login
  rotation validate present Settings; absent Settings remains absent, retaining the Client's distinct
  LoadEmpty defaults. Generic Settings blob replacement is closed. Missing-field migrations and
  the wider wallet/rank/catalog/ownership/delivery/progression schema still keep C13 open.
- Added four reviewed Settings source sections without altering prior hashes (32 total). The
  unchanged source POCO and LoadEmpty body execute through original Newtonsoft in the existing
  headless test. Five strict-state/default/metadata/byte-depth-node/serializer groups and three
  Settings contract/default/corruption groups create no exports or Unity copies. Six forced Mongo
  publication/conflict/metadata/session/fault groups and 30 live Settings/state HTTP assertions run
  in the same owned legacy replica; only the credential-rotation test uses real password derivation.
- Verification passed: zero-warning/error solution build; the strict-reader full runtime/native
  checkpoint `checkpoint-087ce4ea9ba5412380a1667304e6b977` with 267,669 battle/admission/SDK/geometry/
  real-UDP assertions (614.2 seconds) and native smoke (34.2 seconds); then all 16 final fast/native
  stages in `checkpoint-668d59964fae4a9ab1f4ec87c9e98add` (native 34.9 seconds). The legacy run
  `legacy-254de38bf8474ff29e71dd174a6a15e8` passed existing storage/fault groups plus 339 base,
  45 squad, 28 account, 14 dog-tag and 30 Settings/state HTTP assertions (456 total). Follow-up
  source/model layout, serializer and whitespace checks pass. C13 remains incomplete as documented
  in `STORED_STATE_VALIDATION.md`; no full durable-state or Unity/Android completion is claimed.
- Successful final native/legacy cleanup reclaimed 210,867,500 and 212,043,935 disposable bytes.
  Reports remain in bounded LOCALAPPDATA storage. Server/.local measures 2,835,340,352 bytes after
  the full runtime run; historical unowned data and the Unity reference copy remain preserved.
  The broader reconstruction, source-provenance, architecture, performance and validation goal stays active.

### 2026-10-21 — C13 root BSON and economy increment

- Added one reusable root wallet/rank/tier/counter validator under Persistence/Legacy/State. Eighteen
  numeric fields now require explicit BSON Int32/Int64 presence and exact client width; strings,
  doubles (including integral values and NaN), Decimal128, Boolean and null cannot become authority.
  Shared single/list account reads, both authentication channels, account creation before KDF,
  buffered planning/publication/replay, card-pool/squad transaction actors/peers and root projection
  refuse damaged authority. Global Skill and division MedalsBalance remain independent.
- Fixed source-backed defects: starting placement was ten despite the recovered constant being one;
  startup now reads LeaguePlacementMatches and freezes the zero-or-one domain. Root and buffered
  successor ArmyPower cannot exceed Int32.MaxValue / 10, preventing the recovered Client scaling
  property from wrapping. The original getter/League enum execute unchanged in the headless oracle;
  three new source sections bring the reviewed inventory to 35 without changing prior hashes.
- Extracted direct action 192 parsing into Legacy/Progression and its reusable compare-and-set write
  into Persistence/Legacy/Progression. It requires one canonical bounded integer, the expected
  revision/session and a live session deadline. Malformed assertions do not write; internal callers
  also revalidate the successor. Display assertions do not establish combat/economy authority;
  complete inventory-derived Army Power remains open.
- Added five in-memory BSON/domain/source-policy groups and a live root fixture in the existing
  owned Mongo replica. Final root coverage is 98 assertions, including invalid representations,
  required fields, authentication/boot/peer refusal, pre-calculation rejection, invalid successor
  rollback, cached-receipt refusal, source placement on registration, damaged login without rotation,
  direct input boundaries and changed revision/session/expiry. NaN no-mutation checks compare raw
  BSON bytes; fixture setup skips irrelevant KDF work while real registration keeps the work factor.
- Verification: the common root increment passed all 17 runtime/native stages in
  checkpoint-309b09a075924267bef43fe3076a6b85, including 267,662 Battle assertions (612.7 seconds)
  and native smoke (34.6 seconds). After the isolated direct-action extension, the final solution
  build had zero warnings/errors; all 15 fast stages passed in
  checkpoint-ac4bfa252f8e44da89b51ac92fcc6d9b; legacy-c64bf422b2b441f7ab32ca4c58a77800 passed all
  existing storage/fault groups and 554 combined assertions (339 base, 45 squad, 28 account, 14 dog-tag,
  30 Settings/state and 98 root Mongo/HTTP checks). Root checks include direct store guards, not only
  HTTP requests. No repeated full combat run or extra Mongo/Unity copy was needed.
- Successful native/final legacy cleanup reclaimed 210,894,390 and 212,271,210 disposable bytes.
  Reports remain bounded under LOCALAPPDATA. Current Server/.local is 2,835,348,996 bytes and root
  .local is 80,842 bytes; historical evidence remains preserved. C13 stays open for complete root/
  subsystem schemas, inventory-bound semantics, all successor boundaries and explicit migrations.
  Missing numeric authority and historical placement ten are refused without reset; the staged
  audit/evidence/preimage/CAS/replay migration guide is in STORED_STATE_VALIDATION.md. V07 and the
  wider architecture/performance/Client gameplay gates remain open.

### 2026-10-21 — C13 profile publication and T04 environment isolation

- Extracted status, device registration, language, country and rename from the large legacy router
  into Backend/Legacy/Profile and Persistence/Legacy/Profile. Immutable replacements require exact
  canonical fields and diagnostic agreement; repeated form values cannot select an identity.
  Non-economic writes rebase against the current same-session revision with eight bounded attempts.
  DeviceToken/Locale publish as one exact tuple, presence does not regress behind a newer heartbeat,
  and unrelated serialized metadata is retained. Present damaged profile/Settings is refused.
- Rename now has one immutable source-price owner, revalidated input and atomic name/count/Gold/
  revision publication against live session, expected revision/count and funds. Its response uses
  committed fields. The Backend pricing helper delegates to the same checked formula. The unused
  general TryUpdate API was removed; generic writes now remain only in analytics/tutorial callers.
  Status/LastAction add exact BSON presence/type checks and root ranges, bringing numeric fields
  to twenty. Missing old authority is refused rather than defaulted or silently repaired.
- Fixed C23: true rename insufficient-funds responses include source-required RenameCount and
  PlayerGold. Stale revision maps to WrongPlayerData, while a failed CAS re-reads session authority
  to identify revocation/expiry as InvalidToken. The exact original error branch proves both direct
  key reads and wallet recovery. Twelve new source sections bring the inventory to 47 with all prior
  hashes preserved; the original getter, enum, four callbacks and error branch execute headlessly.
- Added four pure contract groups, ten forced Mongo groups and 37 live profile assertions in the
  existing owned replica, without extra KDF work or Unity copies. Races force reads before writes;
  tests cover independent fields, current metadata/presence, session replacement/expiry, free/paid
  rename competition, corrupt profile/Settings, refused policy/consent/funds and database write failure.
  Root Mongo/HTTP coverage expands to 122; final legacy-78d3a9f58a764a468788b1e5da009102 passed all
  old storage/fault groups and 615 combined assertions (339 base, 45 squad, 28 account, 14 dog-tag,
  30 Settings/state, 122 root and 37 profile). Combined counts include direct root store guards.
- The shared BSON/profile increment passed 267,724 full Battle assertions in 618.2 seconds at stage
  16 of checkpoint-8b1d70ddb8c44679892ffe69fba9a348. That report failed overall: native startup exposed
  a real same-shell environment leak. PowerShell 7.6.7 restored an originally absent variable as
  empty; Legacy__ContentPath therefore made the next Backend reject an explicit empty catalog path.
  The environment provider now restores absence while retaining explicit empty/value states.
  Catalog failure policy was preserved. PowerShell 7.6.7 and Windows PowerShell 5.1 pass the isolation
  regression; checkpoint fast/runtime/full selection now includes this small, process-free stage.
- After the isolated error-contract and environment fixes, the final build had zero warnings/errors.
  The same-shell legacy run verified all nine environment values/presence states before the next
  suite; checkpoint-b6e56549c63a4b93a843304134040391 passed all 17 fast/native stages, with native
  smoke at 34.4 seconds and its 74 live integration plus separate storage/recovery checks. The full
  combat run was not repeated for the isolated HTTP error/tooling changes. No Unity/Android or full
  source-fidelity completion is inferred; V07 remains open.
- Successful final legacy/native cleanup reclaimed 212,372,400 and 210,894,350 disposable bytes.
  Current Server/.local is 2,835,357,640 bytes; root .local is 80,842 bytes. Logs/failure evidence
  remain bounded in LOCALAPPDATA and unmarked historical data is preserved. Added concrete C21/C22
  analytics overwrite/tutorial pending-identity races with source review, migration and forced-race
  requirements. C03 nonce identity, C13 schema/successor migrations, T02/T04 remaining producer/Linux
  work and the architecture/performance goal remain incomplete. See PROFILE_PUBLICATION.md and TESTING.md.

### 2026-10-21 — C21 current-state analytics acknowledgements

- Replaced the stale whole-blob SetAnalyticsFlag router helper with Backend/Legacy/Analytics action
  mapping and Persistence/Legacy/Analytics validation/publication. Seven closed identities patch only
  their source flag on the latest session/revision snapshot, with eight bounded CAS attempts.
  Repeated true flags return the current account without another write/revision. Diagnostic payloads
  cannot choose an identity; generic analytics replacement is closed.
- Added shared validation of all 33 recovered field types/counter widths, canonical known names,
  source-null text/history, complete transaction rows, finite source-float money and known count
  bounds. Underflowing nonzero money is refused even beyond double precision. Unique bounded JSON
  and exact unknown numeric metadata are retained without partial DTO serialization or history
  truncation. Missing state is distinct from present null/blank/non-object/damaged state.
- Applied the contract to shared single/list reads, both auth channels, creation before KDF, boot,
  buffer planning/current-player reads and buffered successor publication. The chat marker uses the
  same read/write path, can initialize truly absent analytics before a shown flag, and accepts only
  canonical nonnegative Client Int32 text. Current-snapshot CAS prevents direct flags from erasing an
  actual intervening buffered transaction or its receipt. No rewards are derived from acknowledgements.
- Seventeen reviewed source sections preserve the prior 47 hashes and bring the inventory to 64.
  Original field/transaction declarations, constructor body, six builders, five callbacks, Elite
  request and chat property execute through instrumented boundaries. Four headless groups compare
  source shape/defaults/flags/chat behavior and prove metadata/corruption constraints. Eight Mongo
  groups force both reads before writes, an actual planner/buffer transaction between flag read/write,
  session rotation/expiry, damaged state, invalid internal successors, bypasses and database refusal.
  Seventy-nine HTTP assertions cover all routes, replay, diagnostics, boot and corrupt auth/peer reads.
- Verification: final solution build had zero warnings/errors; all 18 runtime/native stages passed
  in checkpoint-6832749e59f74c8cb36dddaec4052f0e, including 267,663 Battle assertions (610.0 seconds)
  and native smoke (34.4 seconds). Final legacy-f89400720b624c3f8de40b45547d0d7e passed the existing
  storage/fault groups and 694 combined assertions (339 base, 45 squad, 28 account, 14 dog-tag,
  30 Settings/state, 122 root, 37 profile, 79 analytics). Combined counts include direct root guards.
- Successful final native/legacy cleanup reclaimed 210,894,304 and 212,591,952 disposable bytes.
  Server/.local now measures 2,835,366,284 bytes; root .local is 80,842 bytes. The new fixtures reuse
  one owned replica with no extra credential derivation, Unity clone or retired service. Reports and
  failure evidence remain bounded under LOCALAPPDATA; unmarked historical data is preserved.
- C21 is complete at its stated flag/current-publication boundary. C13 still owns complete economic/
  receipt lifecycles, private schemas and missing-field migration; C22 tutorial pending identity is
  next. Generic Update remains in tutorial paths and the fixture-era generic SetSerialized API still
  needs final ownership cleanup. C03, broader architecture/performance work, V07 and real Client
  gameplay gates remain open. See ANALYTICS_PUBLICATION.md and TESTING.md for exact evidence.

### 2026-10-21 — C22 tutorial identity and managed test storage

- Moved tutorial request/callback handling into Backend/Legacy/Tutorial and persistence into
  Persistence/Legacy/Tutorial. Version 1 binds one canonical battle ID to pending/terminal state;
  required exact BSON fields and legacy mirrors are checked at shared account/auth/boot/buffer reads.
  Eight bounded attempts publish one ID/mirror/revision tuple under the live current session.
  Matching replay is read-only and returns current server XP, preventing delayed acknowledgement
  from rolling back newer progress. Client outcome/economy assertions grant nothing.
- Legacy empty/pending state migrates only with its exact old preimage. A completed Boolean whose
  old writer discarded the ID remains readable without reopening onboarding, but cannot bind a new
  request as historical proof. A forced replacement of pending A with B makes old end A fail without
  clearing B. Duplicate starts/ends, session rotation/expiry, damaged state and Mongo write refusal
  conserve account authority. The final generic Update API and fixture-only SetSerialized API were
  removed; trusted card fixture changes now live in the test assembly.
- Seven reviewed Client sections preserve all prior hashes and bring the source inventory to 71.
  Start/dispatch, the contiguous XP/tutorial excerpt and wrong-battle error branch execute unchanged
  with instrumented boundaries. The full classic callback is hash-reviewed, not full gameplay proof.
  Four pure groups, eight forced Mongo groups and 20 HTTP checks reuse the existing owned replica,
  without extra password derivation, Unity copies or retired providers.
- The first runtime run, checkpoint-104039bc582843238ff7abc59dca6abc, failed its Shotgunner UDP check
  after 610.6 seconds and did not reach native smoke. Both peers saw five pellets; the subsequent
  scan test wrongly required that count to survive another live read. The focused check now proves
  both peers saw the same five IDs, compares snapshot/scan IDs only at equal ticks, and replays the
  frozen scan's exact original pages after a deliberate 100-ms advance. A later scan may capture four
  longer-lived cosmetic trails after the real pellet hits. Compact tick/count diagnostics remain;
  production projectile behavior was not changed. Two focused runs passed before the final rerun.
- Final verification: zero-warning/error solution build; all 18 runtime/native stages in
  checkpoint-9b6116be50024b24bf74e33643b247f1, including 267,727 Battle assertions in 624.6 seconds and
  native smoke in 34.4 seconds. Legacy-ebaf25f26a53408f99cb25cc4a55fb8c passed all storage/fault groups
  and 714 combined checks (339 base, 45 squad, 28 account, 14 dog-tag, 30 Settings/state, 122 root,
  37 profile, 79 analytics, 20 tutorial). Root counts include direct store guards. Successful native/
  legacy cleanup reclaimed 210,894,626 and 212,793,397 bytes; the existing Mongo service stayed running.
- New v2 test manifests bind PID to Windows creation FILETIME or Linux boot UUID/start ticks. Final
  disposal rejects a changed/unverifiable owner; retention distinguishes PID reuse while preserving
  inaccessible/legacy/running evidence. Nineteen lifecycle checks pass on Windows and WSL.
  Checkpoint console stages now redirect TEMP/TMP/TMPDIR into their disposable run data, preserving
  the parent environment and avoiding persistent build-server temporary paths.
- The full runtime process started before temporary-root redirection was added. That tooling change
  passed all 16 fast stages in checkpoint-18709fa992a54f73a2b8895084333100. Real UDP proof run
  temporary-root-proof-fcc0fc3a55ea46bea5f5d1bb4483a1bb confirmed C# Worker temporary output stayed
  inside its owned root and successful disposal removed all 1,072 bytes. Direct console/independent
  producers still need migration; T02/T04 are not closed by this increment.
- Read-only inventory found 14,067 WarFriends-prefixed OS temporary entries totaling 3,267,011,658
  bytes, including a 1,430,988,111-byte Unity audit copy and older Mongo fixtures. These unmarked
  historical entries remain preserved. Current Server/.local is 2,835,383,572 bytes and root .local
  is 80,842 bytes; this is not evidence of a current 100-GB directory. C13/C18, remaining architecture,
  measured performance, source-provenance V07 and actual Client gameplay gates keep the goal active.

### 2026-10-21 — S04 first Domain extraction and C24 reproduction

- Used semantic compilation to inventory the actual Backend/Persistence battle references and their
  transitive dependencies. The source-content closure reaches runtime factories and native rope
  validation, so it cannot be moved wholesale into Domain without preserving the wrong dependency.
  The first phase extracts the core contracts/rules while leaving those specific next seams explicit.
- Added the server-only War.Battle.Domain project with only a Shared project reference. Thirty Worker
  sources moved fully and three retained runtime code after their shared declarations were split out;
  one authenticated queue identity moved from Infrastructure. Sixty-nine extracted types now have
  individual files. The new queue policy and assembly visibility metadata bring Domain to 71 authored
  C# files. Existing public namespaces, constructor/JSON order and source revision values are retained.
- Persistence now references Domain/Shared and has no compiled Worker or signer dependency. The
  300-second queue window has one Domain policy owner; the signer's old constant is an alias. Keys,
  signing-domain derivation and token verification stay in Infrastructure. Shared/Client remain
  portable. Backend still references the Worker for content types; S04 is deliberately not complete.
- Extracted canonical terminal validation from TerminalOutbox into BattleTerminalEvidenceValidator.
  Backend, Persistence and statistics use it directly; the old outbox method delegates for source
  compatibility. File headers/checksums, atomic publication, recovery, forwarding and retention stay
  with the Worker. The card-entity range has one shared constant without changing its value.
  Mission runtime factories are source-compatible extensions outside the immutable Domain catalog.
- Moved the unchanged ordinary-card resource with its loader, preserving its logical name and SHA-256.
  Updated source audits and generated documentation paths. Kept all 687 original root moves and added
  the exact 34-origin/69-target extraction manifest. Seven Windows/WSL guard groups reject missing/
  duplicate destinations, source retention errors, escaping paths and malformed metadata. Sixteen
  compiled boundary assertions verify type ownership, allowed references, resource ownership,
  Persistence independence, portable SDK separation and queue policy agreement.
- Final zero-warning/error build and all 20 runtime/native stages passed in
  checkpoint-77fcac4a5d724f3aa4308bfafa774af0: 267,679 Battle assertions in 714.2 seconds and native
  smoke in 35.6 seconds. Legacy-565a3081136543388dda57f8124fe343 passed all storage/fault groups and
  714 combined checks. Successful native/legacy disposal reclaimed 210,895,396 and 212,802,081 bytes.
  The full checkpoint's owned temporary data, including 30 observed directories, was removed too.
  The live Shotgunner check captured tick 540 -> 541 with four trails and replayed its exact frozen rows.
- Release publish proof domain-publish-6aaaee848aa841e4bcac7d9c7ea607b8 verified that both hosts ship
  the same Domain DLL and only their own runtimeconfig, then reclaimed all 31,931,439 disposable bytes.
  The proof also confirms Backend still ships/requires Worker content. Release publishing overlapped
  runtime verification, so elapsed times are not a performance comparison. All four run markers are
  passed with disposable data absent. No actual Linux service, Unity/Android or V07 closure is inferred.
- A compiled Domain reproduction confirmed C24: a valid two-player manifest is accepted, and the
  same GUID supplied as 32 characters and a space-padded 34-character alias is also accepted as two
  players. Guid.TryParseExact trims padding while the distinct set compares raw strings. C24 records
  strict shared identity policy, scope, negative cases and no-publication requirements; this phase
  preserves behavior and does not claim the defect fixed.
- Current Server/.local measures 2,835,436,114 bytes; root .local remains 80,842 bytes. Managed run
  reports remain bounded and historical unowned data is preserved. Continue with canonical identity
  correction and the remaining content/factory/native boundary before simulation extraction. S04,
  C13/C18/C24, remaining structure/performance/testing and Client gameplay gates keep the goal active.

### 2026-10-21 — C24 exact identity and T04 owned temporary storage

- Fixed the compiled same-GUID alias reproduction with one portable CanonicalGuid policy. It checks
  exactly 32 lower-case ASCII hexadecimal characters without parsing, casing or allocation. All 217
  call sites in the seven authored Server projects now use that policy; the audit found no remaining
  GUID parser gate. Opaque match/provider/content IDs keep their existing contracts.
- Manifest, allocation, queue/grant, simulation owners, terminal evidence, reusable account reads,
  buffer planning/publication and SDK readers reject malformed identities. Probe/match issuers clone
  claims before checking/signing, and readers independently reject correctly MACed aliases. Cover
  claim/release compares exact canonical owners. Stored account damage fails before password KDF or
  session rotation; new drafts acquire their server-generated ID before insertion. C13 repair and
  complete subsystem validation remain separate.
- Five protocol groups cover the independent parse/roundtrip oracle, all 128 ASCII values in every
  position, zero/random GUIDs, control/Unicode/alternate forms, issuer/reader refusal and a warmed
  zero-allocation observation. Five battle groups cover actual engine terminal evidence too. Four
  modern Mongo groups and sixteen added root groups prove no document, receipt or planning changes.
  Three correctly signed malformed rosters return 400 without journal/outbox publication.
- The first full run, checkpoint-6f490bf4c71845da8b2093f17c5be28a, reached an old assertion requiring
  uppercase cover normalization. Its corrected scenario proves alias refusal and conserved exact
  ownership. Final build had zero warnings/errors; all 20 runtime stages passed in
  checkpoint-16bb93b8d26c4e7380ea0d1f6e336daa with 267,681 Battle assertions in 716.4 seconds.
  Native smoke-b8fbb2032d3d458b802c43d09ac0c0b6 and legacy-cc5b682bfde046d7b414297525a88c3b then
  passed sequentially: 74 native checks plus the three new roster cases, existing storage/fault groups,
  four modern identity groups and 730 combined legacy checks. C24 is complete for exact identity.
- Windows native/legacy scripts now validate their live parent creation identity before setting
  TEMP/TMP/TMPDIR under their own data/temp. Both actual scripts restored all seventeen observed
  caller variables in one shell and reclaimed 210,894,508 and 212,903,892 disposable bytes. Linux
  smoke exports equivalent paths after the owner check. The lifecycle suite passes 21 Windows/WSL
  cases, including wrong-parent and already-completed refusal; actual Linux services remain open.
- Moved MixedBattleUdpFixture and army-perk source tampering out of explicit Server/.local paths.
  Added focused checkpoint cases with owned logs/temp and an explicit result case name; default
  developer/runtime/source gates keep their scopes. CLI validation rejects missing/mismatched/unknown
  cases and focused/native combinations before execution. This permits a small relevant test without
  a full combat run, extra Mongo replica, Unity import or an unchanged rebuild.
- Final build and all 19 fast stages passed in checkpoint-cac31c82071a4493ad402c7537fe2b6e. Managed
  cases checkpoint-273896370a454ec3bc2142c6d34535b3 (46 army-perk assertions),
  checkpoint-3cf4994443814836b409eff948b93c17 (four Shotgunner UDP assertions) and
  checkpoint-95d323915321423bbcf3acc54d70d6a2 (12 mixed grenade two-peer checks) passed. The mixed
  fixture logged its owned data/temp path and that data was removed on success. WSL CLI/Bash syntax
  checks passed. The path/runner-only increment did not repeat full combat/native/legacy suites.
- Seven remaining C# test files mention .local for other Worker fixtures or Unity export consumers;
  review those producer/consumer pairs next. Existing unmarked history stays preserved. T02/T04/T05,
  S04's content/simulation boundary, other correctness/performance items, V07 and real Client gameplay
  remain open. No comparative network-speed or Linux/Unity runtime improvement is inferred.
- Final read-only inventory: Server/.local 2,835,453,402 bytes (2.6407 GiB, 34,755 files), root .local
  80,842 bytes. Managed LOCALAPPDATA storage was 1,602,577 bytes across nine retained children.
  The reported 100+ GiB is still not present in the inspected paths. Only the original MongoDB service
  remains running; native/legacy test replicas stopped before successful data cleanup.

### 2026-10-21 — S04 complete shared content and simulation extraction

- Inventoried the current Worker with Roslyn against its actual framework/project references; both
  semantic passes reported zero compilation errors. The original 249-type content closure reached
  mutable bullets and native rope. After splitting six projectile factories, shared ballistics/rocket
  limits and managed helicopter pose validation, the 223-type content closure reached neither.
- Domain now owns the complete shared content package and loadout policy. Simulation owns mutable
  matches, weapons, entities, objectives, event/statistic ledgers and native adapters. Backend and
  Persistence reference neither Simulation nor the Worker. Domain references Shared; Simulation
  references Domain/Shared only. Signing, UDP, local journals and Backend adapters stay outside the
  rule libraries. The Worker now has 45 C# sources; Domain has 306 and Simulation 611.
- Six factories accept named BulletLaunch/WeaponStageSelection value inputs with at most four
  parameters. The selected single-bullet branch draws its original roll; shotgun per-pellet order is
  unchanged. Source coefficients, offsets, gravity, height offset, rocket cap and pose tolerance are
  retained. The mutable flight constructor no longer makes source catalogs depend on simulation.
- Processed 600 source files into 235 additional Domain and 610 Simulation files. The extraction
  manifest now covers 631 origins and 914 unique destinations; original 687 root moves remain intact.
  Exact declaration checks passed for all 1,021 moved/split type parts after seam extraction. Sources
  use LF, retain namespaces/member order and have no multiline literal affected by normalization.
  Relocated library files have at most one public top-level type. Existing cohesive internal helpers
  and partial families remain grouped. Empty old simulation directories were removed without
  deleting retained files. No Client asset or content artifact changed.
- GrenadeRig moves with its loader to Domain. GrenadierCornerMuzzles and GrenadierPrimaryWeapon
  move to Simulation; OrdinaryCardIdentities stays Domain-owned. All four resource names/bytes stay
  source-pinned; the Worker embeds no duplicate. Compiled project checks grow from 16 to 57 and verify
  actual ownership, allowed dependencies, no Domain native imports, value launch contexts, catalog/
  factory separation, resource loaders and portable-SDK independence. The old selector stays an alias.
- The first full run, checkpoint-4c82b8c807dd473282ae5ffc6bfc6278, failed after 112 seconds because
  BattleAbortReasonCoverageTests still searched the Worker for engine files. The test now searches
  Simulation and still refuses an empty scan. Updated the matching Python audit and included it in
  fast/runtime gates. All 62 terminal reasons are covered on Windows/WSL; the seven extraction guard
  groups and exact layout inventory also pass on both systems.
- Final zero-warning/error build and all 22 runtime/native stages passed in
  checkpoint-f051e80184bb4457a8aa113664d70083: 267,792 Battle assertions in 598.4 seconds, native smoke
  in 35.9 seconds. The Shotgunner scan observed tick 440 to 441 with four retained rows. Native
  smoke-92afe0e497514d8c9a44e256837cea77 passed 74 live checks and the three signed-roster cases;
  legacy-a0cd6fb7fcf74441a81a5b8f9a1e4807 passed storage/fault groups and 730 combined legacy checks.
  Native and legacy reclaimed 210,894,681 and 212,586,588 bytes after stopping their owned processes.
- Added reusable TestBattlePublish.ps1 with managed fresh destinations, compact reports and successful
  data cleanup. Release battle-publish-33513c0a06164390bf9a0908192310ca passed on Windows PowerShell:
  Backend contains neither Worker nor Simulation; Worker contains Simulation but neither Backend nor
  Persistence. Each has only its own runtimeconfig, and their Domain SHA-256 is identical:
  8bf850fc0ebd298ebe6e541e334df920e56456bc8f311f904844f5de3339a1a3. Disposal reclaimed 28,659,849 bytes.
  The managed publish proof does not package or execute native physics; both fresh outputs report no
  WarRopePhysics.dll. Native provisioning and Linux/Unity runtime remain separate deployment gates.
- The independent structure-source-audit-5aaeb1dc67144ac0a5360fa9dd684e93 confirmed the existing V07
  failures in mission, score-streak and PvP bonus scene binding; the separate card identity audit also
  rejects scene provenance. Co-op spawns, card inventory, bonus spawn areas, Photon ledger and portable
  hashes passed. Its initial terminal-path failure was repaired and the standalone 62-reason audit
  passed on both systems. No digest was replaced to hide source damage. Full-source green is not
  claimed. Runtime/native/legacy/publish ran sequentially; elapsed time is not a performance comparison.
- S04 is complete for project boundaries. S05/S06 composition/feature dispatch, S07-S09 runtime state
  and ports, other correctness/performance/testing items, V07 and actual Client gameplay remain open.

### 2026-10-21 — C16 startup policy and S05 first composition increment

- Backend now captures validated database coordinates, frozen API/auth limits, shared battle keys/
  endpoints, selected template/catalogs and legacy starter/HTTP policy before constructing Mongo
  clients. Worker captures the same supported key/port/endpoint rules before content, journals or
  sockets. Invalid supported settings exit 1 with bounded diagnostics, without printing secrets.
- Missing Legacy content now needs explicit AllowCatalogFreeStartup=true. Supplied blank, padded,
  missing, malformed or unreviewed content still fails. Native connectivity scripts choose this
  mode deliberately; legacy smoke normally loads the reviewed source and requires an explicit
  switch for its missing-source compatibility path. README/.env and BACKEND_STARTUP.md describe it.
- Infrastructure/Configuration owns common key material, nonzero/different key validation, exact
  supported Int32/Boolean parsing and endpoint constraints. Domain/Simulation stay independent.
  The extraction manifest now has 632 origins/915 destinations; compiled boundaries pass 62 checks.
  Backend has 144 authored sources, Worker 45, Domain 306 and Simulation 610. The eight extraction
  guard groups, 21 artifact checks and 62 terminal-reason audit pass on Windows and WSL.
- AddBackendServices groups deferred persistence, legacy, battle/provisioning and limiters. Hosting
  owns store initialization and pipeline composition; Transport/Http owns failure/HTTPS middleware.
  One container-owned control HttpClient is disposed at shutdown. Backend Program is 375 lines,
  but route/use-case extraction remains S05. C25 records a discovered internal result-size status
  inconsistency and requires a native reproduction before its separate correction.
- New focused selectors prove ten startup policy groups and fifteen real invalid Backend/Worker
  processes fail before database initialization/outbox creation. They use owned temporary logs,
  disable crash dumps and have process deadlines. Fast/runtime now have 21/23 stages without build
  or native smoke; runtime includes actual refusal processes. Debug is the default test configuration;
  --no-build/-NoBuild must follow a matching Debug build, not only a Release build.
- The first full run found old fixtures representing absent paths with empty strings; they now
  omit configuration. A later run found positive co-op/pose fixtures using all-zero signing keys;
  they now use a valid deterministic nonzero key. Dedicated zero-key refusal checks remain intact.
  Failed reports are checkpoint-4af297a6cbfe48c18dae7a61f3ed8b59, the stale-Debug repetition
  checkpoint-9adba723c8ee49078e4b1b01ef738850, and checkpoint-2398f83912cc4b5183a1e4d0e48561b7.
- Fresh independent Release publish battle-publish-f7cb32dba2414297b9301f5b08f757b5 passed and
  reclaimed 28,689,957 bytes. Graphs remain independent and the Domain digest matches the prior S04
  publish. This is managed graph verification; native distribution and actual Linux gameplay retain
  their separate gates.
- Read-only inventory remains 2,835,453,402 bytes in Server/.local and 80,842 bytes in root .local.
  No 100-GB .local folder was found in these measured paths. Historical data stays preserved;
  new runs use bounded LOCALAPPDATA storage. TESTING.md identifies all seven direct .local producer files
  and their Unity consumers. T02/T04/T06 remain open for that coordinated migration and project leases.
- Final Debug solution build passed with zero warnings/errors. All 24 runtime/native stages passed in
  checkpoint-a0f862221de147fcb8e18ebc2b130200: 267,795 Battle assertions in 611.8 seconds and native
  smoke in 34.5 seconds. The valid Shotgunner scan observed tick 567 to 568 with five active rows/pellets.
  smoke-518076a34b6a4eb0b491eacedf4a84ba passed 74 live checks plus three signed-roster refusals and
  reclaimed 210,856,409 bytes. legacy-5f523a2d12b44f618147061960d48a51 passed storage/fault groups
  and 730 combined legacy checks, reclaiming 212,845,753 bytes. Native/legacy ran sequentially.
  C16 is complete; S05, C03/C12/C13/C18/C25, runtime state/performance/testing work, V07 and actual
  Unity/Linux/Android gameplay remain open. No content digest or Client asset was changed.
  Final managed storage contains 1,625,076 bytes across nine retained runs; disposable data is gone.
  No test Backend/Worker/Mongo process remains; the original mongod service PID 6164 is preserved.

### 2026-10-21 — S05 modern HTTP ownership, C25 and T04 Release queue gate

- The Backend portion of S05 is implemented: Program.cs is 27 composition lines instead of 375. Maps own
  health, account/profile, probe, grant/reconnect, queue, rematch and internal HTTP. Typed application
  services preserve existing use-case order, failure codes, replay, rollback and durable publication.
  They receive no HttpContext and perform no request-service lookup. ApplicationHttpResults owns
  the common protobuf failure mapping; stores retain atomic persistence and pure projections/rules
  remain separate. Backend now has 173 authored C# files. Legacy dispatch remains S06.
  The final item audit keeps S05 open for the Worker's remaining 263-line composition/control root.
- A compiled nineteen-route graph verifies exact methods, paths, uniqueness and auth/api limiter
  metadata without starting Mongo or listeners. Four pure groups also prove declared size refusal
  before reading, unknown-length consumption no greater than limit + 1, exact boundary and control
  MAC payload/domain/clock checks. The bounded reader never appends the excess byte and clears its
  pooled buffer. Thirty-three new/rewritten feature, test and harness files pass line hygiene.
- C25 first failed native smoke-19e441cac55d4f7d8f173ce9b7a038b3 with declared result oversize 404.
  Shared bounded reads now return 413 for declared/chunked excess at the existing 65536/2048 route
  budgets. Twenty-two real internal HTTP checks prove limits, valid/stale/wrong-domain signatures,
  zero result writes on refusal and accepted terminal bytes/replay without settlement. Both native
  smoke scripts run them. No Client/protobuf/gameplay contract or content digest was changed.
- Startup review found a C16 gap: driver namespace validation accepted database names that the
  account store refused later. A pure regression failed on bad-name before the fix. Backend now
  reuses AccountStore's exact 1-64 ASCII letter/digit/underscore rule before client creation. Real
  process refusals now cover seventeen cases. The focused checkpoint is
  checkpoint-f24882ef608b4db7aa3264bb49c8e11b; the first 22-stage fast run is
  checkpoint-5b5fdd13de6648c3bbff72370e1d86f3.
- New TestBackendQueue.ps1 builds Release, creates one owned replica, bounds its console lifetime,
  stops owned processes, restores temporary environment and uses existing retention. The C# queue
  fixture writes inside owned TEMP instead of Server/.local. Release
  backend-queue-a50d690cc4ae4776a8f95d88c38618e8 passed stable grants, reconnect, scoped cancellation,
  deferred/frozen preparation, multiple actual Backend restarts, Worker outage/recovery and ordinary
  same-opponent rematches; cleanup reclaimed 212,662,186 bytes. No Unity executable/project was
  supplied. Its recovered-source adapter checks are headless, not normal Unity gameplay proof.
- Final Debug and Release builds passed with zero warnings/errors. All 23 selected fast/native stages
  passed in checkpoint-1849f10f9c2d4be2904bffe3fe0bde90; native smoke took 35.1 seconds.
  smoke-0dadd44f3a994dc5baabe4393c49aff4 passed 74 live checks plus twenty-two internal HTTP and three
  signed-roster cases, reclaiming 210,894,565 bytes. legacy-2af8195e718b4b1da6aba8eba1310cc9 passed
  storage/fault groups and 730 combined checks, reclaiming 212,841,841 bytes. Fresh independent
  Release publish battle-publish-2319ab7b6f594cfea079122af0d43a55 retained the same Domain digest and
  reclaimed 28,721,433 bytes. Full combat was not repeated for this Backend-only extraction; the
  preceding C16 full runtime remains its own evidence. Windows/WSL layout, eight extraction guard
  groups, 21 artifact checks and Bash/PowerShell syntax passed. Linux service execution is not claimed.
- Current Server/.local is unchanged at 2,835,453,402 bytes; root .local remains 80,842 bytes. Managed
  storage is 213,088,665 bytes across ten retained runs, including 211,164,178 bytes of the deliberate
  failed C25 reproduction for diagnosis. Successful runs removed disposable data. Only the original
  mongod service PID 6164 remains; there is no test Backend/Worker/Mongo process.
- C26 records a newly identified binary-versus-JSON terminal-envelope capacity mismatch. Resolve that
  bounded transport contract with a valid large-terminal HTTP proof before broader S06 dispatch work.
  C03/C12/C13/C18, the Worker portion of S05, S06-S09, performance/testing/Unity lease work, V07 and gameplay remain
  open. Neither S05 nor C25 closes the full goal. See Server/docs/BACKEND_HTTP_STRUCTURE.md.

### 2026-10-21 — S05 Worker composition, C26 terminal capacity and C27 connection lifetime

- S05 is complete for both hosts: Backend Program remains 27 lines; Worker Program is 22 instead of
  263. BattleHostExtensions owns frozen singleton/host setup. Transport/Control owns nine health,
  registration/reconnect/cancel and result poll/find/ack routes, typed parsing and stable grant/status
  projection. NetworkWorker's single-owner command queue and durable outbox/journal remain the
  application/persistence boundary. No simulation or database mutation moved into HTTP handlers.
- Shared server-only BoundedStreamReader and ControlRequestAuthenticator give both hosts one bounded
  read and timestamp/domain/MAC policy. Domain, Simulation and portable SDK dependencies stay pure.
  Sixty-five compiled boundary checks pass; original 687 root moves and 632 project extractions
  remain guarded. Worker has 59 authored C# files, Backend 173, Domain 306 and Simulation 610.
  Two pure Worker groups verify all nine methods/paths and parser boundaries without instantiating
  NetworkWorker; Backend's nineteen routes remain exact. Five Backend HTTP groups cover limits,
  MAC/clock, route metadata and protocol-specific oversized connection handling.
- C26 first reproduced 413 for a fully validated canonical 65,536-byte terminal in
  smoke-63366e3984f148e8bb62cca74e39fdb8. TerminalResultEnvelope now computes decoded JSON capacity
  as 54 syntax + 192 metadata + 87,384 Base64 = 87,630 bytes. WriteBase64String avoids HTML expansion.
  Only the result handler raises its per-request Kestrel cap, to 525,785 wire bytes for finite
  canonical chunk framing; shared reads still enforce decoded 87,630. Other API/UDP budgets and
  WFR1 digest bytes are unchanged. Metadata and invalid-size local refusal perform zero HTTP sends.
- The maximum fixture uses real engine-produced unscored semantic state plus an explicitly
  documented canonical protobuf compatibility field to fill the exact binary boundary. Existing
  ValidatePayload verifies it before submission. Native acceptance/replay preserves every stored
  byte; maximum declared/normal-chunked/raw one-byte-chunked JSON succeeds. Binary 65,537 bytes,
  decoded cap + 1 and unrelated protobuf excess refuse without result writes. No truncation,
  validator relaxation, economy reward or normal Unity gameplay proof is inferred.
- Exact chunked JSON initially failed because Kestrel counts chunk prefixes/suffixes. Targeted
  smoke-960f95d29e3f43a8bc5cfe977f10306d and the ASP.NET Core source establish the framing boundary.
  Separate finite wire/decoded budgets fix it. C27 then reproduced a reusable 413 connection closed
  during post-response drain, making the next provision request fail with ResponseEnded. Targeted
  smoke-4e48f4ab545142d18f7d6b54b56eb7e0 contains route context and controlled Kestrel debug evidence.
  Both HTTP/1 refusal adapters now advertise closure; the pure test preserves HTTP/2 behavior.
- Native smoke-7d5472c055fb4ae699089a04a4825493 passed all new size/MAC tests but its later 415
  account check encountered the shared IP's exhausted ten-request auth budget. The two new oversized
  registration probes are deliberate auth requests. Both native scripts now select twenty permits
  only for that test process and restore/scope the environment; deployment defaults remain ten.
  No test retries or accepts a missing oversized response.
- Final Debug and Release solution builds passed with zero warnings/errors. All 25 fast/native
  stages passed in checkpoint-5d5f5a1d09b24364a6f0a0b51a478295, native smoke 35.5 seconds. Its native
  smoke-ab86a9a5fffc4cc0bc4f8781cdf26821 passed 31 Backend and 37 Worker HTTP scenarios, 74 live
  integration checks and three signed-roster refusals, reclaiming 210,894,723 bytes. Focused
  checkpoint-b5125173087e4ad887f69da5535f2d74 passed all 17 actual startup refusals. Windows/WSL
  exact layout, eight extraction groups, 21 artifact checks and Bash syntax pass; 24 feature/test
  files pass hygiene. Full unchanged combat was not repeated for this host/transport increment.
- Release backend-queue-4e2733c2a4694b76a9dfbead230c31de passed actual queue, grants, reconnect,
  scoped cancellation, same-opponent rematch and multi-process restart/outage recovery; cleanup
  reclaimed 212,734,446 bytes. legacy-f97e3459d3dc4125a4ba27f584b48448 passed storage/fault groups
  and 730 combined checks, reclaiming 212,634,414 bytes. Independent fresh Release publish
  battle-publish-113ede04d01c4a95bdf9b755bfadab4c passed unchanged Domain digest/host graphs and
  reclaimed 28,741,161 bytes. Actual Linux services, native packaging and normal Unity/Android
  gameplay remain separate gates. Queue adapter console wording is not Editor execution evidence.
- Server/.local is unchanged at 2,835,453,402 bytes and root .local at 80,842 bytes. Managed storage
  contains 424,735,778 bytes across eleven retained runs, mostly two diagnostic failure databases;
  bounded retention removes older owned failures and successful data. No unowned history was
  deleted. Only the original mongod service PID 6164 remains; no test server process is running.
- S06 legacy action ownership, S07-S09 simulation systems, C03/C12/C13/C18, performance and remaining
  test producers/Unity leases, V07 and actual gameplay remain open. S05/C26/C27 do not complete the
  full goal. See Server/docs/WORKER_HOST_STRUCTURE.md and TERMINAL_HTTP_ENVELOPE.md for detailed guides.

### S06 direct HTTP action ownership and small dispatch tests

- Replaced the large direct-action switch with a typed immutable registration graph. All 175
  recovered wire identities have one explicit disposition: 4 anonymous, 60 authenticated,
  25 buffered-only and 86 closed. Duplicate/missing/unknown actions, anonymous-boundary changes,
  invalid owners and disagreement with the buffered supported set stop startup before traffic.
  The registry is explicit source code; enum/name/reflection discovery never installs handlers.
- LegacyEndpoints is now a 34-line HTTP adapter. Dispatch/Composition constructs the feature graph
  once; LegacyRequestDispatcher owns session admission through ILegacySessionAuthentication.
  Feature handlers own player/squad queries, projections, crafting, inbox and diagnostics. Existing
  transactional account/profile/settings/dog-tag/card-pool/squad handlers remain their owners.
  Backend has 199 authored C# files; Backend and Worker roots still contain only Program.cs.
- Rechecked active 1.4.0 action identities, builders and callbacks. Raw configuration 157, exact
  check.php text, offline Photon acknowledgements, public token omission, mandatory callback
  fields and ordered buffer string results remain unchanged. The normal GameEnded 62 path stays
  closed. Crafting admission/claim arithmetic and damaged-state review remain C12/C13; moving that
  code does not complete its authority audit.
- Added the legacy-dispatch focused gate and included it in fast/runtime/full checkpoints. Ten
  process-free groups cover exact Client enum/source case preservation, invalid graphs, profile
  ownership, route/rate-limit metadata, actual HTTP delegate bodies, every session/channel boundary,
  damaged authority and cancellation. Its Mongo endpoint is deliberately unreachable; it creates
  no database directory or service. Final focused execution takes about 1.2 seconds here.
- LegacySmoke caught an extraction regression at action 157 in
  legacy-7e0a6b2b6a554e8ab3b16024121ec574: the async-lambda HTTP mapping discarded IResult and left
  an empty body. Added an actual route-delegate test, reproduced its failure in
  checkpoint-cdf37792d2824027bbcda70b4a1458b6, then changed the mapping to the typed handler method.
  The focused regression passed in checkpoint-9ed04f674e2d449d90bc09b054aae000. Dispatcher-only
  tests had passed and did not protect result execution, so the actual adapter remains in the gate.
- Expanded real HTTP closure verification to all 111 closed/buffered-only actions with both absent
  and valid sessions, plus unchanged-wallet checks. Final legacy-b8f330824037442ca4197ba39dfff703
  passed storage/concurrency/fault groups, 563 base assertions and 391 feature HTTP assertions
  (954 combined), reclaiming 212,827,186 bytes after owned-process shutdown.
- Debug and Release solution builds passed with zero warnings/errors. All 26 fast/native stages
  passed in checkpoint-0d0a62653cb541d4b3376305d88f23d9; native
  smoke-1f612417d7c34a4b8cc8ee2189a01bcc passed Backend/Worker transport, protocol and 74 live
  account/HTTP/UDP checks and reclaimed 210,867,913 bytes. Final naming/import cleanup was followed
  by both builds and all 25 fast stages in checkpoint-2bcf50939e6541cca3b32177cf9665b2.
- Release backend-queue-d2fb4ad85c0f4750b7fa55f8abd3459e passed recovered start acknowledgements,
  queue/grants/reconnect, scoped cancellation, same-opponent rematch, Backend restarts and Worker
  outage recovery, reclaiming 212,592,882 bytes. These are headless/source-adapter checks, not
  normal Unity scene gameplay. Unchanged full combat, Linux services and native packaging were
  not rerun for the direct-dispatch change.
- All 28 new/extracted feature/test files pass LF/width/whitespace hygiene. Root .local remains
  80,842 bytes; Server/.local remains 2,835,453,402 bytes. The separate managed LOCALAPPDATA root
  contains 215,346,980 bytes after bounded retention, including the diagnostic failure. No test
  run remains active; only the pre-existing mongod service PID 6164 remains. No unowned history,
  Client asset or catalog digest was changed.
- S06 remains open for cohesive buffered Inventory/Economy/Cards/Squads owners and typed nested
  dispatch. Make the producer-inventory scanner relocation-safe before that move; preserve the
  same request context, ordered errors, atomic receipts, current rollback and deterministic seed.
  S07-S09, C03/C12/C13/C18, performance, remaining testing/Unity leases and V07 remain open.
  C28 records the remaining verbatim diagnostic logging/length-unit finding from this extraction;
  its operational logging change is separate from the behavior-preserving handler move.
  See Server/docs/LEGACY_ACTION_STRUCTURE.md for the implementation and continuation guide.

### S06 buffered feature completion and C28 diagnostic metadata

- Completed S06's nested execution split. The former thirteen helper partials now have eleven
  stateless Inventory/Economy/Cards/Squads action owners, seven explicit execution/publication
  helpers and three registry types. LegacyBufferPlanner is a single validation/orchestration
  class without an action switch or shared partial family. Public planner/coordinator APIs,
  namespaces, source IDs, supported actions and persistence boundaries are preserved.
- LegacyBufferedActionRegistry has exactly one typed handler per supported action: 21 Inventory,
  2 Economy, 1 Cards and 1 Squads. It freezes the graph and rejects missing, duplicate, unknown,
  invalid-owner and null-handler entries or disagreement with SupportedActions. Unsupported
  buffered operations still return maintenance. Registering a handler does not invent catalog data.
- LegacyBufferedState explicitly owns one request/transaction attempt's lazy subsystem copies,
  wallet deltas and publication plan. Feature owners retain no fields or database/network services.
  Failed actions with pending mutations are refused. Each action gets a fresh context while the
  coordinator keeps its original captured time/seed across transaction retries; source documents,
  ordered commit/replay, current rollback and receipt ownership remain unchanged.
- Made the producer scanner recursive and able to inspect internal static feature methods before
  moving them. Nine scanner regressions cover relocated/transitive producers, cross-file duplicate
  refusal, missing sources/methods, comments/literals and expression bodies. All 71 reviewed Client
  hashes and the same 25 producer result inventories still pass. Every action body's exact tokens,
  including strings and calculations, matched immediately after transplant; the provenance is in
  Server/docs/legacy-buffer-extraction.json. Later explicit braces, width/import cleanup and grouped
  interpolation parameters retain executable Client/producer coverage rather than reblessing those
  historical hashes. All 26 new/extracted feature/test files pass LF/width/whitespace checks; the
  longest method is 77 lines. Backend now has 208 authored C# files; both host roots remain clean.
- Added the process-free legacy-buffer-dispatch selector: five groups verify compiled feature
  ownership, invalid graphs, request isolation, pending-failure publication refusal and the
  unsupported/malformed-input boundaries. It passed in
  checkpoint-dd04826302ac4ba8bc0e59a4ae8225a5 in approximately 0.9 seconds without Mongo.
- C28 now removes raw diagnostic report/error/offer/Arena values from both formatted logs and
  structured properties, retaining validated caller IDs and decoded UTF-8 byte counts. The old
  string.Length-as-bytes label is corrected; wire-encoded form length is not claimed. The capturing
  logger regression failed against the old code in checkpoint-015dc2f8537d44479774f0882e9a6d5d and
  passed after correction in checkpoint-b4609405e6324236989f1b6a75cc960c. Three groups cover
  multiline/credential-like sentinels, ASCII/Korean/supplementary byte counts, omitted fields and
  actual mandatory PlayerID/LogId response execution. No Client behavior or reward authority changed.
- Final Debug and Release solution builds passed with zero warnings/errors. All 28 fast/native
  stages passed in checkpoint-87b9b16de4f84eab90144b6dda3f81e6; native
  smoke-5780f72fd60e47daaedffa2128a216bc passed protocol/transport and 74 live Mongo/HTTP/UDP checks
  in 38.1 seconds and reclaimed 210,902,305 bytes. Legacy
  legacy-c08e9abf820b4d3c8e3275a9293020c6 passed storage/concurrency/fault groups, 563 base and
  391 feature HTTP checks (954 combined), reclaiming 212,614,972 bytes. Executable source contracts
  still report 1,188 callback/value checks, 50 actual producer cases, 151 catalog/replay cases and
  126 action/result dispositions. These are not normal Unity scene or full game verification.
- Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. New runs use
  the separate managed LOCALAPPDATA root, now 215,003,032 bytes after bounded retention. Both
  successful databases were removed after owned shutdown. Only the pre-existing mongod PID 6164
  remains; no test run is active. Temporary source-extraction caches were removed; unowned history,
  Client/library changes, content digests and simulation code were preserved.
- S06 and C28 are complete at their stated scope. S07-S09 simulation ownership, C03/C12/C13/C18,
  measured performance, remaining test producers/Unity leases, V07 and actual gameplay remain open.
  Full unchanged combat, Linux services and normal Unity/Android execution were not rerun for this
  Backend-only increment. See Server/docs/LEGACY_ACTION_STRUCTURE.md and TESTING.md for the guides.

### S07 first increment — connection state and ordered reconnect decisions

- Extracted one cohesive part of MatchEngine lifecycle into PvpConnectionLifecycle and
  PvpParticipantConnection, with explicit reconnect decision/disposition types. The component owns
  roster binding, admission/idle policy, loading/presentation readiness and reconnect state and
  decisions. Player now has getter-only adapters for its seven former writable connection fields;
  no duplicate flag storage remains in the engine. Simulation has 614 authored C# files.
- Preserved exact 1.4.0 source rules: loading readiness precedes presentation readiness, match start
  remains offset by two seconds, reconnect grace is 30/20/10 seconds and attempt four forfeits.
  Admission/idle configuration and no-winner abort for a second silent peer remain explicit existing
  self-hosted policy. No Client code, scene, library, game identity or content digest changed.
- Kept source-sensitive order: validate clocks/gaps before mutation; already-paused grace expiry at
  its former frame point; detect new idle before advancing simulation; record attempt, remove owned
  deployables, then activate pause/deadline. Cleanup failure retains only the incremented attempt.
  Resume clears the lease without resetting history; polling/exact receipt replay refreshes presence
  without resuming. Global phase/revision/clock and world/terminal side effects stay with the engine.
  Reason literals remain in the adapter; all 62 terminal policies remain covered.
- Before touching simulation, captured the original engine twice for nine deterministic scenarios
  and 108 observations. Full framed protobuf snapshots, replies, terminal evidence/events and exact
  clock bits matched across captures and after extraction. The small frozen JSON fixture includes
  human-readable final phase/tick/reason and historical source provenance. The capture switch was
  removed; normal tests never regenerate expectations. This synthetic prototype trace is specific
  refactoring evidence, not full combat, production capacity or Unity gameplay proof.
- Added the pvp-connection focused selector to fast/runtime/full checkpoints. It passed in
  checkpoint-a42adc6e28234304a08ebe79c1c248a5 in about one second. Six additional groups cover
  admission/ready order, read-only reconnect queries, cleanup-failure preparation, traffic versus
  resume, idle/grace boundaries and compiled private-setter/engine-storage ownership. The seven
  new/extracted source/test files pass LF/width/whitespace checks; Client evidence hashes are intact.
- Debug and Release builds passed with zero warnings/errors. Runtime/native
  checkpoint-878944a56acd45f881fb1ca162243609 passed all 31 stages, including 267,866 engine,
  admission, portable SDK, map and two-peer UDP assertions. Full battle took 716.7 seconds while an
  independent Release queue gate also ran; no comparative throughput claim is made. Native
  smoke-df8582c3054b4bce8c36b9909875ee10 passed actual Mongo/HTTP/protobuf/UDP in 36.5 seconds and
  reclaimed 210,894,851 bytes. No redundant second full combat run was needed after those passes.
- Release backend-queue-399769cc221e406ea85d0d805e6676b4 passed recovered start acknowledgement,
  queue/grants/reconnect, cancellation, same-opponent rematch, Backend restarts and Worker-outage
  recovery; cleanup reclaimed 212,591,914 bytes. SDK/source-adapter wording is not normal Unity
  scene or Android execution. Linux service/native packaging and V07 remain separate.
- Root .local remains 80,842 bytes; Server/.local remains 2,835,453,402 bytes. Managed LOCALAPPDATA
  storage contains 214,644,654 bytes after bounded retention; successful databases were removed.
  No run or Backend/Worker/test process remains active; only the original mongod service PID 6164
  remains. Unowned history and concurrent Client/library work were preserved.
- S07 remains open: global phase/time transitions, weapons, projectiles, army/vehicles/air,
  cards/status/collision/projections still require their own state owners and deterministic ordering
  proofs. S08/S09, C03/C12/C13/C18, measured performance, remaining test producers/Unity leases,
  V07 and actual gameplay are not completed by this connection extraction. See
  Server/docs/PVP_CONNECTION_LIFECYCLE.md for the detailed continuation boundary.

### S07 second increment — weapon state ownership and C29 capped-grant arithmetic

- Moved fixed weapon slot membership/selection and magazine, reserve, reload and fire deadlines
  into PvpWeaponLoadout and PvpWeaponSlotState. Slot setters are private; the engine Player retains
  getter-only adapters without duplicate storage. A cached read-only wrapper prevents mutation of
  signed slot membership. Manifest iteration order and the legacy single-slot fallback remain intact.
  Simulation now has 616 authored C# files; aiming, trigger/burst state and global frames stay open.
- Inspected the recovered 1.4.0 Weapon, Pistol, WeaponInventory and ammo-card implementations.
  Preserved double-based tick rounding, inclusive reload completion on inactive slots, immutable
  reserve sentinel, Ammo Box starting-reserve binary32 math and all-slot preflight, Empty Mag's
  first-slot selection and Ammo Thief's second-slot/zero-clip-debit setter semantics. Accepted-shot
  debit and fire scheduling remain separate because existing effects occur between them. Death,
  bonus publication, combat slot selection, revisions and terminal order retain their former scope.
- Before simulation edits, captured eight engine scenarios twice with 99 byte-identical observations.
  Frozen full protobuf/reply/event/clock hashes still match after extraction; normal tests cannot
  regenerate expectations. Extracted a common test-only recorder while retaining all nine existing
  connection traces and their 108 observations. Six new groups cover arithmetic/boundaries,
  conservation, inactive reloads, immutable membership and compiled private-setter ownership.
- C29 fixes a latent internal capped-grant error: starting reserve 3, valid current reserve 4 and
  grant 1 formerly became 3. Already-at/above-cap reserve now remains unchanged; under-cap addition
  widens before saturation, preventing valid near-Int32Max grants from overflowing. The regression
  failed in checkpoint-63f5451843d54d7e93b7f7389fd56dc8 and passed after correction in
  checkpoint-d1bec5d6c041406da3716a1aa1c8c80d. TryResolveCardAmmo currently has no production source
  caller, so this is not observed live-player loss; the broader cap-policy review remains C13.
- Debug and Release solution builds pass with zero warnings/errors. Release focused checks pass
  all eight weapon traces/six state groups and nine connection traces/six lifecycle groups.
  checkpoint-3f65ea1ca5f94495ae20fc5ea3645db3 passes all 32 runtime/native stages, including 267,926
  battle/admission/SDK/map/two-peer UDP assertions. Full battle took 635.1 seconds; native
  smoke-1ca9652d97de4a74a9b0969afb1eff74 passed actual Mongo/HTTP/protobuf/UDP in 40.4 seconds,
  including 74 live integration checks, and reclaimed 210,868,625 bytes. No throughput improvement
  or normal Unity scene/Android gameplay verification is inferred from these correctness checks.
- Six new/extracted C# files pass LF/width/whitespace checks; all six Client evidence hashes remain
  unchanged. Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes.
  New runs use managed LOCALAPPDATA storage, now 932,108 bytes/102 files after bounded retention.
  Successful databases were removed after owned shutdown; only the original mongod service PID
  6164 remains. No active run, test Backend or Worker remains; unowned history was preserved.
- C29 is complete at its stated helper scope. S07 remains open for global lifecycle/time,
  trigger/aim/projectiles, army/vehicles/air, cards/status/collision and projections. S08/S09,
  C03/C12/C13/C18, measured performance, remaining test producers/Unity leases, V07 and actual
  gameplay retain their own work. See Server/docs/PVP_WEAPON_STATE.md and TESTING.md for the guide.

### S07 third increment — physical player movement and frame observations

- PvpPlayerMovementState now owns physical cover/position, private copied route, travelled distance,
  logical destination, deferred/start/update/end clocks and observed frame velocity. Player exposes
  getter-only compatibility observations; the former route/progress storage is removed. Targeting,
  rifle animation and army/card/mortar/air consumers read IsMoving rather than a mutable route array.
  Each participant owns independent state. Simulation now has 617 authored C# files.
- Movement binds the authoritative map at the existing validated start-cover commit, after live
  weapon modes resolve content-owned maps. A second binding is rejected before mutation. Preserved
  GoTo's one-tick deferred destination, binary32 path length/interpolation/evaluation order, inclusive
  arrival and exact cover snap. Observed velocity remains last-frame displacement times 30, including
  skipped ticks; repeated/idle frames produce zero. No navigation/physics formula was rebalanced.
- Admission/freeze/target/direction/occupied-cover gates and receipt/revision authority remain with
  the engine. Movement still precedes reload and the following army/card phases. Velocity finalization
  precedes drone-target refresh in the same finally block, including early returns/failures. Ordinary
  and barrel deaths cancel routes at their original points without rewriting other observations.
- Source BelovedEnemy retains absolute speed 0.5, remaining-distance deadline recalculation and the
  existing later frame expiry point. A separate active-route-expiry group starts near expiry and
  proves that the next frame restores the original speed without resetting progress. It respects
  the engine's every-tick requirement while the effect is active. Reconnect retains simulation
  deadlines and resumes one step without consuming the paused host-time backlog.
- Before simulation edits, captured the original engine twice with identical results: eight traces,
  431 full observations. Five maps each traverse 5-to-6 and back; other cases cover absolute speed,
  rejected assertions/replay, effect expiry, pause/resume and death-before-terminal. Complete framed
  snapshot/reply/terminal-event and clock hashes still match after extraction. These are source-map
  prototype fixtures, not proof of all 60 paths, full combat physics or normal Unity gameplay. Normal
  tests cannot regenerate golden hashes; the temporary capture switch was removed.
- Eight additional state/order groups cover deferral, duplicate/skipped frames, velocity, inclusive
  arrival, speed changes, cancellation, independent/private state, map rebinding/live resolution and
  active expiry. The focused pvp-movement gate now participates in fast/runtime/full checkpoints.
  Debug and Release builds pass without warnings/errors; both configurations pass all eight traces
  and eight groups. Final Debug checkpoint-5a2bb65b6da644cd9cf249a8a333e265 took 4.2 seconds without
  Mongo, sockets, Unity or Library copies. Existing connection/weapon traces still pass in both.
- checkpoint-608a06966f8b44689fae195ce8da32ea passed all 33 runtime/native stages, including 267,800
  engine/admission/SDK/map/real-UDP assertions. Full battle took 670.0 seconds; native
  smoke-8b4608680810409990faa253136ead81 passed in 36.6 seconds with 74 live integration checks and
  reclaimed 210,895,152 bytes. The final test-only active-expiry addition was verified separately
  after that run; no simulation changed while it ran and no second full combat run was needed.
  These correctness timings are not comparative throughput or actual Unity/Android gameplay proof.
- Three new C# files pass LF/width/whitespace checks; all three Client evidence hashes and the map
  artifact hash remain unchanged. Historical .local sizes remain 80,842 bytes at root and
  2,835,453,402 bytes under Server. Managed LOCALAPPDATA storage is 934,794 bytes/104 files after
  retention. All owned test processes/runs ended; only original mongod service PID 6164 remains.
  Unowned history, Client/library work, scenes, content digests and production journals were preserved.
- S07 remains open for global lifecycle/time, remaining weapon/projectile/army/vehicle/air/card/status/
  collision/projection owners. S08/S09, C03/C12/C13/C18, measured performance, remaining test producers/
  Unity leases, V07 and actual gameplay retain separate work. See Server/docs/PVP_PLAYER_MOVEMENT.md
  and TESTING.md for the ownership guide, exact update order and verification boundaries.

### S07 fourth increment — player bullet lifecycle and captured-frame impact order

- PvpPlayerBulletSystem replaces the engine's real-bullet and cosmetic-shotgun dictionaries. It owns
  admission into those collections after the engine's complete preflight, captured-frame advancement,
  removal/completion, detached observations and terminal clear. PvpBulletStep carries immutable
  damage/source/impact metadata without exposing the mutable stored flight. Simulation now has
  619 authored C# files. Shared IDs/capacity, factory validation and world impact authority stay put.
- Preserved insertion-order frame capture and one-flight-at-a-time advancement. Finished real shots
  leave storage before impact dispatch; the engine applies that impact before requesting the next
  step. Lethal hits therefore stop later real/cosmetic flights. InvalidDataException stops the captured
  frame with the same terminal reason; distinct clock exceptions keep propagating. Cosmetic pellets
  still run only at their original later frame point and never receive damage or collision authority.
- The frame cursor and observation are value types with no boxed enumerator, per-flight step object
  or per-frame delegate. The previous captured dictionary-entry array remains. Snapshot projection
  still emits ID-sorted real shotgun bullets followed by ID-sorted cosmetic pellets at the same
  location among other families. Non-shotgun real bullets keep their prior count/presentation split.
  These are structural properties, not a measured networking/calculation throughput improvement.
- Inspected recovered Ammo, BulletBase, BulletSlow and BulletShotGun before extraction. No flight,
  spread, prediction, damage, shield, immunity, hit report or reward formula changed. The engine's
  bonus/shield/barrel/dynamic/player impact routes retain their original callbacks and failure reasons.
  Other projectile families and the large remaining impact/frame orchestration stay open under S07.
- Captured the original engine twice before simulation edits: seven equal scenarios with 350 full
  observations. Frozen complete protobuf/reply/terminal-event/clock hashes still match after extraction.
  Cases cover real/cosmetic completion and replay, coexisting two-owner volleys, lethal-first-hit stop,
  slow-miss check/tail, corrupt geometry abort, pause/resume and terminal cleanup. These prototype
  fixtures do not establish full real weapon geometry, combat physics or normal Unity gameplay.
- Seven ownership/order groups cover frame capture, removal-before-impact, deferred new insertions,
  invalid-step stop, clock exception contracts, cosmetic expiry, detached/sorted projections, match
  isolation and compiled ownership/value types. Focused checkpoint-c29a006d9a8443c2ba950bb77df73087
  passed in approximately one second without Mongo/sockets/Unity. Debug and Release builds pass
  without warnings/errors; both configurations pass the new fixtures and existing connection,
  weapon and movement fixtures. Normal tests cannot regenerate the golden expected hashes.
- First integrated checkpoint-5ae39dd42ee840d3a49c103a492a3511 stopped after 274.7 seconds because
  CombatContentTests still injected a controlled immortal-Drone flight through the deleted private
  dictionary. The fixture now obtains the new private owner and uses AddReal; its actual collision,
  preserved-health and contact-credit assertions remain unchanged. Managed focused combat-content
  checkpoint-25acad5fcf0947388ec9b1d1630f472a passed 29,180 assertions in 78.7 seconds before rerunning
  integration. The existing --combat-content-only selector now has an owned focused checkpoint case,
  giving source-combat diagnostics their own logs/temp without replaying earlier network stages.
- Four new C# files pass LF/width/whitespace checks and all four Client evidence hashes remain
  unchanged. No Client scene/library, content identity, production journal, commit or staging changed.
  See Server/docs/PVP_PLAYER_BULLETS.md and TESTING.md for the implementation/verification boundaries.
- Corrected checkpoint-44e0506a474942f4a49126a5b1f56ae1 passed all 34 runtime/native stages,
  including 267,729 battle/admission/SDK/map/real two-peer UDP assertions in the 725.7-second full
  combat stage. Native smoke-b7c2ed6e9c32457b9093861638b9c9a1 passed in 37.2 seconds with 74 live
  integration checks, reclaiming 210,867,652 bytes. Simulation was unchanged between the reflection
  fixture failure and the passing rerun. Both original flight algorithm source hashes remain intact.
  Correctness timings are not comparative throughput or normal Unity/Android gameplay proof.
- Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. Managed
  LOCALAPPDATA storage is 974,212 bytes/133 files after retention, including bounded failure reports.
  All managed runs and test Backend/Worker/battle processes ended; only original mongod PID 6164
  remains. Successful data was removed after owned shutdown; unowned history was preserved.
- S07 remains open for global lifecycle/time, remaining weapon/projectile/army/vehicle/air/card/status/
  collision/projection owners and impact orchestration. S08/S09, C03/C12/C13/C18, measured performance,
  remaining test producers/Unity leases, V07 and actual gameplay retain their own completion gates.

### S07 fifth increment — delayed/live bazookas, curve state and C30 resource accounting

- PvpPlayerBazookaSystem now owns the live missile dictionary, delayed-launch list and alternating
  curve-sign counter. The engine's three writable members and nested flight/launch types are removed.
  Explicit primary-real/secondary-real/secondary-fake selection and immutable launch/payload/step
  types replace the former eight positional launch fields. Six new production files bring Simulation
  to 625 authored C# files. Shared IDs, whole-volley preflight, source factories and world damage stay put.
- Retained exact M202 primary/fake/real/fake order, float delay multiplication/ceiling, source muzzle
  selection, half damage, random draw and curve-sign order. Due entries are removed before trusted
  launch callbacks; active flights skip their launch tick, advance in captured insertion order and
  leave storage before impact publication. Fake impacts skip damage; terminal hits stop later work.
  Snapshot ordering/metadata and cleanup scope remain unchanged, including retained curve history.
- C30 fixes PendingProjectileCount omitting active bazookas while counting delayed ones. A source
  RPG was present in the snapshot yet absent from capacity; M202 reservations vanished from accounting
  as they became still-live missiles. The engine now includes active plus scheduled missiles once
  within its existing shared 128-flight resource policy. This is server policy, not invented Client
  balancing. Complete preflight still refuses before ammo, counters, shared IDs or shot events.
- The original source RPG regression failed in checkpoint-e284aa5ab06d46a9a6869768d5aa8bfe before
  production edits. Three fixed groups check live RPG accounting, M202 reservation transfer and an
  actual second-player hold/fire refusal with unchanged ammunition at the full shared budget. The
  latter uses controlled host flights for the other slots; it is not an observed normal-gameplay load
  or a claim that network packets can install synthetic authority. No live-player incident is inferred.
- Before production edits, captured six source-bound engine scenarios twice with identical hashes:
  914 complete observations of RPG impact/replay, M202 timing/selection lock, cancellation, pause with
  an active missile, cleanup and two-owner curve ordering. Full snapshot/reply/terminal-event/clock
  bytes still match after extraction and C30. That private count is absent from the wire fixture;
  red/green capacity assertions cover its intentional correction. Normal tests cannot regenerate hashes.
- Six owner/order groups add inclusive due deadlines, reservation transfer, captured insertion order,
  removal before impact, launch-tick skip, invalid-frame stop, detached snapshots, retained curve history,
  isolation and compiled ownership/value-step structure. Final focused
  checkpoint-11c8c9331aee4107a3202d7dd079cb46 passes all six traces/six groups/three capacity groups in
  2.9 seconds without Mongo, sockets or Unity. The trace helper now accepts source content and fixes
  bonus draws; all prior connection/weapon/movement/player-bullet fixtures still match in both builds.
- Exposed the existing --bazooka-only selector as the owned bazooka-combat focused case.
  checkpoint-704798df66dd4a98947ff030d8fd38e7 passed 218 source catalog/presentation/UDP assertions
  in 10.6 seconds, including five live UDP checks. Debug/Release builds pass without warnings/errors.
  These source-bound engine and SDK tests are not normal Unity/Android gameplay certification.
- Ten new C# files pass LF/width/whitespace checks. Three inspected Client source hashes, the original
  missile algorithm hash and the bazooka manifest hash remain unchanged. Source flight/explosion
  algorithms, Client scenes/libraries, content identities and unowned history were preserved. Value
  payload/frame types avoid a separate object per missile observation; no measured speedup is claimed.
  See Server/docs/PVP_PLAYER_BAZOOKAS.md and TESTING.md for the ownership and verification guide.
- Final checkpoint-bc43740813374b63b59253dc9c53c071 passed all 35 runtime/native stages, including
  267,796 engine/admission/SDK/map/real two-peer UDP assertions in the 612.0-second full battle stage.
  Native smoke-318bc217fcdd4be19abbaf0ab41cf123 passed in 36.2 seconds with 74 live integration
  checks and reclaimed 210,867,695 bytes after owned shutdown. No redundant full combat rerun was
  needed after those passes. These elapsed times are correctness observations, not throughput proof.
- Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. Managed
  LOCALAPPDATA storage contains 949,377 bytes/134 files after retention, including bounded diagnostic
  failures. All managed runs and test Backend/Worker/battle processes ended; original mongod service
  PID 6164 remains. Successful data was removed and unowned history/production journals preserved.
- C30 is complete at the shared bazooka budget scope. S07 remains open for global lifecycle/time,
  remaining weapon/grenade/army/vehicle/air/card/status/collision/projection owners and impact orchestration.
  S08/S09, C03/C12/C13/C18, measured performance, remaining test producers/Unity leases, V07 and
  actual Unity/Android gameplay retain their separate completion gates.

### S07 sixth increment — equipped and bonus/card grenade flight ownership

- PvpPlayerGrenadeSystem owns equipped flight membership, advancement, completion, snapshots and
  cleanup. PvpGrenadePayload/PvpGrenadeStep carry immutable launch-bound metadata and observations.
  PvpBonusGrenadeFlightSystem separately owns bonus/card flights, pending collisions and completed
  frame observations. The engine's former collections and nested equipped flight record are removed.
  Four new production files bring Simulation to 629 authored C# files; no mutable flight escapes.
- Equipped flights retain captured insertion order, launch-tick skip, removal before impact, immediate
  existing world-effect application and terminal clear. Invalid authority retains its original reason.
  Bonus/card collisions retain next-frame explosion quotes and current shared-damage reads. All
  pending quotes validate before consumption; active capture follows world explosion effects. Ready
  launches/events complete before collision observations publish. Failed/incomplete frames cannot
  publish partial observations; active plus pending counts once within the existing shared budget.
- Source flight/explosion formulas, shared IDs, animation/ammo publication, card receipts/burst clock,
  world damage, family snapshot order and empty wire source fields remain unchanged. Prior bonus
  terminal state retention is deliberately preserved as a server baseline. Its intended Client
  cleanup/presentation contract remains an explicit V02 question, not a newly confirmed defect.
- Captured the original engine twice before production edits: seven equal source-bound scenarios,
  1,075 full framed snapshot/reply/terminal-event/clock observations. FRAG/M320/Molotov launch/replay/
  impact, ordinary terminal cleanup, three card collisions/next-frame explosions, bonus terminal
  freeze and reconnect pause still match after extraction. The temporary capture switch is removed.
  Eight additional owner/order groups cover detached sorted projections, isolation, capacity transfer,
  late shared setup, immutable previous observations, preflight and partial-frame failures, capture
  boundaries and compiled private ownership/value types. No normal test can regenerate the baseline.
- Final focused checkpoint-4778be54a0774f179006935c1cdb6bc9 passes seven traces/eight groups in
  3.0 seconds without Mongo, sockets or Unity. Exposed existing grenade-combat, grenades-burst-udp and
  bonus-grenade-policy selectors as managed focused cases. Their checkpoints respectively pass
  49,470 source grenade assertions in 34.3 seconds, 13 live Cluster Grenade UDP checks in 8.8 seconds
  and 74 shared-setup checks in 2.9 seconds. Run IDs and commands are recorded in
  Server/docs/PVP_PLAYER_GRENADES.md and TESTING.md. These timings do not prove a throughput gain.
- Debug/Release solution builds pass without warnings/errors; both pass all new traces/groups and
  previous bazooka/bullet/movement/weapon/connection fixtures. Seven new C# files pass LF, width and
  whitespace checks. Five inspected Client hashes, the original flight and bonus explosion algorithm
  hashes and grenade content manifest hash remain unchanged. No Client scene/library/content was edited.
- Final checkpoint-88d706b901d54a98bc50b94fe1dc86ef passed all 36 runtime/native stages. The full
  battle stage passed 267,793 engine/admission/SDK/map/real two-peer UDP assertions in 621.6 seconds.
  Native smoke-1c8fe4262fd6406aa6881d3fe6b17382 passed in 36.8 seconds with 74 live integration
  checks and reclaimed 210,895,041 bytes after owned shutdown. The final code passed once; no
  redundant full combat rerun was needed. These elapsed times are not comparative throughput proof.
- Root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. Managed LOCALAPPDATA
  storage contains 527,459 bytes/128 files after retention. All managed runs and test Backend/Worker/
  battle processes ended; original mongod service PID 6164 remains. Unowned history was preserved.
- S07 remains open for global lifecycle/time, remaining weapon/projectile/army/vehicle/air/card/status/
  collision/projection owners and world-impact orchestration. S08/S09, C03/C12/C13/C18, V02 terminal
  intent, measured performance, remaining test producers/Unity leases, V07 and actual Unity/Android
  gameplay retain their own completion gates. This increment adds no new confirmed correctness item.

### S07 seventh increment — paired army bullet state and launch authority

- PvpArmyBulletSystem replaces the engine's armyProjectiles and armyProjectileAuthority dictionaries
  with one private entry set. Each entry pairs a flight with immutable PvpArmyBulletPayload metadata.
  The nested engine authority record is removed; named required properties replace its eight
  positional constructor arguments. Three new production files bring Simulation to 632 authored C#
  files. Entry/frame/step are value types; there is no additional wrapper object per launched bullet.
- Existing general-army, Assaulter, Gunslinger and Grenadier-primary launch adapters retain shared
  IDs, capacity/event preflight, random/source decisions, damage policies and publication order.
  Complete metadata is prepared before insertion, so the owner cannot publish an unpaired flight.
  This removes a representable internal orphan state, not an observed live-player bug. No new
  confirmed correctness item is claimed. Source ArmyProjectileFlight math is unchanged.
- Captured insertion order, duplicate/launch-tick no-op behavior, completion removal before impact,
  exact InvalidDataException classification and terminal interruption remain unchanged. Cosmetic
  flights retain source doubled tweens without collision queries. Engine callbacks still own
  bonus/barrel/entity/shield/player damage, poison, revenge and terminal publication. Launched bullets
  retain their server-bound authority after soldier death; revenge still requires a live soldier.
- Snapshot family order, sorted IDs, owner/unit/card/poison metadata, position/velocity and the prior
  empty WeaponSourceId remain unchanged. Launch/source/speed diagnostics expose immutable metadata
  and scalars. Terminal cleanup clears the paired entries at the original point. Flame/poison/rocket/
  mortar/grenadier state and global world-impact orchestration retain separate S07 work.
- Before production edits, captured the original engine twice with identical results: nine traces,
  5,625 complete snapshot/reply/terminal-event/clock observations. They cover real/cosmetic Assault
  and Gunslinger, Shotgunner groups, upgraded Commando metadata, soldier death, terminal clear and
  card Grenadier primary fire. Deployment replay and source diagnostics also have assertions.
  The capture switch is removed; ordinary tests cannot bless new expected hashes.
- Eight owner/order groups add pairing, detached sorted snapshots, one-flight-at-a-time observation,
  captured insertion boundaries, duplicate/invalid clocks, exception propagation, cosmetic lifetime,
  clear/isolation and compiled private ownership/value types. Final Debug and Release builds pass
  without warnings/errors; both pass the nine traces/eight groups and all prior connection/weapon/
  movement/bullet/bazooka/grenade fixtures. The three inspected Client, original flight and weapon-
  binding manifest hashes remain unchanged. No Client scene/library/content identity was modified.
- Exposed existing Assaulter-volley, Gunslinger-shooting and Grenadier-primary selectors as small
  managed focused cases. They pass 112, 29 and 23 checks in 5.0, 4.0 and 3.9 seconds respectively.
  Source run IDs and commands are recorded in Server/docs/PVP_ARMY_BULLETS.md and TESTING.md. They
  need no Mongo, socket or Unity project; actual Shotgunner UDP retains its separate existing gate.
- Superseded checkpoint-0682a3d95985426da33798152683ea7a passed its first 35 stages, then was
  deliberately stopped during full battle when the entry changed from a wrapper class to a value
  type. Its bounded failure report remains; this is not a combat assertion failure or a final passing
  result. Final verification must cover the new representation. A completed early focused report
  created under Server/.local was moved, after ownership/terminal checks, to managed LOCALAPPDATA.
- Final checkpoint-8ffd2a3818854311b0b51eec1385b9c9 passed all 37 runtime/native stages on the final
  value-entry code. The nine-trace/eight-group state gate passed in 5.0 seconds. The full battle stage
  passed 267,862 engine/admission/SDK/map/real two-peer UDP assertions in 599.7 seconds, including
  existing source volley/damage and Shotgunner scan gates. Native
  smoke-0979a6e52a2b4f06bbe33d23c4ec51ae passed in 37.3 seconds with 74 live integration checks and
  reclaimed 210,864,232 bytes after owned shutdown. Superseded execution is excluded; these are
  correctness timings, not a throughput comparison or normal Unity/Android gameplay certificate.
- Root .local remains 80,842 bytes. Server/.local now measures 2,624,416,528 bytes/34,638 files,
  down 211,036,874 bytes after marker-based retention of its older managed runs. Managed LOCALAPPDATA
  storage is 553,013 bytes/186 files, including bounded superseded-run diagnostics. All managed runs
  and test Backend/Worker/battle processes ended; original mongod PID 6164 and unowned history remain.
- Five new C# files pass LF/width/whitespace checks, and all five inspected Client/flight/binding hashes
  remain unchanged. No new production correctness item is claimed. S07-S09, C03/C12/C13/C18, V02,
  measured performance, remaining test producers/Unity leases, V07 and actual gameplay retain their
  own completion gates. T05 now explicitly records unknown/malformed console arguments falling
  through to the expensive shared/full test prelude as the next test-runner correction.

### T05 increment — reject malformed test commands before expensive execution

- War.Battle.Tests previously let unmatched arguments fall through to the shared/full prelude,
  which includes socket and long combat checks. A typo or wrong argument count could silently run
  unrelated work. The original unknown-case process regression failed in
  checkpoint-71e9ba41df744cc395ad641b29ee5550 before the guard was installed; it is retained as
  bounded red evidence, not a production-server defect or an intentionally accepted failure.
- Support/BattleSharedSuiteArguments owns the four existing shared entry shapes: no arguments,
  allocation-inventory-only, and the two three-argument Unity paths. Earlier focused routes still
  return through their existing handlers. The final guard sits before the first shared test call;
  unmatched input exits 2 with empty stdout and one fixed stderr line, without echoing argument
  values. Unity executable/project arguments must be nonblank; their bytes are not trimmed or
  rewritten. File existence and actual Unity execution remain the existing audit workflow.
- Support/BattleArgumentProcessTests starts real owned children for 18 unknown/arity/case/blank-path
  refusals, including malformed Worker/store selectors. Each must return the exact safe error and
  leave its isolated scratch path absent. One real valid pure selector succeeds under the same
  child environment, preventing a broken host setup from masquerading as refusal proof. Four
  shared-entry policy checks preserve the intended no-argument/allocation/Unity shapes. Deadlines
  kill and await only the owned child tree; no Mongo, Unity project or Library copy is needed.
- Added managed test-arguments and allocation-inventory focused cases. The argument gate also runs
  in fast/runtime/source checkpoint lists. Green checkpoint-be6031f345604819bbb45b1ee6856ffb passes
  in 4.1 seconds; the actual Debug shared-prefix gate
  checkpoint-d6966ea7d3944ed8ad9128e1dcab7610 passes in 7.3 seconds. Release
  arguments-release-6ffc7bbd29ce437e8014c7b3dad2c039 passes the same argument and allocation cases
  in 4.1 and 6.9 seconds, with owned logs/temp and successful data cleanup.
- Debug and Release solution builds pass without warnings/errors. Final fast
  checkpoint-34c12f3836d74fc6b362e15f97ab0d33 passes all 35 stages in 50.7 seconds of stage time,
  including protocol, artifact ownership, source layout, all extracted PvP state and Legacy contracts.
  Production code/protocol/gameplay is unchanged, so full combat/native/Legacy smoke was not repeated
  for this test-entry fix. Prior integration evidence retains its own scope; no new Unity/Android,
  performance or V07 completion is claimed. T05 remains open for its wider selector/producer work.
- Root .local remains 80,842 bytes and Server/.local 2,624,416,528 bytes/34,638 files. Managed
  LOCALAPPDATA storage is 504,855 bytes/162 files after retention, including bounded red diagnostics.
  No managed run remains active. See Server/docs/TESTING.md for commands, the exact error contract
  and the difference between shared-entry policy checks and actual process verification.

### C31 increment — recovered cumulative flame deadlines and source frames

- Inspection of FlameAmmo.Fire/Update found a concrete timing mismatch before the planned flame/
  poison ownership extraction. The Client accumulates 0.35f deadlines with strict greater-than
  checks; ArmyFlameBurst repeatedly rounded each interval to eleven ticks. At 30 Hz from zero the
  source fires on 11/22/32/43/53/64, versus 11/22/33/44/55/66 on the old server. The original engine
  regression fails in checkpoint-213d8d6c25e74353b732aecae9bd3ad1. This is a reproduced code defect,
  not evidence of an observed historical live-player incident.
- ArmyFlamePulseClock owns cumulative binary32 deadline, last committed source time and ordinal.
  It is a value stored privately inside ArmyFlameBurst, without a new heap wrapper per shot. Strict
  equality, late frames, one commit per Update and six-check completion match the recovered bodies.
  Non-finite, negative, reversed or unrepresentable deadline authority fails before publication.
  The geometry/damage algorithm is unchanged; Simulation now has 633 authored C# files.
- MatchEngine launches and advances flame using its existing pause-excluding BattleCooldownClock.
  Flame executes at the same family position on source frames even when a fixed combat tick does
  not execute. Reconnect/terminal early returns still freeze it. Bullets and poison retain their
  fixed-tick gates. BulletPoison and MainGameEntity use the Client's separate Time.time domain;
  their wider timing review remains open instead of forcing them onto the flame clock.
- Player and bonus-box receipt identities now use committed pulse ordinal plus projectile/victim,
  so different source frames in one combat tick remain distinct and one committed pulse replays
  inertly. The bonus-box adapter takes the committed burst directly; existing controlled host tests
  were updated to commit their first/next pulses while retaining all replay/no-repeat assertions.
  No legacy test-only receipt path or extra positional argument was introduced. Flame skill-shot
  throttling consumes the same source clock, as SkillShotControllerPlayer does; other damage time
  inputs remain unchanged.
- FlameAmmoClockReference compiles the recovered Fire/Update body arithmetic with identifier-only
  substitutions. Runtime anchored extraction compares those exact bodies, ignoring whitespace and
  substituting only the documented fields/callback stubs. Ten groups cover the source schedule,
  offsets, exact/next-float boundaries, late frames, pause, malformed time and isolation, plus actual
  engine deferred player damage/throttle timing, bonus-box pulse replay and live reconnect/resume.
  The box case uses a real soldier with host-controlled callback placement/damage, not natural box
  targeting proof. Existing geometry checks now assert cumulative source deadlines.
- A new box fixture initially omitted ordinary bonus policy, and a new pause fixture initially
  requested an unsupported one-second idle timeout. Their bounded failed reports record fixture
  setup errors. The final fixtures explicitly enable ordinary bonus policy and use the valid
  two-second idle boundary. The original timing red remains separately identifiable.
- Final Debug and Release builds pass without warnings/errors. Release passes all ten clock groups,
  29 geometry assertions and every prior frozen connection/weapon/movement/player-bullet/bazooka/
  grenade/army-bullet trace. Four new C# files pass LF/width/whitespace hygiene. Six inspected Client/
  binding hashes are recorded without modifying recovered source or content. See
  Server/docs/ARMY_FLAME_CLOCK.md. Final integrated evidence is recorded next.
- Final checkpoint-a93bb2b4688d4a72bcea0c959226a3ae passed all 39 runtime/native stages on the final
  value-clock code. The source/host gate passed ten groups in 3.5 seconds. Full battle passed
  267,805 engine/admission/SDK/map/real two-peer UDP assertions in 607.9 seconds, including existing
  live Flamethrower/Commando, geometry, box replay and revenge checks. Native
  smoke-e91a68772cba46b9ba42424d558a9cb1 passed 74 live integration checks in 37.9 seconds and
  reclaimed 210,868,162 bytes after owned shutdown. No duplicate full combat run was needed; these
  correctness timings do not establish throughput or normal Unity/Android gameplay completion.
- Root .local remains 80,842 bytes and Server/.local 2,624,416,528 bytes/34,638 files. Managed
  LOCALAPPDATA storage is 473,108 bytes/73 files after retention. All managed runs and test Backend/
  Worker/battle processes ended; original mongod PID 6164 and unowned history remain preserved.
- C31 is complete at the source-clock/receipt/throttle scope. S07-S09, C03/C12/C13/C18, the separate
  flame cone/overlap arithmetic review in V02, measured performance, remaining test producers/Unity
  leases, V07 and actual Unity/Android retain their own completion gates.

### C32 increment — original managed interpolation for flame cone and minimum damage

- Executed Mathf.Lerp from the workspace's original 1.4.0 UnityEngine.dll and confirmed clamped
  interpolation inputs. FlameAmmo.CheckHit uses this for both distance^0.25 cone interpolation and
  1-distance/radius damage interpolation. The old server extrapolated both. At distance two it
  rejected an overlapping 38-degree target; a large overlapping collider centered at distance four
  produced invalid negative damage instead of the source minimum. Both regressions failed in
  checkpoint-6ed938cacd57438693a0f839564474e4 before production edits.
- ArmyFlameBurst.ResolveCenter now clamps those two inputs to 0..1. The far cone remains its source
  forty-degree half angle beyond distance one, and a valid overlap whose center lies outside radius
  receives minimum damage. Physical overlap, minimum distance, direction, strict angle rejection,
  collider order, raw damage validation, clock, receipt and world-effect routing remain unchanged.
  This changes legitimate hit/damage results; it does not widen the overlap sphere or hide malformed
  source authority. The controlled large-collider fixture is not an observed historical live incident.
- FlameInterpolationReference verifies and reads the 885,248-byte original UnityEngine.dll in place,
  loads a separate test-only assembly context and invokes the real managed Lerp through a float
  delegate. No Unity Editor, native physics engine, project/Library copy, package, production reference
  or copied runtime DLL is required. The checked source call expressions and original binary/binding
  hashes are recorded with the historical before-fix server hash in flame-interpolation-provenance.json.
- Eight groups cover original clamp endpoints, the two regressions, 440 damage/distance/angle matrix
  probes, physical overlap exclusion, near/edge filtering, first eligible collider and invalid raw
  damage. Vector/overlap calculations remain the existing managed geometry; this is an actual managed
  interpolation oracle, not a new native Physics.OverlapSphere or full scene oracle.
- Green checkpoint-2f088441d0574973a348fc78502a27d5 passes all eight groups in 0.9 seconds. Final
  Debug/Release builds pass without warnings/errors; Release passes all eight interpolation groups,
  ten C31 clock groups, 29 prior geometry assertions and every existing frozen connection/weapon/
  movement/player-bullet/bazooka/grenade/army-bullet trace. Two new C# files pass LF/width/whitespace
  checks. No Client scene, code, library, catalog identity or V07 provenance digest was modified.
  See Server/docs/ARMY_FLAME_INTERPOLATION.md; final integrated results follow.
- Final checkpoint-6a501ae622a1442f85d75679c4bbec8c passed all 40 runtime/native stages, including
  the original-math gate in 0.8 seconds. Full battle reported 267,803 engine/admission/SDK/map/real
  two-peer UDP assertions in 623.2 seconds. Native smoke-95a9a8012b2447f7b5ab5f2c564ef8df passed
  74 live integration checks in 36.7 seconds and reclaimed 210,867,519 bytes after owned shutdown.
  No duplicate full combat run was needed. These are correctness timings, not throughput results
  or normal Unity/Android gameplay certification.
- Root .local remains 80,842 bytes and Server/.local 2,624,416,528 bytes/34,638 files. Managed
  LOCALAPPDATA storage contains 937,345 bytes/118 files after retention, including bounded red
  diagnostics. No managed run or test Backend/Worker/battle process remains active; original mongod
  PID 6164 and unowned history are preserved. All three inspected original binary/source/binding
  hashes remain unchanged. No runtime Unity/Photon dependency was added.
- C32 is complete at the two interpolation inputs. S07-S09, C03/C12/C13/C18, wider geometry/source
  audits, measured performance, remaining test producers/Unity leases, V07 and actual gameplay
  retain their own completion gates.

### S07 eighth increment — separate flame burst and poison coroutine owners

- PvpArmyFlameSystem now privately owns burst storage and captured source frames. The frame returns
  a detached ArmyFlameSource for live soldier/owner/geometry preflight, then commits only at the
  prior engine point and returns ArmyFlamePulse for receipts and world effects. The sixth burst
  remains reserved until its world callback completes. Missing sources discard before commit only
  when due; terminal clear remains at its original point. C31 source frames and C32 math are unchanged.
- PvpArmyPoisonSystem separately owns independent coroutine storage and pending-pulse accounting.
  Its frame consumes the due pulse before victim lookup, then returns detached source, damage,
  position and remaining count. Missing/dead victims discard reservations; normal completion removes
  the fifth pulse after world effects. Impact, player damage, live-soldier revenge and terminal
  interruption retain their existing engine order. Already-issued poison survives soldier removal.
- Both owners capture ascending IDs at the original points and exclude later insertions. Frames
  require completion/discard before observing the next entry. Frame cursors and observations are
  value types; existing sorted arrays and model objects remain, with no new per-pulse wrapper.
  Read-only progress queries return detached arrays. This clarifies state ownership without claiming
  measured allocation, CPU or network speed improvement. Simulation now has 639 authored C# files.
- Before production edits, two independent original-engine captures matched all nine traces and
  16,238 observations. Frozen snapshots/replies/event bytes, exact clock bits and effect progress
  cover natural completion, soldier death, terminal boundaries, delayed flame frames, stacked
  poison and reconnect pause/resume. The temporary capture switch was removed. Historical input
  hashes are recorded in pvp-army-effect-baseline-provenance.json; expected hashes were not regenerated
  after extraction. All six original model/Client/binding hashes remain unchanged.
- Six flame and six poison owner/order groups verify commit timing, final reservation lifetime,
  captured insertion boundaries, discard, clock errors, detached observations, invalid insertion,
  match isolation and compiled ownership. Managed focused checkpoint-dbebbe3a3b03431ea3f8b25847602c6a
  passes in 5.4 seconds. The new pvp-army-effects case also runs in fast/runtime checkpoints.
- Final Debug/Release builds pass with zero warnings/errors. Release managed run
  army-effects-release-baf777579bdb484a9a8c03c64282d9d7 passes the new traces/12 owner groups, ten C31
  clock groups, eight C32 groups, 29 prior geometry assertions and every prior extracted-state trace.
  Ten new C# files pass LF/width/whitespace checks. No Unity project/Library copy or new production
  dependency is required. See Server/docs/PVP_ARMY_EFFECTS.md for lifecycle and verification details.
- Existing terminal poison retention is deliberately preserved as a prior-server boundary; source
  lifecycle intent remains part of V02. Shared world effects/capacity and other army families remain
  S07 work. No new correctness item is claimed. S07-S09, C03/C12/C13/C18, wider source/native-geometry
  audits, performance, remaining test producers/Unity leases, V07 and normal Unity/Android stay open.
- Final checkpoint-f3efee39a592439aa6e0a29c7e6ab030 passes all 41 runtime/native stages; the new
  effect stage takes 5.5 seconds. Full battle passes 267,855 engine/admission/SDK/map/real two-peer
  UDP assertions in 666.0 seconds. Native smoke-9e4182e9074d4a6983e63654617582fc passes 74 live checks
  in 37.6 seconds and reclaims 210,866,502 bytes after owned shutdown. No duplicate full combat
  execution was needed; these correctness timings do not establish throughput or actual gameplay.
- Root .local remains 80,842 bytes/4 files and Server/.local 2,624,416,528 bytes/34,638 files.
  External managed storage contains 937,571 bytes/129 files after retention. No managed run or test
  Backend/Worker/battle process remains active. Original mongod PID 6164, unowned historical evidence
  and all six inspected original model/Client/binding hashes remain preserved. Scoped diff checks pass.

### S07 ninth increment — paired Rocket Soldier and Mortar flights

- PvpArmyMissileSystem replaces parallel Rocket/Mortar flight and launch-authority dictionaries
  with one private set of paired entries. CardRocketLaunchAuthority moves to the feature folder with
  its namespace, immutable owner/missile/player policy and optional Mortar setup unchanged. Source
  factories, source setup/sickness changes, callbacks, random draws, shared ID/capacity/event checks,
  Mortar warnings and world damage remain with the engine. Simulation has 642 authored C# files.
- The value frame captures ascending IDs and advances one flight at a time. Completed flight and
  authority leave storage together; impact diagnostics are appended before event/world publication.
  Non-impact observations retain the live entry. Captures exclude later launches. Protobuf snapshots
  preserve family position, wire kind, optional Mortar unit identity, position/velocity and defaults.
  Last-frame impact snapshots and immutable metadata queries expose no stored mutable flight.
- BeginFlightFrame clears diagnostics even on an empty cleanup frame. The engine gate still includes
  outstanding impacts. Terminal clear removes flights/authority but preserves last impact diagnostics.
  A later already-captured impact after a terminal callback retains the original missing-authority
  exception after diagnostics and before world publication. That historical terminal continuation
  remains an explicit V02 Client-policy boundary, not a newly certified desired behavior.
- Private entries, frames and steps are value types. No new per-flight wrapper object was introduced;
  original flights, authority objects, sorted arrays and impact records remain. Pairing prevents
  ordinary operations from creating an orphaned flight/authority state. It is not evidence of an
  observed historical incident or measured CPU/allocation/network improvement.
- Before production changes, two captures matched all ten traces and 10,789 observations: natural
  real/fake Rocket and Mortar, each source soldier's death, each terminal cleanup, live Mortar
  reconnect pause/resume and BIGROCKET deployment. Full snapshot/reply/event bytes, exact clocks,
  launch queries and impact records are frozen. Fake fixtures require trusted accuracy 0.5; normal
  shared fixtures keep default one. Early fake setup could not produce the requested shot and was
  corrected before capture; a stale-binary selector was refused before any full suite. Neither was
  a server correctness regression. The temporary capture selector was removed.
- Eight owner/order groups protect paired/duplicate insertion, sorted detached projections,
  completion-before-callback, capture boundaries, original exception types, fake/Mortar behavior,
  impact lifetime, match isolation, cleared captures and compiled ownership. Managed focused
  checkpoint-8aa0d2b200ab4935931a625f6c1ff87f passes in 7.4 seconds. The pvp-army-missiles case is also
  included in fast/runtime checkpoints. Seven new C# files pass LF/width/method-size checks.
- Final Debug/Release builds pass with zero warnings/errors. Release managed run
  army-missiles-release-6eacc0f237534d629c987c3ccfb58d94 passes twelve focused cases: new missile traces/
  eight groups, every prior extracted-state trace, ten flame clock/eight interpolation groups and
  29 prior flame geometry assertions. Seven original flight/explosion/ordinary-source/Client/binding
  hashes remain unchanged. See Server/docs/PVP_ARMY_MISSILES.md and Server/docs/TESTING.md.
- Source review identified the separate expiry-versus-collision priority discrepancy now tracked in
  C33. This ownership increment preserves that algorithm; a source-anchored red/green correction is
  the next correctness step. Grenadier flights and wider army/world orchestration remain S07 work.
  S07-S09, C03/C12/C13/C18, C33, V02/V07, measured performance, remaining test producers/Unity leases
  and actual Unity/Android gameplay retain their own completion gates.
- Final checkpoint-4a067ac89aa8419e851f690e91880b51 passes all 42 runtime/native stages. The new
  missile stage takes 7.0 seconds; full battle passes 267,866 engine/admission/SDK/map/real two-peer
  UDP assertions in 641.0 seconds. Native smoke-561d07398184482598dce9346aa2ba37 passes 74 live checks
  in 36.7 seconds and reclaims 210,895,163 bytes after owned shutdown. No duplicate full combat
  run was needed; these correctness timings do not establish throughput or normal gameplay.
- Root .local remains 80,842 bytes/4 files and Server/.local 2,624,416,528 bytes/34,638 files.
  External managed evidence is 938,506 bytes/132 files after retention, with no running manifest or
  test Backend/Worker/battle process. Original mongod PID 6164 and unowned historical evidence are
  preserved. Scoped diff and seven new-file hygiene checks pass. C33 remains the next source-backed
  correctness step; wider ownership/performance/Client integration remain open.

### C33 increment — source expiry before straight missile collision

- Rechecked the active 1.4.0 Missile.Fire/AnimateShot/Update and TryKill. Straight Update expires
  after advancing past progress three; TryKill sets mExploded before the collision branch, so no
  same-frame ray occurs. The server queried collision first and could select a later collider or
  throw for collision authority after the source would already have expired at its advanced endpoint.
- Before production changes, checkpoint-ab6a957927a4479ab66f15eb60f55b67 fails six groups: real/fake/
  Mortar expiry, forbidden callback, differential matrix and paired-owner completion. Exact-boundary/
  arming and authority guard groups already pass. This is a controlled regression, not an observed
  historical live-player incident. The source method hash and ordered expressions anchor the
  reference; no recovered Client file or baseline was rewritten.
- The unchanged expiry branch now runs after finite-position validation and before collision. The
  source endpoint, null Collision, projectile/soldier/tick/fake identity and completion are retained.
  Exact progress three and earlier collisions still run. Speed/stop time, movement, target cap,
  arming, ray length, tick/finite/collision validation, source damage and paired ownership are
  unchanged. Reversing only the moved block/comment reproduces the complete pre-fix file hash.
- MissileExpiryReference is a managed translation of only straight progress, expiry and collision
  eligibility with synthetic rays. It does not execute original Unity Update or native physics;
  curved/moving-target/full-pause/scene fidelity remain separate V02 work. Eight groups include fifty
  real/fake/distance/speed/overhead-stop matrix scenarios, strict boundary/earlier collision, forbidden
  callbacks, skipped/duplicate ticks, non-finite/oversized launch input, invalid pre-expiry collision
  and paired-owner completion. No Unity project, Library, package, DLL or production dependency is added.
- Green checkpoint-35bc328753db495c98896b91e9aaee8a passes all eight groups in 0.8 seconds. All ten
  frozen Rocket/Mortar engine traces and eight owner groups remain unchanged. The new
  army-missile-expiry focused case is included in fast/runtime checkpoints. Two new C# files pass
  LF/width/whitespace checks; the largest ordinary methods are 36 and 31 lines. The two Client source,
  source-binding and paired-owner hashes remain unchanged. See Server/docs/ARMY_MISSILE_EXPIRY.md
  and missile-expiry-provenance.json for source scope and historical red-run inputs.
- Final Debug/Release builds pass with zero warnings/errors. Release managed run
  missile-expiry-release-f6951266e29e453a89db905f3d67120b passes thirteen focused cases: new expiry
  groups, every prior frozen ownership trace, ten flame clock/eight interpolation groups and 29 prior
  flame geometry assertions. Runtime/native verification follows on the same integrated code.
- Final checkpoint-cadb083878da4be6850b529aeecc50e0 passes all 43 runtime/native stages. The new
  expiry gate takes 0.9 seconds; full battle passes 267,867 engine/admission/SDK/map/real two-peer
  UDP assertions in 627.0 seconds. Native smoke-3a013c82c97146c9a80c310abf247854 passes 74 live checks
  in 36.6 seconds and reclaims 210,867,748 bytes after owned shutdown. Full combat ran once on the
  integrated correction. These correctness timings are not a CPU/network performance comparison.
- Root .local remains 80,842 bytes/4 files and Server/.local 2,624,416,528 bytes/34,638 files.
  External retained evidence is 939,980 bytes/135 files after retention. No managed run or test
  Backend/Worker/battle process remains active; original mongod PID 6164 and unowned history are
  preserved. Scoped diff and new-file style checks pass; source/binding/owner pins remain unchanged.
- C33 is complete at straight expiry/collision priority. S07-S09, C03/C12/C13/C18, wider V02/V07,
  actual Unity/Android and remaining test-producer/Unity leases retain their completion gates.
  P01 remains open: no standalone performance harness exists yet, so its implementation guide now
  specifies an isolated Release tool, recovered-content scenarios, exact report identity and bounded
  external artifacts. BattlePerformanceLedger is gameplay evidence, not a benchmark implementation.
