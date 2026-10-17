# Hash-bound prestart Worker cancellation

The internal Worker cancellation API now accepts the frozen manifest hash in
addition to match identity. The hash comparison runs on the single simulation
reader before `MatchEndpoint.CancelBeforeStart` can mutate the match. A stale
or conflicting hash returns HTTP 409 without producing cancellation evidence.

This is the Worker/control-client foundation for paired queue cancellation.
The public Backend queue route still returns `already-paired`; it has not yet
been connected to terminal acceptance and durable pair release.

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

Paired cancellation must still capture the authenticated player's exact durable
pair, bind the frozen manifest, coordinate registration/cancellation races, and
accept the validated Worker terminal payload before releasing that pair. Releasing
the pair first would make `BattleTerminalAcceptance` reject a first late result
for lack of its durable roster proof. Missing/unpublished manifests and retries
after Worker failure also need explicit handling; a control acknowledgement
alone is not a substitute for result acceptance.
The cancellation decision and pair identity must be captured together; a later
lookup of the account's current pair could accidentally select a replacement.

Cross-component/process attempt fencing and complete recovered UI entry remain
open as described in [Client cancellation](CLIENT_MATCHMAKING_CANCELLATION.md).
B31/B36 and the complete BattleServer objective remain partial.

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
pruning. This endpoint alone does not release allocator pairs or make public
paired cancellation complete.
