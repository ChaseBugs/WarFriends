"""Pin CARDS_MIN/MAX indexes from the recovered 1.4.0 scene sheets."""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCENE = ASSETS / "Scenes/MainScene.unity"
ARMY = ROOT / "Server/content/recovered-army-deployment.json"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-coop-card-rows.json"

CARD_BEHAVIOURS = {
    "SoldierBehaviourAssaulter", "SoldierBehaviourGrennader",
    "SoldierBehaviourMinigunner", "SoldierBehaviourParachuter",
    "SoldierBehaviourBazooka", "SoldierBehaviourSniper",
    "SoldierBehaviourSwat", "DroneBehaviour",
}


def field(block, name):
    match = re.search(r"^  " + re.escape(name) + r": (.+)$", block, re.M)
    if not match:
        raise ValueError(f"missing scene field {name}")
    return match.group(1)


def main():
    scene_bytes = SCENE.read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    scene_hash = hashlib.sha256(scene_bytes).hexdigest()
    army_bytes = ARMY.read_bytes()
    content_bytes = CONTENT.read_bytes()
    army = json.loads(army_bytes)
    content = json.loads(content_bytes)
    if scene_hash != army["sceneSha256"] or scene_hash != content["mainSceneSha256"]:
        raise ValueError("card rows do not bind the recovered MainScene")

    blocks = {int(match.group(1)): match.group(2) for match in re.finditer(
        r"^--- !u!\d+ &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
        scene, re.M | re.S)}
    script_types = {}
    for folder in ("Scripts", "Plugins"):
        for path in (ASSETS / folder).rglob("*.cs.meta"):
            match = re.search(r"^guid: ([0-9a-f]{32})$",
                              path.read_text(encoding="utf-8-sig"), re.M)
            if match:
                script_types[match.group(1)] = path.stem.removesuffix(".cs")
    sheets = {sheet["type"]: sheet for sheet in content["sheets"]}

    rows = []
    for family in army["families"]:
        if family["behaviorType"] not in CARD_BEHAVIOURS:
            continue
        slots = blocks[family["upgradeSlotsFileId"]]
        game_object_id = int(re.search(
            r"fileID: (\d+)", field(slots, "m_GameObject")).group(1))
        component_ids = [int(value) for value in re.findall(
            r"- 114: \{fileID: (\d+)\}", blocks[game_object_id])]
        matching = []
        for component_id in component_ids:
            component = blocks[component_id]
            guid = re.search(r"guid: ([0-9a-f]{32})", field(component, "m_Script"))
            if guid and "Google2u." + script_types.get(guid.group(1), "") == family["sheetRow"]:
                matching.append(component)
        if len(matching) != 1:
            raise ValueError(f"missing unique card sheet for {family['unitId']}")
        section = re.search(r"^  rowNames:\r?\n(.*?)^  Rows:",
                            matching[0], re.M | re.S)
        if not section:
            raise ValueError(f"missing source row names for {family['unitId']}")
        names = re.findall(r"^  - ([^\r\n]+)$", section.group(1), re.M)
        if len(names) != len(sheets[family["sheetRow"]]["rows"]) or \
                names.count("CARDS_MIN") != names.count("CARDS_MAX") or \
                names.count("CARDS_MIN") > 1:
            raise ValueError(f"card row labels do not match {family['unitId']} stages")
        has_card_rows = "CARDS_MIN" in names
        # UpgradeSlots.LoadDataForCard explicitly uses row zero for both ends
        # when a source sheet lacks CARDS_MIN/MAX (for example Sniper).
        minimum = names.index("CARDS_MIN") if has_card_rows else 0
        maximum = names.index("CARDS_MAX") if has_card_rows else 0
        if has_card_rows and maximum != minimum + 1:
            raise ValueError(f"card rows are not adjacent for {family['unitId']}")
        for index in (minimum, maximum):
            stage = sheets[family["sheetRow"]]["rows"][index]
            if stage["HP"] <= 0 or stage["DAMAGE"] < 0:
                raise ValueError(f"card combat row is unplayable for {family['unitId']}")
        rows.append({
            "unitId": family["unitId"],
            "sheetRow": family["sheetRow"],
            "minimumIndex": minimum,
            "maximumIndex": maximum,
            "hasCardRows": has_card_rows,
        })
    if len(rows) != len(CARD_BEHAVIOURS):
        raise ValueError("co-op card family set is incomplete")
    artifact = {
        "version": 1,
        "sceneSha256": scene_hash,
        "armySha256": hashlib.sha256(army_bytes).hexdigest(),
        "contentSha256": hashlib.sha256(content_bytes).hexdigest(),
        "rows": rows,
    }
    encoded = json.dumps(artifact, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_text(encoding="utf-8") != encoded:
            raise ValueError("co-op card row artifact differs from recovered source")
    elif not sys.argv[1:]:
        OUTPUT.write_text(encoded, encoding="utf-8", newline="\n")
    else:
        raise SystemExit("usage: extract_coop_card_rows.py [--check]")
    print(f"{len(rows)} co-op card families")


if __name__ == "__main__":
    main()
