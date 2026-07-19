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

## Discovery and leaderboards

Squads can be searched and listed using recovered response shapes. Experience and squad-points
indexes support leaderboard reads. Redis may cache ranking data, but MongoDB remains authoritative.

## Messages and challenges

The backend stores recipient-owned normal messages and challenges. Reads are bounded, ignore is a
soft visibility change, and expiring messages enforce logical expiry even before MongoDB's TTL
monitor deletes the row. Sender rate limits and idempotency keys reduce replay and spam.

Challenge acceptance validates the recipient and message state, but the live challenge-to-match
handoff is still incomplete.

## Squad chat

The original client uses Photon Chat for channel messages and Beanstalk only to persist the last
seen timestamp. The backend currently stores that timestamp monotonically and restores it through
`PlayerAnalyticsData`.

Actual chat delivery still requires Photon Chat repointing or a compatible replacement transport,
plus moderation, retention, and push-notification fan-out.

## Missing squad systems

- card pool deposit/withdraw/craft/claim;
- member reminders to deposit;
- squad events, divisions, milestones, and wars;
- atomic multi-document transactions for every membership mutation;
- chat delivery and moderation.

These actions remain rejected rather than mutating guessed card or event state.

## Key implementation files

- `Server/src/services/squadService.ts`
- `Server/src/services/squadWireService.ts`
- `Server/src/services/squadSocialService.ts`
- `Server/src/handlers/squad.ts`
- `Server/src/services/socialService.ts`
