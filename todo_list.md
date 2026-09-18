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
- [ ] Tutorial handoff: GameStartedTutorial (119) → server-bound `BattleId`, TutorialEnded (120) — trusted completion, no client-reported Gold/Warbucks grant
- [ ] ChangeNameAndPassword (121) / CreateFullAccount (122) — full-account upgrade path

### Profile/settings/presence — 13, 29, 139, 140, 150, 165, 170, 192, 196
- [x] SetPlayerStatus (29)
- [x] UpdateDeviceToken (13) — validated device token + optional locale, no response fields to project
- [x] ChangeLanguage (150) — validated locale
- [x] ChangePlayerCountry (196) — 2-letter code, no client-side reader at all for this action
- [x] UpdateSettings (165) — persists `SettingsManager.Settings` blob, rejects malformed JSON
- [x] ChangePlayerName (139) — free first rename; priced rename **(catalog: `Constants.rowIds.SecondRenameGoldCost`)** returns `ServerMaintenance` until that constant is imported, not a guessed price
- [x] GetPlayerInfo (170) — public profile projection of another player; `DeviceToken` withheld; explicit JSON `null` (not an omitted key) for an unknown id, matching the client's un-guarded top-level dictionary index
- [ ] UpdateRegionPings (140) / PhotonIsFull (143) — must not contact Photon (offline mode); safe no-op acknowledgement only
- [ ] UpdateArmyPower (192) recompute-from-loadout authority (currently stores the client-asserted value as a display hint only, per `LegacyBufferProcessor.RecordClientArmyPower`)

All six covered by `Server/scripts/LegacySmoke.ps1` (75 assertions total).

### Wallet and energy — 70, 129
- [ ] RefillDogtags (70) / PayOneDogTag (129) **(catalog: dog-tag gold price constant not yet located)** — do not fabricate a price

### Weapon store/upgrades — 73-76, 104, 116, 126, 128
- [x] WeaponWasShown (104) — buffered
- [x] EquipWeapon (116) — buffered, ownership-checked, rollback fields
- [ ] BuyWeapon (76), BuyWeaponUpgrade (73), InstantWeaponUpgrade (74), ActivateWeaponUpgrade (75), InstantBuyWeapon (126), ActivateWeapon (128) **(catalog: WeaponLevelsSetup prices/stages/durations)**

### Army and vehicles — 77-80, 105, 125, 127, 158, 1003
- [x] ArmyUnitWasShown (105) — buffered
- [x] UpdateEquippedUnits (1003) — buffered, ownership-checked, rollback fields
- [ ] BuyUnit (80), BuyUnitUpgrade (77), InstantUnitUpgrade (78), ActivateUnitUpgrade (79), InstantBuyUnit (125), ActivateUnit (127), PromoteUnit (158) **(catalog: LevelBehaviour/UpgradeSlots prices/stages)**

### Elite parts/scraps — 207, 208, 209
- [ ] UpgradeEliteSlot (209), ConvertScrapsToParts (207), ConvertPartsToScraps (208) **(catalog: exchange rates, eligible elite stage)**

### Cosmetics — 108-110, 168, 191
- [x] VisualWasShown (191) — buffered (clears `notificate`)
- [ ] DecalWasShown (108) — **no live call site in the active client**; classify as dead/unreachable, do not implement as a real feature
- [ ] EquipDecal (110) **(catalog: visual id → `categoryNumber` mapping, `PlayerVisual.Equip`)**
- [ ] BuyDecal (109) **(catalog: `PlayerVisual.priceGold`/`priceWarbucks`)**
- [ ] CustomizationShown (168)

### War Cards — 97, 174-178, 180, 183
- [ ] DepositCards (174) / WithdrawCard (175) — squad pool ledger (needs Squad membership first)
- [ ] BuyCardPack (97) **(catalog: pack contents/rarity odds)**
- [ ] CraftCard (176) / ClaimCraftedCard (177) **(catalog: `CardCraftingManager` costs/deadlines)**
- [ ] CardpoolShown (180), CraftingShown (183)

### VIP, packs and offers — 114, 130, 135, 136, 138, 142, 189, 190, 195, 1007, 1013
- [ ] All items **(catalog + real receipt verification)** — no simulated purchase success per §11.6

### Rewards and inbox claims — 91, 156, 161, 1001, 1002
- [ ] ClaimReward (91), AddVideoReward (156), AddOneTimeReward (161) **(catalog: reward tables)**
- [ ] CheckDailyReward (1001) / ClaimDailyReward (1002) — preserve `claimRweard` field typo and `DailyRewardServerData` shape **(catalog: reward-per-day table)**

### Missions and heroic/co-op progression — 67-69, 111; Daily/starter assignments — 112, 149, 171, 173, 185, 186
- [ ] All items **(catalog: MissionDefinition/AssignmentDefinitions content, map data)**

### Achievements/statistics
- [ ] Classify local/provider-presentation vs durable server reward before adding any claim route (§4 row: "do not invent an achievement claim action absent a caller")

### Ranked PvP/Player Leagues — 62, 64, 65, 106, 107, 152, 182, 198
### Instant Battle/offline PvP — 199
### War Arena — 200-206, 211, 212
- [ ] All items **(needs Battle Server result trust + catalog event config)** — `GameEnded` (62) client assertions must never authorize rewards

### Squad membership/admin — 37, 38, 41, 42, 44, 45, 49, 55-59, 63, 81, 101, 131-133, 151, 172, 181
### Squad Wars — 124
### Squad Events — 113, 160
- [ ] All items — deprioritized, not skipped; large cross-player-consistency surface, tackle as its own vertical

### Config/telemetry — 141, 143, 157, 163, 166, 179, 1007, 1014
- [x] GetConfigurations (157) — boot chain, empty sheet set
- [ ] SendCrashReport (141), SendLog (166), UpdateAnalytics (179), SaveFuseConfigs (1014) — bounded ingestion, no gameplay effect
- [ ] ChatShownFirstTime (163) — trivial flag, low priority

### Skipped per instruction
- [x] ~~Social/challenges/hit list (2,3,4,12,26,84-89,148,184,194)~~ — skipped
- [x] ~~Chat (Chat.cs, ChatBanManager, 193)~~ — skipped
- [x] ~~Social-provider compatibility (52-54,146,154,164,187,188,1005,1008,1009)~~ — skipped, already out of scope per repo policy

### Debug/admin-only actions
- [ ] Not implemented; never expose cheat mutations because the recovered client can send them (§4)

## Battle Server

Everything below is `[ ]` beyond the existing connectivity-probe skeleton (`/v1/network/connect`
ticket issuance; authenticated UDP hello/ping/pong/disconnect; 30 Hz tick loop; replay window).

### Lifecycle and admission
- [ ] Match lifecycle state machine: `Allocated → WaitingForParticipants → Loading → Ready → Running → Ending → Settled → Closed`, with deadlines and idempotency keys
- [ ] Backend-owned allocation replacing `RoomConnectionRandom` rank/league/medals/ArmyPower/streak filtering
- [ ] Disconnect-during-loading, reconnect-during-play, forfeit, simultaneous terminal events, rematch, worker-crash and duplicate-result handling

### Scene/entity identity
- [ ] Stable entity ID + generation, scene binding manifest replacing PhotonView/PhotonLevelView/PhotonLevelIDChanger

### Simulation — player
- [ ] Cover/movement (PlayerController, PhotonTransform → authoritative transform)
- [ ] Weapons: equipped slot, fire/reload/cooldown/ammo, burst/spread, server RNG, hit validation
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
- [ ] RPC → command/event/snapshot-field/local-event migration (165 RPC defs, 173 call sites to review)
- [ ] Bounded reliable command/event delivery: sequence ACKs, retries/timeouts, dedup (current ACK fields are not reliability by themselves)
- [ ] Snapshot protocol: baseline/full-state recovery, chunk bounds, entity generation, interest filtering, interpolation, reconnect cursor
- [ ] Reviewed encryption/key-rotation policy before public deployment (HMAC today is integrity/auth only, not encryption)
- [ ] Preserve offline/local campaign+tutorial path through the replacement adapter until Photon is fully retired

## Content extraction prerequisite (blocks most `(catalog)` items above)

Not a Backend/BattleServer code task by itself, but gates a large fraction of both lists — see
Server_guide.md §5: ranks/unlocks, weapons, units/vehicles, cards, visuals, missions/maps, competitions,
progress/rewards. Each needs schema **and** numeric content extracted from Google2u sheets/scenes/prefabs,
with source path/SHA-256/GUID/revision recorded before anything reads it as authority.
