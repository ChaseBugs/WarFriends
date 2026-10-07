"""Recover the OBB LevelManager weapon order and BotManager boss choices."""

import hashlib
import json
import re
import struct
import sys
import zipfile
from pathlib import Path

import UnityPy


ROOT = Path(__file__).resolve().parents[2]
OBB = ROOT / "main.14008.com.chillingo.warfriends.android.gplay.obb"
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
BOTS = ROOT / "Server/content/recovered-coop-bot-rules.json"
ATTACKS = ROOT / "Server/content/recovered-coop-boss-attack-timing.json"
OUTPUT = ROOT / "Server/content/recovered-coop-boss-loadouts.json"
SOURCE_OBB_SHA256 = "078cd1c4ebaeef4a39646274a54d35ce05741bc15a2e13d95ae55340711b5125"
LEVEL_MANAGER_FILE_ID = 45847
WEAPON_UPGRADES_FILE_ID = 45843
CATEGORY_VALUES = {
    "AssaultRifle": 1, "SMG": 2, "LMG": 4, "SniperRifle": 8,
    "RocketLauncher": 16, "Shotgun": 32, "Grenade": 64, "Pistol": 128,
    "Minigun": 256, "GrenadeLauncher": 512,
}


def level_manager_order():
    if hashlib.sha256(OBB.read_bytes()).hexdigest() != SOURCE_OBB_SHA256:
        raise ValueError("the matching 1.4.0 OBB changed")
    with zipfile.ZipFile(OBB) as archive:
        parts = [name for name in archive.namelist()
                 if re.fullmatch(r"assets/bin/Data/level0\.split\d+", name)]
        parts.sort(key=lambda name: int(name.rsplit("split", 1)[1]))
        if len(parts) != 8:
            raise ValueError("the OBB MainScene level has incomplete split parts")
        scene_data = b"".join(archive.read(name) for name in parts)
    environment = UnityPy.load(scene_data)
    manager = next((obj for obj in environment.objects
                    if obj.path_id == LEVEL_MANAGER_FILE_ID), None)
    if manager is None or manager.type.name != "MonoBehaviour" or manager.byte_size != 1176:
        raise ValueError("LevelManager raw component identity changed")
    raw = manager.get_raw_data()
    count = struct.unpack_from("<I", raw, 32)[0]
    if count != 66 or 36 + count * 12 > len(raw):
        raise ValueError("LevelManager weapon reference array changed")
    references = [struct.unpack_from("<iq", raw, 36 + index * 12)
                  for index in range(count)]
    if any(file_id != 0 or path_id <= 0 for file_id, path_id in references) or \
            len({path_id for _, path_id in references}) != count:
        raise ValueError("LevelManager has invalid or repeated weapon references")
    return [path_id for _, path_id in references]


def script_names():
    folder = ROOT / "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u"
    names = {}
    for path in folder.glob("*.cs.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$", path.read_text(), re.M)
        if match:
            names[match.group(1)] = "Google2u." + path.name.removesuffix(".cs.meta")
    return names


def scene_weapon_rows(source_text, ordered_ids):
    components = {}
    game_objects = set()
    headers = list(re.finditer(r"^--- !u!\d+ &(\d+)\r?$", source_text, re.M))
    for index, header in enumerate(headers):
        file_id = int(header.group(1))
        if file_id not in ordered_ids:
            continue
        body = source_text[header.end():headers[index + 1].start()
                           if index + 1 < len(headers) else len(source_text)]
        game_object = re.search(r"^  m_GameObject: \{fileID: (\d+)\}$", body, re.M)
        category = re.search(r"^  weaponCategory: (\d+)$", body, re.M)
        inventory = re.search(r"^  indexInWeaponInventory: (\d+)$", body, re.M)
        if not game_object or not category or not inventory:
            raise ValueError(f"weapon component {file_id} lacks source fields")
        game_id = int(game_object.group(1))
        components[file_id] = (game_id, int(category.group(1)), int(inventory.group(1)))
        game_objects.add(game_id)
    if len(components) != 66:
        raise ValueError("weapon references did not resolve to 66 source components")

    attached_scripts = {}
    for index, header in enumerate(headers):
        body = source_text[header.end():headers[index + 1].start()
                           if index + 1 < len(headers) else len(source_text)]
        if not body.startswith("\nMonoBehaviour:"):
            continue
        game_object = re.search(r"^  m_GameObject: \{fileID: (\d+)\}$", body, re.M)
        if not game_object or int(game_object.group(1)) not in game_objects:
            continue
        script = re.search(r"^  m_Script: .*guid: ([0-9a-f]{32})", body, re.M)
        if script:
            attached_scripts.setdefault(int(game_object.group(1)), []).append(
                script.group(1))

    upgrade_block = source_text.split(
        f"--- !u!114 &{WEAPON_UPGRADES_FILE_ID}\n", 1)[1].split("--- !u!", 1)[0]
    upgrade_rows = re.findall(
        r"^  - NAME: (Google2u\.[^\n]+)\n    UNLOCKLEVEL: (\d+)$",
        upgrade_block, re.M)
    unlock_by_name = {name: int(level) - 1 for name, level in upgrade_rows}
    if len(upgrade_rows) != 66 or len(unlock_by_name) != 66:
        raise ValueError("WeaponUpgrades source sheet lacks 66 unique names")

    names = script_names()
    rows = []
    for index, file_id in enumerate(ordered_ids):
        game_id, category, inventory = components[file_id]
        matching_names = [names[guid] for guid in attached_scripts[game_id]
                          if guid in names and names[guid] in unlock_by_name]
        if len(matching_names) != 1 or category not in CATEGORY_VALUES.values():
            raise ValueError(f"weapon {file_id} lacks one matching upgrade sheet")
        sheet_name = matching_names[0]
        rows.append({"levelManagerIndex": index,
                     "componentFileId": file_id,
                     "gameObjectFileId": game_id,
                     "sheetName": sheet_name,
                     "category": category,
                     "inventoryIndex": inventory,
                     "unlockLevelIndex": unlock_by_name[sheet_name]})
    if len({row["sheetName"] for row in rows}) != 66 or \
            len({row["inventoryIndex"] for row in rows}) != 66:
        raise ValueError("LevelManager weapon identities are not unique")
    return rows


def last_unlocked(weapons, category, level):
    # LevelManager.GetLastUnlockedWeapon replaces ties only for the fallback.
    chosen = None
    highest_unlock = -1
    for weapon in weapons:
        if weapon["category"] == category and \
                weapon["unlockLevelIndex"] <= level and \
                weapon["unlockLevelIndex"] > highest_unlock:
            chosen = weapon
            highest_unlock = weapon["unlockLevelIndex"]
    if chosen is not None:
        return chosen
    lowest_unlock = 2**31 - 1
    for weapon in weapons:
        if weapon["category"] == category and \
                weapon["unlockLevelIndex"] <= lowest_unlock:
            chosen = weapon
            lowest_unlock = weapon["unlockLevelIndex"]
    if chosen is None:
        raise ValueError(f"no source weapon in category {category}")
    return chosen


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_boss_loadouts.py [--check]")
    scene_bytes = SCENE.read_bytes()
    weapons = scene_weapon_rows(scene_bytes.decode("utf-8-sig"),
                                level_manager_order())
    bots = json.loads(BOTS.read_bytes())
    attack_bytes = ATTACKS.read_bytes()
    attacks = json.loads(attack_bytes)
    if bots["missionSourceSha256"] != hashlib.sha256(scene_bytes).hexdigest() or \
            attacks["sceneSha256"] != bots["missionSourceSha256"]:
        raise ValueError("boss loadout input revisions differ")
    missions = []
    for bot, attack in zip(bots["bots"], attacks["missions"], strict=True):
        if bot["missionIndex"] != attack["missionIndex"]:
            raise ValueError("bot difficulty and attack category rows differ")
        slots = []
        for field in ("primaryCategory", "secondaryCategory",
                      "explosiveCategory", "pistolCategory"):
            raw_category = attack[field]
            category = CATEGORY_VALUES[raw_category.strip()]
            weapon = last_unlocked(weapons, category, bot["bot"]["level"])
            slots.append({"sourceCategory": raw_category,
                          "levelManagerIndex": weapon["levelManagerIndex"],
                          "inventoryIndex": weapon["inventoryIndex"],
                          "sheetName": weapon["sheetName"]})
        missions.append({"missionIndex": bot["missionIndex"],
                         "level": bot["bot"]["level"], "slots": slots})
    artifact = {
        "version": 1,
        "sceneSha256": hashlib.sha256(scene_bytes).hexdigest(),
        "obbSha256": SOURCE_OBB_SHA256,
        "attackSourceSha256": hashlib.sha256(attack_bytes).hexdigest(),
        "levelManagerComponentFileId": LEVEL_MANAGER_FILE_ID,
        "weaponUpgradesComponentFileId": WEAPON_UPGRADES_FILE_ID,
        "weapons": weapons,
        "missions": missions,
    }
    encoded = (json.dumps(artifact, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("boss loadouts differ from source weapon order")
    else:
        OUTPUT.write_bytes(encoded)
    print("66 ordered source weapons and 15 four-slot boss loadouts pinned")


if __name__ == "__main__":
    main()
