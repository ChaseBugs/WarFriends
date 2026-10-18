# Complete ordinary-card identity evidence

The earlier 45-ID inventory tests used `WarCardSourceIdentityCatalog`, which maps source IDs to
implemented host effect identities. A real source-priced pack can return other legitimate Client
cards. Those tests proved a subset; they did not prove complete Client card identity coverage.
Pack generation remains based on the recovered Client catalog, rather than being restricted to
the effects already implemented by the host.

The reviewed `Google2u.CardDefinitions` sheet contains:

| Set | Count | Meaning |
| --- | ---: | --- |
| Ordinary rarity 1–3 definitions | 67 | Valid persisted ordinary-card identities. |
| Ordinary definitions marked implemented by the Client | 57 | Eligible for the existing source pack pools. |
| Existing host effect source-ID map | 45 | A subset of those active Client definitions. |

`OrdinaryCardInventory` now validates identities against the complete 67-row set. Defined inactive
rows are retained as data identities, including zero rows; this does not implement or activate
their effects. Buddy and non-ordinary placeholder rows are separate contracts.

`content/recovered-ordinary-card-identities.json` is reproducible with
`python Server/tools/build_ordinary_card_identities.py`. It records the original source order,
IDs, rarity, implementation flags and sheet provenance. Its SHA-256 is
`6d65e9de3e33729c2cebe3b54ff40e8ea8ebb1a0df1222eb86b591d17ed25408`.
The pinned source content SHA-256 is
`28b94d12a9ba78a8a46287cd40bf51d454afa75c036b1368561d22979e47d39a`.
The BattleServer embeds and hash-validates the derived artifact before using its immutable IDs.

Allocation, JSON/host-capacity and real Mongo inventory tests now exercise all 67 definitions.
Source-priced pack tests also validate their actual awarded identities through this same parser.
They no longer reject legitimate cards just because an effect mapping has not been ported.

## Required effect work

These 12 Client-active IDs have no entry in the current host effect identity map:

`BOOBYTRAP`, `CRITICALS`, `ELECTRICTRAPS`, `EXPLOSIVEPISTOL`, `EXPLOSIVETIMING`,
`HEADAHEAD`, `MEATHEADS`, `PLAGUE`, `ROCKETTURRET`, `SICKNESS`, `TRIGGERHAPPY`, `TURRET`.

Each needs its recovered behavior, authoritative host execution, protocol/Client integration,
consumption provenance, and gameplay verification. Similar names are not permission to map them
to an existing effect or prefab. This identity correction does not complete the War Card feature.
