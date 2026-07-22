# WarFriends backend feature implementation tracker

This is the source-of-truth backlog for the reconstructed backend. It is derived from the
1.6.0 recovered `DatabaseAction` enum and the current `Server/src` implementation.

Status legend:

- **Implemented** — persistent logic, validation, and a tested runtime path exist.
- **Partial** — useful server logic exists, but one or more client contracts or gameplay
  rules are still missing.
- **Missing** — the action is rejected with error code `90`; no false-success response.
- **Telemetry** — deliberately accepted as a no-op because it does not mutate gameplay.

### Recovered-client gap corrections

- **Google Play RTDN is now an authenticated durable wake-up path.** The provider-only route
  verifies Google's OIDC signature/audience plus the exact configured service-account email,
  subscription resource, Android package, canonical Pub/Sub envelope, and one mutually exclusive
  notification before acknowledging. Unique message IDs bind to the decoded payload digest; raw
  purchase tokens become the shared receipt HMAC, and pending-refund tokens use event-bound
  AES-GCM. A renewable-lease worker reuses `subscriptionsv2.get` for subscriptions and the complete
  Voided Purchases sweep for one-time refunds, with whole-batch authority validation, durable retry,
  compare-and-set completion, and terminal TTL. One-time purchases still grant only through the
  client `products.get` path. Pending refund reviews now enter a protected bounded operator queue;
  an exact actor/idempotency-bound recommendation is validated, encrypted, and durably sealed
  before the leased worker calls `orders.reviewrefund`. Google's first accepted call wins, so a
  lost response can resend only the same ciphertext-bound request, and successful local completion
  atomically closes both ledgers with a terminal TTL without changing entitlement directly.
- **Remote configuration targeting no longer widens malformed stock requests.** Recovered action
  157 sends exact `abTestVariant`, `SheetConfiguraton`, and `Language` strings. Missing, numeric,
  padded, control-bearing, delimiter-bearing, or conflicting cache-ID aliases now receive only the
  callback-safe `success;0;{}`/no-publication path instead of being trimmed, stringified, sanitized,
  or replaced with wildcard selectors that could choose a signed balancing release. Partial
  rollout hashing accepts only exact agreeing `PlayerId`/JSON `id`; the stock pre-login `null`
  sentinel and upper-case login/action `Id` can no longer choose a player bucket.
- **Squad Wars division lookup now preserves the server-authored round identity exactly.** The
  recovered client echoes its cached `RoundId` without normalization. Action 124 therefore accepts
  only that canonical field as a bounded string and rejects numeric, alias-only, padded, malformed,
  or control-bearing input instead of trimming it into another division's placement authority.
- **Reusable account creation now preserves opaque identity metadata exactly.** The shared account
  service validates DeviceToken, Locale, and an optional Game Center ID before password hashing or
  MongoDB work, and writes the same exact token and platform ID into both indexed and embedded
  player mirrors. First-time Game Center creation no longer trims a padded external ID into a
  different identity; malformed direct/internal calls fail before the account/identity transaction.
- **First-account locale now commits with the account instead of defaulting every player to
  English.** Recovered CreateAccount and CreateGcAccount require exact `Locale` plus a finite
  invariant-C# `UtcOffset` hint; optional DeviceToken remains an exact opaque string. Locale is
  revalidated at the reusable account service and stored in the same player insert/identity
  transaction. The offset is bounded diagnostics only and never calendar/reward time authority.
  Client `StartingGold`/`StartingWarbucks` Fusebox values remain completely ignored; decoded
  server-owned onboarding policy still owns starting currency.
- **Provider display names now preserve their exact recovered request contract.** Facebook and
  Google Play links require canonical nonempty `Name`; Game Center links/updates retain the exact
  absent/empty name because their recovered builders send none. `PlayerName` may only be an exact
  agreeing duplicate when `Name` is present and can never authorize metadata alone. Request and
  service boundaries reject numeric, padded, control-bearing, or over-100-character names rather
  than stringifying, trimming, or slicing distinct inputs into one durable identity.
- **Direct inventory compatibility routes no longer accept alias-only mutation authority.** The
  stock client keeps weapon/unit/visual acknowledgements, purchases, and equips inside exact
  `RequestBuffer.data`. Explicit replacement-client routes now require `LevelName`, `ObjData`, or
  `DecalId` as their canonical outer field; legacy `Name`/`Data`/`data` values may only accompany
  and exactly duplicate it. Ambiguous direct action 108 remains acknowledged telemetry and cannot
  mark a visual shown merely because a caller supplies a visual-looking alias.
- **Player profile mutations now use the exact recovered request boundary.** Action 29 mutates
  only from `PlayerStatus`; a diagnostic `Status` field can only be an agreeing duplicate and
  malformed, conflicting, or Status-only heartbeats retain callback-safe `Time` without refreshing
  durable presence. Action 196 requires `NewCountryCode`, with `Country` permitted only as an
  agreeing duplicate. Action 13 validates `DeviceToken` and `Locale` together before constructing
  its one changed-subset write, so an incomplete or malformed pair cannot partially refresh the
  stored profile.
- **Loyalty is not a backend action in recovered 1.6.0.** Its only concrete occurrence is the
  `InappScreen.MPJAFCCIOEO.Loyalty` presentation-tab enum and tab-selection UI. There is no Loyalty
  `DbAction`, request builder, durable DTO field, response parser, or balancing table in the
  recovered scripts. Loyalty visuals remain catalog-classified and fail closed, but a separate
  Loyalty backend feature is not missing unless later evidence supplies a real contract.
- **The paid extra War Card slot is implemented.** Reviewed value-pack entitlements set durable
  `CardManagerData.extraSlot`; purchase receipts record whether the pack introduced it, boot
  restores it, shared authority rejects non-Boolean state, and void reversal removes it only after
  the last active granting receipt disappears. The recovered battle selection has three normal
  slots plus VIP, paid-extra, and Buddy candidates, so PvP's six-card bound already covers it.
  The remaining Squad-card gap is only the unmodified client's lack of a nonce/adapter for a
  server-selected Buddy identity.
- **The diagnostic operator consumer is implemented.** Admin-Bearer-only list endpoints cover
  analytics, support logs, and client errors with bounded query-bound cursors and complete row
  validation. Exact UUID detail lookup resolves the `LogId` returned by stock action 166 without
  scanning global pages; application-time expiry and family validation run before any bytes leave.
- **Ranked PvP cannot settle an unstarted pairing.** The complete two-player `joinedPlayerIds` set
  and one-time `roomStartedAt` marker are one durable gameplay boundary. Disconnect/result/used-card
  reports, relayed card play/delivery evidence, and finished reward authority require that proof in
  the complete document validator and mutation compare-and-set filters. Pre-start timeout or player
  cancellation remains a valid no-reward terminal path.
- **The replay-publication operator consumer is implemented.** Admin-Bearer-only list and exact
  detail endpoints expose reviewed action-3000 receipt metadata. Global or player-filtered cursors
  use the unique descending creation-time/video-ID tuple; every selected row is fully revalidated
  and application-time expiry is enforced without ever fetching the player-supplied URL.
- **Experience ranking authority is deterministic and complete.** Global and country action-107
  pages use stable experience/player-ID order, validate the optional country and every selected
  full account before assigning Position, and fail closed on an unexpected order. The optional
  replacement `Rank` metadata validates every strictly higher account instead of counting damaged
  indexed roots; the recovered stock parser continues to consume only `Items` and `Local`.

- **Squad rank progression now follows the recovered 50-row table.** The card-catalog extractor
  keeps each 4.9.5 `Squads` row's one-based `LEVEL`, 64-bit `EXPERIENCE` threshold, roster `SIZE`,
  and `CARDPOOLSIZE` together. Extraction and process startup require the complete exact 1-50
  sequence, monotonic thresholds/unlocks, and equality with the duplicate card-pool capacity array;
  truncation or disagreement fails closed instead of redefining maximum rank or pool authority.
  The dependency-free row validator now feeds the complete card-artifact boundary, and Squad
  gameplay consumes that exact frozen result instead of independently importing partial raw JSON;
  malformed provenance, cards, packs, or shared rules therefore cannot coexist with an accepted
  rank snapshot through a module cycle.
  New squads start with four seats. Complete Squad authority rejects
  a clamped/fractional/out-of-range rank, progress that should already have crossed a non-final
  threshold, or capacity from another row. Confirmed ranked-PvP Squad Points atomically update the
  competitive/member totals, subtract every crossed experience threshold, unlock the target
  roster size, and publish the remainder through the `LevelExperience` field actually consumed by
  `AANECPGDMGM`/`SquadStatsContent`. Startup migration 012 rolls the previous never-advanced
  counter forward idempotently and aborts before its first write if a recovered capacity cannot
  contain an existing roster. Every real rank transition now inserts one deterministic match-bound type-10
  row per current member and crossed rank inside the same match transaction. Its exact recovered
  `Level.N` stores the prior rank because `KGALJDLJCEH.HDCCFKAHHOP` adds one, `SquadId.S` binds the
  refreshed Squad, and the row has no invented reward or claim lifecycle. Post-commit socket,
  Redis, and Squad-status-consented Firebase wake paths all reload the durable validated row.

- **Visual economy now has one immutable runtime catalog.** Entitlement checks, mutations, and
  database-catalog sync validate the exact 4.9.5 provenance/field set, four ordered category
  identities/defaults/counts, all 146 ordered unique playable rows, the one distinct unresolved
  row, prefix membership, acquisition families, and bounded numeric fields. The accepted rows and
  nested category IDs are deep-frozen; truncation, duplicate overwrite, split-category data,
  non-finite values, or later mutation fails before changing ownership, equipment, prices, timed
  access, parts, duplicate compensation, or publication.

- **Army Power and player ranks now share one immutable runtime catalog.** Progression, equipped-
  weapon power, and database-catalog sync require exact 4.9.5 provenance plus all 58 contiguous
  player ranks, 11 ordered category masks with nine exact feature identities each, 165 unique
  weapon identities/indexes, and exactly 11,805 finite nondecreasing DPS rows. The accepted nested
  tables are deep-frozen, so truncation, duplicate overwrite, split feature masks, unsafe values,
  non-finite DPS, or later mutation fails before changing level limits, rewards, conversion values,
  matchmaking Army Power, or publication.

- **Weapon inventory now shares one immutable runtime identity/price catalog.** Shop purchases,
  Black Market inventory, Buddy-card loadout validation, and database-catalog sync require 84
  ordered unique shop rows, 81 ordered unique Black Market rows, nine ordered unresolved rows per
  family, globally unique resolved indexes/names, exactly four starters, one-bit categories, bounded
  prices/level gates, zero recovered delivery time, and exact unresolved evidence. Deep freezing and
  pre-dictionary duplicate checks prevent truncated, reordered, unsafe, or colliding rows from
  changing purchase, equip, loadout, offer, or publication authority.

- **Weapon upgrade and Black Market price tables now share one cross-catalog runtime authority.**
  Startup requires all 165 weapon tables in validated shop-then-Black-Market identity order,
  exactly 11,640 positive safe WarBucks/duration stages, and a matching validated Army Power
  identity/index with exactly one more DPS row for every weapon. The 79 source-backed Black Market
  tables must contain exactly 5,860 positive nondecreasing Gold prices, each with one more price
  than upgrade transitions; `Google2u.LMG_GSh` and `Google2u.LMG_Scifi` remain explicitly closed
  because their recovered rows contain no `WEAPONPRICE`. Every accepted stage tuple and price array
  is deep-frozen before inventory, offer, saved-cursor, or database-catalog consumers can use it.

- **Unit inventory and all three upgrade lanes now share one paired immutable runtime catalog.**
  Gameplay and database-catalog sync validate the two generated artifacts as one MainScene
  snapshot: exact shared provenance, 24 ordered player identities, three helper identities,
  18 ordered unresolved rows, source-backed tutorial/helper sentinels, unique bounded IDs, and
  all 4,124 normal, 684 special, and 216 Elite rows. Each lane must be contiguous from the owning
  unit's `startingSpecial`/`startingElite` offsets, retain its recovered slot/tier ordering, and
  contain safe prices, durations, parts, and finite nondecreasing Army Power. Every accepted row,
  tier-gate array, and nested lane is frozen before lookup maps are built, so artifact truncation,
  cross-file digest drift, duplicate overwrite, malformed sentinels, or later mutation fails before
  purchase, upgrade, equip, Army Power, rental, achievement, or publication authority changes.

## Feature inventory

| Priority | Feature | Client actions | Status | Implemented backend behavior | Required remaining work |
|---|---|---|---|---|---|
| P0 | Transport and boot configuration | `GetConfigurations`, all request routing | Implemented | BestHTTP form posts, URL action/version routes, action consistency check, JSON tooling route, exact three-segment raw configuration response without the parser-breaking empty trailing segment; action 157 preserves exact stock selector/cache strings, accepts documented cache aliases only when all copies agree, and keeps malformed requests on a callback-safe zero-cache no-publication path | Recover exact response keys for every individual action and deploy-time production base host |
| P0 | Guest account and session authentication | `CreateAccount`, `CreateFullAccount`, `LoginToCustomAccount`, `GetPlayerData`, `ChangeNameAndPassword` | Implemented | Persistent player account, versioned salted/peppered scrypt password verification with compare-and-set legacy-HMAC migration, bounded deploy-time 16384-65536 power-of-two work factor, stored-factor verification, opportunistic stronger-factor migration, and downgrade prevention; compare-and-set session rotation on every explicit login, exact typed `DatabasePlayer`/`PlayerData` boot responses whose shared DynamoDB numeric adapter rejects non-finite or unsafe integer projections instead of emitting zero, legacy session migration; bounded active/fallback `AUTH_SECRET` key ring with production validation, session continuity, staged rolling-deployment procedure, and opportunistic compare-and-set password/provider digest migration; atomic MongoDB-backed per-identity login throttle with HMAC-hidden keys, configurable window/cooldown, generic failures, concurrency-safe success clearing, and gameplay-session bypass, plus complete row authority after reservation/collision read binding exact fields/HMAC key/bounded counters/ordered safe dates/non-future audit/bounded expiry-contained lock while retaining policy-change compatibility; exact request-boundary separation requires recovered `Id`/`Password` for explicit login and common `PlayerId`/`Token` for ordinary actions, rejects conflicting aliases, and never treats action-specific `Id` or mutation `Password` as gameplay session proof; provider credentials are restricted to the explicit login action; strict full-account password validation with pre-insert hashing; exact service-level Locale and DeviceToken validation before hashing/write with identical indexed/DTO token mirrors; single-write name/password/session replacement guarded by the authenticated session | Benchmark `AUTH_SCRYPT_COST` against the target production hosts before deployment |
| P0 | Social identity accounts | `CreateGcAccount`, `AddFacebook`, `RemoveFacebook`, `AddGooglePlay`, `RemoveGooglePlay`, `AddGameCenter`, `RemoveOrUpdateGC`, `ExistFBAccount`, `ExistGCAccount`, tutorial account checks; legacy `SwitchToFacebook` | Partial | Unique provider identity ownership, HMAC credential verification, provider login through the stock `LoginToCustomAccount` chooser path, collision rejection, and client-facing identity mirrors; every link/relink/unlink atomically commits the identity authority row with its sparse player mirror and active AccountType, while unlink preserves an active surviving provider or deterministically selects the oldest remaining row before Guest fallback; shared identity lookup validates the complete canonical provider/external ID, bounded owner, exact lower-case SHA-256 HMAC text, trimmed display name, and ordered finite audit dates; provider login and open existence paths reject missing, disconnected, or row/profile-mismatched owners and re-read plus reverify the final credential after comparison so concurrent transfer/rotation cannot authenticate stale authority; Facebook IDs preserve the recovered canonical signed-64-bit string contract without JavaScript precision loss and reserve `-1` only for disconnection; request IDs and opaque credentials now require exact strings, matching duplicate aliases, and no trim/string conversion, while `RemoveOrUpdateGC.haveGcId` accepts only recovered string `0` or `1` so malformed input cannot select unlink; first-time Game Center creation validates the exact external ID again at the reusable service boundary, atomically commits player plus identity, separates the internal session from the platform credential, returns the shared stock account payload, and reproduces duplicate error `15400` with the existing public profile; action 53 is intentionally rejected because 1.6.0 has no outbound call or account-saving response parser for it | Validate live platform tokens in production; add action 53 only if a patched client supplies an explicit account-payload adapter |
| P0 | Player profile and settings | `GetPlayerInfo`, `ChangePlayerName`, `ChangePlayerCountry`, `SetPlayerStatus`, `UpdateDeviceToken`, `UpdateRegionPings`, `UpdateArmyPower`, `UpdateSettings`, `ChangeLanguage` | Partial | Validated name/country/presence/device updates, typed `PlayerInfo`, case-insensitive name uniqueness, exact six-field notification settings, locale persistence; durable country/locale metadata is revalidated at the shared profile boundary, accepting only the exact empty new-account country sentinel or uppercase two-letter country and a trimmed bounded language tag, so public/boot/notification consumers cannot normalize bypassed damage; complete durable notification consent accepts only the six recovered Boolean keys, with total legacy absence mapped to `SettingsManager.LoadEmpty` defaults during boot while partial, extra, or truthy-string snapshots fail before authentication/publication; duplicated root/DTO identity, supported account type, sparse provider IDs, device token, league, Army Power, lifetime-experience, squad-point, and squad-name mirrors must exactly agree after every shared lookup and before insert/authentication/gameplay/boot/profile/leaderboard/rank use, provider DTO IDs must satisfy their recovered wire shapes even when both copies agree, and disconnected sentinels must omit their sparse root index keys; matching mirror values must also retain the recovered nonempty trimmed/control-free 15-character account-name cap, exact `Offline`/`Online`/`InGame` status, exact five-value Squad rank, a source-backed zero-based level index, nonnegative client-width reputation, exact 0/1 log consent, Boolean awaiting-Squad state, client-width last-action time, exact empty/bronze/silver/gold/flawless War Arena crown type with client-width expiry, and a nonempty LeagueId that deserializes to the same stored tier and final division under DatabasePlayer's first/last dash-segment parser; opaque middle segments preserve unknown archived production divisions; shared full-document lookup/insert also validates bounded identity/device fields, exact optional session HMAC, supported legacy/scrypt password digest, canonical optional normalized name, and ordered finite audit dates while retaining missing-session recovery only for separately proven legacy login; real misses remain `null` but damaged rows are rejected, while full-profile saves atomically set/unset every duplicate root so indexed selection/authentication cannot disagree with Unity's displayed value; strict ten-region Photon ping dictionary and exact connection-enum parsing, atomic profile persistence, and source-compatible public `Regions` projection for the stock lowest-combined-latency opponent selector; the same complete stored snapshot is revalidated at the shared profile boundary and rebuilt in canonical region order before publication, only total legacy absence maps to empty regions/`None`, and malformed keys, values, or enums fail before a heartbeat can conceal them; pings remain non-authoritative routing hints; Unicode-normalized multilingual moderation shared by account creation, paid rename, Squad names/descriptions, and direct messages with punctuation/leetspeak resistance plus deploy-time extensions; first free and exponentially priced paid renames using XOR-decoded 4-Gold base cost, atomic profile/count/Gold update, unique-index race handling, exact 11402 recovery fields, and signed-overflow rejection; source-authoritative ArmyPower from equipped permanent/Black Market weapons, permanent units, exact active weapon/unit rental trials, and the current rank row with progression-revision compare-and-swap persistence; stable global/country experience ordering with full selected-row/country/order validation, plus complete strictly-higher-account validation before optional replacement rank publication | Continue tuning operator moderation terms from reviewed production reports |
| P0 | Bootcamp/tutorial lifecycle | `GameStartedTutorial`, `TutorialEnded`, `GetPlayerData` | Implemented | Persistent server-issued battle receipt with retry replay; complete exact-Boolean/ordered bootcamp and Play-Warcards lifecycle validation at shared progression read/publication and before start, finish, rental eligibility, and boot, including exact receipt shape, bounded control-free IDs, safe start times, terminal receipt consumption, and request-time non-future checks; action-120 `EndReason` shares the exact nonnegative invariant-culture C# signed-int parser with `GameEnded` and rejects JavaScript-coercible alternate forms before the Win gate; revision-safe lifecycle writes; Win-only completion; exact decoded MainScene starting minimums of 75 Gold and 15,000 WarBucks; one placement match; durable presence-sensitive `TutorialData` boot marker; atomic progression/profile commit; terminal replay cannot refill spent currency; narrow empty-`BattleId` migration for old stock-client runs; offline score, boxes, cards, wallet, and Army Power echoes are rejected as authority; rentals require this durable completion marker as well as their source level gate | Recover and validate any separate opening-bootcamp box/score rewards before granting those client echoes; `TutorialCards` are temporary battle cards and must not become inventory |
| P0 | Play Warcards tutorial lifecycle | bot `GameStartedMaster`, tutorial `GameEnded`, `GetPlayerData` | Implemented | Exact display-level-6 gate; server-owned `cardTutState` 0/1/2 boot projection from the validated lifecycle; revision-safe action-64 offline-bot BattleId receipt with exact shape and non-future timestamp validation; action-62 settlement requires the matching receipt and ignores client `ObtainedCards`; non-forfeit completion atomically grants the exact `TutorialRewardCards` row (`CLUSTERGRENADE`, `ELITEPARA`, `HEAVYTURRET`, `ELECTRICTRAPS`, `SABOTAGE`) once; explicit Forfeit consumes only the receipt and permits a restart; durable terminal replay cannot duplicate inventory | Recover any original score-based XP/WarBucks result policy for this offline tutorial match; the fixed card onboarding reward is complete and does not trust combat score |
| P0 | Versioned gameplay material database | Internal MongoDB catalog sync and lookup | Implemented | Deterministic 531-entry 4.9.5 release containing 165 playable and 18 unresolved weapons across the shop/Black Market families, 24 playable/three helper/18 unresolved units, 58 player-level XP/Gold/rank-power rows, 11 weapon-feature category rows, 146 playable/one unresolved visual rows, 58 playable/25 unresolved card rows, four card-pack rows, 11,640 weapon upgrade levels, 11,805 weapon DPS rows, 5,860 Black Market level-price rows, and 4,124 normal/684 special/216 elite unit levels; joined per-item documents, source and content SHA-256 hashes, immutable insert-once revisions, complete release/entry authority validation, bounded canonical JSON and recomputed entry hashes, source-triple binding, digest-aware provenance deduplication, complete expected-revision re-read before atomic pointer publication, validated CLI reporting and lookup, idempotent startup/CLI sync, and indexes for version/revision/kind/key queries | Extend the same extraction and versioning model to missions, achievements, Arena loot tables, and archived remote live-ops sheets as those client sources are recovered |
| P0 | Core squad membership | create, discover, join/request/invite, accept/decline, promote/demote/kick, leadership transfer, leave, update/emblem, member reads | Partial | Persistent squads, rank hierarchy, private/public gates, invitations, capacity, recovered squad/player wire adapters, exact promote/demote/kick callback fields, full member snapshots, protected leadership; action 79 restores its bounded literal case-insensitive `SquadNameStart` prefix and validates every complete result/order; action 81 treats echoed `Skill` only as an authenticated-profile assertion, uses server-owned global `player.skill` rather than weekly `medalsBalance`, and returns only stable-ranked complete non-full open/request-required squads passing the medal gate through an eligibility index; both actions explicitly return `IsLocal=false` because no authoritative Squad geography exists; final join/request admission shares the recovered global-Skill gate and exact validated `maxMembers`; non-open wire rows remain distinct server policies, so action 132 routes open or already-invited players through atomic join and invitation consumption, stores a bounded request only for policy 1, and rejects uninvited policy-2 access; action 59 proves manager authority before target lookup, rejects existing membership through exact `13301` identity/name fields, and replays an already-pending invitation without a false revision write; actions 59/133 accept only recovered `PlayerToInviteId` and `SquadId` plus `PlayerToJoin` identity fields, with the invitation Squad derived from authenticated membership instead of generic aliases; action 181 correctly decodes applicant `MessageId` plus Squad `Id`, binds the latter to authenticated manager membership, removes only the requested applicant, and replays an absent row without a false revision write; action 38 now requires `NewSquadId` and separates optional invitation `MessageId`, actions 45/151/132 require exact `SquadId`, action 44 additionally validates exact `CheckMessages=0/1`, and identity-free actions 49/131/63 derive their mutable Squad from authenticated membership with emblem restricted to `Icon`; action 59 atomically creates the pending player and exact type-1 invitation inbox row, replays the existing active row under a partial unique recipient/Squad index, publishes only after commit, and action 38 atomically binds/consumes that recipient/Squad MessageId with membership while generic decline revokes both message and queue authority; every join validates and atomically revokes the bounded indexed set of all other Squad queues and active type-1 rows so a later leave cannot reactivate stale admission; source-decoded escalating 25-WarBucks creation price and persistent count validated at shared progression read/publication plus mutation/boot so its next signed-client price cannot overflow; squad insert, founder mirror, and wallet debit in one transaction; exact create success counter and `3701`/`11403` error contracts; transactional public/invited/manager-approved admission with in-snapshot manager authority, pending-state consumption, and legacy mirror repair; replay-safe transactional leave/deletion with exact deposited normal-card return; transactional promote/demote/kick/leadership mirrors, kick-card return, exact `MessageType=3` offline kick delivery plus post-commit local/cross-node live fan-out, corrected source-exact old-leader `Veteran` rank, exact `3801`-`5901`/`13201`-`13302` failures, optimistic rank rollback snapshots, and a concurrency-guarded audit/repair CLI for legacy roster mirrors and orphan card deposits | Recover the retired local-Squad geography/selection contract before claiming local discovery parity; run the read-only integrity audit before production rollout and manually resolve any ambiguous duplicate/founder/leader records it reports |
| P1 | Squad social systems | `SaveLastSeenSquadChatTimeStamp`, squad chat/message delivery, `InformSquadLeaderAboutEvent` | Partial | Monotonic cross-device chat cursor through stock `SendRequestBuffer`; action-193 accepts only the canonical nonnegative C# signed-int decimal emitted by the recovered `PlayerAnalytics` setter and isolates malformed transport as that item's `UnknownAction` without working-state mutation; the repaired-client direct route requires exactly one recognized timestamp alias with exact C# Int32 form/JSON-number transport, rejecting conflicting aliases and JavaScript coercion before shared time checks; signed-client/bounded-future durable validation at shared progression read/publication and before comparison/revision/boot using one captured publication time; exact `PlayerAnalyticsData` restoration, authenticated membership validation, founder-targeted persistent event notifications with same-node/Redis-backed type-21 live delivery, daily retry idempotency; typed `/hub` Squad Chat replacement with exact recovered three-message history default, authenticated older-history pagination using a versioned millisecond/message-UUID cursor, durable TTL-backed messages, sender nonce idempotency, server-owned sender metadata/timestamps, Unicode moderation, a domain-separated HMAC-keyed atomic fixed-window rate limit that removes the cross-node count-then-insert race without consuming ordinary inbox quota, current-roster-only live fan-out, and optional multi-node Redis notices that carry no trusted content and are resolved through MongoDB/current-roster authority with bounded duplicate suppression; complete message authority validates exact fields, UUID/sender-bound nonce identity, bounded text and sender snapshots, safe ordered dates, one-to-365-day retention, and application-time freshness before insertion/replay/history/fan-out; one immutable startup policy snapshot accepts only 1-100 history rows, 1-365 retention days, 1-1,000 messages per minute, and 1-2,048 text characters without hidden defaults, clamping, or boundary-to-boundary re-reads | Add the Unity Photon Chat-to-WebSocket adapter and offline platform push notifications |
| P1 | Squad card pool and crafting | `DepositCards`, `WithdrawCard`, `CraftCard`, `ClaimCraftedCard`, `CraftAndClaimCard`, `NotifyPlayerToDeposit` | Partial | Exact server-owned `CardManagerData` and `CraftData`; the complete generated card-economy artifact now validates once and deep-freezes before gameplay or database-catalog sync, requiring exact 4.9.5 provenance/fields, 58 ordered unique playable rows, 25 ordered unique unresolved rows, four recovered pack identities/counts, bounded prices/rarities/mission gates/timers/reputation, and the shared 50-row Squad snapshot, so truncation, duplicate overwrite, split pool authority, non-finite values, or later mutation fail closed; complete five-field card-inventory authority at shared read/action/serialization/publication boundaries restricts sparse normal ownership to positive signed-client-safe counts of 58 implemented IDs, caps Buddy ownership at ten exact loadout records with source-backed unit/weapon indexes and bounded legacy visuals, requires signed-client-safe cooldowns and Boolean extra-slot state, and validates cooldown arithmetic before publication; source-extracted 30/60-minute recipes, 240-minute withdrawal cooldown, 480-minute Buddy re-deposit timer, 50 exact one-based squad-level capacities sharing the rank progression lookup without the client's presentation clamp, rarity reputation, and ten-Buddy limit; complete crafting-receipt authority requires either the exact empty zero tuple or three implemented same-rarity Bronze/Silver IDs with the exact duration and signed-client-safe timestamps, so malformed partial receipts cannot reopen consumed inputs; action 174 validates nested deltas/ownership/capacity and atomically exchanges normal inventory/deposits, while Buddy additions validate owner/timestamp identity plus exact server-derived name, level, Army Power, visuals, owned weapon slots, unit-type weapon pair, one-pool limit, and cooldown; action 175 verifies a shared squad roster and transactionally updates donor pool/reputation plus recipient inventory/cooldown, with all 5/15/45 normal and 30-point Buddy Reputation rewards checked against the recovered signed-client maximum before either participant write; Buddy withdrawals preserve their loadout; exact 17401/17402/17501/17502 recovery; actions 176/177 consume timed recipes and grant server-selected results; subscription-only action 2000 validates server-owned expiry and atomically consumes the same recipe plus grants the immediate server-selected result with exact `CardId` response and failure recovery; Gold craft proves starter ID_8; action 178 validates distinct same-roster members, persists the exact type-28 sender snapshot with daily actor/target idempotency, and publishes the validated row live to local or remote authenticated sockets after persistence; paid extra-slot entitlement is durable and already included in the six-card PvP bound | Add a nonce/client adapter for the server-selected Buddy unit type |
| P1 | Squad events and wars | `JoinSquadEvent`, `GetSquadWarsDivision` | Partial | Action 113 derives authenticated roster membership, selects one strictly validated operator-configured season, idempotently creates shared squad/event progress under a unique index, returns exact `EventDefinition` and DynamoDB-style `SquadEventProgress` contracts with viewer-specific level scaling through the shared finite decimal-preserving numeric adapter, and emits recovered `11302` when disabled; complete shared-row authority at insertion/join replay/mutation/active serialization requires exact fields and identities, bounded squad identity, safe season-bounded dates, non-exhausted revision, source-exact tier rows, canonical binary32 fractions, complete earlier tiers, one incomplete active tier, and untouched later tiers; non-finite/unsafe wire values fail instead of publishing raw `NaN`/`Infinity`; confirmed PvP settlement transactionally advances only source IDs 7 win/8 play as binary32 fractions, fails closed on live-definition drift or damaged progress before core rewards can commit, and stores a terminal-match audit receipt while ignoring forged `SquadEventUpdate`; all-current-assignment completion advances one shared tier through terminal `ActiveTier == tierCount` and atomically enqueues one deterministic type-11 reward message per current roster member; Squad Wars now owns deterministic weekly UTC seasons whose duration is frozen with both competition scheduler intervals in one immutable startup timing snapshot, with complete row validation at allocation/retry/read/scheduler boundaries binding exact fields, start-derived ID, safe minimum window, in-window creation, active/settled timestamp shape, and live non-future time, persistent eight-level divisions of at most 50 squads whose complete round authority binds derived ID, season window, level/division, exact outer/entry/member shapes, unique bounded identities, safe totals/revision/dates/status, bounded rosters, and shared-score conservation across member contributions before insertion/assignment/scoring/eligibility/read/placement/settlement, settlement-prepared late-squad allocation independent of UI order, authoritative round-entry pointer repair and fail-closed missing/duplicate/out-of-window scoring invariants, authenticated action-124 reads whose exact canonical `RoundId` cannot be supplied by an alias or changed through trimming/coercion, safe-integer validated squad/member scoring in the terminal match transaction, non-finite/overflow-safe deterministic placement, source-exact 4.9.5 reward bands/member fractions/promotion and demotion, scheduler-leased settlement, processing state, persistent wins, persisted round-start reward eligibility, transactional leave/kick forfeiture, late-join score without first-week reward, and exact replay-safe type-9 end messages; action 91 derives Gold only from type-9/type-11 server messages and claims each exactly once | Recover the retired production Squad Event schedule and Squad Wars calendar; validate relay combat facts before enabling other event assignment IDs; replace reconstructed calendar policy if an archived schedule is found; authoritative combat remains bounded by the shared PvP consensus limitation |
| P1 | Limited-time Event Assignments | `ClaimEventAssignment`, `ClaimEventMilestone` | Partial | Separate `EventAssignmentManager` implementation with strict non-overlapping operator config, immutable definition hashes, one assignment per UTC day, exact outer config/`Midnight`/nested state boot contracts, persistent claim cursors and points, server-owned Gold/WarBucks/Tickets/Scraps/visual/Elite-parts grants, ordered visual milestones, atomic direct and buffered claims, and `BufferId` replay protection; generic shared read/publication authority validates exact safe IDs/digests/totals plus canonical bounded sparse day and milestone records, while the active-config boundary caps daily progress, derives total points from claimed rows, and requires an earned milestone prefix; echoed `RewardType`, `RewardValue`, and `MilestoneId` are assertions only; empty config remains fail-closed | Recover the retired production schedule/rewards and add authoritative winter-box destruction telemetry; the current client-local `EventAssignmentUpdate` remains deliberately ignored until the battle relay can prove it |
| P1 | Instant Battle / Skirmish | `InstantBattle` | Partial | Action 199 owns the rank-9 gate, initial/recharged five-battle batches, exact 48-minute timer, exact 35/70/140 Gold curve, free and paid eligibility, wallet debit, XP/WarBucks payout, level XP/Gold, rank Army Power, dog-tag rank-up refill, lifetime counters, `PlayerAnalyticsData` boot restoration, source-exact `19901`/`19902` failures, and optimistic-concurrency persistence; the complete signed-client counter tuple plus exact private same-second replay receipt is validated at shared progression read/publication and action/boot, including count/price/level/refill/revision consistency and request-time future checks; the shifted hybrid-client MainScene values are realigned to the 1.6.0 Constants order and its visible five/35-Gold UI | Replace the documented environment-owned 20-XP/600-WarBucks per-battle fallback with an archived production reward/third-reward table; action 199 has no request UUID, so durable arbitrary-delay replay identity requires a patched client protocol |
| P0 | PvP matchmaking and rooms | WebSocket `FindMatch`, `JoinMatch`, `MatchEvent`, `MatchResult`; `GameStartedMaster/Client`, `GameEnded`, `PhotonIsFull` | Partial | Authenticated matchmaking with bounded search and post-pair join timeouts; one-time room activation requires both exact local participants or two definite expiring Redis socket routes before `MatchStart`, and cancels stale or unknown pre-start presence without rewards; exact bounded RESP integer parsing prevents strings, Booleans, arrays, fractions, or incoherent Redis results from becoming queue mutation, coordinator/socket liveness, room-start, or disconnect-forfeit authority, and transient queue candidates reject control-bearing or MongoDB-path player IDs before selection; distributed enqueue, stale cleanup, widening, and failed-admission restoration share one exact canonical Redis `TIME` snapshot, and both Lua plus Node require a candidate timestamp inside `(staleBefore, now]` so cross-node wall-clock skew, future rows, or stale rows beyond the bounded cleanup page cannot authorize pairing; `CancelMatch` atomically cancels an authenticated durable assignment only while `roomStartedAt` is absent, releases both profiles, and notifies both nodes, while a started battle is rejected into normal result/forfeit handling; transactional match-row plus two-profile `InGame` admission with distinct/snapshot/current-status validation, concurrent-pairing conflict safety, and non-pairing queue restoration after rejected admission; transactional cancellation with participant presence release and startup repair for legacy stuck `InGame` profiles; server-state discrimination between the Play Warcards tutorial and ordinary `GameControllerDeathMatchOffline` starts, bounded bot metadata, durable participant/battle receipts, exact retry, and parser-safe zero-reward unranked settlement isolated from every ranked/economy/progression/card/rental path; participant-only rooms/events, local and cross-node durable `CardPlayed` delivery receipts that distinguish actual opponent socket sends from pre-delivery evidence or Redis publish acceptance, require a contiguous delivered prefix, and keep failed handoffs retryable without same-process duplicate effects, in-room and durable REST two-party result consensus, bounded first-reporter receipt wait, recovered `EndReason` interpretation, idempotent settlement, authenticated `UsedCards` ownership plus exact delivered-prefix order/multiplicity correlation, normal/Buddy consumption plus server-owned WarBucks/XP/medal/squad rewards and terminal state in one transaction, exact five-card one-match achievement maximum coupled to consumption, exact 58-row XP threshold/Gold level progression with rank Army Power recomputation and replay receipts, source-decoded 200-second ranked win streak with nine verified WarBucks tiers, exact three beginner plus 16 normal ranked-win league WarBucks/squad-point rows, deterministic 100-player beginner rank curves with atomic stage/normal-league transitions, atomic global/weekly medal mirrors and immutable medal/placement response snapshots, independent VIP component multiplication, immutable response fields, and boot restoration, non-null `GameReward` plus conditional level marker for the stock end parser, confirmed-only rental cleanup committed in the match transaction and cached in its receipt, fail-closed configured Squad Event/Squad War preparation before any core reward commit, reconnect grace, disconnect forfeit, no-reward cancellation, restart recovery | Recover the retired Fusebox PvP Win/Loss values to replace the documented 800/400 offline policy, the corrupted tenth win-streak value, and the original global/league medal formula; implement combat-validated extra reward components; Client Photon-to-WebSocket adapter or Photon-compatible server; authoritative timing/target/damage/deployment simulation |
| P1 | Challenge; legacy hit list/provocation | `AcceptChallenge`, `AddToHitList`, `GetPlayersFromHitList`, `ExpandHitList`, `HitListPlayerLoggedIn`, `ProvokePlayer` | Partial | Exact DynamoDB-style challenge delivery and opponent snapshot, recipient-owned acceptance/read/ignore state, logical + TTL expiry, send retry deduplication, durable first-acceptance timestamp, lost-response/concurrent acceptance replay, persistent sender rate limit; complete type-0 message authority validates exact recovered payload keys/enums, bounded identities/text/opponent JSON, sender-time-derived ID, ordered 1-minute-to-7-day TTL, accepted/read/timestamp consistency, and absence of economy fields before insert/replay/publication/acceptance, while one captured application time rejects future/expired rows and new-message TTL policy resolves once at startup as an immutable exact 60-604800-second safe integer without rounding, clamping, hidden substitution, or per-send re-read; recovered Photon room/region/version handoff retained; `IsMatchMaking=0` action-64/65 participant receipts distinguish direct challenges from ranked matches, survive retries/Photon role migration, require a prior start for `GameEnded`, and settle idempotently through a parser-safe zero-reward response without changing ranked/economy/progression/card/rental state; complete receipt authority requires exact fields, bounded identities, supported action/kind/end reason, safe ordered dates, and exact 24-hour active/seven-day terminal intervals before replay/discrimination/settlement, preserves only missing legacy `battleKind` as direct challenge, and enforces application-time expiry plus an expiry-bound compare-and-set independently of asynchronous TTL cleanup; basic player search | Add a Client Photon-to-WebSocket challenge-room adapter if Photon is retired. The named hit-list/provocation methods exist but have no active 1.6.0 call sites; apparent action `84`/`85`/`88` calls occur only in contradictory duplicated decompiler junk. Keep these legacy mutations rejected until an authoritative call path/capacity contract is recovered |
| P0 | Economy and inventory | `BuyWeapon*`, `BuyUnit*`, `BuyDecal`, `Equip*`, `BuyCardPack`, `BuyPack`, `BuyLootboxes`, `RefillDogtags`, `PayOneDogTag`, `GetNewBMOffer`, `AcceptRentalOffer`, conversions, elite upgrades | Partial | Server-owned progression and exact boot-time `PlayerData`; shared read/publication validation for complete item inventory, rental, Black Market, and visual entitlement snapshots prevents malformed expiries, lifecycle intervals, offers, ownership, parts, slots, upgrade cursors, or delivery receipts from entering boot data or unrelated full-document replacements; complete `InventoryData`/`LevelManagerData` authority requires the exact four source-backed weapon slots, exact saved weapon/unit records with catalog-bounded cursors and consistent flags, and exact empty or permanent-cursor-matched active delivery tuples, while only wholly absent legacy inventory materializes the starter loadout; atomic dog-tag regeneration/spend/refill with recovered 900-second normal and subscription-expiry-gated 450-second accelerated timing plus cap/price rules; reproducible scene/assembly extraction for 84 concrete shop weapons, 81 concrete Black Market weapons, and nine unresolved rows in each family; XOR-decoded Gold/WarBucks shop purchase prices, exact level/category/index validation, immediate zero-delivery ownership, rollback, compatible weapon equip; generated per-level upgrade price/duration tables for all 165 concrete weapons and 11,640 transitions plus 11,805 normal DPS and 5,860 Black Market Gold-price rows; server-owned single-delivery receipt, timed/instant activation, float32-accurate Gold-time formula, atomic wallet/level mutations, and `BufferId` replay validation; action 217 exact serialized offer/boot contract, persistent 24-hour deterministic four-unowned-weapon sets selected only from dedicated Black Market setups with `WEAPONPRICE`, active-offer/expiry/price validation, server-derived offered level/feature, exact category feature ArmyPower, and atomic replay-safe redemption through buffered BuyWeapon; source-decoded rental discounts/durations/type weights, exact level-4 boot `Rental` contract, action 138 nested-result parser contract, persistent borrowed weapon/unit trial authority, active-rental equip/ArmyPower validation, post-battle cleanup and sale transition, server-priced permanent conversion, rollback, and retry idempotency; reproducible unit extraction covering 24 player rows with deployment/mechanical classifications, three battle helpers, and 18 unresolved ArmyUpgrades rows plus 4,124 normal, 684 special, and 216 elite price/power levels; authoritative zero-delivery BuyUnit/ActivateUnit purchase for 23 non-tutorial roster units with exact price/level/tier validation, rollback, atomic debit/grant, and replay safety; tutorial grant persistence and full UpdateEquippedUnits ownership/two-per-category/three-mechanical validation with exact 11406 rollback; action 77-79 normal/special upgrades with independent cursors, promotion/special gates, exact current-tier boundaries, one shared delivery receipt, source price/time validation, timed/instant completion, float32-compatible Gold cost, atomic rollback, and replay protection; PromoteUnit action 158 with normal-tier completion, one-based source unlock levels, maximum tier 6, empty-delivery validation, exact 11405 diagnostics, and replay safety; UpgradeEliteSlot action 209 with exact relative cursor, parts/WarBucks price, immediate atomic transition, source error codes, rollback data, and replay safety; action 207/208 Elite-part conversions with XOR-decoded 24:1 purchase and 5:1 sale rates, server-derived full-target/full-balance amounts, exact 20701/20801/20802 errors, atomic wallet/unit mutation, and replay safety; complete active-loadout ArmyPower across equipped permanent/rental unit float rows, equipped shop/Black Market/rental weapon DPS/features, and all 58 rank rows with client-echo rejection and revision-safe persistence; 146-row four-category visual catalog plus exact `DecalManagerData`; exact source-catalog saved rows, catalog-bounded parts, four category-correct slots, and helmet-only previous-head authority; source-priced permanent/timed normal-shop purchase, VIP/expiry checks, category-owned equipment, shown acknowledgements, public slot projection, rollback, and buffer replay safety; exact `CardManagerData`; reproducible 58-playable/25-unresolved card and four-pack extraction; source-priced Gold/WarBucks `BuyCardPack` with unlock/count/playable-ID/fixed-and-ranged-rarity validation, atomic debit/grant, exact rollback, and replay safety, plus an exact replacement `ServerSelect: true` mode that uses the outer durable `BufferId` nonce to return and replay one server-selected source-valid `Cards` array without a second draw or debit; exact `CraftData`; source-timed and subscription-instant three-for-one Bronze/Silver recipes; server-selected Silver/Gold claims with atomic receipt clearing and exact error recovery; normal/Buddy squad-card deposits and cross-player withdrawals with source capacity/loadout/reputation/cooldown rules | Resolve or intentionally retire the nine unresolved shop Pulse Rifle rows, nine unresolved Black Market rows, two concrete Black Market rows without `WEAPONPRICE`, and assetless `HEAD_MASK_ROCKET`; keep three helper rows and 18 unit rows without LevelManager objects closed; recover original Black Market weights/trigger schedule/feature weights and offer-discount entitlement; patch Unity to consume the implemented BufferId-bound `ServerSelect` card-pack response and add a nonce/client adapter for server-selected Buddy identities; add authoritative card reward/consumption events, remaining Arena/loyalty/hidden visual reward families and offer/subscription-backed discounts |
| P2 | RequestBuffer compatibility and acknowledgements | `InstantBuyUnit`, `InstantBuyWeapon`, `ActivateWeapon`, `IgnoreMessage`, `MessageWasShown` | Implemented | Actions 125/126 validate the earlier permanent non-rental purchase, exact recovered Gold coefficients, zero `ExpectedPrice`, and an empty unit/weapon delivery receipt for the all-zero-duration 4.9.5 catalogs, then preserve state identity without a second debit/grant; action 128 likewise validates permanent weapon ownership after the source-exact zero-delivery purchase; stock-buffered action 12 atomically records a bounded durable outbox entry, applies the recipient-filtered idempotent inbox mutation, and clears completed entries; action 194 explicitly acknowledges message impressions without trusting echoed IDs or mutating progression; ordered results and BufferId replay remain exact; one shared authority validates the bounded replay cache, unique trimmed/control-free IDs, safe timestamps, parseable result arrays, and bounded unique message-ignore outbox before lookup, acknowledgement, read, or publication; the outer buffer accepts only contiguous source-emitted numeric keys and every nested entry must contain exactly the recovered lower-case `action`/`data` pair, so aliases or extension fields cannot create competing descriptions of an economy action | Keep nonzero timed instant-purchase lifecycle rejected; implement it only if a source-backed nonzero delivery catalog is recovered |
| P0 | Real-money purchases and subscriptions | `BuyInApp`, `BuySubscription`, `RestorePacks`, `RefundPack`, expiration actions | Partial | Fail-closed Google Play integration through Application Default Credentials and exact package/SKU derivation; one immutable startup application policy binds exact untrimmed Java-style package identity plus purchase/subscription/void/RTDN-worker enablement across delivery, receipt validation, revalidation, and reconciliation, and rejects dependent workers without purchase authority; production startup requires an explicit stable `PURCHASE_TOKEN_HASH_SECRET` so authentication-key rotation cannot orphan the receipt ledger; current `products.get` validation for completed single-quantity currency and reviewed pack purchases including already-consumed client flow; current `subscriptionsv2.get` validation for active/grace/canceled-but-unexpired `subscription1`; authenticated action-9999999 subscription alias sharing the verified receipt ledger while rejecting currency entitlements, with stock action 142 retaining its recovered shared currency/subscription parser; source-exact 4.9.5 Android Gold/WarBucks catalog allowlist; ignored client-authored bases/amounts; HMAC-hidden globally unique purchase-token ledger; complete receipt authority validates exact identity/platform/owner/order/catalog kind/store product/response, safe ordered dates, source-exact reversible grants, encrypted subscription lifecycle and bounded compare-and-set retry counters, plus all-or-none void metadata before every write, replay, revalidation, and reversal; only legacy currency receipts may derive an omitted reversible wallet grant from their exact catalog-bound response; atomic token ownership plus progression grant; immutable one-time-product replay response; monotonic subscription renewal on the same token; exact `Id`/`Gold`/`Warbucks`/`SubscriptionBought`/`ExpireTime`/`dogTagTimerLock` response fields and boot `Subscription` restoration; exact four-field subscription interval validation at shared read/publication, activity requiring `subscribeSince <= now < expireTime`, and boot rejection of future starts before the expiry-driven stock client can activate them; receipt-bound AES-256-GCM subscription-token storage; partial-indexed durable revalidation cursor; cross-node Mongo lease and bounded sequential `subscriptionsv2.get` sweeps; renewal expiry projection; successful paused/on-hold/expired entitlement removal; terminal expired receipts; receipt-authority ordering that prevents an old token revoking a replacement; durable exponential transient retry; fail-safe malformed/unknown-state handling; server-expiry-gated instant card crafting, exact 450-second dog-tag regeneration, and float32-ceiled 0.8 weapon/unit upgrade duration; parameterless expiry notification cannot mutate entitlement; action 130 full `PlayerData` replacement and action 189 bounded restore-list handling for seven fully representable Packs rows (`afstarterpack`, `starterpackB`, three value packs, and two money packs); all pack currencies, VIP extension, recovered weapon, permanent/timed visuals, and extra card slot commit in one progression revision with global token replay safety; incomplete special-weapon/LP/Scraps pack families remain fail-closed; authoritative Voided Purchases `type=0` scheduler with 30-day bootstrap, complete singleton cursor authority binding exact ID/equal successful-end and audit dates/non-future position, durable fully-paginated cursor, overlap replay, validated cross-node lease, HMAC-token plus order-ID binding, atomic exactly-once receipt revocation, currency debt, VIP/timed-benefit subtraction, shared-pack reference preservation, durable-item/equipment rollback, Army Power refresh, and source/reason/time audit; OIDC-authenticated Pub/Sub RTDN route with exact audience/email/subscription/package binding, canonical mutually exclusive payloads, message-ID/payload-digest deduplication, token-safe durable event authority, leased subscription/void worker wake-up, bounded retry and terminal retention, audit-only one-time/test handling, and encrypted pending-refund quarantine; admin-Bearer-only pending-refund list/detail/submission endpoints with stable cursors, actor plus idempotency binding, exact official evidence validation, encrypted immutable outbox, first-call-wins retry using only the identical request, transactional RTDN/review completion, and terminal retention without exposing raw tokens, IP addresses, or usage details; untrusted action 1013 notifications are compatibility-only | Verify purchase, RTDN, ReviewRefund, and voided-purchase calls against live Play Console/Google Cloud credentials; recover the missing special weapon and advertised-benefit semantics before enabling the remaining pack rows; recover offer benefit constants; Apple receipt validation is required before any iOS build is enabled |
| P1 | Gold lootbox bundles | `BuyLootboxes` | Implemented | Exact six-row 4.9.5 MainScene product catalog; server-derived 49/89/159/279/479/749 Gold prices and 5/10/20/40/80/150 reward counts; cryptographic visual selection from the source-valid normal-shop part pool; atomic Gold debit, visual parts, notification flags, and exact duplicate-WarBucks conversion; `_#n` dictionary preservation; recovered `NewVisuals`/`Id`/`LootboxCost`, `11404`, and `13601` contracts | Recover the retired production rarity/visual weights to replace the documented uniform fallback; add a patched-client purchase nonce if durable arbitrary-delay response replay is required |
| P1 | Rewarded video ads | `AddVideoReward` | Partial | Exact four-value reward enum and action-156 request/response adapter; only canonical positive C# enum decimals or the same JSON integers can select a reward branch, while JavaScript-coercible Boolean/array/alternate-number forms fail closed; client dog-tag timing/cap echoes ignored; server-owned atomic Bronze-card, one-tag, Golden Suitcase, and one-part visual grants; normal duplicate-WarBucks conversion; XOR-decoded 24-claim rolling 5/12/15/100-hour source limits plus exact one-minute Golden spacing; complete exact-key positive-safe Date-bounded timestamp/source-cap ledger validation at shared progression read/publication and before grant/boot; grant and comparison clocks use the same exact boundary without flooring or clamping; exact bounded private replay receipt binds supported reward, bounded safe time, non-future revision, matching ledger grant, and immutable response ledger; only provably expired valid entries removed, with future entries retained fail-closed; four exact `videoAdRewardTimes` ledgers restored at boot; same-revision five-second transport replay; documented uniform Golden fallback limited to 1,000 WarBucks, 5 Gold, one level-visible Bronze card, or one normal-shop visual part because the bundled production chance/range rows are internally invalid | Add a provider server-to-server completion callback/nonce before treating an ad impression as verified; recover the retired Golden Suitcase weights/ranges and RandomCard rarity weights before enabling VIP/power-band or production-faithful mixed rewards |
| P1 | Gold-to-WarBucks exchange | `BuyWarbucksRequest` | Implemented | Exact six-row MainScene Gold prices and A/B conversion units, exact per-level `CONVERTGOLDTOWARBUCKS` multiplier, immutable startup-validated case-sensitive `standard`/`b` deployment prefix with runtime validation for injected service calls, atomic wallet mutation, recovered `22101` failure, and narrow same-revision replay receipt for the stock UUID-less request | Recover the retired remote experiment assignment to replace the documented `WARBUCKS_GOLD_VARIANT=standard` deployment default |
| P1 | Assignments and starter progression | `GetNewAssignments`, `SkipAssignment`, `SkipDailyAssignment`, `ClaimAssignment`, `ClaimAssignmentMegaReward`, `SendRequestBuffer`, `CompleteStarterAssignments`, `ClaimStarterAssignment` | Partial | Persistent UTC daily cycle, safe recovered PvP objective subset, settlement-owned progress, atomic Gold claims, one free skip, mega cursor/reward, and exact serialized `AssignmentData`; complete daily-assignment authority at shared read/publication and action/serialization boundaries requires the exact three ordered source IDs/targets, finite consistent progress/done/claim records, claimed-count equality, Boolean skip state, safe daily/mega counters, and one derived safe UTC issuance/reset/day-key tuple; exact `StarterAssignmentsData` boot shape and MainScene thresholds/order/rewards; shared full-snapshot validation at creation, boot, completion, claim, and serialization rejects non-finite or non-C#-signed-int deadlines, unknown IDs, non-Boolean flags, and claimed-but-incomplete records; immutable startup validation of the reconstructed starter-duration policy plus checked deadline arithmetic; server-validated ranked-win/medal/level/squad-point/first-mission completion, ID_2's inventory-backed confirmed War Card plays, ID_7's equipped secondary-weapon level, and ID_8's server-granted Gold craft; every numeric completion proof rejects non-safe persisted values before publishing a marker, and Gold-craft proof increments reject overflow before clearing the timed/subscription receipt; exact-state direct completion retries; ordered atomic starter claims; bounded `BufferId` replay idempotency | Recover authoritative unit deployment for starter ID_3; recover the production starter duration and production/non-currency mega rewards |
| P1 | Daily missions and achievements | `GameStartedCampaign`, `GameStartedCoopMaster/Client`, mission `GameEnded`, `SaveDailyMissions`, `GetNewDailyMissions`, achievement actions `218`-`220` through `SendRequestBuffer` | Partial | Exact `DailyMissionsData`/`SavedMission`/`MissionUnit` wire; complete mission lifecycle authority at shared read/publication and all feature boundaries binds the exact three daily/five ordered Heroic definition/config/unit shapes, consistent completion/reward flags, bounded levels/reward cursor/points, one derived UTC reset tuple, source-backed Heroic target, and bounded unique active/terminal receipts with valid modes/indexes/results/timestamps/responses; restored MainScene `MissionsSettings` and `UnitsInMissions` references; UTC daily issuance and preserved open heroic chains; server-owned start receipts; mode/index/order validation; consumed failure receipts; replay-safe settlement; separate solo/co-op flags; 30-point heroic unlock; all six daily completion variants with exact level-row Gold/Tickets/Scraps and Bronze/Silver/Gold card counts, currency-only before source rank-6 War Card unlock and documented uniform reward-type/`FROMMISSION` eligibility fallbacks afterward; source-exact level-scaled and slot-weighted XP/WarBucks formula with float32-compatible upward-to-50 rounding, zero co-op-master share, and half co-op-client share; source-exact VIP component multipliers; exact rank progression/Gold, dog-tag refill, lifetime XP, public level mirrors, and rank Army Power committed atomically with the receipt; exact level-row Heroic Bronze/Silver/Gold ten-card pack plus unit-specific Elite part, using a chain-persisted bought-first cryptographic unit fallback and server-selected source-valid card identities in the same replay receipt; first-mission starter progress; complete durable `AchievementsData` authority at shared read/publication and all feature boundaries enforces exact shapes, bounded unique IDs, safe offsets/values, known final-target caps, bounded tier arrays, ordered Boolean claim prefixes, and earned claimed tiers while retaining only missing/short schema migrations and non-rewarding bounded future groups; scene-exact groups 6/7/18 remain zero and unclaimable because they count spawned soldier entities, spawned vehicle entities, and stolen crates rather than deployment clicks or War Cards, while the current relay validates none of those combat facts; scene-defined mission/ranked-win/assignment/squad-point/daily-reward achievements; exact groups 0/1/8/9/10/11/15 for permanent unit/weapon purchases, confirmed War Cards, soldier/mechanical/weapon normal upgrades, and collected permanent visuals, re-derived from server snapshots with source gates and rental exclusion; group 15 begins with four category defaults and then counts durable bought or parts-completed non-power-band rows from every implemented grant path, matching scene 7/14/29 to platform 3/10/25 labels, while snapshot normalization retains only an already-claimed tier's minimum target after inventory reversal and discards larger unclaimed imported totals; exact group 3 accepted-Arena-win Ticket tiers and group 4 no-loss maximum-run Scraps tiers, advanced in the replay-safe Arena receipt transition; exact group 13 Silver II/Gold I/Master III tiers, monotonic profile-owned progression, and 5/10/20 Gold rewards; exact group 17 one-match maximum with a 50,000-WarBucks claim coupled to accepted five-card inventory consumption; exact 4.9.5 group 19 first-Squad-War completion and 5,000-WarBucks tier, committed once with the eligible member's type-9 settlement message; ordered atomic claims and recovered `21800`/`21801` failures; repeated progress/offset acknowledgements and already-satisfied monotonic projections preserve exact state identity while genuine legacy schema or inventory-counter normalization persists once | Recover original mission/reward-type/heroic-unit weighting and exact `FROMMISSION` semantics; add authoritative spawned-unit and stolen-crate combat telemetry |
| P1 | Daily rewards | `CheckDailyReward`, `ClaimDailyReward` | Partial | Persistent monthly login calendar, exact `dailyRewardData`/`DayN` contract, one unlock per UTC login day, exact-state same-day check replays without false revisions or MongoDB writes, canonical action-1002 day parsing limited to source-emitted 1-31 decimals or the same JSON integers without JavaScript coercion, with exactly one source `claimRweard` or repaired-client `claimReward` field required so alias precedence cannot select a reward cursor; ordered atomic Gold/WarBucks/Arena Ticket/loose Bronze-Silver-Gold card/Bronze-Silver-Gold pack claims with exact parser payloads, server-selected source-valid card identities, optional VIP pair composition, one revision, and replay rejection with recovered error codes; Gold, WarBucks, and Ticket branches share the central nonnegative safe-reward balance guard before their claim cursor so damaged wallets or overflow leave the day unconsumed; one time-aware exact five-field authority protects shared persisted reads/publication and action/serialization boundaries, rejects malformed current/future calendars, and discards an expired prior-month snapshot before its inert cursors are validated | Replace the documented deterministic seven-position offline schedule and tunable Gold amounts with an archived production live-ops sheet; recover any production `Double`, VIP, visual, or Elite-part calendar entries before enabling them |
| P1 | One-time social/onboarding rewards | `AddOneTimeReward`, Facebook link | Partial | Exact decoded Gold rows for Facebook Like (10), Twitter Follow (10), Facebook login (10), and notification permission (4); strict DBKEY/trigger binding with the login reward restricted to successful Facebook linking; recovered `WeaponTutorial` and `UnitTutorial` exact AK47/Assaulter parameter binding, catalog-derived first-upgrade funding (500/375 WarBucks plus 1 Gold), cursor/ownership/shared-delivery eligibility, and post-upgrade idempotent replay; atomic exactly-once currency/marker persistence; presence-sensitive `WasAdded` response; `PlayerAnalyticsData.collectedRewards` boot restoration; concurrent replay safety | Recover any other archived one-time reward definitions before enabling them; production social/ad/platform proof requires provider callbacks because the stock direct action supplies no verifiable completion evidence |
| P1 | League seasons and leaderboards | player/squad leaderboard reads, `GetPlayerLeaguesDivision`, `FinishPlayerLeague`, `RemoveFromLeague` | Partial | MongoDB-authoritative experience and squad boards with opportunistic Redis warming; global/country player experience pages use stable experience/ID order with complete account/filter/order proof, while legacy-named action 101 follows the recovered Squad screen's actual `Skill` comparison by admitting stable squad-point/name rows through a compound index and validating every complete Squad snapshot, cap, and returned order; exact typed player/division adapters sharing the fail-closed boot/profile numeric boundary so corrupt profile or rank values cannot become zero; source-backed 16-tier rules, 24/72/168-hour UTC seasons, one confirmed-PvP placement match, exact weekly-medal ordering, 30-player minimum, recovered promotion/relegation bands, underfilled/Champion Gold rewards, transactional whole-division settlement, deterministic type-23 result inbox messages, immutable reward delivery, boot/leaderboard `LeagueEvaluation`, processing state, and idempotent refresh; capped background discovery of expired parse-valid managed divisions under one crash-expiring cross-node MongoDB job lease, reusing the whole-division transaction and client-call idempotency; recovered beginner maximums 50/100/150, promotion positions 40/35/31, Unity-compatible rank rounding, cumulative stage advancement, and an atomic final managed-league handoff; one transactional tier/window admission counter assigns stable `localN` divisions with exactly 100 committed ordinals, validates exact fields/tier-end-key identity/positive safe ordinal/signed-client-safe end/ordered dates/current in-window update before deriving the bucket, shares the PvP terminal transaction, rolls back capacity on failed settlement, and leaves legacy `local` seasons intact until settlement; league transitions atomically retain the highest group-13 tier and its exact Gold claims | Recover the retired production division-assignment policy if exact parity is required; verify the reconstructed final beginner weekly-medal reset against an archived service capture; migrate unknown archived production IDs explicitly rather than guessing their deadline |
| P1 | Arena and War Arena | `EnterArena`, `GameStartedMaster/Client`, arena `GameEnded`, lives/hearts, `GetScrapsReward`, `GetArenaLeaderboards`, `WarArenaEnded`, `WarArenaShown`, arena debug actions | Partial | Exact `WarArenaData` boot/entry/leaderboard wire; generated monthly `WarArenaConfig` validates its bounded safe Unix clock before ID/window derivation and routes numeric fields through the shared fail-closed adapter; canonical request transport requires source-emitted nonnegative decimal `UsedGold`/`UsedGolds`/`hearthPrice` or the same safe JSON integers, absent-only free-entry fallback, and exact C# `True`/`False` or JSON Boolean `HeartDialogShown`, without JavaScript coercion; persistent runs/lives/wins/opponent IDs; complete lifecycle authority at shared read/publication and all feature boundaries validates known fields, nonnegative recovered C# `int` counters and crown/shield timestamps, exact empty/bronze/silver/gold/flawless crown types, configured lives/win/top-run bounds, wins no higher than lifetime matches, bounded private timestamps, Boolean flags, unique bounded opponent/shown-event collections, bounded responses, unique supported terminal receipts, and a same-Arena nonterminal active battle while only absent legacy shown history defaults empty; authenticated current-event shown acknowledgement with bounded replay-safe history; server-priced Ticket/Gold entry and heart purchases; start receipts; replay-safe result settlement; duplicate entry/start/result/heart/life/reward/end requests preserve progression identity and avoid false revision writes while expired-receipt cleanup remains durable; abandoned-battle life consumption; one-time exhausted/final-win scraps fallback; exact accepted-win/flawless-run achievement progress coupled to receipt settlement; expired-event rollover; action-206 ranking now admits only `played=true` snapshots for the exact current monthly Arena ID, computes the recovered flawless-first/conditional-score comparison, applies deterministic name/ID ties, revalidates every full account/Arena/event/order result, and uses a current-event admission index so an unrolled prior-month profile cannot rank | Recover the retired remote ArenaPrice/HeartPrice/rules/lootbox/visual tables and original opponent weights; replace configurable scraps fallback with inventory lootbox/crown delivery; add authoritative combat validation; action 206 has no event/history selector, so add history only through an explicit replacement-client or protected operator contract; keep debug mutation actions disabled outside an explicit admin design |
| P2 | Offers, rentals, and VIP | generate/accept offers, rental offer, `AcceptRentalOffer`, `BuyVip`, `OnVIPExpired`, special-offer actions | Partial | Authenticated action 135/136 routes now reject absent retired definitions with exact `13501` NoOffers and `13601` NoDiscountFound instead of generic action 90 or false success, and action 136 returns an empty authoritative offer snapshot; source-decoded 20-25% rental discount, 12-hour trial, 24-hour offer, and 0/2/7 visual/weapon/unit weights; level-4 boot issuance through exact outer `Rental` fields; deterministic unowned weapon/unit selection within the recovered locked-level window; action 138 exact Boolean request and nested `RequestsResults`; free borrowed inventory authority, normal equip and ArmyPower participation only while unexpired, atomic post-battle sale transition inside confirmed PvP/mission/Arena settlement plus exact receipt replay, previous weapon restoration, server-priced permanent conversion, rollback, concurrency safety, and retry idempotency without false progression revisions or MongoDB writes; source-exact four-row VIP Gold/duration catalog, atomic action 114 purchase/active-renewal extension, exact success and `11401`/`13601` recovery fields, progression-backed boot/profile projection and VIP-only visual checks, plus deadline-based action 195 acknowledgement; one shared nonnegative-safe-integer deadline validator protects boot migration, purchase/pack extension, void reversal, dog-tag capacity, daily cards, visual access, and PvP/mission benefits from non-finite permanent entitlement; settlement-time PvP VIP authority with source-decoded 1.5x XP/WarBucks and 2x level-up Gold, durable multiplied balances, immutable base/entitlement replay receipts, and exact `GameReward.IsVip` client multiplication contract; source-exact two virtual VIP dog tags across boot, regeneration, spend/refill, renewal and expiry, with signed base-credit debt preventing bonus replay and the normal five-tag `DogTagMax` preserved for stock-client derivation; authoritative two-card daily VIP grant through the exact `VipReward1`/`VipReward2`/`VipRewardForDay` contract, source-decoded independent 75% Gold/25% Silver rolls, cryptographic card selection, atomic inventory/cursor persistence, and UTC reconnect/renewal duplicate suppression; source-exact four-battle/two-suitcase periodic VIP cycle with boot/GameEnded countdown projection, cryptographic independent one-part draws, exact duplicate WarBucks, `_#n-VIP` `NewVisuals` encoding, and atomic immutable match receipts; missing production reward/lootbox weights are explicitly replaced by documented server-owned fallbacks | Recover the retired production rental selector/random schedule and dialog-frequency counters; recover Fusebox offer definitions before enabling action 135/client-echoed discounts; recover the retired PvP Win/Loss values to replace the documented 800/400 fallback; recover the retired lootbox rarity/visual weights to replace the documented uniform fallback; add special-offer redemption and subscription-backed discounts; visual rentals remain intentionally absent because the 4.9.5 probability is zero |
| P1 | Social directory and inbox | `SearchPlayers`, `GetAllPlayers`, `MessageSent`, `GetAllMessages`, `ReadMessage`, `GetFriendsInfo`, `IgnoreMessage` | Partial | Player directory, prefix search, exact `Items`/Dynamo attribute wire adapter; recovered `Count`/`FriendN` signed-Int64 Facebook lookup plus authoritative roster-based `Friends`/`SquadMates` response ordering and deduplication; persistent normal/challenge and Squad type-3/10/21/28 messages with authenticated same-node and Redis-backed cross-node `InboxMessage` WebSocket fan-out that occurs only after persistence/transaction commit, publishes only bounded row identities, reloads MongoDB authority, suppresses duplicates, excludes read/accepted/ignored or expired rows, and retains `GetAllMessages` recovery; the shared reload path accepts every currently supported message type while reward rows remain unclaimed presentation until action 91; optional data-only Firebase offline wake-ups use a durable recipient/message delivery ledger, one shared push-eligible family set whose bounded crash-window reconciliation includes type-1 invitations and type-10 rank changes, cross-node leased delivery, token-safe terminal handling, and saturating retry backoff without changing inbox authority; read and soft-ignore state through direct and stock RequestBuffer paths, durable cross-collection ignore outbox, bounded reads with optional stock-compatible older-page cursor using exact millisecond/message-ID ordering, exact `ToPlayerId`-only direct-message targeting separated from authenticated `PlayerId`, matching body aliases, reject-not-truncate 500-character/control bounds, and multilingual moderation before recipient lookup or rate reservation; direct read/ignore/reward/accept mutations require exact bounded `MessageId` and never reinterpret authentication `Id` or buffered `ObjData` as row identity; complete recipient-account proof and one HMAC-hidden atomic cross-node one-minute sender counter with exact 1-1000 policy, exact row/date/retention validation, bounded denial saturation, TTL hygiene, and challenge-replay-before-reservation semantics; every numeric message type/payload/timestamp wrapper shares the fail-closed boot adapter while retaining canonical safe-integer-string legacy rows, so malformed durable evidence cannot become a zero reward, placement, level, or message type; all supported families now bind a positive Int32-safe creation Unix second to the final dash-separated `MessageId` segment required by recovered `HHFHFANGCEJ`, fixing previously unreadable millisecond, bare-UUID, and text-final IDs; complete type-3/10/21/27/28 authority validates exact envelopes/lifecycle, recovered payload fields, source-valid returned cards, actor/target/server-owned-Squad relationships, server retry keys, and non-future creation before insertion/replay/pagination/serialization, while read/ignore validates both source and projected successor in one transaction; complete type-9/11/23 authority validates exact envelopes/payloads, bounded identities/text/embedded arrays, safe non-future creation time, the same parser-safe ID/idempotency binding, non-challenge lifecycle, and exact terminal response/read/ignored consistency before producer insertion, inbox publication, claim, or replay, with only absent legacy idempotency keys optional; unsupported or damaged rows fail the whole requested page rather than becoming a partial believable inbox; Gold claims use a pure checked wallet/revision transition and a progression-revision-filtered player replacement in the same retry-safe transaction as the terminal message marker | Add the replacement-client `InboxMessage` adapter; live Facebook token/friend-list validation remains part of provider integration |
| P2 | Replay video publishing | `AddVideoFeed` | Implemented | Authenticated action 3000 accepts only bounded HTTP/HTTPS replay URLs, rejects executable/file/credential-bearing input, stores one deterministic per-player URL record under a unique retry key, and returns the exact `URL` field consumed by `MHEHGPLIFHF`; a dedicated opaque-keyed MongoDB ledger atomically prunes/reserves the 20-per-24-hour rolling allowance across nodes, admits an already-reserved exact hash for crash recovery without consuming twice, conservatively seeds from recent pre-ledger receipts, and has complete exact-key/hash/date/cap/decision/48-hour-retention validation so malformed authority cannot be discarded as expired; complete receipt validation at insertion and replay binds exact known fields, canonical URL, SHA-256 hash, deterministic player-and-URL ID, bounded player identity, immutable timestamps, and exact 365-day retention, with application-time future/expiry rejection independent of delayed TTL cleanup; protected admin list/detail reads add optional player filtering, stable query-bound pagination, complete selected-row validation, reviewed wire fields, and application-time expiry while never dereferencing the URL | The 1.6.0 client has no feed-read database action; build an operator UI or a separately authenticated public feed only if this retired Everyplay integration is intentionally restored |
| P1 | Reports and moderation | `SendPlayerReport`, `ReportCheater`, crash/log actions | Partial | Authenticated durable reports with exact non-truncated target identity, canonical recovered report type, reject-not-truncate bounded messages, and whole-field omission of malformed non-authoritative client evidence; atomic ten-minute duplicate suppression whose complete winner binds exact HMAC/UUID/open-report shape/four semantic identities/claims/twenty-minute retention and optional exact false-authority two-party six-hour match snapshot before queue insertion, configurable atomic MongoDB-backed cross-process per-reporter rate limit whose complete row binds exact fields/expected HMAC key/bounded safe counter/ordered dates/non-future update/exact retention before use and whose denial sentinel prevents unsafe growth without extending the fixed logical window, review status; optional exact-party correlation to the newest recent ranked match with immutable participant snapshots, state, winner/cancellation, authenticated result claims, and bounded relayed/used-card observations; explicit `combatValidated=false` prevents transport observations from masquerading as simulation proof; social/legacy-Photon reports remain accepted without fabricated correlation; active action-166 support uploads now require session identity plus exact PlayerId/PlayerName echoes and durable `SendLogs=1` consent, return the mandatory stock `LogId`, reserve a separate atomic HMAC-hidden quota, and store exact opaque bytes only in a fully validated SHA-256-bound TTL row under immutable size/retention/rate policy; action 92 now preserves its recovered transport-field collision, always acknowledges boot/login-safe calls, and optionally retains only authenticated, consented, bounded, digest-bound TTL diagnostics under a separate atomic quota; source-unproven action 141 remains a non-authoritative acknowledgement; protected admin queue/detail API with bounded filters and stable cursors; optimistic append-audited report review with expected status, actor, terminal notes, exact retry, stale conflict, and immutable terminal states, plus complete pre-publication/mutation/replay row authority requiring immutable creation data and an exact one-or-two-entry unique/legal/bounded/ordered audit projection through `updatedAt`; protected admin permanent/temporary sanction issue/list/revoke with retry keys, retained audit history, one-active-sanction ownership, application-time expiry, shared HTTP/WebSocket enforcement, and exact recovered `3003` contract; separate current-session-authenticated support intake/list/detail/withdraw with one ownership-checked appeal per active sanction and no private fields; protected stable admin appeal queue/detail plus optimistic append-audited review, immutable terminal states, exact retry, transactional sanction revocation on acceptance, and complete submission-replay/read/list/mutation/replay appeal authority binding UUID/sanction/player/submission identity, normalized message, safe dates, open creation equality, and an exact unique legal one-or-two-entry audit projection through `updatedAt`; configurable 30-3650-day terminal report/appeal retention with frozen preview counts, kind-bound bounded export cursors, explicit destructive confirmation, active/open exclusion, same-transaction deletion/count receipt, exact retry, indefinite sanction retention, and pre-count/export/purge lifecycle validation plus ID-and-filter-bound deletion for every eligible report and appeal so forged terminal status aborts before the first write | Add the moderation/support UI or stock-client adapter and authoritative combat-evidence validation |
| P0 | Remote configuration and balancing | `GetConfigurations`, `SaveFuseConfigs` | Partial | Exact no-change and multi-sheet semicolon protocol; DynamoDB-shaped sheet/version/row-ID payloads; startup HMAC integrity verification plus exact root/publication/sheet keys, mandatory fields, case-insensitively unique languages, standalone language wildcard, canonical duplicate-targeting-envelope rejection, signed-client-safe build bounds, actual finite numeric 0-100 rollout percentage, response-size, duplicate, column-count, and delimiter validation, so signed typo fields, selector ambiguity, or JavaScript-coercible policy values fail startup while intentional ordered fallback overlap remains available; ordered AB-variant/language/client-version targeting whose stock selectors must be present exact strings and whose ranged publications require one canonical nonconflicting numeric replacement-client alias, reject malformed selectors/aliases instead of widening them to wildcards or letting `NaN` bypass both bounds, preserve an exact agreeing current-sheet cache identity, and keep stock dotted `Version` separate while allowing unbounded stock publications; deterministic player percentage rollout binds only exact agreeing canonical `PlayerId`/JSON `id`, excluding stock pre-login sentinels and upper-case login/action `Id`; current-release suppression; offline signing command and documented manifest template; client-authored `SaveFuseConfigs` cannot publish or replace operator data; empty manifest path retains bundled client sheets | Recover and review archived production sheet revisions before enabling a live manifest; a patched client is required for end-to-end response-signature verification because the stock parser has no signature field |
| P2 | Analytics and impressions | analytics, shown/impression, and crash/log actions | Partial | Weapon/unit shown actions `104`/`105` persist only source-valid unlocked `showed` state through direct or replay-safe buffered transport; seven parameterless introduction actions authenticate and monotonically persist exact `PlayerAnalyticsData` booleans for chat, customization, Warpath, card pool, league leaderboards, crafting, and Elites, with full known-key/Boolean snapshot validation at shared progression read/publication and before mutation/boot, revision-safe transitions, restoration, and replay safety; action `182` no longer incorrectly returns the top-Squads board; action `212` validates and remembers only the active server-generated Arena event without leaking backend metadata into `WarArenaData`; optional action-179 diagnostic ingestion is disabled by default, accepts only the recovered bounded `PlayerAnalytics` JSON object under an immutable opt-in/size/retention/rate policy, atomically reserves a separate HMAC-hidden per-player quota, stores exact opaque bytes with server UUID/SHA-256/length/timestamps in a fully validated TTL row, and remains isolated from every gameplay authority; action `166` implements the source `SendLogs`/`LogId` support flow under session identity, player consent, exact request/row validation, separate atomic rate capacity, and bounded TTL retention; action `92` implements both recovered error shapes, remains open for callback safety, and permits opt-in retention only with attached session authority plus exact `SendLogs=1`; admin-Bearer-only analytics/support-log/client-error reads use exact kind/player-bound cursors, complete selected-row validation, application-time expiry, reviewed family wire shapes, and global/per-player cursor indexes; actions `194` and `1007` remain authenticated no-ops, while source-unproven crash action `141` remains non-authoritative | Deploy diagnostic retention only under an approved privacy policy and build an operator UI if needed; recover the special-offer impression retention contract before persisting action `1007`; never trust action `179` economy counters; retain action `141` as acknowledgement-only until a real payload sender is recovered |
| P0 | Operations and security | health, MongoDB, optional Redis, auth secret | Partial | Health endpoint, bounded Redis fallback, graceful shutdown, bounded authentication fallback-key validation and documented staged secret rotation without mass session invalidation; persistent login, inbox, challenge, and report abuse limits; HTTP and WebSocket continuous-refill token buckets with HMAC-hidden identities, explicit trusted-proxy policy, Redis-time atomic cross-process enforcement, bounded TTL state, and memory-bounded local outage fallback; exact deployment policy rejects non-safe, fractional, non-finite, or out-of-range HTTP/WebSocket capacity, window, memory, frame, and violation settings before local or Redis enforcement instead of flooring, clamping, or silently defaulting them; Redis Lua integer replies share one non-coercing bounded adapter, and the three-field token-bucket result must form an exact coherent allowed-or-denied state before shared capacity replaces the local fallback; WebSocket parser-level frame allocation limit, serialized pre-parse decisions, retry hints, and bounded violation disconnects; multi-node Squad Chat notices and horizontally coordinated PvP matchmaking/rooms/events/results/presence/disconnect lifecycle; ordered versioned MongoDB migrations with complete exact-field receipt authority, manifest-bound checksum/description, safe non-future audit/duration validation, startup refusal on every malformed/unknown/drifted non-lock history row, singleton-insert acquisition, complete-snapshot expired takeover, and a crash-expiring cluster-wide lease that cannot be renewed after exclusivity lapses; Player League, Squad War, subscription, void-reconciliation, and Firebase delivery jobs now share exact legacy/renewable lease authority with singleton insertion, whole-document expired takeover, serialized one-third-interval heartbeat, non-resurrectable renewal, explicit pre-mutation ownership fences, final-success proof, drained renewal, and owner/duration-scoped release; idempotent job transitions remain the final recovery boundary; generated HTTP request IDs returned to callers plus AsyncLocalStorage propagation into all downstream logger helpers without manual parameter threading; Prometheus text metrics with fixed labels for HTTP count/duration/in-flight, WebSocket connections/messages/rate rejection, Firebase delivery outcomes/recovered intents/sweep failures, Redis availability, and process memory/start time; authenticated multi-node scrape example, nine sustained/traffic-gated alert rules, and a nine-panel bounded-metric Grafana dashboard with repository contract checks; independent constant-time admin Bearer authentication, explicit disabled state, protected/rate-limited metrics, and production minimum-secret enforcement; compressed MongoDB backup with non-overwrite policy and SHA-256/database/size manifest; AES-256-GCM off-host workflow with database/creation/source-metadata authentication, ephemeral plaintext, non-overwrite publication, verified path-confined retention, historical-key restore, and mandatory double-verified destructive-restore confirmation; scheduling, key-retention, restore-drill, and alert-on-failure runbook | Outbound cross-service trace-header propagation if new services are added; deploy the scheduler, encrypted remote storage, Prometheus rules, Alertmanager routes, and Grafana dashboard; execute recurring restore drills |

### Core Squad rank/removal wire authority — Partial

Every successful join now revokes the player's bounded, indexed pending-admission set in every
other Squad. Both `invitedPlayerIds` and embedded `joinRequests` are removed in the membership
transaction, while active type-1 invitation messages are terminalized. This prevents either an old
invitation or a later manager approval from becoming reusable after the player leaves the Squad
they actually joined; damaged selected rows or an excessive cross-Squad set abort before writing.

New policy-1 join requests now commit the Squad queue and a strictly monotonic player-account
revision in one transaction. That player write is a serialization fence against concurrent joins,
which also write the membership mirrors: whichever operation loses must re-read authoritative
membership and either reject the request or include it in cross-Squad cleanup. Exact already-pending
replays remain read-only, so a row removed after their snapshot cannot be recreated.

Action-59 invitation creation now uses the same target-player serialization fence for both a new
queue/message pair and legacy queue repair that materializes a missing type-1 row. A concurrent
join and invitation therefore cannot both commit from pre-membership snapshots: the retried loser
must either reject current membership or expose its capability to join cleanup. Exact active-row
replays remain read-only and do not advance either revision.

Actions 55 and 58 now require their exact recovered target field and canonical `OldSquadRank`; the
asserted rank is compared to the same authoritative roster snapshot used for permission and the
transactional write. A stale/lost-response retry therefore returns the stock `5501`/`5801` full-roster
rollback without applying another step. Actions 57 and 172 likewise accept only their recovered
`PlayerToPromoteId` and `PlayerToKickId`, and all four derive the mutable Squad from authenticated
membership. Action 42 has client UI listeners but no recovered outbound call and is classified
response-only, so it cannot act as an alternate generic-alias kick endpoint. The parent feature
remains Partial only for the explicit geography and production-audit gaps in the table above.

Squad creation, name availability, leader-event notification, and settings updates now parse their
own complete recovered fields instead of sharing a generic Squad-name/target fallback. Actions 37,
41, and 160 require their exact `SquadId`; creation additionally requires `Icon`, `IsPublic` (or an
equivalent nonconflicting replacement `JoinPolicy`), and `SkillRequirement`, while update requires
its recovered policy and `RequiredMedals`. Missing fields cannot become a default open Squad after
the creation debit, and two policy representations cannot select different admission behavior by
alias precedence.

### Firebase offline inbox wake-up — Partial

Optional Firebase HTTP v1 delivery uses Google ADC under exact immutable enablement, project-ID,
and 1-30-second request-timeout policy. Every call rebinds the committed recipient/message identity
to complete MongoDB message authority and the validated player envelope; exact offline status, a
nonempty mirrored token, and matching recovered six-field consent are required. Action 13 preserves
the opaque token byte-for-byte, accepts only empty unregister or a control-free already-trimmed
string up to 4096 characters, and rejects malformed values instead of trimming/truncating them. The data-only
payload sends recovered `id=2` for challenges and `id=90` for supported system-inbox families, with
type-28 following the recovered local `SQUAD_INFO` category. Structured FCM `UNREGISTERED` and
FCM-specific `INVALID_ARGUMENT` responses retire both exact old token mirrors through compare-and-set
without erasing a concurrent action-13 refresh; generic bad payload, sender/project/auth, quota,
service, internal, and transport failures retain the token. Provider failure cannot mutate, claim,
delete, or roll back the authoritative inbox row. A fixed-shape MongoDB ledger deduplicates each
recipient/message pair, and the renewable cross-node worker retries transient and configuration
failures with a bounded one-minute-to-one-hour exponential schedule by default. A bounded join
reconciles committed unread supported messages missing a ledger row, closing a process crash between
inbox commit and post-commit enqueue. Complete ledger validation rejects malformed identities,
digests, states, counters, and dates before provider I/O; terminal delivery/suppression is
compare-and-set against the selected pending snapshot. Delivery is honestly at-least-once because
an accepted provider request whose response is lost may be retried. Visible notification copy and a
distinct source-backed type-27 consent category remain explicit gaps.

Provider attempts and terminal suppressions now use one tested outcome mapping before metrics are
recorded. Successful FCM delivery increments only `outcome="delivered"`; a row rejected before any
provider call increments only `reason="not_eligible"`; and provider-proven invalid tokens increment
the `invalid_token` attempt plus the matching suppression only after token retirement and terminal
ledger publication. This fixes the previous swapped labels that reported successful delivery as
not eligible and ordinary eligibility suppression as an invalid token.

Live inbox delivery now covers every message family emitted by the backend. Direct/challenge and
Squad type-3/21/28 producers publish after durable persistence. Player League type-23 and Squad War
type-9 settlements return only newly inserted row identities from the successful transaction
attempt, while Squad Event type-11 identities return through the enclosing PvP settlement. All
reward notices publish sequentially after commit, reload the complete MongoDB row on the receiving
node, and remain unclaimed until the existing action-91 transaction succeeds.

### Outbound provider correlation — Implemented

Firebase HTTP v1 and all three Google Play Developer API request families now send the generated
`X-Request-ID` already used by the authenticated HTTP boundary and structured logs. Foreground
provider calls reuse only a canonical UUID from `AsyncLocalStorage`; background schedulers generate
a fresh UUID per external call, and a malformed manually installed context is replaced rather than
forwarded. No player ID, inbox identity, purchase token, URL, or arbitrary caller text enters the
header. Any future external service must adopt this same bounded helper before the Operations row's
remaining general propagation item can be retired completely.

The documented offline PvP Win/Loss WarBucks policy is immutable module-startup authority. Both
values must be exact nonnegative integers whose base grant and independently truncated recovered
1.5x VIP grant fit the client's signed-`int` reward fields; the largest supported base is
1,431,655,765. Malformed deployment policy stops startup instead of silently restoring 800/400,
while the retired production Fusebox values remain an explicit unresolved fidelity gap.

The reconstructed Instant Battle XP/WarBucks policy is also immutable module-startup authority.
Each per-battle value must be an exact nonnegative integer no greater than 429,496,729, keeping a
full recovered five-charge batch inside action 199's signed-`int` response fields. Invalid policy
stops startup before traffic. Free Skirmish rewards preserve negative safe-integer Gold debt and
pay down negative safe-integer WarBucks debt instead of treating audited chargebacks as corruption.

Dog-tag deployment policy is an immutable source-compatibility assertion: refill must be exactly
900 seconds and the normal cap exactly five tags, yielding the only supported 4,500-second base
maximum. Account creation and count-only legacy migration share that startup-resolved policy.
Every durable tuple must retain those source values, its two-tag VIP debt floor, and signed-client
boot widths; alternate safe integers and Unix seconds beyond C# `int` range fail before arithmetic,
mutation, migration, or projection instead of creating energy the stock client cannot interpret.

Login throttle configuration is immutable startup authority: maximum attempts must be an exact
safe integer from 2 through 100, the attempt window from 60 through 86,400 seconds, and lockout from
60 through 604,800 seconds. Fractional, non-finite, or out-of-range policy stops startup instead of
being rounded, clamped, or silently replaced while historical throttle rows retain their own
globally bounded interval authority across legitimate policy changes.

Core squad creation and update now parse admission settings exactly at the HTTP boundary and validate
them again in the authoritative service. Join policy is limited to recovered integers 0 through 2,
required medals is a nonnegative C# signed `int`, and the legacy `IsPublic` projection accepts only
exact Boolean representations. Form integers require canonical C# decimal spelling and signed-`int`
width, while Boolean text is neither whitespace-trimmed nor case-folded. Padding, plus signs,
leading zeros, alternate negative zero, fractions, exponents, oversized values, blank values, and
other broadly coerced inputs fail instead of being silently normalized or replaced by a default.
Every core membership, settings, invitation, join-request, PvP Squad Point, and Squad War write now
advances `SquadDocument.updatedAt` through one shared strictly monotonic helper, including writes in
the same wall-clock millisecond. Single-document replacements also bind the exact validated prior
snapshot that granted manager, roster, pending-capability, and admission authority. A compare-and-set
miss fails and requires a fresh read, so an older snapshot cannot overwrite a concurrent demotion,
membership transition, or admission change through the former name-only persistence path.

Action-2 challenge creation now parses the exact required identity/map/game/region/room/version and
optional mission fields emitted by the recovered `BeanstalkServerManager.Challenge` call. Exact C#
decimal integers and source-supported enums are required; nulls, booleans, arrays, blanks,
fractions, exponent strings, missing required fields, and malformed optional fields cannot be
coerced into durable defaults. Retry deduplication now replays a recent same-room row only when its
participants and complete payload equal the new request, so a changed map, game, region, version,
or mission cannot silently return stale invitation metadata.

VIP and lootbox purchase handlers now require the mandatory recovered `discount` as one canonical
0-99 C# decimal integer before service admission. Missing, null, Boolean, array, blank, signed,
leading-zero, fractional, exponent, unsafe, and out-of-range forms cannot coerce into the authorized
zero-discount path and commit a Gold purchase. Both handler and service boundaries also require
product IDs to be own catalog properties, so inherited JavaScript object keys cannot masquerade as
VIP or lootbox rows.

Action-29 presence and action-139 rename-payment assertions now accept only the canonical recovered
decimal integer forms. Missing, null, Boolean, array, blank, space-padded, leading-zero,
fractional, exponent, unsafe, and out-of-range values cannot coerce into Offline/Online or a
free/paid rename flag. Invalid presence transport retains the stock callback-safe `Time` response
without changing durable `Status`/`LastAction`; invalid rename flags fail before profile or Gold
mutation.

`LoginToCustomAccount.AccountType` now has one exact canonical parser shared by dispatch-time
credential-family selection and response projection. Only recovered Guest `0`, Facebook `2`, Game
Center `3`, and Google Play `4` decimal values are accepted. Missing, null, Boolean, array, blank,
signed or space-padded, leading-zero, fractional, exponent, unsafe, and unknown forms cannot coerce
into a provider digest or index; an invalid value remains outside provider authentication instead
of being normalized differently by the two boundaries.

The HTTP authentication envelope now follows the two recovered request-builder branches rather
than a generic alias search. `LoginToCustomAccount` accepts its dedicated `Id`/`Password` pair;
ordinary authenticated actions accept only the common `PlayerId`/`Token` pair. Matching documented
JSON aliases remain compatible, but conflicting aliases fail before lookup. A gameplay action's
own `Id` field can therefore select only its product, message, Squad, or match payload, and a
`Password` carried by account mutation cannot revive a missing or rotated session token.

Every `GameEnded` branch now shares one exact nonnegative C# signed-`int` parser for `EndReason` and
`MissionIndex` before feature-specific enum, receipt, or assignment validation. Missing, null,
Boolean, array, blank, signed or space-padded, leading-zero, fractional, exponent, unsafe, and
oversized values cannot become combat or mission authority through JavaScript coercion. Ranked
settlement applies the same boundary before its optional replacement-transport `WinnerId` alias, so
the alias cannot bypass the mandatory recovered `EndReason` field. When present, `WinnerId` must
exactly equal the participant derived from a supported PvP end reason; malformed, contradictory,
or unsupported-outcome aliases fail before either consensus report is persisted.

REST `GameEnded.UsedCards` and local/distributed WebSocket `MatchResult.UsedCards` now preserve
transport presence through one shared bounded parser. Stock JSON strings and replacement native
arrays are accepted, while only true field absence selects the replacement empty-list shorthand.
Explicit null, Boolean, numeric, object, malformed JSON, or invalid list values fail before result
consensus instead of becoming a zero-consumption report.

Replacement WebSocket `MatchResult` now has executable exact-wrapper authority before local-room or
MongoDB selection. It requires bounded trimmed control-free `MatchId` and `WinnerId`, permits only
optional `UsedCards` and opaque non-authoritative `Stats`, and rejects missing identities,
alternate-case aliases, arrays, null, or extra fields instead of trusting a TypeScript cast.

`JoinMatch` and `MatchEvent` share that executable wrapper boundary before durable admission or
relay. Join permits only bounded `MatchId`; event requires bounded `MatchId`/`Event` and permits only
optional `Data`. Unrecovered non-card Data remains opaque and non-authoritative, while CardPlayed
still passes its deeper sequence, identity, delivery, and terminal-prefix proof.

WebSocket `Identify` now validates an exact bounded `PlayerId`/`Token` pair before authentication.
Missing fields, whitespace/control characters, alternate-case identity aliases, password aliases,
and extra keys fail before credential lookup; authentication still provides the cryptographic proof
and the successful socket identity remains immutable across its connection lifetime.

Every decoded replacement WebSocket message now first passes one exact root-envelope boundary. It
requires a bounded trimmed control-free string `Type`, permits only optional opaque `Payload`, and
rejects primitive/array roots, missing types, alternate aliases, or extra root keys before logging
or dispatch. Each recognized message then applies its own deeper payload authority.

Replacement WebSocket Squad Chat now has the same executable wrapper boundary before persistence.
`SendSquadChat` requires exactly string `ClientMessageId` and `Text`, then delegates nonce grammar,
normalization, moderation, membership, quota, and replay authority to the shared chat service.
`GetSquadChatHistory` accepts only a truly absent payload, an exact empty object, or one string
`BeforeCursor`; explicit malformed cursor presence, aliases, and extra keys fail instead of silently
selecting the latest page.

War Arena price assertions now retain the recovered nonnegative C# signed-`int` boundary both in
the HTTP parser and inside reusable entry/heart mutation services. Fractions are no longer floored,
oversized safe JavaScript integers are rejected, and `NaN`/`Infinity` can no longer become zero and
silently select a valid free, Ticket, or Gold branch for a replacement/direct caller.

Paid-subscription weapon/unit upgrade timing now revalidates its server-authored source duration as
a nonnegative C# signed `int` inside the shared calculator before applying the recovered float32
0.8 multiplier, and validates the discounted result before receipt publication. Fractions are no
longer floored, negatives cannot become invented instant delivery, and non-finite or oversized
durations fail identically for subscribed and unsubscribed callers.

Weapon and unit upgrade receipt creation, normal activation, and instant completion now share one
application-clock authority. Each path requires a nonnegative safe Unix second inside the
JavaScript/BSON Date range, and receipt creation checks the duration addition before publishing its
deadline. Malformed clocks are no longer floored or clamped into a plausible receipt, early
activation, or a cheaper instant-completion price.

The TypeScript build now removes only generated `Server/dist` output before emission. Renamed or
deleted source modules/tests cannot survive as stale runtime code or duplicate test inputs, so
`npm test` counts and executes only the current source tree rather than historical compiler output.

Stock `BattleId` and replacement `MatchId` now share one exact alias boundary for start and result
routes. Every present alias must be a string and simultaneous aliases must be identical; explicit
null, non-string, blank-versus-nonblank, or conflicting IDs cannot choose a lifecycle by nullish
fallback or precedence. True total absence/empty BattleId remains only for downstream validation,
including the documented one-time empty-ID tutorial migration.

Both recovered moderation-report actions now parse mandatory `ReportType` as canonical nonnegative
decimal text or an exact JSON integer in the existing bounded compatibility range. Missing, null,
Boolean, array, blank, signed or space-padded, leading-zero, fractional, exponent, non-finite, and
out-of-range forms cannot silently enter category zero or alter report deduplication identity through
JavaScript coercion.

Stock social-read counts now use their recovered fields and exact client widths. `GetAllMessages`
honors `MessagesCount` before the optional replacement `Limit`, preserves the 50-row absence default
and 100-row cap, and rejects a present zero or noncanonical integer instead of letting `Number() ||`
silently select 50. `GetFriendsInfo` requires canonical nonnegative C# signed-`int` `Count`, bounds
only the processed prefix to 500, and routes every `FriendN` through the connected Facebook
signed-`long` validator, so padded, alternate, disconnected, and out-of-range hashes cannot enter
the MongoDB identity lookup.

Moderation-retention retry receipts now validate exact identity fields, safe nonnegative report/appeal
deletion counts, safe preview/creation chronology, and exact whole-day cutoffs within the global
30-3650-day bounds before replay. Historical receipts remain valid across deploy-time policy changes.

Public player publication now validates the complete durable account envelope at the shared
`DatabasePlayer` and leaderboard adapters. Search, all-player, Facebook-friend, squad-roster,
challenge, experience, and Arena leaderboard views therefore reject malformed credential or audit
authority instead of publishing an apparently usable account from matching public mirrors alone.

Google Play subscription receipts now enforce one scheduler-visible lifecycle: every live receipt
has a Date retry cursor strictly after its latest verification audit, terminal states retain
revocation evidence without a cursor, and only a revoked deleted-account orphan may retire a
nonterminal provider state. Missing, malformed, or terminally contradictory cursors are selected
into the leased audit batch, whose complete receipts validate before the first provider call.
Retry, deleted-account retirement, and provider-result successors also validate before persistence.
Terminal responses without a fresh expiry preserve the last verified entitlement boundary.
The subscription cadence, subscription scheduler interval and batch size, voided-purchase
scheduler interval, and RTDN interval/batch/retention now share one exact bounded provider-policy
service. Initial receipt cursors and
later successful/retry checks use the same 300-to-86,400-second cadence; scheduler intervals accept
only 30-to-3,600 seconds for subscriptions and 60-to-3,600 seconds for void reconciliation, while a
sweep batch accepts 1-to-1,000 receipts. RTDN accepts an exact 10-to-3,600-second interval,
1-to-1,000-event batch, and 30-to-365-day terminal retention. Fractional, non-finite, negative, and
out-of-range settings fail closed instead of being rounded, clamped, or stored as invalid dates.

Player-authored inbox and moderation-report limits now resolve once during module startup as one
immutable exact abuse-policy snapshot before their atomic fixed-window counters authorize any
reserved attempt. Outgoing direct/challenge traffic accepts only 1-1,000 attempts per minute and
reports accept only 1-100 per hour. Fractional, non-finite, zero, negative, and oversized deployment
settings stop startup instead of being floored, clamped, replaced with hidden defaults, or re-read
after traffic begins; durable counters retain their global denial-sentinel bounds so later valid
policy changes remain compatible after restart.

Moderation lifecycle retention now resolves its report/appeal day pair once during module startup
as one immutable exact policy. Both values must remain whole days from 30 through 3,650, while
sanctions remain indefinitely retained. Preview, bounded export, and destructive apply share that
same snapshot; explicit collection-test/tooling policies pass through the identical validator, and
historical purge receipts continue proving their stored intervals against global bounds rather
than the current deployment snapshot.

Trusted proxy topology, HTTP and WebSocket capacities/windows, HTTP local-memory cap, WebSocket
parser payload cap, and WebSocket violation tolerance now resolve together once during module
startup as one immutable eight-value traffic policy. Express and the WebSocket listener capture
that snapshot once for forwarded client identity, parser allocation, local and Redis-backed bucket,
and disconnect decisions. The proxy hop count is an exact integer from zero through 32; malformed
values stop startup rather than being rounded, clamped, defaulted, or independently re-read by
different transport boundaries.

Redis coordination, Google Play purchase verification, subscription revalidation, voided-purchase
reconciliation, and Squad Wars enablement now share exact startup Boolean parsing. Only complete
case-insensitive `true`/`false` literals or a documented missing-value default are accepted; blank,
padded, numeric, or misspelled settings stop startup instead of silently turning a safety worker
off or allowing rolling-deployment nodes to run different coordination modes.

The optional Redis experience leaderboard is now a complete bounded snapshot rather than an
append-only warm-up. Every Mongo-backed public row validates first; one Lua operation deletes the
old set, writes at most the current bounded result, and applies the immutable exact 1-3,600-second
TTL. Duplicate/control-character identities and non-finite scores fail before Redis I/O, while an
outage merely skips warming and never blocks the authoritative MongoDB leaderboard response.

Listener port, MongoDB pool size, and database name now resolve as one immutable startup policy
before MongoClient construction, migrations, workers, or the HTTP listener. Ports must be exact
integers from 1 through 65,535, pool sizes from 1 through 1,000, and database names must be trimmed,
platform-safe, and shorter than 64 UTF-8 bytes. The obsolete unused Redis session-TTL setting was
removed, and successful Redis connection logs no longer publish a configured URL that may embed
credentials.

Squad War maintenance now widens its round/season queries beyond ordinary due dates so malformed or
missing BSON dates and unknown statuses enter validation instead of remaining permanently invisible.
Both selected batches validate before the first settlement write; any non-settled round blocks its
season from closing, allocation applies the same corrupt-or-expired guard, and final closure requires
one exact compare-and-set winner.
The reconstructed calendar now validates its inputs before deriving persistent identity: application
time must be a nonnegative client-width Unix date, duration must be an exact 3,600-through-
2,147,483,647-second value, and the resulting window end must remain client-representable.
Fractional, negative, non-finite, or overflowing policy cannot be silently normalized or create an
`swNaN` season. That duration and the exact 10-through-3,600-second Player League/Squad War polling
intervals are resolved once during module startup as one immutable competition-timing snapshot.
Each frozen scheduler value owns both its local timer and renewable lease sizing, while every Squad
War path derives windows from the same frozen season duration. Malformed deployment values stop
startup rather than being floored, clamped, or re-read into conflicting process-local authority.

Account-sanction rows now have complete durable authority before authentication, issue/revoke replay,
admin publication, appeal intake, and accepted-appeal mutation. Exact known fields, normalized
identities, safe chronology, exact optional duration/expiry equality, and status-consistent
resolution/revocation evidence are mandatory. Active lookup deliberately has no expiry predicate, so
malformed Dates reach validation and cannot silently reopen access through database comparison.

Assignment and RequestBuffer transport now preserves the recovered C# envelope contract before
gameplay logic begins. Every direct or buffered assignment integer must be an exact nonnegative
signed-int value, the `Requests` object must have the contiguous decimal keys `0..Count-1` created
by `requests.Add(requestCount++, value)`, and each nested `Request` must contain exactly the two
lower-case public fields recovered from `Request.cs`: `action` and `data`. JavaScript-coercible
values, upper-case aliases, extra or missing entry members, and arbitrary, padded, negative, gapped,
oversized, or nonnumeric keys reject the complete envelope before its first per-action result or
progression mutation; valid envelopes retain the recovered per-action isolation.

Backend action coverage is now executable rather than inferred from this matrix. The dispatcher
exports its registered handler actions plus an explicit disposition manifest for RequestBuffer-only,
client response/local-only, retired, debug-disabled, raw-route, open non-authoritative telemetry,
and sentinel values. A dedicated test enumerates the recovered `DbAction` contract and requires
every value to occur exactly once across those groups. This prevents an enum addition, handler
removal, or newly recovered call path from becoming an undocumented generic error-90 gap.

The same boundary now covers the nested Json.NET dictionaries inside buffered daily/starter
assignment claims, Event Assignment claims/milestones, and achievement actions 218-220. IDs,
reward/currency echoes, milestone indexes, and progress cursors must be nonnegative Int32 JSON
numbers; achievement `Offset` alone remains signed because the recovered client derives it from
pre-achievement local statistics. Null, Boolean, string, array, fractional, negative, non-finite,
and out-of-range alternatives are isolated as the action's recovered error before claim or reward
state changes.

### Current PvP relay increment

Redis-enabled deployments now use one atomic Lua operation for cross-node queue deduplication,
timeout-based stale cleanup, a bounded widening-league candidate scan, pairing, and removal. Failed
MongoDB admission restores the whole candidate batch atomically without immediately re-pairing the
same two accounts. Every enqueue and complete restoration batch now proves the exact four-field
queue snapshot before its first mutation: a bounded player ID, finite nonnegative Army Power whose
recovered signed-client projection fits, one real Bronze3-through-Champion tier, and a positive safe
millisecond enqueue clock. The Lua candidate reader repeats that proof, binds hash identity/time to
the sorted-set member/score, uses protected JSON decoding, and atomically removes a malformed hash
and score instead of letting one transient row abort matching for healthy players. MongoDB profile
reload and transactional admission remain the final gameplay authority. Redis-disabled or
unavailable deployments retain the same validated in-memory queue.

All four multiplayer timeout settings now resolve once during module startup as one immutable
executable policy snapshot. Matchmaking, join, and disconnect-grace values must be positive exact
seconds whose millisecond conversion fits the Node timer range; the same frozen queue value owns
both local timeout payloads and Redis stale cleanup, and the same disconnect value owns local and
distributed resolution. Result consensus accepts only exact 0-through-15,000 milliseconds and its
frozen value is the REST bridge default. Fractional, non-finite, negative, or oversized settings
stop startup instead of being silently floored, clamped, substituted, re-read into one lifecycle,
or triggering Node's oversized-delay one-millisecond behavior.

The no-Redis `RoomManager` now admits only an exact two-distinct-player allowlist reproduced on
every join and enforces its player-to-room index. One authenticated identity cannot occupy two
process-local rooms, a contradictory overlapping allowlist cannot revise an existing room, and
rejected joins cannot create ghost rooms that survive close cleanup or relay opaque events. During
reconnect grace the room may retain active lifecycle state, but both exact assigned participants
must be currently present before any generic or CardPlayed relay reports successful delivery. The
local path now preflights those constraints without mutation, commits the same durable
`joinedPlayerIds`/one-time `roomStartedAt` transition as distributed admission, and only then
attaches/activates the socket room. An unexpected post-write local conflict cancels the match and
releases both profiles instead of leaving a durable started ghost room. The activating local
handler now acknowledges `MatchJoined` before broadcasting `MatchStart`, matching distributed
ordering instead of starting gameplay from inside the room-registry mutation.

`MatchFound` can cross backend nodes through a size/type-bounded pub/sub instruction. The receiving
node never trusts that instruction as match authority: it reloads MongoDB and proves that the local
target belongs to the named active match before delivering to the socket. Fan-out now requires exact
root/envelope/type-specific payload fields and re-derives every available client-visible fact from
that complete validated match: opponent display name, joined/start state, terminal winner/reason,
result-conflict reason, and disconnect clock. A relayed CardPlayed must equal the authenticated
source's durable sequence/card evidence and a bounded receiving-node receipt suppresses repeated
pub/sub effects. Opaque non-card combat events remain transport-only and non-authoritative. A
closing local WebSocket no longer counts as successful delivery, while committed join-timeout and
match-found-delivery cancellations use the cross-node fan-out path rather than notifying only local
sockets. Authenticated `JoinMatch`
is also durable and retry-safe: each assigned player is added once, the complete pair atomically
claims one `roomStartedAt` transition, and only that compare-and-set winner fans `MatchStart` to
both nodes. Started distributed rooms now authorize events from durable joined membership, bind
fan-out to the authenticated source and assigned opponent, persist CardPlayed evidence plus a
separate successful-delivery receipt for safe transport retries, and settle two durable matching
result reports before broadcasting the terminal row to both nodes. MongoDB is also the sole
terminal decision for the no-Redis room path: the in-memory report map validates only current
socket membership and cannot override a concurrent durable pending, conflict, or finished result.
Every conditional report write replays a finished receipt or result-conflict cancellation observed
on reload, and cancellation-versus-settlement races re-read the committed terminal row before any
client notification. This prevents both sockets from receiving only `ResultPending` after the
opponent's concurrent handler has already completed the match. Assigned authenticated sockets can
also replay a lost terminal response after the transient room has been removed, without extending
that exception to active pending/confirmed reports. Durable result conflict now clears join and
disconnect timers on both transport paths and broadcasts before deleting the no-Redis room, so a
cancelled match cannot continue relaying opaque events. Cross-node reconnect,
disconnect-grace, and forfeit coordination now uses renewable compare-owned Redis socket routes,
durable per-participant disconnect clocks, MongoDB-validated opponent notifications, retry-safe
rejoin clearing, and grace-expiry forfeit or both-offline cancellation. Unknown Redis liveness
extends the grace instead of manufacturing a loss. Socket admission now distinguishes deliberate
no-Redis local mode from an attempted Redis ownership-write failure: distributed handling begins
only after the exact player/socket owner is stored, a failed new claim preserves an older valid
login, and uncertain cleanup compare-deletes only the prospective owner before the new socket is
closed with a retryable coordination error. A live socket's authenticated player binding is now
immutable, preventing a second `Identify` from leaving the first account's local/Redis route aimed
at a transport that has switched identity. Disconnect settlement reads owner value and remaining
TTL in one Lua operation and accepts “connected” only for the exact instance/client UUID pair with
one to 30,000 milliseconds left; malformed, non-expiring, overlong, or incoherent observations are
unknown and cannot manufacture a forfeit reward. Reconnect clearing compare-unsets the exact
disconnect timestamp it observed, and a forfeit repeats that same loser-marker proof inside the
terminal reward transaction. A reconnect or later disconnect therefore invalidates an older grace
callback before any reward, progression, card, rental, league, event, or terminal write.
Process-local active-room closes now persist the same participant markers. Both local and
distributed both-offline cancellation require the complete exact two-player timestamp snapshot
again inside the MongoDB cancellation transaction; a missing, cleared, or replaced peer marker
waits another grace window instead of turning a stale transport observation into cancellation.
Reconnect clearing on both transports is now bound to the exact marker returned by that durable
join snapshot, so a second close racing the reconnect handler keeps its newer offline generation.

Each new match also stores its backend coordinator UUID. Redis carries a renewable crash-expiring
heartbeat for that UUID, and startup plus periodic orphan recovery cancels only matches whose owner
is confirmed dead. Live peer-owned matches survive rolling node starts; an unavailable Redis
liveness read is treated as unknown and never as permission to cancel gameplay. A Redis-selected
node must now commit its first coordinator heartbeat before startup can proceed, so it cannot create
durable matches naming an owner that peers have never observed. Orphan recovery reads coordinator
owner and PTTL atomically: only the exact owner with one to 30,000 milliseconds left is alive, the
exact missing tuple is dead, and malformed/non-expiring/overlong/incoherent state is unknown rather
than permanent match authority. Presence repair
excludes every participant still protected by any active or settling match.

`SetPlayerStatus` now preserves mode compatibility while protecting ranked admission: the active
or settling match lookup and profile write share one MongoDB transaction, so a client heartbeat
cannot clear the server-owned `InGame` reservation during admission, play, or settlement. The
transaction loads and validates the complete durable account before writing status or `updatedAt`;
a narrow heartbeat projection cannot bypass malformed credential, profile, or progression state
and then normalize that damaged row. Action `29` now publishes the recovered `Time` response field
and atomically writes `Status` with its signed-client-`int` Unix `LastAction`; remote clients use
that exact pair and a 2700-second window in `DatabasePlayer.GetRealStatus`. New accounts start with
a current heartbeat, and ranked admission, settlement, cancellation, and restart recovery update
both fields in their owning transaction so backend status changes cannot immediately appear stale.
Admission, cancellation, and restart repair now validate every complete stored account and its
projected presence successor before the first write. Cancellation requires exactly both assigned
IDs to exist and be released; restart repair freezes and validates the exact selected stale-player
set, then verifies MongoDB matched all of them. A damaged or missing account therefore aborts the
transaction instead of being normalized by a broad status update or hidden by partial success.

Moderation duplicate suppression is also cross-process: one HMAC-keyed atomic winner stores the
complete first report payload for ten minutes, and every racing process upserts that same report
ID. TTL removes old coordination rows but is never used as the logical replay clock.

The replacement WebSocket transport now recognizes a typed
`MatchEvent { Event: "CardPlayed", Data: { Sequence, CardId } }` contract. Each authenticated
participant has a contiguous zero-based sequence capped by the recovered six-card selection
limit. The sequence remains an exact JSON integer number at client, local-room, durable-evidence,
and distributed-fan-out boundaries; null, Boolean, blank text, numeric text, arrays, fractions, and
non-finite values cannot coerce to zero. The nested Data object must contain exactly `Sequence` and
string `CardId`; missing fields, alternate aliases, and extra targeting claims fail before evidence,
and local/cross-node paths use the same canonical pair. The backend validates ownership against the complete candidate list, persists evidence
before relaying the effect, acknowledges an exact retry without relaying it twice, and serializes
each socket's messages so `MatchResult` cannot overtake its last card activation. Both local and
cross-node handoffs append one durable contiguous delivery prefix after the opponent socket send.
Terminal `UsedCards`, ordinary settlement, and disconnect-forfeit fallback must reproduce and
consume only that delivered prefix; evidence persisted before a failed handoff cannot debit cards.
The shared match validator rejects gaps, reordered markers, and reports exceeding delivery proof.

The PvP row's remaining live-card boundary now applies to the legacy Photon/REST client path and
to card-effect semantics such as timing, target, damage, and deployment. A Photon-to-WebSocket
adapter must emit these typed events; the backend does not infer them from a terminal list.

Confirmed PvP's personal daily-assignment counters, ranked-win and lifetime squad-point
achievements, squad leaderboard aggregate, and embedded member contribution now commit inside the
same MongoDB transaction as both player rewards and the terminal match receipt. Membership is
re-read from the squad roster in that transaction instead of trusting the profile mirror. This
removes the former best-effort post-commit window in which a crash could permanently lose progress;
finished-match retries return the immutable receipt without applying any counter again. Shared
profile authority now rejects equally corrupt Army Power, lifetime Experience, or Squad Point
mirrors: Army Power retains finite nonnegative fractional storage with a signed-int projection,
Experience is a nonnegative safe integer, and Squad Points are a nonnegative signed-client integer.
PvP settlement checks both counter additions, replaces unchecked `$add` with literal successors,
and validates the canonical progression plus complete projected account before its first write.

The complete durable ranked-match row is now validated before room admission/start, disconnect and
presence decisions, relayed-card mutation/delivery, result consensus, moderation correlation,
cancellation/restart recovery, settlement, and terminal replay. The shared proof binds one UUID to
exactly two distinct bounded server snapshots; participant-only unique joined/disconnect/report/card
maps; ordered safe lifecycle dates; mutually consistent active, cancelled, and finished fields; two
exact terminal reward receipts with safe counters plus internally consistent VIP multipliers,
win-streak, league, level, lootbox, and rental data; and participant-complete bounded Squad Event/War
projections. Only an absent legacy rental-settlement marker reaches the existing idempotent repair;
false markers or rental payloads without the marker fail closed. Every reviewed mutation validates its projected successor first. Dynamic participant
IDs reject MongoDB `.`/`$` path syntax, so a stored or admitted identity cannot redirect a card,
disconnect, or result update into another field.

The complete durable squad document is now one shared authority boundary across membership,
leadership, admission, chat, card-pool transfers, Squad Events, confirmed-PvP squad rewards,
leaderboards, and Squad Wars. It requires exact fields, bounded normalized identities and text,
source-valid ranks and join policy, safe nonnegative counters, ordered timestamps, unique roster and
pending identities, exactly one founder Leader, capacity-consistent membership, bounded admission
queues, and no pending identity already present in the roster. Every reviewed replacement validates
its projected successor before the write. MongoDB's implicit `_id` is accepted only while reading and stripped
before `$set`, preventing valid settings and roster updates from failing on the immutable field.

### Current economy-safety increment

Action 199 now preserves the recovered free-versus-paid wire distinction before Instant Battle
eligibility or wallet logic. Only an absent `IsPaid` field selects the free path; a present paid
price must be the exact positive nonnegative C# signed-int decimal emitted by the confirmation
dialog. Explicit null, blank, Boolean, array, padded, signed, fractional, exponent, zero, negative,
or oversized values return the stock authorization failure instead of becoming a free batch or a
coerced price.

Squad-card nested payloads now preserve the recovered Json.NET shape before inventory or pool
authority is derived. `CardData.amount` and all numeric `BuddyCardData` fields must be bounded JSON
integer numbers matching their C# `int` declarations. Missing, null, Boolean, string, array,
fractional, non-finite, unsafe, and out-of-range values reject instead of manufacturing a card
amount or loadout index; only exact numeric `-1` selects the no-secondary-weapon sentinel.

Buffered card-pack purchases now retain both recovered payload variants. `BuyThreeCards` may omit
`discount` and `StartTime` and derive the legacy zero values, while a standard `BuyCardPack` carries
both as Json.NET numbers backed by C# `int`. Only true absence selects the fallback; explicit null,
Boolean, string, array, fractional, negative, unsafe, or oversized values reject before pack
eligibility, wallet debit, inventory grant, or replay publication.

Replacement clients may now request server-owned pack identities with the exact disjoint
`ServerSelect: true` payload. Unknown keys, aliases, client-supplied `cards`, and non-Boolean forms
reject before selection. The existing outer `BufferId` is the operation nonce: its durable result
stores the selected `Cards` array, so a lost-response retry returns the exact draw without repeating
the wallet debit or inventory grant. Stock clients remain on their recovered local-roll assertion
path until their success parser is patched to apply the returned identities.

Weapon, unit, and visual inventory parsers now preserve each recovered dictionary member's exact
Json.NET transport before any catalog, wallet, ownership, delivery, conversion, or replay decision.
C# `int` fields require signed-Int32 JSON numbers, while the weapon/unit coefficient floats require
finite JSON numbers. The sole integer-text exception is `WeaponScreen.EquipWeapon.Index`, whose call
site explicitly invokes `ToString()` and therefore requires canonical nonnegative Int32 decimal
text. Mandatory discounts and delivery reductions no longer convert absence or null to zero, and
signed numeric values still reach the feature layer so its recovered negative-value errors remain
unchanged.

Action 1003 now also preserves ArmyScreen's sparse equipped-unit detail dictionaries. The client
adds `wasEquipped` and `equipped` only when each value is true and omits a unit when both are false;
the backend therefore treats true absence as false but requires every present member to be exact
JSON `true`. Empty detail objects, explicit false, null, non-Boolean values, and unknown nested keys
return the recovered `CantEquipUnit` result before tutorial ownership or loadout state can change.

The shared persisted-progression read boundary and mutation-result boundary validate all five core
numeric fields before price comparison, publication, or the boot adapter: Gold and WarBucks retain
safe-integer chargeback debt, while Tickets, Scraps, and level experience must be nonnegative safe
integers. Non-finite, fractional, unsafe, or invalid-negative values fail closed instead of
bypassing a debit, entering the adapter's legacy zero fallback, or losing precision in Unity.
The dog-tag tuple shape is likewise validated at every shared persisted read/publication and before
boot or time arithmetic. Callers that own an authoritative request/boot time supply one captured
time for both snapshots and additionally reject future cursors; context-free publishers remain
deterministic while still rejecting every malformed tuple value. Refill/cap values must describe
whole positive tags, the cursor must be a safe Unix second, and stored seconds remain bounded by
the normal cap and the recovered two-virtual-tag VIP debt floor. New-account and legacy-migration
deployment policy requires exact positive safe refill/cap integers with a safe persisted product.
The legacy count-only migration is selected only when the canonical tuple is absent and rejects
negative, fractional, unsafe, and non-finite counts instead of rounding them into spendable energy;
malformed present fields are rejected rather than reinterpreted as legacy state or allowed through
an unrelated replacement.

The offline Daily Reward calendar resolves its deployment-owned ordinary and weekly Gold as one
immutable module-startup policy. Both must be exact nonnegative safe integers and the weekly value
cannot be lower than the ordinary value, so malformed policy stops startup instead of failing only
when a player requests a calendar. Direct policy selection additionally accepts only days 1-31;
fractions, `NaN`, infinity, and out-of-calendar indexes cannot choose an ordinary or weekly row.
Daily Reward check, claim, and wire-countdown entry points now consume the shared Date-bounded
application clock directly. A fractional, non-finite, negative, or oversized time cannot be floored
into a valid UTC login day, claim calendar, or client countdown.
Daily Missions cycle materialization, start, and settlement now use the same shared exact clock.
Settlement carries that one value through receipt expiry, VIP evaluation, rank-up dog-tag refill,
rental cleanup, and terminal receipt publication; malformed time cannot select a UTC mission set or
split one transition across different normalized timestamps.
Daily Missions also require `DatabasePlayer.Level` to identify one exact recovered zero-based rank
row before cycle replay/issuance, reward availability, start, or settlement. The server persists that
index directly for the client's `+1` display conversion and uses the row's one-based display number
for mission reward-table thresholds, fixing the previous floor-and-subtract off-by-one.
Limited-time Event Assignment selection, UTC day indexing, trusted progress, daily claims, and
milestone claims now use the shared Date-bounded clock without flooring. Malformed application time
cannot select an active schedule or turn a fractional boundary into an eligible reward day.
Black Market issuance and rotation now require the authenticated player level to identify one exact
recovered rank row before per-weapon maximum-level clamping. Fractions, non-finite values, negative
levels, and indexes beyond the source catalog cannot publish an empty or lower-rank 24-hour set;
reading an already-active durable set still does not depend on the caller's current level.
Card-pack unlock checks and mission-card `FROMMISSION` selection now require that same exact rank
row. The row index controls the rank-6 unlock and its one-based display number controls the recovered
mission threshold, preventing `NaN` or floored fractional levels from entering card economy.
Rental generation now requires one exact recovered zero-based rank row before the level-4 gate,
candidate window, and deterministic selection seed. Malformed levels cannot generate a lower-pool
offer, while replaying an already-live durable offer intentionally remains independent of a later
profile-level argument.
Normal weapon and unit purchase mutations now resolve that same exact source row before their
zero-based catalog unlock comparisons. Direct or replacement callers can no longer floor a
fractional rank or use a finite integer beyond the 58 recovered rows to authorize ownership; Black
Market redemption continues to use its validated durable offer instead of a later rank argument.
Unit promotion now derives its one-based warning/gate value only from that exact row, and malformed
rank failures remain contained in the corresponding RequestBuffer result without fabricated 11405
diagnostics. Heroic elite-part target selection also validates the exact row before bought-first or
unlocked-pool selection, preventing direct callers from persisting reward authority beside a
normalized corrupt rank.
Rank Army Power derivation now consumes the same exact row instead of copying the client's
post-load presentation clamp. A negative, fractional, non-finite, or oversized stored level cannot
be normalized into the first/final rank contribution and published as a believable indexed total.
Squad Buddy deposit authority now serializes that exact zero-based row index directly, matching
`CardBuddy.CreateDataForCurrentPlayer` and `LevelManager.LoadData`. The former subtract-one path no
longer makes every Buddy above rank zero advertise one level too low, and malformed rank state
cannot be normalized into a durable cross-player loadout.
Normal visual purchases now resolve the same exact recovered rank row before comparing the
catalog's zero-based unlock gate. `NaN` can no longer pass because JavaScript's raw `<` comparison
returns false, and fractional or out-of-catalog values cannot authorize a cosmetic transition in a
direct or replacement caller.
One shared application-clock boundary now protects initial progression creation, persisted
progression reads, successor publication, `PlayerData`, and the top-level player-state response.
It requires a nonnegative safe Unix second inside JavaScript/BSON Date support and passes that same
captured value to dog-tag, subscription, Daily Reward, video-ad, win-streak, Instant Battle,
tutorial, chat, league, and War Arena projections. Fractions and malformed clocks can no longer be
floored into different valid values at nested boot boundaries.
The shared progression read/mutation boundary now treats only an absent legacy revision as zero.
Present and produced revisions must be nonnegative safe integers, and every state-changing write
must advance monotonically before its MongoDB compare-and-swap filter or replacement is built;
multi-action RequestBuffer writes may advance more than one internal step atomically.
The same successor validator guards every reviewed custom replacement: reward-bearing inbox claims,
verified Play purchase delivery/revalidation/reversal, Daily Missions, Instant Battle, rename,
Squad creation/card transfers/departure, tutorial completion, first-Squad-War achievement, core PvP
settlement, and operator Squad-integrity repair all prove both core-balance snapshots plus the
monotonic revision before their transaction can publish progression.
The embedded progression envelope must carry exact schema version 1 at both read and publication
boundaries. A wholly absent progression may use the deterministic account fallback; a missing,
malformed, or future version in a present document fails closed until an explicit migration exists.
The paid-VIP timeline is also validated at those boundaries. Expiry remains the exact recovered
active-benefit predicate, while its display start must be a nonnegative safe Unix second, equal zero
when expiry is zero, and never later than a nonzero expiry. The legacy `DatabasePlayer.vipExpiration`
fallback is independently validated at shared account lookup even when canonical progression owns a
different current value; generation differences need not mirror, but malformed dormant authority
must not survive authentication/gameplay use or unrelated writes.
Any present subscription revalidation owner must be the exact 64-character lowercase hexadecimal
HMAC-SHA256 purchase-receipt key. Absence remains valid for legacy subscription rows; arbitrary or
malformed durable IDs fail before stale-event comparison or publication.
Google Play subscription cadence, subscription sweep interval/batch size, and voided-purchase sweep
interval now resolve together once during module startup as one immutable exact provider schedule.
Receipt creation and later revalidation therefore cannot publish and consume cursors under
different process-local cadence values; fractional, non-finite, or out-of-range policy stops
startup rather than being rounded, clamped, substituted, or independently re-read by either worker.
Purchase enablement, dependent subscription/void-worker enablement, and the Android application ID
now form a second immutable provider snapshot. Its bounded dotted Java identifier is preserved
exactly rather than trimmed, both workers require the main purchase authority, and delivery,
receipt validation, subscription polling, and void reconciliation share the same package/SKU
prefix for the process lifetime.
Direct delivery, subscription revalidation, voided-purchase reversal, and post-delivery boot reloads
also validate the complete private player account and duplicated profile envelope. Existing damaged
players abort the surrounding transaction before grants, reversals, or terminal receipt markers;
only a genuine missing-player result follows an operation's explicit reconciliation behavior.
Authentication's intentionally narrow session compare-and-set projection reuses the exact session
HMAC and supported password-digest validator on both its successful result and concurrent-winner
reload; a malformed durable credential cannot escape through a projection that omits the profile.
Economy/profile retry and transaction reloads independently revalidate the full account before Army
Power refresh, Daily Mission or Instant Battle settlement, PvP settlement, inbox reward claim, and
Player League allocation or population ranking. One corrupt league member aborts the atomic season
settlement before the first player or reward-message write.
The shared account proof now includes the complete source-backed Player League progression tuple
(`BeginnersLeague`, supported normal `LeagueTier`, and exact zero-or-one `RemainingMatches`) plus
the nonnegative safe-integer `MedalsBalance` and `Skill` competition mirrors. Consequently a
damaged league profile fails before authentication/gameplay use, matchmaking admission, tutorial
repair, Squad/economy mutation, ranking, or settlement rather than only during boot projection.
Squad creation, join, leave, rank, leadership, kick, card withdrawal, and chat sender reloads also
prove the complete account before roster/profile publication, inventory transfer, or durable sender
identity. Every player in a multi-account Squad transaction validates independently before its first
write, preserving the all-or-nothing membership and card-transfer boundary.
Operator Squad-integrity repair keeps one explicit exception: it may tolerate only the squad mirror
mismatch it is designed to replace while separately validating private account fields, the exact
audited timestamp, and any progression successor. The Player League scheduler validates its selected
division representative before settlement. Its MongoDB discovery now groups and caps candidate IDs
before returning them, selects due valid local divisions plus malformed exact local-namespace rows,
and validates the complete bounded batch before the first settlement; this removes the unbounded
historical `distinct` result without claiming unknown retired production namespaces. War Arena
validates candidate ID/Army Power profile mirrors without unnecessarily consuming private credential
state.
Action `221` validates its entire narrow lost-response receipt before replay, read, or publication:
only the twelve recovered A/B IDs and matching Gold prices are accepted, the historical grant and
timestamp must be safe, and its receipt revision cannot exceed current progression. Corruption is
never discarded or overwritten to reopen a recent conversion. Its deployment A/B selector is
resolved once during module startup as one immutable exact case-sensitive `standard` or `b`
literal. Whitespace, alternate case, unknown values, and invalid injected service arguments fail
closed instead of being normalized or falling through to the standard curve. The standard default
remains reconstruction policy because the retired production experiment assignment is missing.
The private paid-VIP daily-card marker is validated before comparison, read, and publication: its
UTC day derives exactly from a safe non-future grant timestamp, and its exact two reward IDs must be
implemented recovered Silver/Gold cards (a duplicate pair remains legal). Corruption cannot be
overwritten to reopen the once-per-day grant.
The private War Card play and Gold-card craft lifetime counters are nonnegative safe integers at
shared read/publication and reward-derivation boundaries. Missing legacy fields normalize to zero;
malformed values cannot satisfy starter assignments or achievements or survive an unrelated write.
The complete private `CraftData` receipt is validated before boot, crafting actions, recovery
serialization, or progression publication. Only the exact empty zero tuple or an exact three-card
same-rarity source-duration recipe is valid, and both timestamps must fit the recovered signed C#
`int`; damaged receipts remain available for operator recovery and cannot be silently cleared.
The complete private `CardManagerData` snapshot is validated at those same shared boundaries.
Normal cards require implemented identities and positive signed-client counts; Buddy cards retain a
bounded exact loadout with source-backed unit/weapon values; the two cooldowns are signed-client-safe;
and the paid extra slot is Boolean. Missing legacy inventory alone may materialize the exact empty
shape, while present corruption cannot survive an unrelated progression replacement.

Starter and daily assignments, assignment mega rewards, achievements, reward-bearing inbox
messages, one-time/tutorial grants, Gold conversion, level rewards, normal/VIP lootbox duplicates,
core PvP settlement, Elite-parts conversion, and War Arena Scraps now share one checked
reward-addition path.
The check accepts authoritative chargeback debt in an existing wallet, rejects negative or
non-integer rewards, and rejects any sum outside JavaScript's safe-integer range. Each caller
calculates the final balance before consuming its claim marker or terminal receipt, so invalid
persisted data or an operator-configured overflow fails closed without losing the reward on retry.
Assignment mega Gold now resolves its currency-only deployment fallback once during module startup
as an immutable exact nonnegative safe integer. A malformed value stops startup before players can
earn or consume the 50-point cursor; a valid claim computes the checked final wallet balance before
subtracting that cursor. The default 25 Gold remains reconstruction policy because the retired
production and non-currency mega-reward table has not been recovered. War Arena resolves its
complete operator policy once during module startup as one immutable snapshot before config
projection or lifecycle use. The ID prefix uses only the durable safe-ID alphabet and leaves room
for the monthly suffix; battle count is one through twelve, lives are positive, and Ticket/Gold
prices plus guaranteed Scraps are exact nonnegative client-width integers. Malformed policy stops
startup instead of being rounded, clamped, replaced by an implicit default, or re-read midway
through a run.
Heroic Daily Mission and configured Event Assignment unit-part grants additionally use a checked
signed-client-int successor before their enclosing receipt/claim transition. `SavedArmySlots.parts`
is a recovered C# `int`; JavaScript-safe addition alone must never create an inventory snapshot that
the stock client cannot deserialize or the shared inventory boundary immediately rejects.

Assignment, achievement, and War Arena eligibility counters are also validated before comparisons,
and Arena lifetime increments reject safe-integer overflow before settlement.
This explicitly closes JavaScript's non-finite comparison behavior: `NaN` can never make an active
Arena run appear finished, make an achievement tier appear complete, or unlock a mega reward.

### Lifecycle Boolean request authority

Match and rental branch selectors now preserve the recovered transport instead of relying on
JavaScript truthiness. Actions `64`/`65` require both `IsMatchMaking` and `IsWarArenaBattle` as
exact `"0"`/`"1"` form text; optional action-`62` `TutorialWarcards` and `IsWarArena` markers use
that same grammar when present. Action `138` accepts only C# `"True"`/`"False"` form text for
`buyRentalDiscounted`. Replacement JSON clients may send actual Booleans for either contract.
Numeric, lower-case, padded, null, array, and object aliases fail with action error `90` before
they can select ranked, friendly, tutorial, Arena, free-trial, or permanent-purchase state.
Legacy Squad create/update `IsPublic` uses the same exact `"0"`/`"1"`-or-JSON-Boolean parser
before its inverse mapping to `JoinPolicy`; malformed aliases cannot change admission policy.

### Request routing authority

The URL action and repeated body `requestId`/diagnostic `DbAction` now independently require one
canonical nonnegative C# `int` before they are compared or routed. JSON adapters may use the exact
integer number. Missing, null, Boolean, array, blank, signed, padded, leading-zero, fractional,
exponent, non-finite, and out-of-range values fail before the raw action-157 configuration path or
normal handler registry. `MIN_CLIENT_VERSION` is validated during dispatcher startup as an exact
zero-through-`Int32.MaxValue` integer, with only zero disabling the numeric replacement-client gate.
When enabled, every supplied `ClientVersion`/`clientVersion` alias must use the same canonical value;
malformed or conflicting claims fail as invalid/old instead of using alias precedence or bypassing
comparison through JavaScript `NaN`. The stock dotted `Version` remains the separately documented
BestHTTP field.

## Implementation order

1. Build the patched Client Photon/Photon-Chat-to-WebSocket adapters and authoritative combat evidence; keep the implemented offline-bot fallback isolated from ranked rewards.
2. Recover remaining source-backed combat facts for locked achievements, Event Assignment box progress, unresolved mission/card effects, and PvP anti-cheat validation.
3. Recover archived live-ops authority for Black Market weighting, event calendars, Arena loot/crowns, offers, and retired reward schedules; keep each feature disabled or on its documented reconstruction fallback until then.
4. Complete external provider integration: live social token/friend validation, provider-signed ad completion for action 156, production Play/Firebase credentials, and end-to-end device validation.
5. Finish replacement-client response/push adapters, production league allocation policy, remote-configuration rollout, monitoring deployment, backup scheduling/storage, and recurring restore drills.

## Rules for implementation

- Never acknowledge an unimplemented gameplay mutation as successful.
- Every currency, item, reward, and claim mutation must be atomic and idempotent.
- Calculate server-authored rewards with checked safe-integer arithmetic before consuming the
  corresponding claim marker or receipt; chargeback debt is valid existing state, not reward input.
- The server must validate ownership, rank, match participation, price, capacity, and expiry.
- Paid VIP and subscription timestamps must pass their shared nonnegative-safe-integer validators
  before boot projection, benefit comparison, purchase renewal, reversal, or provider reconciliation.
- Player League `MedalsBalance` and `Skill` values must be nonnegative safe integers before a
  division is returned or settled; beginner/normal tiers and the zero-or-one placement counter are
  validated before boot/admission/progress, and the complete member set before the first reward write.
- Ranked-PvP win-streak authority must be an exact 0-9 count/timestamp pair before settlement or
  boot; its exact two-field shape, count range, zero-pair invariant, and signed-client timestamp
  bound also validate at shared progression read/publication boundaries. Future timestamps are
  rejected against request time at boot/settlement, while deterministic transaction publication
  avoids wall-clock-dependent retry results. Corruption fails closed instead of selecting the
  maximum reward or entering the recovered client's permanent-streak branch.
- Paid-VIP lootbox countdowns must be exact 1-4 integers before shared progression publication;
  only an absent legacy field defaults to four. A selected visual's persisted parts may not exceed its catalog target before duplicate
  conversion, so damaged ownership cannot be normalized into WarBucks.
- Instant Battle timer/lifetime/paid counters must fit the recovered client's nonnegative signed
  integers before readiness, settlement, or boot; future timers and paid five-battle groups beyond
  the lifetime count fail closed instead of being clamped into a recharge or Gold-price state.
- Squad-creation history must keep its linear `(count + 1) * 25` WarBucks price inside the
  recovered client's signed integer before mutation or boot; wallet, revision, and the next count
  are validated before the transactional squad/debit write.
- Profile-owned rename count must remain 0-29 at the shared account boundary before authentication,
  gameplay use, unrelated profile writes, price, recovery, mutation, or PlayerAnalytics boot. The
  next count, Gold wallet, and progression revision validate before the atomic rename so count 29
  cannot publish count 30 and enter the client's signed shift/multiply overflow.
- One-time `collectedRewards` markers must be a bounded dictionary whose present values are exactly
  integer `1` before migration, grant/replay, boot, or shared progression publication. Legacy IDs remain preserved, but malformed
  values cannot split the client's key-presence decision from backend eligibility.
- A current daily-reward calendar must have a real UTC year/month/last-check date and ordered,
  month-bounded unlock/claim cursors before any check, claim, or wire projection.
  Subscription authority must also remain an ordered start/lock/expiry interval; future or inverted
  provider timelines fail closed instead of activating early or producing contradictory benefits.
- Rental state must pass one shared lifecycle validator before boot, equip, Army Power, acceptance,
  settlement, or redemption. Non-finite deadlines, unsupported types/discounts, and trial or sale
  intervals that contradict the replacement boundary fail closed instead of extending authority.
- Black Market state must pass one shared set validator before boot, issuance replay/rotation,
  serialization, or redemption. Unsafe expiry/cursors, duplicate weapon identities, oversized sets,
  and nonzero retired-feature authority fail closed instead of creating permanent offers.
- Visual inventory state must pass one shared authority validator before boot, purchase,
  ownership/equip, paid-pack extension, or voided-purchase reversal. Timed expiry and part counters,
  saved flags, slot keys, equipped IDs, and the previous-head field must retain their bounded recovered
  shape; non-finite expiry fails closed instead of granting a permanent temporary cosmetic.
- Starter assignment state must pass one shared authority validator before creation, boot,
  completion, claim, or serialization. Deadlines must be nonnegative Unix seconds within the
  recovered C# signed-int width, only the ten recovered IDs may exist, record flags must be Boolean,
  and claimed-but-incomplete state is invalid; non-finite or client-unrepresentable deadlines fail
  closed instead of creating permanently claimable onboarding rewards. The deployment-owned
  duration is resolved once during module startup as an immutable exact value in that same domain,
  and account initialization proves the issue-time-plus-duration deadline before addition. Seven
  days remains explicit reconstruction policy because the production duration was not recovered.
  Buffered rejection returns an expired empty client view without rewriting or reserializing the
  corrupt durable evidence, so the recovered per-action error remains transport-safe.
- Daily assignment cycle authority must validate its bounded safe `issued` and `tomorrow` Unix
  seconds plus the exact UTC `dayKey`/next-midnight relationship before rollover, mutation, or
  serialization; corrupt or non-finite reset values fail closed instead of freezing one day forever.
- Client-provided serialized blobs may be round-tripped but must not be trusted for rewards.
- Add tests for contract field names, authorization failures, duplicate requests, and concurrency.
- Update this tracker in the same commit whenever a feature status changes.
