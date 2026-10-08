"""Extract ordered co-op AI destinations from the recovered mission scenes.

These are destination candidates, not a complete AI movement simulation.
EnemyPointObstacle chooses a random position along its source segment.
"""

import hashlib
import json
import math
import re
import sys
from collections import Counter
from pathlib import Path

from extract_army_spawn_points import field, ref, rotate, transform_chain
from extract_coop_spawn_points import (
    MAP_GUID, METAS, MISSION_CATALOG, SCENES,
    game_object_transform,
)


ROOT = Path(__file__).resolve().parents[2]
OUTPUT = ROOT / "Server/content/recovered-coop-enemy-points.json"
COLLECTION_GUID = "d9d8bf95b76e06b83a10740c1390212a"
EXPECTED_TYPES = Counter({
    "EnemyPointObstacle": 58,
    "EnemyPointMinigunner": 20,
    "EnemyPointEngineerTurret": 20,
    "EnemyPointSwat": 10,
    "EnemyPointCorner": 5,
    "EnemyPointRusherSpare": 4,
    "EnemyPointGunslinger": 4,
    "EnemyPointMortar": 4,
    "EnemyPointMech": 4,
    "EnemyPointRusher": 1,
})


def blocks_in(scene):
    return {
        int(match.group(2)): (int(match.group(1)), match.group(3))
        for match in re.finditer(
            r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
            scene, re.M | re.S,
        )
    }


def transform_position(blocks, transform_id):
    if transform_id == 0 or blocks[transform_id][0] != 4:
        raise ValueError("enemy point references a missing Transform")
    _, position = transform_chain(blocks, transform_id)
    return position


def obstacle_segment(blocks, component):
    start_id = ref(component, "obstacleStart")
    end_id = ref(component, "obstacleEnd")
    start = transform_position(blocks, start_id)
    end = transform_position(blocks, end_id)
    if math.dist(start, end) <= 0.01 or math.dist(start, end) > 100:
        raise ValueError("co-op obstacle destination has an invalid segment")
    return {
        "startTransformFileId": start_id,
        "endTransformFileId": end_id,
        "start": start,
        "end": end,
    }


def extract_map(map_entry, script_types):
    scene_path = SCENES / (map_entry["scene"] + ".unity")
    source = scene_path.read_bytes()
    digest = hashlib.sha256(source).hexdigest()
    if digest != map_entry["sceneSha256"]:
        raise ValueError(f"co-op scene changed: {scene_path}")
    blocks = blocks_in(source.decode("utf-8-sig"))
    definitions = [
        (file_id, block) for file_id, (kind, block) in blocks.items()
        if kind == 114 and f"guid: {MAP_GUID}" in block
    ]
    if len(definitions) != 1:
        raise ValueError("expected one source MapDefinition")
    definition_id, definition = definitions[0]
    floor_transform_id = ref(definition, "floorTransform")
    floor_position = transform_position(blocks, floor_transform_id)
    collection_id = ref(definition, "enemyPointsCollection")
    collection = blocks[collection_id][1]
    if f"guid: {COLLECTION_GUID}" not in collection:
        raise ValueError("wrong enemy point collection type")
    point_ids = [int(value) for value in re.findall(
        r"^  - \{fileID: (\d+)\}$",
        collection.split("  enemyPoints:\n", 1)[1], re.M,
    )]
    if not point_ids or len(point_ids) != len(set(point_ids)):
        raise ValueError("empty or duplicate enemy point collection")

    points = []
    for order, component_id in enumerate(point_ids):
        kind, component = blocks[component_id]
        script = re.search(r"guid: ([0-9a-f]{32})", field(component, "m_Script"))
        point_type = script_types.get(script.group(1)) if script else None
        if kind != 114 or point_type is None:
            raise ValueError("unresolved co-op EnemyPoint component")
        game_object_id, transform_id, position, rotation = \
            game_object_transform(blocks, component)
        fraction = int(field(component, "mFraction"))
        if fraction != 1:
            raise ValueError("co-op AI destination is not enemy-owned")
        row = {
            "order": order,
            "componentFileId": component_id,
            "componentType": point_type,
            "gameObjectFileId": game_object_id,
            "transformFileId": transform_id,
            "fraction": fraction,
            "worldPosition": position,
            "worldRotation": rotation,
            "positionKind": "fixed",
        }
        if point_type == "EnemyPointObstacle":
            row["positionKind"] = "segment"
            row["segment"] = obstacle_segment(blocks, component)
        elif point_type == "EnemyPointCorner":
            direction = field(component, "direction")
            coordinates = [float(value) for value in re.findall(
                r"[xyz]: (-?[0-9.]+)", direction,
            )]
            right_side = int(field(component, "rightSide"))
            if (len(coordinates) != 3 or
                    not all(math.isfinite(value) for value in coordinates) or
                    math.dist(coordinates, [0.0, 0.0, 0.0]) < 0.01 or
                    right_side not in (0, 1)):
                raise ValueError("invalid source corner direction or side")
            row["cornerDirection"] = coordinates
            row["cornerRightSide"] = bool(right_side)
        elif point_type == "EnemyPointEngineerTurret":
            # The Client property returns transform.position - forward * 0.2.
            forward = rotate(rotation, [0.0, 0.0, 1.0])
            row["effectivePosition"] = [
                position[axis] - forward[axis] * 0.2 for axis in range(3)
            ]
        points.append(row)
    return {
        "stage": map_entry["stage"],
        "scene": map_entry["scene"],
        "sceneSha256": digest,
        "mapDefinitionFileId": definition_id,
        "floorTransformFileId": floor_transform_id,
        "floorWorldPosition": floor_position,
        "collectionComponentFileId": collection_id,
        "points": points,
    }


def main():
    missions = json.loads(MISSION_CATALOG.read_text(encoding="utf-8"))
    script_types = {}
    for meta in METAS.rglob("EnemyPoint*.cs.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$",
                          meta.read_text(encoding="utf-8-sig"), re.M)
        if match and meta.name != "EnemyPointsCollection.cs.meta":
            script_types[match.group(1)] = meta.name.removesuffix(".cs.meta")
    maps = [extract_map(entry, script_types) for entry in missions["maps"]]
    counts = Counter(point["componentType"] for map_row in maps
                     for point in map_row["points"])
    if counts != EXPECTED_TYPES:
        raise ValueError(f"co-op enemy point inventory changed: {counts}")
    content = json.dumps({"version": 1, "maps": maps}, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("co-op enemy points differ from source scenes")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8")
    else:
        raise ValueError("usage: extract_coop_enemy_points.py [--check]")
    print(f"{len(maps)} co-op maps, {sum(counts.values())} enemy points")


if __name__ == "__main__":
    main()
