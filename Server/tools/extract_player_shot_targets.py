"""Pin the gameplay Player's serialized GameShootableEntityPlayer target points."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path

from extract_army_spawn_points import field, ref, vec, mul, rotate

ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
OUTPUT = ROOT / "Server/content/recovered-player-shot-targets.json"
SCRIPT_GUID = "3c6382a9565da1dc77b10ffb246c509f"


def extract():
    data = SCENE.read_bytes()
    text = data.decode("utf-8-sig")
    blocks = {int(m.group(2)): (int(m.group(1)), m.group(3)) for m in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", text, re.M | re.S)}
    owners = [(ident, body) for ident, (kind, body) in blocks.items()
              if kind == 114 and f"guid: {SCRIPT_GUID}" in body]
    if len(owners) != 2:
        raise ValueError("expected gameplay and rendering player target components")

    def path_and_position(transform_id):
        chain = []
        current = transform_id
        while current:
            kind, transform = blocks[current]
            if kind != 4:
                raise ValueError("target chain has a non-Transform")
            game_object = blocks[ref(transform, "m_GameObject")][1]
            chain.append((field(game_object, "m_Name"),
                          vec(field(transform, "m_LocalPosition")),
                          vec(field(transform, "m_LocalRotation")),
                          vec(field(transform, "m_LocalScale"))))
            current = ref(transform, "m_Father")
            if len(chain) > 64:
                raise ValueError("cyclic target hierarchy")
        position = [0.0, 0.0, 0.0]
        rotation = [0.0, 0.0, 0.0, 1.0]
        scale = [1.0, 1.0, 1.0]
        for _, local_position, local_rotation, local_scale in reversed(chain):
            offset = rotate(rotation, [a*b for a, b in zip(local_position, scale)])
            position = [a+b for a, b in zip(position, offset)]
            rotation = mul(rotation, local_rotation)
            scale = [a*b for a, b in zip(scale, local_scale)]
        if not all(math.isfinite(x) and abs(x) < 10000 for x in position):
            raise ValueError("invalid target position")
        return "/".join(name for name, *_ in reversed(chain)), position

    rows = []
    for ident, component in owners:
        game_object = blocks[ref(component, "m_GameObject")][1]
        name = field(game_object, "m_Name")
        if name not in ("Player", "Player For Rendering"):
            raise ValueError("unexpected target owner")
        target_block = re.search(r"^  targets:\r?\n((?:  - transform: \{fileID: \d+\}\r?\n    type: \d+\r?\n)+)", component, re.M)
        if target_block is None:
            raise ValueError("target list missing")
        targets = []
        for match in re.finditer(r"transform: \{fileID: (\d+)\}\r?\n    type: (\d+)", target_block.group(1)):
            transform_id, target_type = map(int, match.groups())
            path, position = path_and_position(transform_id)
            targets.append({"transformFileId": transform_id, "type": target_type,
                            "path": path, "referencePosition": position})
        if [target["type"] for target in targets] != [1, 1, 2, 16, 8]:
            raise ValueError("source player target types/order changed")
        rows.append({"role": "gameplay" if name == "Player" else "rendering",
                     "componentFileId": ident, "targets": targets})
    rows.sort(key=lambda row: 0 if row["role"] == "gameplay" else 1)
    return {"version": 1, "source": "Assets/Scenes/MainScene.unity",
            "sceneSha256": hashlib.sha256(data).hexdigest(), "players": rows}


def main():
    output = json.dumps(extract(), indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != output:
            raise ValueError("player shot target artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(output, encoding="utf-8")
    else:
        raise ValueError("usage: extract_player_shot_targets.py [--check]")
    print("2 players, 10 serialized shot targets")


if __name__ == "__main__":
    main()
