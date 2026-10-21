# Server test workflow and artifact retention

The MainScene mismatch has a [source-transition audit](MAIN_SCENE_PROVENANCE.md). Run
`python Server/tools/test_main_scene_provenance.py` and
`python Server/tools/audit_main_scene_provenance.py --check` for its eight regression cases and
current evidence report. These checks explain the historical scene delta; they do not replace the
source checkpoint or certify a new content release.

For the first static source candidates, run `python Server/tools/test_mission_content_candidates.py`
and `python Server/tools/stage_mission_content.py`. The latter creates one bounded managed run and
does not update production content. Set `WAR_TEST_RUN_ROOT` to the external managed root as described
below. Candidate success is not a passing production source checkpoint.

The [sheet-value audit and Mono probe](BATTLE_SHEET_VALUE_AUDIT.md) validate the separate numeric
export boundary with no Unity project copy. The value audit currently exits 1 for 390 differences;
the small managed probe proves the float conversion correction, not a new full-scene content release.

Run commands below from the repository root. The test projects are console executables;
`dotnet test` does not execute their current assertion suites.
The checkpoint and artifact scripts require Python 3.10 or newer.
Checkpoint and native/legacy smoke commands use Debug binaries. Build the default solution
configuration before --no-build/-NoBuild; a Release-only build does not refresh those binaries.
TestBackendQueue.ps1 is a separate Release gate and builds that configuration unless -NoBuild is set.

## Choose the smallest relevant gate

```powershell
# Source layout, artifact safety, build, protocol and economy. No Mongo or Unity Editor/native runtime.
python Server/scripts/verify_battle_checkpoint.py --suite fast

# Project/type ownership only, without a host, socket or Mongo process.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --battle-projects-only
python Server/tools/test_server_source_layout.py

# Frozen startup policy; the second case starts only deliberately invalid host processes.
python Server/scripts/verify_battle_checkpoint.py --suite focused --case backend-startup
python Server/scripts/verify_battle_checkpoint.py --suite focused --case startup-refusals
python Server/scripts/verify_battle_checkpoint.py --suite focused --case backend-http
python Server/scripts/verify_battle_checkpoint.py --suite focused --case worker-http
python Server/scripts/verify_battle_checkpoint.py --suite focused --case terminal-envelope

# Legacy registry/session boundaries and actual PHP route delegates; no Mongo fixture or database files.
python Server/scripts/verify_battle_checkpoint.py --suite focused --case legacy-dispatch --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case legacy-buffer-dispatch --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case legacy-diagnostics --no-build

# Focused developer gates and frozen source-bound state checks.
python Server/scripts/verify_battle_checkpoint.py --suite focused --case test-arguments --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-clock --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-geometry --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-interpolation --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case allocation-inventory --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-connection --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-weapons --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-movement --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-player-bullets --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-bazookas --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-bazooka-capacity --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case bazooka-combat --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-grenades --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-army-bullets --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case assaulter-volley --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case gunslinger-shooting --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case grenadier-primary --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case grenade-combat --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case grenades-burst-udp --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case bonus-grenade-policy --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case combat-content --no-build

# Heavier Release queue/reconnect/rematch/restart gate, with one owned Mongo replica.
./Server/scripts/TestBackendQueue.ps1 -MongoExecutable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'

# Exact player identity, signed admission and terminal ownership; no database process.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --canonical-identity-only

# After a successful build, this code gate takes roughly 15-20 seconds on this workstation.
python Server/scripts/verify_battle_checkpoint.py --suite fast --no-build

# One reviewed case, with owned logs, temporary storage and cleanup; no Mongo service.
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-perks --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case mixed-grenade-udp --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case shotgunner-udp --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case battle-projects --no-build
# Use --list to inspect the exact command without starting tests or creating artifacts.
# Omit --no-build to build once before the case. canonical-identity is also available.

# Full runtime combat suite, without claiming recovered-source provenance validation.
python Server/scripts/verify_battle_checkpoint.py --suite runtime --no-build

# Full source/catalog audits, build, protocol and combat checkpoint (the default suite).
python Server/scripts/verify_battle_checkpoint.py --suite battle

# Also run isolated native Mongo/HTTP/UDP integration. No redundant smoke rebuild.
python Server/scripts/verify_battle_checkpoint.py --suite runtime --no-build --native-smoke `
    --mongo-executable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'

# Fresh Release host packages, independent dependency graphs and identical shared Domain bytes.
# Uses owned disposable output; -KeepArtifacts pins complete packages for inspection.
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/TestBattlePublish.ps1

# Legacy response, rollback, economy and concurrent first-rename integration.
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/LegacySmoke.ps1 `
    -NoBuild -MongoExecutable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'

# One calculation family, with already-built binaries.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-economy-only

# Focused real UDP Shotgunner snapshots and immutable projectile scan replay.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --shotgunner-udp-only

# Pure envelope validation, including count/count+1 and duplicate/wrongly typed fields.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-buffer-parser-only

# Card-pool calculations and strict double-encoded quantity parsing.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-card-pool-only

# Source rank order, admission, creation and form assertions without Mongo.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-squad-only

# Registration metadata, exact source integers, frozen starting state and expiry bounds.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-account-only

# Fixed UDP configuration, real packet boundaries and complete oversized reply transfer.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --transport-mtu-only
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --reply-transfer-only

# Actual recovered buffer callback/value conversion, with instrumented manager/UI boundaries.
python Server/tools/generate_legacy_buffer_oracle.py
dotnet run --project Server/tests/War.LegacyContract.Tests --no-build
```

`LegacySmoke.ps1` also runs the real Mongo card-pool conflict/replay/rollback suites against its
existing isolated replica set, sequentially with the buffer transaction checks. No extra Mongo
directory or Unity project is created. See [CARD_POOL_PUBLICATION.md](CARD_POOL_PUBLICATION.md).
The same run also executes forced squad races, injected write failures and the live Backend's
authenticated squad HTTP fixture. See [SQUAD_PUBLICATION.md](SQUAD_PUBLICATION.md). Fixture funding
comes from trusted setup records; it does not change starting currency or add a public funding route.
Account publication/rotation and the live registration/login/device-tuple fixture run in the same
owned instance. Allocation/inventory and rematch storage selectors verify the shared test-account
setup migration. Transport-only fixtures skip unrelated password derivation; credential tests keep
the real 600,000-iteration work factor. See [ACCOUNT_PUBLICATION.md](ACCOUNT_PUBLICATION.md).
Dog-tag tests reuse that same replica for forced revision conflicts, wallet/session/clock changes,
failed atomic publication and live VIP/debt/boot callbacks. The headless source oracle also runs
144 original rule comparisons and two malformed-authority/policy groups. These checks create no
Unity project copy or separate Mongo directory. See [DOG_TAG_PUBLICATION.md](DOG_TAG_PUBLICATION.md).
The C14 verification passed all 16 fast/native stages (`checkpoint-db80146d43984fa89e101390610c6a91`)
and the eight new real-Mongo groups plus 339 base, 45 squad, 28 account and 14 dog-tag HTTP checks
(`legacy-bca2a080d6f34457829f6ec01b319e8c`). Successful legacy cleanup reclaimed 212,146,084 bytes.

The C13 parser/Settings increment adds five strict-state/default/metadata/resource groups and three
recovered Settings contract groups to the same small oracle. Exact byte/depth/node limits and
limit-plus-one inputs stay in memory. Legacy smoke reuses its replica for six Settings publication,
conflict and fault groups, plus direct request/auth/login/boot and rejected-buffer wire checks. No
extra Mongo instance or Unity copy is needed. See [STORED_STATE_VALIDATION.md](STORED_STATE_VALIDATION.md).
The strict-reader runtime/native checkpoint passed 267,669 full Battle assertions in 614.2 seconds
(`checkpoint-087ce4ea9ba5412380a1667304e6b977`). Final fast/native checks passed all 16 selected stages
(`checkpoint-668d59964fae4a9ab1f4ec87c9e98add`); legacy store/fault checks and 456 HTTP assertions passed
in `legacy-254de38bf8474ff29e71dd174a6a15e8`. These results cover this increment, not the entire C13 backlog.

The root-authority increment adds five in-memory groups for eighteen required numeric fields,
exact BSON types/widths, root domains, recovered Army Power scaling and placement policy. Three
source sections bring the reviewed inventory to 35 without a new assembly or Unity clone. The
same owned legacy replica runs 78 additional root HTTP/transaction assertions: malformed reads,
peer selection, invalid successor rollback, cached-receipt refusal and registration/login. Successful
`legacy-216da4b1860540ba8ee9cf0b5eac0497` passed all existing storage/fault groups and 534 combined
assertions, then reclaimed 212,206,707 bytes. The NaN no-mutation fixture compares raw BSON bytes.
The final action-192 extension adds canonical request boundaries and reusable publication checks
for changed revision/session/expiry and an invalid internal successor. Its final legacy run
`legacy-c64bf422b2b441f7ab32ca4c58a77800` passed 98 root Mongo/HTTP assertions and 554 combined
base/specialized assertions, plus the existing storage/fault groups, reclaiming 212,271,210 bytes.
The root count includes direct store guards; it is not a count of HTTP requests. The final build had
zero warnings/errors and all 15 no-build fast stages passed in
`checkpoint-ac4bfa252f8e44da89b51ac92fcc6d9b`.

Before the final direct-action extension, the shared root BSON/reader changes passed all 17
runtime/native stages in `checkpoint-309b09a075924267bef43fe3076a6b85`: 267,662 full Battle assertions
in 612.7 seconds and native smoke in 34.6 seconds, including 74 live integration checks and the
separate storage/recovery checks. These are Windows/headless/SDK results, not Unity gameplay proof.
No second full combat run was needed for the isolated direct-action extension; its final build,
protocol/pure gate and actual Mongo/HTTP tests cover that new path.

The profile increment adds four headless source/input/callback groups, ten forced Mongo groups
and 37 HTTP assertions using the same owned legacy replica. The source inventory is now 47; the
original rename getter, status enum, four callbacks and funds-error branch compile unchanged with
instrumented boundaries.
Twenty required numeric BSON fields now include Status/LastAction; the root fixture expands to 122.
`legacy-19b47d9706524dbba40e3cc729d4420b` passed the existing storage/fault groups and 614 combined
assertions (339 base, 45 squad, 28 account, 14 dog-tag, 30 Settings/state, 122 root Mongo/HTTP and
36 profile HTTP), reclaiming 212,326,231 bytes. This added no Mongo process or Unity copy.
See [PROFILE_PUBLICATION.md](PROFILE_PUBLICATION.md) for exact race and callback boundaries.

The final error-contract extension passed `legacy-78d3a9f58a764a468788b1e5da009102`: 615 combined
assertions, including 37 profile HTTP cases and both mandatory insufficient-funds rollback keys,
plus all storage/fault groups. It reclaimed 212,372,400 bytes. All nine inherited/absent legacy
environment keys were checked after that run before starting the native suite in the same shell.
The final zero-warning/error solution build and all 17 fast/native stages passed in
`checkpoint-b6e56549c63a4b93a843304134040391` (native smoke 34.4 seconds).

The shared twenty-field BSON/profile increment separately passed 267,724 full Battle assertions
in 618.2 seconds (`checkpoint-8b1d70ddb8c44679892ffe69fba9a348`, stage 16). That runtime report is
failed overall: its subsequent native stage exposed the environment restoration defect below.
The final isolated rename-error extension and corrected environment were covered by the subsequent
build, source/pure/protocol and actual Mongo/HTTP/native gates; a second full combat run was unnecessary.

The analytics increment adds four source/schema/metadata/chat groups to the existing headless
executable. Seventeen reviewed sections bring source entries to 64, preserving the prior 47 hashes.
Eight forced Mongo groups and 79 HTTP assertions reuse the owned legacy replica: two flag reads,
actual buffered transaction interleaving, session replacement/expiry, invalid state/successors,
generic bypass refusal, repeated true flags and database write failure. They create no extra Mongo
process, Unity copy or credential derivation work. See
[ANALYTICS_PUBLICATION.md](ANALYTICS_PUBLICATION.md) for the exact schema and lifecycle boundary.
The targeted run `legacy-918379f29dfe4dd7b5afadb4f0d4b1ab` passed the existing storage/fault groups
and 694 combined assertions, reclaiming 212,645,171 bytes. Final integrated results are recorded below.
The final zero-warning/error solution build passed, followed by all 18 runtime/native stages in
`checkpoint-6832749e59f74c8cb36dddaec4052f0e`: 267,663 full Battle assertions in 610.0 seconds,
native smoke in 34.4 seconds, and the source/pure/protocol/environment gates. Final
`legacy-f89400720b624c3f8de40b45547d0d7e` passed all storage/fault groups and 694 combined assertions
(339 base, 45 squad, 28 account, 14 dog-tag, 30 Settings/state, 122 root, 37 profile and 79 analytics).
Root counts include direct store guards. Successful final native/legacy cleanup reclaimed
210,894,304 and 212,591,952 bytes. No gameplay, Linux service or source-fidelity closure is inferred.

The tutorial increment adds four source/BSON/migration groups, eight forced Mongo groups and 20
HTTP checks in the same owned replica. Seven source sections bring the inventory to 71, preserving
all prior hashes. The actual start/dispatch and contiguous XP/tutorial/error excerpts execute with
instrumented boundaries; the complete classic callback is hash-reviewed, not claimed as full gameplay.
`legacy-fa6189bde9694bd69031b4c0820d21ab` passed existing storage/fault groups and 714 combined
assertions, reclaiming 212,766,309 bytes. See [TUTORIAL_PUBLICATION.md](TUTORIAL_PUBLICATION.md).
The final zero-warning/error build passed, followed by all 18 runtime/native stages in
`checkpoint-9b6116be50024b24bf74e33643b247f1`: 267,727 Battle assertions in 624.6 seconds and native
smoke in 34.4 seconds. Final `legacy-ebaf25f26a53408f99cb25cc4a55fb8c` passed storage/fault groups and
714 combined checks (339 base, 45 squad, 28 account, 14 dog-tag, 30 Settings/state, 122 root,
37 profile, 79 analytics and 20 tutorial). Successful native/legacy cleanup reclaimed 210,894,626
and 212,793,397 bytes. The earlier failed runtime run and scan correction are documented below.

The first S04 Domain extraction adds two fast/runtime/source stages: seven project-extraction guard
groups and 16 compiled Domain/resource/Persistence/portable-boundary checks. The seven groups pass
on Windows and WSL. Domain references only Shared; Persistence has no compiled Worker/signer reference.
See [BATTLE_PROJECT_BOUNDARIES.md](BATTLE_PROJECT_BOUNDARIES.md) for the remaining Backend dependency.
The final zero-warning/error build and all 20 runtime/native stages passed in
`checkpoint-77fcac4a5d724f3aa4308bfafa774af0`, with 267,679 Battle assertions in 714.2 seconds and
native smoke in 35.6 seconds. This run observed a legitimate five-to-four Shotgunner transition:
snapshot tick 540, new scan tick 541, four captured/replayed rows. Final
`legacy-565a3081136543388dda57f8124fe343` passed all existing storage/fault groups and 714 combined
checks. Successful native/legacy disposal reclaimed 210,895,396 and 212,802,081 bytes.
The full checkpoint's console-test temporary tree, including 30 observed subdirectories, was also
removed. Release publish proof `domain-publish-6aaaee848aa841e4bcac7d9c7ea607b8` verified identical
Domain DLLs in both hosts and only each host's own runtimeconfig, reclaiming 31,931,439 bytes.
Release publishing overlapped the runtime run; elapsed times are observations, not comparative
performance results. All four successful run markers confirm their disposable data is absent.
No Linux service execution, Unity/Android completion or source-provenance V07 closure is inferred.

C24 adds five protocol identity groups and five in-memory match/allocation/cover/signing/terminal
groups. The four modern Mongo corruption groups verify authentication refusal before KDF/session
rotation with byte-identical documents. Legacy root HTTP/store checks increase from 122 to 138;
all four alias families refuse shared reads, buffer planning/receipts and publication without writes.
Three correctly MACed invalid control rosters return 400 without journal/outbox publication.
See [CANONICAL_IDENTITIES.md](CANONICAL_IDENTITIES.md) for the exact contract and repair boundary.
The first integrated run, `checkpoint-6f490bf4c71845da8b2093f17c5be28a`, failed an existing assertion
that required cover owners to normalize uppercase IDs. The corrected scenario now checks refusal,
preserved ownership after an alias release attempt, and successful release by the canonical owner.
The final zero-warning/error build and all 20 runtime stages passed in
`checkpoint-16bb93b8d26c4e7380ea0d1f6e336daa`: 267,681 full Battle assertions in 716.4 seconds.
Its full runtime suite, native smoke and legacy smoke ran sequentially. Native
`smoke-b8fbb2032d3d458b802c43d09ac0c0b6` passed 74 live checks plus the three signed-roster refusals;
`legacy-cc5b682bfde046d7b414297525a88c3b` passed all existing storage/fault groups, four modern identity
groups and 730 combined legacy checks. Those consist of 339 base, 45 squad, 28 account, 14 dog-tag,
30 Settings/state, 138 root, 37 profile, 79 analytics and 20 tutorial assertions.
Both scripts restored all 17 observed caller environment keys, including TEMP/TMP/TMPDIR, in the same
PowerShell process. Successful native/legacy finalization reclaimed 210,894,508 and 212,903,892 bytes.
All three completed markers confirmed their disposable data was absent before normal retention.

The subsequent tooling-only increment moves MixedBattleUdpFixture and army-perk tamper fixtures
from explicit Server/.local paths to the caller's temporary root. The new focused suite records its
named case in results.json and cannot silently select the full suite or start a Mongo service.
Three initial case/build command scopes and four invalid selector combinations were checked without
starting services; the added mixed-grenade case then ran against its actual Worker and two SDK peers.
Final zero-warning/error build and all 19 fast stages passed in
`checkpoint-cac31c82071a4493ad402c7537fe2b6e`. Focused runs
`checkpoint-273896370a454ec3bc2142c6d34535b3` (46 army-perk checks),
`checkpoint-3cf4994443814836b409eff948b93c17` (four Shotgunner UDP checks, tick 478 to 479, five rows),
and `checkpoint-95d323915321423bbcf3acc54d70d6a2` (12 mixed grenade lifecycle checks) passed.
The mixed fixture's logged path is inside that checkpoint's data/temp; finalization removes it.
The full combat/native/legacy suites were not repeated for this path/runner-only change.
CLI selection and Bash syntax were also checked on WSL; this is not Linux service execution.
Successful reports are subject to the same five-run/512-MiB retention, including focused runs.
Pin a managed run with .keep when its raw evidence needs longer review; documentation preserves the
observed checkpoint results even after normal report retention. T02/T04/T05 remain open for the
remaining producers, storage categories and deployment/gameplay gates.

The complete S04 content/simulation extraction expands compiled project checks from 16 to 57 and
retains --battle-domain-only as an alias for --battle-projects-only. Source layout now checks 631
origins/914 destinations plus the original 687 root moves. Exact declaration comparison verified
1,021 moved/split parts; the seven layout regression groups and 62 terminal-reason audit pass on
Windows/WSL. The terminal audit now runs in fast/runtime gates, making them 20/21 stages without native
smoke. Its source lookup and the corresponding C# abort fixture were corrected after the first full
run, checkpoint-4c82b8c807dd473282ae5ffc6bfc6278, failed its nonempty source scan after 112 seconds.

Final zero-warning/error build and all 22 runtime/native stages passed in
`checkpoint-f051e80184bb4457a8aa113664d70083`: 267,792 Battle assertions in 598.4 seconds and native
smoke in 35.9 seconds. `smoke-92afe0e497514d8c9a44e256837cea77` passed 74 live checks plus the three
signed-roster cases; `legacy-a0cd6fb7fcf74441a81a5b8f9a1e4807` passed storage/fault groups and 730 combined
legacy checks. Native/legacy disposal reclaimed 210,894,681 and 212,586,588 bytes. The full runtime
observed the valid tick-440-to-441 four-row Shotgunner scan. All owned disposable data was removed.

Reusable TestBattlePublish.ps1 passed on Windows PowerShell as
`battle-publish-33513c0a06164390bf9a0908192310ca`. Fresh Release Backend contains neither Worker nor
Simulation; Worker contains Simulation but neither Backend nor Persistence. Both contain only their
own runtimeconfig, and their Domain SHA-256 is
`8bf850fc0ebd298ebe6e541e334df920e56456bc8f311f904844f5de3339a1a3`. Cleanup reclaimed 28,659,849 bytes.
The verifier records native-adapter presence but does not provision or execute native binaries;
neither managed output includes WarRopePhysics.dll. Native physics distribution remains a separate
deployment prerequisite. Debug build, runtime/native, legacy and publishing ran sequentially; these
elapsed times do not prove a comparative performance gain. Source V07 and actual Linux/Unity/Android
gates remain open. See [BATTLE_PROJECT_BOUNDARIES.md](BATTLE_PROJECT_BOUNDARIES.md).

```powershell
# These selectors use an already-running owned smoke Mongo/Backend; they do not start another database.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-dogtags-store-only $env:Mongo__Uri
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-dogtags-http-only `
    $env:Mongo__Uri $env:Mongo__Database 'http://127.0.0.1:18081'
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-settings-store-only $env:Mongo__Uri
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-settings-http-only `
    $env:Mongo__Uri $env:Mongo__Database 'http://127.0.0.1:18081'
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-root-state-http-only `
    $env:Mongo__Uri $env:Mongo__Database 'http://127.0.0.1:18081'
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-profile-store-only $env:Mongo__Uri
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-profile-http-only `
    $env:Mongo__Uri $env:Mongo__Database 'http://127.0.0.1:18081'
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-analytics-store-only $env:Mongo__Uri
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-analytics-http-only `
    $env:Mongo__Uri $env:Mongo__Database 'http://127.0.0.1:18081'
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-tutorial-store-only $env:Mongo__Uri
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --legacy-tutorial-http-only `
    $env:Mongo__Uri $env:Mongo__Database 'http://127.0.0.1:18081'
```

`--no-build` reuses existing binaries; build again after changing C# or project files. The native
PowerShell scripts check that their required Debug binaries exist. Existence does not prove freshness.
Full runtime tests include actual sockets and native physics; use them for integrated verification,
then iterate with focused tests. Unity Play Mode, Android, production Linux and performance tests
remain separate gates. Do not run them automatically for a pure calculation or folder move.

The checkpoint writes per-stage logs and `results.json` with exit codes and elapsed time. A failed
stage stops the selected gate and prints its log location. The suite name records whether source
audits were included; a successful `runtime` report cannot be used as a successful `battle` report.
On 2026-10-21, the integrated Windows runtime/native gate passed all six selected stages: the full
Battle suite reported 267,356 assertions and the native smoke reported 74 live integration checks
plus its separate storage/ordering checks. Legacy smoke separately passed 260 assertions. These
results do not close the source provenance failure below or prove Unity/Android gameplay.

The subsequent buffered-economy increment adds the envelope stage to fast/runtime/battle gates.
Legacy smoke now runs eight targeted real Mongo transaction/fault scenarios before its HTTP fixtures;
the expanded HTTP suite passed 331 assertions, including stable replay outcomes and current rollback fields.
The pure envelope/payload suite passed 48 checks. Wrongly typed strings and equipped flags return
per-action JsonFailure instead of escaping as JSON-node type exceptions.
Ten delivery-clock checks, seven rollback checks and nine bound cosmetic replay checks run in the input selector.
The fast checkpoint and legacy smoke also run the recovered callback oracle: 1,188 matrix checks,
50 original producer scenarios and 151 catalog-fixture scenarios. All 126 current literal server
action/result dispositions require first-delivery and changed-authority replay proof. Six scanner
guard checks run in the fast checkpoint. Two synthetic JSON fixtures total 20,290 bytes and require
no temporary data directory, Unity project copy or extra database. The two original
managed Client DLLs are test-only JSON/type-metadata dependencies. See
[LEGACY_BUFFER_CONTRACTS.md](LEGACY_BUFFER_CONTRACTS.md) for source hashes and the stubbed gameplay boundary.
The same console also runs 13 purchase/promotion rank boundary scenarios, malformed-authority
rejection and comparisons against six compiled, unchanged Client rank properties.
Nine focused catalog groups check immutable aliases, numeric/schema rejection and stage/lane binding;
eight configured-release groups check the real source snapshot entirely in memory. Another 63
producer scenarios cover normal/tier/Elite boundaries, delivery proof, wrong kinds and helper admission.
The compiled Client upgrade getters independently check all 66 weapon and 24 player-unit tracks.
Fast/runtime checkpoints now also check the 132-sheet release profile and current scene role pointers.
The MTU stage adds real 1199/1200-byte authenticated loopback packets, unsupported configuration and
near-maximum chunk-transfer packet checks; it creates no files. The separate reply-transfer selector
also exercises the actual Worker and two SDKs. See [UDP_BUDGET.md](UDP_BUDGET.md).
The fixed-budget increment passed 314 focused MTU checks, 152 Worker/two-SDK transfer assertions
and all 16 fast/native stages (`checkpoint-bf22527dac4440169a21d0b8977d315d`). Native smoke took
34.3 seconds and reclaimed 210,856,189 bytes of disposable data. Full combat simulation was not
rerun for this startup-budget change; the earlier full runtime result remains scoped to its own run.
These tests create no temporary exports. See [LEGACY_CATALOG_VALIDATION.md](LEGACY_CATALOG_VALIDATION.md).
On Windows,
the checkpoint separately runs seven pure PowerShell replay scenarios; the helper was verified on
both Windows PowerShell 5.1 and PowerShell 7. No database is needed for these checks.
See [BUFFERED_ECONOMY_PUBLICATION.md](BUFFERED_ECONOMY_PUBLICATION.md) for transaction guarantees,
non-expiring receipts, historical migration limits and resource budgets.

## Managed artifacts

Both host composition roots are now extracted: Backend has 27 lines and Worker 22. Five Backend
HTTP groups, two Worker route/shape groups and three terminal-envelope groups run without services;
the compiled project boundary gate now checks 65 owners/dependencies/resources. Counts without build
are 24 fast, 26 runtime and 27 runtime/native. This increment ran fast/native and Release live
queue/reconnect/rematch, rather than repeating unchanged full simulation. See
[WORKER_HOST_STRUCTURE.md](WORKER_HOST_STRUCTURE.md) and
[TERMINAL_HTTP_ENVELOPE.md](TERMINAL_HTTP_ENVELOPE.md) for exact limits and fixture scope.

Final Debug/Release builds passed with zero warnings/errors. All 25 fast/native stages passed in
checkpoint-5d5f5a1d09b24364a6f0a0b51a478295; native smoke took 35.5 seconds. Its
smoke-ab86a9a5fffc4cc0bc4f8781cdf26821 reclaimed 210,894,723 bytes. Startup checkpoint
b5125173087e4ad887f69da5535f2d74 passed seventeen real host refusals. Release
backend-queue-4e2733c2a4694b76a9dfbead230c31de passed actual queue/reconnect/rematch/restart recovery
and reclaimed 212,734,446 bytes. Legacy legacy-f97e3459d3dc4125a4ba27f584b48448 passed storage/fault
groups and 730 combined checks, reclaiming 212,634,414 bytes. Fresh independent Release publish
battle-publish-113ede04d01c4a95bdf9b755bfadab4c passed and reclaimed 28,741,161 bytes. The Domain
digest remains unchanged. Windows/WSL exact layout, eight extraction groups, 21 artifact checks
and Bash syntax passed; the full unchanged combat suite was not repeated for these host/HTTP changes.

Failed reproduction evidence and fixture scope are recorded in the terminal-envelope guide. Its
maximum binary test retains real engine semantics with a canonical compatibility-field pad; it is
not normal Unity gameplay proof. Final managed storage is 424,735,778 bytes across eleven children,
mostly two retained diagnostic failure databases, within the existing bounded policy. Historical
workspace data is unchanged; successful data is removed and only the original Mongo service remains.

Native smoke now includes thirty-one Backend and thirty-seven Worker HTTP scenarios. They exercise
maximum binary/canonical payload, derived decoded/wire limits, ordinary/raw one-byte chunks,
unchanged unrelated body budgets, MAC/shape errors, HTTP/1 closure and no terminal writes on refusal.
Both native scripts deliberately choose auth PermitLimit=20 for the single test IP: the two extra
oversize registration requests must not consume the account suite's ten-request production-default
budget. The setting is restored on Windows and scoped to the Linux script process.

The Backend portion of S05 extracts modern route/application ownership; see
[BACKEND_HTTP_STRUCTURE.md](BACKEND_HTTP_STRUCTURE.md). Its historical first-phase verification follows.
The new pure HTTP gate checks streaming/declared limits, MAC/clock binding and all nineteen route
method/path/limiter mappings. Four groups run in fast/runtime; counts without build are now 22 fast,
24 runtime and 25 runtime/native. Startup refusals now include two exact store database-name cases,
bringing their separate real-process count to seventeen. Native smoke adds twenty-two internal HTTP
checks, including accepted terminal replay and zero result writes after oversized rejection.

Both Debug and Release solution builds passed with zero warnings/errors. Final
checkpoint-1849f10f9c2d4be2904bffe3fe0bde90 passed all 23 fast/native stages; native smoke took 35.1
seconds. smoke-0dadd44f3a994dc5baabe4393c49aff4 passed 74 live checks plus the new internal and existing
signed-roster cases, reclaiming 210,894,565 bytes. The focused process-refusal checkpoint was
checkpoint-f24882ef608b4db7aa3264bb49c8e11b. Legacy legacy-2af8195e718b4b1da6aba8eba1310cc9 passed
storage/fault groups and 730 combined checks, reclaiming 212,841,841 bytes. Fresh Release publish
battle-publish-2319ab7b6f594cfea079122af0d43a55 passed independent host graphs and reclaimed 28,721,433
bytes. Full combat was not repeated for this Backend-only extraction; the earlier C16 full runtime
remains scoped to its own source/run. V07, C18 and normal gameplay remain separate gates.

Release backend-queue-a50d690cc4ae4776a8f95d88c38618e8 passed real deferred preparation/provisioning,
stable grants/reconnect, scoped cancellation, same-opponent rematches and multiple actual Backend/
Worker restarts and outage recovery. It reclaimed 212,662,186 bytes. This headless gate passes no
Unity executable/project, creates no Library copy and uses Directory.CreateTempSubdirectory under
the harness's owned TEMP/TMP/TMPDIR. Compact reports remain subject to normal retention.

The C16 startup/composition increment adds ten pure startup-policy groups to fast and fifteen actual
Backend/Worker refusal processes to runtime. With --no-build, fast has 21 stages, runtime 23 and
runtime --native-smoke 24. Invalid-host processes must exit before Mongo initialization or outbox
creation. They use owned temporary logs and a deadline, without a database fixture. See
[BACKEND_STARTUP.md](BACKEND_STARTUP.md) for settings, explicit legacy mode and the open S05 boundary.

Final Debug solution build passed with zero warnings/errors. Runtime/native
`checkpoint-a0f862221de147fcb8e18ebc2b130200` passed all 24 stages: 267,795 Battle assertions in 611.8
seconds, including the valid tick-567-to-568 five-row Shotgunner scan, and native smoke in 34.5 seconds.
`smoke-518076a34b6a4eb0b491eacedf4a84ba` passed 74 live checks plus three signed-roster refusals;
`legacy-5f523a2d12b44f618147061960d48a51` passed all storage/fault groups and 730 combined legacy
checks. Successful disposal reclaimed 210,856,409 and 212,845,753 bytes. Fresh Release host publish
`battle-publish-f7cb32dba2414297b9301f5b08f757b5` retained independent graphs and the unchanged Domain
digest, reclaiming 28,689,957 bytes. This verifies managed publish, not native packaging or Linux runtime.

Earlier runs exposed old fixtures using empty paths for absence and zero signing keys for successful
co-op/pose admission. Fixtures now omit absent settings and use valid deterministic keys; dedicated
zero-key rejection remains covered. One repetition used stale Debug binaries after a Release-only
build, which is why matching build configuration is explicit above. Runtime success does not close
the separate V07 source-provenance failures or C18 ordinary gameplay settlement.

To keep temporary databases off the checkout drive, select a dedicated root for this checkout.
The same ownership checks, successful-data cleanup and bounded retention apply there:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/LegacySmoke.ps1 -NoBuild `
    -MongoExecutable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'
python Server/scripts/test_artifacts.py report
```

On Linux, `WAR_TEST_RUN_ROOT=/your/local/test-runs` selects the same alternative; native smoke's
explicit `SMOKE_RUN_ROOT` takes precedence. Keep the override set when inspecting or pruning that
root, or pass `--root` explicitly. Unset it to return to the workspace default. Historical workspace
evidence is not moved or deleted. The override lifecycle has a dedicated CLI ownership regression.
Run Mongo suites sequentially on a constrained disk: a local E: run recorded a 92-second WiredTiger
checkpoint and exhausted the storage-fixture deadline. The override permits choosing a suitable
local volume; it is not a claim that every machine's system drive is faster.

Unless WAR_TEST_RUN_ROOT is set, new checkpoint, Windows native smoke, Windows legacy smoke and
Linux native smoke runs use
`Server/.local/test-runs/<suite>-<id>/`. Each has a `test-run.json` ownership/status marker.
Logs and reports stay at the run root. Large disposable Mongo files and native-smoke outbox data go
under `data/`. The scripts stop and wait for their owned service processes before finalization.

On success, disposable `data/` is removed. Failures retain it for diagnosis. `-KeepArtifacts` on
Windows or `KEEP_TEST_ARTIFACTS=1` on Linux preserves a complete run and pins it against pruning.
Putting `.keep` in a managed run also pins it. Interrupted/running runs remain protected for manual
inspection. New v2 manifests bind the owner PID to its exact OS creation identity. Windows uses
GetProcessTimes creation FILETIME; Linux uses the boot UUID and /proc start ticks. Completion
rechecks that binding before deleting disposable data. PID reuse cannot complete an older run or
pin a completed run forever. If a live process's creation metadata is inaccessible, pruning preserves
the run. Legacy v1 manifests remain readable with conservative PID-only handling; no creation proof
is invented for them, and running records remain protected regardless of owner liveness.

Automatic retention applies only to validated, completed, unpinned managed runs whose owner is no
longer running. Defaults keep at most five passing and three failing runs, at most 14 days old,
within a shared 512 MiB budget. The byte budget can reduce those counts. Active, pinned, linked,
malformed or unmarked historical data is excluded from automatic deletion and the retained budget.

```powershell
# Preview deletion; this never deletes files.
python Server/scripts/test_artifacts.py prune

# Apply the same bounded policy to eligible managed runs.
python Server/scripts/test_artifacts.py prune --apply

# Inventory all existing evidence, including historical files, without deleting it.
python Server/scripts/test_artifacts.py --root Server/.local report

# Artifact lifecycle and path/ownership safety checks.
python Server/scripts/test_test_artifacts.py
```

The cleaner validates direct-child paths and markers and refuses linked subtrees. It never recursively
clears the entire `.local`. Historical Unity projects, native toolchains, backups and retained Worker
evidence require individual review. Existing C# tests that still create unmarked temporary folders
are tracked for migration; this first increment does not claim all historical producers are managed.
The original nine lifecycle checks passed on Windows Python 3.13 and WSL Python 3.10. The creation
identity/temporary-root increment passes 21 checks on both, including real child-process identity,
forced PID reuse,
inaccessible creation metadata, corrupt/missing identity, legacy compatibility, parent-owned CLI
completion, child temporary-root isolation, refusal of another CLI parent, refusal after completion,
and ownership changing between prune selection and deletion. This verifies the cleaner on both systems;
execution of the Linux native service smoke
remains a separate gate.

The inventory on 2026-10-21 measured approximately 2.05 GiB in this checkout's `Server/.local`,
including loose files. The largest item was the 1.40 GiB co-op geometry Unity project; two older
smoke/legacy directories each contained approximately 201 MiB. The reported 100+ GiB was not present
in the current checkout during this inspection. New successful legacy runs demonstrated disposal
of approximately 201 MiB per run while retaining their small logs and ownership record.
The later root-authority increment measured 2,835,348,996 bytes (about 2.64 GiB) in Server/.local
and 80,842 bytes in root .local. Its new database runs remained under bounded LOCALAPPDATA storage;
the runtime verification added no Unity project clone. This measurement does not inventory other
checkouts or external caches.

For future Unity audits, reuse a deliberately leased disposable project per source/import revision,
instead of copying a new full Assets/Library tree for each server test. Implementation of those
cache leases remains open; do not share an active Unity project across concurrent Editor runs.

An additional read-only inventory on 2026-10-21 found 14,067 WarFriends-prefixed entries under the
user's OS temporary directory, totaling 3,267,011,658 bytes. Its largest item was a 1,430,988,111-byte
Unity audit copy; several old sabotage Mongo fixtures each retained about 201 MiB. This measurement
includes ongoing test artifacts, does not inventory unrelated user files, and does not prove a
100-GiB directory. Unmarked historical entries remain preserved; their names do not establish
ownership or safe deletion.

The post-C24/focused-run inventory measured 2,835,453,402 bytes across 34,755 Server/.local files
(2.6407 GiB), with root .local unchanged at 80,842 bytes. The separately managed LOCALAPPDATA root
contained 1,602,577 bytes across nine retained children after cleanup and ordinary retention.
The original MongoDB service remained running; the smoke scripts left no additional mongod process.

For checkpoint-launched `dotnet run` stages, TEMP, TMP and TMPDIR now point to that live run's
`data/temp`. C# GetTempPath producers and their in-process Workers therefore share disposable owned
storage without rewriting gameplay fixtures. The helper verifies the current process creation
identity before creating that directory and never changes the parent's environment. Success removes
these temporary files with the run's data; failure/keep retains them. Solution builds keep their normal
temporary environment because persistent compiler/build servers may outlive the command. Windows native
and legacy smoke scripts now validate their own live owner through `test_artifacts.py temp-root` after
build, then set the same three variables for their tests and service children. Both restore the caller's
original absent/empty/value states after stopping their owned processes. Linux native smoke validates
the same owner before exporting its run's temporary paths within the script process.
Direct console invocations outside a checkpoint still need migration or an explicitly owned temporary
root. Six C# test files still mention `.local`: some retain real Worker fixture output, while others
write or read Unity audit exports. Those paths require a producer/consumer review rather than a blind
replacement. T02/T04 remain open for these producers and the Linux service execution gate.
The remaining explicit paths have different consumers:

| Test source | Existing output and migration constraint |
| --- | --- |
| LiveBazookaUnityTests.cs | Bazooka fixture directory shared with a Unity audit; pass an explicit export root |
| LiveRifleTests.cs | Optional Unity Editor logs; keep the audit consumer's path explicit |
| LiveSmgTests.cs | Optional Unity Editor log; preserve process shutdown before retention |
| Program.cs | Optional Unity SDK audit log; separate Editor invocation from the normal code gate |
| CoopCornerPreparationPlanTests.cs | corner-interruption-sample.bin consumed by a documented Unity probe |
| CombatContentTests.cs | Two obstacle-initial binaries read by UnityCoopWalkingVisualAudit |

The two binary producers currently run within the ordinary combat suite and overwrite small fixed
exports. They do not account for the multi-gigabyte history, but remain uncontrolled workspace writes.
Gate future export generation behind an explicit audit destination, update the Unity readers/docs in
the same change and prove the normal gate no longer writes those files. Do not silently redirect
only a producer and leave its consumer reading an older sample. Reusable Unity project leases remain
T06; none of the configuration tests added for C16 creates an Editor project or Library copy.
The full runtime process above started before temporary-root redirection was added. That tooling
change passed all 16 fast stages in `checkpoint-18709fa992a54f73a2b8895084333100`. Real focused UDP
run `temporary-root-proof-fcc0fc3a55ea46bea5f5d1bb4483a1bb` then created C# Worker output inside
the owned temporary root and removed its entire 1,072-byte data tree on success. This proves the
actual application honors the temporary environment, alongside the 19 lifecycle checks; no second
full combat run was needed for the environment-only change.

## Real UDP scan timing

`checkpoint-104039bc582843238ff7abc59dca6abc` failed in the live Shotgunner check after 610.6 seconds;
it did not reach native smoke. Both peers had observed five pellets, but no subsequent complete scan
met the test's five-live-pellet condition. A poll and a new scan are different simulation reads: the
real pellet may hit before the scan while four longer-lived cosmetic trails remain. The old condition
incorrectly required the earlier count to survive that interval.

The focused selector now retains exact same-burst five-pellet identity proof on both peers and exact
same-tick snapshot/scan agreement when their ticks match. A complete frozen scan must replay its own
bytes and all pages after a deliberate 100-ms live advance. It may capture either the full five or
the remaining four cosmetic trails; it never compares different ticks as one frame. Compact tick/count
observations accompany failures. Two focused runs passed before the final integrated rerun; that is
test-harness evidence, not a production combat change or Unity gameplay verification.

## PowerShell environment isolation

On PowerShell 7.6.7, passing a null variable to Environment.SetEnvironmentVariable retained an empty
key instead of restoring absence. A same-shell LegacySmoke followed by native smoke therefore left
Legacy__ContentPath empty; the Backend correctly rejected that configured empty catalog path.
The failed native run is `smoke-540ca2c672a04add990fc9cff1e30861`. Catalog validation was not weakened.

Both Windows smoke scripts now restore absent keys through the environment provider and preserve
explicit empty/value states separately. TestEnvironment.ps1 runs in fast/runtime/full checkpoints
and checks all supported states on both installed hosts: PowerShell 7.6.7 supports explicit empty,
while Windows PowerShell 5.1 removes empty values in its older environment API. The final same-shell
LegacySmoke-to-native chain passed with exact prior presence and values conserved.

```powershell
Server/scripts/TestEnvironment.ps1 -IncludeAvailableHosts
```

## Direct legacy dispatch checkpoint

The legacy-dispatch focused gate runs ten groups in approximately 1.2 seconds on this workstation.
It uses an unreachable Mongo endpoint and no database process or directory. It verifies the actual
PHP route delegates as well as the typed dispatcher: dispatcher-only checks initially missed an
empty action-157 body from an ambiguous async-lambda mapping. The new adapter regression failed
before that mapping was corrected and now preserves raw configuration, malformed-request JSON and
the exact reachability text.

LegacySmoke adds authenticated and unauthenticated HTTP checks for all 111 closed/buffered-only
actions and verifies unchanged wallets. legacy-b8f330824037442ca4197ba39dfff703 passed its existing
storage/fault groups and 954 combined HTTP/base assertions; cleanup reclaimed 212,827,186 bytes.
checkpoint-0d0a62653cb541d4b3376305d88f23d9 passed all 26 fast/native stages. Release
backend-queue-d2fb4ad85c0f4750b7fa55f8abd3459e passed recovered start acknowledgement, grants,
reconnect/rematch and restart/outage recovery. Final Debug/Release builds and all 25 fast stages
passed after naming/import cleanup in checkpoint-2bcf50939e6541cca3b32177cf9665b2.

The managed LOCALAPPDATA root contains 215,346,980 bytes after retention, including diagnostic
failure evidence. Historical root .local (80,842 bytes) and Server/.local (2,835,453,402 bytes) are
unchanged. No test Mongo process remains. See [LEGACY_ACTION_STRUCTURE.md](LEGACY_ACTION_STRUCTURE.md)
for source contracts and current direct/buffered feature ownership. These gates do not establish
normal Unity gameplay or a networking/calculation performance improvement.

## Buffered feature and diagnostic checkpoint

The buffered planner's 25 supported actions now execute through a typed registry and eleven
stateless Inventory/Economy/Cards/Squads owners. Five process-free groups validate compiled ownership,
invalid/missing/duplicate handlers, request isolation, failed-publication guards and closed/malformed
actions. Three additional process-free groups capture rendered/structured diagnostic logs, prove
payload omission and UTF-8 byte units, and preserve mandatory Client response fields. Focused runs
took about 0.9 and 0.8 seconds respectively; neither starts Mongo or writes a database directory.

The recursive producer scanner has nine tests, including nested relocation and cross-file duplicate
rejection. The unchanged 71 Client hashes and 25 result inventories pass; executable contracts still
cover 1,188 callback/value checks, 50 actual producer scenarios, 151 catalog/replay cases and 126
reviewed action/result dispositions. These checks do not claim every game formula is audited.

checkpoint-87b9b16de4f84eab90144b6dda3f81e6 passed all 28 fast/native stages; native smoke completed
in 38.1 seconds. legacy-c08e9abf820b4d3c8e3275a9293020c6 passed storage/concurrency/fault groups and
954 combined HTTP/base checks, reclaiming 212,614,972 bytes. Debug and Release builds passed with
zero warnings/errors. Source provenance V07, actual Unity gameplay and unchanged full combat remain
separate; this Backend-only change does not establish measured network/calculation throughput.

## PvP connection state checkpoint

The pvp-connection focused gate runs nine frozen before/after engine traces (108 full observations)
and six owner/order groups in approximately one second without a listener or database directory.
Its baseline was captured twice before simulation edits; normal execution never updates it. Full
snapshot/reply/terminal/event protobuf bytes and exact clock bits must match, with explicit human
assertions for deadlines, winner selection, phase order and pause/resume behavior. See
[PVP_CONNECTION_LIFECYCLE.md](PVP_CONNECTION_LIFECYCLE.md) for source rules and the update sequence.

checkpoint-878944a56acd45f881fb1ca162243609 passed all 31 runtime/native stages. The full battle
stage reported 267,866 engine/admission/SDK/map/real-UDP assertions and took 716.7 seconds alongside
an independent Release queue run. Native smoke-df8582c3054b4bce8c36b9909875ee10 passed in 36.5 seconds
and reclaimed 210,894,851 bytes. backend-queue-399769cc221e406ea85d0d805e6676b4 passed real Release
queue/grants/reconnect, rematch, cancellation and process restart/outage recovery, reclaiming
212,591,914 bytes. Both solution configurations build with zero warnings/errors.

Historical .local sizes remain unchanged. Managed LOCALAPPDATA storage contains 214,644,654 bytes
after retention; no test process remains. S07 is only partially extracted, and normal Unity/Android,
Linux services, performance comparisons and V07 source reconciliation retain separate gates.

## PvP weapon state checkpoint

The pvp-weapons focused gate runs eight frozen prior-engine traces (99 full observations) and six
state/ownership groups in approximately one second without Mongo or sockets. Cases cover finite
and sentinel reserve, cadence, active/inactive and paused reload, Ammo Box replay, Empty Mag,
Ammo Thief and absent-slot fallback. Normal execution cannot regenerate golden hashes. The common
trace recorder still matches every original connection trace. See
[PVP_WEAPON_STATE.md](PVP_WEAPON_STATE.md) for source rules, effect order and the latent C29 finding.

Debug and Release builds pass with zero warnings/errors; both focused gates also pass in Release.
checkpoint-3f65ea1ca5f94495ae20fc5ea3645db3 passed all 32 runtime/native stages, including 267,926
battle/admission/SDK/map/UDP assertions in the 635.1-second full battle stage. Native
smoke-1ca9652d97de4a74a9b0969afb1eff74 passed in 40.4 seconds with 74 live integration checks and
reclaimed 210,868,625 bytes. C29's regression first failed against the old capped-grant arithmetic;
its green result does not establish that this currently uncalled helper caused live-player loss.

After retention, managed LOCALAPPDATA storage contains 932,108 bytes/102 files. Historical root
.local remains 80,842 bytes; Server/.local remains 2,835,453,402 bytes. No run, test Backend or Worker
remains active; the pre-existing Mongo service is preserved. S07, measured performance, V07 and
normal Unity/Android gameplay remain separate work.

## PvP player movement checkpoint

The pvp-movement focused gate runs eight frozen original-engine traces with 431 full observations
and eight state/order groups. It takes approximately four seconds here without Mongo, sockets,
Unity projects or Library copies. It covers both directions of the 5-to-6 path on each of five maps,
deferred/repeated frames, source absolute speed and replay, pause/resume, cancellation, private
state and live map binding. The active-route expiry group additionally requires every simulation
tick while the source card is active, then verifies the first restored-speed frame. This preserves
the existing host guard; the fixture never bypasses it to jump through an effect's lifetime.

The baseline was captured twice before simulation edits. Normal tests cannot regenerate hashes;
full snapshot/reply/terminal-event and clock bytes still match. Separate connection and weapon
gates retain their original fixtures. See [PVP_PLAYER_MOVEMENT.md](PVP_PLAYER_MOVEMENT.md) for state
ownership, exact frame/finally order and the remaining S07 boundary. These traces do not alone prove
all 60 map paths, full combat physics or normal Unity gameplay.

Debug/Release builds pass without warnings/errors, and both configurations pass the final eight
movement traces/eight state groups. Final focused checkpoint-5a2bb65b6da644cd9cf249a8a333e265 took
4.2 seconds. Runtime/native checkpoint-608a06966f8b44689fae195ce8da32ea passed all 33 stages,
including 267,800 battle/admission/SDK/map/UDP assertions in the 670.0-second combat stage. Native
smoke-8b4608680810409990faa253136ead81 passed in 36.6 seconds with 74 live integration checks and
reclaimed 210,895,152 bytes. The final test-only active-expiry addition passed separately after the
integrated run; simulation was unchanged during that run, so full combat was not repeated.

Managed LOCALAPPDATA storage now contains 934,794 bytes/104 files after retention. Root .local and
Server/.local retain their previous 80,842-byte and 2,835,453,402-byte sizes. All owned test processes
and runs have ended; only the pre-existing Mongo service remains. No unowned history was deleted.

## PvP player bullet checkpoint

The pvp-player-bullets focused gate runs seven frozen original-engine traces (350 full observations)
and seven ownership/order groups in approximately one second without Mongo, sockets, Unity or
Library copies. It checks real/cosmetic expiry, replay, two-owner volleys, lethal first-hit interruption,
invalid flight geometry, pause/resume, terminal cleanup, insertion-order frame capture, removal before
impact dispatch, deferred new flights, preserved clock exceptions and detached snapshot ordering.

checkpoint-c29a006d9a8443c2ba950bb77df73087 passed the focused gate. Final Debug/Release builds pass
without warnings/errors; both configurations pass the bullet fixtures, and existing connection,
weapon and movement fixtures still match. Normal tests cannot regenerate the frozen expected hashes.
See [PVP_PLAYER_BULLETS.md](PVP_PLAYER_BULLETS.md) for exact advancement/failure order and scope.
The captured frame and step use value types; this structural allocation guard is not a benchmark
or proof of measured throughput improvement. The fixtures use synthetic prototype flight inputs,
so full combat/native integration and actual Unity gameplay retain separate verification gates.

The first integrated checkpoint-5ae39dd42ee840d3a49c103a492a3511 stopped in CombatContentTests
after 274.7 seconds because a controlled-flight fixture still reflected the removed projectiles
dictionary. It now obtains the new private owner and calls its typed AddReal method; the exact
immortal-Drone health/contact assertions remain unchanged. The existing --combat-content-only
selector is now also exposed as the managed combat-content focused case. It passed 29,180 assertions
in 78.7 seconds in checkpoint-25acad5fcf0947388ec9b1d1630f472a before the integrated rerun.

Corrected checkpoint-44e0506a474942f4a49126a5b1f56ae1 passed all 34 runtime/native stages. The
full battle stage reported 267,729 engine/admission/SDK/map/two-peer UDP assertions in 725.7 seconds;
native smoke-b7c2ed6e9c32457b9093861638b9c9a1 passed in 37.2 seconds with 74 live integration checks
and reclaimed 210,867,652 bytes. The production simulation was unchanged between the fixture failure
and the passing rerun. These elapsed times are correctness-run observations, not throughput comparisons.

Managed LOCALAPPDATA storage contains 974,212 bytes/133 files after retention. Historical .local
sizes remain 80,842 bytes at root and 2,835,453,402 bytes under Server. All owned tests/services and
managed runs ended; only the original Mongo service remains. Failure diagnostics are retained within
the existing bounded policy. S07, performance, V07 and actual Unity/Android retain separate gates.

## PvP player bazooka checkpoint

The pvp-bazookas focused gate runs six frozen original-engine source-bound traces (914 observations),
six owner/order groups and three shared-capacity groups in approximately three seconds without
Mongo, sockets, Unity or Library copies. Cases cover source hold/flight behavior, M202 secondary
order and selection lock, cancellation, pause/resume, terminal cleanup, two-owner curves, captured
frame order, launch-tick skip, invalid frame stop and detached snapshot data.

C30's original live-RPG counter regression failed in
checkpoint-e284aa5ab06d46a9a6869768d5aa8bfe. Fixed source RPG/M202 counts and a controlled full-budget
second-player hold/fire refusal pass in checkpoint-11c8c9331aee4107a3202d7dd079cb46. The private
budget is not part of wire hashes, so the deliberate C30 correction is tested independently of the
unchanged snapshot/reply/event/clock fixtures. The capture switch is removed; tests cannot bless hashes.

The separate bazooka-combat focused case runs the existing source catalog/presentation/real UDP
selector with owned logs/temp. checkpoint-704798df66dd4a98947ff030d8fd38e7 passed 218 assertions in
10.6 seconds, including five live UDP checks. Debug and Release builds pass without warnings/errors;
both configurations pass the state/capacity fixtures and all previous connection, weapon, movement
and player-bullet fixtures. See [PVP_PLAYER_BAZOOKAS.md](PVP_PLAYER_BAZOOKAS.md) for exact ownership,
failure/update order and the source/normal-gameplay boundary. S07 and full runtime/native integration
retain separate completion gates.

Final checkpoint-bc43740813374b63b59253dc9c53c071 passed all 35 runtime/native stages, including
267,796 battle/admission/portable-SDK/map/UDP assertions in the 612.0-second full battle stage.
Native smoke-318bc217fcdd4be19abbaf0ab41cf123 passed in 36.2 seconds with 74 live integration checks,
reclaiming 210,867,695 bytes. No comparative throughput or normal Unity gameplay claim follows from
these correctness timings. Managed LOCALAPPDATA storage is 949,377 bytes/134 files after retention;
the historical .local sizes remain unchanged and all owned test processes/runs have ended.

## PvP equipped and bonus grenade checkpoint

The pvp-grenades focused case runs seven frozen original-engine traces (1,075 complete observations)
and eight owner/order groups. Equipped FRAG/M320/Molotov and bonus/card grenades retain distinct
collision/explosion timing and cleanup boundaries. Late shared-setup damage, failed quote preflight,
partial-frame failure and publication-after-ready-launches have explicit checks. The preserved bonus
terminal freeze is a server baseline pending V02 review, not a certified Client rule.

Final focused checkpoint-4778be54a0774f179006935c1cdb6bc9 passes in 3.0 seconds with no Mongo/socket/
Unity dependency. grenade-combat checkpoint-c459607ba06f4f94878a6babd08f2515 passes 49,470 assertions
in 34.3 seconds; grenades-burst-udp checkpoint-b271b93a30854911a32e7c5485ebffcb passes 13 real card
UDP checks in 8.8 seconds; bonus-grenade-policy checkpoint-620a247d8b5a490fb33c29970094c91f passes
74 shared-setup assertions in 2.9 seconds. These focused commands use owned logs/temp and bounded
retention, without copying a Unity Library or starting a database. Only the UDP selectors open sockets.

Debug and Release builds pass with zero warnings/errors. Both configurations pass all new traces/
groups and the previous bazooka, bullet, movement, weapon and connection fixtures. Seven new C# files
pass LF/width/whitespace checks; eight Client/algorithm/content evidence hashes remain unchanged.
See [PVP_PLAYER_GRENADES.md](PVP_PLAYER_GRENADES.md) for capture provenance, exact frame/failure order
and the remaining ownership boundary. S07, V02, performance, V07 and normal Unity/Android remain open.

Final checkpoint-88d706b901d54a98bc50b94fe1dc86ef passed all 36 runtime/native stages. The full battle
stage reported 267,793 assertions in 621.6 seconds. Native
smoke-1c8fe4262fd6406aa6881d3fe6b17382 passed in 36.8 seconds with 74 live integration checks,
reclaiming 210,895,041 bytes after owned shutdown. These are correctness results, not throughput
measurements. Managed LOCALAPPDATA storage is 527,459 bytes/128 files after retention. Historical
root .local and Server/.local remain 80,842 and 2,835,453,402 bytes respectively; no managed run or
test host remains active, and the original Mongo service is preserved.

## PvP army bullet checkpoint

The pvp-army-bullets focused case runs nine frozen original-engine traces (5,625 complete observations)
and eight owner/order groups. Assaulter/Gunslinger real and cosmetic fire, Shotgunner groups, upgraded
Commando metadata, soldier-death flight survival, terminal cleanup and card Grenadier retain their
snapshot/reply/event/clock bytes. Collection/metadata pairing, immutable observations, captured order,
completion, clocks, exception classification, cosmetic collision suppression and isolation have
explicit owner tests. Normal tests cannot regenerate the expected hashes.

The new assaulter-volley, gunslinger-shooting and grenadier-primary focused cases reuse the existing
source selectors without Mongo, sockets or Unity Library copies. Their initial checkpoints pass
112 checks in 5.0 seconds (checkpoint-c0c1d6e271f545c8a9c32df25cf04b59), 29 checks in 4.0 seconds
(checkpoint-02a73ded79324930bf33f5991a1e8817) and 23 checks in 3.9 seconds
(checkpoint-a5754cf863964468a60a87aaa6f7d63b). The final private-entry value-type adjustment was
made afterward to avoid a new wrapper allocation per launch. It passes the nine traces/eight groups
in both Debug and Release, along with all previous grenade/bazooka/bullet/movement/weapon/connection
fixtures. Both solution builds pass with zero warnings/errors.

Superseded checkpoint-0682a3d95985426da33798152683ea7a was intentionally stopped during battle
after its first 35 stages passed, because the entry representation changed. It retains bounded
failure diagnostics and is not counted as a passing integration run or an observed assertion bug.
See [PVP_ARMY_BULLETS.md](PVP_ARMY_BULLETS.md) for exact ownership, failure order and source limits.

Final checkpoint-8ffd2a3818854311b0b51eec1385b9c9 passed all 37 runtime/native stages on the final
value-entry code, including the army state gate in 5.0 seconds. The full battle stage passed
267,862 assertions in 599.7 seconds. Native smoke-0979a6e52a2b4f06bbe33d23c4ec51ae passed 74 live
integration checks in 37.3 seconds and reclaimed 210,864,232 bytes after owned shutdown. Five new C#
files pass style hygiene; five source/algorithm/binding hashes remain unchanged. These elapsed times
do not establish throughput improvement or normal Unity/Android verification.

Root .local is 80,842 bytes. Server/.local is now 2,624,416,528 bytes/34,638 files after older marked
runs were pruned under the existing retention policy, a measured reduction of 211,036,874 bytes.
Managed LOCALAPPDATA storage is 553,013 bytes/186 files, including bounded superseded-run diagnostics.
No managed run or test host remains active; the original Mongo service and unowned history remain.

## Test command argument boundary

War.Battle.Tests rejects unknown selectors, wrong argument counts, case changes and blank Unity
executable/project arguments before the shared/full-suite prelude. Exit code is 2; stdout is empty;
stderr contains exactly one line:

```text
Invalid battle test arguments. Use no arguments for the full suite or a documented selector.
```

No argument value is echoed. Existing focused handlers remain unchanged. Four shared entry shapes
remain supported: no arguments for the full suite, --allocation-inventory-only for its existing
shared prefix, and --unity/--unity-rifle followed by executable and project paths. Path bytes are
preserved; checking nonblank arguments does not verify file existence or execute Unity.

The test-arguments case runs 18 actual child-process refusals with bounded deadlines, exact output/
exit assertions and nonexistent isolated scratch paths. A valid pure selector runs under that same
environment, and four policy checks preserve shared entry shapes without starting their full/Unity
work. The separate allocation-inventory case executes the actual shared prefix, including its
existing socket/HTTP fixture checks. Neither case needs Mongo or a Unity project/Library copy.

The original unknown-case regression failed in checkpoint-71e9ba41df744cc395ad641b29ee5550. Green
checkpoint-be6031f345604819bbb45b1ee6856ffb passes in 4.1 seconds; Debug shared-prefix
checkpoint-d6966ea7d3944ed8ad9128e1dcab7610 passes in 7.3 seconds. Release
arguments-release-6ffc7bbd29ce437e8014c7b3dad2c039 passes both cases in 4.1 and 6.9 seconds.
Both solution builds pass without warnings/errors. Final fast
checkpoint-34c12f3836d74fc6b362e15f97ab0d33 passes all 35 stages with 50.7 seconds of summed stage time.

This change touches the test executable and checkpoint routing only. Full combat/native/Legacy
smoke was not repeated for this entry guard; prior integration results keep their stated scope.
Root .local and Server/.local remain 80,842 and 2,624,416,528 bytes. Managed LOCALAPPDATA storage
is 504,855 bytes/162 files after retention; no managed run remains active. The argument-refusal gate
is included in fast/runtime/source checkpoints; finer storage/physics/performance selectors, remaining
explicit test producers and reusable Unity leases remain T05/T02/T04/T06 work.

## Army flame source-clock correction

The army-flame-clock case runs ten source/host groups without sockets, Mongo or Unity Library copies.
It compiles verified identifier-only copies of recovered FlameAmmo.Fire/Update bodies and compares
their accumulated deadline bits and callbacks with the server. The original regression failed in
checkpoint-213d8d6c25e74353b732aecae9bd3ad1: source frames 11/22/32/43/53/64 versus old server
11/22/33/44/55/66 for the reviewed 30 Hz zero-based input. Offsets, strict boundaries, late frames,
invalid time, isolation, actual deferred player/throttle behavior, box pulse replay and live reconnect
pause/resume have separate checks. army-flame-geometry exposes the existing 29-assertion selector.

Final Debug/Release builds pass without warnings/errors. Release also passes the ten clock groups,
29 geometry assertions and all prior extracted-state traces. checkpoint-a93bb2b4688d4a72bcea0c959226a3ae
passes all 39 runtime/native stages, with the source/host gate in 3.5 seconds and 267,805 full battle
assertions in 607.9 seconds. Native smoke-e91a68772cba46b9ba42424d558a9cb1 passes 74 live checks in
37.9 seconds, reclaiming 210,868,162 bytes after owned shutdown. See
[ARMY_FLAME_CLOCK.md](ARMY_FLAME_CLOCK.md) for receipt/throttle changes, fixture boundaries and C31 scope.

Four new C# files pass style hygiene; all six inspected source/binding hashes remain unchanged.
Root .local and Server/.local remain 80,842 and 2,624,416,528 bytes. Managed LOCALAPPDATA storage
is 473,108 bytes/73 files after retention, with no active managed run or test host. The original Mongo
service is preserved. Broader ownership, flame geometry audit, V07, performance and normal Unity/
Android remain separate; correctness timings are not a performance comparison.

## Army flame original-math interpolation

army-flame-interpolation reads the pinned original 1.4.0 UnityEngine.dll in place and calls managed
Mathf.Lerp in a separate test-only assembly context. It starts no Unity Editor, scene, native physics,
Mongo or socket and makes no project/Library copy. No production project references or copies that
DLL. Eight groups cover clamp endpoints, far-angle and outside-center regressions, 440 scalar/
geometry probes, overlap exclusion, near/edge filtering, collider order and invalid damage.

The original checkpoint-6ed938cacd57438693a0f839564474e4 fails both regressions before production
changes. Green checkpoint-2f088441d0574973a348fc78502a27d5 passes in 0.9 seconds. Final Debug/Release
builds pass without warnings/errors; Release passes all eight groups, ten clock groups, 29 prior
geometry assertions and every existing extracted-state trace. The managed math oracle does not
execute native Unity overlap/angle APIs or certify complete scenes. See
[ARMY_FLAME_INTERPOLATION.md](ARMY_FLAME_INTERPOLATION.md) for exact evidence and scope.

Final checkpoint-6a501ae622a1442f85d75679c4bbec8c passes all 40 runtime/native stages. The interpolation
gate takes 0.8 seconds; full battle passes 267,803 assertions in 623.2 seconds. Native
smoke-95a9a8012b2447f7b5ab5f2c564ef8df passes 74 live checks in 36.7 seconds, reclaiming 210,867,519
bytes after owned shutdown. These are correctness results, not a throughput comparison. Original
binary/source/binding hashes remain unchanged and both new C# files pass style hygiene.

Root .local and Server/.local remain 80,842 and 2,624,416,528 bytes. Managed LOCALAPPDATA storage is
937,345 bytes/118 files after retention. No managed run or test host remains active; original Mongo
and unowned history are preserved. Wider ownership, native geometry, V07, performance and normal
Unity/Android retain their own completion requirements.

## Army flame and poison ownership

After a successful Debug solution build, the managed focused case is:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-army-effects --no-build
```

Nine frozen before/after traces retain 16,238 full observations, including event bytes and exact
clock/progress state. Six flame and six poison groups protect distinct preflight/commit/completion
points, final reservations, captured insertions, discard, invalid clocks/construction, detached
observations and match isolation. checkpoint-dbebbe3a3b03431ea3f8b25847602c6a passes in 5.4 seconds.
The case is included in fast/runtime checkpoints. It creates no Unity project or Library copy.

Final Debug/Release builds pass without warnings/errors. Release managed run
army-effects-release-baf777579bdb484a9a8c03c64282d9d7 passes all nine traces and twelve owner groups,
the C31/C32/geometry gates and every earlier extracted-state trace. Its reports and disposable files
use the same external managed root and retention policy. See [PVP_ARMY_EFFECTS.md](PVP_ARMY_EFFECTS.md)
for source clocks, update order and terminal poison retention's unproven Client-policy boundary.
These results establish no throughput comparison or normal Unity/Android gameplay certification.

Final checkpoint-f3efee39a592439aa6e0a29c7e6ab030 passes all 41 runtime/native stages. The new effect
gate takes 5.5 seconds; full battle passes 267,855 assertions in 666.0 seconds. Native
smoke-9e4182e9074d4a6983e63654617582fc passes 74 live integration checks in 37.6 seconds and reclaims
210,866,502 bytes after owned shutdown. The full combat suite was run once on the final code.
Root .local remains 80,842 bytes/4 files; Server/.local remains 2,624,416,528 bytes/34,638 files.
External managed storage contains 937,571 bytes/129 files after retention, with no running manifest
or test Backend/Worker/battle process. Original mongod PID 6164 and unowned historical evidence remain
preserved. All six inspected original model/Client/binding hashes still match. Wider S07 ownership,
V02/native geometry, V07, measured performance and actual gameplay retain separate completion gates.

## Rocket Soldier and Mortar flight ownership

After a successful Debug solution build, use this managed focused case while changing missile state:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-army-missiles --no-build
```

Ten frozen traces retain 10,789 observations, including full snapshot/reply/event bytes, clock bits,
frozen launch queries and impact diagnostics. Real/fake Rocket and Mortar, source soldier death,
terminal cleanup, reconnect pause and BIGROCKET card paths are covered. Eight owner/order groups
exercise atomic pairing, sorted projections, callback order, capture, clock/collision exceptions,
fake completion, negative Mortar progress, diagnostic lifetime and cleared terminal captures.
The test reads existing content in memory with no Mongo service, Unity Editor, project/Library copy
or production dependency. The same case is included in fast/runtime checkpoints.

checkpoint-8aa0d2b200ab4935931a625f6c1ff87f passes the focused case in 7.4 seconds. Final Debug/Release
builds pass without warnings/errors. Release managed run
army-missiles-release-6eacc0f237534d629c987c3ccfb58d94 passes all twelve selected cases, including the
new ten traces/eight owner groups, prior ownership traces and flame clock/interpolation/geometry gates.
Seven new C# files pass LF/width/method-size checks; seven original flight/explosion/source/binding
hashes remain unchanged. See [PVP_ARMY_MISSILES.md](PVP_ARMY_MISSILES.md) for retained lifecycle
boundaries and the separate C33 expiry/collision source discrepancy. These tests do not certify
native Unity physics, normal gameplay or production throughput.

Final checkpoint-4a067ac89aa8419e851f690e91880b51 passes all 42 runtime/native stages. The new missile
gate takes 7.0 seconds; full battle passes 267,866 assertions in 641.0 seconds. Native
smoke-561d07398184482598dce9346aa2ba37 passes 74 live integration checks in 36.7 seconds and reclaims
210,895,163 bytes after owned shutdown. Full combat was run once on the integrated ownership change.
Root .local remains 80,842 bytes/4 files and Server/.local 2,624,416,528 bytes/34,638 files.
External retained managed evidence is 938,506 bytes/132 files after retention. No managed run or test
Backend/Worker/battle process remains active; original mongod PID 6164 and unowned history are
preserved. These are correctness timings, not a performance comparison. C33 and wider S07/V02/V07,
performance and actual Unity/Android retain separate completion gates.

## Straight army missile expiry priority

army-missile-expiry pins the recovered Missile.cs source and checks the reviewed Fire/AnimateShot/
Update/TryKill expression order. A small managed reference models straight progress, expiry and
collision eligibility at thirty Hz with synthetic rays. It does not execute original Unity Update
or native physics. Eight groups cover real/fake and negative-progress Mortar expiry, exact progress
three, earlier collisions/arming, forbidden expired callbacks, invalid authority, fifty differential
scenarios and paired-owner completion. The test needs no Mongo, Editor, project/Library copy or DLL.

Before production changes, checkpoint-ab6a957927a4479ab66f15eb60f55b67 fails six groups. Green
checkpoint-35bc328753db495c98896b91e9aaee8a passes all eight in 0.8 seconds. Existing ten frozen army
missile traces/eight owner groups still match without regenerating their expected hashes.
From the repository root after a successful Debug solution build:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-missile-expiry --no-build
```

The new case runs in fast/runtime checkpoints. Final Debug/Release builds pass without warnings or
errors. Both new C# files pass LF/width/whitespace checks with ordinary methods at most 36 lines.
The two Client sources, source binding and paired-owner hashes remain unchanged. Reversing only the
moved expiry block/comment exactly reconstructs the pre-fix model hash. Historical red diagnostics
and provenance are retained under the existing bounded policy. See
[ARMY_MISSILE_EXPIRY.md](ARMY_MISSILE_EXPIRY.md) for scope and final integrated results. These are
correctness tests, not measured throughput or normal Unity/Android gameplay certification.

Release managed run missile-expiry-release-f6951266e29e453a89db905f3d67120b passes all thirteen
selected cases: the new expiry groups, all earlier frozen ownership traces and flame clock/
interpolation/geometry gates. The matching Debug/Release builds both have zero warnings/errors.

Final checkpoint-cadb083878da4be6850b529aeecc50e0 passes all 43 runtime/native stages. Expiry takes
0.9 seconds; full battle passes 267,867 assertions in 627.0 seconds. Native
smoke-3a013c82c97146c9a80c310abf247854 passes 74 live checks in 36.6 seconds and reclaims 210,867,748
bytes after owned shutdown. Full combat was run once on the integrated change.
Root .local remains 80,842 bytes/4 files and Server/.local 2,624,416,528 bytes/34,638 files. External
managed evidence contains 939,980 bytes/135 files after retention, including bounded red diagnostics.
No managed run or test host remains active; original mongod PID 6164 and unowned history are preserved.
C33 is complete at straight expiry priority. Broader V02/V07, performance, ownership, remaining test
producers/Unity leases and normal Unity/Android retain their own completion requirements.

## Managed Client boot storage

`ClientBootSmoke.ps1` now allocates a `client-boot` run through `TestRun.ps1`. Mongo files and
TEMP/TMP/TMPDIR live under owned `data`; logs and validated reports remain at the run root.
After owned processes stop, successful data is reclaimed and failed data retained under normal
retention. `-KeepArtifacts` preserves successful data when explicitly needed. Environment restoration
uses the shared absence-preserving helper. Mongo paths are quoted for external roots containing spaces.

The Unity project still must be disposable under `Server/.local`; it is not copied or deleted by
this script. Managed output can use `WAR_TEST_RUN_ROOT` outside the repository. Starter export uses
a unique scratch filename inside that disposable project to preserve the Editor exporter's existing
path guard, then copies validated JSON into the managed run and removes that scratch file. A failed
export may leave its uniquely named scratch diagnostic in the disposable project.

`TestClientBootStorage.ps1` injects a build failure before any Unity/Mongo launch. On both PowerShell
5 and 7 it verifies owned failed status, retained diagnostic storage, paths with spaces and restored
temporary/export environment. Its own successful parent run reclaims the tiny fixture project.
The 21 shared artifact lifecycle tests also pass. This is failure-path/storage proof, not a new
normal Client bootstrap or full native Mongo/Unity result.

```powershell
pwsh -NoProfile -File Server/scripts/TestClientBootStorage.ps1
python Server/scripts/test_test_artifacts.py
```

## Known source audit failure

Full candidate combat loading can be diagnosed without changing deployed files:

```powershell
python Server/tools/audit_combat_candidate.py --stage <completed-sheet-stage> --assembly Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll
```

The managed run copies production content and overlays hash-verified candidates. It records both
inventories and invokes `--combat-candidate-path` with a 120-second deadline. Success removes data;
failure retains the loader log and diagnostic overlay. These mixed overlays are never release
packages. `test_combat_candidate_audit.py` covers exact inventory and tamper rejection.

All-weapon identity recapture uses the existing Client exporter in an owned source-only copy:

```powershell
python Server/tools/recapture_weapon_bindings.py --unity "C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe"
python Server/tools/test_weapon_recapture.py
```

The runner retains the source inventory, raw native output, hashes and logs. It does not copy the
imported Library; only package source dependencies are reused. Success requires all 66 exported
bindings to match existing values except the exact scene hash, and every inventoried source file
to remain unchanged. Successful temporary projects are removed; failed projects retain diagnostics.
The Editor deadline is 600 seconds. This is identity evidence, not original Unity 5.2 gameplay proof.

Pass a completed capture with `stage_battle_sheet_content.py --weapon-run <run-directory>`.
A later completed sheet stage retaining `weaponEvidence` can be used instead. Both paths repeat
source inventory and native field comparisons, verify output hashes, and retain the native output,
inventory and report. Run `python Server/tools/test_weapon_evidence.py` for the five binding guards.

`recapture_weapon_families.py --unity <editor>` runs the all-weapon and nine family exporters in one owned import.
Only disposable exporter copies have their expected success-exit calls removed; the runner records
before/after hashes and retains its batch wrapper. Original Client files remain unchanged. Each
family output is compared independently against production, allowing only scene provenance to
change. Unexpected fields or values fail the capture and retain diagnostics. This avoids nine
separate project imports but is not a measured gameplay performance improvement.
Run `python Server/tools/test_weapon_family_recapture.py` for batching and comparison guards.
Minigun is explicitly composed from the native family output and same-run all-weapon identities.
Every shared field must match; only setup/component type metadata is added. Raw pose diagnostics
remain in the native file, while `composed-minigun-binding.json` preserves the runtime package schema.
Run `python Server/tools/test_minigun_composition.py` for the five composition guards.
Use `stage_battle_sheet_content.py --weapon-family-run <completed-run>` to include all nine family
packages. Later sheet stages may supply their retained family evidence instead. Both paths recheck
source inventories, exporter preparation hashes, raw output hashes, exact values and reconstructed
Minigun composition. `test_weapon_family_evidence.py` covers five integrity boundaries.

Family staging also builds seven simple weapon manifests. Grenade and the full combat manifest need
additional staged dependencies. Verify the seven packages with their actual production loaders:

```powershell
python Server/tools/test_weapon_manifests.py
dotnet build Server/tests/War.Battle.Tests/War.Battle.Tests.csproj -c Release --no-restore
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --weapon-candidate-path <candidate-directory>
```

With `--pose-run <completed-capture-or-retained-stage>`, staging includes both pose documents and
the grenade manifest. The candidate loader command now requires and checks all eight weapon
packages, including Grenade. This validates manifest hashes, schema and catalog loading, not complete combat.
Run `test_pose_evidence.py` for four evidence integrity guards; the manifest suite now has five tests.

`recapture_pose_content.py --unity <editor>` samples grenade and player poses with the existing
Client Editor exporters in one disposable import. The shared `prepare_editor_batch.py` owns the
recorded success-exit substitutions used by pose and weapon batches. Every sampled field must match
the previous artifact except scene provenance; differences retain raw outputs and the owned project
for review. Run `python Server/tools/test_pose_recapture.py` for strict pose comparison checks.

Boss defend-path evidence can be recaptured without a full Client copy:

```powershell
python Server/tools/capture_boss_paths.py --unity "C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe"
python -m unittest discover -s Server/tools -p test_boss_path_candidates.py
```

Use `WAR_TEST_RUN_ROOT` to select the external managed root. The native runner copies five NavMesh
assets and metadata (under one MB), creates its own small Unity project, retains evidence and removes
the project on success. A failed capture retains owned diagnostics. It has a 180-second Editor
deadline and terminates only its owned process tree. This does not certify normal Client movement.

Pass that completed run to `stage_battle_sheet_content.py --boss-path-run <run-directory>` together
with the native battle evidence and current starter observation. Later stages may pass a completed
sheet stage retaining boss evidence instead; all input/source/output checks run again. The six
binding regression tests are `python -m unittest discover -s Server/tools -p test_boss_path_evidence.py`.

The focused `content-precision` case (`--content-precision-only`) reads the reviewed sheet audit and
checks all 386 corrected numeric inputs against real vehicle/air vitality owners at synthetic death
thresholds. It demonstrates why tiny changes cannot be ignored with a tolerance. It is not a full
replay of unit-specific attacks, modifiers or normal gameplay. The Release case passes; it creates
no Unity project, database or additional content tree.

The full source checkpoint currently stops at the mission-catalog comparison. The Git HEAD and
working MainScene both hash to
`5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`, while the stored mission
catalog records `d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
Re-extracted mission rules, mission map records and boss map records match the stored records;
the MainScene provenance digest differs. The separate card-source identity audit also rejects
its stored MainScene hash. The S04 source audit likewise rejects score-streak and PvP bonus bindings
against that differing scene. This predates the folder moves: no Client scene or content artifact
was modified by this increment. Reconcile the source provenance and dependent artifacts explicitly;
do not replace digests simply to turn the checks green.

## Grenade target native evidence

Run `python Server/tools/recapture_grenade_targets.py --unity <Unity.exe>` with `WAR_TEST_RUN_ROOT`
pointing to the external managed run root. The runner uses one owned source copy, retains the exporter,
source inventory, native output and result hashes, and removes temporary imported data on success.
It uses the shared 600-second Editor deadline and never publishes production content.

Pass the completed run through `stage_battle_sheet_content.py --grenade-target-run <run>` alongside
the existing content, weapon, family, pose and boss evidence arguments. A later completed sheet stage
can supply the same argument: all retained source/exporter/value checks are repeated.
Run `python -m unittest discover -s Server/tools -p test_grenade_target_evidence.py` for its five
integrity guards. The C# `--weapon-candidate-path` entry now also checks the grenade target production
loader, exact admitted revision, wrong-scene rejection and changed sampled-position rejection.
A complete candidate must include `recovered-grenade-shot-targets.json` for that focused check.

Score-streak source transition checks:

```powershell
python Server/tools/audit_score_streak_provenance.py
python -m unittest discover -s Server/tools -p test_score_streak_provenance.py
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --pvp-score-state-only
```

The audit requires repository history for the pinned baselines; it validates source equivalence for
local streak arithmetic and crate eligibility, not networked gameplay. Candidate package checks also
reject mixed code-source snapshots, altered thresholds and mismatched scene/content revisions.

The diagnostic combat runner also creates `source-closure.json`, listing affected source artifacts
absent from the candidate. Its successful exit proves production-loader acceptance of the overlay,
not a self-contained release: `releaseVerified` remains false even when no loader throws. Inspect
`unstagedAffectedArtifacts` before promotion. The skill-shot regression entry is `--pvp-scores-only`;
it includes malformed input rejection as well as score behavior.

Co-op navigation reference staging is part of `stage_mission_content.py` and the combined sheet stage.
`stage_coop_navigation_references.py --navigation <candidate-navigation.json>` prints a read-only
preview. Reuse is allowed only while all reviewed native inputs and observations remain unchanged.
Run `python -m unittest discover -s Server/tools -p test_mission_content_candidates.py` for the 32
candidate checks, including geometry/order/mesh mutation rejection. The PvP diagnostic loader does
not validate co-op navigation runtime admission; keep that verification boundary separate.

When both `--weapon-run` and `--starter-observation` are supplied, combined staging also creates
`recovered-player-weapon-indexes.json` against the exact candidate all-weapon graph. The five checks
in `test_weapon_index_candidates.py` cover complete mapping preservation and mutation rejection.
The C# `--weapon-candidate-path` entry verifies candidate binding hashes and all Backend index
translations. This does not replace the Backend embedded-resource publication gate.

## Co-op navigation candidate loading

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --coop-navigation-candidate-path Server/content
python Server/tools/audit_combat_candidate.py --stage <completed-stage> --assembly <War.Battle.Tests.dll> --scope coop-navigation
```

The second command uses the managed diagnostic overlay and records `loaderScope`. It loads mission,
spawn, NavMesh source, paths and triangles and builds connectivity. It also rejects changed mesh
metadata/bytes, dependency hashes and unreviewed current mission rewards. This does not instantiate
all co-op runtime catalogs, run a match or certify Client movement. Default `--scope combat` retains
the separate PvP combat-package diagnostic. Both keep `releaseVerified` false and report missing
candidate source dependencies.

## Player reference candidate loading

```powershell
python Server/tools/recapture_player_references.py --unity <editor>
python -m unittest discover -s Server/tools -p test_player_reference*.py
python -m unittest discover -s Server/tools -p test_rig_reference_extension.py
python Server/tools/audit_combat_candidate.py --stage <completed-stage> --assembly <War.Battle.Tests.dll> --scope player-reference
```

The capture shares one disposable import across collision, rig-blend and walking-shot exporters.
Its completed evidence enters combined staging through `--player-reference-run <completed-run>`.
Failed captures remain diagnostic evidence and cannot be bound. Original Client files are inventoried
and checked after extraction; successful temporary project data is removed by the managed lifecycle.

Rig-blend admission preserves the legacy exact comparison and adds one reviewed 144-node snapshot.
The added head-target nodes must match the player pose hierarchy; all previous parent relationships
and 12 cases must remain equal. A fingerprint of the entire extended snapshot, excluding only scene
provenance validated separately, also pins the new transforms. Unknown extensions require review.
The eight synthetic regression cases validate rejection boundaries, not Unity equivalence.

The C# scope runs collision, walking-shot and rig blend/composition comparisons, including every
added node. It disables optional walking-shot render-fixture output and restores the environment.
This is native-reference calculation evidence, not two-Client gameplay or original Unity 5.2 parity.

## Grenade rig and player blast reference loading

```powershell
python Server/tools/recapture_blast_references.py --unity <editor> --weapon-run <completed-stage>
python -m unittest discover -s Server/tools -p test_blast_reference*.py
python Server/tools/audit_combat_candidate.py --stage <completed-stage> --assembly <War.Battle.Tests.dll> --scope blast-reference
```

The capture validates retained native weapon evidence before copying the Client. It records the
exact binding bytes and runs grenade-rig and player-explosion exporters in one disposable import.
The rig exporter accepts the managed run's exact project/output paths; its original `.local` mode
remains available for historical tools. Neither mode writes the active Client project.

Combined staging accepts `--blast-reference-run <completed-run>` only alongside `--weapon-run`.
The binder rechecks the original source inventory, exact prepared exporters, native output hashes,
complete sampled values and equality to the stage's weapon dependency. Successful temporary project
data is removed. Failed native output stays diagnostic and cannot be promoted as passing evidence.

The C# diagnostic runs grenade pose projection and native player-overlap comparisons. The current
runtime still reads its pinned embedded grenade rig: matching calculations prove value compatibility,
not that the runtime consumes the candidate rig file. Coordinated embedded/resource or manifest
publication and runtime identity checks remain separate requirements before release.
