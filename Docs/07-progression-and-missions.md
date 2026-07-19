# Progression, Assignments, Missions, and Achievements

## Player levels and experience

The client stores a zero-based level index and separate progress within the current level. Durable
match and mission rewards update progression through server-owned mutations. Level gates for shop
items, units, promotions, and feature unlocks must use the same zero-based/display-level conversion
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
mission completion, and the equipped secondary-weapon level.

Unit deployment, war-card play, and card crafting remain disabled until those event sources are
server authoritative.

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

Inventory, card, and some Arena achievement groups remain inactive until their source events and
reward inventory are authoritative.

## Key implementation files

- `Server/src/services/dailyRewardService.ts`
- `Server/src/services/assignmentService.ts`
- `Server/src/services/starterAssignmentService.ts`
- `Server/src/services/dailyMissionService.ts`
- `Server/src/services/achievementService.ts`
