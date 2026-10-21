"""Pin serialized SoldierBehaviour enemy-point masks from MainScene."""

import argparse
import hashlib
import json
import re
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
ARMY = ROOT / "Server/content/recovered-army-deployment.json"
OUTPUT = ROOT / "Server/content/recovered-coop-enemy-point-masks.json"


def build_document(source, army_bytes):
    army = json.loads(army_bytes)
    digest = hashlib.sha256(source).hexdigest()
    if digest != army["sceneSha256"]:
        raise ValueError("MainScene differs from the deployment graph")
    scene = source.decode("utf-8-sig")
    blocks = {
        int(match.group(1)): match.group(2)
        for match in re.finditer(
            r"^--- !u!\d+ &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
            scene, re.M | re.S,
        )
    }
    rows = []
    seen_components = set()
    seen_units = set()
    for family in army["families"]:
        if type(family["isSoldier"]) is not bool:
            raise ValueError("Soldier classification must be Boolean")
        if not family["isSoldier"]:
            continue
        component_id = family["behaviorFileId"]
        if component_id in seen_components or family["unitId"] in seen_units:
            raise ValueError("Duplicate soldier point-mask identity")
        seen_components.add(component_id)
        seen_units.add(family["unitId"])
        match = re.search(r"^  enemyPointType: (\d+)$",
                          blocks[component_id], re.M)
        if not match:
            raise ValueError("soldier lacks a source enemy-point mask")
        mask = int(match.group(1))
        if mask <= 0 or mask > 0x3FFF:
            raise ValueError("invalid source enemy-point mask")
        row = {
            "behaviorFileId": component_id,
            "behaviorType": family["behaviorType"],
            "unitId": family["unitId"],
            "enemyPointMask": mask,
        }
        if family["behaviorType"] == "SoldierBehaviourSniper":
            distance = re.search(r"^    minSniperDistance: ([0-9.]+)$",
                                 blocks[component_id], re.M)
            if not distance or float(distance.group(1)) != 6:
                raise ValueError("Sniper minimum distance changed in MainScene")
            row["minimumPlayerDistance"] = float(distance.group(1))
        rows.append(row)
    if len(rows) != 16:
        raise ValueError("source soldier mask inventory changed")
    return {"version": 1, "sceneSha256": digest, "soldiers": rows}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true", help="Validate without writing production content")
    args = parser.parse_args()
    document = build_document(SCENE.read_bytes(), ARMY.read_bytes())
    content = (json.dumps(document, indent=2, allow_nan=False) + "\n").encode("utf-8")
    if args.check:
        if not OUTPUT.exists() or OUTPUT.read_bytes() != content:
            raise ValueError("co-op point masks differ from MainScene")
    else:
        OUTPUT.write_bytes(content)
    print(f"{len(document['soldiers'])} source soldier point masks")


if __name__ == "__main__":
    main()
