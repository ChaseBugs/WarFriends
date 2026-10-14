"""Recover the exact MainScene bonus order and source Crates probability rows."""
import hashlib
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"


def digest(data):
    return hashlib.sha256(data).hexdigest()


def main():
    scene_bytes = (ASSETS / "Scenes/MainScene.unity").read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    content_bytes = (ROOT / "Server/content/recovered-battle-content.json").read_bytes()
    content = json.loads(content_bytes)
    if content["mainSceneSha256"] != digest(scene_bytes):
        raise ValueError("Bonus catalog and content refer to different scenes")
    manager_path = ASSETS / "Scripts/Assembly-CSharp/KillStreakManager.cs"
    manager_guid = re.search(r"^guid: (\w+)$", manager_path.with_suffix(".cs.meta").read_text(), re.M)[1]
    manager_blocks = [block for block in scene.split("--- !u!") if "guid: " + manager_guid + "," in block]
    if len(manager_blocks) != 1:
        raise ValueError("Expected one MainScene KillStreakManager")
    manager_object_id = re.search(r"m_GameObject: \{fileID: (\d+)\}", manager_blocks[0])[1]
    grenade_setup_path = ASSETS / "Scripts/Assembly-CSharp/GrenadeAmmoSetup.cs"
    grenade_setup_guid = re.search(
        r"^guid: (\w+)$", grenade_setup_path.with_suffix(".cs.meta").read_text(), re.M)[1]
    grenade_setups = [block for block in scene.split("--- !u!")
                      if block.startswith("114 &") and
                      "guid: " + grenade_setup_guid + "," in block and
                      "m_GameObject: {fileID: " + manager_object_id + "}" in block]
    if len(grenade_setups) != 1:
        raise ValueError("Expected one shared KillStreak Manager grenade setup")
    grenade_setup = grenade_setups[0]
    def obscured_fake_value(field):
        match = re.search(r"^  " + field + r":\n(?:(?!^  \w+:).)*?^    fakeValue: ([\d.]+)$",
                          grenade_setup, re.M | re.S)
        if not match:
            raise ValueError("Missing shared grenade setup " + field)
        return float(match[1])
    initial_direct_damage = obscured_fake_value("damageAmount")
    initial_explosion_damage = obscured_fake_value("explodeDamageAmount")
    if (initial_direct_damage, initial_explosion_damage) != (20.0, 350.0):
        raise ValueError("Shared grenade setup damage changed")
    binding = manager_blocks[0].split("  bonusesPrefabs:\n", 1)[1].split("  killStreakBonusBoxPrefab:", 1)[0]
    references = re.findall(r"fileID: (\d+), guid: (\w+)", binding)
    if len(references) != 9 or len(set(references)) != 9:
        raise ValueError("Expected nine unique source bonus references")
    sheet_path = ASSETS / "Plugins/Assembly-CSharp-firstpass/Google2u/Crates.cs"
    sheet_bytes = sheet_path.read_bytes()
    names_block = re.search(r"rowNames = new string\[9\]\s*\{(.*?)\}", sheet_bytes.decode("utf-8-sig"), re.S)
    names = re.findall(r'"(\w+)"', names_block[1])
    sheets = [sheet for sheet in content["sheets"] if sheet["type"] == "Google2u.Crates"]
    if len(sheets) != 1 or len(names) != 9 or len(sheets[0]["rows"]) != 9:
        raise ValueError("Incomplete Crates name/probability table")
    probabilities = dict(zip(names, sheets[0]["rows"]))
    prefab_paths = {}
    for meta in ASSETS.rglob("*.prefab.meta"):
        match = re.search(r"^guid: (\w+)$", meta.read_text(encoding="utf-8-sig"), re.M)
        if match:
            prefab_paths[match[1]] = meta.with_suffix("")
    rows = []
    grenade_count = None
    grenade_distance = None
    for index, (file_id, guid) in enumerate(references):
        path = prefab_paths[guid]
        prefab_bytes = path.read_bytes()
        prefab = prefab_bytes.decode("utf-8-sig")
        blocks = prefab.split("--- !u!")
        component = next(block for block in blocks if block.startswith("114 &" + file_id + "\n"))
        object_id = re.search(r"m_GameObject: \{fileID: (\d+)\}", component)[1]
        game_object = next(block for block in blocks if block.startswith("1 &" + object_id + "\n"))
        name = re.search(r"^  m_Name: (\w+)$", game_object, re.M)[1]
        if name == "KillStreakBonusGrenades":
            grenade_count = int(re.search(r"^  numberOfgrenades: (\d+)$", component, re.M)[1])
            grenade_distance = int(re.search(r"^  maxDistance: (\d+)$", component, re.M)[1])
        values = probabilities[name]
        if set(values) != {"PROBABILITY", "PROBABILITYARENA"}:
            raise ValueError("Unknown source Crates fields")
        rows.append({"index": index, "name": name, "prefabGuid": guid,
                     "componentFileId": int(file_id), "prefabPath": path.relative_to(ASSETS).as_posix(),
                     "prefabSha256": digest(prefab_bytes),
                     "probability": values["PROBABILITY"], "arenaProbability": values["PROBABILITYARENA"]})
    if set(row["name"] for row in rows) != set(names):
        raise ValueError("Bonus prefabs and probability identities differ")
    grenade_code = (ASSETS / "Scripts/Assembly-CSharp/KillStreakBonusGrenades.cs").read_bytes()
    if grenade_count != 3 or grenade_distance != 3 or grenade_code.count(b"Random.Range(-1.5f, 1.5f)") != 2:
        raise ValueError("Source grenade box burst or fallback spread changed")
    def keyed_value(sheet_type, key):
        table = next(sheet for sheet in content["sheets"] if sheet["type"] == sheet_type)
        values = [row["FLOATVALUE"] for row in table["rows"] if row.get("DBKEY") == key]
        if len(values) != 1:
            raise ValueError("Missing probability rule " + key)
        return values[0]
    bonus_path = ASSETS / "Plugins/Assembly-CSharp-firstpass/Google2u/BonussesDefinitions.cs"
    bonus_bytes = bonus_path.read_bytes()
    bonus_names = re.findall(r'"(\w+)"', re.search(r"rowNames = new string\[8\]\s*\{(.*?)\}", bonus_bytes.decode("utf-8-sig"), re.S)[1])
    bonus_table = next(sheet for sheet in content["sheets"] if sheet["type"] == "Google2u.BonussesDefinitions")
    def bonus_value(name):
        return bonus_table["rows"][bonus_names.index(name)]["FLOATVALUE"]
    levels = next(sheet for sheet in content["sheets"] if sheet["type"] == "Google2u.Levels")["rows"]
    if [row["LEVEL"] for row in levels] != list(range(1, len(levels) + 1)):
        raise ValueError("Source rank display/index binding changed")
    code_names = ["KillStreakBonus", "KillStreakBonusAddCredits", "KillStreakBonusAddMoney",
                  "KillStreakBonusAddAmmo", "KillStreakBonusCard", "PlayerAnalytics", "LevelManager"]
    document = {"version": 1, "sceneSha256": digest(scene_bytes),
                "battleContentSha256": digest(content_bytes), "managerSha256": digest(manager_path.read_bytes()),
                "cratesCodeSha256": digest(sheet_bytes), "bonusDefinitionsCodeSha256": digest(bonus_bytes),
                "grenadeCodeSha256": digest(grenade_code),
                "grenadeSetupCodeSha256": {
                    name: digest((ASSETS / ("Scripts/Assembly-CSharp/" + name + ".cs")).read_bytes())
                    for name in ("GrenadeAmmoBase", "GrenadeAmmo", "CardGrenadesBurst")},
                "probabilityCodeSha256": {name: digest((ASSETS / ("Scripts/Assembly-CSharp/" + name + ".cs")).read_bytes()) for name in code_names},
                "rules": {"goldLowLevelProbability": keyed_value("Google2u.Constants", "GoldCrateLowLevelProbability"),
                          "goldLowLevelMinimum": keyed_value("Google2u.Constants", "GoldCrateLowLevelGoldMin"),
                          "goldLowLevelMaximum": keyed_value("Google2u.Constants", "GoldCrateLowLevelGoldMax"),
                          "goldRegularMinimum": bonus_value("AddGoldMin"),
                          "goldRegularMaximum": bonus_value("AddGoldMax"),
                          "warbucksMinimum": bonus_value("AddWBMin"),
                          "warbucksMaximum": bonus_value("AddWBMax"),
                          "warbucksScalingBase": keyed_value("Google2u.Constants", "WarbucksScalingBase"),
                          "grenadeCount": grenade_count,
                          "grenadeTargetDistance": grenade_distance,
                          "grenadeFallbackDamageMinimum": keyed_value("Google2u.CardConstants", "ClusterGrenadeDamageMin"),
                          "grenadeFallbackDamageMaximum": keyed_value("Google2u.CardConstants", "ClusterGrenadeDamageMax"),
                          "grenadeInitialDirectDamage": initial_direct_damage,
                          "grenadeInitialExplosionDamage": initial_explosion_damage,
                          "cardUnlockLevel": keyed_value("Google2u.CardConstants", "WarcardsUnlockLevel"),
                          "lowAmmoThreshold": bonus_value("LowAmmoRatio"),
                          "lowAmmoMultiplier": bonus_value("AmmoCrateOnLowAmmoRatio"),
                          "rankCount": len(levels)}, "rows": rows}
    data = (json.dumps(document, indent=2) + "\n").encode("utf-8")
    output = ROOT / "Server/content/recovered-pvp-bonus-catalog.json"
    if "--check" in sys.argv:
        if output.read_bytes() != data:
            raise ValueError("Checked-in PvP bonus catalog differs from current source")
    else:
        output.write_bytes(data)
    print("Recovered nine source bonus bindings; SHA-256 " + digest(data))


if __name__ == "__main__":
    main()
