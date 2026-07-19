# PvP Matchmaking and Battle Settlement

## Matchmaking

An authenticated player enters a bounded queue with player ID, league, and Army Power. The search
window widens over time to avoid indefinite waiting while still preferring similar opponents.
Duplicate queue entries are rejected or replaced rather than creating multiple simultaneous
matches for one player.

When two players are paired, the server creates a durable match record and a short-lived room.
Both players must join within the configured timeout. A player not recorded in the match cannot
join the room or relay battle traffic.

## Room lifecycle

```text
FindMatch -> MatchFound -> JoinMatch -> MatchStart
          -> participant-only MatchEvent relay
          -> two result reports -> durable settlement
```

Disconnecting does not immediately destroy the room. A reconnect grace period lets the legitimate
participant return. Expiry becomes either a forfeit or a no-reward cancellation depending on which
players joined and whether battle play was established.

## Result agreement

The server requires compatible reports from both recorded participants before normal PvP rewards
are granted. The recovered `EndReason` is interpreted from each player's perspective so one report
must describe the same winner/loser outcome as the other.

Settlement is idempotent. Once a match ID is consumed, a retry returns the stored outcome rather
than granting experience, medals, squad progress, or assignment progress again.

Each `GameEnded` report also carries the authenticated player's own `UsedCards` JSON array. The
server accepts at most six entries exposed by the recovered three normal, VIP, extra, and Buddy
selection slots. Repeated normal IDs are valid when the player owns enough copies and are charged
once per occurrence. Every normal ID must be playable; every Buddy ID must name the player's exact
positive Buddy snapshot. A reporter cannot submit the opponent's usage list.

## Durable effects

A confirmed ranked result can update:

- player experience and level-experience progress;
- medal balance and squad points;
- normal-card counts and unique Buddy-card ownership;
- the server-owned lifetime War Card play counter used by starter assignment `ID_2`;
- supported assignment and starter-assignment counters;
- supported achievement groups;
- online/in-game presence state.

Only facts confirmed by settlement enter progression systems. Raw client battle statistics are not
sufficient authority for rewards.

The two player documents and terminal match row commit in one MongoDB transaction. Card
consumption, lifetime card-play proof, XP, medals, squad points, presence, and level experience
therefore cannot be partially persisted across a process failure. Assignment, achievement, and
squad aggregate projections run after the core transaction and cannot cause duplicate core
rewards.

## Stock end-screen reward contract

The recovered `DMGJCGJDDID` response parser constructs `IIGFODGJBFA` from `GameReward` before it
processes `Skill`, medals, and placement fields. If `Skill` is present without `GameReward`, the
parser dereferences a null `ServerResultsCache.lastGameReward` object. Every normal PvP response
therefore includes the minimum exact object:

```json
{
  "Xp": {
    "BattleRewards": 30,
    "ExtraRewards": 0,
    "Winstreak": 0,
    "Time": 0,
    "offerMult": 1
  },
  "IsVip": false
}
```

Confirmed winners receive 30 battle XP and confirmed losers receive 10, matching the atomic
settlement constants. A finished retry returns the same deterministic display amount. Pending,
conflicting, or invalid reports still receive a structurally valid object with zero battle XP, so
the stock end screen remains safe without displaying an uncommitted reward.

`LevelExperience` is returned on every outcome because the parser reads it unconditionally.
`Level` is different: its presence is a transition marker, and the client sets
`LevelManager.isLevelUp = true` whenever the key exists. The server therefore emits `Level` only
when the authoritative level index actually increases; returning the unchanged level would create
a false level-up after every PvP battle.

## Current limitations

The WebSocket layer is a controlled relay, not an authoritative combat simulation. It does not
independently reproduce shooting, cover, damage, unit AI, ability cooldowns, or projectile events.
A colluding pair could still submit matching false results. Production fidelity therefore requires
at least authoritative event validation and ideally a server simulation or trusted Photon room
plugin.

The stock request reports only cards the sender admits using. The opponent observes Photon card
RPCs but does not echo those IDs to the meta server, so a modified APK can omit a play. Ownership,
shape, and exactly-once consumption are authoritative for reported IDs; proof that no usage was
omitted requires a Photon plugin or replacement relay that validates live card-play events.

The unmodified recovered APK also expects Photon APIs, so it requires a client adapter or a
Photon-compatible endpoint to use the replacement WebSocket protocol.

## Key implementation files

- `Server/src/services/matchmakingService.ts`
- `Server/src/services/matchService.ts`
- `Server/src/gameRooms/roomManager.ts`
- `Server/src/gameHub.ts`
- `Server/src/handlers/match.ts`
