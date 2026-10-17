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
state. It currently **fails** at the next genuine boundary:
`Server/.local/client-boot-ec87754fc1af4932a7bcbb94834a4ac9/report.json` records
MainScene loaded, account data received, main player/network state assigned,
zero unit rows and one `PlayerInventory.Init` index exception. The call comes
from `LevelManager.OnPlayerDataLoaded` after the real HTTP response, not from an
injected profile or a fabricated game-state message.

The active and disposable MainScene files have identical SHA-256
`d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
Its LevelManager component, file ID `45847`, refers to script GUID
`780c78d4af376959b095359d8460246f` but contains no serialized weapon/unit list
payload. Runtime `PlayerInventory.Init` cannot choose an inventory weapon from
the empty list and indexes `-1`. Repair the real runtime binding from original
Client evidence, preserving canonical indices, before continuing normal lobby
initialization. An empty substitute list or invented inventory must not turn
this gate green.

Run the current diagnostic gate with a refreshed disposable Client copy:

```powershell
./Server/scripts/ClientBootSmoke.ps1 `
  -UnityExecutable 'C:\Program Files\Unity\Hub\Editor\2018.3.0f2\Editor\Unity.exe' `
  -UnityProject 'Server/.local/<disposable-client-copy>' `
  -MongoExecutable 'C:\Program Files\MongoDB\Server\8.3\bin\mongod.exe'
```

The script installs its Editor probe, rejects projects outside `Server/.local`,
preserves the caller's environment, and stops only owned processes. It does not
refresh the runtime/assets in that copy or claim the failing account/unit gate
has passed.

## Remaining normal-flow work

Continue the real account/unit gate above by repairing source-backed LevelManager
bindings, then verify selected cards, player prefab inventory and preview-camera
readiness. Do not replace these dependencies with invented player profiles or
menu stubs to obtain a passing battle test.

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
