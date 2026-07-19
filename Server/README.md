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
- **Squads (core membership)**: create / unique-name check / public or requested join /
  invite / accept / decline / promote / demote / kick / leadership transfer / guarded
  leave, plus details and full member snapshots. Client ranks exactly mirror
  `Member`, `Veteran`, `Leader`, and `Coleader`.
- **PvP (WebSocket `/hub`)**: identify → `FindMatch` (matchmaking pairs by army-power within
  a widening league window) → `MatchFound` → `JoinMatch` → `MatchStart` → in-match
  `MatchEvent` relay to the opponent → `MatchResult`. Room joins/events are restricted to
  recorded match participants, WebSocket settlement requires matching reports from both
  participants, and the database settlement claim is idempotent. Players move from
  `InGame` back to `Online`. `GameEnded` (REST) only accepts a match participant's report.

- **Leaderboards / leagues**: `GetPlayersByExperience` (global player board),
  `GetPlayerLeaguesDivision` (league + 1-based global rank), squad board via
  `GetSquadsByExperience` / `LeagueLeaderboardShown`. MongoDB-authoritative (indexed on
  `experience`), Redis sorted-set cache warmed opportunistically.
- **Social / messaging**: `SearchPlayers` (name prefix), `GetAllPlayers`, `MessageSent` /
  `GetAllMessages` / `ReadMessage` (per-recipient inbox).

Unimplemented state-changing `DbAction` values return error code `90`; only an explicit
allowlist of analytics/impression actions is safely ignored.

### Next

- **Squad extensions** — card pool, squad events/wars, and squad chat are not implemented.
- **Economy** — `Buy*`/`Activate*`/`Equip*`, packs, VIP. **Blocked**: these mutate the
  client-serialized `inventoryData` / `levelManagerData` blobs, whose schema is still
  `⚠ RE-NEEDED`; currently rejected as unimplemented. Currency-only ops can land sooner.
- **Arena** — `EnterArena` / lives / `GetArenaLeaderboards`; league promotion/relegation on
  `FinishPlayerLeague`. Mutating actions without a real implementation are rejected.
- **Assignments / daily / achievements**, **hit list**.
- **Reward tuning** — `matchService.REWARDS` is placeholder; wire to the client's
  MatchMakingConstants / reward config once extracted.
- **Client integration** — form request routing is implemented, but exact response keys for
  every action and the Photon→WebSocket client repoint remain `⚠ RE-NEEDED`.
