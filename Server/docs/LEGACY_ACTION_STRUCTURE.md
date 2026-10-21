# Legacy action ownership

S06 separates both the direct HTTP channel and nested RequestBuffer execution into explicit typed
registries and feature owners. LegacyBufferPlanner no longer has a partial family or action switch.

## Request path

`LegacyEndpoints` maps the two shipped PHP paths and parses the form envelope. It resolves the
dispatcher at mapping time so invalid registrations stop startup before traffic.
`LegacyRequestDispatcher` looks up the immutable registration, authenticates when required, and
calls the typed feature handler. It does not locate request services or perform gameplay writes.

`Dispatch/Composition` is the only dependency-composition boundary for this graph. Each feature
composition file names its exact action IDs and handlers. There is no reflection discovery,
name-based dispatch, runtime fallback registration, or interface for each small calculator.

| Disposition | Actions | Direct HTTP behavior |
| --- | ---: | --- |
| Anonymous | 4 | Configuration 157, account creation 118/146 and login 30 |
| Authenticated | 60 | Session lookup, then the named feature handler |
| BufferedOnly | 25 | InvalidToken without a session; ServerMaintenance with a valid session |
| Closed | 86 | InvalidToken without a session; ServerMaintenance with a valid session |

The registry requires one registration for each of the 175 recovered DatabaseAction identities.
It rejects duplicates, missing or unknown IDs, unknown owners, anonymous-boundary changes and
disagreement with LegacyBufferProcessor.SupportedActions. Adding an enum value cannot silently
open an action. Closed actions have an explicit Unavailable disposition; they are not features
that have been implemented successfully.

## Feature responsibilities

| Owner | Responsibilities |
| --- | --- |
| Accounts/Configuration | Existing account service, credential/session operations and raw configuration response |
| Player | Public lookup, inbox, profile/settings, boot projection, tutorial, Army Power and validated presentation markers |
| Economy | Existing dog-tag refill/payment/VIP-expiry actions |
| Cards | Card pool, timed crafting, crafted-card claim and validated squadmate notification acknowledgement |
| Squads | Existing transactional mutations, public queries and source-compatible squad projection |
| Battle | Published-assignment start acknowledgement and offline Photon compatibility acknowledgements |
| Diagnostics | Client reports/log acknowledgements; no economy, provider, offer or Arena authority |
| Buffering | Action-98 envelope validation and delegation to the existing ordered atomic processor |

Inventory and additional Economy/Cards/Squads operations retain their explicit buffered-only
labels in the direct registry. Their actual implementations belong to the buffered feature
owners below, reached only through the existing receipt/publication coordinator.

## Buffered execution

LegacyBufferProcessor retains numeric request-index ordering and passes each committed player
snapshot to the next action. LegacyBufferStore retains the per-action transaction and receipt.
Inside each transaction attempt, LegacyBufferPlanner validates the account/time, creates one
LegacyBufferedState and invokes its registered feature handler. It converts malformed JSON to the
same per-action failure, then asks that state to construct the publication plan.

| Buffered owner | Actions | Responsibility |
| --- | ---: | --- |
| Inventory | 21 | Separate weapon purchase, weapon upgrade, unit purchase/promotion, unit upgrade, equipment, cosmetic, Elite and notification-marker owners |
| Economy | 2 | Parts/Scraps conversion with the existing source arithmetic and assertions |
| Cards | 1 | Source-priced card packs, server-owned seeded draws and exact rollback fields |
| Squads | 1 | Monotonic last-seen chat timestamp, preserving the remaining analytics metadata |

LegacyBufferedActionRegistry freezes all 25 explicit handlers. Missing, duplicate, unknown,
ownerless or null-handler registrations and differences from SupportedActions fail construction.
Unsupported buffered actions remain maintenance failures; registering a handler never supplies
missing source prices or reward authority.

LegacyBufferedState is a request/publication context, not shared process or match state. It lazily
decodes the affected subsystem blobs, records dirty keys and wallet deltas, and rejects a failed
action that still contains a pending mutation. It does not mutate the durable source document.
The context is new for every action/attempt; the coordinator still captures one time and random
seed outside transaction retries. Repeating a transaction therefore uses the same clock and draws.

Buffering/Execution contains only genuinely shared result/catalog/slot/delivery/publication rules.
Feature-specific rollback projections remain with their owners; the unit rollback shared by
unit purchase and upgrade has one explicit helper. There are no feature stores, service locators,
mutable static feature fields, or feature-calculator interfaces.

legacy-buffer-extraction.json records thirteen original helper-partial hashes and the 25 exact
action-body token hashes checked immediately after transplant. The later brace, line-width,
parameter-grouping and naming cleanup is covered by executable Client/producer tests; those
historical token hashes are not presented as hashes of the cleaned current bodies.

ILegacySessionAuthentication is the narrow I/O boundary used by the dispatcher. Its production
adapter calls the existing LegacyPlayerStore authentication operation. Damaged durable authority
still returns ServerMaintenance; absent/invalid sessions still return InvalidToken. Request
cancellation propagates to session lookup and feature handlers.

## Client behavior preserved

- Action 157 remains raw `success;<sheet configuration>;{}` text. The reachability body is exactly `ok`.
- Account creation/login still precede session authentication. All other actions authenticate first,
  including closed actions and attempted direct buffered purchases.
- RequestBuffer keeps numeric index order, per-action errors, atomic receipts, replay identity and
  authoritative rollback projections. RequestsResults remains a JSON array serialized into a string;
  BufferId remains a plain string. Neither is a Dynamo AttributeValue.
- Public player/squad projections omit DeviceToken. No projection emits Photon Regions.
- UpdateRegionPings and PhotonIsFull acknowledge their empty/log-only Client callbacks without
  contacting Photon or persisting region authority. GameEnded 62 remains closed.
- Crafting keeps its existing admission, random pool selection and atomic subsystem compare-and-set.
  This structural extraction does not close C12/C13 durable-state/arithmetic auditing.

Diagnostic logging now retains the validated caller identity and decoded-field UTF-8 byte counts,
without client report/error/offer/Arena text in either rendered messages or structured properties.
The unit is explicitly UTF-8 bytes, not UTF-16 string.Length or URL-encoded wire size. Client
PlayerID echo and generated LogId remain unchanged. C28's capturing-logger regression first failed
against the old raw-text logging, then passed with the metadata-only implementation.

Evidence was checked in the active 1.4.0 DatabaseAction, BeanstalkServerManager and
ServerResponseHandler sources. Mandatory callback fields and recovered crafting rules remain
commented at their new owners. legacy-direct-extraction.json records the previous dispatcher's
normalized source hash, original authenticated cases and reviewed direct-channel closure fixture.
It is provenance/test evidence, not a runtime routing configuration.

## Verification

Run the process-free dispatch gate after a solution build:

```powershell
python Server/scripts/verify_battle_checkpoint.py --suite focused --case legacy-dispatch --no-build
```

Ten direct-dispatch groups check exact Client enum identities, original direct-action coverage, invalid startup
graphs, player-profile ownership, route/limiter metadata, actual HTTP delegate execution, raw
configuration/failure/probe bodies, anonymous dispatch, every session boundary, direct-channel
closure, corrupt session authority and cancellation. The configured Mongo endpoint is unreachable;
the suite starts no Mongo process, listener or database directory. Five buffered-dispatch groups
check compiled feature ownership, invalid graphs, per-request plan isolation, failed-publication
guards and closed/malformed input. Three diagnostic groups capture both rendered messages and
structured properties, check ASCII/Korean/supplementary-character byte counts and execute the
unchanged mandatory Client response contracts.

```powershell
python Server/scripts/verify_battle_checkpoint.py --suite focused --case legacy-buffer-dispatch --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case legacy-diagnostics --no-build
```

The producer scanner now walks the complete buffered subtree and accepts explicit internal/static
owner methods. Nine scanner regressions cover nested relocation, transitive helpers, duplicates,
missing trees/methods, expression bodies and unsupported literal syntax. All 71 reviewed Client
source hashes and 25 producer result inventories must still match before contract execution.

The actual HTTP delegate check was added after LegacySmoke caught an empty configuration response
from an ambiguous async-lambda mapping during extraction. That check failed against the broken
adapter before the adapter was corrected to a typed handler method. Dispatcher-only tests had
passed and were insufficient to protect HTTP result execution.

LegacySmoke additionally sends both unauthenticated and authenticated real HTTP requests for all
111 closed/buffered-only actions and checks unchanged wallet balances. Its existing source-backed
boot, callbacks, transaction races, receipt replay, rollback, crafting and squad checks remain
required. Native smoke verifies the modern account/network boundary separately. None of these
checks proves normal Unity scene gameplay or a network/calculation speed improvement.

## Further audit boundaries

This responsibility extraction does not complete C12/C13 catalog, arithmetic or damaged-durable-state
audits, C03 control replay policy, C18 normal gameplay settlement, S07-S09 simulation ownership,
performance baselines, remaining test-producer/Unity leases or V07 source provenance. No Client
asset, gameplay rule, catalog digest or protobuf identity was changed to fit the new structure.
