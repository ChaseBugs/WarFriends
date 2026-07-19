# Accounts and Player State

## Account types

The backend supports guest/custom accounts and recovered Facebook, Google Play, and Game Center
identity links. External provider credentials are stored separately from `DatabasePlayer` so they
cannot leak through profile, leaderboard, or opponent responses.

One provider identity may belong to only one WarFriends account, and one player may have at most
one identity per provider. MongoDB unique indexes enforce both rules in addition to service-level
checks.

## Authentication lifecycle

1. Account creation produces a player ID and an opaque session credential.
2. Custom password creation stores a keyed digest, never the clear-text password.
3. Login verifies the durable password/provider credential and rotates the gameplay session token.
4. Normal gameplay requests authenticate with `PlayerId` and the current session token.
5. Linking and unlinking providers validates ownership before changing the identity mirror on the
   public player object.

The distinction between a durable login credential and a short-lived gameplay session prevents a
stale password field from bypassing token rotation.

## Public and private state

`DatabasePlayerDTO` contains information that may appear in profiles, squads, matchmaking, and
leaderboards. `PlayerProgressionState` contains server-owned balances and receipts.

Public examples:

- account name, country, level, experience, reputation, and presence;
- league, medals, squad name/rank/points;
- visible Army Power and player visuals.

Private examples:

- Gold, WarBucks, Tickets, Scraps, and dog-tag time;
- weapon/unit ownership and upgrade cursors;
- pending delivery receipts;
- assignment, mission, Arena, and achievement claim state;
- bounded replay records for buffered mutations.

## Optimistic concurrency

Progression contains a monotonic `revision`. Economy and reward mutations use a compare-and-swap
write against this revision. If another request wins first, the operation reloads/retries or fails
without applying a partial debit or grant.

This protects operations such as:

- spending currency and granting an item;
- consuming a delivery receipt and advancing an upgrade;
- marking a claim complete and granting its reward;
- settling a match exactly once.

## Profile changes

Names are normalized and checked case-insensitively. Countries, locales, notification settings,
presence, and device tokens are bounded and validated before persistence. The reconstructed server
supports the first free rename; paid rename charging remains disabled until that full pricing
contract is recovered.

## Migration behavior

Older development accounts may not contain the latest progression subdocuments. Read adapters
materialize safe defaults, such as the verified starter inventory, without pretending the values
were persisted. The next authoritative mutation writes the canonical schema.

## Key implementation files

- `Server/src/services/authService.ts`
- `Server/src/services/identityService.ts`
- `Server/src/services/playerService.ts`
- `Server/src/services/playerStateService.ts`
- `Server/src/services/progressionMutationService.ts`
- `Server/src/handlers/auth.ts` and `Server/src/handlers/player.ts`
