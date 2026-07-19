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
```

Requires MongoDB (`:27017`) and, optionally, Redis (`:6379`). Set `REDIS_ENABLED=false` to
run Mongo-only. Health check: `GET /health`.

## How the client talks to it

The client (`BeanstalkServerManager`) sends every operation to one endpoint as a JSON
envelope carrying a `DbAction` integer (the `DatabaseAction` enum). The realtime match layer
connects to `ws://<host>/hub`.

```bash
# Create a custom account (DbAction 118)
curl -X POST localhost:8080/pc -H 'Content-Type: application/json' \
  -d '{"DbAction":118,"AccountName":"Maverick","DeviceToken":"dev-A"}'
# → { id, token, Player }  — replay id+token on every authed action
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
  handlers/          DbAction → handler dispatch (auth, player, squad) + fallback ack
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
- **Squads**: full lifecycle — create / unique-name check / join / promote / demote / kick /
  leave, with server-side rank guards.
- **PvP (WebSocket `/hub`)**: identify → `FindMatch` (matchmaking pairs by army-power within
  a widening league window) → `MatchFound` → `JoinMatch` → `MatchStart` → in-match
  `MatchEvent` relay to the opponent → `MatchResult`. Results settle **authoritatively and
  idempotently** (winner/loser xp + medals + squad points; players flipped to InBattle then
  back to Online). `GameEnded` (REST) settles the same way.

- **Leaderboards / leagues**: `GetPlayersByExperience` (global player board),
  `GetPlayerLeaguesDivision` (league + 1-based global rank), squad board via
  `GetSquadsByExperience` / `LeagueLeaderboardShown`. MongoDB-authoritative (indexed on
  `experience`), Redis sorted-set cache warmed opportunistically.
- **Social / messaging**: `SearchPlayers` (name prefix), `GetAllPlayers`, `MessageSent` /
  `GetAllMessages` / `ReadMessage` (per-recipient inbox).

Every other `DbAction` returns a benign ack so the client does not hard-fail.

### Next

- **Economy** — `Buy*`/`Activate*`/`Equip*`, packs, VIP. **Blocked**: these mutate the
  client-serialized `inventoryData` / `levelManagerData` blobs, whose schema is still
  `⚠ RE-NEEDED`; currently acked. Currency-only ops (medals) can land sooner.
- **Arena** — `EnterArena` / lives / `GetArenaLeaderboards`; league promotion/relegation on
  `FinishPlayerLeague` (currently acked).
- **Assignments / daily / achievements**, **hit list**.
- **Reward tuning** — `matchService.REWARDS` is placeholder; wire to the client's
  MatchMakingConstants / reward config once extracted.
- **Client transport** — the envelope shape and Photon→ws repoint are still `⚠ RE-NEEDED`
  (BACKEND.md §5); `dtos/base.ts` and `routes/index.ts` are the single seams to update once
  the real wire format is confirmed from the client.
