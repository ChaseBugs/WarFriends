# WarFriends GameServer

Private backend for the recovered WarFriends client — a **REST meta server** (accounts,
players, squads) plus a **WebSocket match relay** that stands in for Photon PvP. Design and
protocol notes: [`../BACKEND.md`](../BACKEND.md).

Stack: Node.js + Express + TypeScript, MongoDB (native driver), Redis (optional), `ws`.
Structure mirrors the sibling recovery backend (`Heyworks/Backend`).

## Run

```bash
cp .env.example .env      # adjust MONGO_URL / REDIS_URL if needed
npm install
npm run dev               # ts-node-dev, watch mode
# or: npm run build && npm start
# optional explicit catalog publication: npm run sync:catalog
```

Requires MongoDB (`:27017`) and, optionally, Redis (`:6379`). Set `REDIS_ENABLED=false` to
run Mongo-only. Health check: `GET /health`.

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
  wrappers parsed by the recovered 1.6.0 client. Passwords/provider credentials remain
  separate from the rotated internal gameplay session token.
- **Platform identities**: Facebook, Google Play, and Game Center identities have unique
  ownership, HMAC-protected credentials, provider login, collision-safe link/update, and
  unlink behavior. Remaining response-contract work is tracked in `BACKEND_FEATURES.md`.
- **Squads (core membership)**: create / unique-name check / public or requested join /
  invite / accept / decline / promote / demote / kick / leadership transfer / guarded
  leave, plus details and full member snapshots. Client ranks exactly mirror
  `Member`, `Veteran`, `Leader`, and `Coleader`.
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
- **Social / messaging**: `SearchPlayers` (name prefix), `GetAllPlayers`, challenge and normal
  `MessageSent`, `GetAllMessages`, `ReadMessage`, `IgnoreMessage`, and `AcceptChallenge`
  (recipient-owned persistent inbox). Challenges expire logically and through MongoDB TTL;
  identical retries are deduplicated and player-generated traffic has a rolling sender limit.
- **Moderation reports**: authenticated player/cheater reports are validated, rate-limited,
  deduplicated for safe retries, and stored with review status and evidence metadata.
- **Energy economy**: server-owned dog-tag seconds, passive regeneration, atomic
  `PayOneDogTag`, and gold-validated `RefillDogtags` using the recovered 900-second/5-tag
  balancing and refill-price formula.
- **Versioned client-data material database**: MongoDB collections `gameCatalogEntries` and
  `gameCatalogReleases` persist the recovered 4.9.5 weapon, soldier/unit, and upgrade data as
  138 queryable records. Every playable weapon record joins its shop row to the full upgrade
  table; every playable unit joins roster/deployment/purchase data to normal, special, and
  elite level rows. Nine unresolved Pulse Rifles, three helper units, and 18 unresolved unit
  rows are retained with explicit non-playable states instead of being discarded or silently
  enabled. Per-entry SHA-256 hashes and a deterministic release hash make balancing changes
  auditable. Startup idempotently writes all immutable revision entries before switching the
  current 4.9.5 release pointer, so readers cannot observe a partial synchronization. Run
  `npm run sync:catalog` to publish explicitly; normal server startup performs the same sync.
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
  and sums only equipped permanent units. Helper/unresolved rows, offer/subscription discounts,
  and full ArmyPower writes remain fail-closed until weapon and rank power are also recovered. Run
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
  ID_7 are checked against server state; buffered claims are ordered, atomic,
  reward-validated, and replay safe. Unit deployment, war-card, and card-crafting completions
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

- **Squad extensions** — card pool and squad events/wars are not implemented. Chat unread
  state is persistent, but actual channel delivery still requires Photon Chat repointing or
  a compatible replacement transport.
- **Item economy expansion** — unit Elite upgrades and the unit component of ArmyPower are now
  source-authoritative. Recover equipped-weapon and rank power to close the full ArmyPower write,
  then add decals, cards, packs, and VIP. Normal purchase is authoritative for 23
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
