# WarFriends GameServer

Private backend for the recovered WarFriends client — a **REST meta server** (accounts,
players, squads) plus a **WebSocket match relay** that stands in for Photon PvP. Design and
protocol notes: [`../BACKEND.md`](../BACKEND.md).
Core gameplay logic guides: [`../Docs/README.md`](../Docs/README.md).

Stack: Node.js + Express + TypeScript, MongoDB (native driver), Redis (optional), `ws`.
Structure mirrors the sibling recovery backend (`Heyworks/Backend`).

## Run

```bash
cp .env.example .env      # adjust MONGO_URL / REDIS_URL if needed
npm install
npm run dev               # ts-node-dev, watch mode
# or: npm run build && npm start
# optional explicit catalog publication: npm run sync:catalog
# read-only legacy squad/player integrity scan: npm run audit:squads
# apply only unambiguous mirror/card repairs: npm run repair:squads
```

Squad Events are disabled by default because the retired production live-ops schedule was not
recovered. Set `SQUAD_EVENT_CONFIG_PATH` only to an operator-reviewed file following
[`config/README.md`](config/README.md); an empty value makes action 113 return recovered error
`11302` without creating progress or granting rewards.

The separate limited-time Event Assignment calendar is also disabled by default. Set
`EVENT_ASSIGNMENT_CONFIG_PATH` only to a reviewed file following [`config/README.md`](config/README.md).
The backend then publishes its exact boot config/state and enables server-owned action 222/223
claims. Destroyed-box progress remains disabled until the match relay can prove that combat fact.

Requires MongoDB (`:27017`) and, optionally, Redis (`:6379`). Set `REDIS_ENABLED=false` to
run Mongo-only. Cross-player squad-card withdrawal and confirmed PvP core settlement use
multi-document transactions, so enable a single-node replica set for local development (or use a
replicated/sharded managed deployment) and include `replicaSet` in `MONGO_URL`. Health check:
`GET /health`.

## How the client talks to it

The client (`BeanstalkServerManager`) sends form fields to a URL ending in the numeric
`DatabaseAction` and dashed client version. It repeats the action in `requestId`; authenticated
requests use `PlayerId` and `Token`. Development tools may also send a JSON `DbAction`
envelope. `GetConfigurations` returns the exact three-segment raw text format required by the
recovered parser and ends after its sheet-version JSON object without an empty trailing segment;
other implemented actions return JSON. The replacement realtime layer connects to
`ws://<host>/hub`.

```bash
# Create a guest account (DatabaseAction 118) using the recovered BestHTTP shape
curl -X POST localhost:8080/PC/8b004c04-6921-4613-9815-e63b42db4a7c/118/1-6-0 \
  -d 'requestId=118&Version=1.6.0&Os=android&DeviceToken=dev-A'
# Response includes id, Token, Password, AccountType, typed Player, and typed PlayerData.
# Replay PlayerId + Token on every authenticated action.
```

## Layout

```
src/
  config.ts          env-driven config
  constants.ts       client enums (AccountType, League, SquadRank, PlayerStatus), Redis keys
  dbActions.ts       DbAction enum — the full server-operation catalog (wire contract)
  apiErrors.ts       numeric error codes + ApiError
  db.ts              MongoDB connection + typed collection accessors
  redis.ts           optional Redis (matchmaking queue, leaderboards, pub/sub)
  services/databaseMigrationService.ts  ordered, leased MongoDB schema migrations
  dtos/              wire types: envelope (base), DatabasePlayer, Squad
  services/          data/business logic: auth, player, squad
  handlers/          DbAction → handler dispatch (auth, player, squad)
  routes/            Express router: the Beanstalk POST endpoint
  gameRooms/         match room registry + relay types
  gameHub.ts         WebSocket hub: identify → join match → relay events → result
  index.ts           entry: express + http + ws + mongo + redis wiring
  utils/logger.ts    winston logger (per-level rotated files, emoji console)
```

## Status

Working end-to-end (verified live):

- **Accounts / player**: `CreateAccount`, `CreateFullAccount`, `LoginToCustomAccount`,
  `GetPlayerData`/`GetPlayerInfo`, and player settings (name/country/status/device token).
  Login/profile snapshots and private progression use the exact DynamoDB-style attribute
  wrappers parsed by the recovered 1.6.0 client. Human passwords use versioned salted scrypt with
  automatic legacy-HMAC migration; provider credentials remain separate from the rotated internal
  gameplay session token. Durable login guesses use an
  atomic MongoDB throttle keyed by an HMAC of the presented identity; active gameplay sessions
  remain usable and provider credentials are never accepted by ordinary gameplay actions.
  Full-account creation hashes before its single insert, while the recovered action 121 publishes
  name, password digest, and rotated session atomically with a stale-session guard.
  Repeated status, country, language, device-registration, and notification-setting values are
  exact no-ops; token and locale changes from one device-registration request publish together.
- **Platform identities**: Facebook, Google Play, and Game Center identities have unique
  ownership, HMAC-protected credentials, provider login, collision-safe link/update, and
  unlink behavior. First-time `CreateGcAccount` commits the player and identity in one transaction,
  returns separate platform/session credentials, and supplies the recovered `15400` existing-account
  profile contract. Remaining response-contract work is tracked in `BACKEND_FEATURES.md`.
- **Transport abuse boundary**: Express requests use a bounded per-address token bucket and the
  `/hub` WebSocket has an independent continuous-refill per-connection bucket before JSON parsing
  or serialized gameplay work. The WebSocket parser rejects frames above the configured 64-KiB
  default, rejected bursts receive `RateLimited { RetryAfterSeconds }`, and repeated consecutive
  violations close with policy code `1008`. Payload/rate/violation limits are bounded even when an
  unsafe environment value is supplied.
- **Bootcamp/tutorial lifecycle**: authenticated actions `119` and `120` persist one
  server-issued tutorial battle receipt and consume it only for the recovered Win end reason.
  Completion establishes the XOR-decoded MainScene minimums of 75 Gold and 15,000 WarBucks,
  starts the single placement match, and restores the presence-sensitive `TutorialData` marker
  on every later `GetPlayerData`. Client-echoed score, boxes, cards, wallet, and Army Power are
  ignored because the offline tutorial cannot prove them. Retries cannot refill spent currency;
  old no-receipt accounts may migrate once only with the stock empty `BattleId`.
- **Play Warcards tutorial**: the later onboarding battle unlocks at the recovered display
  level 6 and runs through the ordinary offline-bot action `64`/`62` path. The server projects
  `PlayerAnalyticsData.cardTutState` from durable state, binds `TutorialWarcards=1` to the earlier
  BattleId receipt, ignores forged `ObtainedCards`, and grants the exact MainScene
  `TutorialRewardCards` list once: `CLUSTERGRENADE`, `ELITEPARA`, `HEAVYTURRET`,
  `ELECTRICTRAPS`, and `SABOTAGE`. Losses complete it just like the recovered client; explicit
  Forfeit grants nothing, clears the attempt receipt, and leaves the tutorial available to retry.
- **HTTP abuse boundary**: every non-health API request passes through a continuously refilled,
  memory-bounded token bucket keyed by an HMAC-hidden client address. Reverse-proxy addresses are
  trusted only when `TRUST_PROXY_HOPS` is explicitly configured; rejected bursts receive HTTP 429
  and `Retry-After` without reaching request parsing or game handlers.
- **Photon-region profile compatibility**: action `140` validates and atomically persists the
  recovered ten-region latency dictionary plus `None`/`Cellural`/`Wifi` connection type.
  Public `DatabasePlayer` snapshots restore the exact `Regions: { S: "..." }` contract used by
  stock challenge/PvP code to choose the lowest combined-latency region. These client-measured
  values remain routing hints and never authorize a match result or gameplay reward.
- **Feature-introduction persistence**: parameterless actions `163`, `168`, `169`, `180`,
  `182`, `183`, and `213` now require authentication and monotonically persist the recovered
  chat, customization, Warpath, card-pool, league-leaderboard, crafting, and Elites booleans.
  `GetPlayerData` restores all seven through `PlayerAnalyticsData`, preventing onboarding UI
  from repeating after reconnect or reinstall. Action `182` was corrected from an unrelated
  top-Squads response to its real `leagueLeaderboardsShown` write. The broad action `179` blob
  remains ignored because it also contains client-controlled economy and progression counters.
- **Squads (core membership)**: create / unique-name check / public or requested join /
  invite / accept / decline / promote / demote / kick / leadership transfer / guarded
  leave, plus details and full member snapshots. Client ranks exactly mirror
  `Member`, `Veteran`, `Leader`, and `Coleader`. Kick persists the exact type-3 offline
  notification in the membership transaction. The operational integrity audit reports duplicate
  rosters, broken founders/leaders, and missing accounts; repair mode changes only unambiguous
  player mirrors and safely returns orphaned normal card deposits.
- **Squad Wars reads**: `GetSquadWarsDivision` validates its round identifier and returns the
  recovered `LeagueId`/`SquadWarsId`/`Items` contract with ranked `RoundId`/`Position` squad rows.
  The identifier is explicitly marked reconstructed until the retired season scheduler and
  reward tables are recovered or replaced by configured server data.
- **PvP (WebSocket `/hub`)**: identify → `FindMatch` (matchmaking pairs by army-power within
  a widening league window) → `MatchFound` → `JoinMatch` → `MatchStart` → in-match
  `MatchEvent` relay to the opponent → `MatchResult`. Room joins/events are restricted to
  recorded match participants, WebSocket settlement requires matching reports from both
  participants, and the database settlement claim is idempotent. Match creation inserts the
  durable row and reserves both current profiles as `InGame` in one MongoDB transaction; duplicate
  participants, corrupt snapshots, missing accounts, and concurrent active-match claims fail
  without partial state, and still-eligible connected players are restored to the bounded queue.
  With Redis available, queue deduplication, stale cleanup, bounded candidate selection, pairing,
  removal, and failed-admission restoration execute atomically across backend nodes. `MatchFound`
  can be relayed to the opponent's node through a bounded pub/sub instruction, but that receiving
  node re-reads MongoDB and proves active-match membership before sending anything to its socket.
  Without Redis, the same code retains the verified process-local queue and direct delivery path.
  Match rows record their coordinator node, whose renewable Redis heartbeat separates crashed-room
  orphans from live peer-owned matches. Startup and periodic recovery cancel confirmed orphans and
  repair only unprotected `InGame` profiles; an unknown Redis observation is conservatively retried.
  Distributed `JoinMatch` writes authenticated participant membership idempotently to MongoDB. The
  request that atomically completes the assigned pair writes `roomStartedAt` once and fans a
  MongoDB-validated `MatchStart` to both nodes; late join-timeout callbacks cannot cancel it.
  Cancellation likewise commits the terminal match and both presence releases together. On a
  single-node restart, active/settling matches are cancelled and all residual `InGame` profiles
  are repaired in the same transaction, including legacy partial cancellations.
  Replacement clients send an
  inventory-consuming activation as `MatchEvent { Event: "CardPlayed", Data: { Sequence,
  CardId } }`: the server validates the authenticated owner's complete candidate list, durably
  appends contiguous evidence before relaying the effect, acknowledges exact retries without
  relaying twice, and requires terminal `UsedCards` order and multiplicity to match. Per-socket
  message serialization prevents a sender's result from overtaking its last card event; durable
  evidence is also consumed when a disconnect forfeit settles before MatchResult. Players move from
  `InGame` back to `Online`. Disconnects allow a configurable reconnect grace period,
  then resolve as a forfeit or no-reward cancellation; interrupted matches are recovered
  on server restart. Photon-era `GameEnded` reports interpret the recovered `EndReason`
  enum and require matching durable reports from both assigned participants before rewards.
  Action `29` remains the presence heartbeat for non-ranked modes, but its active-match read and
  profile write share a MongoDB transaction. An active/settling ranked reservation always wins
  over a forged or early `Online`/`Offline` report.
- **Squad Chat (WebSocket `/hub`)**: after `Identify`, a replacement client sends
  `SubscribeSquadChat` to receive `SquadChatSubscribed { SquadId, Messages }`, using the exact
  recovered three-message history default. When `NextBeforeCursor` is non-null,
  `GetSquadChatHistory { BeforeCursor }` returns the next older page without changing the bounded
  server page size; the opaque versioned cursor combines exact milliseconds and message UUID so
  equal-time rows are not skipped. It sends text with `SendSquadChat { ClientMessageId, Text }`;
  the server returns `SquadChatMessageAccepted` and delivers a persisted
  `SquadChatMessage` to connected, subscribed current roster members. Player/squad mirrors,
  roster membership, rank, sender name, level, league, and timestamp are all server-owned. A
  sender-scoped 64-character nonce makes reconnect retries idempotent, while moderation,
  single-line validation, a persistent rolling rate limit, immediate expiry filtering, and a
  MongoDB TTL index bound abuse and retention. Optional Redis pub/sub carries only the origin and
  durable message UUID between hub nodes; receiving nodes reload content and the latest roster
  from MongoDB, suppress duplicate notices, and continue single-node delivery when Redis is down.
  This is a replacement protocol: the stock client still needs its Photon Chat adapter repointed
  to these typed messages.

- **Leaderboards / player leagues**: `GetPlayersByExperience` and squad boards remain
  MongoDB-authoritative with opportunistic Redis warming. `GetPlayerLeaguesDivision` now
  materializes a stable UTC season, ranks the exact division by weekly medals, and returns
  `LeagueEvaluation`; confirmed PvP consumes placement; `FinishPlayerLeague` atomically
  promotes/relegates all members and queues the recovered type-23 result/reward messages. The same
  transitions persist exact group-13 league achievement progress (Silver II/Gold I/Master III for
  5/10/20 Gold) from the server-owned profile tier.
- **Social / messaging**: `SearchPlayers` (name prefix), `GetAllPlayers`, exact Facebook-friend and
  authoritative squad-mate resolution through `GetFriendsInfo`, challenge and normal
  `MessageSent`, `GetAllMessages`, `ReadMessage`, `IgnoreMessage`, and `AcceptChallenge`
  (recipient-owned persistent inbox). Challenges expire logically and through MongoDB TTL;
  identical send retries are deduplicated and player-generated traffic has a rolling sender limit.
  Acceptance records its first durable timestamp and is idempotent after a lost response, while
  wrong-recipient, ignored, expired, and non-challenge rows remain rejected.
  Direct DeathMatch challenges retain the stock Photon handoff: the inviter creates a named room
  carrying `battleID`, the inbox message transports room/region/version metadata, and actions
  `64`/`65` report `IsMatchMaking=0` after both clients join. The backend stores a separate,
  participant-owned lifecycle receipt for that tuple and recognizes challenge `GameEnded` retries
  as successful friendly results with a complete zero-valued `GameReward`. This path intentionally
  cannot enter ranked match consensus or mutate currency, XP, medals, league placement, win streak,
  War Cards, squad points/events, assignments, missions, VIP countdowns, or rental state.
  `GetAllMessages` keeps the stock `Items` array and adds an optional `NextCursor`; a replacement
  client sends it back as `BeforeCursor` to read older pages. The cursor combines exact
  milliseconds with the message ID, page size remains server-bounded, and every query retains the
  authenticated recipient filter and immediate challenge-expiry rule.
  The stock buffered `IgnoreMessage` path records a durable progression outbox entry beside
  `BufferId`, performs the recipient-filtered inbox update, and clears the entry afterward, so
  a process interruption is recoverable without allowing one player to hide another's message.
- **Moderation reports**: authenticated player/cheater reports are validated, rate-limited,
  deduplicated for safe retries, and stored with review status and evidence metadata. The
  configurable five-per-hour default is reserved by one atomic MongoDB counter per reporter, so
  simultaneous requests across backend processes cannot overrun it. The submitted
  Army Power/rank/time fields remain explicitly untrusted claims. When both accounts occur in a
  recent replacement-backend ranked match, the report also captures the exact server match ID,
  participant snapshots, state, terminal winner/cancellation, authenticated result claims, and
  bounded relay/used-card observations. The snapshot keeps `combatValidated=false` because the
  relay still cannot prove damage, targets, timing, or card effects; social reports and legacy
  Photon matches remain valid reports with no fabricated match correlation.
  Duplicate target/type requests also converge on one HMAC-keyed MongoDB winner containing the
  complete first payload; all concurrent processes upsert that same report ID, while logical
  ten-minute expiry is enforced independently of delayed TTL cleanup.
- **Public-text moderation**: account/rename names, Squad names/descriptions, and direct messages
  share Unicode-normalized multilingual matching with punctuation/leetspeak resistance. Add
  deployment-specific comma-separated terms with `PROFANITY_EXTRA_TERMS`; report evidence is
  intentionally preserved verbatim for review.
- **Energy economy**: server-owned dog-tag seconds, passive regeneration, atomic
  `PayOneDogTag`, and gold-validated `RefillDogtags` using the recovered 900-second/5-tag
  balancing and refill-price formula.
- **Gold-to-WarBucks exchange**: action `221` validates `WarbucksId` against the deployment-owned
  MainScene A/B prefix, debits the exact 50/200/500/1000/3500/7000 Gold row, and multiplies the
  exact row units by the authenticated player's source `CONVERTGOLDTOWARBUCKS` rank value. The
  wallet and a narrow transport-replay receipt commit atomically. `WARBUCKS_GOLD_VARIANT` defaults
  to the conservative standard curve because the retired remote experiment selector is absent.
- **Instant Battle / Skirmish**: action `199` is server-authoritative from rank 9 onward. A
  new account starts with five ready battles; after a batch is consumed, one battle recharges
  every 48 minutes up to five. A free request consumes every currently ready battle. When none
  are ready, the paid path verifies and debits the exact 35/70/140-Gold escalating price and
  simulates a full five-battle batch. Timer, lifetime/paid counters, wallet, XP, level Gold,
  dog-tag rank-up refill, and rank Army Power commit in one revision-guarded player write and
  are restored through `PlayerAnalyticsData`. The hybrid MainScene's shifted five constants are
  realigned to the old script's field order so its visible five-charge/35-Gold UI agrees with the
  backend. The retired reward table is unavailable; `INSTANT_BATTLE_XP_PER_BATTLE` (20) and
  `INSTANT_BATTLE_WARBUCKS_PER_BATTLE` (600) are explicit offline policy, while rare Gold/card/
  extra-WarBucks rewards remain disabled rather than fabricated.
- **Versioned client-data material database**: MongoDB collections `gameCatalogEntries` and
  `gameCatalogReleases` persist the recovered 4.9.5 weapon, soldier/unit, rank, power, player
  visual, War Card, and card-pack data as 531 queryable records. The 165 concrete weapon
  records comprise 84 shop and 81 dedicated Black Market LevelManager setups; 18 unresolved
  rows retain nine members from each family. Every playable weapon record joins its source row to the full
  upgrade table; every playable unit joins roster/deployment/purchase data to normal, special, and
  elite level rows; every visual joins its price/effect row to a serialized client asset. Nine
  unresolved Pulse Rifles, three helper units, 18 unresolved unit rows, and the assetless
  `HEAD_MASK_ROCKET` visual and 25 card definitions without serialized Card components are
  retained with explicit non-playable states instead of being
  discarded or silently enabled. Per-entry SHA-256 hashes and a deterministic release hash make
  balancing changes auditable. Startup idempotently writes all immutable revision entries before switching the
  current 4.9.5 release pointer, so readers cannot observe a partial synchronization. Run
  `npm run sync:catalog` to publish explicitly; normal server startup performs the same sync.
- **Authoritative Army Power**: `scripts/Extract-ArmyPowerCatalog.mjs` reproduces 11,805 normal
  weapon DPS rows and all 58 player-rank `ARMYPOWER` rows from MainScene. The server independently
  rounds equipped-unit float power, equipped-weapon float DPS, and the current zero-based rank row
  exactly where `LevelManager` does, then atomically stores their sum in both indexed and public
  player state. `UpdateArmyPower` ignores the client's claimed value and recomputes against one
  consistent progression revision; concurrent inventory changes force a reload. Active
  weapon and unit rentals contribute only while the exact persisted 12-hour trial is
  unexpired. Black Market weapons use their persisted offered `boughtIndex` and
  special-feature index with the exact coefficient from all 11 category rows.
  Run `npm run verify:army-power` to compare the
  generated catalog with the recovered scene. Action `192` confirms the source progression
  revision and performs no write when both denormalized Army Power copies are already current.
- **Player visuals and decals**: `scripts/Extract-VisualCatalog.mjs` joins all four serialized
  customization categories to the 4.9.5 PlayerVisuals sheet, producing 146 playable and one
  unresolved row. `DecalManagerData` is server-owned and boot-safe; buffered `BuyDecal`,
  `EquipDecal`, `DecalWasShown`, and `VisualWasShown` validate source, price, category, VIP,
  ownership, expiry, and shop eligibility. Gold/WarBucks debit, permanent or timed ownership,
  four-slot equipment, notification state, rollback data, and `BufferId` replay protection are
  atomic. Re-equipping the current category item and replaying an already-cleared visual badge
  acknowledgement preserve exact state identity instead of creating false inventory revisions.
  Actions `104`/`105` now persist the weapon/unit `showed` flags through both direct and
  buffered transports without granting ownership; locked or unknown rows fail closed. Direct
  action `194` and its stock buffered form are explicit telemetry acknowledgements, so opening a
  notification cannot poison an otherwise valid RequestBuffer with `UnknownAction`; echoed player
  and message identifiers never mutate progression.
  `BuyLootboxes` validates one of the six exact MainScene products (49/89/159/279/479/749 Gold
  for 5/10/20/40/80/150 one-part rewards), atomically debits Gold, persists every part and exact
  duplicate-WarBucks conversion, and returns the recovered `NewVisuals`/`Id`/`LootboxCost`
  contract. Client-authored sales remain rejected. Confirmed active-VIP PvP settlement also owns
  the source-defined four-battle countdown
  and two one-part suitcase rewards: parts, exact duplicate WarBucks, `NewVisuals`, and immutable
  retry receipts commit in the terminal match transaction. The retired production weights are
  unavailable, so selection is explicitly reconstructed as uniform across the 73 normal-shop
  part rows; event/Arena/loyalty/assignment/value-pack grants, visual rentals, and unsupported
  discounts remain fail-closed. Run `npm run verify:visual-catalog` to compare the artifact with
  MainScene.
- **VIP purchase and expiry authority**: action `114` validates `VIP_1` through `VIP_4` against
  the 4.9.5 MainScene table (49 Gold/12 hours, 249/3 days, 499/7 days, and 1799/30 days), debits
  Gold and extends the Unix entitlement in one revision-safe transaction, emits the exact
  `Vip`/`VipStart`/`Gold`/`Id` success contract, and returns recovered `11401`/`13601` recovery
  payloads. Active VIP is read from progression by direct and buffered VIP-only visual purchases;
  action `195` is a deadline-based acknowledgement. Active members also receive exactly two
  daily War Cards through the recovered `VipReward1`/`VipReward2` response contract: each draw is
  Gold with the source-decoded 75% chance and Silver otherwise, while an atomic UTC cursor prevents
  reconnect, renewal, and concurrent-fetch duplicates. Login, VIP purchase, and daily-calendar
  claims use their exact outer/nested parser locations. The periodic benefit advances only on
  confirmed active-VIP PvP, resets after four battles, grants two independently selected visual
  parts, preserves duplicate `_#n-VIP` wire entries, and restores its countdown through
  `PlayerAnalyticsData`. Nonzero VIP discounts stay rejected until retired Fusebox offer
  definitions are recovered into a server allowlist.
- **War Card inventory and card packs**: exact `CardManagerData` is persisted and returned at boot.
  `scripts/Extract-CardCatalog.mjs` reproduces 58 playable cards, 25 unresolved definitions, and
  four source-priced packs from MainScene. Buffered `BuyCardPack` validates unlock level, pack,
  count, playable IDs, fixed and ranged rarity slots, discount, timing, and funds; then atomically
  debits Gold/WarBucks and increments card amounts with `BufferId` replay protection and exact
  rollback fields. The stock client selects card identities before sending and cannot consume
  replacement IDs on success, so identities inside the verified rarity envelope remain
  client-selected until a nonce or client adapter is added. Run `npm run verify:card-catalog` to
  verify the generated artifact.
- **Timed War Card crafting**: exact `CraftData` is returned at boot. Direct `CraftCard` atomically
  consumes three same-rarity owned cards and creates the extracted 30-minute Bronze-to-Silver or
  60-minute Silver-to-Gold receipt. `ClaimCraftedCard` enforces server time, selects one playable
  next-rarity result with cryptographic randomness, grants once, and clears the receipt. Recovered
  17401/17601/17701 recovery bodies restore client state, and a claimed Gold craft proves starter
  assignment ID_8. Subscription-only `CraftAndClaimCard` remains rejected until platform
  subscriptions are authoritative.
- **Squad War Card pool**: `DepositCards` validates the nested
  `AddedCards`/`RemovedCards` dictionaries, ownership, and the recovered 3-10 slot squad-level
  capacity before atomically exchanging inventory and `depositedCardsDic`. `WithdrawCard` verifies
  both players against the same squad roster, transfers one card in a MongoDB transaction, awards
  the donor 5/15/45 rarity reputation, and starts the exact 240-minute recipient cooldown. Existing
  New Buddy deposits reproduce `CreateDataForCurrentPlayer`: owner/timestamp identity, account
  name, zero-based level, Army Power, four visual slots, four owned weapon slots, unit-type-specific
  primary/secondary pair, one-pool limit, and the exact 480-minute cooldown are server-validated.
  Existing Buddy deposits transfer with their full loadout and a ten-card cap.
  `NotifyPlayerToDeposit` validates both players against the same roster and persists the exact
  type-28 sender snapshot with one actor/target reminder per UTC day.
- **Weapon inventory foundation**: private and public player snapshots now serialize the
  exact recovered `InventoryData.slots` and `LevelManagerData.savedWeapons` structures with
  the 4.9.5 starter loadout. Stock buffered `BuyWeapon`/`ActivateWeapon`/`EquipWeapon` supports all 84
  `PURCHASABLE: shop` rows that also have real LevelManager entries. Their obscured Gold and
  WarBucks prices, level gates, category masks, and non-sequential indexes are recovered from
  MainScene; purchases grant immediate ownership because every enabled row has
  `DELIVERTIME=0`. Action `128` validates the preceding permanent purchase as an idempotent
  zero-delivery acknowledgement and cannot grant or convert a rental. Mutations include server
  price/discount validation, atomic debits, category-safe equipment, Unity rollback fields, and
  `BufferId` replay protection. Re-equipping the exact current weapon is validated but preserves
  progression identity instead of creating an unrelated inventory revision. Timed
  `InstantBuyWeapon` remains rejected because no supported
  source row can produce its required pending-delivery state. Nine
  shop-priced Pulse Rifle rows with null LevelManager entries, unknown catalog rows, and
  unrelated OfferManager-discounted purchases still fail closed.
  `../Tools/Extract-WeaponCatalog.ps1` reproduces the catalog by joining the serialized
  LevelManager setup array to the Google2u component on each weapon GameObject, resolving
  Unity DLL script IDs through the recovered assemblies, and XOR-decoding both currency
  fields. Run `npm run verify:weapon-catalog` to prove that the checked-in extraction artifact
  and the runtime catalog still match the recovered 4.9.5 scene exactly.
- **Weapon upgrade lifecycle**: buffered actions `73`-`75` use all 165 recovered per-level
  Google2u tables across shop and Black Market families (11,640 normal-level transitions).
  BuyWeaponUpgrade validates the old index
  and source duration, debits the server-owned WarBucks price, and creates the single shared
  `weaponDelivery` receipt used by
  LevelManager. Normal activation enforces its server end time; instant activation derives
  Gold from the recovered float32 `0.6325`/`-0.175` formula and the persisted delivery receipt.
  A delayed buffer may pay its earlier valid price but can never pay below the receipt-time
  server price. Both completion
  paths increment `boughtIndex` once, clear delivery atomically, return Unity rollback fields
  on failure, and inherit `BufferId` replay protection. Run `npm run verify:weapon-upgrades`
  to compare the generated price/time catalog with MainScene.
- **Black Market weapon offers**: action `217` returns the exact serialized
  `BlackMarketOfferData` contract and persists the same object into boot data. The existing
  weapon extractor now also XOR-decodes all 5,860 normal-level `WEAPONPRICE` Gold values
  across the 79 concrete Black Market rows that contain that purchase column.
  Active sets contain up to four unowned supported weapons for 24 hours and are deterministic
  across retries; buffered `BuyWeapon` redemption requires the authenticated stored offer,
  its unexpired deadline, zero WarBucks, and its exact level price. Weapon level and special
  feature come only from server state, and the wallet/ownership mutation remains atomic and
  BufferId-replay-safe. Reading the same active action-217 set preserves progression identity
  and does not rewrite MongoDB. Issued offers currently use recovered feature index 0; the original
  remote selection weights, trigger schedule, feature weights, and OfferManager discount
  entitlements remain reconstruction gaps.
- **Daily weapon and unit rentals**: GetPlayerData issues the exact outer `Rental` object only
  after durable tutorial completion and once the zero-based player level reaches display rank 4.
  The 4.9.5 MainScene values decode to a
  20-25% sale, a 12-hour free trial, a 24-hour offer, and 0/2/7 visual/weapon/unit weights;
  visual rentals are therefore deliberately not generated. Action `138` accepts only the
  recovered `buyRentalDiscounted` Boolean and returns the nested `RequestsResults` string
  consumed by the old aggregate parser. A free trial materializes one borrowed item, permits
  normal equip and Army Power only while its server deadline is live, then PvP, mission, or
  Arena `GameEnded` removes the borrowed authority, restores a replaced weapon slot, and emits
  the discounted sale variant. Permanent redemption recomputes the price from the stored
  catalog row and discount, atomically debits the authoritative wallet, and is idempotent on
  transport retry. Repeated trial acceptance or permanent redemption returns the existing
  result without incrementing progression revision or replacing an identical MongoDB document;
  the post-battle hook has the same no-write behavior when no trial can advance or its sale is replayed.
  Exact original remote item selection is unavailable, so eligible unowned
  items use a documented deterministic replacement within the recovered three-level window.
- **Unit purchase, loadout, and upgrade lifecycle**: `../Tools/Extract-UnitCatalog.ps1` joins the recovered
  `LevelManager.behaviours` and `additionalBehaviours` arrays through each behaviour's
  `UpgradeSlots` GameObject to the `Google2u.ArmyUpgrades` master row. The checked-in artifact
  records 24 player-roster units, three non-purchasable turret helpers, and 18 newer table rows
  that have no LevelManager object in this client. Buffered `BuyUnit`/`ActivateUnit` now supports
  the 23 non-tutorial player rows with exact XOR-decoded Gold/WarBucks prices, zero-based level
  gates, display unlock checks, initial tier state, atomic wallet/ownership writes, Unity rollback
  fields, and `BufferId` replay protection. All supported rows have `DELIVERTIME=0`, so BuyUnit
  grants ownership and the stock client's immediate ActivateUnit is a validated idempotent
  acknowledgement rather than a fabricated timer. `UpdateEquippedUnits` persists the tutorial
  Assaulter's first backend-visible grant and the full owned roster while enforcing the recovered
  two-per-category and three-mechanical-unit caps; invalid changes receive the exact 11406 rollback
  dictionary. Replaying an identical valid roster returns exact state, while a missing tutorial
  grant still persists once. The same extractor records 4,124 normal, 684 special, and 216 elite per-level rows
  across all 24 player tables, including absolute source offsets, tier, float ArmyPower,
  XOR-decoded WarBucks price, delivery duration, and Elite parts price. Buffered actions `77`-`79`
  use those rows to enforce separate normal and
  special cursors, promotion-gated special access, current-tier maximums, one shared unit-delivery
  receipt, server time, exact WarBucks debit, receipt-backed instant Gold cost, atomic completion,
  Unity rollback, and replay safety. `PromoteUnit` then validates normal-tier completion, the
  recovered one-based `UNLOCKTIER2`-`UNLOCKTIER6` level gates, maximum tier 6, ownership, and an
  empty delivery receipt before advancing only `tier`; the exact 11405 level error includes the
  diagnostics consumed by the client warning handler. `UpgradeEliteSlot` action `209` now validates
  the relative Elite cursor and exact source parts/WarBucks cost, performs the immediate atomic
  debit/increment, returns the recovered `104`/`20902`/`20903` failures, and is replay-safe. Unit
  ArmyPower reproduces Unity float32 addition for normal, promoted-special, and bought-Elite rows
  and sums only equipped permanent units. Helper/unresolved rows and offer/subscription discounts
  remain fail-closed. The authoritative ArmyPower service combines this unit component with the
  recovered weapon DPS and player-rank components, then persists the complete total through a
  progression-revision compare-and-swap. Run
  `npm run verify:unit-catalog` to compare both artifacts with MainScene and the recovered
  assemblies.
- **Daily rewards**: `CheckDailyReward` and `ClaimDailyReward` provide the recovered monthly
  `dailyRewardData` calendar contract, one UTC-day unlock, ordered replay-safe claim cursors,
  and exact parser payloads for Gold, WarBucks, Arena Tickets, loose Bronze/Silver/Gold cards,
  and Bronze/Silver/Gold packs. Wallets, inventory, achievement progress, the optional VIP pair,
  and the claim cursor commit atomically. The deterministic seven-position schedule and amounts
  are an explicit conservative replacement because the original remote live-ops sheet is absent.
- **One-time rewards**: action `161` accepts only the three source-backed Facebook Like, Twitter
  Follow, and notification-permission DBKEYs; the separate Facebook-login reward requires a
  successful authenticated provider link. The server credits their exact decoded Gold values once
  and restores claim markers through `PlayerAnalyticsData.collectedRewards`. The
  response omits the presence-sensitive `WasAdded` property on replay so the stock parser cannot
  add local currency twice. The recovered `WeaponTutorial` and `UnitTutorial` paths are restricted
  to the exact AK47 and Assaulter parameters, require cursor zero and an empty delivery slot, and
  derive their 500/375 WarBucks plus 1 Gold funding from the same generated first-upgrade rows used
  by inventory validation. Unknown archived rows remain closed, and production proof of external
  social/platform actions still requires provider integration.
- **Assignments**: `GetNewAssignments`, both skip actions, assignment/mega claims, and the
  stock `SendRequestBuffer` path use a persistent UTC cycle. Only objectives derived from
  confirmed PvP settlement advance. Same-day `GetNewAssignments` reads preserve progression
  identity while the UTC rollover persists once; buffered claim retries are idempotent by `BufferId`, return
  the cached response without a revision/write, and never roll an unrelated UTC cycle.
- **Limited-time Event Assignments (authoritative claim foundation)**: client actions `222`/`223`
  belong to the separate Christmas-style `EventAssignmentManager`, not Squad Events. A strict,
  non-overlapping, disabled-by-default operator schedule publishes the exact outer
  `EventAssignmentConfig`, UTC `Midnight`, and nested `EventAssignmentData` contracts. Daily and
  ordered milestone claims derive their active index, target, points, currency/parts/visual reward,
  and eligibility from immutable hashed server configuration; wallet/inventory/claim state commits
  atomically and `BufferId` replay cannot grant twice. Client `RewardType`, `RewardValue`, and
  `MilestoneId` are assertions only. The client-local destroyed-winter-box update is deliberately
  ignored until authoritative battle telemetry can advance the provided trusted-progress transition.
- **Daily/co-op/heroic missions**: actions `67`-`69`, `215`, `216`, and mission-flavoured
  `GameEnded` use the exact `DailyMissionsData`, `SavedMission`, and compact `MissionUnit`
  fields. UTC issuance, start receipts, consumed failure receipts, mode/index/order checks,
  no-write same-day boot/start/settled-receipt replay, durable expired-session pruning,
  separate solo/co-op completion, response replay, the 30-point heroic gate, and recovered
  completion currencies are persisted atomically. Mission XP and WarBucks now reproduce the
  recovered `MissionsConstants` exponential level formula, per-slot `MissionsSettings`
  modifiers, upward-to-50 rounding, zero co-op-master share, and half co-op-client share. The
  result applies the source 1.5x/1.5x/2x VIP XP/WarBucks/GameGold rules, crosses exact rank rows,
  grants rank-up Gold, refills dog tags, and recomputes rank Army Power in the same guarded
  document write. Base `GameReward` components are cached with the receipt so retries cannot
  multiply or duplicate them. The archived server's random mission selection remains a
  reconstruction gap. Completing the fifth Heroic mission now also
  grants the exact level-row Bronze/Silver/Gold ten-card pack and one Elite part for the unit
  target persisted in `DailyMissionsData`; identities, inventory, currencies, and receipt commit
  together, with bought units preferred by the documented replacement selector. The daily cycle
  now cryptographically selects all six source reward variants after the rank-6 War Card unlock
  (currency-only before it); Bronze/Silver/Gold card variants grant their exact 8/5/3, 9/6/4, or
  10/7/5 level-row counts through `DailyMissionsCompletionRewardCards`. The missing production
  reward-type weights and `FROMMISSION` selector semantics remain explicit uniform/level fallbacks.
- **Starter assignments (authoritative subset)**: actions `185`/`186` restore the exact
  `StarterAssignmentsData` object and the MainScene-defined thresholds, order, Gold, and
  WarBucks rewards. Ranked wins, medal balance, level, lifetime squad points, and the first
  replay-safe mission completion, and the exact equipped secondary-weapon level required by
  ID_7 and a server-granted Gold craft for ID_8 are checked against server state; buffered claims
  are ordered, atomic, reward-validated, and replay safe. Unit deployment and war-card completions
  remain disabled until those event sources exist.
- **Achievements (authoritative subset)**: actions `218`-`220` use the recovered
  `AchievementsData`/RequestBuffer contract. Solo missions, ranked wins, assignment completion,
  squad points, and daily-reward claims advance only from accepted server settlements. Purchased
  weapons/units, their normal upgrades, paid permanent visuals, and confirmed consumed War Cards
  are re-derived from authoritative progression snapshots using the client's StatsManager rules.
  Accepted Arena wins and maximum-win runs without an accepted loss advance exact MainScene groups
  3 and 4 inside the Arena receipt transition, so retries cannot duplicate their Ticket/Scraps
  progress. Group 13 mirrors the authenticated profile's highest reached league tier and rejects a
  larger action-220 client value. Group 17 retains the largest validated, inventory-consuming PvP
  card list and grants the exact one-time 50,000-WarBucks reward at five cards. Exact serialized
  MainScene tier rewards are granted atomically and replay-safely.
- **Squad social state**: action `193` persists the monotonic Photon Chat unread cursor through
  the stock request buffer and restores it as `PlayerAnalyticsData`; equal or stale cross-device
  cursor updates return the authoritative value without a false revision/write. Squad-event notices are
  membership-validated, founder-targeted, durable, and duplicate-suppressed. The `/hub` replacement
  now persists moderated Squad Chat messages, returns recovered-size history, suppresses nonce
  retries, and fans out only to authenticated subscribers still present in the current roster.
  Multi-node delivery uses non-authoritative Redis notices followed by an authoritative MongoDB
  message/current-roster reload on each receiving node.
- **War Arena (persistent core)**: login supplies the recovered Dynamo-style
  `WarArenaConfig`, while `EnterArena`, action-64/65 starts, Arena `GameEnded`, heart/life
  actions, scraps claims, rollover, and `GetArenaLeaderboards` use the exact `WarArenaData`
  contract. Action `212` requires authentication, accepts only the active server-generated
  `ArenaId`, and retains a bounded two-year event-dialog acknowledgement history without exposing
  it in the public wire object. Replays do not increment progression revision or write MongoDB,
  and acknowledging a dialog cannot enter an event or grant value. Runs and prices are server-owned,
  battle IDs are receipt-bound, and entry/start/result/heart/life/reward/end retries return their
  recovered response without a false revision increment or MongoDB replacement. Expired receipt
  cleanup remains durable because it unblocks a future battle. Arena achievement progress shares this receipt authority; combat outcomes
  remain client-reported pending authoritative validation. The retired remote price/lootbox tables are absent from both APKs,
  so entry/heart/scraps values are environment-tunable and final lootboxes currently use a
  documented scraps fallback rather than fabricated inventory objects.

Unimplemented state-changing `DbAction` values return error code `90`; only an explicit
allowlist of analytics/impression actions is safely ignored.

### Next

- **Squad extensions** — normal/Buddy pool deposits and withdrawals are implemented.
  Server-selected Buddy unit-type RNG and squad events/wars remain. Type-28 card-pool request
  notifications validate same-roster membership and use daily actor/target idempotency. Persistent
  Squad Chat delivery now exists on `/hub`, including optional Redis multi-node fan-out; add the
  Unity Photon-to-WebSocket adapter and offline platform push notifications.
- **Item economy expansion** — unit Elite upgrades, normal shop visuals, Gold lootbox bundles,
  weapon/unit notification acknowledgements, normal card-pack
  purchase, dedicated Black Market weapons, daily weapon/unit rentals, and complete active-loadout
  ArmyPower, periodic VIP visual-part lootboxes, and the exact five-card Play Warcards tutorial
  reward are implemented. Add the remaining authoritative combat card reward/consumption events,
  server-selected card/Buddy RNG, and non-shop visual reward delivery.
  Normal unit purchase is authoritative for 23
  non-tutorial roster units, and the tutorial unit is persisted through its first equip event;
  three helper rows and 18 ArmyUpgrades rows without LevelManager objects remain closed. All 84
  resolvable shop weapons and 81 concrete Black Market weapons support authoritative equip/upgrade
  state; the nine unresolved rows in each weapon family, two Black Market rows without
  `WEAPONPRICE`, unknown items, and
  unrelated discount-bearing requests remain rejected instead of receiving guessed prices or unusable
  inventory records.
- **Player leagues** — the server owns source-backed 16-tier placement and season state,
  exact weekly-medal division ordering, recovered promotion/relegation percentages, the
  30-player underfilled rule, Champion/underfilled Gold rewards, and transactional action-198
  settlement with type-23 inbox results. Confirmed PvP also advances the three beginner stages
  using the recovered 100-player rank curve, 50/100/150 maximums, 40/35/31 promotion positions,
  and Unity-compatible rounding; UI-only random rank jitter is never backend authority. The final
  stage atomically emits the stock normal-league handoff fields and enters the managed Bronze
  division. The local UTC-aligned allocator intentionally uses one reconstructed division per tier
  until the retired production 100-player allocator and background scheduler are recovered or
  replaced; the final beginner weekly-medal reset remains explicit reconstruction policy.
- **Arena fidelity / league operations** — recover production arena prices, rules, opponent
  weighting, lootbox/crown inventory payloads, and authoritative combat evidence; add bounded
  league division documents and scheduled settlement; verify the final beginner weekly-medal reset
  from an archived service response. Arena debug mutations remain rejected.
- **Mission fidelity** — recover the original mission-selection and daily-reward-type weighting,
  exact `FROMMISSION` card eligibility semantics, and production Heroic unit selection weighting
  to replace the documented uniform and bought-first cryptographic fallbacks; add combat-result
  validation.
  Remaining deployment, stolen-crate, and first-Squad-War achievement groups stay unclaimable until
  their gameplay events are authoritative. Group 17 uses accepted owned-card consumption but still
  shares the documented missing live card-event-validation boundary.
- **PvP reward tuning** — XP/medal/squad values in `matchService.REWARDS` remain reconstruction
  policy. Normal WarBucks uses server-owned `PVP_WIN_WARBUCKS` / `PVP_LOSE_WARBUCKS` defaults
  because the retired Fusebox `BattleWarbucksRewards` document is not present in either APK;
  client-echoed reward values are never trusted. VIP's 1.5x WarBucks multiplier is source-decoded.
- **REST result consensus** — `MATCH_RESULT_CONSENSUS_WAIT_MS` bounds the read-only wait that lets
  the first stock `GameEnded` request receive the receipt committed by the second agreeing report.
- **Win-streak fidelity** — the 200-second interval and nine valid WarBucks tiers are decoded from
  MainScene and persisted authoritatively. The corrupted/unusable tenth value is capped at tier nine
  until archived live balancing is available.
- **League win rewards** — the three beginner and 16 normal MainScene WarBucks/squad-point rows
  now settle from authenticated player state, use the exact lower-case `squadPoints` response key,
  and apply VIP independently without trusting client reward echoes.
- **Medal consistency** — confirmed results update both global `Skill` and weekly
  `MedalsBalance`; immutable receipt snapshots keep retries from presenting later battle state.
- **Client integration** — form request routing is implemented, but exact response keys for
  every action and the Photon→WebSocket client repoint remain `⚠ RE-NEEDED`.
