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
2. Custom password creation stores a versioned, salted scrypt digest, never the clear-text password.
3. Login verifies the durable password/provider credential and rotates the gameplay session token.
4. Normal gameplay requests authenticate with `PlayerId` and the current session token.
5. Linking and unlinking providers validates ownership before changing the identity mirror on the
   public player object.

The distinction between a durable login credential and a short-lived gameplay session prevents a
stale password field from bypassing token rotation.

`CreateFullAccount` accepts only an explicit 6-to-128-character password. It never silently turns
the newly issued gameplay token into a password when the field is missing or invalid. The server
derives the password digest before inserting the player document and then publishes the account,
digest, and independent session token in one insert, so a hashing failure cannot leave a guest-only
orphan behind.

The recovered action 121 request sends `Name` and `Password` together. The backend likewise stores
the public name mirror, normalized uniqueness key, password digest, and rotated gameplay token in
one MongoDB compare-and-set update guarded by the session that authenticated the request. A KDF,
unique-name, database, or stale-session failure therefore commits none of those fields. Two
concurrent submissions using the same old session cannot both win. Action 122 exists in the 1.6.0
enum and response listeners, but no authoritative outbound call was recovered; its strict handler
is retained for compatibility without inventing additional request fields.

Human-entered custom passwords use scrypt v1 with `N=16384`, `r=8`, `p=1`, a random 128-bit salt,
and a 256-bit output. Before scrypt, an HMAC with `AUTH_SECRET` binds the password to the player ID
and supplies a server-side pepper. This makes a stolen player database insufficient for independent
offline guessing and gives every guess a memory-hard cost. Historical development rows containing
the old unversioned HMAC remain readable only on `LoginToCustomAccount`; after one valid password
login, a compare-and-set migration replaces that exact legacy digest without overwriting a
concurrent password change. Platform credentials remain separate because production must validate
those with their provider rather than treat an OAuth token as a human password.

Session rotation uses a compare-and-set against the token snapshot that was authenticated. If two
writes race from that same snapshot, only one candidate token is persisted and the losing writer
reloads that winner instead of returning an unpersisted candidate. A later login that already sees
the winner may rotate again; this is the intentional single-session policy, so the last completed
login owns the current gameplay credential. The prior token stops authorizing gameplay when its
replacement is persisted.

`LoginToCustomAccount` also reserves an attempt in the persistent `authRateLimits` collection
before checking a durable custom or platform credential. One atomic counter is shared by every
server process for the HMAC-derived key of the presented identity; the raw player/provider ID is
not stored in the throttle collection. The default policy allows five attempts in fifteen minutes
and then holds the identifier for fifteen minutes. `AUTH_LOGIN_MAX_ATTEMPTS`,
`AUTH_LOGIN_WINDOW_SECONDS`, and `AUTH_LOGIN_LOCKOUT_SECONDS` may tune that deployment policy, but
code clamps all windows to a safe non-zero minimum.

A correct durable login deletes only its own reservation revision, preserving any later concurrent
failure. A valid current gameplay session bypasses the password throttle and clears older failures,
so an attacker who knows a public player ID cannot lock an already authenticated player out of
normal gameplay. Missing accounts, bad credentials, and active cooldowns all return the same code
10 response. Ordinary actions never accept a provider password and never consume login attempts.

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

The recovered client performs a local bad-word check before sending a manual rename, but that UI
check is not authority. The backend applies one Unicode-normalized multilingual policy to account
creation and every rename. It recognizes punctuation-separated and common leetspeak evasions,
uses whole-token rules for ambiguous short terms to reduce false positives, and supports
deployment-specific comma-separated additions through `PROFANITY_EXTRA_TERMS`. The same policy
also protects Squad names/descriptions and normal inbox text, so a modified APK cannot bypass it
by entering public text through another action. Reports remain unfiltered so moderators retain
the submitted evidence.

## One-time social and permission rewards

Action `161` sends `RewardId`, an optional `Parameter`, and no currency amount. Three
client-observed direct rows have authoritative Gold values: `FacebookLike` 10, `TwitterFollow` 10,
and `NotificationAllowReward` 4. The separate `FacebookLoginReward` row is 10 Gold and is granted
only after the authenticated Facebook-link operation succeeds. These values come from CodeStage
`ObscuredFloat` bytes with key 230887; they are not client-selected defaults. The server accepts
only those exact, case-sensitive DBKEY/trigger pairs, atomically credits Gold, and records the ID
in its private `collectedRewards` dictionary. A guest cannot submit the Facebook-login ID through
action 161.

The two onboarding upgrade rewards are also authoritative. `TutorialManagerStage4.ChooseWeapon`
always selects `Google2u.AssaultRifle_AK47`; its first generated upgrade row costs 500 WarBucks and
60 seconds, whose recovered float32 Gold-time formula produces 1 Gold. Stage 5 likewise selects
only `Google2u.DBUpgradeSlotsAssaulter`, with a first normal upgrade costing 375 WarBucks and 60
seconds (also 1 Gold). The server treats `Parameter` only as an assertion of those exact targets,
requires the permanent item at cursor zero with an empty shared delivery receipt, and calculates
the grants from the same generated catalogs used by the purchase endpoints. Thus a modified APK
cannot nominate a higher-cost item or claim funding after starting another upgrade.

The stock `OOIMBPCOENI` parser checks only whether `WasAdded` exists. A first claim therefore
returns `WasAdded`, while a replay deliberately omits the property but still returns `RewardId`
and `Gold`, which the parser reads unconditionally. Sending `WasAdded=false` would be incorrect:
`ContainsKey` would still make the old client add the currency locally. On login, the authoritative
markers are restored through `PlayerAnalyticsData.collectedRewards`, so claimed buttons stay hidden
across devices and reinstallations. Simultaneous duplicate requests share the normal progression
revision guard; after a collision, the loser reloads the winner's marker and becomes a no-op.
Tutorial replays validate the exact target but intentionally check the marker before mutable
upgrade eligibility, so a retry after the forced upgrade completes still returns its original
Gold/WarBucks fields without `WasAdded`. Unknown and still-unrecovered archived reward IDs remain
closed.

## Migration behavior

Older development accounts may not contain the latest progression subdocuments. Read adapters
materialize safe defaults, such as the verified starter inventory, without pretending the values
were persisted. The next authoritative mutation writes the canonical schema.

## Key implementation files

- `Server/src/services/authService.ts`
- `Server/src/services/authRateLimitService.ts`
- `Server/src/services/identityService.ts`
- `Server/src/services/playerService.ts`
- `Server/src/services/playerRenameService.ts`
- `Server/src/services/oneTimeRewardService.ts`
- `Server/src/services/playerStateService.ts`
- `Server/src/services/progressionMutationService.ts`
- `Server/src/handlers/auth.ts`, `Server/src/handlers/identity.ts`, `Server/src/handlers/player.ts`,
  and `Server/src/handlers/economy.ts`
