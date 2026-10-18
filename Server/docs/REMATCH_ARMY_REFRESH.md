# Mixed rematch army refresh

The recovered `PlayerProperties` serializes each current unit's normal, special, and Elite
indexes. `GameControllerOnline` sends the selected local unit order during self-hosted card
selection. A successor battle must therefore bind current durable equipment rather than inherit
the accepted battle's old army lanes.

`IBattleArmyManifestCatalog` makes this refresh capability explicit. The mixed catalog implements
it through the existing source-bound `BattleArmyManifestProjection`; rifle and shotgun catalogs
do not claim it. `BattleManifestFactory.CreateRematchAsync` now permits source army identities
and lane fields only when the active catalog can replace them. Mixed binding removes old lane
fields and rebuilds them from current `BattlePlayerPresentationSource` data, including equipped
unit removal and recovered special/Elite inactive sentinels.

Before returning successor bytes, the factory compares each refreshed unit lane with the current
durable battle allocation. A stale allocation fails before Worker registration rather than
producing an unusable successor manifest. This does not update or manufacture allocations.

## Rejected authority

Army health, damage, speed, accuracy, and shot-speed modifiers and `NewArmyUnitIds` still require
durable projection builders and remain rejected. Shield fields and admission Gold-bonus ledgers
retain their existing rejection. Catalogs without army refresh capability still reject army-bearing
source manifests. This change does not default an expired or unknown modifier into a valid perk.

## Verification

The real MongoDB rematch gate now includes a mixed fixture seeded with source starter inventory
and an explicitly empty ordinary/Buddy card inventory:

1. Create the source manifest with four equipped units at their original lanes.
2. Persist one normal upgrade and unequip the final source-ordered unit.
3. Reject the successor while the battle allocation still contains old lanes.
4. Explicitly refresh the test allocation and build a successor with three units and the new stage.
5. Validate combat content and configure the native host with the refreshed allocations.
6. Reject all five modifier vectors, new-unit flags, and shields.

The existing rifle gate also checks source hashes, fresh identity, participant/cover/master
preservation, weapon/rank refresh, immutable accepted bytes, and rejection of army fields in a
catalog without this capability.

The Release build passed with zero warnings and errors. The Mongo-backed rematch command and
`--allocator-mixed-only` both passed, including the existing 14 starter army host checks.

```powershell
dotnet build Server/tests/War.Battle.Tests/War.Battle.Tests.csproj -c Release --no-restore
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --rematch-manifest-only mongodb://127.0.0.1:27017
```

This is native factory/real-database/host-configuration proof. Automatic allocation, modifier and
shield projection, normal Unity second-battle UI, durable card consumption, and full rematch
gameplay remain open. The fixture's explicit allocation refresh does not prove those paths or
an atomic account/allocation snapshot under concurrent writes.
