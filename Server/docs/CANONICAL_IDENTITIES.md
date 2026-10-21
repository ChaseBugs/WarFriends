# Canonical server identities

C24 closes the gap between parsing a GUID and validating the exact identity stored or signed by this
server. The existing contract requires 32 lower-case hexadecimal characters in N format. A valid GUID
parse alone does not prove that contract: Guid.TryParseExact accepts surrounding whitespace, and
ordinary distinct-string checks can then treat two spellings of the same GUID as different players.

## One lexical policy

War.Shared.CanonicalGuid.IsCanonical checks the exact length and ASCII character set with an ordinary
bounded loop. It performs no parsing, trimming, casing or string allocation. The portable netstandard2.0
assembly gains no server-only dependency. All former GUID parser-based checks in authored Server/src
now use this policy, including manifest/admission, terminal evidence, durable allocation/queue/grant
state, simulation owners/events and the SDK's grant/event/snapshot readers.

This is a format policy. It does not establish account existence, ownership, session validity, UUID
version, reward eligibility or replay authority. Existing signed/session/roster/revision predicates
still own those decisions. A 32-character zero GUID is a canonical spelling; this change does not
invent a UUID-version restriction absent from the existing contract.

Opaque provider IDs, custom match IDs, source/content identities and non-GUID request families retain
their own rules. No client identity is normalized to make it pass. The original recovered 1.4.0
GetServerRequest sends currentPlayer.id unchanged; the fresh server issues lower-case N GUIDs. The
recovered Client project is unchanged, and SDK checks remain distinct from real Unity gameplay.

## Authority boundaries

MatchManifest rejects a padded/uppercase/malformed player before its raw-string distinct set can
accept an alias. Allocation and presentation projections require the same spelling. Canonical
terminal players, winners and GUID-shaped private evidence are checked before publication.

Both probe and match ticket issuers validate an owned claim snapshot before signing. Match session-key
derivation checks the same identity. Readers independently reject correctly MACed malformed claims;
authentication cannot bless invalid identity shape. Queue issuance/control-grant readers retain their
existing owner, expiry and purpose checks around the common policy.

CoverOccupancyRegistry no longer parses and rewrites a supplied owner before claim/release. It checks
the original text, then compares that exact owner. A padded or uppercase alias cannot release another
player's claim or acquire a new one.

LegacyPlayerIdentityAuthority is separate from economy calculation. Shared account/authentication,
list reads, buffer planning/publication and root projection validate durable identity before use.
Existing feature publications validate their committed identity too. Truly new account drafts do not
yet own an ID: creation validates its existing starter/registration authority, generates the server's
ID, then validates that identity before credential derivation/insertion. A caller's unused draft ID
does not become authority.

Modern AccountStore.Login validates the stored profile before password derivation and token rotation.
An invalid durable ID therefore cannot rotate the session and only then fail while projecting its
response. Both modern authentication and legacy reusable reads refuse malformed durable identity.
This lexical boundary does not replace C13's complete BSON/subsystem shape and migration work.

## Damaged historical records

Malformed stored IDs are rejected, not trimmed, lower-cased or assigned a new value during traffic.
An alias can already conflict with another account, signed token, roster, receipt or guild reference.
Automatic normalization would merge authority without evidence. Existing state and claim capacity
remain unchanged on refusal. Operator repair needs a reviewed account binding and complete reference/
receipt preimage plan; general migration tooling remains C13.

## Verification

Five protocol groups compare the policy against an independent BCL parse-plus-roundtrip oracle,
including every ASCII substitution at all 32 positions, padding/control/Unicode/alternate-form cases
and valid zero/random GUIDs. A warmed same-thread allocation check observes zero managed allocations
for the format predicate. Correctly MACed malformed probe claims and SDK grant shape are refused.
This is a local allocation observation, not a network latency or throughput benchmark.

Five in-memory battle groups cover the original same-GUID/different-string manifest reproduction,
allocation no-repair behavior, cover claim/release conservation, issuer/session-key refusal, independently
signed malformed admission and terminal/winner rejection against actual engine-produced evidence.

Four Mongo groups reject malformed modern account IDs during authentication/login without changing
the document. The existing root fixture adds four alias families across reusable single/list/password/
token reads, buffered planning and three HTTP routes. No calculation, state publication or receipt is
allowed. Three correctly signed malformed-control rosters return 400 without active/terminal journal
publication in native smoke. All storage cases reuse an already-owned replica; no extra service is
created by the focused selectors.

```powershell
dotnet run --project Server/tests/War.Protocol.Tests --no-build
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --canonical-identity-only
# Uses an already-running owned Mongo replica.
dotnet run --project Server/tests/War.Battle.Tests --no-build -- --canonical-account-store-only $env:Mongo__Uri
```

Run IDs, final integrated results and disposable-data cleanup are recorded in [TESTING.md](TESTING.md).
The zero-warning/error solution build, full 20-stage runtime checkpoint, native signed-control smoke
and legacy Mongo/HTTP smoke passed. A final source audit found 217 shared policy calls across the
seven projects and no remaining authored GUID parser gate. The later temporary-path/runner change
passed its focused Worker/UDP and army-perk cases plus the 19-stage fast gate.
S04's remaining content/simulation extraction, C13/C18, V07 and actual Client gameplay are independent
open boundaries; identity-format verification does not close them.
