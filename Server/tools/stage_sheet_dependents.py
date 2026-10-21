"""Build reviewed direct dependents from explicit candidate bytes, without production writes."""
import copy
import json

import build_legacy_catalog_profile as profile
import extract_pvp_score_streak_policy as score
import extract_pvp_bonus_catalog as bonus
import build_battle_unit_rules as unit_rules
import extract_army_deployment as deployment
import extract_army_perks as perks
import extract_coop_card_rows as coop_cards
import extract_coop_skillshot_scores as coop_scores
import extract_pvp_skillshot_scores as pvp_scores
import build_ordinary_card_identities as card_identities
import extract_coop_enemy_point_masks as point_masks
import extract_air_unit_geometry as air_geometry
import extract_rusher_weapon_bindings as rusher_weapons
import extract_coop_assaulter_weapon as assaulter_weapon
import extract_landmine_source as landmine
import extract_heavy_turret_source as heavy_turret
import extract_mortar_weapon_pool as mortar_pool
from audit_battle_sheet_values import binary32

ROOT = profile.ROOT
SOLDIER_SOURCE_TRANSITION = (
    "26568579f6b4e7994b5a2266009de3e5ccb42e41169546056f71ffe5acb7ae39",
    "d3da6f858f06c325ace44acb654163df0a47ed6c278b36b3b559c2801d03dccd",
)
PRODUCERS = {
    "recovered-mortar-weapon-pool.json": "extract_mortar_weapon_pool.py",
    "recovered-landmine-source.json": "extract_landmine_source.py",
    "recovered-heavy-turret-source.json": "extract_heavy_turret_source.py",
    "recovered-coop-assaulter-weapon.json": "extract_coop_assaulter_weapon.py",
    "recovered-rusher-weapon-bindings.json": "extract_rusher_weapon_bindings.py",
    "recovered-air-unit-geometry.json": "extract_air_unit_geometry.py",
    "recovered-coop-enemy-point-masks.json": "extract_coop_enemy_point_masks.py",
    "recovered-ordinary-card-identities.json": "build_ordinary_card_identities.py",
    "recovered-coop-skillshot-scores.json": "extract_coop_skillshot_scores.py",
    "recovered-pvp-skillshot-scores.json": "extract_pvp_skillshot_scores.py",
    "recovered-coop-card-rows.json": "extract_coop_card_rows.py",
    "recovered-army-perks.json": "extract_army_perks.py",
    "recovered-army-deployment.json": "extract_army_deployment.py",
    "recovered-battle-unit-rules.json": "build_battle_unit_rules.py",
    "legacy-catalog-profile.json": "build_legacy_catalog_profile.py",
    "recovered-pvp-score-streak-policy.json": "extract_pvp_score_streak_policy.py",
    "recovered-pvp-bonus-catalog.json": "extract_pvp_bonus_catalog.py",
}
HASH_FIELDS = {
    "recovered-mortar-weapon-pool.json": set(),
    "recovered-landmine-source.json": set(),
    "recovered-heavy-turret-source.json": set(),
    "recovered-coop-assaulter-weapon.json": {"sceneSha256"},
    "recovered-rusher-weapon-bindings.json": {"sceneSha256"},
    "recovered-air-unit-geometry.json": set(),
    "recovered-coop-enemy-point-masks.json": {"sceneSha256"},
    "recovered-ordinary-card-identities.json": {"sourceSha256"},
    "recovered-coop-skillshot-scores.json": {"sceneSha256", "battleContentSha256"},
    "recovered-pvp-skillshot-scores.json": {"sceneSha256", "battleContentSha256"},
    "recovered-coop-card-rows.json": {"sceneSha256", "armySha256", "contentSha256"},
    "recovered-army-perks.json": {"deploymentSceneSha256"},
    "recovered-army-deployment.json": {"sceneSha256"},
    "recovered-battle-unit-rules.json": {"sheetArtifactSha256", "observationSha256"},
    "legacy-catalog-profile.json": {"artifactSha256", "claimedMainSceneSha256"},
    "recovered-pvp-bonus-catalog.json": {"sceneSha256", "battleContentSha256"},
    "recovered-pvp-score-streak-policy.json": {"sceneSha256", "battleContentSha256", "scoreManagerSha256",
                                              "gameControllerOnlineSha256"},
}


def encode(value):
    return json.dumps(value, ensure_ascii=False, allow_nan=False, indent=2) + "\n"


def validate_changes(name, previous, candidate, name_proof):
    before = copy.deepcopy(previous)
    after = copy.deepcopy(candidate)
    if before.keys() != after.keys():
        raise ValueError("Dependent schema changed: " + name)
    for key in HASH_FIELDS[name]:
        unchanged = before.pop(key) == after.pop(key)
        retained_observation = name == "recovered-battle-unit-rules.json" and key == "observationSha256"
        if unchanged and not retained_observation:
            raise ValueError("Dependent provenance was not refreshed: " + name)
    if name == "recovered-army-perks.json":
        reviewed = {"Server/content/recovered-army-deployment.json",
                    "Server/content/recovered-battle-content.json", "Server/tools/extract_army_perks.py"}
        if [row["path"] for row in before["sources"]] != [row["path"] for row in after["sources"]]:
            raise ValueError("Army perk source inventory changed")
        for old_source, new_source in zip(before["sources"], after["sources"]):
            if old_source["path"] in reviewed:
                if old_source["sha256"] == new_source["sha256"]:
                    raise ValueError("Army perk dependency was not refreshed")
                old_source["sha256"] = new_source["sha256"]
    if name == "recovered-air-unit-geometry.json":
        previous_hash = before["deploymentSource"]["sha256"]
        candidate_hash = after["deploymentSource"]["sha256"]
        if previous_hash == candidate_hash:
            raise ValueError("Air geometry deployment dependency was not refreshed")
        before["deploymentSource"]["sha256"] = candidate_hash
    if name == "recovered-rusher-weapon-bindings.json":
        # d44cbdbd8 only wraps four visual-loader coroutines in BattleResourceLoadScope.
        # The old catalog hashes the parent source with CRLF; cadence logic is unchanged.
        old_hash, new_hash = SOLDIER_SOURCE_TRANSITION
        reviewed = 0
        for old_family, new_family in zip(before["families"], after["families"]):
            old_cadence = old_family["attackCadence"]
            new_cadence = new_family["attackCadence"]
            if old_cadence["source"] == "Assets/Scripts/Assembly-CSharp/SoldierBehaviour.cs":
                if old_cadence["sha256"] != old_hash or new_cadence["sha256"] != new_hash:
                    raise ValueError("Unreviewed base soldier source revision")
                old_cadence["sha256"] = new_hash
                reviewed += 1
        if reviewed != 4:
            raise ValueError("Base soldier cadence source inventory changed")
    if name == "recovered-coop-assaulter-weapon.json":
        transition = (before["soldierSourceSha256"], after["soldierSourceSha256"])
        if transition != SOLDIER_SOURCE_TRANSITION:
            raise ValueError("Unreviewed Assaulter soldier source revision")
        before["soldierSourceSha256"] = after["soldierSourceSha256"]
    if name in {"recovered-landmine-source.json", "recovered-heavy-turret-source.json"}:
        field = "mainScene" if name == "recovered-landmine-source.json" else "behavior"
        if before[field]["sha256"] == after[field]["sha256"]:
            raise ValueError("Deployable scene dependency was not refreshed")
        before[field]["sha256"] = after[field]["sha256"]
    if name == "recovered-heavy-turret-source.json":
        for index, field in ((0, "DAMAGE"), (1, "HP"), (1, "DAMAGE"), (1, "REALSHOTPROBABILITY")):
            old_value = before["stats"][index][field]
            new_value = after["stats"][index][field]
            if type(old_value) is not float or type(new_value) is not float:
                raise ValueError("Heavy Turret stat must retain its float type")
            if binary32(old_value) != binary32(new_value):
                raise ValueError("Heavy Turret stat changed its recovered bits")
            before["stats"][index][field] = new_value
    if name == "recovered-mortar-weapon-pool.json":
        for field in ("revision", "sceneRevision"):
            if before["deployment"][field] == after["deployment"][field]:
                raise ValueError("Mortar deployment provenance was not refreshed")
            before["deployment"][field] = after["deployment"][field]
    if name == "legacy-catalog-profile.json":
        old_sheets = [row for row in before["sheets"] if row["type"] == "Google2u.BotNames"]
        new_sheets = [row for row in after["sheets"] if row["type"] == "Google2u.BotNames"]
        if len(old_sheets) != 1 or len(new_sheets) != 1:
            raise ValueError("BotNames profile identity is ambiguous")
        for row in name_proof["differences"]:
            index = row["rowIndex"]
            if old_sheets[0]["orderedIdentities"][index] != row["exported"]:
                raise ValueError("Previous profile name differs from original-name audit")
            if new_sheets[0]["orderedIdentities"][index] != row["original"]:
                raise ValueError("Candidate profile name differs from original package")
            old_sheets[0]["orderedIdentities"][index] = row["original"]
    if name == "recovered-pvp-bonus-catalog.json":
        # These recovered float fields only change JSON spelling, never their binary32 value.
        for field in ("warbucksScalingBase", "lowAmmoThreshold"):
            old_value = before["rules"][field]
            new_value = after["rules"][field]
            if type(old_value) is not float or type(new_value) is not float:
                raise ValueError("Bonus float rule has the wrong JSON type")
            if binary32(old_value) != binary32(new_value):
                raise ValueError("Bonus float rule changed its recovered bits")
            before["rules"][field] = new_value
    if name == "recovered-army-deployment.json":
        if len(before["families"]) != len(after["families"]):
            raise ValueError("Army deployment family inventory changed")
        for old_family, new_family in zip(before["families"], after["families"]):
            previous_speed = old_family["movementSpeed"]
            candidate_speed = new_family["movementSpeed"]
            if type(previous_speed) is not float or type(candidate_speed) is not float:
                raise ValueError("Army movement speed must retain its source float type")
            if binary32(previous_speed) != binary32(candidate_speed):
                raise ValueError("Army movement speed changed its recovered bits")
            old_family["movementSpeed"] = candidate_speed
    if encode(before) != encode(after):
        raise ValueError("Unreviewed dependent gameplay/schema change: " + name)


def build_candidates(scene, content, name_proof, observation_bytes=None):
    documents = {
        "recovered-landmine-source.json": landmine.build_document(scene, content),
        "recovered-heavy-turret-source.json": heavy_turret.build_document(scene, content),
        "recovered-coop-assaulter-weapon.json": assaulter_weapon.build_document(scene),
        "recovered-ordinary-card-identities.json": card_identities.build_document(content),
        "recovered-coop-skillshot-scores.json": coop_scores.build_document(scene, content),
        "recovered-pvp-skillshot-scores.json": pvp_scores.build_document(scene, content),
        "recovered-army-deployment.json": deployment.build_document(scene, content),
        "legacy-catalog-profile.json": profile.build_profile(content),
        "recovered-pvp-score-streak-policy.json": score.build_document(scene, content),
        "recovered-pvp-bonus-catalog.json": bonus.build_document(scene, content),
    }
    documents["recovered-army-perks.json"] = perks.build_document(
        scene, content, deployment.encode_document(documents["recovered-army-deployment.json"]))
    documents["recovered-coop-card-rows.json"] = coop_cards.build_document(
        scene, content, deployment.encode_document(documents["recovered-army-deployment.json"]))
    documents["recovered-coop-enemy-point-masks.json"] = point_masks.build_document(
        scene, deployment.encode_document(documents["recovered-army-deployment.json"]))
    documents["recovered-air-unit-geometry.json"] = air_geometry.build_document(
        deployment.encode_document(documents["recovered-army-deployment.json"]))
    documents["recovered-rusher-weapon-bindings.json"] = rusher_weapons.build_document(
        scene, content, deployment.encode_document(documents["recovered-army-deployment.json"]))
    documents["recovered-mortar-weapon-pool.json"] = mortar_pool.build_document(
        scene, deployment.encode_document(documents["recovered-army-deployment.json"]))
    if observation_bytes is not None:
        documents["recovered-battle-unit-rules.json"] = unit_rules.build_document(content, observation_bytes)
    candidates = {}
    for name, document in documents.items():
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        validate_changes(name, previous, document, name_proof)
        if name == "recovered-army-deployment.json":
            candidates[name] = deployment.encode_document(document)
        elif name == "recovered-air-unit-geometry.json":
            candidates[name] = air_geometry.encode_document(document)
        else:
            candidates[name] = encode(document).encode("utf-8")
    return candidates
