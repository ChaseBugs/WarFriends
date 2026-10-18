# Card subsystem writes versus battle consumption

The recovered `CardCraftingManager.Craft` removes three cards locally and sends their source IDs
through action 176. Action 177 claims the server-selected crafted card. The Backend previously
saved `CardManagerData` and `CraftData` with two independent unconditional writes. An earlier
read could overwrite a committed battle debit, and a failure between those writes could publish
only one half of a crafting transition.

`LegacyPlayerStore.TryReplaceSubsystemsAsync` now compares every replaced subsystem with its
exact read value and publishes the group in one MongoDB update. An absent field requires that
the stored field still be absent; explicit null does not satisfy that condition. Unrelated account
fields are not replaced, and successful updates increment the account revision. A conflict returns
false without publishing any companion subsystem.

Both `CraftCard` and `ClaimCraftedCard` use this method for the card and craft blobs. Conflicts
use the existing `WrongPlayerData` failure. Existing successful response fields (`End` and
`CardId`), source IDs, catalog choices, and Client behavior are unchanged.

## Verification

- Release build: zero warnings and errors.
- Real Mongo transaction gate: obtain an account snapshot, commit an actual host-confirmed
  battle card debit, then reject a proposed write based on the earlier card snapshot. Neither
  inventory nor the companion craft blob is overwritten.
- From a fresh snapshot, two concurrent conditional updates produce exactly one winner and
  one combined subsystem publication.
- Existing paired-result debit, exact replay, rollback/retry, zero-row, frozen-ownership, and
  terminal/grant race checks continue to pass.
- `LegacySmoke.ps1`: 248 HTTP assertions pass, including a successful source-backed three-card
  craft start, duplicate-start rejection, empty-claim rejection and early-claim refusal.

The concurrency test exercises the storage boundary with a proposed subsystem update; it is not
a concurrent HTTP crafting test or evidence that an arbitrary test award is valid gameplay.
The timed HTTP smoke does not mature a craft and prove successful action-177 reward delivery.

Artifacts: `.local/card-craft-cas-ff03c84d81af4faaab476dc379065b85` and
`.local/legacy-4906077bb2dd40cca4288c94512b7178`.

## Remaining work

Card deposit/withdrawal writers still need coordinated conditional or
transactional updates. This change does not fence those writers, introduce admission inventory
reservations, complete historical inventory reconciliation, or make every crafting retry return
the original success response. Automatic battle allocation and normal Unity gameplay remain open.


The later [card-pack publication](CARD_PACK_PUBLICATION.md) now fences the buffered pack writer
and publishes its stock and wallet together. Its receipt/account crash gap remains separate work.
