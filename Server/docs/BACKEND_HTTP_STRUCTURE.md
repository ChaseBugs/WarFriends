# Backend HTTP and application ownership

The Backend portion of S05 moves HTTP orchestration out of Program.cs. It captures startup policy,
registers services, initializes stores and composes middleware/feature maps in 27 lines. Root source
layout remains guarded. Existing namespaces needed by callers remain stable; no Client asset,
protobuf field, PHP action ID, catalog identity or database transaction was replaced.

## Feature map

| Feature folder | HTTP responsibility | Application responsibility |
| --- | --- | --- |
| Features/Health | Liveness/readiness | Readiness pings the existing account store |
| Features/Accounts | Register/login/profile parsing and response mapping | Credential/locale validation and account/session operations |
| Features/Network | Authenticated connectivity request | Server-authored probe session and ticket issuance; no match/reward |
| Features/Battle/Authentication | Shared bearer-token adapter | Modern account first, then recovered-session authentication |
| Features/Battle/Admission | Grant/reconnect request adapters | Pair/roster checks, retained assignment and grant rotation |
| Features/Battle/Queue | Attempt/join/cancel request adapters | Replay classification, preparation, pairing, provisioning and cancellation |
| Features/Battle/Rematch | Read/accept/cancel/allocate adapters | Consent, allocation, cancellation and source response projection |
| Features/Battle/Internal | Bounded control request adapters | Existing provisioner/terminal service and validated allocation query |

Hosting/BackendEndpointExtensions composes these maps and the separate recovered legacy dispatcher.
The auth group remains /v1/accounts with its auth policy; the /v1 group retains api. Health and
internal routes retain their previous policy boundary. A compiled route graph verifies all nineteen
modern method/path pairs, uniqueness and inherited limiter metadata.

ApplicationResult carries a value or a named failure. ApplicationHttpResults owns status/protobuf
mapping; application services receive typed requests, authenticated identities and cancellation
tokens, without HttpContext or request-service lookup. Persistence still owns atomic transitions.
Direct and nested buffered legacy dispatch now use explicit typed registrations and feature owners.
Shared simulation state remains S07-S09. See
[LEGACY_ACTION_STRUCTURE.md](LEGACY_ACTION_STRUCTURE.md) for the direct-channel boundary.
Worker composition/control is also extracted into a 22-line Program and explicit host/transport
owners. See [WORKER_HOST_STRUCTURE.md](WORKER_HOST_STRUCTURE.md) for its nine-route graph and gates.

## Authority and ordering preserved

Queue admission still authenticates before parsing. It validates the attempt credential, checks
configured compatibility, reuses an existing attempt/pair, refreshes only inactive account authority,
then verifies the current allocation and complete presentation. Scoped join recaptures time after
preparation for expiry; unscoped join retains its prior capture. The pair is committed before its
manifest is frozen and sent to the Worker. Deferred provisioning retains the same durable pair and
frozen source. Cancellation uses the captured decision and Worker-confirmed proof.

Grant reads still require pair membership and exact ordered presentation rosters. Reconnect checks
the canonical match/request identities, retained assignment and replacement publication. Rematch
keeps consent, reservation, cancellation/recovery, explicit disabled mode and the same response
codes. Optional provisioning capabilities are resolved through constructor injection; requests no
longer locate factories/allocators from IServiceProvider.

Probe tickets remain connectivity-only. Registration/login remain separate from the recovered PHP
contract. Legacy dependencies are composed once in Dispatch/Composition; the HTTP map resolves the
validated dispatcher before traffic. Its raw action-157 response and callback behavior are covered
by actual HTTP delegate tests and LegacySmoke.

## Bounded HTTP reads and C25

The previous result-accept handler returned 404 for a declared body larger than 65536 bytes; its
streamed-size branch returned 413. Allocation-read had the same inconsistency at 2048 bytes. Native
smoke-19e441cac55d4f7d8f173ce9b7a038b3 reproduced the result route's 404 before the correction.

BoundedHttpBody now serves modern protobuf and internal reads. It rejects declared oversize before
reading, consumes at most limit + 1 bytes when length is unknown, and never appends the excess byte
to its retained body. Its pooled read buffer is cleared before return. Provision/protobuf budgets
remain 65536; allocation-read remains 2048. The result route now derives an 87630-byte decoded JSON
budget from its 65536-byte binary contract. Declared/chunked oversize returns 413, with explicit
HTTP/1 closure. Successful fields, snapshot bytes and MAC domains are unchanged.

BattleControlAuthenticator captures the validated control key and an injected TimeProvider. It
preserves exact header binding, SHA-256 HMAC, constant-time comparison, domain separation, supported
timestamp bounds and the inclusive thirty-second skew. No nonce or full C03 replay claim is added.

Startup review also exposed a C16 gap: Mongo's namespace parser accepted names that AccountStore's
existing 1-64 ASCII letter/digit/underscore rule refused later. Backend now reuses that exact store
policy before initialization. Regression input first failed the pure startup gate; both malformed
database-name cases now join the real startup-refusal process suite.

## Verification and test storage

```powershell
# No Mongo/Editor: bounded input, MAC/clock and exact route graph.
python Server/scripts/verify_battle_checkpoint.py --suite focused --case backend-http

# Existing fast gate, including the new pure groups and optional native HTTP checks.
python Server/scripts/verify_battle_checkpoint.py --suite fast --native-smoke `
    --mongo-executable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'

# Explicit heavier gate: builds Release, starts one owned replica and actual Backend/Worker pairs.
./Server/scripts/TestBackendQueue.ps1 -MongoExecutable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'
```

Pure tests cover declared/unknown-length limits, exact boundary, payload/domain/MAC/clock refusal and
nineteen route identities/policies. Native internal HTTP now has thirty-one scenarios over all three
internal endpoints, including declared/chunked oversize, unsigned at-limit bodies, valid signatures,
stale/wrong-domain refusal, zero result writes on rejection, real terminal acceptance and exact
durable replay. Both native smoke scripts invoke this selector.

TestBackendQueue.ps1 provides a separate Windows Release gate with owned replica/logs, a ten-minute
console deadline, process cleanup, TEMP/TMP/TMPDIR restoration and the shared retention policy.
BackendQueueLiveTests now writes under that owned temporary root instead of Server/.local. It
exercises deferred preparation/provisioning, stable grants, reconnect, scoped cancellation, real
Backend restarts, Worker failure/recovery and same-opponent rematches.

The queue gate does not supply Unity executable/project arguments. Its recovered-client adapter
checks are headless; console wording containing Unity is not evidence of Editor or normal gameplay
execution. V07 source provenance, ordinary GameEnded C18, Unity/Android/Linux service execution,
full schema/catalog review and measured performance retain their separate gates.
C26 resolves the binary/JSON/wire expansion mismatch with a shared serializer and derived budgets;
C27 resolves reuse after oversized HTTP/1 refusal. See
[TERMINAL_HTTP_ENVELOPE.md](TERMINAL_HTTP_ENVELOPE.md) for exact maximum and one-byte-chunk proofs,
fixture scope and unchanged other-route limits.
