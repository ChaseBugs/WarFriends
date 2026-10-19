# Recovered army perk rules for normal battle allocation

The normal allocation currently binds equipped unit identities and normal/special/elite indexes,
but omits the combat factors used by `InitializeArmyVitality`. The longer
[normal reload/reconnect run](NORMAL_UNITY_RELOAD.md) reaches completed reload and then fails
infantry restoration. Missing combat authority is a concrete source-level gap; the exact rejected
visual field in that run has not yet been reproduced with the newer diagnostic messages.

## Client calculation

`IGameController.CheckForPerks` starts with `new Perk`, whose health, accuracy, shot speed and
movement coefficients are binary32 one. It visits the friendly player's upgrades in
`LevelManager.behaviours` order for buffs, then the opposing player's upgrades in the same order
for debuffs. `LevelBehaviour.MultipleCurrentPerkForUnit` requires an equipped elite unit, matching
perk faction and a matching exact behavior Type from `PerkUnitCategories`.

The selector reads `LevelBehaviourManager.levelBehaviours`, including its helper entries. It
filters category, soldier/mechanical status and ground/air status, then stores Types. The extracted
target matrix therefore uses Type membership rather than assuming a target row's own flags alone
define its membership. The active manager has 28 entries and 24 matching player Types.

Seven implementations change coefficients: Assaulter health buff, Shotgunner health debuff,
Sniper accuracy buff, Grenadier accuracy debuff, Paratrooper shot-speed debuff, Engineer health
debuff and Assault Helicopter movement buff. Other player families return the existing Perk.
Each modifying implementation reads its attached sheet's ELITE column and uses `1f + value` or
`1f - value`, then multiplies that Perk by the accumulated one. Preserve binary32 intermediate
rounding and source iteration order when implementing the server projection.

These are implementations, not ownership grants. In particular, an extracted implementation or
ELITE column does not establish that a player can buy/activate an elite lane. Durable presentation
and the existing source-backed unit lane validator must authorize every stage before its effect
is used. The 876 values below are cells across complete ELITE columns, including non-elite rows;
they are not 876 available elite upgrades.

## Reproducible artifact

```powershell
python -B Server/tools/extract_army_perks.py
```

`content/recovered-army-perks.json` records 24 ordered families, seven modifying recipes, faction,
target identities, source counts and 876 binary32 column cells. It includes source path/SHA-256
provenance and the exact selector entries. Extraction rejects unknown implementations, missing
family/type bindings, unsupported selectors or changed inputs during extraction/publication.
The output is published by replacement after a complete source recheck and uses UTF-8/LF.

Current SHA-256: `b9597a7c47a00e1ff07a0dc2006f3c885f20b8733dc14636490cf9b15924ce35`.
Two fresh executions produce identical bytes in the current workspace.

The active MainScene hash is `5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.
The army/source-table snapshots retain their historical MainScene hash
`d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`. Commit `f9f63d037`
restored LevelManager bindings; the generator records both scene identities rather than silently
overwriting the old evidence. A direct comparison with that commit's parent confirms all 28
perk-selector behavior payloads are unchanged. Each current player family's identity, component,
type and category flags is also checked against the deployment artifact.

Serialized `indexInLevelsManager` fields are all zero. `LevelManager` assigns the actual indexes
from the restored `behaviours` list during initialization. The artifact retains the serialized
values as provenance and uses that runtime list order for calculation.

## Actual recovered-code verification

`WarFriends.Validation.UnityArmyPerkAudit.Run` opened the disposable MainScene in Unity 2018.3.0f2
and compared the artifact against the actual `PerkUnitCategories.GetUnits` and
`UpgradeSlots.PerkImplementation` methods. It checked source order, attached sheets, faction,
every player-target membership, all 876 column formulas and buff/debuff counts, plus no-op behavior.
It passed **2,425 checks** and exited zero at `.local/army-perk-source-audit.log`.
No scene/prefab/account data was saved or changed. This is not original Unity 5.2 or Android proof.

## Implementation still required

The artifact and recovered-code comparison do not yet change allocation or combat behavior.
Next implement a validated immutable server perk catalog, compute both players' coefficients
from their durable equipped elite lanes in source order, bind complete source-backed army combat
factors into initial and refreshed manifests, and verify real spawned vitality plus the normal
two-Unity reload/reconnect gate. Recompute from current authority on rematch rather than carrying
old factors or accepting arbitrary template modifiers. Keep the infantry renderer's rejection
rules intact while identifying the exact failed field. Terminal unit-card animation indexing
remains a separate pending defect.
