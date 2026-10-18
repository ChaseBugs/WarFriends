# Battle card quantity authority

The recovered Client keeps a separate `amount` for each ordinary card identity in
`CardManager.CardManagerData.cardData`. `Card.RemoveCard` decrements that amount
by one and does not allow a zero amount to become negative. At game end,
`CardManager.InstanceOnGameEnded` removes selections whose amount is below one.
An identity list alone therefore cannot prove available durable inventory.
`CardManager.UseCard` and the accepted self-hosted callback also remove the card
from `cardsForGame`. Duplicate owned copies do not grant repeated uses of that
same hand card. A subsequent random in-battle card grant is separate authority.

## Allocation contract

`BattleAllocationProjection.CardCounts` now contains positive C# Int32 counts in
the exact order of `CardIds`. Both arrays must have equal lengths. Missing/null,
zero, negative and mismatched counts fail validation before host configuration.
An empty card allocation requires an empty count array and grants nothing.
Validation copies the counts as well as IDs so caller mutation cannot change the
validated snapshot. A nonempty identity without positive ownership evidence is rejected.

### Owned catalog capacity versus selected cards

The complete recovered ordinary source-ID map currently contains 45 identities. Applying the
32-entry selection-policy bound to owned allocations or the union of two players' inventories
rejected valid full catalogs before selection. Those three boundaries are now separate:

- Each allocation permits up to 128 owned ordinary-card identities with matching positive counts.
- The host catalog permits their deduplicated two-participant union, bounded at 256 identities.
- `BattleCardSelectionState` retains its existing 32-entry policy limit. Actual command transport
  also retains the 256-byte message bound, and the UDP endpoint retains its selection count guard.

The 128/256 limits are bounded transport capacities, not recovered game hand sizes, extra-slot
entitlements, or permission to select more cards. Buddy limits and durable consumption are unchanged.
An enlarged owned catalog does not increase match-local uses of a selected card.

`CardCatalogCapacityTests` transports all 45 source identities through allocation JSON and host
configuration, selects a representative three-card hand, checks the separate 32/33 policy boundary,
and configures a union exceeding 32 even though each player's own list is smaller. It also checks
the 128/129 allocation and 256/257 catalog boundaries. The real Mongo quantity test now replaces
its owned test row with all 45 identities and verifies both read paths retain their order and counts.
This verifies catalog capacity, not all 45 cards' gameplay effects or normal account projection.

The Release build passed with zero warnings and errors. Both `--allocation-inventory-only` and
`--allocation-inventory-mongo mongodb://127.0.0.1:27017` passed after the capacity change.
The latter used only its generated temporary database and removed it on completion.

Mongo `battle_allocations` stores these counts. Both single and batch reads
validate them. Nonempty historical rows/manifests without counts are rejected;
they need deliberate reprojection from authoritative durable inventory. Do not
backfill one copy per identity. Empty historical allocations remain empty.
Counts are included in the serialized manifest, so the existing manifest digest
and control signing bind quantities too. `MatchEngine.ConfigureBattleAllocations`
retains the recovered one-use-per-selected-hand-card budget, after positive
owned quantity validation. It does not allocate every durable copy as another
match use. The named `UsesPerSelectedHandCard` constant documents that rule.

## Verification

`CardAllocationQuantityTests` covers immutable quantity snapshots, client-width
maximum counts, invalid/missing quantities, JSON round-trip, and actual host
allocation consumption. A player owning three copies can use the selected hand
card once; receipt replay and a second fresh activation both fail without
changing state revision; the other player's hand card remains available.
The existing Backend allocation HTTP/HMAC test now returns and verifies three
copies rather than only checking identities.

Run the focused host/allocation checks with:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --allocation-inventory-only
```

The default native battle run also includes these checks. With an isolated Mongo
process, run:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --allocation-inventory-mongo 'mongodb://127.0.0.1:<owned-test-port>'
```

The Mongo test creates and removes only its generated temporary database. It
checks both durable read paths, then removes stored quantity authority and
requires both paths to reject it. The local run artifacts are under
`Server/.local/card-quantity-3050f53fe2a7446cbb1edbec0cd092ec`.

## Remaining integration

This adds explicit owned-quantity evidence to the allocation-to-host boundary; it does not create allocations from
normal accounts. The durable inventory/progression projector, recovered gameplay hand-slot
and entitlement limits, upgrade ordering, Buddy data authority,
authoritative in-battle hand replenishment, transactional inventory consumption
across matches, settlement and normal Unity battle entry remain unfinished. Match-local reservations do not decrement the
account wallet or durable card inventory. Do not describe these native checks
as complete card economy or normal gameplay verification.

The next projector must also bind the normal path's exact upgrade ordering.
`GameControllerOnline.SubmitSelfHostedCards` echoes `local.Units` in the
Backend presentation order, while recovered `IGameController.GetUnitsUpgrades`
builds a separate full `LevelManager.behaviours` list for gameplay properties.
The current presentation source sorts equipped saved-army keys ordinally;
combat manifest lanes are documented as matching `EquippedArmyUnitIds`.
Do not copy the full 24-row list into an equipped-only signed lane or accept
a nonempty selection echo when the manifest has no corresponding lane.

## Quantity checkpoint verification history

At this checkpoint, the solution built with zero warnings/errors. Focused
allocation/host checks, real Mongo quantity checks and protocol checks passed.
The full native regression was **not green**: its bazooka bonus UDP scenario
failed to collect the selected box at approximately `(0.583, 0.278, -0.735)`;
repeated impacts occurred near `(-2.672, 0.277, -0.479)`. The failure log is
`Server/.local/card-quantity-final-regression.log`. The unchanged isolated
`--pvp-bonus-bazooka-udp-only` rerun passed eight assertions; its log is
`Server/.local/card-quantity-bazooka-repro.log`. Do not infer a complete
regression pass or remove source geometry to force collection. Capture
box placement and cover/missile evidence to determine whether the scenario
selects an obstructed box or a runtime collision discrepancy exists.

The subsequent [fixed-location approach regression](PVP_BONUS_RPG_APPROACH.md)
reproduces the failed impact from cover 2, proves collection from other
covers, and repairs the UDP driver's repeated blocked-cover selection.
The original failed log above remains historical evidence, not a current
full-regression success claim.

After the approach and asynchronous-observation fixes, the final default
native run exits zero with 143,282 assertions. See the subsequent regression
document for the verified scope and log. Normal-account projection and
durable card economy remain unfinished.
