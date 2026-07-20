# Player Visuals and Decals

## Client model

The recovered client calls every player customization a `PlayerVisual`, even though the visible
items include cosmetics and temporary combat modifiers. `CamosManager.DecalManagerData` persists
three fields:

- `visuals`: sparse ownership, notification, expiry, rental, and parts records keyed by visual ID;
- `slots`: four equipped records keyed by numeric category ID;
- `previousHeadDecal`: the permanent helmet restored after a temporary Arena helmet expires.

The four categories and their source defaults are:

| ID | Category | ID prefix | Default |
|---:|---|---|---|
| 0 | Camo | `CAMOS_` | `CAMOS_DEFAULT` |
| 1 | Helmet | `HELMETS_` | `HELMETS_EMPTY` |
| 2 | Head accessory | `HEAD_` | `HEAD_EMPTY` |
| 3 | Power band | `BANDS_` | `BANDS_EMPTY` |

New accounts store only the four slot records. The ownership dictionary remains sparse because
the client creates missing empty `SavedPlayerVisual` values during `InitVisuals`.

## Versioned catalog

`Extract-VisualCatalog.mjs` joins two independent parts of the 4.9.5 MainScene:

1. the Google2u `PlayerVisuals` rows that define price, unlock level, source, VIP requirement,
   duration, rarity, parts, and power-band effect;
2. the serialized visual category components that prove the item has an asset the client can
   resolve and equip.

The resulting artifact contains 146 playable rows across 31 camos, 61 helmets, 47 head
accessories, and 7 power bands. `HEAD_MASK_ROCKET` has a shop row but no serialized visual asset,
so it is retained as one unresolved record and cannot be purchased.

## Purchase authority

`BuyDecal` is processed inside the stock `SendRequestBuffer` transaction. The backend validates:

- that the ID has both a balancing row and a serialized client asset;
- `PURCHASABLE: shop`; event, Arena, loyalty, assignment, value-pack, and hidden rows cannot be
  bought through the normal shop action;
- the zero-based player-level gate derived from `UNLOCKLEVEL`;
- an active VIP expiration for `ONLYFORVIP` rows;
- the exact source Gold or WarBucks price;
- zero discount until an offer entitlement service exists;
- sufficient server-owned balance.

Permanent items set `bought`. Timed power bands also receive `expiresOn = serverNow + TIME`.
Repeating an already active or permanent purchase is an idempotent no-op, and `BufferId` replay
returns the original response without charging again.

## Equipment and expiry

`EquipDecal` sends only the visual ID. The server obtains the destination slot from the immutable
catalog category rather than accepting a client-selected slot. A visual may be equipped only when
one of these conditions is true:

- it is a zero-price shop default;
- its permanent ownership flag is set;
- its collected parts have reached the source requirement;
- it is a timed visual whose server expiration is still in the future.

Borrowed records fail closed until rentals are implemented. Equipping an Arena helmet records the
current permanent helmet in `previousHeadDecal`, allowing the recovered client to restore it when
the temporary helmet expires.

Public `DatabasePlayer` and leaderboard snapshots expose the same authoritative four equipped
slots. They never read the stale DTO placeholder after a successful equipment mutation.

## Notification acknowledgements

Current `VisualWasShown` sets `showed = true` and clears `notificate`. Historical
`DecalWasShown` does the same only when its payload resolves to a real visual ID; recovered legacy
call sites with unrelated impression fields remain authenticated no-op telemetry. Neither path
grants ownership, extends an expiration, debits currency, or changes a slot.

## Periodic VIP lootboxes

The recovered paid-VIP benefit is now part of authoritative PvP settlement. The shipped client
provides these exact contract facts:

- 4.9.5 `Constants.LootboxAfterBattles` decodes to `4`;
- English `ID_VIP_BENEFITS2` is `2X LOOTBOX AFTER {0} BATTLE`;
- `PlayerAnalyticsData.matchesToNextLootboxes` stores and renders the countdown;
- `GameEnded.MatchesToNextLootboxes` refreshes that countdown;
- `GameReward.NewVisuals` is a JSON dictionary **string** whose values are part counts;
- duplicate dictionary keys use `_#n`, while the final `-VIP` marker selects the VIP suitcase
  presentation;
- opening a suitcase adds parts locally and converts already-owned parts using the visual row's
  exact `DUPLICATEWARBUCKS` value.

Every confirmed PvP settlement with active VIP decrements the server-owned `4 -> 3 -> 2 -> 1`
cycle. At `1`, the server resets it to `4`, performs two independent cryptographic draws, persists
the parts and any duplicate WarBucks, and stores the exact `NewVisuals` string in the immutable
per-player match receipt. The player update and terminal match transition share one MongoDB
transaction, so a delayed or repeated `GameEnded` receives the original pair without granting it
again. Inactive VIP battles neither advance nor reset the saved cycle.

The retired production probability table is not present in either recovered APK. The current
selection policy is therefore explicitly reconstructed, not claimed as original balancing: it is
uniform across the 73 playable normal-shop rows with `PARTS > 0`. Event, Arena, assignment,
loyalty, hidden, value-pack, and power-band rows remain excluded until their own authoritative
reward contracts exist. Each draw awards one part, and equal draws are intentionally allowed and
encoded as, for example, `HEAD_CLOWN-VIP` plus `HEAD_CLOWN_#1-VIP`.

## Rollback and security invariants

The client changes its local wallet, ownership, or equipped slot before sending a buffer. A
rejected mutation therefore returns authoritative Gold, WarBucks, and the complete serialized
`DecalManagerData` so the recovered response parser can undo the optimistic change.

- Catalog presence never grants an event, Arena, loyalty, or hidden item.
- Client price, discount, VIP, expiry, parts, and ownership values are never authoritative.
- An unresolved row must not be purchasable even when its price is known.
- Timed power bands are checked against server time at equipment time.
- Purchase, debit, ownership, equipment, and replay-cache updates share one revision-guarded write.

## Remaining work

- Server-owned reward grants for Arena, events, assignments, loyalty, and value packs.
- Recovery of the retired normal-lootbox rarity/visual weights; the periodic VIP path currently
  uses the documented uniform normal-shop fallback.
- Rental grants and expiration cleanup.
- Offer-backed discounts and subscription/VIP purchase flows.
- Server-confirmed achievement progress for collecting visuals.

## Key implementation files

- `Server/scripts/Extract-VisualCatalog.mjs`
- `Server/src/data/visualCatalog.generated.json`
- `Server/src/services/visualInventoryService.ts`
- `Server/src/services/vipLootboxService.ts`
- `Server/src/services/matchService.ts`
- `Server/src/services/assignmentService.ts`
- `Server/src/handlers/visuals.ts`
- `Server/src/tests/visualInventory.test.ts`
- `Server/src/tests/vipLootbox.test.ts`
