"""Extract source-ordered elite perk recipes without changing the recovered Unity project."""

import hashlib
import json
import re
import struct
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCRIPTS = ASSETS / "Scripts/Assembly-CSharp"
OUTPUT = ROOT / "Server/content/recovered-army-perks.json"
EXPECTED_FAMILY_COUNT = 24
SOURCES = {}


def read_source(path):
    payload = path.read_bytes()
    identity = path.relative_to(ROOT).as_posix()
    digest = hashlib.sha256(payload).hexdigest()
    if identity in SOURCES and SOURCES[identity] != digest:
        raise ValueError(f"Source changed during extraction: {identity}")
    SOURCES[identity] = digest
    return payload.decode("utf-8-sig")


def binary32(value):
    return struct.unpack("<f", struct.pack("<f", value))[0]


def field(block, name):
    match = re.search(r"^  " + re.escape(name) + r": (.+)$", block, re.M)
    if not match:
        raise ValueError(f"Missing scene field: {name}")
    return match[1]


def resolve_recipe(class_name):
    source = read_source(SCRIPTS / (class_name + ".cs"))
    if "override Perk PerkImplementation(" in source:
        matches = re.findall(r"perk\.(hpCoef|accuracyCoef|shotSpeedCoef|speedCoef) = 1f ([+-]) num;", source)
        if len(matches) != 1 or 'GetValue(rowIndex, "elite")' not in source:
            raise ValueError(f"Unreviewed perk implementation: {class_name}")
        counts = re.findall(r"perk\.(buffCount|debuffCount) = 1;", source)
        if len(counts) != 1:
            raise ValueError(f"Unreviewed perk count: {class_name}")
        return {"coefficient": matches[0][0], "operation": matches[0][1],
                "countKind": counts[0], "implementation": class_name}
    if class_name == "UpgradeSlots":
        if "return currentPerk;" not in source:
            raise ValueError("Base perk behavior changed")
        return {"coefficient": "none", "operation": "none", "countKind": "none", "implementation": class_name}
    parent = re.search(r"class\s+" + re.escape(class_name) + r"(?:<[^>]+>)?\s*:\s*(\w+)", source)
    if not parent or not parent[1].startswith("UpgradeSlots"):
        raise ValueError(f"Unknown perk inheritance: {class_name}")
    return resolve_recipe(parent[1])


def matches_target(affects, family):
    category_matches = affects["category"] == 0 or family["unitType"] == affects["category"] - 1
    mech_matches = affects["mech"] == 0 or family["isSoldier"] == (affects["mech"] == 2)
    fly_matches = affects["fly"] == 0 or family["isAir"] == (affects["fly"] == 2)
    return category_matches and mech_matches and fly_matches


def validate_family(family, blocks):
    behavior = blocks[family["behaviorFileId"]]
    for scene_name, catalog_name in (("unitDictionaryId", "unitId"), ("unitType", "unitType"),
                                     ("isSoldier", "isSoldier"), ("isAir", "isAir")):
        expected = family[catalog_name]
        actual = field(behavior, scene_name)
        if isinstance(expected, bool):
            expected = int(expected)
        if actual != str(expected):
            raise ValueError(f"Changed family field: {family['unitId']} / {scene_name}")
    slots_id = int(re.search(r"fileID: (\d+)", field(behavior, "upgradeSlots"))[1])
    if slots_id != family["upgradeSlotsFileId"]:
        raise ValueError("The family upgrade component changed")
    behavior_meta = read_source(SCRIPTS / (family["behaviorType"] + ".cs.meta"))
    behavior_guid = re.search(r"^guid: ([0-9a-f]{32})$", behavior_meta, re.M)[1]
    if behavior_guid not in field(behavior, "m_Script"):
        raise ValueError("The family behavior type changed")


def selector_rows(blocks, families):
    manager_meta = read_source(SCRIPTS / "LevelBehaviourManager.cs.meta")
    manager_guid = re.search(r"^guid: ([0-9a-f]{32})$", manager_meta, re.M)[1]
    manager = next(block for block in blocks.values() if "guid: " + manager_guid in block)
    behavior_ids = list(map(int, re.findall(r"behaviour: \{fileID: (\d+)\}", manager)))
    if not {family["behaviorFileId"] for family in families}.issubset(behavior_ids):
        raise ValueError("The perk selector is missing a player unit type")
    known_types = {}
    for family in families:
        meta = read_source(SCRIPTS / (family["behaviorType"] + ".cs.meta"))
        known_types[re.search(r"^guid: ([0-9a-f]{32})$", meta, re.M)[1]] = family["behaviorType"]
    rows = []
    for identity in behavior_ids:
        block = blocks[identity]
        guid = re.search(r"guid: ([0-9a-f]{32})", field(block, "m_Script"))[1]
        if guid in known_types:
            rows.append({"behaviorFileId": identity, "behaviorType": known_types[guid],
                         "unitType": int(field(block, "unitType")),
                         "isSoldier": bool(int(field(block, "isSoldier"))),
                         "isAir": bool(int(field(block, "isAir")))})
    return behavior_ids, rows


def extract_family(family, blocks, sheets, script_names, ordered_families, selectors):
    behavior = blocks[family["behaviorFileId"]]
    slots = blocks[family["upgradeSlotsFileId"]]
    guid = re.search(r"guid: ([0-9a-f]{32})", field(slots, "m_Script"))[1]
    recipe = resolve_recipe(script_names[guid])
    affects_match = re.search(r"^  perkAffects:\n    category: (\d+)\n    mech: (\d+)\n    fly: (\d+)$",
                              behavior, re.M)
    if not affects_match:
        raise ValueError(f"Missing perk selector: {family['unitId']}")
    affects = dict(zip(("category", "mech", "fly"), map(int, affects_match.groups())))
    if affects["category"] not in range(5) or affects["mech"] not in range(3) or affects["fly"] not in range(3):
        raise ValueError("Unknown source perk category")
    perk_type = int(field(behavior, "perkType"))
    if perk_type not in (0, 1):
        raise ValueError("Unknown perk faction")
    values = [] if recipe["coefficient"] == "none" else [
        binary32(float(row["ELITE"])) for row in sheets[family["sheetRow"]]["rows"]]
    if recipe["coefficient"] != "none" and (not values or any(not 0 <= value < 1 for value in values)):
        raise ValueError(f"Invalid elite perk values: {family['unitId']}")
    return {
        "unitId": family["unitId"], "behaviorType": family["behaviorType"],
        "levelManagerIndex": ordered_families.index(family),
        "serializedLevelManagerIndex": int(field(behavior, "indexInLevelsManager")),
        "sheet": family["sheetRow"], "faction": "ally" if perk_type == 0 else "opponent",
        "selector": affects, "recipe": recipe, "eliteColumn": values,
        # Source PerkUnitCategories stores exact behavior Types rather than individual row identities.
        "affectedUnitIds": [target["unitId"] for target in ordered_families
                            if any(matches_target(affects, candidate) for candidate in selectors
                                   if candidate["behaviorType"] == target["behaviorType"])],
    }


def main():
    read_source(Path(__file__))
    deployment = json.loads(read_source(ROOT / "Server/content/recovered-army-deployment.json"))
    content = json.loads(read_source(ROOT / "Server/content/recovered-battle-content.json"))
    scene_path = ASSETS / "Scenes/MainScene.unity"
    scene = read_source(scene_path)
    if content["mainSceneSha256"] != deployment["sceneSha256"]:
        raise ValueError("Deployment and source-table snapshots disagree")
    blocks = {int(match[1]): match[2] for match in re.finditer(
        r"^--- !u!\d+ &(\d+)\n(.*?)(?=^--- !u!|\Z)", scene, re.M | re.S)}
    script_names = {}
    for path in sorted(SCRIPTS.glob("UpgradeSlots*.cs.meta")):
        guid = re.search(r"^guid: ([0-9a-f]{32})$", read_source(path), re.M)[1]
        script_names[guid] = path.name.removesuffix(".cs.meta")
    manager_guid = re.search(r"^guid: ([0-9a-f]{32})$", read_source(SCRIPTS / "LevelManager.cs.meta"), re.M)[1]
    manager = next(block for block in blocks.values() if "guid: " + manager_guid in block)
    ordered_ids = re.findall(r"^  - \{fileID: (\d+)\}$",
                             manager.split("  behaviours:\n", 1)[1].split("  additionalBehaviours:", 1)[0], re.M)
    by_id = {family["behaviorFileId"]: family for family in deployment["families"]}
    ordered = [by_id[int(identity)] for identity in ordered_ids]
    if len(ordered) != EXPECTED_FAMILY_COUNT or len(set(ordered_ids)) != EXPECTED_FAMILY_COUNT:
        raise ValueError("The complete ordered player unit set changed")
    for family in ordered:
        validate_family(family, blocks)
    for name in ("IGameController", "LevelManager", "LevelBehaviourManager", "LevelBehaviour", "Perk",
                 "PerkUnitCategories", "PerkAffects",
                 "PerkType", "PerkUnitCategory", "PerkMechcategory", "PerkFlyCategory", "PlayerProperties"):
        read_source(SCRIPTS / (name + ".cs"))
    sheets = {sheet["type"]: sheet for sheet in content["sheets"]}
    selector_ids, selectors = selector_rows(blocks, ordered)
    families = [extract_family(family, blocks, sheets, script_names, ordered, selectors) for family in ordered]
    if "levelBehaviour.indexInLevelsManager = j;" not in (SCRIPTS / "LevelManager.cs").read_text(encoding="utf-8-sig"):
        raise ValueError("Runtime unit-index initialization changed")
    payload = {
        "version": 1, "clientVersion": "1.4.0",
        "sceneSha256": SOURCES[scene_path.relative_to(ROOT).as_posix()],
        "deploymentSceneSha256": deployment["sceneSha256"],
        "rule": "Start at binary32 one; equipped elite ally buffs then opponent debuffs in LevelManager order.",
        "selectorBehaviorFileIds": selector_ids, "selectorPlayerTypes": selectors,
        "sources": [{"path": path, "sha256": digest} for path, digest in sorted(SOURCES.items())],
        "families": families,
    }
    for identity, digest in SOURCES.items():
        if hashlib.sha256((ROOT / identity).read_bytes()).hexdigest() != digest:
            raise ValueError(f"Source changed before publication: {identity}")
    pending = OUTPUT.with_suffix(".json.pending")
    with pending.open("w", encoding="utf-8", newline="\n") as output:
        output.write(json.dumps(payload, indent=2, ensure_ascii=True, allow_nan=False) + "\n")
    pending.replace(OUTPUT)
    active = sum(family["recipe"]["coefficient"] != "none" for family in families)
    print(f"Extracted {len(families)} ordered families and {active} modifying perk recipes: {OUTPUT.name}")


if __name__ == "__main__":
    main()
