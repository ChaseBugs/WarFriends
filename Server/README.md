# WarFriends GameServer

Private backend for the recovered WarFriends client — a **REST meta server** (accounts,
players, squads) plus a **WebSocket match relay** that stands in for Photon PvP. Design and
protocol notes: [`../BACKEND.md`](../BACKEND.md).
Core gameplay logic guides: [`../Docs/README.md`](../Docs/README.md).

Stack: Node.js + Express + TypeScript, MongoDB (native driver), Redis (optional), `ws`.
Structure mirrors the sibling recovery backend (`Heyworks/Backend`).

Recovered-contract classification: 1.6.0 Loyalty is only an `InappScreen` presentation tab and
has no database action, DTO, parser, or reward table, so it is not an implementable backend gap.
The paid extra War Card slot is already durable through reviewed value-pack grants, exact
`CardManagerData.extraSlot` boot projection, receipt replay, and last-grant-aware void reversal;
PvP's six-candidate ceiling includes that slot.

## Run

```bash
cp .env.example .env      # adjust MONGO_URL / REDIS_URL if needed
npm install
npm run dev               # ts-node-dev, watch mode
# or: npm run build && npm start
# build first removes only generated dist/ output, preventing stale renamed modules/tests
# optional explicit catalog publication: npm run sync:catalog
# read-only legacy squad/player integrity scan: npm run audit:squads
# apply only unambiguous mirror/card repairs: npm run repair:squads
```

`npm run build` executes the cross-platform Node `clean` script before TypeScript emission and
removes only `Server/dist`. This prevents renamed/deleted source files from surviving as stale
runtime modules or duplicate `node --test` inputs; the test count therefore reflects the current
`src/tests` tree instead of historical compiler output.

Squad Events are disabled by default because the retired production live-ops schedule was not
recovered. Set `SQUAD_EVENT_CONFIG_PATH` only to an operator-reviewed file following
[`config/README.md`](config/README.md); an empty value makes action 113 return recovered error
`11302` without creating progress or granting rewards.

The separate limited-time Event Assignment calendar is also disabled by default. Set
`EVENT_ASSIGNMENT_CONFIG_PATH` only to a reviewed file following [`config/README.md`](config/README.md).
The backend then publishes its exact boot config/state and enables server-owned action 222/223
claims. Destroyed-box progress remains disabled until the match relay can prove that combat fact.

Requires MongoDB (`:27017`) and, optionally, Redis (`:6379`). Set `REDIS_ENABLED=false` to
run Mongo-only. Cross-player squad-card withdrawal and confirmed PvP core settlement use
multi-document transactions, so enable a single-node replica set for local development (or use a
replicated/sharded managed deployment) and include `replicaSet` in `MONGO_URL`. Health check:
`GET /health`.

`PORT`, `MONGO_POOL_SIZE`, and `MONGO_DB_NAME` form one immutable early-startup policy: port must be
an exact 1-65,535 integer, pool size an exact 1-1,000 integer, and the trimmed database name must be
platform-safe and shorter than 64 UTF-8 bytes. This validation runs before MongoClient construction,
migrations, workers, or listener startup. Connection logs intentionally omit MongoDB/Redis URLs
because deployment URLs may embed credentials.

All enablement variables accept only complete case-insensitive `true`/`false` literals. Blank,
whitespace-padded, numeric, or misspelled values stop startup instead of silently selecting
`false`, which prevents one node from accidentally disabling Redis or a provider safety worker.

### Schema migration safety

Startup applies the ordered registry in `services/databaseMigrationService.ts` under the singleton
`schemaMigrations` lease. Migration implementations must remain idempotent because MongoDB can
complete `up` before a process persists its success receipt. Every non-lock history row is read and
validated before the first pending migration runs: exact fields, canonical SHA-256 checksum,
manifest-matching description, safe non-future `appliedAt`, and nonnegative safe `durationMs` are
required. An unknown, reordered, duplicated, drifted, or malformed row stops startup.

Lease acquisition inserts the singleton when absent and replaces an expired row only when its full
previous owner/date snapshot still matches. Renewal requires the stored lease to be unexpired at
the captured application time. A stalled process therefore cannot resurrect ownership after its
deadline, even if no other node has acquired the lease yet; it must stop and let a fresh startup
re-evaluate migration history. Invalid lease clocks fail closed for operator repair rather than
being guessed expired.

### Cross-node scheduled-job leases

Player League settlement, Squad War maintenance, Google Play subscription revalidation, Voided
Purchases reconciliation, and Firebase inbox delivery share renewable rows in `scheduledJobLeases`.
A new row records its exact
`leaseMs`, `renewedAt`, and derived expiry. The older four-field row is an explicit read-only legacy
shape: it may finish naturally, then the first exact expired takeover replaces it with the renewable
schema. Absence is acquired by singleton insert, and takeover compare-and-sets every prior field plus
the exact document size so a concurrently changed or damaged row cannot be silently normalized.

The owner heartbeats at one-third of the lease interval and renewal matches only an unexpired row
with the same owner and duration. Explicit fences are serialized with that heartbeat before each
batched or post-provider durable transition. A successful sweep is fenced once more, pending renewal
is drained, and release deletes only the current owner/duration tuple. If a heartbeat is delayed past
expiry or any fence loses its compare-and-set, the old worker fails instead of resurrecting itself or
continuing into the next mutation.

Player League polling, Squad War polling, and Squad War season duration resolve once during module
startup as one immutable competition-timing snapshot. Polling values must be exact integers from 10
through 3,600 seconds, and each same frozen value drives its local scheduler and renewable lease
sizing. Season duration must be an exact 3,600-through-2,147,483,647-second value shared by every
window derivation. Fractional, non-finite, negative, or out-of-range deployment values stop startup
rather than being floored, clamped, or re-read into conflicting settlement authority.

### Rotate `AUTH_SECRET` without invalidating accounts

Production requires `AUTH_SECRET` and every comma-separated `AUTH_SECRET_FALLBACKS` entry to be
distinct and at least 32 characters; at most three fallback keys are accepted. New session tokens,
custom-password digests, and provider-credential digests always use the active `AUTH_SECRET`.
Existing gameplay sessions survive a rotation because their opaque tokens are stored and compared
directly. A durable password/provider login that matches a fallback key is atomically rehashed with
the active key before its replacement gameplay session is returned.

`AUTH_SCRYPT_COST` controls the work factor for newly written custom-password digests. It must be a
power of two from 16384 through 65536, and invalid values stop startup in every environment. Each
digest carries its original bounded factor, so increasing the setting does not lock out existing
accounts: the next valid password login verifies with the stored factor and compare-and-set upgrades
the digest. Lowering the setting affects only new writes and never downgrades an already stronger
digest. Benchmark login latency and memory on the target hosts before raising it, then monitor the
durable-login rate and latency during rollout; gameplay-session requests do not run scrypt.

Use this staged procedure for a rolling deployment from key `old` to key `new`:

1. Generate `new` with a cryptographically secure secret manager. Deploy this server version to
   every node with `AUTH_SECRET=old` and `AUTH_SECRET_FALLBACKS=new`. This compatibility stage makes
   both keys readable before any node starts writing with `new`.
2. Roll every node to `AUTH_SECRET=new` and `AUTH_SECRET_FALLBACKS=old`. Mixed nodes can verify both
   keys; after the roll completes, successful durable logins converge their stored digest to `new`.
3. Keep `old` in the fallback list for the chosen dormant-account recovery window. Removing it does
   not end already-issued gameplay sessions, but an account whose password/provider credential was
   never presented during the overlap will require a supported password reset or provider relink.
4. Remove `old` everywhere after the recovery window and archive/revoke it in the secret manager.
   Never place secrets in Git, application logs, or a comma-containing representation.

An `AUTH_SECRET` change also starts fresh HMAC-hidden HTTP/WebSocket/login/report rate-limit keys and
report fingerprints, so schedule the activation during a monitored low-traffic window. If Google
Play purchases are enabled, set and retain an independent `PURCHASE_TOKEN_HASH_SECRET`; allowing it
to follow `AUTH_SECRET` would orphan receipt-ledger lookups. `ADMIN_SECRET`,
`PURCHASE_TOKEN_ENCRYPTION_SECRET`, and `REMOTE_CONFIGURATION_SIGNING_SECRET` have separate rotation
lifecycles and must not be copied into the authentication key ring.

Remote Google2u sheets remain disabled unless `REMOTE_CONFIGURATION_MANIFEST_PATH` points to an
operator-reviewed manifest signed with `REMOTE_CONFIGURATION_SIGNING_SECRET`. The exact stock
semicolon/DynamoDB-shaped wire supports sheet versions, row IDs, AB variant, language, client-build
range, and deterministic player rollout targeting. A ranged publication requires one canonical
numeric `ClientVersion`/`clientVersion` from a replacement client; conflicting aliases or malformed
values fail targeting, and the stock client's dotted `Version` (for example `1.6.0`) is never
coerced through `NaN` into a ranged match. Unbounded publications may still target the stock client.
Stock targeting itself requires exact string `abTestVariant` and `Language`; the Fuse variant may
be empty but neither selector may be missing, padded, coerced, or control-bearing. The misspelled
`SheetConfiguraton` is canonical, while documented replacement cache aliases are accepted only when
all supplied copies are exact and equal. An invalid cache identity receives `success;0;{}` and can
never select sheets; the server does not trim it or delete semicolon delimiters into another release.
For a rollout below 100 percent, hashing uses only one exact non-sentinel `PlayerId` or its agreeing
lower-case JSON `id` adapter. The common builder's pre-login literal `null`, padded/control-bearing
IDs, conflicting aliases, and upper-case explicit-login/action `Id` retain bundled sheets instead of
selecting a different player's bucket.
The signed manifest itself uses exact root/publication/sheet keys, case-insensitively unique language
selectors, signed-client-safe integer build bounds, and an actual finite numeric 0-100 rollout
percentage; ignored typo fields and JavaScript-coercible policy values fail startup. See
`config/README.md`; unsigned or malformed publication data fails startup, while an empty path
preserves the APK-bundled sheets.

Google Play purchases are fail-closed by default. To enable verified Android currency, reviewed
pack, and `subscription1` delivery, grant a service account Play Console purchase-read access, set
`GOOGLE_APPLICATION_CREDENTIALS` to its JSON file outside this repository, and set
`GOOGLE_PLAY_PURCHASES_ENABLED=true`. `GOOGLE_PLAY_PACKAGE_NAME` must remain the exact deployed
application ID. It is validated once as a bounded, untrimmed dotted Java-style identifier and then
shared by purchase delivery, durable receipt validation, subscription revalidation, and Voided
Purchases reconciliation; dependent workers cannot be enabled while purchase verification is off.
Set a separate random `PURCHASE_TOKEN_HASH_SECRET` of at least 32 characters and
keep it stable across session-secret rotations; changing it requires a purchase-ledger migration.
Set an independent `PURCHASE_TOKEN_ENCRYPTION_SECRET` of at least 32 characters and keep it stable:
subscription tokens are AES-256-GCM encrypted with this key so the scheduler can query later Play
state without storing replayable plaintext. Subscription revalidation and one-time Voided
Purchases reconciliation default to purchase enablement and poll every five minutes; cadence,
batch, and independent emergency-disable controls are documented in `.env.example`.
The server never accepts `GoldBase`, `WarbucksBase`, a price, or an amount as purchase authority.

Operational metrics are available at authenticated `GET /metrics` in Prometheus text format. Send
`Authorization: Bearer <ADMIN_SECRET>`; an empty secret disables the endpoint, and production
requires a separate secret of at least 32 characters. Labels are fixed and
never contain paths, actions, players, addresses, tokens, or arbitrary WebSocket types. Every HTTP
response also includes a generated `X-Request-ID`; request/response/error boundary logs include the
same ID while logging only the query-free request path. Async-local context automatically adds that
ID to downstream authentication, database, economy, and gameplay logger helpers across awaited work.
Firebase and Google Play HTTP requests forward only this generated UUID as `X-Request-ID`; background
provider calls generate a fresh UUID, while malformed manually installed contexts are never sent.
Deployable Prometheus scrape/rule examples and a Grafana overview live under `ops/`. Alerts cover
target loss, sustained 5xx/latency/rate-limit pressure, explicitly required Redis loss, repeated
restarts, high concurrency, sustained meaningful-volume Firebase retry pressure, and repeated
Firebase worker failures. Fixed push metrics expose only delivered/invalid-token/transient/configuration
attempt outcomes, not-eligible/invalid-token suppression reasons, recovered-intent count, and sweep
failure count; they contain no player, message, or token identity. Contract tests reject monitoring
expressions that reference metrics the server does not export.

Production MongoDB backups can use `npm run backup:mongodb:offhost`. The command creates plaintext
only in a unique OS temporary directory, validates the existing dump manifest, and sends an
AES-256-GCM archive plus authenticated metadata to a configured mounted remote volume or UNC share.
It refuses overwrite and prunes only old, same-database archive/manifest pairs after path, size, and
SHA-256 verification; damaged or unrelated files remain untouched. Encrypted restore requires the
matching historical key, explicit database-replacement confirmation, successful GCM authentication,
and the existing independent plaintext manifest check. `OPERATIONS.md` contains scheduling, key
retention, restore-drill, and alerting guidance.

Account sanctions use the same independent admin Bearer credential under
`/admin/moderation`. `POST /sanctions` issues a permanent ban when `durationSeconds` is omitted or a
bounded temporary ban when it is present; `POST /sanctions/:sanctionId/revoke` revokes an active ban;
and `GET /players/:playerId/sanctions` returns the latest 100 audit rows. Mutation requests require
`X-Admin-Actor` and an 8-128 character `Idempotency-Key`, so a lost response can be retried without
creating a second ban, extending a temporary deadline, or duplicating a revocation. The collection
retains expired and revoked history, permits only one active sanction per player, and evaluates expiry
from application time instead of waiting for MongoDB cleanup. Every durable row is validated before
enforcement, replay, operator publication, or appeal mutation: exact fields and normalized identities,
safe chronology, an exact optional duration/expiry pair, and status-consistent resolution/revocation
evidence are required. Authentication reads the active slot without an expiry filter so a malformed
Date fails closed instead of disappearing from the database comparison. After a caller proves account ownership,
all authenticated HTTP gameplay paths enforce the same record, and every non-heartbeat action on an
already-identified WebSocket rechecks it before reading or mutating live game state. The stock client receives exact error
`3003`, `accountId`, and `accountName`; temporary bans additionally receive remaining `seconds`, while
private operator identity and reason never leave the admin API.

The same `/admin/moderation` boundary exposes the report-review queue. `GET /reports` accepts
optional `status`, `kind`, `reportedPlayerId`, and `reporterPlayerId` filters plus a 1-100 `limit`
and opaque `cursor`; `GET /reports/:reportId` returns one complete review record; and
`POST /reports/:reportId/review` moves an `open` report to `reviewing`, `resolved`, or `dismissed`,
or moves `reviewing` to either terminal state. Review mutations require `X-Admin-Actor`, an
`Idempotency-Key`, and an `expectedStatus`; terminal decisions also require a bounded `note`.
Status and the append-only audit entry commit in one MongoDB update. Concurrent moderators cannot
both act on the same stale status, a retry cannot change its decision, and terminal reports cannot
be reopened. Newest-first pages use `createdAt` plus `reportId` as a stable cursor tie-breaker.

The recovered player-report boundary preserves account identity exactly. `ReportedPlayerId` is
never trimmed or truncated into another possible account, required player messages are rejected
when invalid or longer than 1000 characters rather than silently shortened, and `ReportType` accepts
only its canonical recovered decimal form. Cheater-report combat fields remain untrusted operator
context: a malformed, non-finite, control-bearing, or overlong claim is omitted whole and can never
become combat or punishment authority.

Player appeals use the separate `/support/moderation` boundary because the recovered stock banned
dialog has no database appeal action. A support frontend supplies `X-Player-Id` and the current
server-issued session token as `Authorization: Bearer <token>`; passwords and provider credentials
are not accepted. `POST /appeals` creates the sole appeal for that player's currently active
sanction, `GET /appeals` and `GET /appeals/:appealId` expose only owned public appeal fields, and
`POST /appeals/:appealId/withdraw` closes an owned `open` or `reviewing` appeal. Mutations require an
8-128 character `Idempotency-Key`, and withdrawal also requires `expectedStatus`. The support API
never restores gameplay access and never returns sanction reason, operator identity, or review
history. The admin boundary provides `GET /appeals`, `GET /appeals/:appealId`, and
`POST /appeals/:appealId/review`; decisions require the same actor, retry-key, expected-status, and
terminal-note controls as report review. Accepting an appeal revokes a still-live sanction in the
same MongoDB transaction, while rejection and player withdrawal leave the sanction unchanged.

Moderation retention is an explicit admin workflow rather than an automatic TTL. Configure terminal
record age with `MODERATION_REPORT_RETENTION_DAYS` and `MODERATION_APPEAL_RETENTION_DAYS` (30-3650;
both default to 365). The exact pair resolves once during module startup as one immutable policy,
so preview, export, and apply cannot observe different process-local cutoffs. Malformed policy stops
startup instead of being rounded, substituted, or re-read. The retention `preview` endpoint freezes
the cutoffs and eligible counts at one `previewedAt`; page every eligible record through
`GET /admin/moderation/lifecycle/retention/export?kind=reports|appeals&previewedAt=...` before applying
the purge. `POST /admin/moderation/lifecycle/retention/apply` requires that timestamp,
`X-Admin-Actor`, `Idempotency-Key`, and exact confirmation `DELETE_TERMINAL_MODERATION_RECORDS`.
The report/appeal deletes and immutable count receipt commit in one MongoDB transaction, so an exact
lost-response retry returns the original result. Open/reviewing records can never match the purge
filters, and account-sanction audit rows are retained indefinitely by policy.

## How the client talks to it

The client (`BeanstalkServerManager`) sends form fields to a URL ending in the numeric
`DatabaseAction` and dashed client version. It repeats the action in `requestId`; authenticated
requests use `PlayerId` and `Token`. Development tools may also send a JSON `DbAction`
envelope. `GetConfigurations` returns the exact three-segment raw text format required by the
recovered parser and ends after its sheet-version JSON object without an empty trailing segment;
malformed targeting/cache fields retain that callback shape with the zero-cache empty result but
cannot select a publication. Other implemented actions return JSON. The replacement realtime layer connects to
`ws://<host>/hub`.

Both action copies are parsed independently as canonical nonnegative C# `int` decimals before
equality or routing; JSON adapters may use an exact integer number. JavaScript-coercible nulls,
Booleans, arrays, whitespace, leading zeros, fractions, exponents, non-finite numbers, and values
above `Int32.MaxValue` are rejected before action 157's raw-response shortcut as well as ordinary
handlers. `MIN_CLIENT_VERSION`, when nonzero, gates the optional numeric replacement-client
`ClientVersion` field with the same exact grammar. The deployment minimum is validated during
dispatcher startup as an exact integer from zero through `Int32.MaxValue`, with only zero disabling
the gate. If `ClientVersion` and `clientVersion` are both supplied, both must be canonical and equal;
malformed or conflicting claims cannot use alias precedence or `NaN` to bypass the gate. The stock
client continues to send its dotted build in the separate `Version` field.

```bash
# Create a guest account (DatabaseAction 118) using the recovered BestHTTP shape
curl -X POST localhost:8080/PC/8b004c04-6921-4613-9815-e63b42db4a7c/118/1-6-0 \
  -d 'requestId=118&Version=1.6.0&Os=android&DeviceToken=dev-A'
# Response includes id, Token, Password, AccountType, typed Player, and typed PlayerData.
# Replay PlayerId + Token on every authenticated action.
```

## Layout

```
src/
  config.ts          env-driven config
  constants.ts       client enums (AccountType, League, SquadRank, PlayerStatus), Redis keys
  dbActions.ts       DbAction enum — the full server-operation catalog (wire contract)
  apiErrors.ts       numeric error codes + ApiError
  db.ts              MongoDB connection + typed collection accessors
  redis.ts           optional Redis (matchmaking queue, leaderboards, pub/sub)
  services/databaseMigrationService.ts  ordered, leased MongoDB schema migrations
  dtos/              wire types: envelope (base), DatabasePlayer, Squad
  services/          data/business logic: auth, player, squad
  handlers/          DbAction → handler dispatch (auth, player, squad)
  routes/            Express router: the Beanstalk POST endpoint
  gameRooms/         match room registry + relay types
  gameHub.ts         WebSocket hub: identify → join match → relay events → result
  index.ts           entry: express + http + ws + mongo + redis wiring
  utils/logger.ts    winston logger (per-level rotated files, emoji console)
```

## Status

Implemented backend paths (deployment-gated checks are called out explicitly):

- **Accounts / player**: `CreateAccount`, `CreateFullAccount`, `LoginToCustomAccount`,
  `GetPlayerData`/`GetPlayerInfo`, and player settings (name/country/status/device token).
  Recovered guest and Game Center first-account requests require `Locale` and a finite bounded
  invariant-C# `UtcOffset`; their optional DeviceToken is an exact opaque string. Locale is
  normalized once, revalidated by the reusable account service, and committed in the same initial
  player insert (and Game Center identity transaction), so first boot no longer silently becomes
  English. UtcOffset remains a non-authoritative client-local diagnostic hint: server UTC owns
  every reward day, deadline, and receipt. Optional Fusebox `StartingGold`/`StartingWarbucks`
  request fields are never read; decoded server onboarding policy remains the only currency source.
  The reusable creation service validates Locale, DeviceToken, and any Game Center ID before
  password hashing or MongoDB work. It writes the same exact token/ID into indexed and embedded
  player mirrors; a padded or control-bearing token and a padded Game Center ID are rejected rather
  than silently transformed into durable authentication or notification identity.
  Login/profile snapshots and private progression use the exact DynamoDB-style attribute
  wrappers parsed by the recovered 1.6.0 client. Boot, public profile, experience/Arena leaderboard,
  durable inbox responses, Squad War member snapshots, and War Arena configuration share one
  integer-projection numeric adapter. Squad Event progress uses its paired finite decimal-preserving
  adapter. Both reject non-finite or unsafe numeric authority instead of publishing a believable
  zero or raw `NaN`/`Infinity` string; War Arena also validates its monthly derivation clock.
  Root/indexed player identity, sparse provider IDs, device token, league, Army Power,
  lifetime-experience, squad-point, and squad-name mirrors must exactly match the client-facing
  `DatabasePlayer` DTO after every shared player lookup and before insert, authentication/gameplay
  use, or boot/profile/leaderboard projection. A missing row remains a normal lookup miss, while an
  existing split profile fails closed. Provider IDs must also satisfy their recovered wire shapes
  even when root and DTO agree; disconnected sentinels live only in the DTO and their sparse root
  index keys must be absent. Shared full-document lookup/insert additionally validates the private
  account envelope: exact session HMAC, supported legacy/scrypt password digest, bounded identity
  and device fields, canonical optional normalized name, and ordered finite audit dates. A missing
  legacy session is allowed only so a separately proven password/provider login can rotate it. The
  same credential-shape proof guards the intentionally narrow projection returned after a session
  compare-and-set and its concurrent-winner reload, so that race path cannot return a malformed
  stored token merely because it did not fetch the complete profile.
  The shared `DatabasePlayer` and leaderboard adapters also prove that complete envelope before
  public projection. Search, friend, squad-roster, challenge, experience, and Arena views therefore
  cannot advertise a damaged account merely because its public mirrors still look consistent.
  Global and country action-107 pages use a stable `(Experience descending, player ID ascending)`
  order backed by dedicated compound indexes. Every selected row must match the optional country
  and returned order before receiving its one-based `Position`. The recovered callback reads only
  `Items` and `Local`; the additional replacement-compatible `Rank` is one plus the number of
  strictly higher-Experience accounts, and every such account is streamed through the same full
  mirror/credential/audit/progression proof instead of trusting an unvalidated MongoDB count.
  Full-profile saves set/unset those roots atomically, so
  MongoDB cannot order, select, or authenticate by a value different from the one Unity displays.
  Human passwords use versioned salted scrypt with automatic legacy-HMAC migration; provider
  credentials remain separate from the rotated internal
  gameplay session token. `LoginToCustomAccount.AccountType` is parsed once as only canonical
  decimal Guest `0`, Facebook `2`, Game Center `3`, or Google Play `4`, and that same result drives
  credential verification and response projection. Arrays, booleans, blanks, leading-zero,
  fractional/exponent, missing, or unknown values cannot select a provider through coercion.
  Durable login guesses use an
  atomic MongoDB throttle keyed by an HMAC of the presented identity; active gameplay sessions
  remain usable and provider credentials are never accepted by ordinary gameplay actions. The
  complete throttle row is proved after reservation and before collision replay: exact fields and
  lower-case HMAC key, bounded positive attempt/revision counters, ordered safe dates, non-future
  audit time, and a bounded lock contained by expiry. Validation uses the globally supported policy
  range so configuration changes remain compatible without allowing malformed rows to lock forever
  or silently reopen credential work. Deployment policy is validated once during module startup:
  maximum attempts must be an exact integer from 2-100, the attempt window from 60-86,400 seconds,
  and lockout from 60-604,800 seconds. Fractional, non-finite, or out-of-range values stop startup
  instead of being rounded, clamped, or replaced by defaults.
  The dispatcher preserves the recovered authentication envelopes instead of searching every
  identity-shaped field. Explicit `LoginToCustomAccount` uses `Id` plus `Password`; ordinary
  authenticated requests use the common `PlayerId` plus `Token` fields added by
  `BeanstalkServerManager`. Matching documented JSON aliases are accepted, but conflicting aliases
  fail before lookup. Ordinary actions never fall back to `Id` or `Password`: those names are also
  legitimate product/message/Squad and account-mutation payload fields, and treating them as
  credentials would let a missing or rotated session token cross an unrelated action boundary.
  Raw full-document reloads inside Army Power refresh, Daily Missions, Instant Battle, PvP
  settlement, inbox reward claims, and Player League allocation/settlement repeat the same account
  proof before calculating or publishing economy and indexed-profile changes. Authentication proves
  only its earlier snapshot; a newly damaged row aborts the retry or whole transaction, and one
  corrupt league member aborts the complete division before its first rank or reward write. Squad
  creation, admission, departure, rank, leadership, kick, card withdrawal, and chat sender reloads
  apply the same rule before publishing roster/profile mirrors, transferring inventory, or recording
  a sender identity; every player participating in a multi-player mutation must pass independently.
  The operator Squad-integrity repair is the narrow exception to complete mirror proof: it may read
  the squad mirror mismatch it is explicitly replacing, but separately validates all private account
  fields, the exact audited `updatedAt`, and any progression successor before its guarded update.
  Full-account creation hashes before its single insert, while the recovered action 121 publishes
  name, password digest, and rotated session atomically with a stale-session guard.
  Repeated status, country, language, device-registration, and notification-setting values are
  exact no-ops; token and locale changes from one device-registration request publish together.
  Profile mutation requests preserve the recovered field boundary: action 29 mutates only from
  `PlayerStatus` (a diagnostic `Status` duplicate must agree and cannot act alone), action 196
  requires `NewCountryCode` (an optional `Country` duplicate must normalize identically), and
  action 13 requires `DeviceToken` plus `Locale` as one fully validated tuple before either value
  is written. Invalid status reports retain the recovered callback-safe `Time` response without
  refreshing durable presence; incomplete registration and country requests fail before mutation.
  Action 13 treats its FCM token as an opaque credential: empty is the exact unregister sentinel,
  while a nonempty value must already be trimmed, control-free, and no longer than 4096 characters.
  Malformed values are rejected rather than trimmed or truncated into a different unusable token,
  and the complete account boundary applies the same rule to both durable mirrors.
  Persisted notification consent must contain exactly the recovered six Boolean
  `SettingsManager.Settings` fields. A wholly absent legacy value boots with LoadEmpty's five
  enabled categories and disabled maintenance default; partial, extra, or non-Boolean snapshots
  fail closed before an unrelated write can normalize them or boot can change effective consent.
  Persisted country and locale receive the same shared-profile proof before authentication or
  publication: country is either the exact empty new-account sentinel or an upper-case two-letter
  code, and locale is a trimmed bounded language tag. Request handlers still normalize new input,
  but durable lower-case/padded/free-text damage is rejected instead of silently rewritten by a
  later country, language, or device-registration action.
  The same boundary proves DTO-only public scalars before gameplay can consume them: `Level` must
  select one exact 4.9.5 rank row; Reputation is a nonnegative signed-client integer; SendLogs is
  exactly 0/1; awaiting-Squad state is Boolean; LastAction is a nonnegative signed-int Unix second;
  and the War Arena crown tuple uses only empty/bronze/silver/gold/flawless plus a signed-int expiry.
  This makes malformed state fail before squad-card arithmetic, level-gated economy selection,
  presence, or public projection rather than relying on the final numeric wire adapter.
  Equality of duplicated root/profile counters is not sufficient: Army Power must be finite and
  nonnegative with a signed-int truncation result, lifetime Experience must be a nonnegative safe
  integer, and Squad Points must be a nonnegative signed-client integer. This rejects matching
  `NaN`/`Infinity` or overflow in both copies before authentication, matchmaking, leaderboards, or
  settlement while retaining the server's documented fractional Army Power storage.
  That shared proof also validates the full Player League admission tuple before any authenticated
  gameplay handler can use the account: beginner tier is source-bounded, normal tier is supported,
  RemainingMatches is exactly zero or one, and MedalsBalance/Skill are nonnegative safe integers.
  Corrupt league authority therefore cannot enter matchmaking, survive tutorial repair, or wait
  for a later boot/ranking path to discover it.
  The same profile proof restricts `PlayerStatus` to Offline/Online/InGame and `SquadRank` to the
  five recovered values before authentication, publication, or mutation; a heartbeat must never
  overwrite an unknown stored status and conceal durable damage.
- **Platform identities**: Facebook, Google Play, and Game Center identities have unique
  ownership, HMAC-protected credentials, provider login, collision-safe link/update, and
  unlink behavior. Every link, relink, and unlink transaction commits the authoritative identity
  row together with its sparse player mirror and active AccountType; unlink preserves a surviving
  active provider or selects the oldest remaining identity deterministically before falling back to
  Guest. Provider login and open existence checks require that row's player/external IDs to match
  the exact connected player mirror, reject orphan/disconnected rows, and re-read plus reverify the
  final credential after comparison so a concurrent unlink, relink, or rotation cannot authenticate
  a stale owner. Provider selection consumes only the shared exact AccountType parser; malformed
  input remains outside every provider index and credential-digest path. Facebook IDs retain the
  stock C# signed-`long` contract as canonical invariant
  strings, including values above JavaScript's safe-integer range; malformed/out-of-range text and
  the reserved disconnected value `-1` cannot create or resolve an identity. Every shared identity
  lookup also validates the complete row: exact provider/external ID, bounded owner, canonical
  64-character lower-case HMAC, exact bounded control-free display name, and ordered finite audit timestamps. Request
  parsing keeps IDs and opaque credentials as exact strings, rejects conflicting uppercase
  and camel-case aliases, and never converts a JSON number into an identity key. The recovered
  `RemoveOrUpdateGC.haveGcId` selector accepts only exact string `0` or `1`, so missing or malformed
  input cannot silently unlink a valid Game Center account.
  Provider display metadata follows the same exact boundary. Recovered Facebook and Google Play
  links require a nonempty `Name`; Game Center builders send no name and store the exact empty
  value. A diagnostic `PlayerName` may only accompany and byte-for-byte agree with canonical
  `Name`. Numeric, padded, control-bearing, and over-100-character names fail before transaction
  work, and the shared identity service stores the validated string without trim/slice conversion.
  Complete durable identity validation applies the same shape before login or existence results.
  First-time `CreateGcAccount` revalidates its opaque Game Center ID without trimming at the shared
  account service, commits the player and identity in one transaction,
  returns separate platform/session credentials, and supplies the recovered `15400` existing-account
  profile contract. Remaining response-contract work is tracked in `BACKEND_FEATURES.md`.
- **Transport abuse boundary**: Express requests use a bounded per-address token bucket and the
  `/hub` WebSocket uses an independent continuous-refill bucket before JSON parsing. With Redis,
  both are atomic across nodes and use Redis server time; authenticated sockets share one
  HMAC-hidden player bucket across reconnects and addresses. Redis outages fall back to the bounded
  local buckets. The WebSocket decision is serialized with gameplay messages before JSON parsing
  or gameplay work. The WebSocket parser rejects frames above the configured 64-KiB
  default, rejected bursts receive `RateLimited { RetryAfterSeconds }`, and repeated consecutive
  violations close with policy code `1008`. All seven HTTP/WebSocket limits resolve together once
  during module startup; an unsafe environment value stops startup before a listener accepts it.
- **Bootcamp/tutorial lifecycle**: authenticated actions `119` and `120` persist one
  server-issued tutorial battle receipt and consume it only for the recovered Win end reason.
  Action `120` parses `EndReason` through the same exact nonnegative invariant-culture C# `int`
  decimal boundary as `GameEnded`; coercible nulls, Booleans, arrays, blanks, alternate numeric text,
  and oversized values fail before the Win gate or any starter mutation. Replacement JSON clients
  may send the same integer value as a number.
  Completion establishes the XOR-decoded MainScene minimums of 75 Gold and 15,000 WarBucks,
  starts the single placement match, and restores the presence-sensitive `TutorialData` marker
  on every later `GetPlayerData`. Client-echoed score, boxes, cards, wallet, and Army Power are
  ignored because the offline tutorial cannot prove them. Retries cannot refill spent currency;
  old no-receipt accounts may migrate once only with the stock empty `BattleId`. Bootcamp and
  Play-Warcards completion markers are validated together as exact ordered Booleans at the shared
  progression read/publication boundaries and at every tutorial, rental, and boot boundary. Both
  optional receipts must contain exactly a bounded, control-free battle ID and a safe Unix start
  time; terminal phases cannot retain a consumed receipt, and real lifecycle writes reject revision
  overflow. Shared transaction validation is deterministic; boot and gameplay additionally compare
  receipt issuance with their authoritative request time so a future receipt never becomes proof.
- **Play Warcards tutorial**: the later onboarding battle unlocks at the recovered display
  level 6 and runs through the ordinary offline-bot action `64`/`62` path. The server projects
  `PlayerAnalyticsData.cardTutState` from durable state, binds `TutorialWarcards=1` to the earlier
  BattleId receipt, ignores forged `ObtainedCards`, and grants the exact MainScene
  `TutorialRewardCards` list once: `CLUSTERGRENADE`, `ELITEPARA`, `HEAVYTURRET`,
  `ELECTRICTRAPS`, and `SABOTAGE`. Losses complete it just like the recovered client; explicit
  Forfeit grants nothing, clears the attempt receipt, and leaves the tutorial available to retry.
  A terminal Play-Warcards marker without a completed bootcamp fails closed instead of projecting
  the otherwise contradictory `cardTutState = 2`.
- **HTTP abuse boundary**: every non-health API request passes through a continuously refilled
  token bucket keyed by an HMAC-hidden client address. Redis provides bounded-TTL cross-process
  enforcement, while the memory-bounded limiter remains the explicit outage fallback. Proxy
  addresses are trusted only when `TRUST_PROXY_HOPS` is explicitly configured as the exact zero-to-32
  reviewed topology distance; rejected bursts receive HTTP 429
  and `Retry-After` without reaching request parsing or game handlers. HTTP capacity (1-100,000),
  window (1-86,400 seconds), and memory entries (100-1,000,000), plus WebSocket capacity/window,
  payload (1,024-1,048,576 bytes), and violation tolerance (1-100), resolve together as one
  immutable eight-value exact-safe-integer snapshot. Express and the WebSocket listener capture
  that same snapshot for forwarded client identity, parser, bucket, and disconnect behavior.
  Malformed deployment policy fails startup instead of
  being rounded, clamped, defaulted, or independently re-read.
- **Photon-region profile compatibility**: action `140` validates and atomically persists the
  recovered ten-region latency dictionary plus `None`/`Cellural`/`Wifi` connection type.
  Public `DatabasePlayer` snapshots restore the exact `Regions: { S: "..." }` contract used by
  stock challenge/PvP code to choose the lowest combined-latency region. These client-measured
  values remain routing hints and never authorize a match result or gameplay reward. The shared
  stored-profile boundary revalidates every key, integer 0-60000 ms latency, and exact numeric
  connection enum before authentication, presence mutation, or publication, then rebuilds public
  JSON in recovered region order. Only total field absence on a pre-recovery account maps to an
  empty region dictionary and `None`; partial or malformed durable metadata fails closed rather
  than being dropped or overwritten by an unrelated heartbeat.
- **Feature-introduction persistence**: parameterless actions `163`, `168`, `169`, `180`,
  `182`, `183`, and `213` now require authentication and monotonically persist the recovered
  chat, customization, Warpath, card-pool, league-leaderboard, crafting, and Elites booleans.
  The complete snapshot is validated at shared progression read/publication as well as mutation
  and boot, so malformed truthy values cannot survive an unrelated economy replacement.
  `GetPlayerData` restores all seven through `PlayerAnalyticsData`, preventing onboarding UI
  from repeating after reconnect or reinstall. The complete stored snapshot permits only those
  seven keys and Boolean values before mutation or boot; missing legacy flags default to false,
  and a real false-to-true write validates progression revision before incrementing it. Action
  `182` was corrected from an unrelated
  top-Squads response to its real `leagueLeaderboardsShown` write. The broad action `179` blob
  remains non-authoritative because it also contains client-controlled economy and progression
  counters. Optional diagnostic ingestion is described below; it never mutates player state.
- **Squads (core membership)**: create / unique-name check / public or requested join /
  invite / accept / decline / promote / demote / kick / leadership transfer / guarded
  leave, plus details and full member snapshots. Client ranks exactly mirror
  `Member`, `Veteran`, `Leader`, and `Coleader`. Creation uses the exact decoded linear
  `25 * (count + 1)` WarBucks price; a shared signed-client count/price validator runs at
  progression read/publication, mutation, and boot, and wallet, revision, and the next count validate before the atomic
  squad/debit write. Creation, unique-name checking, and leader-event notification require the
  exact recovered `SquadId` rather than borrowing names from join, rename, or generic `Id` fields.
  Action 37 also requires its complete `Icon`, `IsPublic`, and `SkillRequirement` payload before
  any transaction; action 131 requires `IsPublic` and `RequiredMedals` while deriving the mutable
  Squad only from authenticated membership. Create and update treat those admission settings as
  exact assertions at both the HTTP adapter and service boundary: join policy accepts only integers
  0 through 2, required medals accepts only a nonnegative C# signed `int`, and the legacy `IsPublic`
  projection accepts only exact Boolean representations. A replacement `JoinPolicy` may accompany
  `IsPublic` only when both map to the same policy. Decimal form values are canonical and
  client-width-bound; padding, plus signs, leading zeros, alternate negative zero, fractions,
  exponents, oversized values, missing mandatory creation/update fields, and conflicting policy
  aliases fail before mutation, while Boolean text is neither trimmed nor case-folded.
  Action `101` retains its legacy `GetSquadsByExperience` name, but the recovered all-time screen
  sorts and displays wire `Skill`, which this backend projects from authoritative `squadPoints`.
  The global page is therefore admitted by `(squadPoints descending, squad name ascending)` through
  a matching compound index; every full Squad snapshot, result cap, and returned order is checked
  before serialization so lifetime experience cannot displace a higher competitive score.
  Action `79` now applies its recovered literal `SquadNameStart` prefix instead of returning that
  same leaderboard. Action `81` validates the client `Skill` echo against the authenticated
  profile, then recommends only non-full open/request-required squads whose `requiredMedals` the
  player's global `skill` satisfies. Final join/request admission uses that same global value;
  weekly Player League `medalsBalance` is not interchangeable. Because neither recovered Squad
  documents nor requests identify one authoritative country for a multi-member Squad, both reads
  return `IsLocal=false`; the stock UI may use its global fallback and no locale is fabricated.
  Although the stock projection collapses request-required and invite-only to `IsPublic=0`, the
  server keeps their policy authority separate: policy 1 stores a bounded manager request, policy
  2 rejects an uninvited request, and an already invited player is routed through the atomic join
  transaction so the invitation is consumed exactly once. Capacity always uses the validated
  stored `maxMembers`; no missing/falsey default can alter an admission decision. New squads start
  with the four-member capacity from 4.9.5 `Squads` row 1. The extracted 50-row progression table
  binds each one-based rank to `EXPERIENCE`, `SIZE`, and `CARDPOOLSIZE`; complete Squad validation
  requires current progress to remain below its next threshold and capacity to equal the same row.
  Both extraction and runtime loading require exactly the recovered contiguous 1-50 sequence,
  monotonic thresholds/unlocks, and exact equality with the duplicate
  `cardPoolRules.capacityBySquadLevel` array. A truncated or internally split generated artifact
  therefore stops startup rather than silently lowering maximum rank or granting a different pool
  capacity through another consumer. The dependency-free 50-row validator is owned by the complete
  card-catalog authority, and Squad gameplay consumes that exact frozen snapshot. It no longer
  imports and separately accepts the raw JSON subset, so invalid provenance, cards, packs, or other
  shared economy fields cannot coexist with an independently accepted rank table.
  Card-pool admission uses that exact rank row too; unlike the recovered UI helper, it never floors
  or clamps an invalid durable level into a believable first/final `CARDPOOLSIZE` authorization.
  A new policy-1 request transaction advances both the exact Squad revision and a strictly
  monotonic player-account revision. That player write serializes request creation against every
  membership transaction: a winning join makes the retried request observe membership and fail,
  while a winning request is visible to the retried join's cross-Squad cleanup. An identical
  already-pending request remains a read-only replay and cannot recreate a concurrently removed row.
  Action `59` proves manager authority before looking up the requested player, then creates only a
  bounded future-admission capability. A target already owned by any Squad is rejected through the
  recovered `13301` callback with its `PlayerId` and current Squad `Name`; an exact retry for an
  already pending target returns the same Squad snapshot without advancing `updatedAt`. Its request
  accepts only recovered `PlayerToInviteId` and derives the mutable Squad from authenticated
  membership. Every new invitation, including a missing legacy type-1 row materialized from its
  queue, advances the target's strictly monotonic account revision in the same transaction. That
  real player write serializes invitation creation against a concurrent join, while an identical
  active invitation remains a no-write replay. Action `133` likewise requires its exact recovered
  `SquadId` and `PlayerToJoin` pair;
  neither boundary accepts generic aliases belonging to promotion, kick, decline, or another action.
  Action `181` follows its recovered misleading form names exactly: `MessageId` is the applicant
  player ID and `Id` is the manager's current Squad name. The handler binds that Squad assertion to
  authenticated membership before removing only the named pending row. Replaying an already
  completed decline returns the current Squad without advancing `updatedAt` or invalidating another
  manager's otherwise fresh optimistic snapshot.
  The remaining core endpoints no longer share the generic Squad-name alias parser. Action `38`
  requires `NewSquadId` and retains its optional invitation `MessageId` as a separate field; action
  `132` requires `SquadId`; actions `45`, `151`, and `44` require `SquadId`, with action `44` also
  validating the recovered `CheckMessages` value as exact `0`/`1`. Leave (`49`), settings (`131`),
  and emblem (`63`) requests carry no Squad identity, so those mutations derive the only writable
  Squad from authenticated membership; emblem accepts only the recovered `Icon` field.
  Action `59` now commits its pending player and exact recovered type-1 `SquadInvitation` inbox row
  together, returning the existing active message on retry. The row serializes the `Squad` and
  `OtherPlayer` DynamoDB-style JSON strings consumed by `HLHBMMCBHJF`, uses the Squad-status Firebase
  consent, and is published locally/cross-node only after commit. One partial unique index permits
  only one active recipient/Squad generation. FightDialog's generic decline atomically marks that
  row read/ignored and removes the pending capability. Action `38` binds optional `MessageId` to the
  authenticated recipient and requested Squad; acceptance commits membership, queue consumption,
  and a read/ignored/accepted terminal marker in one transaction. A lost response can replay only
  when that terminal message and current roster membership agree. Action `132` has no MessageId, so
  it consumes a matching active type-1 row when present while retaining a bounded legacy migration
  for pending invitations created before durable message delivery existed. Every successful join
  also resolves the player's bounded set of other pending admission capabilities through indexed
  invitation and embedded join-request lookups, validates all selected Squad and message rows
  before writing, then removes the player from every other invitation/request queue and marks every
  other active type-1 row read/ignored in the same membership transaction. Leaving later therefore
  cannot reactivate an invitation or manager approval issued before membership in another Squad.
  Rank and removal mutations are equally action-specific: promote/demote accept only their recovered
  target field and canonical `OldSquadRank`, leadership transfer accepts only `PlayerToPromoteId`,
  and kick accepts only `PlayerToKickId`; all derive the mutable Squad from authenticated membership.
  The old-rank assertion is checked against the same roster snapshot as authority, so a lost-response
  retry returns the stock `5501`/`5801` member-list rollback instead of applying a second rank step.
  `RemoveUserFromSquad` action `42` is response-only: recovered code listens for it as a UI event but
  never sends it. It is deliberately absent from the inbound handler registry, leaving action `172`
  as the sole authenticated manager kick mutation.
  Malformed or blank input is rejected instead of floored, broadly coerced, silently ignored, or
  replaced by a default. Every core membership, settings, invitation, join-request, PvP Squad
  Point, and Squad War write advances `updatedAt` through one shared strictly monotonic helper,
  including operations in the same wall-clock millisecond. Single-document replacements also
  compare the exact validated prior snapshot that authorized them; a concurrent demotion,
  roster edit, or admission change forces a fresh read instead of letting stale manager authority
  overwrite the winning state. Kick persists the exact type-3 offline
  notification in the membership transaction. The operational integrity audit reports duplicate
  rosters, broken founders/leaders, and missing accounts; repair mode changes only unambiguous
  player mirrors and safely returns orphaned normal card deposits.
- **Squad Wars**: the backend creates deterministic weekly UTC seasons and persistent divisions
  for all eight recovered levels, with at most 50 squads per division. `GetSquadWarsDivision`
  derives the caller's division from authenticated membership, rejects stale or foreign round
  IDs, and returns the exact recovered `LeagueId`/`SquadWarsId`/`Items` contract. Its request reads
  only the recovered canonical `RoundId` field and preserves that server-authored ID byte-for-byte;
  numeric, alias-only, padded, malformed, and control-bearing values fail before division lookup
  instead of being trimmed or coerced into another placement authority. Every season row
  is validated before allocation, retry classification, division reads, and scheduler closure:
  exact fields, an ID bound to its UTC start second, a safe window of at least one hour, creation
  inside that window, and an exact active or terminal timestamp shape. Future durable timestamps
  fail on live paths, and settled windows cannot reopen after a configuration-duration change.
  Calendar derivation itself requires a valid nonnegative client-width Unix time and the immutable
  startup duration from the shared competition-timing snapshot: an exact one-hour-through-signed-
  client-int value whose resulting end remains client-representable. Every allocation, read, and
  settlement path uses that same value; invalid policy cannot be floored/clamped, change inside one
  process, or produce an `swNaN` season.
  Every complete division row is likewise proved before creation, assignment/pointer repair,
  scoring, eligibility mutation, reads, placement, or settlement. Its exact round ID, season
  window, level/division, bounded unique squads and members, safe counters, revision and dates,
  active/settled shape, and one-to-50 entry/member bounds must agree; each shared score must equal
  the sum of its member contributions. Post-window leave/kick eligibility may retain an audit
  update during scheduler delay, but the separate half-open scoring proof still blocks points.
  Only a confirmed
  ranked PvP win adds server-derived Squad Points, and that score commits in the same transaction
  as the terminal match receipt. Participant squads created after the season snapshot are assigned
  before rewards begin, without requiring the War UI to be opened first; stale round pointers are
  repaired from the authoritative round entry, while duplicate, missing, or out-of-window entries
  reject settlement for retry. An enabled season that is still being allocated/settled, or a
  database error while preparing it, likewise rejects the match before rewards start. A leased
  scheduler settles expired divisions exactly once,
  applies the source-exact 4.9.5 placement/reward/promotion rules, and sends each eligible
  round-start member who remains in the squad an exact type-9 `SquadWarEnd` message whose Gold is
  claimed once through action `91`. Leaving or being kicked irrevocably forfeits that round's
  personal reward, while late joiners may add confirmed placement score but receive no first-week
  reward. Settlement validates every squad/member score and addition as a nonnegative safe integer
  before the terminal PvP receipt commits, and placement rejects non-finite or overflowing totals
  before sorting. It also completes the exact 4.9.5 group-19 first-Squad-War achievement for each eligible result
  recipient in the same transaction. Its single 5,000-WarBucks tier is replay-idempotent. The
  weekly Monday calendar is explicit reconstruction policy because neither recovered APK contains the
  retired production schedule; no client-supplied score, placement, reward, or squad ID is trusted.
  Maintenance and new-window allocation deliberately query malformed/missing date and status shapes
  in addition to normally expired rows. Complete round and season batches validate before the first
  settlement write, every non-settled round blocks season closure, and the final closure must win one
  exact compare-and-set; BSON comparison cannot hide damaged scheduling authority permanently.
- **PvP (WebSocket `/hub`)**: identify → `FindMatch` (matchmaking pairs by army-power within
  a widening league window) → `MatchFound` → `JoinMatch` → `MatchStart` → in-match
  `MatchEvent` relay to the opponent → `MatchResult`. Room joins/events are restricted to
  recorded match participants. Every decoded client message first requires an exact root envelope:
  one bounded trimmed control-free string `Type`, only optional opaque `Payload`, and no aliases or
  extra root keys. Message-specific validation then owns Payload; malformed roots never reach
  logging or dispatch. WebSocket settlement requires matching reports from both
  participants, and the database settlement claim is idempotent. The terminal transaction now
  includes daily PvP assignments, ranked-win/squad-point achievements, and both the squad total
  and embedded member contribution. The same transaction now advances the Squad's recovered
  64-bit `LevelExperience`, subtracts every crossed rank threshold, and publishes the target row's
  roster capacity. `AANECPGDMGM` receives that progress through `LevelExperience` instead of the
  former hard-coded zero, so `SquadStatsContent` renders the real rank bar and card-pool/roster
  unlocks follow the same source row. Each crossed rank also creates a deterministic match-UUID-bound type-10 row
  for every current member in that transaction. The recovered `KGALJDLJCEH` parser requires only
  `Level.N` and `SquadId.S`; its real virtual appearance callback adds one to Level, so the server
  stores the prior one-based rank and does not attach an invented reward or claim. A crash therefore
  cannot commit the immutable reward receipt while losing one of those client-visible counters or
  notifications, and a finished-match retry cannot count the battle again. Lifetime Experience and Squad Points are checked against their storage bounds and
  written as literal precomputed successors rather than unchecked MongoDB `$add` expressions. The
  canonical progression and complete projected account, including root mirrors, league identity,
  Army Power, presence, and audit time, are proven before the first participant write. Match
  creation inserts the
  durable row and reserves both current profiles as `InGame` in one MongoDB transaction; duplicate
  participants, corrupt snapshots, missing accounts, and concurrent active-match claims fail
  without partial state, and still-eligible connected players are restored to the bounded queue.
  Admission loads and validates each complete durable account before it trusts queue snapshots or
  writes status, so a narrow projection cannot conceal malformed credential, profile, or progression
  authority and then normalize the damaged account through the `InGame` reservation.
  With Redis available, queue deduplication, stale cleanup, bounded candidate selection, pairing,
  removal, and failed-admission restoration execute atomically across backend nodes. Queue writes
  first validate the exact four-field snapshot, including bounded identity, finite nonnegative
  signed-client-safe Army Power projection, a real Bronze3-through-Champion tier, and a positive
  safe enqueue clock; complete recovery batches validate before deduplication or mutation. The Lua
  reader uses protected JSON decoding, proves the same field/type/range contract, binds the payload
  identity and timestamp to its sorted-set member and score, and removes both halves of a malformed
  transient row so it cannot block every healthy search behind it. MongoDB profile reload and the
  transactional two-player reservation remain final admission authority. `MatchFound`
  can be relayed to the opponent's node through a bounded pub/sub instruction, but that receiving
  node re-reads the complete validated match before sending anything to its socket. Redis notices
  require exact root, envelope, and type-specific payload shapes; opponent name, room-start state,
  terminal winner/reason, result-conflict reason, and disconnect status must reproduce MongoDB.
  CardPlayed also must equal the authenticated source's durable sequence/card evidence, with a
  bounded receiving-node receipt suppressing repeated pub/sub effects. Opaque non-card events remain
  non-authoritative transport. A closing local socket is not counted as a successful delivery, and
  committed join-timeout or initial-delivery cancellation reaches remote participants through this
  same validated path.
  Queue, post-pair join, reconnect grace, and REST result consensus now resolve once during module
  startup as one immutable timing snapshot. The first three must be positive safe integer seconds
  whose millisecond delay fits Node's timer range. The same frozen queue value owns local scheduling
  and Redis stale cleanup, and the same disconnect value owns local/distributed resolution. Result
  consensus is an exact 0-through-15,000 milliseconds and its frozen value is every REST bridge's
  default; zero disables waiting. Malformed values stop startup instead of being floored, clamped,
  re-read into one match, or replaced by a hidden five-second wait.
  Without Redis, the same code retains the verified process-local queue and direct delivery path.
  Its room registry accepts only an exact two-distinct-player allowlist reproduced by every join and
  enforces one room per authenticated player. Contradictory overlapping pairs and second-room joins
  fail before room creation, preventing ghost participants that close cleanup would otherwise miss.
  Active lifecycle state is retained during reconnect grace, but generic and CardPlayed relay both
  require the complete connected pair and cannot acknowledge an event delivered to no opponent.
  Local admission preflights that registry without mutation, persists the authenticated participant
  through the same `joinedPlayerIds` and one-time `roomStartedAt` transition used across nodes, and
  only then attaches the socket. A contradictory post-write local interleaving cancels and releases
  the pair rather than preserving a durable started room with no matching transient authority. The
  activating handler sends `MatchJoined` before local `MatchStart` fan-out, matching the distributed
  transport and preventing gameplay from starting ahead of its own admission acknowledgement. A
  pre-start disconnect may leave an idempotent durable join entry, so the activation winner also
  requires both exact local room participants before fan-out; a one-socket activation is cancelled
  atomically and both profiles are released.
  Match rows record their coordinator node, whose renewable Redis heartbeat separates crashed-room
  orphans from live peer-owned matches. When Redis coordination is selected, startup must commit
  that node's first heartbeat before it may create any durable match naming the owner. Startup and
  periodic recovery cancel confirmed orphans and repair only unprotected `InGame` profiles; an
  unknown Redis observation is conservatively retried. Recovery reads owner and PTTL in one Lua
  operation: only the exact coordinator with a remaining one-to-30-second lease is alive, the exact
  missing tuple is dead, and malformed, non-expiring, overlong, or incoherent state is unknown.
  Distributed `JoinMatch` writes authenticated participant membership idempotently to MongoDB. The
  request that atomically completes the assigned pair writes `roomStartedAt` once and fans a
  MongoDB-validated `MatchStart` to both nodes only after both assigned expiring Redis socket routes
  are definitely present. A missing or unknown route cancels that unproven activation without
  rewards, preventing stale pre-start `joinedPlayerIds` from starting one client; late join-timeout
  callbacks cannot cancel a separately proven live activation.
  `CancelMatch` removes an ordinary queue entry when one still exists. After pairing has already
  consumed that entry, it instead resolves the authenticated caller's validated unstarted match,
  atomically cancels the pair and releases both `InGame` profiles, then sends the MongoDB-bound
  no-reward terminal reason to both nodes. The same cancellation reason requires
  `roomStartedAt` to remain absent inside the transaction; a started room returns `AlreadyStarted`
  and must use normal result or disconnect-forfeit handling.
  In-match fan-out is source-bound and requires both durable joins. Card activations store ordered
  evidence separately from the successful live-delivery receipt. Redis publish success is only
  transport acceptance: the node owning the opponent socket writes the receipt after its actual
  socket send, and the sender waits a bounded interval for that MongoDB acknowledgement before
  returning `MatchEventAccepted`. A missing receipt returns `EventDeliveryFailed` and keeps the
  evidence retryable. The receiving process suppresses an already-sent effect while retrying only
  a failed marker write, and independently requires the same durable sequence/card identity before
  delivery. Results use MongoDB's two-party consensus and
  terminal settlement before `MatchEnded` or `ResultConflict` is delivered across nodes. The same
  durable decision controls the process-local room path: its report map proves only current socket
  membership, while every post-write reload recognizes finished receipts and conflict
  cancellations. A concurrent local pending/conflict observation therefore cannot suppress a
  committed terminal event, and cancellation-versus-settlement races notify clients from the row
  that actually won the MongoDB transition. An assigned authenticated participant may recover a
  lost terminal response after transient room cleanup, but cannot use that path to bypass active
  room membership. Result conflict clears every join/disconnect timer and removes the local room
  only after broadcasting the cancellation, preventing further relay against a cancelled row.
  Every distributed socket also owns a renewable Redis route that an older/replaced socket cannot
  refresh or delete. `Identify` enters this mode only after the exact player/socket owner write
  succeeds. Deliberate Redis-unavailable operation stays on the local-room path, while an attempted
  but failed ownership write rejects only the new socket with a retryable coordination error and
  does not evict the older valid login; ambiguous cleanup compare-deletes only the prospective new
  owner. One socket may complete `Identify` only once, so a second account cannot inherit a live
  transport while the first account's route still points to it; account switching reconnects. A
  real close writes a durable disconnect clock and notifies the opponent;
  `JoinMatch` compare-clears that exact clock on re-entry, so it cannot erase a newer disconnect.
  Grace expiry grants a forfeit only while the opponent remains
  connected, cancels when both are offline, and waits rather than guessing when Redis is unknown.
  The liveness decision atomically reads the route and its PTTL, accepting only the exact
  instance/client UUID pair with a remaining one-to-30-second lease. A malformed, non-expiring,
  overlong, or incoherent Redis value is unknown and cannot become proof for a forfeit reward.
  The grace callback also binds the loser's exact disconnect timestamp inside the MongoDB reward
  transaction; a reconnect or replacement marker makes the stale callback a no-op without client
  notification or timer cleanup.
  The no-Redis active-room close path persists the same markers. Both transport modes require one
  exact marker per assigned participant and recheck the complete timestamp snapshot inside the
  cancellation transaction before a both-offline result can release presence; missing or changed
  authority waits another grace window. Reconnect clearing requires the exact marker returned by
  its durable join snapshot and compares it after reload plus in the update filter, preserving a
  newer marker when the same socket closes again while `JoinMatch` is still in flight.
  Cancellation likewise commits the terminal match and both presence releases together. On a
  single-node restart, active/settling matches are cancelled and all residual `InGame` profiles
  are repaired in the same transaction, including legacy partial cancellations. Before those
  writes, the server validates every complete current account and the projected presence snapshot.
  Cancellation requires the exact two assigned IDs and checks that MongoDB matched both; restart
  repair freezes its exact stale-player set and checks that every selected row was matched. Missing
  or damaged accounts abort the transaction instead of being concealed by a partial bulk update.
  Replacement clients send an
  inventory-consuming activation as `MatchEvent { Event: "CardPlayed", Data: { Sequence,
  CardId } }`. `Sequence` must remain an exact JSON integer number from zero through five; null,
  Boolean, blank text, numeric text, arrays, fractions, and non-finite numbers cannot coerce to
  sequence zero. `Data` contains exactly those two fields and `CardId` must be a string within the
  shared terminal-list identity bounds; nested aliases, missing fields, and extra targeting claims
  fail before persistence. Local and cross-node paths reuse that one canonical pair. The server
  validates the authenticated owner's complete candidate list, durably
  appends contiguous evidence before relaying the effect and acknowledges exact retries without
  relaying twice. After the opponent socket send, both local and cross-node paths append the same
  contiguous durable delivery prefix. Terminal `UsedCards`, ordinary settlement, and disconnect
  forfeits reproduce and consume only that prefix; evidence persisted before a failed handoff is
  not inventory authority. The shared match validator rejects delivery gaps, reordering, and
  reports exceeding proof. Per-socket serialization prevents a sender's result from overtaking its
  last card event. Players move from
  `InGame` back to `Online`. Disconnects allow a configurable reconnect grace period,
  then resolve as a forfeit or no-reward cancellation; interrupted matches are recovered
  on server restart. Photon-era `GameEnded` reports interpret the recovered `EndReason`
  enum and require matching durable reports from both assigned participants before rewards. One
  exact nonnegative C# signed-`int` parser now protects `EndReason` and `MissionIndex` across every
  tutorial, Arena, mission, friendly, and ranked branch; coercible JavaScript values and values
  outside the client width fail before settlement. Optional replacement `WinnerId` is only an exact
  assertion of the participant derived from a supported recovered `EndReason`; explicit malformed,
  contradictory, or unsupported-outcome aliases fail before a durable result report is written.
  Stock `UsedCards` JSON strings and replacement native arrays share one strict parser across REST
  `GameEnded` and both local/distributed WebSocket `MatchResult` paths. Only an actually omitted
  replacement field means an empty list; explicit null, Boolean, number, object, malformed JSON,
  oversized, or invalid list input fails before result consensus rather than being nullish-defaulted
  into a zero-consumption report.
  WebSocket `MatchResult` also validates its complete runtime wrapper before any local-room or
  MongoDB lookup: bounded `MatchId` and `WinnerId` are required, only optional `UsedCards` and opaque
  non-authoritative `Stats` are allowed, and missing identities, alternate-case aliases, or extra
  fields fail instead of relying on a compile-time TypeScript cast.
  `JoinMatch` and `MatchEvent` now use the same rule before durable admission or relay. Join permits
  only one bounded `MatchId`; event requires bounded `MatchId`/`Event` and only optional `Data`.
  Unknown event Data remains opaque and cannot affect gameplay state, while `CardPlayed` continues
  through its exact sequence, card identity, live-delivery, and terminal-prefix authority.
  WebSocket `Identify` validates exactly one bounded `PlayerId`/`Token` pair before authentication;
  missing values, whitespace/control characters, alternate-case identity aliases, password aliases,
  and extra keys fail. The authentication service remains the cryptographic proof, while the exact
  wrapper prevents competing descriptions of the socket's immutable account binding.
  The stock `BattleId` and replacement `MatchId` fields likewise identify one lifecycle without
  precedence: every present alias must be a string and two present aliases must be identical.
  True total absence and the legacy empty BattleId still reach feature-specific tutorial migration,
  while explicit null, non-string, blank-versus-nonblank, or conflicting IDs fail at the boundary.
  Action `29` remains the presence heartbeat for non-ranked modes, but its active-match read and
  profile write share a MongoDB transaction. An active/settling ranked reservation always wins
  over a forged or early `Online`/`Offline` report. The same transaction validates the full durable
  account before changing status or `updatedAt`; a heartbeat cannot repair or overwrite around
  malformed account authority through an ID/status-only projection. Its response always includes
  the recovered `Time` Unix second read unconditionally by the stock callback, and a valid report
  writes `Status` plus `LastAction` as one snapshot. Account creation and every server-owned ranked
  transition (admission, settlement, cancellation, and restart repair) also publish both fields in
  their existing transaction. This preserves `DatabasePlayer.GetRealStatus`'s recovered 2700-second
  freshness rule; an invalid status enum receives callback-safe time but cannot refresh durable
  presence. The request status must be one canonical recovered decimal integer; missing/null,
  Boolean, array, blank, space-padded, leading-zero, fractional, or exponent forms cannot become
  Offline or Online through JavaScript coercion.
  One complete durable match validator now guards creation and every read, transition, projection,
  or replay used by room admission/start, disconnect and presence authority, card relay/delivery,
  result consensus, moderation correlation, restart recovery, cancellation, and settlement. It
  requires one UUID, exactly two distinct bounded server snapshots, participant-only unique joined/
  disconnect/report/card maps, safe ordered dates, and mutually consistent active, cancelled, or
  finished fields. The complete two-player join set and the one-time `roomStartedAt` marker form
  one indivisible gameplay boundary: disconnect markers, result and used-card reports, relayed card
  evidence/delivery, and every finished reward row require both. Card/result mutations and the
  terminal update repeat that proof in their MongoDB compare-and-set filters, so a direct service
  call, stale read, timestamp-only row, or pre-start pairing cannot manufacture settlement. A
  no-reward join-timeout or participant cancellation remains valid before that boundary. A
  finished row must retain two exact participant reward receipts whose safe
  counters, VIP component multipliers, streak/league/level/lootbox/rental state, winner, reports,
  and optional participant-complete Squad Event/War projections agree. Projected successors are
  validated before writes. Only an absent legacy `rentalSettled` marker may enter the existing
  idempotent repair path; false markers and rental payloads without the marker fail closed.
  Participant IDs containing MongoDB `.` or `$` path syntax are rejected
  before admission because disconnect, result, and card evidence use participant-keyed subpaths.
- **Offline bot fallback (stock action `64`/`62`)**: `GameControllerDeathMatchOffline` sends
  `IsMatchMaking=1`, `BotId`, `BotName`, and zero-based `BotLevel`, which previously collided with
  the Play Warcards tutorial's bot-shaped start. The server first derives tutorial eligibility
  from durable `cardTutState`; every other source-valid bot-shaped request receives a separate
  participant/battle receipt. Matching `GameEnded` calls settle and replay with a parser-safe
  zero-valued `GameReward`. Bot metadata and combat outcomes are client-simulated, so this path is
  deliberately unranked: it cannot grant currency, XP, medals, league/assignment/achievement/event
  progress, consume War Cards, advance VIP/rentals, or enter two-party match consensus. This makes
  offline gameplay complete cleanly without presenting a forged local win as backend authority.
  Actions `64`/`65` require both recovered lifecycle flags as exact `"0"`/`"1"` form text;
  replacement JSON clients may send actual Booleans. Optional action-62 `TutorialWarcards` and
  `IsWarArena` markers use the same parser when present. Numeric, differently-cased, padded, null,
  or container aliases are rejected before branch selection, rather than becoming false and
  falling into friendly or ranked settlement.
  Entry `UsedGold` and heart `UsedGolds`/`hearthPrice` assertions are revalidated inside the shared
  mutation service as nonnegative C# signed integers. This protects replacement/direct callers as
  well as HTTP traffic: fractions are never floored, oversized JavaScript integers fail, and
  `NaN`/`Infinity` cannot become zero and select a valid free, Ticket, or Gold path.
- **Squad Chat (WebSocket `/hub`)**: after `Identify`, a replacement client sends
  `SubscribeSquadChat` to receive `SquadChatSubscribed { SquadId, Messages }`, using the exact
  recovered three-message history default. When `NextBeforeCursor` is non-null,
  `GetSquadChatHistory { BeforeCursor }` returns the next older page without changing the bounded
  server page size; the opaque versioned cursor combines exact milliseconds and message UUID so
  equal-time rows are not skipped. It sends text with `SendSquadChat { ClientMessageId, Text }`;
  both wrappers reject aliases and extra fields before persistence. History accepts only a truly
  absent payload, an exact empty object, or a string cursor, so explicit malformed cursor presence
  cannot silently request the latest page. Send requires both fields to be strings before the
  shared service applies nonce, text, moderation, membership, quota, and replay rules;
  the server returns `SquadChatMessageAccepted` and delivers a persisted
  `SquadChatMessage` to connected, subscribed current roster members. Player/squad mirrors,
  roster membership, rank, sender name, level, league, and timestamp are all server-owned. A
  sender-scoped 64-character nonce makes reconnect retries idempotent, while moderation,
  single-line validation, an atomic persistent fixed-window rate limit, immediate expiry filtering,
  and a MongoDB TTL index bound abuse and retention. The chat limit uses the same proven counter
  authority as direct messages but a separate HMAC domain, so concurrent nodes cannot pass a
  count-then-insert race and chat cannot consume the inbox quota. Optional Redis pub/sub carries
  only the origin and durable message UUID between hub nodes; receiving nodes reload content and
  the latest roster from MongoDB, suppress duplicate notices, and continue single-node delivery
  when Redis is down.
  Every durable row is validated before insertion, sender-nonce replay, history/cursor publication,
  or cross-node fan-out. It must have exact known fields, a UUID message ID, the sender-bound
  idempotency key, bounded nonce/squad/sender/text, source-valid level/league/rank snapshots, and
  safe ordered dates with one-to-365-day retention. Reads use one captured application time to
  reject future or expired rows. History page size, retention, sender rate, and message length
  resolve once during module startup as one immutable policy snapshot and require exact safe
  integers respectively bounded to 1-100, 1-365 whole days, 1-1,000 attempts per minute, and
  1-2,048 characters. Malformed values stop startup rather than being silently defaulted, clamped,
  or re-read between text admission, rate reservation, durable expiry, and history publication.
  This is a replacement protocol: the stock client still needs its Photon Chat adapter repointed
  to these typed messages.

- **Leaderboards / player leagues**: `GetPlayersByExperience` and squad boards remain
  MongoDB-authoritative with opportunistic Redis warming. The experience cache validates complete
  public rows first, then atomically replaces its bounded sorted-set snapshot and applies one exact
  1-3,600-second startup TTL. Historical top-player IDs cannot accumulate while steady traffic
  keeps the cache alive, and Redis failure never blocks the MongoDB response.
  `GetPlayerLeaguesDivision` now
  materializes a stable UTC season, ranks the exact division by weekly medals, and returns
  `LeagueEvaluation`; confirmed PvP consumes placement; `FinishPlayerLeague` atomically
  promotes/relegates all members and queues the recovered type-23 result/reward messages. The same
  transitions persist exact group-13 league achievement progress (Silver II/Gold I/Master III for
  5/10/20 Gold) from the server-owned profile tier. A background sweep discovers expired managed
  divisions through a grouped, database-limited candidate pipeline and reuses that transaction
  under one crash-expiring MongoDB lease, so historical IDs cannot overflow one unbounded
  `distinct` result, inactive clients do not block settlement, and multiple nodes do not
  intentionally run the same scheduler job. Malformed IDs in the replacement backend's exact
  three-segment `*-local*` namespace are selected and rejected before the first settlement write;
  archived production namespaces remain outside local scheduler ownership.
  Every returned or settled member's weekly medals and global skill mirror must be nonnegative safe
  integers; beginner/normal tier and the recovered zero-or-one placement counter are likewise
  validated before boot, tutorial repair, admission, or PvP progress. One corrupt value aborts
  settlement before any rank, transition, or reward is published. Public account validation also
  reproduces `DatabasePlayer.maxPlayerName`'s 15-character cap and proves that every nonempty
  `LeagueId` would make the recovered first/last dash-segment parser derive the stored tier and
  division. Retired production IDs keep their opaque middle segments; mismatched or malformed
  tuples fail closed instead of making the backend and Unity rank the account in different leagues.
- **Social / messaging**: `SearchPlayers` (name prefix), `GetAllPlayers`, exact Facebook-friend and
  authoritative squad-mate resolution through `GetFriendsInfo`, challenge and normal
  `MessageSent`, `GetAllMessages`, `ReadMessage`, `IgnoreMessage`, and `AcceptChallenge`
  (recipient-owned persistent inbox). Challenges expire logically and through MongoDB TTL;
  identical challenge retries are deduplicated before admission. New direct/challenge attempts use
  one HMAC-hidden MongoDB fixed-window counter per sender, so concurrent backend nodes cannot all
  pass the former count-then-insert race. `OUTGOING_MESSAGES_PER_MINUTE` and the report maximum
  resolve together during module startup as one immutable abuse-policy snapshot; the outgoing value
  must be an exact safe integer from 1 through 1,000 (default 20). Rejected traffic saturates one
  bounded sentinel without extending the original minute, and inactive rows expire after a separate
  storage margin. The
  complete recipient account is validated before a message targets it, rather than trusting an
  ID-only index projection.
  Replacement direct messages use only `ToPlayerId` for their recipient; the common `PlayerId`
  remains exclusively the authenticated actor. `Message`/`Body`/`Text` aliases must agree, and the
  complete bounded control-free body passes normalization and moderation before recipient lookup or
  quota reservation. Invalid or over-500-character text is rejected whole rather than truncated,
  so failed messages cannot probe account existence or consume the sender's valid-message capacity.
  Direct read, ignore, reward-claim, and challenge-accept requests likewise require their recovered
  exact bounded `MessageId`. The dispatcher/account alias `Id` and RequestBuffer field `ObjData`
  cannot substitute for it or redirect which recipient-owned row is mutated; stock buffered ignore
  continues through its separately validated request-data and durable outbox path.
  Once a direct message, challenge, kick, Squad Event notice, or War Card deposit reminder is
  durable, the `/hub` transport pushes an `InboxMessage` envelope to an authenticated recipient on
  the same node and publishes a bounded identity-only Redis hint for other nodes. Transactional
  producers publish only after commit, never from a MongoDB transaction callback that may retry.
  The receiving node reloads the exact recipient/message row from MongoDB, runs the shared
  type-specific authority, excludes already-read/accepted/ignored rows or expired challenges, emits
  the same Dynamo attribute projection as `GetAllMessages`, and keeps a bounded duplicate receipt.
  Redis and socket delivery remain best-effort after persistence; neither can invent content or
  turn delivery failure into message loss because the normal inbox read remains the recovery path.
  Acceptance records its first durable timestamp and is idempotent after a lost response, while
  wrong-recipient, ignored, expired, and non-challenge rows remain rejected.
  The complete type-0 row is validated before insertion, duplicate replay, inbox publication,
  acceptance, and concurrent replay. It requires the exact recovered map/game/region/room/version
  payload and optional mission fields, bounded identities/text and parseable opponent snapshot, a
  sender-and-created-Unix-second-derived ID, and consistent accepted/read/timestamp state with no
  economy fields. The stored TTL must be ordered between one minute and seven days; the deployment
  setting resolves once during module startup as an immutable exact safe integer from 60 through
  604,800 seconds. Fractional, non-finite, negative, and out-of-range settings stop startup rather
  than being floored, clamped, replaced with 24 hours, or re-read per send. Historical rows retain
  their own bounded lifetime because they do not store a policy version. One captured application
  time rejects future or expired invitations independently
  of MongoDB TTL cleanup.
  Action `2` now parses the exact form contract emitted by `BeanstalkServerManager.Challenge` before
  service admission. Required fields cannot disappear into defaults, optional mission fields are
  accepted only when actually present, and nulls, booleans, arrays, blanks, fractional/exponent
  strings, unsupported game types, or invalid regions cannot become believable integers through
  JavaScript coercion. The recent-room retry lookup also compares every participant and payload
  field before replay; changing the map, game, region, version, or mission while retaining a room
  name creates a distinct challenge rather than returning stale invitation metadata.
  Squad create/update likewise parses legacy `IsPublic` only as recovered `"0"`/`"1"` form text
  or an actual JSON Boolean before mapping it to the inverse `JoinPolicy` enum. Numeric, lower-case,
  padded, null, or container aliases cannot silently change a Squad between open and request-only.
  Direct DeathMatch challenges retain the stock Photon handoff: the inviter creates a named room
  carrying `battleID`, the inbox message transports room/region/version metadata, and actions
  `64`/`65` report `IsMatchMaking=0` after both clients join. The backend stores a separate,
  participant-owned lifecycle receipt for that tuple and recognizes challenge `GameEnded` retries
  as successful friendly results with a complete zero-valued `GameReward`. This path intentionally
  cannot enter ranked match consensus or mutate currency, XP, medals, league placement, win streak,
  War Cards, squad points/events, assignments, missions, VIP countdowns, or rental state.
  Each friendly/offline-bot receipt is validated as one complete participant lifecycle before start
  replay, `GameEnded` discrimination, settlement, or terminal replay: only known fields, bounded
  player/battle IDs, action 64/65, one supported kind, safe ordered dates, and the exact 24-hour
  active or seven-day terminal interval are accepted. Only a finished row may carry one recovered
  end reason. Missing `battleKind` remains the explicit legacy direct-challenge migration. Logical
  expiry and the settlement compare-and-set use application time, so delayed MongoDB TTL cleanup
  cannot extend the zero-reward receipt or let it be mistaken for ranked authority.
  `GetFriendsInfo` requires the recovered canonical nonnegative `Count`, bounds the processed
  `FriendN` prefix to 500, and admits only hashes that satisfy the same canonical Facebook signed-`long`
  authority as the connected identity index. `GetAllMessages` now honors stock `MessagesCount`
  before the optional replacement `Limit` alias, keeps the 100-row page cap, and rejects present
  zero or broadly coercible values instead of silently defaulting them. Its response keeps the stock
  `Items` array and adds an optional `NextCursor`; a replacement
  client sends it back as `BeforeCursor` to read older pages. The cursor combines exact
  milliseconds with the message ID, page size remains server-bounded, and every query retains the
  authenticated recipient filter and immediate challenge-expiry rule.
  Every supported durable row is routed through its complete family validator before pagination,
  read/ignore mutation, or DynamoDB serialization. The recovered `HHFHFANGCEJ` constructor parses
  the last dash-separated `MessageId` segment with `Convert.ToInt32`, so challenge, kick, Squad
  Event, Squad level-up, direct type-27, card-deposit, Squad War, Squad Event reward, and Player League IDs now end
  in the same positive Int32-safe creation Unix second. The previous challenge-millisecond,
  bare-UUID, and reward text-final forms are rejected because the stock client cannot deserialize
  them. Types 3/10/21/27/28 additionally bind exact lifecycle flags, recovered payload fields,
  sender/recipient or server-owned Squad identity, source-valid returned-card IDs, retry identities, and
  non-future creation. Recipient plus message ID is unique because stock read/ignore/accept carries
  no stronger row identity; an identical concurrent challenge replays its winner, while a different
  same-second challenge collision asks the sender to retry. Read and ignore validate both the stored row and projected successor inside
  one transaction; an unsupported or damaged row aborts the requested page instead of being
  silently converted into believable generic content.
  The stock buffered `IgnoreMessage` path records a durable progression outbox entry beside
  `BufferId`, performs the recipient-filtered inbox update, and clears the entry afterward, so
  a process interruption is recoverable without allowing one player to hide another's message.
  The replay cache and outbox are validated as complete bounded authority before lookup, read,
  acknowledgement, or publication: BufferIds and message IDs are unique, trimmed, control-free,
  and length-bounded; replay timestamps are safe Unix seconds and cached results parse as bounded
  response arrays. Malformed rows fail closed instead of being discarded and reopening a buffer.
  Reward action `91` accepts only server-generated type-9/11/23 Gold payloads. Its pure transition
  validates the wallet and monotonic revision, then a progression-revision-filtered player update
  commits in the same retry-safe transaction as the terminal message marker. A lost-response retry
  returns the stored immutable delta without performing a second wallet write.
  Those three reward-message families are validated as complete durable snapshots before producer
  insertion, inbox publication, claim, or replay: exact type-specific payloads, bounded identities
  and text, safe creation time, non-challenge lifecycle, and bounded embedded JSON arrays are
  required. Their parser-safe ID ends with creation Unix time and, when present, must equal the
  idempotency key plus that suffix. A terminal marker must contain the exact payload-derived Gold response and be both read
  and ignored. Canonical safe-integer strings remain the explicit legacy DynamoDB-number migration,
  and only an absent older idempotency key is optional; malformed or extra authority fails closed.
  Player League type-23 and Squad War type-9 settlements return only newly inserted message
  identities from their successful MongoDB transaction attempt. Squad Event type-11 and
  presentation-only Squad-level type-10 identities bubble through the enclosing PvP/economy
  transaction. After commit, those references are
  announced sequentially through the same local/Redis inbox fan-out, avoiding both an uncommitted
  reward notice and an unbounded division-close burst. A live `InboxMessage` remains presentation
  only: action `91` is still the sole atomic Gold-claim boundary.
  Optional Firebase Cloud Messaging HTTP v1 delivery adds a durable offline wake-up path after the
  same durable commit. `FIREBASE_PUSH_ENABLED=true` requires an exact Firebase project ID, Google
  Application Default Credentials with messaging permission, and a bounded 1-30 second request
  timeout. The sender re-reads the complete message and player, requires `PlayerStatus.Offline`, a
  nonempty mirrored device token, and the matching recovered consent setting before calling FCM.
  Its data-only payload contains exactly the client-consumed `id`: action `2` for challenges and
  action `90` for supported system-inbox families. Challenge, Squad status, Squad Event, and Player
  League switches gate their respective rows; type-10 is a Squad rank/status change, while type-28
  uses Squad status because the recovered local reminder uses `SQUAD_INFO`. Direct type-27 messages are not pushed because no distinct recovered
  consent mapping exists. No title, body, reward, or ownership assertion crosses FCM, and provider
  failure never rolls back or marks the MongoDB row. The normal inbox read remains recovery.
  Structured HTTP v1 failures retire a token only for `UNREGISTERED` or FCM-specific
  `INVALID_ARGUMENT`. The update compare-and-sets both token mirrors, so a delayed rejection cannot
  erase a newer action-13 registration. Generic payload errors, sender/project/auth mistakes,
  quota, service, internal, and transport failures retain the token. Each recipient/message pair is
  inserted once into `firebasePushDeliveries`; a renewable cross-node lease selects one bounded
  worker, and transient/configuration failures retry with saturating exponential backoff. The
  worker also joins every unread push-eligible inbox family against the ledger to recover a process
  crash after inbox commit but before normal enqueue. That shared family set includes type-1 Squad
  invitations and type-10 rank changes; it deliberately excludes type-27 direct messages. Complete
  fixed-shape ledger authority is validated before provider I/O and every terminal/retry transition
  compare-and-sets the selected pending snapshot.
  Monitoring distinguishes provider calls from terminal suppression: sent delivery increments only
  the delivered-attempt counter, a pre-provider ineligible decision increments only not-eligible
  suppression, and a provider-proven invalid token increments its failed-attempt counter plus
  invalid-token suppression only after retirement and terminal ledger publication. One pure tested
  mapping prevents success and suppression labels from being swapped in individual worker branches.
  This is at-least-once delivery: a provider acceptance followed by a lost HTTP response can produce
  a duplicate wake-up, which is safe because the payload only asks Unity to reload its durable
  inbox. Configure the exact worker bounds with `FIREBASE_PUSH_SCHEDULER_INTERVAL_SECONDS` (5-3600),
  `FIREBASE_PUSH_BATCH_SIZE` (1-1000), `FIREBASE_PUSH_INITIAL_RETRY_SECONDS` (60-86400), and
  `FIREBASE_PUSH_MAXIMUM_RETRY_SECONDS` (initial through seven days). Visible notification copy and
  a source-backed direct-message consent category remain explicit platform-integration gaps.
- **Moderation reports and sanctions**: authenticated player/cheater reports are validated, rate-limited,
  deduplicated for safe retries, and stored with review status and evidence metadata. Mandatory
  `ReportType` accepts only canonical recovered decimal text or an exact JSON integer in the bounded
  compatibility range; missing or coercible JavaScript values cannot silently become category zero. The
  configurable five-per-hour default is the same frozen startup abuse-policy snapshot's exact
  1-through-100 report value. It is reserved by one atomic MongoDB counter per reporter, so
  simultaneous requests across backend processes cannot overrun it or observe a process-local
  policy re-read. Each complete throttle row is
  validated before its count is trusted: exact fields, the expected HMAC-hidden reporter key, a
  bounded safe counter, ordered safe dates, a non-future update, and the exact two-hour storage
  interval are required. Rejected traffic saturates at one global denial sentinel while the original
  one-hour window start remains unchanged, preventing both unsafe counter growth and a spam-extended
  logical lock. The atomic ten-minute retry winner is also validated before its embedded report is
  inserted into the moderation queue. Its exact HMAC identity, open-report fields, UUID, four
  semantic identity dimensions, bounded client claims, creation/retention dates, and optional
  six-hour two-participant ranked-match snapshot must agree; a concurrent winner may preserve its
  own message and evidence but cannot redirect the reporter, target, type, or report family. The submitted
  evidence remains a claim until authoritative combat validation exists. Independently authenticated
  admin routes can issue, inspect, and revoke durable permanent or temporary account bans. Issue and
  revoke operations are idempotent, one active-ban index is race-safe across processes, expired bans
  stop blocking immediately, and enforcement returns the recovered client dialog contract from the
  shared authentication boundary. Complete sanction authority is checked before authentication,
  issue/revoke replay, admin listing, appeal intake, and accepted-appeal revocation: exact known
  fields, normalized identities, safe ordered dates, exact temporary duration/expiry equality, and
  status-consistent resolution or revocation audit evidence are mandatory. The active lookup omits
  an expiry predicate so invalid Dates cannot silently reopen access.
  The authenticated admin queue supports stable filtered pagination, exact report inspection, and
  optimistic `open -> reviewing -> resolved/dismissed` decisions. Each transition appends actor,
  note, previous/next status, operation ID, and timestamp atomically; terminal states are immutable,
  stale snapshots conflict, and identical retries return the committed review without a second entry.
  Every report is proved before admin detail/list publication, mutation, or replay: immutable creation
  authority must remain intact, `open` has no audit metadata, and each later status must be the exact
  projection of one or two unique, legal, bounded, chronologically ordered audit entries ending at
  `updatedAt`. A bare or contradictory terminal status therefore has no moderation authority.
  A separately authenticated support API now accepts one ownership-checked appeal per active
  sanction, permits owned reads and optimistic withdrawal, and exposes no private moderation data.
  Its admin queue supports audited `open -> reviewing -> accepted/rejected` decisions; acceptance
  transactionally revokes the live sanction, while all terminal appeal states remain immutable.
  Complete appeal authority is checked at submission replay, owned/admin read, list, mutation, and
  replay boundaries: exact appeal/sanction/player/submission identities, normalized bounded message,
  safe creation/update dates, and a unique legal one-or-two-entry audit chain must project the final
  status and exact `updatedAt`. Open intake keeps equal creation/update times and no review history.
  Because the recovered banned dialog has only retry/log controls, a replacement support frontend
  or client adapter is still required to expose this workflow to stock-client players.
  Terminal reports and appeals additionally have an admin-only lifecycle preview, bounded stable
  export, and explicitly confirmed transactional purge. The frozen timestamp prevents review/export
  drift; active/open records are excluded, exact retries return the immutable deletion receipt, and
  sanctions remain indefinitely auditable.
  Preview, export, and purge validate every selected report and appeal lifecycle. Purge proves both
  complete sets before its first delete, then deletes only validated IDs that still satisfy each
  frozen terminal/date filter inside the transaction. A forged terminal status therefore aborts
  before either collection changes, and a concurrent record change cannot broaden destructive authority.
  The immutable retry receipt is validated before its counts are returned: exact identity fields,
  safe nonnegative deletion counts, safe preview/creation chronology, and exact whole-day report and
  appeal cutoffs within the global 30-3650-day bounds are required. Global bounds preserve older
  receipts when the current deployment retention policy changes.
  Army Power/rank/time fields remain explicitly untrusted claims. When both accounts occur in a
  recent replacement-backend ranked match, the report also captures the exact server match ID,
  participant snapshots, state, terminal winner/cancellation, authenticated result claims, and
  bounded relay/used-card observations. The snapshot keeps `combatValidated=false` because the
  relay still cannot prove damage, targets, timing, or card effects; social reports and legacy
  Photon matches remain valid reports with no fabricated match correlation.
  Duplicate target/type requests also converge on one HMAC-keyed MongoDB winner containing the
  complete first payload; all concurrent processes upsert that same report ID, while logical
  ten-minute expiry is enforced independently of delayed TTL cleanup.
- **Public-text moderation**: account/rename names, Squad names/descriptions, and direct messages
  share Unicode-normalized multilingual matching with punctuation/leetspeak resistance. Add
  deployment-specific comma-separated terms with `PROFANITY_EXTRA_TERMS`; report evidence is
  intentionally preserved verbatim for review.
- **Player rename economy**: the first rename remains free and later attempts use the exact
  decoded 4-Gold doubling curve. The profile-owned count is restored through `PlayerAnalyticsData`
  and validated at shared account lookup before authentication, gameplay, unrelated profile writes,
  price, recovery, mutation, and boot; Gold, revision, and the next count validate before the atomic
  profile/debit write, so count 29 cannot publish signed-overflowing count 30. The mandatory
  `PayForRename` field accepts only canonical integer `0` or `1`; truthy/falsy, array, blank,
  leading-zero, fractional, exponent, missing, or null values fail before the name or wallet changes.
- **Energy economy**: server-owned dog-tag seconds, passive regeneration, atomic
  `PayOneDogTag`, and gold-validated `RefillDogtags` using the recovered 900-second/5-tag
  balancing and refill-price formula. A verified subscription accelerates only the interval
  between its server-issued timer lock and expiry to the exact 450-second MainScene rate;
  reconnect after expiry materializes the historical split without granting post-expiry speed.
  `DOG_TAG_REFILL_SECONDS=900` and `DOG_TAG_CAP=5` are immutable module-startup compatibility
  assertions, not tunable balancing, because the stock client independently uses those constants.
  Every shared persisted read/publication validates the complete tuple shape. Callers that own an
  authoritative request/boot time supply one captured server time for both snapshots and also
  reject future cursors; context-free publishers remain deterministic while still rejecting every
  malformed tuple value. Refill must remain 900, normal maximum 4,500, and base credit between that
  cap and the source-backed two-tag VIP debt floor. All boot fields and timestamps retain C#
  signed-`int` width, so alternate safe-integer policies and post-2038 cursors fail closed.
  Count-only legacy
  migration requires the canonical tuple to be absent and its old count to remain a nonnegative
  safe integer; fractions, negative values, and non-finite counts cannot be rounded into energy.
  New accounts and legacy migration share the one startup-resolved policy. Malformed present fields
  fail closed instead of being rebuilt or surviving an unrelated full-document replacement.
- **Application-clock authority**: initial progression creation, shared progression reads,
  successor publication, `PlayerData`, and the top-level player-state response first require one
  nonnegative safe Unix second inside JavaScript/BSON Date support. The exact captured value is
  reused across nested dog-tag, subscription, calendar, video-ad, win-streak, Instant Battle,
  tutorial, chat, league, and War Arena decisions. Fractional, non-finite, negative, or oversized
  clocks fail before they can be floored into inconsistent valid boot or entitlement state.
- **Progression revision authority**: the central progression read boundary migrates only an
  absent pre-revision field to zero. Present and produced values must be nonnegative safe integers,
  and every non-no-op transition must advance monotonically before MongoDB builds its revision
  filter or publishes the replacement. A recovered multi-action RequestBuffer may advance several
  internal steps in its single atomic replacement. One shared successor proof also covers custom
  inbox, Google Play entitlement, mission, Instant Battle, rename, Squad economy/card/departure,
  tutorial, Squad War, core PvP, and operator-integrity transactions, validating both core-balance
  snapshots and their revision ordering before a full progression replacement is built.
- **Progression schema authority**: an embedded progression document must declare the exact
  supported schema version `1` at read and publication boundaries. Only a wholly absent progression
  uses the deterministic account fallback; a missing, malformed, or future embedded version fails
  closed until a versioned migration explicitly understands it.
- **Paid-VIP timeline authority**: `Vip` expiry remains the recovered active-benefit predicate;
  `VipStart` is display/reminder metadata. Both are nonnegative safe Unix seconds at shared read and
  publication boundaries, with exact `0/0` for no entitlement and `VipStart <= Vip` otherwise, so
  corrupt or inverted duration metadata cannot reach client progress calculations or later writes.
  Shared account lookup also validates the legacy `DatabasePlayer.vipExpiration` fallback even when
  canonical progression currently masks it. The two storage generations need not be equal, but a
  malformed dormant fallback cannot survive unrelated authenticated gameplay/profile mutations.
- **Subscription receipt ownership**: a present private revalidation owner is the exact
  64-character lowercase hexadecimal HMAC-SHA256 purchase-receipt key generated from the Play token.
  Absence remains valid for pre-binding legacy subscriptions; arbitrary or malformed durable IDs
  fail before comparison or progression publication.
- **Core progression balance authority**: every persisted progression read and every produced
  mutation state validates Gold, WarBucks, Tickets, Scraps, and level XP before price comparison or
  publication. Safe-integer Gold/WarBucks chargeback debt remains legitimate; Tickets, Scraps, and
  XP must be nonnegative safe integers. NaN, Infinity, fractions, unsafe values, and invalid debt
  fail before they can bypass a debit or enter the Dynamo-style boot adapter's legacy zero fallback.
- **Card lifecycle counter authority**: private lifetime `warCardsPlayed` and `goldCardsCrafted`
  values must be nonnegative safe integers at read, publication, and achievement derivation. Missing
  legacy counters normalize to zero; malformed values cannot satisfy card achievements/starter
  assignments or be carried forward by an unrelated progression replacement.
- **Gold-to-WarBucks exchange**: action `221` validates `WarbucksId` against the deployment-owned
  MainScene A/B prefix, debits the exact 50/200/500/1000/3500/7000 Gold row, and multiplies the
  exact row units by the authenticated player's source `CONVERTGOLDTOWARBUCKS` rank value. The
  wallet and a narrow transport-replay receipt commit atomically. `WARBUCKS_GOLD_VARIANT` is
  resolved once during module startup as one immutable exact case-sensitive `standard` or `b`
  literal. Whitespace, alternate case, unknown values, and invalid injected service arguments fail
  closed rather than being normalized or falling through to the standard curve. It defaults to the
  conservative standard curve because the retired remote experiment selector is absent.
  Its two-second lost-response receipt is complete private authority: both recovered A/B prefixes
  remain valid across deployment changes, but the ID must map to its exact source Gold price, grant
  and timestamp must be safe, and receipt revision cannot exceed current progression. A malformed
  receipt fails closed instead of being discarded and reopening the conversion.
- **Instant Battle / Skirmish**: action `199` is server-authoritative from rank 9 onward. A
  new account starts with five ready battles; after a batch is consumed, one battle recharges
  every 48 minutes up to five. A free request consumes every currently ready battle. When none
  are ready, the paid path verifies and debits the exact 35/70/140-Gold escalating price and
  simulates a full five-battle batch. Only an omitted `IsPaid` field selects the free path; the
  paid dialog's C# integer string must be canonical and positive, so explicit null, blank, Boolean,
  array, padded, signed, fractional, exponent, zero, negative, or oversized values reject before
  readiness and wallet logic. Timer, lifetime/paid counters, wallet, XP, level Gold,
  dog-tag rank-up refill, and rank Army Power commit in one revision-guarded player write and
  are restored through `PlayerAnalyticsData`. One shared validator requires all three public
  counters and the exact private replay receipt to retain signed-client values, source price/count
  bounds, level/refill consistency, and a non-future progression revision at shared progression
  read/publication and before readiness, settlement, or boot. Transaction validation remains
  deterministic; action/boot request time separately rejects future timer and receipt timestamps.
  Paid five-battle groups beyond the lifetime count also fail closed. The
  hybrid MainScene's shifted five constants are
  realigned to the old script's field order so its visible five-charge/35-Gold UI agrees with the
  backend. The retired reward table is unavailable; `INSTANT_BATTLE_XP_PER_BATTLE` (20) and
  `INSTANT_BATTLE_WARBUCKS_PER_BATTLE` (600) are explicit offline policy. They resolve once at
  module startup as immutable exact nonnegative integers no greater than 429,496,729 per battle,
  keeping the full five-charge XP and WarBucks response inside the recovered C# signed-`int`
  fields; malformed policy stops startup. A free batch preserves Gold chargeback debt and pays
  WarBucks rewards into WarBucks debt. Rare Gold/card/extra-WarBucks rewards remain disabled rather
  than fabricated.
- **Versioned client-data material database**: MongoDB collections `gameCatalogEntries` and
  `gameCatalogReleases` persist the recovered 4.9.5 weapon, soldier/unit, rank, power, player
  visual, War Card, and card-pack data as 531 queryable records. The 165 concrete weapon
  records comprise 84 shop and 81 dedicated Black Market LevelManager setups; 18 unresolved
  rows retain nine members from each family. Every playable weapon record joins its source row to the full
  upgrade table; every playable unit joins roster/deployment/purchase data to normal, special, and
  elite level rows; every visual joins its price/effect row to a serialized client asset. Nine
  unresolved Pulse Rifles, three helper units, 18 unresolved unit rows, and the assetless
  `HEAD_MASK_ROCKET` visual and 25 card definitions without serialized Card components are
  retained with explicit non-playable states instead of being
  discarded or silently enabled. Per-entry SHA-256 hashes and a deterministic release hash make
  balancing changes auditable. Startup idempotently writes all immutable revision entries before switching the
  current 4.9.5 release pointer, so readers cannot observe a partial synchronization. Run
  `npm run sync:catalog` to publish explicitly; normal server startup performs the same sync.
  A complete durable authority boundary now validates the release pointer before startup reuse,
  CLI reporting, or lookup: exact fields, SHA-256 revision, conserved safe counts, canonically
  ordered unique source triples, and safe ordered dates. Every resolved entry must have an exact
  kind/availability identity, bounded canonical JSON without non-finite values, a recomputed content
  hash, one source triple present in the release, and audit dates no later than pointer publication.
  Deterministic revision rows are insert-once; synchronization re-reads and proves all 531 expected
  identities before atomically replacing the release. Provenance identity includes path, schema,
  and digest because checked-in extraction artifacts can record different snapshots of the same
  source path; the former path/schema-only map silently omitted the unit artifact's recorded digest.
  The card artifact has an additional shared startup boundary used by gameplay and catalog sync:
  it requires exact 4.9.5 provenance and fields, all 58 ordered unique playable cards, 25 ordered
  unique unresolved rows, four recovered pack identities/counts, bounded economy/rule values, and
  the complete matching 50-row Squad snapshot. The accepted result is deep-frozen, including nested
  reputation rules and capacity arrays, so truncation, duplicate-key overwrite, inconsistent pool
  authority, or later in-process mutation cannot change purchases, crafting, rewards, or publication.
- **Authoritative Army Power**: `scripts/Extract-ArmyPowerCatalog.mjs` reproduces 11,805 normal
  weapon DPS rows and all 58 player-rank `ARMYPOWER` rows from MainScene. The server independently
  validates this artifact once for progression, power calculation, and catalog sync: exactly 58
  contiguous rank rows, 11 ordered category masks with nine exact feature identities each, 165
  unique weapon identities/indexes, and 11,805 finite nondecreasing DPS values are required. The
  accepted ranks, feature rows, and per-level DPS arrays are deep-frozen, so a truncated, duplicate,
  split-mask, unsafe, non-finite, or later-mutated snapshot stops before changing player levels,
  rewards, conversions, matchmaking power, or publication. The server independently
  rounds equipped-unit float power, equipped-weapon float DPS, and the current zero-based rank row
  exactly where `LevelManager` does, then atomically stores their sum in both indexed and public
  player state. `UpdateArmyPower` ignores the client's claimed value and recomputes against one
  consistent progression revision; concurrent inventory changes force a reload. Active
  weapon and unit rentals contribute only while the exact persisted 12-hour trial is
  unexpired. Black Market weapons use their persisted offered `boughtIndex` and
  special-feature index with the exact coefficient from all 11 category rows.
  Run `npm run verify:army-power` to compare the
  generated catalog with the recovered scene. Action `192` confirms the source progression
  revision and performs no write when both denormalized Army Power copies are already current.
- **Weapon catalog authority**: normal inventory, Black Market inventory, Buddy-card weapon proof,
  and catalog sync now share one validated, deep-frozen extraction snapshot. Startup requires all
  84 ordered shop rows, 81 ordered Black Market rows, both nine-row unresolved families, globally
  unique resolved indexes/names, exactly four starter weapons, one-bit categories, bounded prices
  and level gates, zero source delivery time, and exact unresolved evidence. Duplicate or truncated
  rows therefore fail before `Object.fromEntries` can silently replace a weapon definition.
- **Player visuals and decals**: `scripts/Extract-VisualCatalog.mjs` joins all four serialized
  customization categories to the 4.9.5 PlayerVisuals sheet, producing 146 playable and one
  unresolved row. Entitlement checks, purchase/reward paths, and catalog sync share one startup-
  validated snapshot requiring the exact category identities/defaults/counts, unique prefix-bound
  assets, deterministic playable rows, the distinct unresolved row, known acquisition families,
  and bounded numeric fields. Its rows and nested category ID arrays are deep-frozen so a duplicate,
  truncated, split-category, non-finite, or later-mutated artifact fails closed rather than changing
  cosmetic or duplicate-compensation authority. `DecalManagerData` is server-owned and boot-safe; buffered `BuyDecal`,
  `EquipDecal`, `DecalWasShown`, and `VisualWasShown` validate source, price, category, VIP,
  ownership, expiry, and shop eligibility. BuyDecal resolves the authenticated zero-based level
  through the exact recovered 58-row catalog before its unlock comparison, so `NaN`, fractions,
  negative indexes, and oversized integers cannot bypass or invent rank eligibility in direct
  mutation callers. Gold/WarBucks debit, permanent or timed ownership,
  four-slot equipment, notification state, rollback data, and `BufferId` replay protection are
  atomic. Re-equipping the current category item and replaying an already-cleared visual badge
  acknowledgement preserve exact state identity instead of creating false inventory revisions.
  Direct replacement-client routes are a separate outer contract: BuyDecal requires `ObjData`,
  EquipDecal/VisualWasShown require `DecalId`, and weapon/unit acknowledgement requires
  `LevelName`. `Name`, `Data`, and `data` may only be exact agreeing duplicates and cannot authorize
  a direct mutation alone. Recovered direct action 108 has no trustworthy visual identity, so it
  remains callback-safe telemetry even when a diagnostic caller supplies a visual-looking alias;
  the current visual badge mutation remains buffered action 191.
  One shared `DecalManagerData` authority boundary validates the exact root/saved/slot shapes,
  source-catalog visual identities, catalog-bounded part counters, all four recovered category
  slots, category-correct equipped IDs, and the helmet-only previous-head value at progression
  read/publication and before boot, ownership/equip, purchase, paid-pack extension, or
  voided-purchase reversal. In particular, unknown IDs, missing slots, cross-category equipment,
  and `NaN`, `Infinity`, fractional, negative, or out-of-Date-range expiry values fail closed
  instead of becoming durable client-invented ownership or permanent power bands.
  Actions `104`/`105` now persist the weapon/unit `showed` flags through both direct and
  buffered transports without granting ownership; locked or unknown rows fail closed. Direct
  action `194` and its stock buffered form are explicit telemetry acknowledgements, so opening a
  notification cannot poison an otherwise valid RequestBuffer with `UnknownAction`; echoed player
  and message identifiers never mutate progression.
  `BuyLootboxes` validates one of the six exact MainScene products (49/89/159/279/479/749 Gold
  for 5/10/20/40/80/150 one-part rewards), atomically debits Gold, persists every part and exact
  duplicate-WarBucks conversion, and returns the recovered `NewVisuals`/`Id`/`LootboxCost`
  contract. Its mandatory `discount` is accepted only as the canonical 0-99 decimal integer sent
  by the recovered dialog; missing/null/Boolean/array/blank/fraction/exponent forms cannot coerce
  into the authorized zero path and commit a malformed purchase. Product IDs must be own catalog
  rows rather than inherited JavaScript object keys. Client-authored sales remain rejected. Confirmed active-VIP PvP settlement also owns
  the source-defined four-battle countdown
  and two one-part suitcase rewards: parts, exact duplicate WarBucks, `NewVisuals`, and immutable
  retry receipts commit in the terminal match transaction. The persisted countdown is validated
  as an exact 1-4 integer at migration, boot, settlement, and every progression publication; only
  an absent legacy field defaults to four. Selected over-target visual parts fail before duplicate conversion instead of being
  clamped into unproven ownership. The retired production weights are
  unavailable, so selection is explicitly reconstructed as uniform across the 73 normal-shop
  part rows; event/Arena/loyalty/assignment/value-pack grants, visual rentals, and unsupported
  discounts remain fail-closed. Run `npm run verify:visual-catalog` to compare the artifact with
  MainScene.
- **Rewarded-video prizes**: action `156` implements the recovered `RandomCard`, `Dogtag`,
  `GoldenSuitcase`, and `LootBox` enum contract. The server ignores client-authored dog-tag timing
  and cap values, atomically persists every card/energy/currency/visual-part grant, applies exact
  duplicate-WarBucks conversion, returns the parser's `AddedCards`, `DogTagSeconds`,
  `DogTagLastUpdate`, `Gold`, `WarBucks`, `NewVisuals`, and `videoAdRewardTimes` fields, and restores
  all four ledgers at boot. Action `156` accepts only the four canonical positive enum decimals
  emitted through the recovered `num.ToString()` call, or the same integer from a replacement JSON
  client; JavaScript-coercible Booleans, arrays, padded/signed/leading-zero/fractional/exponent text,
  zero, and out-of-range values cannot choose a reward branch. XOR-decoded 4.9.5 limits are enforced server-side as 24 claims per
  rolling 5/12/15/100-hour window, with the exact one-minute Golden Suitcase spacing. A shared
  validator requires the grant/comparison clock and every durable ledger entry to be a positive
  safe Unix second inside JavaScript/BSON Date support at progression read/publication and before
  grant or boot. It validates the runtime number directly; a fractional, non-finite, negative, or
  oversized clock cannot be floored or clamped into a valid reward receipt. Its exact private replay
  receipt must bind a supported reward, bounded safe
  timestamp, non-future progression revision, matching ledger grant, and bounded immutable JSON
  response containing the same ledger snapshot;
  only valid timestamps provably older than their reward window are removed, while future entries
  retain capacity after a clock rollback. A narrow
  same-revision five-second receipt prevents a lost HTTP response from granting twice. The
  production Golden Suitcase weights/ranges were remote and the bundled rows are internally
  invalid, so the documented offline table uniformly selects 1,000 WarBucks, 5 Gold, one visible
  Bronze card, or one normal-shop visual part; VIP and power-band prizes remain disabled rather
  than fabricated. The stock Fuse completion callback provides no provider-signed proof, so these
  limits contain economy abuse but cannot attest a real impression; production ad monetization
  requires a provider server-to-server callback/nonce before calling the grant transition.
- **Replay video publishing**: action `3000` restores the retired Everyplay submission callback.
  It validates the authenticated player's bounded HTTP/HTTPS URL, rejects executable, local-file,
  credential-bearing, malformed, and control-character input, and stores a deterministic
  per-player publication. Unique URL identity makes concurrent/lost-response retries harmless.
  A separate per-player rolling ledger atomically prunes and reserves each URL across all backend
  nodes, so simultaneous distinct uploads cannot exceed 20 publications in 24 hours and an exact
  retry after a reservation/receipt crash window does not consume another slot. On first use the
  ledger is conservatively seeded from up to 21 recent legacy receipts, preventing deployment from
  reopening an already-used allowance; exact-key/hash/date/cap/decision/48-hour-retention validation
  fails closed before a damaged row can be pruned. The receipt collection's one-year TTL bounds
  this write-only compatibility data, while the ledger TTL is storage hygiene only. Every
  insert and idempotent replay validates the complete stored row: exact known fields, canonical
  URL, matching SHA-256 URL hash, deterministic player-and-URL ID, bounded player identity,
  immutable creation/update time, and an exact 365-day expiry. Application-time expiry rejects a
  stale row even while MongoDB TTL deletion is delayed. The response echoes the exact `URL`
  consumed by `MHEHGPLIFHF.LLCLNJKBGGM`. No feed-read database action exists in 1.6.0, so the
  backend does not invent an unreachable mobile browsing API.

  Operators can review retained publications through admin-Bearer-only
  `GET /admin/replay-videos` and `GET /admin/replay-videos/:videoId`. The list accepts an optional
  exact `playerId`, a canonical integer `limit` from 1 through 100, and an opaque canonical
  Base64URL cursor bound to that player filter. Its descending `(createdAt, videoId)` ordering is
  backed by global and per-player migration indexes, so concurrent newer uploads do not duplicate
  or skip older pages. Both endpoints exclude expired rows at query time and validate the complete
  receipt again before returning the reviewed `videoId`, `playerId`, URL/hash, and creation/expiry
  fields. They do not fetch, preview, probe, or redirect to the player-supplied URL.
- **VIP purchase and expiry authority**: action `114` validates `VIP_1` through `VIP_4` against
  the 4.9.5 MainScene table (49 Gold/12 hours, 249/3 days, 499/7 days, and 1799/30 days), debits
  Gold and extends the Unix entitlement in one revision-safe transaction, emits the exact
  `Vip`/`VipStart`/`Gold`/`Id` success contract, and returns recovered `11401`/`13601` recovery
  payloads. The mandatory discount uses the same exact canonical decimal parser as lootboxes, and
  both the handler and service require an own VIP catalog row, so malformed zero coercions and
  inherited object keys fail before Gold or entitlement changes. Active VIP is read from progression by direct and buffered VIP-only visual purchases;
  action `195` is a deadline-based acknowledgement. Active members also receive exactly two
  daily War Cards through the recovered `VipReward1`/`VipReward2` response contract: each draw is
  Gold with the source-decoded 75% chance and Silver otherwise, while an atomic UTC cursor prevents
  reconnect, renewal, and concurrent-fetch duplicates. That marker's day must derive from its safe
  non-future grant timestamp and both saved IDs must remain implemented Silver/Gold cards (including
  a legal duplicate), so corruption cannot be overwritten to reopen the pair. Login, VIP purchase,
  and daily-calendar
  claims use their exact outer/nested parser locations. The periodic benefit advances only on
  confirmed active-VIP PvP, resets after four battles, grants two independently selected visual
  parts, preserves duplicate `_#n-VIP` wire entries, and restores its countdown through
  `PlayerAnalyticsData`. Nonzero VIP discounts stay rejected until retired Fusebox offer
  definitions are recovered into a server allowlist. Actions `135` and `136` are authenticated
  fail-closed routes: without that allowlist they return recovered `13501`/`13601` errors and
  never persist client-echoed finish times, discounts, keys, or offer names.
- **Verified Google Play purchases, packs, restore, and revocation**: Android actions `142`,
  `9999999`, and `130` validate the
  recovered `ProductId`/`PurchaseToken`/`PackageName`/`OrderId` proof through Google Play Developer
  API `products.get` or `subscriptionsv2.get`. A global HMAC-keyed token ledger and the progression
  grant commit in one MongoDB transaction, so one store token cannot fund two accounts and a lost
  response retry cannot grant twice. The server owns the recovered 4.9.5 `afgold1`-`afgold6`,
  `bgold1`-`bgold6`, `warbucks1`-`warbucks6`, and `bwarbucks1`-`bwarbucks6` amounts; completed
  single-quantity purchases are accepted even after client-side consumption. The stock action
  `142` retains its shared currency/subscription parser, while explicit subscription alias
  `9999999` accepts only the subscription entitlement family. `subscription1`
  accepts only active, grace-period, or canceled-but-unexpired Play state, advances its verified
  expiry monotonically, and restores the exact `PlayerData.Subscription` object at boot. A
  cross-node Mongo-leased scheduler decrypts only due subscription tokens, rechecks
  `subscriptionsv2.get`, advances renewals, and immediately ends benefits for successfully
  observed paused/on-hold states. Expired receipts become terminal. Transport, credential,
  malformed-response, and unknown-future-state failures use durable exponential retry and never
  shorten paid access. Receipt authority prevents an older token from revoking a newer replacement
  subscription. Seven packs whose serialized benefits are fully representable are enabled:
  `afstarterpack`, `starterpackB`, `valuepackaf`, `valuepackafB`, `valuepackafc`, `moneypack1`, and
  `moneypack1B`. Their wallet, VIP, weapon, timed/permanent visual, and extra-card-slot changes
  commit atomically; action `189` verifies every restored token and returns complete `PlayerData`.
  Unsupported special-weapon or incompletely serialized offer packs remain fail-closed.

  Every full player-document reload in direct delivery, background subscription revalidation,
  voided-purchase reversal, and the final boot-style response validates the same private account and
  duplicated profile envelope used by authentication. A genuinely deleted player retains the
  reconciliation path described by that operation; a present damaged row instead aborts its MongoDB
  transaction before any entitlement, reversal, or terminal receipt marker is written, preserving
  the provider event for retry after repair.

  Every durable Google Play receipt is also validated as one complete authority snapshot before
  replay, replacement, subscription revalidation, void reconciliation, overlap preservation, or
  insertion. Its HMAC identity, owner/order, catalog kind/store product/exact response, ordered safe
  dates, reversible grant, encrypted subscription lifecycle, bounded retry counter, and all-or-none
  void metadata must agree. Only old currency receipts may derive an omitted reversible wallet grant
  from their exact catalog-bound response; pack ownership history has no such migration. Failed
  subscription checks advance the bounded counter with compare-and-set ownership, so concurrent
  workers cannot overwrite each other's provider evidence or retry schedule. Every live receipt
  retains a Date retry cursor strictly after its latest verification audit; terminal Play states
  retain revocation evidence and no cursor, while only a revoked deleted-account orphan may retire
  a nonterminal state. The leased sweep explicitly selects missing, malformed, and terminally
  contradictory cursors, validates the whole selected batch before its first provider call, and
  validates each retry, orphan-retirement, or provider-result successor before writing it. A
  terminal response that omits a new expiry preserves the receipt's last verified expiry as audit
  context instead of deleting the original entitlement boundary.

  Google Play provider scheduling resolves once during module startup as one immutable exact
  four-value deployment snapshot. Subscription cadence is 300-86,400 seconds and is shared by
  initial receipt creation, successful checks, and retry caps; its scheduler interval is
  30-3,600 seconds and its batch is 1-1,000 receipts. The voided-purchase scheduler interval is
  60-3,600 seconds. Every setting must be an exact safe integer. Fractional, non-finite, negative,
  or out-of-range values stop startup instead of being rounded, clamped, independently re-read, or
  used to produce a durable invalid revalidation date.

  Every shared background-job lease is validated before acquisition and after its MongoDB
  compare-and-set: exact fields, bounded job ID, UUID owner, safe ordered dates, and a duration from
  one second through 24 hours. A malformed expiry therefore fails as damaged authority instead of
  looking like permanent lock contention to all nodes.

  A second Mongo-leased scheduler queries Google Play Voided Purchases for one-time products with
  a durable successful-window cursor, ten-minute overlap, complete token pagination, and Google's
  30-day first-run boundary. The singleton cursor must retain exact fields, equal successful-end and
  audit timestamps, safe dates, and a non-future position before it can select or publish a provider
  window, so corruption cannot skip void events. It matches the HMAC token plus exact order ID, reverses each receipt
  once, records source/reason/time, preserves benefits backed by another active pack receipt, and
  resets revoked equipped items to recovered defaults. Already-spent refunded currency becomes a
  negative server balance so later earnings repay the chargeback before spending resumes. The
  client-originated action `1013` is compatibility-only and cannot revoke anything. The
  implementation is contract-tested; live verification and reconciliation require deployment
  credentials.
- **War Card inventory and card packs**: exact `CardManagerData` is persisted and returned at boot.
  `scripts/Extract-CardCatalog.mjs` reproduces 58 playable cards, 25 unresolved definitions, and
  four source-priced packs from MainScene. Buffered `BuyCardPack` validates unlock level, pack,
  count, playable IDs, fixed and ranged rarity slots, discount, timing, and funds; then atomically
  debits Gold/WarBucks and increments card amounts with `BufferId` replay protection and exact
  rollback fields. Pack unlock and mission-card `FROMMISSION` selection first require the
  authenticated zero-based player level to identify one exact recovered rank row. The source index
  controls the rank-6 unlock and its one-based display number controls mission eligibility;
  non-finite, fractional, negative, or out-of-catalog levels cannot bypass the gate through
  JavaScript comparison behavior. `BuyThreeCards` legitimately omits `discount` and `StartTime`; only that true
  absence derives zero, while present fields must remain exact nonnegative C#-int JSON numbers and
  malformed null, Boolean, string, array, fractional, negative, unsafe, or oversized values reject
  before economy logic. The stock client selects card identities before sending and therefore keeps
  those identities as validation assertions. A repaired client may omit `cards` and send the exact
  `ServerSelect: true` contract; the server then draws the complete pack from the same recovered
  fixed/ranged rarity envelope and returns `Cards`. The enclosing `BufferId` is the durable nonce,
  so its cached response replays the exact identities without another debit or draw. The Unity side
  must explicitly consume the returned array; the unmodified success parser still uses its local
  roll. Run `npm run verify:card-catalog` to verify the generated artifact. The complete five-field inventory snapshot is validated before
  read, gameplay use, recovery serialization, and every progression publication. Normal ownership
  is sparse, positive, signed-client-safe, and limited to implemented IDs. Buddy ownership is capped
  at ten exact loadout records with source-backed unit/weapon indexes and bounded legacy visual IDs;
  cooldowns fit the recovered C# `int`, and `extraSlot` must be a real Boolean. Present malformed
  state fails closed instead of being normalized into free ownership, an unlocked slot, or an expired
  squad cooldown.
- **Timed and subscription War Card crafting**: exact `CraftData` is returned at boot. Direct `CraftCard` atomically
  consumes three same-rarity owned cards and creates the extracted 30-minute Bronze-to-Silver or
  60-minute Silver-to-Gold receipt. `ClaimCraftedCard` enforces server time, selects one playable
  next-rarity result with cryptographic randomness, grants once, and clears the receipt. Recovered
  17401/17601/17701 recovery bodies restore client state, and a claimed Gold craft proves starter
  assignment ID_8. Subscription-only action `2000` now validates the server-owned Play expiry,
  consumes the same three-card recipe, grants a server-selected result, and leaves no timed receipt,
  all in one progression revision. Inactive subscribers receive the recovery body that restores the
  stock client's optimistic card removals. The complete durable receipt is validated at shared read,
  action, serialization, and publication boundaries: empty state must be the exact zero tuple, while
  active state must contain exactly three implemented same-rarity Bronze/Silver IDs and the exact
  source duration. Its signed-client timestamps cannot overflow Unity's recovered C# `int`; malformed
  or partial state fails closed instead of being cleared and reopening a three-card exchange.
- **Squad War Card pool**: `DepositCards` validates the nested
  `AddedCards`/`RemovedCards` dictionaries, ownership, and the recovered 3-10 slot squad-level
  capacity before atomically exchanging inventory and `depositedCardsDic`. Nested `CardData.amount`
  and every numeric `BuddyCardData` member must be an exact bounded JSON integer number, matching
  the recovered C# fields; missing, null, Boolean, string, array, fractional, non-finite, or unsafe
  values cannot manufacture an amount/loadout index, and only numeric `-1` means no secondary
  weapon. `WithdrawCard` verifies
  both players against the same squad roster, transfers one card in a MongoDB transaction, awards
  the donor 5/15/45 rarity reputation, and starts the exact 240-minute recipient cooldown. Normal
  and 30-point Buddy rewards share one checked signed-client Reputation increment before either
  participant write, so a near-cap donor cannot publish a value Unity cannot deserialize. Existing
  New Buddy deposits reproduce `CreateDataForCurrentPlayer`: owner/timestamp identity, account
  name, zero-based level, Army Power, four visual slots, four owned weapon slots, unit-type-specific
  primary/secondary pair, one-pool limit, and the exact 480-minute cooldown are server-validated.
  `DatabasePlayer.Level` is already the zero-based `LevelManager.currentLevel.index`, so the Buddy
  snapshot stores that exact recovered row without a display-level subtraction. Malformed or
  out-of-catalog ranks fail before another player can receive the durable loadout.
  Existing Buddy deposits transfer with their full loadout and a ten-card cap.
  `NotifyPlayerToDeposit` validates both players against the same roster and persists the exact
  type-28 sender snapshot with one actor/target reminder per UTC day. Types 3, 21, and 28 use the
  same post-persistence local/cross-node `InboxMessage` delivery as direct messages and challenges;
  an offline target still recovers the authoritative row through `GetAllMessages`.
- **Weapon inventory foundation**: private and public player snapshots now serialize the
  exact recovered `InventoryData.slots` and `LevelManagerData.savedWeapons` structures with
  the 4.9.5 starter loadout. One shared authority now validates the complete nested
  `InventoryData`/`LevelManagerData` snapshot before persisted reads and progression publication:
  exactly four slots must point to an owned source-backed weapon with the recovered index and
  compatible category; saved weapon/unit records must retain their exact Boolean/integer shape,
  catalog-bounded upgrade cursors, tier bounds, consistent bought/borrowed/equipped flags, and
  the recovered two-per-deployment-category and three-mechanical equipped-unit limits;
  and each delivery must be either the exact empty tuple or an active bounded-time receipt that
  matches the permanent saved upgrade cursor. Only a wholly absent legacy item inventory receives
  the exact starter loadout. A malformed nested snapshot therefore fails closed instead of being
  cloned into boot data, Army Power, a price check, or an unrelated full-progression replacement.
  Stock buffered `BuyWeapon`/`ActivateWeapon`/`EquipWeapon` supports all 84
  `PURCHASABLE: shop` rows that also have real LevelManager entries. Their obscured Gold and
  WarBucks prices, level gates, category masks, and non-sequential indexes are recovered from
  MainScene. Normal purchases require the authenticated zero-based level to select one exact row
  in the 58-level source catalog before comparing the weapon gate; fractions, non-finite values,
  negative indexes, and oversized integers fail instead of being floored or clamped. Purchases
  grant immediate ownership because every enabled row has
  `DELIVERTIME=0`. Action `128` validates the preceding permanent purchase as an idempotent
  zero-delivery acknowledgement and cannot grant or convert a rental. Recovered buffered actions
  `125`/`126` apply the same rule to Unity's optimistic `InstantBuyUnit`/`InstantBuyWeapon` calls:
  they require the permanent purchase, exact Gold coefficients, `ExpectedPrice=0`, and an empty
  matching delivery receipt, then preserve state identity without a second debit or grant. Mutations include server
  price/discount validation, atomic debits, category-safe equipment, Unity rollback fields, and
  `BufferId` replay protection. Re-equipping the exact current weapon is validated but preserves
  progression identity instead of creating an unrelated inventory revision. Any nonzero timed
  instant-purchase lifecycle remains rejected because no supported source row can produce its
  required pending-delivery state. Nine
  shop-priced Pulse Rifle rows with null LevelManager entries, unknown catalog rows, and
  unrelated OfferManager-discounted purchases still fail closed.
  `../Tools/Extract-WeaponCatalog.ps1` reproduces the catalog by joining the serialized
  LevelManager setup array to the Google2u component on each weapon GameObject, resolving
  Unity DLL script IDs through the recovered assemblies, and XOR-decoding both currency
  fields. Run `npm run verify:weapon-catalog` to prove that the checked-in extraction artifact
  and the runtime catalog still match the recovered 4.9.5 scene exactly.
  The shared weapon/unit/visual request-number boundary also preserves the recovered Json.NET
  types before this economy logic runs: C# `int` dictionary members are exact signed-Int32 JSON
  numbers, Gold coefficient floats are finite JSON numbers, and only the explicitly stringified
  `EquipWeapon.Index` is canonical nonnegative Int32 decimal text. Mandatory `discount` and
  `deliveryReduce` members cannot disappear or become null-backed zero values. This rejects
  JavaScript-coercible booleans, arrays, blanks, numeric strings, fractions, non-finite numbers,
  and out-of-range values without changing the later source-specific negative-price handling.
  `UpdateEquippedUnits` additionally keeps ArmyScreen's sparse true-only detail map: omitted flags
  mean false, while a present `wasEquipped`/`equipped` must be exact JSON `true`; empty details,
  explicit false/null values, and unknown nested keys fail with `CantEquipUnit` before loadout or
  tutorial-unit state is mutated.
- **Weapon upgrade lifecycle**: buffered actions `73`-`75` use all 165 recovered per-level
  Google2u tables across shop and Black Market families (11,640 normal-level transitions).
  Process startup validates those generated tables against the shared weapon-identity and Army
  Power authorities before gameplay or material-catalog publication: identity order and indexes
  must agree, every weapon must have exactly one more DPS row than upgrade transitions, and all
  WarBucks prices/durations must be positive safe integers with source-ordered durations. The same
  boundary requires 5,860 positive nondecreasing Gold prices across exactly the 79 Black Market
  tables that contain `WEAPONPRICE`, with one more purchase price than upgrade transitions.
  `Google2u.LMG_GSh` and `Google2u.LMG_Scifi` remain source-explicit omissions rather than receiving
  a default price. Accepted stage tuples and price arrays are deep-frozen before lookup maps exist.
  BuyWeaponUpgrade validates the old index and server-derived duration, including the recovered
  float32 `ceil(source * 0.8)` reduction while a verified subscription is active, debits the
  server-owned WarBucks price. The common weapon/unit timer
  revalidates both its catalog source and discounted result as nonnegative C# signed integers;
  fractions are not floored, negatives cannot become instant delivery, and non-finite or oversized
  values fail before a receipt is published. Receipt creation, normal activation, and instant
  completion also share an exact nonnegative application-clock boundary limited to the safe
  JavaScript/BSON Date range. Deadline addition is checked before publication; malformed clocks
  cannot be floored or clamped into an invalid receipt, early activation, or lower instant price.
  The upgrade creates the single shared
  `weaponDelivery` receipt used by
  LevelManager. Normal activation enforces its server end time; instant activation derives
  Gold from the recovered float32 `0.6325`/`-0.175` formula and the persisted delivery receipt.
  A delayed buffer may pay its earlier valid price but can never pay below the receipt-time
  server price. Both completion
  paths increment `boughtIndex` once, clear delivery atomically, return Unity rollback fields
  on failure, and inherit `BufferId` replay protection. Run `npm run verify:weapon-upgrades`
  to compare the generated price/time catalog with MainScene.
- **Black Market weapon offers**: action `217` returns the exact serialized
  `BlackMarketOfferData` contract and persists the same object into boot data. The existing
  weapon extractor now also XOR-decodes all 5,860 normal-level `WEAPONPRICE` Gold values
  across the 79 concrete Black Market rows that contain that purchase column.
  Active sets contain up to four unowned supported weapons for 24 hours and are deterministic
  across retries. New issuance/rotation first requires the authenticated zero-based player level to
  match one exact recovered rank row; only each shorter weapon-price table is then clamped to its
  own last level. Fractional, non-finite, negative, or out-of-catalog levels cannot create an empty
  or lower-rank receipt, while reading an already-active set remains level-independent. Buffered
  `BuyWeapon` redemption requires the authenticated stored offer,
  its unexpired deadline, zero WarBucks, and its exact level price. Weapon level and special
  feature come only from server state, and the wallet/ownership mutation remains atomic and
  BufferId-replay-safe. A shared validator protects progression read/publication, boot projection,
  action-217 replay/rotation, serialization, and redemption from non-finite expiry, unsafe issue cursors, duplicate or
  oversized sets, malformed identities/levels, and nonzero feature authority. Derived expiries
  and cursors are revalidated before persistence. Reading the same active action-217 set preserves progression identity
  and does not rewrite MongoDB. Issued offers currently use recovered feature index 0; the original
  remote selection weights, trigger schedule, feature weights, and OfferManager discount
  entitlements remain reconstruction gaps.
- **Daily weapon and unit rentals**: GetPlayerData issues the exact outer `Rental` object only
  after durable tutorial completion and once the zero-based player level reaches display rank 4.
  New issuance requires that level to identify one exact recovered rank row before the gate,
  candidate window, and deterministic selection seed; malformed or fractional levels are not
  floored into a lower offer pool. An already-live validated offer remains durable authority and
  replays without depending on a later level argument.
  The 4.9.5 MainScene values decode to a
  20-25% sale, a 12-hour free trial, a 24-hour offer, and 0/2/7 visual/weapon/unit weights;
  visual rentals are therefore deliberately not generated. Action `138` accepts only the
  recovered C# `"True"`/`"False"` `buyRentalDiscounted` form value or an actual JSON Boolean and
  returns the nested `RequestsResults` string
  consumed by the old aggregate parser. A free trial materializes one borrowed item, permits
  normal equip and Army Power only while its server deadline is live, then PvP, mission, or
  Arena `GameEnded` removes the borrowed authority, restores a replaced weapon slot, and emits
  the discounted sale variant. That cleanup now commits inside the same authoritative battle
  transition as rewards/lives and is cached in the mission, Arena, or ranked-match receipt;
  a process failure can no longer commit the battle while accidentally preserving the trial.
  One shared lifecycle validator protects progression read/publication, boot, equip, Army Power,
  acceptance, settlement, and redemption: item type, 20-25% discount, generation, previous-slot snapshot, and every deadline
  must be valid, while trial/sale expiries must remain inside the replacement-offer boundary.
  `NaN`, `Infinity`, unsupported visual authority, and contradictory imported intervals fail closed
  instead of turning a borrowed weapon or unit into permanent access.
  Numeric, lower-case, padded, null, array, and object Boolean aliases also fail before the service
  can choose between the free-trial and permanent-purchase inventory transitions.
  Permanent redemption recomputes the price from the stored
  catalog row and discount, atomically debits the authoritative wallet, and is idempotent on
  transport retry. Repeated trial acceptance or permanent redemption returns the existing
  result without incrementing progression revision or replacing an identical MongoDB document;
  legacy pre-migration match receipts retain a retry-safe post-battle repair hook.
  Exact original remote item selection is unavailable, so eligible unowned
  items use a documented deterministic replacement within the recovered three-level window.
- **Unit purchase, loadout, and upgrade lifecycle**: `../Tools/Extract-UnitCatalog.ps1` joins the recovered
  `LevelManager.behaviours` and `additionalBehaviours` arrays through each behaviour's
  `UpgradeSlots` GameObject to the `Google2u.ArmyUpgrades` master row. The checked-in artifact
  records 24 player-roster units, three non-purchasable turret helpers, and 18 newer table rows
  that have no LevelManager object in this client. Process startup validates that identity artifact
  together with the upgrade artifact as one immutable MainScene snapshot before constructing any
  gameplay or sync lookup. It requires matching provenance, exact ordered row families, unique
  bounded IDs, the recovered tutorial/helper sentinel shapes, and contiguous normal/special/Elite
  ranges derived from each player's `startingSpecial` and `startingElite` offsets. All 4,124 normal,
  684 special, and 216 Elite rows must retain safe prices, durations, parts, tier/slot ordering, and
  finite nondecreasing Army Power; every accepted nested row is frozen. A truncated or mismatched
  artifact therefore stops startup instead of silently changing unit economy or publishing a split
  database catalog. Buffered `BuyUnit`/`ActivateUnit` now supports
  the 23 non-tutorial player rows with exact XOR-decoded Gold/WarBucks prices, zero-based level
  gates, display unlock checks, initial tier state, atomic wallet/ownership writes, Unity rollback
  fields, and `BufferId` replay protection. All supported rows have `DELIVERTIME=0`, so BuyUnit
  grants ownership and the stock client's immediate ActivateUnit is a validated idempotent
  acknowledgement rather than a fabricated timer. The unit purchase mutation resolves the exact
  recovered player-level row before the zero-based gate, so an out-of-catalog integer or malformed
  number cannot manufacture shop eligibility even when a replacement caller bypasses the shared
  profile validator. `UpdateEquippedUnits` persists the tutorial
  Assaulter's first backend-visible grant and the full owned roster while enforcing the recovered
  two-per-category and three-mechanical-unit caps; invalid changes receive the exact 11406 rollback
  dictionary. Replaying an identical valid roster returns exact state, while a missing tutorial
  grant still persists once. The same extractor records 4,124 normal, 684 special, and 216 elite per-level rows
  across all 24 player tables, including absolute source offsets, tier, float ArmyPower,
  XOR-decoded WarBucks price, delivery duration, and Elite parts price. Buffered actions `77`-`79`
  use those rows to enforce separate normal and
  special cursors, promotion-gated special access, current-tier maximums, one shared unit-delivery
  receipt, server time, the same subscription-expiry-gated float32 0.8 duration, exact WarBucks
  debit, receipt-backed instant Gold cost, atomic completion, Unity rollback, and replay safety.
  Unit receipt creation, activation, and instant pricing use the same checked application-clock and
  deadline authority as weapon upgrades, so non-finite, fractional, negative, oversized, or
  addition-overflowing times fail before any item or wallet transition.
  `PromoteUnit` then validates normal-tier completion, the
  recovered one-based `UNLOCKTIER2`-`UNLOCKTIER6` level gates, maximum tier 6, ownership, and an
  empty delivery receipt before advancing only `tier`; the exact 11405 level error includes the
  diagnostics consumed by the client warning handler. The one-based value is derived only after
  the stored zero-based index selects an exact recovered rank row. A malformed rank therefore
  cannot pass a promotion gate, and its InternalServerError remains isolated to the buffered action
  without emitting misleading 11405-only fields. `UpgradeEliteSlot` action `209` now validates
  the relative Elite cursor and exact source parts/WarBucks cost, performs the immediate atomic
  debit/increment, returns the recovered `104`/`20902`/`20903` failures, and is replay-safe. Unit
  ArmyPower reproduces Unity float32 addition for normal, promoted-special, and bought-Elite rows
  and sums only equipped permanent units. Helper/unresolved rows and unproven offer discounts
  remain fail-closed. The authoritative ArmyPower service combines this unit component with the
  recovered weapon DPS and player-rank components. Rank power requires the stored zero-based level
  to select one exact 58-row source entry; the client-side post-load clamp is not reused to turn
  non-finite, fractional, negative, or oversized durable state into a believable first/final rank
  contribution. The service then persists the complete total through a
  progression-revision compare-and-swap. Run
  `npm run verify:unit-catalog` to compare both artifacts with MainScene and the recovered
  assemblies.
- **Daily rewards**: `CheckDailyReward` and `ClaimDailyReward` provide the recovered monthly
  `dailyRewardData` calendar contract, one UTC-day unlock, ordered replay-safe claim cursors,
  and a canonical action-1002 `claimRweard` day boundary: only the recovered `int.ToString()`
  decimal from 1 through 31 or the same replacement-client JSON integer is accepted, so coercible
  nulls, Booleans, arrays, and alternate numeric text cannot choose a reward day. A repaired client
  may instead use `claimReward`, but exactly one spelling must be present; equal or conflicting
  aliases fail before the ordered claim transaction rather than relying on property precedence. Claims return
  exact parser payloads for Gold, WarBucks, Arena Tickets, loose Bronze/Silver/Gold cards,
  and Bronze/Silver/Gold packs. All three currency branches use the shared nonnegative safe-reward
  balance guard before advancing the claim cursor, so invalid amounts, damaged wallets, or overflow
  leave the day retryable. The configurable ordinary and weekly Gold values resolve once during
  module startup as an immutable pair of exact nonnegative safe integers, with the weekly value no
  lower than the ordinary value; malformed policy stops startup rather than becoming JSON `null`,
  a rounded reward, or a later calendar-only failure. Direct policy selection also requires an
  exact day from 1 through 31 before ordinary-versus-weekly modulus logic.
  Wallets, inventory, achievement progress, the optional VIP pair,
  and the claim cursor commit atomically. The deterministic seven-position schedule and amounts
  are an explicit conservative replacement because the original remote live-ops sheet is absent.
  One time-aware authority validates the exact five-field snapshot at shared persisted reads and
  full-progression publication as well as before check, claim, or wire projection. Current-month
  year/month/date markers and ordered claim cursors must be valid, future calendars fail closed,
  and both sides of one publication use the same captured server time. Check, claim, and client
  countdown generation require that exact clock inside JavaScript/BSON Date support; malformed or
  fractional time is rejected instead of being floored into a believable UTC day. An expired prior-month
  snapshot is discarded before cursor validation because its rewards cannot carry into the new
  calendar; this narrow rollover rule does not repair damaged active authority.
- **One-time rewards**: action `161` accepts only the three source-backed Facebook Like, Twitter
  Follow, and notification-permission DBKEYs; the separate Facebook-login reward requires a
  successful authenticated provider link. The server credits their exact decoded Gold values once,
  restores them through `PlayerAnalyticsData.collectedRewards`, and shares one bounded marker
  validator across migration, grant/replay, boot, and every progression publication.
  Legacy IDs are preserved, but every present value must be exact integer `1`, matching Unity's
  key-presence collection check so malformed markers cannot reopen an already hidden reward.
  The response omits the presence-sensitive `WasAdded` property on replay so the stock parser cannot
  add local currency twice. The recovered `WeaponTutorial` and `UnitTutorial` paths are restricted
  to the exact AK47 and Assaulter parameters, require cursor zero and an empty delivery slot, and
  derive their 500/375 WarBucks plus 1 Gold funding from the same generated first-upgrade rows used
  by inventory validation. Unknown archived rows remain closed, and production proof of external
  social/platform actions still requires provider integration.
- **Assignments**: `GetNewAssignments`, both skip actions, assignment/mega claims, and the
  stock `SendRequestBuffer` path use a persistent UTC cycle. Only objectives derived from
  confirmed PvP settlement advance. Same-day `GetNewAssignments` reads preserve progression
  identity while the UTC rollover persists once; buffered claim retries are idempotent by `BufferId`, return
  the cached response without a revision/write, and never roll an unrelated UTC cycle. All
  assignment and buffer-envelope integers use the exact nonnegative C# signed-int boundary rather
  than JavaScript coercion. The `Requests` object must contain the exact contiguous decimal keys
  `0..Count-1` emitted by `requests.Add(requestCount++, value)`, and each nested entry must contain
  exactly the recovered lower-case `action` and `data` fields from `Request.cs`. Upper-case aliases,
  extra or missing entry members, and arbitrary, padded, negative, gapped, oversized, or nonnumeric
  keys reject the complete envelope before any action or mutation.
  Persisted daily-assignment authority is now validated completely at shared reads and progression
  publication as well as action/serialization boundaries: the exact three supported records must
  retain their recovered order, IDs and targets; progress fractions and done/claimed flags must
  agree; `completed` must equal claimed records; skip and mega counters must be typed and bounded;
  and issue/reset/day-key values must derive one UTC cycle. Corrupt records or counters fail closed
  instead of changing reward prices, bypassing comparisons, freezing rollover, or surviving an
  unrelated full-progression replacement. The deployment-owned currency-only mega Gold fallback is
  resolved once during module startup as an immutable exact nonnegative safe integer. Malformed
  policy therefore stops startup before players can earn or consume the 50-point cursor. A valid
  claim computes the checked final wallet balance before subtracting that cursor. The default 25
  Gold remains reconstruction policy while the retired production/non-currency reward table is an
  explicit unresolved gap.
- **Reward arithmetic boundary**: server-authored nonnegative currency rewards use one shared
  safe-integer addition guard before publishing their claim or receipt markers. Assignment,
  achievement, inbox, one-time, tutorial, conversion, level-up, lootbox, core-PvP, Elite-part, and War Arena rewards
  therefore reject invalid or overflowing balances atomically while preserving legitimate negative
  Gold or WarBucks chargeback debt. Before boot, those two debt-capable wallets and the nonnegative
  Tickets, Scraps, and level-experience fields must all be safe integers; invalid values fail closed
  before the Dynamo-style adapter can silently project a non-finite value as zero.
- **Squad Events (reviewed seasons only)**: action `113` joins the authenticated current roster to
  one immutable operator-configured season. Confirmed PvP wins/plays advance only recovered
  assignment IDs `7` and `8` as Unity-compatible binary32 fractions. Completing every assignment
  advances shared `ActiveTier` in the same match transaction and enqueues the recovered type-11
  `Tier`/`SquadId`/`Reward` message for every current member. Action `91` then credits that
  server-authored Gold exactly once and replays the original delta after a lost response. Final
  completion uses `ActiveTier == tierCount`; client `SquadEventUpdate` and claimed active tier are
  ignored. The complete shared row is validated before insertion, join replay, match mutation, and
  active-event serialization: exact fields and event/config identity, bounded squad identity,
  safe ordered dates inside the half-open season, non-exhausted revision, source-exact tier rows,
  binary32 fractions, completed earlier tiers, one incomplete active tier, and untouched later
  tiers. Empty schedules remain disabled, while an unreadable or invalid configured schedule, a
  future or incoherent row, changed live definition, or damaged stored event progress rejects match
  settlement before rewards rather than silently discarding a confirmed live-event contribution.
- **Limited-time Event Assignments (authoritative claim foundation)**: client actions `222`/`223`
  belong to the separate Christmas-style `EventAssignmentManager`, not Squad Events. A strict,
  non-overlapping, disabled-by-default operator schedule publishes the exact outer
  `EventAssignmentConfig`, UTC `Midnight`, and nested `EventAssignmentData` contracts. Daily and
  ordered milestone claims derive their active index, target, points, currency/parts/visual reward,
  and eligibility from immutable hashed server configuration; wallet/inventory/claim state commits
  atomically and `BufferId` replay cannot grant twice. A generic exact state validator protects
  shared persisted reads/publication and boot/serialization: IDs and lowercase SHA-256 digests are
  bounded, totals are signed-client-safe, day/milestone keys are canonical bounded sparse indexes,
  progress records are exact, and present milestone markers are only `true`. The active-config
  boundary additionally caps each day, requires claimed days to reach target, derives total points
  exactly from claimed rows, and requires milestones to be an earned prefix. Active selection, UTC
  day indexing, trusted progress, daily claims, and milestone claims require one exact Date-bounded
  application time; fractions and malformed clocks are rejected instead of floored into an active
  event day. Client `RewardType`, `RewardValue`, and
  `MilestoneId` are assertions only. The client-local destroyed-winter-box update is deliberately
  ignored until authoritative battle telemetry can advance the provided trusted-progress transition.
- **Daily/co-op/heroic missions**: actions `67`-`69`, `215`, `216`, and mission-flavoured
  `GameEnded` use the exact `DailyMissionsData`, `SavedMission`, and compact `MissionUnit`
  fields. UTC issuance, start receipts, consumed failure receipts, mode/index/order checks,
  no-write same-day boot/start/settled-receipt replay, durable expired-session pruning,
  separate solo/co-op completion, response replay, the 30-point heroic gate, and recovered
  completion currencies are persisted atomically. One complete lifecycle authority protects
  shared persisted reads/publication and all rollover/boot/action/serialization boundaries. It
  binds the exact three daily and five ordered Heroic mission/config/unit shapes, completion and
  reward flags, level/reward/point bounds, derived UTC reset tuple, source-backed Heroic target,
  and bounded unique active/terminal receipts with valid modes, indexes, results, timestamps, and
  cached JSON. Fresh Heroic unit-target selection validates one exact recovered player-level row
  before applying the documented bought-first/unlocked fallback, even when an already-bought unit
  makes the unlock pool unnecessary. Expired cycles still validate because Heroic progress and replay history carry over;
  malformed receipt history is never trimmed into new replay capacity. Cycle materialization,
  mission start, and settlement require one exact Date-bounded application time. Settlement reuses
  it for receipt expiry, VIP benefits, rank-up dog-tag refill, rental cleanup, and the terminal
  receipt, so fractions or malformed clocks cannot choose a UTC cycle or create mixed timestamps.
  The authenticated `DatabasePlayer.Level` must also identify one exact recovered zero-based rank
  row before cycle replay/issuance, reward selection, start, or settlement. That index is stored
  directly in `dailyMissionLevel`/`heroicMissionLevel` for the client's `+1` display conversion;
  only the row's one-based display number selects the recovered reward-table threshold. This fixes
  the earlier floor-and-subtract rank offset without inventing a new progression scale.
  Mission XP and WarBucks now reproduce the
  recovered `MissionsConstants` exponential level formula, per-slot `MissionsSettings`
  modifiers, upward-to-50 rounding, zero co-op-master share, and half co-op-client share. The
  result applies the source 1.5x/1.5x/2x VIP XP/WarBucks/GameGold rules, crosses exact rank rows,
  grants rank-up Gold, refills dog tags, and recomputes rank Army Power in the same guarded
  document write. Base `GameReward` components are cached with the receipt so retries cannot
  multiply or duplicate them. The archived server's random mission selection remains a
  reconstruction gap. Completing the fifth Heroic mission now also
  grants the exact level-row Bronze/Silver/Gold ten-card pack and one Elite part for the unit
  target persisted in `DailyMissionsData`; identities, inventory, currencies, and receipt commit
  together, with bought units preferred by the documented replacement selector. Daily Mission and
  configured Event Assignment part grants check the recovered signed-client parts width before a
  receipt or claim marker advances, so a near-cap unit cannot become unreadable after a valid
  server-authored reward. The daily cycle
  now cryptographically selects all six source reward variants after the rank-6 War Card unlock
  (currency-only before it); Bronze/Silver/Gold card variants grant their exact 8/5/3, 9/6/4, or
  10/7/5 level-row counts through `DailyMissionsCompletionRewardCards`. The missing production
  reward-type weights and `FROMMISSION` selector semantics remain explicit uniform/level fallbacks.
- **Starter assignments (authoritative subset)**: actions `185`/`186` restore the exact
  `StarterAssignmentsData` object and the MainScene-defined thresholds, order, Gold, and
  WarBucks rewards. Ranked wins, medal balance, level, lifetime squad points, the first replay-safe
  mission completion, confirmed War Cards played, the exact equipped secondary-weapon level for
  ID_7, and a server-granted Gold craft for ID_8 are checked against server state. Every numeric
  proof is validated as a nonnegative safe integer before a permanent completion marker is
  published, and both timed and subscription Gold-card crafts reject proof-counter overflow before
  clearing their receipt. One shared snapshot boundary validates the deadline as a nonnegative Unix
  second within the recovered C# signed-int width, the exact ten-ID namespace, Boolean
  completion/claim flags, and the rule that a claimed record must already be completed before
  creation, boot, completion, claim, or serialization. Non-finite and client-unrepresentable
  deadlines therefore fail closed instead of making a pre-completed onboarding reward permanently
  claimable. `STARTER_ASSIGNMENT_DURATION_SECONDS` is resolved once during module startup as an
  immutable exact value in that same domain, and initialization rejects issue-time-plus-duration
  overflow before addition. The default seven days remains explicit reconstruction policy because
  the production duration is absent from the recovered clients.
  If a buffered claim encounters corrupt durable state, its error adapter returns an expired empty
  client view while preserving the damaged database snapshot for operator repair; it never retries
  serialization of the rejected object or aborts unrelated RequestBuffer results.
  Buffered claims are ordered, atomic, reward-validated, and replay safe.
  Unit deployment remains disabled until that event source exists.
  All nested claim dictionaries now retain their recovered Json.NET numeric types before these
  transitions run: daily/starter assignment IDs and currency echoes, Event Assignment reward and
  milestone fields, and achievement IDs/progress cursors require nonnegative Int32 JSON numbers.
  Achievement `Offset` is the only signed Int32 exception because it represents pre-achievement
  local statistics. JavaScript-coercible nulls, booleans, strings, arrays, fractions, negative
  non-offset values, and out-of-range numbers stay inside the recovered per-action error result and
  cannot reach reward or claim authority.
- **Daily assignment cycle integrity**: `AssignmentData` keeps its private `dayKey`, `issued`, and
  `tomorrow` values as one server-authored UTC tuple. Rollover, PvP progress, skips, claims, mega
  claims, and serialization validate both timestamps as bounded safe Unix seconds and require the
  day key plus next-midnight reset to derive exactly from issuance. A malformed or infinite reset
  therefore fails closed instead of keeping one objective set and its claim surface active forever.
- **VIP entitlement integrity**: every paid-VIP consumer uses one validated nonnegative,
  safe-integer Unix deadline. PvP/mission multipliers, virtual dog-tag capacity, daily cards,
  VIP-only visuals, pack extension, purchase renewal, voided-purchase reversal, and boot migration
  reject corrupt or overflowing deadlines instead of treating `Infinity` as permanent access.
- **Subscription entitlement integrity**: one shared validator owns expiry, subscription-start,
  and dog-tag timer-lock timestamps. Boot projection, Google Play delivery/revalidation, upgrade
  timing, instant card crafting, and accelerated dog-tag regeneration reject non-integer,
  non-finite, negative, or non-`Date`-representable authority instead of granting permanent access.
  Shared read/publication requires the exact four-field shape and enforces
  `subscribeSince <= dogTagTimerLock <= expireTime`. Benefit activity now requires
  `subscribeSince <= now < expireTime`, and boot rejects a future start before serializing the
  expiry-driven stock-client model. Future starts and provider expiries that invert this interval
  therefore fail closed rather than activating or corrupting it.
- **Achievements (authoritative subset)**: actions `218`-`220` use the recovered
  `AchievementsData`/RequestBuffer contract. Solo missions, ranked wins, assignment completion,
  squad points, and daily-reward claims advance only from accepted server settlements. Purchased
  weapons/units, their normal upgrades, collected permanent visuals, and confirmed consumed War
  Cards are re-derived from authoritative progression snapshots. Visual group 15 includes the four
  recovered category defaults, then counts source-backed bought or parts-completed non-power-band
  rows from shop, event, assignment, pack, and lootbox grants; this maps the scene's 7/14/29 values
  to the platform labels for 3/10/25 collected equipment pieces without trusting client progress.
  Snapshot normalization retains only the minimum target of an already-claimed tier when a later
  chargeback removes inventory; larger unclaimed/imported totals are discarded.
  The exact 4.9.5 tiers for soldier deployment (group 6), vehicle deployment (group 7), and stolen
  crates (group 18) are present in the wire model, but their values are pinned to zero and their
  claim paths fail closed because stock `GameEnded.Stats` is self-authored combat telemetry.
  Accepted Arena wins and maximum-win runs without an accepted loss advance exact MainScene groups
  3 and 4 inside the Arena receipt transition, so retries cannot duplicate their Ticket/Scraps
  progress. Group 13 mirrors the authenticated profile's highest reached league tier and rejects a
  larger action-220 client value. Group 17 retains the largest validated, inventory-consuming PvP
  card list and grants the exact one-time 50,000-WarBucks reward at five cards. Group 19 completes
  only with an eligible type-9 Squad War settlement and exposes its exact one-time 5,000-WarBucks
  reward. Exact serialized MainScene tier rewards are granted atomically and replay-safely.
  A dependency-free durable authority now protects shared progression reads/publication and every
  normalization, projection, acknowledgement, increment, claim, and serialization boundary. It
  requires exact outer/group/tier shapes, bounded unique IDs, signed-client-safe offsets and values,
  bounded known/unknown tier arrays, ordered Boolean claim prefixes, known values no higher than
  their final recovered target, and no claimed known tier without its earned value. Missing groups
  and short known tier arrays remain schema-migration inputs; bounded well-formed future groups are
  preserved but cannot produce a reward without an explicit server definition. Thus duplicate IDs,
  `NaN`, oversized values, and forged claim markers cannot bypass completion gates or survive an
  unrelated full-progression replacement.
- **Squad social state**: action `193` persists the monotonic Photon Chat unread cursor through
  the stock request buffer and restores it as `PlayerAnalyticsData`; equal or stale cross-device
  cursor updates return the authoritative value without a false revision/write. Its buffered
  `data` must be the canonical nonnegative signed C# `int` decimal emitted by the recovered
  `PlayerAnalytics` setter; empty, padded, signed, leading-zero, fractional, exponent, or oversized
  text produces only that request item's `UnknownAction` result without mutating the buffer's
  working state. A repaired-client direct call must provide exactly one recognized timestamp alias
  as an exact C# Int32 form value or JSON integer; conflicting aliases, nulls, Booleans, arrays,
  fractions, and exponent text fail before cursor comparison. Both incoming and
  stored cursors must be nonnegative signed-client integers inside the bounded server-time skew
  window before shared persisted reads/publication, comparison, mutation, or boot; both snapshots
  in one publication use the same captured server time. Malformed/future durable state therefore
  cannot suppress later messages, poison the recovered C# `int` field, or survive an unrelated
  full-progression replacement. Squad-event notices are
  membership-validated, founder-targeted, durable, and duplicate-suppressed. The `/hub` replacement
  now persists moderated Squad Chat messages, returns recovered-size history, suppresses nonce
  retries, and fans out only to authenticated subscribers still present in the current roster.
  Multi-node delivery uses non-authoritative Redis notices followed by an authoritative MongoDB
   message/current-roster reload on each receiving node.
  All squad consumers now share one complete durable-document validator before using roster,
  leadership, admission, chat, card-pool, event, PvP reward, leaderboard, or Squad War authority.
  The validator requires exact fields; bounded normalized names, descriptions, emblems, and player
  identities; source-valid ranks and join policy; safe nonnegative counters; ordered timestamps;
  unique members and pending identities; exactly one Leader matching the founder; an exact
  source-row level/progress/capacity tuple; capacity-consistent
  membership; bounded request/invitation queues; and no pending identity already in the roster.
  Mutations validate the projected successor before writing. MongoDB's implicit `_id` is treated as
  read-only storage metadata and removed before `$set`, so settings and roster replacements cannot
  fail by attempting to update MongoDB's immutable identifier.
  Startup migration `20260722_012_recovered_squad_progression` rolls the old reconstruction's
  never-advanced experience counter through those thresholds and replaces its invented rank-one
  capacity. It plans every row before writing and stops for operator review if the recovered target
  capacity cannot hold an existing roster; migration never removes a member to make data fit.
- **War Arena (persistent core)**: login supplies the recovered Dynamo-style
  `WarArenaConfig`, while `EnterArena`, action-64/65 starts, Arena `GameEnded`, heart/life
  actions, scraps claims, rollover, and `GetArenaLeaderboards` use the exact `WarArenaData`
  contract. The nearest-Army-Power fallback validates every candidate's duplicated public profile
  mirrors before using its ID or power, without making public opponent selection depend on private
  credentials. Action `212` requires authentication, accepts only the active server-generated
  `ArenaId`, and retains a bounded two-year event-dialog acknowledgement history without exposing
  it in the public wire object. Replays do not increment progression revision or write MongoDB,
  and acknowledging a dialog cannot enter an event or grant value. The `UsedGold`, `UsedGolds`, and
  `hearthPrice` assertions accept only canonical nonnegative integer decimals from the recovered
  `ToString()` calls or the same safe JSON integers; only absent optional `UsedGold` selects zero.
  `HeartDialogShown` accepts only exact C# `True`/`False` text or a JSON Boolean. JavaScript-coercible
  nulls, arrays, blanks, alternate number syntax, lowercase Boolean text, and numeric Boolean
  substitutes therefore cannot select entry, heart, or scraps behavior. Runs and prices are
  server-owned. The safe Arena ID prefix, battle limit, life count, Ticket/Gold prices, and
  guaranteed-Scraps fallback resolve together during module startup as one immutable policy. The
  prefix leaves room for the monthly suffix; numeric values must be exact nonnegative C# `int`
  values, with positive lives and one-to-twelve battles. Invalid policy stops startup instead of
  being floored, clamped, replaced by a hidden default, or re-read midway through a run. Battle IDs
  are receipt-bound, and entry/start/result/heart/life/reward/end retries return their
  recovered response without a false revision increment or MongoDB replacement. Expired receipt
  cleanup remains durable because it unblocks a future battle. One complete lifecycle authority
  protects shared persisted reads/publication plus every Arena action and boot boundary. It
  validates known fields, nonnegative C# `int` counters and public crown/shield timestamps, only
  the recovered empty/bronze/silver/gold/flawless crown types, configured lives/win/top-run bounds,
  wins no higher than lifetime matches, bounded private timestamps and response JSON, Boolean
  flags, unique bounded opponent/shown-event collections, supported unique settlement receipts, and an
  active battle bound to the same Arena with no terminal duplicate. Only the absent legacy
  shown-event list normalizes empty; malformed durable history fails closed instead of being
  truncated into replay capacity or satisfying a reward gate. Arena achievement progress shares
  this receipt authority, and lifetime run/match/loss/flawless increments reject safe-integer
  overflow before publication. `GetArenaLeaderboards` has no request fields in the recovered
  client and parses one current `Items` array. Its query therefore requires both `played=true` and
  the exact current server-generated monthly Arena ID, preventing an unrolled prior-month profile
  from retaining a rank. The aggregation reproduces the client's flawless-first comparison:
  positive `flawless` values rank before non-flawless `topRun` values, followed by deterministic
  binary name and player-ID ties. Every selected full account, Arena snapshot, event identity, and
  final ordering is revalidated before `Position` and `WarArenaData` are returned; a dedicated
  current-event prefix index bounds the ranking scan. Historical boards are not added to action
  206 because the stock request has no season selector or history parser. Combat outcomes remain client-reported pending authoritative
  validation. The retired remote price/lootbox tables are absent from both APKs,
  so entry/heart/scraps values are environment-tunable and final lootboxes currently use a
  documented scraps fallback rather than fabricated inventory objects.

Unimplemented state-changing `DbAction` values return error code `90`. Post-login impression
actions `194` and `1007` are explicit authenticated no-ops, so their untrusted payloads cannot
change gameplay and an unauthenticated request cannot receive a false success. Action `179` is
also authenticated and remains non-authoritative, but can optionally retain its exact recovered
`PlayerAnalytics` JSON string for short-lived diagnostics. The narrow handler-less allowlist is
reserved for source-unproven crash action `141` telemetry. Action `92` now has a dedicated open
acknowledgement and optional authenticated retention path; the active action `166` support-log
contract is authenticated and durable as described below.
`handlerlessActionDispositions` records every other intentional dispatcher exception: actions that
run only inside the atomic RequestBuffer, client response/local-only values, retired contracts,
disabled debug mutations, the raw configuration route, open non-authoritative telemetry, and the
enum sentinel. `backendActionCoverage.test.ts` combines those groups with the live handler registry
and requires every recovered enum value to appear exactly once. Adding or activating an action must
therefore update its executable disposition instead of silently falling through error `90`.

### Client analytics ingestion

`CLIENT_ANALYTICS_ENABLED=false` is the privacy-safe default because the recovered client exposes
no separate analytics-consent field. When an operator explicitly enables it, action `179` requires
the normal gameplay session and exactly the source-defined `PlayerAnalytics` JSON object string.
The immutable startup policy bounds that UTF-8 value to 256-65,536 bytes, retains it for 1-90 whole
days, and admits 1-120 submissions per player/minute. Defaults are 32 KiB, 30 days, and 12/minute.

The atomic rate reservation uses an HMAC-hidden domain separate from inbox and Squad Chat quotas,
so concurrent nodes cannot pass a count-then-insert race or let diagnostics consume social capacity.
The stored row binds a server UUID, authenticated player ID, exact opaque bytes, SHA-256, byte
length, receipt time, and expiry; complete row validation rejects field, digest, JSON-shape, clock,
and retention corruption. A versioned migration installs player/time and TTL indexes. Action `179`
has no operation UUID, so an uncertain network retry may create a second diagnostic observation;
guessing deduplication from equal JSON would collapse legitimate equal submissions. Most
importantly, no gameplay service reads this collection: client Gold, inventory, achievement,
progression, or match values remain assertions even when preserved for operator analysis. Actions
`194` and `1007` remain authenticated no-ops until their original retention semantics are recovered.

### Client support logs

Action `166` now implements the active `BeanstalkServerManager.SendLogs` contract. It requires the
normal gameplay session, exact request `PlayerId`/`PlayerName` echoes, and the durable recovered
`SendLogs == 1` consent. The server stores only its authenticated ID/name snapshot, the exact opaque
`Logs` bytes, a strict bounded client-version string, SHA-256, byte length, receipt time, and expiry.
It then returns the server UUID as mandatory `LogId`; the stock success parser reads this field
unconditionally and displays it as the player's support reference.

`CLIENT_LOG_RETENTION_DAYS`, `CLIENT_LOG_MAX_PAYLOAD_BYTES`, and
`CLIENT_LOG_EVENTS_PER_MINUTE` resolve together once at startup. Exact supported ranges are 1-30
whole days, 1,024-1,048,576 UTF-8 bytes, and 1-20 uploads per player/minute; defaults are 14 days,
1 MiB, and two/minute. An independent HMAC-hidden atomic rate domain prevents simultaneous nodes
from admitting an upload burst without consuming inbox, Squad Chat, or action-179 capacity. The
versioned player/time and TTL indexes support direct support lookup and bounded retention. The
request has no operation UUID, so a lost response may produce another LogId rather than guessing
that equal text is a replay. Stored logs never authorize gameplay. Action `141` remains an open
non-authoritative acknowledgement because its only apparent sender is contradictory decompiler
junk with no trustworthy payload.

### Client error diagnostics

Action `92` implements both recovered `BeanstalkServerManager.SendErrorMessage` forms: failed
server-response parsing (`DbAction`, `ServerResponse`, and `PostParameters`) and generic message
parsing (`MessageToParse`). The stock wire contract reuses `DbAction` for the failed action's text
while `requestId` carries numeric action 92. Envelope normalization now preserves that collision as
`ReportedDbAction` before dispatch; contradictory numeric route/request copies still fail closed.

The action remains an open success acknowledgement because it can fire while login or player boot
is failing. Retention is stricter: `CLIENT_ERROR_ENABLED` is false by default, and a row is stored
only when valid session credentials attach the current account and its durable `SendLogs` flag is
exactly 1. Authenticated `PlayerName` must match the request echo. The two payload shapes are
exclusive, client version is bounded, and the complete diagnostic is SHA-256/byte-length bound in
an exact fixed-shape row. Defaults are 14 days, 32 KiB, and six retained events/player/minute;
supported immutable ranges are 1-30 days, 1,024-65,536 bytes, and 1-60/minute. A separate
HMAC-hidden atomic quota and versioned player/time plus TTL indexes bound concurrent-node abuse and
retention without consuming inbox, Squad Chat, analytics, or explicit support-log capacity. Error
rows are never read by gameplay services. Pre-login, disabled, and no-consent calls return the
stock success shape without storing sensitive data or triggering an error-report feedback loop.

### Administrative diagnostic reads

The independent admin Bearer credential protects `GET /admin/diagnostics/:kind`, where `kind` is
exactly `analytics`, `support-logs`, or `client-errors`. Optional `playerId`, `limit` (1-100, default
50), and `cursor` query parameters provide a stable descending `(receivedAt, UUID)` view without
granting gameplay sessions access to sensitive diagnostics. Cursors are canonical Base64URL JSON,
bound to the exact kind and player filter, and cannot carry a future timestamp.

`GET /admin/diagnostics/:kind/:id` performs an exact unexpired UUID lookup under the same admin
boundary. In particular, support can resolve the `LogId` displayed by the stock action-166 upload
without walking global pages. Missing or expired references return 404; malformed IDs return 400;
and a selected damaged row fails closed before any diagnostic bytes are returned.

Each selected row is revalidated through its complete family authority before serialization, and
one damaged row aborts the whole page rather than returning partial believable diagnostics.
Application-time expiry prevents TTL-monitor delay from extending operator visibility. Dedicated
global and per-player compound indexes support the cursor order. The response exposes only the
reviewed fields for that family; it never joins diagnostics to progression, purchases, rewards, or
combat authority. Deployments should place this sensitive endpoint behind their normal operator
network controls in addition to the required `ADMIN_SECRET`.

### Next

- **Squad extensions** — normal/Buddy pool deposits and withdrawals, configured Squad Events,
  reconstruction-scheduled Squad Wars, and persistent `/hub` Squad Chat with optional Redis
  multi-node fan-out are implemented. Type-28 card-pool request notifications validate same-roster
  membership and use daily actor/target idempotency. Add the Unity Photon/Photon-Chat-to-WebSocket
  adapters, recover the retired Squad Event calendar, and recover server-selected Buddy unit-type
  weighting. Source-backed FCM data wake-ups now use durable retry/deduplication for supported Squad
  inbox rows; visible notification copy remains an external platform/presentation gap.
- **Item economy expansion** — unit Elite upgrades, normal shop visuals, Gold lootbox bundles,
  weapon/unit notification acknowledgements, normal card-pack
  purchase, dedicated Black Market weapons, daily weapon/unit rentals, and complete active-loadout
  ArmyPower, periodic VIP visual-part lootboxes, and the exact five-card Play Warcards tutorial
  reward are implemented. Add the remaining authoritative combat card reward/consumption events,
  server-selected card/Buddy RNG, and source-backed Arena/loyalty/hidden visual reward delivery.
  Normal unit purchase is authoritative for 23
  non-tutorial roster units, and the tutorial unit is persisted through its first equip event;
  three helper rows and 18 ArmyUpgrades rows without LevelManager objects remain closed. All 84
  resolvable shop weapons and 81 concrete Black Market weapons support authoritative equip/upgrade
  state; the nine unresolved rows in each weapon family, two Black Market rows without
  `WEAPONPRICE`, unknown items, and
  unrelated discount-bearing requests remain rejected instead of receiving guessed prices or unusable
  inventory records.
- **Player leagues** — the server owns source-backed 16-tier placement and season state,
  exact weekly-medal division ordering, recovered promotion/relegation percentages, the
  30-player underfilled rule, Champion/underfilled Gold rewards, and transactional action-198
  settlement with type-23 inbox results. Confirmed PvP also advances the three beginner stages
  using the recovered 100-player rank curve, 50/100/150 maximums, 40/35/31 promotion positions,
  and Unity-compatible rounding; UI-only random rank jitter is never backend authority. The final
  stage atomically emits the stock normal-league handoff fields and enters the managed Bronze
  division. The local UTC-aligned allocator uses a transactional tier/window counter to create
  stable `localN` divisions of exactly 100 committed admissions; allocation shares the confirmed
  PvP transaction, so an aborted settlement cannot consume capacity. The complete returned counter
  must retain exact fields, tier/end/season-key identity, a positive safe ordinal, signed-client-safe
  end time, ordered dates, and an update equal to the current in-window transaction time before that
  ordinal becomes a division ID. Pre-upgrade `local` divisions
  are never split mid-season and finish under their original immutable ID. The retired production
  assignment policy and final beginner weekly-medal reset remain explicit reconstruction policy.
- **Arena fidelity / league operations** — recover production arena prices, rules, opponent
  weighting, lootbox/crown inventory payloads, and authoritative combat evidence; add bounded
  league division documents and scheduled settlement; verify the final beginner weekly-medal reset
  from an archived service response. Arena debug mutations remain rejected.
- **Mission fidelity** — recover the original mission-selection and daily-reward-type weighting,
  exact `FROMMISSION` card eligibility semantics, and production Heroic unit selection weighting
  to replace the documented uniform and bought-first cryptographic fallbacks; add combat-result
  validation.
  Recovered groups 6 and 7 count the individual soldier and vehicle entities passed to
  `MatchStats.DeployUnit`, not deployment clicks or War Card use; group 18 counts crates stolen.
  All three stay unclaimable until the relay can validate those combat facts. Group 17 uses
  accepted owned-card consumption but still
  shares the documented missing live card-event-validation boundary.
- **PvP reward tuning** — XP/medal/squad values in `matchService.REWARDS` remain reconstruction
  policy. Normal WarBucks uses server-owned `PVP_WIN_WARBUCKS` / `PVP_LOSE_WARBUCKS` defaults
  because the retired Fusebox `BattleWarbucksRewards` document is not present in either APK;
  client-echoed reward values are never trusted. VIP's 1.5x WarBucks multiplier is source-decoded.
  Both deployment values are validated once during module startup as exact nonnegative integers no
  greater than 1,431,655,765, which keeps the independently truncated VIP component inside the
  recovered C# signed-`int` field. Invalid policy stops startup rather than silently restoring the
  800/400 defaults, and the resolved policy remains immutable for every match in that process.
- **REST result consensus** — `MATCH_RESULT_CONSENSUS_WAIT_MS` is an exact integer from 0 through
  15,000 and bounds the read-only wait that lets the first stock `GameEnded` request receive the
  receipt committed by the second agreeing report. Zero returns the pending response immediately.
- **Win-streak fidelity** — the 200-second interval and nine valid WarBucks tiers are decoded from
  MainScene and persisted authoritatively. The corrupted/unusable tenth value is capped at tier nine
  until archived live balancing is available. Shared progression read/publication first validates
  the exact two-field shape, count range, zero-pair invariant, and signed-client timestamp bound
  without consulting the wall clock, keeping MongoDB retries deterministic. Settlement and boot
  then add the authoritative non-future comparison:
  count is limited to 0-9, zero requires timestamp zero, and positive streaks require a non-future
  signed-client-int Unix second. Corrupt counts are rejected rather than clamped into tier nine,
  and future timestamps cannot enter the recovered client's permanent `isInfinite` display path.
- **League win rewards** — the three beginner and 16 normal MainScene WarBucks/squad-point rows
  now settle from authenticated player state, use the exact lower-case `squadPoints` response key,
  and apply VIP independently without trusting client reward echoes.
- **Medal consistency** — confirmed results update both global `Skill` and weekly
  `MedalsBalance`; immutable receipt snapshots keep retries from presenting later battle state.
- **Client integration** — form request routing is implemented, but exact response keys for
  every action and the Photon→WebSocket client repoint remain `⚠ RE-NEEDED`.
