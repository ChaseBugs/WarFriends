"""Extract BotMission player starts from the five multiplayer scenes."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path

from extract_army_spawn_points import MAP_GUID, field, mul, ref, transform_chain
from extract_coop_spawn_points import PLAYER_POINT_GUID


ROOT = Path(__file__).resolve().parents[2]
SCENES = ROOT / "Clients/ExportedProject/Assets/Scenes"
MISSIONS = ROOT / "Server/content/recovered-mission-catalog.json"
OUTPUT = ROOT / "Server/content/recovered-coop-boss-anchors.json"


def world_rotation(chain):
    rotation = [0.0, 0.0, 0.0, 1.0]
    for transform in reversed(chain):
        rotation = mul(rotation, transform["rotation"])
    if not all(math.isfinite(value) for value in rotation) or \
            abs(sum(value * value for value in rotation) - 1) > 0.001:
        raise ValueError("invalid boss defend-point rotation")
    return rotation


def extract_map(source):
    path = SCENES / (source["scene"] + ".unity")
    scene_bytes = path.read_bytes()
    if hashlib.sha256(scene_bytes).hexdigest() != source["sceneSha256"]:
        raise ValueError(f"boss mission scene changed: {path}")
    scene = scene_bytes.decode("utf-8-sig")
    blocks = {
        int(match.group(2)): (int(match.group(1)), match.group(3))
        for match in re.finditer(
            r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
            scene, re.M | re.S)
    }
    definitions = [(id, block) for id, (kind, block) in blocks.items()
                   if kind == 114 and f"guid: {MAP_GUID}" in block]
    if len(definitions) != 1:
        raise ValueError("boss scene needs one MapDefinition")
    definition_id, definition = definitions[0]
    section = definition.split("  playersPositions:\n", 1)[1].split(
        "  spawnAreas:", 1)[0]
    entries = re.findall(
        r"  - point: \{fileID: (\d+)\}\n"
        r"    fraction: (\d+)\n"
        r"    cameraPath: \{fileID: \d+\}\n"
        r"    mainPosition: ([01])\n", section)
    if len(entries) != 8 or [int(row[1]) for row in entries] != [1] * 4 + [2] * 4:
        raise ValueError("boss scene needs four ordered shields per fraction")

    positions = []
    for index, (component_id, fraction, main) in enumerate(entries):
        component = blocks[int(component_id)][1]
        if PLAYER_POINT_GUID not in component:
            raise ValueError("boss shield is not a PlayerPoint")
        game_object_id = ref(component, "m_GameObject")
        game_object = blocks[game_object_id][1]
        transform_id = int(re.search(
            r"^  - 4: \{fileID: (\d+)\}$", game_object, re.M).group(1))
        chain, location = transform_chain(blocks, transform_id)
        positions.append({"index": index, "fraction": int(fraction),
                          "main": main == "1",
                          "componentFileId": int(component_id),
                          "gameObjectFileId": game_object_id,
                          "transformFileId": transform_id,
                          "worldPosition": location,
                          "worldRotation": world_rotation(chain)})
    if [row["index"] for row in positions if row["fraction"] == 1 and row["main"]] != [1, 2] or \
            [row["index"] for row in positions if row["fraction"] == 2 and row["main"]] != [5, 6]:
        raise ValueError("boss main defend-point order changed")
    return {"stage": source["stage"], "scene": source["scene"],
            "sceneSha256": source["sceneSha256"],
            "mapDefinitionFileId": definition_id,
            "playerPositions": positions}


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_boss_anchors.py [--check]")
    missions = json.loads(MISSIONS.read_bytes())
    maps = [extract_map(source) for source in missions["bossMaps"]]
    artifact = {"version": 1,
                "missionSourceSha256": missions["sourceSha256"],
                "maps": maps}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("boss anchors differ from recovered scenes")
    else:
        OUTPUT.write_bytes(encoded)
    print("five multiplayer boss maps with eight ordered shield anchors each")


if __name__ == "__main__":
    main()
