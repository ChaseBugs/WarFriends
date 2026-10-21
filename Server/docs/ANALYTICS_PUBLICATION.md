# Shown-once analytics and buffered chat markers

This implements C21 against the active recovered 1.4.0 Client. The acknowledgements are monotonic
Boolean updates. They grant no currency, inventory, achievement, combat result or receipt entitlement.
Client files and assets remain unchanged.

## Source contracts

| Action | Stored field | Recovered behavior |
| --- | --- | --- |
| 163 ChatShownFirstTime | chatShown | Empty per-action payload; optimistic builder and success callback set true |
| 168 CustomizationShown | customizationShown | Empty payload; builder/callback set true |
| 169 WarpathShownFirstTime | warpathShown | Empty payload; builder/callback set true |
| 180 CardpoolShown | cardpoolShown | Empty payload; callback also schedules local notifications |
| 182 LeagueLeaderboardShown | leagueLeaderboardsShown | Empty payload; builder sets true; no response-switch case |
| 183 CraftingShown | craftingShown | Empty payload; builder/callback set true |
| 213 ElitesFeatureShown | elitesShown | Dedicated request sets true; success callback only logs |

No success callback indexes response fields, so the existing plain Result acknowledgement is enough.
Diagnostic Name/Flag/Value fields cannot select the property or supply authority. The Backend maps
only these action IDs to the closed LegacyAnalyticsFlag enum; unsupported enum values fail before
database access. Existing UpdateAnalytics remains non-mutating: its four-field client delta is not
a complete progression snapshot and cannot replace private server state.

The recovered base LoadEmpty uses Activator.CreateInstance. Its data fields start with false/zero,
two initialized dictionaries and a nullable transaction list. Only a genuinely absent subsystem may
select that construction path. Present BSON-null, JSON null, blank, non-object or malformed state
is refused; none is reset to a fresh claimable object.

## Structure and serialization

`War.Persistence/Legacy/Analytics` owns the shared JSON contract, flag identities and publication.
`War.Backend/Legacy/Analytics` owns action mapping and callback shape. The old SetAnalyticsFlag
router method was removed. Generic SetSerialized refuses analytics, as it already refuses Settings.

LegacyAnalyticsContract covers all 33 recovered mutable fields: exact nonnegative client-Int32
counters, nine Boolean fields, nullable source text, bounded finite nonnegative source-float money,
integer maps and transaction history. A present transaction row requires all five source members
(id, p, gold, wb, money); source-null p/history remain valid. Known-field case aliases, scalar string
coercion and partial/null transaction rows are refused. Nonzero float underflow is rejected even
when the exponent also underflows a double, rather than becoming a zero monetary observation.

The common envelope enforces unique decoded names, finite numbers, one MiB UTF-8, depth 32 and
65,536 nodes. Accepted unknown root/transaction metadata survives unchanged in value and numeric
text, including Int64.MaxValue and decimal text beyond double precision. Validation-only shared
reads use JsonDocument; a mutable JsonObject is built only where a feature needs a patch. No partial
DTO serialization drops unknown data, and no malformed history is truncated to fit a limit.

Present paid-VIP lootbox countdowns require 1-4 under reviewed authority. Paid Instant Battle
five-battle groups cannot exceed the recorded lifetime battle count. These checks do not establish
the full VIP/Instant Battle lifecycle, catalog identities, purchase/claim receipts or reward policy.
Missing-field migrations and absent countdown policy remain explicit C13 work; a flag update does
not fill unrelated progression fields or turn a source constructor default into reward authority.

## Publication and interleaving

MarkAnalyticsShownAsync captures one supported application time and makes at most eight attempts:

1. Read and validate the current account, analytics, session and present Settings.
2. Require the authenticated session hash and an unexpired session.
3. Return the current account without writing if the selected flag is already true.
4. Patch only that property on the current JSON object and validate its full successor.
5. Compare-and-set the current Revision, same SessionHash and live deadline; increment Revision
   once. Retry a same-session revision conflict against the newly committed snapshot.

Two flags therefore accumulate instead of overwriting each other. A buffered chat update committed
between the read and write also survives the retry, along with its receipt and exact metadata.
Session rotation/expiry refuses publication. A failed database write leaves the old document intact.
These monotonic flags need no per-intent receipt: repeating true has no additional effect and does
not consume a revision. This does not solve nonce identity for economic/profile replacement actions.

Shared single/list account reads, both authentication channels, account creation before KDF, boot,
buffer planning/current-player reads and buffered successor publication use the same contract.
Damage is rejected before a success, mutation or buffered receipt can be published. The pending
buffered action does not get to normalize a corrupt analytics snapshot.

SaveLastSeenSquadChatTimeStamp (193) now reads/writes through this contract too. A missing subsystem
can accept its first valid marker before any shown flag has been sent. Its payload must be exact
canonical nonnegative Int32 text from the original setter; signs, padding, leading zeros, fractions
and exponents return the existing per-action WrongPlayerData without an analytics mutation. Valid
markers advance monotonically; this change does not invent a future-timestamp tolerance policy.

## Verification and remaining scope

Seventeen source sections add the unchanged field declarations, transaction model, constructor
body, six builders, five callbacks, dedicated Elite builder/callback and chat property. The prior
47 hashes remain unchanged; that increment reached 64 entries, with the later tutorial review
bringing the current total to 71. Executable source runs against
instrumented request, notification and constructor boundaries, with no Editor, project clone,
native Unity or retired service. It is not normal gameplay or notification-delivery proof.

Four headless groups compare every known field/case alias with the actual source model, check
source acknowledgements/defaults and chat monotonicity, reject corrupt/underflowing values and prove
exact unknown numeric preservation. Eight Mongo groups force both flag reads before writes, actual
buffer transaction interleaving, rotated/expired sessions, damaged state, invalid internal successors,
generic/unsupported bypass refusal, repeated true flags and server-rejected writes. They reuse the
existing owned replica and trusted fixtures without password derivation.

Seventy-nine live HTTP assertions exercise all seven routes, diagnostic non-authority, replay,
ordinary boot and damaged state/authentication/peer-read refusal with unchanged raw BSON and no
new buffer receipt. Test runs and storage reclamation are recorded in TESTING.md.
The final build had zero warnings/errors. All 18 runtime/native stages passed, including 267,663
full Battle assertions; final legacy smoke passed 694 combined assertions and the separate
storage/fault groups. The detailed run IDs and scope remain in TESTING.md.

Complete analytics reward/receipt lifecycles, private subsystem schemas, durable migrations and
the remaining broader combat/reward integration are still open. C21 does not make C13 or backend reconstruction
complete, and it does not imply Unity/Android, production Linux or measured capacity verification.
