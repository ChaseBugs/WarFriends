# Recovered 1.4.0 communication contracts

Inspected 2026-09-19 against `Clients/ExportedProject`, not the older 1.6.0/4.9.5 client. The machine-readable [inventory](client-communication-inventory.json) records source paths, line numbers, signatures, and source SHA-256 digests. Regenerate with `python Server/tools/inventory_client.py`.

## HTTP account/progression channel

`BeanstalkUrlCreator.CreateUrl()` selects `index_09_25_2015.php` on the original environment host. `BeanstalkServerManager.GetServerRequest()` posts form fields to that single URL. **This is not the older `/<action>/<version>` transport.**

Common fields are `requestId` (DatabaseAction integer), `Version`, `Os=android`, `SheetConfig`, and action-specific string fields. The header `App-Version` carries the short version. Most authenticated calls add `Token` and `PlayerId`; the account-management allowlist differs. Null/empty action values become the literal string `null`. Debug and cheat flags are client assertions, never authorization.

The recovered enum contains **175 named actions**. [LEGACY_ACTIONS.md](LEGACY_ACTIONS.md) lists every ID, with references in the JSON inventory. Examples:

| Operation | ID | Evidence / constraints |
|---|---:|---|
| LoginToCustomAccount | 30 | Distinct from provider login and account creation |
| GetPlayerData | 34 | Includes buffered requests; response is a full initialization contract |
| GameEnded | 62 | Client-reported outcome/statistics must not authorize rewards in the replacement |
| GameStartedMaster / Client | 64 / 65 | Original peer-hosted PvP lifecycle |
| SendRequestBuffer | 98 | `BufferId`, invariant `Count`, JSON `Requests` |
| CreateAccount | 118 | `Locale`, invariant `UtcOffset`; optional Fusebox starting-currency assertions |
| ChangePlayerName | 139 | Do not substitute a later client's action numbering |
| UpdateRegionPings | 140 | Distinct from later-version protocol guidance |
| GetConfigurations | 157 | Raw semicolon-delimited configuration stream |
| ChangePlayerCountry | 196 | Preserve the exact recovered request builder during migration |
| CheckDailyReward / ClaimDailyReward | 1001 / 1002 | Separate check and mutation |

`RequestBuffer` stores ordered requests with `{action,data}`; `data` is itself serialized content. `RequestBufferManager` persists pending work and `GetPlayerData` can carry `Buffers`. Buffered economy operations require idempotency keyed by player, buffer identity and request position, exact request validation, server-owned prices, and per-action results. A retry cannot apply a purchase twice. Request/response inventory counts are not coverage claims.

`ServerResponseHandler.ServerRequestFinished()` ordinarily reads a JSON dictionary and its `Result` code; values greater than 10 enter error handling. It has **137 directly indexed response keys** (nested DTO fields add more). `GetConfigurations` bypasses normal JSON parsing; `GameConfigurationManager.PrepareConfigurations()` parses semicolon sections. `GetCheckRequest()` posts to sibling `check.php`; connectivity checking expects the recovered acknowledgement.

`LoadPlayerData()` calls `DatabaseSerializedObject.LoadObjects()` and consumes Dynamo-style typed values such as `Gold.N`, `WarBucks.N`, `Level.N`, dog-tag fields, and serialized `S` strings. It also triggers inventory, tutorial, calendar, notification, and UI initialization. A small replacement `PlayerProfile` is **not** a compatible stock-client boot response. The new `/v1` protobuf account API is deliberately separate and currently used by the new SDK/smoke clients only.

### Implemented: the legacy boot chain

`War.Backend/Legacy/` now serves the recovered client's own channel at `/check.php` and
`/index_09_25_2015.php`, alongside — not replacing — the new `/v1` protobuf API. Only the host in
`BeanstalkUrlCreator` needs repointing; the paths match what the shipped client requests.

Shapes established from the client's parsers and locked in by `scripts/LegacySmoke.ps1`
(**159 assertions**, run against live MongoDB):

- Top-level response keys are **bare JSON**, because `ServerResponseHandler` reads them with
  `Convert.ToInt32`/`ToString` straight off a `Dictionary<string, object>`. Wrapping `Result` or
  `Time` in an AttributeValue breaks the client.
- `Player` and `PlayerData` are **DynamoDB AttributeValue JSON** (`{"Id":{"S":…},"Level":{"N":…}}`),
  proven by `StringParser.ParseString(key, databaseType, dict)` evaluating
  `dict[key][databaseType]`. `N` is emitted as a string, DynamoDB's real wire shape.
- Each of the **16** `DatabaseSerializedObjectGeneric<T>` subsystems loads its own blob from
  `PlayerData` keyed by `typeof(T).Name`, with a JSON document escaped inside an `S` string.
  A **missing key is not an error**: `Load` falls through to `LoadEmpty()`, an
  `Activator.CreateInstance` default. Omission is therefore the correct encoding of "new account",
  and no starter blob is synthesised.
- Mandatory keys, indexed without a presence check: `CreateAccount` needs `Player`, `Token`,
  `Password`, `PlayerData`, `Time`; `LoginToCustomAccount` needs `Player`, `AccountType`, `Token`,
  `Password` (and **not** `PlayerData` — the client follows up with `GetPlayerData`);
  `GetPlayerData` needs `Time` and `PlayerData`; `GetAllMessages` needs `Items` even when empty.
  Every other key in these responses is `ContainsKey`-guarded and may be omitted.
- **Client dispatch quirk:** the failure branch triggers only on `Result > 10`, so
  `SameFacebookAlreadyCreated` (3) and `AccountAlreadyCreated` (4) reach the *success* handler.
  `LegacyResponse.Failure` refuses to emit a sub-11 code for this reason.
- `check.php` must return exactly `ok`. It is a reachability probe: no session, no rewards.
- `GetConfigurations` is not JSON — `success;<version>;<versionsJson>` leaves the client on its
  shipped Google2u sheets.

Authority held server-side: the guest `Password` and `Token` are server-generated (PBKDF2-SHA256,
600k iterations; the token is stored hashed and rotated on every login, and is bound to its
`PlayerId`). The client's `StartingGold`/`StartingWarbucks` arrive on an unauthenticated action
from a Fuseboxx payload and are logged and discarded; `Legacy:Starter` is the authority. Actions
outside the boot chain return `ServerMaintenance` and log, rather than a hollow `Success` that
would send the client into a handler indexing keys that are not there.

Offline deployment: `Regions` is never emitted, because it deserializes to a
`Dictionary<CloudRegionCode, int>` of Photon Cloud region pings and no Photon is reachable. The
client's null guard leaves `bestRegions` null, which is the accurate representation. Plain-HTTP
serving is opt-in via `Legacy:AllowInsecureHttp` and logs a warning; it is not a default.

### Implemented: buffered request replay

`RequestBufferManager`/`RequestBuffer` are the client's own offline queue: UI actions are appended
locally, `Save()`d, and sent as a batch either via `SendRequestBuffer` (98) or, for anything still
unacknowledged, attached to the next `GetPlayerData` (34) as the `Buffers` field. `War.Backend/Legacy/LegacyBuffer.cs`
and `War.Persistence/LegacyBufferStore.cs` implement both paths.

- **Wire shapes differ from the boot chain.** `ProcessBuffer` reads `RequestsResults`/`BufferId`
  with the single-argument `ParseString` (a bare `ToString()`), and each result entry with
  `ParseIntToken`/`ParseLongToken` — so buffer results are **plain JSON, not DynamoDB
  AttributeValues**. `RequestsResults` itself is a JSON array serialized into a string field.
- **On success the client needs only `ActionId`/`Result`.** Every other field
  `ProcessBuffer` reads on a request's success branch is `!= null`-guarded; the rollback fields
  (`LevelName`, `Weapon`, `InventoryData`, `data`, …) are read only on that action's specific
  failure code, and must carry the authoritative state for the client to revert to.
- **Idempotency is claim-then-apply**, keyed by player + buffer id + request index per
  `Server/AGENTS.md`. `LegacyBufferStore.TryClaim` pushes a null-result placeholder conditional on
  the index being absent; `Complete` fills in the result afterward. A crash between the two leaves
  the index claimed-but-unresolved, and replay reports a failure rather than risk re-granting —
  see the remarks on `LegacyBufferProcessor` for why that direction of error is preferred.
- **Implemented actions**: six that need no catalog data — `WeaponWasShown` (104),
  `ArmyUnitWasShown` (105), `VisualWasShown` (191), `EquipWeapon` (116), `UpdateEquippedUnits`
  (1003), `SaveLastSeenSquadChatTimeStamp` (193, a squad-chat read-receipt timestamp — see
  [Implemented: card crafting](#implemented-card-crafting) for why it's implemented despite the
  "Chat" name) — plus nineteen priced from the catalog: `BuyWeapon`/`BuyUnit` (76/80),
  `BuyWeaponUpgrade`/`ActivateWeaponUpgrade`/`InstantWeaponUpgrade` (73/75/74),
  `BuyUnitUpgrade`/`ActivateUnitUpgrade`/`InstantUnitUpgrade` (77/79/78),
  `ActivateWeapon`/`InstantBuyWeapon`/`ActivateUnit`/`InstantBuyUnit` (128/126/127/125),
  `PromoteUnit` (158, no cost), `BuyDecal`/`EquipDecal` (109/110),
  `UpgradeEliteSlot`/`ConvertPartsToScraps`/`ConvertScrapsToParts` (209/208/207), and
  `BuyCardPack` (97) — see
  [Implemented: the Google2u economy catalog](#implemented-the-google2u-economy-catalog),
  [Implemented: weapon and unit upgrade deliveries](#implemented-weapon-and-unit-upgrade-deliveries),
  [Implemented: elite parts and scraps](#implemented-elite-parts-and-scraps) and
  [Implemented: card packs](#implemented-card-packs) below. The remaining 4 buffered actions —
  `ClaimAssignment`/`ClaimStarterAssignment` (need Battle Server result trust) and
  `IgnoreMessage`/`MessageWasShown` (the owner's "skip Social" instruction) — are out of scope for
  reasons unrelated to catalog data; they return `ServerMaintenance` rather than a fabricated
  success. Granting an unpriced or unauthoritative outcome would be worse than refusing it.
- `PlayerState.cs` models the blobs these actions touch field-for-field against the client's
  POCOs, explicit `JsonPropertyName`s included (`equippedID`'s casing is not a typo):
  `LevelManagerData`, `InventoryData`, `DecalManagerData`, `CardManagerData`. `PlayerAnalyticsData`
  is deliberately **not** modeled the same way — it has ~30 fields and only one or two are ever
  touched by any implemented action, so `WorkingState.Analytics` (`LegacyBuffer.cs`) patches just
  the specific field a given action needs as raw JSON, the same targeted approach
  `LegacyEndpoints.SetAnalyticsFlag` uses for direct actions — round-tripping through a partial C#
  model would silently drop every field this pass doesn't know about. The remaining subsystem blobs
  stay opaque strings, unread and unwritten by buffer processing, until an implemented action needs
  to mutate one.

### Implemented: the Google2u economy catalog

An earlier pass of this document wrongly concluded the Google2u row *schema* classes were missing
from the recovered source, because it searched only `Assets/Scripts`. They are fully recovered at
`Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/*Row.cs` — one file per
sheet type (e.g. `WeaponUpgradesRow.cs`), ~132 of them. Separately, the row **data** — actual
prices, unlock levels, balance constants — was already exported by the parallel Battle Server
effort's `SelfHostedBattleExport.Run` Unity Editor tool into the same
`Server/content/recovered-battle-content.json` the Battle Server uses for map geometry: a `sheets`
array of `{ "type": "Google2u.<Name>", "path": "<scene GameObject path>", "rows": [...] }`, field
names matching the recovered row classes exactly (all-caps: `PRICE`, `PRICEGOLD`, `DBKEY`, …), 132
sheet instances covering weapons, units, cards, visuals, VIP, missions, assignments, arena and
squad-wars rewards.

`War.Backend/Legacy/LegacyCatalog.cs` loads this file (`Legacy:ContentPath` config, same file
`Battle__ContentPath` already points at) and indexes every sheet. Missing/unset path is not an
error — the catalog is simply empty and every catalog-dependent action keeps refusing exactly as
before. First consumers, each verified against the real exported numbers via `scripts/LegacySmoke.ps1`:

- **Starter balances** (`LegacyStarterState.FromCatalog`): `StartingGold=75`, `StartingWarbucks=15000`,
  `DogTagCap=5` from `Google2u.Constants`, replacing the previously-fabricated 500/50/10
  placeholders (which remain as the fallback only when no catalog is configured).
- **`ChangePlayerName` (139)**: `SecondRenameGoldCost=25` from the same Constants sheet feeds
  `PlayerAnalytics.renameGoldPrice`'s `2^(RenameCount-1) * 25` formula — verified through a third
  rename (25 gold, then 50 gold).
- **`BuyWeapon` (76)** and **`BuyUnit` (80)**, both buffered: priced from `Google2u.WeaponUpgrades`/
  `Google2u.ArmyUpgrades` by the item's `NAME` (a unit's is its DBUpgradeSlots sheet type name,
  from `UpgradeSlots.GetSheetName()` = `excel.GetType().ToString()`). `PRICE` (Warbucks) or
  `PRICEGOLD` (Gold), whichever is nonzero, is charged; `CANBEBOUGHT` is the level gate despite its
  boolean-sounding name (`WeaponLevelsSetup.canBeBought =&gt; currentLevel.index &gt;=
  CANBEBOUGHT - 1`, confirmed identical for `UpgradeSlots.canBeBought`). Weapons additionally
  require `PURCHASABLE == "shop"`; **unit rows carry no `PURCHASABLE` field at all** — verified
  against the recovered `ArmyUpgrades` sheet — so that check does not apply to `BuyUnit`. A nonzero
  `DELIVERTIME` (no weapon or unit in the current export actually has one) or a nonzero
  client-asserted `discount` is refused rather than guessed at — no delivery-completion action or
  sale-validation system exists yet. Re-buying an already-owned item succeeds as a no-op (the shop
  UI never offers a buy action for something already owned, so there's no evidenced failure code
  to reuse for that case). Wallet debits are folded into the same buffer-processing document write
  as the `LevelManagerData` blob update, but — like the existing buffer-receipt claim/complete pair
  — are not yet atomic against a *second, concurrently-processed* buffer for the same player; that
  needs the Mongo replica set `README.md` already lists as a prerequisite for economy settlement.

### Implemented: weapon and unit upgrade deliveries

`BuyWeaponUpgrade`/`ActivateWeaponUpgrade`/`InstantWeaponUpgrade` (73/75/74) and their unit
equivalents `BuyUnitUpgrade`/`ActivateUnitUpgrade`/`InstantUnitUpgrade` (77/79/78) implement a
genuine three-step **timed delivery** state machine, using `LevelManagerData.WeaponDelivery`/
`UnitDelivery` (already modeled) to track the single in-flight delivery — matching the client's own
single shared `LevelManager.weaponDelivery`/`unitDelivery` slot, not a per-item queue.

- **A separate export from the base sheets.** `WeaponLevelsSetup.uprgradesExcel =
  GetComponent<Google2uComponentBase>()` is a *distinct* per-weapon/unit component from
  `Google2u.WeaponUpgrades`/`ArmyUpgrades`. Its sheet type name is the item's own name (e.g.
  `Google2u.AssaultRifle_AK47`, 26 rows; `Google2u.DBUpgradeSlotsAssaulter`, 136 rows), one row per
  upgrade level, fields `NEXTUPGRADEPRICE`/`NEXTUPGRADEPRICEGOLD`/`DELIVERYTIME` at the row index
  equal to the item's current `BoughtIndex`. **An earlier note here claimed only `AssaultRifle_AK47`
  had this exported and was wrong** — re-checked: the export covers essentially the full weapon and
  unit roster, so `PriceNotFound` is the correct outcome for a genuinely unrecognised name, not the
  expected common case.
- **Field spelling is exactly as recovered and deliberately not normalized**: this per-level sheet
  uses `DELIVERYTIME`; the base `WeaponUpgrades`/`ArmyUpgrades` sheets use `DELIVERTIME`.
- **`BuyWeaponUpgrade`/`BuyUnitUpgrade`** charge the price and start the timer
  (`start=now`, `end=now+DELIVERYTIME`), but do **not** advance `BoughtIndex` yet — matching
  `UpgradeSlots.BuyUpgrade()`. Guards, in order: sheet exists (`PriceNotFound`); item owned
  (folded into `WrongIndexToActivate` for units, since the client's shared case block has no
  unit-specific "not bought" code the way weapons have `WeaponNotBought`); the client's asserted
  `BoughtIndex` matches the server's stored value (`WrongIndexToActivate` otherwise — a stale
  request relative to a change the server already applied); not already maxed out
  (`AlreadyMaximumUpgrade`); no delivery already pending (`AlreadyUpgrading`); funds
  (`NotEnoughGold`/`NotEnoughWarbucks`).
- **`ActivateWeaponUpgrade`/`ActivateUnitUpgrade`** complete a delivery once its timer has
  naturally elapsed — free, matching `UpgradeSlot.Activate()`. Before `end`, refused with
  `TooSoonToActivate`.
- **`InstantWeaponUpgrade`/`InstantUnitUpgrade`** pay Gold to skip the remaining wait, reproducing
  `MiscTools.ConvertTimeIntoGold` exactly: `ceil(GoldCoefficient * minutes^GoldExpCoefficient *
  minutes)` over the seconds actually remaining, using the verified catalog constants
  (`GoldCoefficient=0.6325`, `GoldExpCoefficient=-0.175`) — **never** the client's own
  `ExpectedPrice`/`GoldCoefficient`/`GoldExpCoefficient` request fields, which are logging
  assertions only.
- **The special upgrade track is now traced, but still deliberately out of scope.** The client also
  has `UpgradeSlots.upgradeSlotSpecial` (requested with `IsSpecial=1`, tracked by
  `SavedArmySlots.specialSlot`). An earlier note here said its pricing row source hadn't been traced
  at all; re-checked while implementing elite parts/scraps below, and it has: it prices from the
  *same* per-unit sheet as the normal track, filtered to a different row range by the row's own
  `TIER` column (`TIER / 10 == 1`, offset `Google2u.ArmyUpgrades`' `STARTINGSPECIAL` — see
  [Implemented: elite parts and scraps](#implemented-elite-parts-and-scraps) for the full scheme).
  What remains genuinely unimplemented is `UpgradeSlots.actualMaxLevel`, which further gates the
  special track by the unit's *promoted* tier (`PromoteUnit`'s own tier, via a second
  `Tier % 10 < actualTier` filter) — a materially larger feature than the elite track needed, so
  `IsSpecial=1` stays refused with `ServerMaintenance` rather than a half-correct implementation.
- **Found and fixed a real bug in the normal track while tracing this**: the "already maxed" ceiling
  used to be the per-unit sheet's *raw* row count. That overcounts whenever a unit's sheet also has
  special/elite rows appended after the normal track (confirmed on `DBUpgradeSlotsAssaulter`: 136
  raw rows are only 101 real normal-track rows) — a sufficiently-leveled unit could have bought past
  its true max and silently priced from a special or elite row instead. Fixed with a `TrackRows`
  helper that filters by `TIER / 10 == 0`, falling back to the full sheet when the sheet has no
  `TIER` column at all (every weapon sheet, which has no special/elite tracks to begin with, so
  behavior there is unchanged).

**`ActivateWeapon`/`InstantBuyWeapon`/`ActivateUnit`/`InstantBuyUnit` (128/126/127/125)** close the
loop on `BuyWeapon`/`BuyUnit` themselves. `WeaponLevelsSetup.Buy()` only sets `bought=true`
immediately for a **gold**-priced item; a Warbucks-priced or free one instead starts a delivery
(`weaponDeliveryTime = weaponUpgradesRow.DELIVERTIME`), and the client's own `BuyWeapon()`/
`BuyUnit()` UI methods unconditionally queue this confirmation action right after — calling the
local `ActivateWeapon()`/`ActivateUnit()` immediately when that delivery time is zero, which it is
for every item in the current export. So a real client's buffer for "buy this weapon" is actually
**two** entries, `BuyWeapon` then `ActivateWeapon`, and the second one must be safe to call on an
item the first one already fully purchased. These four handlers treat an already-bought item as an
idempotent success (no charge), and fall back to completing a genuinely pending delivery (checked
against `LevelManagerData.WeaponDelivery`/`UnitDelivery`) for forward-compatibility, should a
future catalog update introduce a nonzero base `DELIVERTIME` that `BuyWeapon`/`BuyUnit` don't yet
create a delivery for (they currently refuse those instead — see above).

**`PromoteUnit` (158)** advances `SavedArmySlots.Tier`, gated by the player's `Level` against
`Google2u.ArmyUpgrades`' `UNLOCKTIER2..UNLOCKTIER6` (tier 6 is max — `UpgradeSlots.GetUnlockTierLevel`
returns a sentinel `999` beyond it, unreachable by any player level). No cost. It is the one action
in this whole file confirmed to have **zero response fields read anywhere** in the recovered client
(no match for "PromoteUnit" at all in `ServerResponseHandler.cs`), so its `Result` code only needs
to land on the correct side of the client's `> 10` success/failure split.

**`BuyDecal` (109)** prices cosmetics from `Google2u.PlayerVisuals` by `NAME`, a genuinely
narrower contract than the weapon/unit economy: the only evidenced failure codes at this call site
are `NotEnoughWarbucks`/`NotEnoughLevel`/`NotEnoughGold`/`DecalOnlyForVip`, so a client-asserted
`discount` or an unrecognised name both fall back to `PriceNotFound` (not `DecalCategoryNotFound`,
which belongs to `EquipDecal`'s (110) failure set, not this one). Guards, in order: row exists and
`PURCHASABLE == "shop"` (`PriceNotFound`); already owned (idempotent no-op success, same reasoning
as `BuyWeapon`/`BuyUnit`); `ONLYFORVIP` gate against the player's live VIP expiry
(`DecalOnlyForVip`); `UNLOCKLEVEL` (`NotEnoughLevel`); then `PRICEGOLD` or `PRICEWARBUCKS`,
whichever is nonzero (`NotEnoughGold`/`NotEnoughWarbucks`). Failure rolls back the whole
`DecalManagerData` blob, not a per-item field, matching how the other buffered actions in this file
roll back their subsystem blob. A successful response's `ExpiresOn` is a separate rental/promo
timestamp (`0` for the permanent purchases this pass covers), distinct from the `Bought` flag itself.
**`EquipDecal` (110)** equips an owned cosmetic. `CamosScreen.EquipPlayerVisual` sends the decal's
bare `NAME` string as `Request.data` — **not JSON**, unlike `BuyDecal`'s payload.

- **The equip slot is `CATEGORYID`, not `CATEGORY`.** An earlier note in this document's history
  claimed `CATEGORY` was the slot index; re-checked and corrected: `CATEGORY` is
  `PlayerVisual.rarity` (Common..Legendary), unrelated to equip slots. The real slot key is the row's
  separate `CATEGORYID` field (0–3), matching `PlayerVisualCategory.categoryNumber`. Verified two
  ways from the recovered client itself, not guessed: the extracted `MainScene.unity` serializes
  `CamosManager.playerVisualCategories` as exactly four components in order — `idPrefix` `CAMOS_`,
  `HELMETS_`, `HEAD_`, `BANDS_` at indices 0–3 — and every exported `Google2u.PlayerVisuals` row's
  `CATEGORYID` matches its own name's prefix exactly (every `CAMOS_*` row carries `CATEGORYID=0`,
  every `HELMETS_*` row `CATEGORYID=1`, and so on). `CamosManager`'s own `Equip()` writes
  `data.slots[owner.categoryNumber].equippedID = id`, so `CATEGORYID` is exactly that key.
- **Ownership mirrors `PlayerVisual.isBought`'s free-item clause.** A zero-price
  `PURCHASABLE == "shop"` visual (e.g. `HELMETS_EMPTY`) is always equippable without an explicit
  `BuyDecal` first, matching the client's own `equipPart.SetActive(isBought)` gating (which treats a
  free shop item as always-owned). This pass does not reproduce `isBought`'s `PARTS`-based
  duplicate-unlock clause, matching `BuyDecal`'s own scope. It also does not seed any decal as
  pre-owned for a newly created account — the same pre-existing gap already affects starting
  weapons/units and is not this action's job to fix.
- **Both evidenced failures reload the whole `DecalManagerData` blob**: an unrecognised name (no
  category can be determined) is `DecalCategoryNotFound`; a recognised-but-unowned name is
  `DecalNotBought`.

### Implemented: elite parts and scraps

`UpgradeEliteSlot` (209), `ConvertPartsToScraps` (208) and `ConvertScrapsToParts` (207) — all
buffered — implement the unit "elite" upgrade track: a fourth, higher tier of per-unit upgrades
paid in **Elite Parts** rather than Gold/Warbucks directly, with the option to buy a level outright
in Warbucks instead of grinding for parts.

- **A per-unit sheet encodes three upgrade tracks in one table.** `UpgradeSlot.maxPower` filters a
  `Google2u.DBUpgradeSlots<Type>` sheet's rows by `Tier / 10`: 0 is the normal track (already used by
  `BuyUnitUpgrade`), 1 is the special track (`UpgradeSlotSpecial`, still unimplemented — see above),
  2 is elite (`UpgradeSlotElite`). Confirmed on the recovered `DBUpgradeSlotsAssaulter` sheet: its
  136 rows split into exactly 101 track-0, 25 track-1 and 6 track-2 rows, in that contiguous order,
  plus 3 unused `TIER=-1` padding rows — and `Google2u.ArmyUpgrades`' own `STARTINGSPECIAL=101` for
  that exact unit lines up with where the track-0 block ends. `LegacyBuffer.cs`'s new `TrackRows`
  helper reproduces this filter; a sheet with no `TIER` column at all (every weapon sheet, which has
  no special/elite tracks) is returned unfiltered.
- **Elite availability is a separate gate from row presence.** `UpgradeSlotElite.isUnlocked =>
  owner.armyUpgradesRow.STARTINGELITE > 0`. `DBUpgradeSlotsAssaulter`'s sheet *has* six `TIER=21`
  rows, but its `ArmyUpgrades` row's `STARTINGELITE` is `-1` — elite is not actually available for
  that unit. `DBUpgradeSlotsShotgunner` (`STARTINGELITE=127`) is the real, unlocked test case.
- **The elite row repurposes the normal track's two price columns.** `NEXTUPGRADEPRICEGOLD` is
  actually the **Elite Parts** required for that level (`UpgradeSlotElite.upgradePriceParts`), and
  `NEXTUPGRADEPRICE` is the **Warbucks** price to buy the level outright instead
  (`ArmyScreen.UpgradeUnitElite`) — column names are exactly as recovered, not renamed to match their
  real meaning. `ArmyScreen.BuyUnitElite`/`UpgradeUnitElite` both always assert
  `SpentParts == upgradePriceParts` and decrement `currentParts` by that amount regardless of which
  path is used; the server clamps the result at 0 (a defensive floor, not new gameplay logic, since
  the client's own unclamped local subtraction can go negative). There is no client-visible discount
  field for this action (unlike `BuyWeaponUpgrade`/`BuyUnitUpgrade`'s `discount`), so `SpentWarbucks`
  must be exactly `0` or the row's undiscounted price — `OfferManager.DiscountedUnit`'s special-offer
  system is untraced and out of scope, matching every other discount/offer path in this file.
- **`ConvertPartsToScraps`/`ConvertScrapsToParts`** use `Google2u.Constants` `PartToScrapsSell=5`
  (1 part → 5 scraps) and `PartToScrapsUpgrade=24` (24 scraps → 1 missing part). Both client call
  sites (`ArmyLeftBuffDialog`) always convert the *entire* current amount or fill the *entire* gap —
  never a partial one — so `ConvertPartsToScraps`'s client-asserted `PartsToConvert`/`Scraps` must
  match the server's own stored parts count and recomputed total exactly (`IncorrectPartsAmount`
  otherwise), and `ConvertScrapsToParts`'s `Request.data` is just the unit's bare sheet name (like
  `WeaponWasShown`/`EquipDecal`, not JSON) since there is nothing left for the client to assert.
- **None of these three actions' evidenced failure branches read any response field** — each just
  shows an error dialog and forces a relog (`GameLoginManager.Relog()`), which re-syncs everything
  via a fresh `GetPlayerData` — so a bare `Result` is the entire failure contract, unlike most other
  economy actions in this file, which resync one item or a whole subsystem blob inline.
- A genuine success path for any of the three is not reachable in the smoke-test account: no
  mission/reward system is implemented yet to grant a unit its first Elite Parts, and converting
  Scraps into parts needs Scraps the account has no way to earn either. All 8 assertions verify
  refusal paths — the locked-unit gate, stale `BoughtIndex`, mismatched asserted parts, and the
  zero-parts/zero-scraps state a fresh account is actually in — which is what's actually reachable
  and verifiable without fabricating a currency grant.

### Implemented: card packs

`BuyCardPack` (97) covers both the three named Gold-priced packs and the Warbucks-priced
`THREE_CARDS` promo pack — previously deferred earlier in this session as a large, separate
RNG-reproduction concern; re-scoped and implemented once the exact algorithm and its backing
constants were traced.

- **The client performs its own RNG before ever sending the request**, and the resulting card ids
  ride along in the payload's `cards` array purely as an assertion — `LegacyBufferProcessor` never
  reads it. Rewards must be server-owned, matching this file's standing rule that client-reported
  outcomes are never authoritative, so the awarded cards are generated independently here from the
  same algorithm, using the server's own stored player `Level`, never the client's.
- **The pool is `Google2u.CardDefinitions` filtered to `IMPLEMENTED=true` and grouped by `RARITY`**
  (1=Bronze/2=Silver/3=Gold) — exactly `CardManager.OnPlayerDataLoaded`'s own population of
  `mCardsByQuality`. Verified counts: 26 Bronze, 17 Silver, 14 Gold implemented cards.
  `FROMMISSION` is a separate flag unrelated to pack pool membership and is not filtered on.
- **`Google2u.CardPacks` has exactly four rows** — `BRONZE_CARDPACK`/`SILVER_CARDPACK`/
  `GOLD_CARDPACK` (priced in Gold: 19/39/69) and `THREE_CARDS` (priced in Warbucks: 1200) — each
  just a `NAME`/`GOLD`/`WARBUCKS` price row with **no composition data**, so which cards a named
  pack draws from is a finite, evidenced mapping matched by name
  (`CardManager.GetCardsFromCardpack`'s `switch` on `CardType`), not something read generically from
  the row.
- **Two distinct generation algorithms, both reproduced exactly**: `GetCardsFromCardpack` (the three
  named packs) draws a fixed number of guaranteed-rarity cards (`BronzePackBronzeCards=7`/
  `SilverPackSilverCards=6`/`GoldPackGoldCards=5`) plus a level-weighted random remainder up to
  `CardsInPack=10`; `BuyThreeCards` (`THREE_CARDS`) instead calls the parameterless
  `AddRandomCard()` exactly 3 times with no guaranteed cards and **does not consult `CardsInPack` at
  all**. The random-rarity roll (`GetRandomRarity`) is a level-interpolated threshold check —
  `LevelManager.InterpolateNumbersBasedOnLevel` between the client's hardcoded
  `LowLevelTreshold=7`/`HighLevelTreshold=10` and the verified `Google2u.Constants`
  `SilverCardRarityEarly=0.2`/`SilverCardRarity=0.6`/`GoldCardRarityEarly=0.7`/`GoldCardRarity=0.9`
  — reproduced faithfully, including which of the two thresholds each pack's guaranteed/random
  split maps its `min`/`max` roll range to.
- **A real, unavoidable wire-contract gap, left as-is rather than fabricated around**: the client's
  `OnBuyCardPack` success handler reads **zero response fields**. A genuine client's own local RNG
  guess therefore stays on screen until the next full `GetPlayerData` reconciles it against the real
  `CardManagerData` this handler writes — there is no evidenced field to correct it immediately. This
  is the same "server-owned, client-reported outcomes never trusted" posture as every other
  reward-granting action in this file; it just has no immediate correction path on the wire, which
  is a property of the recovered contract itself, not a shortcut taken here.
- **The evidenced failure set is narrower than for weapons/units**: only `NotEnoughWarbucks` and
  `CardPackNotFound`/`NoDiscountFound` are read by `ServerResponseHandler`'s case block for this
  action. There is no `NotEnoughGold` case here at all — `NotEnoughWarbucks` is reused deliberately,
  not a naming mistake, as the insufficient-funds code even for the three Gold-priced packs, because
  it is the only code this block actually resyncs `CardManagerData`/the wallet for.
- New `CardManagerData`/`SavedCardData` model in `PlayerState.cs`. The unused `buddyCardData`/
  `nextWithdraw`/`nextBuddyDeposit`/`extraSlot` fields (Squad card-pool deposit/withdraw, buddy
  cards) are modeled too, even though nothing implemented yet writes them, so a future write through
  this same round-trip never silently drops them — the same reasoning already applied to
  `DecalManagerData`'s full shape.

### Implemented: Squad membership, management and card pool

`CheckUniqueSquadName` (41), `CreateSquad` (37), `JoinSquad` (38), `GetSquadDetails` (45),
`GetAllSquadMembers` (44), `LeaveSquad` (49), `PromotePlayer` (55), `DemotePlayer` (58),
`PromotePlayerToFounder` (57), `KickPlayer` (172), `UpdateSquad` (131), `UpdateSquadEmblem` (63),
`GetSquads` (56), `FindSuggestedSquads` (81), `InvitePlayerToSquad` (59), `JoinSquadRequest` (132),
`AcceptSquadJoinRequest` (133), `DeclineSquadJoinRequest` (181), `GetFullSquadInfo` (151),
`DepositCards` (174), `WithdrawCard` (175) — a real Squad membership, management, invite/request
and card-pool vertical. Squad was the largest remaining "deprioritized, not skipped" category once
every Battle-Server-dependent, real-payment-blocked, RNG-deferred and untraceable-content action
in the enum sweep above was exhausted, so this re-scopes a substantial part of it into a genuine
implementation rather than leaving the whole feature area untouched.

- **The squad's display name doubles as its own identifier.** `CreateSquad`'s request builder sends
  the name as `SquadId` with no separate generated id (`BeanstalkServerManager.CreateSquad`), so the
  new `LegacySquadStore`/`LegacySquadDocument` (Mongo collection `legacySquads`) uses that name as
  the document's own `_id` — Mongo's native uniqueness constraint is exactly what
  `CheckUniqueSquadName` needs to answer, with no separate reservation/lock required.
- **`CreateSquad`'s price is real, verified, and escalating — not flat.**
  `PlayerAnalytics.createSquadWarBucksPrice = (squadCreationsCount + 1) *
  Constants.rowIds.WarBucksCreateSquadPrice` (verified 50,000 Warbucks). Reproduced via a new
  `LegacyPlayerDocument.SquadCreationsCount` field, incremented on every successful creation and
  echoed back as the optional `squadCreationsCnt` the client syncs its own local counter from. The
  squad document is inserted (with its creator as `SquadRank.Leader`) *before* the price is charged,
  so a name collision (`SquadnameTaken`) never needs a refund path.
- **None of these fourteen actions have a dedicated failure-branch case in `ServerResponseHandler`
  at all** — like `PromoteUnit` earlier in this document, a bare `Result` is the entire failure
  contract for every one of them; only the success paths need real response fields
  (`SquadId`/`PlayerRank` unguarded top-level on `CreateSquad`/`JoinSquad`; `Squad` — cast directly,
  unguarded — on `CreateSquad`/`GetSquadDetails`; `SquadMembers`/`SquadId` unguarded on
  `GetAllSquadMembers`; `Items` unguarded on `GetSquads`/`FindSuggestedSquads`). Each squad member
  in `SquadMembers`, and each promoted/demoted/kicked target, is the exact same `Player`-shaped
  projection as `GetPlayerInfo`'s `PlayerInfo` field, since they all feed
  `DatabasePlayer.CreateFromDatabase`.
- **Rank/settings actions are gated on the caller's own stored `SquadRank`, never a client
  assertion.** `PromotePlayer`/`DemotePlayer`/`PromotePlayerToFounder`/`KickPlayer`/`UpdateSquad`/
  `UpdateSquadEmblem` all require the caller to already hold `SquadRank.Leader` or `Coleader` in
  their own squad (`NotLeaderOfSquad` otherwise), resolved server-side from the caller's session,
  not from any field the request carries. `PromotePlayer`/`DemotePlayer` step the target exactly one
  `SquadRank` at a time, clamped at `Coleader`/`Member` — already at the limit is an idempotent
  success, since no evidenced code exists for "can't go further" (same reasoning as other
  already-maxed cases elsewhere in this file). The client's own asserted `OldSquadRank` is never
  read as authoritative. `PromotePlayerToFounder` transfers sole leadership — `OnPromotePlayerToFounder`
  unconditionally drops the *caller's own* local rank to Veteran regardless of whether the guarded
  `PromotedPlayer` field is present, so the server does the same authoritatively for both players in
  one call. `UpdateSquad`'s request field is `RequiredMedals`, not `SkillRequirement` like
  `CreateSquad` uses for the same concept — confirmed real from the request builder, not normalized
  away as a typo.
- **`GetSquads`/`FindSuggestedSquads` share one handler but search differently.** `GetSquads` filters
  public squads by the client's `SquadNameStart` prefix (a real Mongo regex query);
  `FindSuggestedSquads` sends a `Skill` value instead, but no skill-matching formula was traced from
  the recovered client, so it degrades to "any public squad" — an honest simplification, not a
  fabricated heuristic.
- **Found and fixed a real bug while testing this batch**: `CreateSquad`'s insufficient-funds path
  originally removed only the failed creator's *membership* from the newly-inserted squad, leaving
  the squad *document* itself behind as a real, empty, publicly-searchable orphan —
  `GetSquads`/`FindSuggestedSquads` would then legitimately return it as a genuine search result.
  Fixed by deleting the whole document on that refusal instead of just the one membership entry.
- **The invite/request-to-join path turned out not to need the message/inbox system after all.**
  An earlier pass here assumed `InvitePlayerToSquad`/`JoinSquadRequest`/`AcceptSquadJoinRequest`/
  `DeclineSquadJoinRequest` were blocked on the same message system the owner's "skip Social"
  instruction covers, since `JoinSquad`'s own accept-an-invite path uses a `MessageId`. Re-checked
  each handler's exact response reads: `OnInvitePlayerToSquad`/`OnJoinSquadRequest` read *nothing*
  from the server at all (one hides a waiting dialog, the other flips a local UI flag), and
  `OnDeclineSquadJoinRequest` reads only its own already-sent request fields, never the response
  body. None of the four genuinely need a delivered message to function correctly. Implemented via
  two new `LegacySquadDocument` lists — `PendingInvites`/`PendingRequests` — that track the same
  real state a message would have carried, without needing message delivery. The recovered enum has
  no separate "accept invite" action, so `JoinSquad` itself was extended: a private squad is
  joinable when the caller is in that squad's `PendingInvites`, matching how a genuine client would
  actually accept one (via `JoinSquad`'s own `MessageId` parameter, which this reproduction
  substitutes for). `GetFullSquadInfo` (151) combines `GetSquadDetails` + `GetAllSquadMembers` into
  one response, exactly matching `OnGetFullSquadInfo`'s own `OnGetSquadDetails();
  OnGetAllSquadMembers();` pair against the same response body.
- **`RemoveUserFromSquad` (42) is verified dead** — zero live call sites and no response reader
  anywhere in the recovered client, the same class of finding as `ChangeNameAndPassword`/
  `CreateFullAccount`/`SystemMessage` elsewhere in this document. Not implemented, by design.
- **Battle-derived squad statistics are deliberately zeroed, not omitted.**
  `DatabaseSquad.CreateFromDatabase` reads real fields for kills/battles-won/battles-lost/
  squad-points/Squad Wars round data, but none of them are meaningful without Battle Server result
  trust — the same reason Ranked PvP/Player Leagues and War Arena stay out of scope. A squad this
  slice creates is a real, joinable group with no war-derived history yet, which zero correctly
  represents; a battle-derived field is never a placeholder.
- **Deliberate limits, each a documented gap, not a silent assumption**: no verified maximum squad
  size exists (`GetSquadRankSize` depends on an untraced catalog sheet), so member-count gating is
  not enforced at all; leadership does not auto-transfer when a Leader/Coleader leaves a non-empty
  squad (no evidenced succession rule, `PromotePlayerToFounder` is the only supported transfer, and
  only while the caller is still present to call it); a squad left with zero members is not
  actively deleted (no evidenced cleanup rule); the real, evidenced one-time 50-Gold first-join
  reward (`GoldRewardFirstTimeSquad`) needs a "claimed once" flag inside the still-unmodeled
  `PlayerAnalyticsData` blob and is deferred rather than risk re-granting it on every join.
- **A real testing limitation, not hidden**: `CreateSquad`'s 50,000-Warbucks price is far beyond
  this smoke-test account's starting balance (15,000 with the catalog loaded), so its success path —
  and everything downstream that needs a squad to already exist, including every rank/settings
  action's success path — is not reachable in `LegacySmoke.ps1` as currently seeded. The assertions
  branch dynamically on the live balance where relevant (matching the posture already established
  for `UpgradeEliteSlot`/`ConvertPartsToScraps`), and every reachable outcome is verified for real:
  the failure paths (`WrongPlayerData` on an overlong name, `NotEnoughWarBucksForCreateSquad`,
  `SquadNoLongerExists`, `NoSquadFound`, `SquadLeaveError`, `NotLeaderOfSquad` on all six rank/
  settings actions plus `InvitePlayerToSquad`/`AcceptSquadJoinRequest`/`DeclineSquadJoinRequest`)
  and both searches' genuinely-empty-result success path (no squad ever exists yet in this run's
  isolated database, so an empty `Items` array is the real, not assumed, outcome).

**`DepositCards` (174) and `WithdrawCard` (175) close out the vertical.** The squad card pool is
not a separate structure at all: `DatabasePlayer.CreateFromDatabase` parses a `DepositedCards` map
directly off *each squad member's own player record*, which is why it becomes visible to squadmates
simply by virtue of `GetAllSquadMembers`/`GetSquadDetails`/`GetFullSquadInfo` already projecting the
full `Player` shape through `PlayerObject` — no dedicated pool-fetch action exists in the enum
because none is needed.

- **A genuinely different wire shape from `CardManagerData.CardData`.** The exact parse site reads
  `DepositedCards["M"][cardId]["M"]["Amount"]["N"]` — a *nested* DynamoDB map (capitalized
  `Amount`), not the flat `{"amount":N}` string `CardManagerData` itself uses elsewhere in this same
  client. `PlayerObject` was extended to emit precisely this nested shape, confirmed from
  `DatabasePlayer.CreateFromDatabase`'s own deserialization branch, not assumed by analogy with the
  simpler shape.
- **`AddedCards`/`RemovedCards` are double-encoded.** `CardpoolDialog.GetCardsInJson` serializes a
  `Dictionary<string, string>` whose *values* are themselves `JsonConvert.SerializeObject`d
  `CardManager.CardData` (`{"amount":N}`) — a JSON string inside a JSON string. Parsed tolerantly,
  skipping any single malformed entry rather than failing the whole request.
- **Ownership is verified both directions, never trusted from the client.** Depositing requires the
  player to actually own at least as many of the card as they claim to be moving into the pool;
  un-depositing requires the pool to actually hold at least that many. Both are computed from the
  server's own stored `CardManagerData`/`DepositedCards`, never the client's assertion.
- **`WithdrawCard`'s cooldown is real, verified, and server-owned.** `Google2u.Constants`
  `CardWithdrawTimer` (240 seconds) — the client never computes this locally at all; `OnWithdrawCard`
  reads `mResponse["NextWithdraw"]` as an unguarded top-level index and simply stores whatever the
  server last returned. Reproduced by storing the cooldown deadline in the withdrawing player's own
  `CardManagerData.NextWithdraw` (a field `CardManagerData` already modeled for `BuyCardPack`).
- **Buddy-card deposits use a distinct wire shape and are out of scope.** `DatabasePlayer`'s parser
  has a second branch for keys matching a `"start-end"` numeric range pattern (a rental/time-window
  key, not a card id) with a plain `{"S":...}` value — clearly a different encoding for buddy cards
  specifically. Rather than guess at that shape, a request naming the literal card id `"BuddyCard"`
  is refused outright.
- **8 real assertions, including a genuine success round trip.** Deposit-then-undeposit is exercised
  using whichever card the `BuyCardPack` tests earlier in the same run actually won — never a
  hardcoded card id, since the pack's contents are genuinely random — reading the result back
  through `GetPlayerInfo` (170) rather than `GetPlayerData`, since `GetPlayerData`'s response has no
  `Player` object at all (only `PlayerData`) and `DepositedCards` lives on the `Player` shape.

### Implemented: card crafting

`CraftCard` (176) and `ClaimCraftedCard` (177) — two direct (non-buffered) actions mirroring
`CardCraftingManager`. `CraftCard` requires exactly 3 cards of the same rarity (Bronze or Silver;
Gold is never accepted since there is no higher tier to craft into) and the player must genuinely
own that many of each of the three, verified against the server's own `CardManagerData.CardData`,
never the client's assertion. On success the three cards are debited and a `CraftData{cards, start,
end}` blob is written mirroring `CardCraftingManager.CraftData`; the client's own `isCrafting` flag
is `cards.Count > 0 && start < end`, reproduced identically server-side.

- **The craft duration is a real, verified `Google2u.Constants` value, and the constant names the
  *output* tier, not the input.** `CardCraftTimeSilver` (30 minutes) gates a Bronze→Silver craft;
  `CardCraftTimeGold` (60 minutes) gates a Silver→Gold craft. This was checked against the client
  source directly (not assumed from the name) since the naming is easy to misread backwards.
- **`AlreadyUpgrading` (105) and `TooSoonToActivate` (106) are reused, not invented.** A second
  `CraftCard` while one is already in progress (`cards.Count > 0 && start < end`) returns
  `AlreadyUpgrading`; a `ClaimCraftedCard` before `end` has passed returns `TooSoonToActivate` — both
  existing codes already used elsewhere in the recovered enum for the same "an upgrade timer is
  still running" shape, not new server-invented semantics.
- **The awarded card's RNG is server-owned, reusing `BuyCardPack`'s own machinery.** `PickCard` and
  `CardPoolsByRarity` (originally written for `BuyCardPack`) were promoted from `private` to
  `internal` in `LegacyBufferProcessor` specifically so `ClaimCraftedCard` could call the same
  uniform-pick-by-rarity roll rather than re-deriving it — the two features draw from the identical
  `Google2u.CardDefinitions` `IMPLEMENTED=true` pools grouped by `RARITY`.
- **The failure contract is a bare `Result` code.** Like `CraftCard`/`ClaimCraftedCard`'s siblings
  elsewhere in this vertical, `ServerResponseHandler` has exactly one dispatch case for each action's
  success path — no rollback fields are ever read on failure.
- **`OnCraftCards`'s `End` field is an unguarded top-level read**, so `CraftCard`'s success response
  always carries it; `ClaimCraftedCard`'s success response carries the awarded `CardId` the same way.
- **8 real assertions**, including a genuine success round trip crafting 3 real owned Bronze cards
  into a Silver, reusing whichever Bronze cards the same test run's `BuyCardPack` tests actually won.
  A full craft's real-world duration (30 real minutes) makes `ClaimCraftedCard`'s success path
  unreachable within a single smoke-test run; `TooSoonToActivate` immediately after starting a craft
  is verified instead, and covers the same guard the eventual success path depends on.

`NotifyPlayerToDeposit` (178) is a third direct action closing out the card-pool vertical: a
squadmate nudge with no persisted effect at all — `ServerResponseHandler` shares its success case
with `UpdateArmyPower`, logging only ("Action Success: NotifyPlayerToDeposit") and reading nothing
back. A real push notification (Fuse/FCM) is out of scope, matching every other retired third-party
SDK this project doesn't reach for. The only real validation left is that the target `SquadMemberId`
is genuinely a squadmate of the caller — never trusted blindly, the same check `WithdrawCard` already
makes of its own target. 2 assertions cover the deterministic "not in a squad" / "targeting yourself"
refusals; the real success path shares `CreateSquad`'s same economic unreachability in this suite.

**`SaveLastSeenSquadChatTimeStamp` (193) was re-checked out of the owner's "skip Chat" scope.** It
was originally grouped under the owner's "skip Social" instruction by name alone, but its actual
client-side role (`PlayerAnalytics.lastSeenSquadChatTimestamp`'s setter) is a read-receipt timestamp
for a squad-chat unread badge — not a chat message itself. The recovered `DatabaseAction` enum has no
message-send/receive action at all (no `SendChatMessage`/`GetChatMessages`), so there is no real
chat-transport feature being implemented by honoring this one. This matches the exact precedent
already accepted for `ChatShownFirstTime` (163), a "Chat"-named action implemented despite the label
for the same reason. It is buffered: the client's setter only ever advances the stored value, never
regresses it, reproduced by patching just that one field of the otherwise-unmodeled
`PlayerAnalyticsData` blob (`WorkingState.Analytics`/`AnalyticsChanged` in `LegacyBuffer.cs`) rather
than modeling the blob's ~30 fields for the sake of one integer. 7 assertions, including one
confirming an earlier "shown once" flag already written into the same blob survives this later,
narrower patch untouched.

### Implemented: profile and presence

Six catalog-free actions from the `Server_guide.md` "Profile/settings/presence" domain:
`UpdateDeviceToken` (13), `ChangeLanguage` (150), `ChangePlayerCountry` (196), `UpdateSettings`
(165), `ChangePlayerName` (139), `GetPlayerInfo` (170). See `todo_list.md` for the full checklist
this fits into.

- `ChangePlayerName` reproduces `PlayerAnalytics.renameGoldPrice` exactly: free while
  `RenameCount == 0`, else `2^(RenameCount-1) * Constants.rowIds.SecondRenameGoldCost`. That row
  value (`SecondRenameGoldCost=25`) is now extracted and verified — see
  [Implemented: the Google2u economy catalog](#implemented-the-google2u-economy-catalog) — so a
  priced rename returns `ServerMaintenance` only when no catalog is configured at all, never a
  guessed price. The shift is capped at 30, not the client's 31, because the client's own `int`
  arithmetic overflows negative at 31; reproducing that would let a high rename count buy a name for
  negative gold, so the cap is a deliberate safety deviation from the source, not new gameplay logic.
- `GetPlayerInfo` surfaces a real, source-verified subtlety: `OnGetPlayerInfo` reads
  `mResponse["PlayerInfo"]` as a **direct index on the top-level response `Dictionary<string,
  object>`**, not through `ContainsKey` or a nested `JToken` (which never throws on a missing key).
  A genuine .NET dictionary throws `KeyNotFoundException` on a missing key even though the caller
  immediately compares the result to `null` — so an unknown player id must still emit
  `"PlayerInfo": null` as an explicit key, never an omitted one. This is the one boot/profile
  response key discovered so far where "guarded with `!= null`" does **not** mean "safe to omit"
  the way it does for every `PlayerData`/nested-`JToken` field. `DeviceToken` is withheld from this
  projection since it has no use to a third party and the client's reader never requires it.
- `ChangePlayerCountry` has no case at all in the client's response switch — nothing reads the
  body, so a bare `Result` is the entire contract.

### Implemented: dog-tag energy economy

`RefillDogtags` (70) and `PayOneDogTag` (129) are both direct (non-buffered) actions, dispatched
straight from `CreateServerRequest`, not `RequestBuffer`.

- **The client sends no price and no current count for either action** — only the
  `DogTagRefillTime`/`DogTagCap` constants it built its own local UI from, which the server reads
  for logging only and never trusts. Both actions are entirely server-computed from the player's
  own stored `DogTagSeconds`/`DogTagLastUpdate`, re-deriving `DogTagManager`'s own local
  regeneration formula: `serverSeconds = clamp(DogTagSeconds + (now - DogTagLastUpdate), 0, DogTagMax)`.
- **`RefillDogtags`'s price is a hardcoded client formula, not a catalog row**:
  `DogTagManager.dogtagRefillPrice => 35 - 2 * currentDogtags`. `DogtagDialog.RefillButtonClick`
  never lets a genuine client send this request while already full (it shows a confirmation dialog
  instead), and there is no dedicated result code in the recovered enum for that case — so an
  already-full refill is an idempotent no-op success (no charge), the same reasoning already used
  elsewhere in this document for "buy an already-owned item": inventing an unevidenced code would
  be a guess, and charging for a refill that adds nothing would be worse than refusing it.
  Insufficient gold is the one real evidenced failure, `NotEnoughGoldForDogtags` (7001).
- **`PayOneDogTag` is not a purchase, despite its name.** Every live call site
  (`GameControllerOnline.PayDogtag`, `GameControllerDeathMatch`) spends one already-held dog tag as
  an early-quit penalty — "pay **with** one dog tag", not "pay [gold] for one dog tag". `OnPayOneDogTag`
  reads no `Gold` field at all, only `LastUpdate`/`Seconds` (both unguarded top-level indices, always
  emitted). It always succeeds — there is no evidenced failure code — and floors the result at zero
  seconds rather than letting it go negative.
- **Found and fixed a real pre-existing bug while wiring these**: `LegacyStarterState.DogTagMax` was
  being assigned the bare `Google2u.Constants` `DogTagCap` value (5) directly. `DogTagManager.max`
  is actually `DogTagCap * DogTagRefillTime` — a tag *count* times a per-tag regen *period*, in
  seconds (4500 with the verified catalog, not 5) — and the client's own `LoadPlayerData` reads
  `DogTagMax` as that product (`Singleton<DogTagManager>.instance.UpdateDogtags(dtSeconds,
  dtLastUpdate, dtMax)` sets `max = dtMax` directly, then divides by `DogTagRefillTime` everywhere
  it derives a tag count). `FromCatalog` now requires both constants before computing the real
  product, rather than substituting the count for the seconds cap.
- Adding the six new requests these two actions' tests needed pushed `LegacySmoke.ps1` past the
  production "api" rate limit (120/minute per IP) — the script is a single fast sequential client on
  one IP, and only grows as more actions gain coverage. Rather than loosen that production default,
  the limiter's `PermitLimit`/window became configurable (`RateLimiting:Api/Auth:PermitLimit`/
  `WindowSeconds`, defaulting to the exact previous hardcoded 120/min and 10/min), and the smoke
  script sets its own generous override via `RateLimiting__Api__PermitLimit` instead.

### Implemented: tutorial handoff

`GameStartedTutorial` (119) issues a server-bound `BattleId`; `TutorialEnded` (120) validates it
matches, marks completion idempotently (a replay after completion succeeds again without
re-applying anything), and grants nothing from the client's reported `Experience`/`Gold`/
`GoldBoxes`/`WarBucksBoxes`/`ObtainedCards`/`UsedCards`/`ArmyPower` — there is no verified tutorial
reward table yet, and these actions never had server authority over rewards to begin with.

Both actions share `OnGameEnded`/`OnClassicGameEnded` with `GameEnded` (62) client-side. Two
source-verified traps closed here:

- `OnTutorialStarted` reads `mResponse["BattleId"]` as a **direct top-level dictionary index** —
  the same "must be present, ContainsKey/nested-JToken rules don't apply" hazard as `GetPlayerInfo`.
  Unlike `GetPlayerInfo`, this value is never legitimately null: the server always has a battle id.
- `OnClassicGameEnded` reads `int num6 = StringParser.ParseInt(mResponse["LevelExperience"]);` —
  **also an unguarded top-level index**, and it runs *before* the method's `TutorialData` check.
  Omitting `LevelExperience` would throw, aborting the method before
  `PlayerAnalytics.instance.tutorialFinished` is ever set — silently leaving a completed-server-side
  tutorial stuck incomplete on the client. Every field that would apply a *reward*
  (`GameReward`, `Level`, `VipReward1`, `MissionManagerData`, …) is `ContainsKey`-guarded and is
  correctly omitted instead.
- The top-level response's `TutorialData` key (presence-only, marks the tutorial finished) is
  distinct from the nested `PlayerData.TutorialData` that `LoadPlayerData`/`PlayerDataObject`
  checks — same name, two different keys in two different objects.

### Implemented: telemetry, presence no-ops, and shown-once flags

Nineteen more catalog-free actions: `UpdateArmyPower` (192, non-authoritative display hint),
`UpdateRegionPings` (140) and `PhotonIsFull` (143) (offline no-ops — `OnUpdateRegionPings` is a
literal empty method and `OnPhotonIsFull` only logs, so neither needs a real Photon Cloud to
answer correctly), `SendLog` (166), `SendCrashReport` (141, no live call site found but harmless
to answer), `ErrorMessage` (92), `UpdateAnalytics` (179), `Test` (167), `OnVIPExpired` (195),
`ReportCheater` (197), `SpecialOfferShowed` (1007), `WarArenaShown` (212), and seven "shown once"
flags — `ChatShownFirstTime` (163), `CustomizationShown` (168), `WarpathShownFirstTime` (169),
`CardpoolShown` (180), `LeagueLeaderboardShown` (182), `CraftingShown` (183),
`ElitesFeatureShown` (213).

- **`ErrorMessage` (92)** is `BeanstalkServerManager.OnWebRequestError`'s own failure telemetry —
  logged only, no case anywhere in `ServerResponseHandler`. Notable: the client's own sender
  short-circuits this action entirely when `mUrlCreator.isLocalhost` is true (`"Not sending error to
  database!!"`), so it is unreachable from a client whose `ServerEndpoint.BaseUrl` is literally
  `http://localhost:...` — real for any other host (a LAN IP, a domain) the constant is repointed to.

- **`OnSendLog` reads `mResponse["LogId"]` as an unguarded top-level index** — the same hazard as
  `GetPlayerInfo`'s `PlayerInfo` and `OnTutorialStarted`'s `BattleId`. A generated id is always
  returned; log content itself is not persisted (diagnostic only). `OnTest` (`Test`, 167) and
  `OnReportCheater` (`ReportCheater`, 197) carry the same hazard: `mResponse["Test"]` and
  `mResponse["PlayerID"]` (capitalized exactly like that, not `PlayerId`) are read as unguarded
  top-level indices too, purely to print in a log line — never asserted against — so `Test` answers
  a literal `true` and `ReportCheater` echoes the client's own asserted `ReportedPlayerId` back.
- The seven "shown once" flags are fields *inside* the unmodeled `PlayerAnalyticsData` blob
  (`chatShown`, `customizationShown`, `warpathShown`, `cardpoolShown`, `leagueLeaderboardsShown`,
  `craftingShown`, `elitesShown` — confirmed against `PlayerAnalytics.PlayerAnalyticsData`, ~30
  fields total). They are patched as raw JSON (`JsonNode`/`JsonObject`), not round-tripped through
  a partial C# model: a model covering only seven of thirty fields would silently discard every
  other field already stored in that blob on the next write. Model the type fully before anything
  needs those other fields back.
- `UpdateAnalytics`'s request field is `JsonConvert.SerializeObject(PlayerAnalytics.GetUpdates())`
  — an unverified delta shape, not the full blob. It is logged only, not merged into
  `PlayerAnalyticsData`, since guessing at `GetUpdates()`'s contract risks silently corrupting
  that blob for a client-side reader that itself reads nothing back.
- **`OnVIPExpired` only re-syncs `DogTagSeconds`/`DogTagLastUpdate`, and only if both keys are
  `ContainsKey`-present** — because losing VIP shrinks the player's dog-tag cap by its VIP bonus
  (`DogTagManager.mVipSeconds`). No account on this server has ever held VIP — `BuyVip` needs real
  receipt verification this server does not implement, per `Server_guide.md` §11.6 — so there is no
  bonus capacity to revoke; a bare `Result` (omitting both keys) is the correct "nothing changed"
  answer, not a shortcut around a harder case.
- **`SpecialOfferShowed` (1007) and `WarArenaShown` (212) were both originally grouped by ID
  proximity into payment-blocked/Battle-dependent buckets — re-checked, not implemented on trust.**
  `OfferManager.ShowedSavedOnServer()` (the `SpecialOfferShowed` success handler) and
  `WarArenaShownRequest.OnSuccess` (the `WarArenaShown` success handler) both read nothing at all
  from the server response — each only touches the client's own already-local state
  (`OfferManager`'s own cache; `WarArena.instance`'s config/open state). `SpecialOfferShowed`'s
  request carries a `showedOffers` id list — a pure "don't show this offer again" presentation fact,
  fully separable from `GenerateSpecialOffer`/`AcceptSpecialOffer`'s actual paid accept flow, which
  stays refused per §11.6. `WarArenaShown`'s request carries only an `ArenaId` string. Neither is
  modeled or replayed anywhere — logged only, matching `SendCrashReport`'s own precedent for a real,
  harmless answer with no downstream consumer yet.
- **Investigated and deliberately left out of this batch**: `IgnoreMessage` (12),
  `SendPlayerReport` (148), `ReadMessage` (184), `MessageWasShown` (194) all looked like generic
  trivial telemetry at first glance — each reads no response fields, same as the actions above — but
  their IDs are already covered by the owner's "skip Social" instruction
  (`Social/challenges/hit list`, see `todo_list.md`), so they stay unimplemented as a scope decision,
  not an oversight.

## Photon realtime and chat channels

Core Photon types occur in **98 gameplay source files**. The inventory finds **165 `[PunRPC]`/`[RPC]` method definitions**, **173 literal `.RPC()` calls**, **35 `OnPhotonSerializeView` occurrences** (definitions and calls), and **398 PhotonView attachments** in scenes/prefabs. Dynamic calls through `PhotonCachedRPC` require separate review; these counts are not all possible runtime messages.

| Boundary | Recovered responsibility | Replacement ownership |
|---|---|---|
| PhotonConnectionManager | Region pings, cloud connection, room creation/join, random matchmaking, reconnect callbacks | Backend matchmaking/allocator + battle-session state machine |
| RoomConnection subclasses / PlayerProperties | SQL lobby filters, two-player room selection, custom room/player properties | Validated server matchmaking criteria and authenticated participants |
| PhotonView / PhotonLevelIDChanger / PhotonLevelView | View IDs, observed components, scene object ownership | Stable server entity IDs and an audited scene-entity map |
| PhotonCachedRPC | Delayed/buffered local and online RPC delivery | Explicit event lifecycle, reliable delivery, bounded replay |
| PlayerNetworkStatus / GameControllerOnline | Match state, rematch, disconnection, peer-host/client branches | Authoritative match lifecycle and reconnect snapshot |
| PhotonTransform / OnPhotonSerializeView | Ordered position/rotation and component streams | Typed snapshots, sequence/tick numbers, interpolation |
| AIObject, weapons, vehicles, CardManager RPCs | Spawns, combat effects, damage/death, War Cards | Validated client commands; server-owned simulation/results |
| Chat.cs | Photon Chat connection, public/squad subscriptions, message history and online status | Separate authenticated protobuf-over-WSS chat service; never combat UDP |

`PhotonConnectionManager.Start()` configures send rate 26 and serialization rate 13, a 4,000 ms disconnect timeout, and MTU 1,500. The replacement starts with a 30 Hz host loop and a 1,200-byte authenticated datagram budget; snapshot frequency requires measurement, not a blind translation of Photon settings.

`CustomTypes.Register()` installs custom Photon type 90 for `UpgradeSlots.UnitUpgrades` (24 bytes) and type 88 for `PlayerInventory.EquippedWeapon` (10 bytes). Replace these with explicit protobuf messages bound to authoritative loadouts; never accept client-sent HP/damage multipliers as authority.

`PhotonConnectionManager.JoinOfflineGame()` still creates an offline Photon room. Therefore campaign/tutorial paths also require migration before removing Photon assemblies. Deleting PhotonView components now would break both serialized references and local/offline behavior.

`SocketHandler` additionally contains a BestHTTP Socket.IO connection to localhost:3000, with a `chatmessage` listener and player ID query. This is a separate experimental-looking code path, not proof that production chat used Socket.IO. The inspected `Chat.cs` explicitly constructs Photon Chat's `ChatClient`. Provider SDK traffic (analytics, purchases, social) is a third category and is not replaced merely by changing the game server URL.

## Required migration sequence

1. Prove the new SDK and protobuf HTTP/UDP admission path (implemented outside gameplay).
2. Define complete typed account/bootstrap DTOs from all 1.4.0 loaders and provide authoritative starter/catalog state. Replace the HTTP adapter/parser together, preserving callback order and buffered rollback semantics. **Partly done** — see [Implemented: the legacy boot chain](#implemented-the-legacy-boot-chain), [Implemented: buffered request replay](#implemented-buffered-request-replay), [Implemented: the Google2u economy catalog](#implemented-the-google2u-economy-catalog), [Implemented: weapon and unit upgrade deliveries](#implemented-weapon-and-unit-upgrade-deliveries), [Implemented: profile and presence](#implemented-profile-and-presence), [Implemented: tutorial handoff](#implemented-tutorial-handoff) and [Implemented: telemetry, presence no-ops, and shown-once flags](#implemented-telemetry-presence-no-ops-and-shown-once-flags), plus the full checklist in `todo_list.md`. 45 distinct actions are now served and covered by `scripts/LegacySmoke.ps1` (159 assertions): the boot chain (`check.php`, 157, 118, 30, 34, 5, 29 — 6 actions), claim-then-apply idempotent replay of 18 of the 27 buffered actions (104, 105, 191, 116, 1003, 76, 80, 73, 75, 74, 77, 79, 78, 128, 126, 127, 125, 158 — 11 of these priced from the real recovered catalog, including a full timed-delivery state machine for both weapon/unit upgrades and base purchases), the tutorial handoff (119, 120), and 18 catalog-free profile/telemetry actions (13, 139, 140, 141, 143, 150, 163, 165, 166, 168, 169, 170, 179, 180, 183, 192, 196, 1014). `ChangeNameAndPassword` (121) and `CreateFullAccount` (122) were investigated and found to have **no live caller in the active client**; achievements were investigated and found to be **100% local/Google-Play-provider presentation with zero Backend involvement** — both are closed findings, not gaps. Still outstanding: the remaining 131 of 175 named actions; most of the other 9 economy/cosmetic-catalog buffered actions among them now have a clear unblock path (the catalog exists and covers essentially the full weapon/unit roster — see below), just not yet wired one by one.
3. Add a backend-owned two-player allocation, participant-bound tickets, and a battle state machine. The current connectivity grant does not represent a match.
4. Map the 398 view attachments into stable entity bindings. Replace room/ownership/offline lifecycle calls before touching individual combat RPCs.
5. Implement cover movement, weapons/ammo/cooldowns, hit validation, damage, unit AI and War Cards server-side. Convert each RPC into either a client command or server event; do not create an unrestricted generic RPC relay.
6. Complete command/event delivery, snapshots/interpolation, loss/reordering tests, reconnect and bounded replay. Current UDP includes a partial signed match transport and [bounded shot/impact/death/terminal event cursor](BATTLE_EVENTS.md); normal Client presentation and durable restart recovery remain open.
7. Replace Photon Chat with authenticated WSS, Mongo-backed membership/history and rate limits. Add internal authenticated result submission and atomic/idempotent Mongo settlement.
8. Run two Unity clients through campaign/tutorial and PvP, then remove Photon/PUN/Chat sources and DLLs once no code or serialized dependency remains. Verify all 12 scenes and 781 prefabs again.

The existing Unity runtime has not been rewired in this checkpoint. The new server and portable SDK contain no Photon dependency; that does not mean the old Unity client is already Photon-free.
