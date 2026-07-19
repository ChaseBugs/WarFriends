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

Requires MongoDB (`:27017`) and, optionally, Redis (`:6379`). Set `REDIS_ENABLED=false` to
run Mongo-only. Cross-player squad-card withdrawal and confirmed PvP core settlement use
multi-document transactions, so enable a single-node replica set for local development (or use a
replicated/sharded managed deployment) and include `replicaSet` in `MONGO_URL`. Health check:
`GET /health`.

## How the client talks to it

The client (`BeanstalkServerManager`) sends form fields to a URL ending in the numeric
`DatabaseAction` and dashed client version. It repeats the action in `requestId`; authenticated
requests use `PlayerId` and `Token`. Development tools may also send a JSON `DbAction`
envelope. `GetConfigurations` returns the raw text format required by the recovered parser;
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
- **Platform identities**: Facebook, Google Play, and Game Center identities have unique
  ownership, HMAC-protected credentials, provider login, collision-safe link/update, and
  unlink behavior. First-time `CreateGcAccount` commits the player and identity in one transaction,
  returns separate platform/session credentials, and supplies the recovered `15400` existing-account
  profile contract. Remaining response-contract work is tracked in `BACKEND_FEATURES.md`.
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
  participants, and the database settlement claim is idempotent. Players move from
  `InGame` back to `Online`. Disconnects allow a configurable reconnect grace period,
  then resolve as a forfeit or no-reward cancellation; interrupted matches are recovered
  on server restart. Photon-era `GameEnded` reports interpret the recovered `EndReason`
  enum and require matching durable reports from both assigned participants before rewards.

- **Leaderboards / leagues**: `GetPlayersByExperience` (global player board),
  `GetPlayerLeaguesDivision` (league + 1-based global rank), squad board via
  `GetSquadsByExperience` / `LeagueLeaderboardShown`. MongoDB-authoritative (indexed on
  `experience`), Redis sorted-set cache warmed opportunistically.
- **Social / messaging**: `SearchPlayers` (name prefix), `GetAllPlayers`, exact Facebook-friend and
  authoritative squad-mate resolution through `GetFriendsInfo`, challenge and normal
  `MessageSent`, `GetAllMessages`, `ReadMessage`, `IgnoreMessage`, and `AcceptChallenge`
  (recipient-owned persistent inbox). Challenges expire logically and through MongoDB TTL;
  identical retries are deduplicated and player-generated traffic has a rolling sender limit.
- **Moderation reports**: authenticated player/cheater reports are validated, rate-limited,
  deduplicated for safe retries, and stored with review status and evidence metadata.
- **Public-text moderation**: account/rename names, Squad names/descriptions, and direct messages
  share Unicode-normalized multilingual matching with punctuation/leetspeak resistance. Add
  deployment-specific comma-separated terms with `PROFANITY_EXTRA_TERMS`; report evidence is
  intentionally preserved verbatim for review.
- **Energy economy**: server-owned dog-tag seconds, passive regeneration, atomic
  `PayOneDogTag`, and gold-validated `RefillDogtags` using the recovered 900-second/5-tag
  balancing and refill-price formula.
- **Versioned client-data material database**: MongoDB collections `gameCatalogEntries` and
  `gameCatalogReleases` persist the recovered 4.9.5 weapon, soldier/unit, rank, power, player
  visual, War Card, and card-pack data as 441 queryable records. Every playable weapon record joins its shop row to the full
  upgrade table; every playable unit joins roster/deployment/purchase data to normal, special, and
  elite level rows; every visual joins its price/effect row to a serialized client asset. Nine
  unresolved Pulse Rifles, three helper units, 18 unresolved unit rows, and the assetless
  `HEAD_MASK_ROCKET` visual and 25 card definitions without serialized Card components are
  retained with explicit non-playable states instead of being
  discarded or silently enabled. Per-entry SHA-256 hashes and a deterministic release hash make
  balancing changes auditable. Startup idempotently writes all immutable revision entries before switching the
  current 4.9.5 release pointer, so readers cannot observe a partial synchronization. Run
  `npm run sync:catalog` to publish explicitly; normal server startup performs the same sync.
- **Authoritative Army Power**: `scripts/Extract-ArmyPowerCatalog.mjs` reproduces 5,865 normal
  weapon DPS rows and all 58 player-rank `ARMYPOWER` rows from MainScene. The server independently
  rounds equipped-unit float power, equipped-weapon float DPS, and the current zero-based rank row
  exactly where `LevelManager` does, then atomically stores their sum in both indexed and public
  player state. `UpdateArmyPower` ignores the client's claimed value and recomputes against one
  consistent progression revision; concurrent inventory changes force a reload. Unsupported
  rental and black-market acquisition remains closed, while all 11 category coefficient rows are
  retained as reference data for that future flow. Run `npm run verify:army-power` to compare the
  generated catalog with the recovered scene.
- **Player visuals and decals**: `scripts/Extract-VisualCatalog.mjs` joins all four serialized
  customization categories to the 4.9.5 PlayerVisuals sheet, producing 146 playable and one
  unresolved row. `DecalManagerData` is server-owned and boot-safe; buffered `BuyDecal`,
  `EquipDecal`, `DecalWasShown`, and `VisualWasShown` validate source, price, category, VIP,
  ownership, expiry, and shop eligibility. Gold/WarBucks debit, permanent or timed ownership,
  four-slot equipment, notification state, rollback data, and `BufferId` replay protection are
  atomic. Event/Arena/loyalty/assignment/value-pack grants, parts, rentals, and unsupported
  discounts remain fail-closed. Run `npm run verify:visual-catalog` to compare the artifact with
  MainScene.
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
  the 4.9.5 starter loadout. Stock buffered `BuyWeapon`/`EquipWeapon` supports all 84
  `PURCHASABLE: shop` rows that also have real LevelManager entries. Their obscured Gold and
  WarBucks prices, level gates, category masks, and non-sequential indexes are recovered from
  MainScene; purchases grant immediate ownership because every enabled row has
  `DELIVERTIME=0`. Mutations include server price/discount validation, atomic debits,
  category-safe equipment, Unity rollback fields, and `BufferId` replay protection. Nine
  shop-priced Pulse Rifle rows with null LevelManager entries, unknown catalog rows, and
  offer-discounted purchases still fail closed.
  `../Tools/Extract-WeaponCatalog.ps1` reproduces the catalog by joining the serialized
  LevelManager setup array to the Google2u component on each weapon GameObject, resolving
  Unity DLL script IDs through the recovered assemblies, and XOR-decoding both currency
  fields. Run `npm run verify:weapon-catalog` to prove that the checked-in extraction artifact
  and the runtime catalog still match the recovered 4.9.5 scene exactly.
- **Weapon upgrade lifecycle**: buffered actions `73`-`75` use all 84 recovered per-level
  Google2u tables (5,781 normal-level transitions). BuyWeaponUpgrade validates the old index
  and source duration, debits the server-owned WarBucks price, and creates the single shared
  `weaponDelivery` receipt used by
  LevelManager. Normal activation enforces its server end time; instant activation derives
  Gold from the recovered float32 `0.6325`/`-0.175` formula and the persisted delivery receipt.
  A delayed buffer may pay its earlier valid price but can never pay below the receipt-time
  server price. Both completion
  paths increment `boughtIndex` once, clear delivery atomically, return Unity rollback fields
  on failure, and inherit `BufferId` replay protection. Run `npm run verify:weapon-upgrades`
  to compare the generated price/time catalog with MainScene.
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
  dictionary. The same extractor records 4,124 normal, 684 special, and 216 elite per-level rows
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
  `dailyRewardData` calendar contract, one UTC-day unlock, ordered atomic Gold grants, and
  replay-safe claim cursors. Reward amounts are conservative environment-tunable defaults
  because the original remote live-ops reward sheet is not present in the recovered APK.
- **Assignments**: `GetNewAssignments`, both skip actions, assignment/mega claims, and the
  stock `SendRequestBuffer` path use a persistent UTC cycle. Only objectives derived from
  confirmed PvP settlement advance; buffered claim retries are idempotent by `BufferId`.
- **Daily/co-op/heroic missions**: actions `67`-`69`, `215`, `216`, and mission-flavoured
  `GameEnded` use the exact `DailyMissionsData`, `SavedMission`, and compact `MissionUnit`
  fields. UTC issuance, start receipts, consumed failure receipts, mode/index/order checks,
  separate solo/co-op completion, response replay, the 30-point heroic gate, and recovered
  currency rewards are persisted atomically. The archived server's random selection and
  normal per-battle reward formula are explicitly reconstructed gaps; card-pack/elite-part
  delivery remains disabled until inventory IDs are authoritative.
- **Starter assignments (authoritative subset)**: actions `185`/`186` restore the exact
  `StarterAssignmentsData` object and the MainScene-defined thresholds, order, Gold, and
  WarBucks rewards. Ranked wins, medal balance, level, lifetime squad points, and the first
  replay-safe mission completion, and the exact equipped secondary-weapon level required by
  ID_7 and a server-granted Gold craft for ID_8 are checked against server state; buffered claims
  are ordered, atomic, reward-validated, and replay safe. Unit deployment and war-card completions
  remain disabled until those event sources exist.
- **Achievements (authoritative subset)**: actions `218`-`220` use the recovered
  `AchievementsData`/RequestBuffer contract. Solo missions, ranked wins, assignment
  completion, squad points, and daily-reward claims advance only from accepted server
  settlements; tier rewards come from the serialized MainScene table and are granted
  atomically and replay-safely.
- **Squad social state**: action `193` persists the monotonic Photon Chat unread cursor through
  the stock request buffer and restores it as `PlayerAnalyticsData`; squad-event notices are
  membership-validated, founder-targeted, durable, and duplicate-suppressed.
- **War Arena (persistent core)**: login supplies the recovered Dynamo-style
  `WarArenaConfig`, while `EnterArena`, action-64/65 starts, Arena `GameEnded`, heart/life
  actions, scraps claims, rollover, and `GetArenaLeaderboards` use the exact `WarArenaData`
  contract. Runs and prices are server-owned, battle IDs are receipt-bound, and result/reward
  retries are idempotent. The retired remote price/lootbox tables are absent from both APKs,
  so entry/heart/scraps values are environment-tunable and final lootboxes currently use a
  documented scraps fallback rather than fabricated inventory objects.

Unimplemented state-changing `DbAction` values return error code `90`; only an explicit
allowlist of analytics/impression actions is safely ignored.

### Next

- **Squad extensions** — normal/Buddy pool deposits and withdrawals are implemented.
  Server-selected Buddy unit-type RNG and squad events/wars remain. Type-28 card-pool request
  notifications validate same-roster membership and use daily actor/target idempotency. Chat unread
  state is persistent, but actual channel delivery still requires Photon Chat repointing or a
  compatible replacement transport.
- **Item economy expansion** — unit Elite upgrades, normal shop visuals, normal card-pack
  purchase, and complete normal-loadout ArmyPower are implemented. Add authoritative card reward
  and consumption events, server-selected card/Buddy RNG, black-market features, rentals,
  VIP purchasing, and non-shop visual reward delivery. Normal unit purchase is authoritative for 23
  non-tutorial roster units, and the tutorial unit is persisted through its first equip event;
  three helper rows and 18 ArmyUpgrades rows without LevelManager objects remain closed. All 84 resolvable
  shop weapons support exact Gold or WarBucks purchase/equip plus server-owned upgrade
  delivery/activation; the nine null-reference Pulse Rifle rows, unknown items, and
  discount-bearing requests remain rejected instead of receiving guessed prices or unusable
  inventory records.
- **Arena fidelity / leagues** — recover production arena prices, rules, opponent weighting,
  lootbox/crown inventory payloads, and authoritative combat evidence; implement league
  promotion/relegation on `FinishPlayerLeague`. Arena debug mutations remain rejected.
- **Mission fidelity** — recover the original mission-selection weighting and normal battle
  reward formula, add combat-result validation, restore the missing recovered-client
  `MissionsSettings`/`UnitsInMissionsConfig` references, and deliver heroic inventory rewards.
  Remaining achievement groups stay unclaimable until their gameplay events are authoritative.
- **Reward tuning** — `matchService.REWARDS` is placeholder; wire to the client's
  MatchMakingConstants / reward config once extracted.
- **Client integration** — form request routing is implemented, but exact response keys for
  every action and the Photon→WebSocket client repoint remain `⚠ RE-NEEDED`.
