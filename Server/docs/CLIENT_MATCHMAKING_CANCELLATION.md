# Client matchmaking cancellation and resource ownership

Normal lobby disconnect now cancels a pending queue search even before the
adapter owns a UDP connection. The source controller also cancels its delayed
start on Reset/OnDisable and ignores obsolete completion/cancellation callbacks.
This checkpoint improves B31; paired-match cancellation is still incomplete.

## Source behavior and fixes

Previously, `PhotonConnectionManager.Disconnect` found the self-hosted adapter
only when `OwnsMatch` was true. During HTTP queue search that is false, so the
normal cancel path missed the active search. A canceled initial delay could
also create an adapter later and publish `CompleteSelfHostedJoin` after the
lobby had already reset.

The original adapter stored its CTS, HTTP client and bearer token in separate
mutable fields. Canceling Find could run its `finally` and dispose that HTTP
client while the remote cancellation still used it. Cleanup also referenced
shared fields rather than one captured operation's resources.

`SelfHostedMatchmakingAttempt` now owns one Backend client, token, search CTS,
search-completion signal and cancellation task. It publishes the HTTP task
before signaling local cancellation. Completion waits for both the search and
remote cleanup, then disposes only that attempt. Repeated cancellation shares
the outstanding task. A failed cleanup retains its resources for explicit retry.

The adapter keeps `IsMatchmaking` true until cleanup is confirmed. A new search
first retries/waits for a canceled predecessor; direct grant admission cannot
bypass that pending cleanup. Operation identity is checked before and after UDP
admission, and finishing an old operation cannot clear a different one. Successful
search cleanup disposes its HTTP resources without closing the UDP connection.
Empty tokens and out-of-range timeouts reject before creating a pending operation.

Only `cancelled` or `not-queued`, with no match ID or roster, acknowledge queue
cleanup. The Backend's `already-paired` response is deliberately rejected as a
cancellation receipt. HTTP failures remain observable; intentional cancellation
does not reset a newer lobby or show the recovered matchmaking-failure dialog.

Destroying a component stops local search/admission but lets its bounded HTTP
cancellation finish before releasing the client. A failed cleanup on a destroyed
owner releases resources because that owner can no longer retry. This does not
promise request delivery after the whole process exits.

The DeathMatch controller captures its own request CTS across the initial delay
and HTTP/admission awaits. Reset clears that ownership before cancellation;
old continuations cannot clear a replacement request or publish a room join.
The private async method was renamed with an Async suffix; no serialized asset
or recovered gameplay identity changed.

## Verification

The protocol executable links the exact plain C# attempt source shipped to Unity.
Nine checks cover authenticated cancellation, task sharing, retained HTTP
ownership during pending cleanup, failure/retry, rejection of already-paired
authority and eventual resource release.

`UnityMatchmakingCancellationAudit.RunAsync` reproduces the old normal-Disconnect
failure and exercises the fixed source components with a controlled HTTP handler.
It enters an empty Play Mode scene so adapter destruction invokes the actual
Unity OnDestroy lifecycle; Editor-only object creation does not prove that callback.
It covers pending queue disconnect, repeated explicit cancellation, blocked direct
admission, cleanup after component destruction, delayed reset, old-continuation
isolation and OnDisable. It uses real source methods and SDK request code but
does not allocate a persistent Backend match or render the lobby.
The delayed-reset case holds the old synchronization-context continuation until
its replacement request exists, then drains it deliberately. It does not rely
on a favorable timer race to exercise the ownership guard.

The existing live bazooka Play Mode scenario now also has an HTTP matchmaking
entry mode:

```powershell
dotnet run --project Server/tests/War.Battle.Tests --no-build -- `
  --unity-bazooka-matchmaking-only <UnityExecutable> <DisposableProject>
```

It starts an ephemeral authenticated Kestrel facade over the fixture's real
signed Worker grant. Unity calls its normal public `MatchmakeAndConnect`, performs
one queue join and one grant request, then admits the real UDP Worker. The facade
requires zero cancel requests on this successful path. The adapter must remain
connected after search resources close, then complete the existing five-flight,
source-effect, automatic polling and callback-retry checks. No signing key or
test bearer token is committed; temporary grant files are removed in `finally`.

The test allocation now uses the actual `m` plus 32 lowercase hex match ID
contract. Its prior arbitrary bazooka fixture ID was correctly rejected by the
SDK's queue validator; no production validation was weakened to pass this test.

The facade is test-only and preallocated. It does not prove Mongo-backed pairing,
normal recovered-session login, two Unity queue participants or complete menu/UI
boot. Use the source/effect tools listed in
[the Play Mode setup](PLAYER_BAZOOKA_LIVE_PLAY_MODE.md#running), current Client
sources including the new attempt script/meta, and the additional cancellation
audit when running these gates in a disposable project.

The current solution builds with zero warnings/errors. All 1,175 protocol checks
and the 74 live Mongo/HTTP/protobuf/UDP smoke checks pass, including restart-safe
result acknowledgement. Static asset audits retain zero missing scripts/broken
references and the same 17 preexisting NGUI sprite mismatches.

## Remaining boundary

The normal Unity attempt now acquires and preserves a server-issued credential
for scoped HTTP/SDK search and cleanup, as detailed in
[queue attempt fencing](QUEUE_ATTEMPT_FENCING.md). Its updated SDK/protobuf plugin
binaries, native cancellation Play Mode and HTTP-to-UDP admission checks pass.
Actual Mongo allocator fencing has separate service tests. Full recovered UI
boot and scoped ownership across a real Backend process restart still need proof.
The server now cancels a registered prestart pair through hash-bound Worker
control and accepts its validated terminal result before releasing both players.
The Client accepts the resulting `cancelled` response; running or unavailable
control transitions remain `already-paired` and cannot acknowledge cleanup.
Missing manifests or transport/evidence failures return a retryable HTTP 503.
Region/ping-based bot routing, full recovered UI loading, two actual Unity
clients, Android and Linux gameplay also remain open. B31/B32/B36 and the overall
goal remain partial.

The [next control checkpoint](PAIRED_CANCELLATION_CONTROL.md) adds a signed,
hash-bound Worker cancellation request and pre-mutation manifest guard. It
now connects the public queue route to terminal acceptance/pair release for
registered prestart matches; durable distributed attempt fencing remains open.
