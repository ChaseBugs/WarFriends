# Recovered Client lobby bootstrap boundary

The active 1.4.0 Client is recovered, but recovery is not proof that its normal
login/menu/battle bootstrap works with the replacement services. This checkpoint
addresses one real prerequisite of that path, not a completed lobby migration.

## Shared self-hosted Backend address

Before this checkpoint, `BeanstalkUrlCreator.CreateUrl` still returned the retired
AWS production address while the battle SDK used loopback. Normal account and
configuration requests therefore could not prepare the same server state as the
replacement battle transport.

`SelfHostedBackendEndpoint` now owns the common default
`http://127.0.0.1:8080/`. Set `WARFRIENDS_BACKEND_URL` before starting Unity to
select a different self-hosted Backend directory. The process value is captured
once on first use. An unset or empty override selects the default; a nonempty
malformed override fails rather than choosing a retired server.

The URL must be absolute, end in a directory slash, and contain no credentials,
query or fragment. The existing SDK transport policy is preserved: HTTPS, or
HTTP on loopback for local development. Physical Android testing can use
`adb reverse tcp:8080 tcp:8080` with the loopback default. A deployment path prefix
requires its own reverse-proxy routing; the native Backend routes below are at
its root by default.

Normal recovered-session matchmaking and rematch use this common address.
Explicit SDK admission/test APIs can still take a configured endpoint when no
process override exists. A process override takes priority there too. The
adapter retains the resolved match endpoint for reconnect rather than reverting
to its serialized default. Existing serialized fields and script GUIDs remain.

The legacy URL builder now returns `index_09_25_2015.php` relative to that common
root. Its sibling connectivity URL remains `check.php`; `requestId`, POST fields,
configuration parsing and callback order are unchanged. This is the active
1.4.0 contract, not the older `/api/<action>/<version>` transport. The Production
storage-environment identity remains unchanged so saved login records do not
silently move to another local bucket. Social app-link metadata is unchanged.

## Evidence

`--client-endpoint-only` links the exact active Unity resolver into native tests.
Isolated child processes check the local default, configured SDK directory,
process override, immutable routing, legacy filename/path prefix and rejection
of malformed or unsupported transport settings.

`UnityBackendEndpointAudit` uses the actual recovered `BeanstalkUrlCreator` and
BestHTTP library against the owned native Backend. It requires the exact POST
`check.php` response `ok` before the existing real HTTP/UDP rematch scenario.
The scenario uses the same process override for the battle SDK, and its native
coordinator requires `UNITY_BACKEND_ENDPOINT_PASSED` as well as the existing
rematch/cancellation/ownership markers. This is transport integration evidence,
not a normal menu or account bootstrap proof.
The native transport run passed in
`Server/.local/queue-live-5c276048971f441cad8794d8dcdfa092/UnitySameOpponentRematch.log`.
The installed source also passed the disposable Unity 2018.3.0f2 compilation
gate. Static asset checks retain zero missing scripts/broken references and the
same seventeen existing NGUI atlas mismatches.

## Actual startup observations

`UnityNormalClientBootAudit` now runs the original SplashScene in Play Mode and
observes its transition to MainScene. It uses a disposable project under
`Server/.local`, a unique Unity company/product storage identity, and bounded
exception samples containing source frames rather than account/session values.
It does not replace managers, profiles, scenes or player data with test doubles.

The baseline reached the startup account-request path but threw
`DllNotFoundException: sqlite3` through `AwsEvents` and
`EventTrackingManager.Start`. The retired analytics manager was constructing an
AWS delivery client during application startup. The active EventTrackingManager
now omits AWS construction, event delivery and focus/session delivery. Its public
purchase callback remains a documented compatibility sink; local gameplay
statistics and existing non-AWS paths are unchanged. Dependency DLLs and asset
identities are preserved.

The subsequent unavailable-Backend observation reached MainScene with its main
player and PlayerNetworkStatus assigned and zero observed runtime exceptions:
`Server/.local/unity-normal-boot-offline-analytics.log`. This observation still
recorded 45 error-level logs and did not verify account loading, rendering or
retired-service-independent complete boot. The first baseline's MainScene test
filtered scene-owned controllers and missed persistent controllers; the current
probe uses the actual loaded scene name and includes persistent scene objects.
The AWS exception and its source stack remain valid baseline evidence.

`Server/scripts/ClientBootSmoke.ps1` now starts an isolated native Mongo replica
set and real Backend, then runs that same original Client startup. Its stricter
gate requires actual account data, initialized unit rows and player network
state. Its original failing boundary is preserved at:
`Server/.local/client-boot-ec87754fc1af4932a7bcbb94834a4ac9/report.json` records
MainScene loaded, account data received, main player/network state assigned,
zero unit rows and one `PlayerInventory.Init` index exception. The call comes
from `LevelManager.OnPlayerDataLoaded` after the real HTTP response, not from an
injected profile or a fabricated game-state message.

The failing active and disposable MainScene files had identical SHA-256
`d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
Its LevelManager component, file ID `45847`, refers to script GUID
`780c78d4af376959b095359d8460246f` but contained no serialized weapon/unit list
payload. Runtime `PlayerInventory.Init` could not choose an inventory weapon
from the empty list and indexed `-1`.

## Original LevelManager binding repair

`restore_level_manager_bindings.py` now reads the actual OBB `level0` component
45847 with metadata from the APK's original managed assemblies. It verifies the
matching OBB digest, byte-identical reference DLLs, Unity 5.2.5f1 version,
LevelManager type/owner, complete 1,176-byte payload consumption, and every
original Mono header field. Unity 5's enabled-byte alignment comes from the
same file's native MonoBehaviour schema before the script PPtr is decoded.

The original payload contains **66 weapons, 24 player units and 3 additional
units**. All 93 pointers resolve to the existing active component IDs and the
same script classes. The tool preserves exact pointer order, existing headers,
script GUIDs and object IDs; it refuses conflicting custom payloads. No names,
indices, prices, progression values or inventory entries are invented. A repeat
dry run reports no changes.

Only that component's missing custom payload is appended to MainScene. The
active scene hash becomes
`5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.
[The binding evidence](level-manager-bindings.json) records the original package,
assembly and raw component hashes, all ordered fields, and before/after export
hashes. Existing combat/economy artifacts retain their immutable pre-binding
export provenance; their balance data and geometry did not change.

After this repair, original Splash/MainScene startup against a fresh real
Backend passed in
`Server/.local/client-boot-58366426cd8d465aaa66caf2a9d20a20/report.json`.
It records real account data, 24 initialized/sorted unit rows, 66
initialized/sorted weapon rows, player network state, completed
`loadingPlayerData` callbacks and **zero observed runtime exceptions**. The
strengthened gate waits for those callbacks and sorted lists, then observes
twelve more real frames. It also records 72 error-level logs, which remain
separate from the exception counter and need further classification. This is
account/catalog initialization evidence, not complete rendered lobby or battle
verification.

Static reference checks now count 288,258 nonzero references, including the 93
restored pointers, with zero missing scripts/broken references. The same seventeen
pre-existing NGUI atlas selections remain unmatched.

Reproduce the binding check with `python Server/tools/restore_level_manager_bindings.py`;
add `--apply` only to restore a missing payload from the verified source.

Run the account/unit initialization gate with a refreshed disposable Client copy:

```powershell
./Server/scripts/ClientBootSmoke.ps1 `
  -UnityExecutable 'C:\Program Files\Unity\Hub\Editor\2018.3.0f2\Editor\Unity.exe' `
  -UnityProject 'Server/.local/<disposable-client-copy>' `
  -MongoExecutable 'C:\Program Files\MongoDB\Server\8.3\bin\mongod.exe'
```

The script installs its Editor probe, rejects projects outside `Server/.local`,
preserves the caller's environment, and stops only owned processes. It does not
refresh the runtime/assets in that copy. Supply a copy containing the restored
MainScene payload and current runtime before running it.

## Remaining normal-flow work

Continue from the real account/unit gate by verifying selected cards, player
prefab inventory and preview-camera readiness. Do not replace these dependencies
with invented player profiles or menu stubs to obtain a passing battle test.

`GameControllerOnline.InitializeSelfHostedPlayers` currently publishes
`mBothPlayersConnected` and other controller/player fields before all profile,
weapon, preview and presentation initialization finishes. A later failure can
leave a partially initialized lobby that rejects retry as already connected.
Observe and repair that boundary against the real normal bootstrap, including
failure cleanup, before declaring player initialization complete.

Successful real lobby entry, normal friend/Coop rematch, complete screen cancel
and reset races, two Unity players, original Unity 5.2/Android compatibility and
retired-service-independent full application boot remain unverified. SDK and
empty-scene Editor passes do not close these requirements.

## Empty-table and Buddy initialization checks

The next actual boot isolated two invalid queries without changing game data:
`GameConfigurationManager.Awake` requested column names from the legitimate empty
`Google2u.Squads` table, and offline card loading looked up the separate `BUDDY`
template in ordinary `CardDefinitions`.

`Google2uComponentBase` now discovers empty-table metadata from its declared row
type and includes only generated `Get_` column properties. Structural `Length`
and `Item` properties are not columns. Missing row value access still fails;
no placeholder row or squad progression is invented. Buddy templates retain
their separate initialization and bypass ordinary card-definition lookup.

`Server/tools/UnityEmptySheetSchemaAudit.cs`, installed only in the disposable
project's `Assets/Editor`, passed with Unity 2018.3.0f2. It checks the exact five
Squads columns, absent/structural column rejection, unchanged empty row count,
intentional absent-value rejection, and populated-table value access. Its one
intentional missing-row error is negative-test evidence, not a startup error.

A refreshed real Backend/Mongo/Splash-to-MainScene run passed at
`Server/.local/client-boot-74f53bbb6792486186d5f172e795aadb/report.json`.
It records complete account callbacks, 24 initialized units, 66 initialized
weapons, ordinary and offline card definitions ready, zero invalid bootstrap
queries and zero exceptions. Error-level logs decreased from 72 to 70. Their
bounded stack-source counts are 33 KinematicRagdoll, 11 NetworkObjectPool,
11 ArmyPreviewCamera.PlayerDataLoaded, 11 preview texture coroutines, and one
each from account-response diagnostics, Fuse configuration, WarningDialog and
ServerResultsCache. These remaining logs are not treated as successful rendering
or harmless errors without inspection. Reports retain source locations rather
than raw account response messages.

The smoke gate now requires card definitions and rejects either invalid query.
The solution builds with no warnings/errors and the protocol executable passes.
This remains disposable Unity 2018 account/catalog proof, not original Unity 5.2,
Android, rendered lobby, two-player or normal battle-entry verification.

Normal matchmaking also remains blocked for a newly created account until a
server-authoritative battle allocation is projected from durable client-shaped
inventory/progression. `Program.cs` currently rejects absent allocation with
`battle_allocation_missing`; native transport fixtures supplying allocation do
not prove that normal account path. Implement this alongside the existing
player-initialization failure/rollback boundary, preserving card ownership and
upgrade authority rather than granting a test loadout.
### Fresh-account durable projection prerequisite

The current `LegacyEndpoints.PlayerData` projection deliberately omits absent
subsystem keys so the recovered Client takes `LoadEmpty()`. New guest account
creation now supplies source-derived `InventoryData`, `LevelManagerData` and
`DecalManagerData` in the original account insert. A Mongo change-stream observer
verified all three during actual Unity account boot; resulting Client defaults
are unchanged. Existing accounts are not backfilled. In contrast,
`BattlePlayerPresentationSource.ReadRequired` requires those stored blobs.
Creating an empty battle allocation alone cannot make a fresh account
admissible. The normal-account path needs source-backed, server-authored
matching battle projection and derived ownership; it
must not accept a Client-generated starter inventory as proof of ownership.

Materialization must preserve derived starter ownership. `PlayerInventory.Init`
chooses each missing slot's compatible weapon with the lowest unlock index
in the restored source order. `WeaponLevelsSetup.bought` accepts source shop
weapons with unlock index zero and zero ordinary/Gold prices even when the
saved `bought` flag is false. `UpgradeSlots.GetArmySlot` also starts a missing
record with `bought=false` and the source start tier. The current battle
weapon and unit projections now evaluate reviewed source free/tutorial/rank
rules without marking defaults purchased. Borrowed units remain available
independently of the equipped flag, as UpgradeSlots.canUseInBattle requires.
Unit special/Elite lanes use source offsets only when active; inactive lanes
use the wire sentinel -1. Corrupt stages fail rather than being clamped.

### Verified weapon index conversion

The [starter observation and index bridge](CLIENT_STARTER_LOADOUT.md) now
records the real initial slot choices and all 66 weapon identity pairs.
The Backend projects stored LevelManager indexes into battle allWeapons
indexes; PlayerProperties converts those authenticated views back into
local LevelManager indexes. Actual Unity mapping checks, native identity
checks and Mongo-backed live queue/rematch gates pass. The full source starter
presentation now passes native checks. Automatic allocation is still required before a
fresh normal account can enter matchmaking automatically.

### Insert-only allocation preparation

The working-tree `BattleAllocationStore.CreateIfMissing` validates the projection, uses only
Mongo `$setOnInsert` fields and rereads through the shared allocation validator. Existing
inventory and revisions are not replaced by initialization; malformed existing rows are not
reset into new authority. The account projection Mongo test now repeats initialization with
an empty card projection and checks that existing quantities remain intact.

The isolated build at `Server/.local/allocation-create-build.log` passes with zero warnings
and errors. The first isolated Mongo run did not reach the tests: replica-set initialization
exceeded the existing thirty-second startup deadline. Its local `allocation-create-mongo-*`
directory retains Mongo evidence; the owned Mongo process was stopped by finally cleanup.
No Mongo test success or normal matchmaking completion is claimed. The queue route is
unchanged pending durable account/allocation consistency and concurrent initialization proof.

The subsequent complete `--allocation-inventory-mongo` run passes with exit zero at
`Server/.local/allocation-create-mongo-33050281ea0b4b488e65b3f92db226ee/tests.log`.
It covers account projection, repeated concurrent initialization preserving card quantities and
revision one, rejection of damaged existing quantities, full-catalog quantity round trips and
competing card-pack buffer conservation. The replica bootstrap test deadline is now 120 seconds
to accommodate first storage checkpoints on the development disk; production timeouts are unchanged.
The owned Mongo process was stopped after the tests. First-creation races and atomic account
revision binding still require coverage before normal matchmaking is connected to this primitive.

First creation now runs eight concurrent initializer calls against an absent allocation. The
complete inventory Mongo suite passes with exit zero at the same directory's
`race-ready-tests.log`; initial ownership, retry preservation, revision one and damaged-row
rejection remain checked. Duplicate-key races are handled only by rereading and validating the
winner, never by replacing it. This does not bind allocation to a durable account revision.

The preceding `race-tests.log` run failed before tests because Mongo was not ready. The test
bootstrap helper now accepts an already initialized replica, waits for writable Primary and
verifies the requested replica-set name. Its readiness proof is separate from allocation tests;
production server selection limits are unchanged. The owned Mongo process was stopped after
the successful run, and the final build has zero warnings and errors.

### Account-revision preparation transaction

`BattleAllocationPreparationStore.PrepareAsync` now reads the account and initial allocation
inside one snapshot/majority transaction. It requires a trusted expected account revision,
projects from that transaction's account document and reserves the revision with a real write
before inserting absent allocation authority. Concurrent account writes therefore conflict with
the transaction rather than allowing an old read to publish silently. Existing validated
allocations are preserved; initial preparation does not refresh or replenish battle inventory.
The supplied projection must be pure because Mongo may retry the transaction callback.

The native Mongo suite passes at the existing evidence directory's `prepare-tests.log`, exit
zero. It rejects a stale revision without creating an allocation, verifies creation alongside
one account revision advance and checks replay without another revision advance. Existing
quantity/corruption and card-pack concurrency checks also pass. Build evidence is
`Server/.local/allocation-prepare-build.log`, zero warnings/errors. This is not yet registered
in queue admission. Concurrent preparation/account mutation and coherent manifest publication
still need executable scenarios before the normal route is enabled.

The forced account-mutation scenario now passes in the full inventory Mongo suite at
`account-race-tests.log` in that evidence directory, exit zero. The test pauses the pure
projection after reading two owned cards, commits an empty card inventory through the normal
account store, and releases preparation. The transaction rejects the old revision without an
allocation or an additional account revision. A fresh preparation then publishes zero cards.
This exercises an actual Mongo write conflict/retry boundary, not a sequential stale-read check.
Build evidence is `Server/.local/allocation-account-race-build.log`, zero warnings/errors.
Queue wiring and coherent paired manifest publication remain open.

### Normal queue preparation wiring

The current queue join route now prepares an absent allocation through the account-revision
transaction instead of returning `battle_allocation_missing`. It validates the exact durable
presentation against the configured manifest catalog inside the projection callback before
writing. Unknown accounts, unsupported equipment and stale account revisions fail before
queue admission. Existing allocations retain the previous validation/preservation path.

`BackendQueueLiveTests` no longer seeds allocations directly. Its first real HTTP queue join
must create allocation authority without inventing card or unit ownership. The fixture still
provisions authenticated legacy accounts with a reviewed rifle loadout; it is not a new guest
account or normal two-Unity-scene proof. Release build evidence is
`Server/.local/normal-allocation-queue-build.log`, zero warnings/errors. Coherent paired
manifest reads remain a separate required boundary.

The real Backend/Worker/Mongo `--queue-live` run passes with exit zero at
`Server/.local/allocation-create-mongo-33050281ea0b4b488e65b3f92db226ee/normal-queue-tests.log`.
Runtime artifacts are in `Server/.local/queue-live-a500b36999bf40be93d9d1a698044798`.
The run covers automatic initial allocation, stable grants, real HTTP/UDP readiness/cancellation,
terminal acceptance, rematches, lost registration replies, process restart and unattended
cancellation recovery. It uses source adapters in native tests; no two normal Unity scenes are
launched by this mode. This evidence predates the subsequent coherent authority reader changes.

### Coherent paired authority reads

`BattleManifestFactory.Create` now obtains both participants' allocations and durable accounts
through `BattleAllocationStore.GetAccountSnapshotsAsync`. Both queries share one snapshot/majority
Mongo transaction, and returned rows preserve the source roster order. Missing participants or
damaged allocation quantities abort the whole read instead of publishing a partial manifest.
Presentations are projected from those exact account documents, replacing separate store reads.
This guarantees one read snapshot, not automatic refresh of an allocation after a later account change.

The inventory Mongo suite passes with exit zero at `paired-authority-tests.log` in the same
evidence directory. It includes roster ordering, empty ownership, missing participant and
damaged participant rejection alongside prior preparation/card-pack concurrency checks.
`Server/.local/paired-authority-build.log` records zero build warnings/errors. A second real
queue run with this reader and a forced between-query mutation scenario remain required.

The between-query mutation scenario now passes in `snapshot-race-tests.log` in the existing
evidence directory. A test-configured Mongo client's command observer commits a new account
and allocation together, using a separate client, immediately after the account query returns
and before the allocation query starts. The manifest read retains old account Gold and zero
cards while independent post-read queries confirm new Gold and two owned cards. No production
pause hook or fake database is used. `BattleAllocationStore(IMongoDatabase)` permits reuse of
the configured client's session/command observer. The complete inventory suite exits zero.
`Server/.local/paired-authority-race-build.log` records a clean Release build. The subsequent
real queue regression is running separately and must not be inferred from this focused result.

That subsequent queue regression terminated unsuccessfully: `coherent-normal-queue-tests.log`
records a UDP command timeout in `LiveSameOpponentRematchChecks.FinishRoundAsync` at the second
participant's Forfeit, during the lost-registration-reply/restart scenario. Runtime artifacts
are in `Server/.local/queue-live-5be9dbcf5d6f4b378e8298afa9a886fe`. Worker logs contain a tick
backlog warning, but that is not established as the cause. The earlier queue success does not
prove the newer reader passes the complete gate. Preserve this failure for diagnosis rather
than widening timeouts or declaring it harmless. Owned processes were cleaned up after exit.

The current source additionally compares allocation identities, card quantities and all unit
lanes with `BattleAllocationSource.Project` from the same durable account. Queue admission
checks before joining, and manifest construction rechecks its transactional rows before
freezing. A stale allocation is rejected rather than replenished or trusted. Legitimate later
equipment changes still need an inactive-allocation refresh policy; this guard alone is not
that policy and can reject such changes until refresh is implemented.

The Mongo suite with the added mismatched-card rejection passes with exit zero at
`account-match-tests.log`; `Server/.local/allocation-account-match-build.log` records a clean
build. These results do not resolve the preceding live Forfeit timeout or replace a fresh
whole-queue run against the changed admission and manifest checks.

### Terminal response timeout investigation

Worker source review confirms that a terminal command's outbox publication and active-journal
completion occur before its UDP response is sent. Outbox publication includes write-through
and a durable flush. This is a possible latency boundary, not a proven explanation for the
observed Forfeit timeout. The terminal endpoint retains its session/reply authority; result
acceptance alone does not immediately remove it in the inspected path.

Worker health metrics now expose terminal persistence attempt count, total milliseconds and
maximum milliseconds, with a warning for an attempt lasting at least one second. Persistence
ordering and SDK retry deadlines remain unchanged. The live queue harness captures typed
Worker metrics as `failure-worker-metrics.json` before cleanup if a scenario fails, without
session credentials or replacing the original exception. The diagnostic Release build passes
at `Server/.local/terminal-persistence-metrics-build.log`. The associated actual queue run writes
`terminal-diagnostics-queue-tests.log` in the existing Mongo evidence directory; its final
status must be inspected separately before claiming a resolved regression.

The diagnostic whole-queue rerun now completes with exit zero at
`terminal-diagnostics-queue-tests.log`. Runtime artifacts are in
`Server/.local/queue-live-4dc45ecf68e544a5807dac67baed8759`. This run includes the coherent
reader, account/allocation equality checks and terminal persistence diagnostics. Readiness,
terminal acceptance, same-opponent rematches, lost registration replies, Backend/Worker
restarts and unattended cancellation recovery pass. It does not launch two normal Unity scenes.
The earlier Forfeit timeout did not recur; its cause remains unproven and its failed artifacts
are retained. A mid-run metrics sample showed 197ms maximum terminal persistence for that
Worker instance; this is not a run-wide maximum or proof excluding all storage delays.
No timeout was widened and no durability guarantee was relaxed. Owned processes exited or
were cleaned up after the test completed.

### Inactive refresh admission fence prerequisite

`BattleAdmissionFence` provides a player-keyed write within the caller's Mongo transaction.
It requires canonical one/two-player identities, orders participants deterministically and
validates the complete existing revision before incrementing it. Missing revision fields
deserialize as zero and fail; they do not manufacture revision one. Transactions acquiring
the same participant conflict and retry through Mongo's existing transaction policy.

The inventory Mongo suite passes at `admission-fence-tests.log` in the existing evidence
directory, exit zero. Eight competing transactions conserve all revisions, and a damaged
zero revision is rejected without repair. Build evidence is `Server/.local/admission-fence-build.log`.
This primitive is not wired to production admissions yet. General queue ticket creation,
pairing, scoped joins and rematch reservation must acquire the same fence before allocation
refresh can depend on it. A read-only absence check is insufficient to prevent write skew.
The inactive-refresh feature remains incomplete and is not enabled by this checkpoint.

The current working tree wires this fence into unscoped ticket insertion/pairing, scoped join
and candidate pairing, rematch participant reservation and initial allocation preparation.
Unscoped ticket insertion now checks existing pair ownership in its transaction instead of
publishing a ticket independently. Preparation rejects an existing queue ticket or pair under
the same fence. General ticket admission was split into short methods; retry/expiry behavior
is retained. Startup creates the fence collection before concurrent queue traffic.

The first focused batch passed scoped queue and rematch reservation tests, then stopped because
the rematch army stale-allocation test still expected its old feature-local error text. The
shared account validator correctly rejected that state earlier; the expected rejection is now
updated without broadening accepted exceptions. Final focused results are being collected in
`*-fenced-final.log` in the existing Mongo evidence directory. This wiring does not yet enable
allocation refresh. Active-ownership rejection and refresh-versus-admission races, plus prepared
rematch manifest revision binding, remain required before refresh can be safely published.

The final focused batch passes all five commands with exit zero: scoped queue attempts,
rematch reservations, rematch manifests, manifest snapshots and inventory allocation. Evidence
is the corresponding `*-fenced-final.log` files; the build at
`Server/.local/admission-fence-wiring-build.log` has zero warnings/errors.

The additional `active-ownership-tests.log` suite also passes with exit zero. It creates a real
waiting ticket, verifies preparation rejection, forms a pair through the normal queue store,
and verifies rejection again without an account revision change. Build evidence is
`Server/.local/admission-active-ownership-build.log`. These are actual Mongo store transactions,
not a running Worker or normal two-Unity match. Cross-path refresh races and prepared-rematch
revision binding remain open; allocation refresh itself is still disabled.

The preparation-versus-general-queue race now passes in
`preparation-admission-race-tests.log` in the existing evidence directory, exit zero.
An actual preparation transaction holds the shared fence after reading its account. A separate
configured Mongo client's command observer confirms normal queue admission attempts to insert
that same fence before the gate is released. No ticket is visible and admission is incomplete
while preparation is held. After release, preparation commits, admission returns waiting, and
the persisted allocation matches the current account. The test then cancels its exact waiting
ticket. No production pause hook is used. `BattleMatchQueueStore(IMongoDatabase)` reuses the
configured client's sessions; the ordinary URI constructor retains its existing settings.

The complete inventory suite still passes, including active-ownership, account mutation,
paired snapshot and card-pack concurrency checks. Build evidence is
`Server/.local/preparation-admission-race-build.log`, zero warnings/errors. This verifies one
cross-path ordering; rematch-versus-refresh and prepared-rematch revision binding remain open.

### Prepared rematch account revision binding

Manifest preparation now carries the exact ordered account revisions read with its allocations.
The ordinary byte-returning factory APIs remain available; the rematch allocator uses the
prepared result and supplies its revision proof to participant reservation. The proof stays
server-side and does not alter Client protobuf or manifest JSON fields.

A prepared rematch requires complete, ordered, positive and non-exhausted account revisions.
After acquiring participant fences, reservation conditionally advances both matching account
revisions inside the same transaction as consent, pair and frozen manifest publication.
A stale second account aborts and rolls back the first account write too. Existing allocated
reservation replay returns its frozen result without reserving the accounts a second time.
Missing, reversed, zero, negative and exhausted proofs are rejected.

Actual Mongo tests pass with exit zero at `rematch-reservation-only-account-proof-final.log`
and `rematch-manifest-only-account-proof-final.log` in the existing evidence directory.
The change-stream audit observes all seven writes (two accounts, two fences, consent, pair,
manifest) sharing one transaction. Factory tests verify exact ordered revisions after a durable
equipment update. `Server/.local/rematch-account-proof-final-build.log` records zero build
warnings/errors. The preceding inventory suite also passes at `allocation-inventory-mongo-account-proof.log`.
This is focused store/factory evidence, not a fresh whole-queue or two-Unity gameplay run.
Inactive allocation refresh and its direct race with rematch reservation remain unimplemented.

### Inactive allocation refresh storage implementation

`BattleAllocationPreparationStore.RefreshInactiveAsync` now updates a valid existing allocation
from the supplied server-owned account projection. It shares the preparation fence, inactive
ticket/pair checks and exact expected account revision. The prior allocation is validated before
replacement; damaged or exhausted revisions fail rather than being normalized. A changed
projection conditionally replaces its exact prior revision and advances the account revision
in the same transaction. An identical projection changes neither account nor allocation revision.
The create-only `PrepareAsync` boundary remains available and preserves existing allocations.

The complete inventory Mongo suite passes with exit zero at `inactive-refresh-tests.log` in the
existing evidence directory. Tests remove owned cards, reject a stale account revision, refresh
to zero ownership, replay unchanged content, reject waiting-ticket/pair ownership and reject
a damaged allocation revision without repair or account writes. A later valid inventory change
is reflected only after cancellation of the waiting ticket. Existing preparation/admission and
snapshot race tests also pass. `Server/.local/inactive-refresh-build.log` records zero warnings/errors.

This is a storage API, not yet enabled in normal queue HTTP admission. Direct refresh-versus-
rematch contention and the whole real queue/Worker regression remain necessary before wiring
and declaring this integration complete. Normal two-Unity gameplay remains a separate gate.

### Inactive refresh versus rematch reservation

The native `--rematch-refresh-race-only` scenario now holds an actual inactive-refresh
transaction after its account projection while a separate configured Mongo client attempts
rematch reservation. A command observer confirms reservation reaches the shared fence write.
It cannot publish a pair while refresh is held. After refresh commits, the old prepared account
proof is rejected. The refreshed card quantity survives; no partial pair, frozen manifest or
account revision write remains, and mutual consent stays ready for a fresh preparation.

The final run passes with exit zero at `rematch-refresh-race-final-tests.log` in the existing
evidence directory. Build evidence is `Server/.local/rematch-refresh-race-final-build.log`,
zero warnings/errors. `BattleRematchConsentStore(IMongoDatabase, BattleResultStore)` permits
configured session observation; the existing URI constructor retains its behavior. The
accepted round and prepared payload are store fixtures, not normal Unity/Worker gameplay.
This proves the refresh-winning ordering. HTTP queue refresh wiring, whole real queue/Worker
regression with refresh enabled and normal two-Unity gameplay remain open.

### Normal HTTP inactive refresh wiring

The current queue route now checks signed-attempt replay outcomes before preparing a loadout.
`ExistingAttemptAsync` reads only that attempt's cancelled/completed/paired authority, validates
its receipt and pair binding, and never creates a ticket. This prevents an already assigned
attempt from refreshing current inventory instead of returning its frozen match. Old cancelled
attempts cannot select a successor pair.

For new admission, an absent or account-mismatched allocation now invokes `RefreshInactiveAsync`
with the server-owned projection and manifest presentation validation. Equal contents retain
the existing allocation. Active waiting tickets still prevent a changed loadout from being
refreshed; the player must cancel that search first. The common allocation reader now validates
durable revision bounds for single, batch and paired reads as well as refresh.

Release build passes at `Server/.local/queue-inactive-refresh-build.log`. Focused queue and
inventory suites pass at `queue-attempts-only-inactive-refresh-http.log` and
`allocation-inventory-mongo-inactive-refresh-http.log` in the existing evidence directory.
The real queue run is writing `queue-live-inactive-refresh-http.log`, with runtime artifacts
in `Server/.local/queue-live-a2bfe1fbcdfe46a49d9f70913da5c3f3`; its final result remains pending.
Its new HTTP scenario changes durable inventory as a server fixture, verifies rejection while
waiting, cancels, then rejoins and checks the refreshed quantity. This is not purchase/economy
authority proof or normal two-Unity gameplay acceptance.

The real HTTP/UDP queue run now completes with exit zero at
`queue-live-inactive-refresh-http.log`. Its explicit HTTP refresh scenario passes, followed by
the existing readiness/cancellation, same-opponent rematch, lost registration reply, process
restart and unattended recovery scenarios. Owned test processes were cleaned up. The final
behavior-preserving naming/namespace cleanup also builds cleanly at
`Server/.local/queue-inactive-refresh-final-build.log`. This closes the native integration gate
for this queue refresh path, not fresh starter-profile rendering, normal two-Unity gameplay,
Android or complete inventory/economy reservation against every legacy writer.
# Normal matchmaking routing evidence — 2026-10-19

The actual Splash-to-MainScene account boot passed with the read-only
`UnityNormalMatchmakingReadinessAudit` included. Evidence:
`Server/.local/client-boot-f191e9331e0d4e04977e1862f5da0113/report.json`.
The Release build had zero warnings/errors. Unity initialized 24 unit rows and 66 weapon rows,
with zero exceptions and the existing 70 error-level diagnostics. The disposable package manifest
retained SHA-256 `7212bb6d4ae5db21b4fe5d10a4a0666d1f2c63618d8277b692254dd1c2c815a3`.

The fresh account had display rank 2, while the recovered easy-bot threshold was 4.
Its stored average match FPS was 0, below the recovered minimum of 20. Cached high ping and
repeated losses were false. The active controller was `GameControllerCampaign`. These observations
explain the random DeathMatch routing predicates; they do not report that a match was started.
Calling random matchmaking with this account would select the recovered local-bot path rather
than self-hosted UDP admission. The audit does not modify rank, device history or routing flags.

Normal two-Unity PvP acceptance therefore needs an explicitly identified returning-player fixture
whose progression and saved match FPS satisfy the source conditions, or prior source gameplay that
earns that state. Do not disable the easy-bot/slow-device rules to force a passing test. Keep a
separate fresh-account campaign/local-bot acceptance gate. Neither gate is completed by this boot run.

## Returning-player login fixture

`ClientBootSmoke.ps1 -VerifyReturningPlayer` performs two real Unity launches against the same
isolated Backend/database and persistent-data identity. The first launch retains the fresh
account insertion proof. Between launches, a test-only command requires an isolated
`war_client_boot_<GUID>` database, exactly one account and no battle tickets, pairs or allocations.
A revision-conditional update seeds synthetic returning-player state, not earned progression.

The fixture uses recovered rank index 4 (display rank 5), zero within-rank experience and total
experience 215,960, the sum of the first four `Google2u.Levels.EXPERIENCE` rows. A saved device
entry contains one 30 FPS sample. `UserDeviceManager.GetAverageMatchFPS` falls back to the first
saved device if the current model is absent. No Client bot condition is overridden.

The two-launch run passed at `Server/.local/client-boot-c0fbaf4815bd4372bbc7ddf0acc6d6a0`:

- Release build: zero warnings/errors; original starter insertion proof passed.
- `returning-report.json`: rank 5, saved FPS 30, all four bot-routing predicates false and
  `canUseSelfHostedMatchmaking=true`; 24 unit rows and 66 weapon rows initialized, zero exceptions.
- `Unity-returning.log`: normal successful-login callback present, account-creation callback absent.
- Returning boot recorded 71 error-level logs. Compared with fresh boot, the create-account log
  is absent and logs for missing Fusebox configuration and missing War Arena configuration appear
  in `GetPlayerData`/`OnGetPlayerData`. Other diagnostics remain unresolved.
- The disposable package manifest hash remained unchanged from the value recorded above.

The active controller remained Campaign. This proves returning-player data loading and
eligibility for random PvP, not admission, a started match, rendering or combat. Next, use two
separately isolated returning identities with the actual DeathMatch controller, real Backend and
battle Worker; observe normal lobby/card-selection/loading/readiness before claiming gameplay acceptance.

## Normal DeathMatch queue admission

`ClientBootSmoke.ps1 -VerifyNormalQueue` extends the returning-player run by calling the original
`SwitchToDeathMatch` and `GameControllerDeathMatch.StartRandomMatchMaking` entrypoints. A separate
MongoDB change-stream observer starts before the second Unity launch. It requires a durable scoped
queue-ticket insertion bound to the returning account and a validated battle allocation. The Unity
audit waits for that observer's report; a lobby screen alone cannot pass the script.

The first run at `Server/.local/client-boot-3be103d6f3c346b0a84a1c6378193eb5` failed:
normal matchmaking reported `BackendStatusException` and no ticket was observed. Inspection found
the boot-only harness had not configured matchmaking policy, which explicitly disables queue join
in the Backend. The queue mode now supplies the existing starter mixed-combat template and all
nine weapon content manifests, restoring inherited environment values during cleanup. It does not
replace the account's four-weapon/four-unit starter ownership with the simpler rifle-only fixture.

The configured run at `Server/.local/client-boot-3b4fd09182ce470d8f68e193899ca8ae` passed:

- Release build had zero warnings/errors; fresh initial-state insertion and returning login passed.
- `normal-queue.json` and `QueueObserver.log` record the durable scoped ticket/account/allocation binding.
- `returning-report.json` records `normalQueueStarted=true`, `normalQueueObserved=true`, active
  `GameControllerDeathMatch`, rank 5, saved FPS 30, zero exceptions and 71 error-level diagnostics.
- The owned script exited successfully and cleaned up its processes. The disposable package
  manifest retained its recorded SHA-256.

This run has one Unity participant and no paired battle Worker. It does not prove two-client
admission, card selection, loading/readiness, rendering, combat or acknowledged cancellation.
Those remain the next integration gates; the full BattleServer checklist remains open.

## Two normal Unity participants: current failed entry gate

The new `ClientBootSmoke.ps1 -SecondUnityProject <disposable-project>` mode runs the ordinary
account boot for two separate persistent identities, seeds exactly two synthetic returning accounts,
starts a real battle Worker and launches both normal DeathMatch controllers. Each participant
publishes lobby readiness before either starts searching, preserving the source matchmaking wait
and bot-fallback rules. The audit calls the normal card-selection completion method and requires
both authoritative `Running` and the normal Client's `gameIsRunning`, with the same match ID.
It does not pass merely because both sockets connect.

Use distinct projects under `Server/.local` with independent Assets and Library directories.
`NormalUnityPairSmoke.ps1` is a child of the parent boot script; it depends on that parent's isolated
Backend/database/environment and owns only its Worker and Unity processes. The Worker receives
the recovered map data and the existing mixed starter weapon manifests. Control registration uses
`/internal/matches`, separately from `/health/ready`. No active Client assets or reference projects
were changed to build this harness.

The initial attempts are retained as failed evidence:

- `client-boot-3a6b6d31233b439db9e96f255aaffa12`: second-project initialization exceeded the
  owned process limit. Separate prewarming subsequently exited normally; this is not gameplay proof.
- `client-boot-07b3c37fd607442296b323e0bb0f0685`: second boot reached account creation but did
  not finish unit/weapon initialization before its audit deadline. Logs also record prefab updates;
  they do not establish the sole cause. The next run completed both ordinary boots without changing
  their audit deadlines.
- `client-boot-62e36f278c784ce09f4903f04cf13542`: the first harness configuration sent control
  registration to `/`, producing Worker 404 responses. Subsequent bot fallback/card errors do not
  prove successful UDP admission. The harness control URL was corrected before the following run.

The configured run at `Server/.local/client-boot-3bac052f04284c60b4fb34563de5af84` **failed** its
complete entry gate. Release build had zero warnings/errors; both booted accounts and pair-fixture
setup passed. Both logs contain `ALL PLAYERS CONNECTED`, both reports contain two players and
`hasSubmittedCards=true`, and both controllers entered the post-selection loading path. Neither
report has `hasReachedRunning=true`; both ultimately record `GameCancelled`. Error-level counts
are 107 and 108, with zero uncaught exceptions. The script exited nonzero and cleaned up its owned
processes. Both disposable package manifests retain SHA-256
`7212bb6d4ae5db21b4fe5d10a4a0666d1f2c63618d8277b692254dd1c2c815a3`.

Source-backed integration gaps exposed by this run:

1. `GameControllerPVP.LoadLevelAndStartGame` still sends `GameStartedMaster` (64) or
   `GameStartedClient` (65). The Backend logs both as unimplemented and returns `Result:503`.
   `GameController.WaitForServerResponse` waits for `mGameCreated`, which is set by the successful
   `OnGameStarted` callback. A success response requires `Time`; it may also update `BattleId`
   and the paired dog-tag fields. Implement this acknowledgement against the authenticated current
   pair/frozen manifest, preserving the recovered callback order and server-owned economy. Do not
   fabricate successful receipts for an unallocated match or skip the Client's wait.
2. `GameControllerOnline.AquireLevelName` still waits for `mMapIdSet`, historically supplied by
   Photon map RPCs. The self-hosted roster initializer does not set it. The current protobuf grant
   has no map identity/revision fields. This is a separate pending contract gap even after the
   HTTP acknowledgement is supplied; bind the trusted manifest's map to the existing local map
   entries rather than selecting an arbitrary/default scene.

These are actionable prerequisites, not a claim that they are the only remaining loading failures.
Normal rendered combat, mobile execution, reconnect, outcomes and the full feature checklist remain open.
