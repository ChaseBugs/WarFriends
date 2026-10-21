# Backend implementation boundaries

The active Backend is the .NET 10 host. The action inventory and recovered Client evidence live in
[README.md](README.md) and [CLIENT_COMMUNICATION.md](docs/CLIENT_COMMUNICATION.md). Historical
TypeScript feature counts and tests do not describe this implementation.

The [battle project extraction](docs/BATTLE_PROJECT_BOUNDARIES.md) puts the shared content package in
Domain and mutable execution in Simulation. Backend/Persistence reference neither the Worker nor
Simulation. Compiled dependency, resource and native-import checks guard these boundaries; gameplay,
complete durable-state validation and internal runtime ownership remain separate work.

| Area | Current verified boundary | Remaining work |
| --- | --- | --- |
| Guest account/session | Initial credentials/session/metadata/state commit in one insert; validated frozen starter policy; committed-revision rotation and damaged-session refusal | Complete shared player-state validation; anonymous per-intent replay is not claimed |
| Canonical player identity | One exact allocation-free policy across account, match, signing, terminal and SDK boundaries; signed-alias and stored-corruption no-write checks | Reviewed repair of historical references and complete schemas remain C13 |
| Buffered purchases | Atomic mutation/receipt; exact replay binding; current rollback/timer/cosmetic projection; all current literal result dispositions checked against recovered callback | Full catalog/state validation and complete gameplay/Client integration |
| Boot with pending buffers | Envelope validated before execution; committed account used for following buffers and PlayerData | Full action-contract matrix and gameplay completion |
| Replay retention | New receipts have no TTL; old unbound claims remain refused | Compaction with a permanent replay fence; already deleted historical receipts cannot be recovered |
| Purchase/promotion rank | Shared comparison of stored rank index with catalog display level; recovered Client predicates and threshold scenarios verified | Complete catalog identity and durable-state validation |
| Catalog authority | Immutable indexed rows, exact integers, configured schema/count/identity/snapshot profile, typed upgrade lanes and player/helper admission | Source-value and scene-provenance reconciliation; full durable-state validation |
| Upgrade limits | Recovered weapon/normal-tier/Elite boundaries; owned current index and active delivery proof before completion or instant debit | Special-track purchase and complete durable delivery/state migration |
| UDP budget | Startup requires the shared 1200-byte protocol limit; authenticated boundary datagrams and Worker/SDK chunk reconstruction verified | Measured capacity/performance work; no adaptive MTU negotiation |
| Dog tags | Source debt/VIP/price rules, checked clocks, session/revision-bound atomic writes and boot/expiry resynchronization | Stable Client intent identity; broader progression migration and battle admission/settlement integration |
| Stored JSON/Settings | Strict typed JSON, metadata conservation and separate DTOs; complete six-Boolean Settings; exact root BSON integers and shared wallet/rank/tier/counter checks | Full root/subsystem schema, competition lifecycle, successor validation and explicit migrations remain C13 |
| Direct profile mutations | Canonical inputs; exact device/locale tuple; current-session/revision publication; atomic source-priced rename; callback-safe malformed status | Per-intent nonce contract and complete stored-profile schema migrations |
| Shown-once analytics | Seven closed flag identities; current-snapshot CAS; shared 33-field shape contract; exact metadata; validated buffered chat markers; repeated true is read-only | Full reward/receipt lifecycle and schema migrations remain C13 |
| Tutorial acknowledgement | Versioned pending/terminal identity, atomic mirrors, bound replay and current-XP callbacks without rewards | Trusted evidence for old unbound completion; broader host-derived combat/reward integration |
| Card pool | Atomic inventory/deposit/withdrawal, donor reputation and squad fence; keyed retry receipts | Recovered Client operation nonce; Buddy-card rental pool remains unsupported |
| Squad direct actions | Atomic creation, admission/moves, roles, leadership, leave/kick and settings; source rank order and HTTP contracts verified | Per-intent replay identity, general capacity policy and first-join reward receipt |
| Server structure | Both Programs compose frozen services/maps; separate Domain/Simulation; Backend/Persistence have no Worker reference; modern Backend application services and Worker control adapters; exact route/assembly checks | Legacy dispatch and cohesive simulation systems |
| Startup policy | Frozen database/rate/content/legacy options before DB initialization; common key/port/endpoint rules; explicit catalog-free opt-in; exact store database-name policy; real process refusal checks | Complete source catalog/schema review remains C12/C13 |
| Internal HTTP input | Derived terminal binary/JSON/wire budgets; exact maximum replay; shared bounded reads/domain MAC; HTTP/1 closure on size refusal; no result writes after rejection | C03 nonces and complete terminal schema review remain separate |

See [buffered economy publication](docs/BUFFERED_ECONOMY_PUBLICATION.md) for transaction tests,
resource limits and migration behavior, [TESTING.md](docs/TESTING.md) for executable gates, and
[todo-list.md](../todo-list.md) for the complete ordered backlog. This status is not a claim that
ordinary battle settlement, normal Unity gameplay, or the whole Backend is complete.

See [squad publication](docs/SQUAD_PUBLICATION.md) for role/membership transactions and the direct
request retry boundary, and [card pool publication](docs/CARD_POOL_PUBLICATION.md) for transfers.
See [account publication](docs/ACCOUNT_PUBLICATION.md) for registration, sessions and fixture boundaries.
See [buffer contract review](docs/LEGACY_BUFFER_CONTRACTS.md) for the actual callback oracle,
mandatory cosmetic success fields, exhaustive current disposition matrix and instrumented runtime boundary.
