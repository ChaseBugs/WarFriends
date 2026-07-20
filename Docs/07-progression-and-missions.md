# Progression, Assignments, Missions, and Achievements

## Player levels and experience

The client stores a zero-based level index and separate progress within the current level. The
backend extracts all 58 exact MainScene rows containing `EXPERIENCE`, `REWARDGOLD`, and
`ARMYPOWER`. Confirmed PvP rewards cross those thresholds transactionally, subtract per-level XP,
grant source Gold once, advance the player level, and recompute rank Army Power. Level gates for
shop items, units, promotions, and feature unlocks use the same zero-based/display-level conversion
as `LevelManager`.

## Dog-tag energy

Energy is stored as accumulated seconds rather than only a tag count. The default recovered model
uses a 900-second refill interval and a five-tag cap. Passive regeneration is calculated from server
time. Spending one tag and buying a full refill are atomic, and Gold price is server-calculated.

## Daily rewards

The server maintains a monthly calendar cursor with two ordered values: rewards available and
rewards already claimed. At most one new day becomes available per distinct UTC date. Claims must
be sequential and cannot be replayed.

The response uses `dailyRewardData` and `DayN` fields expected by Unity. Current Gold reward values
are conservative configuration defaults because the original production live-ops sheet has not
been recovered.

## Daily assignments

The server issues a stable UTC-day assignment set. Only confirmed PvP settlement facts advance the
supported objectives. Claims validate completion and exact reward, skips obey their daily limit,
and the mega-reward cursor advances in order.

Unsupported objectives never advance from a client-provided fraction. `BufferId` makes claim and
skip retries idempotent.

## Starter assignments

The limited onboarding chain uses recovered MainScene thresholds, order, and currency rewards.
Supported completion facts include ranked wins, medal balance, level, lifetime squad points, first
mission completion, the equipped secondary-weapon level, and War Cards consumed by confirmed PvP
settlement.

Recovered class registration maps `ID_2` to PlayWarcard and `ID_3` to DeployUnit. `ID_2` completes
only after three inventory-backed card consumptions have committed with confirmed match results;
the client `StatsManager.cardsPlayed` value is never trusted. Unit deployment (`ID_3`) remains
disabled until that event source is server-authoritative. Gold-card crafting completes `ID_8` only
from an accepted server-owned craft claim.

## Daily, co-op, and heroic missions

The server issues the exact `DailyMissionsData`, `SavedMission`, and compact `MissionUnit` shapes.
A battle-start action creates a private receipt binding player, mode, day, and battle ID. `GameEnded`
must consume a compatible receipt.

Settlement provides:

- replay-safe success or stored failure response;
- separate solo and co-op completion flags;
- ordered heroic missions and the 30-point heroic gate;
- recovered daily and heroic currency completion rewards.

Original mission selection weighting, normal per-battle reward formulas, and authoritative combat
validation are still incomplete.

## Achievements

Achievement state mirrors the recovered `{ data: [...] }` shape. Supported counters advance only
from server-confirmed events such as ranked settlement, assignment claims, mission completion,
squad points, and daily rewards. Tier claims are ordered and atomic.

Accepted Arena settlements now advance the two MainScene Arena groups in the same atomic state
transition that consumes the battle receipt. `AchievementWinArenaBattles` (group 3) grants 5, 15,
and 50 Tickets at 2, 10, and 100 accepted wins. `AchievementFlawlessHero` (group 4) grants 50,
150, and 250 Scraps after 1, 3, and 10 complete maximum-win runs with no accepted loss. Replaying
the same battle receipt returns its stored response, so neither counter can advance twice.

Seven additional MainScene groups are now reconstructed from server-owned snapshots: bought units
(group 0), bought weapons (1), confirmed War Cards consumed in PvP (8), soldier normal upgrades
(9), mechanical normal upgrades (10), weapon upgrades (11), and paid permanent visuals (15).
Their exact three-tier targets and Gold/WarBucks rewards come from the serialized Achievements
component. Purchase counters require source unlock level above three, upgrade counters sum only
normal `boughtIndex`, visual counting excludes power bands, and temporary rentals never qualify.
Recomputing these monotonic values from inventory also migrates older accounts without trusting
the client's action-220 progress or offset.

Arena combat details are still client-reported: these achievements are authoritative for the
server's accepted receipt lifecycle, not proof that the client simulated combat honestly.
Deployment and per-match combat-feat groups remain inactive until their event facts are
server-authoritative.

## Key implementation files

- `Server/src/services/dailyRewardService.ts`
- `Server/src/services/assignmentService.ts`
- `Server/src/services/starterAssignmentService.ts`
- `Server/src/services/dailyMissionService.ts`
- `Server/src/services/achievementService.ts`
