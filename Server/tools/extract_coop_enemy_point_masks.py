"""Pin serialized SoldierBehaviour enemy-point masks from MainScene."""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
ARMY = ROOT / "Server/content/recovered-army-deployment.json"
OUTPUT = ROOT / "Server/content/recovered-coop-enemy-point-masks.json"


def main():
    source = SCENE.read_bytes()
    army = json.loads(ARMY.read_text(encoding="utf-8"))
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
    for family in army["families"]:
        if not family["isSoldier"]:
            continue
        component_id = family["behaviorFileId"]
        match = re.search(r"^  enemyPointType: (\d+)$",
                          blocks[component_id], re.M)
        if not match:
            raise ValueError("soldier lacks a source enemy-point mask")
        mask = int(match.group(1))
        if mask <= 0 or mask > 0x3FFF:
            raise ValueError("invalid source enemy-point mask")
        rows.append({
            "behaviorFileId": component_id,
            "behaviorType": family["behaviorType"],
            "unitId": family["unitId"],
            "enemyPointMask": mask,
        })
    if len(rows) != 16:
        raise ValueError("source soldier mask inventory changed")
    content = json.dumps({"version": 1, "sceneSha256": digest,
                          "soldiers": rows}, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("co-op point masks differ from MainScene")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8")
    else:
        raise ValueError("usage: extract_coop_enemy_point_masks.py [--check]")
    print(f"{len(rows)} source soldier point masks")


if __name__ == "__main__":
    main()
