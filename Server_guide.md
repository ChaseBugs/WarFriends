# WarFriends Server implementation guide

Client-derived specification and implementation roadmap, inspected 2026-09-19.

## 1. Scope and evidence

The owner confirms Client recovery is complete. This document describes the Server needed to support its existing behavior. The active reference is **WarFriends 1.4.0**, `Clients/ExportedProject`, including its gameplay scripts, Google2u sheets, scenes, prefabs and serialized settings. Do not substitute later 1.6.0/4.9.5 rules or counts. `DecompiledCSharp` and original assemblies are secondary fidelity references; quarantined sources are not runtime dependencies.

This guide combines inspected source contracts with a **proposed** server design. Source facts, current code, and proposed DTOs are distinguished. It is a development specification, not a claim that every feature is implemented or that all original production rules are recoverable. Static extraction inventories help locate contracts; they do not prove every branch has been reviewed. Before implementing an action, inspect its caller, builder, parser, failure handling, and relevant serialized content together.

Authoritative source indexes:

- [Client communication analysis](Server/docs/CLIENT_COMMUNICATION.md).
- [Machine-readable communication inventory](Server/docs/client-communication-inventory.json): action references, request builders, response consumers, RPC signatures, serialization locations and asset attachments.
- [Architecture and accepted overrides](BACKEND_DESIGN.md).
- [Server runtime instructions](Server/README.md).
- Source appendices below cover all named actions, direct request-builder candidates, response-reader keys, serialized subsystem field declarations, RPC definitions and stream locations.

## 2. Architecture and responsibility boundary

Use the accepted .NET 10 ASP.NET Core Backend, separate .NET 10 Battle Worker, MongoDB, and protobuf. Run native processes on Windows for development and Linux for production; no Docker. Shared protocol/Client SDK target .NET Standard 2.0. Do not assume the Client can reference .NET 10 assemblies.

| Component | Owns | Must not own |
|---|---|---|
| Backend | Authentication, accounts, complete boot projection, catalogs, wallets, inventory, timers, missions, competitions, Squads, chat authorization, matchmaking allocation, durable result settlement | Per-frame Unity presentation or trusting player-reported rewards |
| Battle Server | Participant admission, match lifecycle, authoritative combat state, movement, weapons, AI, vehicles, cards, objectives, snapshots, reconnect, terminal match evidence | Direct Mongo wallet updates or unrestricted client RPC forwarding |
| Client | Input, animation, NGUI, effects, audio, prediction/interpolation, existing progression presentation and callbacks | Final ownership, prices, damage, score, win or reward authority |
| Shared protocol | Explicit portable messages, identifiers and stable enum mappings | Credentials for other sessions, database documents, UnityEngine types or Photon SDK |
| Background jobs | Expired deliveries/rentals, competition closure, inbox/outbox delivery, stale-match reconciliation, receipt processing | Resetting malformed state to reopen claims |

Use one Backend deployment initially, with logical domain modules. Split services only when operational needs justify it. Redis is optional, not a prerequisite. Mongo is private to Backend/jobs. Battle hosts call an authenticated internal Backend endpoint for assignment and settlement.

### Current working-tree checkpoint (code presence, not a new validation run)

- **Initialized animation continuation:** source collider initialization and ten rifle-related clips are exported into 159 immutable 30 Hz pose samples. A guarded Client alias repair restores `idle`/`run` from uniquely attached recovered suffix names. Server geometry passes 954 animated Unity ray comparisons; source blending/procedural aim and projectile scheduling remain outstanding. See [pose evidence](Server/docs/PLAYER_POSES.md).

- **Player collision continuation:** MainScene gameplay and preview collision rigs are exported separately. Server primitive intersections, immutable rigid placement, host-only target/part resolution and map occlusion pass source ray fixtures. Runtime initialization/animated stances and source projectile timing remain prerequisites for connecting normal firing to damage. See [collision evidence](Server/docs/PLAYER_COLLISION.md).

- **Player combat continuation:** the server-only health transition now preserves the recovered coefficient order, friendly-fire/immortality rules, damage refunds and lethal outcome. Full snapshots carry health/death plus within-tick revisions. It is tested through internal resolved-hit fixtures; normal Fire commands still await authoritative player hitboxes/projectiles and cannot apply damage. See [damage source mapping](Server/docs/PLAYER_DAMAGE.md).

- **Battle update:** up to 32 startup-provisioned two-player matches support signed admission, ready/countdown, finite ammo/reload, command receipts, reconnect key rotation, cover movement over recovered navigation paths and static map raycasts. A portable SDK and Unity adapter exist; the SDK passed inside Unity Mono. See [Battle Server implementation and tests](Server/docs/BATTLE_SERVER.md). Damage/death, weapon variants, AI/vehicles/cards, normal Unity battle-flow integration, production allocation and settlement remain unfinished; matches cannot award rewards.
- Existing `/v1` protobuf registration/login/profile/connectivity endpoints, Mongo account store, portable SDK, and authenticated UDP hello/ping/pong/disconnect.
- Newer working-tree legacy files serve `/check.php`, `/index_09_25_2015.php`, boot/login/player retrieval, an empty inbox, status, and buffered dispatch. Read `Server/src/War.Backend/Legacy/LegacyEndpoints.cs` and `LegacyBuffer.cs` for the actual boundary.
- Buffer allowlist currently names `WeaponWasShown`, `ArmyUnitWasShown`, `VisualWasShown`, `EquipWeapon`, `UpdateEquippedUnits`. Verify enum values from source: **DecalWasShown=108; VisualWasShown=191**. An older paragraph in the communication analysis incorrectly calls 108 VisualWasShown.
- Empty inbox support is not full messaging. Boot transport is not full starter/content initialization. A connectivity ticket is not matchmaking. A UDP tick loop is not combat simulation.
- Legacy and `/v1` have separate persistence implementations (`LegacyPlayerStore` versus `AccountStore`). Before integrating real gameplay, define one canonical player identity/state and migration path; never create two independent wallets for the same person.
- Existing claim-then-complete buffer receipts have a crash window. They must be upgraded to atomic state+receipt publication before enabling reward/economy mutations. An unresolved receipt must not become a second grant, but permanently losing a legitimate mutation is not executable-complete recovery either.
- Current starter defaults in code are reconstruction settings, not verified production data. Confirm rank indexing, starter inventory, dog-tag policy and all limits from the active Client before shipping.

No Client code is changed by this guide. Photon replacement requires a coordinated Client adapter migration; the Server alone cannot make the existing Photon Client speak the new UDP protocol.

## 3. Legacy transport and boot contracts

Read [BeanstalkServerManager.cs](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs), [ServerResponseHandler.cs](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs), [StringParser.cs](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StringParser.cs), and `DatabaseSerializedObjectGeneric.cs`.

1. Connectivity: sibling `check.php`, body exactly `ok`.
2. Configurations: action 157; raw semicolon-separated stream, not the normal JSON response.
3. CreateAccount 118 or LoginToCustomAccount 30. Login's exact fields are `AccountType`, `Id`, `Password`; this differs from the new `/v1` username API.
4. GetPlayerData 34 includes saved `Buffers`; resolve pending operations before publishing the authoritative boot view.
5. Follow-up inbox/config/subsystem callbacks must retain the Client's ordering. Tutorial start 119 and end 120 are separate transitions with a server-bound battle identity.

All normal legacy requests POST form fields to `index_09_25_2015.php`. Common fields: `requestId`, `Version`, `Os`, `SheetConfig`; header `App-Version`; authenticated actions use `PlayerId` and `Token`. The builder turns empty/null action values into literal `null`. This is action-specific legacy spelling, not permission to broadly coerce malformed input. The configuration builder also contains the distinct spelling `SheetConfiguraton`.

Normal responses have bare JSON envelope values such as `Result` and `Time`. The Client treats `Result > 10` as failure; do not send an error with an apparent success code. Nested Player/PlayerData use Dynamo-style `S`/`N` wrappers; `N` values are numeric strings. Exact wrappers differ across response families: no universal wrapper conversion.

| Response | Required directly indexed content found in boot reader | Notes |
|---|---|---|
| CreateAccount | Player, Token, Password, PlayerData, Time | Secrets are account-specific; never log them |
| LoginToCustomAccount | Player, AccountType, Token, Password | Follow-up GetPlayerData initializes remaining state |
| GetPlayerData | Time, PlayerData | Guarded optional fields may still be behaviorally necessary for playable content |
| GetAllMessages | Items array | Empty array is valid; omission breaks the consumer |
| GetConfigurations | Raw sections | Preserve section grammar/version handling |
| Buffer results | BufferId, RequestsResults | RequestsResults is a JSON array encoded inside a string; entries use plain fields |

Each of 16 `DatabaseSerializedObjectGeneric<T>` subclasses consumes a JSON blob stored under the T-name inside a Dynamo `S`. Missing blobs invoke defaults, but defaults are not evidence of server-owned starter entitlements. See the DTO appendix for exact class/field spelling. Keep `equippedID`, `boughtIndex`, `slotUpgradeindex`, and similar original casing at the adapter boundary.

### Buffered mutations

`RequestBuffer.requests` is a dictionary of request index to `{action,data}`; `data` is serialized content. Action 98 carries `BufferId`, `Count`, `Requests`; action 34 can carry multiple `Buffers`. Preserve request order and dependency between actions. Do not flatten inner data into arbitrary HTTP aliases.

For each entry: authenticate player; validate stable buffer identity/count/index/payload; bind an immutable payload digest; replay an existing receipt only if that digest agrees; load and validate authority; compute the transition; atomically publish state plus the exact response receipt; return `ActionId` and `Result` with the action-specific success or rollback fields. A reused id with altered contents must fail. Per-action failure must not escape the entire buffer or acknowledge unrelated entries as successful.

Rollback fields in `ServerResponseHandler.ProcessBuffer` include `LevelName`, `Weapon`, `InventoryData`, and `data`, depending on action/error. Derive them from current server state, not echoed failed input. Golden fixtures must cover each success and failure branch, including a purchase queued before equip and a retry after process termination.

## 4. Backend feature requirements

The IDs below are from the active Client enum. Some enum members are callback/result/debug identifiers rather than independently callable features; the complete appendix retains them without assuming public routes.

| Domain | Client actions / evidence | Required Backend behavior and DTO/content |
|---|---|---|
| Accounts and boot | 30,34,118,119,120,121,122; GameLoginManager, tutorial controller | Guest credentials, durable identity, session rotation/revocation, locale, full boot, rename/password transitions, tutorial receipt. AccountSession, PlayerBootstrap, TutorialState |
| Profile/settings/presence | 13,29,139,140,150,165,170,192,196 | Exact request fields; region diagnostics adapted without Photon Cloud, name policy and rename price, locale/settings, public profile, durable presence. Recompute ArmyPower from owned loadout; client value is diagnostic |
| Wallet and energy | 70,129; DatabasePlayer, DogTagManager, GameVariables | Gold/WarBucks/Tickets/Scraps and other source currencies, checked debits/credits, dog-tag countdown/refill/VIP interaction, one charge per admitted battle. Wallet, EnergyState, CurrencyTransaction |
| Weapon store/upgrades | 73-76,104,116,126,128 | Catalog-bound identity/index/category, unlock rank, purchase currency, delivery start/end, instant completion, activation, shown marker, equip ownership. LevelManagerData and InventoryData |
| Army and vehicles | 77-80,105,125,127,158,1003 | Unit unlock/purchase, ordinary/special upgrades, promotion, delivery, equipped lineup and capacity, authoritative combat loadout. Tanks/helicopters are vehicle units |
| Elite parts/scraps | 207,208,209 | Source conversion rates, eligible unit/elite stage, ownership and parts conservation, exact parts+WarBucks debit; no client-provided exchange-rate authority |
| Cosmetics | 108-110,168,191 | Categories/slots, purchase or parts unlock, equip, shown state, borrowing/expiry and fallback visual. DecalManagerData; distinguish decal and newer visual markers |
| War Cards | 97,174-178,180,183 | Pack grants, rarity/content, owned counts, deck/mission gates, squad pool deposits/withdrawals and permissions, crafting cost/deadline/claim, battle reservation and consumption. CardManagerData, CraftData, pool ledger |
| VIP, packs and offers | 114,130,135,136,138,142,189,190,195,1007,1013 | Entitlements, rentals and expiry, lootbox selection, receipt verification/replay/refund, offer eligibility and immutable quoted price. InAppData plus private receipts; missing production offers remain explicitly configured/disabled |
| Rewards and inbox claims | 91,156,161,1001,1002 | One-time reward keys, verified rewarded-video eligibility, calendar check/ordered claim, inbox receipt. Preserve typo `claimRweard`; enforce cooldowns and one atomic claim |
| Missions and heroic/co-op progression | 67-69,111; MissionsManager, MissionDefinition | Mission availability, map/objective/waves, completion flags by mode, attempts, heroic selection, stars/highscore, server-confirmed rewards and leaderboards. MissionManagerData |
| Daily/starter assignments | 112,149,171,173,185,186 | Source assignment IDs/targets, issue/reset/deadline, skip cost, trusted progress, completion/claim distinction, mega reward. AssignmentData, StarterAssignmentsData; do not trust submitted completed IDs |
| Achievements/statistics | AchievementsManager, StatsManager, GameEnded | Determine which achievements are local/provider presentation versus durable server rewards; trusted counters for shots/hits/kills/spawns/vehicles/crates/cards/mission outcomes. Do not invent an achievement claim action absent a caller |
| Ranked PvP/Player Leagues | 62,64,65,106,107,152,182,198 | Admission, placement, medals/league division, bounded rankings, win streak, score/reward settlement, season closure and last-season view |
| Instant Battle/offline PvP | 199; GameControllerDeathMatchOffline | Separate instant-battle action from simulated offline PvP. Validate charges/cooldowns/paid branch, bot definition, exact mode reward policy and receipt; neither can become arbitrary client-win rewards |
| War Arena | 200-206,211,212; WarArena, WarArenaConfig | Event schedule/rules, entry Tickets/Gold, runs/wins/lives/opponent restrictions, hearts, scraps/rewards, leaderboard/flawless/top run and terminal receipts |
| Squad membership/admin | 37,38,41,42,44,45,49,55-59,63,81,101,131-133,151,172,181 | Unique identity, rank gates, creation fee, leader/officer permissions, invitations/request queues, acceptance, kicks/leaves/promotions/founder transfer, public/private settings, emblem, roster and stats |
| Squad Wars | 124; SquadWarManager, SquadWarsContent | Timed divisions of competing squads; aggregate trusted member Squad Points, rank squads/members, promotion/demotion, participation and reward receipts. This is not evidence of a dedicated simultaneous team-v-team arena |
| Squad Events | 113,160; DatabaseSquadEventDefinition/Progress | Server-configured event/tier/assignment/reward state, membership eligibility, trusted shared progress, join and notification, per-member claims when source-supported |
| Social/challenges/hit list | 2,3,4,12,26,84-89,148,184,194 | Player search/privacy, challenge capability bound to inviter/invitee/mode, hit-list limits, inbox read/ignore/show state, reports and moderation. Player lookup does not authorize a room join |
| Chat | Chat.cs, ChatBanManager,193 | Authenticated WSS, public/squad channels, membership checked on subscribe/send, ordered history, bans/mutes, limits, reconnect cursor and last-seen timestamp |
| Config/telemetry | 141,143,157,163,166,179,1007,1014 and other shown flags | Versioned config, bounded diagnostic ingestion, no debug/Fuse/analytics fields may grant gameplay state; redact tokens/passwords |
| Social-provider compatibility | 52-54,146,154,164,187,188,1005,1008,1009 | Facebook/Google Play/Game Center integration remains explicitly out of scope under repository guidance; retain safe unavailable responses, no fabricated provider authentication |
| Debug/admin-only actions | Debug*, MaxAll, Test, Kick/removal variants requiring review | Never expose cheat mutations because the recovered Client can send them. Classify exact consumer before enabling an operator-only tool |

### Squad gameplay detail

`DatabaseSquad` carries squad identity/emblem/message, public status, skill requirement, size, rank, levelExperience, squadPoints, roundId/division and accumulated statistics. `SquadWarManager` sorts squads by points, then rank/name; members by points, then level/name. `SquadWarsContent.ToBattleClick` opens BattlePreparation. Rewards are displayed by squad tier/division and member contribution brackets. Preserve these concepts; recover concrete table rows and server season timing separately. Do not turn the absence of old production scheduling into an invented claim that a fixed schedule was recovered.

Membership changes must atomically reconcile player membership, roster, pending invitations, chat authorization, card-pool access and active competition eligibility. An officer cannot replay an old authorized request after losing rank. Handle founder transfer explicitly; avoid orphaned squads or two leaders.

### Reward ownership detail

The original `GameEnded` sends Experience, boxes, bonuses, UsedCards, ObtainedCards, Stats, assignment updates and SquadEventUpdate. These describe the old trust boundary. In the replacement they are assertions/diagnostics; trusted Battle evidence owns results. TutorialEnded likewise cannot grant its submitted Gold/Warbucks. Issuing a battle must freeze relevant loadout and catalog revision so a concurrent shop upgrade cannot change already-running combat.

### Exact request/DTO pitfalls to implement first

| Contract | Verified Client detail | Consequence |
|---|---|---|
| Profile status / device / country | `PlayerStatus`; `DeviceToken` plus `Locale`; `NewCountryCode` | Bind the exact fields; do not let friendly aliases bypass validation |
| Squad creation versus update | Create sends `SkillRequirement`; update sends `RequiredMedals` | These are different builders; validate and map at the action adapter |
| Account creation | `Locale`, `UtcOffset`, optional starting-currency assertions | Validate locale and invariant finite offset; server controls starter balances and UTC time |
| Daily rewards | action 1002 sends `claimRweard`; `DailyRewardMonthScreen.DailyRewardSerwerData` exposes month/year/dayRewards/lastClaimed/toClaim | Preserve spelling and source parser mapping; do not replace it with a later calendar DTO |
| Instant Battle 199 | Paid dialog sends `IsPaid` containing a Gold price string, not a Boolean | Absent and paid price branches differ; derive price and capacity server-side |
| Arena entry 200 | `EnterArenaRequest.Send` includes `UsedGold` only when positive | Absent does not mean an arbitrary malformed value can be coerced to free |
| Arena entry response | `WarArenaData` is directly read; `Tickets`/`Gold` are interpreted as spent amounts | Distinguish transaction deltas from total wallet balances |
| Arena expiry 211 | `WarArenaEndedRequest.Send` supplies `ArenaId`; response may carry `Scraps` and `NewArena`; WarArenaNotFound error reads `WrongId` | Bind old/new event identities and source-specific failure payload |
| Arena revival | `hearthPrice` and `HeartDialogShown` appear in separate builders | Preserve spelling and exact integer/Boolean grammar; price remains assertion |
| Weapon indexes | `InventoryData.slots` stores `SerializedSlotDetail{name,weaponIndex}`; battle EquippedWeapon adds upgrade and enabled | Bind name/index/category to one ordered catalog, not independent user-selected values |
| Unit upgrades | Custom Photon type 90 serializes normal/special/elite indexes, HP/damage scales and flags | New loadout carries validated indexes; server derives scales |

Freeze both request and response fixtures for these cases before expanding generic DTO helpers. Add failure fixtures to prove the Client does not apply a reward twice or roll back to a fabricated state.

## 5. Content that must be extracted

Google2u `*Row.cs` files describe schemas; numeric content may live in serialized components in scenes/prefabs. Extract both schemas and values. `LevelManager` ordered lists also determine integer identities: sorting by filename can silently change weapon/unit indexes. Read asset GUID/fileID bindings and maintain a revisioned identity manifest.

| Content family | Evidence to inspect | Output and validation |
|---|---|---|
| Ranks/unlocks | Levels, LevelManager, feature unlock consumers | Zero-based source rank index versus display index+1; rewards/XP thresholds and feature gates |
| Weapons | WeaponLevelsSetup, per-weapon Google2u rows, WeaponUpgrades, AmmoSetup | Ordered IDs, stage prices/durations, clip/ammo, cadence, reload, damage, accuracy/critical behavior and category |
| Units/vehicles | LevelBehaviour, UpgradeSlots, DBUpgradeSlots* including Tank/Helicopter, behavior definitions | Ordered IDs, HP/damage, normal/special/elite progression, spawn rules and AI parameters |
| Cards | CardManager, card effects, card/crafting/pool sheet schemas | Identity, rarity, cost/count, targeting, cooldown, effect duration, stacking/expiry and mission gates |
| Visuals | CamosManager, PlayerVisuals, slots/categories | Asset-to-id mapping, prices/parts target, defaults, rental and equip constraints |
| Missions/maps | MissionsManager, MissionDefinition, mission/bot subclasses, scenes | Objective graphs, waves, spawn/cover points, navigation, blockers, destructibles, reward/score definitions |
| Competitions | MatchMakingConstants, leagues, SquadLeaderboards, SquadWarsReward, WarArenaParameters/config | Selection bounds, placements, reward brackets, event rules; separate dynamic production policy from shipped defaults |
| Progress/rewards | TaskDefinitions, AssignmentDefinitions, StarterAssignments, VIP, pack/reward consumers | Target evaluators, one-time IDs, reward rows, timers, entitlements and supported empty/disabled configuration |

For every extracted artifact record client version, source path, source SHA-256, asset GUID/fileID if applicable, row order, source field names/types, units, revision hash, and unresolved entries. Validate finite values, integer widths, unique IDs, referential integrity, monotonic stages where required, and completeness against the active source. Freeze accepted data before gameplay access. No later-version hardcoded row counts are authority for 1.4.0.

## 6. Battle Server requirements

### Modes and lifecycle

Solo campaign already simulates AI locally (`GameControllerCampaign` enables Photon offline mode). It can retain that Client-side simulation while Backend owns progression and reward policy; Battle Server hosting is not required for solo play. The shipped Missions table contains 75 rows over five map stages. Local Photon API replacement remains necessary to remove Photon. The Battle-host campaign/AI items below apply to shared co-op or an explicitly chosen future server-verified simulation, not a requirement to move every solo mission into this Worker.

Recovered `GameController.GameType` values: Campaign=2, Coop=4, DeathMatch=8, DeathMatchOffline=16, WarArena=32. Tutorial has a dedicated controller/start/end flow; do not assign it a recovered enum value that does not exist. End reasons: None=0, Killed=1, Win=2, WinByForfeit=3, Forfeit=5, Kia=8, MissionFailed=9, MissionSuccess=10. Keep a mapping layer between these numbers and new protobuf enums.

Proposed lifecycle: `Allocated -> WaitingForParticipants -> Loading -> Ready -> Running -> Ending -> Settled -> Closed`, with explicit cancelled/expired/aborted outcomes. Every transition has a server deadline, accepted participant set and idempotency key. No play before map/catalog agreement and admission. Handle disconnect during loading, reconnect during play, opponent forfeit, simultaneous terminal events, rematch, worker crash and duplicate result delivery.

Ranked matching currently filters rank, league, medals, ArmyPower and win/loss streak in `RoomConnectionRandom`; War Arena filters current wins and previous opponents. Reconstruct eligibility from authoritative Backend state. Region/latency observations remain hints. Original minimum-master-FPS logic exists because a player hosted; it is not a dedicated-server authority requirement.

### Simulation work packages

| System | Client evidence | Battle implementation and observable outputs |
|---|---|---|
| Scene/entity identity | PhotonView, PhotonLevelView, PhotonLevelIDChanger, view attachment inventory | Stable entity ID + generation, scene binding manifest, owner/team, spawn/despawn; retain original asset links in Client adapter |
| Player cover/movement | PlayerController, movement/cover helpers, PhotonTransform | Allowed cover transitions, movement speed/timing, aim/stance, collision bounds, authoritative transform and input acknowledgement |
| Weapons | PlayerWeapon, Weapon, burst/hold/click/swipe weapons, AmmoSetup | Equipped slot, fire/reload/cooldown/ammo, burst/spread, server RNG, hit validation, critical/over-time damage and source-specific weapon behavior |
| Projectiles/explosions | PhysicalAmmoWeapon, projectile/ammo/area components | Spawn velocity, travel/collision, radius/falloff, friendly-fire policy, impact and damage events |
| Health/destruction | MainGameEntity, AIObject, DestroyableObjectMultipleParts | Damage eligibility, HP/shields/statuses, destructible parts, death ownership and exactly-once kill credit |
| Army deployment | LevelBehaviour, UpgradeSlots, AI spawn/controller calls | Catalog loadout, capacity/resources/cooldowns, spawn eligibility, unit entity creation and actual spawn counters |
| Infantry AI | SoldierBehaviour definitions, soldier implementations | Target acquisition, cover/path navigation, firing, special abilities, death; source-specific state machines |
| Vehicles | Tank, Helicopter, AssaultHelicopter, AICar/Buggy/Transporter, drone/mech/turret families | Ground/air movement, paths, turret/cannon targeting, multiple damageable parts, passenger/drop behavior where present, destroyed-state events |
| War Cards | CardManager and individual card implementations/RPCs | Reserved inventory, activation conditions, valid targets, effect parameters, spawned units/modifiers, duration/stacking/expiry, consumption receipt |
| Missions/co-op | GameControllerCampaign/Coop, MissionsManager, Mission subclasses | Waves/objectives/timer, team participant rules, scripted progression, heroic modifiers, mission success/failure and stars evidence |
| PvP/Arena | GameControllerPVP/DeathMatch/WarArena | Correct victory/end conditions, rematch policy, Arena modifiers, anti-stall/timeout and forfeit policy |
| Statistics | StatsManager.MatchStats, SkillShot and objectives | Authoritative kills/hits/shots, deployed versus spawned units, destroyed vehicles, crates, cards, ribbons and play duration |

The recovered logic uses Unity physics/navigation/animation callbacks. A plain .NET Worker cannot directly run MonoBehaviours or Unity NavMesh. Extract portable gameplay state machines and map collision/navigation data, then compare against Client behavior. If a Unity headless simulation host is considered, document it as a separate architecture decision; do not quietly claim the current Worker provides Unity physics. Visual effects can remain Client-side, but any animation timing that controls damage/spawn must have an explicit server equivalent.

### Photon replacement and transport

The source inventory finds 165 RPC definitions, 173 literal RPC calls, 35 serialization occurrences, 98 core Photon-using gameplay files and 398 scene/prefab PhotonView attachments. These are static counts, not message coverage. Include dynamic cached calls, room/player properties and offline rooms in the migration.

- Translate each RPC into either a validated client command, a server-only event, a snapshot field, or a presentation-only local event. The appendix lists all definitions for this review. Never permit arbitrary method names or arbitrary object dictionaries from an untrusted sender.
- Keep separate channels: Backend HTTPS protobuf; legacy form/JSON during migration; combat UDP protobuf; chat WSS protobuf; internal authenticated host-control/result calls.
- Existing 1,200-byte authenticated datagrams, replay window and 30 Hz loop are a foundation. HMAC provides integrity/authentication, not encryption. Avoid sending passwords/tokens/private data over combat packets. Decide reviewed encryption/key-rotation policy before public deployment.
- Add bounded reliable command/event delivery, sequence acknowledgements, retries/timeouts and deduplication. Snapshot updates can be sequenced/unreliable. ACK fields alone implement no reliability. Separate packet sequence, command identity and simulation tick.
- Snapshot protocol needs baseline/full-state recovery, chunk bounds, last processed input, entity generation, interest filtering, interpolation and reconnect cursor. Do not depend on oversized fragmented UDP packets.
- Validate ticket match/player/server/purpose/expiry, bind session keys and participant slot, reject session reuse in a different match, cap packets/bytes/commands/entities and rate-limit before expensive work.
- Preserve local campaign/tutorial through the replacement adapter; original offline Photon rooms are still dependencies. Remove Photon only after online, offline, chat, serialization and scene bindings have replacements.

## 7. DTO design for new protobuf channels

Names below are **proposed contracts**, not existing Client wire names or implemented messages. Existing messages in `Server/protocol/war.proto` remain the connectivity/account baseline. Do not renumber their fields. Domain DTOs must project into the exact legacy responses until an authorized Client migration replaces those consumers.

Use `int32` for recovered C# int fields, `int64` for long counters/timestamps when the source supports them, and explicit strings for opaque IDs. Convert anti-cheat wrappers such as ObscuredInt into validated scalar values at the boundary. Use presence (`optional`/message/oneof) where absent differs from zero/false; reject unknown enum values at authority boundaries. Bound all repeated/map/string/bytes values. Reserve deleted field tags and names. See the official [protobuf evolution guide](https://protobuf.dev/programming-guides/proto3/).

| Proposed DTO | Fields / nested records | Owner and validation |
|---|---|---|
| RequestContext | request_id:string, protocol_version:uint32, expected_revision:int64 optional | Player derived from session, not trusted request PlayerId; stable request identity |
| PlayerBootstrap | player, wallet, energy, inventory, army, cards, visuals, progression, missions, arena, squad summary, inbox cursor, catalog_revision, server_time | Consistent authoritative revision; legacy projection uses source blob names |
| WalletState | gold:int64, warbucks:int64, tickets:int64, scraps:int64, revision:int64 | Validate adapter width and arithmetic; source balances never set by client |
| DeliveryState | item_id, bought_index, slot_id, start/end, activation_needed | Source ItemDelivery semantics; exact purchase/instant/activate transitions |
| LoadoutSnapshot | revision, catalog_revision, weapons[], units[], card_allowances[], visuals | Backend-authored immutable match input; indexes agree with source identity map |
| WeaponLoadout | source_id/index, upgrade_index, slot, enabled | Own/bought/delivered/equip/category validation |
| UnitLoadout | source_id/index, normal/special/elite indexes, special/elite flags | Server derives HP/damage multipliers; never accept a submitted scale |
| MutationResult | request_id, result enum, state_revision, typed updated state, typed rollback/error details | Receipt returned identically on retry |
| RewardGrant | grant_id, reason, currencies[], items[], source_receipt_id | Backend-only creation; generic public GrantReward route prohibited |
| SquadState | squad_id/name, emblem, message, admission, founder, rank, level_experience, members[], revision | Preserve source DTO projection; bounded queues and roster |
| CompetitionState | competition_id, kind, start/end, division, entries[], player eligibility, settlement_revision | Event-specific validation; no mixing Arena and Squad season identities |
| MatchRequest | request_id, mode, optional mission_id/heroic, optional challenge_id, loadout_revision | Backend resolves roster/rank/energy, mode authorization and opponents |
| MatchAllocation | match_id, mode, server_id, endpoint, participant-specific ticket/key, expires_at, map_id, catalog_revision | Grant returned only to bound participant; no other player's secret |
| MatchManifest (internal) | match_id, participants[], authoritative loadouts, map_revision, rules_revision, seed, deadlines | Backend -> Worker; not accepted from public Client |
| ClientReady | match_id, loaded_map_revision, protocol_version | Sender identity from admitted session |
| PlayerInput | command_id:uint64, client_tick:uint32, movement/cover intent, aim, buttons | Tick window and rate limits; aim is intent, not proof of a hit |
| FireCommand / ReloadCommand | command_id, weapon_slot, aim, client_tick | No damage/reward fields; authoritative ammo/cadence/ownership |
| DeployUnitCommand | command_id, loadout_slot, spawn_zone_id | No HP/unit price; enforce deployment and map rules |
| PlayCardCommand | command_id, card_instance/id, oneof target entity/position/side | Validate reserved quantity, effect-specific target and cooldown |
| EntitySnapshot | entity_id:uint32, generation:uint32, kind, position/rotation, hp, animation/state, owner/team | Server -> Client; bounded numeric values and versioned compression |
| WorldSnapshot | server_tick, snapshot_id, baseline_id optional, last_input_id, entities[], removals[] | Full snapshot recovery when baseline missing |
| BattleEvent | event_id, server_tick, oneof spawn/hit/death/card/objective/end | Server only; reliable ordering where effects depend on prior events |
| ReconnectRequest / ReconnectSnapshot | ticket/cursor -> manifest revision, phase, full state, unacknowledged reliable events | Rotated session, bounded grace, no reset of match rewards |
| BattleResult (internal) | match_id, host_id, manifest hash, terminal_id, start/end, outcome, participants[], trusted stats/card consumption, evidence digest | Authenticate assigned host; validate state and participant conservation before settlement |
| BattleSettlement | settlement_id, match_id, player revisions, rewards, progression changes, terminal status | Backend response; outbox retries independently of presentation |
| ChatSend / ChatMessage | request_id, channel_id, body -> message_id, sender summary, server_time, sequence | Membership, ban and length/rate checks; sender cannot impersonate |

Example proposed command schema (illustrative only; tags belong to these new messages):

```proto
syntax = "proto3";
package war.battle.v1;
message Aim { float x = 1; float y = 2; float z = 3; }
message FireCommand {
  uint64 command_id = 1;
  uint32 client_tick = 2;
  int32 weapon_slot = 3;
  Aim aim = 4;
}
message DeployUnitCommand {
  uint64 command_id = 1;
  int32 loadout_slot = 2;
  string spawn_zone_id = 3;
}
message CombatCommand {
  oneof payload {
    FireCommand fire = 1;
    DeployUnitCommand deploy = 2;
  }
}
```

Do not adopt gRPC solely because protobuf is selected. The existing SDK uses ordinary HTTP protobuf bodies; this avoids imposing native HTTP/2 requirements on the recovered Unity runtime. Validate any future gRPC transport against the actual Unity target; Microsoft documents [platform-specific gRPC limitations](https://learn.microsoft.com/aspnet/core/grpc/supported-platforms).

## 8. MongoDB authority and internal settlement

Proposed collections and required logical indexes (not a claim these already exist):

| Collection | Identity/index | Content and atomic boundary |
|---|---|---|
| players | unique playerId; unique normalized account name when used | Canonical account, credential hash, settings and player revision |
| player_state | unique playerId | Wallet, inventory, serialized progression, timers; bounded document size |
| sessions | unique tokenHash; playerId; expiresAt TTL | Auth binding/revocation; explicit expiry check even before TTL cleanup |
| operation_receipts | unique playerId+requestId or playerId+bufferId+index | Payload hash, committed result and state revision; transaction with mutation |
| catalog_releases/entries | unique revision and revision+kind+sourceId | Validated immutable content plus atomic active pointer |
| squads | unique squadId/name | Roster/settings/progression/revision; transaction with affected players |
| squad_memberships | unique playerId if normalized separately | Prevent simultaneous membership; never inconsistent roster mirrors |
| competitions/entries | unique eventId; eventId+divisionId+participantId | Schedule, admission, conserved score and terminal settlements |
| matches | unique matchId; status+deadline; participant indexes | Manifest, assigned host, admission and terminal settlement identity |
| inventory_reservations | unique matchId+playerId | Reserved cards/entry resource policy, consume/release state |
| purchase_receipts | unique provider+receiptId | Verification, grant and refund/reversal lifecycle |
| inbox/chat_messages | owner/channel+sequence; unique messageId | Reward claims separate from read state; bounded retention |
| outbox | unique eventId; nextAttemptAt+status | Committed notifications/results queued with transaction |
| job_leases | unique jobKey | Renewable lease + fencing token for scheduling ownership |

Mongo multi-document transactions require a replica-set/sharded deployment; standalone Mongo smoke tests do not prove cross-document economy safety. Use a native development replica set for transaction tests and appropriate replicated production deployment. See [MongoDB transaction requirements](https://www.mongodb.com/docs/manual/core/transactions-production-consideration/). No Docker is required.

Settlement transaction: authenticate assigned host; validate manifest and terminal outcome; check immutable match receipt; verify all affected player/squad/event state; derive rewards from frozen policy and trusted stats; consume reserved items/entry costs exactly once; apply wallet/progression/competition changes; insert receipt and outbox; mark match settled; commit. Duplicate identical terminal submission returns receipt; conflicting outcome is rejected and audited. Client `GameEnded` waits for/polls this result instead of authorizing settlement.

Use revision compare-and-set and transaction retry on fresh reads. Handle unknown commit outcomes by querying the immutable receipt. Validate time once per operation, use UTC server time, preserve Client signed widths, reject overflow/nonfinite counters and future invalid timestamps. Retention must not expire idempotency protection while an old request is still accepted.

## 9. Implementation order and acceptance gates

| Stage | Deliverable | Proof required before moving on |
|---|---|---|
| 1. Contract and content baseline | Freeze source identity/schema manifest; exact legacy action/response fixtures; classify unsupported/provider/debug actions | Every enum member classified; no invented default economy; source links resolve |
| 2. Complete boot and account | Canonical identity/state, source-backed starter inventory, tutorial handoff, session/profile/settings | Fresh account -> tutorial -> main menu -> restart with same state; exact Client callbacks |
| 3. Economy and buffer authority | Catalog importer, shop/delivery/equip, cards/crafting, visuals, VIP/energy and atomic receipts | Real Mongo transaction tests; concurrent spending, crash/retry, rollback branches and expiry |
| 4. Match admission + minimal combat | Backend allocation, one map manifest, two participants, ready/start/move/fire/damage/end | Two Unity instances complete one authoritative battle; forged win/damage rejected |
| 5. Full combat parity | Every weapon/unit/vehicle/card family, objectives, campaign/co-op/Arena/bots | RPC/stream migration checklist closed; source-based behavior fixtures and all relevant maps |
| 6. Durable progression | Trusted match settlement, assignments, missions, league/Arena/calendar/reward flows | Duplicate/malformed terminal results cannot double-grant; restart preserves pending work |
| 7. Squad/social systems | Membership/admin, chat, pool, events, Squad Wars and leaderboards | Concurrent join/kick/deposit/settlement, event-bound rewards, reconnect chat history |
| 8. Photon retirement + operations | All room/view/offline/chat dependencies migrated, Linux deployment and recovery | Unity scene/prefab/code audit; Windows and native Linux runtime smoke; Android and two-client loss tests |

Some work can be developed in parallel conceptually, but economy and result authority must exist before competitive rewards are enabled. A reasonable milestone is one complete vertical path before attempting all 175 named actions. Do not assign a completion date from inventory counts alone; physics/AI fidelity and missing dynamic content are the largest uncertainty.

## 10. Validation and deployment checklist

- Backend: golden legacy requests/responses, missing versus null, invariant numbers/booleans, typo/case preservation, direct and buffered paths, success/error rollback, session mismatch, unknown/debug action rejection.
- State: corrupt snapshots fail before writes; rank/ID/order/content revision checks; wallet overflow; duplicate and concurrent grants; crashes before/after receipt commit; timer/season boundaries; refund and debt behavior explicitly specified.
- Battle: duplicate/out-of-order/lost/delayed packets, unauthorized commands, replayed admission, reconnect/full snapshot, wrong map/catalog, excessive entities/projectiles, illegal movement/aim/ammo/card use, worker death and terminal result replay.
- Gameplay parity: weapon cadence/reload/damage, target types, cover/line of sight, unit spawn versus deployment click, tank cannon/turret, helicopter flight/drop/attack, each card effect and mission end condition.
- UI: actual recovered Client boot/tutorial/inventory/battle/results/Squad screens. HTTP smoke success alone does not prove correct initialization or NGUI behavior.
- Existing commands: `dotnet build Server/WarFriendsServer.sln`; `dotnet run --project Server/tests/War.Protocol.Tests`; native Mongo `Server/scripts/Smoke.ps1` or `smoke.sh`; `Server/scripts/LegacySmoke.ps1` for legacy changes. This documentation task does not rerun or certify these tests.
- Production: TLS for Backend/WSS; private Mongo and internal endpoints; secret injection; systemd services already have templates; graceful host drain; readiness tied to required dependencies; logs with match/request/receipt IDs but no credentials; metrics for tick time, packet loss, queue bounds, settlement lag and transaction failures; backup and restore drill.
- Run Linux binaries on Linux, not just cross-publish. Keep Windows development paths out of runtime configuration. Bind public addresses explicitly; defaults are loopback.

## 11. Explicit unresolved work and version traps

1. Server-only live configuration: schedules, matchmaking policy, reward weights, prices/offer variants absent from assets need explicit reconstruction policy or disabled features. Recovered schemas do not prove recovered values.
2. Unity-dependent navigation/physics: map exports and parity tests are necessary for authoritative .NET combat.
3. New legacy implementation: review defaults, input validation, state ownership and receipt atomicity before treating its successful boot as complete gameplay support.
4. Active 1.4.0 MissionManagerData is campaign/heroic progress; do not transplant a later Daily Missions DTO. DecalManagerData, WinStreak and other blob names must come from this source.
5. Existing historical docs may mention later-version action 108, dog-tag constants, action/version URLs or catalog counts. This guide uses active source evidence; resolve contradictions at the builder/parser/content, not by copying those numbers.
6. Local/provider-only achievements and presentation enum entries do not automatically require a new reward feature. External social providers remain out of scope. Actual store/payment support, if enabled, requires verified receipts rather than simulated purchase success.

<!-- GENERATED_SOURCE_APPENDICES -->

## Appendix A. Complete named action inventory

Generated from the active enum, not a copied later-version list. A missing direct builder means **inspect references**, not "unsupported" or "safe to implement empty". Callback/result and diagnostic identifiers are retained. Complete direct builder fields follow in Appendix B.

| ID | Exact Client name | Direct builder(s) | Other source reference example |
|---:|---|---|---|
| 2 | `MessageSent` | [Challenge](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L791) | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L569), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L83) |
| 3 | `AcceptChallenge` | [AcceptChallenge](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1835) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L246) |
| 4 | `GetAllPlayers` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 5 | `GetAllMessages` | [GetAllMessagesCoroutine](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L211) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L209) |
| 12 | `IgnoreMessage` | Inspect caller / buffer / dispatch | [MessageManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MessageManager.cs#L51), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L206) |
| 13 | `UpdateDeviceToken` | [UpdateDeviceToken](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1697) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L212) |
| 26 | `GetFriendsInfo` | [GetFriendsInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1301) | [AllTimeContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AllTimeContent.cs#L203), [SelectFriendsDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelectFriendsDialog.cs#L367) |
| 29 | `SetPlayerStatus` | [SetPlayerStatus](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1843) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L249), [SessionManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SessionManager.cs#L87) |
| 30 | `LoginToCustomAccount` | [Login](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1853) | [GameLoginManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameLoginManager.cs#L380), [IntroductionSquadButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/IntroductionSquadButton.cs#L53) |
| 34 | `GetPlayerData` | [GetPlayerData](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L732) | [DatabaseSerializedObjectGeneric](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseSerializedObjectGeneric.cs#L40), [FuseboxxService](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FuseboxxService.cs#L143) |
| 37 | `CreateSquad` | [CreateSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L776) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L92), [SquadCreateScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadCreateScreen.cs#L225) |
| 38 | `JoinSquad` | [JoinSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L822) | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L548), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L95) |
| 39 | `UniqueSquadNameFailure` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1378), [SquadCreateScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadCreateScreen.cs#L237) |
| 40 | `UniqueSquadNameSuccess` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1378), [SquadCreateScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadCreateScreen.cs#L231) |
| 41 | `CheckUniqueSquadName` | [CheckUniqueSquadName](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1738) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L218) |
| 42 | `RemoveUserFromSquad` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 44 | `GetAllSquadMembers` | Inspect caller / buffer / dispatch | [ChatSquadButtonOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ChatSquadButtonOnline.cs#L25), [NotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/NotificationManager.cs#L44) |
| 45 | `GetSquadDetails` | [GetSquadDetails](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1621) | [AllTimeContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AllTimeContent.cs#L207), [FightDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FightDialog.cs#L145) |
| 49 | `LeaveSquad` | [LeaveSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1169) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L98) |
| 52 | `AddFacebook` | [AddFacebookToCustomAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1229) | [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L367), [CardSelectionScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardSelectionScreen.cs#L193) |
| 53 | `SwitchToFacebook` | Inspect caller / buffer / dispatch | [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L367), [CardSelectionScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardSelectionScreen.cs#L193) |
| 54 | `FacebookLoginOk` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 55 | `PromotePlayer` | [PromotePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1257) | [MemberRecord](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MemberRecord.cs#L385), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L558) |
| 56 | `GetSquads` | [GetSquads](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1760) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L224), [SquadFindResults](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadFindResults.cs#L121) |
| 57 | `PromotePlayerToFounder` | [PromotePlayerToFounder](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1369) | [MemberRecord](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MemberRecord.cs#L348), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L123) |
| 58 | `DemotePlayer` | [DemotePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1389) | [MemberRecord](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MemberRecord.cs#L367), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L559) |
| 59 | `InvitePlayerToSquad` | [InvitePlayerToSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1437) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L134) |
| 60 | `UserAddedToSquadSuccess` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2648), [SquadFindScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadFindScreen.cs#L137) |
| 62 | `GameEnded` | [GameEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1006) | [LeagueArcManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LeagueArcManager.cs#L210), [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L46) |
| 63 | `UpdateSquadEmblem` | [UpdateEmblem](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1818) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L243) |
| 64 | `GameStartedMaster` | [GameStartedMaster](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L861) | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L38), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L153) |
| 65 | `GameStartedClient` | [GameStartedClient](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L843) | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L39), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L154) |
| 67 | `GameStartedCampaign` | [GameStartedCampaign](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L951) | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L40), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L155) |
| 68 | `GameStartedCoopMaster` | [GameCoopStartedMaster](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L961) | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L41), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L156) |
| 69 | `GameStartedCoopClient` | [GameCoopStartedClient](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L979) | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L42), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L157) |
| 70 | `RefillDogtags` | [RefillDogtags](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1445) | [DogtagDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DogtagDialog.cs#L84), [PurchaseProtection](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PurchaseProtection.cs#L87) |
| 73 | `BuyWeaponUpgrade` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L337), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L61) |
| 74 | `InstantWeaponUpgrade` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L350), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L34) |
| 75 | `ActivateWeaponUpgrade` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L351), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2926) |
| 76 | `BuyWeapon` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L338), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L35) |
| 77 | `BuyUnitUpgrade` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L230), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L341) |
| 78 | `InstantUnitUpgrade` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L231), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L345) |
| 79 | `ActivateUnitUpgrade` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L232), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L346) |
| 80 | `BuyUnit` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L233), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L342) |
| 81 | `FindSuggestedSquads` | [FindSuggestedSquads](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1780) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L225), [SquadFindResults](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadFindResults.cs#L121) |
| 84 | `AddToHitList` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 85 | `GetPlayersFromHitList` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 86 | `ExpandHitList` | [ExpandHitList](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1547) | No direct enum reference found |
| 87 | `HitListPlayerLoggedIn` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 88 | `ProvokePlayer` | [ProvokePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1553) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L170) |
| 89 | `SearchPlayers` | [SearchPlayers](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1810) | [SelectFriendsDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelectFriendsDialog.cs#L370), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L234) |
| 90 | `SystemMessage` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L573) |
| 91 | `ClaimReward` | [ClaimReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1562) | [InGameMessageDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InGameMessageDialog.cs#L123), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L173) |
| 92 | `ErrorMessage` | [SendErrorMessage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L577), [SendErrorMessage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L671) | No direct enum reference found |
| 94 | `DebugAddLevel` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L182) |
| 97 | `BuyCardPack` | Inspect caller / buffer / dispatch | [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L550), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L38) |
| 98 | `SendRequestBuffer` | [SendRequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1577) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L185) |
| 101 | `GetSquadsByExperience` | [GetSquadsByExperience](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1794) | [AllTimeContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AllTimeContent.cs#L195), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L231) |
| 104 | `WeaponWasShown` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2928), [WeaponScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L777) |
| 105 | `ArmyUnitWasShown` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L972), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2998) |
| 106 | `GetPlayerLeaguesDivision` | [GetPlayersFromLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1746) | [LeagueArcManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LeagueArcManager.cs#L141), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L221) |
| 107 | `GetPlayersByExperience` | [GetPlayersByExperience](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1865) | [AllTimeContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AllTimeContent.cs#L199), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L258) |
| 108 | `DecalWasShown` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3116) |
| 109 | `BuyDecal` | Inspect caller / buffer / dispatch | [CamosScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L801), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L39) |
| 110 | `EquipDecal` | Inspect caller / buffer / dispatch | [CamosScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L817), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3117) |
| 111 | `GetMissionLeaderboards` | [GetMissionLeaderboards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1332) | [MissionDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionDialog.cs#L174), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L191) |
| 112 | `SkipAssignment` | Inspect caller / buffer / dispatch | [DailyPart](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DailyPart.cs#L85), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L194) |
| 113 | `JoinSquadEvent` | [JoinSquadEvent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1653) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L197) |
| 114 | `BuyVip` | [BuyVip](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1659) | [BuyVIPDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BuyVIPDialog.cs#L50), [HeaderDogtagButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/HeaderDogtagButton.cs#L67) |
| 116 | `EquipWeapon` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3240), [WeaponScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L788) |
| 118 | `CreateAccount` | [CreateAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L891) | [FuseboxxService](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FuseboxxService.cs#L144), [GameController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameController.cs#L263) |
| 119 | `GameStartedTutorial` | [GameStartedTutorial](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1877) | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L43), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L277) |
| 120 | `TutorialEnded` | [TutorialEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1147) | [FuseboxxService](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FuseboxxService.cs#L145), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L141) |
| 121 | `ChangeNameAndPassword` | [ChangeNameAndPassword](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1885) | No direct enum reference found |
| 122 | `CreateFullAccount` | Inspect caller / buffer / dispatch | No direct enum reference found |
| 124 | `GetSquadWarsDivision` | [GetSquadsFromRound](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1917) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L228), [SquadWarManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadWarManager.cs#L63) |
| 125 | `InstantBuyUnit` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L234), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L370) |
| 126 | `InstantBuyWeapon` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L376), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L41) |
| 127 | `ActivateUnit` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L235), [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L371) |
| 128 | `ActivateWeapon` | Inspect caller / buffer / dispatch | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L377), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2930) |
| 129 | `PayOneDogTag` | [PayOneDogtag](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2023) | [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L147), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L280) |
| 130 | `BuyPack` | Inspect caller / buffer / dispatch | [CamosScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L252), [CardSelectionScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardSelectionScreen.cs#L189) |
| 131 | `UpdateSquad` | [UpdateSquadInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2039) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L289) |
| 132 | `JoinSquadRequest` | [JoinSquadRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L835) | [PushNotificationManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PushNotificationManager.cs#L549), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L292) |
| 133 | `AcceptSquadJoinRequest` | [AcceptSquadJoinRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1687) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L347), [ServerResultsCache](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResultsCache.cs#L424) |
| 134 | `DebugAddSquadLevel` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L295) |
| 135 | `GenerateSpecialOffer` | [GenerateSpecialOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2081) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L301) |
| 136 | `AcceptSpecialOffer` | [AcceptSpecialOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2100) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L166) |
| 138 | `AcceptRentalOffer` | [AcceptRentalOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2120) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L167) |
| 139 | `ChangePlayerName` | [ChangePlayerName](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2159) | [MenuHeader](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MenuHeader.cs#L137), [OverallStats](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/OverallStats.cs#L282) |
| 140 | `UpdateRegionPings` | [UpdateRegionPings](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2174) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L261) |
| 141 | `SendCrashReport` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L89) |
| 142 | `BuyInApp` | Inspect caller / buffer / dispatch | [InappGold](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InappGold.cs#L136), [InAppHandlerAndroid](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InAppHandlerAndroid.cs#L166) |
| 143 | `PhotonIsFull` | [PhotonIsFull](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2183) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L286) |
| 146 | `CreateGcAccount` | [CreateGcAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L912) | [FuseboxxService](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/FuseboxxService.cs#L146), [GameController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameController.cs#L263) |
| 147 | `AddDebugGoodies` | Inspect caller / buffer / dispatch | [GameController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameController.cs#L263), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L307) |
| 148 | `SendPlayerReport` | [SendPlayerReport](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1587) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L320) |
| 149 | `GetNewAssignments` | [GetNewAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1182) | [DailyPart](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DailyPart.cs#L86), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L335) |
| 150 | `ChangeLanguage` | [ChangeLanguage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1428) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L338) |
| 151 | `GetFullSquadInfo` | [GetFullSquadInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1636) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L341), [SquadDetailsDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadDetailsDialog.cs#L220) |
| 152 | `GetLastWeeksPlayerLeague` | [GetLastWeeksPlayerLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1500) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L350) |
| 154 | `AddGameCenter` | [AddGameCenter](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L936) | [GameLoginManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameLoginManager.cs#L382), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L362) |
| 156 | `AddVideoReward` | [AddVideoReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1416) | [DogtagDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DogtagDialog.cs#L84), [GainedCardsAnimation](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GainedCardsAnimation.cs#L28) |
| 157 | `GetConfigurations` | [GetConfigurations](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L504) | [GameLoginManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameLoginManager.cs#L393), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L44) |
| 158 | `PromoteUnit` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L830) |
| 159 | `DebugChangeLevel` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L179) |
| 160 | `InformSquadLeaderAboutEvent` | [InformSquadLeaderAboutEvent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1267) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L344), [SquadEventDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadEventDialog.cs#L89) |
| 161 | `AddOneTimeReward` | [AddOneTimeReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1377) | [MainScreenSocial](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MainScreenSocial.cs#L53), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L365) |
| 162 | `DebugChangeMedals` | Inspect caller / buffer / dispatch | [HeaderLeagueButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/HeaderLeagueButton.cs#L48), [LeagueArcGuiElement](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LeagueArcGuiElement.cs#L224) |
| 163 | `ChatShownFirstTime` | [ChatShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1512) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L380) |
| 164 | `RemoveFacebook` | [RemoveFacebook](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L481) | [HeaderDogtagButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/HeaderDogtagButton.cs#L64), [IntroductionSquadButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/IntroductionSquadButton.cs#L56) |
| 165 | `UpdateSettings` | [UpdateSettings](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1772) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L390), [SettingsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SettingsManager.cs#L138) |
| 166 | `SendLog` | [SendLogs](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L701) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L417), [SettingsDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SettingsDialog.cs#L154) |
| 167 | `Test` | [TestMethod](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L694) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L110), [ServerResultsCache](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResultsCache.cs#L177) |
| 168 | `CustomizationShown` | [CustomizationShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1526) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L393) |
| 169 | `WarpathShownFirstTime` | [WarpathShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1519) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L396) |
| 170 | `GetPlayerInfo` | [GetPlayerInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L971) | [PlayerProfileDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerProfileDialog.cs#L305), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L314) |
| 171 | `ClaimAssignment` | Inspect caller / buffer / dispatch | [AssignmentsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssignmentsManager.cs#L287), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2806) |
| 172 | `KickPlayer` | [KickPlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1399) | [MemberRecord](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MemberRecord.cs#L432), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L264) |
| 173 | `ClaimAssignmentMegaReward` | [ClaimAssignmentMegaReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1570) | [DailyPart](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DailyPart.cs#L89), [MainScreenAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MainScreenAssignments.cs#L75) |
| 174 | `DepositCards` | [DepositCards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L617) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L267), [SquadCardpoolContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadCardpoolContent.cs#L151) |
| 175 | `WithdrawCard` | [WithdrawCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L989) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L359), [SquadCardpoolContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SquadCardpoolContent.cs#L151) |
| 176 | `CraftCard` | [CraftCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1408) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L420) |
| 177 | `ClaimCraftedCard` | [ClaimCraftedCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1176) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L332) |
| 178 | `NotifyPlayerToDeposit` | [NotifyPlayerToDeposit](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L655) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L310) |
| 179 | `UpdateAnalytics` | [UpdateAnalytics](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L646) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L113) |
| 180 | `CardpoolShown` | [CardpoolShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1533) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L411) |
| 181 | `DeclineSquadJoinRequest` | [DeclineSquadJoinRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1677) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L203) |
| 182 | `LeagueLeaderboardShown` | [LeagueLeaderboardsShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L639) | No direct enum reference found |
| 183 | `CraftingShown` | [CraftingShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1540) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L414) |
| 184 | `ReadMessage` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L283) |
| 185 | `CompleteStarterAssignments` | [CompleteStarterAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1188) | [IntroductionDealsStarterAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/IntroductionDealsStarterAssignments.cs#L36), [MainScreenAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MainScreenAssignments.cs#L75) |
| 186 | `ClaimStarterAssignment` | Inspect caller / buffer / dispatch | [IntroductionDealsStarterAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/IntroductionDealsStarterAssignments.cs#L36), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2821) |
| 187 | `AddGooglePlay` | [AddGooglePlay](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1245) | [GameLoginManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameLoginManager.cs#L404), [IntroductionSquadButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/IntroductionSquadButton.cs#L57) |
| 188 | `RemoveGooglePlay` | [RemoveGooglePlay](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L491) | [IntroductionSquadButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/IntroductionSquadButton.cs#L58), [MainScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MainScreen.cs#L76) |
| 189 | `RestorePacks` | [RestorePacks](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L528) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L329) |
| 190 | `BuyLootboxes` | [BuyLootboxes](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1668) | [InappLootboxes](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InappLootboxes.cs#L97), [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L535) |
| 191 | `VisualWasShown` | Inspect caller / buffer / dispatch | [CamosScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L809), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3107) |
| 192 | `UpdateArmyPower` | [UpdateArmyPower](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L882) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L311) |
| 193 | `SaveLastSeenSquadChatTimeStamp` | Inspect caller / buffer / dispatch | [PlayerAnalytics](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerAnalytics.cs#L304) |
| 194 | `MessageWasShown` | Inspect caller / buffer / dispatch | [MessageManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MessageManager.cs#L41) |
| 195 | `OnVIPExpired` | [OnVipExpired](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1197) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L252) |
| 196 | `ChangePlayerCountry` | [ChangePlayerCountry](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1206) | No direct enum reference found |
| 197 | `ReportCheater` | [SendCheaterReport](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1607) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L326) |
| 198 | `FinishPlayerLeague` | [FinishPlayerLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2152) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L356) |
| 199 | `InstantBattle` | Inspect caller / buffer / dispatch | [InstantBattleButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InstantBattleButton.cs#L55), [InstantBattleConfirmDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InstantBattleConfirmDialog.cs#L53) |
| 200 | `EnterArena` | Inspect caller / buffer / dispatch | [EnterArenaRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnterArenaRequest.cs#L17), [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L71) |
| 201 | `BuyArenaHearth` | [BuyArenaHearth](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2143) | [BuyHearthDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BuyHearthDialog.cs#L79), [BuyTicketsDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BuyTicketsDialog.cs#L90) |
| 202 | `TakeArenaLife` | [TakeArenaLife](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2136) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L147) |
| 203 | `GetScrapsReward` | [GetScrapsReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2128) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L150) |
| 204 | `DebugChangeArenaLives` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L129) |
| 205 | `DebugChangeArenaWins` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L130) |
| 206 | `GetArenaLeaderboards` | Inspect caller / buffer / dispatch | [GetArenaLeaderboardsRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GetArenaLeaderboardsRequest.cs#L22), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L399) |
| 207 | `ConvertScrapsToParts` | Inspect caller / buffer / dispatch | [ArmyLeftBuffDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyLeftBuffDialog.cs#L230), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3221) |
| 208 | `ConvertPartsToScraps` | Inspect caller / buffer / dispatch | [ArmyLeftBuffDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyLeftBuffDialog.cs#L204), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L117) |
| 209 | `UpgradeEliteSlot` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L929), [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L107) |
| 210 | `DebugAddScraps` | Inspect caller / buffer / dispatch | [DebugAddScrapsRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DebugAddScrapsRequest.cs#L11), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L408) |
| 211 | `WarArenaEnded` | Inspect caller / buffer / dispatch | [ServerErrorHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerErrorHandler.cs#L74), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L405) |
| 212 | `WarArenaShown` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L383), [WarArenaShownRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaShownRequest.cs#L12) |
| 213 | `ElitesFeatureShown` | Inspect caller / buffer / dispatch | [ElitesFeatureShownRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ElitesFeatureShownRequest.cs#L9), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L377) |
| 1000 | `MaxAll` | Inspect caller / buffer / dispatch | [GameController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameController.cs#L263), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L317) |
| 1001 | `CheckDailyReward` | [checkDaylyRewards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2114) | [MainScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MainScreen.cs#L64), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L426) |
| 1002 | `ClaimDailyReward` | [claimDailyReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2106) | [MainScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MainScreen.cs#L65), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L433) |
| 1003 | `UpdateEquippedUnits` | Inspect caller / buffer / dispatch | [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L719), [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3315) |
| 1004 | `DebugRenewRental` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L437) |
| 1005 | `RemoveOrUpdateGC` | [UpdateGC](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L714) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L274) |
| 1006 | `RemoveFromLeague` | Inspect caller / buffer / dispatch | [LeagueContent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LeagueContent.cs#L226), [PlayerLeagueFinished](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerLeagueFinished.cs#L102) |
| 1007 | `SpecialOfferShowed` | [SendSpecialOfferShowed](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2064) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L304) |
| 1008 | `ExistGCAccount` | [CheckIfExistGcAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2194) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L423) |
| 1009 | `ExistFBAccount` | [ExistFacebookAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1215) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L107) |
| 1010 | `DebugChangeLeague` | Inspect caller / buffer / dispatch | [HeaderLeagueButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/HeaderLeagueButton.cs#L48), [LeagueArcGuiElement](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LeagueArcGuiElement.cs#L224) |
| 1011 | `DebugChangeDivision` | Inspect caller / buffer / dispatch | [HeaderLeagueButton](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/HeaderLeagueButton.cs#L48), [LeagueArcGuiElement](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LeagueArcGuiElement.cs#L224) |
| 1012 | `DebugChangeAnticheat` | Inspect caller / buffer / dispatch | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L323) |
| 1013 | `RefundPack` | [RefundedInapps](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L520) | No direct enum reference found |
| 1014 | `SaveFuseConfigs` | [SendFuseboxConfigurations](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L663) | [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L440) |

## Appendix B. Direct request DTO field candidates

Fields are literal tuple names grouped by builder method. Conditional fields, dynamic keys, common auth fields and nested JSON need source review; a listed field is **not necessarily required**. No fields found means no literal tuple fields in this method, not necessarily an empty wire request. Overloads may repeat.

| Builder | Action ID/name | Literal action field candidates |
|---|---|---|
| [GetAllMessagesCoroutine](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L211) | 5 `GetAllMessages` | `MessagesCount` |
| [RemoveFacebook](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L481) | 164 `RemoveFacebook` | `gameCenterId`, `gameCenterPassword`, `isGameCenter` |
| [RemoveGooglePlay](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L491) | 188 `RemoveGooglePlay` | None found |
| [GetConfigurations](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L504) | 157 `GetConfigurations` | `DebugVersion`, `Language`, `SheetConfiguraton`, `abTestVariant` |
| [RefundedInapps](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L520) | 1013 `RefundPack` | `Packs` |
| [RestorePacks](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L528) | 189 `RestorePacks` | `Packs` |
| [SendErrorMessage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L577) | 92 `ErrorMessage` | `ClientVersion`, `DbAction`, `ExceptionMessage`, `ExceptionStacktrace`, `PlayerName`, `PostParameters`, `ServerResponse` |
| [DepositCards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L617) | 174 `DepositCards` | `AddedCards`, `RemovedCards` |
| [LeagueLeaderboardsShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L639) | 182 `LeagueLeaderboardShown` | None found |
| [UpdateAnalytics](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L646) | 179 `UpdateAnalytics` | `PlayerAnalytics` |
| [NotifyPlayerToDeposit](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L655) | 178 `NotifyPlayerToDeposit` | `SquadMemberId` |
| [SendFuseboxConfigurations](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L663) | 1014 `SaveFuseConfigs` | `fuseData` |
| [SendErrorMessage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L671) | 92 `ErrorMessage` | `ClientVersion`, `ExceptionMessage`, `ExceptionStacktrace`, `MessageToParse`, `PlayerName` |
| [TestMethod](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L694) | 167 `Test` | None found |
| [SendLogs](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L701) | 166 `SendLog` | `ClientVersion`, `Logs`, `PlayerId`, `PlayerName` |
| [UpdateGC](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L714) | 1005 `RemoveOrUpdateGC` | `GameCenterId`, `GameCenterPassword`, `haveGcId` |
| [GetPlayerData](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L732) | 34 `GetPlayerData` | `AndroidAdvertisingID`, `AndroidID`, `Buffers`, `DogTagCap`, `DogTagRefillTime`, `FuseboxxConfigValue`, `IDFA`, `IDFV`, `KochavaDeviceID`, `LocalPersistenceHandle`, `Locale`, `UnsentRewards`, `height`, `width` |
| [CreateSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L776) | 37 `CreateSquad` | `Icon`, `IsPublic`, `Message`, `SkillRequirement`, `SquadId` |
| [Challenge](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L791) | 2 `MessageSent` | `ChallengedPlayerId`, `GameType`, `IsHeroic`, `MapName`, `MissionData`, `MissionNumber`, `Region`, `clientVersion`, `roomName` |
| [JoinSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L822) | 38 `JoinSquad` | `MessageId`, `NewSquadId` |
| [JoinSquadRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L835) | 132 `JoinSquadRequest` | `SquadId` |
| [GameStartedClient](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L843) | 65 `GameStartedClient` | `BattleId`, `DogTagCap`, `DogTagRefillTime`, `IsHitList`, `IsMatchMaking`, `IsWarArenaBattle` |
| [GameStartedMaster](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L861) | 64 `GameStartedMaster` | `BattleId`, `BotId`, `BotLevel`, `BotName`, `DogTagCap`, `DogTagRefillTime`, `IsMatchMaking`, `IsWarArenaBattle` |
| [UpdateArmyPower](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L882) | 192 `UpdateArmyPower` | `ArmyPower` |
| [CreateAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L891) | 118 `CreateAccount` | `Locale`, `StartingGold`, `StartingWarbucks`, `UtcOffset` |
| [CreateGcAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L912) | 146 `CreateGcAccount` | `GameCenterId`, `GameCenterPassword`, `Locale`, `StartingGold`, `StartingWarbucks`, `UtcOffset` |
| [AddGameCenter](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L936) | 154 `AddGameCenter` | `GameCenterId`, `GameCenterPassword`, `RemoveOld` |
| [GameStartedCampaign](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L951) | 67 `GameStartedCampaign` | `BattleId`, `DogTagCap`, `DogTagRefillTime` |
| [GameCoopStartedMaster](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L961) | 68 `GameStartedCoopMaster` | `BattleId`, `DogTagCap`, `DogTagRefillTime` |
| [GetPlayerInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L971) | 170 `GetPlayerInfo` | `PlayerInfoId` |
| [GameCoopStartedClient](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L979) | 69 `GameStartedCoopClient` | `BattleId`, `DogTagCap`, `DogTagRefillTime` |
| [WithdrawCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L989) | 175 `WithdrawCard` | `CardId`, `IdOfPlayer` |
| [GameEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1006) | 62 `GameEnded` | `AssignmentsUpdate`, `BattleAnalytics`, `BattleId`, `EndReason`, `Experience`, `FpsData`, `FpsDevice`, `GoldBonusCount`, `GoldBoxes`, `IsHeroic`, `IsMaster`, `IsWarArena`, `LevelReward`, `LostGameInRow`, `MissionBot`, `MissionData`, `MissionIndex`, `ObtainedCards`, `PlayerProgressRate`, `SquadEventActiveTier`, `SquadEventUpdate`, `SquadId`, `StarterPackDays`, `Stats`, `TimeBonus`, `TutorialWarcards`, `UsedCards`, `WarBucksBoxes`, `WarBucksRibbons`, `WarbuckRewardLoss`, `WarbuckRewardWin` |
| [TutorialEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1147) | 120 `TutorialEnded` | `ArmyPower`, `BattleId`, `EndReason`, `Experience`, `Gold`, `GoldBoxes`, `ObtainedCards`, `UsedCards`, `WarBucksBoxes`, `Warbucks` |
| [LeaveSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1169) | 49 `LeaveSquad` | None found |
| [ClaimCraftedCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1176) | 177 `ClaimCraftedCard` | None found |
| [GetNewAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1182) | 149 `GetNewAssignments` | None found |
| [CompleteStarterAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1188) | 185 `CompleteStarterAssignments` | `AssignmentsIds` |
| [OnVipExpired](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1197) | 195 `OnVIPExpired` | `DogTagCap`, `DogTagRefillTime` |
| [ChangePlayerCountry](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1206) | 196 `ChangePlayerCountry` | `NewCountryCode` |
| [ExistFacebookAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1215) | 1009 `ExistFBAccount` | `FacebookId`, `FacebookPassword` |
| [AddFacebookToCustomAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1229) | 52 `AddFacebook` | `FacebookId`, `FacebookPassword`, `Name` |
| [AddGooglePlay](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1245) | 187 `AddGooglePlay` | `GooglePlayId`, `GooglePlayPassword`, `Name` |
| [PromotePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1257) | 55 `PromotePlayer` | `OldSquadRank`, `PlayerToPromoteId` |
| [InformSquadLeaderAboutEvent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1267) | 160 `InformSquadLeaderAboutEvent` | `SquadId` |
| [GetFriendsInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1301) | 26 `GetFriendsInfo` | `Count`, `Friend`, `SquadId` |
| [GetMissionLeaderboards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1332) | 111 `GetMissionLeaderboards` | `Friends`, `SquadId` |
| [PromotePlayerToFounder](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1369) | 57 `PromotePlayerToFounder` | `PlayerToPromoteId` |
| [AddOneTimeReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1377) | 161 `AddOneTimeReward` | `Parameter`, `RewardId` |
| [DemotePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1389) | 58 `DemotePlayer` | `OldSquadRank`, `PlayerToDemoteId` |
| [KickPlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1399) | 172 `KickPlayer` | `PlayerToKickId` |
| [CraftCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1408) | 176 `CraftCard` | `Cards` |
| [AddVideoReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1416) | 156 `AddVideoReward` | `DogTagCap`, `DogTagRefillTime`, `Reward` |
| [ChangeLanguage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1428) | 150 `ChangeLanguage` | `Locale` |
| [InvitePlayerToSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1437) | 59 `InvitePlayerToSquad` | `PlayerToInviteId` |
| [RefillDogtags](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1445) | 70 `RefillDogtags` | `DogTagCap`, `DogTagRefillTime` |
| [GetLastWeeksPlayerLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1500) | 152 `GetLastWeeksPlayerLeague` | None found |
| [ChatShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1512) | 163 `ChatShownFirstTime` | None found |
| [WarpathShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1519) | 169 `WarpathShownFirstTime` | None found |
| [CustomizationShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1526) | 168 `CustomizationShown` | None found |
| [CardpoolShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1533) | 180 `CardpoolShown` | None found |
| [CraftingShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1540) | 183 `CraftingShown` | None found |
| [ExpandHitList](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1547) | 86 `ExpandHitList` | None found |
| [ProvokePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1553) | 88 `ProvokePlayer` | `DeviceToken`, `PlayerName` |
| [ClaimReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1562) | 91 `ClaimReward` | `MessageId` |
| [ClaimAssignmentMegaReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1570) | 173 `ClaimAssignmentMegaReward` | None found |
| [SendRequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1577) | 98 `SendRequestBuffer` | `BufferId`, `Count`, `Requests` |
| [SendPlayerReport](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1587) | 148 `SendPlayerReport` | `Message`, `ReportType`, `ReportedPlayerId` |
| [SendCheaterReport](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1607) | 197 `ReportCheater` | `MyArmyPower`, `MyRank`, `OpponentArmyPower`, `OpponentRank`, `ReportType`, `ReportedPlayerId`, `TimeOfMatch` |
| [GetSquadDetails](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1621) | 45 `GetSquadDetails` | `SquadId` |
| [GetFullSquadInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1636) | 151 `GetFullSquadInfo` | `SquadId` |
| [JoinSquadEvent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1653) | 113 `JoinSquadEvent` | None found |
| [BuyVip](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1659) | 114 `BuyVip` | `Id`, `discount` |
| [BuyLootboxes](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1668) | 190 `BuyLootboxes` | `Id`, `discount` |
| [DeclineSquadJoinRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1677) | 181 `DeclineSquadJoinRequest` | `Id`, `MessageId` |
| [AcceptSquadJoinRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1687) | 133 `AcceptSquadJoinRequest` | `PlayerToJoin`, `SquadId` |
| [UpdateDeviceToken](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1697) | 13 `UpdateDeviceToken` | `DeviceToken`, `Locale` |
| [CheckUniqueSquadName](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1738) | 41 `CheckUniqueSquadName` | `SquadId` |
| [GetPlayersFromLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1746) | 106 `GetPlayerLeaguesDivision` | `LeagueId` |
| [GetSquads](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1760) | 56 `GetSquads` | `IsGlobal`, `SquadNameStart` |
| [UpdateSettings](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1772) | 165 `UpdateSettings` | `Settings` |
| [FindSuggestedSquads](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1780) | 81 `FindSuggestedSquads` | `IsGlobal`, `Skill` |
| [GetSquadsByExperience](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1794) | 101 `GetSquadsByExperience` | `SquadId` |
| [SearchPlayers](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1810) | 89 `SearchPlayers` | `PlayerName` |
| [UpdateEmblem](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1818) | 63 `UpdateSquadEmblem` | `Icon` |
| [AcceptChallenge](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1835) | 3 `AcceptChallenge` | `MessageId` |
| [SetPlayerStatus](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1843) | 29 `SetPlayerStatus` | `PlayerStatus` |
| [Login](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1853) | 30 `LoginToCustomAccount` | `AccountType`, `Id`, `Password` |
| [GetPlayersByExperience](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1865) | 107 `GetPlayersByExperience` | None found |
| [GameStartedTutorial](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1877) | 119 `GameStartedTutorial` | `Name` |
| [ChangeNameAndPassword](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1885) | 121 `ChangeNameAndPassword` | `Name`, `Password` |
| [GetSquadsFromRound](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1917) | 124 `GetSquadWarsDivision` | `RoundId` |
| [PayOneDogtag](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2023) | 129 `PayOneDogTag` | `DogTagCap`, `DogTagRefillTime` |
| [UpdateSquadInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2039) | 131 `UpdateSquad` | `IsPublic`, `Message`, `RequiredMedals` |
| [SendSpecialOfferShowed](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2064) | 1007 `SpecialOfferShowed` | `showedOffers` |
| [GenerateSpecialOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2081) | 135 `GenerateSpecialOffer` | `dbKey`, `discount`, `finish`, `forceReplace`, `height`, `lang`, `offerName`, `width` |
| [AcceptSpecialOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2100) | 136 `AcceptSpecialOffer` | None found |
| [claimDailyReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2106) | 1002 `ClaimDailyReward` | `claimRweard` |
| [checkDaylyRewards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2114) | 1001 `CheckDailyReward` | None found |
| [AcceptRentalOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2120) | 138 `AcceptRentalOffer` | `buyRentalDiscounted` |
| [GetScrapsReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2128) | 203 `GetScrapsReward` | `HeartDialogShown` |
| [TakeArenaLife](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2136) | 202 `TakeArenaLife` | None found |
| [BuyArenaHearth](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2143) | 201 `BuyArenaHearth` | `hearthPrice` |
| [FinishPlayerLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2152) | 198 `FinishPlayerLeague` | None found |
| [ChangePlayerName](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2159) | 139 `ChangePlayerName` | `Name`, `PayForRename` |
| [UpdateRegionPings](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2174) | 140 `UpdateRegionPings` | `Connection`, `Regions` |
| [PhotonIsFull](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2183) | 143 `PhotonIsFull` | None found |
| [CheckIfExistGcAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L2194) | 1008 `ExistGCAccount` | `GameCenterId` |

### Requests sent outside BeanstalkServerManager

These callers use the public SendServerRequest wrapper, including Arena, Instant Battle and dynamic purchase actions. Dynamic action expressions require caller inspection.

| Source / method | Named action or dynamic expression | Literal tuple fields |
|---|---|---|
| [BuyTicketsClick](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BuyTicketsDialog.cs#L76) | BuyArenaHearth | `UsedGolds` |
| [Send](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DebugAddScrapsRequest.cs#L9) | DebugAddScraps | None found |
| [Send](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ElitesFeatureShownRequest.cs#L6) | ElitesFeatureShown | None found |
| [Send](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnterArenaRequest.cs#L10) | EnterArena | `UsedGold` |
| [SendRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GetArenaLeaderboardsRequest.cs#L10) | GetArenaLeaderboards | None found |
| [InstantBattleClick](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InstantBattleButton.cs#L62) | InstantBattle | None found |
| [NextBattleButtonClick](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InstantBattleConfirmDialog.cs#L46) | InstantBattle | `IsPaid` |
| [Send](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaEndedRequest.cs#L7) | WarArenaEnded | `ArenaId` |
| [Send](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaShownRequest.cs#L6) | WarArenaShown | `ArenaId` |

## Appendix C. Response reader DTO keys

Literal `mResponse[...]` keys grouped by method. This list intentionally does not label all keys mandatory: inspect `ContainsKey`, null checks and result-code branches. Nested `StringParser`/DTO readers add fields beyond this envelope index.

| Reader | Direct envelope keys |
|---|---|
| [ServerRequestFinished](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L35) | `Result`, `Test`, `WarArenaData`, `dailyRewardData` |
| [OnVipExpired](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L489) | `DogTagLastUpdate`, `DogTagSeconds` |
| [OnRestorePacks](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L499) | `PlayerData`, `RestoredPacks` |
| [OnClaimCraftedCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L518) | `CardId` |
| [OnCraftCards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L527) | `End` |
| [OnWithdrawCard](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L541) | `NextWithdraw` |
| [OnDepositCards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L551) | `NextBuddyDeposit` |
| [OnGetPlayerInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L569) | `PlayerInfo`, `SquadWarsId` |
| [OnSendLog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L590) | `LogId` |
| [OnRemoveLogin](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L602) | `AccountType`, `Name`, `guestId`, `guestPassword` |
| [OnDebugChangeMedals](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L641) | `Medals`, `MedalsBalance` |
| [OnDebugChangeLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L656) | `leagueId` |
| [OnAddOneTimeReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L663) | `Gold`, `RewardId`, `WarBucks` |
| [OnAddReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L713) | `AddedCards`, `CardsInCardPack`, `DogTagLastUpdate`, `DogTagSeconds`, `ExpiresOn`, `Gold`, `Id`, `NewVisuals`, `Scraps`, `Tickets`, `Vip`, `VipReward1`, `VipReward2`, `VipRewardForDay`, `VipStart`, `WarBucks`, `addPowerbandTime`, `addedVIP`, `videoAdRewardTimes` |
| [OnAcceptSquadJoinRequest](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L837) | `joinedPlayer` |
| [OnGetFullSquadInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L851) | `SquadWarsId` |
| [OnSendPlayerReport](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L872) | `Reported` |
| [OnReportCheater](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L877) | `PlayerID` |
| [OnChangePlayerName](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L896) | `Name`, `PayForRename`, `RenameCount` |
| [OnAcceptSpecialOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L908) | `RequestsResults` |
| [OnGenerateSpecialOffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L925) | `offers` |
| [DebugAddSquadLevel](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L930) | `Squad` |
| [OnAddGameCenter](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1059) | `GameCenterId` |
| [OnCheckExistFbAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1066) | `FacebookId`, `FacebookName`, `FacebookPassword`, `facebookLevel`, `facebookMedals` |
| [OnAddServiceProvider](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1122) | `Gold`, `Vip`, `VipReward1`, `VipReward2`, `VipRewardForDay`, `VipStart` |
| [OnBuyInApp](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1214) | `Gold`, `Id`, `Warbucks` |
| [OnBuyPack](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1252) | `PackId`, `PlayerData`, `VipReward1`, `VipReward2`, `VipRewardForDay` |
| [OnBuyLootboxes](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1310) | `Id`, `LootboxCost`, `NewVisuals` |
| [OnDebugMaxAll](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1331) | `PlayerData` |
| [OnDebugAddGoodies](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1339) | `PlayerData` |
| [OnBuyVip](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1347) | `Gold`, `Id`, `Vip`, `VipReward1`, `VipReward2`, `VipRewardForDay`, `VipStart` |
| [OnCheckUniqueSquadName](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1375) | `IsUnique` |
| [OnClaimReward](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1381) | `Gold`, `Rewards`, `Warbucks` |
| [OnCheckExistGcAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1405) | `GameCenterId`, `resultMessage` |
| [OnGCUpdated](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1433) | `AccountType`, `Added`, `gcID`, `gcPassword` |
| [OnCreateAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1462) | `AccountType`, `BattleId`, `LeagueEvaluation`, `MaintenanceMessage`, `Password`, `Player`, `PlayerData`, `Time`, `Token`, `WarArenaConfig` |
| [OnBuyArenaHeart](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1540) | `ArenaLives`, `goldSpent`, `ticketsSpent` |
| [OnTakeArenaHearth](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1562) | `ArenaLives` |
| [OnCreateSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1575) | `EventDefinition`, `PlayerRank`, `Squad`, `SquadId`, `WarsEvaluation`, `squadCreationsCnt` |
| [OnDebugAddLevel](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1599) | `Level` |
| [OnDemotePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1609) | `DemotedPlayer` |
| [OnKickPlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1620) | `Player` |
| [OnArenaEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1649) | `ArenaLives`, `ArenaWins`, `DecalExpiresOn`, `DecalId`, `Flawless`, `GameReward`, `Lootbox`, `Scraps`, `Shields`, `TopRun`, `VisualTimestamp`, `VisualType` |
| [OnClassicGameEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1773) | `AssignmentData`, `BeginnersLeague`, `ElitePackDeadline`, `ElitePackId`, `EnteredLeague`, `GameReward`, `Level`, `LevelExperience`, `MatchesToNextLootboxes`, `MedalsBalance`, `MissionManagerData`, `MoneyPackDeadline`, `PlacementMatchesRequired`, `Rental`, `Skill`, `SpecialPackFromServer`, `Squad`, `SquadEventProgress`, `StarterPackDeadline`, `Time`, `TimeStamp`, `VipReward1`, `VipReward2`, `VipRewardForDay`, `WinCount`, `squadPoints` |
| [OnInstantBattleEnded](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2033) | `AddedCards`, `BattleCount`, `ExperienceGained`, `ExtraWarBucks`, `Gold`, `InstantBattleTime`, `Level`, `LevelExperience`, `MoneyPackDeadline`, `PaidInstantBattles`, `WarBucks` |
| [OnGameStarted](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2135) | `BattleId`, `LastUpdate`, `Seconds`, `Time` |
| [OnGetAllMessages](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2157) | `Items` |
| [OnChangeAnticheatStatus](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2176) | `Anticheat` |
| [OnGetAllSquadMembers](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2185) | `SquadId`, `SquadMembers`, `SquadMessages`, `SquadWarsId` |
| [OnGetFriendsInfo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2240) | `Friends`, `SquadMates` |
| [OnGetMissionLeaderboards](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2274) | `Friends`, `SquadMates` |
| [OnGetPlayerData](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2296) | `BattleId`, `DailyGold`, `DailyGoldDay`, `DeviceToken`, `LapsedPlayerRewardId`, `LeagueEvaluation`, `LeagueId`, `MaintenanceMessage`, `MedalsBalance`, `PlacementMatchesRequired`, `PlayerData`, `Rental`, `Scraps`, `Skill`, `SpecialPackFromServer`, `Squad`, `Time`, `VipReward1`, `VipReward2`, `VipRewardForDay`, `WarArenaConfig`, `dailyRewardData`, `fuseData`, `specialOffers` |
| [OnGetPlayersByExperience](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2462) | `Items`, `Local` |
| [OnGetLastWeeksPlayerLeague](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2485) | `Items` |
| [OnGetPlayerLeaguesDivision](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2503) | `Items`, `LeagueEvaluation`, `LeagueId`, `PlayerLeaguesId` |
| [OnGetSquadDetails](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2528) | `EventDefinition`, `Squad`, `SquadEventProgress`, `SquadId`, `SquadWarsId`, `SquadWarsPosition`, `WarsEvaluation` |
| [OnGetSquads](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2563) | `IsLocal`, `Items` |
| [OnGetSquadsByExperience](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2574) | `Items`, `Local` |
| [OnGetSquadWarsDivision](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2595) | `Items`, `LeagueId`, `SquadWarsId` |
| [OnJoinSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2634) | `Gold`, `PlayerRank`, `SquadId` |
| [OnJoinSquadEvent](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2652) | `SquadEventProgress` |
| [OnLeaveSquad](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2662) | `DepositedCards` |
| [OnLoginToCustomAccount](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2679) | `AccountType`, `MaintenanceMessage`, `Password`, `Player`, `Token` |
| [OnPayOneDogTag](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2718) | `LastUpdate`, `Seconds` |
| [OnPromotePlayer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2725) | `PromotedPlayer` |
| [OnPromotePlayerToFounder](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2741) | `PromotedPlayer` |
| [OnRefillDogtags](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2763) | `Gold` |
| [OnSearchPlayers](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2773) | `Items` |
| [OnSendRequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L2783) | `BufferId`, `RequestsResults` |
| [OnSetPlayerStatus](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3354) | `Time` |
| [OnSkipAssignment](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3362) | `AssignmentData`, `WarBucksSkipPrice` |
| [OnGetNewAssignments](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3370) | `AssignmentData` |
| [OnTutorialStarted](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L3376) | `BattleId` |

### Delegated response readers

Literal response dictionary keys in separate OnSuccess/OnError readers; these are also conditional candidates, not an unconditional required-fields list.

| Source / method | Dictionary keys |
|---|---|
| [OnSuccess](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DebugAddScrapsRequest.cs#L14) | Scraps |
| [OnSuccess](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnterArenaRequest.cs#L20) | Gold, Tickets, WarArenaData |
| [OnSuccess](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GetArenaLeaderboardsRequest.cs#L26) | Items |
| [OnSuccess](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaEndedRequest.cs#L16) | NewArena, Scraps |
| [OnError](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaEndedRequest.cs#L37) | WrongId |

## Appendix D. Persisted subsystem and supporting DTO declarations

Source C# field declarations retain their names/types/default expressions. These are **not protobuf definitions**. Computed properties, serialization attributes, custom converters, constructors and loader defaults must also be inspected at the linked source. Nested helper types are included; runtime manager fields are excluded. Obscured scalar wrappers need plain validated wire values.

| Manager | Serialized blob type |
|---|---|
| [AssignmentsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssignmentsManager.cs#L1) | `AssignmentsManager.AssignmentData` |
| [CamosManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosManager.cs#L1) | `CamosManager.DecalManagerData` |
| [CardCraftingManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardCraftingManager.cs#L1) | `CardCraftingManager.CraftData` |
| [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L1) | `CardManager.CardManagerData` |
| [ChatBanManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ChatBanManager.cs#L1) | `ChatBanManager.ChatBanData` |
| [InAppDataManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InAppDataManager.cs#L1) | `InAppDataManager.InAppData` |
| [LevelManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L1) | `LevelManager.LevelManagerData` |
| [MissionsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L1) | `MissionsManager.MissionManagerData` |
| [PlayerAnalytics](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerAnalytics.cs#L1) | `PlayerAnalytics.PlayerAnalyticsData` |
| [PlayerInventory](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerInventory.cs#L1) | `PlayerInventory.InventoryData` |
| [SettingsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SettingsManager.cs#L1) | `SettingsManager.Settings` |
| [StarterAssignmentsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StarterAssignmentsManager.cs#L1) | `StarterAssignmentsManager.StarterAssignmentsData` |
| [StatsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StatsManager.cs#L1) | `StatsManager.StatisticsData` |
| [UserDeviceManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UserDeviceManager.cs#L1) | `UserDeviceManager.UserDevices` |
| [WarArena](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArena.cs#L1) | `WarArena.WarArenaData` |
| [WinStreakManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WinStreakManager.cs#L1) | `WinStreakManager.WinStreak` |

### AchievementsManager.AchievementDefinition

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AchievementsManager.cs#L10)

```csharp
public Achievement achievememt;
public string achievementType;
public Achievements.rowIds rowId;
```

### AssignmentsManager.AssignmentData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssignmentsManager.cs#L13)

```csharp
public List<DatabaseAssignment> assignments;
public int tomorrow;
public int completed;
public int issued;
public int rewardCounter;
public int days;
```

### AssignmentsManager.DatabaseAssignment

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssignmentsManager.cs#L29)

```csharp
public int id;
public bool done;
public bool claimed;
public float completeFract;
public float lastCompletedFract;
public int target;
public int secondTarget;
public int tutorialId;
```

### CamosManager.DecalManagerData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosManager.cs#L14)

```csharp
public Dictionary<string, SavedPlayerVisual> visuals = new Dictionary<string, SavedPlayerVisual>();
public Dictionary<int, SavedPlayerVisualSlot> slots = new Dictionary<int, SavedPlayerVisualSlot>();
public string previousHeadDecal = string.Empty;
```

### CamosManager.SavedPlayerVisualSlot

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosManager.cs#L24)

```csharp
public string equippedID;
```

### CamosManager.SavedPlayerVisual

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosManager.cs#L30)

```csharp
public bool bought;
public bool showed;
public int expiresOn;
public bool borrowed;
public int parts;
public bool notificate;
```

### CamosManager.VisualVisibilityConfiguration

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosManager.cs#L46)

```csharp
public string helmetId;
public string headAccessoryId;
public bool hideHelmet;
public bool hideHeadAccesory;
```

### CamosManager.CamoHairConfiguration

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosManager.cs#L58)

```csharp
public string camoId;
public string otherVisualId;
public int hairIndex;
```

### CardCraftingManager.CraftData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardCraftingManager.cs#L12)

```csharp
public List<string> cards = new List<string>();
public int start;
public int end;
```

### CardManager.CardData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L38)

```csharp
public int amount;
```

### CardManager.BuddyCardData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L44)

```csharp
public int amount;
public string buddyName;
public Dictionary<int, CamosManager.SavedPlayerVisualSlot> equippedVisuals;
public LevelBehaviour.UnitType unityType;
public int primaryWeapon;
public int secondaryWeapon;
public int armypower;
public int level;
```

### CardManager.CardManagerData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L64)

```csharp
public Dictionary<string, CardData> cardData = new Dictionary<string, CardData>();
public Dictionary<string, BuddyCardData> buddyCardData = new Dictionary<string, BuddyCardData>();
public int nextWithdraw;
public int nextBuddyDeposit;
public bool extraSlot;
```

### ChatBanManager.ChatBanData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ChatBanManager.cs#L8)

```csharp
public int timestamp;
public bool forever;
```

### DailyRewardMonthScreen.DailyRewardSerwerData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DailyRewardMonthScreen.cs#L10)

```csharp
public Action dataUpdated;
public int month;
public int year;
public List<DailyRewardDataForDay> dayRewards;
public int lastClaimed;
public int toClaim;
```

### DailyRewardMonthScreen.DailyRewardDataForDay

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DailyRewardMonthScreen.cs#L184)

```csharp
public DailyReward rewardType;
public DailyRewardDouble doubleFor;
public string parameters;
public long count;
```

### DatabaseGameReward.DatabaseGameReward

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseGameReward.cs#L6)

```csharp
public int mRemainingFightsToAssign;
public int mOldMedals;
public int mNewMedals;
public int mOldBalanceMedals;
public int mNewBalanceMedals;
```

### DatabaseMessage.DatabaseMessage

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseMessage.cs#L6)

```csharp
public string messageId;
public Type messageType;
public int messageTime;
public string playerId;
public bool wasIgnored;
```

### DatabasePlayer.DatabasePlayer

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabasePlayer.cs#L11)

```csharp
public string accountName;
public AccountType accountType;
public int armyPower;
public string deviceToken;
public long experience;
public long facebookId;
public string googlePlayId;
public string id;
public int lastAction;
public int reputation;
public string leagueDivision;
public string leagueId;
public int vipExpiration;
public League leagueTier = League.Bronze3;
public Dictionary<string, string> depositedCardsDic;
public int level;
public string country;
public int sendLogsValue;
public int beginnersLeague;
public Dictionary<int, CamosManager.SavedPlayerVisualSlot> playerVisuals;
public PlayerInventory.InventoryData inventoryData;
public LevelManager.LevelManagerData levelManagerData;
public int skill;
public int medalsBalance;
public int remainingMatches;
public string squadName;
public int squadPoints;
public SquadRank squadRank;
public PlayerStatus status;
public string gameCenterId;
public StatsManager.StatisticsData statisticsData;
public bool awaitingSquadMember;
public string visualType;
public int visualTimestamp;
public Dictionary<CloudRegionCode, int> bestRegions;
public InternetConnection connectionType;
```

### DatabasePlayerData.DatabasePlayerData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabasePlayerData.cs#L8)

```csharp
public int armyPower;
public long experience;
public long facebookId;
public string id;
public int level;
public int levelExperience;
public string accountName;
public int skill;
public string squadId;
public string country;
public string leagueDivision;
public string leagueId;
public League leagueTier = League.Bronze3;
public int beginnersLeague;
public int leaderboardPosition;
public CamosManager.DecalManagerData decalData;
```

### DatabaseSquad.DatabaseSquad

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseSquad.cs#L4)

```csharp
public int experience;
public string icon;
public bool isPublic;
public long levelExperience;
public string message;
public string name;
public int rank;
public string roundId;
public int squadWarDivision;
public int size;
public int skill;
public int skillRequirement;
public int squadPoints;
public int globalPosition;
public int warsPosition;
public int bestSkill;
public string division;
public int battlesLost;
public int battlesWon;
public int cardsPlayed;
public int kills;
public int unitsDeployed;
public int tiersCompleted;
public int squadPointsBest;
public int squadWarWins;
```

### DatabaseSquadEventDefinition.DatabaseSquadEventDefinition

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseSquadEventDefinition.cs#L5)

```csharp
public int eventStart;
public int eventEnd;
public int nTiers;
public List<EventTier> tiers;
```

### DatabaseSquadEventDefinition.EventTier

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseSquadEventDefinition.cs#L7)

```csharp
public int reward;
public int nAssignments;
public List<int> assignmentIds;
```

### DatabaseSquadEventProgress.DatabaseSquadEventProgress

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseSquadEventProgress.cs#L6)

```csharp
public string squadId;
public string eventId;
public int activeTier;
public float levelProgress;
public List<EventTierProgress> tiers;
```

### DatabaseSquadEventProgress.EventTierProgress

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseSquadEventProgress.cs#L8)

```csharp
public int reward;
public int tierNumber;
public List<float> assignmentsProgress;
public List<int> targets;
public Dictionary<int, string> assignmentsSecondParams;
```

### InAppDataManager.InAppData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InAppDataManager.cs#L9)

```csharp
public Dictionary<string, InAppInfo> inapps;
```

### InAppDataManager.InAppInfo

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/InAppDataManager.cs#L15)

```csharp
public int left;
public Dictionary<string, string> days;
```

### LevelManager.ItemDelivery

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L15)

```csharp
public bool activationNeeded;
public int boughtIndex;
public long end;
public string itemId;
public int slotId;
public long start;
```

### LevelManager.LevelManagerData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L31)

```csharp
public Dictionary<string, SavedArmySlots> savedArmies = new Dictionary<string, SavedArmySlots>();
public Dictionary<string, SavedWeaponSlots> savedWeapons = new Dictionary<string, SavedWeaponSlots>();
public ItemDelivery unitDelivery = new ItemDelivery();
public ItemDelivery weaponDelivery = new ItemDelivery();
```

### LevelManager.SavedArmySlots

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L55)

```csharp
public bool bought;
public int boughtIndex;
public int specialSlot;
public bool showed;
public int tier;
public bool borrowed;
public bool wasEquipped;
public bool equipped;
public int eliteSlot;
public int parts;
```

### LevelManager.SavedWeaponSlots

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L79)

```csharp
public bool bought;
public int boughtIndex;
public bool showed;
public bool borrowed;
```

### LevelManager.GameLevel

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L91)

```csharp
public int index;
public LevelsRow row;
```

### LevelManager.WeaponLevelDefinition

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/LevelManager.cs#L134)

```csharp
public ObscuredFloat accuracy;
public ObscuredInt ammoCount = 100;
public ObscuredFloat burstLockTime = 0.3f;
public ObscuredInt burstSize = 3;
public ObscuredInt clipSize = 10;
public ObscuredFloat criticalDamage;
public ObscuredFloat damageAmount;
public ObscuredFloat rateOfFire = 1f;
public ObscuredFloat reloadTime = 5f;
```

### MissionDefinition.MissionDefinition

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionDefinition.cs#L7)

```csharp
public int map;
public int objective;
public float maxTimeForMission;
public int scoreFor1Star;
public int scoreFor2Stars;
public int scoreFor3Stars;
public int maxUnits;
public int rewardWarbucks;
public int rewardGold;
public int rewardXP;
public MissionDefinitionMissionTypes type;
public float hpFract;
public float timeFract;
public int recommendedAP;
public int playerEnergy;
public int botEnergy;
public List<MissionDefinitionBehaviour> behaviours;
public List<MissionDefinitionInitialUnit> initialUnits;
public List<MissionDefinitionEvent> events;
public List<MissionDefinitionShieldState> playerShieldStates;
public List<MissionDefinitionShieldState> botShieldStates;
public MissionDefinitionBot bot;
```

### MissionsManager.MissionData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L13)

```csharp
public int attemptCount;
public bool completedAlone;
public bool completedInCoop;
public bool completedInCoopClient;
public int highscore;
public int numberOfStars;
public int attemptHero;
public int attemptCoop;
public int attemptHeroCoop;
```

### MissionsManager.HeroicMissionData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L42)

```csharp
public int goldReward;
public int index;
public int warbucksReward;
public bool completed;
public HeroicType type;
```

### MissionsManager.MissionManagerData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L56)

```csharp
public Dictionary<int, MissionData> missionData = new Dictionary<int, MissionData>();
public HeroicMissionData heroicData = new HeroicMissionData();
```

### PlayerAnalytics.PlayerAnalyticsData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerAnalytics.cs#L11)

```csharp
public int warbucksSpent;
public int goldSpent;
public bool boughtInApp;
public int installTimestamp;
public float realMoneySpent;
public int numberOfSessions;
public int moneyPackDeadline;
public int starterPackDeadline;
public Dictionary<string, int> elitePackDeadlines = new Dictionary<string, int>();
public List<Transaction> transactions;
public Dictionary<string, int> collectedRewards = new Dictionary<string, int>();
public int totalBattles;
public bool chatShown;
public bool elitesShown;
public bool customizationShown;
public bool warpathShown;
public bool cardpoolShown;
public bool craftingShown;
public bool leagueLeaderboardsShown;
public bool anticheatStatus;
public int goldBonuses;
public int rateAppShownCounter;
public string rateAppFirstVersion;
public string rateAppClientVersion;
public int rateAppClickYesCounter;
public int renameCount;
public int squadCreationsCount;
public int matchesToNextLootboxes;
public int lastSeenSquadChatTimeStampDB;
public int instantBattlesTime;
public int instantBattles;
public int paidInstantBattles;
public int cardTutState;
```

### PlayerAnalytics.Transaction

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerAnalytics.cs#L264)

```csharp
public int id;
public string p;
public int gold;
public int wb;
public float money;
```

### PlayerInventory.EquippedWeapon

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerInventory.cs#L10)

```csharp
public int weaponId;
public int weaponUpgrade;
public bool enabled = true;
```

### PlayerInventory.InventorySlot

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerInventory.cs#L20)

```csharp
public int index;
public WeaponCategory category;
public string dictionaryId;
public string iconName;
```

### PlayerInventory.InventoryData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerInventory.cs#L54)

```csharp
public Dictionary<int, SerializedSlotDetail> slots = new Dictionary<int, SerializedSlotDetail>();
```

### PlayerInventory.SerializedSlotDetail

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerInventory.cs#L60)

```csharp
public string name;
public int weaponIndex;
```

### PlayerProperties.PlayerProperties

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerProperties.cs#L6)

```csharp
public List<Tuple<string, CardManager.BuddyCardData>> buddyCards = new List<Tuple<string, CardManager.BuddyCardData>>();
public string chosenCards = string.Empty;
public string country;
public long facebookID;
public bool isInLeague;
public bool isVip;
public League league;
public int leagueMedals;
public int beginnersLeague;
public int medals;
public string name;
public PhotonPlayer photonPlayer;
public string playerID;
public string[] playerVisuals;
public Texture texture;
public int matchMadeGames;
public WarArenaCrown warArenaCrown;
```

### Request.Request

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Request.cs#L4)

```csharp
public DatabaseAction action;
public string data;
```

### SettingsManager.Settings

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SettingsManager.cs#L9)

```csharp
public bool challenge;
public bool squadStatus;
public bool squadEvents;
public bool maintenance;
public bool playerLeague;
public bool dailyRewardNotification;
```

### StarterAssignmentsManager.StarterAssignmentsData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StarterAssignmentsManager.cs#L12)

```csharp
public int deadline;
public Dictionary<string, StarterAssignmentData> assignments = new Dictionary<string, StarterAssignmentData>();
```

### StarterAssignmentsManager.StarterAssignmentData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StarterAssignmentsManager.cs#L15)

```csharp
public bool completed;
public bool claimed;
```

### StatsManager.StatisticsData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StatsManager.cs#L13)

```csharp
public int missionsPlayed;
public int mmmGames;
public int battlesWonRanked;
public int battlesLostRanked;
public float deathMatchWinLooseStreak;
public float deathMatchOfflineWinLooseStreak;
public float deathMatchLossesInRow;
public int battlesWon;
public int battlesLost;
public int battlesLostInRow;
public int kills;
public int vehicleDestroyed;
public int hits;
public int shotsFired;
public int unitsDeployed;
public int cardsPlayed;
public int scorestreakGained;
public int cratesStolen;
public int squadPointsTotal;
public Dictionary<int, int> unitsDeployedSpecific = new Dictionary<int, int>();
public Dictionary<int, int> weaponKills;
public Dictionary<string, int> cardsPlayedSeparately = new Dictionary<string, int>();
public int secondsPlayed;
public int maxMedals;
public League bestLeague;
public int missionsKills;
public int missionsDeaths;
public int missionsHits;
public int missionsShotsFired;
public int missionSucces;
public int arenaAllTimeRuns;
public int arenaBattlesPlayed;
public int arenaWins;
public int arenaFlawless;
public int arenaLootboxes;
public Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;
```

### StatsManager.MatchStats

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StatsManager.cs#L196)

```csharp
public int missionsPlayed;
public int mmmGames;
public int battlesWonRanked;
public int battlesLostRanked;
public float deathMatchWinLooseStreak;
public float deathMatchOfflineWinLooseStreak;
public float deathMatchLossesInRow;
public int battlesWon;
public int battlesLost;
public int battlesLostInRow;
public int kills;
public int vehicleDestroyed;
public int hits;
public int shotsFired;
public int scorestreakGained;
public int cratesStolen;
public int cardsPlayed;
public Dictionary<string, int> cardsPlayedSeparately = new Dictionary<string, int>();
public Dictionary<int, int> weaponKills = new Dictionary<int, int>();
public Dictionary<int, int> unitsDeployedSpecific = new Dictionary<int, int>();
public Dictionary<int, int> unitsSpawnedSpecific = new Dictionary<int, int>();
public int secondsPlayed;
public int missionsKills;
public int missionsDeaths;
public int missionsHits;
public int missionsShotsFired;
public int missionSucces;
public Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;
public int deployClicks;
```

### UpgradeSlots.UnitUpgrades

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UpgradeSlots.cs#L24)

```csharp
public bool isElite;
public bool isSpecial;
public int slotUpgradeindex;
public int slotUpgradeIndexElite;
public int slotUpgradeIndexSpecial;
public float scaleDamage;
public float scaleHp;
```

### UpgradeSlots.VisualSlotMesh

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UpgradeSlots.cs#L79)

```csharp
public MeshRenderer part;
public MeshRenderer partRed;
public int visualSlotId;
```

### UserDeviceManager.UserDevices

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UserDeviceManager.cs#L12)

```csharp
public Dictionary<string, UserDevice> userDevices = new Dictionary<string, UserDevice>();
```

### UserDeviceManager.UserDevice

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UserDeviceManager.cs#L18)

```csharp
public List<int> lastAverageFps = new List<int>();
```

### WarArena.WarArenaData

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArena.cs#L12)

```csharp
public ObscuredInt wins;
public ObscuredInt lives = 3;
public List<string> opponents = new List<string>();
public string arenaId;
public int runs;
public string visualType;
public int visualTimestamp;
public int flawless;
public int topRun;
public int shields;
public bool played;
public bool heartDialogShown;
```

### WarArenaConfig.WarArenaConfig

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaConfig.cs#L7)

```csharp
public Dictionary<LevelBehaviour, int> unitDropRates = new Dictionary<LevelBehaviour, int>();
public List<WarArenaReward> warArenaRewards = new List<WarArenaReward>();
public Dictionary<string, Tuple<string, string>> rulesTexts = new Dictionary<string, Tuple<string, string>>();
public int battles;
public List<Node> nodes = new List<Node>();
public int lootBoxesCount;
public List<PlayWindow> playWindows = new List<PlayWindow>();
public int start;
public int end;
public string rules;
public int lifeCount;
public string arenaName;
public string arenaDescription;
public string id;
```

### WarArenaConfig.Node

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaConfig.cs#L25)

```csharp
public int reviveCost;
public LootBoxType lootBoxType;
public VisualType visualType;
public WarArenaReward visualReward;
```

### WarArenaConfig.PlayWindow

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WarArenaConfig.cs#L76)

```csharp
public int start;
public int end;
public int arenaStartTime;
public int windowIndex;
```

### WinStreakManager.WinStreak

[Source declaration](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WinStreakManager.cs#L8)

```csharp
public int WinCount;
public int TimeStamp;
```

## Appendix E. Complete discovered RPC definition checklist

Every row needs direction/authority classification, replacement DTO, delivery semantics and a parity test before Photon removal. Signatures containing Unity/Photon objects must be translated to IDs/scalars, not copied into the portable SDK. An RPC named damage/kill is not authorization for a Client to cause it.

| Source | Recovered RPC signature |
|---|---|
| [AICarBase](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarBase.cs#L370) | `public override void ReSyncRPC(byte fr, Vector3 positon, Quaternion rotation, UpgradeSlots.UnitUpgrades upgrades, bool spawnedByCard, float progress, string cardId)` |
| [AIObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AIObject.cs#L191) | `protected void SyncUpgradesRPC(byte fr, UpgradeSlots.UnitUpgrades upgrades)` |
| [AIObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AIObject.cs#L223) | `protected void StartEnemyBehaviourNetwork(byte newFraction)` |
| [AIObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AIObject.cs#L245) | `protected void SetPower(byte power)` |
| [AIObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AIObject.cs#L285) | `protected void SpawnByCardRPC(float progress, string cardId)` |
| [AIObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AIObject.cs#L348) | `public virtual void ReSyncRPC(byte fr, Vector3 positon, Quaternion rotation, UpgradeSlots.UnitUpgrades upgrades, bool spawnedByCard, float progress, string cardId)` |
| [AIObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AIObject.cs#L366) | `public virtual void ReSyncDisabledRPC()` |
| [BatchedWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BatchedWeapon.cs#L58) | `private void ShootBatchRPC(Vector3 position, int fakeAndRealShotsMask, bool shootLocaly, byte shotType, byte batchSize)` |
| [CardIconIndicator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardIconIndicator.cs#L95) | `public void UpdateIndicatorRPC(int iconId, float fract)` |
| [CardIconIndicator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardIconIndicator.cs#L113) | `public void Show2RPC(int iconId, bool show)` |
| [CardIconIndicator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardIconIndicator.cs#L129) | `public void ShowRPC(int iconId, float duration, float fullDuration, bool animated)` |
| [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L696) | `private void CardWasUsedOnline(string cardId, byte fraction, int playerID)` |
| [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L854) | `private void PlayCardRPC(string id, byte fraction, int playerId)` |
| [CardManagerDeathmatchOffline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManagerDeathmatchOffline.cs#L261) | `private void PlayCard(string id, byte fraction)` |
| [CardManagerDeathmatchOffline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManagerDeathmatchOffline.cs#L290) | `private void CardWasUsedOnline(string id, byte fraction)` |
| [Crane](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Crane.cs#L76) | `protected void StartCraneAnimationRPC(float time)` |
| [Crane](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Crane.cs#L116) | `private void PickMagneticObjectRPC(byte index)` |
| [Crane](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Crane.cs#L144) | `private void PickDropPointRPC(byte index)` |
| [Decoy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Decoy.cs#L88) | `protected void SetupRPC(byte fr)` |
| [Decoy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Decoy.cs#L105) | `protected void OnDeathRPC()` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L582) | `protected virtual void RefillRPC(float health, float maxHealth)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L591) | `protected void SetIsImmortalRPC(bool value)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L678) | `protected virtual void DamageEvent(float health, byte type, byte prefabIndex, byte indexInPool)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L684) | `protected virtual void DamageEventShoot(float health, byte type, byte prefabIndex, byte indexInPool, byte partIndex, Vector3 pos)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L690) | `protected virtual void DeathEvent(float health, byte type, byte prefabIndex, byte indexInPool, Vector3 force)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L696) | `protected virtual void DeathEventShoot(float health, byte type, byte prefabIndex, byte indexInPool, byte partIndex, Vector3 pos, Vector3 force)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L722) | `protected virtual void DamageEventPlayer(float health, byte type, byte playerIndex)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L728) | `protected virtual void DamageEventPlayerShoot(float health, byte type, byte playerIndex, byte partIndex, Vector3 position)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L734) | `protected virtual void DeathEventPlayer(float health, byte type, byte playerIndex, Vector3 force)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L740) | `protected virtual void DeathEventPlayerShoot(float health, byte type, byte playerIndex, byte partIndex, Vector3 position, Vector3 force)` |
| [DestroyableObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DestroyableObject.cs#L794) | `protected void SyncNetwork(float health, float maxHealth, bool isDead)` |
| [Drone](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Drone.cs#L129) | `protected void SetTransparent(bool isTransparent)` |
| [ElectricTrap](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ElectricTrap.cs#L82) | `protected void SetTrapRPC(bool visible)` |
| [ElectricTrap](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ElectricTrap.cs#L94) | `protected void ExplodeRPC(Vector3 position)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L956) | `private void PlayeScifiParticles(bool enable)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L1656) | `public void FreezeRPC(bool freeze)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2180) | `public void SnapColt(bool toCover)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2247) | `private void BuildMortar()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2261) | `private void FireMortar()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2324) | `private void ShootFromCrawl(float hideAfter)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2337) | `private void ShootStandNew(float hideAfter)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2350) | `private void Crawl()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2371) | `private void Idle()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2381) | `public void SittingIdle()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2391) | `private void Repair()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2401) | `private void StartFlying()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2411) | `private void ShootFromCover(bool right, float hideAfter)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2428) | `private void Walk()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2441) | `private void RopeSlide()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2451) | `private void ThrowGrenadeFromCrawl()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2461) | `private void ShootFromShield()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2471) | `private void ThrowGrenadeFromCover(bool right)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2481) | `private void ShootFromBazookaFromCrawl()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2491) | `private void ShootFromBazookaFromCover(bool right)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2501) | `private void ShootStand()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2511) | `private void ShootWalk(Vector3 dir)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2524) | `private void ShootAdditive()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2534) | `private void ShadowSetActive(bool value)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2544) | `public void SoldierBehaviourSwitchWeapon(bool isSecondary)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2553) | `private void SoldierBehaviourStartShootingNetwork(Vector3 position, int fakeAndRealShots, bool isNetworkCopy, byte shotType, byte batchSize)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2562) | `private void SetCanDie(bool canDieValue)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2568) | `public void ChangeWeightForDestroyablePart(float mult, int index)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2575) | `public void ChangeWeightForDestroyablePartRPC(float mult, int index)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2591) | `public void ShowEngineerBuildingIndicator(bool show, byte soldierFraction)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2597) | `public void UpdateEngineerBuildingIndicator(float progress)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2603) | `public void ImproveAllWeaponsRPC(float multiplayer)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2609) | `public void WeaponIgnoreLayer(int layer)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2628) | `private void UpdateHeadScaleRPC(float newScale)` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2781) | `private void Warp()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2793) | `private void WarpIdle()` |
| [EnemyController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2813) | `private void SyncWarperRPC(Vector3 position, Quaternion rotation)` |
| [ExplosionManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ExplosionManager.cs#L45) | `protected void MissileExplodeRPC(Vector3 position, float explodeDamage, float damageAmount, float deadRadius, float hurtRadius, Vector3 exposionCoef, float additionalUpForce, float playerBehindShieldRatio, int explosionType)` |
| [GameControllerCoop](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerCoop.cs#L310) | `private void FinishGameCoopClient(byte gameEndReason, int playerId)` |
| [GameControllerCoop](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerCoop.cs#L341) | `protected override void FinishGameMultiplayerRPC(byte gameEndReason)` |
| [GameControllerDeathMatch](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerDeathMatch.cs#L97) | `protected override void FinishGameMultiplayerRPC(byte gameEndReason)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L257) | `protected void LoadingFinishedRPC(int playerID, int stateCounter)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L369) | `public virtual void FinishChoosingCardsRPC(string upgradesJson, int playerId, int stateCounter, string chosenCards, string selectedBuddyCards)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L422) | `protected void StartCameraAnimationFinishedRPC(int id)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L499) | `public void RematchRPC(int playerID, int stateUpdate)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L687) | `private void ResyncTimeRPC(float syncTime)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L721) | `protected void SetMapRPC(int i)` |
| [GameControllerOnline](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerOnline.cs#L1096) | `protected virtual void FinishGameMultiplayerRPC(byte gameEndReason)` |
| [GameControllerWarArena](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerWarArena.cs#L145) | `protected override void FinishGameMultiplayerRPC(byte gameEndReason)` |
| [Grenade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Grenade.cs#L57) | `public override void ShootCopyRPC(int index, Vector3 from, Vector3 to, byte ID, bool isFakeShot)` |
| [GrenadeAmmoBase](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GrenadeAmmoBase.cs#L253) | `public void ExplodeNetwork(Vector3 position)` |
| [Helicopter](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Helicopter.cs#L345) | `private void ShowRope()` |
| [Kevlar](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Kevlar.cs#L69) | `private void SyncKevlar(float health, float maxHealth)` |
| [Kevlar](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Kevlar.cs#L81) | `private void SetUpKevlarNetwork(float maxHealth, int stackIndex)` |
| [KillStreakManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/KillStreakManager.cs#L192) | `private void SpawnBonusNetwork(byte boxIndexInObjectPool, Vector3 position, int bonusIndex, byte playerID, int boxId)` |
| [KillStreakManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/KillStreakManager.cs#L239) | `private void ActivateBonusResultRPC(int id, bool res)` |
| [KillStreakManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/KillStreakManager.cs#L245) | `private void TryActivateBonusRPC(int boxID, double serverTime)` |
| [KillStreakManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/KillStreakManager.cs#L286) | `private void BoobyTrapSetRPC(byte bits)` |
| [MagneticObject](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MagneticObject.cs#L74) | `private void Sync(Vector3 pos, Quaternion rot)` |
| [MatchManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MatchManager.cs#L567) | `public void StartOverTime_RPC()` |
| [MatchManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MatchManager.cs#L643) | `private void SetHitByPlayerRPC(int playerID)` |
| [MatchManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MatchManager.cs#L658) | `private void SetHitByUnitRPC(string unitN, int unitL, string unitSprite, bool isCard)` |
| [MatchManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MatchManager.cs#L670) | `private void EnviromentalHitRPC()` |
| [MechAnimator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MechAnimator.cs#L42) | `public void Walk()` |
| [MechAnimator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MechAnimator.cs#L53) | `public void Shoot()` |
| [MechAnimator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MechAnimator.cs#L63) | `public void StopShoot()` |
| [MechAnimator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MechAnimator.cs#L73) | `public void Idle()` |
| [MechAnimator](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MechAnimator.cs#L84) | `public void Strafe(bool left)` |
| [MineAmmo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MineAmmo.cs#L171) | `public void SendExplode()` |
| [MineAmmo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MineAmmo.cs#L183) | `protected void SetBlinkIntervalRPC(float value)` |
| [MineAmmo](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MineAmmo.cs#L189) | `protected void SetBeepRPC(bool value)` |
| [MiniDrone](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MiniDrone.cs#L82) | `private void SetFractionRPC(byte byteFraction)` |
| [MiniDrone](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MiniDrone.cs#L111) | `private void PlaySparks()` |
| [Missile](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Missile.cs#L106) | `protected void SyncTrajectoryRPC(float middleRot, float nrOfRotations, float rotatemagnitude)` |
| [MissionsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L312) | `protected void MissionSucceededRPC(int missionIndex)` |
| [MissionsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L605) | `private void LoadUnitsVisualsRPC(int missionIndex)` |
| [Mortar](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Mortar.cs#L31) | `public override void ShootCopyRPC(int index, Vector3 from, Vector3 to, byte playerID, bool isFakeShot)` |
| [NetworkObjectPool](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/NetworkObjectPool.cs#L153) | `private void NetworkReInstantiate(int prefabIndex, int indexInObjectPool, Vector3 position, Quaternion rotation)` |
| [NetworkObjectPool](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/NetworkObjectPool.cs#L169) | `private void NetworkReInstantiate_1(int prefabIndex, int indexInObjectPool)` |
| [NetworkObjectPool](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/NetworkObjectPool.cs#L217) | `private void NetworkInstantiate(int index, Vector3 position, Quaternion rotation)` |
| [Parachute](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Parachute.cs#L100) | `private void LandedNetwork()` |
| [PhysicalAmmoWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PhysicalAmmoWeapon.cs#L56) | `public virtual void ShootCopyRPC(int index, Vector3 from, Vector3 to, byte playerID, bool isFakeShot)` |
| [PhysicalAmmoWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PhysicalAmmoWeapon.cs#L77) | `public override void FireNetworkRPC(Vector3 to, bool fake, byte type)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L337) | `public void ChangeWeightForDestroyablePartRPC(float mult, int index)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L343) | `private void SetCurrentPoint(int index)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L352) | `public void AddAmmoRPC(int index, int amount)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L364) | `public void SetNoDamageChanceRPC(float chance)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L570) | `private void InitBotRPC(byte f)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L600) | `private void PlayTrailRPC(Vector3 from, Vector3 to, float time)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L972) | `public void PlayShotAnimationNetwork(byte weapon, bool right)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L1007) | `public void Uncover(bool right, bool hideBack)` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L1033) | `private void Idle()` |
| [PlayerController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L1043) | `private void Walk()` |
| [ScoreManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ScoreManager.cs#L196) | `private void RecieveOponentScore(int score)` |
| [ScoreManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ScoreManager.cs#L203) | `private void RecieveSkillShotsCount(int skillShot, int skillshotCount)` |
| [ScoreManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ScoreManager.cs#L249) | `private void AddCoopScoreRPC(int scoreToAdd)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L136) | `private void SetCanRegenerateRPC(bool value)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L142) | `private void SetAutoRepairRPC(bool value)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L148) | `private void SetPlayer(int playerID)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L163) | `private void SetShieldRefresTimeRPC(float seconds)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L356) | `protected override void RefillRPC(float health, float maxHealth)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L398) | `private void GetLockRPC()` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L409) | `private void GetLockResultRPC(byte res)` |
| [Shield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Shield.cs#L436) | `protected void SyncShieldRPC(float health, float maxHealth, bool isDead)` |
| [SkillShotController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SkillShotController.cs#L196) | `protected void RecieveSkillshot(int type, int power, int playerId)` |
| [SkillShotControllerBonusBox](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SkillShotControllerBonusBox.cs#L17) | `protected void RecieveStolen(byte fraction)` |
| [SlowMotionManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SlowMotionManager.cs#L75) | `protected void SlowMotionForNetwork(float seconds)` |
| [SoldierBehaviour](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviour.cs#L484) | `protected virtual void AttachWeaponsRPC(byte[] indices)` |
| [SoldierBehaviourBuddy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviourBuddy.cs#L111) | `public void ChangeCamoRPC(string equippedVisualsString)` |
| [SoldierBehaviourBuddy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviourBuddy.cs#L132) | `private void SetWeaponsUpgradeRPC(int level, int levelSec)` |
| [SoldierBehaviourBuddy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviourBuddy.cs#L138) | `private void ChangeWeaponsRPC(int primaryIndex, int secondaryIndex)` |
| [SoldierBehaviourBuddy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviourBuddy.cs#L197) | `private void PickUpgradesRPC(int buddyType, int weaponCategory, float progress, float hpToAdd, float damageToAdd, int primary, int secondary)` |
| [SoldierBehaviourBuddy](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviourBuddy.cs#L280) | `private void ShowNameRPC(string buddyName)` |
| [SoldierBehaviourCommando](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierBehaviourCommando.cs#L102) | `protected override void AttachWeaponsRPC(byte[] indices)` |
| [SpawningManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SpawningManager.cs#L71) | `private void SpawnForCardRPC(int behaviourIndex, int count, float progress, byte fraction, Vector3 position, bool spawnEnabled)` |
| [SpawningManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SpawningManager.cs#L127) | `private void SpawnAIObjectRPC(int indexInPool, int indexOfObject, byte fraction, Vector3 pos)` |
| [SpawningManagerDeathMatch](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs#L750) | `private void SendUnitRPC(int index, byte fraction, bool useEnergy)` |
| [SpawningManagerDeathMatch](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs#L781) | `private void GetRandomUnitsForHost(byte fraction, int playerID)` |
| [SpawningManagerDeathMatch](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs#L798) | `private void RecieveRandomUnitsForHost(byte[] armies, int id)` |
| [SpawningManagerDeathMatch](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs#L909) | `private void ReSyncPowerRPC(int masterPower, int clientPower)` |
| [TimeManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/TimeManager.cs#L166) | `private void PauseGameRPC(bool focusLost, bool setTime, int playerID, int counter)` |
| [TimeManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/TimeManager.cs#L211) | `private void ResumeGameRPC()` |
| [Train](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Train.cs#L119) | `private void StartMovementAtTimeRPC(double time, byte[] array, bool reverse)` |
| [TurretBase](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/TurretBase.cs#L156) | `protected void SetShieldPositionRPC(int playerPositionIndex, int turretPositionIndex)` |
| [TurretWeaponBasic](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/TurretWeaponBasic.cs#L277) | `protected void AimNetwork(Vector3 position)` |
| [UnitShield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UnitShield.cs#L98) | `private void SyncShield(float health, int hitCount)` |
| [UnitShield](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/UnitShield.cs#L113) | `private void SetUpShieldNetwork(float maxHealth)` |
| [WaveManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WaveManager.cs#L227) | `private void SpawnWaveAIObjectRPC(int indexInPool, int indexOfObject)` |
| [Weapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Weapon.cs#L273) | `public virtual void FireNetworkRPC(Vector3 to, bool fake, byte type)` |
| [Weapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Weapon.cs#L327) | `public void SetBullletSpeedCoef(float coef)` |
| [WeaponInventory](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponInventory.cs#L198) | `private void ChangeWeapon(byte weaponIndex)` |

## Appendix F. Photon stream and buffered-call discovery

Streams are positional contracts: open each method and record write/read order, conditional branches and owner direction. These locations include calls as well as definitions. The existing JSON inventory separately records literal RPC call sites and PhotonView asset attachments.

| Source | OnPhotonSerializeView line(s) |
|---|---|
| AICar | [83](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICar.cs#L83), [85](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICar.cs#L85) |
| AICarBase | [283](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarBase.cs#L283), [287](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarBase.cs#L287), [294](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarBase.cs#L294) |
| AICarBuggy | [191](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarBuggy.cs#L191), [193](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarBuggy.cs#L193) |
| AICarTransporter | [183](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarTransporter.cs#L183), [185](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AICarTransporter.cs#L185) |
| AssaultHelicopter | [348](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssaultHelicopter.cs#L348), [350](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssaultHelicopter.cs#L350) |
| Crane | [257](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Crane.cs#L257) |
| DroneSteering | [233](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DroneSteering.cs#L233), [235](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DroneSteering.cs#L235) |
| EnemyController | [2290](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2290), [2299](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2299), [2306](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/EnemyController.cs#L2306) |
| Helicopter | [377](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Helicopter.cs#L377), [379](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Helicopter.cs#L379) |
| Mech | [265](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Mech.cs#L265), [267](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Mech.cs#L267) |
| MechAnimator | [134](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MechAnimator.cs#L134) |
| MissionsManager | [381](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MissionsManager.cs#L381) |
| Parachute | [153](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Parachute.cs#L153), [155](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Parachute.cs#L155) |
| PhotonTransform | [71](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PhotonTransform.cs#L71) |
| PlayerController | [1053](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L1053), [1057](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L1057), [1064](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerController.cs#L1064) |
| ScoreManager | [327](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ScoreManager.cs#L327) |
| Tank | [332](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Tank.cs#L332), [336](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Tank.cs#L336), [341](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Tank.cs#L341) |
| TimeManager | [337](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/TimeManager.cs#L337) |
| Train | [212](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/Train.cs#L212) |

### Buffered request producers

Action-specific `data` schemas are assembled at these call sites. Read dictionary/object construction before the call; direct HTTP field candidates in Appendix B do not describe this inner JSON.

| Source | Buffered action references |
|---|---|
| [ArmyLeftBuffDialog](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyLeftBuffDialog.cs#L1) | [208 ConvertPartsToScraps](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyLeftBuffDialog.cs#L204), [207 ConvertScrapsToParts](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyLeftBuffDialog.cs#L230) |
| [ArmyScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L1) | [1003 UpdateEquippedUnits](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L719), [80 BuyUnit](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L735), [125 InstantBuyUnit](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L755), [127 ActivateUnit](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L778), [158 PromoteUnit](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L830), [77 BuyUnitUpgrade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L846), [78 InstantUnitUpgrade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L882), [79 ActivateUnitUpgrade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L910), [209 UpgradeEliteSlot](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L929), [209 UpgradeEliteSlot](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L952), [105 ArmyUnitWasShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ArmyScreen.cs#L972) |
| [AssignmentsManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssignmentsManager.cs#L1) | [171 ClaimAssignment](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/AssignmentsManager.cs#L287) |
| [CamosScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L1) | [109 BuyDecal](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L801), [191 VisualWasShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L809), [110 EquipDecal](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CamosScreen.cs#L817) |
| [CardManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L1) | [97 BuyCardPack](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L550), [97 BuyCardPack](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs#L637) |
| [MessageManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MessageManager.cs#L1) | [194 MessageWasShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MessageManager.cs#L41), [12 IgnoreMessage](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/MessageManager.cs#L51) |
| [PlayerAnalytics](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerAnalytics.cs#L1) | [193 SaveLastSeenSquadChatTimeStamp](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PlayerAnalytics.cs#L304) |
| [StarterAssignment](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StarterAssignment.cs#L1) | [186 ClaimStarterAssignment](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/StarterAssignment.cs#L63) |
| [WeaponScreen](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L1) | [76 BuyWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L631), [126 InstantBuyWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L651), [128 ActivateWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L671), [73 BuyWeaponUpgrade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L707), [74 InstantWeaponUpgrade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L738), [75 ActivateWeaponUpgrade](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L760), [104 WeaponWasShown](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L777), [116 EquipWeapon](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/WeaponScreen.cs#L788) |

## Appendix G. Catalog schema inventory

These are schema class names, not proof of populated/validated table rows. Recover serialized values and the consuming gameplay mappings as described in section 5.

- [AchievementsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AchievementsRow.cs#L1), [ArenaLootboxesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/ArenaLootboxesRow.cs#L1), [ArmyUpgradesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/ArmyUpgradesRow.cs#L1), [AssaultRifle_AK47EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_AK47EliteRow.cs#L1), [AssaultRifle_AK47Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_AK47Row.cs#L1), [AssaultRifle_AKS47URow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_AKS47URow.cs#L1)
- [AssaultRifle_FamasEliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_FamasEliteRow.cs#L1), [AssaultRifle_FamasRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_FamasRow.cs#L1), [AssaultRifle_G36EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_G36EliteRow.cs#L1), [AssaultRifle_G36Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_G36Row.cs#L1), [AssaultRifle_M16Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_M16Row.cs#L1), [AssaultRifle_QBZ95EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_QBZ95EliteRow.cs#L1)
- [AssaultRifle_QBZ95Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_QBZ95Row.cs#L1), [AssaultRifle_SteyrAUGRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssaultRifle_SteyrAUGRow.cs#L1), [AssignmentDefinitionsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/AssignmentDefinitionsRow.cs#L1), [BalanceTableRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/BalanceTableRow.cs#L1), [Bazooka_FGMEliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_FGMEliteRow.cs#L1), [Bazooka_FGMRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_FGMRow.cs#L1)
- [Bazooka_HaterRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_HaterRow.cs#L1), [Bazooka_HMVRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_HMVRow.cs#L1), [Bazooka_M202Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_M202Row.cs#L1), [Bazooka_PanzerfaustRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_PanzerfaustRow.cs#L1), [Bazooka_RPG7Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Bazooka_RPG7Row.cs#L1), [BonussesDefinitionsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/BonussesDefinitionsRow.cs#L1)
- [BotNamesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/BotNamesRow.cs#L1), [CardConstantsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/CardConstantsRow.cs#L1), [CardDefinitionsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/CardDefinitionsRow.cs#L1), [CardPacksRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/CardPacksRow.cs#L1), [ConstantsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/ConstantsRow.cs#L1), [CountryInfoRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/CountryInfoRow.cs#L1)
- [CratesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/CratesRow.cs#L1), [DBUpgradeSlotsAssaulterRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsAssaulterRow.cs#L1), [DBUpgradeSlotsAssaultHeliRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsAssaultHeliRow.cs#L1), [DBUpgradeSlotsBazookaRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsBazookaRow.cs#L1), [DBUpgradeSlotsBuddyRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsBuddyRow.cs#L1), [DBUpgradeSlotsCarBuggyRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsCarBuggyRow.cs#L1)
- [DBUpgradeSlotsCarRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsCarRow.cs#L1), [DBUpgradeSlotsCommandoRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsCommandoRow.cs#L1), [DBUpgradeSlotsDroneRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsDroneRow.cs#L1), [DBUpgradeSlotsEngineerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsEngineerRow.cs#L1), [DBUpgradeSlotsFlamethrowerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsFlamethrowerRow.cs#L1), [DBUpgradeSlotsGrennaderRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsGrennaderRow.cs#L1)
- [DBUpgradeSlotsGunslingerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsGunslingerRow.cs#L1), [DBUpgradeSlotsHeavyTurretRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsHeavyTurretRow.cs#L1), [DBUpgradeSlotsHelicopterRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsHelicopterRow.cs#L1), [DBUpgradeSlotsMachineGunnerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsMachineGunnerRow.cs#L1), [DBUpgradeSlotsMechRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsMechRow.cs#L1), [DBUpgradeSlotsMinigunnerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsMinigunnerRow.cs#L1)
- [DBUpgradeSlotsMortarRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsMortarRow.cs#L1), [DBUpgradeSlotsParachuterRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsParachuterRow.cs#L1), [DBUpgradeSlotsRockyTurretRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsRockyTurretRow.cs#L1), [DBUpgradeSlotsSciFiRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsSciFiRow.cs#L1), [DBUpgradeSlotsShotgunnerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsShotgunnerRow.cs#L1), [DBUpgradeSlotsSniperRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsSniperRow.cs#L1)
- [DBUpgradeSlotsSwatRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsSwatRow.cs#L1), [DBUpgradeSlotsTankRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsTankRow.cs#L1), [DBUpgradeSlotsTransporterRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsTransporterRow.cs#L1), [DBUpgradeSlotsTurretRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsTurretRow.cs#L1), [DBUpgradeSlotsWarperRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/DBUpgradeSlotsWarperRow.cs#L1), [Grenade_FLASHRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_FLASHRow.cs#L1)
- [Grenade_FRAGRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_FRAGRow.cs#L1), [Grenade_M84Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_M84Row.cs#L1), [Grenade_MolotovRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_MolotovRow.cs#L1), [Grenade_POISONRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_POISONRow.cs#L1), [Grenade_SMOKEEliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_SMOKEEliteRow.cs#L1), [Grenade_SMOKERow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Grenade_SMOKERow.cs#L1)
- [GrenadeLauncher_M320Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/GrenadeLauncher_M320Row.cs#L1), [HeroicRewardsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/HeroicRewardsRow.cs#L1), [IGoogle2uRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/IGoogle2uRow.cs#L1), [InAppsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/InAppsRow.cs#L1), [LevelsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LevelsRow.cs#L1), [LMG_M249EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_M249EliteRow.cs#L1)
- [LMG_M249Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_M249Row.cs#L1), [LMG_M60EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_M60EliteRow.cs#L1), [LMG_M60Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_M60Row.cs#L1), [LMG_MG4Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_MG4Row.cs#L1), [LMG_MinigunRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_MinigunRow.cs#L1), [LMG_PKMachinegunEliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_PKMachinegunEliteRow.cs#L1)
- [LMG_PKMachinegunRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_PKMachinegunRow.cs#L1), [LMG_SA80Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LMG_SA80Row.cs#L1), [LootboxesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/LootboxesRow.cs#L1), [MatchMakingConstantsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/MatchMakingConstantsRow.cs#L1), [MatchMakingDeviationRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/MatchMakingDeviationRow.cs#L1), [MissionsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/MissionsRow.cs#L1)
- [PacksRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/PacksRow.cs#L1), [Pistol_BerretaRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Pistol_BerretaRow.cs#L1), [Pistol_DesertEagleRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Pistol_DesertEagleRow.cs#L1), [Pistol_JesterRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Pistol_JesterRow.cs#L1), [Pistol_M1911Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Pistol_M1911Row.cs#L1), [Pistol_Magnum357Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Pistol_Magnum357Row.cs#L1)
- [Pistol_Remmington51Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Pistol_Remmington51Row.cs#L1), [PlayerBotDiffcultiesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/PlayerBotDiffcultiesRow.cs#L1), [PlayerBotsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/PlayerBotsRow.cs#L1), [PlayerLeaderboardsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/PlayerLeaderboardsRow.cs#L1), [PlayerVisualsRaritiesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/PlayerVisualsRaritiesRow.cs#L1), [PlayerVisualsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/PlayerVisualsRow.cs#L1)
- [Shotgun_AA12Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_AA12Row.cs#L1), [Shotgun_BenelliRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_BenelliRow.cs#L1), [Shotgun_BlackhandRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_BlackhandRow.cs#L1), [Shotgun_SaigaEliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_SaigaEliteRow.cs#L1), [Shotgun_SaigaRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_SaigaRow.cs#L1), [Shotgun_SawnOffRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_SawnOffRow.cs#L1)
- [Shotgun_SPASRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_SPASRow.cs#L1), [Shotgun_StrikerEliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_StrikerEliteRow.cs#L1), [Shotgun_StrikerRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/Shotgun_StrikerRow.cs#L1), [SkillshotsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SkillshotsRow.cs#L1), [SMG_CPWRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_CPWRow.cs#L1), [SMG_MP5_eliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_MP5_eliteRow.cs#L1)
- [SMG_MP5Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_MP5Row.cs#L1), [SMG_MP7Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_MP7Row.cs#L1), [SMG_P90EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_P90EliteRow.cs#L1), [SMG_P90Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_P90Row.cs#L1), [SMG_UMP45Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_UMP45Row.cs#L1), [SMG_VectorRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SMG_VectorRow.cs#L1)
- [SniperRifle_AWMFRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_AWMFRow.cs#L1), [SniperRifle_DragunovRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_DragunovRow.cs#L1), [SniperRifle_M110EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_M110EliteRow.cs#L1), [SniperRifle_M110Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_M110Row.cs#L1), [SniperRifle_M24Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_M24Row.cs#L1), [SniperRifle_M90EliteRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_M90EliteRow.cs#L1)
- [SniperRifle_M90Row](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_M90Row.cs#L1), [SniperRifle_MSRRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SniperRifle_MSRRow.cs#L1), [SquadEmblemsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SquadEmblemsRow.cs#L1), [SquadLeaderboardsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SquadLeaderboardsRow.cs#L1), [SquadsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SquadsRow.cs#L1), [SquadWarsRewardRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/SquadWarsRewardRow.cs#L1)
- [StarterAssignmentsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/StarterAssignmentsRow.cs#L1), [StringConstantsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/StringConstantsRow.cs#L1), [TaskDefinitionsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/TaskDefinitionsRow.cs#L1), [UnitsContantsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/UnitsContantsRow.cs#L1), [VersionsRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/VersionsRow.cs#L1), [VIPRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/VIPRow.cs#L1)
- [WarArenaParametersRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/WarArenaParametersRow.cs#L1), [WeaponUpgradesRow](Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/WeaponUpgradesRow.cs#L1)

## Appendix H. Evidence digests and refresh

Refresh only these appendices with `python Server/tools/build_server_guide_appendices.py`. The authored guide must be reviewed separately when behavior changes. This lexical inventory scans top-level recovered gameplay scripts and Google2u schemas; third-party nested folders are not gameplay specifications.

| Source | SHA-256 |
|---|---|
| [DatabaseAction](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/DatabaseAction.cs#L1) | `7042f3caf46c97a603d2796549f38c176b4e7aa400a70106f39295f7387c59f5` |
| [BeanstalkServerManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs#L1) | `aad36783d45d6ba807a36b37e2ae812fc6fa33afdfcb660acb0637a928580e0f` |
| [ServerResponseHandler](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs#L1) | `a4faa120eebe50fb7ed38b0f3b7000f5a86a6d186747c67f63dc2b07e6edb359` |
| [RequestBuffer](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/RequestBuffer.cs#L1) | `fd3aa3bc0e97611225afbf8313141f6c50ada33ed7a9e643d7d1f4bd70ef8e9d` |
| [GameController](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameController.cs#L1) | `f15ff3ee3387dfa6272ea9c56d82df15dd74e66a6ba1a0dc281f2e9ade73949b` |
| [PhotonConnectionManager](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/PhotonConnectionManager.cs#L1) | `5f62e1541a4f9fdde603a749618fb46362de640c4844338db3833ea82c79f957` |
| [CustomTypes](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CustomTypes.cs#L1) | `c58b7a591fc32c9d4f357cb1a28dd36583668e6f2a7e765b451687a579558384` |

Inventory totals: **175 named actions; 108 direct builder entries; 16 serialized subsystem managers; 165 RPC definitions; 35 serialization occurrences; 134 Google2u row schemas**. Counts measure source discovery, not implementation completeness.
