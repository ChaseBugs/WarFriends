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

## Durable effects

A confirmed ranked result can update:

- player experience and level-experience progress;
- medal balance and squad points;
- supported assignment and starter-assignment counters;
- supported achievement groups;
- online/in-game presence state.

Only facts confirmed by settlement enter progression systems. Raw client battle statistics are not
sufficient authority for rewards.

## Current limitations

The WebSocket layer is a controlled relay, not an authoritative combat simulation. It does not
independently reproduce shooting, cover, damage, unit AI, ability cooldowns, or projectile events.
A colluding pair could still submit matching false results. Production fidelity therefore requires
at least authoritative event validation and ideally a server simulation or trusted Photon room
plugin.

The unmodified recovered APK also expects Photon APIs, so it requires a client adapter or a
Photon-compatible endpoint to use the replacement WebSocket protocol.

## Key implementation files

- `Server/src/services/matchmakingService.ts`
- `Server/src/services/matchService.ts`
- `Server/src/gameRooms/roomManager.ts`
- `Server/src/gameHub.ts`
- `Server/src/handlers/match.ts`
