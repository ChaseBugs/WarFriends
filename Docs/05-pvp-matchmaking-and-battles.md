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

The first `GameEnded` HTTP request waits for up to five seconds (configurable through
`MATCH_RESULT_CONSENSUS_WAIT_MS`) for the other participant's already-in-flight report. This wait
does not weaken consensus or create a result: it only lets the first stock client receive the same
immutable receipt that the second agreeing request commits. Previously that client immediately
received a pending, zero-valued result and had no second callback for its result screen. If the
other report never arrives, the bounded wait still returns pending and grants nothing. Rental
trials also advance only after a confirmed/finished receipt, never from a pending report.

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
  "Warbucks": {
    "BattleRewards": 800,
    "ExtraRewards": 0,
    "Winstreak": 400,
    "League": 200,
    "offerMult": 1
  },
  "Xp": {
    "BattleRewards": 30,
    "ExtraRewards": 0,
    "Winstreak": 0,
    "Time": 0,
    "offerMult": 1
  },
  "GameGold": {
    "BattleRewards": 5,
    "League": 0,
    "offerMult": 1
  },
  "IsVip": false
}
```

Confirmed winners receive 30 battle XP and confirmed losers receive 10, matching the atomic
settlement constants. `GameGold.BattleRewards` contains only Gold earned by crossing level
thresholds, so its normal value is zero. A finished retry returns the original XP and Gold receipt.
Pending, conflicting, or invalid reports still receive structurally valid zero values, so the stock
end screen remains safe without displaying an uncommitted reward.

Normal PvP also credits `Warbucks.BattleRewards` in the settlement transaction: the offline
defaults are 800 for a win and 400 for a loss. The exact production values were delivered by the
retired Fusebox `BattleWarbucksRewards` document and are absent from both recovered APKs, so these
numbers are explicitly reconstruction policy, not claimed production balancing. Operators may
replace them with `PVP_WIN_WARBUCKS` and `PVP_LOSE_WARBUCKS`. The request's
`WarbuckRewardWin`/`WarbuckRewardLoss` echoes are ignored because a modified client could otherwise
mint arbitrary currency. Active VIP settlement persists 1.5 times the base using the C# parser's
positive float-to-int truncation, while the response sends the base plus `IsVip=true` so the
client applies that decoded multiplier exactly once.

## League win rewards

Confirmed ranked winners now receive the exact `REWARDWARBUCKS` and `REWARDSQUADPOINTS` values
advertised by the recovered league UI. The three beginner rows grant 200/400/600 WarBucks and one
squad point. The 16 normal tiers grant 800 through 5000 WarBucks and two through seven squad
points. The WarBucks value is returned in `GameReward.Warbucks.League`; a current squad member's
point delta is returned in the parser's lower-case outer `squadPoints` field and is also committed
to the player, squad, achievement, and assignment projections.

The source table does not establish a league payout on a defeat, so the offline backend uses the
conservative winner-only rule and returns zero for both components after a loss. Active VIP applies
the decoded 1.5x multiplier to `Warbucks.League` independently, matching the client's per-component
truncation. The result request cannot choose the league, payout, or squad-point amount: all three
come from the authenticated player's settlement-time server state. The table's `WINFACTOR` and
`LOSEFACTOR` rows are retained for future medal-formula recovery but are not guessed into the
current fixed global/league medal policy.

## Medal mirrors and replay snapshots

`DatabasePlayer` and the stock end parser distinguish global medals (`Skill`) from the current
weekly/division balance (`MedalsBalance`). The retired base medal document is not in either APK, so
the replacement server retains its documented +25 win / -12 loss policy with a zero floor. Both
mirrors now change atomically from the same confirmed result; previously only `MedalsBalance`
changed, leaving global matchmaking/profile medals permanently frozen.

The exact post-match `Skill`, `MedalsBalance`, placement counter, beginner-league value, and any
normal-league entry transition are stored in the terminal receipt. A delayed `GameEnded` retry
therefore returns the values that belonged to that match rather than reading state changed by later
battles. The recovered per-tier `WINFACTOR`/`LOSEFACTOR` values remain recorded but intentionally
unused until the missing original base formula and rounding order can be proven.

## Timed win-streak rewards

Ranked wins now advance a private server-owned streak and return the recovered outer `WinCount`
and `TimeStamp` fields consumed by `DMGJCGJDDID`. `GetPlayerData` also restores the same values
through the serialized nested type key `WinStreak`, so reconnecting no longer erases the lobby
counter. The decoded `WinstreakInterval` is 200 seconds: the next confirmed win continues only
while `previous TimeStamp + 200 > settlement time`; equality is expired. A loss clears the state.

The verified MainScene `WinstreakReward1..9` WarBucks values are 400, 700, 1000, 1400, 1800,
2200, 2600, 3000, and 3600. They are stored in `GameReward.Warbucks.Winstreak` separately from
the base win/loss grant because the client applies and truncates the VIP 1.5x multiplier separately
for each component. The nominal tenth scene row decodes to `1.5`, identical to the VIP multiplier
and not a credible currency value. Until an archived live reward document is recovered, the server
explicitly caps both streak count and reward at the ninth verified tier rather than inventing a
tenth payout.

`LevelExperience` is returned on every outcome because the parser reads it unconditionally.
`Level` is different: its presence is a transition marker, and the client sets
`LevelManager.isLevelUp = true` whenever the key exists. The server therefore emits `Level` only
when the authoritative level index actually increases; returning the unchanged level would create
a false level-up after every PvP battle.

The server uses all 58 `LevelManager.levels` rows extracted from the 4.9.5 MainScene. Each row
contains the exact XP threshold, level-up Gold reward, and rank Army Power. Settlement adds the
player's 30/10 XP to current `LevelExperience`; every crossed row subtracts its threshold, advances
the zero-based `DatabasePlayer.Level`, and credits its `REWARDGOLD`. The new level's rank power is
then included in a full authoritative Army Power recomputation.

Level progress, Gold, public level, Army Power, card consumption, periodic VIP visual parts,
duplicate WarBucks, match rewards, and the terminal match state share the same MongoDB transaction.
The match stores an immutable per-player receipt containing base/streak/league WarBucks, streak
state, the exact squad-point delta, both medal mirrors, placement transition, XP, Gold, old/new level, remaining
level XP, the post-match VIP lootbox countdown, and the exact optional `GameReward.NewVisuals`
dictionary string. A finished `GameEnded` retry can therefore reproduce the original
`GameReward.GameGold`, conditional `Level`, `MatchesToNextLootboxes`, and suitcase pair without
granting anything twice. At source level 58 there is no next row, so XP may continue accumulating
but no repeated max-level Gold is granted.

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
