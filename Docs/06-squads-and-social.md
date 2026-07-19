# Squads and Social Systems

## Core squad model

A squad is a persistent MongoDB document with a unique name, founder/leader data, membership list,
join policy, medal requirement, emblem, experience, and squad points. Player documents retain a
denormalized squad name/rank because the recovered client expects those fields in normal profile
responses.

Recovered ranks are `Member`, `Veteran`, `Coleader`, and `Leader`. Authorization uses explicit rank
rules rather than relying on numeric enum order.

## Membership flows

Implemented flows include:

- unique-name check and squad creation;
- public join or private join request;
- invitation, acceptance, and decline;
- promotion, demotion, kick, and protected leadership transfer;
- guarded leave and founder succession;
- emblem/settings updates and full member snapshots.

Every mutation verifies actor membership, actor authority, target membership, capacity, and join
policy. A leader cannot accidentally leave a squad without a valid succession path.

Public joins, invitation joins, and manager-approved join requests use one admission transaction.
The transaction reads the squad and target player from one snapshot, rechecks capacity, medal
requirements, privacy, invitation/request state, and the approving manager's current rank, then
commits the roster, consumes pending admission records, and updates the player's squad mirror
together. A replay cannot duplicate the roster, and an older roster-only partial state is repaired
without changing an existing member's rank.

LeaveSquad is also transactional and replay-safe. It binds the request to the player's current
server-owned squad, preventing a forged or stale squad name from clearing unrelated membership.
The same commit removes the roster entry (or deletes a last-member squad), clears both player
mirrors and deposited-card state, and returns all deposited normal War Cards to the authoritative
inventory. A founder of a multi-member squad must still transfer leadership first. Repeating a
completed leave is harmless, while a legacy player-only mirror is repaired when its squad no
longer exists.

Promotion, demotion, leadership transfer, and kick also use snapshot transactions. Each operation
checks the actor's current roster rank, applies one allowed transition, and updates the target
player mirror together with the roster. Leadership transfer updates both player mirrors and keeps
exactly one founder. The recovered `PromotePlayerToFounder` callback immediately changes the old
leader to `Veteran`, so the backend uses that exact result; the earlier reconstruction's
`Coleader` result was incorrect. Kick clears the target's membership/deposits and returns their
normal deposited cards to authoritative inventory in the same commit. It also persists the
target's `MessageType=3` kick notification in that transaction. The notification contains the
exact `KickedPlayerId`, `SquadKickedFrom`, administrator snapshot, and JSON
`KickedPlayerDepositedCards` fields parsed by `MBACFNICJPL`. A connected client can therefore
repair its already-loaded squad/card state immediately, while an offline client receives the
message after login without risking loss between the membership commit and inbox delivery.

## Client error contracts

Squad failures use the recovered `IJEAJGCCHEF` values rather than reconstruction-only generic
codes. Admission returns `3801` for full, `3803` for insufficient medals, `3804` for a private
squad, and `3805` when the squad disappeared. Pending-request conflicts use `13201`, `13301`, and
`13302`; the last two include the exact `PlayerId` and optional current `Name` fields consumed by
the awaiting-member UI. Leave uses `4901`; promote, founder transfer, demote, and kick use `5501`,
`5701`, `5801`, and `5802`. Promote/demote failures also return a fresh `SquadMembers` array because
the stock error parser reloads that snapshot to roll back its optimistic rank display.

## Legacy integrity audit

`npm run audit:squads` in `Server` performs a read-only comparison of every squad roster and
player document. It reports duplicate roster rows, cross-squad membership, missing accounts,
founders outside the roster, invalid leader sets/ranks, player mirror drift, and deposited cards
left on a player who has no roster membership. Add `--json` after `--` for machine-readable output.

`npm run repair:squads` applies only deterministic player-side repairs: `squads.members` supplies
the single authoritative name/rank, or an absent roster clears stale mirrors and returns valid
normal deposits before clearing the pool dictionary. Every write matches the audited `updatedAt`,
so a concurrent gameplay mutation becomes a reported conflict instead of being overwritten.
Ambiguous roster/founder/leader problems remain manual by design; the tool never guesses which
squad or manager should own a player.

## Squad creation economy

Squad creation is a paid, server-authoritative operation. The recovered
`PlayerAnalytics.createSquadWarBucksPrice` formula is `(squadCreationsCount + 1) * 25`, so a
player's first creation costs 25 WarBucks, the second costs 50, and the third costs 75. The base
value is not an estimate: the 4.9.5 MainScene stores `WarBucksCreateSquadPrice` as obscured bytes
`e785cb41` with key `230887`, which decodes to the float value 25.

The original UI subtracts that price optimistically before action 37 reaches the backend. The
server never trusts the local subtraction. It reloads the founder's authoritative progression,
calculates the price from the persisted creation count, and commits four related changes in one
MongoDB transaction: the unique squad document, founder roster entry, player squad mirror, and
WarBucks/count progression update. A name-index conflict or concurrent founder-state change
aborts all four changes, preventing a paid but missing squad or a free squad with no wallet debit.

On success, the response includes exact key `squadCreationsCnt`; the stock callback copies it
back into PlayerAnalytics. If funds are insufficient, exact source error `11403` includes both
`squadCreationsCnt` and `PlayerWB`, which the generic error parser uses to undo the optimistic UI
debit. A unique-name race uses exact source error `3701`. `GetPlayerData` also restores
`squadCreationsCount` inside `PlayerAnalyticsData`, so restarting or changing devices cannot reset
the next creation price.

## Discovery and leaderboards

Squads can be searched and listed using recovered response shapes. Experience and squad-points
indexes support leaderboard reads. Redis may cache ranking data, but MongoDB remains authoritative.

## Messages and challenges

The backend stores recipient-owned normal messages and challenges. Reads are bounded, ignore is a
soft visibility change, and expiring messages enforce logical expiry even before MongoDB's TTL
monitor deletes the row. Sender rate limits and idempotency keys reduce replay and spam.

War Card contribution reminders are also implemented as recovered `DepositWarcards` inbox
messages. The backend validates both players against the same server-owned squad roster, rejects
self-notification, emits the five-field sender snapshot consumed by the original UI, and limits
each actor/target pair to one persistent reminder per UTC day.

Challenge acceptance validates the recipient and message state, but the live challenge-to-match
handoff is still incomplete.

## Squad chat

The original client uses Photon Chat for channel messages and Beanstalk only to persist the last
seen timestamp. The backend currently stores that timestamp monotonically and restores it through
`PlayerAnalyticsData`.

Actual chat delivery still requires Photon Chat repointing or a compatible replacement transport,
plus moderation, retention, and push-notification fan-out.

## Card-pool integration

Normal-card deposits, cross-player withdrawals, timed crafting, claims, and member contribution
reminders are implemented. Cross-player withdrawal uses a MongoDB transaction so donor pool,
recipient inventory/cooldown, and donor reputation commit together. Buddy deposits validate the
client-selected unit type against a server-derived weapon pair, owned loadout, visuals, Army Power,
name, level, timestamped identity, single-pool limit, and 480-minute cooldown. Buddy withdrawals
preserve that exact snapshot. Only server selection of the Buddy unit-type roll remains a modified-
client protocol task.

## Missing squad systems

- squad events, divisions, milestones, and wars;
- chat delivery and moderation.

All currently implemented multi-document membership changes are transactional. An operational
integrity scan is still desirable for accounts written before these transaction boundaries were
introduced.

Unrecovered actions remain rejected rather than mutating guessed card or event state.

## Key implementation files

- `Server/src/services/squadService.ts`
- `Server/src/services/squadWireService.ts`
- `Server/src/services/squadSocialService.ts`
- `Server/src/services/squadCardPoolService.ts`
- `Server/src/handlers/cards.ts`
- `Server/src/handlers/squad.ts`
- `Server/src/services/socialService.ts`
