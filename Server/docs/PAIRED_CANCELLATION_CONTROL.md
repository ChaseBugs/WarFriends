# Hash-bound prestart Worker cancellation

The internal Worker cancellation API now accepts the frozen manifest hash in
addition to match identity. The hash comparison runs on the single simulation
reader before `MatchEndpoint.CancelBeforeStart` can mutate the match. A stale
or conflicting hash returns HTTP 409 without producing cancellation evidence.

This is the Worker/control-client foundation for paired queue cancellation.
The public Backend queue route now cancels a registered prestart pair, accepts
validated terminal evidence, and releases the pair only after durable acceptance.

## Control contract

```json
{"matchId":"m0123456789abcdef0123456789abcdef","manifestHash":"<64 lowercase hex characters>"}
```

POST this JSON to `/internal/matches/cancel` with the existing server-only
`X-War-Control-Time` and `X-War-Control-Mac` headers. The MAC authenticates the
exact UTF-8 body under `war/match/control/v1/`. The existing freshness, loopback
control listener, request-size and bounded control-queue policies remain.

Only an exact known manifest may be canceled through the hash-bound form.
Waiting/countdown cancellation returns HTTP 200 with exactly `code`, `matchId`
and `manifestHash`; its code is `cancelled-before-start` or replay-safe
`already-cancelled`. Terminal evidence is flushed to the durable outbox before
the successful response. Running, unknown or conflicting authority remains 409.
Malformed hash/extra-field requests fail before entering the simulation queue.

The older one-field signed request and existing one-argument router/two-argument
Worker APIs remain compatible with trusted older tools. New Backend coordination
must use the hash-bound request rather than treating an echoed hash after a
mutation as protection against canceling the wrong authority.

`War.Infrastructure.BattleMatchCancellationClient` requires the expected hash,
signs both fields, caps response reads at 1,024 bytes, and validates the exact
response identity and shape. Only HTTP 200 acknowledges completion; HTTP 202 is
not a durable receipt. Wrong identity/hash, unsupported codes, extra fields,
malformed JSON, oversized bodies and HTTP refusals cannot become success. The
control key stays server-side; no Unity/portable SDK dependency was added.

## Evidence and remaining integration

Protocol cases verify the exact signed body and response/input rejection.
The native Windows smoke submits a correctly signed conflicting hash to a real
Worker, requires 409 and no terminal outbox file, then cancels with the actual
registration hash. The repeat must acknowledge the same hash and durable
terminal file. Existing Mongo/HTTP/UDP and restart-safe outbox checks also pass.
This does not claim Linux runtime validation from portable C# compilation.
The server-only C# control client also replays the real Worker cancellation and
rejects a conflicting hash after cancellation. The final solution builds with
zero warnings/errors; 1,193 protocol checks (18 new cancellation checks) and
74 live Mongo/HTTP/protobuf/UDP checks pass.

The public coordinator captures the authenticated player's pair with
`CancelWithPairAsync`, reads its frozen manifest, invokes hash-bound cancellation,
retrieves retained terminal proof, requires the exact aborted prestart reason,
manifest hash and ordered roster, and calls `BattleTerminalAcceptance`. Only
accepted or exact already-accepted evidence becomes `cancelled`. That acceptance
path persists and rereads exact bytes before releasing the pair. A repeat after
release becomes `not-queued`; no reward or winner is fabricated.

Running or otherwise unavailable Worker control transitions remain
`already-paired`, which the Unity attempt correctly refuses as successful cleanup.
Unavailable transport, unavailable/invalid source-backed settings or invalid terminal
evidence return HTTP 503 `match_cancellation_deferred`, retaining authority for retry.
A missing snapshot is now prepared from the normal immutable server factory;
a missing Worker registration can be recovered as described below.
An aborted HTTP request does not become a success; already persisted Worker
proof can be replayed by a later request or the normal result forwarder.

Native authenticated queue tests now prove unavailable-Worker retention, refusal
to cancel a running battle, successful prestart cancellation with stored proof,
release of both roster members, replay, revoked grant delivery and a distinct
new match. The signed C# client retrieves actual Worker evidence; six protocol
cases check bounded envelopes, identity, encoding, digest and the separate MAC
domain. The current protocol total is 1,322; native general smoke remains 74
checks plus the targeted lookup checks. Linux runtime and complete UI gameplay
are not claimed from these Windows service tests.

Cancellation can now recover a missing frozen manifest or an interrupted Worker
registration using the same source-backed factory and atomic snapshot identity.
Scoped attempts prevent an old cancellation from selecting a replacement pair;
normal Unity uses these scoped SDK calls. Full recovered UI entry, requests
crashing while in flight, normal admission/cancellation races remain separate proof/work boundaries. Durable
[unattended recovery](UNATTENDED_CANCELLATION_RECOVERY.md) now handles committed
intents without another client retry. B31/B36 and
the complete BattleServer objective remain partial.

## Atomic allocator decision

`BattleMatchQueueStore.CancelWithPairAsync` returns the validated match ID and
an immutable copy of the ordered roster from the cancellation transaction itself.
Waiting-ticket cancellation returns no pair. The existing string-only `Cancel`
method delegates to this decision API, preserving the public route contract.
A coordinator must retain this captured authority rather than resolving the
account's current pair after cancellation. This API does not release a pair or
cancel a Worker; terminal acceptance and registration fencing remain open.

The native manifest-snapshot fixture checks captured identity, preservation after
release and replacement allocation, and rejection of a corrupt durable pair.

## Targeted terminal evidence

The signed `POST /internal/results/find` route accepts exactly `matchId` and
`manifestHash`, using the separate HMAC domain `war/result/find/v1/`. It returns
exactly `matchId`, `digest`, and base64 `snapshot` for retained pending **or
acknowledged** terminal evidence. Missing evidence returns 404, conflicting
manifest authority 409, malformed requests 400, and unsigned requests 401.
Requests are capped at 256 bytes, under the existing global control body limit.

`TerminalOutbox.FindEvidence` validates identity before path construction and
reads under the same lock as acknowledgement and pruning. It returns a detached
snapshot and its canonical payload digest. This removes pending-page starvation
and the race where the regular forwarder acknowledges a cancellation result
before a coordinator reads it. Retention remains bounded by the existing
acknowledgement policy; Backend accepted-result replay is still necessary after
pruning. The public coordinator uses this endpoint before terminal acceptance. The
endpoint itself never releases allocator pairs.

## Interrupted preparation recovery

A real-service regression reproduced the old failure: a durable scoped pair
with no snapshot returned HTTP 503 `match_cancellation_deferred` forever when
cancellation was its only remaining request. The same issue applied when the
snapshot existed but registration never reached the Worker.

`BattleCancellationPreparation` now uses `BattleManifestSnapshotStore.GetOrCreate`
and the normal `BattleManifestFactory`. Existing settings are immutable and
never replaced. If preparation never finished, the first valid server factory
publication establishes the source-backed settings, just as ordinary admission
would. Missing configuration or invalid durable loadouts still fail closed.

The cancellation client recognizes only HTTP 409 with exactly
`{"code":"unknown-match"}` as `BattleMatchNotRegisteredException`. Running,
manifest-conflicting, malformed, oversized, duplicate-key or extra-field refusals
never authorize registration recovery. A missing registration is retried once
through the signed `BattleMatchControlClient`, then cancellation is requested
again with the frozen manifest hash. No loop silently overrides Worker authority.
The preparer does not call grant publication and creates no deliverable Backend
grant. The Worker still owns the actual aborted terminal result; acceptance
validates its exact hash/roster and stores it before allocator release.

The native HTTP/Mongo/Worker fixture now proves both a missing-snapshot pair and
a frozen-but-unregistered pair. Both cancel without a winner, retain the correct
frozen hash, store real Worker terminal proof, release both roster members and
publish no player grants. The frozen case also checks exact snapshot bytes are
unchanged. Existing running-match cancellation refusal and three real Backend
restart checks still pass. Eight protocol cases cover the narrow refusal
classification; the protocol total is 1,322.

These tests model interruption by publishing only the durable prefix of normal
allocation. They do not claim an arbitrary process kill at every instruction,
registration/cancellation scheduling under all load. A subsequent
[unattended recovery checkpoint](UNATTENDED_CANCELLATION_RECOVERY.md) now retains
committed pair intent and retries it after process or transport failure. Broad
B31/B36 completion and complete Unity/Android/Linux gameplay remain open.
