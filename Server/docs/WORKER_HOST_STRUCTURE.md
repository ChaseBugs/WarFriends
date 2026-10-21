# Worker host and control ownership

The Worker entry point now composes frozen startup options, services and endpoint maps in 22 lines.
Backend remains 27 composition lines. S05 separates host/HTTP ownership without moving match state,
journal authority or database work into transport.

## Owners

| Location | Responsibility |
| --- | --- |
| Hosting/BattleHostExtensions | Loopback Kestrel limits, frozen singleton options and one hosted NetworkWorker |
| Transport/Control/BattleControlEndpoints | Composes health, match and result endpoint maps |
| WorkerHealthEndpoints | Liveness, readiness and existing metrics projection |
| WorkerMatchEndpoints | Bounded registration/reconnect/cancellation parsing and response mapping |
| WorkerMatchRequests | Exact JSON fields and existing identifier request rules |
| WorkerGrantProjection | Existing grant field names, statuses and response shapes |
| WorkerResultEndpoints | Poll, targeted find and acknowledgement adapters |
| WorkerResultRequests | Exact result-reference JSON fields |
| WorkerControlPolicy | Existing route body budgets and MAC domains |
| WorkerControlAuthentication / WorkerControlBody | HTTP adapters over shared server-only transport policies |
| War.Infrastructure/Transport | Bounded stream reading, control MAC verification and terminal envelope encoding |

NetworkWorker still accepts match commands through its existing single-owner queue. TerminalOutbox
and ActiveMatchJournal retain durable local authority. HTTP adapters do not step simulation, mutate
match dictionaries, invent rewards or access Mongo. The explicit DI root creates one NetworkWorker
instance and registers that same instance as the hosted service.

## Exact route and input boundaries

| Method/path | Request budget |
| --- | ---: |
| GET /health/live | No body processing |
| GET /health/ready | No body processing |
| GET /health/metrics | No body processing |
| POST /internal/matches | 65,536 |
| POST /internal/matches/reconnect | 1,024 |
| POST /internal/matches/cancel | 256 |
| POST /internal/results/poll | 16 |
| POST /internal/results/find | 256 |
| POST /internal/results/ack | 256 |

Match operations retain war/match/control/v1/. Result poll/find/ack retain their separate domains.
ControlRequestAuthenticator captures the control key and injected TimeProvider and preserves the
inclusive thirty-second timestamp skew, supported timestamp shape, SHA-256 HMAC and constant-time
comparison. Backend delegates to the same implementation; Domain, Simulation and portable SDKs
gain no host, configuration, key or database dependency. C03 nonces remain separate work.

Request adapters keep the prior field/identifier rules and error distinctions. Malformed references
return 400; missing lookup/ack returns 404; a conflicting terminal lookup returns 409. A damaged
outbox is not normalized into a client-shape error. Registration, reconnect and prestart-cancel
responses retain their prior status/code/grant fields and durable ordering.

Shared stream reads stop at route budget + 1 instead of copying an unknown-length body in full.
Early HTTP/1 oversize refusal advertises closure so later requests cannot race an unread-body drain.
Global Worker Kestrel size remains 65,536; C26's larger encoded result allowance belongs only to
the Backend acceptance route, not Worker admission or UDP. The UDP budget remains 1,200.

## Maintenance and verification

```powershell
# Metadata/request-shape checks; no listener, journal or Mongo process.
python Server/scripts/verify_battle_checkpoint.py --suite focused --case worker-http

# Actual size/MAC/shape probes and the existing HTTP/UDP/restart smoke.
python Server/scripts/verify_battle_checkpoint.py --suite fast --native-smoke `
    --mongo-executable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'

# Release Backend/Worker pairing, reconnect, same-opponent rematch and outage recovery.
./Server/scripts/TestBackendQueue.ps1 -MongoExecutable 'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'
```

Two pure groups check the nine unique method/path mappings and parser boundaries without creating
NetworkWorker. Thirty-seven native Worker scenarios cover declared/chunked oversize, HTTP/1 closure,
unsigned in-budget input, signed malformed shape, stale/wrong-domain MAC and no terminal publication.
The matching Backend graph has nineteen routes. Both graphs must be updated deliberately when a
reviewed new route is added.

S06 legacy dispatch now has separate direct/buffered feature owners. S07-S09 cohesive simulation
ownership remains separate. This host
extraction does not establish ordinary Unity/Android gameplay, Linux service execution, native
packaging or measured throughput. Source provenance V07 and normal settlement C18 remain open.
