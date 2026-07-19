# Versioned Gameplay Material Database

## Purpose

Recovered client data is useful only if the backend can identify its source version, prove that it
has not drifted, and query it without trusting gameplay requests. The material database converts
checked-in 4.9.5 extraction artifacts into versioned MongoDB documents.

## Collections

### `gameCatalogEntries`

Each entry is keyed by:

- `clientVersion`;
- deterministic `catalogRevision`;
- `kind` (`weapon`, `unit`, `rank`, or `weaponFeature`);
- Google2u `key`.

An entry also stores availability, source path/SHA-256/schema version, an entry content hash, and a
joined data payload.

Weapon payloads contain the shop definition, all normal upgrade transitions, and every playable
DPS row. Unit payloads contain roster, behavior, deployment, purchase, tier, and
normal/special/Elite level information. Rank documents contain the zero-based index, display level,
and exact `ARMYPOWER` value. Weapon-feature reference documents preserve nine DPS coefficients for
each of 11 categories without making the incomplete black-market acquisition path playable.

### `gameCatalogReleases`

One release pointer per client version identifies the complete revision currently visible to
readers. It stores counts and the source manifest.

## Publication safety

Synchronization writes every immutable entry for a new revision first. Only after all upserts
succeed does it update the release pointer. A reader therefore sees either the complete old
revision or the complete new revision, never a partial catalog.

Content hashes use recursively sorted JSON object keys. Re-running an unchanged extraction creates
the same revision and upserts the same keys, making startup synchronization idempotent.

## Current 4.9.5 contents

- 84 playable weapons and 9 unresolved weapon rows;
- 5,781 weapon upgrade transitions;
- 5,865 playable weapon DPS rows, 58 rank-power rows, and 11 weapon-feature category rows;
- 24 playable units, 3 helper units, and 18 unresolved unit rows;
- 4,124 normal, 684 special, and 216 Elite unit rows.

Unresolved/helper entries are retained as evidence with non-playable availability. Database
presence alone must never authorize their purchase.

## Operations

Normal server startup creates indexes and synchronizes the checked-in catalog. An operator may run:

```text
cd Server
npm run sync:catalog
```

The sync command uses `Server/.env`, builds TypeScript, publishes the release, and prints its hash
and entry count.

## Extension rules

Future extractors should follow the same model for decals, cards, packs, mission tables,
achievements, Arena loot, and archived live-ops sheets:

1. record client version and exact source hash;
2. preserve unresolved rows with an explicit reason;
3. generate deterministic output;
4. verify checked-in artifacts against the original source;
5. fail closed when runtime data has no authoritative row.

## Key implementation files

- `Server/src/services/gameCatalogService.ts`
- `Server/src/scripts/syncGameCatalog.ts`
- `Server/src/db.ts`
- `Server/src/tests/gameCatalog.test.ts`
