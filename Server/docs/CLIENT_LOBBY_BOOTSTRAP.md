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
