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

## Remaining normal-flow work

Run the recovered MainScene with isolated local persistence and the real native
Backend, then verify actual account/configuration initialization, LevelManager
unit definitions, selected cards, player prefab inventory and preview-camera
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
