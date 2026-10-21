# Immutable legacy catalog authority

`LegacyCatalog` now owns read-only rows and ordinal indexes instead of returning mutable JsonObjects.
Parsing, scalar arithmetic, consumed-field validation, identity binding, host dependencies and export
metadata are separate responsibilities under `Legacy/Catalog`. The public facade retains its existing
namespace. Source-provenance reconciliation remains open under C12/V07.

## Validation before publication

The reader refuses malformed root/sheet/row types, duplicate JSON properties, duplicate sheet types,
and duplicate identities in the currently indexed tables. Invalid entries are never skipped or merged.
All 7,554 rows in the current 132-sheet artifact remain in source order. Every cell must be a finite
JSON scalar. Null, arrays and objects are not recovered row-cell shapes.

The indexed tables are Constants/CardConstants by `DBKEY`, and WeaponUpgrades/ArmyUpgrades/
PlayerVisuals/CardDefinitions/CardPacks by `NAME`. These are the current identity lookup consumers.
Other tables remain available as read-only source rows, but arbitrary identity lookup is refused.
This distinction preserves duplicate `starterpackB` variants in the unimplemented IAP Packs table
and repeated blank PlayerBots names without selecting the first row as authority.

Consumed purchase prices, delivery durations, indexes and upgrade prices must be exact nonnegative
Int32 values. Missing price fields fail; they cannot become a zero-price purchase. Known constants
validate their own integer, positive coefficient, probability and bounded grant-count domains. The
source GoldExpCoefficient is **-0.175**, so its sign is permitted while the coefficient and arithmetic
rates have their own positive domains. Binary32 arithmetic constants must remain finite and must not
underflow when converted to the Client's float representation. IAP `PRICE` fields remain fractional
source data; shop-currency rules are not applied to unrelated tables.

Integral readers accept exact integral exponent notation, preserve Int64 endpoints and reject tiny
fractional tails, numeric strings, overflow and underflow. `ConstantInt` no longer casts a double.
The account starter reader shares this exact numeric implementation and retains its stricter
nonnegative lexical boundary. Request-payload parsing and durable-state validation remain separate
work; their mutable JsonObjects are not catalog rows.

Only base weapon/unit identities with priced upgrade rows can select upgrade authority. Required
price/duration fields and normal-unit track identity validate during binding. The three recovered
starting-tier-zero turret helpers have combat rows without shop-upgrade prices and stay outside
this upgrade index. They are also refused as player purchases, promotions, delivery activations
and equipped units. Unrelated tables such as Constants cannot supply a free upgrade even if a
damaged durable weapon/unit slot names them. Complete durable-state validation remains C13.

`Parse` and `Load` validate all supplied rows while permitting partial catalogs for isolated pure
consumers. The host uses `LoadConfigured`: an omitted path explicitly selects catalog-free mode;
a present path requires export metadata, eight current dependency sheets, required constants and
referenced upgrade sheets. Guaranteed card counts and rarity threshold ordering are checked before
traffic. `ParseConfigured` provides the same complete host boundary for in-memory inputs. Small
partial test fixtures use supplied-row validation and cannot bypass malformed prices.

## Configured source snapshot

The embedded [release profile](../content/legacy-catalog-profile.json) binds all 132 sheets and
7,554 rows to the recovered Google2u row-class field names/types, component-declared row counts,
ordered identities and exact artifact bytes. All 131 nonempty sheets match their declared counts.
The empty, unconsumed `Google2u.Squads` export stays explicitly closed although its component declares
50 rows. No missing production squad definitions are invented. Source duplicate-name variants remain
ordered data rather than unique purchase identities.

The profile is a reviewed baseline for the existing export, not a claim of complete scene fidelity.
Any content edit, even a well-typed price change, fails configured startup until the snapshot/schema
change receives review and the embedded profile is rebuilt. Run
`python Server/tools/build_legacy_catalog_profile.py --check` to detect drift. Source-code hashes
normalize UTF-8/LF; the content hash binds exact bytes, with CRLF pinned by `.gitattributes`.

Current MainScene pointers independently bind 24 player units and three helpers to the same source
identity sets. The read-only `verify_legacy_unit_roster.py` guard follows each behavior's upgrade-slot
GameObject to its attached Google2u component; generic slot type names are insufficient. It compares
role sets, preserving the distinct source sheet and LevelManager behavior orderings.

## Upgrade boundaries

`LegacyUpgradeTrack` caches validated normal/special/Elite lanes and normal limits by unit tier.
The current 1.4.0 player tracks contain 1,724 normal, 344 special and 42 Elite rows. STARTINGSPECIAL
must equal the normal count; an enabled STARTINGELITE must equal normal plus special counts. Lane
TIER values are ordered and only trailing `-1` padding is allowed. Historical version counts do not apply.

WeaponLevelsSetup reserves an extra row: maximum legal stored weapon index is `rowCount - 2`.
Unit normal limits follow UpgradeSlot's current-tier count minus one; Elite limits are Elite count
minus one. The previous checks allowed an extra purchase at the terminal index and ignored the
normal tier ceiling. Parts purchases also refuse an already-maxed Elite lane before consuming Scraps.

Normal upgrade completion, including instant completion, requires owned current state, a legal next
index and an active delivery with matching item, current index and normal SlotId. This proof runs
before charging Gold or incrementing state. A completed delivery clears its SlotId as well as its
item, timer and activation flag. Special-track purchase remains explicitly unsupported.

Explicit reader resource bounds are 32 MiB of UTF-8, 512 sheets, 16,384 rows per sheet, 100,000 total
rows and 256 fields per object. These are server resource policy, not recovered production settings.

## Snapshot ownership and provenance

Rows own cloned JsonElement storage and frozen field indexes. Ordered sheet views are read-only
collections; identity and constant maps are frozen. Returning a scalar, row or sheet does not return
a writable authority alias. Mutating input JSON or a separately parsed copy leaves the catalog intact.
Identity lookups reuse the same row object and do not scan source lists or clone rows per request.
This changes lookup structure; no HTTP/combat/network throughput improvement is claimed without P01/P08 measurements.

Export metadata records Client version, export Unity label, claimed MainScene SHA-256 and the exact
loaded-byte SHA-256. Wrong Client version, incomplete metadata and malformed digest identity fail.
The Unity label is export provenance and is never used as the recovered runtime compatibility target.
The source hash is a recorded claim, not proof that the current scene matches the export.

The known V07 mismatch remains: the catalog records MainScene digest `d46f81ff...`, while the current
scene audit reports `5b159bba...`. This increment does not rewrite either digest, regenerate content
or certify the current artifact as a newly verified scene extraction. Schema/count/identity/track
guards now protect the reviewed export; source-value and complete scene-provenance reconciliation
remain open. Regenerating the profile does not resolve V07.

## Verification

The recovered callback console now runs nine focused catalog scenarios covering immutable aliases,
malformed/duplicate input, missing/negative/fractional/overflow prices, exact integer boundaries,
constant domains, provenance identity, source-backed duplicate variants and linked-stage/lane corruption.
Eight additional configured-release groups test the real release, missing sheets/rows, unknown fields,
source field types, identity order, changed prices and mismatched source metadata, entirely in memory.
The populated response/replay suite adds weapon/unit regressions for unrelated table selection,
bringing it to 151 scenarios. All 126 literal server result dispositions must remain covered.
An additional 63 producer scenarios cover upgrade boundaries, tier gates, wrong item kinds, invalid
delivery proofs and helper admission. All 66 weapon and 24 player-unit tracks are compared with ten
unchanged, compiled Client upgrade getters/methods at reviewed boundaries.

These tests parse in-memory input or small existing fixtures. They create no temporary catalog export,
Unity project or extra database. Legacy storage/HTTP smoke reuses its one owned Mongo replica and
checks the real configured artifact. See [TESTING.md](TESTING.md) and
[LEGACY_BUFFER_CONTRACTS.md](LEGACY_BUFFER_CONTRACTS.md) for commands and runtime boundaries.
