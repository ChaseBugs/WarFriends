# Account-derived battle allocation source

`BattleAllocationSource` builds a validated allocation from one durable legacy account snapshot.
It is registered in Backend dependency injection; `GetAsync` reads the account and `Project` is a
non-mutating projection. It does not accept packet-supplied inventory or publish a queue ticket.

## Recovered rules

- `CardManager.CardManagerData` stores ordinary ownership as `cardData[id].amount`.
- `CardManager.OnPlayerDataLoaded` supplies zero amounts for absent ordinary card rows.
- `DatabaseSerializedObjectGeneric.Load` uses the source default when the subsystem is absent.
  Accordingly, an absent `CardManagerData` projects no ordinary cards and grants nothing.
- `CardManager.selectedCards` emits source `Card.id` strings, rather than C# class names.
- Unit lanes use the existing `BattlePlayerPresentationSource`, preserving equipped/borrowed
  source order, saved-to-absolute stages, and inactive special/Elite sentinels.

The source validates the complete present card-state container before projecting positive
quantities. It rejects unknown and duplicate fields, unknown ordinary source IDs, null containers,
malformed records, non-integer/negative/out-of-Int32 amounts, and malformed flag/timer metadata.
Zero quantities are omitted. All 67 defined ordinary source IDs are supported by the inventory map;
output IDs are ordinally sorted with counts in matching order. Allocation validation freezes the
result. Existing malformed state is not reset, rewritten, or converted into ownership.

## Buddy boundary

`CardBuddy.SpawnUnit` consumes unit type, primary/secondary weapons, visuals, and level-derived
combat data. The current native host only supports Buddy ID ownership/selection; it does not
project that complete combat description or run the source Buddy summon.

`CardBuddy.Init` changes amount zero to one. Every persisted Buddy row is loaded by
`CardManager.OnPlayerDataLoaded`, so silently dropping zero rows would also misrepresent the
recovered flow. The new source rejects every nonempty Buddy dictionary with an explicit
unsupported-projection error. It does not manufacture a Buddy, discard its metadata, or claim
that an ID alone implements its combat behavior. Empty Buddy state remains valid.

## Verification and integration state

`BattleAllocationSourceTests` covers absent subsystem defaults, all 67 defined ordinary IDs, exact
Int32 maximum quantity, zero ownership, deterministic ordering, immutable source data, malformed
and duplicate JSON, oversized state, unknown IDs, and both zero/positive Buddy-row rejection.

The real Mongo gate inserts an account with 67 defined ordinary card rows, reads it through `GetAsync`,
stores the resulting allocation, and verifies quantities and army lanes on readback. This write
is explicit test setup in the gate's owned temporary database; the source itself is read-only.

```powershell
dotnet build Server/tests/War.Battle.Tests/War.Battle.Tests.csproj -c Release --no-restore
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --allocation-inventory-only
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --allocation-inventory-mongo mongodb://127.0.0.1:27017
```

Release build passed with zero warnings/errors; both focused commands passed. The complete
native suite was not rerun for this checkpoint.

At that checkpoint, normal matchmaking required a pre-existing trusted allocation. Automatic publication,
concurrent inventory fencing, actual hand-slot/extra-slot entitlements, Buddy combat projection,
complete cross-match consumption, and rendered Unity battle entry remain required work.
This source is a prerequisite for those paths, not their completion.
The later [paired-result card debit](ATOMIC_CARD_CONSUMPTION.md) reuses the extracted
`OrdinaryCardInventory` parser and provides atomic ordinary-card consumption at first terminal
acceptance. It does not complete admission reservation or all legacy writer coordination.


The [complete card identity audit](ORDINARY_CARD_IDENTITIES.md) replaces the earlier 45-ID effect
map used as an inventory validator. Valid persisted identities now cover all 67 ordinary rows;
57 are Client-active, and 12 of those still lack host effect identity integration. Identity
projection does not implement those missing effects or activate the inactive definitions.

## Current admission integration

Normal queue admission now creates an absent allocation through the account-revision preparation
transaction, after validating source equipment against the configured manifest catalog. Existing
allocations are preserved and checked against account ownership; they are not replenished on
retry. Paired manifests use one Mongo snapshot for account and allocation reads. Actual Mongo
tests force concurrent inventory changes and between-query successor publication.

The first queue integration run passed without manually inserted allocations. A subsequent
whole-queue run with coherent reads failed on a rematch Forfeit UDP timeout. The diagnostic
whole-queue rerun subsequently passed without widening timeouts; the earlier cause remains
unproven. These tests do not establish complete current gameplay acceptance. Safe inactive refresh after legitimate
equipment changes, admission reservations, the remaining card effects, Buddy and normal Unity
battle entry remain required. See [current boot/admission evidence](CLIENT_LOBBY_BOOTSTRAP.md).
