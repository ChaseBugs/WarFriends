# First-account defaults: recovered Client audit

Audited 2026-10-22 against `Clients/ExportedProject` (1.4.0). This is a source audit, not a new Unity Play Mode verification. Paths below refer to `Assets/Scripts/Assembly-CSharp` unless stated otherwise.

## Initialization order

1. `BeanstalkServerManager.CreateAccount` sends Locale/UtcOffset and optional Fusebox starting-currency assertions. It does not send a starter weapon selection or a guest name.
2. `ServerResponseHandler.OnCreateAccount` parses `Player`, saves the credentials/profile with `GameLoginManager.SavePlayer`, then calls `LoadPlayerData`.
3. `LoadPlayerData` loads serialized subsystems through `DatabaseSerializedObject.LoadObjects`. `DatabaseSerializedObjectGeneric<T>.Load` invokes `LoadEmpty` when the subsystem is absent. Sending an empty JSON object is not equivalent: it deserializes an object and bypasses the subclass defaults.
4. Outside an already-running tutorial, it reads `Gold`, `WarBucks`, `Level`, `LevelExperience`, `Experience`, `ArmyPower`, dog tags and optional Tickets/Scraps from the server. `Wallet.Init` and `LevelManager.LoadData` apply those values; they do not invent initial balances or rank.
5. `OnCreateAccount` starts/continues the tutorial only when the response contains `BattleId` and a tutorial is not already running. Otherwise it takes the loadout path. `UseOnGetPlayerData`, when present, redirects the callback earlier.

## Defaults and ownership

| Field | Client evidence | Current Backend behavior |
| --- | --- | --- |
| Guest name | `DatabasePlayer.CreateFromDatabase` reads `Name.S`; `name` returns accountName. No fixed `Recruit` default was found in this path. | `LegacyAccountService.CreateAsync` explicitly assigns `Recruit`. This is reconstruction policy, not recovered production naming. |
| Gold / cash | `ServerResponseHandler.LoadPlayerData` reads `Gold.N` and `WarBucks.N`; cash is WarBucks. Recovered Constants contain StartingGold=75 and StartingWarbucks=15000. | `LegacyStarterState.FromCatalog` supplies 75 / 15000, subject to explicit operator overrides. Client currency assertions are ignored. |
| Rank | `LevelManager.GameLevel.displayNumber` is `index + 1`; `LoadData` stores the server index without conversion. | Default `Level=1` means displayed rank **2**, not rank 1. The current account defaults therefore do not represent a rank-1 initial tutorial account. |
| Dog tags | Capacity is tag count multiplied by regeneration seconds. | Catalog default 5 × 900 = 4500 seconds. Do not substitute the count 5 for the duration. |
| Equipped weapons | `PlayerInventory.Init` fills missing slots with the first lowest-unlock-rank weapon matching that slot's category mask. Existing slots are preserved. | `LegacyInitialLoadout` inserts the reviewed Client observation atomically with account creation. See exact slots below. |
| Weapon/unit progression | `LevelManager.Init`, `WeaponLevelsSetup.Init`, and upgrade-slot rules initialize source-backed free ownership and progression. | Reviewed `LevelManagerData` is included in the initial insert. Catalog entries are not all purchased weapons/units. |
| Appearance | `CamosManager` initializes category selections. | Reviewed `DecalManagerData` includes CAMOS_DEFAULT, HELMETS_EMPTY, HEAD_EMPTY and BANDS_EMPTY. |
| Notification settings | `SettingsManager.LoadEmpty`: challenge, squadStatus, squadEvents, playerLeague and dailyRewardNotification=true; maintenance remains false. Getters additionally honor the platform notification enable flag. | Absent Settings deliberately lets Client apply these defaults. Updates persist the complete validated six-Boolean snapshot. Absence alone is not a settings failure. |

The reviewed inventory observation (`client-starter-loadout-observation.json`) contains:

| Slot | Sheet identity | Client list index |
| --- | --- | --- |
| 0 | Google2u.AssaultRifle_AK47 | 1 |
| 1 | Google2u.SniperRifle_M24 | 3 |
| 2 | Google2u.Grenade_FRAG | 6 |
| 3 | Google2u.Pistol_Remmington51 | 13 |

These list indexes are not interchangeable with sheet inventory identifiers. Preserve both sheet names and the recovered list order.

`TutorialManagerBase.SetPlayerDefaultWeapons` is a separate temporary combat loadout. It selects category-index-zero weapons through BotManager, starts with the pistol, and selectively enables rifle/sniper/grenade ammunition across tutorial stages. It must not be used as the persistent account inventory initializer.

## Confirmed differences and remaining work

- **First tutorial is not wired into registration.** `LegacyAccountEndpoint.CreateAsync` does not issue a tutorial BattleId. Combined with Level=1, current registration enters the existing rank-2 lobby path. Restoring first-time onboarding requires a durable tutorial start/resume/completion lifecycle, not merely adding a fabricated BattleId or setting Level to zero. Validate the three stage callbacks and one-time rewards before changing that flow.
- **Catalog-free diagnostic defaults differ from actual content.** `LegacyStarterState` still defines Gold=500, WarBucks=50 and DogTagMax=10 when no catalog is loaded. Normal startup requires a catalog unless `Legacy:AllowCatalogFreeStartup` is explicitly enabled. Thus this discrepancy does not explain incorrect balances on a catalog-backed server; inspect the effective deployment options and the stored account first. Replace these diagnostic defaults with a clearly reviewed policy if catalog-free account creation is intended for players.
- **Name generation is server policy.** Decide an offline naming policy independently of recovered Client parsing. The Client does not provide evidence that every original new player was called Recruit.
- **Existing accounts are not reinitialized.** Changing starter policy only affects new inserts. An old account with incorrect equipment or balances needs a targeted, idempotent migration based on proven missing state; resetting all users would erase earned progression.
- **Do not overwrite defaults after login.** `GameLoginManager.TryPresetStartingCurrency` is a one-time Fusebox-era preview path. Authoritative balances still come from PlayerData. Do not reintroduce an online Fusebox dependency or grant request-supplied starting currency.

## Verification needed for an onboarding implementation

1. Test the original Mongo insert: name policy, intended zero-based rank, XP, source currency, dog-tag duration and complete starter equipment together.
2. Run a fresh isolated Client through tutorial creation, restart/resume, all stage completions and the first lobby. Assert the four equipped sheet identities and wallet values after each authoritative response.
3. Replay registration/session and tutorial completion requests without duplicate reward grants; verify a returning player's modified settings, purchased equipment and currency survive login.
4. Run account rules, protocol checks and native Mongo/legacy smoke tests. Existing starter observation is explicitly rankIndex=1 and is not proof of rank-0 tutorial behavior.

This audit does not change gameplay defaults, existing account data, or the running servers.
