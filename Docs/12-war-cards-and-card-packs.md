# War Cards and Card Packs

## Recovered state contract

The stock client stores War Card ownership in `CardManager.CardManagerData`. The backend persists
the same object and returns it in the typed `PlayerData.CardManagerData` boot field:

```json
{
  "cardData": {},
  "buddyCardData": {},
  "nextWithdraw": 0,
  "nextBuddyDeposit": 0,
  "extraSlot": false
}
```

`cardData` maps a card ID to its owned `amount`. `buddyCardData` is the squad-buddy snapshot used
by the deposit/withdraw flow and preserves amount, buddy identity, equipped visuals, unit type,
weapons, Army Power, and level. The timer fields and extra-slot flag are preserved even though the
squad card pool is not implemented yet. New accounts begin with the exact empty shape; old player
documents are materialized safely when first loaded.

## Authoritative 4.9.5 catalog

`Server/scripts/Extract-CardCatalog.mjs` deterministically reads
`Client/ExportedProject/Assets/Scenes/MainScene.unity`, joins the `CardDefinitions` table to the
serialized `CardManager` components, decodes obscured float constants, and records the source
SHA-256 hash. The generated catalog contains:

- 58 playable serialized card assets: 27 Bronze, 17 Silver, and 14 Gold;
- 25 definition rows without a serialized playable `Card` component, retained as unresolved;
- four source-priced card packs;
- display level 6 as the War Card unlock level;
- the recovered level thresholds and rarity probabilities used by the client;
- the 30-minute Bronze-to-Silver recipe, 60-minute Silver-to-Gold recipe, 240-minute squad
  withdrawal cooldown, and ten-buddy-card limit.

Unresolved rows remain queryable evidence in the material database but can never be purchased or
granted. Run `npm run verify:card-catalog` in `Server` to prove that the checked-in artifact still
matches the recovered scene.

## Card-pack balancing

| Pack | Currency and price | Cards | Fixed first slots | Remaining slots |
|---|---:|---:|---|---|
| `BRONZE_CARDPACK` | 19 Gold | 10 | 7 Bronze | Bronze-Silver |
| `SILVER_CARDPACK` | 39 Gold | 10 | 6 Silver | Silver-Gold |
| `GOLD_CARDPACK` | 69 Gold | 10 | 5 Gold | Silver-Gold |
| `THREE_CARDS` | 1,200 WarBucks | 3 | none | Bronze-Gold |

The client request contains `cards`, `cardPack`, `discount`, and `StartTime`; it does not contain a
trusted price. The server selects the pack row, requires the player to have unlocked War Cards,
rejects unsupported discounts and malformed timing, validates the exact card count and rarity of
every position, and derives the Gold or WarBucks debit from the catalog.

## Purchase transaction

`BuyCardPack` is action 97 and travels through the stock `SendRequestBuffer` path. One accepted
request performs these changes in one optimistic state transition:

1. validate the pack, level gate, cards, discount, timing, and wallet;
2. debit the source-owned price;
3. increment every card amount with safe-integer protection;
4. increment the progression revision and persist the new `CardManagerData`;
5. cache the result by `BufferId` so a network retry returns the original result without charging
   or granting twice.

Failures do not partially mutate the wallet or inventory. The response includes the exact recovery
fields consumed by the old client: `Gold`, `WarBucks`, `CardManagerData`, and `SpecialOffers`.
Recovered result codes are 100 for insufficient currency, 112 for an invalid/unavailable pack or
roll, and 13601 for a discount without a server-owned entitlement.

## Timed card crafting

The backend also persists the exact `CardCraftingManager.CraftData` login and recovery object:

```json
{
  "cards": [],
  "start": 0,
  "end": 0
}
```

`CraftCard` (action 176) accepts exactly three owned playable cards of one rarity. Three Bronze
cards are removed atomically and create a 30-minute receipt for one Silver result; three Silver
cards create a 60-minute receipt for one Gold result. Gold, unresolved, mixed-rarity, missing, and
duplicate-over-owned inputs are rejected. A second start while a receipt exists returns recovered
code 17601 and the current `CraftData` instead of consuming more cards.

`ClaimCraftedCard` (action 177) validates server time, chooses one playable next-rarity card with a
cryptographic random selector, grants it, and clears the receipt in the same progression revision.
Early or duplicate claims return code 17701 and cannot grant twice. Invalid card ownership uses
code 17401 with authoritative `CardManagerData`, `CraftData`, and deposited-card recovery fields.
The returned `CardId` is authoritative because the stock claim parser explicitly adds the ID from
the server response. A claimed Gold craft also records the server fact used to validate starter
assignment `ID_8`.

`CraftAndClaimCard` (action 2000) remains rejected. The stock client exposes it to subscribers,
but the reconstructed backend does not yet own a platform-verified subscription entitlement;
accepting it would let a modified APK bypass both the timer and subscription purchase.

## Compatibility and trust boundary

The unmodified client chooses card identities locally and adds them to its local inventory before
queueing the request. Its success parser logs completion but does not read replacement card IDs.
The old protocol also supplies no server nonce from which both sides could reproduce one random
roll. Consequently, independently replacing the identities on the server would desynchronize a
stock client.

The current compatibility implementation therefore treats the submitted identities as a claim and
enforces the complete source rarity envelope: only the 58 playable IDs are accepted, the count must
be exact, fixed slots must have the specified rarity, and all remaining slots must lie within the
pack's allowed range. Currency and persistence are server-owned, but identity selection inside that
valid range is not yet fully server-authoritative.

A future fully authoritative design requires either a client adapter that accepts the server's
selected cards or a server-issued nonce committed before the client roll. Until then, this boundary
must remain explicit in anti-cheat and economy reviews.

## Remaining card systems

The following systems are still fail-closed or incomplete:

- consuming War Cards during an authoritative PvP battle;
- granting cards or card packs from missions, Arena, assignments, offers, and achievements;
- squad deposits, withdrawals, buddy-card timers, extra slots, and notifications;
- subscription-backed instant `CraftAndClaimCard`;
- server-owned offer/subscription discounts;
- a server-selected card-pack RNG protocol compatible with a modified client.

## Key implementation files

- `Server/scripts/Extract-CardCatalog.mjs`
- `Server/src/data/cardCatalog.generated.json`
- `Server/src/services/cardInventoryService.ts`
- `Server/src/services/assignmentService.ts`
- `Server/src/handlers/cards.ts`
- `Server/src/services/playerStateService.ts`
- `Server/src/tests/cardInventory.test.ts`
