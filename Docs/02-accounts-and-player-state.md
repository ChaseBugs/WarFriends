# Accounts and Player State

## Account types

The backend supports guest/custom accounts and recovered Facebook, Google Play, and Game Center
identity links. External provider credentials are stored separately from `DatabasePlayer` so they
cannot leak through profile, leaderboard, or opponent responses.

One provider identity may belong to only one WarFriends account, and one player may have at most
one identity per provider. MongoDB unique indexes enforce both rules in addition to service-level
checks.

### First-time Game Center creation

The recovered iOS path calls `CreateGcAccount` before any WarFriends session exists. It sends
`GameCenterId` and `GameCenterPassword`, then routes a successful response through the same account
parser used by `CreateAccount`. The backend therefore returns the full `Player`, DynamoDB-style
`PlayerData`, `AccountType = 3`, an internal gameplay `Token`, and the original platform credential
as `Password`. The two credentials are deliberately different: only the internal token authorizes
normal gameplay requests.

The new player row and its Game Center identity row are inserted in one MongoDB transaction. The
unique provider/external-id index decides simultaneous creation races, so the losing request cannot
leave an unreachable Recruit account. An existing identity returns recovered error `15400` with
`GameCenterId` and the owner's public FHIPGDADNFG `PlayerData`; this is the exact shape used by the
stock `UserExistsDialog`. Session credentials and stored HMAC values are never included in that
duplicate response.

## Authentication lifecycle

1. Account creation produces a player ID and an opaque session credential.
2. Custom password creation stores a keyed digest, never the clear-text password.
3. Login verifies the durable password/provider credential and rotates the gameplay session token.
4. Normal gameplay requests authenticate with `PlayerId` and the current session token.
5. Linking and unlinking providers validates ownership before changing the identity mirror on the
   public player object.

The distinction between a durable login credential and a short-lived gameplay session prevents a
stale password field from bypassing token rotation.

### Facebook account selection

`DatabaseAction.SwitchToFacebook` exists in the recovered enum, and several UI components listen
for it as a generic refresh signal. However, the 1.6.0 `BeanstalkServerManager` has no outbound
request for action 53 and `OGLEHLIPEFM` has no response branch that saves a returned target player.
Returning success for action 53 would therefore leave the old local credentials active.

The authoritative stock path starts from the existing-account dialog. When the player selects the
other Facebook account, the client clears its local account and calls `LoginToCustomAccount` with
`Id`, `Password`, and `AccountType = 2`. That implemented handler verifies the Facebook identity,
returns the shared account payload, saves separate provider/session credentials, and then triggers
`GetPlayerData`. Action 53 remains intentionally unregistered instead of reporting a false switch;
a future patched-client adapter may add it only together with an explicit account-payload parser.

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
presence, and device tokens are bounded and validated before persistence.

### Player rename economy

`ChangePlayerName` sends `Name` and `PayForRename`. The first rename is free because the stored
`RenameCount` is zero. Later prices reproduce `PlayerAnalytics.renameGoldPrice`: four Gold for
count one, then doubling for every completed rename. The base value is recovered from the 4.9.5
`SecondRenameGoldCost` MainScene row. Its CodeStage `ObscuredFloat` bytes `e7858340`, decrypted
with key 230887, resolve to 4.

The profile name, normalized unique key, incremented `RenameCount`, and Gold balance commit in one
revision-guarded MongoDB update. A concurrent economy mutation forces the rename to reload and
recalculate its price. The database unique index decides simultaneous case-insensitive name races,
so two players cannot reserve the same spelling by passing a preflight check together.

The Rename dialog changes its local wallet only after success. The response echoes `PayForRename`
and returns the new `RenameCount`, allowing the client to deduct the exact price it displayed. On
insufficient Gold, source error `11402` returns the authoritative `RenameCount` and `PlayerGold`
fields consumed by the stock rollback dialog. Extreme counts that trigger the original client's
signed 32-bit price overflow are rejected instead of becoming free.

The recovered client performs a local bad-word check before sending a manual rename. A production
server-side profanity policy still needs an authoritative multilingual rule set; it must not infer
one from corrupted decompiler strings.

## Migration behavior

Older development accounts may not contain the latest progression subdocuments. Read adapters
materialize safe defaults, such as the verified starter inventory, without pretending the values
were persisted. The next authoritative mutation writes the canonical schema.

## Key implementation files

- `Server/src/services/authService.ts`
- `Server/src/services/identityService.ts`
- `Server/src/services/playerService.ts`
- `Server/src/services/playerRenameService.ts`
- `Server/src/services/playerStateService.ts`
- `Server/src/services/progressionMutationService.ts`
- `Server/src/handlers/auth.ts`, `Server/src/handlers/identity.ts`, and `Server/src/handlers/player.ts`
