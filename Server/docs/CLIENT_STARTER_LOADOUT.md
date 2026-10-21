# Recovered starter loadout and weapon index bridge

The 1.4.0 Client has separate weapon index domains. Persisted
`PlayerInventory.InventoryData.slots[*].weaponIndex` and
`PlayerInventory.EquippedWeapon.weaponId` address `LevelManager.weaponLevelsSetups`.
`WeaponInventory.SetWeapons` then resolves each setup's `indexInWeaponInventory`
to its actual `allWeapons` object. The battle binding graph and
`BattleWeaponView.weapon_index` use that latter domain.

Previously the Backend copied a persisted index directly into the battle view,
and `PlayerProperties.CreateFromBattleView` copied it directly back into an
EquippedWeapon. This could reject a valid persisted loadout at manifest binding
or display a different weapon from the signed battle identity.

## Implemented conversion

The Backend now resolves the stored source ID plus LevelManager index through
`BattleClientWeaponIndices`. The Client resolves that same source ID plus battle
inventory index against its initialized scene before building EquippedWeapon.
Neither side guesses a weapon from the number alone or accepts a mismatched
source ID/index pair. Existing Photon/legacy index semantics are preserved.

| Equipped slot | Source identity | Persisted LevelManager index | Battle allWeapons index |
|---|---|---:|---:|
| 0 | Google2u.AssaultRifle_AK47 | 1 | 11 |
| 1 | Google2u.SniperRifle_M24 | 3 | 2 |
| 2 | Google2u.Grenade_FRAG | 6 | 5 |
| 3 | Google2u.Pistol_Remmington51 | 13 | 12 |

The [identity-only artifact](../content/recovered-player-weapon-indexes.json)
contains all 66 source identities in LevelManager order. The allWeapons indexes
span 0-66 with no mapped source at index 20; they are not a dense 0-65 domain.
The artifact binds the reviewed combat graph and the actual Client observation.
It is embedded in the Backend assembly and checked by digest, schema, complete
count, ordered unique LevelManager indexes and unique supported inventory
indexes during startup. It is independent of deployment working directories.

Identity-map SHA-256:
`adcd85fe32936e52d85a7d45bce982b7c58a94ec4b353b749ad00d07eaf3fa34`.
No prices, ownership flags or rewards are published by this identity artifact.

Manually seeded documents that stored a battle inventory number in the legacy
field need explicit source-based repair. The runtime does not accept both index
domains as aliases. The queue/rematch test fixtures now store the actual
persisted AK47 index 1 and still produce battle index 11.

## Observed initial state

[The observation](client-starter-loadout-observation.json) was captured after
original Splash/MainScene startup against a fresh real Backend and isolated
Mongo database. It has 66 weapon definitions, 24 player-unit definitions,
four slot masks and the exact InventoryData, LevelManagerData and
DecalManagerData blobs. No account ID, password, token or wallet is exported.
The configured server and Client rank indexes are both 1; the observed game
controller is outside tutorial mode. This is a configured bootstrap reference,
not proof of unknown original production account defaults.

The original reference matched two fresh accounts. A current fresh-account re-observation on
2026-10-22 matches every original gameplay/context/serialized value; only the WeaponInventory.cs
source hash differs. Reading metadata did not change state. The observation records MainScene
SHA-256 and thirteen runtime rule-file hashes, all checked against the active Client. Its current
SHA-256 is `47134e42bab46e5f45534f6749c98335db65acbf85a1f0b2d37de6b6cfe58718`.
Serialized object-key order also differs in the raw observation; sorted-key JSON comparison proves
all values and JSON types unchanged after the single reviewed source-hash replacement. The four
hash-bound observation/derived JSON files are explicitly pinned to LF in `.gitattributes`, preventing
Windows checkout conversion from invalidating the verified runtime digests.
MainScene remains
`5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.
The existing combat graph retains its pre-pointer-restoration provenance;
every one of its 66 source IDs and inventory indexes matches the observation.

Important rules for subsequent authoritative materialization:

- Missing inventory slots choose the compatible weapon with the lowest unlock
  index, retaining source order for ties. All four observed slots match this rule.
- Stored `bought=false` does not mean unavailable. Source zero-price/unlock-zero
  weapons and units derive ownership without changing that saved flag.
- Source-marked tutorial weapons/units have additional normal-versus-tutorial
  rules. FRAG and Assaulter are available in this observed non-tutorial context
  despite nonzero shop prices and false stored purchase flags. This does not
  authorize a currency grant or mark a purchase receipt.
- The selected initial units are Assaulter, Shotgunner, Grennader and
  MachineGunner, retaining their exact source names and starting tier 1.
- Saved special/Elite slot zero is not a battle upgrade entitlement. The source
  computes separate absolute indexes and isBought flags; absent lanes must not
  be emitted as purchased stage zero. Original negative inactive-lane sentinels
  remain in the observation for review.
- Initial cosmetic IDs are CAMOS_DEFAULT, HELMETS_EMPTY, HEAD_EMPTY and
  BANDS_EMPTY. Preserve these exact identities.

## Reproduction and verification

The managed `observe_starter_loadout.py` runner copies source/settings and cached package sources,
imports them once without copying the existing asset database or compiled assemblies, then invokes
the real Client boot smoke. It uses the original MainScene bytes, not the escaped export input.

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/tools/observe_starter_loadout.py --unity `
  'C:/Program Files/Unity/Hub/Editor/2018.3.0f2/Editor/Unity.exe' --mongo `
  'C:/Program Files/MongoDB/Server/8.3/bin/mongod.exe'
```

Run `starter-observation-1c01d52d59664b2893830602b7e33b16` verified 15,599 unchanged source/package
inputs and removed its temporary source project/Library. Child `client-boot-c620569ec7f64fe08204b4189ea51780`
completed actual Backend/Mongo/Unity account startup, 24 units, 66 weapons and 133 weapon index checks,
with zero runtime exceptions and the same 70 error-level diagnostics. Its Mongo/temp cleanup reclaimed
211,143,280 bytes. This is startup/loadout proof, not normal battle completion or Android verification.

After comparing the fresh observation, the observation, weapon-index map, initial-state artifact and
unit-rule artifact were refreshed together with their four owning Backend hash pins. Each derived
artifact changes only observationSha256; gameplay and source content remain exact. The broad battle
content precision correction remains a separate staged release. MainScene provenance audit preimage
hashes were refreshed only for the two affected published index/unit artifacts.

Current Release build has zero warnings/errors. Verification passes 54,236 initial-loadout/weapon/
unit checks, 268 index checks, protocol checks, native smoke (74 live checks plus transactional/control
scenarios) and legacy smoke (563 HTTP assertions plus contract/publication scenarios). Native runs
`smoke-df4242c02651441a85097758b54aa97c` and `legacy-8625d0404b3e4ac18e60bc5b24f722f5` passed and
reclaimed their owned database/temp data. Original unrelated Mongo PID 6164 was preserved.

Refresh a disposable Client under Server/.local with the current runtime, then
run `ClientBootSmoke.ps1` with its usual Unity/Mongo arguments and
`-ExportStarterLoadout`. The script copies the Editor exporter, restores the
caller's environment and stops only its own processes. The Editor writes a unique scratch export
inside the disposable project; the runner retains validated JSON in its managed run, which may use
an external `WAR_TEST_RUN_ROOT`. Successful owned Mongo/temp data is removed; failed diagnostics are
retained. `-KeepArtifacts` explicitly retains successful temporary data. It fails if metadata reads alter state or any
of the 133 actual Client index checks fails.

After reviewing the resulting starter-loadout.json, copy it to the observation
path and run:

```powershell
python Server/tools/build_player_weapon_index_map.py --write
```

The generator verifies active source hashes and every combat binding. Review
and update the embedded catalog's observation/map digest constants when the
reference changes. Without --write, the command verifies the committed bytes.

The final solution builds with zero warnings/errors. Verification passed:

- Actual Unity 2018.3 account bootstrap, complete data-loaded callbacks,
  24 units, 66 weapons, zero runtime exceptions and 133 index checks.
- 268 native bidirectional identity, invalid-pair and Backend-projection checks
  (`--client-weapon-index-only`), plus 1,360 protocol checks.
- Real Mongo rematch manifest refresh (`--rematch-manifest-only`) and actual
  Backend/Worker HTTP/UDP queue, cancellation, restart, recovery and rematch
  (`--queue-live`). Mongo artifacts are under
  Server/.local/weapon-index-live-7c0a2c096465493f9d03c284089d51f3.
- Static asset audit: no missing scripts/broken references. The same 17 NGUI
  atlas mismatches remain; the boot still records 70 error-level diagnostics.

The final Client reference run is
Server/.local/client-boot-790c4cab61324591949cc147696d71a2.
This does not prove original Unity 5.2, Android, rendered UI or normal battle
controller entry. The observation is not imported as starter economy or
ownership authority. Later sections describe the implemented derived ownership
and unit lane projection; automatic battle allocation remains open.

## Atomic initial account state

New guest accounts now receive source-derived InventoryData, LevelManagerData
and DecalManagerData in the account's original MongoDB insert. Existing accounts
are not reset or backfilled. Other missing subsystem keys retain their existing
Client default path.

`python Server/tools/build_initial_client_state.py` verifies the generated
`Server/content/recovered-initial-client-state.json`; `--write` regenerates it.
The generator reconstructs defaults from reviewed source metadata and requires
equality with the actual Client observation. Backend startup pins the artifact
digest and validates complete subsystem shapes before accepting accounts.
Every purchase/borrowing flag stays false, progression and parts stay zero,
deliveries stay inactive, and wallet authority is unchanged. These blobs do not
replace the Client's derived free/tutorial ownership rules.

The actual Unity/Mongo run under
Server/.local/client-boot-ab946193541c46a79f06a2f4f1d2a3e0 completed account
callbacks with 24 units, 66 weapons, zero exceptions and the same 70 error-level
diagnostics. Its change-stream observer verified all three complete blobs in
the original insert, rather than a later repair. The Client's resulting
serialized defaults equal the committed observation. Five focused native
checks also verify source equality and independent account containers.
The real Mongo-backed legacy HTTP smoke passes all 248 assertions, including
new-account blobs, login, buffered mutation replay and rollback contracts.
This remains Unity 2018 disposable-project evidence, not original Unity 5.2,
Android, rendered UI or complete normal battle-entry proof.

## Weapon availability in normal battle presentation

`BattleWeaponOwnership` now evaluates all 66 reviewed weapon identities from
the hash-pinned observation's source metadata. It reads no Client-reported
prices or computed ownership flags. The normal battle presentation supplies
durable rank and a server-selected non-tutorial context. Tutorial mode remains
an explicit separate evaluator input; account tutorial completion is not used
as a substitute for the current gameplay mode.

The recovered `WeaponLevelsSetup.bought` branch grants source-marked tutorial
weapons outside tutorial. Inside tutorial those weapons require saved Bought;
Borrowed does not bypass that branch. Other weapons allow source shop/free
access, saved Bought with the source minimum purchase rank, or saved Borrowed.
Checking availability never writes purchase or borrowing flags. Unknown source
identities and ranks outside the supported zero-based range fail closed.

Native checks cover all 66 actual Client initial observations, all 43 ranks,
both gameplay modes and all purchase/borrowing flag combinations, including
flag immutability. Presentation checks isolate the four initial weapons by
unequipping units in the test fixture, reject an unowned paid rifle and accept
its durable borrowed state. This isolation does not prove a complete starter
presentation by itself. The unit implementation below now checks the complete
starter presentation; automatic allocations remain absent.

Verification: Release solution build succeeds with zero warnings/errors;
`--initial-loadout-only` passes 45,485 checks including the earlier initial
state checks, and `--client-weapon-index-only` passes 268 identity checks.
The source-hash/index generator also verifies the active Client metadata.

## Unit ownership and upgrade lane projection

`BattleUnitProjection` now follows UpgradeSlots.bought and canUseInBattle for
all 24 source player units. Free/tutorial ownership does not write Bought.
Borrowed units remain selectable even if their Equipped flag is false.
Normal battle entry supplies a server-selected non-tutorial mode; tutorial
mode remains separate and does not follow account completion flags.

`build_battle_unit_rules.py` verifies the active rule/scene hashes, pins the
reviewed sheet artifact, checks contiguous upgrade lanes against the observed
offsets, and produces `content/recovered-battle-unit-rules.json`. Backend embeds
and hashes that immutable rule set. Disabled Elite definitions can retain sheet
rows, such as Assaulter; rows alone never enable the Elite lane.

Normal stages stay relative because their source offset is zero. A special lane
is active only after promotion above the starting tier; its wire index adds
STARTINGSPECIAL to the saved relative stage. Elite needs STARTINGELITE > 0 and
saved eliteSlot > 0; its wire index adds that offset. Inactive lanes emit -1,
matching PlayerProperties' wire isSpecial/isElite checks. Legacy saved tier zero
uses the source start tier. Negative or out-of-range stages, unavailable Elite
progress and special progress on an unpromoted unit fail instead of being clamped
into combat authority. No purchase, tier promotion or upgrade is written.

Native checks compare all 24 initial ownership observations, exercise every
supported rank/mode/purchase/borrowing combination, and verify normal lane
endpoints, promoted special offsets and enabled/disabled Elite bounds. The full
source starter account projects four weapons and four units with normal stage
zero and both optional lanes inactive, without modifying saved state.
Automatic allocation, other account selection limits, rendered Client parity
and complete normal battle admission remain separate open requirements.

Actual Unity/Mongo validation also passes at
Server/.local/client-boot-f3ef05e1c6054248baf50ace9c0dc319. The change-stream
observer projects all four weapons and four units directly from the original
account insert and verifies no special/Elite upgrade grants. Account callbacks
complete with 24 units, 66 weapons, zero exceptions and the same 70 error-level
diagnostics. Final serialized Client defaults equal the committed observation.
This does not verify upgraded-unit rendering, original Unity 5.2, Android or
normal matchmaking; no allocation was supplied by this test.

The final Release solution build has zero warnings/errors.
`--initial-loadout-only` passes 54,236 combined initial-state, weapon and unit
checks; `--client-weapon-index-only` passes 268 identity checks. The unit rule
generator verifies the committed artifact against source hashes and lane bounds.

The [army admission checkpoint](STARTER_ARMY_ADMISSION.md) now carries that
equipped-only ordering into mixed manifests and verifies the source starter
selection echo through the native host. It also fixes grenade package loading
and mixed binding classification. Mixed grenade switching/runtime and automatic
card/account allocation remain incomplete; admission is not full gameplay proof.

The later [queue admission integration](CLIENT_LOBBY_BOOTSTRAP.md) now creates and refreshes
inactive allocations from current durable account state. Native HTTP/UDP queue/rematch/restart
checks pass, including refusing refresh while queued and updating ownership after cancellation.
Those live fixtures use a reviewed rifle profile; they do not prove the complete recovered
starter profile entering and rendering a normal Unity battle.
