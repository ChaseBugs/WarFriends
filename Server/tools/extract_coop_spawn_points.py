"""Extract co-op player and AI spawn anchors from the five source mission scenes."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path

from extract_army_spawn_points import COLLECTION_GUID, COLLECTIONS, MAP_GUID
from extract_army_spawn_points import field, mul, ref, transform_chain


ROOT = Path(__file__).resolve().parents[2]
SCENES = ROOT / "Clients/ExportedProject/Assets/Scenes"
METAS = ROOT / "Clients/ExportedProject/Assets/Scripts"
MISSION_CATALOG = ROOT / "Server/content/recovered-mission-catalog.json"
OUTPUT = ROOT / "Server/content/recovered-coop-spawn-points.json"
PLAYER_POINT_GUID = "8e9e336d4e9d43c6305ae38d9233296d"


def world_rotation(chain):
    rotation = [0.0, 0.0, 0.0, 1.0]
    for transform in reversed(chain):
        rotation = mul(rotation, transform["rotation"])
    length = math.sqrt(sum(value * value for value in rotation))
    if not math.isfinite(length) or length < 0.5 or length > 2:
        raise ValueError("invalid co-op source rotation")
    return [value / length for value in rotation]


def game_object_transform(blocks, component):
    game_object_id = ref(component, "m_GameObject")
    game_object = blocks[game_object_id][1]
    match = re.search(r"^  - 4: \{fileID: (\d+)\}$", game_object, re.M)
    if not match:
        raise ValueError("spawn point has no Transform")
    transform_id = int(match.group(1))
    chain, world_position = transform_chain(blocks, transform_id)
    return game_object_id, transform_id, world_position, world_rotation(chain)


def player_positions(blocks, definition):
    section = definition.split("  playersPositions:\n", 1)[1].split(
        "  spawnAreas:", 1
    )[0]
    rows = re.findall(
        r"  - point: \{fileID: (\d+)\}\n"
        r"    fraction: (\d+)\n"
        r"    cameraPath: \{fileID: \d+\}\n"
        r"    mainPosition: ([01])\n",
        section,
    )
    if len(rows) != 4 or sum(int(main) for _, _, main in rows) != 2:
        raise ValueError("co-op scene has an unexpected allied defend-position set")
    result = []
    for index, (component_id, fraction, main) in enumerate(rows):
        component = blocks[int(component_id)][1]
        if PLAYER_POINT_GUID not in component or int(fraction) != 2:
            raise ValueError("co-op defend point is not an allied PlayerPoint")
        game_object_id, transform_id, position, rotation = game_object_transform(
            blocks, component)
        result.append({
            "index": index,
            "componentFileId": int(component_id),
            "gameObjectFileId": game_object_id,
            "transformFileId": transform_id,
            "main": bool(int(main)),
            "worldPosition": position,
            "worldRotation": rotation,
        })
    return result


def spawn_points(blocks, definition, script_types):
    result = []
    for category in COLLECTIONS:
        collection_id = ref(definition, category)
        if collection_id == 0:
            if category != "spawnPointsCollectionAssaultHelis":
                raise ValueError(f"required co-op collection is absent: {category}")
            continue
        collection = blocks[collection_id][1]
        if COLLECTION_GUID not in collection:
            raise ValueError(f"wrong collection component: {category}")
        section = collection.split("  spawnPoints:\n", 1)[1]
        ids = [int(value) for value in re.findall(
            r"^  - \{fileID: (\d+)\}$", section, re.M
        )]
        if not ids:
            raise ValueError(f"empty co-op collection: {category}")
        for order, component_id in enumerate(ids):
            component = blocks[component_id][1]
            guid = re.search(r"guid: ([0-9a-f]{32})", field(component, "m_Script"))
            kind = script_types.get(guid.group(1)) if guid else None
            if kind is None or not kind.startswith("SpawnPoint"):
                raise ValueError("unresolved source spawn component")
            fraction = int(field(component, "mFraction"))
            if fraction not in (1, 2):
                raise ValueError("invalid source spawn fraction")
            game_object_id, transform_id, position, rotation = game_object_transform(
                blocks, component
            )
            result.append({
                "collection": category,
                "order": order,
                "componentFileId": component_id,
                "componentType": kind,
                "fraction": fraction,
                "gameObjectFileId": game_object_id,
                "transformFileId": transform_id,
                "worldPosition": position,
                "worldRotation": rotation,
            })
    if len({row["componentFileId"] for row in result}) != len(result):
        raise ValueError("duplicate co-op spawn component")
    return result


def extract_map(entry, script_types):
    path = SCENES / (entry["scene"] + ".unity")
    scene_bytes = path.read_bytes()
    digest = hashlib.sha256(scene_bytes).hexdigest()
    if digest != entry["sceneSha256"]:
        raise ValueError(f"co-op map changed: {path}")
    scene = scene_bytes.decode("utf-8-sig")
    blocks = {
        int(match.group(2)): (int(match.group(1)), match.group(3))
        for match in re.finditer(
            r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
            scene,
            re.M | re.S,
        )
    }
    definitions = [
        (id, block) for id, (kind, block) in blocks.items()
        if kind == 114 and f"guid: {MAP_GUID}" in block
    ]
    if len(definitions) != 1:
        raise ValueError("expected one MapDefinition in co-op scene")
    definition_id, definition = definitions[0]
    return {
        "stage": entry["stage"],
        "scene": entry["scene"],
        "sceneSha256": digest,
        "mapDefinitionFileId": definition_id,
        "playerPositions": player_positions(blocks, definition),
        "spawnPoints": spawn_points(blocks, definition, script_types),
    }


def main():
    catalog = json.loads(MISSION_CATALOG.read_text(encoding="utf-8"))
    script_types = {}
    for meta in METAS.rglob("SpawnPoint*.cs.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$", meta.read_text(
            encoding="utf-8-sig"
        ), re.M)
        if match:
            script_types[match.group(1)] = meta.name.removesuffix(".cs.meta")
    maps = [extract_map(entry, script_types) for entry in catalog["maps"]]
    serialized = json.dumps({"version": 2, "maps": maps}, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != serialized:
            raise ValueError("co-op spawn artifact differs from source scenes")
    elif not sys.argv[1:]:
        OUTPUT.write_text(serialized, encoding="utf-8")
    else:
        raise ValueError("usage: extract_coop_spawn_points.py [--check]")
    print(f"{len(maps)} co-op maps, {sum(len(m['spawnPoints']) for m in maps)} spawn points")


if __name__ == "__main__":
    main()
