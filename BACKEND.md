# WarFriends Backend Rebuild Specification

> How to build a private server so the recovered client can play **PvP** and use the
> **Squad** system again. Every claim here is grounded in the decompiled 1.6.0 client
> (`Client-Decompiled-Mono-1.6.0/`). Items that still need reverse-engineering are marked
> **⚠ RE-NEEDED** — do not invent them, extract them from the client/assemblies.

---

## 1. Architecture — the client talks to TWO servers

The client is not a single-backend game. It uses two independent services, and both must
exist for PvP to work:

| Tier | Client class | Protocol | Responsibility |
|------|-------------|----------|----------------|
| **Meta server** | `BeanstalkServerManager` | HTTPS REST (JSON over `HTTPRequest`/BestHTTP) | Accounts, player data, **Squads**, matchmaking request, leaderboards, economy, arena, rewards. Authoritative persistent state. |
| **Realtime server** | `PhotonConnectionManager`, `GameControllerPVP` | Photon Realtime (UDP) | The live PvP match session between two players (room join, turn/action sync, result). |

Supporting client classes: `SessionManager` (session lifecycle), `ServerResultsCache`
(client-side cache of server responses), `GameLoginManager` (holds `currentPlayer`).

```
                 ┌─────────────────────────┐
   REST (JSON)   │  Meta Server (Beanstalk │  ← YOU BUILD THIS
  ┌─────────────▶│  replacement) + Database│
  │              └─────────────────────────┘
┌─┴────────┐            ▲ match record / rewards
│  Client  │            │
└─┬────────┘     ┌───────┴──────────────────┐
  │  Photon UDP  │  Photon Realtime server  │  ← self-host Photon Server SDK
  └─────────────▶│  (rooms, event relay)    │     OR use Photon Cloud app id
                 └──────────────────────────┘
```

**Minimum to get PvP playable:** stand up the Meta server + a Photon endpoint. The Meta
server pairs two players and hands them a room; Photon relays the in-match traffic.

---

## 2. Tier 1 — Meta server (Beanstalk replacement)

### 2.1 Transport envelope (confirmed from `BeanstalkServerManager`)

- Single HTTPS service. Client builds a request path containing `/PC/` and an app
  identifier GUID `8b004c04-6921-4613-9815-e63b42db4a7c`. **⚠ RE-NEEDED**: confirm the
  exact base URL + route by dumping the string builder in `BeanstalkServerManager` (the URL
  is assembled from config, likely `GetConfigurations` / a region host table).
- Every request carries the operation id in field **`DbAction`** (integer = `DatabaseAction`
  enum value, see §2.3) plus a payload of action-specific fields.
- Common request fields seen in the client: `id`, `password`/`token`, `AccountType`,
  `ClientVersion`/`clientVersion`, `DeviceToken`, `AndroidID`, `AndroidAdvertisingID`,
  `BundleId`, `FacebookId`/`FacebookPassword`, `GooglePlayId`/`GooglePlayPassword`,
  `GameCenterId`/`GameCenterPassword`. HTTP header `App-Version` is set.
- Response is **JSON** (parsed with `Newtonsoft.Json`). Empty response is treated as an
  error (`"Beanstalk: Error - empty response from server"`). The server returns a
  `DbAction` echo + result payload; the client routes it back through `ServerResultsCache`.
- **⚠ RE-NEEDED**: exact response envelope keys and whether the body is signed/encrypted.
  Extract by logging one real request or reading the response-parse switch in
  `BeanstalkServerManager`.

### 2.2 Authentication model

Account types (`AccountType` enum) and the login actions from the enum:

- Anonymous/custom device account: `CreateAccount` (118), `CreateFullAccount` (122),
  `LoginToCustomAccount` (30), `CreateGcAccount` (146), `ChangeNameAndPassword` (121).
- Social linking: `AddFacebook`/`SwitchToFacebook`/`RemoveFacebook`,
  `AddGooglePlay`/`RemoveGooglePlay`, `AddGameCenter`, `ExistFBAccount`, `ExistGCAccount`.
- Auth is **id + password/token** based (fields `id`, `password`, `token`). Reimplement as:
  device-generated credential on first `CreateAccount`, returned id/token reused on
  subsequent `LoginToCustomAccount`. Social ids map onto the same player row.

### 2.3 Operation catalog — `DatabaseAction` (the full REST API)

Source of truth: `DatabaseAction.cs`. This enum **is** the server's endpoint list — every
value is one operation the server must handle. Grouped by subsystem:

**Session / account**
`CreateAccount 118`, `CreateFullAccount 122`, `LoginToCustomAccount 30`,
`CreateGcAccount 146`, `ChangeNameAndPassword 121`, `ChangePlayerName 139`,
`SetPlayerStatus 29`, `GetPlayerData 34`, `GetPlayerInfo 170`, `UpdateDeviceToken 13`,
`UpdateSettings 165`, `ChangeLanguage 150`, `ChangePlayerCountry 196`,
`AddFacebook 52`/`SwitchToFacebook 53`/`RemoveFacebook 164`,
`AddGooglePlay 187`/`RemoveGooglePlay 188`, `AddGameCenter 154`, `GetConfigurations 157`.

**Squad system** (see §2.5 — this is a core ask)
`CreateSquad 37`, `JoinSquad 38`, `JoinSquadRequest 132`, `AcceptSquadJoinRequest 133`,
`DeclineSquadJoinRequest 181`, `LeaveSquad 49`, `RemoveUserFromSquad 42`,
`KickPlayer 172`, `PromotePlayer 55`, `PromotePlayerToFounder 57`, `DemotePlayer 58`,
`InvitePlayerToSquad 59`, `CheckUniqueSquadName 41`, `UpdateSquad 131`,
`UpdateSquadEmblem 63`, `GetSquadDetails 45`, `GetFullSquadInfo 151`,
`GetAllSquadMembers 44`, `GetSquads 56`, `GetSquadsByExperience 101`,
`FindSuggestedSquads 81`, `JoinSquadEvent 113`, `InformSquadLeaderAboutEvent 160`,
`SaveLastSeenSquadChatTimeStamp 193`, `GetSquadWarsDivision 124`.

**Matchmaking / PvP match lifecycle** (see §3)
`GameStartedMaster 64`, `GameStartedClient 65`, `GameEnded 62`, `PhotonIsFull 143`,
`UpdateRegionPings 140`, `GameStartedCoopMaster 68`, `GameStartedCoopClient 69`,
`GameStartedCampaign 67`, `GameStartedTutorial 119`, `InstantBattle 199`,
`AcceptChallenge 3`, `ProvokePlayer 88`, `ReportCheater 197`, `SendPlayerReport 148`.

**Social / messaging / hit list**
`MessageSent 2`, `GetAllMessages 5`, `ReadMessage 184`, `IgnoreMessage 12`,
`GetFriendsInfo 26`, `GetAllPlayers 4`, `SearchPlayers 89`, `AddToHitList 84`,
`GetPlayersFromHitList 85`, `ExpandHitList 86`, `HitListPlayerLoggedIn 87`,
`SystemMessage 90`.

**Economy / progression** (server must be authoritative to prevent cheating)
`BuyWeapon 76`, `BuyUnit 80`, `BuyWeaponUpgrade 73`, `BuyUnitUpgrade 77`,
`ActivateWeapon(Upgrade) 75/128`, `ActivateUnit(Upgrade) 79/127`, `EquipWeapon 116`,
`EquipDecal 110`, `BuyDecal 109`, `BuyCardPack 97`, `BuyPack 130`, `BuyVip 114`,
`BuyLootboxes 190`, `BuyInApp 142`, `BuySubscription 9999999`, `RefundPack 1013`,
`RestorePacks 189`, `ClaimReward 91`, `RefillDogtags 70`, `UpdateArmyPower 192`,
`UpdateEquippedUnits 1003`, `DepositCards 174`/`WithdrawCard 175`,
`CraftCard 176`/`ClaimCraftedCard 177`/`CraftAndClaimCard 2000`.

**Leaderboards / leagues / arena**
`GetPlayerLeaguesDivision 106`, `GetPlayersByExperience 107`, `FinishPlayerLeague 198`,
`GetMissionLeaderboards 111`, `GetArenaLeaderboards 206`, `EnterArena 200`,
`TakeArenaLife 202`, `BuyArenaHearth 201`, `WarArenaEnded 211`, `RemoveFromLeague 1006`.

**Assignments / missions / daily / achievements**
`GetNewAssignments 149`, `ClaimAssignment 171`, `ClaimAssignmentMegaReward 173`,
`SkipAssignment 112`, `CompleteStarterAssignments 185`, `ClaimStarterAssignment 186`,
`GetNewDailyMissions 216`, `SaveDailyMissions 215`, `CheckDailyReward 1001`,
`ClaimDailyReward 1002`, `ClaimAchievement 218`, `ClaimEventAssignment 222`,
`ClaimEventMilestone 223`.

**Telemetry / debug** (debug ops should be disabled in production server)
`UpdateAnalytics 179`, `SendCrashReport 141`, `SendLog 166`, `Test 167`,
and the `Debug*` values (94, 134, 147, 159, 162, 204, 205, 210, 1010–1015).

> The full numeric list is in `Client-Decompiled-Mono-1.6.0/.../DatabaseAction.cs`. Server
> switches on `DbAction`; unknown/debug actions should return a benign error.

### 2.4 Core persisted model — `DatabasePlayer`

From `DatabasePlayer.cs`, the player row the server owns (authoritative):

```
id (string, PK)      accountName          accountType (enum)
password/token       experience (long)    level, skill, reputation
armyPower            medalsBalance        remainingMatches
league: leagueTier (Bronze3…), leagueId, leagueDivision, beginnersLeague
squad:  squadName, squadPoints, squadRank (enum)
vipExpiration (int)  country, deviceToken, sendLogsValue
inventoryData (PlayerInventory.InventoryData)     ← weapons/units/cards owned
levelManagerData (LevelManager.LevelManagerData)  ← progression
playerVisuals (Dictionary<int, SavedPlayerVisualSlot>)  ← camos/decals
depositedCardsDic (Dictionary<string,string>)     ← squad card pool deposits
status (PlayerStatus), lastAction (int)
statisticsData
```

JSON field names on the wire (from the model + `ServerResultsCache` keys): `Name`,
`Experience`, `Level`, `Skill`, `Reputation`, `ArmyPower`, `MedalsBalance`, `LeagueId`,
`SquadId`, `SquadPoints`, `SquadRank`, `InventoryData`, `LevelManagerData`,
`PlayerVisuals`, `DepositedCards`, `Vip`, `Country`, `AccountType`, `Status`,
`StatisticsData`, `Regions`, `BeginnersLeague`.

Store `InventoryData`/`LevelManagerData`/`StatisticsData` as opaque JSON blobs first
(client serializes them) — you don't need to model them field-by-field to get running.

`ServerResultsCache` names the read collections the server must be able to return:
`globalPlayerLeaderboard`, `localPlayerLeaderboard`, `leagueMembers`, `squad`,
`squadMembers`, `globalSquadLeaderboard`, `localSquadLeaderboard`, `missionLeaderboards`,
`arenaLeaderboard`, `players`, `squadsFromLeague`, `playerInfo`, `lastWeeksPlayerLeague`,
`facebookFriends`.

### 2.5 Squad system (detail)

Data model needed (a `Squad` table + `SquadMember` join):

```
Squad:   id/name (unique — CheckUniqueSquadName), emblem, description,
         experience, squadPoints, leagueId/division, createdBy(founderId),
         settings (open/invite-only, min level), eventState
Member:  playerId, squadId, rank (SquadRank: Member/Officer/Leader/Founder),
         joinedAt, contribution/points, lastSeenChatTimestamp
JoinRequest: playerId, squadId, status(pending/accepted/declined), createdAt
```

Operations to implement (map 1:1 to §2.3 Squad actions):

1. **Create** — `CheckUniqueSquadName 41` → `CreateSquad 37`. Founder becomes rank Founder.
2. **Discovery** — `GetSquads 56`, `GetSquadsByExperience 101`, `FindSuggestedSquads 81`,
   `GetSquadDetails 45`, `GetFullSquadInfo 151`, `GetAllSquadMembers 44`.
3. **Join** — open: `JoinSquad 38`; gated: `JoinSquadRequest 132` →
   `AcceptSquadJoinRequest 133` / `DeclineSquadJoinRequest 181`;
   invite: `InvitePlayerToSquad 59`.
4. **Membership admin** — `PromotePlayer 55`, `PromotePlayerToFounder 57`,
   `DemotePlayer 58`, `KickPlayer 172` / `RemoveUserFromSquad 42`, `LeaveSquad 49`.
   Enforce rank permissions server-side.
5. **Squad meta** — `UpdateSquad 131`, `UpdateSquadEmblem 63`,
   `SaveLastSeenSquadChatTimeStamp 193`.
6. **Squad events / wars** — `JoinSquadEvent 113`, `InformSquadLeaderAboutEvent 160`,
   `GetSquadWarsDivision 124`, leaderboard reads (`globalSquadLeaderboard`,
   `localSquadLeaderboard`, `squadsFromLeague`).
7. **Card pool** — `DepositCards 174`, `WithdrawCard 175`, `NotifyPlayerToDeposit 178`
   (uses `DatabasePlayer.depositedCardsDic`).

**Squad chat**: the client has `ChatSquadButtonOnline` and a chat timestamp. **⚠ RE-NEEDED**:
determine whether squad chat rides Photon (a per-squad Photon room / chat) or a REST poll.
Check `PhotonConnectionManager` + any `Chat`/`Photon Chat` usage before choosing.

---

## 3. Tier 2 — Realtime PvP (Photon)

WarFriends PvP pairs two real players in a Photon room; the match is a turn-based
card+shooter. The Meta server does matchmaking and result-recording; Photon carries the
live turn/action traffic.

### 3.1 Match flow (from `DatabaseAction` + `GameControllerPVP` naming)

1. Client asks the **Meta server** for an opponent / match (matchmaking uses league, skill,
   `armyPower`; tuning lives in Google2u sheets `MatchMakingConstants`,
   `MatchMakingDeviation`, and `MatchmakingMode`). **⚠ RE-NEEDED**: identify the exact
   matchmaking action + how the room name/opponent is returned (inspect the matchmaking
   request path in `BeanstalkServerManager`/`SessionManager`).
2. Both clients connect to Photon and join the same room. One becomes Photon **master**
   (`GameStartedMaster 64`), the other **client** (`GameStartedClient 65`); each reports its
   start to the Meta server.
3. In-match sync runs over Photon (`GameControllerPVP`, `PhotonLevelView`,
   `PhotonCachedRPC`) via RPCs / `RaiseEvent`. If a room is full/unavailable the client
   sends `PhotonIsFull 143`.
4. On completion the client sends `GameEnded 62` to the Meta server, which validates the
   result and grants rewards / league + squad points (server-authoritative).
5. `UpdateRegionPings 140` reports per-region latency so matchmaking can pick a Photon region.

### 3.2 What you must provide for Photon

- **Option A (fastest): Photon Cloud** — create a Photon Realtime app, put its **AppId** and
  version into the client's Photon config. **⚠ RE-NEEDED**: locate where the client reads the
  Photon AppId/region (a `PhotonServerSettings` asset or config string) and repoint it.
- **Option B: self-host** the Photon Server SDK on-prem and point the client's Photon host at
  it. Needed if you want zero external dependency.
- **⚠ RE-NEEDED — the in-match protocol**: the set of RPC method names / `RaiseEvent` event
  codes and room custom-property keys that `GameControllerPVP` and `PhotonLevelView` exchange.
  Extract these before you can validate/anti-cheat matches server-side. Photon relays them
  regardless, so P2P-trusted play works without decoding them, but result validation does not.
  Dump them from `GameControllerPVP.cs`, `PhotonLevelView.cs`, `PhotonCachedRPC.cs`
  (grep for `RPC`, `RaiseEvent`, `PunRPC`, `SetCustomProperties`).

---

## 4. Suggested implementation

### 4.1 Stack

- **Meta server**: any HTTP framework (Node/TypeScript, ASP.NET, or Go). One `POST` route
  that switches on `DbAction`. Return the client's expected JSON envelope.
- **DB**: Postgres (relational: players, squads, members, join_requests, messages,
  leaderboards, matches) — the original used a document store (Beanstalk + likely DynamoDB),
  but relational is fine and simpler for squads/leaderboards.
- **Realtime**: Photon Cloud (Option A) to start.
- **Cache/leaderboards**: Redis sorted sets for `*Leaderboard` reads.

### 4.2 Build order (get PvP + Squad playable)

1. **Handshake & config** — `GetConfigurations 157`, `CreateAccount 118`,
   `LoginToCustomAccount 30`, `GetPlayerData 34`. Client must boot to menu against your
   server first. Nail the request/response envelope here (§2.1).
2. **Player persistence** — store/serve `DatabasePlayer` (inventory/level blobs opaque).
3. **Squad system** — full §2.5 set. Independently testable without Photon.
4. **Matchmaking + match record** — opponent selection, `GameStartedMaster/Client`,
   `GameEnded`, reward grant, league/squad point updates.
5. **Photon wiring** — repoint AppId, verify two clients join a room and complete a match.
6. **Economy, arena, assignments, leaderboards, messaging** — remaining `DatabaseAction`s.

### 4.3 Verification

- Boot the recovered client (`Client/ExportedProject`, Unity 2020.3.49f1) pointed at your
  local server; confirm it reaches the menu (login round-trip succeeds).
- Create a squad from two accounts; confirm join/promote/kick propagate.
- Run two clients through matchmaking into one Photon room and complete a PvP match; confirm
  `GameEnded` rewards land and leaderboards update.

---

## 5. Open reverse-engineering tasks (before/while building)

All are extractable from the decompiled client — do not guess:

1. **Exact REST base URL + route + response envelope** (`BeanstalkServerManager` URL builder
   and response-parse switch).
2. **Request/response JSON schema per `DbAction`** — capture from the parse code or a live
   trace of the original (if any endpoint still answers).
3. **Whether payloads are signed/encrypted/obfuscated** and any anti-cheat token.
4. **Matchmaking action + room handoff** — how client gets its opponent and Photon room.
5. **Photon config location** (AppId/region/appVersion) in the client to repoint.
6. **In-match Photon RPC/event/room-property protocol** (`GameControllerPVP`,
   `PhotonLevelView`, `PhotonCachedRPC`).
7. **Squad chat transport** (Photon Chat vs REST).

> Reminder: the 1.6.0 assemblies are Beebyte-obfuscated — internal method bodies are
> scrambled, but **string literals, enum values, serialized field names, and public/JSON
> keys survive** and are the reliable source for the wire protocol.
