# Client and Server Architecture

## Overview

WarFriends uses two different network planes:

1. A **meta server** for accounts, player state, economy, squads, missions, leaderboards, and
   durable battle settlement.
2. A **realtime battle transport** for matchmaking, room membership, opponent events, and
   short-lived PvP state.

The recovered client originally used a Beanstalk HTTP backend and Photon services. The current
server replaces the meta backend with Express/MongoDB and supplies a WebSocket match relay.
This relay is not a full Photon protocol implementation, so the client still needs a transport
adapter or a Photon-compatible service before an unmodified APK can use it directly.

## Meta request flow

The client sends a numeric `DatabaseAction` in the URL and repeats it in the request body. Most
stock requests are BestHTTP form posts. Diagnostic clients may send a JSON envelope.

```text
Unity action
  -> HTTP route normalizes form/JSON fields
  -> action dispatcher selects one handler
  -> authentication resolves PlayerId + Token
  -> service validates and changes server-owned state
  -> response adapter emits the exact legacy field names
```

Important transport rules:

- The URL action and body action must agree.
- Authenticated gameplay operations use a rotated server session token.
- Client-version gates run before the action handler.
- Unknown gameplay mutations return error `90`; they are never acknowledged as successful.
- Only an explicit allowlist of analytics and impression actions is accepted as a no-op.

## Boot sequence

After login, `GetPlayerData` restores public profile data and private progression. The response
uses DynamoDB-style wrappers because the recovered C# parser expects numbers as `{ "N": "..." }`
and serialized objects as `{ "S": "<json>" }`.

The most important restored objects are:

- `DatabasePlayer`: identity, visible profile, league, squad, and Army Power.
- `InventoryData`: equipped weapon slots.
- `LevelManagerData`: owned weapons, owned units, and delivery receipts.
- `AssignmentData`, `DailyMissionsData`, `AchievementsData`, and `WarArenaData`.
- Wallet, dog-tag, settings, and analytics cursor fields.

Sending a normal JSON number or using the wrong nested type name can produce a syntactically valid
response that the Unity client silently loads as zero or empty.

### Configuration boot response

`GetConfigurations` is the one recovered action that bypasses the normal JSON envelope. The stock
parser reads semicolon-delimited segments in this exact order:

```text
success;<sheet configuration version>;{<sheet versions JSON>}
```

When no remote sheets are published, the server echoes the client's current version and returns an
empty sheet-version object, preserving the APK's bundled Google2u data. The response must stop after
the closing `}`. A trailing semicolon creates a fourth empty segment; the Client tries to deserialize
that segment as a sheet object and may fail during boot. Semicolons are removed from the echoed
version so client input cannot inject another wire segment.

## Persistence model

MongoDB stores one player document per account. Frequently queried profile dimensions are copied
to indexed top-level fields, while the exact client-facing profile is stored in `player` and
private economy state is stored in `progression`.

The backend also uses dedicated collections for squads, identities, matches, messages, reports,
and versioned gameplay catalog data. Redis is optional and is used only for acceleration and
coordination paths that have a MongoDB fallback or durable source of truth.

## Trust boundary

The client is a presentation and input device, not an authority for rewards or inventory.
The server must independently validate:

- identity and session ownership;
- item ownership and equipped-slot compatibility;
- level, tier, price, duration, capacity, and expiry;
- match participation and agreement between battle reports;
- reward eligibility and whether a claim has already been consumed.

Serialized client blobs can be returned for compatibility, but they cannot authorize currency,
items, match rewards, or progression.

## Key implementation files

- `Server/src/routes/index.ts`: HTTP normalization and action routes.
- `Server/src/handlers/index.ts`: action dispatch and authentication boundary.
- `Server/src/db.ts`: MongoDB collections and indexes.
- `Server/src/gameHub.ts`: WebSocket match transport.
- `Server/src/services/playerStateService.ts`: legacy boot-response adapters.
