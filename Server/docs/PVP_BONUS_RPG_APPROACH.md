# RPG crate approach verification

The full native run recorded in `BATTLE_CARD_INVENTORY.md` failed to collect a
box near `(0.5833868, 0.2775715, -0.73505604)` on City_Multiplayer. Seven RPG
impacts repeated near `(-2.6722121, 0.27738816, -0.47879574)`. The old UDP driver
selected the friendly cover nearest the box's Z coordinate on every attempt.
It did not remember that this firing position had already failed, and could
also fire after only one hop toward the requested cover.

## Deterministic evidence

`PvpBonusRpgReplay` uses existing host draw injection, the recovered City map,
normal admission/readiness, normal cover commands and actual RPG hold/flight.
It fixes the failed X/Z location, issues the source Kevlar prefab through the
normal confirmed-scorestreak planner, waits for real landing and tests all
four friendly covers with missile draws 0, 0.5 and 1. Neither box coordinates
nor collection receipts are injected into an active registry.

The [committed result](rpg-crate-cover-replay.json) binds map SHA-256
`acaf878b188dbc17fca6795b5db7e9c7797b91dee0fcb6fb02d5e85d7cc11c4f`.
All three cover-2 flights reproduce the failed impact within 0.0001 world
units and leave the box uncollected. Covers 0, 1 and 3 collect it for all three
draws. Thus the nearest-Z cover is demonstrably a blocked firing position for
this case. The regression requires the blocked outcomes as well as successful
ones; it does not remove geometry or enlarge blast radii to pass.

The original failure did not retain its prefab or complete random history.
This replay fixes source prefab 6, both missile draws to the same chosen value
and the initial curve sign. It establishes the location/cover counterexample,
not a byte-for-byte recreation of every original random input or Unity parity.

## Driver change

`RpgCoverSearch` remembers attempted covers for one box. The first attempt keeps
the existing nearest-Z ordering. If the box survives, the next attempt selects
an untried friendly cover. A different box resets that history; exhausted
covers fail explicitly. The replay checks that this same search first chooses
the blocked cover, then chooses a cover whose real host flight succeeds.

`PvpBonusRpgApproach` now waits for every normal movement hop to finish before
firing from the chosen cover. The UDP scenario retains its real hold, flight,
impact, and both-peer collection assertions. Failure/success diagnostics now
include each firing cover. Server collision, damage, collection, source assets
and Client behavior are unchanged by this test-driver repair.

Reproduce the deterministic regression and its report:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --pvp-bonus-rpg-replay Server/.local/rpg-crate-cover-replay.json
```

Run actual two-peer transport separately:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --pvp-bonus-bazooka-udp-only
```

This does not complete random crate placement coverage, every bonus effect,
normal Unity battle entry or BattleServer implementation.

## Asynchronous peer observation

The next full run reached a separate shotgun bonus assertion that compared
entire crate ID lists from two sequential UDP polls. The source worker may
publish another matured crate between those observations. Different server
revisions therefore need not have identical complete active sets. The old
failure did not retain both snapshots; its log is preserved at
`Server/.local/rpg-cover-search-before-observation-fix.log`.

The scenario now requires exactly one occurrence of its selected crate on
each peer, with the same immutable owner and prefab. Equal authority
revisions must still have the exact same full ID list. Failures record both
server ticks, revisions and ID lists. Six focused checks prove that later
publication can add another box while changed owner/prefab, missing selected
identity and different lists at the same revision remain rejected. This
does not waive the later two-peer impact and collection assertions.

## Verified result

The final test project builds with zero warnings/errors. The fixed-location
replay passes all twelve cover/draw cases (nine collections and three
required blocked outcomes); all six asynchronous-identity checks pass.
Focused actual UDP shotgun and bazooka scenarios pass, including repeated
bazooka runs. The final default native executable exits zero and reports
**143,282** battle-engine, admission, portable-SDK, map-geometry and real
two-peer UDP assertions. Its log is
`Server/.local/rpg-cover-search-regression.log`. This result supersedes the
two earlier failed regression checkpoints, while preserving their evidence.
It remains native Windows verification of existing implemented boundaries,
not Linux execution, normal Unity gameplay or full BattleServer completion.
