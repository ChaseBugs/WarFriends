# Legacy account and session publication

The guest account channel now separates form parsing, a frozen starter policy, account service,
HTTP projection and persistence under `War.Backend/Legacy/Accounts` and
`War.Persistence/Legacy/Accounts`. The mutable `LegacyStarterState` is configuration input only;
it is copied into `LegacyStarterPolicy` before traffic. The legacy dispatcher retains the original
PHP filename/action IDs and delegates account creation/login to this feature.

## Source contract and metadata

`BeanstalkServerManager.CreateAccount` in the active 1.4.0 Client sends required `Locale` and invariant
`UtcOffset`. Its optional Fusebox `StartingGold`/`StartingWarbucks` fields are assertions and never
starting-wallet authority. `ServerTime.GetUtcOffset` returns hours from two separate clock captures,
so small fractions/exponent notation are legitimate diagnostics. The parser accepts finite invariant
C# numeric text, bounded to +/-24 hours as an explicit diagnostic sanity limit. It never uses that
value for clocks, calendars, rewards, session expiry or deadlines.

Locale must satisfy the existing server locale grammar, including the recovered `kr`, `jp`, `cn`,
`tc` and `br` codes. Guest creation does not require DeviceToken because the recovered builder does
not send one. Replacement callers may provide it; an explicitly empty/null-literal/multiple-valued,
control-bearing, whitespace-only, oversized or invalid-UTF-16 token refuses the request. Valid opaque
values, including surrounding spaces, are preserved without trimming or rebinding an identity.
The reusable persistence entry validates registration metadata again before credential work.

The same opaque validation now protects action 13's complete `DeviceToken`/`Locale` tuple. Either
missing/malformed member refuses the mutation without changing either field, revision or presence.
Creation's missing optional token remains distinct from this direct action's required token.

`CreateGcAccount` retains a closed provider boundary: validate Locale/UtcOffset and the exact nonempty
GameCenterId, then return ServerMaintenance without creating an account or contacting a provider.
No provider credential, identity link or external-service boot dependency was enabled. Valid platform
ID text is not trimmed into another identity, and unsupported provider creation is not counted as a
missing guest feature.

## Starting state and startup policy

Source constants for starting Gold/WarBucks and dog-tag capacity/period are checked as unique exact
nonnegative integers. Their raw JSON decimal/exponent representation is validated without floating
point or decimal underflow rounding: `75.1`, `1e-100`, a tiny nonzero fractional tail and overflow
cannot turn into an accepted integer. Positive cap/period multiplication must fit Client Int32.
The current source yields 75 Gold, 15,000 WarBucks, 5 * 900 = 4,500 dog-tag seconds and one placement
match. LeaguePlacementMatches is now a required catalog integer; it replaces the unevidenced
ten-match server default. Deployment starting placement must stay inside zero or one.

The snapshot validates nonnegative wallets/placement count, rank index 0-42 from the recovered
43-row level table, positive dog-tag capacity, positive whole session hours with supported date
arithmetic, and a bounded control/semicolon-free sheet version. Existing defaults, including starting
rank index 1 and the 24-hour session policy, are preserved as reconstruction/deployment choices;
this does not invent missing production server policy.

Account creation now runs the shared root wallet/rank/tier/counter validator before password work.
Typed account reads now require twenty present exact BSON integer fields and refuse invalid root
authority before authentication, login rotation or projection. Existing placement-ten documents
and missing numeric fields are not repaired during login; see
[STORED_STATE_VALIDATION.md](STORED_STATE_VALIDATION.md) for migration prerequisites and open schemas.

An omitted Legacy:ContentPath retains the documented catalog-free compatibility defaults. A configured
missing, malformed or empty catalog now fails startup instead of silently changing starter currency
to those defaults. Full catalog/release validation and an explicit deployment-mode policy remain in
C12/C16; validating this starter snapshot does not validate all 132 sheets.

The reviewed InventoryData/LevelManagerData/DecalManagerData initial blobs remain source-exact and
are copied into an independent per-player container. No Client assets or generated source artifacts
were rewritten. The other missing subsystem blobs retain the Client's own LoadEmpty behavior.

## One initial insert

`LegacyAccountService` builds server-owned starter fields. Persistence revalidates metadata, starter
bounds, application time and session date arithmetic before generating a password or running PBKDF2.
One captured nonnegative Client-width Unix second owns CreatedUtc, LastAction, DogTagLastUpdate and
the response Time. Initial session expiry derives from that same application time.

Before the only insert, persistence generates the account ID, random password/token, salted password
hash, token hash and expiry. The insert commits those fields, Locale/optional DeviceToken, the UTC-offset
diagnostic and initial blobs together at revision 1. Plaintext credentials return only after successful
insertion. There is no empty SessionHash insertion or second IssueSession write, and the old unvalidated
Insert API was removed. A failed insert publishes no account and returns no successful credential result.
The unique sparse SessionHash index remains unchanged; historical empty strings are not deleted or
rewritten merely to free that index slot.

Create's required callback fields remain Player, Token, Password, PlayerData and Time, with optional
AccountType included. Login's required Player/AccountType/Token/Password remain present; it still
fetches PlayerData separately. Credentials and metadata are not printed in test output or error logs.

## Rotation and historical damage

The password work factor remains PBKDF2-SHA256 with 600,000 iterations, a 16-byte salt and 32-byte
derived key. Stored iteration values never select arbitrary work. Missing-account verification still
does equivalent password work. Login validates existing session/credential authority before issuing
a replacement; an empty/malformed hash, invalid dates, exhausted revision or malformed credential
material cannot become an automatic repair.

Rotation re-reads the account, confirms the verified credential material still matches, validates its
current session, and compare-and-sets the current revision. Up to four attempts handle concurrent
account updates. A deleted account or changed credential produces no token result. The returned token
is paired with the exact committed document/revision, rather than mutating an old in-memory snapshot.
Two concurrent logins may both commit in sequence; this remains a single-session model in which the
latest token retires the earlier one. A valid expired session can renew through its password; an expired
bearer cannot authenticate.

Malformed historical authority is refused and logged through the Client-readable maintenance result.
It is not silently reconstructed from the supplied password. This is not a complete validator for every
player/progression BSON field; C13 remains open. Anonymous CreateAccount has no recovered per-intent
nonce, so this does not claim permanent guest-registration replay or recovery of a lost first response.

## Verification and fixture cost

- `--legacy-account-only`: four grouped metadata/parser, exact source-number, immutable startup-policy
  and session-date scenarios, including a configured missing catalog.
- `--legacy-account-store-only <mongo-uri>`: seven real-Mongo scenarios cover rejection before password
  material/write activity; four concurrent one-insert registrations; injected insert failure;
  historical empty-hash refusal without repair; valid expired renewal; concurrent rotation/deleted
  account/changed credential; and injected rotation failure. Command observation verifies that initial
  inserts already contain session material and revision 1.
- `--legacy-account-http-only <uri> <database> <base-url>`: 28 real HTTP assertions cover required input,
  closed provider behavior, source starting balances, exact metadata/time, mandatory response fields,
  login/retired tokens, invalid device tuples, historical damage and parallel registration.

LegacySmoke runs these with the existing buffer/card-pool/squad checks in one owned Mongo process.
It now also runs allocation/inventory and rematch-manifest storage selectors so the shared account
fixture migration is exercised. Thirteen transport/gameplay fixture insertion sites now use explicit
trusted raw setup through `LegacyTestAccounts`, preserving their known token identities and skipping
password derivation that those tests never verify. Actual account creation/password tests retain the
real work factor. Live queue fixture execution remains its separately selected gate.

No extra Mongo data directory or Unity copy is created by these groups. Successful runs discard their
owned database files and retain compact logs under the selected WAR_TEST_RUN_ROOT. Windows native
proof does not establish Linux service execution, Unity gameplay, WAN capacity or a password-hashing
performance benchmark.
