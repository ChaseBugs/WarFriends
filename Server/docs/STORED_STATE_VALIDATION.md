# Stored legacy state: JSON, Settings and root economy

The C13 increments strengthen typed state serialization, notification Settings, direct profiles and root numeric
authority. They do not certify the whole account/progression container.

## Typed subsystem reading and publication

`PlayerState` retains its public API and namespace. The 14 existing DTOs now live one per file under
`Legacy/State/Models`, with the same type identities, JSON names and nullable source identities.
`LegacyStateObject` retains unmodeled root/nested metadata as JsonElements during known-field writes.
Exact Int64 metadata survives without passing through a double projection.

| Input | Current behavior |
| --- | --- |
| Missing dictionary key | Explicit model construction path; no present state is discarded |
| Present null dictionary value or JSON `null` | Invalid durable state, never a new empty object |
| Empty/blank text, non-object root, duplicate property | Refused before interpretation/publication |
| String in a numeric field | Refused; integer dictionary keys do not need scalar number coercion |
| Case alias of a known DTO field | Refused to avoid disagreement with Newtonsoft's case-insensitive binding |
| Required model/map/list or model-row null | Refused; nullable source string identities remain permitted |
| Unknown metadata | Preserved where the feature permits it; never promoted to price/reward authority |

The recovered BuddyCardData appearance map has no initializer and can be null; that exception is
explicit. Card-pool mutations retain their reviewed stricter unmapped-field refusal rather than
silently ignoring unknown inventory authority. Refusing a mutation preserves its input; it does not
strip metadata to make the operation pass.

The shared serializer options are read-only. The common JSON envelope requires an object, unique
decoded property names and finite numbers, with explicit server resource policy of one MiB UTF-8,
32 nesting levels and 65,536 nodes. Known integer dictionaries require canonical Int32 key text.
Serialization checks its successor too, rejecting duplicate/case-shadowing extension data and null
required containers before publication. These limits are resource policy, not recovered economy data.

Readers of persisted dictionaries use the key-aware overload to distinguish absence from a present
null value. Invalid typed state raises InvalidDataException, separate from malformed client payloads.
Legacy authority middleware maps that refusal to the existing maintenance result before a success
body starts. A transaction that cannot read valid state must not publish its mutation or consume
the action's receipt. Existing correctly handled payload errors keep their per-action JSON result.

## Complete notification Settings

Source evidence is SettingsManager.Settings/LoadEmpty/OnDialogClose, the action-165 builder and
OnSendSettings. The request is one JSON string named Settings, containing exactly six Boolean fields:
challenge, squadStatus, squadEvents, maintenance, playerLeague and dailyRewardNotification.
The callback reads no response fields; successful acknowledgement clears the manager's dirty flag.

The request parser refuses partial/unknown fields, duplicates, case aliases, null, arrays, numeric or
string Boolean substitutes and repeated form values. Its separate request budget is 4 KiB UTF-8.
The immutable parsed value cannot be built through an unchecked public constructor.

`Legacy/Preferences` owns the adapter; `War.Persistence/Legacy/Preferences` owns request/durable schema
validation and publication. Present durable Settings requires all six flags. It may retain bounded
unmodeled metadata that does not shadow a source field. A complete replacement updates the six flags
against the latest account while conserving that metadata and unrelated subsystem blobs.

One captured application time owns session checks. A single Mongo FindOneAndUpdate binds expected
account revision and authenticated session; definite conflicts re-read and merge current metadata,
bounded to eight attempts. Session rotation refuses the old caller. An uncertain write is not retried
by the application as a fresh operation. The old generic Settings blob-write bypass is closed.

Authentication in both legacy channels, credential/session rotation and PlayerData projection validate
present Settings. A damaged present snapshot is not repaired by login, boot or a new request. Missing
Settings stays absent: the unchanged Client's LoadEmpty enables five notification flags and leaves
maintenance false. An explicit complete all-false request has different intent and remains valid.
These are full flag snapshots; no source-supported per-field intent or nonce exists, so an old replay
after later user choices cannot be identified as a new versus old intent without protocol work.

## Root BSON and economy authority

`LegacyPlayerEconomyAuthority` owns one reusable root check at account creation, shared account
reads, both authentication channels, buffered planning/publication, card-pool/squad actor/peer
transaction reads and legacy root projection. Selected player lists validate every returned member
before the caller can publish a partial result. Cached buffered success cannot bypass current-root
validation. Invalid authority refuses the operation before calculation or receipt consumption.

Twenty numeric fields require persisted BSON Int32 or Int64 values, including explicit presence.
Strings, doubles (even integral values), Decimal128, Boolean and null do not become counters.
The fifteen client-Int32 fields also require that width before deserialization; five amounts retain
the full nonnegative Int64 domain used by ServerResponseHandler.LoadPlayerData. No floating point
conversion or hidden zero construction occurs. Their writers retain the existing BSON widths.

The check covers nonnegative wallets/experience/counters, the 43 recovered rank indexes, beginner
tiers zero through three, placement remaining zero or one, and the normal league tier zero through
sixteen. A bounded control-free league identity requires canonical tier text; division allocation,
calendar and season identity remain separate unfinished authority. Global Skill and division
MedalsBalance are independent values in the recovered Client and are deliberately not equated.

Two calculation/default defects were confirmed against source:

- DatabasePlayer.armyPowerX10 multiplies a signed Int32 without checking overflow. Accepted stored
  and buffered successor ArmyPower is now at most `Int32.MaxValue / 10`, before the Client sees it.
- The server's ten-match placement default contradicted Google2u.Constants.LeaguePlacementMatches
  (one). Catalog startup now reads that constant, the default is one, and frozen starting policy
  refuses values outside the source zero-or-one domain before password derivation or persistence.

Direct UpdateArmyPower (192) now requires one canonical invariant decimal inside the same power
domain, then publishes against the authenticated revision/session and unexpired session deadline.
The endpoint owns canonical parsing; `War.Persistence/Legacy/Progression` owns the reusable
validation and compare-and-set write. Internal callers cannot bypass the successor range check.
Missing/repeated fields, signs, padding, leading zeros, fractions, exponents and overflowing values
return JsonFailure without writing. The recovered builder emits exactly this integer form, and its
success callback reads no extra keys. The value remains a display assertion: complete server-side
recomputation from validated inventory is still open, and this assertion must never grant value or
select combat/matchmaking outcomes. Other generic successor boundaries remain C13 work.

These are refusal boundaries, not an automatic repair. Historical documents missing a required
numeric field or containing the old placement value ten require an explicit reviewed migration.
Do not clamp them, substitute defaults, reset placement or rewrite balances during authentication.
Legacy BSON FormatException and InvalidDataException return the existing maintenance result before
a response starts. Root schema migration and complete league lifecycle validation remain open.

### Required migration follow-up

1. Audit raw BSON without typed coercion, login or session rotation. Report field/type/range and
   document identity; never print credentials, tokens, private subsystem bodies or invented balances.
2. Bind each proposed repair to a known writer/schema and source rule. An absent balance is not
   evidence of zero. Placement ten is not evidence that no placement match was played.
3. Produce a dry-run plan with expected revision and complete preimage digest. Keep records without
   sufficient evidence closed and explicitly reported rather than making them eligible by reset.
4. Apply approved versioned repairs with compare-and-set inside the same authority boundary. Validate
   the full successor before publication and retain retry-safe migration receipts.
5. Exercise missing/invalid BSON, changed revision/session, repeated application and failed writes
   against an owned replica. Verify unaffected metadata, wallets, progression and receipts bytewise.

No general repair tool is implemented. Tutorial now explicitly migrates unambiguous unstarted/
pending states, retaining unbound old completion as read-only; its generic Update API was removed.
The fixture-era SetSerialized API was also removed; trusted card setup now lives in the test assembly.
Profile writers have dedicated authority boundaries and the unused generic TryUpdate API was removed.
See [PROFILE_PUBLICATION.md](PROFILE_PUBLICATION.md) for the five direct mutation contracts.

## Verification and remaining C13 work

The headless executable runs five strict-state/default/metadata/resource groups and three Settings
groups. Four reviewed Settings sections brought the source inventory to 32 without changing prior
hashes. The original Settings POCO and LoadEmpty body execute unchanged against a simple base boundary
and the original Newtonsoft binary. Builders/callbacks are hash-reviewed; this is not native UI proof.

Six real-Mongo groups force initial publication, same-revision complete updates, newer metadata,
session rotation, damaged-state refusal and a server-rejected write. Live HTTP tests cover malformed
forms, exact metadata, boot, authentication/login refusal and buffered corrupt-state rejection without
new receipts. They reuse the existing owned legacy smoke replica and credential-free fixtures except
the tests that actually verify credential/session rotation behavior.

Three root source sections brought the inventory to 35; twelve profile sections brought it to 47.
Seventeen analytics sections brought the inventory to 64; seven tutorial sections now bring it to 71.
The original Army Power getter and
League enum execute unchanged in the existing headless oracle; beginner-name source is hash-reviewed.
Five root groups cover required fields, nine bad BSON representations across all twenty numeric
fields, exact integer widths, twenty-seven damaged root snapshots, boundary values and placement
policy. The live root fixture uses the same owned replica to exercise authentication/boot/peer reads,
pre-calculation refusal, invalid successor rollback, existing receipt refusal and registration/login.
The direct assertion fixture also covers malformed/repeated inputs, zero/maximum/ordinary values,
changed revision/session/expiry and an invalid internal successor without writing.
Raw BSON bytes are compared so a NaN fixture cannot produce a false mutation report through NaN
value-equality behavior. One registration uses real credential derivation; other root fixtures do not.

The final legacy run passed 98 root Mongo/HTTP checks and 554 combined assertions plus the existing forced
Mongo/fault groups. The common root BSON/reader increment passed 267,662 full Battle assertions and
native Mongo/HTTP/UDP smoke; the subsequent isolated direct-action extension passed the final
zero-warning/error build, all 15 fast stages and the live legacy suite. Run identifiers and timing
are recorded in [TESTING.md](TESTING.md). No Client asset/code or Unity runtime was changed.

The profile increment adds four pure source/input/callback groups, ten forced Mongo groups and
37 HTTP assertions. Status/LastAction extend the BSON presence/representation matrix to twenty
fields and the root Mongo/HTTP fixture to 122. Five feature-owned profile writers validate current
stored profile/Settings and protect session/revision/expiry authority without discarding metadata.
The final legacy fixture count for this increment is 615 combined assertions plus its separate
storage/fault groups. These scoped checks still do not prove all shared subsystem schemas.

The analytics increment adds a shared contract for 33 known fields while retaining bounded unknown
metadata. Present null/non-object/duplicate/aliased/coercive state is refused before authentication,
boot, buffered planning/publication or shown-once mutation. The seven monotonic flags use current
session/revision publication and a repeated true flag is read-only; the buffered chat marker shares
that schema and writer. Four source-backed groups, eight forced Mongo groups and 79 live HTTP
assertions are described in [ANALYTICS_PUBLICATION.md](ANALYTICS_PUBLICATION.md). This does not complete
the private receipt/reward lifecycles or missing-field schema migrations tracked in C13.

Tutorial adds a versioned three-member identity document with exact BSON types and coherent legacy
mirrors. Present null/malformed state and numeric/string completion flags are refused before shared
read/auth/boot/buffer use. Only proven unstarted/pending legacy state can migrate during publication;
old completed state whose ID was cleared remains readable but cannot authorize a new replay. The
current-XP response avoids regressing later progress. See [TUTORIAL_PUBLICATION.md](TUTORIAL_PUBLICATION.md).

Complete root schema/competition lifecycle validation, catalog-bound ownership/index/delivery semantics,
all remaining subsystem schemas, explicit missing-field migrations and successor validation at every
shared account boundary remain C13. Generic DTO constructor defaults for omitted fields are not a
replacement for those feature-specific migration proofs. No complete durable-state claim is made.
