# Server source ownership

The Backend and BattleServer keep `Program.cs` as their only root-level C# source file.
Runtime configuration, project files, and package locks remain at the project root.
The migration map is [server-source-layout.json](server-source-layout.json); its hashes record the
original bytes of 687 root moves. That first relocation was byte-identical. Later project/type
extractions are recorded in [battle-project-extraction.json](battle-project-extraction.json).

## Backend

`Features/Accounts`, `Features/Network` and `Features/Health` own the modern account/probe/health
endpoints. `Features/Battle/Authentication`, `Admission`, `Queue`, `Rematch` and `Internal` separate
authentication, typed use cases and HTTP adapters. Application owns transport-neutral result/failure
types; Transport/Http maps them to the unchanged protobuf error envelope and bounds incoming bodies.
Program.cs composes maps in 27 lines. See [BACKEND_HTTP_STRUCTURE.md](BACKEND_HTTP_STRUCTURE.md).

`Features/Battle` owns allocations, loadouts, catalogs, manifests, provisioning, cancellation,
rematches, and result acceptance in separate folders. `Transport/Http` owns protobuf HTTP encoding.
`Legacy` owns the current 1.4.0 PHP/form compatibility channel. New checked economy calculations live
in `Legacy/Economy`. The direct HTTP adapter now delegates to an immutable 175-action registry with
typed anonymous/session handlers and explicit closed/buffered-only dispositions. Feature composition,
player/squad queries, projections, crafting and diagnostics have separate owners. Buffered execution
also uses typed feature registration. See [LEGACY_ACTION_STRUCTURE.md](LEGACY_ACTION_STRUCTURE.md).

Buffered requests now separate envelope/value parsing, pure mutation planning, transactional commit,
and Client response projection. Receipt DTOs and transaction validation live in
`War.Persistence/Legacy/Buffers`. `LegacyBufferedResponse` owns delivery-clock projection and
`LegacyBufferedRollback` owns current failure-state projection; `LegacyBufferedCosmeticResponse`
owns mandatory cosmetic success fields. `Legacy/Buffering/LegacyBufferPlanner` owns validation,
registered execution and publication planning. Inventory/Economy/Cards/Squads own the 25 buffered
actions; Execution contains the per-request state and shared helpers. The planner has no action
switch or partial family. One captured time and seed come from the coordinator outside retries;
neither the planner nor feature calculators depend on a store/network service. Headless producer
checks preserve Client result/rollback contracts; the recursive source inventory guards relocation.
`Legacy/Progression/LegacyRankGate` owns zero-based stored rank versus displayed-level eligibility
for weapon/unit/cosmetic purchases and tier promotion.
`Legacy/Catalog` owns bounded parsing, immutable scalar/row/sheet storage, reviewed identity indexes,
exact integer reads, consumed-field domains, typed upgrade lanes/tier limits, configured-host
dependencies and the embedded reviewed release profile. Upgrade completion admission is separate
from price calculation and transactional persistence.
See [LEGACY_CATALOG_VALIDATION.md](LEGACY_CATALOG_VALIDATION.md) for the remaining release audit.

Card-pool actions now use `Legacy/Cards`: the endpoint parses the request, an immutable policy owns
source cooldown/reputation, and pure rules calculate conserved transfers. Persistence owns the
session-bound account/donor/squad writes and replay receipts. See
[CARD_POOL_PUBLICATION.md](CARD_POOL_PUBLICATION.md) for the legacy retry boundary.

`Legacy/Squads` now separates request parsing, immutable creation policy, admission, role/settings
rules and response projection. `War.Persistence/Legacy/Squads` owns snapshot reads and atomic
one/two-roster publication. The old independent squad write helpers were removed. See
[SQUAD_PUBLICATION.md](SQUAD_PUBLICATION.md) for source authority and concurrency/fault verification.

`Legacy/Accounts` now owns guest registration/login, metadata parsing, immutable starting policy and
response projection. `War.Persistence/Legacy/Accounts` owns credential/session validation, one-insert
creation and committed-revision rotation. The old generic account insertion and separate initial
session write were removed. See [ACCOUNT_PUBLICATION.md](ACCOUNT_PUBLICATION.md).

`Legacy/DogTags` owns frozen source capacity/VIP policy, debt/regeneration arithmetic and direct
callback fields. `War.Persistence/Legacy/DogTags` owns tuple validation and session/revision-bound
single-document publication. `Legacy/Progression/LegacyPlayerDataEndpoint` owns pending-buffer boot
flow and one projection clock; `Legacy/Time/LegacyClientTime` owns recovered wire timestamp bounds.
See [DOG_TAG_PUBLICATION.md](DOG_TAG_PUBLICATION.md) for concurrency and anonymous-retry limits.

`Legacy/State/Models` now holds the 14 serialized DTOs separately, retaining their public namespaces.
The state facade uses bounded unique JSON, strict scalar/known-container reading and preserved
unmodeled metadata. `Legacy/Preferences` and `War.Persistence/Legacy/Preferences` own the complete
Settings contract, current-session/revision publication and metadata conservation. See
[STORED_STATE_VALIDATION.md](STORED_STATE_VALIDATION.md) for the wider C13 boundary still open.
`War.Persistence/Legacy/State` owns strict BSON integer serializers and the shared root
wallet/rank/tier/counter validator. Account reads/authentication, transaction snapshots and Backend
projection reuse that boundary; starting placement comes from the immutable catalog constant.
Feature-specific progression, missing-field migrations and complete successor schemas remain open.
`Legacy/Profile` owns canonical input/diagnostic agreement and the five direct profile callbacks.
`War.Persistence/Legacy/Profile` owns immutable replacements, current-session/revision rebasing,
stored-profile checks and source-priced atomic rename publication. The old generic TryUpdate was
removed. See [PROFILE_PUBLICATION.md](PROFILE_PUBLICATION.md) for concurrency and replay limits.
`Legacy/Analytics` maps seven source acknowledgement actions; `War.Persistence/Legacy/Analytics`
owns known-field validation and current-session/revision publication. Buffered chat markers share
the contract, retaining unknown metadata without null/default repair. Repeated true flags are
read-only. See [ANALYTICS_PUBLICATION.md](ANALYTICS_PUBLICATION.md).
`Legacy/Tutorial` owns the 119/120 callback projection. `War.Persistence/Legacy/Tutorial` owns
versioned pending/terminal identity, explicit legacy migration/refusal and current-session/revision
publication. It replaces the final production generic Update calls; fixture perturbations live in
test support. See [TUTORIAL_PUBLICATION.md](TUTORIAL_PUBLICATION.md) for replay and no-reward scope.
`Legacy/Progression/LegacyArmyPowerEndpoint` bounds the recovered direct display assertion and
delegates its single-field publication to `War.Persistence/Legacy/Progression`, which revalidates
root/session/successor authority and requires the authenticated revision/session and live expiry.

## BattleServer

| Folder | Owner and boundary |
| --- | --- |
| `Hosting` | Worker lifecycle, startup configuration, queues and socket orchestration. |
| `Matches` | Registry/router, loading handshake and rematch transport state. |
| `Transport/Admission` | Tickets, sessions, key rotation and reconnect state. |
| `Transport/Udp` | Per-match endpoint, sender limits and datagram budget. |
| `Transport/Reliability` | Reliable event cursors, bounded transfers and chunk replay. |
| `Transport/Snapshots` | Connection projection and snapshot assembly/interpolation policies. |
| `Persistence` | Local terminal evidence and active allocation journal; no MongoDB. |
| `Backend` | Internal HTTP allocator/result adapters. |

The Worker now has 59 authored C# files. Hosting, transport and local recovery remain here; the
simulation tree and shared content package have left the executable.
Program.cs composes its frozen startup, host services and maps in 22 lines. Hosting/BattleHostExtensions
owns the one hosted NetworkWorker; Transport/Control owns health, match and result adapters, request
parsers, grant projection and route limits. Shared stream/MAC/envelope policies live in Infrastructure.
See [WORKER_HOST_STRUCTURE.md](WORKER_HOST_STRUCTURE.md) and
[TERMINAL_HTTP_ENVELOPE.md](TERMINAL_HTTP_ENVELOPE.md) for authority, wire budgets and actual HTTP gates.

## Domain and Simulation

War.Battle.Domain owns 306 source files: match/queue contracts, shared Content, managed Geometry,
Combat rules, Presentation validation and Results validation/projections. Backend and Persistence
consume it without a Worker or Simulation reference. Domain references Shared only.

War.Battle.Simulation owns 642 source files. Match keeps the existing MatchEngine family; Coop keeps
the existing co-op runtime. Army/Air/Vehicles/Players, Weapons/Projectiles and Cards/World own mutable
execution. Timing, Objectives, Events, Progression and Results own runtime state and evidence; Physics
owns native adapters. Simulation references Domain/Shared only. Source-specific helpers used only by
one simulation stay with that consumer; shared package definitions belong to Domain.

Six projectile factories now build flights from named value-type launch inputs. Their source catalogs
carry no mutable projectile construction. Managed helicopter pose validation no longer imports native
physics through the content package. Resources move with their loaders and the Worker duplicates none.
See [BATTLE_PROJECT_BOUNDARIES.md](BATTLE_PROJECT_BOUNDARIES.md) for the graph, exact extraction
inventory, resource ownership and verification. Existing public namespaces remain compatible.

## Remaining dependency and state work

Backend Hosting now owns frozen configuration, service registration, store initialization and pipeline
composition. Transport/Http owns the shared HTTP failure/HTTPS middleware. Shared endpoint/key rules
live in Infrastructure/Configuration; both rule libraries stay independent. See
[BACKEND_STARTUP.md](BACKEND_STARTUP.md). Both composition roots and modern HTTP/control maps are extracted.
Typed legacy direct/buffered dispatch is also extracted. Cohesive MatchEngine/CoopMatchRuntime state
still needs S07-S09.
The first S07 increment moves admission/readiness/reconnect flags and decisions into
Match/Lifecycle/PvpConnectionLifecycle and PvpParticipantConnection. Existing Player projections
read those flags through getter-only adapters; the shared engine no longer stores writable copies.
Cleanup/terminal calls retain their original frame positions. See
[PVP_CONNECTION_LIFECYCLE.md](PVP_CONNECTION_LIFECYCLE.md) for before/after traces and the remaining scope.
Weapon membership/selection and ammo/reload/fire deadlines now belong to Match/Weapons owners,
with read-only Player adapters and private slot setters. Shot/animation/projectile side effects
retain their original frame positions. See [PVP_WEAPON_STATE.md](PVP_WEAPON_STATE.md).
Physical player cover/route progress, arrival clocks and observed velocity now belong to
Match/Movement/PvpPlayerMovementState. Targeting reads getter-only observations; command authority
and frame/expiry order remain with the engine. See [PVP_PLAYER_MOVEMENT.md](PVP_PLAYER_MOVEMENT.md).
Player real/cosmetic bullet collections now belong to Match/Projectiles/PvpPlayerBulletSystem.
Its captured value frame advances one flight before the existing engine impact adapter runs;
terminal hits stop the remaining frame. See [PVP_PLAYER_BULLETS.md](PVP_PLAYER_BULLETS.md).
Match/Projectiles/PvpPlayerBazookaSystem similarly owns delayed/active player missiles and curve
history, with immutable launch/payload observations. Shared budget accounting now includes both
states exactly once. See [PVP_PLAYER_BAZOOKAS.md](PVP_PLAYER_BAZOOKAS.md).
PvpPlayerGrenadeSystem owns equipped grenade flights; PvpBonusGrenadeFlightSystem separately owns
bonus/card flights, pending explosions and read-only frame observations. Collision/explosion timing
and shared-setup reads retain their original boundaries. See [PVP_PLAYER_GRENADES.md](PVP_PLAYER_GRENADES.md).
PvpArmyBulletSystem pairs army real/cosmetic flights with immutable launch metadata in one private
entry set. Completion, detached projections and diagnostic queries share that set; world impacts
remain engine-owned. See [PVP_ARMY_BULLETS.md](PVP_ARMY_BULLETS.md).
Army/ArmyFlamePulseClock owns the recovered cumulative float deadline and pulse ordinal as a private
value inside ArmyFlameBurst. Flame uses source frames while bullets/poison retain fixed-tick gates;
world effects remain engine-owned. See [ARMY_FLAME_CLOCK.md](ARMY_FLAME_CLOCK.md) for C31 and evidence.
C32 corrects two clamped interpolation inputs in the existing flame query; its original managed
math oracle lives in tests only. See [ARMY_FLAME_INTERPOLATION.md](ARMY_FLAME_INTERPOLATION.md).
Match/Effects/PvpArmyFlameSystem and PvpArmyPoisonSystem now separately own burst/coroutine storage,
captured frames and completion. Value observations preserve their distinct preflight/commit points;
world effects and shared capacity remain engine-owned. See [PVP_ARMY_EFFECTS.md](PVP_ARMY_EFFECTS.md).
Match/Projectiles/PvpArmyMissileSystem pairs shared Rocket Soldier/Mortar flights with immutable
launch authority and owns last-frame impact diagnostics. Source launch/collision/world effects keep
their original boundaries. See [PVP_ARMY_MISSILES.md](PVP_ARMY_MISSILES.md).
C33 subsequently fixes straight missile expiry/collision priority inside the existing flight model;
paired ownership and world routing remain unchanged. See [ARMY_MISSILE_EXPIRY.md](ARMY_MISSILE_EXPIRY.md).
A separate assembly does not make an existing shared partial-state family independent
systems or enable its closed gameplay modes. Measured performance and full Client integration retain
their own gates.

Keep the portable `War.Shared` and `War.Client` assemblies free of server secrets, MongoDB and host
dependencies. Do not add database work to the battle tick or introduce parallel mutation inside a
match. See [../../todo-list.md](../../todo-list.md) for the ordered implementation and verification plan.

Run `python Server/tools/verify_server_source_layout.py` from the repository root after adding or
moving sources. Audit tools search nested MatchEngine sources. Root moves remain in server-source-layout.json;
cross-project/type splits are recorded separately in battle-project-extraction.json. Update both the
manifest and its exact guard inventory deliberately when changing destinations.
