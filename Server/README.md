# WarFriends server — new .NET implementation

This is a fresh implementation following `../BACKEND_DESIGN.md`, with the owner's overrides: **MongoDB, no Docker, Windows development and Linux deployment, protobuf communication, no Photon dependency in the new stack**.

The server is a standalone .NET application, not a Unity Dedicated Server/headless Player build.
ASP.NET Core serves Backend HTTP; a separate Worker hosts UDP battles and War.Battle.Simulation.
Production server execution does not require Unity Editor or UnityEngine. Recovered Client rules
guide the simulation; managed/native server geometry still requires its own compatibility verification.

The current checkpoint is executable networking and account persistence, not a complete game backend or a completed Unity migration. Read [the detailed client audit](docs/CLIENT_COMMUNICATION.md) before implementing game features.

## Structure and status

The [battle project boundary extraction](docs/BATTLE_PROJECT_BOUNDARIES.md) separates shared contracts,
content and managed rules into War.Battle.Domain and mutable execution into War.Battle.Simulation.
Backend/Persistence have no Worker or Simulation reference. Worker owns transport/local recovery and
runs Simulation; both libraries stay free of hosting, database and signing dependencies.

Source navigation is described in [Server source ownership](docs/SERVER_STRUCTURE.md).
Modern Backend HTTP maps and application use cases have feature owners; its Program.cs contains
only composition. Worker Program also composes its host/control maps in 22 lines. See
[Backend HTTP ownership](docs/BACKEND_HTTP_STRUCTURE.md) for route, authority,
body-budget and live queue/reconnect/rematch verification boundaries.
See [legacy action ownership](docs/LEGACY_ACTION_STRUCTURE.md) for the explicit 175-action registry,
authentication boundary, feature handlers and the separate 25-action buffered feature registry.
The first [PvP lifecycle extraction](docs/PVP_CONNECTION_LIFECYCLE.md) gives admission/readiness and
reconnect state a separate owner, with frozen before/after engine traces; broader S07 work remains.
The [weapon state extraction](docs/PVP_WEAPON_STATE.md) similarly separates signed slots, ammunition
and reload/fire deadlines, retaining accepted-shot and card/bonus publication order.
The [player movement extraction](docs/PVP_PLAYER_MOVEMENT.md) owns cover paths, progress, deadlines
and frame velocity while preserving command authority, reconnect pauses and speed-effect order.
The [player bullet extraction](docs/PVP_PLAYER_BULLETS.md) owns real/cosmetic flight lifecycle,
preserving one-impact-at-a-time ordering, terminal interruption and detached snapshot observations.
The [bazooka state extraction](docs/PVP_PLAYER_BAZOOKAS.md) owns delayed/active missiles and curve
history; C30 also fixes their omission from the shared projectile capacity budget.
The [grenade state extraction](docs/PVP_PLAYER_GRENADES.md) separates equipped flights from bonus/card
flights and pending explosions, retaining each family's timing, failure and observation boundaries.
The [army bullet extraction](docs/PVP_ARMY_BULLETS.md) pairs each real/cosmetic flight with immutable
launch authority, preserving source factories, world-impact order and soldier-death flight lifetime.
The [army flame clock correction](docs/ARMY_FLAME_CLOCK.md) replaces rounded per-pulse tick intervals
with the Client's cumulative float deadlines and pause-excluding source frames.
The [flame interpolation correction](docs/ARMY_FLAME_INTERPOLATION.md) matches the original managed
Mathf.Lerp clamp for far cone angles and minimum damage on large overlapping colliders.
The [army effect extraction](docs/PVP_ARMY_EFFECTS.md) gives flame bursts and independent poison
coroutines separate owners, preserving their different clocks, commit points and world-effect order.
The [army missile extraction](docs/PVP_ARMY_MISSILES.md) pairs Rocket Soldier/Mortar flights with
frozen launch authority and owns their detached snapshots and last-frame impact diagnostics.
The [army missile expiry correction](docs/ARMY_MISSILE_EXPIRY.md) skips collision queries after the
source lifetime has expired while preserving exact-boundary and earlier collisions.
The [test workflow](docs/TESTING.md) provides managed focused cases and bounded artifact retention.
Malformed test commands now exit before shared/full tests; the argument gate checks actual child
processes and preserves the existing allocation and Unity entry shapes.
See [Worker host ownership](docs/WORKER_HOST_STRUCTURE.md) and
[terminal HTTP budgets](docs/TERMINAL_HTTP_ENVELOPE.md) for shared MAC/stream rules, maximum binary
transport and bounded chunk framing. Other API and UDP limits retain their existing values.
The explicit test-only auth limiter allowance is twenty requests per window for native smoke;
the deployment default remains ten. Caller environment is restored after the Windows script.
Backend and BattleServer keep only `Program.cs` at their C# roots; 687 implementation files now live
under feature folders. Namespaces and runtime assembly identities are preserved. Project-level
domain extraction remains tracked in [the active improvement plan](../todo-list.md).

Use [the testing workflow](docs/TESTING.md) for the fast developer gate, full runtime/source gates,
and bounded artifact retention. New native/legacy smoke runs discard successful temporary databases
and retain compact reports under `.local/test-runs`; `-KeepArtifacts` preserves a diagnostic run.
The full recovered-source audit currently has a MainScene provenance mismatch documented there.

The [canonical identity policy](docs/CANONICAL_IDENTITIES.md) now checks exact lower-case N GUIDs
across account reads/publications, match admission, signing, terminal evidence and SDK readers.
Malformed stored identities fail before mutation; traffic never trims or rewrites them into an owner.

| Project | Responsibility | Current implementation |
|---|---|---|
| War.Shared | Generated protobuf contracts and portable packet codec | .NET Standard 2.0; fixed schema and bounded authenticated packets |
| War.Client | New portable client SDK | Protobuf registration/login/profile; authenticated UDP hello/ping |
| War.Battle.Domain | Shared server contracts, source content and managed rules | Host-independent library; Domain/SDK and resource boundaries checked |
| War.Battle.Simulation | Match state and combat execution | Separate library; Domain/Shared only; native adapters isolated from content |
| War.Backend | ASP.NET Core/.NET 10 process | Mongo account creation/login/profile, admission grants, readiness/liveness |
| War.Persistence | Official MongoDB C# driver | Unique account/session indexes; salted PBKDF2 credentials; hashed expiring bearer sessions |
| War.Infrastructure | Server-only security | Domain-separated session keys, signed expiring server-bound tickets |
| War.BattleServer | Separate .NET 10 Worker process | UDP receive queue, single-owner 30 Hz host loop, authenticated sessions and replay checks |

The battle process does no database work. It hosts connectivity probes and bounded, provisioned two-player matches. Its queue is capped at 512 datagrams, processing at 128 per tick, with at most 128 admitted/closed unexpired probe sessions. Closed-ticket tombstones expire with their original tickets. Sessions bind to the observed endpoint; reconnect/address migration requires a new grant. Probe sessions expire after 120 seconds.

Datagrams are protobuf bytes followed by a 32-byte HMAC; total size is at most 1,200 bytes. Authentication covers the exact bytes. The control API returns match session keys only to an HMAC-authenticated allocator. UDP provides integrity/authentication, **not encryption**. See [BattleServer status](docs/BATTLE_SERVER.md) for the implemented combat slice and remaining authority gaps.

`Battle__MtuBytes` supports only `1200`, matching the codec, reply pages and SDK. Other values fail
startup instead of silently changing receive limits. See [UDP budget](docs/UDP_BUDGET.md) for packet
boundary and real Worker/SDK transfer checks.

Mongo is the only required data service. Battle matchmaking now publishes a pair and consumes both queue tickets in one [Mongo transaction](https://www.mongodb.com/docs/drivers/csharp/current/crud/transactions/), and cancellation uses the same transactional ownership boundary. **The Backend requires a Mongo replica set at startup**, including a single-node replica set for local Windows/Linux development; a standalone `mongod` is no longer sufficient. The native smoke scripts start and initiate isolated single-node replica sets. Future multi-document economy/settlement work can use the same deployment topology. Redis remains optional; there is no PostgreSQL, EF Core, Docker, or Kubernetes dependency.

## Windows: verified smoke test

The active Unity 1.4.0 legacy HTTP builder and normal battle-session entry now
share `http://127.0.0.1:8080/`. Set `WARFRIENDS_BACKEND_URL` before starting Unity
to override both with one Backend directory URL. The active legacy paths are
root `check.php` and `index_09_25_2015.php`; this does not use the older 1.6.0
`/api/` transport. See [Client lobby bootstrap](docs/CLIENT_LOBBY_BOOTSTRAP.md)
for transport tests and the still-unverified normal scene initialization.
`scripts/ClientBootSmoke.ps1` exercises original Splash/MainScene account startup
in a disposable Client copy against its own MongoDB and Backend. With the exact
original LevelManager lists restored, this gate now passes account-data loading
and initialization of 24 units/66 weapons. Rendered lobby and battle bootstrap
remain open; see the linked boundary for error-level logs and verification scope.

For a repeatable source/build/test checkpoint on Windows or Linux, run
`python Server/scripts/verify_battle_checkpoint.py` from the repository root.
Add `--native-smoke` to run the platform's isolated MongoDB, Backend, and UDP
smoke after those checks; on Windows, `--mongo-executable PATH` selects mongod.
`--list` prints the exact stages. This checkpoint does not replace Unity Play
Mode, Android, two real Clients, or production Linux-host release validation.

Install .NET 10 SDK and native MongoDB. From the repository root:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/Smoke.ps1 -MongoExecutable 'C:\Program Files\MongoDB\Server\8.3\bin\mongod.exe'
```

Supply your installed mongod path, or omit the parameter if it is on PATH. This launches and initiates an isolated single-node Mongo replica set on 27028, backend on 18080, and UDP host on 30080. It uses generated development secrets, checks two independent clients, stops only processes it started, and restores the calling environment. Compact logs remain under ignored `Server/.local/test-runs/`; successful runs discard disposable DB/outbox data. Use `-KeepArtifacts` to preserve it or `-NoBuild` after a successful build. No existing database is modified.

Verified on Windows on 2026-10-09: build with zero warnings/errors, **1,034 protocol/admission/replay checks** including 1,000 malformed-packet fuzz checks, **138,509 BattleServer assertions**, and **74 live MongoDB/HTTP/protobuf/UDP checks**. The live run includes malformed probe rejection, a two-peer match that pauses and resumes through a rotated UDP grant, idempotent reconnect-request retry, old-session revocation, and authenticated fetch/ack of unscored terminal evidence across two BattleServer process restarts. The durable terminal snapshot is checked byte-for-byte against the UDP result. These are console test executables; invoke them with `dotnet run`, not `dotnet test`.

## Manual development

`.env.example` documents configuration; .NET does not load that file automatically. In both process shells set the same randomly generated base64 32-byte `Battle__SigningKey` and a second, distinct `Battle__ControlKey`. The signing key protects player UDP sessions; the control key authenticates allocator, reconnect, cancellation, allocation-read, and result operations. Set `ASPNETCORE_ENVIRONMENT=Development` only for local HTTP testing. Start MongoDB at localhost:27017 as a replica set and initiate it before launching the Backend; set `Mongo__Uri` to its replica-set URI (for example `mongodb://127.0.0.1:27017/?replicaSet=wfDev`).

```powershell
$env:ASPNETCORE_ENVIRONMENT='Development'
$env:ASPNETCORE_URLS='http://127.0.0.1:8080'
$env:Battle__SigningKey='<same generated base64 key in both shells>'
$env:Battle__ControlKey='<same second generated base64 key in both shells>'
$env:Legacy__ContentPath=(Resolve-Path 'Server/content/recovered-battle-content.json').Path
dotnet run --project Server/src/War.Backend --no-launch-profile
# Second shell, same two keys:
dotnet run --project Server/src/War.BattleServer --no-launch-profile
```

The BattleServer also listens on a loopback-only match-control port (default UDP port + 1, configurable with `Battle__ControlPort`). Its HMAC-authenticated `/internal/matches` registration and reconnect contracts are documented in [BattleServer provisioning](docs/BATTLE_SERVER.md). The Backend delivers roster-bound grants through authenticated matchmaking and `POST /v1/battle/reconnect` rotates one player's grant during a running match. Normal Unity two-client integration remains open.

Protobuf endpoints: POST `/v1/accounts/register`, POST `/v1/accounts/login`, GET `/v1/player`, POST `/v1/network/connect`. Use `Content-Type: application/x-protobuf`; authenticated calls require `Authorization: Bearer <token>`. See `protocol/war.proto` and `War.Client`. These endpoints do not implement the stock client's legacy PHP/JSON contracts or its full PlayerData.

## Legacy channel for the recovered 1.4.0 client

The recovered Unity client speaks its own channel, served from `src/War.Backend/Legacy/` at
`POST /index_09_25_2015.php` (a form POST whose `requestId` selects the action) and `GET|POST
/check.php`. It runs alongside `/v1`, which stays the new protobuf API.

Actions `GameStartedMaster` (64) and `GameStartedClient` (65) additionally support a scoped,
read-only loading acknowledgement for published self-hosted random PvP assignments. They require
the exact current `BattleId`, source transport flags and source dog-tag policy assertions, and
return `Time`/`BattleId` only after checking the current pair, frozen manifest and issued assignment.
They do not create a battle, charge entry twice or grant rewards. Bot, Arena and friend starts remain outside
this adapter. Trusted map ID/revision delivery now replaces the Photon map-selection wait and both
normal Unity participants load the assigned City scene. Entry still fails at the prototype admission
deadline before readiness is accepted. See [map assignment](docs/BATTLE_MAP_ASSIGNMENT.md) and
[entry evidence](docs/CLIENT_LOBBY_BOOTSTRAP.md).

Implemented: **85 of 175 named actions.** The boot chain — reachability, `GetConfigurations` (157),
`CreateAccount` (118), `LoginToCustomAccount` (30), `GetPlayerData` (34), `GetAllMessages` (5) and
`SetPlayerStatus` (29); transactional idempotent replay of 25 of 29 buffered actions
(`WeaponWasShown` 104, `ArmyUnitWasShown` 105, `VisualWasShown` 191, `EquipWeapon` 116,
`UpdateEquippedUnits` 1003, `BuyWeapon` 76, `BuyUnit` 80, `BuyWeaponUpgrade` 73,
`ActivateWeaponUpgrade` 75, `InstantWeaponUpgrade` 74, `BuyUnitUpgrade` 77,
`ActivateUnitUpgrade` 79, `InstantUnitUpgrade` 78, `ActivateWeapon` 128, `InstantBuyWeapon` 126,
`ActivateUnit` 127, `InstantBuyUnit` 125, `PromoteUnit` 158, `BuyDecal` 109, `EquipDecal` 110,
`UpgradeEliteSlot` 209, `ConvertPartsToScraps` 208, `ConvertScrapsToParts` 207, `BuyCardPack` 97,
`SaveLastSeenSquadChatTimeStamp` 193 —
13 of the economy actions priced from the real recovered catalog, including a full timed-delivery
state machine for both upgrades and base purchases, and a server-owned RNG card-pack reward
reproducing the client's own level-interpolated rarity algorithm) via
`SendRequestBuffer` (98) and the `Buffers` field on `GetPlayerData`; the tutorial handoff
(`GameStartedTutorial` 119, `TutorialEnded` 120); the dog-tag energy economy (`RefillDogtags` 70,
`PayOneDogTag` 129 — the latter is a consumption penalty, not a purchase, despite its name); and 26
catalog-free profile/telemetry actions (`UpdateDeviceToken` 13, `ChangeLanguage` 150,
`ChangePlayerCountry` 196, `UpdateSettings` 165, `ChangePlayerName` 139, `GetPlayerInfo` 170,
`UpdateArmyPower` 192, `UpdateRegionPings` 140, `PhotonIsFull` 143, `SendLog` 166, `Test` 167,
`SendCrashReport` 141, `ErrorMessage` 92, `UpdateAnalytics` 179, `OnVIPExpired` 195,
`ReportCheater` 197, `SaveFuseConfigs` 1014, `SpecialOfferShowed` 1007 and `WarArenaShown` 212 (two
more logged-only presentation facts, re-examined out of the payment-blocked and Battle-dependent
buckets respectively — neither response reader consumes anything from the server), and the seven "shown once" flags
`ChatShownFirstTime` 163 / `CustomizationShown` 168 / `WarpathShownFirstTime` 169 /
`CardpoolShown` 180 / `LeagueLeaderboardShown` 182 / `CraftingShown` 183 /
`ElitesFeatureShown` 213); and a Squad **membership, management, invite/request and card pool**
vertical — `CheckUniqueSquadName` (41), `CreateSquad` (37), `JoinSquad` (38), `GetSquadDetails`
(45), `GetAllSquadMembers` (44), `LeaveSquad` (49), `PromotePlayer` (55), `DemotePlayer` (58),
`PromotePlayerToFounder` (57), `KickPlayer` (172), `UpdateSquad` (131), `UpdateSquadEmblem` (63),
`GetSquads` (56), `FindSuggestedSquads` (81), `InvitePlayerToSquad` (59), `JoinSquadRequest` (132),
`AcceptSquadJoinRequest` (133), `DeclineSquadJoinRequest` (181), `GetFullSquadInfo` (151),
`DepositCards` (174), `WithdrawCard` (175) — backed by a new `LegacySquadStore`/
`LegacySquadDocument` Mongo collection, re-scoped from "deprioritized" once every
Battle-Server-dependent, payment-blocked, RNG-deferred and untraceable-content action was
exhausted. `CreateSquad`'s price is real and escalating (`(squadCreationsCount + 1) *
WarBucksCreateSquadPrice`, verified 50,000 Warbucks), not flat or invented; rank/settings actions
are gated on the caller holding `SquadRank.Leader`/`Coleader` in their own squad; the invite/request
flow tracks pending invites/requests directly on the squad document rather than needing the
message/inbox system "skip Social" already covers, since none of those four actions' response
handlers actually read anything back from a delivered message; the card pool turned out to live on
each squad member's own player record (not a separate structure), with a real, server-owned
`WithdrawCard` cooldown (`Google2u.Constants` `CardWithdrawTimer`, verified 240 seconds).
`NotifyPlayerToDeposit` (178) rounds out the card-pool pair as a third direct action — it shares its
`ServerResponseHandler` success case with `UpdateArmyPower` (logged only, nothing read back), so the
only real validation left is that the target is genuinely a squadmate.

`CraftCard` (176) and `ClaimCraftedCard` (177) are two more direct (non-buffered) actions: three
same-rarity cards go in, and after a real `Google2u.Constants` duration
(`CardCraftTimeSilver`=30min for a Bronze craft, `CardCraftTimeGold`=60min for a Silver craft — the
constant names the *output* tier, not the input) a random higher-rarity card comes out, reusing
`BuyCardPack`'s own RNG-by-rarity-pool machinery (`PickCard`/`CardPoolsByRarity`, promoted to
`internal` for this reuse) rather than duplicating it.

`SaveLastSeenSquadChatTimeStamp` (193, in the buffered list above) was re-checked out of the owner's
"skip Chat" scope: it's a read-receipt timestamp for a squad-chat unread badge, not a chat message
itself, matching the same precedent already accepted for `ChatShownFirstTime` (163) — the recovered
enum has no message-send/receive action at all, so no real chat-transport feature is being built
here. It patches just the one field of the otherwise-unmodeled `PlayerAnalyticsData` blob it needs,
the same targeted approach `SetAnalyticsFlag` already uses for the "shown once" flags.

**The Google2u economy catalog is now loaded** (`Legacy:ContentPath`, pointing at
`Server/content/recovered-battle-content.json` — the same file the Battle Server exports map
geometry into) and covers **essentially the full weapon and unit roster**, not just a sample: base
prices/unlock levels (`WeaponUpgrades`/`ArmyUpgrades`) and, separately, per-item upgrade-level
tables (one sheet per weapon/unit, e.g. `AssaultRifle_AK47` 26 rows, `DBUpgradeSlotsAssaulter` 136
rows) with `NEXTUPGRADEPRICE`/`NEXTUPGRADEPRICEGOLD`/`DELIVERYTIME` per level. `ChangePlayerName`'s
rename price, `BuyWeapon`/`BuyUnit`'s pricing/unlock-gating, and the weapon/unit upgrade delivery
lifecycle are all priced from these real, verified numbers; starter balances default to the
catalog's `StartingGold=75`/`StartingWarbucks=15000`/`DogTagCap=5` rather than fabricated
placeholders. Every other action returns `ServerMaintenance` and logs, because a hollow `Success`
would send the client into a handler that indexes response keys it did not receive — most
remaining economy actions now have a clear unblock path (see `docs/CLIENT_COMMUNICATION.md`) but
aren't wired one by one yet. See [the active server backlog](../todo-list.md) for the current Backend/Battle Server work;
`todo_list.md` remains historical.
This is not a playable game backend: no battles, Squad Wars/leagues/arena, most real purchases, and
no leaderboard-style Squad search by XP (meaningless without real battle-derived stats).

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File Server/scripts/LegacySmoke.ps1 -MongoExecutable 'C:\Program Files\MongoDB\Server\8.3\bin\mongod.exe'
```

Verified on Windows against live MongoDB: **339 base HTTP assertions**, 45 squad and 28 account HTTP assertions, plus targeted buffered
transaction/fault scenarios covering the exact wire shapes the
shipped client parses — the DynamoDB AttributeValue encoding of `Player`/`PlayerData`, bare
top-level `Result`/`Time`, the `"ok"` probe body, the semicolon-delimited configuration stream,
session rotation, rejection of stale/forged/cross-bound tokens, buffered-request idempotency
(replaying the same buffer id/index returns the recorded result rather than re-applying it, for
both the direct `SendRequestBuffer` path and buffers carried on `GetPlayerData`), and the
`GetPlayerInfo` case where the client indexes a top-level response key directly and so requires an
explicit JSON `null` rather than an omitted key for an unknown player.
`docs/CLIENT_COMMUNICATION.md`
records the evidence for each shape.
Buffered account changes and complete replay responses now commit together; boot projects the
returned committed account. Strict envelope validation rejects malformed input before execution.
Pure buffered calculations now live in `Legacy/Buffering`; the coordinator owns persistence/replay.
BuyDecal success always includes its required identity/expiry, including owned no-ops and bound
historical replay. [Buffer contract tests](docs/LEGACY_BUFFER_CONTRACTS.md) execute the actual recovered
callback/value parser without cloning a Unity project. All 126 current literal server result
dispositions now have first-delivery/current-authority replay checks using small test fixtures.
Full gameplay, catalog/state validation and the complete action inventory remain explicit follow-up work.
The catalog now publishes immutable rows and reviewed identity indexes, rejects malformed/duplicate
authority, and validates consumed price/duration domains before use. Configured startup also checks
current dependency sheets/constants, source field types/counts/identities and exact reviewed snapshot
bytes. Typed upgrade lanes enforce recovered weapon, current-tier and Elite limits; completion needs
owned current state and matching active delivery before a charge or increment.
[Catalog validation](docs/LEGACY_CATALOG_VALIDATION.md) documents remaining source-value reconciliation
and the unresolved V07 scene-provenance mismatch.
Purchase and promotion gates now compare displayed rank (`Level + 1`) with catalog requirements,
matching the recovered Client. This fixes delayed unlocks and previously unreachable final-tier gates.
Dog-tag mutations now preserve source penalty debt, include VIP in refill price/fullness and publish
against current session/revision authority. Boot uses one validated Time for dog-tag projection and
UTC midnight. See [dog-tag publication](docs/DOG_TAG_PUBLICATION.md) for source rules and retry limits.
Typed stored state now rejects numeric-string coercion, present nulls, duplicate/case-shadowed fields
and required null containers while retaining permitted unmodeled metadata. Complete Settings updates
preserve current metadata and bind session/revision authority. Root wallet/rank/tier counters now
require exact persisted BSON integers, and shared readers/transactions reject damaged authority.
New accounts use the recovered one-match placement constant; Army Power is bounded before the
Client's signed-Int32 times-ten calculation. Historical invalid records require reviewed migration. See
[stored state validation](docs/STORED_STATE_VALIDATION.md) for verified scope and remaining C13 work.
Five direct profile mutations now have feature-owned parsing and persistence, current-session/
revision predicates, exact device/locale tuples and one source-priced name/count/Gold publication.
Malformed heartbeats remain callback-safe without refreshing presence. Status and LastAction join
the twenty required exact root BSON numeric fields. See
[profile publication](docs/PROFILE_PUBLICATION.md) for source callbacks, forced races and nonce limits.
Shown-once analytics flags now patch current validated state with session/revision guards, preserving
other flags, buffered chat updates and exact metadata. Invalid present JSON is refused without reset;
repeated true flags perform no write. See [analytics publication](docs/ANALYTICS_PUBLICATION.md) for
the shared field contract and remaining progression/receipt boundaries.
The tutorial handshake now retains one versioned battle ID through completion, with atomic
session/revision-bound mirrors and read-only replay. Old completion without a retained ID remains
readable but cannot authorize a new terminal replay. See
[tutorial publication](docs/TUTORIAL_PUBLICATION.md); no combat/economy rewards are inferred.
See [buffered economy publication](docs/BUFFERED_ECONOMY_PUBLICATION.md) for the non-expiring replay
policy and historical receipt limitations. See [account publication](docs/ACCOUNT_PUBLICATION.md),
[card pool publication](docs/CARD_POOL_PUBLICATION.md) and [squad publication](docs/SQUAD_PUBLICATION.md)
for their transaction, validation, replay and verification boundaries.

To point the client at this server, change only the host in its `BeanstalkUrlCreator`; the paths
already match. Configure starter state under `Legacy:Starter` — it is authoritative, and the
client's own `StartingGold`/`StartingWarbucks` assertions are discarded. Starting options are frozen
and validated before database initialization. Set Legacy__ContentPath for source-backed gameplay.
Only an explicit Legacy__AllowCatalogFreeStartup=true permits omission for connectivity/profile
testing; catalog-dependent mutations stay closed. A configured missing, malformed or empty source
always fails startup. Shared port/key rules and immutable limiter/content options are described in
[Backend startup policy](docs/BACKEND_STARTUP.md). Serving the legacy channel
over plain HTTP requires `Legacy__AllowInsecureHttp=true` and logs a warning; it exposes
credentials and session tokens, so use it only on an isolated offline network.

## Linux without containers

Install the .NET 10 runtime and MongoDB natively. A Linux smoke script is provided:

```bash
bash Server/scripts/smoke.sh
# Override MONGOD if the executable is not on PATH.
```

It also needs curl and openssl. Linux-x64 publish succeeded from Windows:

```sh
dotnet publish Server/src/War.Backend -c Release -r linux-x64 --self-contained false -o Server/artifacts/linux/backend
dotnet publish Server/src/War.BattleServer -c Release -r linux-x64 --self-contained false -o Server/artifacts/linux/battle
```

The Battle test executable and standalone Battle Worker ran under Ubuntu 22.04 WSL2; this does not verify a production Linux host. Copy artifacts to `/opt/warfriends/backend` and `/opt/warfriends/battle`; the `deploy/*.service` files are systemd templates for a dedicated unprivileged `warfriends` user. Install the .NET runtime for the framework-dependent units, and supply restricted `/etc/warfriends/backend.env` and `battle.env` files. The battle unit creates `/var/lib/warfriends-battle` and defaults `Battle__ResultOutboxPath` to its `outbox` subdirectory so terminal evidence remains writable under `ProtectSystem=strict`. Keep any path override inside that writable state directory. Do not copy development secrets.

Production must use HTTPS. The backend rejects non-HTTPS game requests outside Development. Configure Kestrel with a real certificate using `ASPNETCORE_URLS=https://0.0.0.0:8443` plus `Kestrel__Certificates__Default__Path`/`Password`, or explicitly configure a trusted proxy/TLS arrangement before deployment. Forwarded headers are not trusted by default. Keep Mongo private and authenticated. Set `Battle__PublicHost` to the advertised host, `Battle__BindAddress` to the appropriate local interface, and open only the chosen UDP port. Health endpoints are `/health/live` and `/health/ready`.

## Unity integration boundary

`War.Client` and `War.Shared` target .NET Standard 2.0 and are tested by the smoke client. Unity integration requires the .NET 4.x/compatible .NET Standard profile and the matching Google.Protobuf dependencies; the original Unity 5.2 legacy profile is not compatible. Do not copy arbitrary dependency versions into the currently recovered project.

No client scenes, prefabs, scripts, or Photon DLLs were removed or altered in this server checkpoint. The SDK is ready for an isolated Unity integration scene; replacing the existing game's 165 RPC definitions and 398 view attachments requires the staged migration in the audit. Neither a successful console handshake nor a Linux publish proves Unity gameplay compatibility.

## Design references

- [Official MongoDB C# driver](https://www.mongodb.com/docs/drivers/csharp/current/get-started/)
- [Protobuf C# generated code](https://protobuf.dev/reference/csharp/csharp-generated/)
- [Microsoft: native Linux hosting with systemd](https://learn.microsoft.com/en-au/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-8.0)

Package versions are pinned in project files and NuGet lockfiles. Keep `War.Infrastructure` server-only; it contains ticket-signing capability and must not be distributed with Unity.
