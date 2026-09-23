# WarFriends Server — feature to-do list

Derived from [Server_guide.md](Server_guide.md) sections 4 (Backend) and 6 (Battle Server), cross-checked
against the active client at `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp`. IDs are
`DatabaseAction` values from that source, not the new `war.proto` message numbers.

**Scope note on "skip Social":** the guide itself separates `Social/challenges/hit list`, `Chat`, and
`Social-provider compatibility` as distinct domains from Squad membership/Squad Wars/Squad Events. This
list skips the three Social-named domains (and marks Chat/provider integration out of scope, matching
existing repo policy). Squad systems are listed but deprioritized, not skipped — flag if that's not what
you meant.

Legend: `[x]` implemented and covered by `Server/scripts/LegacySmoke.ps1`; `[~]` partially implemented;
`[ ]` not started; **(catalog)** blocked on Google2u sheet/content extraction (Server_guide.md §5), not
yet begun; **(needs Battle Server)** blocked on Battle Server result trust existing first.

## Backend

### Accounts and boot — 30, 34, 118, 119, 120, 121, 122
- [x] CreateAccount (118) — guest identity, session, starter wallet
- [x] LoginToCustomAccount (30) — `AccountType`/`Id`/`Password`, session rotation
- [x] GetPlayerData (34) — full boot projection incl. buffered-request resolution
- [x] GetAllMessages (5) — empty inbox
- [x] Tutorial handoff: GameStartedTutorial (119) issues a server-bound `BattleId`; TutorialEnded (120) validates it, marks completion idempotently, grants nothing from the client's reported `Experience`/`Gold`/`GoldBoxes`/etc. Found and closed a real gap: `OnClassicGameEnded` reads `LevelExperience` via an *unguarded* top-level index positioned before its `TutorialData` check — omitting it would have silently prevented the client from ever marking the tutorial finished.
- [x] ChangeNameAndPassword (121) / CreateFullAccount (122) — **verified dead: no live caller of either in the active client** (`BeanstalkServerManager.ChangeNameAndPassword` itself has no UI caller; `CreateFullAccount` has no caller at all). Neither has a response reader either, so implementing either would mean inventing an unevidenced contract. Not implemented, by design.

### Profile/settings/presence — 13, 29, 139, 140, 150, 165, 170, 192, 196
- [x] SetPlayerStatus (29)
- [x] UpdateDeviceToken (13) — validated device token + optional locale, no response fields to project
- [x] ChangeLanguage (150) — validated locale
- [x] ChangePlayerCountry (196) — 2-letter code, no client-side reader at all for this action
- [x] UpdateSettings (165) — persists `SettingsManager.Settings` blob, rejects malformed JSON
- [x] ChangePlayerName (139) — free first rename; priced rename **(catalog: `Constants.rowIds.SecondRenameGoldCost`)** returns `ServerMaintenance` until that constant is imported, not a guessed price
- [x] GetPlayerInfo (170) — public profile projection of another player; `DeviceToken` withheld; explicit JSON `null` (not an omitted key) for an unknown id, matching the client's un-guarded top-level dictionary index
- [x] UpdateRegionPings (140) / PhotonIsFull (143) — offline no-op acknowledgement; `OnUpdateRegionPings` is a literal empty method, `OnPhotonIsFull` only logs; Photon payload never stored or relayed
- [x] UpdateArmyPower (192) — accepted as a non-authoritative display hint only (same posture as `LegacyBufferProcessor.RecordClientArmyPower`); real recompute-from-loadout authority still needs the weapon/unit power catalog

All nine covered by `Server/scripts/LegacySmoke.ps1` (195 assertions total across the whole suite by this point in the session, along with everything below).

### Wallet and energy — 70, 129
- [x] RefillDogtags (70) — direct (non-buffered) action. The client sends no price at all, only the `DogTagRefillTime`/`DogTagCap` constants it built its own UI from (unused assertions); the real price is `DogTagManager.dogtagRefillPrice`, a **hardcoded client formula, not a catalog row**: `35 - 2*currentDogtags`, recomputed server-side from the player's own stored `DogTagSeconds`/`DogTagLastUpdate` regen state (never trusted from the client). `DogtagDialog` never lets a genuine client send this while already full and there is no evidenced result code for that case, so it's an idempotent no-op success (no charge) rather than an invented code. Found and fixed a real pre-existing bug while wiring this: `LegacyStarterState.DogTagMax` was being set to the bare `DogTagCap` constant (5) instead of `DogTagCap * DogTagRefillTime` (4500 seconds) — `DogTagManager.max` is explicitly a count-times-period product, not a raw tag count, and the client's `GetPlayerData` reader treats `DogTagMax` as seconds. 11 assertions.
- [x] PayOneDogTag (129) — direct action. **Not a purchase despite the name**: every live call site (`GameControllerOnline.PayDogtag`/`GameControllerDeathMatch`) spends one already-held dog tag as an early-quit penalty ("pay [with] one dog tag"). No price, no Gold field read by `OnPayOneDogTag`; always succeeds (no evidenced failure code), floors at zero seconds rather than going negative. Covered by the same 11-assertion block above.
- Also fixed while implementing these: the "api" rate-limit policy's `PermitLimit`/window are now configurable (`RateLimiting:Api/Auth:PermitLimit`/`WindowSeconds`, defaulting to the exact previous hardcoded 120/min and 10/min) so `LegacySmoke.ps1` — a single fast sequential client sharing one IP, which only grows as more actions gain coverage — can raise its own limit via `RateLimiting__Api__PermitLimit=2000` without touching the production default.

### Weapon store/upgrades — 73-76, 104, 116, 126, 128
- [x] WeaponWasShown (104) — buffered
- [x] EquipWeapon (116) — buffered, ownership-checked, rollback fields
- [x] BuyWeapon (76) — buffered, priced from `Google2u.WeaponUpgrades` by `NAME` (`PRICE`/`PRICEGOLD`, whichever is nonzero); `CANBEBOUGHT` is the level gate (not a bool, despite the name — `currentLevel.index >= CANBEBOUGHT - 1`); `PURCHASABLE` must equal `"shop"`; nonzero `DELIVERTIME` or client-asserted `discount` refused (no delivery-completion action or sale system implemented yet); re-buying an owned weapon is an idempotent no-op success. 10 assertions in `LegacySmoke.ps1` against real catalog rows (`AssaultRifle_AK47` free, `Grenade_FRAG` 999 Warbucks, `Bazooka_RPG7` 89 gold, `AssaultRifle_G36` level-gated, `LMG_Minigun` non-shop, unknown name, nonzero discount)
- [x] BuyWeaponUpgrade (73), ActivateWeaponUpgrade (75), InstantWeaponUpgrade (74) — a genuine per-weapon **timed delivery** state machine using `LevelManagerData.WeaponDelivery`. Price/delivery time come from the weapon's *own* per-level sheet (same type name as the weapon, e.g. `Google2u.AssaultRifle_AK47`, 26 rows) — a separate export from `WeaponUpgrades`, confirmed near-complete across the weapon roster (an earlier note claiming only AK47 was exported was wrong — corrected). Fields `NEXTUPGRADEPRICE`/`NEXTUPGRADEPRICEGOLD`/`DELIVERYTIME` (note: `DELIVERYTIME`, not the base sheet's `DELIVERTIME` — not a typo). `InstantWeaponUpgrade` reproduces `MiscTools.ConvertTimeIntoGold` exactly (`ceil(GoldCoefficient * minutes^GoldExpCoefficient * minutes)`, verified constants `GoldCoefficient=0.6325`/`GoldExpCoefficient=-0.175`), never the client's `ExpectedPrice`. 9 assertions verifying the full lifecycle (buy → AlreadyUpgrading on a second buy → TooSoonToActivate → instant-complete charges the server-computed 1 gold, not the client's asserted 999 → BoughtIndex advances, delivery clears)
- [x] BuyUnitUpgrade (77), ActivateUnitUpgrade (79), InstantUnitUpgrade (78) — same pattern via `Google2u.DBUpgradeSlots<Type>` sheets and `LevelManagerData.UnitDelivery` (confirmed `DBUpgradeSlotsAssaulter` has 136 rows, identical field names). The client's separate **special upgrade track** (`IsSpecial=1`, `SavedArmySlots.specialSlot`) has no traced pricing source and is refused with `ServerMaintenance` rather than reusing the normal track's numbers. 9 assertions, including the `IsSpecial=1` refusal
- [x] ActivateWeapon (128), InstantBuyWeapon (126), ActivateUnit (127), InstantBuyUnit (125) — confirm/instant-complete a pending base-purchase delivery. The real client always queues `ActivateWeapon`/`ActivateUnit` right after `BuyWeapon`/`BuyUnit` whenever the item's delivery time is 0 (true for every item in the current export, since `WeaponLevelsSetup.Buy()` only skips the delivery step for gold-priced items) — so these must be safe to call on an item `BuyWeapon`/`BuyUnit` already fully completed, and are treated as idempotent no-op successes in that case. 8 assertions covering both the idempotent-already-bought path and the genuine "nothing pending, nothing owned" mismatch (`WrongIndexToActivate`)
- [ ] Special upgrade track (`IsSpecial=1`) pricing source not traced — needed before `BuyWeaponUpgrade`/`BuyUnitUpgrade` fully cover both tracks

### Army and vehicles — 77-80, 105, 125, 127, 158, 1003
- [x] ArmyUnitWasShown (105) — buffered
- [x] UpdateEquippedUnits (1003) — buffered, ownership-checked, rollback fields
- [x] BuyUnit (80) — buffered, priced from `Google2u.ArmyUpgrades` by `NAME` (the unit's DBUpgradeSlots sheet type name). Unlike weapons, unit rows carry **no `PURCHASABLE` field at all** — verified against the sheet — so there is no "not sold in shop" gate, only the `CANBEBOUGHT` level gate. Same scope limits as BuyWeapon (instant delivery only, no discount validation). 8 assertions in `LegacySmoke.ps1` against real rows (`DBUpgradeSlotsShotgunner` free, `DBUpgradeSlotsAssaulter` 1500 Warbucks, `DBUpgradeSlotsSwat` level-gated, unknown name)
- [x] BuyUnitUpgrade (77), ActivateUnitUpgrade (79), InstantUnitUpgrade (78) — see the Weapon store/upgrades section above (same timed-delivery pattern, `DBUpgradeSlots<Type>` per-level sheets)
- [x] InstantBuyUnit (125), ActivateUnit (127) — see the Weapon store/upgrades section above (same pending-delivery-confirmation pattern)
- [x] PromoteUnit (158) — advances `SavedArmySlots.Tier`, gated by player `Level` against `Google2u.ArmyUpgrades`' `UNLOCKTIER2..UNLOCKTIER6` (tier 6 is max, sentinel 999). No cost. **Has zero response fields read anywhere in the recovered client** (confirmed: no `PromoteUnit` match at all in `ServerResponseHandler.cs`) — the `Result` code only needs to land on the right side of the `>10` split. 3 assertions

### Elite parts/scraps — 207, 208, 209
- [x] UpgradeEliteSlot (209), ConvertPartsToScraps (208), ConvertScrapsToParts (207) — all three buffered. Traced the elite track fully: a unit's per-level sheet (`Google2u.DBUpgradeSlots<Type>`) encodes THREE upgrade tracks in one table via its `TIER` column (`Tier/10` selects the track: 0=normal, 1=`UpgradeSlotSpecial`, 2=`UpgradeSlotElite`) — confirmed on `DBUpgradeSlotsAssaulter` (136 rows = 101 normal + 25 special + 6 elite + 3 unused `TIER=-1` padding) and cross-checked against `Google2u.ArmyUpgrades`' own `STARTINGSPECIAL=101` for that exact unit. Elite availability is gated separately by `STARTINGELITE > 0` on the `ArmyUpgrades` row (`DBUpgradeSlotsAssaulter` has elite ROWS in its sheet but `STARTINGELITE=-1`, i.e. not actually unlocked for that unit — `DBUpgradeSlotsShotgunner` (`STARTINGELITE=127`) is used as the real test case instead). The elite row **repurposes the normal track's two price columns**: `NEXTUPGRADEPRICEGOLD` is actually Elite **Parts** required, `NEXTUPGRADEPRICE` is the **Warbucks** price to skip the parts grind (`ArmyScreen.BuyUnitElite`/`UpgradeUnitElite`). `PartToScrapsSell=5`/`PartToScrapsUpgrade=24` (verified `Google2u.Constants`) drive the two conversion actions. None of the three actions' evidenced failure branches read any response field (each just shows an error dialog and forces a relog, which re-syncs via a fresh `GetPlayerData`) — bare `Result` is the whole failure contract, unlike most economy actions in this file. 8 assertions covering every refusal path (elite-locked unit, wrong `BoughtIndex`, wrong asserted parts, zero-parts/zero-scraps state) — a genuine success path isn't reachable in this test account without a Parts/Scraps source, since no mission/reward system grants either yet.
- **Found and fixed a real pre-existing bug while tracing this**: `BuyUnitUpgrade`'s "already maxed" ceiling used the per-unit sheet's *raw* row count (136 for `DBUpgradeSlotsAssaulter`) instead of the normal track's real row count (101, via the `TIER/10==0` filter above) — a sufficiently-leveled unit could have bought past its true normal-track max and silently priced from a special/elite row instead. Fixed via a new `TrackRows` helper; weapon sheets (which have no `TIER` column at all) are unaffected since the helper falls back to the full sheet. No regression: existing tests only exercise low `BoughtIndex` values well within the real 101-row bound.
- The **special** upgrade track (`IsSpecial=1`) is now understood — same per-unit sheet, `TIER/10==1`, offset `STARTINGSPECIAL` — but remains unimplemented: its buy-gate depends on `UpgradeSlots.actualMaxLevel`, which further restricts the track by the unit's *promoted* tier (`PromoteUnit`'s own `Tier` field) via a second `Tier%10 < actualTier` filter — a materially larger feature than what's implemented here, deliberately deferred rather than half-built.

### Cosmetics — 108-110, 168, 191
- [x] VisualWasShown (191) — buffered (clears `notificate`)
- [ ] DecalWasShown (108) — **no live call site in the active client**; classify as dead/unreachable, do not implement as a real feature
- [x] BuyDecal (109) — buffered, priced from `Google2u.PlayerVisuals` by `NAME`. Failure set is genuinely narrower than weapons/units — evidenced codes are only `NotEnoughWarbucks`/`NotEnoughLevel`/`NotEnoughGold`/`DecalOnlyForVip` (checked in that VIP-before-funds order) plus `NoDiscountFound`; an unknown/non-shop name falls back to `PriceNotFound` rather than reusing `DecalCategoryNotFound`/`DecalNotBought`, which belong to `EquipDecal`'s own evidenced set instead. On success the client assigns `ExpiresOn` directly (a real, separate rental/promo-window field, not an ownership flag) — a permanent purchase reports `0`. **Unlike weapons/units, the client's failure branch resyncs the entire `DecalManagerData` blob**, not one item's state. `PARTS`/`DUPLICATEWARBUCKS` (an alternate parts-based unlock and re-purchase price) are out of scope. 9 assertions against real rows (`CAMOS_DEFAULT` free, `CAMOS_MACHINEGUNNER` 800000 Warbucks, `CAMOS_PARA` VIP-gated)
- [x] EquipDecal (110) — buffered; `CamosScreen.EquipPlayerVisual` sends the decal's bare `NAME` as `data`, **not JSON** (unlike `BuyDecal`). The real slot key is `Google2u.PlayerVisuals`' `CATEGORYID` field (0-3) — **not `CATEGORY`, which is `PlayerVisual.rarity`**; an earlier note here conflated the two. Confirmed from the recovered `MainScene.unity` itself: `CamosManager.playerVisualCategories` serializes exactly 4 `PlayerVisualCategory` components in order (`idPrefix` CAMOS_/HELMETS_/HEAD_/BANDS_ = categoryNumber 0/1/2/3), and every exported `PlayerVisuals` row's `CATEGORYID` matches its name's prefix exactly. A zero-price `PURCHASABLE=="shop"` visual (e.g. `HELMETS_EMPTY`) equips without ever being explicitly bought, mirroring `PlayerVisual.isBought`'s free-shop-item clause — this pass does not seed any decal as pre-owned for a new account (same pre-existing gap as starting weapons/units). Evidenced failures: unresolvable name → `DecalCategoryNotFound` (108); resolvable but unowned → `DecalNotBought` (107); both reload the whole `DecalManagerData` blob. 7 assertions, including reading back `GetPlayerData`'s `DecalManagerData.slots` to confirm the correct `CATEGORYID` slot was written.
- [x] CustomizationShown (168) — trivial "shown once" flag, patched into `PlayerAnalyticsData.customizationShown`

### War Cards — 97, 174-178, 180, 183
- [x] DepositCards (174) / WithdrawCard (175) — the squad pool ledger, unblocked once Squad membership existed. **The "pool" is not a separate structure at all**: `DatabasePlayer.CreateFromDatabase` parses a `DepositedCards` map directly off each squad member's *own player record* — visible to squadmates simply because `GetAllSquadMembers`/`GetSquadDetails`/`GetFullSquadInfo` already project the full `Player` shape. New `LegacyPlayerDocument.DepositedCards` field, emitted by `PlayerObject` in the exact nested DynamoDB shape `DatabasePlayer` expects (`DepositedCards["M"][cardId]["M"]["Amount"]["N"]` — a different encoding from `CardManagerData.CardData`'s own flat `{"amount":N}`, confirmed from the exact client parse site, not assumed). `AddedCards`/`RemovedCards` are each a JSON-serialized `Dictionary<string,string>` whose *values* are themselves JSON-serialized `{"amount":N}` (double-encoded) — parsed tolerantly, skipping malformed entries rather than failing the whole request. Depositing verifies the player actually owns enough of the card first (never trusting the client's assertion); un-depositing verifies the pool actually holds that much. `WithdrawCard`'s cooldown is real and server-owned: `Google2u.Constants` `CardWithdrawTimer` (verified 240 seconds) — the client never computes this locally, it only stores whatever `NextWithdraw` the server last returned (an unguarded top-level read in `OnWithdrawCard`, so always emitted). Buddy-card deposits use a distinct wire shape (a numeric `"start-end"` range key instead of a card id) and are explicitly refused (the literal id `"BuddyCard"`) rather than mishandled. 8 assertions, including a full real round trip — deposit-then-undeposit — using whichever card the `BuyCardPack` tests above actually won (never a hardcoded id, since the outcome is genuinely random).
- [x] BuyCardPack (97) — buffered. **The RNG-reproduction concern that deferred this action earlier this session is resolved**: `CardManager.GetCardsFromCardpack`/`BuyThreeCards` perform genuine client-side card selection, so the client's asserted `cards` array is never read — the server independently reproduces the exact same algorithm (`GetRandomRarity`'s level-interpolated threshold roll via `LevelManager.InterpolateNumbersBasedOnLevel`, hardcoded `LowLevelTreshold=7`/`HighLevelTreshold=10`) using its own stored player `Level`, drawing from `Google2u.CardDefinitions` rows filtered to `IMPLEMENTED=true` and grouped by `RARITY` (26 Bronze/17 Silver/14 Gold in the verified export). `Google2u.CardPacks` has exactly four rows (`BRONZE_CARDPACK`=19 Gold, `SILVER_CARDPACK`=39 Gold, `GOLD_CARDPACK`=69 Gold, `THREE_CARDS`=1200 Warbucks) with no composition data, so pack contents are matched by name against a finite, evidenced 4-way mapping (verified real values, not a schema field). **Notable wire-contract gap left as-is, not fabricated around**: the client's `OnBuyCardPack` success handler reads zero response fields, so a genuine client's own local RNG guess stays on screen until the next full `GetPlayerData` reconciles it against the real, server-generated `CardManagerData` — matches how every other reward-granting action here treats client-reported outcomes as non-authoritative, just without an immediate wire-level correction path for this one. Evidenced failure set is narrower than weapons/units: only `NotEnoughWarbucks` (reused even for the three Gold-priced packs — there is no `NotEnoughGold` case in this action's response block) and `CardPackNotFound`/`NoDiscountFound`. New `CardManagerData`/`SavedCardData` model in `PlayerState.cs` (also modeling the unused `buddyCardData`/`nextWithdraw`/`nextBuddyDeposit`/`extraSlot` fields so a future write never silently drops them). 8 assertions verifying exact price debits and exact card counts (10 for a named pack, +3 for `THREE_CARDS`).
- [x] CraftCard (176) / ClaimCraftedCard (177) — **the "untraced costs/deadlines" concern that deferred this action is resolved**: `CardCraftingManager.CraftWarcard` only ever offers exactly 3 cards of the *same* rarity — Bronze crafts into a random Silver (`Google2u.Constants` `CardCraftTimeSilver`, verified 30 minutes), Silver crafts into a random Gold (`CardCraftTimeGold`, verified 60 minutes); Gold has no higher tier and is never offered (`canAnyWarcardBeCrafted` only checks Bronze/Silver counts). The constant names refer to the *output* tier, not the input — a real, deliberate naming choice in the recovered client, not a mismatch to normalize. `CraftCard` verifies all 3 named cards exist, share one rarity (1 or 2), and are actually owned in sufficient cumulative counts before consuming them and starting a new `CraftData` blob (`cards`/`start`/`end`, mirroring `CardCraftingManager.CraftData` exactly — the "one timed slot" concurrency limit reuses `AlreadyUpgrading`, the same code already used for weapon/unit upgrade deliveries). `ClaimCraftedCard` takes no request fields at all and reads state entirely server-side: verifies the craft is complete (`TooSoonToActivate` otherwise), then awards a *server-generated* random card from the correct output rarity pool — reusing `BuyCardPack`'s own `CardPoolsByRarity`/`PickCard` RNG machinery (promoted from `private` to `internal` for reuse, not duplicated). Neither action has a dedicated failure-branch case in `ServerResponseHandler`, so bare `Result` covers every refusal. New `CraftData` model in `PlayerState.cs` (registered subsystem key, already present in `LegacyPlayerStore.SerializedKeys`). 8 assertions, including a full real success path (crafting 3 genuinely owned Bronze cards this same run's `BuyCardPack` tests won) — the *claim* success path itself is not reachable within a smoke-test's runtime (a real 30-minute wait), so `TooSoonToActivate` immediately after starting is what's verified instead, which is the actually-correct behavior for that timing, not a skipped case.
- [x] CardpoolShown (180), CraftingShown (183) — trivial "shown once" flags, same pattern as CustomizationShown

### VIP, packs and offers — 114, 130, 135, 136, 138, 142, 189, 190, 1013
- [ ] All items **(catalog + real receipt verification)** — no simulated purchase success per §11.6
- [x] ~~`OnVIPExpired` (195)~~ — originally grouped under this heading by ID proximity, but it doesn't need VIP purchasing to exist at all: it just re-syncs the dog-tag energy state a VIP expiry would have changed, and does nothing when the two relevant response keys aren't asserted (which is always true here, since no account can ever actually hold VIP without the receipt-verified `BuyVip` this section blocks). Implemented under Config/telemetry below — moved out of this heading's id list.
- [x] ~~`SpecialOfferShowed` (1007)~~ — also originally grouped here by ID proximity to the offer-accept flow; re-checked and it's a bare "don't show again" presentation fact (`OfferManager.ShowedSavedOnServer()` reads nothing from the response), fully separable from the actual paid accept/purchase path. Implemented under Config/telemetry below.

### Rewards and inbox claims — 91, 156, 161, 1001, 1002
- [ ] ClaimReward (91), AddVideoReward (156) **(depends on the retired Fuse rewarded-video ad SDK's completion callback contract — untraceable, not just "not yet imported")**, AddOneTimeReward (161) **(investigated 2026-09-20: every real call site — Facebook Like, Twitter Follow, Rate-App, push-notification opt-in — is a social-provider/marketing trigger already in the owner's skip list; the two non-social call sites, `WeaponTutorial`/`UnitTutorial` tutorial-stage bonuses, share the exact same wire action. Left unimplemented rather than risk re-litigating the skip boundary on a shared, ambiguous mechanism — not a catalog gap, a scope-overlap concern)**
- [ ] CheckDailyReward (1001) / ClaimDailyReward (1002) — preserve `claimRweard` field typo and `DailyRewardSerwerData` shape (note: `DailyRewardSerwerData`, not `...ServerData` — the misspelling is in the recovered client itself). **Investigated (2026-09-19): the per-day reward calendar (`config.Day01..DayNN`, each `{Type,Double,Count,Param}`) has zero trace anywhere in the recovered client** — no default/fallback table, no matching Google2u sheet found among the 132 exported sheet types. This is pure server-authored content that was never shipped client-side, unlike every other economy table implemented so far. Implementing this would mean inventing reward amounts — correctly left unimplemented, not merely deprioritized.

### Missions and heroic/co-op progression — 67-69, 111; Daily/starter assignments — 112, 149, 171, 173, 185, 186
- [ ] All items — **correction (2026-09-20): the earlier "(catalog: MissionDefinition/AssignmentDefinitions content, map data)" reason was stale.** `Google2u.Missions` (75 rows, real map/bot/reward data) and `Google2u.StarterAssignments` (10 rows, real WB/Gold rewards) both actually exist in the recovered catalog export. The real blocker is Battle Server result trust, not missing content: `GameStartedCampaign`/`CoopMaster`/`CoopClient` (67-69) need real match orchestration (map/room/opponent), and `GetMissionLeaderboards`/`GetNewAssignments`/`SkipAssignment`/`ClaimAssignment`/`ClaimAssignmentMegaReward` (111/149/112/171/173) all depend on `Assignment.Update()` reading `StatsManager`'s trusted battle counters (kills, matches won). `CompleteStarterAssignments`/`ClaimStarterAssignment` (185/186) are separately confirmed blocked in the Squad membership/admin section above (the 10 starter tasks are claimed strictly in order and the first one needs a real PVP win).

### Achievements/statistics
- [x] Classified: **verified 100% local/Google-Play-provider presentation, zero Backend involvement**. `Achievement.CompleteAchievement()` calls only `GooglePlayGameService.instance.ReportAchievement(...)`; there is no achievement-related `DatabaseAction` in the recovered enum at all, and no achievement path ever reaches `BeanstalkServerManager`. Correctly requires **no** Backend route — closed, not deferred. `StatsManager`'s trusted counters (shots/hits/kills/…) are a separate concern gated on Battle Server result trust, tracked under Ranked PvP/Player Leagues below.

### Ranked PvP/Player Leagues — 62, 64, 65, 106, 107, 152, 182, 198
### Instant Battle/offline PvP — 199
### War Arena — 200-206, 211
- [ ] All items **(needs Battle Server result trust + catalog event config)** — `GameEnded` (62) client assertions must never authorize rewards
- [x] ~~`WarArenaShown` (212)~~ — originally grouped here by ID proximity; re-checked and `WarArenaShownRequest.OnSuccess` reads nothing from the response either, touching only the client's own local `WarArena` state. Implemented under Config/telemetry below, same posture as `SpecialOfferShowed`.

### Squad membership/admin — 37, 38, 41, 42, 44, 45, 49, 55-59, 63, 81, 101, 131-133, 151, 172, 178, 181, 193
- [x] CheckUniqueSquadName (41), CreateSquad (37), JoinSquad (38, direct/public join only), GetSquadDetails (45), GetAllSquadMembers (44), LeaveSquad (49) — a real, joinable Squad membership vertical, re-scoped from "deprioritized" once every other Backend-only, non-fabricated action was exhausted. New `LegacySquadStore`/`LegacySquadDocument` in `War.Persistence` (Mongo collection `legacySquads`, squad name doubles as the document's own `_id` — matching `CreateSquad`'s request, which sends the display name as `SquadId` with no separate generated identifier, so Mongo's native `_id` uniqueness is exactly what `CheckUniqueSquadName` answers). `CreateSquad`'s price is real and escalating, not flat: `(squadCreationsCount + 1) * WarBucksCreateSquadPrice` (verified 50,000 Warbucks) — new `LegacyPlayerDocument.SquadCreationsCount` field tracks it, matching `PlayerAnalytics.createSquadWarBucksPrice` exactly. None of these six actions have a dedicated failure-branch case in `ServerResponseHandler` at all, so a bare `Result` is the whole failure contract for every one of them — only the success paths need real fields. 8 assertions; the `CreateSquad`/`JoinSquad` success path is not economically reachable in this test account (50,000 Warbucks vs. a 15,000-Warbucks starting balance) so those specific assertions branch dynamically, same posture as `UpgradeEliteSlot`/`ConvertPartsToScraps` earlier — the reachable failure paths (`WrongPlayerData` on an overlong name, `NotEnoughWarBucksForCreateSquad`, `SquadNoLongerExists`, `NoSquadFound`, `SquadLeaveError`) are all verified for real.
- **Deliberately out of scope within this same vertical, documented not silently assumed**: no verified maximum squad size exists (`GetSquadRankSize` depends on an untraced catalog sheet), so member-count gating is not enforced anywhere; leadership does not auto-transfer if a Leader/Coleader leaves a non-empty squad (no evidenced succession rule); a squad left with zero members is not actively deleted (no evidenced cleanup rule, and nothing else in this vertical lists squads by membership in a way that would need it pruned); the one-time 50-Gold first-join reward (`GoldRewardFirstTimeSquad`, a real verified constant) needs a "claimed once" flag inside the still-unmodeled `PlayerAnalyticsData` blob and is deferred rather than risk re-granting it every join.
- [x] InvitePlayerToSquad (59), JoinSquadRequest (132), AcceptSquadJoinRequest (133), DeclineSquadJoinRequest (181), GetFullSquadInfo (151) — **the invite/request-to-join path originally believed blocked on the message/inbox system is not, in fact, blocked**: re-checked each handler's exact response reads and found `OnInvitePlayerToSquad`/`OnJoinSquadRequest` read nothing at all from the server, and `OnDeclineSquadJoinRequest` reads only its own already-sent request fields, never the response body — none of the four genuinely need a delivered message to function correctly. Implemented via two new `LegacySquadDocument` lists, `PendingInvites`/`PendingRequests`, tracking the same real state a message would have carried without needing message delivery; `JoinSquad` was extended so a private squad is joinable when the caller is in its `PendingInvites` (the recovered enum has no separate "accept invite" action — `JoinSquad`'s own optional `MessageId` is how a genuine client normally does this). `GetFullSquadInfo` combines `GetSquadDetails` + `GetAllSquadMembers` in one response, exactly matching `OnGetFullSquadInfo`'s own `OnGetSquadDetails(); OnGetAllSquadMembers();` pair. 5 assertions.
- [x] ~~RemoveUserFromSquad (42)~~ — **verified dead**: zero live call sites and no response reader anywhere in the recovered client (same class of finding as `ChangeNameAndPassword`/`CreateFullAccount`/`SystemMessage`). Not implemented, by design.
- [x] PromotePlayer (55), DemotePlayer (58), PromotePlayerToFounder (57), KickPlayer (172), UpdateSquad (131), UpdateSquadEmblem (63), GetSquads (56), FindSuggestedSquads (81) — rounding out the membership slice into rank management, settings and search, all gated on the caller holding `SquadRank.Leader`/`Coleader` in their own squad (`NotLeaderOfSquad` otherwise — again no dedicated failure-branch case in `ServerResponseHandler` for any of these eight, so bare `Result` covers every refusal). `PromotePlayer`/`DemotePlayer` step the target one `SquadRank` at a time, clamped at `Coleader`/`Member` (already-maxed is an idempotent success, no evidenced code for "can't go further"); the client's own asserted `OldSquadRank` is never trusted, matching this file's standing rule for mutations. `PromotePlayerToFounder` transfers sole leadership (target becomes Leader, caller drops to Veteran) — `OnPromotePlayerToFounder` unconditionally demotes the caller locally regardless of whether the guarded response field is present, so the server does the same authoritatively. `UpdateSquad`'s request field is `RequiredMedals`, not `SkillRequirement` like `CreateSquad` uses — confirmed real, not a typo to normalize. `GetSquads` filters public squads by name prefix (a real Mongo query); `FindSuggestedSquads` shares the same handler but sends a `Skill` value instead of a prefix — no skill-matching formula was traced from the recovered client, so it degrades to "any public squad" rather than a guessed heuristic. **Found and fixed a real bug while testing this batch**: `CreateSquad`'s insufficient-funds path was removing only the failed creator's *membership*, leaving the squad *document* itself behind as a real, empty, publicly-searchable orphan that `GetSquads`/`FindSuggestedSquads` would then legitimately return — fixed by deleting the whole document on that refusal instead. 9 assertions, all exercising the `NotLeaderOfSquad` guard (deterministic, no squad ever exists in this run) plus both searches' genuinely-empty-results success path.
- [x] NotifyPlayerToDeposit (178) — direct action, `CardpoolRecord.NotifyClick` nudging a squadmate to deposit. Shares its `ServerResponseHandler` success case with `UpdateArmyPower` (logged only, "Action Success", reads nothing back) — a real push notification (Fuse/FCM) is out of scope like every other retired third-party SDK, so the only real validation possible is that the target is genuinely a squadmate (`WrongPlayerData` otherwise, never trusted blindly, same check as `WithdrawCard`'s target). 2 assertions covering the deterministic "not in a squad" / "targeting yourself" refusals — the real success path shares the same economic unreachability as `CreateSquad` above.
- [x] SaveLastSeenSquadChatTimeStamp (193) — buffered. **Re-categorized out of the owner's "skip Chat" bucket** (see the Full-enum categorization sweep's correction note): it's a read-receipt timestamp for a squad-chat unread badge, not a chat message itself, matching the exact precedent already accepted for `ChatShownFirstTime` (163) — the recovered enum has no message-send/receive action at all, so there is no chat-transport feature being implemented here. `PlayerAnalytics.lastSeenSquadChatTimestamp`'s setter only ever advances, never regresses; reproduced by patching just this one field of the otherwise-unmodeled `PlayerAnalyticsData` blob (new `WorkingState.Analytics`/`AnalyticsChanged` in `LegacyBuffer.cs`, same targeted-field approach as `LegacyEndpoints.SetAnalyticsFlag` so every other key already stored in that blob survives untouched). 7 assertions, including one confirming an earlier shown-once flag in the same blob survives this later patch.
- `RemoveUserFromSquad`'s dead-action status and `CheckUniqueSquadName`'s local-only `UniqueSquadNameSuccess`/`UniqueSquadNameFailure` siblings (not real requests — `OnCheckUniqueSquadName` dispatches these purely as local client-side event markers, never sent over the wire) are noted above/here for completeness, not left as open items. **`UserAddedToSquadSuccess` (60) is the same class of non-request**: `OnJoinSquad`'s success handler calls `Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.UserAddedToSquadSuccess)`, a purely local event dispatch `SquadFindScreen` reacts to — never a `CreateServerRequest`/`SendServerRequest` call, so there is nothing here for the Backend to answer.
### Squad Wars — 124
### Squad Events — 113, 160
- [ ] All items — deprioritized, not skipped; large cross-player-consistency surface, tackle as its own vertical

### Config/telemetry — 92, 141, 143, 157, 163, 166, 167, 179, 182, 195, 197, 212, 213, 1007, 1014
- [x] GetConfigurations (157) — boot chain, empty sheet set
- [x] SendCrashReport (141) — logged only; no live call site found in the active client, kept for completeness
- [x] SendLog (166) — `LogId` is an unguarded top-level read in `OnSendLog`; generated per call, log content itself not persisted
- [x] UpdateAnalytics (179) — logged only; the request's `PlayerAnalytics` field is an unverified delta shape (`PlayerAnalytics.GetUpdates()`), so it is deliberately **not** merged into the `PlayerAnalyticsData` blob to avoid silent corruption from a guessed merge contract
- [x] ChatShownFirstTime (163) — trivial "shown once" flag, patched into `PlayerAnalyticsData.chatShown`
- [x] WarpathShownFirstTime (169) — one of the guide's "other shown flags"; same trivial pattern, patched into `PlayerAnalyticsData.warpathShown`
- [x] SaveFuseConfigs (1014) — logged only; dispatcher case is `LogResponse` with no field read
- [x] LeagueLeaderboardShown (182), ElitesFeatureShown (213) — two more trivial "shown once" flags, same `SetAnalyticsFlag` pattern, patched into `PlayerAnalyticsData.leagueLeaderboardsShown`/`elitesShown`
- [x] Test (167) — `OnTest` reads `mResponse["Test"]` as an unguarded top-level index (only ever printed, never asserted); answered with a literal `true`
- [x] OnVIPExpired (195) — `OnVipExpired` only re-syncs `DogTagSeconds`/`DogTagLastUpdate`, and only if both keys are `ContainsKey`-present, because losing VIP shrinks the dog-tag cap by its VIP bonus. No account in this server has ever held VIP (`BuyVip` needs real receipt verification, out of scope per §11.6), so there is no bonus to revoke — a bare `Result` (omitting both keys) is the correct "nothing changed" answer, not a shortcut.
- [x] ReportCheater (197) — `OnReportCheater` reads `mResponse["PlayerID"]` (capitalized exactly like this) as an unguarded top-level index; logged only and echoes the client's own asserted `ReportedPlayerId` back under that key. Report content is not otherwise persisted or actioned yet.
- [x] ErrorMessage (92) — `BeanstalkServerManager.OnWebRequestError`'s own failure telemetry, logged only, no case anywhere in `ServerResponseHandler`. **Notable finding**: the client's own sender skips this action entirely when `mUrlCreator.isLocalhost` is true — unreachable from a client pointed at `http://localhost:...`, real for any other host `ServerEndpoint.BaseUrl` is repointed to (LAN IP, domain).
- [x] SpecialOfferShowed (1007), WarArenaShown (212) — two more logged-only direct actions, re-examined out of the payment-blocked and Battle-dependent buckets respectively (see the corrections under "VIP, packs and offers" and "War Arena" above). Neither response reader (`OfferManager.ShowedSavedOnServer()`, `WarArenaShownRequest.OnSuccess`) reads anything back from the server, and both requests carry only presentation-tracking data (a shown-offer id list; an `ArenaId`), never purchase or battle-result content — same "harmless, logged only" precedent as `SendCrashReport`. 2 assertions.
- **Investigated and correctly left out of this batch**: `IgnoreMessage`(12), `SendPlayerReport`(148), `ReadMessage`(184), `MessageWasShown`(194) all looked like generic trivial telemetry at first glance, but their IDs are already covered by the owner's "skip Social" instruction (`Social/challenges/hit list`) — not implemented, per that standing scope decision, not an oversight. `SystemMessage`(90) is not a real client request at all — its only occurrence anywhere in the client is as a message-*type* case in `PushNotificationManager.cs`, never a `CreateServerRequest`/`SendServerRequest` call site.

24 catalog-free profile/telemetry/presence actions (13, 92, 119, 120, 140, 141, 143, 163, 167, 168,
169, 179, 180, 182, 183, 192, 195, 196, 197, 213) plus the tutorial handoff and dog-tag economy are
covered by `Server/scripts/LegacySmoke.ps1` (195 assertions total, alongside the buffered/economy
tests above).

### Full-enum categorization sweep (2026-09-19)

Every one of the 175 `DatabaseAction` values has now been individually checked against the
recovered client and assigned to exactly one bucket below — either implemented above, or excluded
for a specific, evidenced reason. None of the exclusions are "not started yet"; each was
investigated. IDs are grouped by why they're out, not by feature area:

- **Owner's explicit skip list** (already listed under "Skipped per instruction" above): Social/
  challenges/hit list (2, 3, 4, 12, 26, 84–89, 148, 184, 194), social-provider compatibility
  (52–54, 146, 154, 164, 187, 188, 1005, 1008, 1009). **Correction (2026-09-20): `Chat (193)` was
  originally grouped here by name, but re-checked against the exact same precedent already accepted
  for `ChatShownFirstTime` (163) — a "Chat"-named action implemented despite the label, since it's a
  bare UI-shown flag with no message send/receive involved.** `SaveLastSeenSquadChatTimeStamp` (193)
  is the same shape: a read-receipt timestamp for a squad-chat unread badge, not a message itself —
  the recovered enum has no `SendChatMessage`/`GetChatMessages` action at all, so there is no real
  chat-transport feature here to skip in the first place. Implemented below in the Squad section.
- **Needs Battle Server result trust** (explicitly out of scope for this pass per the owner's
  `/goal` — a separate effort is on Battle Server): `GameEnded` (62), `GameStartedMaster/Client/
  Campaign/CoopMaster/CoopClient` (64/65/67/68/69), `InstantBattle` (199), the Ranked PvP/Player
  League actions that read real league data (`FinishPlayerLeague`, `GetLastWeeksPlayerLeague`,
  `GetPlayerLeaguesDivision`, `RemoveFromLeague`, ids 106/107/152) — one id originally grouped
  under this same heading, `LeagueLeaderboardShown` (182), turned out on inspection to be a bare
  "shown once" UI flag with no league data involved at all, so it's implemented above despite the
  grouping; all War Arena actions (`EnterArena`,
  `GetArenaLeaderboards`, `GetScrapsReward`, `TakeArenaLife`, `WarArenaEnded`,
  `BuyArenaHearth`, 200–206/211), and all Missions/heroic/co-op and Daily/starter-assignment
  actions (`GetMissionLeaderboards`, `GetNewAssignments`, `SkipAssignment`, `ClaimAssignment`,
  `ClaimAssignmentMegaReward`, `CompleteStarterAssignments`, `ClaimStarterAssignment`) — assignment
  progress (kills, matches won, points scored) is only ever authoritative once Battle Server results
  are trusted. **Investigated and re-confirmed (2026-09-20): `CompleteStarterAssignments`/
  `ClaimStarterAssignment` stay genuinely blocked** even though their `Google2u.StarterAssignments`
  catalog data (10 rows, real WB/Gold rewards) turned out to exist — the 10 starter tasks
  (`StarterAssignmentsManager.mAssignments`) are claimed strictly in list order and the very first,
  `StarterAssignmentWinPVPBattle`, itself needs trusted battle results, so nothing later in the
  sequence is reachable regardless of catalog availability. **`WarArenaShown` (212) turned out to be
  a second id mis-grouped into this Battle-dependent heading by ID proximity — moved below.**
- **Real-money purchase / receipt verification required, no simulated success per §11.6**: `BuyVip`,
  `BuyInApp`, `BuyPack`, `BuyLootboxes`, `RefundPack`, `RestorePacks`, `AcceptSpecialOffer`,
  `AcceptRentalOffer`, `GenerateSpecialOffer` (ids 114/130/135/136/138/142/189/190) — see the
  VIP/packs section above for why `OnVIPExpired` (195), originally grouped with these by ID
  proximity, is implemented instead. **`SpecialOfferShowed` (1007) is a second id mis-grouped here —
  moved below**: `OfferManager.ShowedSavedOnServer()` reads nothing from the response, so it is
  purely a "don't show this offer again" presentation fact (a list of already-seen offer ids), fully
  separable from `GenerateSpecialOffer`/`AcceptSpecialOffer`'s actual accept/purchase flow, which
  stays refused.
- [x] SpecialOfferShowed (1007), WarArenaShown (212) — two more trivial, logged-only direct actions,
  re-examined out of the payment-blocked and Battle-dependent buckets respectively once actually
  traced: neither response reader (`OfferManager.ShowedSavedOnServer()`, `WarArenaShownRequest.OnSuccess`)
  reads anything back from the server, and both requests carry only presentation-tracking data
  (a shown-offer id list; an `ArenaId`) with no purchase or battle-result content attached. Neither
  is modeled or replayed — no implemented action reads either back — matching `SendCrashReport`'s own
  precedent for a real, harmless, logged-only answer. 2 assertions.
- **Untraceable server-only content** (zero trace anywhere in the recovered client — implementing
  would mean inventing numbers, not importing them): `CheckDailyReward`/`ClaimDailyReward` (the
  per-day reward calendar), `ClaimReward`/`AddVideoReward` (depend on the retired Fuse rewarded-video
  ad SDK's completion contract), `AddOneTimeReward` (same reward-table gap).
- **Formerly in this bucket, now resolved**: `BuyCardPack` and `CraftCard`/`ClaimCraftedCard` were
  both once listed here (RNG-reproduction and untraced cost/deadline concerns, respectively) — both
  turned out tractable once actually investigated and are now implemented in the War Cards section
  above. No large deferred feature remains in this bucket as of this pass.
- **Squad and squad-adjacent** (deprioritized per the guide's own taxonomy, not skipped — see the
  Squad sections below). **Update: membership, management, the invite/request flow, the card
  pool, the deposit-nudge and the chat-badge timestamp are no longer in this bucket** —
  `CheckUniqueSquadName`/`CreateSquad`/`JoinSquad`/
  `GetSquadDetails`/`GetAllSquadMembers`/`LeaveSquad`/`PromotePlayer`/`DemotePlayer`/
  `PromotePlayerToFounder`/`KickPlayer`/`UpdateSquad`/`UpdateSquadEmblem`/`GetSquads`/
  `FindSuggestedSquads`/`InvitePlayerToSquad`/`JoinSquadRequest`/`AcceptSquadJoinRequest`/
  `DeclineSquadJoinRequest`/`GetFullSquadInfo`/`DepositCards`/`WithdrawCard`/`NotifyPlayerToDeposit`/
  `SaveLastSeenSquadChatTimeStamp` are implemented once every Battle-Server/payment/RNG/
  untraceable-content action was exhausted; see the Squad membership/admin and War Cards sections
  above for the evidence and the deliberate limits (no size cap, no first-join Gold reward, no
  buddy-card deposits). `RemoveUserFromSquad` is verified dead (no live caller, no response reader).
  Still in this bucket: `MessageSent` (squad-invite notification — re-checked, its one real call
  site is `BeanstalkServerManager.Challenge`, a Photon-region PvP challenge, genuinely Battle-Server-
  dependent despite the misleading name), `InformSquadLeaderAboutEvent`/`JoinSquadEvent` (both
  genuinely require the Squad Events tier/assignment content traced under Squad Events below — the
  response shape `DatabaseSquadEventProgress` couples directly to `DatabaseSquadEventDefinition`
  tiers/assignment ids that don't exist server-side), `GetPlayersByExperience`/`GetSquadsByExperience`
  (leaderboard-style XP ranking — unlike `GetSquads`/`FindSuggestedSquads`, these are explicitly
  competitive rankings meaningless without real battle-derived stats: this account's `Experience`
  can never move without Battle Server result trust, so a real leaderboard query would just return a
  degenerate all-zero-all-tied sort, not a genuine feature).
  `UniqueSquadNameSuccess`/`UniqueSquadNameFailure`/`UserAddedToSquadSuccess`
  are not real requests at all — `OnCheckUniqueSquadName`/`OnJoinSquad` dispatch them as purely
  local client-side event markers, never sent over the wire.
- **Debug/cheat — re-checked (2026-09-20), and it's stronger than "never implemented by policy":
  every single one is verified dead, zero live call sites anywhere in the shipped client.** `MaxAll`,
  `AddDebugGoodies`, `DebugAddLevel`, `DebugAddSquadLevel`, `DebugChangeAnticheat`,
  `DebugChangeArenaLives`, `DebugChangeArenaWins`, `DebugChangeDivision`, `DebugChangeLeague`,
  `DebugChangeLevel`, `DebugChangeMedals`, `DebugRenewRental` have no `SendServerRequest`/
  `CreateServerRequest` call site at all — a stripped-for-release debug menu presumably drove these
  originally. `DebugAddScraps` is the one exception with a request *builder*
  (`DebugAddScrapsRequest.Send()`), but even that builder itself has zero callers anywhere in the
  client — so it's equally unreachable in practice. This isn't a policy choice not to implement
  cheats; it's the same class of finding as the verified-dead entries below (no real client could
  ever send any of these 13 requests), so it costs nothing to leave them out.
- **Verified dead/unreachable in the active client** (already closed, not deferred):
  `ChangeNameAndPassword` (121), `CreateFullAccount` (122) — no live caller of either; `DecalWasShown`
  (108) — no live call site at all; `SystemMessage` (90) — never a real outgoing request, only a
  message-type case constant; `RemoveUserFromSquad` (42) — no live caller and no response reader.
  **Additionally confirmed (2026-09-20), a batch grep across the entire recovered client for every
  still-unimplemented action name outside the enum declaration itself**: `GetAllPlayers` (4),
  `FacebookLoginOk` (54), `AddToHitList` (84), `GetPlayersFromHitList` (85),
  `HitListPlayerLoggedIn` (87) have **zero references anywhere in the client outside
  `DatabaseAction.cs`'s own enum body** — not merely "no live caller" (a builder method that exists
  but nothing invokes), but never mentioned again at all. These were already correctly excluded via
  the owner's skip list (Social/hit-list, social-provider) or as duplicates of already-dead ids, so
  this doesn't change any categorization — it just confirms none of the owner's skip-list ids were
  quietly hiding a real, reachable feature behind the "skip" label.
  `UserAddedToSquadSuccess` (60) — a local event dispatch, not a real request (see the Squad
  membership/admin section above); all 13 debug/cheat actions above.

The remaining un-mentioned IDs (`ErrorMessage` 92 and everything listed as `[x]` in the sections
above) are implemented. This sweep found no additional Backend-only, non-fabricated action left to
wire — everything past this point genuinely needs Battle Server, real payment verification, content
this pass cannot invent, or is out of scope by the owner's own instruction.

### Skipped per instruction
- [x] ~~Social/challenges/hit list (2,3,4,12,26,84-89,148,184,194)~~ — skipped
- [x] ~~Chat (Chat.cs, ChatBanManager, 193)~~ — skipped
- [x] ~~Social-provider compatibility (52-54,146,154,164,187,188,1005,1008,1009)~~ — skipped, already out of scope per repo policy

### Debug/admin-only actions
- [ ] Not implemented; never expose cheat mutations because the recovered client can send them (§4)

## Battle Server

**Note:** this section is a secondary-hand summary from `Server/docs/BATTLE_SERVER.md` — this
session's own work is on the Backend (per `/goal`); check that doc directly before extending
Battle Server code.

### Lifecycle and admission
- [x] Prototype match lifecycle: waiting → 2s countdown → running → ended/aborted, 1–32 isolated matches/2 participants on one UDP socket (`MatchEngine.cs`, `MatchRouter.cs`)
- [x] Strict manifest validation + player/host/match/content-bound signed admission, separate crypto domain from connectivity probes (`MatchManifest.cs`, `MatchTokens.cs`)
- [x] Reconnect with fresh signed capability + strictly increasing generation, preserving command receipts
- [ ] Backend-owned allocation replacing `RoomConnectionRandom` rank/league/medals/ArmyPower/streak filtering — "allocator integration is future work" (BATTLE_SERVER.md)
- [ ] Durable/authenticated result handoff to Backend (explicitly deferred, "do not implement wallets or Backend routes in this Battle-only work")

### Scene/entity identity
- [x] Recovered map geometry: 5 scenes, 40 cover nodes, 60 NavMesh paths, 1,004 collider records, 200 reference Physics rays validated within 0.002 units (`Server/content/recovered-battle-content.json`, `RecoveredBattleMap.cs`) — evidence, not yet a validated combat catalog
- [ ] Stable entity ID + generation, scene binding manifest replacing PhotonView/PhotonLevelView/PhotonLevelIDChanger for general (non-weapon-prototype) entities

### Simulation — player
- [x] Cover/movement prototype: server-timed movement over recovered paths, cover side/start/adjacency/occupancy enforced; movement speed still trusted manifest input
- [x] Weapons prototype: finite-ammo reloadable fire/reload/cadence/clip/reserve, target-position validated, stop-and-wait command replay (64/participant) — **unscored, no damage applied** (`RewardEligible` always false)
- [ ] Individual firing modes (burst/hold/click/swipe), server RNG, hit validation against health
- [ ] Projectiles/explosions: spawn/travel/collision, radius/falloff, friendly-fire policy

### Simulation — world
- [ ] Health/destruction: HP/shields/statuses, destructible parts, exactly-once kill credit
- [ ] Army deployment: catalog loadout, capacity/cooldowns, spawn eligibility
- [ ] Infantry AI: SoldierBehaviour state machines
- [ ] Vehicles: Tank/Helicopter/AssaultHelicopter/AICar family — movement, turret targeting, multi-part damage
- [ ] War Cards: reserved inventory, activation/targeting, effect params, consumption receipt
- [ ] Missions/co-op: waves/objectives/timer, heroic modifiers, success/failure evidence
- [ ] PvP/Arena: victory/end conditions, rematch, anti-stall/timeout, forfeit
- [ ] Statistics: authoritative kills/hits/shots/deployed/destroyed/cards, tied to `StatsManager.MatchStats`

### Photon replacement and transport
- [x] New protobuf tags 20-22 (MatchHello/MatchCommand/MatchReply) appended without renumbering existing fields; HMAC-framed, 1,200-byte datagrams
- [x] Stop-and-wait command retry semantics: same command ID + bytes replay the original reply; conflicting retries/out-of-order IDs rejected — explicitly "request/reply reliability for this slice, not general reliable event delivery"
- [x] Portable `War.Client.MatchConnection` + Unity `SelfHostedBattleClient`/SDK DLLs under `Assets/Plugins/WarFriends.Networking` — **not wired into normal battle preparation/player/weapon/game-controller flow yet**
- [ ] RPC → command/event/snapshot-field/local-event migration (165 RPC defs, 173 call sites to review) — only firing is migrated so far
- [ ] Full reliable command/event delivery beyond stop-and-wait; snapshot protocol (baseline/full-state recovery, interest filtering, interpolation)
- [ ] Reviewed encryption/key-rotation policy before public deployment (HMAC today is integrity/auth only, not encryption)
- [ ] Preserve offline/local campaign+tutorial path through the replacement adapter until Photon is fully retired — solo campaign still uses offline Photon APIs today

## Content extraction prerequisite (blocks most `(catalog)` items above)

Not a Backend/BattleServer code task by itself, but gates a large fraction of both lists — see
Server_guide.md §5: ranks/unlocks, weapons, units/vehicles, cards, visuals, missions/maps, competitions,
progress/rewards. Each needs schema **and** numeric content extracted from Google2u sheets/scenes/prefabs,
with source path/SHA-256/GUID/revision recorded before anything reads it as authority.

**RESOLVED (2026-09-19).** The initial finding above was wrong in one detail and is superseded:

- The Google2u row **schema classes do exist** as recovered source, just not under `Assets/Scripts` —
  they're at `Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/*Row.cs`
  (e.g. `WeaponUpgradesRow.cs`), one file per sheet type, ~132 of them.
- The row **data** (actual prices, unlock levels, balance constants) is already exported and
  sitting in `Server/content/recovered-battle-content.json`'s `sheets` array — the parallel Battle
  Server effort's `SelfHostedBattleExport.Run` pulled it in the same pass as the map geometry.
  `132` sheet instances, field names matching the recovered row classes exactly (all-caps:
  `PRICE`, `PRICEGOLD`, `DBKEY`, …).

**The catalog is now loaded and live in the Backend**: `War.Backend/Legacy/LegacyCatalog.cs` reads
`Legacy:ContentPath` (same file the Battle Server already uses via `Battle__ContentPath`) and
indexes all 132 sheets. First consumers, verified against the real data:
- `LegacyStarterState.FromCatalog` — `StartingGold=75`, `StartingWarbucks=15000`,
  `DogTagCap=5` (Google2u.Constants), replacing the previously-fabricated 500/50/10 placeholders.
- `ChangePlayerName` (139) — `SecondRenameGoldCost=25` from the same Constants sheet; the
  `2^(RenameCount-1) * 25` formula is now verified end-to-end by `LegacySmoke.ps1` through a third
  rename (25, then 50 gold).

**Sheet types available for the remaining economy actions** (see the 63 distinct `Google2u.*`
types in the content file for the full list): `WeaponUpgrades` (66 rows, keyed by `NAME`, fields
`PRICE`/`PRICEGOLD`/`UNLOCKLEVEL`/`CANBEBOUGHT`/`PURCHASABLE`/`WEAPONCATEGORY`/…), `ArmyUpgrades`,
17 `DBUpgradeSlots<UnitType>` sheets, `CardDefinitions`/`CardPacks`/`CardConstants`,
`PlayerVisuals`/`PlayerVisualsRarities`, `VIP`, `Packs`/`InApps`, `Missions`/`TaskDefinitions`/
`StarterAssignments`, `WarArenaParameters`, `SquadWarsReward`/`SquadLeaderboards`. Each needs its
own row-shape review before wiring — don't assume `PRICE`/`PRICEGOLD` generalizes without checking.
