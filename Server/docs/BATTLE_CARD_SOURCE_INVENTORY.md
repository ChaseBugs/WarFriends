# Recovered 1.4.0 battle-card source inventory

Source: `Clients/ExportedProject/Assets/Scenes/MainScene.unity`
`CardDefinitions.Rows`, cross-checked against
`Server/src/War.BattleServer/WarCardSourceIdentityCatalog.cs` and
the normal Client `CardManager.UseSelfHostedCard` dispatcher.
The scene contains 67 unique rows: 57 marked `IMPLEMENTED: 1` and
10 marked `IMPLEMENTED: 0`. A scene flag does not prove that the
self-hosted Worker or normal Unity battle path can activate the card.
Every source-enabled row has a scene Card component; its class is
resolved through the component's MonoScript GUID and `.cs.meta`.
A dash in the reviewed column means the server catalog has not
pinned that class/ID pair. Disabled rows may lack a scene component.
A direct Client route is only a dispatch path, not end-to-end proof.
The dispatcher currently has 29 card classes and
7 source-specific unit-card IDs. While connected to
the self-hosted match, unsupported cards are rejected before the
recovered Photon fallback; they need host commands before admission.

## Source-enabled rows

| Source ID | Rarity | Scene class | Reviewed | Direct host route |
|---|---:|---|---|---|
| `SLOWMOVE` | 3 | `CardBelovedEnemy` | yes | yes |
| `FREEZE` | 2 | `CardBrokenLegs` | yes | yes |
| `HEAVYDRONE` | 3 | `CardSpawnUnit` | yes | yes |
| `APOCALYPSE` | 3 | `CardMassShieldDestroyer` | yes | yes |
| `MINEENEMY` | 3 | `CardMineYourStep` | yes | yes |
| `BIGROCKET` | 3 | `CardSpawnUnit` | yes | yes |
| `ELITEMINIGUN` | 3 | `CardSpawnUnit` | yes | yes |
| `IMMORTAL` | 3 | `CardSwiftImmortality` | yes | yes |
| `ROCKETTURRET` | 3 | `CardRockyTurret` | no | no |
| `DISARMED` | 3 | `CardDisarmedAndLocked` | yes | yes |
| `ELITESWAT` | 3 | `CardSpawnUnit` | yes | yes |
| `BIGMEDKIT` | 3 | `CardHealMeNowBig` | yes | yes |
| `AIRSTRIKE` | 3 | `CardAirstrike` | yes | no |
| `SABOTAGE` | 2 | `CardSabotage` | yes | yes |
| `HEAVYTURRET` | 2 | `CardHeavyTurret` | yes | yes |
| `ELITESNIPER` | 3 | `CardSpawnUnit` | yes | yes |
| `CLUSTERGRENADE` | 3 | `CardGrenadesBurst` | yes | no |
| `HEADAHEAD` | 2 | `CardHeadAhead` | no | no |
| `KEVLARUP` | 2 | `CardKevlarUp` | yes | yes |
| `REFLECTION` | 2 | `CardShiedlsRefection` | yes | yes |
| `AMMOTHIEF` | 2 | `CardAmmoThief` | yes | yes |
| `EMPTYMAG` | 1 | `CardEmptyMag` | yes | yes |
| `GREATGRENADIER` | 2 | `CardSpawnUnit` | yes | yes |
| `MEATHEADS` | 2 | `CardSoldierOnSteroids` | no | no |
| `BOOBYTRAP` | 2 | `CardBoobyTrap` | no | no |
| `ELECTRICTRAPS` | 2 | `CardElectricTraps` | no | no |
| `SMALLMEDKIT` | 1 | `CardHealMeNowSmall` | yes | yes |
| `ELITEPARA` | 2 | `CardSpawnUnit` | yes | yes |
| `VEHICLEHEALTH` | 1 | `CardHealthForMachines` | yes | yes |
| `TURRETCRATE` | 1 | `CardIncreaseBonusChance` | no | no |
| `HEALTHCRATE` | 1 | `CardIncreaseBonusChance` | no | no |
| `KEVLARCRATE` | 1 | `CardIncreaseBonusChance` | no | no |
| `BULLETHARMLESS` | 1 | `CardBulletSponge` | yes | yes |
| `AMMOBOX` | 2 | `CardAmmoBox` | yes | yes |
| `BACKSTAB` | 1 | `CardBackstab` | yes | yes |
| `EXPLOSIVEPISTOL` | 2 | `CardExplosivePistol` | no | no |
| `MEDKIT` | 2 | `CardHealMeNow` | yes | yes |
| `DECOY` | 2 | `CardDecoy` | yes | yes |
| `MAXHEALTHINC` | 1 | `CardHealthierMyself` | yes | yes |
| `MINE` | 1 | `CardLandmine` | yes | yes |
| `TURRET` | 1 | `CardTurret` | no | no |
| `RANDOMKEVLAR` | 1 | `CardRandomKevlar` | yes | yes |
| `EXPLOSIVETIMING` | 1 | `CardRocketTiming` | no | no |
| `STREAKBOOST` | 1 | `CardScorestreakBooster` | no | no |
| `DESTROYSHIELD` | 1 | `CardShieldDestroyer` | yes | yes |
| `SHIELDSPAWNER` | 1 | `CardShieldsSpawner` | yes | yes |
| `SHIELDSHEALTH` | 2 | `CardShieldsUp` | yes | yes |
| `SLOWDOWN` | 1 | `CardSlowdown` | yes | no |
| `HEALINGSTORM` | 1 | `CardHealingStorm` | yes | yes |
| `TRIGGERHAPPY` | 1 | `CardSoldiersShootout` | no | no |
| `AMMOCRATE` | 1 | `CardIncreaseBonusChance` | no | no |
| `SICKNESS` | 1 | `CardSickness` | no | no |
| `CRITICALS` | 1 | `CardCriticalInsurance` | no | no |
| `SUPERSOLDIERS` | 1 | `CardHealthForSoldiers` | yes | yes |
| `CRATEBLOCKER` | 1 | `CardScoreStreakKiller` | no | no |
| `SHIELDGENERATOR` | 1 | `CardShieldGenerator` | yes | yes |
| `PLAGUE` | 1 | `CardPoisonedArmy` | no | no |

## Source-disabled rows

| Source ID | Rarity | Scene class | Reviewed |
|---|---:|---|---|
| `SHIELDRAFFLE` | 2 | — | no |
| `CHEMICALUNIT` | 3 | — | no |
| `ELITETANK` | 3 | — | no |
| `TOPBUILDERS` | 3 | — | no |
| `MADGANG` | 3 | — | no |
| `HELISTRIKE` | 2 | — | no |
| `MIRRORMYSELF` | 2 | — | no |
| `INVISIBILITY` | 2 | — | no |
| `PARALYZE` | 1 | `CardParalyzeThese` | no |
| `HEALTHYUNIT` | 1 | `CardHealthChangeUnit` | no |

`PARALYZE` has a `CardParalyzeThese` class and artwork, but
its MainScene row is source-disabled. Do not enable it as a
playable 1.4.0 War Card without new source evidence.
